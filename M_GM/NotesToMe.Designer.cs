namespace M_GM
{
    partial class NotesToMe
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
            this.dpPage = new DividerPanel.DividerPanel();
            this.cbxToPage = new System.Windows.Forms.ComboBox();
            this.lblCurrPage = new System.Windows.Forms.Label();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.dividerPanel3 = new DividerPanel.DividerPanel();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.dpPage.SuspendLayout();
            this.dividerPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dpPage
            // 
            this.dpPage.AllowDrop = true;
            this.dpPage.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dpPage.Controls.Add(this.cbxToPage);
            this.dpPage.Controls.Add(this.lblCurrPage);
            this.dpPage.Controls.Add(this.lblPageCount);
            this.dpPage.Controls.Add(this.lblText);
            this.dpPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.dpPage.Location = new System.Drawing.Point(10, 10);
            this.dpPage.Name = "dividerPanel1";
            this.dpPage.Size = new System.Drawing.Size(558, 24);
            this.dpPage.TabIndex = 0;
            // 
            // cbxToPage
            // 
            this.cbxToPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxToPage.FormattingEnabled = true;
            this.cbxToPage.Location = new System.Drawing.Point(197, 1);
            this.cbxToPage.Name = "cbxToPage";
            this.cbxToPage.Size = new System.Drawing.Size(88, 20);
            this.cbxToPage.TabIndex = 3;
            this.cbxToPage.SelectedIndexChanged += new System.EventHandler(this.cbxToPage_SelectedIndexChanged);
            // 
            // lblCurrPage
            // 
            this.lblCurrPage.AutoSize = true;
            this.lblCurrPage.ForeColor = System.Drawing.Color.Red;
            this.lblCurrPage.Location = new System.Drawing.Point(90, 6);
            this.lblCurrPage.Name = "lblCurrPage";
            this.lblCurrPage.Size = new System.Drawing.Size(11, 12);
            this.lblCurrPage.TabIndex = 2;
            this.lblCurrPage.Text = "1";
            // 
            // lblPageCount
            // 
            this.lblPageCount.AutoSize = true;
            this.lblPageCount.ForeColor = System.Drawing.Color.Red;
            this.lblPageCount.Location = new System.Drawing.Point(25, 6);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(11, 12);
            this.lblPageCount.TabIndex = 1;
            this.lblPageCount.Text = "1";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(-1, 6);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(305, 12);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "共有　 页,当前　　页      转到第　　　　　　　　页";
            // 
            // dividerPanel3
            // 
            this.dividerPanel3.AllowDrop = true;
            this.dividerPanel3.Controls.Add(this.dataGrid);
            this.dividerPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel3.Location = new System.Drawing.Point(10, 34);
            this.dividerPanel3.Name = "dividerPanel3";
            this.dividerPanel3.Size = new System.Drawing.Size(558, 296);
            this.dividerPanel3.TabIndex = 2;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowTemplate.Height = 23;
            this.dataGrid.Size = new System.Drawing.Size(558, 296);
            this.dataGrid.TabIndex = 1;
            this.dataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellClick);
            // 
            // NotesToMe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 340);
            this.Controls.Add(this.dividerPanel3);
            this.Controls.Add(this.dpPage);
            this.Name = "NotesToMe";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "NOTES已处理信息";
            this.Load += new System.EventHandler(this.NotesToMe_Load);
            this.dpPage.ResumeLayout(false);
            this.dpPage.PerformLayout();
            this.dividerPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DividerPanel.DividerPanel dpPage;
        private DividerPanel.DividerPanel dividerPanel3;
        private System.Windows.Forms.Label lblCurrPage;
        private System.Windows.Forms.Label lblPageCount;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.ComboBox cbxToPage;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.DataGridView dataGrid;
    }
}