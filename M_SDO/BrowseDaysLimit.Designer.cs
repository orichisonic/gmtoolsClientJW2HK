namespace M_SDO
{
    partial class BrowseDaysLimit
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
            this.components = new System.ComponentModel.Container();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DaysLimit = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dividerPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.pictureBox1);
            this.dividerPanel1.Controls.Add(this.DaysLimit);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel1.Location = new System.Drawing.Point(0, 0);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(176, 54);
            this.dividerPanel1.TabIndex = 3;
            this.dividerPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.dividerPanel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::M_SDO.Properties.Resources.close;
            this.pictureBox1.Location = new System.Drawing.Point(143, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 15);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // DaysLimit
            // 
            this.DaysLimit.AutoSize = true;
            this.DaysLimit.Location = new System.Drawing.Point(12, 21);
            this.DaysLimit.Name = "DaysLimit";
            this.DaysLimit.Size = new System.Drawing.Size(83, 12);
            this.DaysLimit.TabIndex = 0;
            this.DaysLimit.Text = "NowLoading...";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BrowseDaysLimit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 54);
            this.Controls.Add(this.dividerPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BrowseDaysLimit";
            this.ShowInTaskbar = false;
            this.Text = "BrowseDaysLimit";
            this.Load += new System.EventHandler(this.BrowseDaysLimit_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label DaysLimit;
        private System.Windows.Forms.Timer timer1;


    }
}