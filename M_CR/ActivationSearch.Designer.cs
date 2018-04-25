namespace M_CR
{
    partial class ActivationSearch
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtActivationCode = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.chkbxActivation = new System.Windows.Forms.CheckBox();
            this.chkbxAccount = new System.Windows.Forms.CheckBox();
            this.cbxServerIP = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.lblContent = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.dividerPanel1.SuspendLayout();
            this.dividerPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "激活码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码：";
            // 
            // txtActivationCode
            // 
            this.txtActivationCode.Location = new System.Drawing.Point(59, 2);
            this.txtActivationCode.Name = "txtActivationCode";
            this.txtActivationCode.Size = new System.Drawing.Size(175, 21);
            this.txtActivationCode.TabIndex = 2;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(59, 29);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(175, 21);
            this.txtPwd.TabIndex = 3;
            this.txtPwd.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "帐号：";
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(59, 82);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(175, 21);
            this.txtAccount.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(254, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(254, 51);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "重置";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel1.Controls.Add(this.chkbxActivation);
            this.dividerPanel1.Controls.Add(this.chkbxAccount);
            this.dividerPanel1.Controls.Add(this.cbxServerIP);
            this.dividerPanel1.Controls.Add(this.label4);
            this.dividerPanel1.Controls.Add(this.label1);
            this.dividerPanel1.Controls.Add(this.btnCancel);
            this.dividerPanel1.Controls.Add(this.txtActivationCode);
            this.dividerPanel1.Controls.Add(this.btnSearch);
            this.dividerPanel1.Controls.Add(this.label2);
            this.dividerPanel1.Controls.Add(this.txtPwd);
            this.dividerPanel1.Controls.Add(this.label3);
            this.dividerPanel1.Controls.Add(this.txtAccount);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(458, 147);
            this.dividerPanel1.TabIndex = 10;
            // 
            // chkbxActivation
            // 
            this.chkbxActivation.AutoSize = true;
            this.chkbxActivation.Location = new System.Drawing.Point(59, 114);
            this.chkbxActivation.Name = "chkbxActivation";
            this.chkbxActivation.Size = new System.Drawing.Size(84, 16);
            this.chkbxActivation.TabIndex = 12;
            this.chkbxActivation.Text = "激活码查询";
            this.chkbxActivation.UseVisualStyleBackColor = true;
            this.chkbxActivation.CheckedChanged += new System.EventHandler(this.chkbxActivation_CheckedChanged_1);
            // 
            // chkbxAccount
            // 
            this.chkbxAccount.AutoSize = true;
            this.chkbxAccount.Location = new System.Drawing.Point(149, 114);
            this.chkbxAccount.Name = "chkbxAccount";
            this.chkbxAccount.Size = new System.Drawing.Size(72, 16);
            this.chkbxAccount.TabIndex = 13;
            this.chkbxAccount.Text = "帐号查询";
            this.chkbxAccount.UseVisualStyleBackColor = true;
            this.chkbxAccount.CheckedChanged += new System.EventHandler(this.chkbxAccount_CheckedChanged_1);
            // 
            // cbxServerIP
            // 
            this.cbxServerIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServerIP.FormattingEnabled = true;
            this.cbxServerIP.Location = new System.Drawing.Point(59, 56);
            this.cbxServerIP.Name = "cbxServerIP";
            this.cbxServerIP.Size = new System.Drawing.Size(175, 20);
            this.cbxServerIP.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "服务器：";
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.BorderSide = System.Windows.Forms.Border3DSide.Top;
            this.dividerPanel2.Controls.Add(this.lblContent);
            this.dividerPanel2.Controls.Add(this.lblResult);
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 157);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(458, 222);
            this.dividerPanel2.TabIndex = 11;
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(12, 40);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(41, 12);
            this.lblContent.TabIndex = 1;
            this.lblContent.Text = "label4";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.ForeColor = System.Drawing.Color.Red;
            this.lblResult.Location = new System.Drawing.Point(12, 19);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(65, 12);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "查询结果：";
            // 
            // ActivationSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 389);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "ActivationSearch";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "帐号/激活码查询[疯狂卡丁车]";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel1.PerformLayout();
            this.dividerPanel2.ResumeLayout(false);
            this.dividerPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtActivationCode;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private DividerPanel.DividerPanel dividerPanel1;
        private DividerPanel.DividerPanel dividerPanel2;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.CheckBox chkbxActivation;
        private System.Windows.Forms.CheckBox chkbxAccount;
        private System.Windows.Forms.ComboBox cbxServerIP;
        private System.Windows.Forms.Label label4;
    }
}

