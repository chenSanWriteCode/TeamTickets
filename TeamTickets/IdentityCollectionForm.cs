using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using TeamTickets.Entity;
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
        public IdentityCollectionForm(string phoneNum = null)
        {
            InitializeComponent();
            this.phoneNum = phoneNum;
            changeLabelAttation();

            changeLabelSum(); 
            labelStatus.Text = "";

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
        private string createId(int increase=1)
        {
            ConfigXmlDocument doc = new ConfigXmlDocument();
            doc.Load(ConstInfo.TicketID_Path);
            var date = doc.SelectSingleNode("TicketID/date").InnerText;
            string ticketId = "";
            if (date!=currentDate)
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
            return currentDate+"-"+ticketId;
        }
        private void receivedData(IDCard card)
        {
            if (checkDGV())
            {
                addDGVRow(card);
            }
        }

        private bool addDGVRow(IDCard card)
        {

            foreach (DataGridViewRow item in dgv_idData.Rows)
            {
                if (item.Cells[1].Value.ToString() == card.Code)
                {
                    MyMessageBox msg = new MyMessageBox($"{card.Code}已添加");
                    msg.Show();
                    //MessageBox.Show();
                    return false;
                };
            }
            dgv_idData.BeginInvoke(new Action(() =>
            {
                int index = dgv_idData.Rows.Add();
                dgv_idData.Rows[index].Cells[0].Value = card.Name;
                dgv_idData.Rows[index].Cells[1].Value = card.Code;
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
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ConstInfo.URL_Base_Save);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            PassengerInfoParam param = new PassengerInfoParam()
            {
                account = phoneNum,
                groupPassengerInfo = null
            };
            dict.Add("jsonStr", JsonConvert.SerializeObject(param));
            var response = await client.PostAsync(ConstInfo.URL_Save, new FormUrlEncodedContent(dict));
            var result = await response.Content.ReadAsStringAsync();
            try
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    err = JsonConvert.DeserializeObject<HttpErr>(result);
                }
                else
                {
                    err.code = -1;
                    err.msg = result;
                }
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
                msg.Show();
                //MessageBox.Show("单张团体票最少10人");
                return;
            }
            var serviceResult = await saveInfo();
            if (serviceResult.code!=1)
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
                AffectStr = startDay.ToString("yyyy-MM-dd") + "    至    "+ endDay.ToString("yyyy-MM-dd"),
                TeamCount = dgv_idData.Rows.Count,
                BabyCount = Convert.ToInt32(tb_baby.Text),
                HalfCount = Convert.ToInt32(tb_child.Text),
                GuideCount = Convert.ToInt32(tb_guid.Text)
            };
            PrintService service = new PrintService();
            var result = service.print(ticket);
            if (result.Success)
            {
                IDConfirmForm confirm = new IDConfirmForm();
                if (confirm.ShowDialog() == DialogResult.OK)
                {
                    dgv_idData.Rows.Clear();
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
                msg.Show();
                //MessageBox.Show("出现错误，请重新打印" + result.Message);
            }

        }

        private void btn_idAdd_ok_Click(object sender, EventArgs e)
        {
            if (!checkDGV())
            {
                MyMessageBox msg = new MyMessageBox("单次最多添加20人");
                msg.Show();
                //MessageBox.Show("单次最多添加20人");
                return;
            }
            if (checkIDNum())
            {
                IDCard idInfo = new IDCard() { Code = tb_idNum.Text };
                var result = addDGVRow(idInfo);
                if (result)
                {
                    MyMessageBox msg = new MyMessageBox("添加成功");
                    msg.Show();
                    //MessageBox.Show("添加成功");
                }
                tb_idNum.Clear();
            }
            else
            {
                MyMessageBox msg = new MyMessageBox("请输入正确身份证号");
                msg.Show();
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
        private bool checkIDNum()
        {
            return tb_idNum.Text.Length == 18;
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
            tb_idNum.AppendText(checkIDNum() ? "" : num.ToString());
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
