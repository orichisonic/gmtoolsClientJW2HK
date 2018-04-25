namespace M_SDO
{
    partial class RateEdit
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
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cbxServerIP = new System.Windows.Forms.ToolStripComboBox();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.txtItemName = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrevPage = new System.Windows.Forms.ToolStripButton();
            this.btnNextPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cbxToPageIndex = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsLblText = new System.Windows.Forms.ToolStripLabel();
            this.dpDgContainer = new DividerPanel.DividerPanel();
            this.dgInfoList = new System.Windows.Forms.DataGridView();
            this.dpEditContainer = new DividerPanel.DividerPanel();
            this.rbtSexGirl = new System.Windows.Forms.RadioButton();
            this.rbtSexBoy = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.btnEditCancel = new System.Windows.Forms.Button();
            this.btnEditOk = new System.Windows.Forms.Button();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTimes = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dividerPanel5 = new DividerPanel.DividerPanel();
            this.cbxItems = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxSClass = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxBClass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dividerPanel3 = new DividerPanel.DividerPanel();
            this.dividerPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.dpDgContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInfoList)).BeginInit();
            this.dpEditContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel1.Controls.Add(this.toolStrip1);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(813, 35);
            this.dividerPanel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbxServerIP,
            this.btnSearch,
            this.toolStripSeparator4,
            this.toolStripLabel3,
            this.txtItemName,
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.btnAdd,
            this.btnEdit,
            this.btnDel,
            this.toolStripSeparator2,
            this.btnPrevPage,
            this.btnNextPage,
            this.toolStripLabel1,
            this.cbxToPageIndex,
            this.toolStripLabel2,
            this.toolStripSeparator3,
            this.tsLblText});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(813, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cbxServerIP
            // 
            this.cbxServerIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServerIP.Items.AddRange(new object[] {
            "服装",
            "道具"});
            this.cbxServerIP.Name = "cbxServerIP";
            this.cbxServerIP.Size = new System.Drawing.Size(121, 25);
            // 
            // btnSearch
            // 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.Image = global::M_SDO.Properties.Resources.searchbutton1;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(23, 22);
            this.btnSearch.Text = "查看";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(115, 22);
            this.toolStripLabel3.Text = "搜索（道具名称）：";
            // 
            // txtItemName
            // 
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::M_SDO.Properties.Resources.searchbutton1;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = global::M_SDO.Properties.Resources.add;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 22);
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Image = global::M_SDO.Properties.Resources.edit;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(23, 22);
            this.btnEdit.Text = "编辑";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDel.Image = global::M_SDO.Properties.Resources.del;
            this.btnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(23, 22);
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrevPage.Image = global::M_SDO.Properties.Resources.prev_1;
            this.btnPrevPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(23, 22);
            this.btnPrevPage.Text = "上一页";
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNextPage.Image = global::M_SDO.Properties.Resources.next_1;
            this.btnNextPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(23, 22);
            this.btnNextPage.Text = "下一页";
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(43, 22);
            this.toolStripLabel1.Text = "转到第";
            // 
            // cbxToPageIndex
            // 
            this.cbxToPageIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxToPageIndex.Name = "cbxToPageIndex";
            this.cbxToPageIndex.Size = new System.Drawing.Size(121, 25);
            this.cbxToPageIndex.SelectedIndexChanged += new System.EventHandler(this.cbxToPageIndex_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(19, 22);
            this.toolStripLabel2.Text = "页";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsLblText
            // 
            this.tsLblText.Name = "tsLblText";
            this.tsLblText.Size = new System.Drawing.Size(78, 22);
            this.tsLblText.Text = "toolStripLabel1";
            // 
            // dpDgContainer
            // 
            this.dpDgContainer.AllowDrop = true;
            this.dpDgContainer.Controls.Add(this.dgInfoList);
            this.dpDgContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.dpDgContainer.Location = new System.Drawing.Point(10, 45);
            this.dpDgContainer.Name = "dividerPanel2";
            this.dpDgContainer.Size = new System.Drawing.Size(813, 258);
            this.dpDgContainer.TabIndex = 1;
            // 
            // dgInfoList
            // 
            this.dgInfoList.AllowUserToAddRows = false;
            this.dgInfoList.AllowUserToDeleteRows = false;
            this.dgInfoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInfoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgInfoList.Location = new System.Drawing.Point(0, 0);
            this.dgInfoList.MultiSelect = false;
            this.dgInfoList.Name = "dgInfoList";
            this.dgInfoList.ReadOnly = true;
            this.dgInfoList.RowTemplate.Height = 23;
            this.dgInfoList.Size = new System.Drawing.Size(813, 258);
            this.dgInfoList.TabIndex = 0;
            this.dgInfoList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgInfoList_CellClick);
            this.dgInfoList.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgInfoList_ColumnHeaderMouseClick);
            this.dgInfoList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgInfoList_MouseUp);
            // 
            // dpEditContainer
            // 
            this.dpEditContainer.AllowDrop = true;
            this.dpEditContainer.Controls.Add(this.rbtSexGirl);
            this.dpEditContainer.Controls.Add(this.rbtSexBoy);
            this.dpEditContainer.Controls.Add(this.label7);
            this.dpEditContainer.Controls.Add(this.btnEditCancel);
            this.dpEditContainer.Controls.Add(this.btnEditOk);
            this.dpEditContainer.Controls.Add(this.txtDays);
            this.dpEditContainer.Controls.Add(this.label6);
            this.dpEditContainer.Controls.Add(this.txtTimes);
            this.dpEditContainer.Controls.Add(this.label5);
            this.dpEditContainer.Controls.Add(this.txtRate);
            this.dpEditContainer.Controls.Add(this.label4);
            this.dpEditContainer.Controls.Add(this.dividerPanel5);
            this.dpEditContainer.Controls.Add(this.cbxItems);
            this.dpEditContainer.Controls.Add(this.label3);
            this.dpEditContainer.Controls.Add(this.cbxSClass);
            this.dpEditContainer.Controls.Add(this.label2);
            this.dpEditContainer.Controls.Add(this.cbxBClass);
            this.dpEditContainer.Controls.Add(this.label1);
            this.dpEditContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpEditContainer.Location = new System.Drawing.Point(10, 313);
            this.dpEditContainer.Name = "dividerPanel4";
            this.dpEditContainer.Size = new System.Drawing.Size(813, 198);
            this.dpEditContainer.TabIndex = 3;
            // 
            // rbtSexGirl
            // 
            this.rbtSexGirl.AutoSize = true;
            this.rbtSexGirl.Location = new System.Drawing.Point(55, 78);
            this.rbtSexGirl.Name = "rbtSexGirl";
            this.rbtSexGirl.Size = new System.Drawing.Size(35, 16);
            this.rbtSexGirl.TabIndex = 17;
            this.rbtSexGirl.TabStop = true;
            this.rbtSexGirl.Tag = "0";
            this.rbtSexGirl.Text = "女";
            this.rbtSexGirl.UseVisualStyleBackColor = true;
            this.rbtSexGirl.Click += new System.EventHandler(this.rbtSexGirl_Click);
            // 
            // rbtSexBoy
            // 
            this.rbtSexBoy.AutoSize = true;
            this.rbtSexBoy.Checked = true;
            this.rbtSexBoy.Location = new System.Drawing.Point(14, 78);
            this.rbtSexBoy.Name = "rbtSexBoy";
            this.rbtSexBoy.Size = new System.Drawing.Size(35, 16);
            this.rbtSexBoy.TabIndex = 16;
            this.rbtSexBoy.TabStop = true;
            this.rbtSexBoy.Tag = "1";
            this.rbtSexBoy.Text = "男";
            this.rbtSexBoy.UseVisualStyleBackColor = true;
            this.rbtSexBoy.Click += new System.EventHandler(this.rbtSexBoy_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "性别选择：";
            // 
            // btnEditCancel
            // 
            this.btnEditCancel.Location = new System.Drawing.Point(364, 58);
            this.btnEditCancel.Name = "btnEditCancel";
            this.btnEditCancel.Size = new System.Drawing.Size(75, 23);
            this.btnEditCancel.TabIndex = 14;
            this.btnEditCancel.Text = "取消";
            this.btnEditCancel.UseVisualStyleBackColor = true;
            this.btnEditCancel.Click += new System.EventHandler(this.btnEditCancel_Click);
            // 
            // btnEditOk
            // 
            this.btnEditOk.Location = new System.Drawing.Point(364, 26);
            this.btnEditOk.Name = "btnEditOk";
            this.btnEditOk.Size = new System.Drawing.Size(75, 23);
            this.btnEditOk.TabIndex = 13;
            this.btnEditOk.Text = "确定";
            this.btnEditOk.UseVisualStyleBackColor = true;
            this.btnEditOk.Click += new System.EventHandler(this.btnEditOk_Click);
            // 
            // txtDays
            // 
            this.txtDays.Location = new System.Drawing.Point(181, 116);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(157, 21);
            this.txtDays.TabIndex = 12;
            this.txtDays.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDays_KeyUp);
            this.txtDays.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtDays_MouseUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(179, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "期限(天)：";
            // 
            // txtTimes
            // 
            this.txtTimes.Location = new System.Drawing.Point(181, 73);
            this.txtTimes.Name = "txtTimes";
            this.txtTimes.Size = new System.Drawing.Size(157, 21);
            this.txtTimes.TabIndex = 10;
            this.txtTimes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTimes_KeyUp);
            this.txtTimes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtTimes_MouseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "使用次数：";
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(181, 29);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(157, 21);
            this.txtRate.TabIndex = 8;
            this.txtRate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRate_KeyUp);
            this.txtRate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtRate_MouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "比率值(0-1000)：";
            // 
            // dividerPanel5
            // 
            this.dividerPanel5.AllowDrop = true;
            this.dividerPanel5.BorderSide = System.Windows.Forms.Border3DSide.Left;
            this.dividerPanel5.Location = new System.Drawing.Point(164, 14);
            this.dividerPanel5.Name = "dividerPanel5";
            this.dividerPanel5.Size = new System.Drawing.Size(10, 167);
            this.dividerPanel5.TabIndex = 6;
            // 
            // cbxItems
            // 
            this.cbxItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxItems.FormattingEnabled = true;
            this.cbxItems.Location = new System.Drawing.Point(14, 161);
            this.cbxItems.Name = "cbxItems";
            this.cbxItems.Size = new System.Drawing.Size(138, 20);
            this.cbxItems.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "物品名称：";
            // 
            // cbxSClass
            // 
            this.cbxSClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSClass.FormattingEnabled = true;
            this.cbxSClass.Location = new System.Drawing.Point(14, 117);
            this.cbxSClass.Name = "cbxSClass";
            this.cbxSClass.Size = new System.Drawing.Size(138, 20);
            this.cbxSClass.TabIndex = 3;
            this.cbxSClass.SelectedIndexChanged += new System.EventHandler(this.cbxSClass_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "小类：";
            // 
            // cbxBClass
            // 
            this.cbxBClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBClass.FormattingEnabled = true;
            this.cbxBClass.Location = new System.Drawing.Point(14, 29);
            this.cbxBClass.Name = "cbxBClass";
            this.cbxBClass.Size = new System.Drawing.Size(138, 20);
            this.cbxBClass.TabIndex = 1;
            this.cbxBClass.SelectedIndexChanged += new System.EventHandler(this.cbxBClass_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "大类：";
            // 
            // dividerPanel3
            // 
            this.dividerPanel3.AllowDrop = true;
            this.dividerPanel3.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel3.Location = new System.Drawing.Point(10, 303);
            this.dividerPanel3.Name = "dividerPanel3";
            this.dividerPanel3.Size = new System.Drawing.Size(813, 10);
            this.dividerPanel3.TabIndex = 2;
            // 
            // RateEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 521);
            this.Controls.Add(this.dpEditContainer);
            this.Controls.Add(this.dividerPanel3);
            this.Controls.Add(this.dpDgContainer);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "RateEdit";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "道具获取比率设置";
            this.Load += new System.EventHandler(this.RateEdit_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.dpDgContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgInfoList)).EndInit();
            this.dpEditContainer.ResumeLayout(false);
            this.dpEditContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DividerPanel.DividerPanel dividerPanel1;
        private DividerPanel.DividerPanel dpDgContainer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cbxServerIP;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.DataGridView dgInfoList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private DividerPanel.DividerPanel dpEditContainer;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDel;
        private System.Windows.Forms.ComboBox cbxItems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxSClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxBClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private DividerPanel.DividerPanel dividerPanel5;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTimes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnPrevPage;
        private System.Windows.Forms.ToolStripButton btnNextPage;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.Button btnEditCancel;
        private System.Windows.Forms.Button btnEditOk;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel tsLblText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbtSexGirl;
        private System.Windows.Forms.RadioButton rbtSexBoy;
        private System.Windows.Forms.ToolStripComboBox cbxToPageIndex;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripTextBox txtItemName;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private DividerPanel.DividerPanel dividerPanel3;
    }
}