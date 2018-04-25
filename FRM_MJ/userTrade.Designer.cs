namespace FRM_MJ
{
    partial class userTrade
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
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.beginDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.serverIP = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.userName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewSortOrder = new System.Windows.Forms.ListView();
            this.id = new System.Windows.Forms.ColumnHeader();
            this.account = new System.Windows.Forms.ColumnHeader();
            this.char_name = new System.Windows.Forms.ColumnHeader();
            this.type_id = new System.Windows.Forms.ColumnHeader();
            this.level = new System.Windows.Forms.ColumnHeader();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.dividerPanel3 = new DividerPanel.DividerPanel();
            this.dividerPanel1.SuspendLayout();
            this.dividerPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(332, 36);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(168, 21);
            this.endDate.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "结束日期：";
            // 
            // beginDate
            // 
            this.beginDate.Location = new System.Drawing.Point(88, 36);
            this.beginDate.Name = "beginDate";
            this.beginDate.Size = new System.Drawing.Size(149, 21);
            this.beginDate.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "开始日期：";
            // 
            // serverIP
            // 
            this.serverIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serverIP.FormattingEnabled = true;
            this.serverIP.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.serverIP.Location = new System.Drawing.Point(86, 10);
            this.serverIP.Name = "serverIP";
            this.serverIP.Size = new System.Drawing.Size(151, 20);
            this.serverIP.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "区域：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(526, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "查看";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(331, 9);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(169, 21);
            this.userName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "帐号：";
            // 
            // listViewSortOrder
            // 
            this.listViewSortOrder.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewSortOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.account,
            this.char_name,
            this.type_id,
            this.level});
            this.listViewSortOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSortOrder.FullRowSelect = true;
            this.listViewSortOrder.GridLines = true;
            this.listViewSortOrder.Location = new System.Drawing.Point(2, 2);
            this.listViewSortOrder.MultiSelect = false;
            this.listViewSortOrder.Name = "listViewSortOrder";
            this.listViewSortOrder.Size = new System.Drawing.Size(689, 276);
            this.listViewSortOrder.TabIndex = 8;
            this.listViewSortOrder.UseCompatibleStateImageBehavior = false;
            this.listViewSortOrder.View = System.Windows.Forms.View.Details;
            // 
            // id
            // 
            this.id.Text = "编号";
            this.id.Width = 49;
            // 
            // account
            // 
            this.account.Text = "帐号";
            // 
            // char_name
            // 
            this.char_name.Text = "角色名";
            this.char_name.Width = 108;
            // 
            // type_id
            // 
            this.type_id.Text = "操作内容";
            // 
            // level
            // 
            this.level.Text = "操作日期";
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.endDate);
            this.dividerPanel1.Controls.Add(this.userName);
            this.dividerPanel1.Controls.Add(this.label4);
            this.dividerPanel1.Controls.Add(this.label1);
            this.dividerPanel1.Controls.Add(this.beginDate);
            this.dividerPanel1.Controls.Add(this.button1);
            this.dividerPanel1.Controls.Add(this.label2);
            this.dividerPanel1.Controls.Add(this.label3);
            this.dividerPanel1.Controls.Add(this.serverIP);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(693, 78);
            this.dividerPanel1.TabIndex = 2;
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 88);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(693, 10);
            this.dividerPanel2.TabIndex = 3;
            // 
            // dividerPanel3
            // 
            this.dividerPanel3.AllowDrop = true;
            this.dividerPanel3.Controls.Add(this.listViewSortOrder);
            this.dividerPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel3.Location = new System.Drawing.Point(10, 98);
            this.dividerPanel3.Name = "dividerPanel3";
            this.dividerPanel3.Padding = new System.Windows.Forms.Padding(2);
            this.dividerPanel3.Size = new System.Drawing.Size(693, 280);
            this.dividerPanel3.TabIndex = 4;
            // 
            // userTrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 388);
            this.Controls.Add(this.dividerPanel3);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "userTrade";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "玩家操作日志";
            this.Load += new System.EventHandler(this.userTrade_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel1.PerformLayout();
            this.dividerPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.ListView listViewSortOrder;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader account;
        private System.Windows.Forms.ColumnHeader char_name;
        private System.Windows.Forms.ColumnHeader type_id;
        private System.Windows.Forms.ColumnHeader level;
        private System.Windows.Forms.ComboBox serverIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker beginDate;
        private System.Windows.Forms.Label label2;
        private DividerPanel.DividerPanel dividerPanel1;
        private DividerPanel.DividerPanel dividerPanel2;
        private DividerPanel.DividerPanel dividerPanel3;
    }
}