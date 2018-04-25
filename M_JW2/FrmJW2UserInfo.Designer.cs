namespace M_JW2
{
    partial class FrmJW2UserInfo
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtNick = new System.Windows.Forms.TextBox();
            this.lblNick = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.tpgBodyInfo = new System.Windows.Forms.TabPage();
            this.GrdBodyItemInfo = new System.Windows.Forms.DataGridView();
            this.pnlBodyItemInfo = new System.Windows.Forms.Panel();
            this.cmbBodyItemInfo = new System.Windows.Forms.ComboBox();
            this.lblBodyItemInfo = new System.Windows.Forms.Label();
            this.tpgStoryState = new System.Windows.Forms.TabPage();
            this.GrdStoryState = new System.Windows.Forms.DataGridView();
            this.pnlStoryState = new System.Windows.Forms.Panel();
            this.cmbStorySate = new System.Windows.Forms.ComboBox();
            this.lblStoryState = new System.Windows.Forms.Label();
            this.tpgCharacter = new System.Windows.Forms.TabPage();
            this.GrdRoleView = new System.Windows.Forms.DataGridView();
            this.pnlRoleView = new System.Windows.Forms.Panel();
            this.cmbRoleView = new System.Windows.Forms.ComboBox();
            this.lblRoleView = new System.Windows.Forms.Label();
            this.tbcResult = new System.Windows.Forms.TabControl();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerStoryState = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerBodyItemInfo = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerHomeItemInfo = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerBuyPresentLog = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerBugleSendLog = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerConsumerItemUser = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerUserFamilyInfo = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReStoryState = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReBodyItemInfo = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReHomeItemInfo = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReBuyPresentLog = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReBugleSendLog = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReConsumerItemUser = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReUserFamilyInfo = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerInterIntem = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReInterIntem = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerInterBodyItem = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReBodyInterIntem = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReInterBodyItem = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerIntimacyNumLog = new System.ComponentModel.BackgroundWorker();
            this.GrpSearch.SuspendLayout();
            this.tpgBodyInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdBodyItemInfo)).BeginInit();
            this.pnlBodyItemInfo.SuspendLayout();
            this.tpgStoryState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdStoryState)).BeginInit();
            this.pnlStoryState.SuspendLayout();
            this.tpgCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdRoleView)).BeginInit();
            this.pnlRoleView.SuspendLayout();
            this.tbcResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.label1);
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
            this.GrpSearch.Size = new System.Drawing.Size(956, 133);
            this.GrpSearch.TabIndex = 4;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索條件";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(344, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "提示:雙擊用戶資料資?顯示故事劇情狀態";
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
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(310, 23);
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
            this.lblAccount.Size = new System.Drawing.Size(59, 12);
            this.lblAccount.TabIndex = 26;
            this.lblAccount.Text = "玩家帳?：";
            // 
            // cmbServer
            // 
            this.cmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(107, 25);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(187, 20);
            this.cmbServer.TabIndex = 25;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(24, 28);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(65, 12);
            this.lblServer.TabIndex = 24;
            this.lblServer.Text = "遊戲伺服器：";
            // 
            // tpgBodyInfo
            // 
            this.tpgBodyInfo.Controls.Add(this.GrdBodyItemInfo);
            this.tpgBodyInfo.Controls.Add(this.pnlBodyItemInfo);
            this.tpgBodyInfo.Location = new System.Drawing.Point(4, 21);
            this.tpgBodyInfo.Name = "tpgBodyInfo";
            this.tpgBodyInfo.Size = new System.Drawing.Size(948, 384);
            this.tpgBodyInfo.TabIndex = 4;
            this.tpgBodyInfo.Text = "身上道具信息";
            this.tpgBodyInfo.UseVisualStyleBackColor = true;
            // 
            // GrdBodyItemInfo
            // 
            this.GrdBodyItemInfo.AllowUserToAddRows = false;
            this.GrdBodyItemInfo.AllowUserToDeleteRows = false;
            this.GrdBodyItemInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdBodyItemInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdBodyItemInfo.Location = new System.Drawing.Point(0, 37);
            this.GrdBodyItemInfo.Name = "GrdBodyItemInfo";
            this.GrdBodyItemInfo.ReadOnly = true;
            this.GrdBodyItemInfo.RowTemplate.Height = 23;
            this.GrdBodyItemInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdBodyItemInfo.Size = new System.Drawing.Size(948, 347);
            this.GrdBodyItemInfo.TabIndex = 15;
            // 
            // pnlBodyItemInfo
            // 
            this.pnlBodyItemInfo.Controls.Add(this.cmbBodyItemInfo);
            this.pnlBodyItemInfo.Controls.Add(this.lblBodyItemInfo);
            this.pnlBodyItemInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBodyItemInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlBodyItemInfo.Name = "pnlBodyItemInfo";
            this.pnlBodyItemInfo.Size = new System.Drawing.Size(948, 37);
            this.pnlBodyItemInfo.TabIndex = 13;
            // 
            // cmbBodyItemInfo
            // 
            this.cmbBodyItemInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBodyItemInfo.FormattingEnabled = true;
            this.cmbBodyItemInfo.Location = new System.Drawing.Point(124, 8);
            this.cmbBodyItemInfo.Name = "cmbBodyItemInfo";
            this.cmbBodyItemInfo.Size = new System.Drawing.Size(100, 20);
            this.cmbBodyItemInfo.TabIndex = 1;
            this.cmbBodyItemInfo.SelectedIndexChanged += new System.EventHandler(this.cmbBodyItemInfo_SelectedIndexChanged);
            // 
            // lblBodyItemInfo
            // 
            this.lblBodyItemInfo.AutoSize = true;
            this.lblBodyItemInfo.Location = new System.Drawing.Point(20, 13);
            this.lblBodyItemInfo.Name = "lblBodyItemInfo";
            this.lblBodyItemInfo.Size = new System.Drawing.Size(89, 12);
            this.lblBodyItemInfo.TabIndex = 0;
            this.lblBodyItemInfo.Text = "?選擇查看?數：";
            // 
            // tpgStoryState
            // 
            this.tpgStoryState.Controls.Add(this.GrdStoryState);
            this.tpgStoryState.Controls.Add(this.pnlStoryState);
            this.tpgStoryState.Location = new System.Drawing.Point(4, 21);
            this.tpgStoryState.Name = "tpgStoryState";
            this.tpgStoryState.Padding = new System.Windows.Forms.Padding(3);
            this.tpgStoryState.Size = new System.Drawing.Size(948, 384);
            this.tpgStoryState.TabIndex = 0;
            this.tpgStoryState.Text = "故事剧情状态";
            this.tpgStoryState.UseVisualStyleBackColor = true;
            // 
            // GrdStoryState
            // 
            this.GrdStoryState.AllowUserToAddRows = false;
            this.GrdStoryState.AllowUserToDeleteRows = false;
            this.GrdStoryState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdStoryState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdStoryState.Location = new System.Drawing.Point(3, 40);
            this.GrdStoryState.Name = "GrdStoryState";
            this.GrdStoryState.ReadOnly = true;
            this.GrdStoryState.RowTemplate.Height = 23;
            this.GrdStoryState.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdStoryState.Size = new System.Drawing.Size(942, 341);
            this.GrdStoryState.TabIndex = 15;
            // 
            // pnlStoryState
            // 
            this.pnlStoryState.Controls.Add(this.cmbStorySate);
            this.pnlStoryState.Controls.Add(this.lblStoryState);
            this.pnlStoryState.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStoryState.Location = new System.Drawing.Point(3, 3);
            this.pnlStoryState.Name = "pnlStoryState";
            this.pnlStoryState.Size = new System.Drawing.Size(942, 37);
            this.pnlStoryState.TabIndex = 13;
            // 
            // cmbStorySate
            // 
            this.cmbStorySate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStorySate.FormattingEnabled = true;
            this.cmbStorySate.Location = new System.Drawing.Point(124, 8);
            this.cmbStorySate.Name = "cmbStorySate";
            this.cmbStorySate.Size = new System.Drawing.Size(100, 20);
            this.cmbStorySate.TabIndex = 1;
            this.cmbStorySate.SelectedIndexChanged += new System.EventHandler(this.cmbStorySate_SelectedIndexChanged);
            // 
            // lblStoryState
            // 
            this.lblStoryState.AutoSize = true;
            this.lblStoryState.Location = new System.Drawing.Point(20, 13);
            this.lblStoryState.Name = "lblStoryState";
            this.lblStoryState.Size = new System.Drawing.Size(89, 12);
            this.lblStoryState.TabIndex = 0;
            this.lblStoryState.Text = "?選擇查看?數：";
            // 
            // tpgCharacter
            // 
            this.tpgCharacter.Controls.Add(this.GrdRoleView);
            this.tpgCharacter.Controls.Add(this.pnlRoleView);
            this.tpgCharacter.Location = new System.Drawing.Point(4, 21);
            this.tpgCharacter.Name = "tpgCharacter";
            this.tpgCharacter.Size = new System.Drawing.Size(948, 384);
            this.tpgCharacter.TabIndex = 7;
            this.tpgCharacter.Text = "用户资料信息";
            this.tpgCharacter.UseVisualStyleBackColor = true;
            // 
            // GrdRoleView
            // 
            this.GrdRoleView.AllowUserToAddRows = false;
            this.GrdRoleView.AllowUserToDeleteRows = false;
            this.GrdRoleView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdRoleView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdRoleView.Location = new System.Drawing.Point(0, 37);
            this.GrdRoleView.Name = "GrdRoleView";
            this.GrdRoleView.ReadOnly = true;
            this.GrdRoleView.RowTemplate.Height = 23;
            this.GrdRoleView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdRoleView.Size = new System.Drawing.Size(948, 347);
            this.GrdRoleView.TabIndex = 18;
            this.GrdRoleView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdRoleView_CellClick);
            // 
            // pnlRoleView
            // 
            this.pnlRoleView.Controls.Add(this.cmbRoleView);
            this.pnlRoleView.Controls.Add(this.lblRoleView);
            this.pnlRoleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRoleView.Location = new System.Drawing.Point(0, 0);
            this.pnlRoleView.Name = "pnlRoleView";
            this.pnlRoleView.Size = new System.Drawing.Size(948, 37);
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
            this.cmbRoleView.SelectedIndexChanged += new System.EventHandler(this.cmbRoleView_SelectedIndexChanged);
            // 
            // lblRoleView
            // 
            this.lblRoleView.AutoSize = true;
            this.lblRoleView.Location = new System.Drawing.Point(20, 13);
            this.lblRoleView.Name = "lblRoleView";
            this.lblRoleView.Size = new System.Drawing.Size(89, 12);
            this.lblRoleView.TabIndex = 0;
            this.lblRoleView.Text = "?選擇查看?數：";
            // 
            // tbcResult
            // 
            this.tbcResult.Controls.Add(this.tpgCharacter);
            this.tbcResult.Controls.Add(this.tpgStoryState);
            this.tbcResult.Controls.Add(this.tpgBodyInfo);
            this.tbcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcResult.Location = new System.Drawing.Point(0, 133);
            this.tbcResult.Name = "tbcResult";
            this.tbcResult.SelectedIndex = 0;
            this.tbcResult.Size = new System.Drawing.Size(956, 409);
            this.tbcResult.TabIndex = 20;
            this.tbcResult.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbcResult_Selected);
            // 
            // backgroundWorkerFormLoad
            // 
            this.backgroundWorkerFormLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFormLoad_DoWork);
            this.backgroundWorkerFormLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFormLoad_RunWorkerCompleted);
            // 
            // backgroundWorkerStoryState
            // 
            this.backgroundWorkerStoryState.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerStoryState_DoWork);
            this.backgroundWorkerStoryState.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerStoryState_RunWorkerCompleted);
            // 
            // backgroundWorkerBodyItemInfo
            // 
            this.backgroundWorkerBodyItemInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerBodyItemInfo_DoWork);
            this.backgroundWorkerBodyItemInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerBodyItemInfo_RunWorkerCompleted);
            // 
            // backgroundWorkerHomeItemInfo
            // 
            this.backgroundWorkerHomeItemInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerHomeItemInfo_DoWork);
            this.backgroundWorkerHomeItemInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerHomeItemInfo_RunWorkerCompleted);
            // 
            // backgroundWorkerBuyPresentLog
            // 
            this.backgroundWorkerBuyPresentLog.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerBuyPresentLog_DoWork);
            this.backgroundWorkerBuyPresentLog.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerBuyPresentLog_RunWorkerCompleted);
            // 
            // backgroundWorkerBugleSendLog
            // 
            this.backgroundWorkerBugleSendLog.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerBugleSendLog_DoWork);
            this.backgroundWorkerBugleSendLog.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerBugleSendLog_RunWorkerCompleted);
            // 
            // backgroundWorkerConsumerItemUser
            // 
            this.backgroundWorkerConsumerItemUser.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerConsumerItemUser_DoWork);
            this.backgroundWorkerConsumerItemUser.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerConsumerItemUser_RunWorkerCompleted);
            // 
            // backgroundWorkerUserFamilyInfo
            // 
            this.backgroundWorkerUserFamilyInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerUserFamilyInfo_DoWork);
            this.backgroundWorkerUserFamilyInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerUserFamilyInfo_RunWorkerCompleted);
            // 
            // backgroundWorkerReStoryState
            // 
            this.backgroundWorkerReStoryState.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReStoryState_DoWork);
            this.backgroundWorkerReStoryState.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReStoryState_RunWorkerCompleted);
            // 
            // backgroundWorkerReBodyItemInfo
            // 
            this.backgroundWorkerReBodyItemInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReBodyItemInfo_DoWork);
            this.backgroundWorkerReBodyItemInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReBodyItemInfo_RunWorkerCompleted);
            // 
            // backgroundWorkerReHomeItemInfo
            // 
            this.backgroundWorkerReHomeItemInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReHomeItemInfo_DoWork);
            this.backgroundWorkerReHomeItemInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReHomeItemInfo_RunWorkerCompleted);
            // 
            // backgroundWorkerReBuyPresentLog
            // 
            this.backgroundWorkerReBuyPresentLog.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReBuyPresentLog_DoWork);
            this.backgroundWorkerReBuyPresentLog.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReBuyPresentLog_RunWorkerCompleted);
            // 
            // backgroundWorkerReBugleSendLog
            // 
            this.backgroundWorkerReBugleSendLog.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReBugleSendLog_DoWork);
            this.backgroundWorkerReBugleSendLog.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReBugleSendLog_RunWorkerCompleted);
            // 
            // backgroundWorkerReConsumerItemUser
            // 
            this.backgroundWorkerReConsumerItemUser.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReConsumerItemUser_DoWork);
            this.backgroundWorkerReConsumerItemUser.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReConsumerItemUser_RunWorkerCompleted);
            // 
            // backgroundWorkerReUserFamilyInfo
            // 
            this.backgroundWorkerReUserFamilyInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReUserFamilyInfo_DoWork);
            this.backgroundWorkerReUserFamilyInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReUserFamilyInfo_RunWorkerCompleted);
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
            // backgroundWorkerInterIntem
            // 
            this.backgroundWorkerInterIntem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerInterIntem_DoWork);
            this.backgroundWorkerInterIntem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerInterIntem_RunWorkerCompleted);
            // 
            // backgroundWorkerReInterIntem
            // 
            this.backgroundWorkerReInterIntem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReInterIntem_DoWork);
            this.backgroundWorkerReInterIntem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReInterIntem_RunWorkerCompleted);
            // 
            // backgroundWorkerInterBodyItem
            // 
            this.backgroundWorkerInterBodyItem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerInterBodyItem_DoWork);
            this.backgroundWorkerInterBodyItem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerInterBodyItem_RunWorkerCompleted);
            // 
            // backgroundWorkerReBodyInterIntem
            // 
            this.backgroundWorkerReBodyInterIntem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReBodyInterIntem_DoWork);
            this.backgroundWorkerReBodyInterIntem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReBodyInterIntem_RunWorkerCompleted);
            // 
            // backgroundWorkerReInterBodyItem
            // 
            this.backgroundWorkerReInterBodyItem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReInterBodyItem_DoWork);
            this.backgroundWorkerReInterBodyItem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReInterBodyItem_RunWorkerCompleted);
            // 
            // FrmJW2UserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 542);
            this.Controls.Add(this.tbcResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmJW2UserInfo";
            this.Text = "用戶資?查?";
            this.Load += new System.EventHandler(this.FrmJW2UserInfo_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.tpgBodyInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdBodyItemInfo)).EndInit();
            this.pnlBodyItemInfo.ResumeLayout(false);
            this.pnlBodyItemInfo.PerformLayout();
            this.tpgStoryState.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdStoryState)).EndInit();
            this.pnlStoryState.ResumeLayout(false);
            this.pnlStoryState.PerformLayout();
            this.tpgCharacter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdRoleView)).EndInit();
            this.pnlRoleView.ResumeLayout(false);
            this.pnlRoleView.PerformLayout();
            this.tbcResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtNick;
        private System.Windows.Forms.Label lblNick;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.ComboBox cmbServer;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TabPage tpgBodyInfo;
        private System.Windows.Forms.DataGridView GrdBodyItemInfo;
        private System.Windows.Forms.Panel pnlBodyItemInfo;
        private System.Windows.Forms.ComboBox cmbBodyItemInfo;
        private System.Windows.Forms.Label lblBodyItemInfo;
        private System.Windows.Forms.TabPage tpgStoryState;
        private System.Windows.Forms.DataGridView GrdStoryState;
        private System.Windows.Forms.Panel pnlStoryState;
        private System.Windows.Forms.ComboBox cmbStorySate;
        private System.Windows.Forms.Label lblStoryState;
        private System.Windows.Forms.TabPage tpgCharacter;
        private System.Windows.Forms.TabControl tbcResult;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerStoryState;
        private System.ComponentModel.BackgroundWorker backgroundWorkerBodyItemInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerHomeItemInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerBuyPresentLog;
        private System.ComponentModel.BackgroundWorker backgroundWorkerBugleSendLog;
        private System.ComponentModel.BackgroundWorker backgroundWorkerConsumerItemUser;
        private System.ComponentModel.BackgroundWorker backgroundWorkerUserFamilyInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReStoryState;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReBodyItemInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReHomeItemInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReBuyPresentLog;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReBugleSendLog;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReConsumerItemUser;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReUserFamilyInfo;
        private System.Windows.Forms.DataGridView GrdRoleView;
        private System.Windows.Forms.Panel pnlRoleView;
        private System.Windows.Forms.ComboBox cmbRoleView;
        private System.Windows.Forms.Label lblRoleView;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerInterIntem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReInterIntem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerInterBodyItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReBodyInterIntem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReInterBodyItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerIntimacyNumLog;
    }
}