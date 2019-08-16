using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using TeamTickets.Entity;

namespace TeamTickets
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private async void btn_AppTunnel_Click(object sender, EventArgs e)
        {
            PhoneNumForm phone = new PhoneNumForm();
            string phoneNum = "";
            phone.translatePhoneNum = ((num) => { phoneNum = num; });
            var result = phone.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                var err = await isVip(phoneNum);
                
                if (err.code==0)
                {
                    IdentityCollectionForm idForm = new IdentityCollectionForm(phoneNum);
                    idForm.ShowDialog();
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MyMessageBox msb = new MyMessageBox( err.msg);
                    msb.Show();
                    //MessageBox.Show(err.msg);
                }
            }
        }

        private void btn_windowTunnel_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            IdentityCollectionForm idForm = new IdentityCollectionForm();
            idForm.ShowDialog();
            this.Cursor = Cursors.Default;
        }


        private async Task<HttpErr> isVip(string phoneNum)
        {
            HttpErr err = new HttpErr();
            ServicePointManager.ServerCertificateValidationCallback+= (sender, cert, chain, sslPolicyErrors) => true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ConstInfo.URL_Base_Phone);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("phoneNo", phoneNum);

            var response = await client.PostAsync(ConstInfo.URL_Phone, new FormUrlEncodedContent(dict));
            var result = await response.Content.ReadAsStringAsync();
            try
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    err = JsonConvert.DeserializeObject<HttpErr>(result);
                }
                else
                {
                    err.code = -2;
                    err.msg = result;
                }
            }
            catch (Exception e)
            {
                err.code = -2;
                err.msg = e.Message+result;
            }
            return err;
        }
    }
}
