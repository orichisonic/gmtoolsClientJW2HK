namespace FRM_MJ
{
    partial class userPwdBehavior
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.serverIP = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.actionType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.userName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.dividerPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serverIP
            // 
            this.serverIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serverIP.FormattingEnabled = true;
            this.serverIP.Location = new System.Drawing.Point(126, 52);
            this.serverIP.Name = "serverIP";
            this.serverIP.Size = new System.Drawing.Size(299, 20);
            this.serverIP.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "玩家区域：";
            // 
            // actionType
            // 
            this.actionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionType.FormattingEnabled = true;
            this.actionType.Items.AddRange(new object[] {
            "保存玩家密码",
            "修改玩家密码",
            "恢复玩家密码"});
            this.actionType.Location = new System.Drawing.Point(126, 78);
            this.actionType.Name = "actionType";
            this.actionType.Size = new System.Drawing.Size(299, 20);
            this.actionType.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "操作方式：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(350, 132);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 24);
            this.button2.TabIndex = 24;
            this.button2.Text = "取消";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(261, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 23;
            this.button1.Text = "确认";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(126, 104);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(299, 21);
            this.userName.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(55, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "玩家帐号：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.label4);
            this.dividerPanel1.Controls.Add(this.serverIP);
            this.dividerPanel1.Controls.Add(this.label2);
            this.dividerPanel1.Controls.Add(this.userName);
            this.dividerPanel1.Controls.Add(this.actionType);
            this.dividerPanel1.Controls.Add(this.button1);
            this.dividerPanel1.Controls.Add(this.label3);
            this.dividerPanel1.Controls.Add(this.button2);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.dividerPanel1.Size = new System.Drawing.Size(499, 292);
            this.dividerPanel1.TabIndex = 29;
            // 
            // userPwdBehavior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 312);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "userPwdBehavior";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "密码操作";
            this.Load += new System.EventHandler(this.userPwdBehavior_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox serverIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox actionType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label label2;
        private DividerPanel.DividerPanel dividerPanel1;
    }
}