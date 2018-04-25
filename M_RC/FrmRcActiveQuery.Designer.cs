namespace M_RC
{
    partial class FrmRcActiveQuery
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorkerQuery = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TpgState = new System.Windows.Forms.TabPage();
            this.RoleInfoView = new System.Windows.Forms.DataGridView();
            this.backgroundWorkerAccont = new System.ComponentModel.BackgroundWorker();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.LblAccount = new System.Windows.Forms.Label();
            this.TxtAccount = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxBat = new System.Windows.Forms.CheckBox();
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.tabControl1.SuspendLayout();
            this.TpgState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoleInfoView)).BeginInit();
            this.GrpSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorkerQuery
            // 
            this.backgroundWorkerQuery.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerQuery_DoWork);
            this.backgroundWorkerQuery.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerQuery_RunWorkerCompleted);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TpgState);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 103);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(655, 314);
            this.tabControl1.TabIndex = 5;
            // 
            // TpgState
            // 
            this.TpgState.Controls.Add(this.RoleInfoView);
            this.TpgState.Location = new System.Drawing.Point(4, 21);
            this.TpgState.Name = "TpgState";
            this.TpgState.Padding = new System.Windows.Forms.Padding(3);
            this.TpgState.Size = new System.Drawing.Size(647, 289);
            this.TpgState.TabIndex = 0;
            this.TpgState.Text = "查詢結果";
            this.TpgState.UseVisualStyleBackColor = true;
            // 
            // RoleInfoView
            // 
            this.RoleInfoView.AllowUserToAddRows = false;
            this.RoleInfoView.AllowUserToDeleteRows = false;
            this.RoleInfoView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoleInfoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoleInfoView.Location = new System.Drawing.Point(3, 3);
            this.RoleInfoView.Name = "RoleInfoView";
            this.RoleInfoView.ReadOnly = true;
            this.RoleInfoView.RowTemplate.Height = 23;
            this.RoleInfoView.Size = new System.Drawing.Size(641, 283);
            this.RoleInfoView.TabIndex = 9;
            // 
            // backgroundWorkerAccont
            // 
            this.backgroundWorkerAccont.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerAccont_DoWork);
            this.backgroundWorkerAccont.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerAccont_RunWorkerCompleted);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(397, 25);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(86, 23);
            this.BtnSearch.TabIndex = 4;
            this.BtnSearch.Text = "搜索";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // LblAccount
            // 
            this.LblAccount.AutoSize = true;
            this.LblAccount.Location = new System.Drawing.Point(24, 17);
            this.LblAccount.Name = "LblAccount";
            this.LblAccount.Size = new System.Drawing.Size(65, 12);
            this.LblAccount.TabIndex = 5;
            this.LblAccount.Text = "玩家帳號：";
            this.LblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtAccount
            // 
            this.TxtAccount.Location = new System.Drawing.Point(26, 32);
            this.TxtAccount.Name = "TxtAccount";
            this.TxtAccount.Size = new System.Drawing.Size(162, 21);
            this.TxtAccount.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(397, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "關閉";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxBat
            // 
            this.checkBoxBat.AutoSize = true;
            this.checkBoxBat.Location = new System.Drawing.Point(26, 72);
            this.checkBoxBat.Name = "checkBoxBat";
            this.checkBoxBat.Size = new System.Drawing.Size(84, 16);
            this.checkBoxBat.TabIndex = 29;
            this.checkBoxBat.Text = "啟動碼查詢";
            this.checkBoxBat.UseVisualStyleBackColor = true;
            this.checkBoxBat.Visible = false;
            this.checkBoxBat.CheckedChanged += new System.EventHandler(this.checkBoxBat_CheckedChanged);
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.checkBoxBat);
            this.GrpSearch.Controls.Add(this.button1);
            this.GrpSearch.Controls.Add(this.TxtAccount);
            this.GrpSearch.Controls.Add(this.LblAccount);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(655, 103);
            this.GrpSearch.TabIndex = 4;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索條件";
            // 
            // FrmRcActiveQuery
            // 
            this.AcceptButton = this.BtnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 417);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmRcActiveQuery";
            this.Text = "啟動大區查詢";
            this.Load += new System.EventHandler(this.FrmRcCodeQuery_Load);
            this.tabControl1.ResumeLayout(false);
            this.TpgState.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RoleInfoView)).EndInit();
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorkerQuery;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TpgState;
        private System.Windows.Forms.DataGridView RoleInfoView;
        private System.ComponentModel.BackgroundWorker backgroundWorkerAccont;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Label LblAccount;
        private System.Windows.Forms.TextBox TxtAccount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxBat;
        private System.Windows.Forms.GroupBox GrpSearch;
    }
}

