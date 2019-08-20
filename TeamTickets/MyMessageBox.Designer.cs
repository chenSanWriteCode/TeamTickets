namespace TeamTickets
{
    partial class MyMessageBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyMessageBox));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_ok = new System.Windows.Forms.Button();
            this.rtbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::TeamTickets.Properties.Resources.info;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(116, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(60, 60);
            this.panel1.TabIndex = 0;
            this.panel1.Resize += new System.EventHandler(this.Form1_Resize);
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.Transparent;
            this.btn_ok.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_ok.BackgroundImage")));
            this.btn_ok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ok.FlatAppearance.BorderSize = 0;
            this.btn_ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ok.ForeColor = System.Drawing.Color.White;
            this.btn_ok.Location = new System.Drawing.Point(62, 176);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(175, 68);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            this.btn_ok.Resize += new System.EventHandler(this.Form1_Resize);
            // 
            // rtbox
            // 
            this.rtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbox.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold);
            this.rtbox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rtbox.Location = new System.Drawing.Point(23, 106);
            this.rtbox.Multiline = true;
            this.rtbox.Name = "rtbox";
            this.rtbox.Size = new System.Drawing.Size(254, 64);
            this.rtbox.TabIndex = 5;
            this.rtbox.Text = "提示信息";
            this.rtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MyMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::TeamTickets.Properties.Resources.mbback2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(300, 273);
            this.Controls.Add(this.rtbox);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "MyMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyMessageBox";
            this.TopMost = true;
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.TextBox rtbox;
    }
}