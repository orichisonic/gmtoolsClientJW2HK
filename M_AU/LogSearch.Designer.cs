namespace M_AU
{
    partial class LogSearch
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
            this.chkTrade = new System.Windows.Forms.CheckBox();
            this.chkConsume = new System.Windows.Forms.CheckBox();
            this.lblAccountOrNick = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.cbxServerIP = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.beginDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.chkRecv = new System.Windows.Forms.CheckBox();
            this.chkSend = new System.Windows.Forms.CheckBox();
            this.chkAccount = new System.Windows.Forms.CheckBox();
            this.chkNick = new System.Windows.Forms.CheckBox();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.lblPaidAll = new System.Windows.Forms.Label();
            this.cbxToPageIndex = new System.Windows.Forms.ComboBox();
            this.lblCurrPage = new System.Windows.Forms.Label();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.lblTextDes = new System.Windows.Forms.Label();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.gbSendRecv = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dpCase = new DividerPanel.DividerPanel();
            this.dgInfoList = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.dividerPanel2.SuspendLayout();
            this.dividerPanel1.SuspendLayout();
            this.gbSendRecv.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.dpCase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInfoList)).BeginInit();
            this.SuspendLayout();
            // 
            // chkTrade
            // 
            this.chkTrade.AutoSize = true;
            this.chkTrade.Checked = true;
            this.chkTrade.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrade.Location = new System.Drawing.Point(6, 20);
            this.chkTrade.Name = "chkTrade";
            this.chkTrade.Size = new System.Drawing.Size(96, 16);
            this.chkTrade.TabIndex = 0;
            this.chkTrade.Text = "玩家交易记录";
            this.chkTrade.UseVisualStyleBackColor = true;
            this.chkTrade.Click += new System.EventHandler(this.chkTrade_Click);
            // 
            // chkConsume
            // 
            this.chkConsume.AutoSize = true;
            this.chkConsume.Location = new System.Drawing.Point(6, 44);
            this.chkConsume.Name = "chkConsume";
            this.chkConsume.Size = new System.Drawing.Size(96, 16);
            this.chkConsume.TabIndex = 1;
            this.chkConsume.Text = "玩家消费记录";
            this.chkConsume.UseVisualStyleBackColor = true;
            this.chkConsume.Click += new System.EventHandler(this.chkConsume_Click);
            // 
            // lblAccountOrNick
            // 
            this.lblAccountOrNick.AutoSize = true;
            this.lblAccountOrNick.Location = new System.Drawing.Point(6, 145);
            this.lblAccountOrNick.Name = "lblAccountOrNick";
            this.lblAccountOrNick.Size = new System.Drawing.Size(65, 12);
            this.lblAccountOrNick.TabIndex = 2;
            this.lblAccountOrNick.Text = "玩家帐号：";
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(8, 160);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(214, 21);
            this.txtAccount.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(8, 191);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(89, 191);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.endDate);
            this.groupBox1.Controls.Add(this.cbxServerIP);
            this.groupBox1.Controls.Add(this.txtAccount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.beginDate);
            this.groupBox1.Controls.Add(this.lblAccountOrNick);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 231);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "交易/消费记录查询";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "服务器：";
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(8, 117);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(214, 21);
            this.endDate.TabIndex = 14;
            // 
            // cbxServerIP
            // 
            this.cbxServerIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServerIP.FormattingEnabled = true;
            this.cbxServerIP.Location = new System.Drawing.Point(8, 32);
            this.cbxServerIP.Name = "cbxServerIP";
            this.cbxServerIP.Size = new System.Drawing.Size(214, 20);
            this.cbxServerIP.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "开始日期：";
            // 
            // beginDate
            // 
            this.beginDate.Location = new System.Drawing.Point(8, 73);
            this.beginDate.Name = "beginDate";
            this.beginDate.Size = new System.Drawing.Size(214, 21);
            this.beginDate.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "结束日期：";
            // 
            // chkRecv
            // 
            this.chkRecv.AutoSize = true;
            this.chkRecv.Location = new System.Drawing.Point(7, 43);
            this.chkRecv.Name = "chkRecv";
            this.chkRecv.Size = new System.Drawing.Size(60, 16);
            this.chkRecv.TabIndex = 15;
            this.chkRecv.Text = "接受人";
            this.chkRecv.UseVisualStyleBackColor = true;
            this.chkRecv.Click += new System.EventHandler(this.chkRecv_Click);
            // 
            // chkSend
            // 
            this.chkSend.AutoSize = true;
            this.chkSend.Checked = true;
            this.chkSend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSend.Location = new System.Drawing.Point(7, 20);
            this.chkSend.Name = "chkSend";
            this.chkSend.Size = new System.Drawing.Size(60, 16);
            this.chkSend.TabIndex = 10;
            this.chkSend.Text = "发送人";
            this.chkSend.UseVisualStyleBackColor = true;
            this.chkSend.Click += new System.EventHandler(this.chkSend_Click);
            // 
            // chkAccount
            // 
            this.chkAccount.AutoSize = true;
            this.chkAccount.Checked = true;
            this.chkAccount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAccount.Location = new System.Drawing.Point(7, 19);
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
            this.chkNick.Location = new System.Drawing.Point(6, 41);
            this.chkNick.Name = "chkNick";
            this.chkNick.Size = new System.Drawing.Size(72, 16);
            this.chkNick.TabIndex = 9;
            this.chkNick.Text = "玩家昵称";
            this.chkNick.UseVisualStyleBackColor = true;
            this.chkNick.Click += new System.EventHandler(this.chkNick_Click);
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Controls.Add(this.lblPaidAll);
            this.dividerPanel2.Controls.Add(this.cbxToPageIndex);
            this.dividerPanel2.Controls.Add(this.lblCurrPage);
            this.dividerPanel2.Controls.Add(this.lblPageCount);
            this.dividerPanel2.Controls.Add(this.lblTextDes);
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 241);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(699, 27);
            this.dividerPanel2.TabIndex = 10;
            // 
            // lblPaidAll
            // 
            this.lblPaidAll.AutoSize = true;
            this.lblPaidAll.Location = new System.Drawing.Point(286, 9);
            this.lblPaidAll.Name = "lblPaidAll";
            this.lblPaidAll.Size = new System.Drawing.Size(0, 12);
            this.lblPaidAll.TabIndex = 17;
            // 
            // cbxToPageIndex
            // 
            this.cbxToPageIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxToPageIndex.FormattingEnabled = true;
            this.cbxToPageIndex.Location = new System.Drawing.Point(183, 6);
            this.cbxToPageIndex.Name = "cbxToPageIndex";
            this.cbxToPageIndex.Size = new System.Drawing.Size(66, 20);
            this.cbxToPageIndex.TabIndex = 16;
            this.cbxToPageIndex.SelectedIndexChanged += new System.EventHandler(this.cbxToPageIndex_SelectedIndexChanged);
            // 
            // lblCurrPage
            // 
            this.lblCurrPage.AutoSize = true;
            this.lblCurrPage.ForeColor = System.Drawing.Color.Red;
            this.lblCurrPage.Location = new System.Drawing.Point(103, 12);
            this.lblCurrPage.Name = "lblCurrPage";
            this.lblCurrPage.Size = new System.Drawing.Size(11, 12);
            this.lblCurrPage.TabIndex = 15;
            this.lblCurrPage.Text = "1";
            // 
            // lblPageCount
            // 
            this.lblPageCount.AutoSize = true;
            this.lblPageCount.ForeColor = System.Drawing.Color.Red;
            this.lblPageCount.Location = new System.Drawing.Point(19, 12);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(11, 12);
            this.lblPageCount.TabIndex = 14;
            this.lblPageCount.Text = "1";
            // 
            // lblTextDes
            // 
            this.lblTextDes.AutoSize = true;
            this.lblTextDes.Location = new System.Drawing.Point(-2, 12);
            this.lblTextDes.Name = "lblTextDes";
            this.lblTextDes.Size = new System.Drawing.Size(269, 12);
            this.lblTextDes.TabIndex = 13;
            this.lblTextDes.Text = "共　　页，当前第　　页，转到第　　　　　　页";
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel1.Controls.Add(this.gbSendRecv);
            this.dividerPanel1.Controls.Add(this.groupBox3);
            this.dividerPanel1.Controls.Add(this.groupBox2);
            this.dividerPanel1.Controls.Add(this.groupBox1);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(699, 231);
            this.dividerPanel1.TabIndex = 6;
            // 
            // gbSendRecv
            // 
            this.gbSendRecv.Controls.Add(this.chkSend);
            this.gbSendRecv.Controls.Add(this.chkRecv);
            this.gbSendRecv.Location = new System.Drawing.Point(249, 160);
            this.gbSendRecv.Name = "gbSendRecv";
            this.gbSendRecv.Size = new System.Drawing.Size(200, 71);
            this.gbSendRecv.TabIndex = 12;
            this.gbSendRecv.TabStop = false;
            this.gbSendRecv.Text = "赠/收人";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkAccount);
            this.groupBox3.Controls.Add(this.chkNick);
            this.groupBox3.Location = new System.Drawing.Point(249, 82);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 67);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "帐号/昵称";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkTrade);
            this.groupBox2.Controls.Add(this.chkConsume);
            this.groupBox2.Location = new System.Drawing.Point(249, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 70);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "记录类型";
            // 
            // dpCase
            // 
            this.dpCase.AllowDrop = true;
            this.dpCase.Controls.Add(this.dgInfoList);
            this.dpCase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpCase.Location = new System.Drawing.Point(10, 268);
            this.dpCase.Name = "dividerPanel3";
            this.dpCase.Size = new System.Drawing.Size(699, 139);
            this.dpCase.TabIndex = 11;
            // 
            // dgInfoList
            // 
            this.dgInfoList.AllowUserToAddRows = false;
            this.dgInfoList.AllowUserToDeleteRows = false;
            this.dgInfoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInfoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgInfoList.Location = new System.Drawing.Point(0, 0);
            this.dgInfoList.Name = "dgInfoList";
            this.dgInfoList.RowTemplate.Height = 23;
            this.dgInfoList.Size = new System.Drawing.Size(699, 139);
            this.dgInfoList.TabIndex = 0;
            // 
            // LogSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 417);
            this.Controls.Add(this.dpCase);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "LogSearch";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "交易/消费记录查询[劲舞团]";
            this.Load += new System.EventHandler(this.LogSearch_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.dividerPanel2.ResumeLayout(false);
            this.dividerPanel2.PerformLayout();
            this.dividerPanel1.ResumeLayout(false);
            this.gbSendRecv.ResumeLayout(false);
            this.gbSendRecv.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.dpCase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgInfoList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkTrade;
        private System.Windows.Forms.CheckBox chkConsume;
        private System.Windows.Forms.Label lblAccountOrNick;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private DividerPanel.DividerPanel dividerPanel2;
        private DividerPanel.DividerPanel dividerPanel1;
        private DividerPanel.DividerPanel dpCase;
        private System.Windows.Forms.DataGridView dgInfoList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxServerIP;
        private System.Windows.Forms.CheckBox chkAccount;
        private System.Windows.Forms.CheckBox chkNick;
        private System.Windows.Forms.CheckBox chkSend;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.DateTimePicker beginDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkRecv;
        private System.Windows.Forms.GroupBox gbSendRecv;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTextDes;
        private System.Windows.Forms.Label lblPageCount;
        private System.Windows.Forms.ComboBox cbxToPageIndex;
        private System.Windows.Forms.Label lblCurrPage;
        private System.Windows.Forms.Label lblPaidAll;
    }
}

