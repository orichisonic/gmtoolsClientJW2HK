namespace M_GM
{
    partial class SetServer
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxGameType = new System.Windows.Forms.ComboBox();
            this.cbxGameName = new System.Windows.Forms.ComboBox();
            this.tbxDBIP = new System.Windows.Forms.TextBox();
            this.tbxDBName = new System.Windows.Forms.TextBox();
            this.tbxDBPwd = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.cbxGameCity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.listViewDBInfo = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.serverIP = new System.Windows.Forms.ColumnHeader();
            this.city = new System.Windows.Forms.ColumnHeader();
            this.gameName = new System.Windows.Forms.ColumnHeader();
            this.dbType = new System.Windows.Forms.ColumnHeader();
            this.dbFlag = new System.Windows.Forms.ColumnHeader();
            this.cbxDBType = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.dividerPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.dividerPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "游戏名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "数据库IP：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "数据库库用户名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "数据库登陆密码：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "游戏大区名：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "游戏类型：";
            // 
            // cbxGameType
            // 
            this.cbxGameType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGameType.FormattingEnabled = true;
            this.cbxGameType.Items.AddRange(new object[] {
            "LogDB",
            "GameDB",
            "MemberDB"});
            this.cbxGameType.Location = new System.Drawing.Point(127, 46);
            this.cbxGameType.Name = "cbxGameType";
            this.cbxGameType.Size = new System.Drawing.Size(227, 20);
            this.cbxGameType.TabIndex = 6;
            // 
            // cbxGameName
            // 
            this.cbxGameName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGameName.FormattingEnabled = true;
            this.cbxGameName.Location = new System.Drawing.Point(127, 20);
            this.cbxGameName.Name = "cbxGameName";
            this.cbxGameName.Size = new System.Drawing.Size(227, 20);
            this.cbxGameName.TabIndex = 8;
            // 
            // tbxDBIP
            // 
            this.tbxDBIP.Location = new System.Drawing.Point(127, 98);
            this.tbxDBIP.Name = "tbxDBIP";
            this.tbxDBIP.Size = new System.Drawing.Size(227, 21);
            this.tbxDBIP.TabIndex = 9;
            // 
            // tbxDBName
            // 
            this.tbxDBName.Location = new System.Drawing.Point(127, 124);
            this.tbxDBName.Name = "tbxDBName";
            this.tbxDBName.Size = new System.Drawing.Size(227, 21);
            this.tbxDBName.TabIndex = 10;
            // 
            // tbxDBPwd
            // 
            this.tbxDBPwd.Location = new System.Drawing.Point(127, 153);
            this.tbxDBPwd.Name = "tbxDBPwd";
            this.tbxDBPwd.Size = new System.Drawing.Size(227, 21);
            this.tbxDBPwd.TabIndex = 11;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(10, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(441, 334);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dividerPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(433, 309);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据库设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.cbxDBType);
            this.dividerPanel1.Controls.Add(this.cbxGameCity);
            this.dividerPanel1.Controls.Add(this.label7);
            this.dividerPanel1.Controls.Add(this.btnCancel);
            this.dividerPanel1.Controls.Add(this.btnApply);
            this.dividerPanel1.Controls.Add(this.tbxDBIP);
            this.dividerPanel1.Controls.Add(this.cbxGameType);
            this.dividerPanel1.Controls.Add(this.label2);
            this.dividerPanel1.Controls.Add(this.label3);
            this.dividerPanel1.Controls.Add(this.cbxGameName);
            this.dividerPanel1.Controls.Add(this.tbxDBPwd);
            this.dividerPanel1.Controls.Add(this.label1);
            this.dividerPanel1.Controls.Add(this.label4);
            this.dividerPanel1.Controls.Add(this.tbxDBName);
            this.dividerPanel1.Controls.Add(this.label5);
            this.dividerPanel1.Controls.Add(this.label6);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel1.Location = new System.Drawing.Point(3, 3);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(427, 303);
            this.dividerPanel1.TabIndex = 3;
            // 
            // cbxGameCity
            // 
            this.cbxGameCity.Location = new System.Drawing.Point(127, 72);
            this.cbxGameCity.Name = "cbxGameCity";
            this.cbxGameCity.Size = new System.Drawing.Size(227, 21);
            this.cbxGameCity.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "数据库状态：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(280, 228);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(199, 228);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 12;
            this.btnApply.Text = "确认";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dividerPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(433, 309);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "数据库信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Controls.Add(this.listViewDBInfo);
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel2.Location = new System.Drawing.Point(3, 3);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(427, 303);
            this.dividerPanel2.TabIndex = 0;
            // 
            // listViewDBInfo
            // 
            this.listViewDBInfo.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewDBInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.serverIP,
            this.city,
            this.gameName,
            this.dbType,
            this.dbFlag});
            this.listViewDBInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewDBInfo.FullRowSelect = true;
            this.listViewDBInfo.GridLines = true;
            this.listViewDBInfo.Location = new System.Drawing.Point(0, 0);
            this.listViewDBInfo.MultiSelect = false;
            this.listViewDBInfo.Name = "listViewDBInfo";
            this.listViewDBInfo.Size = new System.Drawing.Size(427, 303);
            this.listViewDBInfo.TabIndex = 5;
            this.listViewDBInfo.UseCompatibleStateImageBehavior = false;
            this.listViewDBInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "编号";
            this.columnHeader1.Width = 44;
            // 
            // serverIP
            // 
            this.serverIP.Text = "服务器IP";
            this.serverIP.Width = 81;
            // 
            // city
            // 
            this.city.Text = "大区名称";
            this.city.Width = 113;
            // 
            // gameName
            // 
            this.gameName.Text = "所属游戏";
            this.gameName.Width = 79;
            // 
            // dbType
            // 
            this.dbType.Text = "数据库类型";
            this.dbType.Width = 153;
            // 
            // dbFlag
            // 
            this.dbFlag.Text = "数据库状态";
            // 
            // cbxDBType
            // 
            this.cbxDBType.AutoSize = true;
            this.cbxDBType.Checked = true;
            this.cbxDBType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxDBType.Location = new System.Drawing.Point(127, 184);
            this.cbxDBType.Name = "cbxDBType";
            this.cbxDBType.Size = new System.Drawing.Size(48, 16);
            this.cbxDBType.TabIndex = 19;
            this.cbxDBType.Text = "可用";
            this.cbxDBType.UseVisualStyleBackColor = true;
            // 
            // SetServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 354);
            this.Controls.Add(this.tabControl1);
            this.Name = "SetServer";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "游戏数据库设置";
            this.Load += new System.EventHandler(this.SetServer_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.dividerPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxGameType;
        private System.Windows.Forms.TextBox tbxDBPwd;
        private System.Windows.Forms.TextBox tbxDBName;
        private System.Windows.Forms.TextBox tbxDBIP;
        private System.Windows.Forms.ComboBox cbxGameName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private DividerPanel.DividerPanel dividerPanel2;
        private System.Windows.Forms.ListView listViewDBInfo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader serverIP;
        private System.Windows.Forms.ColumnHeader city;
        private System.Windows.Forms.ColumnHeader gameName;
        private System.Windows.Forms.ColumnHeader dbType;
        private System.Windows.Forms.ColumnHeader dbFlag;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox cbxGameCity;
        private System.Windows.Forms.CheckBox cbxDBType;


    }
}