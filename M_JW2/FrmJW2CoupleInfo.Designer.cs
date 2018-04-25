namespace M_JW2
{
    partial class FrmJW2CoupleInfo
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
            this.tpgCoupleInfo = new System.Windows.Forms.TabPage();
            this.GrdCoupleInfo = new System.Windows.Forms.DataGridView();
            this.tpgCoupleLog = new System.Windows.Forms.TabPage();
            this.GrdCoupleLog = new System.Windows.Forms.DataGridView();
            this.pnlCoupleLog = new System.Windows.Forms.Panel();
            this.cmbCoupleLog = new System.Windows.Forms.ComboBox();
            this.lblHomeItemInfo = new System.Windows.Forms.Label();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerCoupleInfo = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReCoupleInfo = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerCoupleLog = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReCoupleLog = new System.ComponentModel.BackgroundWorker();
            this.GrpSearch.SuspendLayout();
            this.tbcResult.SuspendLayout();
            this.tpgCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdRoleView)).BeginInit();
            this.pnlRoleView.SuspendLayout();
            this.tpgCoupleInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdCoupleInfo)).BeginInit();
            this.tpgCoupleLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdCoupleLog)).BeginInit();
            this.pnlCoupleLog.SuspendLayout();
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
            this.GrpSearch.Size = new System.Drawing.Size(669, 140);
            this.GrpSearch.TabIndex = 3;
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
            this.lblNick.Text = "玩家昵称：";
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
            this.cmbServer.SelectedIndexChanged += new System.EventHandler(this.cmbServer_SelectedIndexChanged);
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
            this.tbcResult.Controls.Add(this.tpgCoupleInfo);
            this.tbcResult.Controls.Add(this.tpgCoupleLog);
            this.tbcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcResult.Location = new System.Drawing.Point(0, 140);
            this.tbcResult.Name = "tbcResult";
            this.tbcResult.SelectedIndex = 0;
            this.tbcResult.Size = new System.Drawing.Size(669, 280);
            this.tbcResult.TabIndex = 33;
            this.tbcResult.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbcResult_Selected);
            // 
            // tpgCharacter
            // 
            this.tpgCharacter.Controls.Add(this.GrdRoleView);
            this.tpgCharacter.Controls.Add(this.pnlRoleView);
            this.tpgCharacter.Location = new System.Drawing.Point(4, 21);
            this.tpgCharacter.Name = "tpgCharacter";
            this.tpgCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.tpgCharacter.Size = new System.Drawing.Size(661, 255);
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
            this.GrdRoleView.Size = new System.Drawing.Size(655, 212);
            this.GrdRoleView.TabIndex = 24;
            this.GrdRoleView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoleGridView_CellClick);
            // 
            // pnlRoleView
            // 
            this.pnlRoleView.Controls.Add(this.cmbRoleView);
            this.pnlRoleView.Controls.Add(this.lblRoleView);
            this.pnlRoleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRoleView.Location = new System.Drawing.Point(3, 3);
            this.pnlRoleView.Name = "pnlRoleView";
            this.pnlRoleView.Size = new System.Drawing.Size(655, 37);
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
            // tpgCoupleInfo
            // 
            this.tpgCoupleInfo.Controls.Add(this.GrdCoupleInfo);
            this.tpgCoupleInfo.Location = new System.Drawing.Point(4, 21);
            this.tpgCoupleInfo.Name = "tpgCoupleInfo";
            this.tpgCoupleInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpgCoupleInfo.Size = new System.Drawing.Size(661, 255);
            this.tpgCoupleInfo.TabIndex = 1;
            this.tpgCoupleInfo.Text = "情侶信息";
            this.tpgCoupleInfo.UseVisualStyleBackColor = true;
            // 
            // GrdCoupleInfo
            // 
            this.GrdCoupleInfo.AllowUserToAddRows = false;
            this.GrdCoupleInfo.AllowUserToDeleteRows = false;
            this.GrdCoupleInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdCoupleInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdCoupleInfo.Location = new System.Drawing.Point(3, 3);
            this.GrdCoupleInfo.Name = "GrdCoupleInfo";
            this.GrdCoupleInfo.ReadOnly = true;
            this.GrdCoupleInfo.RowTemplate.Height = 23;
            this.GrdCoupleInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdCoupleInfo.Size = new System.Drawing.Size(655, 249);
            this.GrdCoupleInfo.TabIndex = 24;
            // 
            // tpgCoupleLog
            // 
            this.tpgCoupleLog.Controls.Add(this.GrdCoupleLog);
            this.tpgCoupleLog.Controls.Add(this.pnlCoupleLog);
            this.tpgCoupleLog.Location = new System.Drawing.Point(4, 21);
            this.tpgCoupleLog.Name = "tpgCoupleLog";
            this.tpgCoupleLog.Size = new System.Drawing.Size(661, 255);
            this.tpgCoupleLog.TabIndex = 2;
            this.tpgCoupleLog.Text = "情侶日誌";
            this.tpgCoupleLog.UseVisualStyleBackColor = true;
            // 
            // GrdCoupleLog
            // 
            this.GrdCoupleLog.AllowUserToAddRows = false;
            this.GrdCoupleLog.AllowUserToDeleteRows = false;
            this.GrdCoupleLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdCoupleLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdCoupleLog.Location = new System.Drawing.Point(0, 37);
            this.GrdCoupleLog.Name = "GrdCoupleLog";
            this.GrdCoupleLog.ReadOnly = true;
            this.GrdCoupleLog.RowTemplate.Height = 23;
            this.GrdCoupleLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdCoupleLog.Size = new System.Drawing.Size(661, 218);
            this.GrdCoupleLog.TabIndex = 23;
            // 
            // pnlCoupleLog
            // 
            this.pnlCoupleLog.Controls.Add(this.cmbCoupleLog);
            this.pnlCoupleLog.Controls.Add(this.lblHomeItemInfo);
            this.pnlCoupleLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCoupleLog.Location = new System.Drawing.Point(0, 0);
            this.pnlCoupleLog.Name = "pnlCoupleLog";
            this.pnlCoupleLog.Size = new System.Drawing.Size(661, 37);
            this.pnlCoupleLog.TabIndex = 21;
            // 
            // cmbCoupleLog
            // 
            this.cmbCoupleLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCoupleLog.FormattingEnabled = true;
            this.cmbCoupleLog.Location = new System.Drawing.Point(124, 8);
            this.cmbCoupleLog.Name = "cmbCoupleLog";
            this.cmbCoupleLog.Size = new System.Drawing.Size(100, 20);
            this.cmbCoupleLog.TabIndex = 1;
            this.cmbCoupleLog.SelectedIndexChanged += new System.EventHandler(this.cmbCoupleLog_SelectedIndexChanged);
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
            // backgroundWorkerCoupleInfo
            // 
            this.backgroundWorkerCoupleInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCoupleInfo_DoWork);
            this.backgroundWorkerCoupleInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCoupleInfo_RunWorkerCompleted);
            // 
            // backgroundWorkerReCoupleInfo
            // 
            this.backgroundWorkerReCoupleInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReCoupleInfo_DoWork);
            this.backgroundWorkerReCoupleInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReCoupleInfo_RunWorkerCompleted);
            // 
            // backgroundWorkerCoupleLog
            // 
            this.backgroundWorkerCoupleLog.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCoupleLog_DoWork);
            this.backgroundWorkerCoupleLog.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCoupleLog_RunWorkerCompleted);
            // 
            // backgroundWorkerReCoupleLog
            // 
            this.backgroundWorkerReCoupleLog.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReCoupleLog_DoWork);
            this.backgroundWorkerReCoupleLog.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReCoupleLog_RunWorkerCompleted);
            // 
            // FrmJW2CoupleInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 420);
            this.Controls.Add(this.tbcResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmJW2CoupleInfo";
            this.Text = "情侶信息";
            this.Load += new System.EventHandler(this.FrmJW2CoupleInfo_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.tbcResult.ResumeLayout(false);
            this.tpgCharacter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdRoleView)).EndInit();
            this.pnlRoleView.ResumeLayout(false);
            this.pnlRoleView.PerformLayout();
            this.tpgCoupleInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdCoupleInfo)).EndInit();
            this.tpgCoupleLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdCoupleLog)).EndInit();
            this.pnlCoupleLog.ResumeLayout(false);
            this.pnlCoupleLog.PerformLayout();
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
        private System.Windows.Forms.TabPage tpgCoupleInfo;
        private System.Windows.Forms.TabPage tpgCoupleLog;
        private System.Windows.Forms.DataGridView GrdCoupleInfo;
        private System.Windows.Forms.DataGridView GrdCoupleLog;
        private System.Windows.Forms.Panel pnlCoupleLog;
        private System.Windows.Forms.ComboBox cmbCoupleLog;
        private System.Windows.Forms.Label lblHomeItemInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCoupleInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReCoupleInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCoupleLog;
        private System.Windows.Forms.DataGridView GrdRoleView;
        private System.Windows.Forms.Panel pnlRoleView;
        private System.Windows.Forms.ComboBox cmbRoleView;
        private System.Windows.Forms.Label lblRoleView;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReCoupleLog;
    }
}