namespace M_JW2
{
    partial class FrmJW2ActivityExchangeLog
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
            this.txtNick = new System.Windows.Forms.TextBox();
            this.lblNick = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.DtpEnd = new System.Windows.Forms.DateTimePicker();
            this.LblLink = new System.Windows.Forms.Label();
            this.DtpBegin = new System.Windows.Forms.DateTimePicker();
            this.LblDate = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.tbcResult = new System.Windows.Forms.TabControl();
            this.tpgCharacter = new System.Windows.Forms.TabPage();
            this.GrdRoleView = new System.Windows.Forms.DataGridView();
            this.pnlRoleView = new System.Windows.Forms.Panel();
            this.cmbRoleView = new System.Windows.Forms.ComboBox();
            this.lblRoleView = new System.Windows.Forms.Label();
            this.tpgConsumerItemLog = new System.Windows.Forms.TabPage();
            this.GrdActiveExchangeLog = new System.Windows.Forms.DataGridView();
            this.pnlActiveExchangeLog = new System.Windows.Forms.Panel();
            this.cmbActiveExchangeLog = new System.Windows.Forms.ComboBox();
            this.lblActiveExchangeLog = new System.Windows.Forms.Label();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReActiveExchange = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerActiveExchange = new System.ComponentModel.BackgroundWorker();
            this.GrpSearch.SuspendLayout();
            this.tbcResult.SuspendLayout();
            this.tpgCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdRoleView)).BeginInit();
            this.pnlRoleView.SuspendLayout();
            this.tpgConsumerItemLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdActiveExchangeLog)).BeginInit();
            this.pnlActiveExchangeLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.txtNick);
            this.GrpSearch.Controls.Add(this.lblNick);
            this.GrpSearch.Controls.Add(this.txtAccount);
            this.GrpSearch.Controls.Add(this.lblAccount);
            this.GrpSearch.Controls.Add(this.DtpEnd);
            this.GrpSearch.Controls.Add(this.LblLink);
            this.GrpSearch.Controls.Add(this.DtpBegin);
            this.GrpSearch.Controls.Add(this.LblDate);
            this.GrpSearch.Controls.Add(this.btnClose);
            this.GrpSearch.Controls.Add(this.btnSearch);
            this.GrpSearch.Controls.Add(this.cmbServer);
            this.GrpSearch.Controls.Add(this.lblServer);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(719, 195);
            this.GrpSearch.TabIndex = 8;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索條件";
            // 
            // txtNick
            // 
            this.txtNick.Location = new System.Drawing.Point(12, 152);
            this.txtNick.Name = "txtNick";
            this.txtNick.Size = new System.Drawing.Size(187, 21);
            this.txtNick.TabIndex = 130;
            // 
            // lblNick
            // 
            this.lblNick.AutoSize = true;
            this.lblNick.Location = new System.Drawing.Point(12, 126);
            this.lblNick.Name = "lblNick";
            this.lblNick.Size = new System.Drawing.Size(65, 12);
            this.lblNick.TabIndex = 129;
            this.lblNick.Text = "玩家昵稱：";
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(12, 87);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(187, 21);
            this.txtAccount.TabIndex = 128;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(12, 72);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(65, 12);
            this.lblAccount.TabIndex = 127;
            this.lblAccount.Text = "玩家帳號：";
            // 
            // DtpEnd
            // 
            this.DtpEnd.CustomFormat = "yyyy-MM-dd";
            this.DtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpEnd.Location = new System.Drawing.Point(227, 87);
            this.DtpEnd.Name = "DtpEnd";
            this.DtpEnd.Size = new System.Drawing.Size(166, 21);
            this.DtpEnd.TabIndex = 126;
            // 
            // LblLink
            // 
            this.LblLink.AutoSize = true;
            this.LblLink.Location = new System.Drawing.Point(231, 72);
            this.LblLink.Name = "LblLink";
            this.LblLink.Size = new System.Drawing.Size(65, 12);
            this.LblLink.TabIndex = 125;
            this.LblLink.Text = "結束時間：";
            // 
            // DtpBegin
            // 
            this.DtpBegin.CustomFormat = "yyyy-MM-dd";
            this.DtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpBegin.Location = new System.Drawing.Point(227, 35);
            this.DtpBegin.Name = "DtpBegin";
            this.DtpBegin.Size = new System.Drawing.Size(168, 21);
            this.DtpBegin.TabIndex = 124;
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Location = new System.Drawing.Point(225, 20);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(65, 12);
            this.LblDate.TabIndex = 123;
            this.LblDate.Text = "開始時間：";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(401, 72);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "關閉";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(401, 36);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbServer
            // 
            this.cmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(14, 36);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(179, 20);
            this.cmbServer.TabIndex = 1;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(12, 20);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(77, 12);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "遊戲伺服器：";
            // 
            // tbcResult
            // 
            this.tbcResult.Controls.Add(this.tpgCharacter);
            this.tbcResult.Controls.Add(this.tpgConsumerItemLog);
            this.tbcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcResult.Location = new System.Drawing.Point(0, 195);
            this.tbcResult.Name = "tbcResult";
            this.tbcResult.SelectedIndex = 0;
            this.tbcResult.Size = new System.Drawing.Size(719, 416);
            this.tbcResult.TabIndex = 64;
            this.tbcResult.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbcResult_Selected);
            // 
            // tpgCharacter
            // 
            this.tpgCharacter.Controls.Add(this.GrdRoleView);
            this.tpgCharacter.Controls.Add(this.pnlRoleView);
            this.tpgCharacter.Location = new System.Drawing.Point(4, 21);
            this.tpgCharacter.Name = "tpgCharacter";
            this.tpgCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.tpgCharacter.Size = new System.Drawing.Size(711, 391);
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
            this.GrdRoleView.Size = new System.Drawing.Size(705, 348);
            this.GrdRoleView.TabIndex = 39;
            this.GrdRoleView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdRoleView_CellDoubleClick);
            // 
            // pnlRoleView
            // 
            this.pnlRoleView.Controls.Add(this.cmbRoleView);
            this.pnlRoleView.Controls.Add(this.lblRoleView);
            this.pnlRoleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRoleView.Location = new System.Drawing.Point(3, 3);
            this.pnlRoleView.Name = "pnlRoleView";
            this.pnlRoleView.Size = new System.Drawing.Size(705, 37);
            this.pnlRoleView.TabIndex = 37;
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
            // tpgConsumerItemLog
            // 
            this.tpgConsumerItemLog.Controls.Add(this.GrdActiveExchangeLog);
            this.tpgConsumerItemLog.Controls.Add(this.pnlActiveExchangeLog);
            this.tpgConsumerItemLog.Location = new System.Drawing.Point(4, 21);
            this.tpgConsumerItemLog.Name = "tpgConsumerItemLog";
            this.tpgConsumerItemLog.Padding = new System.Windows.Forms.Padding(3);
            this.tpgConsumerItemLog.Size = new System.Drawing.Size(711, 391);
            this.tpgConsumerItemLog.TabIndex = 1;
            this.tpgConsumerItemLog.Text = "活躍度獲得記錄";
            this.tpgConsumerItemLog.UseVisualStyleBackColor = true;
            // 
            // GrdActiveExchangeLog
            // 
            this.GrdActiveExchangeLog.AllowUserToAddRows = false;
            this.GrdActiveExchangeLog.AllowUserToDeleteRows = false;
            this.GrdActiveExchangeLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdActiveExchangeLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdActiveExchangeLog.Location = new System.Drawing.Point(3, 40);
            this.GrdActiveExchangeLog.Name = "GrdActiveExchangeLog";
            this.GrdActiveExchangeLog.ReadOnly = true;
            this.GrdActiveExchangeLog.RowTemplate.Height = 23;
            this.GrdActiveExchangeLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdActiveExchangeLog.Size = new System.Drawing.Size(705, 348);
            this.GrdActiveExchangeLog.TabIndex = 39;
            // 
            // pnlActiveExchangeLog
            // 
            this.pnlActiveExchangeLog.Controls.Add(this.cmbActiveExchangeLog);
            this.pnlActiveExchangeLog.Controls.Add(this.lblActiveExchangeLog);
            this.pnlActiveExchangeLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActiveExchangeLog.Location = new System.Drawing.Point(3, 3);
            this.pnlActiveExchangeLog.Name = "pnlActiveExchangeLog";
            this.pnlActiveExchangeLog.Size = new System.Drawing.Size(705, 37);
            this.pnlActiveExchangeLog.TabIndex = 37;
            // 
            // cmbActiveExchangeLog
            // 
            this.cmbActiveExchangeLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActiveExchangeLog.FormattingEnabled = true;
            this.cmbActiveExchangeLog.Location = new System.Drawing.Point(124, 8);
            this.cmbActiveExchangeLog.Name = "cmbActiveExchangeLog";
            this.cmbActiveExchangeLog.Size = new System.Drawing.Size(100, 20);
            this.cmbActiveExchangeLog.TabIndex = 1;
            this.cmbActiveExchangeLog.SelectedIndexChanged += new System.EventHandler(this.cmbActiveExchangeLog_SelectedIndexChanged);
            // 
            // lblActiveExchangeLog
            // 
            this.lblActiveExchangeLog.AutoSize = true;
            this.lblActiveExchangeLog.Location = new System.Drawing.Point(20, 13);
            this.lblActiveExchangeLog.Name = "lblActiveExchangeLog";
            this.lblActiveExchangeLog.Size = new System.Drawing.Size(101, 12);
            this.lblActiveExchangeLog.TabIndex = 0;
            this.lblActiveExchangeLog.Text = "請選擇查看頁數：";
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
            // backgroundWorkerReActiveExchange
            // 
            this.backgroundWorkerReActiveExchange.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReActiveExchange_DoWork);
            this.backgroundWorkerReActiveExchange.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReActiveExchange_RunWorkerCompleted);
            // 
            // backgroundWorkerActiveExchange
            // 
            this.backgroundWorkerActiveExchange.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerActiveExchange_DoWork);
            this.backgroundWorkerActiveExchange.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerActiveExchange_RunWorkerCompleted);
            // 
            // FrmJW2ActivityExchangeLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 611);
            this.Controls.Add(this.tbcResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmJW2ActivityExchangeLog";
            this.Text = "活躍度獲得記錄";
            this.Load += new System.EventHandler(this.FrmJW2ActivityExchangeLog_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.tbcResult.ResumeLayout(false);
            this.tpgCharacter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdRoleView)).EndInit();
            this.pnlRoleView.ResumeLayout(false);
            this.pnlRoleView.PerformLayout();
            this.tpgConsumerItemLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdActiveExchangeLog)).EndInit();
            this.pnlActiveExchangeLog.ResumeLayout(false);
            this.pnlActiveExchangeLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.TextBox txtNick;
        private System.Windows.Forms.Label lblNick;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.DateTimePicker DtpEnd;
        private System.Windows.Forms.Label LblLink;
        private System.Windows.Forms.DateTimePicker DtpBegin;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbServer;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TabControl tbcResult;
        private System.Windows.Forms.TabPage tpgCharacter;
        private System.Windows.Forms.TabPage tpgConsumerItemLog;
        private System.Windows.Forms.DataGridView GrdRoleView;
        private System.Windows.Forms.Panel pnlRoleView;
        private System.Windows.Forms.ComboBox cmbRoleView;
        private System.Windows.Forms.Label lblRoleView;
        private System.Windows.Forms.DataGridView GrdActiveExchangeLog;
        private System.Windows.Forms.Panel pnlActiveExchangeLog;
        private System.Windows.Forms.ComboBox cmbActiveExchangeLog;
        private System.Windows.Forms.Label lblActiveExchangeLog;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReActiveExchange;
        private System.ComponentModel.BackgroundWorker backgroundWorkerActiveExchange;
    }
}