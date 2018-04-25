namespace M_AU
{
    partial class SendSth
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnItemTo = new System.Windows.Forms.Button();
            this.lstItemResult = new System.Windows.Forms.ListBox();
            this.btnItemSearch = new System.Windows.Forms.Button();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstRecvUsers = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.btnAccountTo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lstUserResult = new System.Windows.Forms.ListBox();
            this.chkAccount = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.chkNick = new System.Windows.Forms.CheckBox();
            this.lblAccOrNick = new System.Windows.Forms.Label();
            this.cbxServerIP = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lstSendItem = new System.Windows.Forms.ListView();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.dividerPanel3 = new DividerPanel.DividerPanel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnConfrimToSend = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            this.dividerPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.dividerPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.dividerPanel3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dividerPanel2);
            this.groupBox3.Controls.Add(this.btnItemSearch);
            this.groupBox3.Controls.Add(this.txtItemName);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Location = new System.Drawing.Point(13, 343);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(239, 239);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "道具信息";
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.BorderSide = System.Windows.Forms.Border3DSide.Top;
            this.dividerPanel2.Controls.Add(this.label2);
            this.dividerPanel2.Controls.Add(this.btnItemTo);
            this.dividerPanel2.Controls.Add(this.lstItemResult);
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dividerPanel2.Location = new System.Drawing.Point(3, 89);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.dividerPanel2.Size = new System.Drawing.Size(233, 147);
            this.dividerPanel2.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "查询结果：";
            // 
            // btnItemTo
            // 
            this.btnItemTo.Location = new System.Drawing.Point(121, 120);
            this.btnItemTo.Name = "btnItemTo";
            this.btnItemTo.Size = new System.Drawing.Size(103, 24);
            this.btnItemTo.TabIndex = 1;
            this.btnItemTo.Text = "导入获赠列表";
            this.btnItemTo.UseVisualStyleBackColor = true;
            this.btnItemTo.Click += new System.EventHandler(this.btnItemTo_Click);
            // 
            // lstItemResult
            // 
            this.lstItemResult.FormattingEnabled = true;
            this.lstItemResult.ItemHeight = 12;
            this.lstItemResult.Location = new System.Drawing.Point(7, 27);
            this.lstItemResult.Name = "lstItemResult";
            this.lstItemResult.Size = new System.Drawing.Size(217, 88);
            this.lstItemResult.TabIndex = 0;
            this.lstItemResult.SelectedIndexChanged += new System.EventHandler(this.lstItemResult_SelectedIndexChanged);
            // 
            // btnItemSearch
            // 
            this.btnItemSearch.Location = new System.Drawing.Point(149, 60);
            this.btnItemSearch.Name = "btnItemSearch";
            this.btnItemSearch.Size = new System.Drawing.Size(75, 23);
            this.btnItemSearch.TabIndex = 7;
            this.btnItemSearch.Text = "查询";
            this.btnItemSearch.UseVisualStyleBackColor = true;
            this.btnItemSearch.Click += new System.EventHandler(this.btnItemSearch_Click);
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(10, 34);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(217, 21);
            this.txtItemName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "道具名称：";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(594, 232);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "赠送";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstRecvUsers);
            this.groupBox2.Location = new System.Drawing.Point(258, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(546, 324);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "获赠玩家";
            // 
            // lstRecvUsers
            // 
            this.lstRecvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstRecvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRecvUsers.FullRowSelect = true;
            this.lstRecvUsers.Location = new System.Drawing.Point(3, 17);
            this.lstRecvUsers.MultiSelect = false;
            this.lstRecvUsers.Name = "lstRecvUsers";
            this.lstRecvUsers.Size = new System.Drawing.Size(540, 304);
            this.lstRecvUsers.TabIndex = 0;
            this.lstRecvUsers.UseCompatibleStateImageBehavior = false;
            this.lstRecvUsers.View = System.Windows.Forms.View.Details;
            this.lstRecvUsers.SelectedIndexChanged += new System.EventHandler(this.lstRecvUsers_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "帐号";
            this.columnHeader1.Width = 96;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "昵称";
            this.columnHeader2.Width = 85;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "性别";
            this.columnHeader3.Width = 64;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dividerPanel1);
            this.groupBox1.Controls.Add(this.chkAccount);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtAccount);
            this.groupBox1.Controls.Add(this.chkNick);
            this.groupBox1.Controls.Add(this.lblAccOrNick);
            this.groupBox1.Location = new System.Drawing.Point(13, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 261);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "玩家信息";
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.BorderSide = System.Windows.Forms.Border3DSide.Top;
            this.dividerPanel1.Controls.Add(this.btnAccountTo);
            this.dividerPanel1.Controls.Add(this.label3);
            this.dividerPanel1.Controls.Add(this.lstUserResult);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dividerPanel1.Location = new System.Drawing.Point(3, 113);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(233, 145);
            this.dividerPanel1.TabIndex = 18;
            // 
            // btnAccountTo
            // 
            this.btnAccountTo.Location = new System.Drawing.Point(121, 122);
            this.btnAccountTo.Name = "btnAccountTo";
            this.btnAccountTo.Size = new System.Drawing.Size(103, 20);
            this.btnAccountTo.TabIndex = 6;
            this.btnAccountTo.Text = "导入玩家列表";
            this.btnAccountTo.UseVisualStyleBackColor = true;
            this.btnAccountTo.Click += new System.EventHandler(this.btnAccountTo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "查询结果(玩家信息)：";
            // 
            // lstUserResult
            // 
            this.lstUserResult.FormattingEnabled = true;
            this.lstUserResult.ItemHeight = 12;
            this.lstUserResult.Location = new System.Drawing.Point(7, 34);
            this.lstUserResult.Name = "lstUserResult";
            this.lstUserResult.Size = new System.Drawing.Size(217, 76);
            this.lstUserResult.TabIndex = 0;
            this.lstUserResult.SelectedIndexChanged += new System.EventHandler(this.lstUserResult_SelectedIndexChanged);
            // 
            // chkAccount
            // 
            this.chkAccount.AutoSize = true;
            this.chkAccount.Checked = true;
            this.chkAccount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAccount.Location = new System.Drawing.Point(6, 62);
            this.chkAccount.Name = "chkAccount";
            this.chkAccount.Size = new System.Drawing.Size(72, 16);
            this.chkAccount.TabIndex = 16;
            this.chkAccount.Text = "玩家帐号";
            this.chkAccount.UseVisualStyleBackColor = true;
            this.chkAccount.Click += new System.EventHandler(this.chkAccount_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(156, 84);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(6, 35);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(219, 21);
            this.txtAccount.TabIndex = 11;
            // 
            // chkNick
            // 
            this.chkNick.AutoSize = true;
            this.chkNick.Enabled = false;
            this.chkNick.Location = new System.Drawing.Point(84, 62);
            this.chkNick.Name = "chkNick";
            this.chkNick.Size = new System.Drawing.Size(72, 16);
            this.chkNick.TabIndex = 17;
            this.chkNick.Text = "玩家昵称";
            this.chkNick.UseVisualStyleBackColor = true;
            this.chkNick.Click += new System.EventHandler(this.chkNick_Click);
            // 
            // lblAccOrNick
            // 
            this.lblAccOrNick.AutoSize = true;
            this.lblAccOrNick.Location = new System.Drawing.Point(6, 19);
            this.lblAccOrNick.Name = "lblAccOrNick";
            this.lblAccOrNick.Size = new System.Drawing.Size(65, 12);
            this.lblAccOrNick.TabIndex = 10;
            this.lblAccOrNick.Text = "玩家帐号：";
            // 
            // cbxServerIP
            // 
            this.cbxServerIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServerIP.FormattingEnabled = true;
            this.cbxServerIP.Location = new System.Drawing.Point(6, 20);
            this.cbxServerIP.Name = "cbxServerIP";
            this.cbxServerIP.Size = new System.Drawing.Size(219, 20);
            this.cbxServerIP.TabIndex = 15;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lstSendItem);
            this.groupBox4.Location = new System.Drawing.Point(258, 343);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(546, 239);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "赠送物品列表";
            // 
            // lstSendItem
            // 
            this.lstSendItem.CheckBoxes = true;
            this.lstSendItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader6});
            this.lstSendItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSendItem.FullRowSelect = true;
            this.lstSendItem.Location = new System.Drawing.Point(3, 17);
            this.lstSendItem.MultiSelect = false;
            this.lstSendItem.Name = "lstSendItem";
            this.lstSendItem.Size = new System.Drawing.Size(540, 219);
            this.lstSendItem.TabIndex = 0;
            this.lstSendItem.UseCompatibleStateImageBehavior = false;
            this.lstSendItem.View = System.Windows.Forms.View.Details;
            this.lstSendItem.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstSendItem_ItemCheck);
            this.lstSendItem.Click += new System.EventHandler(this.lstSendItem_Click);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "道具名称";
            this.columnHeader7.Width = 369;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "性别要求";
            this.columnHeader6.Width = 123;
            // 
            // dividerPanel3
            // 
            this.dividerPanel3.AllowDrop = true;
            this.dividerPanel3.BorderSide = System.Windows.Forms.Border3DSide.Top;
            this.dividerPanel3.Controls.Add(this.btnReset);
            this.dividerPanel3.Controls.Add(this.btnConfrimToSend);
            this.dividerPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dividerPanel3.Location = new System.Drawing.Point(10, 601);
            this.dividerPanel3.Name = "dividerPanel3";
            this.dividerPanel3.Size = new System.Drawing.Size(797, 31);
            this.dividerPanel3.TabIndex = 25;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(84, 8);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "重新设置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnConfrimToSend
            // 
            this.btnConfrimToSend.Location = new System.Drawing.Point(3, 8);
            this.btnConfrimToSend.Name = "btnConfrimToSend";
            this.btnConfrimToSend.Size = new System.Drawing.Size(75, 23);
            this.btnConfrimToSend.TabIndex = 0;
            this.btnConfrimToSend.Text = "赠送";
            this.btnConfrimToSend.UseVisualStyleBackColor = true;
            this.btnConfrimToSend.Click += new System.EventHandler(this.btnConfrimToSend_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbxServerIP);
            this.groupBox5.Location = new System.Drawing.Point(13, 13);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(239, 57);
            this.groupBox5.TabIndex = 26;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "服务器：";
            // 
            // SendSth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 642);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.dividerPanel3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SendSth";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "物品发送[劲舞团]";
            this.Load += new System.EventHandler(this.SendSth_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.dividerPanel2.ResumeLayout(false);
            this.dividerPanel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.dividerPanel3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstUserResult;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAccount;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.CheckBox chkNick;
        private System.Windows.Forms.Label lblAccOrNick;
        private System.Windows.Forms.ComboBox cbxServerIP;
        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.Button btnAccountTo;
        private System.Windows.Forms.ListView lstRecvUsers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView lstSendItem;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private DividerPanel.DividerPanel dividerPanel2;
        private System.Windows.Forms.Button btnItemSearch;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstItemResult;
        private System.Windows.Forms.Button btnItemTo;
        private DividerPanel.DividerPanel dividerPanel3;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnConfrimToSend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ColumnHeader columnHeader6;

    }
}