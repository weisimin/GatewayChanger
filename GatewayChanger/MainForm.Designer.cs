namespace GatewayChanger
{
    partial class MainForm
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
            this.tb_log = new System.Windows.Forms.TextBox();
            this.cb_autochange = new System.Windows.Forms.CheckBox();
            this.btn_switch = new System.Windows.Forms.Button();
            this.cb_autoadd = new System.Windows.Forms.CheckBox();
            this.cb_localgateway = new System.Windows.Forms.TextBox();
            this.lbl_localgateway = new System.Windows.Forms.Label();
            this.cb_servergateway = new System.Windows.Forms.Label();
            this.tb_serverip = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tb_log
            // 
            this.tb_log.Location = new System.Drawing.Point(13, 4);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.Size = new System.Drawing.Size(439, 165);
            this.tb_log.TabIndex = 0;
            // 
            // cb_autochange
            // 
            this.cb_autochange.AutoSize = true;
            this.cb_autochange.Location = new System.Drawing.Point(13, 188);
            this.cb_autochange.Name = "cb_autochange";
            this.cb_autochange.Size = new System.Drawing.Size(132, 16);
            this.cb_autochange.TabIndex = 1;
            this.cb_autochange.Text = "外围IP自动切换网关";
            this.cb_autochange.UseVisualStyleBackColor = true;
            this.cb_autochange.CheckedChanged += new System.EventHandler(this.cb_autochange_CheckedChanged);
            // 
            // btn_switch
            // 
            this.btn_switch.Location = new System.Drawing.Point(367, 178);
            this.btn_switch.Name = "btn_switch";
            this.btn_switch.Size = new System.Drawing.Size(75, 23);
            this.btn_switch.TabIndex = 2;
            this.btn_switch.Text = "启动";
            this.btn_switch.UseVisualStyleBackColor = true;
            this.btn_switch.Click += new System.EventHandler(this.btn_switch_Click);
            // 
            // cb_autoadd
            // 
            this.cb_autoadd.AutoSize = true;
            this.cb_autoadd.Location = new System.Drawing.Point(13, 227);
            this.cb_autoadd.Name = "cb_autoadd";
            this.cb_autoadd.Size = new System.Drawing.Size(108, 16);
            this.cb_autoadd.TabIndex = 3;
            this.cb_autoadd.Text = "自动添加到路由";
            this.cb_autoadd.UseVisualStyleBackColor = true;
            this.cb_autoadd.CheckedChanged += new System.EventHandler(this.cb_autoadd_CheckedChanged);
            // 
            // cb_localgateway
            // 
            this.cb_localgateway.Location = new System.Drawing.Point(197, 221);
            this.cb_localgateway.Name = "cb_localgateway";
            this.cb_localgateway.Size = new System.Drawing.Size(139, 21);
            this.cb_localgateway.TabIndex = 4;
            this.cb_localgateway.Text = "192.168.6.254";
            // 
            // lbl_localgateway
            // 
            this.lbl_localgateway.AutoSize = true;
            this.lbl_localgateway.Location = new System.Drawing.Point(138, 227);
            this.lbl_localgateway.Name = "lbl_localgateway";
            this.lbl_localgateway.Size = new System.Drawing.Size(53, 12);
            this.lbl_localgateway.TabIndex = 5;
            this.lbl_localgateway.Text = "本地网关";
            // 
            // cb_servergateway
            // 
            this.cb_servergateway.AutoSize = true;
            this.cb_servergateway.Location = new System.Drawing.Point(142, 189);
            this.cb_servergateway.Name = "cb_servergateway";
            this.cb_servergateway.Size = new System.Drawing.Size(53, 12);
            this.cb_servergateway.TabIndex = 7;
            this.cb_servergateway.Text = "外围网关";
            // 
            // tb_serverip
            // 
            this.tb_serverip.Location = new System.Drawing.Point(201, 183);
            this.tb_serverip.Name = "tb_serverip";
            this.tb_serverip.Size = new System.Drawing.Size(139, 21);
            this.tb_serverip.TabIndex = 6;
            this.tb_serverip.Text = "172.16.3.55";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 281);
            this.Controls.Add(this.cb_servergateway);
            this.Controls.Add(this.tb_serverip);
            this.Controls.Add(this.lbl_localgateway);
            this.Controls.Add(this.cb_localgateway);
            this.Controls.Add(this.cb_autoadd);
            this.Controls.Add(this.btn_switch);
            this.Controls.Add(this.cb_autochange);
            this.Controls.Add(this.tb_log);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.CheckBox cb_autochange;
        private System.Windows.Forms.Button btn_switch;
        private System.Windows.Forms.CheckBox cb_autoadd;
        private System.Windows.Forms.TextBox cb_localgateway;
        private System.Windows.Forms.Label lbl_localgateway;
        private System.Windows.Forms.Label cb_servergateway;
        private System.Windows.Forms.TextBox tb_serverip;
    }
}

