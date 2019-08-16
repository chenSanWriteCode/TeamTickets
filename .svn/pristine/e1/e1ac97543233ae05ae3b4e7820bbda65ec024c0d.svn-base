using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamTickets
{
    public partial class PhoneNumForm : Form
    {

        public Action<string> translatePhoneNum;
        public PhoneNumForm()
        {
            InitializeComponent();
        }


        #region 窗体圆角的实现        
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                SetWindowRegion();
            }
            else
            {
                this.Region = null;
            }
        }
        public void SetWindowRegion()
        {
            System.Drawing.Drawing2D.GraphicsPath FormPath;
            FormPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            FormPath = GetRoundedRectPath(rect, 20);
            this.Region = new Region(FormPath);
        }        
        /// <summary>      
        /// ///       
        /// /// </summary>   
        /// /// <param name="rect">窗体大小</param>    
        /// /// <param name="radius">圆角大小</param>    
        /// /// <returns></returns>        
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();
            path.AddArc(arcRect, 180, 90);//左上角              
            arcRect.X = rect.Right - diameter;//右上角         
            path.AddArc(arcRect, 270, 90);
            arcRect.Y = rect.Bottom - diameter;// 右下角        
            path.AddArc(arcRect, 0, 90);
            arcRect.X = rect.Left;// 左下角          
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }       
        #endregion
        private void btn_phone_ok_Click(object sender, EventArgs e)
        {
            if (checkPhoneNum())
            {
                this.DialogResult = DialogResult.OK;
                if (translatePhoneNum != null)
                {
                    translatePhoneNum(tb_phoneNum.Text);
                    this.Close();
                }
            }
            else
            {
                MyMessageBox msb = new MyMessageBox(this,"请输入完整手机号");
                msb.Show();
            }
        }
        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private bool checkPhoneNum()
        {
            return tb_phoneNum.Text.Length == 11;
        }
        private void appendText(int num)
        {
            tb_phoneNum.AppendText(checkPhoneNum()?"":num.ToString());
        }
        #region 0-9 键盘
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
        #endregion
        private void btn_clear_Click(object sender, EventArgs e)
        {
            tb_phoneNum.Clear();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            string content = tb_phoneNum.Text;
            if (content.Length>0)
            {
                tb_phoneNum.Text = content.Substring(0, content.Length - 1);
            }
        }

        
    }
}
