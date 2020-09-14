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
            this.cb_autochange = new System.Windows.Forms.CheckBox();
            this.btn_switch = new System.Windows.Forms.Button();
            this.cb_autoadd = new System.Windows.Forms.CheckBox();
            this.tb_localgateway = new System.Windows.Forms.TextBox();
            this.lbl_localgateway = new System.Windows.Forms.Label();
            this.cb_servergateway = new System.Windows.Forms.Label();
            this.tb_serverip = new System.Windows.Forms.TextBox();
            this.lbl_excuteip = new System.Windows.Forms.Label();
            this.tb_excuteip = new System.Windows.Forms.TextBox();
            this.tb_setserverdefault = new System.Windows.Forms.Button();
            this.btn_importchina = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_autochange
            // 
            this.cb_autochange.AutoSize = true;
            this.cb_autochange.Location = new System.Drawing.Point(30, 12);
            this.cb_autochange.Name = "cb_autochange";
            this.cb_autochange.Size = new System.Drawing.Size(132, 16);
            this.cb_autochange.TabIndex = 1;
            this.cb_autochange.Text = "外围IP自动切换网关";
            this.cb_autochange.UseVisualStyleBackColor = true;
            this.cb_autochange.CheckedChanged += new System.EventHandler(this.cb_autochange_CheckedChanged);
            // 
            // btn_switch
            // 
            this.btn_switch.Enabled = false;
            this.btn_switch.Location = new System.Drawing.Point(29, 90);
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
            this.cb_autoadd.Location = new System.Drawing.Point(30, 68);
            this.cb_autoadd.Name = "cb_autoadd";
            this.cb_autoadd.Size = new System.Drawing.Size(132, 16);
            this.cb_autoadd.TabIndex = 3;
            this.cb_autoadd.Text = "自动添加到本地路由";
            this.cb_autoadd.UseVisualStyleBackColor = true;
            this.cb_autoadd.CheckedChanged += new System.EventHandler(this.cb_autoadd_CheckedChanged);
            // 
            // tb_localgateway
            // 
            this.tb_localgateway.Location = new System.Drawing.Point(255, 62);
            this.tb_localgateway.Name = "tb_localgateway";
            this.tb_localgateway.Size = new System.Drawing.Size(139, 21);
            this.tb_localgateway.TabIndex = 4;
            this.tb_localgateway.Text = "192.168.6.254";
            // 
            // lbl_localgateway
            // 
            this.lbl_localgateway.AutoSize = true;
            this.lbl_localgateway.Location = new System.Drawing.Point(196, 68);
            this.lbl_localgateway.Name = "lbl_localgateway";
            this.lbl_localgateway.Size = new System.Drawing.Size(53, 12);
            this.lbl_localgateway.TabIndex = 5;
            this.lbl_localgateway.Text = "本地网关";
            // 
            // cb_servergateway
            // 
            this.cb_servergateway.AutoSize = true;
            this.cb_servergateway.Location = new System.Drawing.Point(198, 13);
            this.cb_servergateway.Name = "cb_servergateway";
            this.cb_servergateway.Size = new System.Drawing.Size(53, 12);
            this.cb_servergateway.TabIndex = 7;
            this.cb_servergateway.Text = "外围网关";
            // 
            // tb_serverip
            // 
            this.tb_serverip.Location = new System.Drawing.Point(259, 7);
            this.tb_serverip.Name = "tb_serverip";
            this.tb_serverip.Size = new System.Drawing.Size(135, 21);
            this.tb_serverip.TabIndex = 6;
            this.tb_serverip.Text = "172.16.3.55";
            // 
            // lbl_excuteip
            // 
            this.lbl_excuteip.AutoSize = true;
            this.lbl_excuteip.Location = new System.Drawing.Point(197, 40);
            this.lbl_excuteip.Name = "lbl_excuteip";
            this.lbl_excuteip.Size = new System.Drawing.Size(53, 12);
            this.lbl_excuteip.TabIndex = 9;
            this.lbl_excuteip.Text = "排除的IP";
            // 
            // tb_excuteip
            // 
            this.tb_excuteip.Location = new System.Drawing.Point(258, 34);
            this.tb_excuteip.Name = "tb_excuteip";
            this.tb_excuteip.Size = new System.Drawing.Size(135, 21);
            this.tb_excuteip.TabIndex = 8;
            this.tb_excuteip.Text = "45.119.126.225";
            // 
            // tb_setserverdefault
            // 
            this.tb_setserverdefault.Enabled = false;
            this.tb_setserverdefault.Location = new System.Drawing.Point(138, 90);
            this.tb_setserverdefault.Name = "tb_setserverdefault";
            this.tb_setserverdefault.Size = new System.Drawing.Size(132, 23);
            this.tb_setserverdefault.TabIndex = 10;
            this.tb_setserverdefault.Text = "设置外围网关为默认";
            this.tb_setserverdefault.UseVisualStyleBackColor = true;
            this.tb_setserverdefault.Click += new System.EventHandler(this.tb_setserverdefault_Click);
            // 
            // btn_importchina
            // 
            this.btn_importchina.Location = new System.Drawing.Point(30, 149);
            this.btn_importchina.Name = "btn_importchina";
            this.btn_importchina.Size = new System.Drawing.Size(75, 23);
            this.btn_importchina.TabIndex = 11;
            this.btn_importchina.Text = "导入中国IP";
            this.btn_importchina.UseVisualStyleBackColor = true;
            this.btn_importchina.Click += new System.EventHandler(this.btn_importchina_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 215);
            this.Controls.Add(this.btn_importchina);
            this.Controls.Add(this.tb_setserverdefault);
            this.Controls.Add(this.lbl_excuteip);
            this.Controls.Add(this.tb_excuteip);
            this.Controls.Add(this.cb_servergateway);
            this.Controls.Add(this.tb_serverip);
            this.Controls.Add(this.lbl_localgateway);
            this.Controls.Add(this.tb_localgateway);
            this.Controls.Add(this.cb_autoadd);
            this.Controls.Add(this.btn_switch);
            this.Controls.Add(this.cb_autochange);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox cb_autochange;
        private System.Windows.Forms.Button btn_switch;
        private System.Windows.Forms.CheckBox cb_autoadd;
        private System.Windows.Forms.TextBox tb_localgateway;
        private System.Windows.Forms.Label lbl_localgateway;
        private System.Windows.Forms.Label cb_servergateway;
        private System.Windows.Forms.TextBox tb_serverip;
        private System.Windows.Forms.Label lbl_excuteip;
        private System.Windows.Forms.TextBox tb_excuteip;
        private System.Windows.Forms.Button tb_setserverdefault;
        private System.Windows.Forms.Button btn_importchina;
    }
}

