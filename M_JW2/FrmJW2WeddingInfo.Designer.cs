namespace M_JW2
{
    partial class FrmJW2WeddingInfo
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
            this.GrdRoleView = new System.Windows.Forms.DataGridView();
            this.pnlRoleView = new System.Windows.Forms.Panel();
            this.cmbRoleView = new System.Windows.Forms.ComboBox();
            this.lblRoleView = new System.Windows.Forms.Label();
            this.tpgWeddingInfo = new System.Windows.Forms.TabPage();
            this.GrdWeddingInfo = new System.Windows.Forms.DataGridView();
            this.tpgWeddingLog = new System.Windows.Forms.TabPage();
            this.GrdWeddingLog = new System.Windows.Forms.DataGridView();
            this.pnlHomeItemInfo = new System.Windows.Forms.Panel();
            this.cmbHomeItemInfo = new System.Windows.Forms.ComboBox();
            this.lblHomeItemInfo = new System.Windows.Forms.Label();
            this.GrdCharacter = new System.Windows.Forms.DataGridView();
            this.GrdMarried = new System.Windows.Forms.DataGridView();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerWeddingInfo = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerWeddingLog = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReWeddingLog = new System.ComponentModel.BackgroundWorker();
            this.GrpSearch.SuspendLayout();
            this.tbcResult.SuspendLayout();
            this.tpgCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdRoleView)).BeginInit();
            this.pnlRoleView.SuspendLayout();
            this.tpgWeddingInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdWeddingInfo)).BeginInit();
            this.tpgWeddingLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdWeddingLog)).BeginInit();
            this.pnlHomeItemInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdMarried)).BeginInit();
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
            this.GrpSearch.Size = new System.Drawing.Size(635, 140);
            this.GrpSearch.TabIndex = 2;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索條件";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(315, 52);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "關閉";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(315, 16);
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
            this.tbcResult.Controls.Add(this.tpgWeddingInfo);
            this.tbcResult.Controls.Add(this.tpgWeddingLog);
            this.tbcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcResult.Location = new System.Drawing.Point(0, 140);
            this.tbcResult.Name = "tbcResult";
            this.tbcResult.SelectedIndex = 0;
            this.tbcResult.Size = new System.Drawing.Size(635, 308);
            this.tbcResult.TabIndex = 27;
            this.tbcResult.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbcResult_Selected);
            // 
            // tpgCharacter
            // 
            this.tpgCharacter.Controls.Add(this.GrdRoleView);
            this.tpgCharacter.Controls.Add(this.pnlRoleView);
            this.tpgCharacter.Location = new System.Drawing.Point(4, 21);
            this.tpgCharacter.Name = "tpgCharacter";
            this.tpgCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.tpgCharacter.Size = new System.Drawing.Size(627, 283);
            this.tpgCharacter.TabIndex = 0;
            this.tpgCharacter.Text = "玩家基本資訊";
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
            this.GrdRoleView.Size = new System.Drawing.Size(621, 240);
            this.GrdRoleView.TabIndex = 21;
            this.GrdRoleView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdRoleView_CellClick);
            // 
            // pnlRoleView
            // 
            this.pnlRoleView.Controls.Add(this.cmbRoleView);
            this.pnlRoleView.Controls.Add(this.lblRoleView);
            this.pnlRoleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRoleView.Location = new System.Drawing.Point(3, 3);
            this.pnlRoleView.Name = "pnlRoleView";
            this.pnlRoleView.Size = new System.Drawing.Size(621, 37);
            this.pnlRoleView.TabIndex = 19;
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
            // tpgWeddingInfo
            // 
            this.tpgWeddingInfo.Controls.Add(this.GrdWeddingInfo);
            this.tpgWeddingInfo.Location = new System.Drawing.Point(4, 21);
            this.tpgWeddingInfo.Name = "tpgWeddingInfo";
            this.tpgWeddingInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpgWeddingInfo.Size = new System.Drawing.Size(627, 283);
            this.tpgWeddingInfo.TabIndex = 1;
            this.tpgWeddingInfo.Text = "婚姻信息";
            this.tpgWeddingInfo.UseVisualStyleBackColor = true;
            // 
            // GrdWeddingInfo
            // 
            this.GrdWeddingInfo.AllowUserToAddRows = false;
            this.GrdWeddingInfo.AllowUserToDeleteRows = false;
            this.GrdWeddingInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdWeddingInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdWeddingInfo.Location = new System.Drawing.Point(3, 3);
            this.GrdWeddingInfo.Name = "GrdWeddingInfo";
            this.GrdWeddingInfo.ReadOnly = true;
            this.GrdWeddingInfo.RowTemplate.Height = 23;
            this.GrdWeddingInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdWeddingInfo.Size = new System.Drawing.Size(621, 277);
            this.GrdWeddingInfo.TabIndex = 23;
            // 
            // tpgWeddingLog
            // 
            this.tpgWeddingLog.Controls.Add(this.GrdWeddingLog);
            this.tpgWeddingLog.Controls.Add(this.pnlHomeItemInfo);
            this.tpgWeddingLog.Location = new System.Drawing.Point(4, 21);
            this.tpgWeddingLog.Name = "tpgWeddingLog";
            this.tpgWeddingLog.Size = new System.Drawing.Size(627, 283);
            this.tpgWeddingLog.TabIndex = 2;
            this.tpgWeddingLog.Text = "婚姻日誌";
            this.tpgWeddingLog.UseVisualStyleBackColor = true;
            // 
            // GrdWeddingLog
            // 
            this.GrdWeddingLog.AllowUserToAddRows = false;
            this.GrdWeddingLog.AllowUserToDeleteRows = false;
            this.GrdWeddingLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdWeddingLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdWeddingLog.Location = new System.Drawing.Point(0, 37);
            this.GrdWeddingLog.Name = "GrdWeddingLog";
            this.GrdWeddingLog.ReadOnly = true;
            this.GrdWeddingLog.RowTemplate.Height = 23;
            this.GrdWeddingLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdWeddingLog.Size = new System.Drawing.Size(627, 246);
            this.GrdWeddingLog.TabIndex = 20;
            // 
            // pnlHomeItemInfo
            // 
            this.pnlHomeItemInfo.Controls.Add(this.cmbHomeItemInfo);
            this.pnlHomeItemInfo.Controls.Add(this.lblHomeItemInfo);
            this.pnlHomeItemInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHomeItemInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlHomeItemInfo.Name = "pnlHomeItemInfo";
            this.pnlHomeItemInfo.Size = new System.Drawing.Size(627, 37);
            this.pnlHomeItemInfo.TabIndex = 18;
            // 
            // cmbHomeItemInfo
            // 
            this.cmbHomeItemInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHomeItemInfo.FormattingEnabled = true;
            this.cmbHomeItemInfo.Location = new System.Drawing.Point(124, 8);
            this.cmbHomeItemInfo.Name = "cmbHomeItemInfo";
            this.cmbHomeItemInfo.Size = new System.Drawing.Size(100, 20);
            this.cmbHomeItemInfo.TabIndex = 1;
            this.cmbHomeItemInfo.SelectedIndexChanged += new System.EventHandler(this.cmbHomeItemInfo_SelectedIndexChanged);
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
            // GrdCharacter
            // 
            this.GrdCharacter.AllowUserToAddRows = false;
            this.GrdCharacter.AllowUserToDeleteRows = false;
            this.GrdCharacter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdCharacter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdCharacter.Location = new System.Drawing.Point(0, 140);
            this.GrdCharacter.Name = "GrdCharacter";
            this.GrdCharacter.ReadOnly = true;
            this.GrdCharacter.RowTemplate.Height = 23;
            this.GrdCharacter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdCharacter.Size = new System.Drawing.Size(635, 308);
            this.GrdCharacter.TabIndex = 26;
            // 
            // GrdMarried
            // 
            this.GrdMarried.AllowUserToAddRows = false;
            this.GrdMarried.AllowUserToDeleteRows = false;
            this.GrdMarried.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdMarried.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdMarried.Location = new System.Drawing.Point(0, 140);
            this.GrdMarried.Name = "GrdMarried";
            this.GrdMarried.ReadOnly = true;
            this.GrdMarried.RowTemplate.Height = 23;
            this.GrdMarried.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdMarried.Size = new System.Drawing.Size(635, 308);
            this.GrdMarried.TabIndex = 28;
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
            // backgroundWorkerWeddingInfo
            // 
            this.backgroundWorkerWeddingInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerWeddingInfo_DoWork);
            this.backgroundWorkerWeddingInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerWeddingInfo_RunWorkerCompleted);
            // 
            // backgroundWorkerWeddingLog
            // 
            this.backgroundWorkerWeddingLog.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerWeddingLog_DoWork);
            this.backgroundWorkerWeddingLog.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerWeddingLog_RunWorkerCompleted);
            // 
            // backgroundWorkerReWeddingLog
            // 
            this.backgroundWorkerReWeddingLog.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReWeddingLog_DoWork);
            this.backgroundWorkerReWeddingLog.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReWeddingLog_RunWorkerCompleted);
            // 
            // FrmJW2WeddingInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 448);
            this.Controls.Add(this.tbcResult);
            this.Controls.Add(this.GrdCharacter);
            this.Controls.Add(this.GrdMarried);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmJW2WeddingInfo";
            this.Text = "婚姻信息";
            this.Load += new System.EventHandler(this.FrmJW2WeddingInfo_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.tbcResult.ResumeLayout(false);
            this.tpgCharacter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdRoleView)).EndInit();
            this.pnlRoleView.ResumeLayout(false);
            this.pnlRoleView.PerformLayout();
            this.tpgWeddingInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdWeddingInfo)).EndInit();
            this.tpgWeddingLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdWeddingLog)).EndInit();
            this.pnlHomeItemInfo.ResumeLayout(false);
            this.pnlHomeItemInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdMarried)).EndInit();
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
        private System.Windows.Forms.TabPage tpgWeddingInfo;
        private System.Windows.Forms.DataGridView GrdCharacter;
        private System.Windows.Forms.DataGridView GrdMarried;
        private System.Windows.Forms.DataGridView GrdWeddingInfo;
        private System.Windows.Forms.TabPage tpgWeddingLog;
        private System.Windows.Forms.DataGridView GrdWeddingLog;
        private System.Windows.Forms.Panel pnlHomeItemInfo;
        private System.Windows.Forms.ComboBox cmbHomeItemInfo;
        private System.Windows.Forms.Label lblHomeItemInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReSearch;
        private System.Windows.Forms.DataGridView GrdRoleView;
        private System.Windows.Forms.Panel pnlRoleView;
        private System.Windows.Forms.ComboBox cmbRoleView;
        private System.Windows.Forms.Label lblRoleView;
        private System.ComponentModel.BackgroundWorker backgroundWorkerWeddingInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerWeddingLog;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReWeddingLog;
    }
}