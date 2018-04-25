namespace M_JW2
{
    partial class FrmJW2BanPlayer
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblHintCheck = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtNick = new System.Windows.Forms.TextBox();
            this.lblNick = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.tbcResult = new System.Windows.Forms.TabControl();
            this.tpgCharacter = new System.Windows.Forms.TabPage();
            this.GrdResult = new System.Windows.Forms.DataGridView();
            this.tpgBanPlayer = new System.Windows.Forms.TabPage();
            this.pnlBanPlayer = new System.Windows.Forms.Panel();
            this.DptBanEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblBanEndTime = new System.Windows.Forms.Label();
            this.btnResetBan = new System.Windows.Forms.Button();
            this.btnBanAccount = new System.Windows.Forms.Button();
            this.txtBanReason = new System.Windows.Forms.TextBox();
            this.lblBanReason = new System.Windows.Forms.Label();
            this.txtBanAccount = new System.Windows.Forms.TextBox();
            this.lblBanAccount = new System.Windows.Forms.Label();
            this.tpgAllBanPlayer = new System.Windows.Forms.TabPage();
            this.GrdCharacter = new System.Windows.Forms.DataGridView();
            this.pnlListPage = new System.Windows.Forms.Panel();
            this.cmbListPage = new System.Windows.Forms.ComboBox();
            this.lblListPage = new System.Windows.Forms.Label();
            this.tpgUnBind = new System.Windows.Forms.TabPage();
            this.pnlUnBind = new System.Windows.Forms.Panel();
            this.txtUnBindReason = new System.Windows.Forms.TextBox();
            this.lblUnBindReason = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnUnBind = new System.Windows.Forms.Button();
            this.txtUnBindAccount = new System.Windows.Forms.TextBox();
            this.lblUnBindAccount = new System.Windows.Forms.Label();
            this.tpgSearchBan = new System.Windows.Forms.TabPage();
            this.GrdIsBan = new System.Windows.Forms.DataGridView();
            this.pnlQueryAccount = new System.Windows.Forms.Panel();
            this.btnResetInfo = new System.Windows.Forms.Button();
            this.btnSearchInfo = new System.Windows.Forms.Button();
            this.txtQueryAccount = new System.Windows.Forms.TextBox();
            this.lblQueryAccount = new System.Windows.Forms.Label();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerBanPlayer = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerBanList = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReBanList = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerUnBind = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerQueryBan = new System.ComponentModel.BackgroundWorker();
            this.GrpSearch.SuspendLayout();
            this.tbcResult.SuspendLayout();
            this.tpgCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdResult)).BeginInit();
            this.tpgBanPlayer.SuspendLayout();
            this.pnlBanPlayer.SuspendLayout();
            this.tpgAllBanPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdCharacter)).BeginInit();
            this.pnlListPage.SuspendLayout();
            this.tpgUnBind.SuspendLayout();
            this.pnlUnBind.SuspendLayout();
            this.tpgSearchBan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdIsBan)).BeginInit();
            this.pnlQueryAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.label1);
            this.GrpSearch.Controls.Add(this.lblHintCheck);
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
            this.GrpSearch.Size = new System.Drawing.Size(918, 133);
            this.GrpSearch.TabIndex = 4;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索條件";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(498, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(389, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "雙擊查詢玩家帳號封停與否中的帳號資訊可以進入解封玩家帳號進行解封";
            // 
            // lblHintCheck
            // 
            this.lblHintCheck.AutoSize = true;
            this.lblHintCheck.BackColor = System.Drawing.SystemColors.Control;
            this.lblHintCheck.ForeColor = System.Drawing.Color.Red;
            this.lblHintCheck.Location = new System.Drawing.Point(463, 56);
            this.lblHintCheck.Name = "lblHintCheck";
            this.lblHintCheck.Size = new System.Drawing.Size(305, 12);
            this.lblHintCheck.TabIndex = 32;
            this.lblHintCheck.Text = "提示：當玩家帳號和昵稱為空時，可以查詢封停帳號列表";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(382, 90);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 31;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(382, 56);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 30;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            // cmbServer
            // 
            this.cmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(107, 25);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(187, 20);
            this.cmbServer.TabIndex = 25;
            this.cmbServer.SelectedIndexChanged += new System.EventHandler(this.cmbServer_SelectedIndexChanged);
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
            this.tbcResult.Controls.Add(this.tpgBanPlayer);
            this.tbcResult.Controls.Add(this.tpgAllBanPlayer);
            this.tbcResult.Controls.Add(this.tpgUnBind);
            this.tbcResult.Controls.Add(this.tpgSearchBan);
            this.tbcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcResult.Location = new System.Drawing.Point(0, 133);
            this.tbcResult.Name = "tbcResult";
            this.tbcResult.SelectedIndex = 0;
            this.tbcResult.Size = new System.Drawing.Size(918, 446);
            this.tbcResult.TabIndex = 5;
            this.tbcResult.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbcResult_Selected);
            // 
            // tpgCharacter
            // 
            this.tpgCharacter.Controls.Add(this.GrdResult);
            this.tpgCharacter.Location = new System.Drawing.Point(4, 21);
            this.tpgCharacter.Name = "tpgCharacter";
            this.tpgCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.tpgCharacter.Size = new System.Drawing.Size(910, 421);
            this.tpgCharacter.TabIndex = 4;
            this.tpgCharacter.Text = "玩家基本資訊";
            this.tpgCharacter.UseVisualStyleBackColor = true;
            // 
            // GrdResult
            // 
            this.GrdResult.AllowUserToAddRows = false;
            this.GrdResult.AllowUserToDeleteRows = false;
            this.GrdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdResult.Location = new System.Drawing.Point(3, 3);
            this.GrdResult.Name = "GrdResult";
            this.GrdResult.ReadOnly = true;
            this.GrdResult.RowTemplate.Height = 23;
            this.GrdResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdResult.Size = new System.Drawing.Size(904, 415);
            this.GrdResult.TabIndex = 13;
            this.GrdResult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdResult_CellDoubleClick);
            this.GrdResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdResult_CellClick);
            // 
            // tpgBanPlayer
            // 
            this.tpgBanPlayer.Controls.Add(this.pnlBanPlayer);
            this.tpgBanPlayer.Location = new System.Drawing.Point(4, 21);
            this.tpgBanPlayer.Name = "tpgBanPlayer";
            this.tpgBanPlayer.Size = new System.Drawing.Size(910, 421);
            this.tpgBanPlayer.TabIndex = 2;
            this.tpgBanPlayer.Text = "封停玩家帳號";
            this.tpgBanPlayer.UseVisualStyleBackColor = true;
            // 
            // pnlBanPlayer
            // 
            this.pnlBanPlayer.Controls.Add(this.DptBanEndTime);
            this.pnlBanPlayer.Controls.Add(this.lblBanEndTime);
            this.pnlBanPlayer.Controls.Add(this.btnResetBan);
            this.pnlBanPlayer.Controls.Add(this.btnBanAccount);
            this.pnlBanPlayer.Controls.Add(this.txtBanReason);
            this.pnlBanPlayer.Controls.Add(this.lblBanReason);
            this.pnlBanPlayer.Controls.Add(this.txtBanAccount);
            this.pnlBanPlayer.Controls.Add(this.lblBanAccount);
            this.pnlBanPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBanPlayer.Location = new System.Drawing.Point(0, 0);
            this.pnlBanPlayer.Name = "pnlBanPlayer";
            this.pnlBanPlayer.Size = new System.Drawing.Size(910, 421);
            this.pnlBanPlayer.TabIndex = 0;
            // 
            // DptBanEndTime
            // 
            this.DptBanEndTime.CustomFormat = "yyyy-MM-dd";
            this.DptBanEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DptBanEndTime.Location = new System.Drawing.Point(138, 102);
            this.DptBanEndTime.Name = "DptBanEndTime";
            this.DptBanEndTime.ShowUpDown = true;
            this.DptBanEndTime.Size = new System.Drawing.Size(88, 21);
            this.DptBanEndTime.TabIndex = 36;
            this.DptBanEndTime.Visible = false;
            // 
            // lblBanEndTime
            // 
            this.lblBanEndTime.AutoSize = true;
            this.lblBanEndTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBanEndTime.Location = new System.Drawing.Point(43, 106);
            this.lblBanEndTime.Name = "lblBanEndTime";
            this.lblBanEndTime.Size = new System.Drawing.Size(89, 12);
            this.lblBanEndTime.TabIndex = 35;
            this.lblBanEndTime.Text = "封停截止時間：";
            this.lblBanEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBanEndTime.Visible = false;
            // 
            // btnResetBan
            // 
            this.btnResetBan.Location = new System.Drawing.Point(429, 53);
            this.btnResetBan.Name = "btnResetBan";
            this.btnResetBan.Size = new System.Drawing.Size(75, 23);
            this.btnResetBan.TabIndex = 5;
            this.btnResetBan.Text = "重置";
            this.btnResetBan.UseVisualStyleBackColor = true;
            this.btnResetBan.Click += new System.EventHandler(this.btnResetBan_Click);
            // 
            // btnBanAccount
            // 
            this.btnBanAccount.Location = new System.Drawing.Point(313, 53);
            this.btnBanAccount.Name = "btnBanAccount";
            this.btnBanAccount.Size = new System.Drawing.Size(91, 23);
            this.btnBanAccount.TabIndex = 4;
            this.btnBanAccount.Text = "封停帳號";
            this.btnBanAccount.UseVisualStyleBackColor = true;
            this.btnBanAccount.Click += new System.EventHandler(this.btnBanAccount_Click);
            // 
            // txtBanReason
            // 
            this.txtBanReason.Location = new System.Drawing.Point(45, 178);
            this.txtBanReason.Multiline = true;
            this.txtBanReason.Name = "txtBanReason";
            this.txtBanReason.Size = new System.Drawing.Size(459, 185);
            this.txtBanReason.TabIndex = 3;
            // 
            // lblBanReason
            // 
            this.lblBanReason.AutoSize = true;
            this.lblBanReason.Location = new System.Drawing.Point(43, 152);
            this.lblBanReason.Name = "lblBanReason";
            this.lblBanReason.Size = new System.Drawing.Size(65, 12);
            this.lblBanReason.TabIndex = 2;
            this.lblBanReason.Text = "封停原因：";
            // 
            // txtBanAccount
            // 
            this.txtBanAccount.Location = new System.Drawing.Point(45, 56);
            this.txtBanAccount.Name = "txtBanAccount";
            this.txtBanAccount.ReadOnly = true;
            this.txtBanAccount.Size = new System.Drawing.Size(245, 21);
            this.txtBanAccount.TabIndex = 1;
            // 
            // lblBanAccount
            // 
            this.lblBanAccount.AutoSize = true;
            this.lblBanAccount.Location = new System.Drawing.Point(43, 30);
            this.lblBanAccount.Name = "lblBanAccount";
            this.lblBanAccount.Size = new System.Drawing.Size(113, 12);
            this.lblBanAccount.TabIndex = 0;
            this.lblBanAccount.Text = "待封停的玩家帳號：";
            // 
            // tpgAllBanPlayer
            // 
            this.tpgAllBanPlayer.Controls.Add(this.GrdCharacter);
            this.tpgAllBanPlayer.Controls.Add(this.pnlListPage);
            this.tpgAllBanPlayer.Location = new System.Drawing.Point(4, 21);
            this.tpgAllBanPlayer.Name = "tpgAllBanPlayer";
            this.tpgAllBanPlayer.Padding = new System.Windows.Forms.Padding(3);
            this.tpgAllBanPlayer.Size = new System.Drawing.Size(910, 421);
            this.tpgAllBanPlayer.TabIndex = 0;
            this.tpgAllBanPlayer.Text = "封停帳號列表";
            this.tpgAllBanPlayer.UseVisualStyleBackColor = true;
            // 
            // GrdCharacter
            // 
            this.GrdCharacter.AllowUserToAddRows = false;
            this.GrdCharacter.AllowUserToDeleteRows = false;
            this.GrdCharacter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdCharacter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdCharacter.Location = new System.Drawing.Point(3, 45);
            this.GrdCharacter.Name = "GrdCharacter";
            this.GrdCharacter.ReadOnly = true;
            this.GrdCharacter.RowTemplate.Height = 23;
            this.GrdCharacter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdCharacter.Size = new System.Drawing.Size(904, 373);
            this.GrdCharacter.TabIndex = 13;
            this.GrdCharacter.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdCharacter_CellDoubleClick);
            this.GrdCharacter.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdCharacter_CellClick);
            // 
            // pnlListPage
            // 
            this.pnlListPage.Controls.Add(this.cmbListPage);
            this.pnlListPage.Controls.Add(this.lblListPage);
            this.pnlListPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlListPage.Location = new System.Drawing.Point(3, 3);
            this.pnlListPage.Name = "pnlListPage";
            this.pnlListPage.Size = new System.Drawing.Size(904, 42);
            this.pnlListPage.TabIndex = 0;
            // 
            // cmbListPage
            // 
            this.cmbListPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListPage.FormattingEnabled = true;
            this.cmbListPage.Location = new System.Drawing.Point(117, 11);
            this.cmbListPage.Name = "cmbListPage";
            this.cmbListPage.Size = new System.Drawing.Size(95, 20);
            this.cmbListPage.TabIndex = 1;
            this.cmbListPage.SelectedIndexChanged += new System.EventHandler(this.cmbListPage_SelectedIndexChanged);
            // 
            // lblListPage
            // 
            this.lblListPage.AutoSize = true;
            this.lblListPage.Location = new System.Drawing.Point(15, 16);
            this.lblListPage.Name = "lblListPage";
            this.lblListPage.Size = new System.Drawing.Size(101, 12);
            this.lblListPage.TabIndex = 0;
            this.lblListPage.Text = "请选择查看页数：";
            // 
            // tpgUnBind
            // 
            this.tpgUnBind.Controls.Add(this.pnlUnBind);
            this.tpgUnBind.Location = new System.Drawing.Point(4, 21);
            this.tpgUnBind.Name = "tpgUnBind";
            this.tpgUnBind.Padding = new System.Windows.Forms.Padding(3);
            this.tpgUnBind.Size = new System.Drawing.Size(910, 421);
            this.tpgUnBind.TabIndex = 1;
            this.tpgUnBind.Text = "解封玩家帳號";
            this.tpgUnBind.UseVisualStyleBackColor = true;
            // 
            // pnlUnBind
            // 
            this.pnlUnBind.Controls.Add(this.txtUnBindReason);
            this.pnlUnBind.Controls.Add(this.lblUnBindReason);
            this.pnlUnBind.Controls.Add(this.btnReset);
            this.pnlUnBind.Controls.Add(this.btnUnBind);
            this.pnlUnBind.Controls.Add(this.txtUnBindAccount);
            this.pnlUnBind.Controls.Add(this.lblUnBindAccount);
            this.pnlUnBind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUnBind.Location = new System.Drawing.Point(3, 3);
            this.pnlUnBind.Name = "pnlUnBind";
            this.pnlUnBind.Size = new System.Drawing.Size(904, 415);
            this.pnlUnBind.TabIndex = 0;
            // 
            // txtUnBindReason
            // 
            this.txtUnBindReason.Location = new System.Drawing.Point(56, 146);
            this.txtUnBindReason.Multiline = true;
            this.txtUnBindReason.Name = "txtUnBindReason";
            this.txtUnBindReason.Size = new System.Drawing.Size(483, 162);
            this.txtUnBindReason.TabIndex = 5;
            // 
            // lblUnBindReason
            // 
            this.lblUnBindReason.AutoSize = true;
            this.lblUnBindReason.Location = new System.Drawing.Point(54, 114);
            this.lblUnBindReason.Name = "lblUnBindReason";
            this.lblUnBindReason.Size = new System.Drawing.Size(65, 12);
            this.lblUnBindReason.TabIndex = 4;
            this.lblUnBindReason.Text = "解封原因：";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(464, 64);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnUnBind
            // 
            this.btnUnBind.Location = new System.Drawing.Point(336, 64);
            this.btnUnBind.Name = "btnUnBind";
            this.btnUnBind.Size = new System.Drawing.Size(97, 23);
            this.btnUnBind.TabIndex = 2;
            this.btnUnBind.Text = "解封账号";
            this.btnUnBind.UseVisualStyleBackColor = true;
            this.btnUnBind.Click += new System.EventHandler(this.btnUnBind_Click);
            // 
            // txtUnBindAccount
            // 
            this.txtUnBindAccount.Location = new System.Drawing.Point(54, 67);
            this.txtUnBindAccount.Name = "txtUnBindAccount";
            this.txtUnBindAccount.ReadOnly = true;
            this.txtUnBindAccount.Size = new System.Drawing.Size(233, 21);
            this.txtUnBindAccount.TabIndex = 1;
            // 
            // lblUnBindAccount
            // 
            this.lblUnBindAccount.AutoSize = true;
            this.lblUnBindAccount.Location = new System.Drawing.Point(52, 37);
            this.lblUnBindAccount.Name = "lblUnBindAccount";
            this.lblUnBindAccount.Size = new System.Drawing.Size(113, 12);
            this.lblUnBindAccount.TabIndex = 0;
            this.lblUnBindAccount.Text = "待解封的玩家帐号：";
            // 
            // tpgSearchBan
            // 
            this.tpgSearchBan.Controls.Add(this.GrdIsBan);
            this.tpgSearchBan.Controls.Add(this.pnlQueryAccount);
            this.tpgSearchBan.Location = new System.Drawing.Point(4, 21);
            this.tpgSearchBan.Name = "tpgSearchBan";
            this.tpgSearchBan.Size = new System.Drawing.Size(910, 421);
            this.tpgSearchBan.TabIndex = 5;
            this.tpgSearchBan.Text = "查詢玩家帳號封停與否";
            this.tpgSearchBan.UseVisualStyleBackColor = true;
            // 
            // GrdIsBan
            // 
            this.GrdIsBan.AllowUserToAddRows = false;
            this.GrdIsBan.AllowUserToDeleteRows = false;
            this.GrdIsBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdIsBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdIsBan.Location = new System.Drawing.Point(0, 51);
            this.GrdIsBan.Name = "GrdIsBan";
            this.GrdIsBan.ReadOnly = true;
            this.GrdIsBan.RowTemplate.Height = 23;
            this.GrdIsBan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdIsBan.Size = new System.Drawing.Size(910, 370);
            this.GrdIsBan.TabIndex = 17;
            this.GrdIsBan.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdIsBan_CellDoubleClick);
            // 
            // pnlQueryAccount
            // 
            this.pnlQueryAccount.Controls.Add(this.btnResetInfo);
            this.pnlQueryAccount.Controls.Add(this.btnSearchInfo);
            this.pnlQueryAccount.Controls.Add(this.txtQueryAccount);
            this.pnlQueryAccount.Controls.Add(this.lblQueryAccount);
            this.pnlQueryAccount.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQueryAccount.Location = new System.Drawing.Point(0, 0);
            this.pnlQueryAccount.Name = "pnlQueryAccount";
            this.pnlQueryAccount.Size = new System.Drawing.Size(910, 51);
            this.pnlQueryAccount.TabIndex = 15;
            // 
            // btnResetInfo
            // 
            this.btnResetInfo.Location = new System.Drawing.Point(508, 13);
            this.btnResetInfo.Name = "btnResetInfo";
            this.btnResetInfo.Size = new System.Drawing.Size(75, 23);
            this.btnResetInfo.TabIndex = 33;
            this.btnResetInfo.Text = "重置";
            this.btnResetInfo.UseVisualStyleBackColor = true;
            this.btnResetInfo.Click += new System.EventHandler(this.btnResetInfo_Click);
            // 
            // btnSearchInfo
            // 
            this.btnSearchInfo.Location = new System.Drawing.Point(396, 13);
            this.btnSearchInfo.Name = "btnSearchInfo";
            this.btnSearchInfo.Size = new System.Drawing.Size(75, 23);
            this.btnSearchInfo.TabIndex = 32;
            this.btnSearchInfo.Text = "搜索";
            this.btnSearchInfo.UseVisualStyleBackColor = true;
            this.btnSearchInfo.Click += new System.EventHandler(this.btnSearchInfo_Click);
            // 
            // txtQueryAccount
            // 
            this.txtQueryAccount.Location = new System.Drawing.Point(122, 15);
            this.txtQueryAccount.Name = "txtQueryAccount";
            this.txtQueryAccount.Size = new System.Drawing.Size(237, 21);
            this.txtQueryAccount.TabIndex = 1;
            // 
            // lblQueryAccount
            // 
            this.lblQueryAccount.AutoSize = true;
            this.lblQueryAccount.Location = new System.Drawing.Point(50, 18);
            this.lblQueryAccount.Name = "lblQueryAccount";
            this.lblQueryAccount.Size = new System.Drawing.Size(65, 12);
            this.lblQueryAccount.TabIndex = 0;
            this.lblQueryAccount.Text = "玩家帐号：";
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
            // backgroundWorkerBanPlayer
            // 
            this.backgroundWorkerBanPlayer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerBanPlayer_DoWork);
            this.backgroundWorkerBanPlayer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerBanPlayer_RunWorkerCompleted);
            // 
            // backgroundWorkerBanList
            // 
            this.backgroundWorkerBanList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerBanList_DoWork);
            this.backgroundWorkerBanList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerBanList_RunWorkerCompleted);
            // 
            // backgroundWorkerReBanList
            // 
            this.backgroundWorkerReBanList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReBanList_DoWork);
            this.backgroundWorkerReBanList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReBanList_RunWorkerCompleted);
            // 
            // backgroundWorkerUnBind
            // 
            this.backgroundWorkerUnBind.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerUnBind_DoWork);
            this.backgroundWorkerUnBind.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerUnBind_RunWorkerCompleted);
            // 
            // backgroundWorkerQueryBan
            // 
            this.backgroundWorkerQueryBan.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerQueryBan_DoWork);
            this.backgroundWorkerQueryBan.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerQueryBan_RunWorkerCompleted);
            // 
            // FrmJW2BanPlayer
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(918, 579);
            this.Controls.Add(this.tbcResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmJW2BanPlayer";
            this.Text = "玩家帳號解/封停";
            this.Load += new System.EventHandler(this.FrmJW2BanPlayer_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.tbcResult.ResumeLayout(false);
            this.tpgCharacter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdResult)).EndInit();
            this.tpgBanPlayer.ResumeLayout(false);
            this.pnlBanPlayer.ResumeLayout(false);
            this.pnlBanPlayer.PerformLayout();
            this.tpgAllBanPlayer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdCharacter)).EndInit();
            this.pnlListPage.ResumeLayout(false);
            this.pnlListPage.PerformLayout();
            this.tpgUnBind.ResumeLayout(false);
            this.pnlUnBind.ResumeLayout(false);
            this.pnlUnBind.PerformLayout();
            this.tpgSearchBan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdIsBan)).EndInit();
            this.pnlQueryAccount.ResumeLayout(false);
            this.pnlQueryAccount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtNick;
        private System.Windows.Forms.Label lblNick;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.ComboBox cmbServer;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TabControl tbcResult;
        private System.Windows.Forms.TabPage tpgCharacter;
        private System.Windows.Forms.DataGridView GrdResult;
        private System.Windows.Forms.TabPage tpgBanPlayer;
        private System.Windows.Forms.Panel pnlBanPlayer;
        private System.Windows.Forms.Button btnResetBan;
        private System.Windows.Forms.Button btnBanAccount;
        private System.Windows.Forms.TextBox txtBanReason;
        private System.Windows.Forms.Label lblBanReason;
        private System.Windows.Forms.TextBox txtBanAccount;
        private System.Windows.Forms.Label lblBanAccount;
        private System.Windows.Forms.TabPage tpgAllBanPlayer;
        private System.Windows.Forms.DataGridView GrdCharacter;
        private System.Windows.Forms.Panel pnlListPage;
        private System.Windows.Forms.ComboBox cmbListPage;
        private System.Windows.Forms.Label lblListPage;
        private System.Windows.Forms.TabPage tpgUnBind;
        private System.Windows.Forms.Panel pnlUnBind;
        private System.Windows.Forms.TextBox txtUnBindReason;
        private System.Windows.Forms.Label lblUnBindReason;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnUnBind;
        private System.Windows.Forms.TextBox txtUnBindAccount;
        private System.Windows.Forms.Label lblUnBindAccount;
        private System.Windows.Forms.Label lblHintCheck;
        private System.Windows.Forms.DateTimePicker DptBanEndTime;
        private System.Windows.Forms.Label lblBanEndTime;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerBanPlayer;
        private System.ComponentModel.BackgroundWorker backgroundWorkerBanList;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReBanList;
        private System.ComponentModel.BackgroundWorker backgroundWorkerUnBind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tpgSearchBan;
        private System.Windows.Forms.Panel pnlQueryAccount;
        private System.Windows.Forms.Button btnResetInfo;
        private System.Windows.Forms.Button btnSearchInfo;
        private System.Windows.Forms.TextBox txtQueryAccount;
        private System.Windows.Forms.Label lblQueryAccount;
        private System.ComponentModel.BackgroundWorker backgroundWorkerQueryBan;
        private System.Windows.Forms.DataGridView GrdIsBan;
    }
}