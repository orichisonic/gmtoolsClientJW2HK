namespace M_JW2
{
    partial class FrmJW2NoticeManage
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerReSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSendNotice = new System.ComponentModel.BackgroundWorker();
            this.lblServerList = new System.Windows.Forms.Label();
            this.pnlServerList = new System.Windows.Forms.Panel();
            this.pblSelectAll = new System.Windows.Forms.Panel();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.GrpServer = new System.Windows.Forms.GroupBox();
            this.clbServer = new System.Windows.Forms.CheckedListBox();
            this.GrpNotice = new System.Windows.Forms.GroupBox();
            this.pnlNoticeList = new System.Windows.Forms.Panel();
            this.GrdNotice = new System.Windows.Forms.DataGridView();
            this.cmsEditNotice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.编辑公告信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlNotice = new System.Windows.Forms.Panel();
            this.cmbNotice = new System.Windows.Forms.ComboBox();
            this.lblNotice = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbStauas = new System.Windows.Forms.ComboBox();
            this.txtContent = new System.Windows.Forms.RichTextBox();
            this.chbNoticeImmed = new System.Windows.Forms.CheckBox();
            this.DptStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.DptEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblMin = new System.Windows.Forms.Label();
            this.nudTimeSpan = new System.Windows.Forms.NumericUpDown();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblTimeSpan = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAddNotice = new System.Windows.Forms.Button();
            this.lblContent = new System.Windows.Forms.Label();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.pnlNoticeInfo = new System.Windows.Forms.Panel();
            this.btnNoticeInfo = new System.Windows.Forms.Button();
            this.backgroundWorkerEditNotice = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerDeleteNotice = new System.ComponentModel.BackgroundWorker();
            this.MnuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ItmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlServerList.SuspendLayout();
            this.pblSelectAll.SuspendLayout();
            this.GrpServer.SuspendLayout();
            this.GrpNotice.SuspendLayout();
            this.pnlNoticeList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdNotice)).BeginInit();
            this.cmsEditNotice.SuspendLayout();
            this.pnlNotice.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeSpan)).BeginInit();
            this.pnlNoticeInfo.SuspendLayout();
            this.MnuGrid.SuspendLayout();
            this.SuspendLayout();
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
            // backgroundWorkerSendNotice
            // 
            this.backgroundWorkerSendNotice.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSendNotice_DoWork);
            this.backgroundWorkerSendNotice.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSendNotice_RunWorkerCompleted);
            // 
            // lblServerList
            // 
            this.lblServerList.AutoSize = true;
            this.lblServerList.Location = new System.Drawing.Point(3, 9);
            this.lblServerList.Name = "lblServerList";
            this.lblServerList.Size = new System.Drawing.Size(101, 12);
            this.lblServerList.TabIndex = 0;
            this.lblServerList.Text = "遊戲伺服器列表：";
            // 
            // pnlServerList
            // 
            this.pnlServerList.Controls.Add(this.lblServerList);
            this.pnlServerList.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlServerList.Location = new System.Drawing.Point(3, 17);
            this.pnlServerList.Name = "pnlServerList";
            this.pnlServerList.Size = new System.Drawing.Size(187, 33);
            this.pnlServerList.TabIndex = 4;
            // 
            // pblSelectAll
            // 
            this.pblSelectAll.Controls.Add(this.btnSelectAll);
            this.pblSelectAll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pblSelectAll.Location = new System.Drawing.Point(3, 449);
            this.pblSelectAll.Name = "pblSelectAll";
            this.pblSelectAll.Size = new System.Drawing.Size(187, 46);
            this.pblSelectAll.TabIndex = 5;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(42, 14);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 0;
            this.btnSelectAll.Text = "全選";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // GrpServer
            // 
            this.GrpServer.Controls.Add(this.clbServer);
            this.GrpServer.Controls.Add(this.pnlServerList);
            this.GrpServer.Controls.Add(this.pblSelectAll);
            this.GrpServer.Dock = System.Windows.Forms.DockStyle.Left;
            this.GrpServer.Location = new System.Drawing.Point(0, 0);
            this.GrpServer.Name = "GrpServer";
            this.GrpServer.Size = new System.Drawing.Size(193, 498);
            this.GrpServer.TabIndex = 6;
            this.GrpServer.TabStop = false;
            // 
            // clbServer
            // 
            this.clbServer.CheckOnClick = true;
            this.clbServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbServer.FormattingEnabled = true;
            this.clbServer.Location = new System.Drawing.Point(3, 50);
            this.clbServer.MultiColumn = true;
            this.clbServer.Name = "clbServer";
            this.clbServer.Size = new System.Drawing.Size(187, 388);
            this.clbServer.TabIndex = 6;
            // 
            // GrpNotice
            // 
            this.GrpNotice.Controls.Add(this.pnlNoticeList);
            this.GrpNotice.Controls.Add(this.panel1);
            this.GrpNotice.Controls.Add(this.pnlNoticeInfo);
            this.GrpNotice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpNotice.Location = new System.Drawing.Point(193, 0);
            this.GrpNotice.Name = "GrpNotice";
            this.GrpNotice.Size = new System.Drawing.Size(690, 498);
            this.GrpNotice.TabIndex = 7;
            this.GrpNotice.TabStop = false;
            // 
            // pnlNoticeList
            // 
            this.pnlNoticeList.Controls.Add(this.GrdNotice);
            this.pnlNoticeList.Controls.Add(this.pnlNotice);
            this.pnlNoticeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoticeList.Location = new System.Drawing.Point(3, 49);
            this.pnlNoticeList.Name = "pnlNoticeList";
            this.pnlNoticeList.Size = new System.Drawing.Size(684, 147);
            this.pnlNoticeList.TabIndex = 53;
            // 
            // GrdNotice
            // 
            this.GrdNotice.AllowUserToAddRows = false;
            this.GrdNotice.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrdNotice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GrdNotice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrdNotice.DefaultCellStyle = dataGridViewCellStyle2;
            this.GrdNotice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdNotice.Location = new System.Drawing.Point(0, 35);
            this.GrdNotice.Name = "GrdNotice";
            this.GrdNotice.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrdNotice.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.GrdNotice.RowTemplate.Height = 23;
            this.GrdNotice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdNotice.Size = new System.Drawing.Size(684, 112);
            this.GrdNotice.TabIndex = 14;
            this.GrdNotice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdNotice_CellClick);
            // 
            // cmsEditNotice
            // 
            this.cmsEditNotice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑公告信息ToolStripMenuItem});
            this.cmsEditNotice.Name = "cmsEditNotice";
            this.cmsEditNotice.Size = new System.Drawing.Size(143, 26);
            this.cmsEditNotice.Click += new System.EventHandler(this.cmsEditNotice_Click);
            // 
            // 编辑公告信息ToolStripMenuItem
            // 
            this.编辑公告信息ToolStripMenuItem.Name = "编辑公告信息ToolStripMenuItem";
            this.编辑公告信息ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.编辑公告信息ToolStripMenuItem.Text = "編輯公告資訊";
            this.编辑公告信息ToolStripMenuItem.Click += new System.EventHandler(this.编辑公告信息ToolStripMenuItem_Click);
            // 
            // pnlNotice
            // 
            this.pnlNotice.Controls.Add(this.cmbNotice);
            this.pnlNotice.Controls.Add(this.lblNotice);
            this.pnlNotice.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNotice.Location = new System.Drawing.Point(0, 0);
            this.pnlNotice.Name = "pnlNotice";
            this.pnlNotice.Size = new System.Drawing.Size(684, 35);
            this.pnlNotice.TabIndex = 0;
            // 
            // cmbNotice
            // 
            this.cmbNotice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNotice.FormattingEnabled = true;
            this.cmbNotice.Location = new System.Drawing.Point(131, 7);
            this.cmbNotice.Name = "cmbNotice";
            this.cmbNotice.Size = new System.Drawing.Size(100, 20);
            this.cmbNotice.TabIndex = 3;
            this.cmbNotice.SelectedIndexChanged += new System.EventHandler(this.cmbNotice_SelectedIndexChanged);
            // 
            // lblNotice
            // 
            this.lblNotice.AutoSize = true;
            this.lblNotice.Location = new System.Drawing.Point(27, 12);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(89, 12);
            this.lblNotice.TabIndex = 2;
            this.lblNotice.Text = "?選擇查看?數：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.cmbStauas);
            this.panel1.Controls.Add(this.txtContent);
            this.panel1.Controls.Add(this.chbNoticeImmed);
            this.panel1.Controls.Add(this.DptStartTime);
            this.panel1.Controls.Add(this.lblStartTime);
            this.panel1.Controls.Add(this.lblType);
            this.panel1.Controls.Add(this.cmbType);
            this.panel1.Controls.Add(this.DptEndTime);
            this.panel1.Controls.Add(this.lblMin);
            this.panel1.Controls.Add(this.nudTimeSpan);
            this.panel1.Controls.Add(this.lblEndTime);
            this.panel1.Controls.Add(this.lblTimeSpan);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnAddNotice);
            this.panel1.Controls.Add(this.lblContent);
            this.panel1.Controls.Add(this.BtnEdit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 196);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 299);
            this.panel1.TabIndex = 52;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(355, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 17);
            this.label11.TabIndex = 69;
            this.label11.Text = "狀態:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Visible = false;
            // 
            // cmbStauas
            // 
            this.cmbStauas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStauas.FormattingEnabled = true;
            this.cmbStauas.Items.AddRange(new object[] {
            "ゼ祇癳",
            "祇癳い",
            "祇癳"});
            this.cmbStauas.Location = new System.Drawing.Point(403, 51);
            this.cmbStauas.Name = "cmbStauas";
            this.cmbStauas.Size = new System.Drawing.Size(84, 20);
            this.cmbStauas.TabIndex = 68;
            this.cmbStauas.Visible = false;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(117, 166);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(452, 82);
            this.txtContent.TabIndex = 67;
            this.txtContent.Text = "";
            this.txtContent.TextChanged += new System.EventHandler(this.txtContent_TextChanged);
            // 
            // chbNoticeImmed
            // 
            this.chbNoticeImmed.AutoSize = true;
            this.chbNoticeImmed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chbNoticeImmed.Location = new System.Drawing.Point(376, 17);
            this.chbNoticeImmed.Name = "chbNoticeImmed";
            this.chbNoticeImmed.Size = new System.Drawing.Size(74, 19);
            this.chbNoticeImmed.TabIndex = 64;
            this.chbNoticeImmed.Text = "立即發送";
            this.chbNoticeImmed.UseVisualStyleBackColor = true;
            this.chbNoticeImmed.CheckedChanged += new System.EventHandler(this.chbNoticeImmed_CheckedChanged);
            // 
            // DptStartTime
            // 
            this.DptStartTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.DptStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DptStartTime.Location = new System.Drawing.Point(117, 14);
            this.DptStartTime.Name = "DptStartTime";
            this.DptStartTime.ShowUpDown = true;
            this.DptStartTime.Size = new System.Drawing.Size(125, 21);
            this.DptStartTime.TabIndex = 63;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStartTime.Location = new System.Drawing.Point(51, 18);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(67, 15);
            this.lblStartTime.TabIndex = 62;
            this.lblStartTime.Text = "開始時間：";
            this.lblStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblType.Location = new System.Drawing.Point(51, 127);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(62, 15);
            this.lblType.TabIndex = 61;
            this.lblType.Text = "公告?型：";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblType.Visible = false;
            this.lblType.Click += new System.EventHandler(this.lblType_Click);
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(117, 123);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(187, 20);
            this.cmbType.TabIndex = 60;
            this.cmbType.Visible = false;
            // 
            // DptEndTime
            // 
            this.DptEndTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.DptEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DptEndTime.Location = new System.Drawing.Point(117, 50);
            this.DptEndTime.Name = "DptEndTime";
            this.DptEndTime.ShowUpDown = true;
            this.DptEndTime.Size = new System.Drawing.Size(125, 21);
            this.DptEndTime.TabIndex = 59;
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMin.Location = new System.Drawing.Point(204, 91);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(26, 15);
            this.lblMin.TabIndex = 58;
            this.lblMin.Text = "分?";
            // 
            // nudTimeSpan
            // 
            this.nudTimeSpan.Location = new System.Drawing.Point(117, 86);
            this.nudTimeSpan.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.nudTimeSpan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTimeSpan.Name = "nudTimeSpan";
            this.nudTimeSpan.Size = new System.Drawing.Size(84, 21);
            this.nudTimeSpan.TabIndex = 56;
            this.nudTimeSpan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEndTime.Location = new System.Drawing.Point(51, 54);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(67, 15);
            this.lblEndTime.TabIndex = 55;
            this.lblEndTime.Text = "結束時間：";
            this.lblEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTimeSpan
            // 
            this.lblTimeSpan.AutoSize = true;
            this.lblTimeSpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTimeSpan.Location = new System.Drawing.Point(51, 90);
            this.lblTimeSpan.Name = "lblTimeSpan";
            this.lblTimeSpan.Size = new System.Drawing.Size(67, 15);
            this.lblTimeSpan.TabIndex = 57;
            this.lblTimeSpan.Text = "間隔時間：";
            this.lblTimeSpan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(307, 266);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 54;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAddNotice
            // 
            this.btnAddNotice.Location = new System.Drawing.Point(131, 264);
            this.btnAddNotice.Name = "btnAddNotice";
            this.btnAddNotice.Size = new System.Drawing.Size(75, 23);
            this.btnAddNotice.TabIndex = 53;
            this.btnAddNotice.Text = "發送公告";
            this.btnAddNotice.UseVisualStyleBackColor = true;
            this.btnAddNotice.Click += new System.EventHandler(this.btnAddNotice_Click);
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(51, 166);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(65, 12);
            this.lblContent.TabIndex = 51;
            this.lblContent.Text = "公告内容：";
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(117, 264);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(75, 24);
            this.BtnEdit.TabIndex = 70;
            this.BtnEdit.Text = "修改狀態";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Visible = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // pnlNoticeInfo
            // 
            this.pnlNoticeInfo.Controls.Add(this.btnNoticeInfo);
            this.pnlNoticeInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNoticeInfo.Location = new System.Drawing.Point(3, 17);
            this.pnlNoticeInfo.Name = "pnlNoticeInfo";
            this.pnlNoticeInfo.Size = new System.Drawing.Size(684, 32);
            this.pnlNoticeInfo.TabIndex = 51;
            // 
            // btnNoticeInfo
            // 
            this.btnNoticeInfo.Location = new System.Drawing.Point(13, 6);
            this.btnNoticeInfo.Name = "btnNoticeInfo";
            this.btnNoticeInfo.Size = new System.Drawing.Size(99, 23);
            this.btnNoticeInfo.TabIndex = 0;
            this.btnNoticeInfo.Text = "查看公告??";
            this.btnNoticeInfo.UseVisualStyleBackColor = true;
            this.btnNoticeInfo.Click += new System.EventHandler(this.btnNoticeInfo_Click);
            // 
            // backgroundWorkerEditNotice
            // 
            this.backgroundWorkerEditNotice.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerEditNotice_DoWork);
            this.backgroundWorkerEditNotice.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerEditNotice_RunWorkerCompleted);
            // 
            // backgroundWorkerDeleteNotice
            // 
            this.backgroundWorkerDeleteNotice.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDeleteNotice_DoWork);
            this.backgroundWorkerDeleteNotice.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerDeleteNotice_RunWorkerCompleted);
            // 
            // MnuGrid
            // 
            this.MnuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItmDelete});
            this.MnuGrid.Name = "MnuGrid";
            this.MnuGrid.Size = new System.Drawing.Size(119, 26);
            // 
            // ItmDelete
            // 
            this.ItmDelete.Name = "ItmDelete";
            this.ItmDelete.Size = new System.Drawing.Size(118, 22);
            this.ItmDelete.Text = "э篈";
            this.ItmDelete.Click += new System.EventHandler(this.ItmDelete_Click);
            // 
            // FrmJW2NoticeManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(883, 498);
            this.Controls.Add(this.GrpNotice);
            this.Controls.Add(this.GrpServer);
            this.Name = "FrmJW2NoticeManage";
            this.Text = "公告管理";
            this.Load += new System.EventHandler(this.FrmGDNoticeManage_Load);
            this.pnlServerList.ResumeLayout(false);
            this.pnlServerList.PerformLayout();
            this.pblSelectAll.ResumeLayout(false);
            this.GrpServer.ResumeLayout(false);
            this.GrpNotice.ResumeLayout(false);
            this.pnlNoticeList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdNotice)).EndInit();
            this.cmsEditNotice.ResumeLayout(false);
            this.pnlNotice.ResumeLayout(false);
            this.pnlNotice.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeSpan)).EndInit();
            this.pnlNoticeInfo.ResumeLayout(false);
            this.MnuGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSendNotice;
        private System.Windows.Forms.Label lblServerList;
        private System.Windows.Forms.Panel pnlServerList;
        private System.Windows.Forms.Panel pblSelectAll;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.GroupBox GrpServer;
        private System.Windows.Forms.CheckedListBox clbServer;
        private System.Windows.Forms.GroupBox GrpNotice;
        private System.Windows.Forms.Panel pnlNoticeInfo;
        private System.Windows.Forms.Button btnNoticeInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.DateTimePicker DptEndTime;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.NumericUpDown nudTimeSpan;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblTimeSpan;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnAddNotice;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Panel pnlNoticeList;
        private System.Windows.Forms.Panel pnlNotice;
        private System.Windows.Forms.ComboBox cmbNotice;
        private System.Windows.Forms.Label lblNotice;
        private System.Windows.Forms.DataGridView GrdNotice;
        private System.Windows.Forms.DateTimePicker DptStartTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.CheckBox chbNoticeImmed;
        private System.Windows.Forms.ContextMenuStrip cmsEditNotice;
        private System.Windows.Forms.ToolStripMenuItem 编辑公告信息ToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerEditNotice;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDeleteNotice;
        private System.Windows.Forms.RichTextBox txtContent;
        private System.Windows.Forms.ContextMenuStrip MnuGrid;
        private System.Windows.Forms.ToolStripMenuItem ItmDelete;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbStauas;
        private System.Windows.Forms.Button BtnEdit;
    }
}