namespace M_JW2
{
    partial class FrmJW2MMoney
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
            this.lblHint = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNick = new System.Windows.Forms.TextBox();
            this.lblNick = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.DtpEnd = new System.Windows.Forms.DateTimePicker();
            this.LblLink = new System.Windows.Forms.Label();
            this.DtpBegin = new System.Windows.Forms.DateTimePicker();
            this.LblDate = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CmbServer = new System.Windows.Forms.ComboBox();
            this.LblServer = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.tbcResult = new System.Windows.Forms.TabControl();
            this.tpgCharacter = new System.Windows.Forms.TabPage();
            this.RoleInfoView = new System.Windows.Forms.DataGridView();
            this.pnlRoleView = new System.Windows.Forms.Panel();
            this.cmbRoleView = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tpgFamilyDonationLog = new System.Windows.Forms.TabPage();
            this.GrdFamilyDonationLog = new System.Windows.Forms.DataGridView();
            this.pnlFamilyDonationLog = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbMoneyType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbFamilyDonationLog = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tpgFamilyConsumerLog = new System.Windows.Forms.TabPage();
            this.GrdFamilyConsumerLog = new System.Windows.Forms.DataGridView();
            this.pnlFamilyConsumerLog = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbFamilyConsumerLog = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GrdRoleView = new System.Windows.Forms.DataGridView();
            this.GrdWeddingInfo = new System.Windows.Forms.DataGridView();
            this.GrdWeddingLog = new System.Windows.Forms.DataGridView();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerFamilyDonationLog = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReFamilyDonationLog = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerFamilyConsumerLog = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReFamilyConsumerLog = new System.ComponentModel.BackgroundWorker();
            this.GrpSearch.SuspendLayout();
            this.tbcResult.SuspendLayout();
            this.tpgCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoleInfoView)).BeginInit();
            this.pnlRoleView.SuspendLayout();
            this.tpgFamilyDonationLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdFamilyDonationLog)).BeginInit();
            this.pnlFamilyDonationLog.SuspendLayout();
            this.tpgFamilyConsumerLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdFamilyConsumerLog)).BeginInit();
            this.pnlFamilyConsumerLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdRoleView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdWeddingInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdWeddingLog)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.lblHint);
            this.GrpSearch.Controls.Add(this.textBox1);
            this.GrpSearch.Controls.Add(this.label7);
            this.GrpSearch.Controls.Add(this.txtNick);
            this.GrpSearch.Controls.Add(this.lblNick);
            this.GrpSearch.Controls.Add(this.txtAccount);
            this.GrpSearch.Controls.Add(this.lblAccount);
            this.GrpSearch.Controls.Add(this.DtpEnd);
            this.GrpSearch.Controls.Add(this.LblLink);
            this.GrpSearch.Controls.Add(this.DtpBegin);
            this.GrpSearch.Controls.Add(this.LblDate);
            this.GrpSearch.Controls.Add(this.button1);
            this.GrpSearch.Controls.Add(this.CmbServer);
            this.GrpSearch.Controls.Add(this.LblServer);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(1119, 186);
            this.GrpSearch.TabIndex = 12;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索條件";
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.ForeColor = System.Drawing.Color.Red;
            this.lblHint.Location = new System.Drawing.Point(410, 133);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(155, 12);
            this.lblHint.TabIndex = 129;
            this.lblHint.Text = "提示：貨幣類型為C表示金幣";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(193, 133);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(168, 21);
            this.textBox1.TabIndex = 128;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(197, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 127;
            this.label7.Text = "道具名：";
            // 
            // txtNick
            // 
            this.txtNick.Location = new System.Drawing.Point(6, 133);
            this.txtNick.Name = "txtNick";
            this.txtNick.Size = new System.Drawing.Size(168, 21);
            this.txtNick.TabIndex = 126;
            // 
            // lblNick
            // 
            this.lblNick.AutoSize = true;
            this.lblNick.Location = new System.Drawing.Point(10, 118);
            this.lblNick.Name = "lblNick";
            this.lblNick.Size = new System.Drawing.Size(65, 12);
            this.lblNick.TabIndex = 125;
            this.lblNick.Text = "玩家昵稱：";
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(8, 80);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(166, 21);
            this.txtAccount.TabIndex = 124;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(10, 65);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(65, 12);
            this.lblAccount.TabIndex = 123;
            this.lblAccount.Text = "玩家帳號：";
            // 
            // DtpEnd
            // 
            this.DtpEnd.CustomFormat = "yyyy-MM-dd";
            this.DtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpEnd.Location = new System.Drawing.Point(193, 80);
            this.DtpEnd.Name = "DtpEnd";
            this.DtpEnd.Size = new System.Drawing.Size(166, 21);
            this.DtpEnd.TabIndex = 122;
            // 
            // LblLink
            // 
            this.LblLink.AutoSize = true;
            this.LblLink.Location = new System.Drawing.Point(191, 65);
            this.LblLink.Name = "LblLink";
            this.LblLink.Size = new System.Drawing.Size(65, 12);
            this.LblLink.TabIndex = 121;
            this.LblLink.Text = "結束時間：";
            // 
            // DtpBegin
            // 
            this.DtpBegin.CustomFormat = "yyyy-MM-dd";
            this.DtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpBegin.Location = new System.Drawing.Point(193, 35);
            this.DtpBegin.Name = "DtpBegin";
            this.DtpBegin.Size = new System.Drawing.Size(168, 21);
            this.DtpBegin.TabIndex = 120;
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Location = new System.Drawing.Point(197, 20);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(65, 12);
            this.LblDate.TabIndex = 119;
            this.LblDate.Text = "開始時間：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(381, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "關閉";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CmbServer
            // 
            this.CmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbServer.FormattingEnabled = true;
            this.CmbServer.Location = new System.Drawing.Point(8, 35);
            this.CmbServer.Name = "CmbServer";
            this.CmbServer.Size = new System.Drawing.Size(166, 20);
            this.CmbServer.TabIndex = 8;
            this.CmbServer.SelectedIndexChanged += new System.EventHandler(this.CmbServer_SelectedIndexChanged);
            // 
            // LblServer
            // 
            this.LblServer.AutoSize = true;
            this.LblServer.Location = new System.Drawing.Point(6, 20);
            this.LblServer.Name = "LblServer";
            this.LblServer.Size = new System.Drawing.Size(77, 12);
            this.LblServer.TabIndex = 7;
            this.LblServer.Text = "遊戲伺服器：";
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(381, 32);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 4;
            this.BtnSearch.Text = "搜索";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // tbcResult
            // 
            this.tbcResult.Controls.Add(this.tpgCharacter);
            this.tbcResult.Controls.Add(this.tpgFamilyDonationLog);
            this.tbcResult.Controls.Add(this.tpgFamilyConsumerLog);
            this.tbcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcResult.Location = new System.Drawing.Point(0, 186);
            this.tbcResult.Name = "tbcResult";
            this.tbcResult.SelectedIndex = 0;
            this.tbcResult.Size = new System.Drawing.Size(1119, 341);
            this.tbcResult.TabIndex = 33;
            this.tbcResult.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbcResult_Selected);
            // 
            // tpgCharacter
            // 
            this.tpgCharacter.Controls.Add(this.RoleInfoView);
            this.tpgCharacter.Controls.Add(this.pnlRoleView);
            this.tpgCharacter.Location = new System.Drawing.Point(4, 21);
            this.tpgCharacter.Name = "tpgCharacter";
            this.tpgCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.tpgCharacter.Size = new System.Drawing.Size(1111, 316);
            this.tpgCharacter.TabIndex = 0;
            this.tpgCharacter.Text = "用戶資料資訊";
            this.tpgCharacter.UseVisualStyleBackColor = true;
            // 
            // RoleInfoView
            // 
            this.RoleInfoView.AllowUserToAddRows = false;
            this.RoleInfoView.AllowUserToDeleteRows = false;
            this.RoleInfoView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoleInfoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoleInfoView.Location = new System.Drawing.Point(3, 40);
            this.RoleInfoView.Name = "RoleInfoView";
            this.RoleInfoView.ReadOnly = true;
            this.RoleInfoView.RowTemplate.Height = 23;
            this.RoleInfoView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RoleInfoView.Size = new System.Drawing.Size(1105, 273);
            this.RoleInfoView.TabIndex = 24;
            this.RoleInfoView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoleInfoView_CellDoubleClick);
            this.RoleInfoView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoleInfoView_CellClick);
            // 
            // pnlRoleView
            // 
            this.pnlRoleView.Controls.Add(this.cmbRoleView);
            this.pnlRoleView.Controls.Add(this.label1);
            this.pnlRoleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRoleView.Location = new System.Drawing.Point(3, 3);
            this.pnlRoleView.Name = "pnlRoleView";
            this.pnlRoleView.Size = new System.Drawing.Size(1105, 37);
            this.pnlRoleView.TabIndex = 22;
            // 
            // cmbRoleView
            // 
            this.cmbRoleView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoleView.FormattingEnabled = true;
            this.cmbRoleView.Location = new System.Drawing.Point(124, 8);
            this.cmbRoleView.Name = "cmbRoleView";
            this.cmbRoleView.Size = new System.Drawing.Size(100, 20);
            this.cmbRoleView.TabIndex = 1;
            this.cmbRoleView.SelectedIndexChanged += new System.EventHandler(this.cmbRoleView_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "請選擇查看頁數：";
            // 
            // tpgFamilyDonationLog
            // 
            this.tpgFamilyDonationLog.Controls.Add(this.GrdFamilyDonationLog);
            this.tpgFamilyDonationLog.Controls.Add(this.pnlFamilyDonationLog);
            this.tpgFamilyDonationLog.Location = new System.Drawing.Point(4, 21);
            this.tpgFamilyDonationLog.Name = "tpgFamilyDonationLog";
            this.tpgFamilyDonationLog.Padding = new System.Windows.Forms.Padding(3);
            this.tpgFamilyDonationLog.Size = new System.Drawing.Size(1111, 316);
            this.tpgFamilyDonationLog.TabIndex = 1;
            this.tpgFamilyDonationLog.Text = "金錢日誌";
            this.tpgFamilyDonationLog.UseVisualStyleBackColor = true;
            // 
            // GrdFamilyDonationLog
            // 
            this.GrdFamilyDonationLog.AllowUserToAddRows = false;
            this.GrdFamilyDonationLog.AllowUserToDeleteRows = false;
            this.GrdFamilyDonationLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdFamilyDonationLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdFamilyDonationLog.Location = new System.Drawing.Point(3, 40);
            this.GrdFamilyDonationLog.Name = "GrdFamilyDonationLog";
            this.GrdFamilyDonationLog.ReadOnly = true;
            this.GrdFamilyDonationLog.RowTemplate.Height = 23;
            this.GrdFamilyDonationLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdFamilyDonationLog.Size = new System.Drawing.Size(1105, 273);
            this.GrdFamilyDonationLog.TabIndex = 28;
            // 
            // pnlFamilyDonationLog
            // 
            this.pnlFamilyDonationLog.Controls.Add(this.button3);
            this.pnlFamilyDonationLog.Controls.Add(this.textBox2);
            this.pnlFamilyDonationLog.Controls.Add(this.checkBox2);
            this.pnlFamilyDonationLog.Controls.Add(this.comboBox2);
            this.pnlFamilyDonationLog.Controls.Add(this.label6);
            this.pnlFamilyDonationLog.Controls.Add(this.cmbMoneyType);
            this.pnlFamilyDonationLog.Controls.Add(this.label5);
            this.pnlFamilyDonationLog.Controls.Add(this.cmbFamilyDonationLog);
            this.pnlFamilyDonationLog.Controls.Add(this.label2);
            this.pnlFamilyDonationLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFamilyDonationLog.Location = new System.Drawing.Point(3, 3);
            this.pnlFamilyDonationLog.Name = "pnlFamilyDonationLog";
            this.pnlFamilyDonationLog.Size = new System.Drawing.Size(1105, 37);
            this.pnlFamilyDonationLog.TabIndex = 25;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(911, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "查詢";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(790, 8);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 11;
            this.textBox2.Visible = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(670, 10);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(96, 16);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.Text = "按道具名查詢";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(515, 8);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 9;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(468, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "類型：";
            // 
            // cmbMoneyType
            // 
            this.cmbMoneyType.FormattingEnabled = true;
            this.cmbMoneyType.Items.AddRange(new object[] {
            "發信",
            "創建家族"});
            this.cmbMoneyType.Location = new System.Drawing.Point(319, 8);
            this.cmbMoneyType.Name = "cmbMoneyType";
            this.cmbMoneyType.Size = new System.Drawing.Size(121, 20);
            this.cmbMoneyType.TabIndex = 7;
            this.cmbMoneyType.SelectedIndexChanged += new System.EventHandler(this.cmbMoneyType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(248, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "金幣類型：";
            // 
            // cmbFamilyDonationLog
            // 
            this.cmbFamilyDonationLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFamilyDonationLog.FormattingEnabled = true;
            this.cmbFamilyDonationLog.Location = new System.Drawing.Point(124, 8);
            this.cmbFamilyDonationLog.Name = "cmbFamilyDonationLog";
            this.cmbFamilyDonationLog.Size = new System.Drawing.Size(100, 20);
            this.cmbFamilyDonationLog.TabIndex = 1;
            this.cmbFamilyDonationLog.SelectedIndexChanged += new System.EventHandler(this.cmbFamilyDonationLog_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "請選擇查看頁數：";
            // 
            // tpgFamilyConsumerLog
            // 
            this.tpgFamilyConsumerLog.Controls.Add(this.GrdFamilyConsumerLog);
            this.tpgFamilyConsumerLog.Controls.Add(this.pnlFamilyConsumerLog);
            this.tpgFamilyConsumerLog.Location = new System.Drawing.Point(4, 21);
            this.tpgFamilyConsumerLog.Name = "tpgFamilyConsumerLog";
            this.tpgFamilyConsumerLog.Size = new System.Drawing.Size(1111, 316);
            this.tpgFamilyConsumerLog.TabIndex = 2;
            this.tpgFamilyConsumerLog.Text = "消費日誌";
            this.tpgFamilyConsumerLog.UseVisualStyleBackColor = true;
            // 
            // GrdFamilyConsumerLog
            // 
            this.GrdFamilyConsumerLog.AllowUserToAddRows = false;
            this.GrdFamilyConsumerLog.AllowUserToDeleteRows = false;
            this.GrdFamilyConsumerLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdFamilyConsumerLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdFamilyConsumerLog.Location = new System.Drawing.Point(0, 37);
            this.GrdFamilyConsumerLog.Name = "GrdFamilyConsumerLog";
            this.GrdFamilyConsumerLog.ReadOnly = true;
            this.GrdFamilyConsumerLog.RowTemplate.Height = 23;
            this.GrdFamilyConsumerLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdFamilyConsumerLog.Size = new System.Drawing.Size(1111, 279);
            this.GrdFamilyConsumerLog.TabIndex = 27;
            // 
            // pnlFamilyConsumerLog
            // 
            this.pnlFamilyConsumerLog.Controls.Add(this.comboBox1);
            this.pnlFamilyConsumerLog.Controls.Add(this.label4);
            this.pnlFamilyConsumerLog.Controls.Add(this.cmbFamilyConsumerLog);
            this.pnlFamilyConsumerLog.Controls.Add(this.label3);
            this.pnlFamilyConsumerLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFamilyConsumerLog.Location = new System.Drawing.Point(0, 0);
            this.pnlFamilyConsumerLog.Name = "pnlFamilyConsumerLog";
            this.pnlFamilyConsumerLog.Size = new System.Drawing.Size(1111, 37);
            this.pnlFamilyConsumerLog.TabIndex = 25;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "发信",
            "创建家族"});
            this.comboBox1.Location = new System.Drawing.Point(365, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(286, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "消費類型：";
            // 
            // cmbFamilyConsumerLog
            // 
            this.cmbFamilyConsumerLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFamilyConsumerLog.FormattingEnabled = true;
            this.cmbFamilyConsumerLog.Location = new System.Drawing.Point(124, 8);
            this.cmbFamilyConsumerLog.Name = "cmbFamilyConsumerLog";
            this.cmbFamilyConsumerLog.Size = new System.Drawing.Size(100, 20);
            this.cmbFamilyConsumerLog.TabIndex = 1;
            this.cmbFamilyConsumerLog.SelectedIndexChanged += new System.EventHandler(this.cmbFamilyConsumerLog_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "請選擇查看頁數：";
            // 
            // GrdRoleView
            // 
            this.GrdRoleView.AllowUserToAddRows = false;
            this.GrdRoleView.AllowUserToDeleteRows = false;
            this.GrdRoleView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdRoleView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdRoleView.Location = new System.Drawing.Point(0, 186);
            this.GrdRoleView.Name = "GrdRoleView";
            this.GrdRoleView.ReadOnly = true;
            this.GrdRoleView.RowTemplate.Height = 23;
            this.GrdRoleView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdRoleView.Size = new System.Drawing.Size(1119, 341);
            this.GrdRoleView.TabIndex = 31;
            // 
            // GrdWeddingInfo
            // 
            this.GrdWeddingInfo.AllowUserToAddRows = false;
            this.GrdWeddingInfo.AllowUserToDeleteRows = false;
            this.GrdWeddingInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdWeddingInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdWeddingInfo.Location = new System.Drawing.Point(0, 186);
            this.GrdWeddingInfo.Name = "GrdWeddingInfo";
            this.GrdWeddingInfo.ReadOnly = true;
            this.GrdWeddingInfo.RowTemplate.Height = 23;
            this.GrdWeddingInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdWeddingInfo.Size = new System.Drawing.Size(1119, 341);
            this.GrdWeddingInfo.TabIndex = 32;
            // 
            // GrdWeddingLog
            // 
            this.GrdWeddingLog.AllowUserToAddRows = false;
            this.GrdWeddingLog.AllowUserToDeleteRows = false;
            this.GrdWeddingLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdWeddingLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdWeddingLog.Location = new System.Drawing.Point(0, 186);
            this.GrdWeddingLog.Name = "GrdWeddingLog";
            this.GrdWeddingLog.ReadOnly = true;
            this.GrdWeddingLog.RowTemplate.Height = 23;
            this.GrdWeddingLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdWeddingLog.Size = new System.Drawing.Size(1119, 341);
            this.GrdWeddingLog.TabIndex = 30;
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
            // backgroundWorkerFamilyDonationLog
            // 
            this.backgroundWorkerFamilyDonationLog.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFamilyDonationLog_DoWork);
            this.backgroundWorkerFamilyDonationLog.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFamilyDonationLog_RunWorkerCompleted);
            // 
            // backgroundWorkerReFamilyDonationLog
            // 
            this.backgroundWorkerReFamilyDonationLog.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReFamilyDonationLog_DoWork);
            this.backgroundWorkerReFamilyDonationLog.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReFamilyDonationLog_RunWorkerCompleted);
            // 
            // backgroundWorkerFamilyConsumerLog
            // 
            this.backgroundWorkerFamilyConsumerLog.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFamilyConsumerLog_DoWork);
            this.backgroundWorkerFamilyConsumerLog.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFamilyConsumerLog_RunWorkerCompleted);
            // 
            // backgroundWorkerReFamilyConsumerLog
            // 
            this.backgroundWorkerReFamilyConsumerLog.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReFamilyConsumerLog_DoWork);
            this.backgroundWorkerReFamilyConsumerLog.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReFamilyConsumerLog_RunWorkerCompleted);
            // 
            // FrmJW2MMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 527);
            this.Controls.Add(this.tbcResult);
            this.Controls.Add(this.GrdRoleView);
            this.Controls.Add(this.GrdWeddingInfo);
            this.Controls.Add(this.GrdWeddingLog);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmJW2MMoney";
            this.Text = "錢幣消費記錄";
            this.Load += new System.EventHandler(this.FrmJW2MMoney_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.tbcResult.ResumeLayout(false);
            this.tpgCharacter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RoleInfoView)).EndInit();
            this.pnlRoleView.ResumeLayout(false);
            this.pnlRoleView.PerformLayout();
            this.tpgFamilyDonationLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdFamilyDonationLog)).EndInit();
            this.pnlFamilyDonationLog.ResumeLayout(false);
            this.pnlFamilyDonationLog.PerformLayout();
            this.tpgFamilyConsumerLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdFamilyConsumerLog)).EndInit();
            this.pnlFamilyConsumerLog.ResumeLayout(false);
            this.pnlFamilyConsumerLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdRoleView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdWeddingInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdWeddingLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CmbServer;
        private System.Windows.Forms.Label LblServer;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TabControl tbcResult;
        private System.Windows.Forms.TabPage tpgCharacter;
        private System.Windows.Forms.TabPage tpgFamilyDonationLog;
        private System.Windows.Forms.TabPage tpgFamilyConsumerLog;
        private System.Windows.Forms.DataGridView GrdRoleView;
        private System.Windows.Forms.DataGridView GrdWeddingInfo;
        private System.Windows.Forms.DataGridView GrdWeddingLog;
        private System.Windows.Forms.DateTimePicker DtpEnd;
        private System.Windows.Forms.Label LblLink;
        private System.Windows.Forms.DateTimePicker DtpBegin;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.DataGridView RoleInfoView;
        private System.Windows.Forms.Panel pnlRoleView;
        private System.Windows.Forms.ComboBox cmbRoleView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView GrdFamilyDonationLog;
        private System.Windows.Forms.Panel pnlFamilyDonationLog;
        private System.Windows.Forms.ComboBox cmbFamilyDonationLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView GrdFamilyConsumerLog;
        private System.Windows.Forms.Panel pnlFamilyConsumerLog;
        private System.Windows.Forms.ComboBox cmbFamilyConsumerLog;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFamilyDonationLog;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReFamilyDonationLog;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFamilyConsumerLog;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReFamilyConsumerLog;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMoneyType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNick;
        private System.Windows.Forms.Label lblNick;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblHint;
    }
}