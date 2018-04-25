namespace M_CR
{
    partial class Frm_Kart_Board
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
            this.components = new System.ComponentModel.Container();
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.CmbServer = new System.Windows.Forms.ComboBox();
            this.LblServer = new System.Windows.Forms.Label();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.LblName = new System.Windows.Forms.Label();
            this.ChkClose = new System.Windows.Forms.CheckBox();
            this.ChkOpen = new System.Windows.Forms.CheckBox();
            this.LblStatus = new System.Windows.Forms.Label();
            this.TxtID = new System.Windows.Forms.TextBox();
            this.LblID = new System.Windows.Forms.Label();
            this.DtpDate = new System.Windows.Forms.DateTimePicker();
            this.LblDate = new System.Windows.Forms.Label();
            this.GrpInput = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.TxtCode = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnColor = new System.Windows.Forms.Button();
            this.TxtColor = new System.Windows.Forms.TextBox();
            this.ChkStatus = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.TxtContent = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtSpeed = new System.Windows.Forms.TextBox();
            this.LblSpeed = new System.Windows.Forms.Label();
            this.ChkPlay = new System.Windows.Forms.CheckBox();
            this.LblIName = new System.Windows.Forms.Label();
            this.TxtIID = new System.Windows.Forms.TextBox();
            this.LblIID = new System.Windows.Forms.Label();
            this.LblPlay = new System.Windows.Forms.Label();
            this.LblColor = new System.Windows.Forms.Label();
            this.DptStop = new System.Windows.Forms.DateTimePicker();
            this.LblStop = new System.Windows.Forms.Label();
            this.DptStart = new System.Windows.Forms.DateTimePicker();
            this.LblStart = new System.Windows.Forms.Label();
            this.MnuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ItmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ItmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ItmSep = new System.Windows.Forms.ToolStripSeparator();
            this.ItmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.PnlGrid = new System.Windows.Forms.Panel();
            this.GrdList = new System.Windows.Forms.DataGridView();
            this.PnlPage = new System.Windows.Forms.Panel();
            this.CmbPage = new System.Windows.Forms.ComboBox();
            this.LblPage = new System.Windows.Forms.Label();
            this.DlgColor = new System.Windows.Forms.ColorDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GrpSearch.SuspendLayout();
            this.GrpInput.SuspendLayout();
            this.MnuGrid.SuspendLayout();
            this.PnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdList)).BeginInit();
            this.PnlPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.CmbServer);
            this.GrpSearch.Controls.Add(this.LblServer);
            this.GrpSearch.Controls.Add(this.BtnReset);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Controls.Add(this.TxtName);
            this.GrpSearch.Controls.Add(this.LblName);
            this.GrpSearch.Controls.Add(this.ChkClose);
            this.GrpSearch.Controls.Add(this.ChkOpen);
            this.GrpSearch.Controls.Add(this.LblStatus);
            this.GrpSearch.Controls.Add(this.TxtID);
            this.GrpSearch.Controls.Add(this.LblID);
            this.GrpSearch.Controls.Add(this.DtpDate);
            this.GrpSearch.Controls.Add(this.LblDate);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(645, 108);
            this.GrpSearch.TabIndex = 0;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索条件";
            // 
            // CmbServer
            // 
            this.CmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbServer.FormattingEnabled = true;
            this.CmbServer.Location = new System.Drawing.Point(133, 20);
            this.CmbServer.Name = "CmbServer";
            this.CmbServer.Size = new System.Drawing.Size(149, 20);
            this.CmbServer.TabIndex = 12;
            // 
            // LblServer
            // 
            this.LblServer.AutoSize = true;
            this.LblServer.Location = new System.Drawing.Point(44, 29);
            this.LblServer.Name = "LblServer";
            this.LblServer.Size = new System.Drawing.Size(77, 12);
            this.LblServer.TabIndex = 11;
            this.LblServer.Text = "服务器列表：";
            // 
            // BtnReset
            // 
            this.BtnReset.Location = new System.Drawing.Point(449, 18);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(89, 23);
            this.BtnReset.TabIndex = 10;
            this.BtnReset.Text = "【重  置】";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(336, 18);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(89, 23);
            this.BtnSearch.TabIndex = 9;
            this.BtnSearch.Text = "【搜  索】";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(411, 75);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(143, 21);
            this.TxtName.TabIndex = 8;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(328, 80);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(77, 12);
            this.LblName.TabIndex = 7;
            this.LblName.Text = "发布人名称：";
            // 
            // ChkClose
            // 
            this.ChkClose.AutoSize = true;
            this.ChkClose.Location = new System.Drawing.Point(475, 52);
            this.ChkClose.Name = "ChkClose";
            this.ChkClose.Size = new System.Drawing.Size(48, 16);
            this.ChkClose.TabIndex = 6;
            this.ChkClose.Text = "未用";
            this.ChkClose.UseVisualStyleBackColor = true;
            // 
            // ChkOpen
            // 
            this.ChkOpen.AutoSize = true;
            this.ChkOpen.Location = new System.Drawing.Point(411, 52);
            this.ChkOpen.Name = "ChkOpen";
            this.ChkOpen.Size = new System.Drawing.Size(48, 16);
            this.ChkOpen.TabIndex = 5;
            this.ChkOpen.Text = "已用";
            this.ChkOpen.UseVisualStyleBackColor = true;
            // 
            // LblStatus
            // 
            this.LblStatus.AutoSize = true;
            this.LblStatus.Location = new System.Drawing.Point(321, 54);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(83, 12);
            this.LblStatus.TabIndex = 4;
            this.LblStatus.Text = "有 效 状 态：";
            // 
            // TxtID
            // 
            this.TxtID.Location = new System.Drawing.Point(134, 75);
            this.TxtID.Name = "TxtID";
            this.TxtID.Size = new System.Drawing.Size(147, 21);
            this.TxtID.TabIndex = 3;
            // 
            // LblID
            // 
            this.LblID.AutoSize = true;
            this.LblID.Location = new System.Drawing.Point(43, 80);
            this.LblID.Name = "LblID";
            this.LblID.Size = new System.Drawing.Size(89, 12);
            this.LblID.TabIndex = 2;
            this.LblID.Text = "发 布 人ＩＤ：";
            // 
            // DtpDate
            // 
            this.DtpDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.DtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpDate.Location = new System.Drawing.Point(134, 48);
            this.DtpDate.Name = "DtpDate";
            this.DtpDate.Size = new System.Drawing.Size(147, 21);
            this.DtpDate.TabIndex = 1;
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Location = new System.Drawing.Point(43, 53);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(89, 12);
            this.LblDate.TabIndex = 0;
            this.LblDate.Text = "公告生效时间：";
            // 
            // GrpInput
            // 
            this.GrpInput.Controls.Add(this.label3);
            this.GrpInput.Controls.Add(this.label2);
            this.GrpInput.Controls.Add(this.button4);
            this.GrpInput.Controls.Add(this.button3);
            this.GrpInput.Controls.Add(this.TxtCode);
            this.GrpInput.Controls.Add(this.label1);
            this.GrpInput.Controls.Add(this.BtnColor);
            this.GrpInput.Controls.Add(this.TxtColor);
            this.GrpInput.Controls.Add(this.ChkStatus);
            this.GrpInput.Controls.Add(this.button2);
            this.GrpInput.Controls.Add(this.button1);
            this.GrpInput.Controls.Add(this.TxtContent);
            this.GrpInput.Controls.Add(this.label9);
            this.GrpInput.Controls.Add(this.label8);
            this.GrpInput.Controls.Add(this.TxtSpeed);
            this.GrpInput.Controls.Add(this.LblSpeed);
            this.GrpInput.Controls.Add(this.ChkPlay);
            this.GrpInput.Controls.Add(this.LblIName);
            this.GrpInput.Controls.Add(this.TxtIID);
            this.GrpInput.Controls.Add(this.LblIID);
            this.GrpInput.Controls.Add(this.LblPlay);
            this.GrpInput.Controls.Add(this.LblColor);
            this.GrpInput.Controls.Add(this.DptStop);
            this.GrpInput.Controls.Add(this.LblStop);
            this.GrpInput.Controls.Add(this.DptStart);
            this.GrpInput.Controls.Add(this.LblStart);
            this.GrpInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GrpInput.Location = new System.Drawing.Point(0, 172);
            this.GrpInput.Name = "GrpInput";
            this.GrpInput.Size = new System.Drawing.Size(645, 301);
            this.GrpInput.TabIndex = 2;
            this.GrpInput.TabStop = false;
            this.GrpInput.Text = "记录内容：";
            this.GrpInput.Visible = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(498, 180);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(65, 23);
            this.button4.TabIndex = 25;
            this.button4.Text = "重置频道";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(499, 105);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 23);
            this.button3.TabIndex = 24;
            this.button3.Text = "全选";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // TxtCode
            // 
            this.TxtCode.CheckOnClick = true;
            this.TxtCode.ColumnWidth = 33;
            this.TxtCode.FormattingEnabled = true;
            this.TxtCode.HorizontalExtent = 10;
            this.TxtCode.Location = new System.Drawing.Point(115, 106);
            this.TxtCode.MultiColumn = true;
            this.TxtCode.Name = "TxtCode";
            this.TxtCode.Size = new System.Drawing.Size(379, 36);
            this.TxtCode.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "秒";
            // 
            // BtnColor
            // 
            this.BtnColor.Location = new System.Drawing.Point(202, 46);
            this.BtnColor.Name = "BtnColor";
            this.BtnColor.Size = new System.Drawing.Size(40, 23);
            this.BtnColor.TabIndex = 21;
            this.BtnColor.Text = "颜色";
            this.BtnColor.UseVisualStyleBackColor = true;
            this.BtnColor.Click += new System.EventHandler(this.BtnColor_Click);
            // 
            // TxtColor
            // 
            this.TxtColor.Location = new System.Drawing.Point(115, 46);
            this.TxtColor.Name = "TxtColor";
            this.TxtColor.ReadOnly = true;
            this.TxtColor.Size = new System.Drawing.Size(68, 21);
            this.TxtColor.TabIndex = 20;
            // 
            // ChkStatus
            // 
            this.ChkStatus.AutoSize = true;
            this.ChkStatus.Location = new System.Drawing.Point(356, 74);
            this.ChkStatus.Name = "ChkStatus";
            this.ChkStatus.Size = new System.Drawing.Size(72, 16);
            this.ChkStatus.TabIndex = 19;
            this.ChkStatus.Text = "当即生效";
            this.ChkStatus.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(330, 260);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "取　　消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(219, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "发　　布";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtContent
            // 
            this.TxtContent.Location = new System.Drawing.Point(115, 154);
            this.TxtContent.Multiline = true;
            this.TxtContent.Name = "TxtContent";
            this.TxtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtContent.Size = new System.Drawing.Size(380, 73);
            this.TxtContent.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(45, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "公告内容：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "频道编号：";
            // 
            // TxtSpeed
            // 
            this.TxtSpeed.Location = new System.Drawing.Point(115, 75);
            this.TxtSpeed.Name = "TxtSpeed";
            this.TxtSpeed.Size = new System.Drawing.Size(97, 21);
            this.TxtSpeed.TabIndex = 12;
            // 
            // LblSpeed
            // 
            this.LblSpeed.AutoSize = true;
            this.LblSpeed.Location = new System.Drawing.Point(45, 79);
            this.LblSpeed.Name = "LblSpeed";
            this.LblSpeed.Size = new System.Drawing.Size(65, 12);
            this.LblSpeed.TabIndex = 11;
            this.LblSpeed.Text = "播放速度：";
            // 
            // ChkPlay
            // 
            this.ChkPlay.AutoSize = true;
            this.ChkPlay.Location = new System.Drawing.Point(356, 51);
            this.ChkPlay.Name = "ChkPlay";
            this.ChkPlay.Size = new System.Drawing.Size(36, 16);
            this.ChkPlay.TabIndex = 10;
            this.ChkPlay.Text = "是";
            this.ChkPlay.UseVisualStyleBackColor = true;
            this.ChkPlay.CheckedChanged += new System.EventHandler(this.ChkPlay_CheckedChanged);
            // 
            // LblIName
            // 
            this.LblIName.AutoSize = true;
            this.LblIName.Location = new System.Drawing.Point(281, 77);
            this.LblIName.Name = "LblIName";
            this.LblIName.Size = new System.Drawing.Size(65, 12);
            this.LblIName.TabIndex = 8;
            this.LblIName.Text = "发布状态：";
            // 
            // TxtIID
            // 
            this.TxtIID.Location = new System.Drawing.Point(499, 247);
            this.TxtIID.Name = "TxtIID";
            this.TxtIID.Size = new System.Drawing.Size(140, 21);
            this.TxtIID.TabIndex = 7;
            this.TxtIID.Visible = false;
            // 
            // LblIID
            // 
            this.LblIID.AutoSize = true;
            this.LblIID.Location = new System.Drawing.Point(429, 251);
            this.LblIID.Name = "LblIID";
            this.LblIID.Size = new System.Drawing.Size(65, 12);
            this.LblIID.TabIndex = 6;
            this.LblIID.Text = "发布人ID：";
            this.LblIID.Visible = false;
            // 
            // LblPlay
            // 
            this.LblPlay.AutoSize = true;
            this.LblPlay.Location = new System.Drawing.Point(281, 53);
            this.LblPlay.Name = "LblPlay";
            this.LblPlay.Size = new System.Drawing.Size(65, 12);
            this.LblPlay.TabIndex = 5;
            this.LblPlay.Text = "每日播放：";
            // 
            // LblColor
            // 
            this.LblColor.AutoSize = true;
            this.LblColor.Location = new System.Drawing.Point(45, 53);
            this.LblColor.Name = "LblColor";
            this.LblColor.Size = new System.Drawing.Size(65, 12);
            this.LblColor.TabIndex = 4;
            this.LblColor.Text = "文本颜色：";
            // 
            // DptStop
            // 
            this.DptStop.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.DptStop.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DptStop.Location = new System.Drawing.Point(356, 21);
            this.DptStop.Name = "DptStop";
            this.DptStop.Size = new System.Drawing.Size(139, 21);
            this.DptStop.TabIndex = 3;
            // 
            // LblStop
            // 
            this.LblStop.AutoSize = true;
            this.LblStop.Location = new System.Drawing.Point(281, 25);
            this.LblStop.Name = "LblStop";
            this.LblStop.Size = new System.Drawing.Size(65, 12);
            this.LblStop.TabIndex = 2;
            this.LblStop.Text = "失效时间：";
            // 
            // DptStart
            // 
            this.DptStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.DptStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DptStart.Location = new System.Drawing.Point(115, 21);
            this.DptStart.Name = "DptStart";
            this.DptStart.Size = new System.Drawing.Size(140, 21);
            this.DptStart.TabIndex = 1;
            // 
            // LblStart
            // 
            this.LblStart.AutoSize = true;
            this.LblStart.Location = new System.Drawing.Point(45, 25);
            this.LblStart.Name = "LblStart";
            this.LblStart.Size = new System.Drawing.Size(65, 12);
            this.LblStart.TabIndex = 0;
            this.LblStart.Text = "生效时间：";
            // 
            // MnuGrid
            // 
            this.MnuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItmEdit,
            this.ItmDelete,
            this.ItmSep,
            this.ItmAdd});
            this.MnuGrid.Name = "MnuGrid";
            this.MnuGrid.Size = new System.Drawing.Size(147, 76);
            // 
            // ItmEdit
            // 
            this.ItmEdit.Enabled = false;
            this.ItmEdit.Name = "ItmEdit";
            this.ItmEdit.Size = new System.Drawing.Size(146, 22);
            this.ItmEdit.Text = "编辑该条记录";
            this.ItmEdit.Click += new System.EventHandler(this.ItmEdit_Click);
            // 
            // ItmDelete
            // 
            this.ItmDelete.Enabled = false;
            this.ItmDelete.Name = "ItmDelete";
            this.ItmDelete.Size = new System.Drawing.Size(146, 22);
            this.ItmDelete.Text = "删除该条记录";
            this.ItmDelete.Click += new System.EventHandler(this.ItmDelete_Click);
            // 
            // ItmSep
            // 
            this.ItmSep.Name = "ItmSep";
            this.ItmSep.Size = new System.Drawing.Size(143, 6);
            // 
            // ItmAdd
            // 
            this.ItmAdd.Name = "ItmAdd";
            this.ItmAdd.Size = new System.Drawing.Size(146, 22);
            this.ItmAdd.Text = "新增一条纪录";
            this.ItmAdd.Click += new System.EventHandler(this.ItmAdd_Click);
            // 
            // PnlGrid
            // 
            this.PnlGrid.Controls.Add(this.GrdList);
            this.PnlGrid.Controls.Add(this.PnlPage);
            this.PnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlGrid.Location = new System.Drawing.Point(0, 108);
            this.PnlGrid.Name = "PnlGrid";
            this.PnlGrid.Size = new System.Drawing.Size(645, 64);
            this.PnlGrid.TabIndex = 4;
            // 
            // GrdList
            // 
            this.GrdList.AllowUserToAddRows = false;
            this.GrdList.AllowUserToDeleteRows = false;
            this.GrdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdList.ContextMenuStrip = this.MnuGrid;
            this.GrdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdList.Location = new System.Drawing.Point(0, 35);
            this.GrdList.Name = "GrdList";
            this.GrdList.ReadOnly = true;
            this.GrdList.RowTemplate.Height = 23;
            this.GrdList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdList.Size = new System.Drawing.Size(645, 29);
            this.GrdList.TabIndex = 6;
            this.GrdList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdList_CellClick);
            // 
            // PnlPage
            // 
            this.PnlPage.Controls.Add(this.CmbPage);
            this.PnlPage.Controls.Add(this.LblPage);
            this.PnlPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlPage.Location = new System.Drawing.Point(0, 0);
            this.PnlPage.Name = "PnlPage";
            this.PnlPage.Size = new System.Drawing.Size(645, 35);
            this.PnlPage.TabIndex = 0;
            // 
            // CmbPage
            // 
            this.CmbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPage.FormattingEnabled = true;
            this.CmbPage.Location = new System.Drawing.Point(557, 6);
            this.CmbPage.Name = "CmbPage";
            this.CmbPage.Size = new System.Drawing.Size(63, 20);
            this.CmbPage.TabIndex = 1;
            this.CmbPage.SelectedIndexChanged += new System.EventHandler(this.CmbPage_SelectedIndexChanged);
            // 
            // LblPage
            // 
            this.LblPage.AutoSize = true;
            this.LblPage.Location = new System.Drawing.Point(462, 11);
            this.LblPage.Name = "LblPage";
            this.LblPage.Size = new System.Drawing.Size(89, 12);
            this.LblPage.TabIndex = 0;
            this.LblPage.Text = "请选择显示页：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(501, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "PS:网通大区添加频道信息时速度比较慢 请稍侯!";
            // 
            // Frm_Kart_Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 473);
            this.Controls.Add(this.PnlGrid);
            this.Controls.Add(this.GrpInput);
            this.Controls.Add(this.GrpSearch);
            this.Name = "Frm_Kart_Board";
            this.Text = "公告管理系统[疯狂卡丁车]";
            this.Load += new System.EventHandler(this.Frm_Kart_Board_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.GrpInput.ResumeLayout(false);
            this.GrpInput.PerformLayout();
            this.MnuGrid.ResumeLayout(false);
            this.PnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdList)).EndInit();
            this.PnlPage.ResumeLayout(false);
            this.PnlPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.GroupBox GrpInput;
        private System.Windows.Forms.DateTimePicker DtpDate;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.TextBox TxtID;
        private System.Windows.Forms.Label LblID;
        private System.Windows.Forms.CheckBox ChkClose;
        private System.Windows.Forms.CheckBox ChkOpen;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.ContextMenuStrip MnuGrid;
        private System.Windows.Forms.ToolStripMenuItem ItmEdit;
        private System.Windows.Forms.ToolStripMenuItem ItmDelete;
        private System.Windows.Forms.ComboBox CmbServer;
        private System.Windows.Forms.Label LblServer;
        private System.Windows.Forms.ToolStripSeparator ItmSep;
        private System.Windows.Forms.ToolStripMenuItem ItmAdd;
        private System.Windows.Forms.Panel PnlGrid;
        private System.Windows.Forms.Panel PnlPage;
        private System.Windows.Forms.DataGridView GrdList;
        private System.Windows.Forms.ComboBox CmbPage;
        private System.Windows.Forms.Label LblPage;
        private System.Windows.Forms.Label LblStop;
        private System.Windows.Forms.DateTimePicker DptStart;
        private System.Windows.Forms.Label LblStart;
        private System.Windows.Forms.Label LblColor;
        private System.Windows.Forms.DateTimePicker DptStop;
        private System.Windows.Forms.ColorDialog DlgColor;
        private System.Windows.Forms.Label LblPlay;
        private System.Windows.Forms.CheckBox ChkPlay;
        private System.Windows.Forms.Label LblIName;
        private System.Windows.Forms.TextBox TxtIID;
        private System.Windows.Forms.Label LblIID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtSpeed;
        private System.Windows.Forms.Label LblSpeed;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TxtContent;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox ChkStatus;
        private System.Windows.Forms.Button BtnColor;
        private System.Windows.Forms.TextBox TxtColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox TxtCode;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}