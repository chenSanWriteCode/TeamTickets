using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using TeamTickets.Entity;
using TeamTickets.GroupPassengersService;
using TeamTickets.Service;

namespace TeamTickets
{
    public partial class IdentityCollectionForm : Form
    {
        private string phoneNum { get; set; }
        private ReadID IDRead;
        private string currentDate;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams paras = base.CreateParams;
                paras.ExStyle |= 0x02000000;
                return paras;
            }
        }
        public IdentityCollectionForm(string phoneNum = "")
        {
            InitializeComponent();
            this.phoneNum = phoneNum;
            changeLabelAttation();

            changeLabelSum();
            labelStatus.Text = "";
            l_sum.Text = $"当前已登记 0人 / 共20人 【 0元票: 0人 | 半价票: 0人 | 导游票: 0人】";
            currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            createId(0);
            IDRead = new ReadID();
            IDRead.receivedID = receivedData;
            try
            {
                IDRead.start();
            }
            catch (Exception err)
            {
                this.labelStatus.Text = "身份证读卡器连接失败，请检查！";
            }

        }
        private string createId(int increase = 1)
        {
            ConfigXmlDocument doc = new ConfigXmlDocument();
            doc.Load(ConstInfo.TicketID_Path);
            var date = doc.SelectSingleNode("TicketID/date").InnerText;
            string ticketId = "";
            if (date != currentDate)
            {
                var dateNode = doc.SelectSingleNode("TicketID/date");
                dateNode.InnerText = currentDate;
                ticketId = "0000";
            }
            else
            {
                var id = doc.SelectSingleNode("TicketID/id").InnerText;
                var currentID = Convert.ToInt32(id) + increase;
                ticketId = currentID.ToString().PadLeft(4, '0');
            }
            doc.SelectSingleNode("TicketID/id").InnerText = ticketId;
            doc.Save(ConstInfo.TicketID_Path);
            return currentDate + "-" + ticketId;
        }
        private void receivedData(IDCard card)
        {
            if (!checkDGV())
            {
                MyMessageBox msg = new MyMessageBox($"单次最多添加20人!");
                msg.ShowDialog();
                return;
            }
            //TODO:身份证合法性校验（可能存在读取身份证号错位的情况）
            if (!checkIDNum(card.Code))
            {
                MyMessageBox msg = new MyMessageBox($"{card.Code} 身份证不合法，请重新采集");
                msg.ShowDialog();
                return;
            }
            //TODO: 身份证地址判断 新疆，西藏

            //TODO： 身份证民族判断，维族特殊处理 
            addDGVRow(card);
        }

        private bool addDGVRow(IDCard card)
        {

            foreach (DataGridViewRow item in dgv_idData.Rows)
            {
                if (item.Cells[2].Value.ToString() == card.Code)
                {
                    MyMessageBox msg = new MyMessageBox($"{card.Code}已添加");
                    msg.ShowDialog();
                    return false;
                };
            }
            dgv_idData.BeginInvoke(new Action(() =>
            {
                int index = dgv_idData.Rows.Add();
                dgv_idData.Rows[index].Cells[0].Value = index + 1;
                dgv_idData.Rows[index].Cells[1].Value = card.Name;
                dgv_idData.Rows[index].Cells[2].Value = card.Code;
                dgv_idData.ClearSelection();
            }));
            return true;
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            dgv_idData.Rows.Clear();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            var collection = dgv_idData.SelectedRows;
            if (collection.Count == 1)
            {
                dgv_idData.Rows.Remove(collection[0]);
            }
        }

        private async Task<HttpErr> saveInfo()
        {
            HttpErr err = new HttpErr();
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(ConstInfo.URL_Base_Save);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            PassengerInfoParam param = new PassengerInfoParam()
            {
                deptId = ConstInfo.harbour,
                account = phoneNum,
                groupPassengerInfo = new List<PassengerInfo>()
            };
            foreach (DataGridViewRow item in dgv_idData.Rows)
            {
                param.groupPassengerInfo.Add(
                    new PassengerInfo
                    {
                        cardName = item.Cells["id_name"].Value.ToString(),
                        cardNo = item.Cells["id_num"].Value.ToString()
                    });
            }

            //dict.Add("jsonStr", JsonConvert.SerializeObject(param));
            //client.DefaultRequestHeaders.Add("SOAPAction", "TransactionOntimeService");
            //var response = await client.PostAsync(ConstInfo.URL_Save, new FormUrlEncodedContent(dict));
            //var result = await response.Content.ReadAsStringAsync();
            try
            {
                GroupCertificateServiceClient saveClient = new GroupCertificateServiceClient();
                var saveResponse = await saveClient.groupCertificateSaveAsync(JsonConvert.SerializeObject(param));
                err = JsonConvert.DeserializeObject<HttpErr>(saveResponse.Body.@return); 
                //if (response.StatusCode == HttpStatusCode.OK)
                //{
           
                //    err = JsonConvert.DeserializeObject<HttpErr>(result);
                //}
                //else
                //{
                //    err.code = -1;
                //    err.msg = result;
                //}
            }
            catch (Exception e)
            {
                err.code = -1;
                err.msg = e.Message + err;
            }

            return err;
        }

        private DateTime convertToDateTime(string str)
        {
            DateTime convertD = DateTime.Now;
            DateTimeFormatInfo format = new DateTimeFormatInfo();
            format.LongDatePattern = "yyyy-MM-dd HH:mm:ss";
            convertD = DateTime.Parse(str, format);
            return convertD;
        }
        private async void btn_Print_Click(object sender, EventArgs e)
        {
            if (dgv_idData.Rows.Count < 10)
            {
                MyMessageBox msg = new MyMessageBox($"单张团体票最少10人");
                msg.ShowDialog();
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            btn_Print.Enabled = false;
            var serviceResult = await saveInfo();
            if (serviceResult.code != 1)
            {
                MyMessageBox msg = new MyMessageBox(serviceResult.msg);
                msg.Show();
                return;
            }
            var data = (TicketReturnInfo)serviceResult.retval;
            var startDay = convertToDateTime(data.startTime);
            var endDay = convertToDateTime(data.endTime);
            var diffDay = (endDay.Date - startDay.Date).Days;
            TicketCode ticket = new TicketCode()
            {
                Id = createId(),
                Code = data.certificateNum,
                AffectDay = diffDay,
                AffectStr = startDay.ToString("yyyy-MM-dd") + "    至    " + endDay.ToString("yyyy-MM-dd"),
                TeamCount = dgv_idData.Rows.Count,
                BabyCount = Convert.ToInt32(tb_baby.Text),
                HalfCount = Convert.ToInt32(tb_child.Text),
                GuideCount = Convert.ToInt32(tb_guid.Text)
            };
            PrintService service = new PrintService();
            var result = service.print(ticket);
            this.Cursor = Cursors.Default;
            btn_Print.Enabled = true;
            if (result.Success)
            {
                IDConfirmForm confirm = new IDConfirmForm();
                if (confirm.ShowDialog() == DialogResult.OK)
                {
                    dgv_idData.Rows.Clear();
                    tb_baby.Text = "0";
                    tb_child.Text = "0";
                    tb_guid.Text = "0";
                    l_sum.Text = $"当前已登记 0人 / 共20人 【 0元票: 0人 | 半价票: 0人 | 导游票: 0人】";
                }
                else
                {
                    try
                    {
                        IDRead.end();
                    }
                    catch (Exception err)
                    {

                    }
                    this.Close();
                }
            }
            else
            {
                MyMessageBox msg = new MyMessageBox("出现错误，请重新打印" + result.Message);
                msg.ShowDialog();
                //MessageBox.Show("出现错误，请重新打印" + result.Message);
            }
        }

        private void btn_idAdd_ok_Click(object sender, EventArgs e)
        {
            if (!checkDGV())
            {
                MyMessageBox msg = new MyMessageBox("单次最多添加20人!");
                msg.ShowDialog();
                //MessageBox.Show("单次最多添加20人");
                return;
            }
            if (checkIDNum(tb_idNum.Text))
            {
                IDCard idInfo = new IDCard() { Code = tb_idNum.Text };
                var result = addDGVRow(idInfo);
                if (result)
                {
                    //MyMessageBox msg = new MyMessageBox("添加成功");
                    //msg.Show();
                    //MessageBox.Show("添加成功");
                }
                tb_idNum.Clear();
            }
            else
            {
                MyMessageBox msg = new MyMessageBox("请输入正确身份证号");
                msg.ShowDialog();
                //MessageBox.Show();
            }
        }
        private void btn_idBackspace_Click(object sender, EventArgs e)
        {
            string content = tb_idNum.Text;
            if (content.Length > 0)
            {
                tb_idNum.Text = content.Substring(0, content.Length - 1);
            }
        }
        private bool checkDGV()
        {
            return dgv_idData.Rows.Count < 20;
        }
        private bool checkIDNumIs18()
        {
            return tb_idNum.Text.Length == 18;
        }
        //身份证合法性判断
        private bool checkIDNum(string idNum)
        {
            Regex regId = new Regex(@"^\d{17}(\d|x)$", RegexOptions.IgnoreCase);
            if (idNum.Length != 18)
            {
                return false;
            }
            else
            {
                if (!regId.IsMatch(idNum))
                {
                    return false;
                }
                else
                {
                    int iS = 0;
                    int[] iW = new int[] { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
                    string LastCode = "10X98765432";
                    for (int i = 0; i < 17; i++)
                    {
                        iS += int.Parse(idNum.Substring(i, 1)) * iW[i];
                    }
                    int iY = iS % 11;
                    if (idNum.Substring(17, 1) != LastCode.Substring(iY, 1))
                        return false;
                    return true;
                }
            }
        }
        private void changeLabelAttation()
        {
            var notices = ConfigurationManager.AppSettings.AllKeys.Where(x => x.Contains("Notice_")).OrderBy(x => x).ToList();
            StringBuilder notice = new StringBuilder();
            notice.AppendLine("注意事项：");
            foreach (var item in notices)
            {
                notice.AppendLine(ConfigurationManager.AppSettings[item]);
            }
            l_attition.Text = notice.ToString();
        }
        private void changeLabelSum()
        {
            l_sum.Text = $"当前已登记{dgv_idData.Rows.Count}人 / 共20人 【 0元票: {tb_baby.Text}人 | 半价票:{tb_child.Text}人 | 导游票:{tb_guid.Text}人】";
        }
        #region 0-9+x 键盘
        private void appendText(int num)
        {
            tb_idNum.AppendText(checkIDNumIs18() ? "" : num.ToString());
        }
        private void appendText_X()
        {
            tb_idNum.AppendText(tb_idNum.Text.Length == 17 ? "X" : "");
        }
        private void btn_1_Click(object sender, EventArgs e)
        {
            appendText(1);
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            appendText(2);
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            appendText(3);
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            appendText(4);
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            appendText(5);
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            appendText(6);
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            appendText(7);
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            appendText(8);
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            appendText(9);
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            appendText(0);
        }


        private void btn_x_Click(object sender, EventArgs e)
        {
            appendText_X();
        }

        #endregion

        private void dgv_idData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            changeLabelSum();
        }
        private void dgv_idData_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            changeLabelSum();
        }

        #region 0元票、半价票、导游票的加减法
        private string oper(string text, Operation op)
        {
            int countOld = Convert.ToInt32(text);
            int countNew = 0;
            switch (op)
            {
                case Operation.Jian:
                    countNew = countOld - 1;
                    break;
                case Operation.Jia:
                    countNew = countOld + 1;
                    break;
            }
            if (countNew >= 0)
            {
                return countNew.ToString();
            }
            else
            {
                return countOld.ToString();
            }
        }

        private void btn_baby_jian_Click(object sender, EventArgs e)
        {
            tb_baby.Text = oper(tb_baby.Text, Operation.Jian);
            changeLabelSum();
        }

        private void btn_baby_jia_Click(object sender, EventArgs e)
        {
            tb_baby.Text = oper(tb_baby.Text, Operation.Jia);
            changeLabelSum();
        }

        private void btn_child_jian_Click(object sender, EventArgs e)
        {
            tb_child.Text = oper(tb_child.Text, Operation.Jian);
            changeLabelSum();
        }

        private void btn_child_jia_Click(object sender, EventArgs e)
        {
            tb_child.Text = oper(tb_child.Text, Operation.Jia);
            changeLabelSum();
        }

        private void btn_guide_jian_Click(object sender, EventArgs e)
        {
            tb_guid.Text = oper(tb_guid.Text, Operation.Jian);
            changeLabelSum();
        }

        private void btn_guide_jia_Click(object sender, EventArgs e)
        {
            tb_guid.Text = oper(tb_guid.Text, Operation.Jia);
            changeLabelSum();
        }
        #endregion

        private void btnHome_Click(object sender, EventArgs e)
        {
            try
            {
                IDRead.end();
            }
            catch (Exception err)
            {

            }
            this.Close();
        }


    }

    public enum Operation
    {
        Jian = 0,
        Jia
    }
}
