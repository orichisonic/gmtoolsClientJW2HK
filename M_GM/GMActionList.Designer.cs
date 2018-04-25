namespace M_GM
{
    partial class GMActionList
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
            this.userID = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.beginDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewSortOrder = new System.Windows.Forms.ListView();
            this.id = new System.Windows.Forms.ColumnHeader();
            this.account = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.char_name = new System.Windows.Forms.ColumnHeader();
            this.type_id = new System.Windows.Forms.ColumnHeader();
            this.level = new System.Windows.Forms.ColumnHeader();
            this.dividerPanel3 = new DividerPanel.DividerPanel();
            this.ITC_Next = new ImageTextControl.IMGTXTCTRL();
            this.ITC_Prev = new ImageTextControl.IMGTXTCTRL();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.dividerPanel4 = new DividerPanel.DividerPanel();
            this.dividerPanel3.SuspendLayout();
            this.dividerPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // userID
            // 
            this.userID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userID.FormattingEnabled = true;
            this.userID.Location = new System.Drawing.Point(77, 62);
            this.userID.Name = "userID";
            this.userID.Size = new System.Drawing.Size(142, 20);
            this.userID.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(241, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 24);
            this.button1.TabIndex = 17;
            this.button1.Text = "查看";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // endDate
            // 
            this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDate.Location = new System.Drawing.Point(77, 35);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(142, 21);
            this.endDate.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "结束日期：";
            // 
            // beginDate
            // 
            this.beginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.beginDate.Location = new System.Drawing.Point(77, 8);
            this.beginDate.Name = "beginDate";
            this.beginDate.Size = new System.Drawing.Size(142, 21);
            this.beginDate.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "开始日期：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "GM帐号：";
            // 
            // listViewSortOrder
            // 
            this.listViewSortOrder.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewSortOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.account,
            this.columnHeader1,
            this.char_name,
            this.type_id,
            this.level});
            this.listViewSortOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSortOrder.FullRowSelect = true;
            this.listViewSortOrder.GridLines = true;
            this.listViewSortOrder.Location = new System.Drawing.Point(2, 2);
            this.listViewSortOrder.MultiSelect = false;
            this.listViewSortOrder.Name = "listViewSortOrder";
            this.listViewSortOrder.Size = new System.Drawing.Size(618, 252);
            this.listViewSortOrder.TabIndex = 9;
            this.listViewSortOrder.UseCompatibleStateImageBehavior = false;
            this.listViewSortOrder.View = System.Windows.Forms.View.Details;
            // 
            // id
            // 
            this.id.Text = "编号";
            this.id.Width = 45;
            // 
            // account
            // 
            this.account.Text = "GM姓名";
            this.account.Width = 102;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "游戏名称";
            this.columnHeader1.Width = 108;
            // 
            // char_name
            // 
            this.char_name.Text = "服务器";
            this.char_name.Width = 114;
            // 
            // type_id
            // 
            this.type_id.Text = "操作日期";
            this.type_id.Width = 173;
            // 
            // level
            // 
            this.level.Text = "操作内容";
            this.level.Width = 300;
            // 
            // dividerPanel3
            // 
            this.dividerPanel3.AllowDrop = true;
            this.dividerPanel3.Controls.Add(this.ITC_Next);
            this.dividerPanel3.Controls.Add(this.ITC_Prev);
            this.dividerPanel3.Controls.Add(this.userID);
            this.dividerPanel3.Controls.Add(this.button1);
            this.dividerPanel3.Controls.Add(this.label1);
            this.dividerPanel3.Controls.Add(this.endDate);
            this.dividerPanel3.Controls.Add(this.label2);
            this.dividerPanel3.Controls.Add(this.label4);
            this.dividerPanel3.Controls.Add(this.beginDate);
            this.dividerPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel3.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel3.Name = "dividerPanel3";
            this.dividerPanel3.Padding = new System.Windows.Forms.Padding(5);
            this.dividerPanel3.Size = new System.Drawing.Size(622, 96);
            this.dividerPanel3.TabIndex = 0;
            // 
            // ITC_Next
            // 
            this.ITC_Next.ControlPoint = new System.Drawing.Point(0, 0);
            this.ITC_Next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ITC_Next.IMG_SRC = null;
            this.ITC_Next.ITXT_ForeColor = System.Drawing.Color.Black;
            this.ITC_Next.ITXT_MouseHoverColor = System.Drawing.Color.Red;
            this.ITC_Next.ITXT_TEXT = "下一页";
            this.ITC_Next.Location = new System.Drawing.Point(386, 66);
            this.ITC_Next.Name = "ITC_Next";
            this.ITC_Next.Size = new System.Drawing.Size(64, 18);
            this.ITC_Next.TabIndex = 20;
            this.ITC_Next.ITC_CLICIK += new ImageTextControl.ITCEventHandler(this.ITC_Next_ITC_CLICIK);
            // 
            // ITC_Prev
            // 
            this.ITC_Prev.ControlPoint = new System.Drawing.Point(0, 0);
            this.ITC_Prev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ITC_Prev.IMG_SRC = null;
            this.ITC_Prev.ITXT_ForeColor = System.Drawing.Color.Black;
            this.ITC_Prev.ITXT_MouseHoverColor = System.Drawing.Color.Red;
            this.ITC_Prev.ITXT_TEXT = "上一页";
            this.ITC_Prev.Location = new System.Drawing.Point(316, 66);
            this.ITC_Prev.Name = "ITC_Prev";
            this.ITC_Prev.Size = new System.Drawing.Size(64, 18);
            this.ITC_Prev.TabIndex = 19;
            this.ITC_Prev.ITC_CLICIK += new ImageTextControl.ITCEventHandler(this.ITC_Prev_ITC_CLICIK);
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 106);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(622, 10);
            this.dividerPanel1.TabIndex = 3;
            // 
            // dividerPanel4
            // 
            this.dividerPanel4.AllowDrop = true;
            this.dividerPanel4.Controls.Add(this.listViewSortOrder);
            this.dividerPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel4.Location = new System.Drawing.Point(10, 116);
            this.dividerPanel4.Name = "dividerPanel4";
            this.dividerPanel4.Padding = new System.Windows.Forms.Padding(2);
            this.dividerPanel4.Size = new System.Drawing.Size(622, 256);
            this.dividerPanel4.TabIndex = 4;
            // 
            // GMActionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 382);
            this.Controls.Add(this.dividerPanel4);
            this.Controls.Add(this.dividerPanel1);
            this.Controls.Add(this.dividerPanel3);
            this.Name = "GMActionList";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "GM 操作日志";
            this.Load += new System.EventHandler(this.GMActionList_Load);
            this.dividerPanel3.ResumeLayout(false);
            this.dividerPanel3.PerformLayout();
            this.dividerPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker beginDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listViewSortOrder;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader account;
        private System.Windows.Forms.ColumnHeader char_name;
        private System.Windows.Forms.ColumnHeader type_id;
        private System.Windows.Forms.ColumnHeader level;
        private System.Windows.Forms.ComboBox userID;
        private DividerPanel.DividerPanel dividerPanel3;
        private DividerPanel.DividerPanel dividerPanel1;
        private DividerPanel.DividerPanel dividerPanel4;
        private ImageTextControl.IMGTXTCTRL ITC_Next;
        private ImageTextControl.IMGTXTCTRL ITC_Prev;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}