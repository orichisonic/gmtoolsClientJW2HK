namespace M_JW2
{
    partial class FrmJW2FamilyInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CmbServer = new System.Windows.Forms.ComboBox();
            this.LblServer = new System.Windows.Forms.Label();
            this.lblAccountOrNick = new System.Windows.Forms.TextBox();
            this.LblAccount = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.RoleInfoView = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.GrpResult = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpgFamilyInfo = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.pnlRoleView = new System.Windows.Forms.Panel();
            this.cmbRoleView = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tpgFamilyPet = new System.Windows.Forms.TabPage();
            this.GrdFamilyPetInfo = new System.Windows.Forms.DataGridView();
            this.pnlFamilyPetInfo = new System.Windows.Forms.Panel();
            this.cmbFamilyPetInfo = new System.Windows.Forms.ComboBox();
            this.lblFamilyPetInfo = new System.Windows.Forms.Label();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerFamilyMember = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReFamilyMember = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerBaseInfo = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReBaseInfo = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerBaseOrder = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReBaseOrder = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerApplicationMember = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReApplicationMember = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerModiFamilyName = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerFamilyPetInfo = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReFamilyPetInfo = new System.ComponentModel.BackgroundWorker();
            this.GrpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoleInfoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.GrpResult.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpgFamilyInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.pnlRoleView.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tpgFamilyPet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdFamilyPetInfo)).BeginInit();
            this.pnlFamilyPetInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.label3);
            this.GrpSearch.Controls.Add(this.button1);
            this.GrpSearch.Controls.Add(this.CmbServer);
            this.GrpSearch.Controls.Add(this.LblServer);
            this.GrpSearch.Controls.Add(this.lblAccountOrNick);
            this.GrpSearch.Controls.Add(this.LblAccount);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(735, 99);
            this.GrpSearch.TabIndex = 11;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索條件";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(22, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(257, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "提示：要顯示家族成員資訊請雙擊某條家族資訊";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(380, 65);
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
            this.CmbServer.SelectedIndexChanged += new System.EventHandler(this.CmbServer_SelectedIndexChanged);
            // 
            // LblServer
            // 
            this.LblServer.AutoSize = true;
            this.LblServer.Location = new System.Drawing.Point(6, 20);
            this.LblServer.Name = "LblServer";
            this.LblServer.Size = new System.Drawing.Size(71, 12);
            this.LblServer.TabIndex = 7;
            this.LblServer.Text = "遊戲伺服器:";
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
            this.BtnSearch.Location = new System.Drawing.Point(380, 32);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 4;
            this.BtnSearch.Text = "搜索";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // RoleInfoView
            // 
            this.RoleInfoView.AllowUserToAddRows = false;
            this.RoleInfoView.AllowUserToDeleteRows = false;
            this.RoleInfoView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.RoleInfoView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoleInfoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoleInfoView.Location = new System.Drawing.Point(3, 3);
            this.RoleInfoView.Name = "RoleInfoView";
            this.RoleInfoView.ReadOnly = true;
            this.RoleInfoView.RowTemplate.Height = 23;
            this.RoleInfoView.Size = new System.Drawing.Size(566, 346);
            this.RoleInfoView.TabIndex = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(566, 346);
            this.dataGridView1.TabIndex = 11;
            // 
            // GrpResult
            // 
            this.GrpResult.Controls.Add(this.tabControl1);
            this.GrpResult.Controls.Add(this.dataGridView4);
            this.GrpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpResult.Location = new System.Drawing.Point(0, 99);
            this.GrpResult.Name = "GrpResult";
            this.GrpResult.Size = new System.Drawing.Size(735, 312);
            this.GrpResult.TabIndex = 12;
            this.GrpResult.TabStop = false;
            this.GrpResult.Text = "搜索結果";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpgFamilyInfo);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tpgFamilyPet);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 17);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(729, 292);
            this.tabControl1.TabIndex = 14;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tpgFamilyInfo
            // 
            this.tpgFamilyInfo.Controls.Add(this.dataGridView2);
            this.tpgFamilyInfo.Controls.Add(this.pnlRoleView);
            this.tpgFamilyInfo.Location = new System.Drawing.Point(4, 21);
            this.tpgFamilyInfo.Name = "tpgFamilyInfo";
            this.tpgFamilyInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpgFamilyInfo.Size = new System.Drawing.Size(721, 267);
            this.tpgFamilyInfo.TabIndex = 0;
            this.tpgFamilyInfo.Text = "家族信息";
            this.tpgFamilyInfo.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 40);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(715, 224);
            this.dataGridView2.TabIndex = 21;
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellDoubleClick);
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // pnlRoleView
            // 
            this.pnlRoleView.Controls.Add(this.cmbRoleView);
            this.pnlRoleView.Controls.Add(this.label1);
            this.pnlRoleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRoleView.Location = new System.Drawing.Point(3, 3);
            this.pnlRoleView.Name = "pnlRoleView";
            this.pnlRoleView.Size = new System.Drawing.Size(715, 37);
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
            this.cmbRoleView.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
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
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(721, 267);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "家族名稱修改";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(429, 194);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "重置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(217, 194);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "確定";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(351, 100);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(254, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "家族現名稱：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(351, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(252, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "家族名稱：";
            // 
            // tpgFamilyPet
            // 
            this.tpgFamilyPet.Controls.Add(this.GrdFamilyPetInfo);
            this.tpgFamilyPet.Controls.Add(this.pnlFamilyPetInfo);
            this.tpgFamilyPet.Location = new System.Drawing.Point(4, 21);
            this.tpgFamilyPet.Name = "tpgFamilyPet";
            this.tpgFamilyPet.Size = new System.Drawing.Size(721, 267);
            this.tpgFamilyPet.TabIndex = 6;
            this.tpgFamilyPet.Text = "家族寵物信息";
            this.tpgFamilyPet.UseVisualStyleBackColor = true;
            // 
            // GrdFamilyPetInfo
            // 
            this.GrdFamilyPetInfo.AllowUserToAddRows = false;
            this.GrdFamilyPetInfo.AllowUserToDeleteRows = false;
            this.GrdFamilyPetInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdFamilyPetInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdFamilyPetInfo.Location = new System.Drawing.Point(0, 37);
            this.GrdFamilyPetInfo.Name = "GrdFamilyPetInfo";
            this.GrdFamilyPetInfo.ReadOnly = true;
            this.GrdFamilyPetInfo.RowTemplate.Height = 23;
            this.GrdFamilyPetInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdFamilyPetInfo.Size = new System.Drawing.Size(721, 230);
            this.GrdFamilyPetInfo.TabIndex = 36;
            // 
            // pnlFamilyPetInfo
            // 
            this.pnlFamilyPetInfo.Controls.Add(this.cmbFamilyPetInfo);
            this.pnlFamilyPetInfo.Controls.Add(this.lblFamilyPetInfo);
            this.pnlFamilyPetInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFamilyPetInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlFamilyPetInfo.Name = "pnlFamilyPetInfo";
            this.pnlFamilyPetInfo.Size = new System.Drawing.Size(721, 37);
            this.pnlFamilyPetInfo.TabIndex = 34;
            // 
            // cmbFamilyPetInfo
            // 
            this.cmbFamilyPetInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFamilyPetInfo.FormattingEnabled = true;
            this.cmbFamilyPetInfo.Location = new System.Drawing.Point(124, 8);
            this.cmbFamilyPetInfo.Name = "cmbFamilyPetInfo";
            this.cmbFamilyPetInfo.Size = new System.Drawing.Size(100, 20);
            this.cmbFamilyPetInfo.TabIndex = 1;
            this.cmbFamilyPetInfo.SelectedIndexChanged += new System.EventHandler(this.cmbFamilyPetInfo_SelectedIndexChanged);
            // 
            // lblFamilyPetInfo
            // 
            this.lblFamilyPetInfo.AutoSize = true;
            this.lblFamilyPetInfo.Location = new System.Drawing.Point(20, 13);
            this.lblFamilyPetInfo.Name = "lblFamilyPetInfo";
            this.lblFamilyPetInfo.Size = new System.Drawing.Size(101, 12);
            this.lblFamilyPetInfo.TabIndex = 0;
            this.lblFamilyPetInfo.Text = "請選擇查看頁數：";
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView4.Location = new System.Drawing.Point(3, 17);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.ReadOnly = true;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView4.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView4.RowTemplate.Height = 23;
            this.dataGridView4.Size = new System.Drawing.Size(729, 292);
            this.dataGridView4.TabIndex = 13;
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
            // backgroundWorkerFamilyMember
            // 
            this.backgroundWorkerFamilyMember.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFamilyMember_DoWork);
            this.backgroundWorkerFamilyMember.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFamilyMember_RunWorkerCompleted);
            // 
            // backgroundWorkerReSearch
            // 
            this.backgroundWorkerReSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReSearch_DoWork);
            this.backgroundWorkerReSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReSearch_RunWorkerCompleted);
            // 
            // backgroundWorkerReFamilyMember
            // 
            this.backgroundWorkerReFamilyMember.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReFamilyMember_DoWork);
            this.backgroundWorkerReFamilyMember.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReFamilyMember_RunWorkerCompleted);
            // 
            // backgroundWorkerBaseInfo
            // 
            this.backgroundWorkerBaseInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerBaseInfo_DoWork);
            this.backgroundWorkerBaseInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerBaseInfo_RunWorkerCompleted);
            // 
            // backgroundWorkerReBaseInfo
            // 
            this.backgroundWorkerReBaseInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReBaseInfo_DoWork);
            this.backgroundWorkerReBaseInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReBaseInfo_RunWorkerCompleted);
            // 
            // backgroundWorkerBaseOrder
            // 
            this.backgroundWorkerBaseOrder.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerBaseOrder_DoWork);
            this.backgroundWorkerBaseOrder.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerBaseOrder_RunWorkerCompleted);
            // 
            // backgroundWorkerReBaseOrder
            // 
            this.backgroundWorkerReBaseOrder.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReBaseOrder_DoWork);
            this.backgroundWorkerReBaseOrder.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReBaseOrder_RunWorkerCompleted);
            // 
            // backgroundWorkerApplicationMember
            // 
            this.backgroundWorkerApplicationMember.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerApplicationMember_DoWork);
            this.backgroundWorkerApplicationMember.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerApplicationMember_RunWorkerCompleted);
            // 
            // backgroundWorkerReApplicationMember
            // 
            this.backgroundWorkerReApplicationMember.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReApplicationMember_DoWork);
            this.backgroundWorkerReApplicationMember.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReApplicationMember_RunWorkerCompleted);
            // 
            // backgroundWorkerModiFamilyName
            // 
            this.backgroundWorkerModiFamilyName.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerModiFamilyName_DoWork);
            this.backgroundWorkerModiFamilyName.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerModiFamilyName_RunWorkerCompleted);
            // 
            // backgroundWorkerFamilyPetInfo
            // 
            this.backgroundWorkerFamilyPetInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFamilyPetInfo_DoWork);
            this.backgroundWorkerFamilyPetInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFamilyPetInfo_RunWorkerCompleted);
            // 
            // backgroundWorkerReFamilyPetInfo
            // 
            this.backgroundWorkerReFamilyPetInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReFamilyPetInfo_DoWork);
            this.backgroundWorkerReFamilyPetInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReFamilyPetInfo_RunWorkerCompleted);
            // 
            // FrmJW2FamilyInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 411);
            this.Controls.Add(this.GrpResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmJW2FamilyInfo";
            this.Text = "家族信息";
            this.Load += new System.EventHandler(this.FrmJW2FamilyInfo_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoleInfoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.GrpResult.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpgFamilyInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.pnlRoleView.ResumeLayout(false);
            this.pnlRoleView.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tpgFamilyPet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdFamilyPetInfo)).EndInit();
            this.pnlFamilyPetInfo.ResumeLayout(false);
            this.pnlFamilyPetInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CmbServer;
        private System.Windows.Forms.Label LblServer;
        private System.Windows.Forms.TextBox lblAccountOrNick;
        private System.Windows.Forms.Label LblAccount;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.DataGridView RoleInfoView;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox GrpResult;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpgFamilyInfo;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFamilyMember;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel pnlRoleView;
        private System.Windows.Forms.ComboBox cmbRoleView;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReFamilyMember;
        private System.ComponentModel.BackgroundWorker backgroundWorkerBaseInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReBaseInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerBaseOrder;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReBaseOrder;
        private System.ComponentModel.BackgroundWorker backgroundWorkerApplicationMember;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReApplicationMember;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.ComponentModel.BackgroundWorker backgroundWorkerModiFamilyName;
        private System.Windows.Forms.TabPage tpgFamilyPet;
        private System.Windows.Forms.DataGridView GrdFamilyPetInfo;
        private System.Windows.Forms.Panel pnlFamilyPetInfo;
        private System.Windows.Forms.ComboBox cmbFamilyPetInfo;
        private System.Windows.Forms.Label lblFamilyPetInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFamilyPetInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReFamilyPetInfo;
    }
}