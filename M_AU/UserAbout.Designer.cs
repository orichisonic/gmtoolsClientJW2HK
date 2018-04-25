namespace M_AU
{
    partial class UserAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAbout));
            this.lblAccountOrNick = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAccount = new System.Windows.Forms.CheckBox();
            this.chkNick = new System.Windows.Forms.CheckBox();
            this.cbxServerIP = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tcInfoCard = new System.Windows.Forms.TabControl();
            this.userInfo = new System.Windows.Forms.TabPage();
            this.dpEdit = new DividerPanel.DividerPanel();
            this.btnModiCancel = new System.Windows.Forms.Button();
            this.btnModiOk = new System.Windows.Forms.Button();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.txtExp = new System.Windows.Forms.TextBox();
            this.cbxLevel = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserNick = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dividerPanel5 = new DividerPanel.DividerPanel();
            this.linkEdit = new System.Windows.Forms.LinkLabel();
            this.linkEquipment = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dividerPanel4 = new DividerPanel.DividerPanel();
            this.dgPartInfoList = new System.Windows.Forms.DataGridView();
            this.equipList = new System.Windows.Forms.TabPage();
            this.imgtxtctrl1 = new ImageTextControl.IMGTXTCTRL();
            this.label9 = new System.Windows.Forms.Label();
            this.dividerPanel6 = new DividerPanel.DividerPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.dividerPanel7 = new DividerPanel.DividerPanel();
            this.dividerPanel9 = new DividerPanel.DividerPanel();
            this.dgEquipList = new System.Windows.Forms.DataGridView();
            this.dividerPanel8 = new DividerPanel.DividerPanel();
            this.cbxToPageIndex = new System.Windows.Forms.ComboBox();
            this.lblCurrPage = new System.Windows.Forms.Label();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.dividerPanel3 = new DividerPanel.DividerPanel();
            this.groupBox1.SuspendLayout();
            this.tcInfoCard.SuspendLayout();
            this.userInfo.SuspendLayout();
            this.dpEdit.SuspendLayout();
            this.dividerPanel5.SuspendLayout();
            this.dividerPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPartInfoList)).BeginInit();
            this.equipList.SuspendLayout();
            this.dividerPanel7.SuspendLayout();
            this.dividerPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEquipList)).BeginInit();
            this.dividerPanel8.SuspendLayout();
            this.dividerPanel1.SuspendLayout();
            this.dividerPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAccountOrNick
            // 
            this.lblAccountOrNick.AutoSize = true;
            this.lblAccountOrNick.Location = new System.Drawing.Point(249, 17);
            this.lblAccountOrNick.Name = "lblAccountOrNick";
            this.lblAccountOrNick.Size = new System.Drawing.Size(65, 12);
            this.lblAccountOrNick.TabIndex = 0;
            this.lblAccountOrNick.Text = "玩家帐号：";
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(249, 33);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(195, 21);
            this.txtAccount.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(451, 32);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(532, 32);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAccount);
            this.groupBox1.Controls.Add(this.chkNick);
            this.groupBox1.Controls.Add(this.cbxServerIP);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblAccountOrNick);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.txtAccount);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(721, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "帐号录入";
            // 
            // chkAccount
            // 
            this.chkAccount.AutoSize = true;
            this.chkAccount.Checked = true;
            this.chkAccount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAccount.Location = new System.Drawing.Point(14, 61);
            this.chkAccount.Name = "chkAccount";
            this.chkAccount.Size = new System.Drawing.Size(72, 16);
            this.chkAccount.TabIndex = 8;
            this.chkAccount.Text = "玩家帐号";
            this.chkAccount.UseVisualStyleBackColor = true;
            this.chkAccount.Click += new System.EventHandler(this.chkAccount_Click);
            // 
            // chkNick
            // 
            this.chkNick.AutoSize = true;
            this.chkNick.Location = new System.Drawing.Point(92, 61);
            this.chkNick.Name = "chkNick";
            this.chkNick.Size = new System.Drawing.Size(72, 16);
            this.chkNick.TabIndex = 9;
            this.chkNick.Text = "玩家昵称";
            this.chkNick.UseVisualStyleBackColor = true;
            this.chkNick.Click += new System.EventHandler(this.chkNick_Click);
            // 
            // cbxServerIP
            // 
            this.cbxServerIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServerIP.FormattingEnabled = true;
            this.cbxServerIP.Location = new System.Drawing.Point(14, 32);
            this.cbxServerIP.Name = "cbxServerIP";
            this.cbxServerIP.Size = new System.Drawing.Size(219, 20);
            this.cbxServerIP.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "服务器：";
            // 
            // tcInfoCard
            // 
            this.tcInfoCard.Controls.Add(this.userInfo);
            this.tcInfoCard.Controls.Add(this.equipList);
            this.tcInfoCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcInfoCard.Location = new System.Drawing.Point(0, 0);
            this.tcInfoCard.Name = "tcInfoCard";
            this.tcInfoCard.SelectedIndex = 0;
            this.tcInfoCard.Size = new System.Drawing.Size(721, 410);
            this.tcInfoCard.TabIndex = 0;
            this.tcInfoCard.Click += new System.EventHandler(this.tcInfoCard_Click);
            // 
            // userInfo
            // 
            this.userInfo.Controls.Add(this.dpEdit);
            this.userInfo.Controls.Add(this.dividerPanel5);
            this.userInfo.Controls.Add(this.dividerPanel4);
            this.userInfo.Location = new System.Drawing.Point(4, 21);
            this.userInfo.Name = "userInfo";
            this.userInfo.Padding = new System.Windows.Forms.Padding(3);
            this.userInfo.Size = new System.Drawing.Size(713, 385);
            this.userInfo.TabIndex = 0;
            this.userInfo.Text = "玩家角色资料";
            this.userInfo.UseVisualStyleBackColor = true;
            // 
            // dpEdit
            // 
            this.dpEdit.AllowDrop = true;
            this.dpEdit.BorderSide = System.Windows.Forms.Border3DSide.Top;
            this.dpEdit.Controls.Add(this.btnModiCancel);
            this.dpEdit.Controls.Add(this.btnModiOk);
            this.dpEdit.Controls.Add(this.txtMoney);
            this.dpEdit.Controls.Add(this.txtExp);
            this.dpEdit.Controls.Add(this.cbxLevel);
            this.dpEdit.Controls.Add(this.label8);
            this.dpEdit.Controls.Add(this.label5);
            this.dpEdit.Controls.Add(this.label1);
            this.dpEdit.Controls.Add(this.txtUserNick);
            this.dpEdit.Controls.Add(this.label4);
            this.dpEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpEdit.Location = new System.Drawing.Point(3, 215);
            this.dpEdit.Name = "dividerPanel6";
            this.dpEdit.Size = new System.Drawing.Size(707, 167);
            this.dpEdit.TabIndex = 3;
            // 
            // btnModiCancel
            // 
            this.btnModiCancel.Location = new System.Drawing.Point(154, 117);
            this.btnModiCancel.Name = "btnModiCancel";
            this.btnModiCancel.Size = new System.Drawing.Size(75, 23);
            this.btnModiCancel.TabIndex = 10;
            this.btnModiCancel.Text = "取消";
            this.btnModiCancel.UseVisualStyleBackColor = true;
            this.btnModiCancel.Click += new System.EventHandler(this.btnModiCancel_Click);
            // 
            // btnModiOk
            // 
            this.btnModiOk.Location = new System.Drawing.Point(73, 117);
            this.btnModiOk.Name = "btnModiOk";
            this.btnModiOk.Size = new System.Drawing.Size(75, 23);
            this.btnModiOk.TabIndex = 9;
            this.btnModiOk.Text = "修改";
            this.btnModiOk.UseVisualStyleBackColor = true;
            this.btnModiOk.Click += new System.EventHandler(this.btnModiOk_Click);
            // 
            // txtMoney
            // 
            this.txtMoney.Location = new System.Drawing.Point(73, 90);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(177, 21);
            this.txtMoney.TabIndex = 8;
            this.txtMoney.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMoney_KeyUp);
            // 
            // txtExp
            // 
            this.txtExp.Location = new System.Drawing.Point(73, 63);
            this.txtExp.Name = "txtExp";
            this.txtExp.Size = new System.Drawing.Size(177, 21);
            this.txtExp.TabIndex = 7;
            this.txtExp.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtExp_KeyUp);
            // 
            // cbxLevel
            // 
            this.cbxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLevel.FormattingEnabled = true;
            this.cbxLevel.Location = new System.Drawing.Point(73, 37);
            this.cbxLevel.Name = "cbxLevel";
            this.cbxLevel.Size = new System.Drawing.Size(177, 20);
            this.cbxLevel.TabIndex = 6;
            this.cbxLevel.SelectedIndexChanged += new System.EventHandler(this.cbxLevel_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "金钱：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "等级：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "经验：";
            // 
            // txtUserNick
            // 
            this.txtUserNick.Enabled = false;
            this.txtUserNick.Location = new System.Drawing.Point(73, 10);
            this.txtUserNick.Name = "txtUserNick";
            this.txtUserNick.Size = new System.Drawing.Size(177, 21);
            this.txtUserNick.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "当前角色：";
            // 
            // dividerPanel5
            // 
            this.dividerPanel5.AllowDrop = true;
            this.dividerPanel5.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel5.Controls.Add(this.linkEdit);
            this.dividerPanel5.Controls.Add(this.linkEquipment);
            this.dividerPanel5.Controls.Add(this.label3);
            this.dividerPanel5.Controls.Add(this.label2);
            this.dividerPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel5.Location = new System.Drawing.Point(3, 167);
            this.dividerPanel5.Name = "dividerPanel5";
            this.dividerPanel5.Size = new System.Drawing.Size(707, 48);
            this.dividerPanel5.TabIndex = 2;
            // 
            // linkEdit
            // 
            this.linkEdit.AutoSize = true;
            this.linkEdit.Location = new System.Drawing.Point(346, 24);
            this.linkEdit.Name = "linkEdit";
            this.linkEdit.Size = new System.Drawing.Size(77, 12);
            this.linkEdit.TabIndex = 3;
            this.linkEdit.TabStop = true;
            this.linkEdit.Text = "编辑玩家信息";
            this.linkEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEdit_LinkClicked);
            // 
            // linkEquipment
            // 
            this.linkEquipment.AutoSize = true;
            this.linkEquipment.Location = new System.Drawing.Point(272, 24);
            this.linkEquipment.Name = "linkEquipment";
            this.linkEquipment.Size = new System.Drawing.Size(53, 12);
            this.linkEquipment.TabIndex = 2;
            this.linkEquipment.TabStop = true;
            this.linkEquipment.Text = "身上装备";
            this.linkEquipment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEquipment_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(2, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "提醒：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(341, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "请在上方选定要查看的玩家角色，然后查看角色的　　　　　或";
            // 
            // dividerPanel4
            // 
            this.dividerPanel4.AllowDrop = true;
            this.dividerPanel4.Controls.Add(this.dgPartInfoList);
            this.dividerPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel4.Location = new System.Drawing.Point(3, 3);
            this.dividerPanel4.Name = "dividerPanel4";
            this.dividerPanel4.Size = new System.Drawing.Size(707, 164);
            this.dividerPanel4.TabIndex = 1;
            // 
            // dgPartInfoList
            // 
            this.dgPartInfoList.AllowUserToAddRows = false;
            this.dgPartInfoList.AllowUserToDeleteRows = false;
            this.dgPartInfoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPartInfoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPartInfoList.Location = new System.Drawing.Point(0, 0);
            this.dgPartInfoList.MultiSelect = false;
            this.dgPartInfoList.Name = "dgPartInfoList";
            this.dgPartInfoList.ReadOnly = true;
            this.dgPartInfoList.RowTemplate.Height = 23;
            this.dgPartInfoList.Size = new System.Drawing.Size(707, 164);
            this.dgPartInfoList.TabIndex = 0;
            this.dgPartInfoList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPartInfoList_CellClick);
            // 
            // equipList
            // 
            this.equipList.Controls.Add(this.imgtxtctrl1);
            this.equipList.Controls.Add(this.label9);
            this.equipList.Controls.Add(this.dividerPanel6);
            this.equipList.Controls.Add(this.label7);
            this.equipList.Controls.Add(this.dividerPanel7);
            this.equipList.Location = new System.Drawing.Point(4, 21);
            this.equipList.Name = "equipList";
            this.equipList.Padding = new System.Windows.Forms.Padding(3);
            this.equipList.Size = new System.Drawing.Size(713, 385);
            this.equipList.TabIndex = 1;
            this.equipList.Text = "身上装备";
            this.equipList.UseVisualStyleBackColor = true;
            // 
            // imgtxtctrl1
            // 
            this.imgtxtctrl1.ControlPoint = new System.Drawing.Point(0, 0);
            this.imgtxtctrl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgtxtctrl1.IMG_SRC = ((System.Drawing.Image)(resources.GetObject("imgtxtctrl1.IMG_SRC")));
            this.imgtxtctrl1.ITXT_ForeColor = System.Drawing.Color.DarkRed;
            this.imgtxtctrl1.ITXT_MouseHoverColor = System.Drawing.Color.Red;
            this.imgtxtctrl1.ITXT_TEXT = "删除道具";
            this.imgtxtctrl1.Location = new System.Drawing.Point(350, 54);
            this.imgtxtctrl1.Name = "imgtxtctrl1";
            this.imgtxtctrl1.Size = new System.Drawing.Size(72, 14);
            this.imgtxtctrl1.TabIndex = 5;
            this.imgtxtctrl1.ITC_CLICIK += new ImageTextControl.ITCEventHandler(this.imgtxtctrl1_ITC_CLICIK);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(315, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "操作提示：";
            // 
            // dividerPanel6
            // 
            this.dividerPanel6.AllowDrop = true;
            this.dividerPanel6.BorderSide = System.Windows.Forms.Border3DSide.Right;
            this.dividerPanel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.dividerPanel6.Location = new System.Drawing.Point(293, 3);
            this.dividerPanel6.Name = "dividerPanel6";
            this.dividerPanel6.Size = new System.Drawing.Size(10, 379);
            this.dividerPanel6.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(315, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(341, 36);
            this.label7.TabIndex = 2;
            this.label7.Text = "如果要删除玩家的装备，请先选中列表中的要删除的装备，然后\r\n\r\n点击";
            // 
            // dividerPanel7
            // 
            this.dividerPanel7.AllowDrop = true;
            this.dividerPanel7.Controls.Add(this.dividerPanel9);
            this.dividerPanel7.Controls.Add(this.dividerPanel8);
            this.dividerPanel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.dividerPanel7.Location = new System.Drawing.Point(3, 3);
            this.dividerPanel7.Name = "dividerPanel7";
            this.dividerPanel7.Size = new System.Drawing.Size(290, 379);
            this.dividerPanel7.TabIndex = 1;
            // 
            // dividerPanel9
            // 
            this.dividerPanel9.AllowDrop = true;
            this.dividerPanel9.Controls.Add(this.dgEquipList);
            this.dividerPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel9.Location = new System.Drawing.Point(0, 31);
            this.dividerPanel9.Name = "dividerPanel9";
            this.dividerPanel9.Size = new System.Drawing.Size(290, 348);
            this.dividerPanel9.TabIndex = 2;
            // 
            // dgEquipList
            // 
            this.dgEquipList.AllowUserToAddRows = false;
            this.dgEquipList.AllowUserToDeleteRows = false;
            this.dgEquipList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEquipList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgEquipList.Location = new System.Drawing.Point(0, 0);
            this.dgEquipList.MultiSelect = false;
            this.dgEquipList.Name = "dgEquipList";
            this.dgEquipList.ReadOnly = true;
            this.dgEquipList.RowTemplate.Height = 23;
            this.dgEquipList.Size = new System.Drawing.Size(290, 348);
            this.dgEquipList.TabIndex = 0;
            this.dgEquipList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEquipList_CellClick);
            // 
            // dividerPanel8
            // 
            this.dividerPanel8.AllowDrop = true;
            this.dividerPanel8.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel8.Controls.Add(this.cbxToPageIndex);
            this.dividerPanel8.Controls.Add(this.lblCurrPage);
            this.dividerPanel8.Controls.Add(this.lblPageCount);
            this.dividerPanel8.Controls.Add(this.label10);
            this.dividerPanel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel8.Location = new System.Drawing.Point(0, 0);
            this.dividerPanel8.Name = "dividerPanel8";
            this.dividerPanel8.Size = new System.Drawing.Size(290, 31);
            this.dividerPanel8.TabIndex = 1;
            // 
            // cbxToPageIndex
            // 
            this.cbxToPageIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxToPageIndex.FormattingEnabled = true;
            this.cbxToPageIndex.Location = new System.Drawing.Point(187, 5);
            this.cbxToPageIndex.Name = "cbxToPageIndex";
            this.cbxToPageIndex.Size = new System.Drawing.Size(57, 20);
            this.cbxToPageIndex.TabIndex = 8;
            this.cbxToPageIndex.SelectedIndexChanged += new System.EventHandler(this.cbxToPageIndex_SelectedIndexChanged);
            // 
            // lblCurrPage
            // 
            this.lblCurrPage.AutoSize = true;
            this.lblCurrPage.ForeColor = System.Drawing.Color.Red;
            this.lblCurrPage.Location = new System.Drawing.Point(103, 10);
            this.lblCurrPage.Name = "lblCurrPage";
            this.lblCurrPage.Size = new System.Drawing.Size(11, 12);
            this.lblCurrPage.TabIndex = 7;
            this.lblCurrPage.Text = "1";
            // 
            // lblPageCount
            // 
            this.lblPageCount.AutoSize = true;
            this.lblPageCount.ForeColor = System.Drawing.Color.Red;
            this.lblPageCount.Location = new System.Drawing.Point(17, 10);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(11, 12);
            this.lblPageCount.TabIndex = 6;
            this.lblPageCount.Text = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(-1, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(269, 12);
            this.label10.TabIndex = 5;
            this.label10.Text = "共　　页，当前第　　页，转到第　　　　　　页";
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.groupBox1);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(721, 86);
            this.dividerPanel1.TabIndex = 1;
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 96);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(721, 10);
            this.dividerPanel2.TabIndex = 2;
            // 
            // dividerPanel3
            // 
            this.dividerPanel3.AllowDrop = true;
            this.dividerPanel3.Controls.Add(this.tcInfoCard);
            this.dividerPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel3.Location = new System.Drawing.Point(10, 106);
            this.dividerPanel3.Name = "dividerPanel3";
            this.dividerPanel3.Size = new System.Drawing.Size(721, 410);
            this.dividerPanel3.TabIndex = 3;
            // 
            // UserAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 526);
            this.Controls.Add(this.dividerPanel3);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "UserAbout";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "用户资料查询[劲舞团]";
            this.Load += new System.EventHandler(this.UserAbout_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tcInfoCard.ResumeLayout(false);
            this.userInfo.ResumeLayout(false);
            this.dpEdit.ResumeLayout(false);
            this.dpEdit.PerformLayout();
            this.dividerPanel5.ResumeLayout(false);
            this.dividerPanel5.PerformLayout();
            this.dividerPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPartInfoList)).EndInit();
            this.equipList.ResumeLayout(false);
            this.equipList.PerformLayout();
            this.dividerPanel7.ResumeLayout(false);
            this.dividerPanel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgEquipList)).EndInit();
            this.dividerPanel8.ResumeLayout(false);
            this.dividerPanel8.PerformLayout();
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAccountOrNick;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tcInfoCard;
        private System.Windows.Forms.TabPage userInfo;
        private System.Windows.Forms.TabPage equipList;
        private DividerPanel.DividerPanel dividerPanel1;
        private DividerPanel.DividerPanel dividerPanel2;
        private DividerPanel.DividerPanel dividerPanel3;
        private System.Windows.Forms.DataGridView dgPartInfoList;
        private DividerPanel.DividerPanel dividerPanel4;
        private DividerPanel.DividerPanel dividerPanel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DividerPanel.DividerPanel dpEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxServerIP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkAccount;
        private System.Windows.Forms.CheckBox chkNick;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserNick;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnModiOk;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.TextBox txtExp;
        private System.Windows.Forms.ComboBox cbxLevel;
        private System.Windows.Forms.LinkLabel linkEdit;
        private System.Windows.Forms.LinkLabel linkEquipment;
        private System.Windows.Forms.Button btnModiCancel;
        private DividerPanel.DividerPanel dividerPanel7;
        private System.Windows.Forms.DataGridView dgEquipList;
        private System.Windows.Forms.Label label9;
        private DividerPanel.DividerPanel dividerPanel6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private DividerPanel.DividerPanel dividerPanel9;
        private DividerPanel.DividerPanel dividerPanel8;
        private ImageTextControl.IMGTXTCTRL imgtxtctrl1;
        private System.Windows.Forms.Label lblCurrPage;
        private System.Windows.Forms.Label lblPageCount;
        private System.Windows.Forms.ComboBox cbxToPageIndex;
    }
}