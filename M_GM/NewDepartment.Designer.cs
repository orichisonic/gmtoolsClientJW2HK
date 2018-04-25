namespace M_GM
{
    partial class NewDepartment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewDepartment));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lstGameRole = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeptName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.dividerPanel5 = new DividerPanel.DividerPanel();
            this.dgDepartList = new System.Windows.Forms.DataGridView();
            this.dividerPanel4 = new DividerPanel.DividerPanel();
            this.ibtDelDepart = new ImageTextControl.IMGTXTCTRL();
            this.ibtNewDepart = new ImageTextControl.IMGTXTCTRL();
            this.ibtEditDepart = new ImageTextControl.IMGTXTCTRL();
            this.dpVerticalLine = new DividerPanel.DividerPanel();
            this.dpSet = new DividerPanel.DividerPanel();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dividerPanel1.SuspendLayout();
            this.dividerPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDepartList)).BeginInit();
            this.dividerPanel4.SuspendLayout();
            this.dpSet.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(89, 459);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(8, 459);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lstGameRole
            // 
            this.lstGameRole.CheckBoxes = true;
            this.lstGameRole.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstGameRole.Location = new System.Drawing.Point(8, 173);
            this.lstGameRole.Name = "lstGameRole";
            this.lstGameRole.Size = new System.Drawing.Size(322, 279);
            this.lstGameRole.TabIndex = 9;
            this.lstGameRole.UseCompatibleStateImageBehavior = false;
            this.lstGameRole.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "游戏名称";
            this.columnHeader1.Width = 234;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "可管理游戏设置：";
            // 
            // txtDeptName
            // 
            this.txtDeptName.Location = new System.Drawing.Point(6, 15);
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.Size = new System.Drawing.Size(322, 21);
            this.txtDeptName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "部门名称：";
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel1.Controls.Add(this.dividerPanel5);
            this.dividerPanel1.Controls.Add(this.dividerPanel4);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(415, 485);
            this.dividerPanel1.TabIndex = 12;
            // 
            // dividerPanel5
            // 
            this.dividerPanel5.AllowDrop = true;
            this.dividerPanel5.Controls.Add(this.dgDepartList);
            this.dividerPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel5.Location = new System.Drawing.Point(0, 26);
            this.dividerPanel5.Name = "dividerPanel5";
            this.dividerPanel5.Size = new System.Drawing.Size(415, 459);
            this.dividerPanel5.TabIndex = 2;
            // 
            // dgDepartList
            // 
            this.dgDepartList.AllowUserToAddRows = false;
            this.dgDepartList.AllowUserToDeleteRows = false;
            this.dgDepartList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDepartList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDepartList.Location = new System.Drawing.Point(0, 0);
            this.dgDepartList.Name = "dgDepartList";
            this.dgDepartList.ReadOnly = true;
            this.dgDepartList.RowTemplate.Height = 23;
            this.dgDepartList.Size = new System.Drawing.Size(415, 459);
            this.dgDepartList.TabIndex = 0;
            this.dgDepartList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDepartList_CellClick);
            this.dgDepartList.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgDepartList_ColumnHeaderMouseClick);
            // 
            // dividerPanel4
            // 
            this.dividerPanel4.AllowDrop = true;
            this.dividerPanel4.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel4.Controls.Add(this.ibtDelDepart);
            this.dividerPanel4.Controls.Add(this.ibtNewDepart);
            this.dividerPanel4.Controls.Add(this.ibtEditDepart);
            this.dividerPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel4.Location = new System.Drawing.Point(0, 0);
            this.dividerPanel4.Name = "dividerPanel4";
            this.dividerPanel4.Size = new System.Drawing.Size(415, 26);
            this.dividerPanel4.TabIndex = 1;
            // 
            // ibtDelDepart
            // 
            this.ibtDelDepart.ControlPoint = new System.Drawing.Point(0, 0);
            this.ibtDelDepart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtDelDepart.IMG_SRC = ((System.Drawing.Image)(resources.GetObject("ibtDelDepart.IMG_SRC")));
            this.ibtDelDepart.ITXT_ForeColor = System.Drawing.Color.Red;
            this.ibtDelDepart.ITXT_MouseHoverColor = System.Drawing.Color.Blue;
            this.ibtDelDepart.ITXT_TEXT = "删除部门";
            this.ibtDelDepart.Location = new System.Drawing.Point(284, 2);
            this.ibtDelDepart.Name = "ibtDelDepart";
            this.ibtDelDepart.Size = new System.Drawing.Size(76, 18);
            this.ibtDelDepart.TabIndex = 3;
            this.ibtDelDepart.ITC_CLICIK += new ImageTextControl.ITCEventHandler(this.ibtDelDepart_ITC_CLICIK);
            // 
            // ibtNewDepart
            // 
            this.ibtNewDepart.ControlPoint = new System.Drawing.Point(0, 0);
            this.ibtNewDepart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtNewDepart.IMG_SRC = ((System.Drawing.Image)(resources.GetObject("ibtNewDepart.IMG_SRC")));
            this.ibtNewDepart.ITXT_ForeColor = System.Drawing.Color.Black;
            this.ibtNewDepart.ITXT_MouseHoverColor = System.Drawing.Color.Red;
            this.ibtNewDepart.ITXT_TEXT = "新建部门";
            this.ibtNewDepart.Location = new System.Drawing.Point(0, 2);
            this.ibtNewDepart.Name = "ibtNewDepart";
            this.ibtNewDepart.Size = new System.Drawing.Size(76, 18);
            this.ibtNewDepart.TabIndex = 2;
            this.ibtNewDepart.ITC_CLICIK += new ImageTextControl.ITCEventHandler(this.ibtNewDepart_ITC_CLICIK);
            // 
            // ibtEditDepart
            // 
            this.ibtEditDepart.ControlPoint = new System.Drawing.Point(0, 0);
            this.ibtEditDepart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtEditDepart.IMG_SRC = ((System.Drawing.Image)(resources.GetObject("ibtEditDepart.IMG_SRC")));
            this.ibtEditDepart.ITXT_ForeColor = System.Drawing.Color.Black;
            this.ibtEditDepart.ITXT_MouseHoverColor = System.Drawing.Color.Red;
            this.ibtEditDepart.ITXT_TEXT = "编辑部门信息（请先选择部门）";
            this.ibtEditDepart.Location = new System.Drawing.Point(82, 1);
            this.ibtEditDepart.Name = "ibtEditDepart";
            this.ibtEditDepart.Size = new System.Drawing.Size(196, 18);
            this.ibtEditDepart.TabIndex = 1;
            this.ibtEditDepart.ITC_CLICIK += new ImageTextControl.ITCEventHandler(this.ibtEditDepart_ITC_CLICIK);
            // 
            // dpVerticalLine
            // 
            this.dpVerticalLine.AllowDrop = true;
            this.dpVerticalLine.BorderSide = System.Windows.Forms.Border3DSide.Right;
            this.dpVerticalLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.dpVerticalLine.Location = new System.Drawing.Point(425, 10);
            this.dpVerticalLine.Name = "dpVerticalLine";
            this.dpVerticalLine.Size = new System.Drawing.Size(10, 485);
            this.dpVerticalLine.TabIndex = 13;
            // 
            // dpSet
            // 
            this.dpSet.AllowDrop = true;
            this.dpSet.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dpSet.Controls.Add(this.txtRemark);
            this.dpSet.Controls.Add(this.label3);
            this.dpSet.Controls.Add(this.btnCancel);
            this.dpSet.Controls.Add(this.label1);
            this.dpSet.Controls.Add(this.btnOK);
            this.dpSet.Controls.Add(this.txtDeptName);
            this.dpSet.Controls.Add(this.label2);
            this.dpSet.Controls.Add(this.lstGameRole);
            this.dpSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpSet.Location = new System.Drawing.Point(435, 10);
            this.dpSet.Name = "dpSet";
            this.dpSet.Size = new System.Drawing.Size(269, 485);
            this.dpSet.TabIndex = 14;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(6, 57);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(322, 93);
            this.txtRemark.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "备注：";
            // 
            // NewDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 505);
            this.Controls.Add(this.dpSet);
            this.Controls.Add(this.dpVerticalLine);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "NewDepartment";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "部门管理";
            this.Load += new System.EventHandler(this.NewDepartment_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDepartList)).EndInit();
            this.dividerPanel4.ResumeLayout(false);
            this.dpSet.ResumeLayout(false);
            this.dpSet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ListView lstGameRole;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDeptName;
        private System.Windows.Forms.Label label1;
        private DividerPanel.DividerPanel dividerPanel1;
        private DividerPanel.DividerPanel dpVerticalLine;
        private DividerPanel.DividerPanel dpSet;
        private System.Windows.Forms.DataGridView dgDepartList;
        private DividerPanel.DividerPanel dividerPanel5;
        private DividerPanel.DividerPanel dividerPanel4;
        private ImageTextControl.IMGTXTCTRL ibtEditDepart;
        private ImageTextControl.IMGTXTCTRL ibtNewDepart;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRemark;
        private ImageTextControl.IMGTXTCTRL ibtDelDepart;
    }
}