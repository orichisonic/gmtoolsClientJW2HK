namespace M_RC
{
    partial class FrmPlayGiftInfo
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
            this.label3 = new System.Windows.Forms.Label();
            this.TxtNick = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.CmbServer = new System.Windows.Forms.ComboBox();
            this.LblServer = new System.Windows.Forms.Label();
            this.TxtAccount = new System.Windows.Forms.TextBox();
            this.LblAccount = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TpgCharacter = new System.Windows.Forms.TabPage();
            this.RoleInfoView = new System.Windows.Forms.DataGridView();
            this.PnlPage = new System.Windows.Forms.Panel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.LblPage = new System.Windows.Forms.Label();
            this.TpgItem = new System.Windows.Forms.TabPage();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.CmbPlayerItem = new System.Windows.Forms.ComboBox();
            this.lblPlayItem = new System.Windows.Forms.Label();
            this.BtnSend = new System.Windows.Forms.Button();
            this.TxtReason = new System.Windows.Forms.TextBox();
            this.LblSendReason = new System.Windows.Forms.Label();
            this.TxtContentInfo = new System.Windows.Forms.TextBox();
            this.LblSendContent = new System.Windows.Forms.Label();
            this.TxtCharinfo = new System.Windows.Forms.TextBox();
            this.LblPlayNickName = new System.Windows.Forms.Label();
            this.backgroundWorkerServerLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSerch = new System.ComponentModel.BackgroundWorker();
            this.GrpSearch.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TpgCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoleInfoView)).BeginInit();
            this.PnlPage.SuspendLayout();
            this.TpgItem.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.label3);
            this.GrpSearch.Controls.Add(this.TxtNick);
            this.GrpSearch.Controls.Add(this.label8);
            this.GrpSearch.Controls.Add(this.BtnClose);
            this.GrpSearch.Controls.Add(this.CmbServer);
            this.GrpSearch.Controls.Add(this.LblServer);
            this.GrpSearch.Controls.Add(this.TxtAccount);
            this.GrpSearch.Controls.Add(this.LblAccount);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(933, 167);
            this.GrpSearch.TabIndex = 5;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "·j¯Á±ø¥ó";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(326, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "ÂùÀ»¨¤¦â¸ê°T¶i¤Jµo°e¹D¨ã";
            // 
            // TxtNick
            // 
            this.TxtNick.Location = new System.Drawing.Point(22, 124);
            this.TxtNick.Name = "TxtNick";
            this.TxtNick.Size = new System.Drawing.Size(162, 21);
            this.TxtNick.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "ª±®aÎîºÙ:";
            // 
            // BtnClose
            // 
            this.BtnClose.AutoSize = true;
            this.BtnClose.Location = new System.Drawing.Point(445, 29);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(87, 23);
            this.BtnClose.TabIndex = 9;
            this.BtnClose.Text = "Ãö³¬";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // CmbServer
            // 
            this.CmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbServer.FormattingEnabled = true;
            this.CmbServer.Location = new System.Drawing.Point(23, 32);
            this.CmbServer.Name = "CmbServer";
            this.CmbServer.Size = new System.Drawing.Size(162, 20);
            this.CmbServer.TabIndex = 8;
            this.CmbServer.SelectedIndexChanged += new System.EventHandler(this.CmbServer_SelectedIndexChanged);
            // 
            // LblServer
            // 
            this.LblServer.AutoSize = true;
            this.LblServer.Location = new System.Drawing.Point(21, 17);
            this.LblServer.Name = "LblServer";
            this.LblServer.Size = new System.Drawing.Size(71, 12);
            this.LblServer.TabIndex = 7;
            this.LblServer.Text = "¿ï¾Ü¦øªA¾¹Æ÷:";
            // 
            // TxtAccount
            // 
            this.TxtAccount.Location = new System.Drawing.Point(23, 74);
            this.TxtAccount.Name = "TxtAccount";
            this.TxtAccount.Size = new System.Drawing.Size(162, 21);
            this.TxtAccount.TabIndex = 6;
            // 
            // LblAccount
            // 
            this.LblAccount.AutoSize = true;
            this.LblAccount.Location = new System.Drawing.Point(21, 59);
            this.LblAccount.Name = "LblAccount";
            this.LblAccount.Size = new System.Drawing.Size(59, 12);
            this.LblAccount.TabIndex = 5;
            this.LblAccount.Text = "ª±®a±b¸¹:";
            this.LblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(328, 30);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(87, 23);
            this.BtnSearch.TabIndex = 4;
            this.BtnSearch.Text = "·j¯Á";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TpgCharacter);
            this.tabControl1.Controls.Add(this.TpgItem);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 167);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(933, 458);
            this.tabControl1.TabIndex = 6;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // TpgCharacter
            // 
            this.TpgCharacter.Controls.Add(this.RoleInfoView);
            this.TpgCharacter.Controls.Add(this.PnlPage);
            this.TpgCharacter.Location = new System.Drawing.Point(4, 21);
            this.TpgCharacter.Name = "TpgCharacter";
            this.TpgCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.TpgCharacter.Size = new System.Drawing.Size(925, 433);
            this.TpgCharacter.TabIndex = 0;
            this.TpgCharacter.Text = "¨¤¦â«H®§";
            this.TpgCharacter.UseVisualStyleBackColor = true;
            // 
            // RoleInfoView
            // 
            this.RoleInfoView.AllowUserToAddRows = false;
            this.RoleInfoView.AllowUserToDeleteRows = false;
            this.RoleInfoView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoleInfoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoleInfoView.Location = new System.Drawing.Point(3, 34);
            this.RoleInfoView.Name = "RoleInfoView";
            this.RoleInfoView.ReadOnly = true;
            this.RoleInfoView.RowTemplate.Height = 23;
            this.RoleInfoView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RoleInfoView.Size = new System.Drawing.Size(919, 396);
            this.RoleInfoView.TabIndex = 25;
            this.RoleInfoView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoleInfoView_CellDoubleClick);
            this.RoleInfoView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoleInfoView_CellClick);
            // 
            // PnlPage
            // 
            this.PnlPage.Controls.Add(this.comboBox2);
            this.PnlPage.Controls.Add(this.LblPage);
            this.PnlPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlPage.Location = new System.Drawing.Point(3, 3);
            this.PnlPage.Name = "PnlPage";
            this.PnlPage.Size = new System.Drawing.Size(919, 31);
            this.PnlPage.TabIndex = 26;
            this.PnlPage.TabStop = true;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(112, 8);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // LblPage
            // 
            this.LblPage.AutoSize = true;
            this.LblPage.Location = new System.Drawing.Point(5, 11);
            this.LblPage.Name = "LblPage";
            this.LblPage.Size = new System.Drawing.Size(89, 12);
            this.LblPage.TabIndex = 1;
            this.LblPage.Text = "½Ð¿ï¾Ü¬d¬Ý­¶¼Æ";
            // 
            // TpgItem
            // 
            this.TpgItem.Controls.Add(this.txtName);
            this.TpgItem.Controls.Add(this.lblName);
            this.TpgItem.Controls.Add(this.groupBox1);
            this.TpgItem.Controls.Add(this.BtnSend);
            this.TpgItem.Controls.Add(this.TxtReason);
            this.TpgItem.Controls.Add(this.LblSendReason);
            this.TpgItem.Controls.Add(this.TxtContentInfo);
            this.TpgItem.Controls.Add(this.LblSendContent);
            this.TpgItem.Controls.Add(this.TxtCharinfo);
            this.TpgItem.Controls.Add(this.LblPlayNickName);
            this.TpgItem.Location = new System.Drawing.Point(4, 21);
            this.TpgItem.Name = "TpgItem";
            this.TpgItem.Padding = new System.Windows.Forms.Padding(3);
            this.TpgItem.Size = new System.Drawing.Size(925, 433);
            this.TpgItem.TabIndex = 1;
            this.TpgItem.Text = "µo°e¹D¨ã";
            this.TpgItem.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(144, 179);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(112, 21);
            this.txtName.TabIndex = 21;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(55, 182);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 12);
            this.lblName.TabIndex = 20;
            this.lblName.Text = "¨¤¦â¦W:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbType);
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.CmbPlayerItem);
            this.groupBox1.Controls.Add(this.lblPlayItem);
            this.groupBox1.Location = new System.Drawing.Point(6, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(740, 119);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "·j¯Á¹D¨ã";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(333, 73);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(84, 16);
            this.checkBox2.TabIndex = 33;
            this.checkBox2.Text = "¹D¨ãid·j¯Á";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(333, 50);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 16);
            this.checkBox1.TabIndex = 32;
            this.checkBox1.Text = "¹D¨ã¦W·j¯Á";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtCode
            // 
            this.txtCode.Enabled = false;
            this.txtCode.Location = new System.Drawing.Point(141, 54);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(156, 21);
            this.txtCode.TabIndex = 31;
            this.txtCode.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "¹D¨ãID:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(333, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 23);
            this.button1.TabIndex = 29;
            this.button1.Text = "·j¯Á";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(141, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(156, 21);
            this.textBox1.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "¹D¨ã¦W:";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(557, 20);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(177, 20);
            this.cmbType.TabIndex = 26;
            this.cmbType.Visible = false;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(555, 54);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(35, 12);
            this.lblType.TabIndex = 25;
            this.lblType.Text = "?„e£º";
            this.lblType.Visible = false;
            // 
            // CmbPlayerItem
            // 
            this.CmbPlayerItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPlayerItem.FormattingEnabled = true;
            this.CmbPlayerItem.Location = new System.Drawing.Point(141, 88);
            this.CmbPlayerItem.Name = "CmbPlayerItem";
            this.CmbPlayerItem.Size = new System.Drawing.Size(156, 20);
            this.CmbPlayerItem.TabIndex = 22;
            // 
            // lblPlayItem
            // 
            this.lblPlayItem.AutoSize = true;
            this.lblPlayItem.Location = new System.Drawing.Point(49, 91);
            this.lblPlayItem.Name = "lblPlayItem";
            this.lblPlayItem.Size = new System.Drawing.Size(59, 12);
            this.lblPlayItem.TabIndex = 21;
            this.lblPlayItem.Text = "ª±®a¹D¨ã:";
            // 
            // BtnSend
            // 
            this.BtnSend.Location = new System.Drawing.Point(144, 393);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(75, 23);
            this.BtnSend.TabIndex = 14;
            this.BtnSend.Text = "µo°e";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // TxtReason
            // 
            this.TxtReason.Location = new System.Drawing.Point(144, 285);
            this.TxtReason.Multiline = true;
            this.TxtReason.Name = "TxtReason";
            this.TxtReason.Size = new System.Drawing.Size(280, 90);
            this.TxtReason.TabIndex = 13;
            // 
            // LblSendReason
            // 
            this.LblSendReason.AutoSize = true;
            this.LblSendReason.Location = new System.Drawing.Point(56, 288);
            this.LblSendReason.Name = "LblSendReason";
            this.LblSendReason.Size = new System.Drawing.Size(59, 12);
            this.LblSendReason.TabIndex = 12;
            this.LblSendReason.Text = "µo°e²z¥Ñ:";
            // 
            // TxtContentInfo
            // 
            this.TxtContentInfo.Location = new System.Drawing.Point(144, 215);
            this.TxtContentInfo.Multiline = true;
            this.TxtContentInfo.Name = "TxtContentInfo";
            this.TxtContentInfo.Size = new System.Drawing.Size(280, 64);
            this.TxtContentInfo.TabIndex = 11;
            // 
            // LblSendContent
            // 
            this.LblSendContent.AutoSize = true;
            this.LblSendContent.Location = new System.Drawing.Point(53, 215);
            this.LblSendContent.Name = "LblSendContent";
            this.LblSendContent.Size = new System.Drawing.Size(59, 12);
            this.LblSendContent.TabIndex = 10;
            this.LblSendContent.Text = "µo°e¤º®e:";
            // 
            // TxtCharinfo
            // 
            this.TxtCharinfo.Location = new System.Drawing.Point(144, 142);
            this.TxtCharinfo.Name = "TxtCharinfo";
            this.TxtCharinfo.ReadOnly = true;
            this.TxtCharinfo.Size = new System.Drawing.Size(112, 21);
            this.TxtCharinfo.TabIndex = 7;
            // 
            // LblPlayNickName
            // 
            this.LblPlayNickName.AutoSize = true;
            this.LblPlayNickName.Location = new System.Drawing.Point(53, 151);
            this.LblPlayNickName.Name = "LblPlayNickName";
            this.LblPlayNickName.Size = new System.Drawing.Size(53, 12);
            this.LblPlayNickName.TabIndex = 6;
            this.LblPlayNickName.Text = "ª±®aÎîºÙ";
            // 
            // backgroundWorkerServerLoad
            // 
            this.backgroundWorkerServerLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerServerLoad_DoWork);
            this.backgroundWorkerServerLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerServerLoad_RunWorkerCompleted);
            // 
            // backgroundWorkerSerch
            // 
            this.backgroundWorkerSerch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSerch_DoWork);
            this.backgroundWorkerSerch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSerch_RunWorkerCompleted);
            // 
            // FrmPlayGiftInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 625);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmPlayGiftInfo";
            this.Text = "ª±®a¹D¨ã«H®§";
            this.Load += new System.EventHandler(this.FrmPlayLogInfo_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.TpgCharacter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RoleInfoView)).EndInit();
            this.PnlPage.ResumeLayout(false);
            this.PnlPage.PerformLayout();
            this.TpgItem.ResumeLayout(false);
            this.TpgItem.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.ComboBox CmbServer;
        private System.Windows.Forms.Label LblServer;
        private System.Windows.Forms.TextBox TxtAccount;
        private System.Windows.Forms.Label LblAccount;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TpgCharacter;
        private System.Windows.Forms.TabPage TpgItem;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.TextBox TxtReason;
        private System.Windows.Forms.Label LblSendReason;
        private System.Windows.Forms.TextBox TxtContentInfo;
        private System.Windows.Forms.Label LblSendContent;
        private System.Windows.Forms.TextBox TxtCharinfo;
        private System.Windows.Forms.Label LblPlayNickName;
        private System.ComponentModel.BackgroundWorker backgroundWorkerServerLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSerch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CmbPlayerItem;
        private System.Windows.Forms.Label lblPlayItem;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox TxtNick;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView RoleInfoView;
        private System.Windows.Forms.Panel PnlPage;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label LblPage;
        private System.Windows.Forms.Label label3;
    }
}