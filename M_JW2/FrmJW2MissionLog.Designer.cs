namespace M_JW2
{
    partial class FrmJW2MissionLog
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
            this.tbcResult = new System.Windows.Forms.TabControl();
            this.tpgCharacter = new System.Windows.Forms.TabPage();
            this.pnlRoleView = new System.Windows.Forms.Panel();
            this.cmbRoleView = new System.Windows.Forms.ComboBox();
            this.lblRoleView = new System.Windows.Forms.Label();
            this.GrdRoleView = new System.Windows.Forms.DataGridView();
            this.tpgNormalMission = new System.Windows.Forms.TabPage();
            this.GrdNormalMission = new System.Windows.Forms.DataGridView();
            this.pnlNormalMission = new System.Windows.Forms.Panel();
            this.cmbNormalMission = new System.Windows.Forms.ComboBox();
            this.lblHomeItemInfo = new System.Windows.Forms.Label();
            this.tpgStoryMission = new System.Windows.Forms.TabPage();
            this.GrdStoryMission = new System.Windows.Forms.DataGridView();
            this.pnlStoryMission = new System.Windows.Forms.Panel();
            this.cmdStoryMission = new System.Windows.Forms.ComboBox();
            this.lblStoryMission = new System.Windows.Forms.Label();
            this.tpgFamilyMission = new System.Windows.Forms.TabPage();
            this.GrdFamilyMission = new System.Windows.Forms.DataGridView();
            this.pnlFamilyMission = new System.Windows.Forms.Panel();
            this.cmbFamilyMission = new System.Windows.Forms.ComboBox();
            this.lblFamilyMission = new System.Windows.Forms.Label();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerNormailMissionLog = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerStoryMissionLog = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerFamilyMissionLog = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReNormailMissionLog = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReStoryMissionLog = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReFamilyMissionLog = new System.ComponentModel.BackgroundWorker();
            this.GrpSearch.SuspendLayout();
            this.tbcResult.SuspendLayout();
            this.tpgCharacter.SuspendLayout();
            this.pnlRoleView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdRoleView)).BeginInit();
            this.tpgNormalMission.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdNormalMission)).BeginInit();
            this.pnlNormalMission.SuspendLayout();
            this.tpgStoryMission.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdStoryMission)).BeginInit();
            this.pnlStoryMission.SuspendLayout();
            this.tpgFamilyMission.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdFamilyMission)).BeginInit();
            this.pnlFamilyMission.SuspendLayout();
            this.SuspendLayout();
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
            this.GrpSearch.Size = new System.Drawing.Size(652, 140);
            this.GrpSearch.TabIndex = 4;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索條件";
            // 
            // DtpEnd
            // 
            this.DtpEnd.CustomFormat = "yyyy-MM-dd";
            this.DtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpEnd.Location = new System.Drawing.Point(316, 87);
            this.DtpEnd.Name = "DtpEnd";
            this.DtpEnd.Size = new System.Drawing.Size(166, 21);
            this.DtpEnd.TabIndex = 130;
            // 
            // LblLink
            // 
            this.LblLink.AutoSize = true;
            this.LblLink.Location = new System.Drawing.Point(314, 62);
            this.LblLink.Name = "LblLink";
            this.LblLink.Size = new System.Drawing.Size(65, 12);
            this.LblLink.TabIndex = 129;
            this.LblLink.Text = "結束時間：";
            // 
            // DtpBegin
            // 
            this.DtpBegin.CustomFormat = "yyyy-MM-dd";
            this.DtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpBegin.Location = new System.Drawing.Point(316, 38);
            this.DtpBegin.Name = "DtpBegin";
            this.DtpBegin.Size = new System.Drawing.Size(168, 21);
            this.DtpBegin.TabIndex = 128;
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Location = new System.Drawing.Point(314, 18);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(65, 12);
            this.LblDate.TabIndex = 127;
            this.LblDate.Text = "開始時間：";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(565, 57);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "關閉";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(565, 21);
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
            // tbcResult
            // 
            this.tbcResult.Controls.Add(this.tpgCharacter);
            this.tbcResult.Controls.Add(this.tpgNormalMission);
            this.tbcResult.Controls.Add(this.tpgStoryMission);
            this.tbcResult.Controls.Add(this.tpgFamilyMission);
            this.tbcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcResult.Location = new System.Drawing.Point(0, 140);
            this.tbcResult.Name = "tbcResult";
            this.tbcResult.SelectedIndex = 0;
            this.tbcResult.Size = new System.Drawing.Size(652, 296);
            this.tbcResult.TabIndex = 40;
            this.tbcResult.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbcResult_Selected);
            // 
            // tpgCharacter
            // 
            this.tpgCharacter.Controls.Add(this.pnlRoleView);
            this.tpgCharacter.Controls.Add(this.GrdRoleView);
            this.tpgCharacter.Location = new System.Drawing.Point(4, 21);
            this.tpgCharacter.Name = "tpgCharacter";
            this.tpgCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.tpgCharacter.Size = new System.Drawing.Size(644, 271);
            this.tpgCharacter.TabIndex = 0;
            this.tpgCharacter.Text = "用户资料信息";
            this.tpgCharacter.UseVisualStyleBackColor = true;
            // 
            // pnlRoleView
            // 
            this.pnlRoleView.Controls.Add(this.cmbRoleView);
            this.pnlRoleView.Controls.Add(this.lblRoleView);
            this.pnlRoleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRoleView.Location = new System.Drawing.Point(3, 3);
            this.pnlRoleView.Name = "pnlRoleView";
            this.pnlRoleView.Size = new System.Drawing.Size(638, 37);
            this.pnlRoleView.TabIndex = 25;
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
            // GrdRoleView
            // 
            this.GrdRoleView.AllowUserToAddRows = false;
            this.GrdRoleView.AllowUserToDeleteRows = false;
            this.GrdRoleView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdRoleView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdRoleView.Location = new System.Drawing.Point(3, 3);
            this.GrdRoleView.Name = "GrdRoleView";
            this.GrdRoleView.ReadOnly = true;
            this.GrdRoleView.RowTemplate.Height = 23;
            this.GrdRoleView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdRoleView.Size = new System.Drawing.Size(638, 265);
            this.GrdRoleView.TabIndex = 26;
            // 
            // tpgNormalMission
            // 
            this.tpgNormalMission.Controls.Add(this.GrdNormalMission);
            this.tpgNormalMission.Controls.Add(this.pnlNormalMission);
            this.tpgNormalMission.Location = new System.Drawing.Point(4, 21);
            this.tpgNormalMission.Name = "tpgNormalMission";
            this.tpgNormalMission.Padding = new System.Windows.Forms.Padding(3);
            this.tpgNormalMission.Size = new System.Drawing.Size(644, 271);
            this.tpgNormalMission.TabIndex = 1;
            this.tpgNormalMission.Text = "普通任务";
            this.tpgNormalMission.UseVisualStyleBackColor = true;
            // 
            // GrdNormalMission
            // 
            this.GrdNormalMission.AllowUserToAddRows = false;
            this.GrdNormalMission.AllowUserToDeleteRows = false;
            this.GrdNormalMission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdNormalMission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdNormalMission.Location = new System.Drawing.Point(3, 40);
            this.GrdNormalMission.Name = "GrdNormalMission";
            this.GrdNormalMission.ReadOnly = true;
            this.GrdNormalMission.RowTemplate.Height = 23;
            this.GrdNormalMission.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdNormalMission.Size = new System.Drawing.Size(638, 228);
            this.GrdNormalMission.TabIndex = 26;
            // 
            // pnlNormalMission
            // 
            this.pnlNormalMission.Controls.Add(this.cmbNormalMission);
            this.pnlNormalMission.Controls.Add(this.lblHomeItemInfo);
            this.pnlNormalMission.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNormalMission.Location = new System.Drawing.Point(3, 3);
            this.pnlNormalMission.Name = "pnlNormalMission";
            this.pnlNormalMission.Size = new System.Drawing.Size(638, 37);
            this.pnlNormalMission.TabIndex = 24;
            // 
            // cmbNormalMission
            // 
            this.cmbNormalMission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNormalMission.FormattingEnabled = true;
            this.cmbNormalMission.Location = new System.Drawing.Point(124, 8);
            this.cmbNormalMission.Name = "cmbNormalMission";
            this.cmbNormalMission.Size = new System.Drawing.Size(100, 20);
            this.cmbNormalMission.TabIndex = 1;
            this.cmbNormalMission.SelectedIndexChanged += new System.EventHandler(this.cmbNormalMission_SelectedIndexChanged);
            // 
            // lblHomeItemInfo
            // 
            this.lblHomeItemInfo.AutoSize = true;
            this.lblHomeItemInfo.Location = new System.Drawing.Point(20, 13);
            this.lblHomeItemInfo.Name = "lblHomeItemInfo";
            this.lblHomeItemInfo.Size = new System.Drawing.Size(101, 12);
            this.lblHomeItemInfo.TabIndex = 0;
            this.lblHomeItemInfo.Text = "請選擇查看頁數：";
            // 
            // tpgStoryMission
            // 
            this.tpgStoryMission.Controls.Add(this.GrdStoryMission);
            this.tpgStoryMission.Controls.Add(this.pnlStoryMission);
            this.tpgStoryMission.Location = new System.Drawing.Point(4, 21);
            this.tpgStoryMission.Name = "tpgStoryMission";
            this.tpgStoryMission.Size = new System.Drawing.Size(644, 271);
            this.tpgStoryMission.TabIndex = 2;
            this.tpgStoryMission.Text = "故事任务";
            this.tpgStoryMission.UseVisualStyleBackColor = true;
            // 
            // GrdStoryMission
            // 
            this.GrdStoryMission.AllowUserToAddRows = false;
            this.GrdStoryMission.AllowUserToDeleteRows = false;
            this.GrdStoryMission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdStoryMission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdStoryMission.Location = new System.Drawing.Point(0, 37);
            this.GrdStoryMission.Name = "GrdStoryMission";
            this.GrdStoryMission.ReadOnly = true;
            this.GrdStoryMission.RowTemplate.Height = 23;
            this.GrdStoryMission.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdStoryMission.Size = new System.Drawing.Size(644, 234);
            this.GrdStoryMission.TabIndex = 26;
            // 
            // pnlStoryMission
            // 
            this.pnlStoryMission.Controls.Add(this.cmdStoryMission);
            this.pnlStoryMission.Controls.Add(this.lblStoryMission);
            this.pnlStoryMission.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStoryMission.Location = new System.Drawing.Point(0, 0);
            this.pnlStoryMission.Name = "pnlStoryMission";
            this.pnlStoryMission.Size = new System.Drawing.Size(644, 37);
            this.pnlStoryMission.TabIndex = 24;
            // 
            // cmdStoryMission
            // 
            this.cmdStoryMission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdStoryMission.FormattingEnabled = true;
            this.cmdStoryMission.Location = new System.Drawing.Point(124, 8);
            this.cmdStoryMission.Name = "cmdStoryMission";
            this.cmdStoryMission.Size = new System.Drawing.Size(100, 20);
            this.cmdStoryMission.TabIndex = 1;
            this.cmdStoryMission.SelectedIndexChanged += new System.EventHandler(this.cmdStoryMission_SelectedIndexChanged);
            // 
            // lblStoryMission
            // 
            this.lblStoryMission.AutoSize = true;
            this.lblStoryMission.Location = new System.Drawing.Point(20, 13);
            this.lblStoryMission.Name = "lblStoryMission";
            this.lblStoryMission.Size = new System.Drawing.Size(101, 12);
            this.lblStoryMission.TabIndex = 0;
            this.lblStoryMission.Text = "請選擇查看頁數：";
            // 
            // tpgFamilyMission
            // 
            this.tpgFamilyMission.Controls.Add(this.GrdFamilyMission);
            this.tpgFamilyMission.Controls.Add(this.pnlFamilyMission);
            this.tpgFamilyMission.Location = new System.Drawing.Point(4, 21);
            this.tpgFamilyMission.Name = "tpgFamilyMission";
            this.tpgFamilyMission.Size = new System.Drawing.Size(644, 271);
            this.tpgFamilyMission.TabIndex = 3;
            this.tpgFamilyMission.Text = "家族任务";
            this.tpgFamilyMission.UseVisualStyleBackColor = true;
            // 
            // GrdFamilyMission
            // 
            this.GrdFamilyMission.AllowUserToAddRows = false;
            this.GrdFamilyMission.AllowUserToDeleteRows = false;
            this.GrdFamilyMission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdFamilyMission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdFamilyMission.Location = new System.Drawing.Point(0, 37);
            this.GrdFamilyMission.Name = "GrdFamilyMission";
            this.GrdFamilyMission.ReadOnly = true;
            this.GrdFamilyMission.RowTemplate.Height = 23;
            this.GrdFamilyMission.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdFamilyMission.Size = new System.Drawing.Size(644, 234);
            this.GrdFamilyMission.TabIndex = 26;
            // 
            // pnlFamilyMission
            // 
            this.pnlFamilyMission.Controls.Add(this.cmbFamilyMission);
            this.pnlFamilyMission.Controls.Add(this.lblFamilyMission);
            this.pnlFamilyMission.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFamilyMission.Location = new System.Drawing.Point(0, 0);
            this.pnlFamilyMission.Name = "pnlFamilyMission";
            this.pnlFamilyMission.Size = new System.Drawing.Size(644, 37);
            this.pnlFamilyMission.TabIndex = 24;
            // 
            // cmbFamilyMission
            // 
            this.cmbFamilyMission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFamilyMission.FormattingEnabled = true;
            this.cmbFamilyMission.Location = new System.Drawing.Point(124, 8);
            this.cmbFamilyMission.Name = "cmbFamilyMission";
            this.cmbFamilyMission.Size = new System.Drawing.Size(100, 20);
            this.cmbFamilyMission.TabIndex = 1;
            this.cmbFamilyMission.SelectedIndexChanged += new System.EventHandler(this.cmbFamilyMission_SelectedIndexChanged);
            // 
            // lblFamilyMission
            // 
            this.lblFamilyMission.AutoSize = true;
            this.lblFamilyMission.Location = new System.Drawing.Point(20, 13);
            this.lblFamilyMission.Name = "lblFamilyMission";
            this.lblFamilyMission.Size = new System.Drawing.Size(101, 12);
            this.lblFamilyMission.TabIndex = 0;
            this.lblFamilyMission.Text = "請選擇查看頁數：";
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
            // backgroundWorkerNormailMissionLog
            // 
            this.backgroundWorkerNormailMissionLog.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerNormailMissionLog_DoWork);
            this.backgroundWorkerNormailMissionLog.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerNormailMissionLog_RunWorkerCompleted);
            // 
            // backgroundWorkerStoryMissionLog
            // 
            this.backgroundWorkerStoryMissionLog.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerStoryMissionLog_DoWork);
            this.backgroundWorkerStoryMissionLog.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerStoryMissionLog_RunWorkerCompleted);
            // 
            // backgroundWorkerFamilyMissionLog
            // 
            this.backgroundWorkerFamilyMissionLog.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFamilyMission_DoWork);
            this.backgroundWorkerFamilyMissionLog.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFamilyMission_RunWorkerCompleted);
            // 
            // backgroundWorkerReNormailMissionLog
            // 
            this.backgroundWorkerReNormailMissionLog.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReNormailMissionLog_DoWork);
            this.backgroundWorkerReNormailMissionLog.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReNormailMissionLog_RunWorkerCompleted);
            // 
            // backgroundWorkerReStoryMissionLog
            // 
            this.backgroundWorkerReStoryMissionLog.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReStoryMissionLog_DoWork);
            this.backgroundWorkerReStoryMissionLog.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReStoryMissionLog_RunWorkerCompleted);
            // 
            // backgroundWorkerReFamilyMissionLog
            // 
            this.backgroundWorkerReFamilyMissionLog.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReFamilyMissionLog_DoWork);
            this.backgroundWorkerReFamilyMissionLog.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReFamilyMissionLog_RunWorkerCompleted);
            // 
            // FrmJW2MissionLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 436);
            this.Controls.Add(this.tbcResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmJW2MissionLog";
            this.Text = "任務日誌查詢";
            this.Load += new System.EventHandler(this.FrmJW2MissionLog_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.tbcResult.ResumeLayout(false);
            this.tpgCharacter.ResumeLayout(false);
            this.pnlRoleView.ResumeLayout(false);
            this.pnlRoleView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdRoleView)).EndInit();
            this.tpgNormalMission.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdNormalMission)).EndInit();
            this.pnlNormalMission.ResumeLayout(false);
            this.pnlNormalMission.PerformLayout();
            this.tpgStoryMission.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdStoryMission)).EndInit();
            this.pnlStoryMission.ResumeLayout(false);
            this.pnlStoryMission.PerformLayout();
            this.tpgFamilyMission.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdFamilyMission)).EndInit();
            this.pnlFamilyMission.ResumeLayout(false);
            this.pnlFamilyMission.PerformLayout();
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
        private System.Windows.Forms.TabPage tpgNormalMission;
        private System.Windows.Forms.TabPage tpgStoryMission;
        private System.Windows.Forms.TabPage tpgFamilyMission;
        private System.Windows.Forms.Panel pnlRoleView;
        private System.Windows.Forms.ComboBox cmbRoleView;
        private System.Windows.Forms.Label lblRoleView;
        private System.Windows.Forms.DataGridView GrdRoleView;
        private System.Windows.Forms.DataGridView GrdNormalMission;
        private System.Windows.Forms.Panel pnlNormalMission;
        private System.Windows.Forms.ComboBox cmbNormalMission;
        private System.Windows.Forms.Label lblHomeItemInfo;
        private System.Windows.Forms.DataGridView GrdStoryMission;
        private System.Windows.Forms.Panel pnlStoryMission;
        private System.Windows.Forms.ComboBox cmdStoryMission;
        private System.Windows.Forms.Label lblStoryMission;
        private System.Windows.Forms.DataGridView GrdFamilyMission;
        private System.Windows.Forms.Panel pnlFamilyMission;
        private System.Windows.Forms.ComboBox cmbFamilyMission;
        private System.Windows.Forms.Label lblFamilyMission;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerNormailMissionLog;
        private System.ComponentModel.BackgroundWorker backgroundWorkerStoryMissionLog;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFamilyMissionLog;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReNormailMissionLog;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReStoryMissionLog;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReFamilyMissionLog;
        private System.Windows.Forms.DateTimePicker DtpEnd;
        private System.Windows.Forms.Label LblLink;
        private System.Windows.Forms.DateTimePicker DtpBegin;
        private System.Windows.Forms.Label LblDate;
    }
}