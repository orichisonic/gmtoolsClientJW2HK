namespace M_RC
{
    partial class BrowseMusicName1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowseMusicName));
            this.musicName = new System.Windows.Forms.Label();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dividerPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // musicName
            // 
            this.musicName.AutoSize = true;
            this.musicName.Location = new System.Drawing.Point(40, 17);
            this.musicName.Name = "musicName";
            this.musicName.Size = new System.Drawing.Size(83, 12);
            this.musicName.TabIndex = 0;
            this.musicName.Text = "NowLoading...";
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.musicName);
            this.dividerPanel1.Controls.Add(this.pictureBox1);
            this.dividerPanel1.Location = new System.Drawing.Point(8, 5);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(176, 51);
            this.dividerPanel1.TabIndex = 2;
            this.dividerPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.dividerPanel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = global::M_RC.Properties.Resources.close;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(156, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 15);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
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
            this.ClientSize = new System.Drawing.Size(190, 61);
            this.Controls.Add(this.dividerPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BrowseMusicName";
            this.ShowInTaskbar = false;
            this.Text = "BrowseMusicName";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BrowseMusicName_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BrowseMusicName_MouseDown);
            this.Load += new System.EventHandler(this.BrowseMusicName_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label musicName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.Timer timer1;
    }
}