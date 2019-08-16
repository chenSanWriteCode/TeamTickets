namespace TeamTickets
{
    partial class HomeForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btn_windowTunnel = new System.Windows.Forms.Button();
            this.btn_AppTunnel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(240, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(549, 86);
            this.label1.TabIndex = 1;
            this.label1.Text = "团体乘客身份采集";
            // 
            // btn_windowTunnel
            // 
            this.btn_windowTunnel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_windowTunnel.BackColor = System.Drawing.Color.Transparent;
            this.btn_windowTunnel.BackgroundImage = global::TeamTickets.Properties.Resources.anniu3;
            this.btn_windowTunnel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_windowTunnel.FlatAppearance.BorderSize = 0;
            this.btn_windowTunnel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_windowTunnel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_windowTunnel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_windowTunnel.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Bold);
            this.btn_windowTunnel.ForeColor = System.Drawing.Color.White;
            this.btn_windowTunnel.Location = new System.Drawing.Point(530, 246);
            this.btn_windowTunnel.Margin = new System.Windows.Forms.Padding(0);
            this.btn_windowTunnel.Name = "btn_windowTunnel";
            this.btn_windowTunnel.Size = new System.Drawing.Size(407, 137);
            this.btn_windowTunnel.TabIndex = 2;
            this.btn_windowTunnel.Text = "导游窗口购票";
            this.btn_windowTunnel.UseVisualStyleBackColor = false;
            this.btn_windowTunnel.Click += new System.EventHandler(this.btn_windowTunnel_Click);
            // 
            // btn_AppTunnel
            // 
            this.btn_AppTunnel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_AppTunnel.BackColor = System.Drawing.Color.Transparent;
            this.btn_AppTunnel.BackgroundImage = global::TeamTickets.Properties.Resources.anniu2;
            this.btn_AppTunnel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_AppTunnel.FlatAppearance.BorderSize = 0;
            this.btn_AppTunnel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_AppTunnel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_AppTunnel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AppTunnel.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_AppTunnel.ForeColor = System.Drawing.Color.White;
            this.btn_AppTunnel.Location = new System.Drawing.Point(65, 246);
            this.btn_AppTunnel.Margin = new System.Windows.Forms.Padding(0);
            this.btn_AppTunnel.Name = "btn_AppTunnel";
            this.btn_AppTunnel.Size = new System.Drawing.Size(407, 137);
            this.btn_AppTunnel.TabIndex = 3;
            this.btn_AppTunnel.Text = "导游App购票";
            this.btn_AppTunnel.UseVisualStyleBackColor = false;
            this.btn_AppTunnel.Click += new System.EventHandler(this.btn_AppTunnel_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(322, 693);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(354, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "技术支持：东方瑞创达电子科技有限公司";
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::TeamTickets.Properties.Resources.timg3VHL8KA2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_windowTunnel);
            this.Controls.Add(this.btn_AppTunnel);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HomeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  首页";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_windowTunnel;
        private System.Windows.Forms.Button btn_AppTunnel;
        private System.Windows.Forms.Label label2;
    }
}

