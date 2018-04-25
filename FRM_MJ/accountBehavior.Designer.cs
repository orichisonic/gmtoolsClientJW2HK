namespace FRM_MJ
{
    partial class accountBehavior
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpAccountAction = new System.Windows.Forms.TabPage();
            this.tbLockReson = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.actionType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.serverIP = new System.Windows.Forms.ComboBox();
            this.tpLockAccount = new System.Windows.Forms.TabPage();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.listViewSortOrder = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.tabControl1.SuspendLayout();
            this.tpAccountAction.SuspendLayout();
            this.tpLockAccount.SuspendLayout();
            this.dividerPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpAccountAction);
            this.tabControl1.Controls.Add(this.tpLockAccount);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(10, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(402, 283);
            this.tabControl1.TabIndex = 0;
            // 
            // tpAccountAction
            // 
            this.tpAccountAction.Controls.Add(this.tbLockReson);
            this.tpAccountAction.Controls.Add(this.label5);
            this.tpAccountAction.Controls.Add(this.btnOK);
            this.tpAccountAction.Controls.Add(this.dateTimePicker1);
            this.tpAccountAction.Controls.Add(this.label4);
            this.tpAccountAction.Controls.Add(this.userName);
            this.tpAccountAction.Controls.Add(this.actionType);
            this.tpAccountAction.Controls.Add(this.label3);
            this.tpAccountAction.Controls.Add(this.label2);
            this.tpAccountAction.Controls.Add(this.label1);
            this.tpAccountAction.Controls.Add(this.serverIP);
            this.tpAccountAction.Location = new System.Drawing.Point(4, 21);
            this.tpAccountAction.Name = "tpAccountAction";
            this.tpAccountAction.Padding = new System.Windows.Forms.Padding(3);
            this.tpAccountAction.Size = new System.Drawing.Size(394, 258);
            this.tpAccountAction.TabIndex = 0;
            this.tpAccountAction.Text = "帐号操作";
            this.tpAccountAction.UseVisualStyleBackColor = true;
            // 
            // tbLockReson
            // 
            this.tbLockReson.Location = new System.Drawing.Point(87, 100);
            this.tbLockReson.Multiline = true;
            this.tbLockReson.Name = "tbLockReson";
            this.tbLockReson.Size = new System.Drawing.Size(288, 88);
            this.tbLockReson.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "停封描述：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(300, 221);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(87, 194);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(288, 21);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "停封到：";
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(88, 73);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(287, 21);
            this.userName.TabIndex = 5;
            // 
            // actionType
            // 
            this.actionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionType.FormattingEnabled = true;
            this.actionType.Items.AddRange(new object[] {
            "时限停封",
            "永久封停"});
            this.actionType.Location = new System.Drawing.Point(88, 46);
            this.actionType.Name = "actionType";
            this.actionType.Size = new System.Drawing.Size(287, 20);
            this.actionType.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "玩家帐号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "操作：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "服务器：";
            // 
            // serverIP
            // 
            this.serverIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serverIP.FormattingEnabled = true;
            this.serverIP.Location = new System.Drawing.Point(87, 20);
            this.serverIP.Name = "serverIP";
            this.serverIP.Size = new System.Drawing.Size(288, 20);
            this.serverIP.TabIndex = 0;
            // 
            // tpLockAccount
            // 
            this.tpLockAccount.Controls.Add(this.dividerPanel1);
            this.tpLockAccount.Location = new System.Drawing.Point(4, 21);
            this.tpLockAccount.Name = "tpLockAccount";
            this.tpLockAccount.Padding = new System.Windows.Forms.Padding(3);
            this.tpLockAccount.Size = new System.Drawing.Size(394, 258);
            this.tpLockAccount.TabIndex = 1;
            this.tpLockAccount.Text = "永久锁定会员列表";
            this.tpLockAccount.UseVisualStyleBackColor = true;
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.listViewSortOrder);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel1.Location = new System.Drawing.Point(3, 3);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.dividerPanel1.Size = new System.Drawing.Size(388, 252);
            this.dividerPanel1.TabIndex = 0;
            // 
            // listViewSortOrder
            // 
            this.listViewSortOrder.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewSortOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewSortOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSortOrder.FullRowSelect = true;
            this.listViewSortOrder.GridLines = true;
            this.listViewSortOrder.Location = new System.Drawing.Point(2, 2);
            this.listViewSortOrder.MultiSelect = false;
            this.listViewSortOrder.Name = "listViewSortOrder";
            this.listViewSortOrder.Size = new System.Drawing.Size(384, 248);
            this.listViewSortOrder.TabIndex = 9;
            this.listViewSortOrder.UseCompatibleStateImageBehavior = false;
            this.listViewSortOrder.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "编号";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "帐号";
            this.columnHeader3.Width = 75;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "所在服务器";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "封锁日期";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "描述";
            // 
            // accountBehavior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 303);
            this.Controls.Add(this.tabControl1);
            this.Name = "accountBehavior";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "帐号操作[猛将]";
            this.Load += new System.EventHandler(this.accountBehavior_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpAccountAction.ResumeLayout(false);
            this.tpAccountAction.PerformLayout();
            this.tpLockAccount.ResumeLayout(false);
            this.dividerPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpAccountAction;
        private System.Windows.Forms.TabPage tpLockAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox serverIP;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.ComboBox actionType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.ListView listViewSortOrder;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox tbLockReson;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}