namespace M_GD
{
    partial class FrmGDAccountManage
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtNick = new System.Windows.Forms.TextBox();
            this.lblNick = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.tbcResult = new System.Windows.Forms.TabControl();
            this.tpgCharacter = new System.Windows.Forms.TabPage();
            this.GrdCharacter = new System.Windows.Forms.DataGridView();
            this.tpgModiLvl = new System.Windows.Forms.TabPage();
            this.pnlModiLvl = new System.Windows.Forms.Panel();
            this.NudNewLvl = new System.Windows.Forms.ComboBox();
            this.txtCharLvl = new System.Windows.Forms.TextBox();
            this.lblCharLvl = new System.Windows.Forms.Label();
            this.btnResetLvl = new System.Windows.Forms.Button();
            this.btnModiLvl = new System.Windows.Forms.Button();
            this.lblNewLvl = new System.Windows.Forms.Label();
            this.tpgAddMoney = new System.Windows.Forms.TabPage();
            this.pnlAddMoney = new System.Windows.Forms.Panel();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblContent = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.btnResetMoney = new System.Windows.Forms.Button();
            this.btnAddMoney = new System.Windows.Forms.Button();
            this.NudMoney = new System.Windows.Forms.NumericUpDown();
            this.txtCharMoney = new System.Windows.Forms.TextBox();
            this.lblCharMoney = new System.Windows.Forms.Label();
            this.lblMoney = new System.Windows.Forms.Label();
            this.tpgModiPwd = new System.Windows.Forms.TabPage();
            this.pnlModiPwd = new System.Windows.Forms.Panel();
            this.btnTempPwd = new System.Windows.Forms.Button();
            this.btnRecoverPwd = new System.Windows.Forms.Button();
            this.txtTempPwd = new System.Windows.Forms.TextBox();
            this.txtCharPwd = new System.Windows.Forms.TextBox();
            this.lblCharPwd = new System.Windows.Forms.Label();
            this.btnModiPwd = new System.Windows.Forms.Button();
            this.lblTempPwd = new System.Windows.Forms.Label();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerModiLvl = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerModiPwd = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerRecoverPwd = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerCheckPwd = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerAddMoney = new System.ComponentModel.BackgroundWorker();
            this.GrpSearch.SuspendLayout();
            this.tbcResult.SuspendLayout();
            this.tpgCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdCharacter)).BeginInit();
            this.tpgModiLvl.SuspendLayout();
            this.pnlModiLvl.SuspendLayout();
            this.tpgAddMoney.SuspendLayout();
            this.pnlAddMoney.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudMoney)).BeginInit();
            this.tpgModiPwd.SuspendLayout();
            this.pnlModiPwd.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
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
            this.GrpSearch.Size = new System.Drawing.Size(861, 133);
            this.GrpSearch.TabIndex = 5;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索条件";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(382, 90);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 31;
            this.btnClose.Text = "壽敕";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(382, 56);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 30;
            this.btnSearch.Text = "刲坰";
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
            this.lblServer.Text = "游戏服务器：";
            // 
            // tbcResult
            // 
            this.tbcResult.Controls.Add(this.tpgCharacter);
            this.tbcResult.Controls.Add(this.tpgModiLvl);
            this.tbcResult.Controls.Add(this.tpgAddMoney);
            this.tbcResult.Controls.Add(this.tpgModiPwd);
            this.tbcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcResult.Location = new System.Drawing.Point(0, 133);
            this.tbcResult.Name = "tbcResult";
            this.tbcResult.SelectedIndex = 0;
            this.tbcResult.Size = new System.Drawing.Size(861, 404);
            this.tbcResult.TabIndex = 6;
            this.tbcResult.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbcResult_Selected);
            // 
            // tpgCharacter
            // 
            this.tpgCharacter.Controls.Add(this.GrdCharacter);
            this.tpgCharacter.Location = new System.Drawing.Point(4, 21);
            this.tpgCharacter.Name = "tpgCharacter";
            this.tpgCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.tpgCharacter.Size = new System.Drawing.Size(853, 379);
            this.tpgCharacter.TabIndex = 0;
            this.tpgCharacter.Text = "玩家角色信息";
            this.tpgCharacter.UseVisualStyleBackColor = true;
            // 
            // GrdCharacter
            // 
            this.GrdCharacter.AllowUserToAddRows = false;
            this.GrdCharacter.AllowUserToDeleteRows = false;
            this.GrdCharacter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdCharacter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdCharacter.Location = new System.Drawing.Point(3, 3);
            this.GrdCharacter.Name = "GrdCharacter";
            this.GrdCharacter.ReadOnly = true;
            this.GrdCharacter.RowTemplate.Height = 23;
            this.GrdCharacter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdCharacter.Size = new System.Drawing.Size(847, 373);
            this.GrdCharacter.TabIndex = 13;
            this.GrdCharacter.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdCharacter_CellDoubleClick);
            this.GrdCharacter.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdCharacter_CellClick);
            // 
            // tpgModiLvl
            // 
            this.tpgModiLvl.Controls.Add(this.pnlModiLvl);
            this.tpgModiLvl.Location = new System.Drawing.Point(4, 21);
            this.tpgModiLvl.Name = "tpgModiLvl";
            this.tpgModiLvl.Size = new System.Drawing.Size(853, 379);
            this.tpgModiLvl.TabIndex = 2;
            this.tpgModiLvl.Text = "修改角色等級";
            this.tpgModiLvl.UseVisualStyleBackColor = true;
            // 
            // pnlModiLvl
            // 
            this.pnlModiLvl.Controls.Add(this.NudNewLvl);
            this.pnlModiLvl.Controls.Add(this.txtCharLvl);
            this.pnlModiLvl.Controls.Add(this.lblCharLvl);
            this.pnlModiLvl.Controls.Add(this.btnResetLvl);
            this.pnlModiLvl.Controls.Add(this.btnModiLvl);
            this.pnlModiLvl.Controls.Add(this.lblNewLvl);
            this.pnlModiLvl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlModiLvl.Location = new System.Drawing.Point(0, 0);
            this.pnlModiLvl.Name = "pnlModiLvl";
            this.pnlModiLvl.Size = new System.Drawing.Size(853, 379);
            this.pnlModiLvl.TabIndex = 0;
            // 
            // NudNewLvl
            // 
            this.NudNewLvl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NudNewLvl.FormattingEnabled = true;
            this.NudNewLvl.Location = new System.Drawing.Point(351, 180);
            this.NudNewLvl.Name = "NudNewLvl";
            this.NudNewLvl.Size = new System.Drawing.Size(169, 20);
            this.NudNewLvl.TabIndex = 10;
            // 
            // txtCharLvl
            // 
            this.txtCharLvl.Location = new System.Drawing.Point(351, 84);
            this.txtCharLvl.Name = "txtCharLvl";
            this.txtCharLvl.ReadOnly = true;
            this.txtCharLvl.Size = new System.Drawing.Size(169, 21);
            this.txtCharLvl.TabIndex = 9;
            // 
            // lblCharLvl
            // 
            this.lblCharLvl.AutoSize = true;
            this.lblCharLvl.Location = new System.Drawing.Point(269, 87);
            this.lblCharLvl.Name = "lblCharLvl";
            this.lblCharLvl.Size = new System.Drawing.Size(65, 12);
            this.lblCharLvl.TabIndex = 8;
            this.lblCharLvl.Text = "玩家帳號：";
            // 
            // btnResetLvl
            // 
            this.btnResetLvl.Location = new System.Drawing.Point(445, 283);
            this.btnResetLvl.Name = "btnResetLvl";
            this.btnResetLvl.Size = new System.Drawing.Size(75, 23);
            this.btnResetLvl.TabIndex = 5;
            this.btnResetLvl.Text = "重置";
            this.btnResetLvl.UseVisualStyleBackColor = true;
            this.btnResetLvl.Click += new System.EventHandler(this.btnResetLvl_Click);
            // 
            // btnModiLvl
            // 
            this.btnModiLvl.Location = new System.Drawing.Point(294, 283);
            this.btnModiLvl.Name = "btnModiLvl";
            this.btnModiLvl.Size = new System.Drawing.Size(75, 23);
            this.btnModiLvl.TabIndex = 4;
            this.btnModiLvl.Text = "更改等級";
            this.btnModiLvl.UseVisualStyleBackColor = true;
            this.btnModiLvl.Click += new System.EventHandler(this.btnModiLvl_Click);
            // 
            // lblNewLvl
            // 
            this.lblNewLvl.AutoSize = true;
            this.lblNewLvl.Location = new System.Drawing.Point(269, 183);
            this.lblNewLvl.Name = "lblNewLvl";
            this.lblNewLvl.Size = new System.Drawing.Size(65, 12);
            this.lblNewLvl.TabIndex = 2;
            this.lblNewLvl.Text = "軍銜等級：";
            // 
            // tpgAddMoney
            // 
            this.tpgAddMoney.Controls.Add(this.pnlAddMoney);
            this.tpgAddMoney.Location = new System.Drawing.Point(4, 21);
            this.tpgAddMoney.Name = "tpgAddMoney";
            this.tpgAddMoney.Size = new System.Drawing.Size(853, 379);
            this.tpgAddMoney.TabIndex = 4;
            this.tpgAddMoney.Text = "添加金錢";
            this.tpgAddMoney.UseVisualStyleBackColor = true;
            // 
            // pnlAddMoney
            // 
            this.pnlAddMoney.Controls.Add(this.txtContent);
            this.pnlAddMoney.Controls.Add(this.lblContent);
            this.pnlAddMoney.Controls.Add(this.lblTitle);
            this.pnlAddMoney.Controls.Add(this.txtTitle);
            this.pnlAddMoney.Controls.Add(this.btnResetMoney);
            this.pnlAddMoney.Controls.Add(this.btnAddMoney);
            this.pnlAddMoney.Controls.Add(this.NudMoney);
            this.pnlAddMoney.Controls.Add(this.txtCharMoney);
            this.pnlAddMoney.Controls.Add(this.lblCharMoney);
            this.pnlAddMoney.Controls.Add(this.lblMoney);
            this.pnlAddMoney.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAddMoney.Location = new System.Drawing.Point(0, 0);
            this.pnlAddMoney.Name = "pnlAddMoney";
            this.pnlAddMoney.Size = new System.Drawing.Size(853, 379);
            this.pnlAddMoney.TabIndex = 0;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(326, 185);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(179, 105);
            this.txtContent.TabIndex = 18;
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(255, 188);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(41, 12);
            this.lblContent.TabIndex = 17;
            this.lblContent.Text = "內容：";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(255, 140);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(41, 12);
            this.lblTitle.TabIndex = 16;
            this.lblTitle.Text = "標題：";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(326, 137);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(179, 21);
            this.txtTitle.TabIndex = 15;
            // 
            // btnResetMoney
            // 
            this.btnResetMoney.Location = new System.Drawing.Point(430, 314);
            this.btnResetMoney.Name = "btnResetMoney";
            this.btnResetMoney.Size = new System.Drawing.Size(75, 23);
            this.btnResetMoney.TabIndex = 14;
            this.btnResetMoney.Text = "重置";
            this.btnResetMoney.UseVisualStyleBackColor = true;
            this.btnResetMoney.Click += new System.EventHandler(this.btnResetMoney_Click);
            // 
            // btnAddMoney
            // 
            this.btnAddMoney.Location = new System.Drawing.Point(257, 314);
            this.btnAddMoney.Name = "btnAddMoney";
            this.btnAddMoney.Size = new System.Drawing.Size(75, 23);
            this.btnAddMoney.TabIndex = 13;
            this.btnAddMoney.Text = "添加G幣";
            this.btnAddMoney.UseVisualStyleBackColor = true;
            this.btnAddMoney.Click += new System.EventHandler(this.btnAddMoney_Click);
            // 
            // NudMoney
            // 
            this.NudMoney.Location = new System.Drawing.Point(326, 88);
            this.NudMoney.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.NudMoney.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudMoney.Name = "NudMoney";
            this.NudMoney.Size = new System.Drawing.Size(179, 21);
            this.NudMoney.TabIndex = 12;
            this.NudMoney.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtCharMoney
            // 
            this.txtCharMoney.Location = new System.Drawing.Point(326, 40);
            this.txtCharMoney.Name = "txtCharMoney";
            this.txtCharMoney.ReadOnly = true;
            this.txtCharMoney.Size = new System.Drawing.Size(179, 21);
            this.txtCharMoney.TabIndex = 11;
            // 
            // lblCharMoney
            // 
            this.lblCharMoney.AutoSize = true;
            this.lblCharMoney.Location = new System.Drawing.Point(255, 43);
            this.lblCharMoney.Name = "lblCharMoney";
            this.lblCharMoney.Size = new System.Drawing.Size(65, 12);
            this.lblCharMoney.TabIndex = 10;
            this.lblCharMoney.Text = "玩家帳號：";
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Location = new System.Drawing.Point(255, 90);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(59, 12);
            this.lblMoney.TabIndex = 9;
            this.lblMoney.Text = "G幣數量：";
            // 
            // tpgModiPwd
            // 
            this.tpgModiPwd.Controls.Add(this.pnlModiPwd);
            this.tpgModiPwd.Location = new System.Drawing.Point(4, 21);
            this.tpgModiPwd.Name = "tpgModiPwd";
            this.tpgModiPwd.Size = new System.Drawing.Size(853, 379);
            this.tpgModiPwd.TabIndex = 3;
            this.tpgModiPwd.Text = "修改臨時密碼";
            this.tpgModiPwd.UseVisualStyleBackColor = true;
            // 
            // pnlModiPwd
            // 
            this.pnlModiPwd.Controls.Add(this.btnTempPwd);
            this.pnlModiPwd.Controls.Add(this.btnRecoverPwd);
            this.pnlModiPwd.Controls.Add(this.txtTempPwd);
            this.pnlModiPwd.Controls.Add(this.txtCharPwd);
            this.pnlModiPwd.Controls.Add(this.lblCharPwd);
            this.pnlModiPwd.Controls.Add(this.btnModiPwd);
            this.pnlModiPwd.Controls.Add(this.lblTempPwd);
            this.pnlModiPwd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlModiPwd.Location = new System.Drawing.Point(0, 0);
            this.pnlModiPwd.Name = "pnlModiPwd";
            this.pnlModiPwd.Size = new System.Drawing.Size(853, 379);
            this.pnlModiPwd.TabIndex = 0;
            // 
            // btnTempPwd
            // 
            this.btnTempPwd.Location = new System.Drawing.Point(535, 190);
            this.btnTempPwd.Name = "btnTempPwd";
            this.btnTempPwd.Size = new System.Drawing.Size(93, 23);
            this.btnTempPwd.TabIndex = 10;
            this.btnTempPwd.Text = "查看临时密码";
            this.btnTempPwd.UseVisualStyleBackColor = true;
            this.btnTempPwd.Click += new System.EventHandler(this.btnTempPwd_Click);
            // 
            // btnRecoverPwd
            // 
            this.btnRecoverPwd.Location = new System.Drawing.Point(535, 161);
            this.btnRecoverPwd.Name = "btnRecoverPwd";
            this.btnRecoverPwd.Size = new System.Drawing.Size(93, 23);
            this.btnRecoverPwd.TabIndex = 9;
            this.btnRecoverPwd.Text = "恢复密码";
            this.btnRecoverPwd.UseVisualStyleBackColor = true;
            this.btnRecoverPwd.Click += new System.EventHandler(this.btnRecoverPwd_Click);
            // 
            // txtTempPwd
            // 
            this.txtTempPwd.Location = new System.Drawing.Point(281, 192);
            this.txtTempPwd.Name = "txtTempPwd";
            this.txtTempPwd.Size = new System.Drawing.Size(179, 21);
            this.txtTempPwd.TabIndex = 8;
            // 
            // txtCharPwd
            // 
            this.txtCharPwd.Location = new System.Drawing.Point(281, 132);
            this.txtCharPwd.Name = "txtCharPwd";
            this.txtCharPwd.ReadOnly = true;
            this.txtCharPwd.Size = new System.Drawing.Size(179, 21);
            this.txtCharPwd.TabIndex = 7;
            // 
            // lblCharPwd
            // 
            this.lblCharPwd.AutoSize = true;
            this.lblCharPwd.Location = new System.Drawing.Point(210, 135);
            this.lblCharPwd.Name = "lblCharPwd";
            this.lblCharPwd.Size = new System.Drawing.Size(65, 12);
            this.lblCharPwd.TabIndex = 6;
            this.lblCharPwd.Text = "玩家帐号：";
            // 
            // btnModiPwd
            // 
            this.btnModiPwd.Location = new System.Drawing.Point(535, 132);
            this.btnModiPwd.Name = "btnModiPwd";
            this.btnModiPwd.Size = new System.Drawing.Size(93, 23);
            this.btnModiPwd.TabIndex = 4;
            this.btnModiPwd.Text = "更改临时密码";
            this.btnModiPwd.UseVisualStyleBackColor = true;
            this.btnModiPwd.Click += new System.EventHandler(this.btnModiPwd_Click);
            // 
            // lblTempPwd
            // 
            this.lblTempPwd.AutoSize = true;
            this.lblTempPwd.Location = new System.Drawing.Point(210, 195);
            this.lblTempPwd.Name = "lblTempPwd";
            this.lblTempPwd.Size = new System.Drawing.Size(65, 12);
            this.lblTempPwd.TabIndex = 2;
            this.lblTempPwd.Text = "临时密码：";
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
            // backgroundWorkerModiLvl
            // 
            this.backgroundWorkerModiLvl.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerModiLvl_DoWork);
            this.backgroundWorkerModiLvl.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerModiLvl_RunWorkerCompleted);
            // 
            // backgroundWorkerModiPwd
            // 
            this.backgroundWorkerModiPwd.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerModiPwd_DoWork);
            this.backgroundWorkerModiPwd.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerModiPwd_RunWorkerCompleted);
            // 
            // backgroundWorkerRecoverPwd
            // 
            this.backgroundWorkerRecoverPwd.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerRecoverPwd_DoWork);
            this.backgroundWorkerRecoverPwd.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerRecoverPwd_RunWorkerCompleted);
            // 
            // backgroundWorkerCheckPwd
            // 
            this.backgroundWorkerCheckPwd.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCheckPwd_DoWork);
            this.backgroundWorkerCheckPwd.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCheckPwd_RunWorkerCompleted);
            // 
            // backgroundWorkerAddMoney
            // 
            this.backgroundWorkerAddMoney.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerAddMoney_DoWork);
            this.backgroundWorkerAddMoney.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerAddMoney_RunWorkerCompleted);
            // 
            // FrmGDAccountManage
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(861, 537);
            this.Controls.Add(this.tbcResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmGDAccountManage";
            this.Text = "玩家帐号管理";
            this.Load += new System.EventHandler(this.FrmGDAccountManage_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.tbcResult.ResumeLayout(false);
            this.tpgCharacter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdCharacter)).EndInit();
            this.tpgModiLvl.ResumeLayout(false);
            this.pnlModiLvl.ResumeLayout(false);
            this.pnlModiLvl.PerformLayout();
            this.tpgAddMoney.ResumeLayout(false);
            this.pnlAddMoney.ResumeLayout(false);
            this.pnlAddMoney.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudMoney)).EndInit();
            this.tpgModiPwd.ResumeLayout(false);
            this.pnlModiPwd.ResumeLayout(false);
            this.pnlModiPwd.PerformLayout();
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
        private System.Windows.Forms.DataGridView GrdCharacter;
        private System.Windows.Forms.TabPage tpgModiLvl;
        private System.Windows.Forms.Panel pnlModiLvl;
        private System.Windows.Forms.TextBox txtCharLvl;
        private System.Windows.Forms.Label lblCharLvl;
        private System.Windows.Forms.Button btnResetLvl;
        private System.Windows.Forms.Button btnModiLvl;
        private System.Windows.Forms.Label lblNewLvl;
        private System.Windows.Forms.TabPage tpgModiPwd;
        private System.Windows.Forms.Panel pnlModiPwd;
        private System.Windows.Forms.TextBox txtCharPwd;
        private System.Windows.Forms.Label lblCharPwd;
        private System.Windows.Forms.Button btnModiPwd;
        private System.Windows.Forms.Label lblTempPwd;
        private System.Windows.Forms.TextBox txtTempPwd;
        private System.Windows.Forms.Button btnRecoverPwd;
        private System.Windows.Forms.Button btnTempPwd;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerModiLvl;
        private System.ComponentModel.BackgroundWorker backgroundWorkerModiPwd;
        private System.ComponentModel.BackgroundWorker backgroundWorkerRecoverPwd;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCheckPwd;
        private System.Windows.Forms.TabPage tpgAddMoney;
        private System.Windows.Forms.Panel pnlAddMoney;
        private System.Windows.Forms.Button btnResetMoney;
        private System.Windows.Forms.Button btnAddMoney;
        private System.Windows.Forms.NumericUpDown NudMoney;
        private System.Windows.Forms.TextBox txtCharMoney;
        private System.Windows.Forms.Label lblCharMoney;
        private System.Windows.Forms.Label lblMoney;
        private System.ComponentModel.BackgroundWorker backgroundWorkerAddMoney;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ComboBox NudNewLvl;
    }
}