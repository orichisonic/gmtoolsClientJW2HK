namespace M_CR
{
    partial class PartBehavior
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkNick = new System.Windows.Forms.CheckBox();
            this.chkAccount = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.cbxServerIP = new System.Windows.Forms.ComboBox();
            this.lblIDOrNick = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.dpDataGrid = new DividerPanel.DividerPanel();
            this.dgAccountInfo = new System.Windows.Forms.DataGridView();
            this.dpNoteText = new DividerPanel.DividerPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dpModi = new DividerPanel.DividerPanel();
            this.txtnickname = new System.Windows.Forms.TextBox();
            this.btnNicknameCanel = new System.Windows.Forms.Button();
            this.btnNickname = new System.Windows.Forms.Button();
            this.btnModNickName = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtM = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnModiCancel = new System.Windows.Forms.Button();
            this.btnModiPwd = new System.Windows.Forms.Button();
            this.btnModiApply = new System.Windows.Forms.Button();
            this.txtG = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtExp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxLevel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPlayerID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dividerPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.dpDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccountInfo)).BeginInit();
            this.dpNoteText.SuspendLayout();
            this.dpModi.SuspendLayout();
            this.SuspendLayout();
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.groupBox1);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(702, 101);
            this.dividerPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkNick);
            this.groupBox1.Controls.Add(this.chkAccount);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtAccount);
            this.groupBox1.Controls.Add(this.cbxServerIP);
            this.groupBox1.Controls.Add(this.lblIDOrNick);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(702, 101);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "帐号查询";
            // 
            // chkNick
            // 
            this.chkNick.AutoSize = true;
            this.chkNick.Location = new System.Drawing.Point(90, 78);
            this.chkNick.Name = "chkNick";
            this.chkNick.Size = new System.Drawing.Size(108, 16);
            this.chkNick.TabIndex = 15;
            this.chkNick.Text = "昵称(模糊查询)";
            this.chkNick.UseVisualStyleBackColor = true;
            this.chkNick.Click += new System.EventHandler(this.chkNick_Click);
            // 
            // chkAccount
            // 
            this.chkAccount.AutoSize = true;
            this.chkAccount.Checked = true;
            this.chkAccount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAccount.Location = new System.Drawing.Point(18, 78);
            this.chkAccount.Name = "chkAccount";
            this.chkAccount.Size = new System.Drawing.Size(72, 16);
            this.chkAccount.TabIndex = 12;
            this.chkAccount.Text = "帐号查询";
            this.chkAccount.UseVisualStyleBackColor = true;
            this.chkAccount.Click += new System.EventHandler(this.chkAccount_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "查询方式：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(517, 32);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(436, 32);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(227, 34);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(203, 21);
            this.txtAccount.TabIndex = 3;
            // 
            // cbxServerIP
            // 
            this.cbxServerIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServerIP.FormattingEnabled = true;
            this.cbxServerIP.Location = new System.Drawing.Point(18, 35);
            this.cbxServerIP.Name = "cbxServerIP";
            this.cbxServerIP.Size = new System.Drawing.Size(203, 20);
            this.cbxServerIP.TabIndex = 2;
            // 
            // lblIDOrNick
            // 
            this.lblIDOrNick.AutoSize = true;
            this.lblIDOrNick.Location = new System.Drawing.Point(225, 20);
            this.lblIDOrNick.Name = "lblIDOrNick";
            this.lblIDOrNick.Size = new System.Drawing.Size(65, 12);
            this.lblIDOrNick.TabIndex = 1;
            this.lblIDOrNick.Text = "玩家帐号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器：";
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 111);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(702, 10);
            this.dividerPanel2.TabIndex = 1;
            // 
            // dpDataGrid
            // 
            this.dpDataGrid.AllowDrop = true;
            this.dpDataGrid.Controls.Add(this.dgAccountInfo);
            this.dpDataGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.dpDataGrid.Location = new System.Drawing.Point(10, 121);
            this.dpDataGrid.Name = "dividerPanel3";
            this.dpDataGrid.Size = new System.Drawing.Size(702, 179);
            this.dpDataGrid.TabIndex = 2;
            // 
            // dgAccountInfo
            // 
            this.dgAccountInfo.AllowUserToAddRows = false;
            this.dgAccountInfo.AllowUserToDeleteRows = false;
            this.dgAccountInfo.AllowUserToOrderColumns = true;
            this.dgAccountInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAccountInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAccountInfo.Location = new System.Drawing.Point(0, 0);
            this.dgAccountInfo.MultiSelect = false;
            this.dgAccountInfo.Name = "dgAccountInfo";
            this.dgAccountInfo.ReadOnly = true;
            this.dgAccountInfo.RowTemplate.Height = 23;
            this.dgAccountInfo.Size = new System.Drawing.Size(702, 179);
            this.dgAccountInfo.TabIndex = 0;
            this.dgAccountInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dgAccountInfo.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgAccountInfo_ColumnHeaderMouseClick);
            // 
            // dpNoteText
            // 
            this.dpNoteText.AllowDrop = true;
            this.dpNoteText.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dpNoteText.Controls.Add(this.label8);
            this.dpNoteText.Controls.Add(this.label7);
            this.dpNoteText.Dock = System.Windows.Forms.DockStyle.Top;
            this.dpNoteText.Location = new System.Drawing.Point(10, 300);
            this.dpNoteText.Name = "dividerPanel4";
            this.dpNoteText.Size = new System.Drawing.Size(702, 46);
            this.dpNoteText.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(-1, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(245, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "请先在上方选择玩家角色后修改玩家相关信息";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(0, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "提醒：";
            // 
            // dpModi
            // 
            this.dpModi.AllowDrop = true;
            this.dpModi.BorderSide = System.Windows.Forms.Border3DSide.Top;
            this.dpModi.Controls.Add(this.txtnickname);
            this.dpModi.Controls.Add(this.btnNicknameCanel);
            this.dpModi.Controls.Add(this.btnNickname);
            this.dpModi.Controls.Add(this.btnModNickName);
            this.dpModi.Controls.Add(this.label10);
            this.dpModi.Controls.Add(this.TxtM);
            this.dpModi.Controls.Add(this.label2);
            this.dpModi.Controls.Add(this.btnModiCancel);
            this.dpModi.Controls.Add(this.btnModiPwd);
            this.dpModi.Controls.Add(this.btnModiApply);
            this.dpModi.Controls.Add(this.txtG);
            this.dpModi.Controls.Add(this.label9);
            this.dpModi.Controls.Add(this.txtExp);
            this.dpModi.Controls.Add(this.label5);
            this.dpModi.Controls.Add(this.cbxLevel);
            this.dpModi.Controls.Add(this.label4);
            this.dpModi.Controls.Add(this.txtPlayerID);
            this.dpModi.Controls.Add(this.label3);
            this.dpModi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpModi.Location = new System.Drawing.Point(10, 346);
            this.dpModi.Name = "dividerPanel5";
            this.dpModi.Size = new System.Drawing.Size(702, 159);
            this.dpModi.TabIndex = 4;
            // 
            // txtnickname
            // 
            this.txtnickname.Location = new System.Drawing.Point(427, 10);
            this.txtnickname.Name = "txtnickname";
            this.txtnickname.ReadOnly = true;
            this.txtnickname.Size = new System.Drawing.Size(137, 21);
            this.txtnickname.TabIndex = 19;
            // 
            // btnNicknameCanel
            // 
            this.btnNicknameCanel.Enabled = false;
            this.btnNicknameCanel.Location = new System.Drawing.Point(585, 68);
            this.btnNicknameCanel.Name = "btnNicknameCanel";
            this.btnNicknameCanel.Size = new System.Drawing.Size(111, 23);
            this.btnNicknameCanel.TabIndex = 18;
            this.btnNicknameCanel.Text = "取消";
            this.btnNicknameCanel.UseVisualStyleBackColor = true;
            this.btnNicknameCanel.Click += new System.EventHandler(this.btnNicknameCanel_Click);
            // 
            // btnNickname
            // 
            this.btnNickname.Enabled = false;
            this.btnNickname.Location = new System.Drawing.Point(585, 39);
            this.btnNickname.Name = "btnNickname";
            this.btnNickname.Size = new System.Drawing.Size(111, 23);
            this.btnNickname.TabIndex = 17;
            this.btnNickname.Text = "确认修改";
            this.btnNickname.UseVisualStyleBackColor = true;
            this.btnNickname.Click += new System.EventHandler(this.btnNickname_Click);
            // 
            // btnModNickName
            // 
            this.btnModNickName.Location = new System.Drawing.Point(585, 9);
            this.btnModNickName.Name = "btnModNickName";
            this.btnModNickName.Size = new System.Drawing.Size(111, 23);
            this.btnModNickName.TabIndex = 16;
            this.btnModNickName.Text = "修改昵称";
            this.btnModNickName.UseVisualStyleBackColor = true;
            this.btnModNickName.Click += new System.EventHandler(this.btnModNickName_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(365, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "用户昵称：";
            // 
            // TxtM
            // 
            this.TxtM.Location = new System.Drawing.Point(69, 118);
            this.TxtM.Name = "TxtM";
            this.TxtM.Size = new System.Drawing.Size(137, 21);
            this.TxtM.TabIndex = 13;
            this.TxtM.Visible = false;
            this.TxtM.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtM_KeyUp);
            this.TxtM.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TxtM_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "M 币：";
            this.label2.Visible = false;
            // 
            // btnModiCancel
            // 
            this.btnModiCancel.Location = new System.Drawing.Point(238, 38);
            this.btnModiCancel.Name = "btnModiCancel";
            this.btnModiCancel.Size = new System.Drawing.Size(111, 23);
            this.btnModiCancel.TabIndex = 11;
            this.btnModiCancel.Text = "取消";
            this.btnModiCancel.UseVisualStyleBackColor = true;
            this.btnModiCancel.Click += new System.EventHandler(this.btnModiCancel_Click);
            // 
            // btnModiPwd
            // 
            this.btnModiPwd.AutoSize = true;
            this.btnModiPwd.Enabled = false;
            this.btnModiPwd.Location = new System.Drawing.Point(238, 67);
            this.btnModiPwd.Name = "btnModiPwd";
            this.btnModiPwd.Size = new System.Drawing.Size(111, 23);
            this.btnModiPwd.TabIndex = 10;
            this.btnModiPwd.Text = "修改当前玩家密码";
            this.btnModiPwd.UseVisualStyleBackColor = true;
            this.btnModiPwd.Visible = false;
            this.btnModiPwd.Click += new System.EventHandler(this.btnModiPwd_Click);
            // 
            // btnModiApply
            // 
            this.btnModiApply.Location = new System.Drawing.Point(238, 9);
            this.btnModiApply.Name = "btnModiApply";
            this.btnModiApply.Size = new System.Drawing.Size(111, 23);
            this.btnModiApply.TabIndex = 9;
            this.btnModiApply.Text = "确认";
            this.btnModiApply.UseVisualStyleBackColor = true;
            this.btnModiApply.Click += new System.EventHandler(this.btnModiApply_Click);
            // 
            // txtG
            // 
            this.txtG.Location = new System.Drawing.Point(69, 89);
            this.txtG.Name = "txtG";
            this.txtG.Size = new System.Drawing.Size(137, 21);
            this.txtG.TabIndex = 8;
            this.txtG.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtG_KeyUp);
            this.txtG.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtG_MouseUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "G 币：";
            // 
            // txtExp
            // 
            this.txtExp.Location = new System.Drawing.Point(69, 62);
            this.txtExp.Name = "txtExp";
            this.txtExp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtExp.Size = new System.Drawing.Size(137, 21);
            this.txtExp.TabIndex = 5;
            this.txtExp.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtExp_KeyUp);
            this.txtExp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtExp_MouseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-2, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "玩家经验：";
            // 
            // cbxLevel
            // 
            this.cbxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLevel.FormattingEnabled = true;
            this.cbxLevel.Items.AddRange(new object[] {
            "白驾照",
            "黄驾照",
            "蓝驾照",
            "绿驾照",
            "红驾照",
            "彩色驾照"});
            this.cbxLevel.Location = new System.Drawing.Point(69, 36);
            this.cbxLevel.Name = "cbxLevel";
            this.cbxLevel.Size = new System.Drawing.Size(137, 20);
            this.cbxLevel.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-1, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "驾照等级：";
            // 
            // txtPlayerID
            // 
            this.txtPlayerID.Enabled = false;
            this.txtPlayerID.Location = new System.Drawing.Point(69, 9);
            this.txtPlayerID.Name = "txtPlayerID";
            this.txtPlayerID.Size = new System.Drawing.Size(137, 21);
            this.txtPlayerID.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-2, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "玩家帐号：";
            // 
            // PartBehavior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 515);
            this.Controls.Add(this.dpModi);
            this.Controls.Add(this.dpNoteText);
            this.Controls.Add(this.dpDataGrid);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "PartBehavior";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "玩家角色信息操作[疯狂卡丁车]";
            this.Load += new System.EventHandler(this.PartBehavior_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.dpDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAccountInfo)).EndInit();
            this.dpNoteText.ResumeLayout(false);
            this.dpNoteText.PerformLayout();
            this.dpModi.ResumeLayout(false);
            this.dpModi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DividerPanel.DividerPanel dividerPanel1;
        private DividerPanel.DividerPanel dividerPanel2;
        private DividerPanel.DividerPanel dpDataGrid;
        private DividerPanel.DividerPanel dpNoteText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.ComboBox cbxServerIP;
        private System.Windows.Forms.Label lblIDOrNick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgAccountInfo;
        private DividerPanel.DividerPanel dpModi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPlayerID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtExp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtG;
        private System.Windows.Forms.Button btnModiApply;
        private System.Windows.Forms.Button btnModiPwd;
        private System.Windows.Forms.Button btnModiCancel;
        private System.Windows.Forms.CheckBox chkNick;
        private System.Windows.Forms.CheckBox chkAccount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnModNickName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnNicknameCanel;
        private System.Windows.Forms.Button btnNickname;
        private System.Windows.Forms.TextBox txtnickname;
    }
}