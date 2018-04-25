namespace M_SDO
{
    partial class BlanketToUser
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkCode = new System.Windows.Forms.CheckBox();
            this.chkKeyID = new System.Windows.Forms.CheckBox();
            this.txtKeyOrCode = new System.Windows.Forms.TextBox();
            this.lblKeyOrCode = new System.Windows.Forms.Label();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.dpInfos = new DividerPanel.DividerPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKeyID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaster = new System.Windows.Forms.TextBox();
            this.dividerPanel1.SuspendLayout();
            this.dpInfos.SuspendLayout();
            this.SuspendLayout();
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.btnSearch);
            this.dividerPanel1.Controls.Add(this.chkCode);
            this.dividerPanel1.Controls.Add(this.chkKeyID);
            this.dividerPanel1.Controls.Add(this.txtKeyOrCode);
            this.dividerPanel1.Controls.Add(this.lblKeyOrCode);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(489, 81);
            this.dividerPanel1.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(211, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkCode
            // 
            this.chkCode.AutoSize = true;
            this.chkCode.Location = new System.Drawing.Point(73, 52);
            this.chkCode.Name = "chkCode";
            this.chkCode.Size = new System.Drawing.Size(60, 16);
            this.chkCode.TabIndex = 8;
            this.chkCode.Text = "激活码";
            this.chkCode.UseVisualStyleBackColor = true;
            this.chkCode.Click += new System.EventHandler(this.chkCode_Click);
            // 
            // chkKeyID
            // 
            this.chkKeyID.AutoSize = true;
            this.chkKeyID.Checked = true;
            this.chkKeyID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeyID.Location = new System.Drawing.Point(7, 52);
            this.chkKeyID.Name = "chkKeyID";
            this.chkKeyID.Size = new System.Drawing.Size(60, 16);
            this.chkKeyID.TabIndex = 7;
            this.chkKeyID.Text = "序列号";
            this.chkKeyID.UseVisualStyleBackColor = true;
            this.chkKeyID.Click += new System.EventHandler(this.chkKeyID_Click);
            // 
            // txtKeyOrCode
            // 
            this.txtKeyOrCode.Location = new System.Drawing.Point(7, 25);
            this.txtKeyOrCode.Name = "txtKeyOrCode";
            this.txtKeyOrCode.Size = new System.Drawing.Size(198, 21);
            this.txtKeyOrCode.TabIndex = 6;
            // 
            // lblKeyOrCode
            // 
            this.lblKeyOrCode.AutoSize = true;
            this.lblKeyOrCode.Location = new System.Drawing.Point(5, 10);
            this.lblKeyOrCode.Name = "lblKeyOrCode";
            this.lblKeyOrCode.Size = new System.Drawing.Size(53, 12);
            this.lblKeyOrCode.TabIndex = 5;
            this.lblKeyOrCode.Text = "序列号：";
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 91);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(489, 10);
            this.dividerPanel2.TabIndex = 6;
            // 
            // dpInfos
            // 
            this.dpInfos.AllowDrop = true;
            this.dpInfos.Controls.Add(this.txtMaster);
            this.dpInfos.Controls.Add(this.label3);
            this.dpInfos.Controls.Add(this.txtCode);
            this.dpInfos.Controls.Add(this.label2);
            this.dpInfos.Controls.Add(this.txtKeyID);
            this.dpInfos.Controls.Add(this.label1);
            this.dpInfos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpInfos.Location = new System.Drawing.Point(10, 101);
            this.dpInfos.Name = "dpInfos";
            this.dpInfos.Size = new System.Drawing.Size(489, 253);
            this.dpInfos.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "序列号：";
            // 
            // txtKeyID
            // 
            this.txtKeyID.Location = new System.Drawing.Point(14, 34);
            this.txtKeyID.Name = "txtKeyID";
            this.txtKeyID.ReadOnly = true;
            this.txtKeyID.Size = new System.Drawing.Size(174, 21);
            this.txtKeyID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "激活码：";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(14, 82);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(174, 21);
            this.txtCode.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "使用者：";
            // 
            // txtMaster
            // 
            this.txtMaster.Location = new System.Drawing.Point(14, 131);
            this.txtMaster.Name = "txtMaster";
            this.txtMaster.ReadOnly = true;
            this.txtMaster.Size = new System.Drawing.Size(174, 21);
            this.txtMaster.TabIndex = 5;
            // 
            // BlanketToUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 364);
            this.Controls.Add(this.dpInfos);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "BlanketToUser";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "跳舞毯查询";
            this.Load += new System.EventHandler(this.BlanketToUser_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel1.PerformLayout();
            this.dpInfos.ResumeLayout(false);
            this.dpInfos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chkCode;
        private System.Windows.Forms.CheckBox chkKeyID;
        private System.Windows.Forms.TextBox txtKeyOrCode;
        private System.Windows.Forms.Label lblKeyOrCode;
        private DividerPanel.DividerPanel dividerPanel2;
        private DividerPanel.DividerPanel dpInfos;
        private System.Windows.Forms.TextBox txtMaster;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKeyID;
        private System.Windows.Forms.Label label1;

    }
}