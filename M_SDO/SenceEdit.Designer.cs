namespace M_SDO
{
    partial class SenceEdit
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
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.dgInfoList = new System.Windows.Forms.DataGridView();
            this.dividerPanel3 = new DividerPanel.DividerPanel();
            this.dpEdit = new DividerPanel.DividerPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtSenceName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSenceID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dividerPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.dividerPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInfoList)).BeginInit();
            this.dpEdit.SuspendLayout();
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
            this.dividerPanel1.Size = new System.Drawing.Size(540, 36);
            this.dividerPanel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(540, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::M_SDO.Properties.Resources.add;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "新建";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::M_SDO.Properties.Resources.edit;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "编辑";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::M_SDO.Properties.Resources.del;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "删除";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Controls.Add(this.dgInfoList);
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 46);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(540, 236);
            this.dividerPanel2.TabIndex = 1;
            // 
            // dgInfoList
            // 
            this.dgInfoList.AllowUserToAddRows = false;
            this.dgInfoList.AllowUserToDeleteRows = false;
            this.dgInfoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInfoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgInfoList.Location = new System.Drawing.Point(0, 0);
            this.dgInfoList.Name = "dgInfoList";
            this.dgInfoList.ReadOnly = true;
            this.dgInfoList.RowTemplate.Height = 23;
            this.dgInfoList.Size = new System.Drawing.Size(540, 236);
            this.dgInfoList.TabIndex = 0;
            this.dgInfoList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgInfoList_CellClick);
            this.dgInfoList.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgInfoList_ColumnHeaderMouseClick);
            this.dgInfoList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgInfoList_MouseUp);
            // 
            // dividerPanel3
            // 
            this.dividerPanel3.AllowDrop = true;
            this.dividerPanel3.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel3.Location = new System.Drawing.Point(10, 282);
            this.dividerPanel3.Name = "dividerPanel3";
            this.dividerPanel3.Size = new System.Drawing.Size(540, 10);
            this.dividerPanel3.TabIndex = 2;
            // 
            // dpEdit
            // 
            this.dpEdit.AllowDrop = true;
            this.dpEdit.Controls.Add(this.btnCancel);
            this.dpEdit.Controls.Add(this.btnOK);
            this.dpEdit.Controls.Add(this.txtSenceName);
            this.dpEdit.Controls.Add(this.label2);
            this.dpEdit.Controls.Add(this.txtSenceID);
            this.dpEdit.Controls.Add(this.label1);
            this.dpEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpEdit.Location = new System.Drawing.Point(10, 292);
            this.dpEdit.Name = "dpEdit";
            this.dpEdit.Size = new System.Drawing.Size(540, 105);
            this.dpEdit.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(161, 63);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(80, 63);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtSenceName
            // 
            this.txtSenceName.Location = new System.Drawing.Point(80, 36);
            this.txtSenceName.Name = "txtSenceName";
            this.txtSenceName.Size = new System.Drawing.Size(165, 21);
            this.txtSenceName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "场景名称：";
            // 
            // txtSenceID
            // 
            this.txtSenceID.Location = new System.Drawing.Point(80, 9);
            this.txtSenceID.Name = "txtSenceID";
            this.txtSenceID.Size = new System.Drawing.Size(165, 21);
            this.txtSenceID.TabIndex = 1;
            this.txtSenceID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSenceID_KeyUp);
            this.txtSenceID.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtSenceID_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "场景编号：";
            // 
            // SenceEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 407);
            this.Controls.Add(this.dpEdit);
            this.Controls.Add(this.dividerPanel3);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "SenceEdit";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "场景编辑";
            this.Load += new System.EventHandler(this.SenceEdit_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.dividerPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgInfoList)).EndInit();
            this.dpEdit.ResumeLayout(false);
            this.dpEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private DividerPanel.DividerPanel dividerPanel2;
        private DividerPanel.DividerPanel dividerPanel3;
        private DividerPanel.DividerPanel dpEdit;
        private System.Windows.Forms.DataGridView dgInfoList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtSenceName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSenceID;
    }
}