namespace TeamTickets
{
    partial class IDConfirmForm
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
            this.btn_continue = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_continue
            // 
            this.btn_continue.BackgroundImage = global::TeamTickets.Properties.Resources.btn_ok;
            this.btn_continue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_continue.FlatAppearance.BorderSize = 0;
            this.btn_continue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_continue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_continue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_continue.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_continue.Location = new System.Drawing.Point(33, 160);
            this.btn_continue.Name = "btn_continue";
            this.btn_continue.Size = new System.Drawing.Size(151, 61);
            this.btn_continue.TabIndex = 2;
            this.btn_continue.Text = "继续";
            this.btn_continue.UseVisualStyleBackColor = true;
            this.btn_continue.Click += new System.EventHandler(this.btn_continue_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(158, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "保存成功";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(70, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(336, 38);
            this.label2.TabIndex = 0;
            this.label2.Text = "是否继续下个团体采集？";
            // 
            // btn_cancle
            // 
            this.btn_cancle.BackgroundImage = global::TeamTickets.Properties.Resources.btn_cancle;
            this.btn_cancle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_cancle.FlatAppearance.BorderSize = 0;
            this.btn_cancle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_cancle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_cancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancle.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_cancle.Location = new System.Drawing.Point(281, 160);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(151, 61);
            this.btn_cancle.TabIndex = 1;
            this.btn_cancle.Text = "取消";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btn_continue);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_cancle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 257);
            this.panel1.TabIndex = 3;
            // 
            // IDConfirmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(475, 257);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IDConfirmForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IDConfirmForm";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_continue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Panel panel1;
    }
}