namespace M_JW2
{
    partial class FrmJW2FamilyItemInfo
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
            this.button1 = new System.Windows.Forms.Button();
            this.CmbServer = new System.Windows.Forms.ComboBox();
            this.LblServer = new System.Windows.Forms.Label();
            this.lblAccountOrNick = new System.Windows.Forms.TextBox();
            this.LblAccount = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.GrpResult = new System.Windows.Forms.GroupBox();
            this.TbcResult = new System.Windows.Forms.TabControl();
            this.tpgFamilyInfo = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.pnlRoleView = new System.Windows.Forms.Panel();
            this.cmbRoleView = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tpgFamilyItemInfo = new System.Windows.Forms.TabPage();
            this.FamilyItemGridView = new System.Windows.Forms.DataGridView();
            this.GbPage = new System.Windows.Forms.GroupBox();
            this.CbPage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerFamilyItemInfo = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReFamilyItemInfo = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReSearch = new System.ComponentModel.BackgroundWorker();
            this.GrpSearch.SuspendLayout();
            this.GrpResult.SuspendLayout();
            this.TbcResult.SuspendLayout();
            this.tpgFamilyInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.pnlRoleView.SuspendLayout();
            this.tpgFamilyItemInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FamilyItemGridView)).BeginInit();
            this.GbPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.button1);
            this.GrpSearch.Controls.Add(this.CmbServer);
            this.GrpSearch.Controls.Add(this.LblServer);
            this.GrpSearch.Controls.Add(this.lblAccountOrNick);
            this.GrpSearch.Controls.Add(this.LblAccount);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(634, 99);
            this.GrpSearch.TabIndex = 9;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索條件";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(475, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "關閉";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CmbServer
            // 
            this.CmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbServer.FormattingEnabled = true;
            this.CmbServer.Location = new System.Drawing.Point(8, 35);
            this.CmbServer.Name = "CmbServer";
            this.CmbServer.Size = new System.Drawing.Size(166, 20);
            this.CmbServer.TabIndex = 8;
            // 
            // LblServer
            // 
            this.LblServer.AutoSize = true;
            this.LblServer.Location = new System.Drawing.Point(6, 20);
            this.LblServer.Name = "LblServer";
            this.LblServer.Size = new System.Drawing.Size(77, 12);
            this.LblServer.TabIndex = 7;
            this.LblServer.Text = "遊戲伺服器：";
            // 
            // lblAccountOrNick
            // 
            this.lblAccountOrNick.Location = new System.Drawing.Point(192, 35);
            this.lblAccountOrNick.Name = "lblAccountOrNick";
            this.lblAccountOrNick.Size = new System.Drawing.Size(166, 21);
            this.lblAccountOrNick.TabIndex = 6;
            // 
            // LblAccount
            // 
            this.LblAccount.AutoSize = true;
            this.LblAccount.Location = new System.Drawing.Point(190, 20);
            this.LblAccount.Name = "LblAccount";
            this.LblAccount.Size = new System.Drawing.Size(65, 12);
            this.LblAccount.TabIndex = 5;
            this.LblAccount.Text = "家族名稱：";
            this.LblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(475, 32);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 4;
            this.BtnSearch.Text = "搜索";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // GrpResult
            // 
            this.GrpResult.Controls.Add(this.TbcResult);
            this.GrpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpResult.Location = new System.Drawing.Point(0, 99);
            this.GrpResult.Name = "GrpResult";
            this.GrpResult.Size = new System.Drawing.Size(634, 334);
            this.GrpResult.TabIndex = 10;
            this.GrpResult.TabStop = false;
            this.GrpResult.Text = "搜索結果";
            // 
            // TbcResult
            // 
            this.TbcResult.Controls.Add(this.tpgFamilyInfo);
            this.TbcResult.Controls.Add(this.tpgFamilyItemInfo);
            this.TbcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbcResult.Location = new System.Drawing.Point(3, 17);
            this.TbcResult.Name = "TbcResult";
            this.TbcResult.SelectedIndex = 0;
            this.TbcResult.Size = new System.Drawing.Size(628, 314);
            this.TbcResult.TabIndex = 59;
            this.TbcResult.SelectedIndexChanged += new System.EventHandler(this.TbcResult_SelectedIndexChanged);
            // 
            // tpgFamilyInfo
            // 
            this.tpgFamilyInfo.Controls.Add(this.dataGridView2);
            this.tpgFamilyInfo.Controls.Add(this.pnlRoleView);
            this.tpgFamilyInfo.Location = new System.Drawing.Point(4, 21);
            this.tpgFamilyInfo.Name = "tpgFamilyInfo";
            this.tpgFamilyInfo.Size = new System.Drawing.Size(620, 289);
            this.tpgFamilyInfo.TabIndex = 2;
            this.tpgFamilyInfo.Text = "家族信息";
            this.tpgFamilyInfo.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 37);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(620, 252);
            this.dataGridView2.TabIndex = 24;
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellDoubleClick);
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // pnlRoleView
            // 
            this.pnlRoleView.Controls.Add(this.cmbRoleView);
            this.pnlRoleView.Controls.Add(this.label2);
            this.pnlRoleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRoleView.Location = new System.Drawing.Point(0, 0);
            this.pnlRoleView.Name = "pnlRoleView";
            this.pnlRoleView.Size = new System.Drawing.Size(620, 37);
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
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "請選擇查看頁數：";
            // 
            // tpgFamilyItemInfo
            // 
            this.tpgFamilyItemInfo.Controls.Add(this.FamilyItemGridView);
            this.tpgFamilyItemInfo.Controls.Add(this.GbPage);
            this.tpgFamilyItemInfo.Location = new System.Drawing.Point(4, 21);
            this.tpgFamilyItemInfo.Name = "tpgFamilyItemInfo";
            this.tpgFamilyItemInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpgFamilyItemInfo.Size = new System.Drawing.Size(620, 289);
            this.tpgFamilyItemInfo.TabIndex = 0;
            this.tpgFamilyItemInfo.Text = "家族道具信息";
            this.tpgFamilyItemInfo.UseVisualStyleBackColor = true;
            // 
            // FamilyItemGridView
            // 
            this.FamilyItemGridView.AllowUserToAddRows = false;
            this.FamilyItemGridView.AllowUserToDeleteRows = false;
            this.FamilyItemGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FamilyItemGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FamilyItemGridView.Location = new System.Drawing.Point(3, 55);
            this.FamilyItemGridView.Name = "FamilyItemGridView";
            this.FamilyItemGridView.ReadOnly = true;
            this.FamilyItemGridView.RowTemplate.Height = 23;
            this.FamilyItemGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FamilyItemGridView.Size = new System.Drawing.Size(614, 231);
            this.FamilyItemGridView.TabIndex = 12;
            // 
            // GbPage
            // 
            this.GbPage.Controls.Add(this.CbPage);
            this.GbPage.Controls.Add(this.label1);
            this.GbPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.GbPage.Location = new System.Drawing.Point(3, 3);
            this.GbPage.Name = "GbPage";
            this.GbPage.Size = new System.Drawing.Size(614, 52);
            this.GbPage.TabIndex = 11;
            this.GbPage.TabStop = false;
            this.GbPage.Text = "翻页";
            // 
            // CbPage
            // 
            this.CbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbPage.FormattingEnabled = true;
            this.CbPage.Location = new System.Drawing.Point(130, 14);
            this.CbPage.Name = "CbPage";
            this.CbPage.Size = new System.Drawing.Size(121, 20);
            this.CbPage.TabIndex = 1;
            this.CbPage.SelectedIndexChanged += new System.EventHandler(this.CbPage_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "請輸入查看的頁數:";
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
            // backgroundWorkerFamilyItemInfo
            // 
            this.backgroundWorkerFamilyItemInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFamilyItemInfo_DoWork);
            this.backgroundWorkerFamilyItemInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFamilyItemInfo_RunWorkerCompleted);
            // 
            // backgroundWorkerReFamilyItemInfo
            // 
            this.backgroundWorkerReFamilyItemInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReFamilyItemInfo_DoWork);
            this.backgroundWorkerReFamilyItemInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReFamilyItemInfo_RunWorkerCompleted);
            // 
            // backgroundWorkerReSearch
            // 
            this.backgroundWorkerReSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReSearch_DoWork);
            this.backgroundWorkerReSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReSearch_RunWorkerCompleted);
            // 
            // FrmJW2FamilyItemInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 433);
            this.Controls.Add(this.GrpResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmJW2FamilyItemInfo";
            this.Text = "家族道具信息";
            this.Load += new System.EventHandler(this.FrmJW2FamilyItemInfo_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.GrpResult.ResumeLayout(false);
            this.TbcResult.ResumeLayout(false);
            this.tpgFamilyInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.pnlRoleView.ResumeLayout(false);
            this.pnlRoleView.PerformLayout();
            this.tpgFamilyItemInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FamilyItemGridView)).EndInit();
            this.GbPage.ResumeLayout(false);
            this.GbPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CmbServer;
        private System.Windows.Forms.Label LblServer;
        private System.Windows.Forms.TextBox lblAccountOrNick;
        private System.Windows.Forms.Label LblAccount;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.GroupBox GrpResult;
        private System.Windows.Forms.TabControl TbcResult;
        private System.Windows.Forms.TabPage tpgFamilyInfo;
        private System.Windows.Forms.TabPage tpgFamilyItemInfo;
        private System.Windows.Forms.DataGridView FamilyItemGridView;
        private System.Windows.Forms.GroupBox GbPage;
        private System.Windows.Forms.ComboBox CbPage;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFamilyItemInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReFamilyItemInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReSearch;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel pnlRoleView;
        private System.Windows.Forms.ComboBox cmbRoleView;
        private System.Windows.Forms.Label label2;
    }
}