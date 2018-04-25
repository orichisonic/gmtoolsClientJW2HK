namespace M_Audition
{
    partial class ExchangeMoreInfo
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
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.LblUser = new System.Windows.Forms.Label();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.GrdInfo = new System.Windows.Forms.DataGridView();
            this.dividerPanel2.SuspendLayout();
            this.dividerPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Controls.Add(this.LblUser);
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(576, 25);
            this.dividerPanel2.TabIndex = 1;
            // 
            // LblUser
            // 
            this.LblUser.AutoSize = true;
            this.LblUser.Location = new System.Drawing.Point(-1, 9);
            this.LblUser.Name = "LblUser";
            this.LblUser.Size = new System.Drawing.Size(0, 12);
            this.LblUser.TabIndex = 0;
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.GrdInfo);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 35);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(576, 258);
            this.dividerPanel1.TabIndex = 2;
            // 
            // GrdInfo
            // 
            this.GrdInfo.AllowUserToAddRows = false;
            this.GrdInfo.AllowUserToDeleteRows = false;
            this.GrdInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdInfo.Location = new System.Drawing.Point(0, 0);
            this.GrdInfo.Name = "GrdInfo";
            this.GrdInfo.ReadOnly = true;
            this.GrdInfo.RowTemplate.Height = 23;
            this.GrdInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdInfo.Size = new System.Drawing.Size(576, 258);
            this.GrdInfo.TabIndex = 0;
            // 
            // ExchangeMoreInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 303);
            this.Controls.Add(this.dividerPanel1);
            this.Controls.Add(this.dividerPanel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExchangeMoreInfo";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "道具回收兑换详细记录";
            this.dividerPanel2.ResumeLayout(false);
            this.dividerPanel2.PerformLayout();
            this.dividerPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DividerPanel.DividerPanel dividerPanel2;
        private System.Windows.Forms.Label LblUser;
        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.DataGridView GrdInfo;

    }
}