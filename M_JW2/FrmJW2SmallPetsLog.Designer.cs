namespace M_JW2
{
    partial class FrmJW2SmallPetsLog
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
            this.tbcResult = new System.Windows.Forms.TabControl();
            this.tpgCharacter = new System.Windows.Forms.TabPage();
            this.GrdRoleView = new System.Windows.Forms.DataGridView();
            this.pnlRoleView = new System.Windows.Forms.Panel();
            this.cmbRoleView = new System.Windows.Forms.ComboBox();
            this.lblRoleView = new System.Windows.Forms.Label();
            this.tpgSmallPetEgg = new System.Windows.Forms.TabPage();
            this.GrdPetEgg = new System.Windows.Forms.DataGridView();
            this.pnlPetEgg = new System.Windows.Forms.Panel();
            this.cmbPetEgg = new System.Windows.Forms.ComboBox();
            this.lblPetEgg = new System.Windows.Forms.Label();
            this.tpgSmallPet = new System.Windows.Forms.TabPage();
            this.GrdSmallPet = new System.Windows.Forms.DataGridView();
            this.pnlsmallPet = new System.Windows.Forms.Panel();
            this.cmbSmallPet = new System.Windows.Forms.ComboBox();
            this.lblSmallPet = new System.Windows.Forms.Label();
            this.tabSmallPetEggExchange = new System.Windows.Forms.TabPage();
            this.GrdSmallPetEggExchange = new System.Windows.Forms.DataGridView();
            this.pnlSmallPetEggExchange = new System.Windows.Forms.Panel();
            this.cmbSmallPetEggExchange = new System.Windows.Forms.ComboBox();
            this.lblSmallPetEggExchange = new System.Windows.Forms.Label();
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.DtpEnd = new System.Windows.Forms.DateTimePicker();
            this.LblLink = new System.Windows.Forms.Label();
            this.DtpBegin = new System.Windows.Forms.DateTimePicker();
            this.LblDate = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtNick = new System.Windows.Forms.TextBox();
            this.lblNick = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerPetEgg = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerRePetEgg = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSmallPet = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReSmallPet = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSmallPetEggExchange = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReSmallPetEggExchange = new System.ComponentModel.BackgroundWorker();
            this.tbcResult.SuspendLayout();
            this.tpgCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdRoleView)).BeginInit();
            this.pnlRoleView.SuspendLayout();
            this.tpgSmallPetEgg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdPetEgg)).BeginInit();
            this.pnlPetEgg.SuspendLayout();
            this.tpgSmallPet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdSmallPet)).BeginInit();
            this.pnlsmallPet.SuspendLayout();
            this.tabSmallPetEggExchange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdSmallPetEggExchange)).BeginInit();
            this.pnlSmallPetEggExchange.SuspendLayout();
            this.GrpSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcResult
            // 
            this.tbcResult.Controls.Add(this.tpgCharacter);
            this.tbcResult.Controls.Add(this.tpgSmallPetEgg);
            this.tbcResult.Controls.Add(this.tpgSmallPet);
            this.tbcResult.Controls.Add(this.tabSmallPetEggExchange);
            this.tbcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcResult.Location = new System.Drawing.Point(0, 140);
            this.tbcResult.Name = "tbcResult";
            this.tbcResult.SelectedIndex = 0;
            this.tbcResult.Size = new System.Drawing.Size(752, 324);
            this.tbcResult.TabIndex = 35;
            this.tbcResult.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbcResult_Selected_1);
            // 
            // tpgCharacter
            // 
            this.tpgCharacter.Controls.Add(this.GrdRoleView);
            this.tpgCharacter.Controls.Add(this.pnlRoleView);
            this.tpgCharacter.Location = new System.Drawing.Point(4, 21);
            this.tpgCharacter.Name = "tpgCharacter";
            this.tpgCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.tpgCharacter.Size = new System.Drawing.Size(744, 299);
            this.tpgCharacter.TabIndex = 0;
            this.tpgCharacter.Text = "用戶資料資訊";
            this.tpgCharacter.UseVisualStyleBackColor = true;
            // 
            // GrdRoleView
            // 
            this.GrdRoleView.AllowUserToAddRows = false;
            this.GrdRoleView.AllowUserToDeleteRows = false;
            this.GrdRoleView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdRoleView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdRoleView.Location = new System.Drawing.Point(3, 40);
            this.GrdRoleView.Name = "GrdRoleView";
            this.GrdRoleView.ReadOnly = true;
            this.GrdRoleView.RowTemplate.Height = 23;
            this.GrdRoleView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdRoleView.Size = new System.Drawing.Size(738, 256);
            this.GrdRoleView.TabIndex = 24;
            this.GrdRoleView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdRoleView_CellDoubleClick);
            // 
            // pnlRoleView
            // 
            this.pnlRoleView.Controls.Add(this.cmbRoleView);
            this.pnlRoleView.Controls.Add(this.lblRoleView);
            this.pnlRoleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRoleView.Location = new System.Drawing.Point(3, 3);
            this.pnlRoleView.Name = "pnlRoleView";
            this.pnlRoleView.Size = new System.Drawing.Size(738, 37);
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
            // lblRoleView
            // 
            this.lblRoleView.AutoSize = true;
            this.lblRoleView.Location = new System.Drawing.Point(20, 13);
            this.lblRoleView.Name = "lblRoleView";
            this.lblRoleView.Size = new System.Drawing.Size(101, 12);
            this.lblRoleView.TabIndex = 0;
            this.lblRoleView.Text = "請選擇查看頁數：";
            // 
            // tpgSmallPetEgg
            // 
            this.tpgSmallPetEgg.Controls.Add(this.GrdPetEgg);
            this.tpgSmallPetEgg.Controls.Add(this.pnlPetEgg);
            this.tpgSmallPetEgg.Location = new System.Drawing.Point(4, 21);
            this.tpgSmallPetEgg.Name = "tpgSmallPetEgg";
            this.tpgSmallPetEgg.Padding = new System.Windows.Forms.Padding(3);
            this.tpgSmallPetEgg.Size = new System.Drawing.Size(744, 299);
            this.tpgSmallPetEgg.TabIndex = 1;
            this.tpgSmallPetEgg.Text = "小寵物蛋查詢";
            this.tpgSmallPetEgg.UseVisualStyleBackColor = true;
            // 
            // GrdPetEgg
            // 
            this.GrdPetEgg.AllowUserToAddRows = false;
            this.GrdPetEgg.AllowUserToDeleteRows = false;
            this.GrdPetEgg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdPetEgg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdPetEgg.Location = new System.Drawing.Point(3, 40);
            this.GrdPetEgg.Name = "GrdPetEgg";
            this.GrdPetEgg.ReadOnly = true;
            this.GrdPetEgg.RowTemplate.Height = 23;
            this.GrdPetEgg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdPetEgg.Size = new System.Drawing.Size(738, 256);
            this.GrdPetEgg.TabIndex = 26;
            // 
            // pnlPetEgg
            // 
            this.pnlPetEgg.Controls.Add(this.cmbPetEgg);
            this.pnlPetEgg.Controls.Add(this.lblPetEgg);
            this.pnlPetEgg.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPetEgg.Location = new System.Drawing.Point(3, 3);
            this.pnlPetEgg.Name = "pnlPetEgg";
            this.pnlPetEgg.Size = new System.Drawing.Size(738, 37);
            this.pnlPetEgg.TabIndex = 24;
            // 
            // cmbPetEgg
            // 
            this.cmbPetEgg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPetEgg.FormattingEnabled = true;
            this.cmbPetEgg.Location = new System.Drawing.Point(124, 8);
            this.cmbPetEgg.Name = "cmbPetEgg";
            this.cmbPetEgg.Size = new System.Drawing.Size(100, 20);
            this.cmbPetEgg.TabIndex = 1;
            this.cmbPetEgg.SelectedIndexChanged += new System.EventHandler(this.cmdPetEgg_SelectedIndexChanged);
            // 
            // lblPetEgg
            // 
            this.lblPetEgg.AutoSize = true;
            this.lblPetEgg.Location = new System.Drawing.Point(20, 13);
            this.lblPetEgg.Name = "lblPetEgg";
            this.lblPetEgg.Size = new System.Drawing.Size(101, 12);
            this.lblPetEgg.TabIndex = 0;
            this.lblPetEgg.Text = "請選擇查看頁數：";
            // 
            // tpgSmallPet
            // 
            this.tpgSmallPet.Controls.Add(this.GrdSmallPet);
            this.tpgSmallPet.Controls.Add(this.pnlsmallPet);
            this.tpgSmallPet.Location = new System.Drawing.Point(4, 21);
            this.tpgSmallPet.Name = "tpgSmallPet";
            this.tpgSmallPet.Size = new System.Drawing.Size(744, 299);
            this.tpgSmallPet.TabIndex = 2;
            this.tpgSmallPet.Text = "小寵物查詢";
            this.tpgSmallPet.UseVisualStyleBackColor = true;
            // 
            // GrdSmallPet
            // 
            this.GrdSmallPet.AllowUserToAddRows = false;
            this.GrdSmallPet.AllowUserToDeleteRows = false;
            this.GrdSmallPet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdSmallPet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdSmallPet.Location = new System.Drawing.Point(0, 37);
            this.GrdSmallPet.Name = "GrdSmallPet";
            this.GrdSmallPet.ReadOnly = true;
            this.GrdSmallPet.RowTemplate.Height = 23;
            this.GrdSmallPet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdSmallPet.Size = new System.Drawing.Size(744, 262);
            this.GrdSmallPet.TabIndex = 23;
            // 
            // pnlsmallPet
            // 
            this.pnlsmallPet.Controls.Add(this.cmbSmallPet);
            this.pnlsmallPet.Controls.Add(this.lblSmallPet);
            this.pnlsmallPet.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlsmallPet.Location = new System.Drawing.Point(0, 0);
            this.pnlsmallPet.Name = "pnlsmallPet";
            this.pnlsmallPet.Size = new System.Drawing.Size(744, 37);
            this.pnlsmallPet.TabIndex = 21;
            // 
            // cmbSmallPet
            // 
            this.cmbSmallPet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSmallPet.FormattingEnabled = true;
            this.cmbSmallPet.Location = new System.Drawing.Point(124, 8);
            this.cmbSmallPet.Name = "cmbSmallPet";
            this.cmbSmallPet.Size = new System.Drawing.Size(100, 20);
            this.cmbSmallPet.TabIndex = 1;
            this.cmbSmallPet.SelectedIndexChanged += new System.EventHandler(this.cmdSmallPet_SelectedIndexChanged);
            // 
            // lblSmallPet
            // 
            this.lblSmallPet.AutoSize = true;
            this.lblSmallPet.Location = new System.Drawing.Point(20, 13);
            this.lblSmallPet.Name = "lblSmallPet";
            this.lblSmallPet.Size = new System.Drawing.Size(101, 12);
            this.lblSmallPet.TabIndex = 0;
            this.lblSmallPet.Text = "請選擇查看頁數：";
            // 
            // tabSmallPetEggExchange
            // 
            this.tabSmallPetEggExchange.Controls.Add(this.GrdSmallPetEggExchange);
            this.tabSmallPetEggExchange.Controls.Add(this.pnlSmallPetEggExchange);
            this.tabSmallPetEggExchange.Location = new System.Drawing.Point(4, 21);
            this.tabSmallPetEggExchange.Name = "tabSmallPetEggExchange";
            this.tabSmallPetEggExchange.Size = new System.Drawing.Size(744, 299);
            this.tabSmallPetEggExchange.TabIndex = 3;
            this.tabSmallPetEggExchange.Text = "小寵物蛋兌換查詢";
            this.tabSmallPetEggExchange.UseVisualStyleBackColor = true;
            // 
            // GrdSmallPetEggExchange
            // 
            this.GrdSmallPetEggExchange.AllowUserToAddRows = false;
            this.GrdSmallPetEggExchange.AllowUserToDeleteRows = false;
            this.GrdSmallPetEggExchange.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdSmallPetEggExchange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdSmallPetEggExchange.Location = new System.Drawing.Point(0, 37);
            this.GrdSmallPetEggExchange.Name = "GrdSmallPetEggExchange";
            this.GrdSmallPetEggExchange.ReadOnly = true;
            this.GrdSmallPetEggExchange.RowTemplate.Height = 23;
            this.GrdSmallPetEggExchange.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdSmallPetEggExchange.Size = new System.Drawing.Size(744, 262);
            this.GrdSmallPetEggExchange.TabIndex = 26;
            // 
            // pnlSmallPetEggExchange
            // 
            this.pnlSmallPetEggExchange.Controls.Add(this.cmbSmallPetEggExchange);
            this.pnlSmallPetEggExchange.Controls.Add(this.lblSmallPetEggExchange);
            this.pnlSmallPetEggExchange.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSmallPetEggExchange.Location = new System.Drawing.Point(0, 0);
            this.pnlSmallPetEggExchange.Name = "pnlSmallPetEggExchange";
            this.pnlSmallPetEggExchange.Size = new System.Drawing.Size(744, 37);
            this.pnlSmallPetEggExchange.TabIndex = 24;
            // 
            // cmbSmallPetEggExchange
            // 
            this.cmbSmallPetEggExchange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSmallPetEggExchange.FormattingEnabled = true;
            this.cmbSmallPetEggExchange.Location = new System.Drawing.Point(124, 8);
            this.cmbSmallPetEggExchange.Name = "cmbSmallPetEggExchange";
            this.cmbSmallPetEggExchange.Size = new System.Drawing.Size(100, 20);
            this.cmbSmallPetEggExchange.TabIndex = 1;
            this.cmbSmallPetEggExchange.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // lblSmallPetEggExchange
            // 
            this.lblSmallPetEggExchange.AutoSize = true;
            this.lblSmallPetEggExchange.Location = new System.Drawing.Point(20, 13);
            this.lblSmallPetEggExchange.Name = "lblSmallPetEggExchange";
            this.lblSmallPetEggExchange.Size = new System.Drawing.Size(101, 12);
            this.lblSmallPetEggExchange.TabIndex = 0;
            this.lblSmallPetEggExchange.Text = "請選擇查看頁數：";
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.DtpEnd);
            this.GrpSearch.Controls.Add(this.LblLink);
            this.GrpSearch.Controls.Add(this.DtpBegin);
            this.GrpSearch.Controls.Add(this.LblDate);
            this.GrpSearch.Controls.Add(this.btnClose);
            this.GrpSearch.Controls.Add(this.btnSearch);
            this.GrpSearch.Controls.Add(this.txtNick);
            this.GrpSearch.Controls.Add(this.lblNick);
            this.GrpSearch.Controls.Add(this.txtAccount);
            this.GrpSearch.Controls.Add(this.lblAccount);
            this.GrpSearch.Controls.Add(this.cmbServer);
            this.GrpSearch.Controls.Add(this.lblServer);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(752, 140);
            this.GrpSearch.TabIndex = 34;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索條件";
            // 
            // DtpEnd
            // 
            this.DtpEnd.CustomFormat = "yyyy-MM-dd";
            this.DtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpEnd.Location = new System.Drawing.Point(384, 87);
            this.DtpEnd.Name = "DtpEnd";
            this.DtpEnd.Size = new System.Drawing.Size(166, 21);
            this.DtpEnd.TabIndex = 126;
            // 
            // LblLink
            // 
            this.LblLink.AutoSize = true;
            this.LblLink.Location = new System.Drawing.Point(294, 91);
            this.LblLink.Name = "LblLink";
            this.LblLink.Size = new System.Drawing.Size(65, 12);
            this.LblLink.TabIndex = 125;
            this.LblLink.Text = "結束時間：";
            // 
            // DtpBegin
            // 
            this.DtpBegin.CustomFormat = "yyyy-MM-dd";
            this.DtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpBegin.Location = new System.Drawing.Point(384, 55);
            this.DtpBegin.Name = "DtpBegin";
            this.DtpBegin.Size = new System.Drawing.Size(168, 21);
            this.DtpBegin.TabIndex = 124;
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Location = new System.Drawing.Point(294, 59);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(65, 12);
            this.LblDate.TabIndex = 123;
            this.LblDate.Text = "開始時間：";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(588, 80);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "關閉";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(588, 44);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtNick
            // 
            this.txtNick.Location = new System.Drawing.Point(109, 87);
            this.txtNick.Name = "txtNick";
            this.txtNick.Size = new System.Drawing.Size(179, 21);
            this.txtNick.TabIndex = 5;
            // 
            // lblNick
            // 
            this.lblNick.AutoSize = true;
            this.lblNick.Location = new System.Drawing.Point(41, 91);
            this.lblNick.Name = "lblNick";
            this.lblNick.Size = new System.Drawing.Size(65, 12);
            this.lblNick.TabIndex = 4;
            this.lblNick.Text = "玩家昵稱：";
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(109, 52);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(179, 21);
            this.txtAccount.TabIndex = 3;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(41, 55);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(65, 12);
            this.lblAccount.TabIndex = 2;
            this.lblAccount.Text = "玩家帳號：";
            // 
            // cmbServer
            // 
            this.cmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(109, 18);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(179, 20);
            this.cmbServer.TabIndex = 1;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(29, 21);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(77, 12);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "遊戲伺服器：";
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
            // backgroundWorkerPetEgg
            // 
            this.backgroundWorkerPetEgg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerPetEgg_DoWork);
            this.backgroundWorkerPetEgg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerPetEgg_RunWorkerCompleted);
            // 
            // backgroundWorkerSmallPet
            // 
            this.backgroundWorkerSmallPet.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSmallPet_DoWork);
            this.backgroundWorkerSmallPet.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSmallPet_RunWorkerCompleted);
            // 
            // backgroundWorkerReSmallPet
            // 
            this.backgroundWorkerReSmallPet.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReSmallPet_DoWork);
            this.backgroundWorkerReSmallPet.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReSmallPet_RunWorkerCompleted);
            // 
            // backgroundWorkerSmallPetEggExchange
            // 
            this.backgroundWorkerSmallPetEggExchange.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSmallPetEggExchange_DoWork);
            this.backgroundWorkerSmallPetEggExchange.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSmallPetEggExchange_RunWorkerCompleted);
            // 
            // backgroundWorkerReSmallPetEggExchange
            // 
            this.backgroundWorkerReSmallPetEggExchange.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReSmallPetEggExchange_DoWork);
            this.backgroundWorkerReSmallPetEggExchange.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReSmallPetEggExchange_RunWorkerCompleted);
            // 
            // FrmJW2SmallPetsLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 464);
            this.Controls.Add(this.tbcResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmJW2SmallPetsLog";
            this.Text = "小寵物查詢";
            this.Load += new System.EventHandler(this.FrmJW2SmallPetsLog_Load);
            this.tbcResult.ResumeLayout(false);
            this.tpgCharacter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdRoleView)).EndInit();
            this.pnlRoleView.ResumeLayout(false);
            this.pnlRoleView.PerformLayout();
            this.tpgSmallPetEgg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdPetEgg)).EndInit();
            this.pnlPetEgg.ResumeLayout(false);
            this.pnlPetEgg.PerformLayout();
            this.tpgSmallPet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdSmallPet)).EndInit();
            this.pnlsmallPet.ResumeLayout(false);
            this.pnlsmallPet.PerformLayout();
            this.tabSmallPetEggExchange.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdSmallPetEggExchange)).EndInit();
            this.pnlSmallPetEggExchange.ResumeLayout(false);
            this.pnlSmallPetEggExchange.PerformLayout();
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcResult;
        private System.Windows.Forms.TabPage tpgCharacter;
        private System.Windows.Forms.DataGridView GrdRoleView;
        private System.Windows.Forms.Panel pnlRoleView;
        private System.Windows.Forms.ComboBox cmbRoleView;
        private System.Windows.Forms.Label lblRoleView;
        private System.Windows.Forms.TabPage tpgSmallPetEgg;
        private System.Windows.Forms.TabPage tpgSmallPet;
        private System.Windows.Forms.DataGridView GrdSmallPet;
        private System.Windows.Forms.Panel pnlsmallPet;
        private System.Windows.Forms.ComboBox cmbSmallPet;
        private System.Windows.Forms.Label lblSmallPet;
        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtNick;
        private System.Windows.Forms.Label lblNick;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.ComboBox cmbServer;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TabPage tabSmallPetEggExchange;
        private System.Windows.Forms.DataGridView GrdPetEgg;
        private System.Windows.Forms.Panel pnlPetEgg;
        private System.Windows.Forms.ComboBox cmbPetEgg;
        private System.Windows.Forms.Label lblPetEgg;
        private System.Windows.Forms.DataGridView GrdSmallPetEggExchange;
        private System.Windows.Forms.Panel pnlSmallPetEggExchange;
        private System.Windows.Forms.ComboBox cmbSmallPetEggExchange;
        private System.Windows.Forms.Label lblSmallPetEggExchange;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPetEgg;
        private System.ComponentModel.BackgroundWorker backgroundWorkerRePetEgg;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSmallPet;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReSmallPet;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSmallPetEggExchange;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReSmallPetEggExchange;
        private System.Windows.Forms.DateTimePicker DtpEnd;
        private System.Windows.Forms.Label LblLink;
        private System.Windows.Forms.DateTimePicker DtpBegin;
        private System.Windows.Forms.Label LblDate;
    }
}