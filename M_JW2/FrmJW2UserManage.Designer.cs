namespace M_JW2
{
    partial class FrmJW2UserManage
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
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.txtNick = new System.Windows.Forms.TextBox();
            this.lblNick = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.CmbServer = new System.Windows.Forms.ComboBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.tbcResult = new System.Windows.Forms.TabControl();
            this.tpgCharacter = new System.Windows.Forms.TabPage();
            this.RoleGridView = new System.Windows.Forms.DataGridView();
            this.pnlRoleView = new System.Windows.Forms.Panel();
            this.cmbRoleView = new System.Windows.Forms.ComboBox();
            this.lblBodyItemInfo = new System.Windows.Forms.Label();
            this.tpgModifyUser = new System.Windows.Forms.TabPage();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbModiContent = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tpgModifyPass = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerModiLvl = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerModiPassword = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerModiExp = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerRecoverPassword = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerCheckPwd = new System.ComponentModel.BackgroundWorker();
            this.GrpSearch.SuspendLayout();
            this.tbcResult.SuspendLayout();
            this.tpgCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoleGridView)).BeginInit();
            this.pnlRoleView.SuspendLayout();
            this.tpgModifyUser.SuspendLayout();
            this.tpgModifyPass.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.btnClose);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Controls.Add(this.txtNick);
            this.GrpSearch.Controls.Add(this.lblNick);
            this.GrpSearch.Controls.Add(this.txtAccount);
            this.GrpSearch.Controls.Add(this.lblAccount);
            this.GrpSearch.Controls.Add(this.CmbServer);
            this.GrpSearch.Controls.Add(this.lblServer);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(620, 133);
            this.GrpSearch.TabIndex = 5;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索條件";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(310, 57);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 31;
            this.btnClose.Text = "關閉";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(310, 23);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 30;
            this.BtnSearch.Text = "搜索";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtNick
            // 
            this.txtNick.Location = new System.Drawing.Point(107, 92);
            this.txtNick.Name = "txtNick";
            this.txtNick.Size = new System.Drawing.Size(187, 21);
            this.txtNick.TabIndex = 29;
            // 
            // lblNick
            // 
            this.lblNick.AutoSize = true;
            this.lblNick.Location = new System.Drawing.Point(36, 95);
            this.lblNick.Name = "lblNick";
            this.lblNick.Size = new System.Drawing.Size(65, 12);
            this.lblNick.TabIndex = 28;
            this.lblNick.Text = "玩家昵稱：";
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(107, 58);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(187, 21);
            this.txtAccount.TabIndex = 27;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(36, 61);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(65, 12);
            this.lblAccount.TabIndex = 26;
            this.lblAccount.Text = "玩家帳號：";
            // 
            // CmbServer
            // 
            this.CmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbServer.FormattingEnabled = true;
            this.CmbServer.Location = new System.Drawing.Point(107, 25);
            this.CmbServer.Name = "CmbServer";
            this.CmbServer.Size = new System.Drawing.Size(187, 20);
            this.CmbServer.TabIndex = 25;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(24, 28);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(77, 12);
            this.lblServer.TabIndex = 24;
            this.lblServer.Text = "遊戲伺服器：";
            // 
            // tbcResult
            // 
            this.tbcResult.Controls.Add(this.tpgCharacter);
            this.tbcResult.Controls.Add(this.tpgModifyUser);
            this.tbcResult.Controls.Add(this.tpgModifyPass);
            this.tbcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcResult.Location = new System.Drawing.Point(0, 133);
            this.tbcResult.Name = "tbcResult";
            this.tbcResult.SelectedIndex = 0;
            this.tbcResult.Size = new System.Drawing.Size(620, 277);
            this.tbcResult.TabIndex = 37;
            this.tbcResult.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbcResult_Selected);
            // 
            // tpgCharacter
            // 
            this.tpgCharacter.Controls.Add(this.RoleGridView);
            this.tpgCharacter.Controls.Add(this.pnlRoleView);
            this.tpgCharacter.Location = new System.Drawing.Point(4, 21);
            this.tpgCharacter.Name = "tpgCharacter";
            this.tpgCharacter.Size = new System.Drawing.Size(612, 252);
            this.tpgCharacter.TabIndex = 7;
            this.tpgCharacter.Text = "用戶資料資訊";
            this.tpgCharacter.UseVisualStyleBackColor = true;
            // 
            // RoleGridView
            // 
            this.RoleGridView.AllowUserToAddRows = false;
            this.RoleGridView.AllowUserToDeleteRows = false;
            this.RoleGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoleGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoleGridView.Location = new System.Drawing.Point(0, 37);
            this.RoleGridView.Name = "RoleGridView";
            this.RoleGridView.ReadOnly = true;
            this.RoleGridView.RowTemplate.Height = 23;
            this.RoleGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RoleGridView.Size = new System.Drawing.Size(612, 215);
            this.RoleGridView.TabIndex = 18;
            this.RoleGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoleGridView_CellDoubleClick);
            // 
            // pnlRoleView
            // 
            this.pnlRoleView.Controls.Add(this.cmbRoleView);
            this.pnlRoleView.Controls.Add(this.lblBodyItemInfo);
            this.pnlRoleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRoleView.Location = new System.Drawing.Point(0, 0);
            this.pnlRoleView.Name = "pnlRoleView";
            this.pnlRoleView.Size = new System.Drawing.Size(612, 37);
            this.pnlRoleView.TabIndex = 16;
            // 
            // cmbRoleView
            // 
            this.cmbRoleView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoleView.FormattingEnabled = true;
            this.cmbRoleView.Location = new System.Drawing.Point(124, 8);
            this.cmbRoleView.Name = "cmbRoleView";
            this.cmbRoleView.Size = new System.Drawing.Size(100, 20);
            this.cmbRoleView.TabIndex = 1;
            this.cmbRoleView.SelectedIndexChanged += new System.EventHandler(this.cmbBodyItemInfo_SelectedIndexChanged);
            // 
            // lblBodyItemInfo
            // 
            this.lblBodyItemInfo.AutoSize = true;
            this.lblBodyItemInfo.Location = new System.Drawing.Point(20, 13);
            this.lblBodyItemInfo.Name = "lblBodyItemInfo";
            this.lblBodyItemInfo.Size = new System.Drawing.Size(101, 12);
            this.lblBodyItemInfo.TabIndex = 0;
            this.lblBodyItemInfo.Text = "請選擇查看頁數：";
            // 
            // tpgModifyUser
            // 
            this.tpgModifyUser.Controls.Add(this.textBox3);
            this.tpgModifyUser.Controls.Add(this.textBox2);
            this.tpgModifyUser.Controls.Add(this.textBox1);
            this.tpgModifyUser.Controls.Add(this.cmbModiContent);
            this.tpgModifyUser.Controls.Add(this.button2);
            this.tpgModifyUser.Controls.Add(this.button1);
            this.tpgModifyUser.Controls.Add(this.label5);
            this.tpgModifyUser.Controls.Add(this.label4);
            this.tpgModifyUser.Controls.Add(this.label3);
            this.tpgModifyUser.Controls.Add(this.label2);
            this.tpgModifyUser.Location = new System.Drawing.Point(4, 21);
            this.tpgModifyUser.Name = "tpgModifyUser";
            this.tpgModifyUser.Padding = new System.Windows.Forms.Padding(3);
            this.tpgModifyUser.Size = new System.Drawing.Size(612, 252);
            this.tpgModifyUser.TabIndex = 0;
            this.tpgModifyUser.Text = "修改用戶";
            this.tpgModifyUser.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(235, 165);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(121, 21);
            this.textBox3.TabIndex = 9;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(235, 117);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(121, 21);
            this.textBox2.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(235, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(121, 21);
            this.textBox1.TabIndex = 7;
            // 
            // cmbModiContent
            // 
            this.cmbModiContent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModiContent.FormattingEnabled = true;
            this.cmbModiContent.Location = new System.Drawing.Point(235, 67);
            this.cmbModiContent.Name = "cmbModiContent";
            this.cmbModiContent.Size = new System.Drawing.Size(121, 20);
            this.cmbModiContent.TabIndex = 6;
            this.cmbModiContent.SelectedIndexChanged += new System.EventHandler(this.cmbModiContent_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(342, 202);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "重置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(158, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "確定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(134, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "新等級：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(134, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "現在等級：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "修改內容：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "角色昵稱：";
            // 
            // tpgModifyPass
            // 
            this.tpgModifyPass.Controls.Add(this.button5);
            this.tpgModifyPass.Controls.Add(this.button4);
            this.tpgModifyPass.Controls.Add(this.button3);
            this.tpgModifyPass.Controls.Add(this.textBox5);
            this.tpgModifyPass.Controls.Add(this.textBox4);
            this.tpgModifyPass.Controls.Add(this.label7);
            this.tpgModifyPass.Controls.Add(this.label6);
            this.tpgModifyPass.Location = new System.Drawing.Point(4, 21);
            this.tpgModifyPass.Name = "tpgModifyPass";
            this.tpgModifyPass.Size = new System.Drawing.Size(612, 252);
            this.tpgModifyPass.TabIndex = 4;
            this.tpgModifyPass.Text = "修改密碼";
            this.tpgModifyPass.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(438, 130);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 8;
            this.button5.Text = "查詢密碼";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(438, 87);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "恢復密碼";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(438, 49);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "修改密碼";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(234, 115);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 21);
            this.textBox5.TabIndex = 4;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(234, 72);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(100, 21);
            this.textBox4.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(133, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "新密碼：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(133, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "帳號：";
            // 
            // backgroundWorkerFormLoad
            // 
            this.backgroundWorkerFormLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFormLoad_DoWork);
            this.backgroundWorkerFormLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFormLoad_RunWorkerCompleted);
            // 
            // backgroundWorkerSearch
            // 
            this.backgroundWorkerSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSearch_DoWork);
            this.backgroundWorkerSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSearch_RunWorkerCompleted);
            // 
            // backgroundWorkerReSearch
            // 
            this.backgroundWorkerReSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReSearch_DoWork);
            this.backgroundWorkerReSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReSearch_RunWorkerCompleted);
            // 
            // backgroundWorkerModiLvl
            // 
            this.backgroundWorkerModiLvl.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerModiLvl_DoWork);
            this.backgroundWorkerModiLvl.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerModiLvl_RunWorkerCompleted);
            // 
            // backgroundWorkerModiPassword
            // 
            this.backgroundWorkerModiPassword.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerModiPassword_DoWork);
            this.backgroundWorkerModiPassword.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerModiPassword_RunWorkerCompleted);
            // 
            // backgroundWorkerModiExp
            // 
            this.backgroundWorkerModiExp.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerModiExp_DoWork);
            this.backgroundWorkerModiExp.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerModiExp_RunWorkerCompleted);
            // 
            // backgroundWorkerRecoverPassword
            // 
            this.backgroundWorkerRecoverPassword.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerRecoverPassword_DoWork);
            this.backgroundWorkerRecoverPassword.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerRecoverPassword_RunWorkerCompleted);
            // 
            // backgroundWorkerCheckPwd
            // 
            this.backgroundWorkerCheckPwd.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCheckPwd_DoWork);
            this.backgroundWorkerCheckPwd.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCheckPwd_RunWorkerCompleted);
            // 
            // FrmJW2UserManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 410);
            this.Controls.Add(this.tbcResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmJW2UserManage";
            this.Text = "玩家管理";
            this.Load += new System.EventHandler(this.FrmJW2UserManage_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.tbcResult.ResumeLayout(false);
            this.tpgCharacter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RoleGridView)).EndInit();
            this.pnlRoleView.ResumeLayout(false);
            this.pnlRoleView.PerformLayout();
            this.tpgModifyUser.ResumeLayout(false);
            this.tpgModifyUser.PerformLayout();
            this.tpgModifyPass.ResumeLayout(false);
            this.tpgModifyPass.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox txtNick;
        private System.Windows.Forms.Label lblNick;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.ComboBox CmbServer;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TabControl tbcResult;
        private System.Windows.Forms.TabPage tpgCharacter;
        private System.Windows.Forms.TabPage tpgModifyUser;
        private System.Windows.Forms.TabPage tpgModifyPass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cmbModiContent;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.DataGridView RoleGridView;
        private System.Windows.Forms.Panel pnlRoleView;
        private System.Windows.Forms.ComboBox cmbRoleView;
        private System.Windows.Forms.Label lblBodyItemInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerModiLvl;
        private System.ComponentModel.BackgroundWorker backgroundWorkerModiPassword;
        private System.ComponentModel.BackgroundWorker backgroundWorkerModiExp;
        private System.ComponentModel.BackgroundWorker backgroundWorkerRecoverPassword;
        private System.Windows.Forms.Button button5;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCheckPwd;
    }
}