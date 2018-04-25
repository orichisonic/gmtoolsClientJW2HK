namespace M_SDO
{
    partial class Frm_SDO_Pwd
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
            this.BtnGetMail = new System.Windows.Forms.Button();
            this.TxtPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtMail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.TxtAccount = new System.Windows.Forms.TextBox();
            this.LblAccount = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnGetMail
            // 
            this.BtnGetMail.Location = new System.Drawing.Point(211, 22);
            this.BtnGetMail.Name = "BtnGetMail";
            this.BtnGetMail.Size = new System.Drawing.Size(103, 23);
            this.BtnGetMail.TabIndex = 14;
            this.BtnGetMail.Text = "获取E-mail地址";
            this.BtnGetMail.UseVisualStyleBackColor = true;
            this.BtnGetMail.Click += new System.EventHandler(this.BtnGetMail_Click);
            // 
            // TxtPwd
            // 
            this.TxtPwd.Location = new System.Drawing.Point(15, 126);
            this.TxtPwd.Name = "TxtPwd";
            this.TxtPwd.Size = new System.Drawing.Size(169, 21);
            this.TxtPwd.TabIndex = 13;
            this.TxtPwd.Text = "123456";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "玩家口令：";
            // 
            // TxtMail
            // 
            this.TxtMail.Location = new System.Drawing.Point(15, 75);
            this.TxtMail.Name = "TxtMail";
            this.TxtMail.Size = new System.Drawing.Size(169, 21);
            this.TxtMail.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "玩家信箱：";
            // 
            // BtnClose
            // 
            this.BtnClose.AutoSize = true;
            this.BtnClose.Location = new System.Drawing.Point(211, 94);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(103, 23);
            this.BtnClose.TabIndex = 9;
            this.BtnClose.Text = "重    置";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // TxtAccount
            // 
            this.TxtAccount.Location = new System.Drawing.Point(15, 25);
            this.TxtAccount.Name = "TxtAccount";
            this.TxtAccount.Size = new System.Drawing.Size(169, 21);
            this.TxtAccount.TabIndex = 6;
            // 
            // LblAccount
            // 
            this.LblAccount.AutoSize = true;
            this.LblAccount.Location = new System.Drawing.Point(13, 10);
            this.LblAccount.Name = "LblAccount";
            this.LblAccount.Size = new System.Drawing.Size(65, 12);
            this.LblAccount.TabIndex = 5;
            this.LblAccount.Text = "玩家帐号：";
            this.LblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(211, 57);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(103, 23);
            this.BtnSearch.TabIndex = 4;
            this.BtnSearch.Text = "发送口令";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // Frm_SDO_Pwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 373);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnGetMail);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.TxtPwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtMail);
            this.Controls.Add(this.LblAccount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtAccount);
            this.Name = "Frm_SDO_Pwd";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "发送密码";
            this.Load += new System.EventHandler(this.Frm_SDO_Pwd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.TextBox TxtAccount;
        private System.Windows.Forms.Label LblAccount;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnGetMail;
        private System.Windows.Forms.TextBox TxtPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtMail;
    }
}