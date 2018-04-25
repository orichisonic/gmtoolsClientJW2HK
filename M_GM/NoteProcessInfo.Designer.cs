namespace M_GM
{
    partial class NoteProcessInfo
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
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.txtProcessContent = new System.Windows.Forms.TextBox();
            this.txtNotesContent = new System.Windows.Forms.TextBox();
            this.lblProcessDate = new System.Windows.Forms.Label();
            this.lblProcesser = new System.Windows.Forms.Label();
            this.lblNoteTitle = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.dividerPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.BackColor = System.Drawing.SystemColors.Menu;
            this.dividerPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.dividerPanel1.Controls.Add(this.dividerPanel2);
            this.dividerPanel1.Controls.Add(this.txtProcessContent);
            this.dividerPanel1.Controls.Add(this.txtNotesContent);
            this.dividerPanel1.Controls.Add(this.lblProcessDate);
            this.dividerPanel1.Controls.Add(this.lblProcesser);
            this.dividerPanel1.Controls.Add(this.lblNoteTitle);
            this.dividerPanel1.Controls.Add(this.label5);
            this.dividerPanel1.Controls.Add(this.label4);
            this.dividerPanel1.Controls.Add(this.label3);
            this.dividerPanel1.Controls.Add(this.label2);
            this.dividerPanel1.Controls.Add(this.label1);
            this.dividerPanel1.Controls.Add(this.linkLabel1);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel1.Location = new System.Drawing.Point(0, 0);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(484, 367);
            this.dividerPanel1.TabIndex = 13;
            this.dividerPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.dividerPanel1_Paint);
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.BorderSide = System.Windows.Forms.Border3DSide.Top;
            this.dividerPanel2.Location = new System.Drawing.Point(6, 212);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(472, 10);
            this.dividerPanel2.TabIndex = 24;
            // 
            // txtProcessContent
            // 
            this.txtProcessContent.BackColor = System.Drawing.SystemColors.Menu;
            this.txtProcessContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProcessContent.Location = new System.Drawing.Point(114, 271);
            this.txtProcessContent.Multiline = true;
            this.txtProcessContent.Name = "txtProcessContent";
            this.txtProcessContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProcessContent.Size = new System.Drawing.Size(348, 82);
            this.txtProcessContent.TabIndex = 23;
            // 
            // txtNotesContent
            // 
            this.txtNotesContent.BackColor = System.Drawing.SystemColors.Menu;
            this.txtNotesContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNotesContent.Location = new System.Drawing.Point(114, 60);
            this.txtNotesContent.Multiline = true;
            this.txtNotesContent.Name = "txtNotesContent";
            this.txtNotesContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotesContent.Size = new System.Drawing.Size(348, 144);
            this.txtNotesContent.TabIndex = 22;
            // 
            // lblProcessDate
            // 
            this.lblProcessDate.AutoSize = true;
            this.lblProcessDate.BackColor = System.Drawing.SystemColors.Menu;
            this.lblProcessDate.Location = new System.Drawing.Point(112, 248);
            this.lblProcessDate.Name = "lblProcessDate";
            this.lblProcessDate.Size = new System.Drawing.Size(41, 12);
            this.lblProcessDate.TabIndex = 21;
            this.lblProcessDate.Text = "label7";
            // 
            // lblProcesser
            // 
            this.lblProcesser.AutoSize = true;
            this.lblProcesser.BackColor = System.Drawing.SystemColors.Menu;
            this.lblProcesser.Location = new System.Drawing.Point(112, 226);
            this.lblProcesser.Name = "lblProcesser";
            this.lblProcesser.Size = new System.Drawing.Size(41, 12);
            this.lblProcesser.TabIndex = 20;
            this.lblProcesser.Text = "label6";
            // 
            // lblNoteTitle
            // 
            this.lblNoteTitle.AutoSize = true;
            this.lblNoteTitle.BackColor = System.Drawing.SystemColors.Menu;
            this.lblNoteTitle.Location = new System.Drawing.Point(112, 36);
            this.lblNoteTitle.Name = "lblNoteTitle";
            this.lblNoteTitle.Size = new System.Drawing.Size(17, 12);
            this.lblNoteTitle.TabIndex = 19;
            this.lblNoteTitle.Text = "11";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Menu;
            this.label5.Location = new System.Drawing.Point(12, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "处理过程描述：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Menu;
            this.label4.Location = new System.Drawing.Point(36, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "处理日期：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Menu;
            this.label3.Location = new System.Drawing.Point(24, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "内　　　容：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Menu;
            this.label2.Location = new System.Drawing.Point(24, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "NOTES 主题：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Menu;
            this.label1.Location = new System.Drawing.Point(48, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "处理人：";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.SystemColors.Menu;
            this.linkLabel1.Location = new System.Drawing.Point(433, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(29, 12);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "关闭";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // NoteProcessInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(484, 367);
            this.Controls.Add(this.dividerPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NoteProcessInfo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "NoteProcessInfo";
            this.Load += new System.EventHandler(this.NoteProcessInfo_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.TextBox txtProcessContent;
        private System.Windows.Forms.TextBox txtNotesContent;
        private System.Windows.Forms.Label lblProcessDate;
        private System.Windows.Forms.Label lblProcesser;
        private System.Windows.Forms.Label lblNoteTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private DividerPanel.DividerPanel dividerPanel2;
    }
}