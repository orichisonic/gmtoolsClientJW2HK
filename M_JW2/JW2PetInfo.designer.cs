namespace M_JW2
{
    partial class JW2PetInfo
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtNick = new System.Windows.Forms.TextBox();
            this.lblNick = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.tpgCharacter = new System.Windows.Forms.TabPage();
            this.GrdRoleView = new System.Windows.Forms.DataGridView();
            this.pnlRoleView = new System.Windows.Forms.Panel();
            this.cmbRoleView = new System.Windows.Forms.ComboBox();
            this.lblRoleView = new System.Windows.Forms.Label();
            this.tbcResult = new System.Windows.Forms.TabControl();
            this.tpgPetName = new System.Windows.Forms.TabPage();
            this.GrdPet = new System.Windows.Forms.DataGridView();
            this.pnlPet = new System.Windows.Forms.Panel();
            this.cmbPet = new System.Windows.Forms.ComboBox();
            this.lblStoryState = new System.Windows.Forms.Label();
            this.tpgModiPetName = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReMessage = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerMessage = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerModiPetName = new System.ComponentModel.BackgroundWorker();
            this.GrpSearch.SuspendLayout();
            this.tpgCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdRoleView)).BeginInit();
            this.pnlRoleView.SuspendLayout();
            this.tbcResult.SuspendLayout();
            this.tpgPetName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdPet)).BeginInit();
            this.pnlPet.SuspendLayout();
            this.tpgModiPetName.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.label3);
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
            this.GrpSearch.Size = new System.Drawing.Size(825, 133);
            this.GrpSearch.TabIndex = 4;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索條件";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(417, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 12);
            this.label3.TabIndex = 32;
            this.label3.Text = "提示：雙擊寵物資訊進行寵物名稱修改";
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
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            // tpgCharacter
            // 
            this.tpgCharacter.Controls.Add(this.GrdRoleView);
            this.tpgCharacter.Controls.Add(this.pnlRoleView);
            this.tpgCharacter.Location = new System.Drawing.Point(4, 21);
            this.tpgCharacter.Name = "tpgCharacter";
            this.tpgCharacter.Size = new System.Drawing.Size(817, 384);
            this.tpgCharacter.TabIndex = 7;
            this.tpgCharacter.Text = "用戶資料資訊";
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
            this.GrdRoleView.Size = new System.Drawing.Size(817, 347);
            this.GrdRoleView.TabIndex = 18;
            this.GrdRoleView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdRoleView_CellDoubleClick);
            // 
            // pnlRoleView
            // 
            this.pnlRoleView.Controls.Add(this.cmbRoleView);
            this.pnlRoleView.Controls.Add(this.lblRoleView);
            this.pnlRoleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRoleView.Location = new System.Drawing.Point(0, 0);
            this.pnlRoleView.Name = "pnlRoleView";
            this.pnlRoleView.Size = new System.Drawing.Size(817, 37);
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
            this.lblRoleView.Size = new System.Drawing.Size(101, 12);
            this.lblRoleView.TabIndex = 0;
            this.lblRoleView.Text = "請選擇查看頁數：";
            // 
            // tbcResult
            // 
            this.tbcResult.Controls.Add(this.tpgCharacter);
            this.tbcResult.Controls.Add(this.tpgPetName);
            this.tbcResult.Controls.Add(this.tpgModiPetName);
            this.tbcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcResult.Location = new System.Drawing.Point(0, 133);
            this.tbcResult.Name = "tbcResult";
            this.tbcResult.SelectedIndex = 0;
            this.tbcResult.Size = new System.Drawing.Size(825, 409);
            this.tbcResult.TabIndex = 20;
            this.tbcResult.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbcResult_Selected);
            // 
            // tpgPetName
            // 
            this.tpgPetName.Controls.Add(this.GrdPet);
            this.tpgPetName.Controls.Add(this.pnlPet);
            this.tpgPetName.Location = new System.Drawing.Point(4, 21);
            this.tpgPetName.Name = "tpgPetName";
            this.tpgPetName.Size = new System.Drawing.Size(817, 384);
            this.tpgPetName.TabIndex = 9;
            this.tpgPetName.Text = "寵物信息";
            this.tpgPetName.UseVisualStyleBackColor = true;
            // 
            // GrdPet
            // 
            this.GrdPet.AllowUserToAddRows = false;
            this.GrdPet.AllowUserToDeleteRows = false;
            this.GrdPet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdPet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdPet.Location = new System.Drawing.Point(0, 37);
            this.GrdPet.Name = "GrdPet";
            this.GrdPet.ReadOnly = true;
            this.GrdPet.RowTemplate.Height = 23;
            this.GrdPet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdPet.Size = new System.Drawing.Size(817, 347);
            this.GrdPet.TabIndex = 18;
            this.GrdPet.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdPet_CellDoubleClick);
            // 
            // pnlPet
            // 
            this.pnlPet.Controls.Add(this.cmbPet);
            this.pnlPet.Controls.Add(this.lblStoryState);
            this.pnlPet.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPet.Location = new System.Drawing.Point(0, 0);
            this.pnlPet.Name = "pnlPet";
            this.pnlPet.Size = new System.Drawing.Size(817, 37);
            this.pnlPet.TabIndex = 16;
            // 
            // cmbPet
            // 
            this.cmbPet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPet.FormattingEnabled = true;
            this.cmbPet.Location = new System.Drawing.Point(124, 8);
            this.cmbPet.Name = "cmbPet";
            this.cmbPet.Size = new System.Drawing.Size(100, 20);
            this.cmbPet.TabIndex = 1;
            // 
            // lblStoryState
            // 
            this.lblStoryState.AutoSize = true;
            this.lblStoryState.Location = new System.Drawing.Point(20, 13);
            this.lblStoryState.Name = "lblStoryState";
            this.lblStoryState.Size = new System.Drawing.Size(101, 12);
            this.lblStoryState.TabIndex = 0;
            this.lblStoryState.Text = "請選擇查看頁數：";
            // 
            // tpgModiPetName
            // 
            this.tpgModiPetName.Controls.Add(this.button2);
            this.tpgModiPetName.Controls.Add(this.button1);
            this.tpgModiPetName.Controls.Add(this.textBox2);
            this.tpgModiPetName.Controls.Add(this.label2);
            this.tpgModiPetName.Controls.Add(this.textBox1);
            this.tpgModiPetName.Controls.Add(this.label1);
            this.tpgModiPetName.Location = new System.Drawing.Point(4, 21);
            this.tpgModiPetName.Name = "tpgModiPetName";
            this.tpgModiPetName.Size = new System.Drawing.Size(817, 384);
            this.tpgModiPetName.TabIndex = 8;
            this.tpgModiPetName.Text = "寵物名稱修改";
            this.tpgModiPetName.UseVisualStyleBackColor = true;
            this.tpgModiPetName.Click += new System.EventHandler(this.tpgModiPetName_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(460, 198);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "重置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "確定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(382, 104);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "寵物現名稱：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(382, 54);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(283, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "寵物名稱：";
            // 
            // backgroundWorkerFormLoad
            // 
            this.backgroundWorkerFormLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFormLoad_DoWork);
            this.backgroundWorkerFormLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFormLoad_RunWorkerCompleted);
            // 
            // backgroundWorkerReMessage
            // 
            this.backgroundWorkerReMessage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReMessage_DoWork);
            this.backgroundWorkerReMessage.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReMessage_RunWorkerCompleted);
            // 
            // backgroundWorkerMessage
            // 
            this.backgroundWorkerMessage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerMessage_DoWork);
            this.backgroundWorkerMessage.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerMessage_RunWorkerCompleted);
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
            // backgroundWorkerModiPetName
            // 
            this.backgroundWorkerModiPetName.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerModiPetName_DoWork);
            this.backgroundWorkerModiPetName.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerModiPetName_RunWorkerCompleted);
            // 
            // JW2PetInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 542);
            this.Controls.Add(this.tbcResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "JW2PetInfo";
            this.Text = "寵物信息";
            this.Load += new System.EventHandler(this.JW2PetInfo_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.tpgCharacter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdRoleView)).EndInit();
            this.pnlRoleView.ResumeLayout(false);
            this.pnlRoleView.PerformLayout();
            this.tbcResult.ResumeLayout(false);
            this.tpgPetName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdPet)).EndInit();
            this.pnlPet.ResumeLayout(false);
            this.pnlPet.PerformLayout();
            this.tpgModiPetName.ResumeLayout(false);
            this.tpgModiPetName.PerformLayout();
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
        private System.Windows.Forms.TabPage tpgCharacter;
        private System.Windows.Forms.TabControl tbcResult;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReMessage;
        private System.ComponentModel.BackgroundWorker backgroundWorkerMessage;
        private System.Windows.Forms.DataGridView GrdRoleView;
        private System.Windows.Forms.Panel pnlRoleView;
        private System.Windows.Forms.ComboBox cmbRoleView;
        private System.Windows.Forms.Label lblRoleView;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReSearch;
        private System.Windows.Forms.TabPage tpgModiPetName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorkerModiPetName;
        private System.Windows.Forms.TabPage tpgPetName;
        private System.Windows.Forms.DataGridView GrdPet;
        private System.Windows.Forms.Panel pnlPet;
        private System.Windows.Forms.ComboBox cmbPet;
        private System.Windows.Forms.Label lblStoryState;
    }
}