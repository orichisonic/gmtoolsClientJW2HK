namespace M_SDO
{
    partial class BrowseMusicName
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
            this.musicName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.dividerPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // musicName
            // 
            this.musicName.AutoSize = true;
            this.musicName.Location = new System.Drawing.Point(15, 22);
            this.musicName.Name = "musicName";
            this.musicName.Size = new System.Drawing.Size(83, 12);
            this.musicName.TabIndex = 0;
            this.musicName.Text = "NowLoading...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::M_SDO.Properties.Resources.close;
            this.pictureBox1.Location = new System.Drawing.Point(175, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 15);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.pictureBox1);
            this.dividerPanel1.Controls.Add(this.musicName);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel1.Location = new System.Drawing.Point(0, 0);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(198, 52);
            this.dividerPanel1.TabIndex = 2;
            this.dividerPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.dividerPanel1_Paint);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BrowseMusicName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 52);
            this.Controls.Add(this.dividerPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BrowseMusicName";
            this.ShowInTaskbar = false;
            this.Text = "BrowseMusicName";
            this.Load += new System.EventHandler(this.BrowseMusicName_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label musicName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.Timer timer1;
    }
}