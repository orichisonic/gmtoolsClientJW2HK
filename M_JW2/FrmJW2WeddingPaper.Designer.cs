namespace M_JW2
{
    partial class FrmJW2WeddingPaper
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
            this.tpgWeddingPaper = new System.Windows.Forms.TabPage();
            this.GrdWeddingPaper = new System.Windows.Forms.DataGridView();
            this.pnlWeddingPaper = new System.Windows.Forms.Panel();
            this.cmbWeddingPaper = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerWeddingPaper = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReWeddingPaper = new System.ComponentModel.BackgroundWorker();
            this.GrpSearch.SuspendLayout();
            this.tbcResult.SuspendLayout();
            this.tpgCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdRoleView)).BeginInit();
            this.pnlRoleView.SuspendLayout();
            this.tpgWeddingPaper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdWeddingPaper)).BeginInit();
            this.pnlWeddingPaper.SuspendLayout();
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
            this.GrpSearch.Size = new System.Drawing.Size(676, 140);
            this.GrpSearch.TabIndex = 5;
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
            this.tbcResult.Controls.Add(this.tpgWeddingPaper);
            this.tbcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcResult.Location = new System.Drawing.Point(0, 140);
            this.tbcResult.Name = "tbcResult";
            this.tbcResult.SelectedIndex = 0;
            this.tbcResult.Size = new System.Drawing.Size(676, 284);
            this.tbcResult.TabIndex = 45;
            this.tbcResult.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbcResult_Selected);
            // 
            // tpgCharacter
            // 
            this.tpgCharacter.Controls.Add(this.GrdRoleView);
            this.tpgCharacter.Controls.Add(this.pnlRoleView);
            this.tpgCharacter.Location = new System.Drawing.Point(4, 21);
            this.tpgCharacter.Name = "tpgCharacter";
            this.tpgCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.tpgCharacter.Size = new System.Drawing.Size(668, 259);
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
            this.GrdRoleView.Size = new System.Drawing.Size(662, 216);
            this.GrdRoleView.TabIndex = 30;
            this.GrdRoleView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdRoleView_CellClick);
            // 
            // pnlRoleView
            // 
            this.pnlRoleView.Controls.Add(this.cmbRoleView);
            this.pnlRoleView.Controls.Add(this.lblRoleView);
            this.pnlRoleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRoleView.Location = new System.Drawing.Point(3, 3);
            this.pnlRoleView.Name = "pnlRoleView";
            this.pnlRoleView.Size = new System.Drawing.Size(662, 37);
            this.pnlRoleView.TabIndex = 28;
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
            // tpgWeddingPaper
            // 
            this.tpgWeddingPaper.Controls.Add(this.GrdWeddingPaper);
            this.tpgWeddingPaper.Controls.Add(this.pnlWeddingPaper);
            this.tpgWeddingPaper.Location = new System.Drawing.Point(4, 21);
            this.tpgWeddingPaper.Name = "tpgWeddingPaper";
            this.tpgWeddingPaper.Padding = new System.Windows.Forms.Padding(3);
            this.tpgWeddingPaper.Size = new System.Drawing.Size(668, 259);
            this.tpgWeddingPaper.TabIndex = 1;
            this.tpgWeddingPaper.Text = "結婚證書資訊";
            this.tpgWeddingPaper.UseVisualStyleBackColor = true;
            // 
            // GrdWeddingPaper
            // 
            this.GrdWeddingPaper.AllowUserToAddRows = false;
            this.GrdWeddingPaper.AllowUserToDeleteRows = false;
            this.GrdWeddingPaper.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdWeddingPaper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdWeddingPaper.Location = new System.Drawing.Point(3, 40);
            this.GrdWeddingPaper.Name = "GrdWeddingPaper";
            this.GrdWeddingPaper.ReadOnly = true;
            this.GrdWeddingPaper.RowTemplate.Height = 23;
            this.GrdWeddingPaper.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdWeddingPaper.Size = new System.Drawing.Size(662, 216);
            this.GrdWeddingPaper.TabIndex = 30;
            // 
            // pnlWeddingPaper
            // 
            this.pnlWeddingPaper.Controls.Add(this.cmbWeddingPaper);
            this.pnlWeddingPaper.Controls.Add(this.label1);
            this.pnlWeddingPaper.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlWeddingPaper.Location = new System.Drawing.Point(3, 3);
            this.pnlWeddingPaper.Name = "pnlWeddingPaper";
            this.pnlWeddingPaper.Size = new System.Drawing.Size(662, 37);
            this.pnlWeddingPaper.TabIndex = 28;
            // 
            // cmbWeddingPaper
            // 
            this.cmbWeddingPaper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWeddingPaper.FormattingEnabled = true;
            this.cmbWeddingPaper.Location = new System.Drawing.Point(124, 8);
            this.cmbWeddingPaper.Name = "cmbWeddingPaper";
            this.cmbWeddingPaper.Size = new System.Drawing.Size(100, 20);
            this.cmbWeddingPaper.TabIndex = 1;
            this.cmbWeddingPaper.SelectedIndexChanged += new System.EventHandler(this.cmbWeddingPaper_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "請選擇查看頁數：";
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
            // backgroundWorkerWeddingPaper
            // 
            this.backgroundWorkerWeddingPaper.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerWeddingPaper_DoWork);
            this.backgroundWorkerWeddingPaper.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerWeddingPaper_RunWorkerCompleted);
            // 
            // backgroundWorkerReWeddingPaper
            // 
            this.backgroundWorkerReWeddingPaper.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReWeddingPaper_DoWork);
            this.backgroundWorkerReWeddingPaper.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReWeddingPaper_RunWorkerCompleted);
            // 
            // FrmJW2WeddingPaper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 424);
            this.Controls.Add(this.tbcResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmJW2WeddingPaper";
            this.Text = "結婚證書資訊";
            this.Load += new System.EventHandler(this.FrmJW2WeddingPaper_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.tbcResult.ResumeLayout(false);
            this.tpgCharacter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdRoleView)).EndInit();
            this.pnlRoleView.ResumeLayout(false);
            this.pnlRoleView.PerformLayout();
            this.tpgWeddingPaper.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdWeddingPaper)).EndInit();
            this.pnlWeddingPaper.ResumeLayout(false);
            this.pnlWeddingPaper.PerformLayout();
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
        private System.Windows.Forms.TabPage tpgWeddingPaper;
        private System.Windows.Forms.Panel pnlRoleView;
        private System.Windows.Forms.ComboBox cmbRoleView;
        private System.Windows.Forms.Label lblRoleView;
        private System.Windows.Forms.DataGridView GrdWeddingPaper;
        private System.Windows.Forms.Panel pnlWeddingPaper;
        private System.Windows.Forms.ComboBox cmbWeddingPaper;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerWeddingPaper;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReWeddingPaper;
        private System.Windows.Forms.DataGridView GrdRoleView;
    }
}