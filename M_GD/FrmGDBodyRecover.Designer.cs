namespace M_GD
{
    partial class FrmGDBodyRecover
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
            this.label2 = new System.Windows.Forms.Label();
            this.DtpEnd = new System.Windows.Forms.DateTimePicker();
            this.LblLink = new System.Windows.Forms.Label();
            this.DtpBegin = new System.Windows.Forms.DateTimePicker();
            this.LblDate = new System.Windows.Forms.Label();
            this.txtNick = new System.Windows.Forms.TextBox();
            this.lblNick = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.TxtAccount = new System.Windows.Forms.TextBox();
            this.LblAccount = new System.Windows.Forms.Label();
            this.CmbServer = new System.Windows.Forms.ComboBox();
            this.LblServer = new System.Windows.Forms.Label();
            this.TbcResult = new System.Windows.Forms.TabControl();
            this.TpgCharacter = new System.Windows.Forms.TabPage();
            this.GrdCharacter = new System.Windows.Forms.DataGridView();
            this.TpgDistintegrationOfTheBodyLog = new System.Windows.Forms.TabPage();
            this.GrdDistintegrationOfTheBody = new System.Windows.Forms.DataGridView();
            this.pnlDistintegrationOfTheBody = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbDistintegrationOfTheBody = new System.Windows.Forms.ComboBox();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerDistintegrationOfTheBody = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReDistintegrationOfTheBody = new System.ComponentModel.BackgroundWorker();
            this.GrpSearch.SuspendLayout();
            this.TbcResult.SuspendLayout();
            this.TpgCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdCharacter)).BeginInit();
            this.TpgDistintegrationOfTheBodyLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdDistintegrationOfTheBody)).BeginInit();
            this.pnlDistintegrationOfTheBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.label2);
            this.GrpSearch.Controls.Add(this.DtpEnd);
            this.GrpSearch.Controls.Add(this.LblLink);
            this.GrpSearch.Controls.Add(this.DtpBegin);
            this.GrpSearch.Controls.Add(this.LblDate);
            this.GrpSearch.Controls.Add(this.txtNick);
            this.GrpSearch.Controls.Add(this.lblNick);
            this.GrpSearch.Controls.Add(this.BtnClose);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Controls.Add(this.TxtAccount);
            this.GrpSearch.Controls.Add(this.LblAccount);
            this.GrpSearch.Controls.Add(this.CmbServer);
            this.GrpSearch.Controls.Add(this.LblServer);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(867, 157);
            this.GrpSearch.TabIndex = 103;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索條件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(254, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 12);
            this.label2.TabIndex = 115;
            this.label2.Text = "提示:雙擊機體解體記錄對機體進行恢復操作";
            // 
            // DtpEnd
            // 
            this.DtpEnd.CustomFormat = "yyyy-MM-dd";
            this.DtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpEnd.Location = new System.Drawing.Point(222, 80);
            this.DtpEnd.Name = "DtpEnd";
            this.DtpEnd.Size = new System.Drawing.Size(188, 21);
            this.DtpEnd.TabIndex = 114;
            // 
            // LblLink
            // 
            this.LblLink.AutoSize = true;
            this.LblLink.Location = new System.Drawing.Point(231, 65);
            this.LblLink.Name = "LblLink";
            this.LblLink.Size = new System.Drawing.Size(59, 12);
            this.LblLink.TabIndex = 113;
            this.LblLink.Text = "結束時間:";
            // 
            // DtpBegin
            // 
            this.DtpBegin.CustomFormat = "yyyy-MM-dd";
            this.DtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpBegin.Location = new System.Drawing.Point(222, 34);
            this.DtpBegin.Name = "DtpBegin";
            this.DtpBegin.Size = new System.Drawing.Size(188, 21);
            this.DtpBegin.TabIndex = 112;
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Location = new System.Drawing.Point(231, 18);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(59, 12);
            this.LblDate.TabIndex = 111;
            this.LblDate.Text = "開始時間:";
            // 
            // txtNick
            // 
            this.txtNick.Location = new System.Drawing.Point(8, 128);
            this.txtNick.Name = "txtNick";
            this.txtNick.Size = new System.Drawing.Size(187, 21);
            this.txtNick.TabIndex = 110;
            // 
            // lblNick
            // 
            this.lblNick.AutoSize = true;
            this.lblNick.Location = new System.Drawing.Point(10, 113);
            this.lblNick.Name = "lblNick";
            this.lblNick.Size = new System.Drawing.Size(59, 12);
            this.lblNick.TabIndex = 109;
            this.lblNick.Text = "玩家帳號:";
            // 
            // BtnClose
            // 
            this.BtnClose.AutoSize = true;
            this.BtnClose.Location = new System.Drawing.Point(432, 61);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(72, 23);
            this.BtnClose.TabIndex = 107;
            this.BtnClose.Text = "關閉";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.AutoSize = true;
            this.BtnSearch.Location = new System.Drawing.Point(432, 32);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(72, 23);
            this.BtnSearch.TabIndex = 106;
            this.BtnSearch.Text = "搜索";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TxtAccount
            // 
            this.TxtAccount.Location = new System.Drawing.Point(8, 79);
            this.TxtAccount.Name = "TxtAccount";
            this.TxtAccount.Size = new System.Drawing.Size(188, 21);
            this.TxtAccount.TabIndex = 105;
            // 
            // LblAccount
            // 
            this.LblAccount.AutoSize = true;
            this.LblAccount.Location = new System.Drawing.Point(6, 65);
            this.LblAccount.Name = "LblAccount";
            this.LblAccount.Size = new System.Drawing.Size(59, 12);
            this.LblAccount.TabIndex = 104;
            this.LblAccount.Text = "玩家帳號:";
            // 
            // CmbServer
            // 
            this.CmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbServer.FormattingEnabled = true;
            this.CmbServer.Location = new System.Drawing.Point(8, 32);
            this.CmbServer.Name = "CmbServer";
            this.CmbServer.Size = new System.Drawing.Size(188, 20);
            this.CmbServer.TabIndex = 103;
            // 
            // LblServer
            // 
            this.LblServer.AutoSize = true;
            this.LblServer.Location = new System.Drawing.Point(6, 17);
            this.LblServer.Name = "LblServer";
            this.LblServer.Size = new System.Drawing.Size(71, 12);
            this.LblServer.TabIndex = 102;
            this.LblServer.Text = "遊戲伺服器:";
            // 
            // TbcResult
            // 
            this.TbcResult.Controls.Add(this.TpgCharacter);
            this.TbcResult.Controls.Add(this.TpgDistintegrationOfTheBodyLog);
            this.TbcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbcResult.Location = new System.Drawing.Point(0, 157);
            this.TbcResult.Name = "TbcResult";
            this.TbcResult.SelectedIndex = 0;
            this.TbcResult.Size = new System.Drawing.Size(867, 459);
            this.TbcResult.TabIndex = 124;
            this.TbcResult.Selected += new System.Windows.Forms.TabControlEventHandler(this.TbcResult_Selected);
            // 
            // TpgCharacter
            // 
            this.TpgCharacter.Controls.Add(this.GrdCharacter);
            this.TpgCharacter.Location = new System.Drawing.Point(4, 21);
            this.TpgCharacter.Name = "TpgCharacter";
            this.TpgCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.TpgCharacter.Size = new System.Drawing.Size(859, 434);
            this.TpgCharacter.TabIndex = 0;
            this.TpgCharacter.Text = "角色信息";
            this.TpgCharacter.UseVisualStyleBackColor = true;
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
            this.GrdCharacter.Size = new System.Drawing.Size(853, 428);
            this.GrdCharacter.TabIndex = 9;
            this.GrdCharacter.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdCharacter_CellDoubleClick);
            // 
            // TpgDistintegrationOfTheBodyLog
            // 
            this.TpgDistintegrationOfTheBodyLog.Controls.Add(this.GrdDistintegrationOfTheBody);
            this.TpgDistintegrationOfTheBodyLog.Controls.Add(this.pnlDistintegrationOfTheBody);
            this.TpgDistintegrationOfTheBodyLog.Location = new System.Drawing.Point(4, 21);
            this.TpgDistintegrationOfTheBodyLog.Name = "TpgDistintegrationOfTheBodyLog";
            this.TpgDistintegrationOfTheBodyLog.Size = new System.Drawing.Size(859, 434);
            this.TpgDistintegrationOfTheBodyLog.TabIndex = 9;
            this.TpgDistintegrationOfTheBodyLog.Text = "機體解體記錄";
            this.TpgDistintegrationOfTheBodyLog.UseVisualStyleBackColor = true;
            // 
            // GrdDistintegrationOfTheBody
            // 
            this.GrdDistintegrationOfTheBody.AllowUserToAddRows = false;
            this.GrdDistintegrationOfTheBody.AllowUserToDeleteRows = false;
            this.GrdDistintegrationOfTheBody.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdDistintegrationOfTheBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdDistintegrationOfTheBody.Location = new System.Drawing.Point(0, 31);
            this.GrdDistintegrationOfTheBody.Name = "GrdDistintegrationOfTheBody";
            this.GrdDistintegrationOfTheBody.ReadOnly = true;
            this.GrdDistintegrationOfTheBody.RowTemplate.Height = 23;
            this.GrdDistintegrationOfTheBody.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdDistintegrationOfTheBody.Size = new System.Drawing.Size(859, 403);
            this.GrdDistintegrationOfTheBody.TabIndex = 22;
            this.GrdDistintegrationOfTheBody.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdDistintegrationOfTheBody_CellDoubleClick);
            // 
            // pnlDistintegrationOfTheBody
            // 
            this.pnlDistintegrationOfTheBody.Controls.Add(this.label1);
            this.pnlDistintegrationOfTheBody.Controls.Add(this.CmbDistintegrationOfTheBody);
            this.pnlDistintegrationOfTheBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDistintegrationOfTheBody.Location = new System.Drawing.Point(0, 0);
            this.pnlDistintegrationOfTheBody.Name = "pnlDistintegrationOfTheBody";
            this.pnlDistintegrationOfTheBody.Size = new System.Drawing.Size(859, 31);
            this.pnlDistintegrationOfTheBody.TabIndex = 20;
            this.pnlDistintegrationOfTheBody.TabStop = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "恁寁脤艘珜杅ㄩ";
            // 
            // CmbDistintegrationOfTheBody
            // 
            this.CmbDistintegrationOfTheBody.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDistintegrationOfTheBody.FormattingEnabled = true;
            this.CmbDistintegrationOfTheBody.Location = new System.Drawing.Point(112, 7);
            this.CmbDistintegrationOfTheBody.Name = "CmbDistintegrationOfTheBody";
            this.CmbDistintegrationOfTheBody.Size = new System.Drawing.Size(121, 20);
            this.CmbDistintegrationOfTheBody.TabIndex = 0;
            this.CmbDistintegrationOfTheBody.SelectedIndexChanged += new System.EventHandler(this.CmbDistintegrationOfTheBody_SelectedIndexChanged);
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
            // backgroundWorkerDistintegrationOfTheBody
            // 
            this.backgroundWorkerDistintegrationOfTheBody.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDistintegrationOfTheBody_DoWork);
            this.backgroundWorkerDistintegrationOfTheBody.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerDistintegrationOfTheBody_RunWorkerCompleted);
            // 
            // backgroundWorkerReDistintegrationOfTheBody
            // 
            this.backgroundWorkerReDistintegrationOfTheBody.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReDistintegrationOfTheBody_DoWork);
            this.backgroundWorkerReDistintegrationOfTheBody.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReDistintegrationOfTheBody_RunWorkerCompleted);
            // 
            // FrmGDBodyRecover
            // 
            this.ClientSize = new System.Drawing.Size(867, 616);
            this.Controls.Add(this.TbcResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmGDBodyRecover";
            this.Text = "機體恢復資訊查詢";
            this.Load += new System.EventHandler(this.FrmGDPlayerLog_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.TbcResult.ResumeLayout(false);
            this.TpgCharacter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdCharacter)).EndInit();
            this.TpgDistintegrationOfTheBodyLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdDistintegrationOfTheBody)).EndInit();
            this.pnlDistintegrationOfTheBody.ResumeLayout(false);
            this.pnlDistintegrationOfTheBody.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.DateTimePicker DtpEnd;
        private System.Windows.Forms.Label LblLink;
        private System.Windows.Forms.DateTimePicker DtpBegin;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.TextBox txtNick;
        private System.Windows.Forms.Label lblNick;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox TxtAccount;
        private System.Windows.Forms.Label LblAccount;
        private System.Windows.Forms.ComboBox CmbServer;
        private System.Windows.Forms.Label LblServer;
        private System.Windows.Forms.TabControl TbcResult;
        private System.Windows.Forms.TabPage TpgCharacter;
        private System.Windows.Forms.TabPage TpgDistintegrationOfTheBodyLog;
        private System.Windows.Forms.DataGridView GrdCharacter;
        private System.Windows.Forms.Panel pnlDistintegrationOfTheBody;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbDistintegrationOfTheBody;
        private System.Windows.Forms.DataGridView GrdDistintegrationOfTheBody;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDistintegrationOfTheBody;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReDistintegrationOfTheBody;
        private System.Windows.Forms.Label label2;
    }
}