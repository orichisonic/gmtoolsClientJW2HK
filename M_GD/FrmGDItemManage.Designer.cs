namespace M_GD
{
    partial class FrmGDItemManage
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnBatchAdd = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
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
            this.tpgMixTreeItems = new System.Windows.Forms.TabPage();
            this.GrdMixItems = new System.Windows.Forms.DataGridView();
            this.pnlMixItems = new System.Windows.Forms.Panel();
            this.cmbMixItems = new System.Windows.Forms.ComboBox();
            this.lblMixItems = new System.Windows.Forms.Label();
            this.tpgUserUnits = new System.Windows.Forms.TabPage();
            this.GrdUnits = new System.Windows.Forms.DataGridView();
            this.pnlUnits = new System.Windows.Forms.Panel();
            this.cmbUnits = new System.Windows.Forms.ComboBox();
            this.lblUnits = new System.Windows.Forms.Label();
            this.tpgCombatItems = new System.Windows.Forms.TabPage();
            this.GrdCombatItems = new System.Windows.Forms.DataGridView();
            this.pnlCombatItems = new System.Windows.Forms.Panel();
            this.cmbCombatItems = new System.Windows.Forms.ComboBox();
            this.lblCombatItems = new System.Windows.Forms.Label();
            this.tpgOperators = new System.Windows.Forms.TabPage();
            this.GrdOperators = new System.Windows.Forms.DataGridView();
            this.pnlOperators = new System.Windows.Forms.Panel();
            this.cmbOperators = new System.Windows.Forms.ComboBox();
            this.lblOperators = new System.Windows.Forms.Label();
            this.tpgPaintItems = new System.Windows.Forms.TabPage();
            this.GrdPaintItems = new System.Windows.Forms.DataGridView();
            this.pnlPaintItems = new System.Windows.Forms.Panel();
            this.cmbPaintItems = new System.Windows.Forms.ComboBox();
            this.lblPaintItems = new System.Windows.Forms.Label();
            this.tpgSkillItems = new System.Windows.Forms.TabPage();
            this.GrdSkillItems = new System.Windows.Forms.DataGridView();
            this.pnlSkillItems = new System.Windows.Forms.Panel();
            this.cmbSkillItems = new System.Windows.Forms.ComboBox();
            this.lblSkillItems = new System.Windows.Forms.Label();
            this.tpgStickItems = new System.Windows.Forms.TabPage();
            this.GrdStickerItems = new System.Windows.Forms.DataGridView();
            this.pnlStickerItems = new System.Windows.Forms.Panel();
            this.cmbStickerItems = new System.Windows.Forms.ComboBox();
            this.lblStickerItems = new System.Windows.Forms.Label();
            this.tpgAddItem = new System.Windows.Forms.TabPage();
            this.pnlAddItem = new System.Windows.Forms.Panel();
            this.chbSearch = new System.Windows.Forms.CheckBox();
            this.btnBluSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.cmbItemType = new System.Windows.Forms.ComboBox();
            this.lblItemType = new System.Windows.Forms.Label();
            this.txtCharName = new System.Windows.Forms.TextBox();
            this.lblCharName = new System.Windows.Forms.Label();
            this.listViewAddItem = new System.Windows.Forms.ListView();
            this.colItemName = new System.Windows.Forms.ColumnHeader();
            this.colItemNum = new System.Windows.Forms.ColumnHeader();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnDelList = new System.Windows.Forms.Button();
            this.btnAddList = new System.Windows.Forms.Button();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblContent = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblItemList = new System.Windows.Forms.Label();
            this.NudItemNum = new System.Windows.Forms.NumericUpDown();
            this.lblItemNum = new System.Windows.Forms.Label();
            this.cmbItemName = new System.Windows.Forms.ComboBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.tpgBatchAdd = new System.Windows.Forms.TabPage();
            this.GrdBatchResult = new System.Windows.Forms.DataGridView();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerCombatItems = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReUnits = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReMixTree = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReOperators = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerOperators = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReCombatItems = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerUnits = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerMixTree = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerPaintItems = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerRePaintItems = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSkillItems = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReSkillItems = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerStickerItems = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReStickerItems = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerDeleteItem = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerItemList = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerAddItem = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerBluSearch = new System.ComponentModel.BackgroundWorker();
            this.openFileDlgBatch = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorkerBatchAdd = new System.ComponentModel.BackgroundWorker();
            this.GrpSearch.SuspendLayout();
            this.tbcResult.SuspendLayout();
            this.tpgCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdCharacter)).BeginInit();
            this.tpgMixTreeItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdMixItems)).BeginInit();
            this.pnlMixItems.SuspendLayout();
            this.tpgUserUnits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdUnits)).BeginInit();
            this.pnlUnits.SuspendLayout();
            this.tpgCombatItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdCombatItems)).BeginInit();
            this.pnlCombatItems.SuspendLayout();
            this.tpgOperators.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdOperators)).BeginInit();
            this.pnlOperators.SuspendLayout();
            this.tpgPaintItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdPaintItems)).BeginInit();
            this.pnlPaintItems.SuspendLayout();
            this.tpgSkillItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdSkillItems)).BeginInit();
            this.pnlSkillItems.SuspendLayout();
            this.tpgStickItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdStickerItems)).BeginInit();
            this.pnlStickerItems.SuspendLayout();
            this.tpgAddItem.SuspendLayout();
            this.pnlAddItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudItemNum)).BeginInit();
            this.tpgBatchAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdBatchResult)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.label1);
            this.GrpSearch.Controls.Add(this.label2);
            this.GrpSearch.Controls.Add(this.btnBatchAdd);
            this.GrpSearch.Controls.Add(this.txtFilePath);
            this.GrpSearch.Controls.Add(this.lblFilePath);
            this.GrpSearch.Controls.Add(this.btnBrowse);
            this.GrpSearch.Controls.Add(this.lblHint);
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
            this.GrpSearch.Size = new System.Drawing.Size(981, 175);
            this.GrpSearch.TabIndex = 4;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索條件";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(23, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(665, 12);
            this.label1.TabIndex = 42;
            this.label1.Text = "選擇括弧裏帶個數的道具，例如：必殺覺醒（10個）再選擇數量。用戶得到的道具總數為括弧裏的數量乘選擇的數量的總和。";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(407, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 12);
            this.label2.TabIndex = 41;
            this.label2.Text = "如果玩家帳號由數字組成，在玩家帳號前加單引號";
            // 
            // btnBatchAdd
            // 
            this.btnBatchAdd.Location = new System.Drawing.Point(776, 56);
            this.btnBatchAdd.Name = "btnBatchAdd";
            this.btnBatchAdd.Size = new System.Drawing.Size(92, 23);
            this.btnBatchAdd.TabIndex = 40;
            this.btnBatchAdd.Text = "批量添加道具";
            this.btnBatchAdd.UseVisualStyleBackColor = true;
            this.btnBatchAdd.Click += new System.EventHandler(this.btnBatchAdd_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(478, 25);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(292, 21);
            this.txtFilePath.TabIndex = 38;
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFilePath.Location = new System.Drawing.Point(407, 30);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(67, 15);
            this.lblFilePath.TabIndex = 37;
            this.lblFilePath.Text = "文件路径：";
            this.lblFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(776, 25);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(92, 23);
            this.btnBrowse.TabIndex = 39;
            this.btnBrowse.Text = "流覽";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.ForeColor = System.Drawing.Color.Red;
            this.lblHint.Location = new System.Drawing.Point(24, 126);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(293, 12);
            this.lblHint.TabIndex = 32;
            this.lblHint.Text = "提示：雙擊查詢得到的道具資訊，可以刪除相應的道具";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(309, 59);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 31;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(309, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 30;
            this.btnSearch.Text = "查询";
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
            this.tbcResult.Controls.Add(this.tpgMixTreeItems);
            this.tbcResult.Controls.Add(this.tpgUserUnits);
            this.tbcResult.Controls.Add(this.tpgCombatItems);
            this.tbcResult.Controls.Add(this.tpgOperators);
            this.tbcResult.Controls.Add(this.tpgPaintItems);
            this.tbcResult.Controls.Add(this.tpgSkillItems);
            this.tbcResult.Controls.Add(this.tpgStickItems);
            this.tbcResult.Controls.Add(this.tpgAddItem);
            this.tbcResult.Controls.Add(this.tpgBatchAdd);
            this.tbcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcResult.Location = new System.Drawing.Point(0, 175);
            this.tbcResult.Name = "tbcResult";
            this.tbcResult.SelectedIndex = 0;
            this.tbcResult.Size = new System.Drawing.Size(981, 461);
            this.tbcResult.TabIndex = 5;
            this.tbcResult.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbcResult_Selected);
            this.tbcResult.SelectedIndexChanged += new System.EventHandler(this.tbcResult_SelectedIndexChanged);
            // 
            // tpgCharacter
            // 
            this.tpgCharacter.Controls.Add(this.GrdCharacter);
            this.tpgCharacter.Location = new System.Drawing.Point(4, 21);
            this.tpgCharacter.Name = "tpgCharacter";
            this.tpgCharacter.Size = new System.Drawing.Size(973, 436);
            this.tpgCharacter.TabIndex = 7;
            this.tpgCharacter.Text = "玩家角色信息";
            this.tpgCharacter.UseVisualStyleBackColor = true;
            // 
            // GrdCharacter
            // 
            this.GrdCharacter.AllowUserToAddRows = false;
            this.GrdCharacter.AllowUserToDeleteRows = false;
            this.GrdCharacter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdCharacter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdCharacter.Location = new System.Drawing.Point(0, 0);
            this.GrdCharacter.Name = "GrdCharacter";
            this.GrdCharacter.ReadOnly = true;
            this.GrdCharacter.RowTemplate.Height = 23;
            this.GrdCharacter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdCharacter.Size = new System.Drawing.Size(973, 436);
            this.GrdCharacter.TabIndex = 10;
            this.GrdCharacter.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdCharacter_CellDoubleClick);
            this.GrdCharacter.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdCharacter_CellClick);
            // 
            // tpgMixTreeItems
            // 
            this.tpgMixTreeItems.Controls.Add(this.GrdMixItems);
            this.tpgMixTreeItems.Controls.Add(this.pnlMixItems);
            this.tpgMixTreeItems.Location = new System.Drawing.Point(4, 21);
            this.tpgMixTreeItems.Name = "tpgMixTreeItems";
            this.tpgMixTreeItems.Padding = new System.Windows.Forms.Padding(3);
            this.tpgMixTreeItems.Size = new System.Drawing.Size(973, 436);
            this.tpgMixTreeItems.TabIndex = 0;
            this.tpgMixTreeItems.Text = "玩家機體組合";
            this.tpgMixTreeItems.UseVisualStyleBackColor = true;
            // 
            // GrdMixItems
            // 
            this.GrdMixItems.AllowUserToAddRows = false;
            this.GrdMixItems.AllowUserToDeleteRows = false;
            this.GrdMixItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdMixItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdMixItems.Location = new System.Drawing.Point(3, 40);
            this.GrdMixItems.Name = "GrdMixItems";
            this.GrdMixItems.ReadOnly = true;
            this.GrdMixItems.RowTemplate.Height = 23;
            this.GrdMixItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdMixItems.Size = new System.Drawing.Size(967, 393);
            this.GrdMixItems.TabIndex = 12;
            this.GrdMixItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdMixItems_CellDoubleClick);
            // 
            // pnlMixItems
            // 
            this.pnlMixItems.Controls.Add(this.cmbMixItems);
            this.pnlMixItems.Controls.Add(this.lblMixItems);
            this.pnlMixItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMixItems.Location = new System.Drawing.Point(3, 3);
            this.pnlMixItems.Name = "pnlMixItems";
            this.pnlMixItems.Size = new System.Drawing.Size(967, 37);
            this.pnlMixItems.TabIndex = 11;
            // 
            // cmbMixItems
            // 
            this.cmbMixItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMixItems.FormattingEnabled = true;
            this.cmbMixItems.Location = new System.Drawing.Point(124, 8);
            this.cmbMixItems.Name = "cmbMixItems";
            this.cmbMixItems.Size = new System.Drawing.Size(100, 20);
            this.cmbMixItems.TabIndex = 1;
            this.cmbMixItems.SelectedIndexChanged += new System.EventHandler(this.cmbMixItems_SelectedIndexChanged);
            // 
            // lblMixItems
            // 
            this.lblMixItems.AutoSize = true;
            this.lblMixItems.Location = new System.Drawing.Point(20, 13);
            this.lblMixItems.Name = "lblMixItems";
            this.lblMixItems.Size = new System.Drawing.Size(101, 12);
            this.lblMixItems.TabIndex = 0;
            this.lblMixItems.Text = "请选择查看页数：";
            // 
            // tpgUserUnits
            // 
            this.tpgUserUnits.Controls.Add(this.GrdUnits);
            this.tpgUserUnits.Controls.Add(this.pnlUnits);
            this.tpgUserUnits.Location = new System.Drawing.Point(4, 21);
            this.tpgUserUnits.Name = "tpgUserUnits";
            this.tpgUserUnits.Size = new System.Drawing.Size(973, 436);
            this.tpgUserUnits.TabIndex = 4;
            this.tpgUserUnits.Text = "玩家機體信息";
            this.tpgUserUnits.UseVisualStyleBackColor = true;
            // 
            // GrdUnits
            // 
            this.GrdUnits.AllowUserToAddRows = false;
            this.GrdUnits.AllowUserToDeleteRows = false;
            this.GrdUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdUnits.Location = new System.Drawing.Point(0, 37);
            this.GrdUnits.Name = "GrdUnits";
            this.GrdUnits.ReadOnly = true;
            this.GrdUnits.RowTemplate.Height = 23;
            this.GrdUnits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdUnits.Size = new System.Drawing.Size(973, 399);
            this.GrdUnits.TabIndex = 12;
            this.GrdUnits.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdUnits_CellDoubleClick);
            // 
            // pnlUnits
            // 
            this.pnlUnits.Controls.Add(this.cmbUnits);
            this.pnlUnits.Controls.Add(this.lblUnits);
            this.pnlUnits.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUnits.Location = new System.Drawing.Point(0, 0);
            this.pnlUnits.Name = "pnlUnits";
            this.pnlUnits.Size = new System.Drawing.Size(973, 37);
            this.pnlUnits.TabIndex = 11;
            // 
            // cmbUnits
            // 
            this.cmbUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnits.FormattingEnabled = true;
            this.cmbUnits.Location = new System.Drawing.Point(124, 8);
            this.cmbUnits.Name = "cmbUnits";
            this.cmbUnits.Size = new System.Drawing.Size(100, 20);
            this.cmbUnits.TabIndex = 1;
            this.cmbUnits.SelectedIndexChanged += new System.EventHandler(this.cmbUnits_SelectedIndexChanged);
            // 
            // lblUnits
            // 
            this.lblUnits.AutoSize = true;
            this.lblUnits.Location = new System.Drawing.Point(20, 13);
            this.lblUnits.Name = "lblUnits";
            this.lblUnits.Size = new System.Drawing.Size(101, 12);
            this.lblUnits.TabIndex = 0;
            this.lblUnits.Text = "请选择查看页数：";
            // 
            // tpgCombatItems
            // 
            this.tpgCombatItems.Controls.Add(this.GrdCombatItems);
            this.tpgCombatItems.Controls.Add(this.pnlCombatItems);
            this.tpgCombatItems.Location = new System.Drawing.Point(4, 21);
            this.tpgCombatItems.Name = "tpgCombatItems";
            this.tpgCombatItems.Padding = new System.Windows.Forms.Padding(3);
            this.tpgCombatItems.Size = new System.Drawing.Size(973, 436);
            this.tpgCombatItems.TabIndex = 1;
            this.tpgCombatItems.Text = "玩家戰鬥道具";
            this.tpgCombatItems.UseVisualStyleBackColor = true;
            // 
            // GrdCombatItems
            // 
            this.GrdCombatItems.AllowUserToAddRows = false;
            this.GrdCombatItems.AllowUserToDeleteRows = false;
            this.GrdCombatItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdCombatItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdCombatItems.Location = new System.Drawing.Point(3, 40);
            this.GrdCombatItems.Name = "GrdCombatItems";
            this.GrdCombatItems.ReadOnly = true;
            this.GrdCombatItems.RowTemplate.Height = 23;
            this.GrdCombatItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdCombatItems.Size = new System.Drawing.Size(967, 393);
            this.GrdCombatItems.TabIndex = 11;
            this.GrdCombatItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdCombatItems_CellDoubleClick);
            // 
            // pnlCombatItems
            // 
            this.pnlCombatItems.Controls.Add(this.cmbCombatItems);
            this.pnlCombatItems.Controls.Add(this.lblCombatItems);
            this.pnlCombatItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCombatItems.Location = new System.Drawing.Point(3, 3);
            this.pnlCombatItems.Name = "pnlCombatItems";
            this.pnlCombatItems.Size = new System.Drawing.Size(967, 37);
            this.pnlCombatItems.TabIndex = 0;
            // 
            // cmbCombatItems
            // 
            this.cmbCombatItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCombatItems.FormattingEnabled = true;
            this.cmbCombatItems.Location = new System.Drawing.Point(124, 8);
            this.cmbCombatItems.Name = "cmbCombatItems";
            this.cmbCombatItems.Size = new System.Drawing.Size(100, 20);
            this.cmbCombatItems.TabIndex = 1;
            this.cmbCombatItems.SelectedIndexChanged += new System.EventHandler(this.cmbCombatItems_SelectedIndexChanged);
            // 
            // lblCombatItems
            // 
            this.lblCombatItems.AutoSize = true;
            this.lblCombatItems.Location = new System.Drawing.Point(20, 13);
            this.lblCombatItems.Name = "lblCombatItems";
            this.lblCombatItems.Size = new System.Drawing.Size(101, 12);
            this.lblCombatItems.TabIndex = 0;
            this.lblCombatItems.Text = "请选择查看页数：";
            // 
            // tpgOperators
            // 
            this.tpgOperators.Controls.Add(this.GrdOperators);
            this.tpgOperators.Controls.Add(this.pnlOperators);
            this.tpgOperators.Location = new System.Drawing.Point(4, 21);
            this.tpgOperators.Name = "tpgOperators";
            this.tpgOperators.Size = new System.Drawing.Size(973, 436);
            this.tpgOperators.TabIndex = 2;
            this.tpgOperators.Text = "玩家副官信息";
            this.tpgOperators.UseVisualStyleBackColor = true;
            // 
            // GrdOperators
            // 
            this.GrdOperators.AllowUserToAddRows = false;
            this.GrdOperators.AllowUserToDeleteRows = false;
            this.GrdOperators.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdOperators.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdOperators.Location = new System.Drawing.Point(0, 37);
            this.GrdOperators.Name = "GrdOperators";
            this.GrdOperators.ReadOnly = true;
            this.GrdOperators.RowTemplate.Height = 23;
            this.GrdOperators.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdOperators.Size = new System.Drawing.Size(973, 399);
            this.GrdOperators.TabIndex = 14;
            this.GrdOperators.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdOperators_CellDoubleClick);
            // 
            // pnlOperators
            // 
            this.pnlOperators.Controls.Add(this.cmbOperators);
            this.pnlOperators.Controls.Add(this.lblOperators);
            this.pnlOperators.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOperators.Location = new System.Drawing.Point(0, 0);
            this.pnlOperators.Name = "pnlOperators";
            this.pnlOperators.Size = new System.Drawing.Size(973, 37);
            this.pnlOperators.TabIndex = 13;
            // 
            // cmbOperators
            // 
            this.cmbOperators.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperators.FormattingEnabled = true;
            this.cmbOperators.Location = new System.Drawing.Point(124, 8);
            this.cmbOperators.Name = "cmbOperators";
            this.cmbOperators.Size = new System.Drawing.Size(100, 20);
            this.cmbOperators.TabIndex = 1;
            this.cmbOperators.SelectedIndexChanged += new System.EventHandler(this.cmbOperators_SelectedIndexChanged);
            // 
            // lblOperators
            // 
            this.lblOperators.AutoSize = true;
            this.lblOperators.Location = new System.Drawing.Point(20, 13);
            this.lblOperators.Name = "lblOperators";
            this.lblOperators.Size = new System.Drawing.Size(101, 12);
            this.lblOperators.TabIndex = 0;
            this.lblOperators.Text = "请选择查看页数：";
            // 
            // tpgPaintItems
            // 
            this.tpgPaintItems.Controls.Add(this.GrdPaintItems);
            this.tpgPaintItems.Controls.Add(this.pnlPaintItems);
            this.tpgPaintItems.Location = new System.Drawing.Point(4, 21);
            this.tpgPaintItems.Name = "tpgPaintItems";
            this.tpgPaintItems.Size = new System.Drawing.Size(973, 436);
            this.tpgPaintItems.TabIndex = 3;
            this.tpgPaintItems.Text = "玩家塗裝道具";
            this.tpgPaintItems.UseVisualStyleBackColor = true;
            // 
            // GrdPaintItems
            // 
            this.GrdPaintItems.AllowUserToAddRows = false;
            this.GrdPaintItems.AllowUserToDeleteRows = false;
            this.GrdPaintItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdPaintItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdPaintItems.Location = new System.Drawing.Point(0, 37);
            this.GrdPaintItems.Name = "GrdPaintItems";
            this.GrdPaintItems.ReadOnly = true;
            this.GrdPaintItems.RowTemplate.Height = 23;
            this.GrdPaintItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdPaintItems.Size = new System.Drawing.Size(973, 399);
            this.GrdPaintItems.TabIndex = 15;
            this.GrdPaintItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdPaintItems_CellDoubleClick);
            // 
            // pnlPaintItems
            // 
            this.pnlPaintItems.Controls.Add(this.cmbPaintItems);
            this.pnlPaintItems.Controls.Add(this.lblPaintItems);
            this.pnlPaintItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPaintItems.Location = new System.Drawing.Point(0, 0);
            this.pnlPaintItems.Name = "pnlPaintItems";
            this.pnlPaintItems.Size = new System.Drawing.Size(973, 37);
            this.pnlPaintItems.TabIndex = 14;
            // 
            // cmbPaintItems
            // 
            this.cmbPaintItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaintItems.FormattingEnabled = true;
            this.cmbPaintItems.Location = new System.Drawing.Point(124, 8);
            this.cmbPaintItems.Name = "cmbPaintItems";
            this.cmbPaintItems.Size = new System.Drawing.Size(100, 20);
            this.cmbPaintItems.TabIndex = 1;
            this.cmbPaintItems.SelectedIndexChanged += new System.EventHandler(this.cmbPaintItems_SelectedIndexChanged);
            // 
            // lblPaintItems
            // 
            this.lblPaintItems.AutoSize = true;
            this.lblPaintItems.Location = new System.Drawing.Point(20, 13);
            this.lblPaintItems.Name = "lblPaintItems";
            this.lblPaintItems.Size = new System.Drawing.Size(101, 12);
            this.lblPaintItems.TabIndex = 0;
            this.lblPaintItems.Text = "请选择查看页数：";
            // 
            // tpgSkillItems
            // 
            this.tpgSkillItems.Controls.Add(this.GrdSkillItems);
            this.tpgSkillItems.Controls.Add(this.pnlSkillItems);
            this.tpgSkillItems.Location = new System.Drawing.Point(4, 21);
            this.tpgSkillItems.Name = "tpgSkillItems";
            this.tpgSkillItems.Size = new System.Drawing.Size(973, 436);
            this.tpgSkillItems.TabIndex = 5;
            this.tpgSkillItems.Text = "玩家技能道具";
            this.tpgSkillItems.UseVisualStyleBackColor = true;
            // 
            // GrdSkillItems
            // 
            this.GrdSkillItems.AllowUserToAddRows = false;
            this.GrdSkillItems.AllowUserToDeleteRows = false;
            this.GrdSkillItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdSkillItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdSkillItems.Location = new System.Drawing.Point(0, 37);
            this.GrdSkillItems.Name = "GrdSkillItems";
            this.GrdSkillItems.ReadOnly = true;
            this.GrdSkillItems.RowTemplate.Height = 23;
            this.GrdSkillItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdSkillItems.Size = new System.Drawing.Size(973, 399);
            this.GrdSkillItems.TabIndex = 16;
            this.GrdSkillItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdSkillItems_CellDoubleClick);
            // 
            // pnlSkillItems
            // 
            this.pnlSkillItems.Controls.Add(this.cmbSkillItems);
            this.pnlSkillItems.Controls.Add(this.lblSkillItems);
            this.pnlSkillItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSkillItems.Location = new System.Drawing.Point(0, 0);
            this.pnlSkillItems.Name = "pnlSkillItems";
            this.pnlSkillItems.Size = new System.Drawing.Size(973, 37);
            this.pnlSkillItems.TabIndex = 15;
            // 
            // cmbSkillItems
            // 
            this.cmbSkillItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSkillItems.FormattingEnabled = true;
            this.cmbSkillItems.Location = new System.Drawing.Point(124, 8);
            this.cmbSkillItems.Name = "cmbSkillItems";
            this.cmbSkillItems.Size = new System.Drawing.Size(100, 20);
            this.cmbSkillItems.TabIndex = 1;
            this.cmbSkillItems.SelectedIndexChanged += new System.EventHandler(this.cmbSkillItems_SelectedIndexChanged);
            // 
            // lblSkillItems
            // 
            this.lblSkillItems.AutoSize = true;
            this.lblSkillItems.Location = new System.Drawing.Point(20, 13);
            this.lblSkillItems.Name = "lblSkillItems";
            this.lblSkillItems.Size = new System.Drawing.Size(101, 12);
            this.lblSkillItems.TabIndex = 0;
            this.lblSkillItems.Text = "请选择查看页数：";
            // 
            // tpgStickItems
            // 
            this.tpgStickItems.Controls.Add(this.GrdStickerItems);
            this.tpgStickItems.Controls.Add(this.pnlStickerItems);
            this.tpgStickItems.Location = new System.Drawing.Point(4, 21);
            this.tpgStickItems.Name = "tpgStickItems";
            this.tpgStickItems.Size = new System.Drawing.Size(973, 436);
            this.tpgStickItems.TabIndex = 6;
            this.tpgStickItems.Text = "玩家標籤道具";
            this.tpgStickItems.UseVisualStyleBackColor = true;
            // 
            // GrdStickerItems
            // 
            this.GrdStickerItems.AllowUserToAddRows = false;
            this.GrdStickerItems.AllowUserToDeleteRows = false;
            this.GrdStickerItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdStickerItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdStickerItems.Location = new System.Drawing.Point(0, 37);
            this.GrdStickerItems.Name = "GrdStickerItems";
            this.GrdStickerItems.ReadOnly = true;
            this.GrdStickerItems.RowTemplate.Height = 23;
            this.GrdStickerItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdStickerItems.Size = new System.Drawing.Size(973, 399);
            this.GrdStickerItems.TabIndex = 17;
            this.GrdStickerItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdStickerItems_CellDoubleClick);
            // 
            // pnlStickerItems
            // 
            this.pnlStickerItems.Controls.Add(this.cmbStickerItems);
            this.pnlStickerItems.Controls.Add(this.lblStickerItems);
            this.pnlStickerItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStickerItems.Location = new System.Drawing.Point(0, 0);
            this.pnlStickerItems.Name = "pnlStickerItems";
            this.pnlStickerItems.Size = new System.Drawing.Size(973, 37);
            this.pnlStickerItems.TabIndex = 16;
            // 
            // cmbStickerItems
            // 
            this.cmbStickerItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStickerItems.FormattingEnabled = true;
            this.cmbStickerItems.Location = new System.Drawing.Point(124, 8);
            this.cmbStickerItems.Name = "cmbStickerItems";
            this.cmbStickerItems.Size = new System.Drawing.Size(100, 20);
            this.cmbStickerItems.TabIndex = 1;
            this.cmbStickerItems.SelectedIndexChanged += new System.EventHandler(this.cmbStickerItems_SelectedIndexChanged);
            // 
            // lblStickerItems
            // 
            this.lblStickerItems.AutoSize = true;
            this.lblStickerItems.Location = new System.Drawing.Point(20, 13);
            this.lblStickerItems.Name = "lblStickerItems";
            this.lblStickerItems.Size = new System.Drawing.Size(101, 12);
            this.lblStickerItems.TabIndex = 0;
            this.lblStickerItems.Text = "请选择查看页数：";
            // 
            // tpgAddItem
            // 
            this.tpgAddItem.Controls.Add(this.pnlAddItem);
            this.tpgAddItem.Location = new System.Drawing.Point(4, 21);
            this.tpgAddItem.Name = "tpgAddItem";
            this.tpgAddItem.Size = new System.Drawing.Size(973, 436);
            this.tpgAddItem.TabIndex = 8;
            this.tpgAddItem.Text = "添加道具";
            this.tpgAddItem.UseVisualStyleBackColor = true;
            // 
            // pnlAddItem
            // 
            this.pnlAddItem.Controls.Add(this.chbSearch);
            this.pnlAddItem.Controls.Add(this.btnBluSearch);
            this.pnlAddItem.Controls.Add(this.txtSearch);
            this.pnlAddItem.Controls.Add(this.lblSearch);
            this.pnlAddItem.Controls.Add(this.cmbItemType);
            this.pnlAddItem.Controls.Add(this.lblItemType);
            this.pnlAddItem.Controls.Add(this.txtCharName);
            this.pnlAddItem.Controls.Add(this.lblCharName);
            this.pnlAddItem.Controls.Add(this.listViewAddItem);
            this.pnlAddItem.Controls.Add(this.btnReset);
            this.pnlAddItem.Controls.Add(this.btnAddItem);
            this.pnlAddItem.Controls.Add(this.btnDelList);
            this.pnlAddItem.Controls.Add(this.btnAddList);
            this.pnlAddItem.Controls.Add(this.txtContent);
            this.pnlAddItem.Controls.Add(this.lblContent);
            this.pnlAddItem.Controls.Add(this.lblTitle);
            this.pnlAddItem.Controls.Add(this.lblItemList);
            this.pnlAddItem.Controls.Add(this.NudItemNum);
            this.pnlAddItem.Controls.Add(this.lblItemNum);
            this.pnlAddItem.Controls.Add(this.cmbItemName);
            this.pnlAddItem.Controls.Add(this.lblItemName);
            this.pnlAddItem.Controls.Add(this.txtTitle);
            this.pnlAddItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAddItem.Location = new System.Drawing.Point(0, 0);
            this.pnlAddItem.Name = "pnlAddItem";
            this.pnlAddItem.Size = new System.Drawing.Size(973, 436);
            this.pnlAddItem.TabIndex = 1;
            // 
            // chbSearch
            // 
            this.chbSearch.AutoSize = true;
            this.chbSearch.Location = new System.Drawing.Point(37, 77);
            this.chbSearch.Name = "chbSearch";
            this.chbSearch.Size = new System.Drawing.Size(96, 16);
            this.chbSearch.TabIndex = 44;
            this.chbSearch.Text = "使用模糊查詢";
            this.chbSearch.UseVisualStyleBackColor = true;
            this.chbSearch.CheckedChanged += new System.EventHandler(this.chbSearch_CheckedChanged);
            // 
            // btnBluSearch
            // 
            this.btnBluSearch.Location = new System.Drawing.Point(173, 132);
            this.btnBluSearch.Name = "btnBluSearch";
            this.btnBluSearch.Size = new System.Drawing.Size(75, 23);
            this.btnBluSearch.TabIndex = 43;
            this.btnBluSearch.Text = "查詢";
            this.btnBluSearch.UseVisualStyleBackColor = true;
            this.btnBluSearch.Click += new System.EventHandler(this.btnBluSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(37, 132);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(130, 21);
            this.txtSearch.TabIndex = 42;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(49, 109);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(65, 12);
            this.lblSearch.TabIndex = 41;
            this.lblSearch.Text = "模糊查询：";
            // 
            // cmbItemType
            // 
            this.cmbItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemType.FormattingEnabled = true;
            this.cmbItemType.Location = new System.Drawing.Point(740, 306);
            this.cmbItemType.Name = "cmbItemType";
            this.cmbItemType.Size = new System.Drawing.Size(121, 20);
            this.cmbItemType.TabIndex = 40;
            this.cmbItemType.Visible = false;
            // 
            // lblItemType
            // 
            this.lblItemType.AutoSize = true;
            this.lblItemType.Location = new System.Drawing.Point(765, 291);
            this.lblItemType.Name = "lblItemType";
            this.lblItemType.Size = new System.Drawing.Size(65, 12);
            this.lblItemType.TabIndex = 39;
            this.lblItemType.Text = "道具分類：";
            this.lblItemType.Visible = false;
            // 
            // txtCharName
            // 
            this.txtCharName.Location = new System.Drawing.Point(37, 30);
            this.txtCharName.Name = "txtCharName";
            this.txtCharName.ReadOnly = true;
            this.txtCharName.Size = new System.Drawing.Size(195, 21);
            this.txtCharName.TabIndex = 38;
            // 
            // lblCharName
            // 
            this.lblCharName.AutoSize = true;
            this.lblCharName.Location = new System.Drawing.Point(35, 15);
            this.lblCharName.Name = "lblCharName";
            this.lblCharName.Size = new System.Drawing.Size(65, 12);
            this.lblCharName.TabIndex = 26;
            this.lblCharName.Text = "玩家帳號：";
            // 
            // listViewAddItem
            // 
            this.listViewAddItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colItemName,
            this.colItemNum});
            this.listViewAddItem.Location = new System.Drawing.Point(332, 62);
            this.listViewAddItem.MultiSelect = false;
            this.listViewAddItem.Name = "listViewAddItem";
            this.listViewAddItem.Size = new System.Drawing.Size(301, 203);
            this.listViewAddItem.TabIndex = 21;
            this.listViewAddItem.UseCompatibleStateImageBehavior = false;
            this.listViewAddItem.View = System.Windows.Forms.View.Details;
            // 
            // colItemName
            // 
            this.colItemName.Text = "道具名称";
            this.colItemName.Width = 232;
            // 
            // colItemNum
            // 
            this.colItemNum.Text = "道具数量";
            this.colItemNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colItemNum.Width = 65;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(558, 315);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 19;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddItem.Location = new System.Drawing.Point(234, 315);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(122, 23);
            this.btnAddItem.TabIndex = 18;
            this.btnAddItem.Text = "贈送道具";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnDelList
            // 
            this.btnDelList.Location = new System.Drawing.Point(262, 190);
            this.btnDelList.Name = "btnDelList";
            this.btnDelList.Size = new System.Drawing.Size(47, 29);
            this.btnDelList.TabIndex = 15;
            this.btnDelList.Text = "<-";
            this.btnDelList.UseVisualStyleBackColor = true;
            this.btnDelList.Click += new System.EventHandler(this.btnDelList_Click);
            // 
            // btnAddList
            // 
            this.btnAddList.Location = new System.Drawing.Point(262, 127);
            this.btnAddList.Name = "btnAddList";
            this.btnAddList.Size = new System.Drawing.Size(47, 28);
            this.btnAddList.TabIndex = 14;
            this.btnAddList.Text = "->";
            this.btnAddList.UseVisualStyleBackColor = true;
            this.btnAddList.Click += new System.EventHandler(this.btnAddList_Click);
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(670, 117);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(181, 148);
            this.txtContent.TabIndex = 13;
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(670, 100);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(41, 12);
            this.lblContent.TabIndex = 12;
            this.lblContent.Text = "内容：";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(668, 46);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(53, 12);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "发件人：";
            // 
            // lblItemList
            // 
            this.lblItemList.AutoSize = true;
            this.lblItemList.Location = new System.Drawing.Point(330, 47);
            this.lblItemList.Name = "lblItemList";
            this.lblItemList.Size = new System.Drawing.Size(89, 12);
            this.lblItemList.TabIndex = 10;
            this.lblItemList.Text = "贈送道具列表：";
            // 
            // NudItemNum
            // 
            this.NudItemNum.Location = new System.Drawing.Point(37, 244);
            this.NudItemNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudItemNum.Name = "NudItemNum";
            this.NudItemNum.Size = new System.Drawing.Size(195, 21);
            this.NudItemNum.TabIndex = 6;
            this.NudItemNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblItemNum
            // 
            this.lblItemNum.AutoSize = true;
            this.lblItemNum.Location = new System.Drawing.Point(35, 228);
            this.lblItemNum.Name = "lblItemNum";
            this.lblItemNum.Size = new System.Drawing.Size(65, 12);
            this.lblItemNum.TabIndex = 5;
            this.lblItemNum.Text = "道具數量：";
            // 
            // cmbItemName
            // 
            this.cmbItemName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemName.FormattingEnabled = true;
            this.cmbItemName.Location = new System.Drawing.Point(37, 196);
            this.cmbItemName.Name = "cmbItemName";
            this.cmbItemName.Size = new System.Drawing.Size(196, 20);
            this.cmbItemName.TabIndex = 4;
            this.cmbItemName.SelectedIndexChanged += new System.EventHandler(this.cmbItemName_SelectedIndexChanged);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(35, 180);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(65, 12);
            this.lblItemName.TabIndex = 3;
            this.lblItemName.Text = "道具名稱：";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(668, 62);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(183, 21);
            this.txtTitle.TabIndex = 0;
            // 
            // tpgBatchAdd
            // 
            this.tpgBatchAdd.Controls.Add(this.GrdBatchResult);
            this.tpgBatchAdd.Location = new System.Drawing.Point(4, 21);
            this.tpgBatchAdd.Name = "tpgBatchAdd";
            this.tpgBatchAdd.Size = new System.Drawing.Size(973, 436);
            this.tpgBatchAdd.TabIndex = 9;
            this.tpgBatchAdd.Text = "批量增加道具";
            this.tpgBatchAdd.UseVisualStyleBackColor = true;
            // 
            // GrdBatchResult
            // 
            this.GrdBatchResult.AllowUserToAddRows = false;
            this.GrdBatchResult.AllowUserToDeleteRows = false;
            this.GrdBatchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdBatchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdBatchResult.Location = new System.Drawing.Point(0, 0);
            this.GrdBatchResult.Name = "GrdBatchResult";
            this.GrdBatchResult.ReadOnly = true;
            this.GrdBatchResult.RowTemplate.Height = 23;
            this.GrdBatchResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdBatchResult.Size = new System.Drawing.Size(973, 436);
            this.GrdBatchResult.TabIndex = 14;
            // 
            // backgroundWorkerFormLoad
            // 
            this.backgroundWorkerFormLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFormLoad_DoWork);
            this.backgroundWorkerFormLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFormLoad_RunWorkerCompleted);
            // 
            // backgroundWorkerCombatItems
            // 
            this.backgroundWorkerCombatItems.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCombatItems_DoWork);
            this.backgroundWorkerCombatItems.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCombatItems_RunWorkerCompleted);
            // 
            // backgroundWorkerReUnits
            // 
            this.backgroundWorkerReUnits.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReUnits_DoWork);
            this.backgroundWorkerReUnits.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReUnits_RunWorkerCompleted);
            // 
            // backgroundWorkerReMixTree
            // 
            this.backgroundWorkerReMixTree.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReMixTree_DoWork);
            this.backgroundWorkerReMixTree.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReMixTree_RunWorkerCompleted);
            // 
            // backgroundWorkerReOperators
            // 
            this.backgroundWorkerReOperators.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReOperators_DoWork);
            this.backgroundWorkerReOperators.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReOperators_RunWorkerCompleted);
            // 
            // backgroundWorkerOperators
            // 
            this.backgroundWorkerOperators.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerOperators_DoWork);
            this.backgroundWorkerOperators.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerOperators_RunWorkerCompleted);
            // 
            // backgroundWorkerSearch
            // 
            this.backgroundWorkerSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSearch_DoWork);
            this.backgroundWorkerSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSearch_RunWorkerCompleted);
            // 
            // backgroundWorkerReCombatItems
            // 
            this.backgroundWorkerReCombatItems.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReCombatItems_DoWork);
            this.backgroundWorkerReCombatItems.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReCombatItems_RunWorkerCompleted);
            // 
            // backgroundWorkerUnits
            // 
            this.backgroundWorkerUnits.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerUnits_DoWork);
            this.backgroundWorkerUnits.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerUnits_RunWorkerCompleted);
            // 
            // backgroundWorkerMixTree
            // 
            this.backgroundWorkerMixTree.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerMixTree_DoWork);
            this.backgroundWorkerMixTree.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerMixTree_RunWorkerCompleted);
            // 
            // backgroundWorkerPaintItems
            // 
            this.backgroundWorkerPaintItems.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerPaintItems_DoWork);
            this.backgroundWorkerPaintItems.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerPaintItems_RunWorkerCompleted);
            // 
            // backgroundWorkerRePaintItems
            // 
            this.backgroundWorkerRePaintItems.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerRePaintItems_DoWork);
            this.backgroundWorkerRePaintItems.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerRePaintItems_RunWorkerCompleted);
            // 
            // backgroundWorkerSkillItems
            // 
            this.backgroundWorkerSkillItems.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSkillItems_DoWork);
            this.backgroundWorkerSkillItems.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSkillItems_RunWorkerCompleted);
            // 
            // backgroundWorkerReSkillItems
            // 
            this.backgroundWorkerReSkillItems.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReSkillItems_DoWork);
            this.backgroundWorkerReSkillItems.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReSkillItems_RunWorkerCompleted);
            // 
            // backgroundWorkerStickerItems
            // 
            this.backgroundWorkerStickerItems.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerStickerItems_DoWork);
            this.backgroundWorkerStickerItems.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerStickerItems_RunWorkerCompleted);
            // 
            // backgroundWorkerReStickerItems
            // 
            this.backgroundWorkerReStickerItems.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReStickerItems_DoWork);
            this.backgroundWorkerReStickerItems.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReStickerItems_RunWorkerCompleted);
            // 
            // backgroundWorkerDeleteItem
            // 
            this.backgroundWorkerDeleteItem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDeleteItem_DoWork);
            this.backgroundWorkerDeleteItem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerDeleteItem_RunWorkerCompleted);
            // 
            // backgroundWorkerItemList
            // 
            this.backgroundWorkerItemList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerItemList_DoWork);
            this.backgroundWorkerItemList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerItemList_RunWorkerCompleted);
            // 
            // backgroundWorkerAddItem
            // 
            this.backgroundWorkerAddItem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerAddItem_DoWork);
            this.backgroundWorkerAddItem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerAddItem_RunWorkerCompleted);
            // 
            // backgroundWorkerBluSearch
            // 
            this.backgroundWorkerBluSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerBluSearch_DoWork);
            this.backgroundWorkerBluSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerBluSearch_RunWorkerCompleted);
            // 
            // openFileDlgBatch
            // 
            this.openFileDlgBatch.FileName = "openFileDialog1";
            // 
            // backgroundWorkerBatchAdd
            // 
            this.backgroundWorkerBatchAdd.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerBatchAdd_DoWork);
            this.backgroundWorkerBatchAdd.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerBatchAdd_RunWorkerCompleted);
            // 
            // FrmGDItemManage
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(981, 636);
            this.Controls.Add(this.tbcResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmGDItemManage";
            this.Text = "道具管理";
            this.Load += new System.EventHandler(this.FrmGDItemManage_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.tbcResult.ResumeLayout(false);
            this.tpgCharacter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdCharacter)).EndInit();
            this.tpgMixTreeItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdMixItems)).EndInit();
            this.pnlMixItems.ResumeLayout(false);
            this.pnlMixItems.PerformLayout();
            this.tpgUserUnits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdUnits)).EndInit();
            this.pnlUnits.ResumeLayout(false);
            this.pnlUnits.PerformLayout();
            this.tpgCombatItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdCombatItems)).EndInit();
            this.pnlCombatItems.ResumeLayout(false);
            this.pnlCombatItems.PerformLayout();
            this.tpgOperators.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdOperators)).EndInit();
            this.pnlOperators.ResumeLayout(false);
            this.pnlOperators.PerformLayout();
            this.tpgPaintItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdPaintItems)).EndInit();
            this.pnlPaintItems.ResumeLayout(false);
            this.pnlPaintItems.PerformLayout();
            this.tpgSkillItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdSkillItems)).EndInit();
            this.pnlSkillItems.ResumeLayout(false);
            this.pnlSkillItems.PerformLayout();
            this.tpgStickItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdStickerItems)).EndInit();
            this.pnlStickerItems.ResumeLayout(false);
            this.pnlStickerItems.PerformLayout();
            this.tpgAddItem.ResumeLayout(false);
            this.pnlAddItem.ResumeLayout(false);
            this.pnlAddItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudItemNum)).EndInit();
            this.tpgBatchAdd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdBatchResult)).EndInit();
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
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.TabControl tbcResult;
        private System.Windows.Forms.TabPage tpgCharacter;
        private System.Windows.Forms.DataGridView GrdCharacter;
        private System.Windows.Forms.TabPage tpgMixTreeItems;
        private System.Windows.Forms.Panel pnlMixItems;
        private System.Windows.Forms.ComboBox cmbMixItems;
        private System.Windows.Forms.Label lblMixItems;
        private System.Windows.Forms.TabPage tpgUserUnits;
        private System.Windows.Forms.Panel pnlUnits;
        private System.Windows.Forms.ComboBox cmbUnits;
        private System.Windows.Forms.Label lblUnits;
        private System.Windows.Forms.TabPage tpgCombatItems;
        private System.Windows.Forms.DataGridView GrdCombatItems;
        private System.Windows.Forms.Panel pnlCombatItems;
        private System.Windows.Forms.ComboBox cmbCombatItems;
        private System.Windows.Forms.Label lblCombatItems;
        private System.Windows.Forms.TabPage tpgOperators;
        private System.Windows.Forms.Panel pnlOperators;
        private System.Windows.Forms.ComboBox cmbOperators;
        private System.Windows.Forms.Label lblOperators;
        private System.Windows.Forms.TabPage tpgPaintItems;
        private System.Windows.Forms.Panel pnlPaintItems;
        private System.Windows.Forms.ComboBox cmbPaintItems;
        private System.Windows.Forms.Label lblPaintItems;
        private System.Windows.Forms.TabPage tpgSkillItems;
        private System.Windows.Forms.Panel pnlSkillItems;
        private System.Windows.Forms.ComboBox cmbSkillItems;
        private System.Windows.Forms.Label lblSkillItems;
        private System.Windows.Forms.TabPage tpgStickItems;
        private System.Windows.Forms.Panel pnlStickerItems;
        private System.Windows.Forms.ComboBox cmbStickerItems;
        private System.Windows.Forms.Label lblStickerItems;
        private System.Windows.Forms.TabPage tpgAddItem;
        private System.Windows.Forms.Panel pnlAddItem;
        private System.Windows.Forms.TextBox txtCharName;
        private System.Windows.Forms.Label lblCharName;
        private System.Windows.Forms.ListView listViewAddItem;
        private System.Windows.Forms.ColumnHeader colItemName;
        private System.Windows.Forms.ColumnHeader colItemNum;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnDelList;
        private System.Windows.Forms.Button btnAddList;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblItemList;
        private System.Windows.Forms.NumericUpDown NudItemNum;
        private System.Windows.Forms.Label lblItemNum;
        private System.Windows.Forms.ComboBox cmbItemName;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox txtTitle;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCombatItems;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReUnits;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReMixTree;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReOperators;
        private System.ComponentModel.BackgroundWorker backgroundWorkerOperators;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReCombatItems;
        private System.ComponentModel.BackgroundWorker backgroundWorkerUnits;
        private System.ComponentModel.BackgroundWorker backgroundWorkerMixTree;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPaintItems;
        private System.ComponentModel.BackgroundWorker backgroundWorkerRePaintItems;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSkillItems;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReSkillItems;
        private System.ComponentModel.BackgroundWorker backgroundWorkerStickerItems;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReStickerItems;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDeleteItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerItemList;
        private System.ComponentModel.BackgroundWorker backgroundWorkerAddItem;
        private System.Windows.Forms.DataGridView GrdSkillItems;
        private System.Windows.Forms.DataGridView GrdMixItems;
        private System.Windows.Forms.DataGridView GrdUnits;
        private System.Windows.Forms.DataGridView GrdOperators;
        private System.Windows.Forms.DataGridView GrdPaintItems;
        private System.Windows.Forms.DataGridView GrdStickerItems;
        private System.ComponentModel.BackgroundWorker backgroundWorkerBluSearch;
        private System.Windows.Forms.CheckBox chbSearch;
        private System.Windows.Forms.Button btnBluSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ComboBox cmbItemType;
        private System.Windows.Forms.Label lblItemType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBatchAdd;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TabPage tpgBatchAdd;
        private System.Windows.Forms.DataGridView GrdBatchResult;
        private System.Windows.Forms.OpenFileDialog openFileDlgBatch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerBatchAdd;
        private System.Windows.Forms.Label label1;
    }
}