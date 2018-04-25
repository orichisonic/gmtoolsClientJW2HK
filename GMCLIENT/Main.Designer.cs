namespace GMCLIENT
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MtmGM = new System.Windows.Forms.ToolStripMenuItem();
            this.MtmGame = new System.Windows.Forms.ToolStripMenuItem();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.dPanelLeft = new DividerPanel.DividerPanel();
            this.TrvMenu = new System.Windows.Forms.TreeView();
            this.dpStatus = new DividerPanel.DividerPanel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel_mdi_tab = new System.Windows.Forms.Panel();
            this.tabControl_mdichild = new System.Windows.Forms.TabControl();
            this.imageList_tabpage_icons = new System.Windows.Forms.ImageList(this.components);
            this.dpMiddle = new DividerPanel.DividerPanel();
            this.picOpenClose = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.dPanelLeft.SuspendLayout();
            this.dpStatus.SuspendLayout();
            this.panel_mdi_tab.SuspendLayout();
            this.dpMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOpenClose)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MtmGM,
            this.MtmGame});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(715, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MtmGM
            // 
            this.MtmGM.Name = "MtmGM";
            this.MtmGM.Size = new System.Drawing.Size(67, 20);
            this.MtmGM.Text = "系统管理";
            // 
            // MtmGame
            // 
            this.MtmGame.Name = "MtmGame";
            this.MtmGame.Size = new System.Drawing.Size(67, 20);
            this.MtmGame.Text = "游戏管理";
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.BorderSide = System.Windows.Forms.Border3DSide.Top;
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(0, 24);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(715, 10);
            this.dividerPanel1.TabIndex = 1;
            // 
            // dPanelLeft
            // 
            this.dPanelLeft.AllowDrop = true;
            this.dPanelLeft.Controls.Add(this.TrvMenu);
            this.dPanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.dPanelLeft.Location = new System.Drawing.Point(0, 34);
            this.dPanelLeft.Name = "dividerPanel2";
            this.dPanelLeft.Padding = new System.Windows.Forms.Padding(2);
            this.dPanelLeft.Size = new System.Drawing.Size(183, 347);
            this.dPanelLeft.TabIndex = 4;
            // 
            // TrvMenu
            // 
            this.TrvMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrvMenu.Location = new System.Drawing.Point(2, 2);
            this.TrvMenu.Name = "TrvMenu";
            this.TrvMenu.Size = new System.Drawing.Size(179, 343);
            this.TrvMenu.TabIndex = 0;
            this.TrvMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TrvMenu_AfterSelect);
            this.TrvMenu.Click += new System.EventHandler(this.TrvMenu_Click);
            // 
            // dpStatus
            // 
            this.dpStatus.AllowDrop = true;
            this.dpStatus.Controls.Add(this.lblStatus);
            this.dpStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dpStatus.Location = new System.Drawing.Point(193, 356);
            this.dpStatus.Name = "dpStatus";
            this.dpStatus.Size = new System.Drawing.Size(522, 25);
            this.dpStatus.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(6, 6);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 12);
            this.lblStatus.TabIndex = 0;
            // 
            // panel_mdi_tab
            // 
            this.panel_mdi_tab.Controls.Add(this.tabControl_mdichild);
            this.panel_mdi_tab.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_mdi_tab.Location = new System.Drawing.Point(193, 34);
            this.panel_mdi_tab.Name = "panel_mdi_tab";
            this.panel_mdi_tab.Size = new System.Drawing.Size(522, 27);
            this.panel_mdi_tab.TabIndex = 10;
            // 
            // tabControl_mdichild
            // 
            this.tabControl_mdichild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_mdichild.ImageList = this.imageList_tabpage_icons;
            this.tabControl_mdichild.Location = new System.Drawing.Point(0, 0);
            this.tabControl_mdichild.Name = "tabControl_mdichild";
            this.tabControl_mdichild.SelectedIndex = 0;
            this.tabControl_mdichild.Size = new System.Drawing.Size(522, 27);
            this.tabControl_mdichild.TabIndex = 9;
            this.tabControl_mdichild.MouseLeave += new System.EventHandler(this.tabControl_mdichild_MouseLeave);
            this.tabControl_mdichild.Click += new System.EventHandler(this.tabControl_mdichild_Click);
            this.tabControl_mdichild.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tabControl_mdichild_MouseMove);
            this.tabControl_mdichild.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tabControl_mdichild_MouseUp);
            // 
            // imageList_tabpage_icons
            // 
            this.imageList_tabpage_icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_tabpage_icons.ImageStream")));
            this.imageList_tabpage_icons.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_tabpage_icons.Images.SetKeyName(0, "close.gif");
            this.imageList_tabpage_icons.Images.SetKeyName(1, "close_over.gif");
            // 
            // dpMiddle
            // 
            this.dpMiddle.AllowDrop = true;
            this.dpMiddle.Controls.Add(this.picOpenClose);
            this.dpMiddle.Dock = System.Windows.Forms.DockStyle.Left;
            this.dpMiddle.Location = new System.Drawing.Point(183, 34);
            this.dpMiddle.Name = "dividerPanel3";
            this.dpMiddle.Size = new System.Drawing.Size(10, 347);
            this.dpMiddle.TabIndex = 5;
            // 
            // picOpenClose
            // 
            this.picOpenClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picOpenClose.Image = global::GMCLIENT.Properties.Resources.left_right2;
            this.picOpenClose.Location = new System.Drawing.Point(1, 129);
            this.picOpenClose.Margin = new System.Windows.Forms.Padding(0);
            this.picOpenClose.Name = "picOpenClose";
            this.picOpenClose.Size = new System.Drawing.Size(6, 50);
            this.picOpenClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picOpenClose.TabIndex = 0;
            this.picOpenClose.TabStop = false;
            this.picOpenClose.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 381);
            this.Controls.Add(this.panel_mdi_tab);
            this.Controls.Add(this.dpStatus);
            this.Controls.Add(this.dpMiddle);
            this.Controls.Add(this.dPanelLeft);
            this.Controls.Add(this.dividerPanel1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GMTOOLS 游戏管理工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.MdiChildActivate += new System.EventHandler(this.FormMain_MdiChildActivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.dPanelLeft.ResumeLayout(false);
            this.dpStatus.ResumeLayout(false);
            this.dpStatus.PerformLayout();
            this.panel_mdi_tab.ResumeLayout(false);
            this.dpMiddle.ResumeLayout(false);
            this.dpMiddle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOpenClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MtmGM;
        private System.Windows.Forms.ToolStripMenuItem MtmGame;
        private DividerPanel.DividerPanel dividerPanel1;
        private DividerPanel.DividerPanel dPanelLeft;
        private System.Windows.Forms.TreeView TrvMenu;
        private DividerPanel.DividerPanel dpStatus;
        private System.Windows.Forms.Panel panel_mdi_tab;
        private System.Windows.Forms.TabControl tabControl_mdichild;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ImageList imageList_tabpage_icons;
        private DividerPanel.DividerPanel dpMiddle;
        private System.Windows.Forms.PictureBox picOpenClose;
        private System.Windows.Forms.Timer timer1;
    }
}

