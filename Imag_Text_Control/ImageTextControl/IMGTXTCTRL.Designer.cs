using System.Drawing;

namespace ImageTextControl
{
    partial class IMGTXTCTRL
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.IMG = new System.Windows.Forms.PictureBox();
            this.TXT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.IMG)).BeginInit();
            this.SuspendLayout();
            // 
            // IMG
            // 
            this.IMG.Location = new System.Drawing.Point(0, 0);
            this.IMG.Name = "IMG";
            this.IMG.Size = new System.Drawing.Size(18, 18);
            this.IMG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.IMG.TabIndex = 0;
            this.IMG.TabStop = false;
            this.IMG.MouseLeave += new System.EventHandler(this.IMG_MouseLeave);
            this.IMG.Click += new System.EventHandler(this.IMG_Click);
            this.IMG.MouseMove += new System.Windows.Forms.MouseEventHandler(this.IMG_MouseMove);
            // 
            // TXT
            // 
            this.TXT.AutoSize = true;
            this.TXT.Location = new System.Drawing.Point(24, 3);
            this.TXT.Name = "TXT";
            this.TXT.Size = new System.Drawing.Size(0, 12);
            this.TXT.TabIndex = 1;
            this.TXT.MouseLeave += new System.EventHandler(this.TXT_MouseLeave);
            this.TXT.Click += new System.EventHandler(this.TXT_Click);
            this.TXT.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TXT_MouseMove);
            // 
            // IMGTXTCTRL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TXT);
            this.Controls.Add(this.IMG);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "IMGTXTCTRL";
            this.Size = new System.Drawing.Size(140, 20);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.IMGTXTCTRL_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.IMGTXT_MOUSEMOVE);
            this.MouseLeave += new System.EventHandler(this.IMGTXTCTRL_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.IMG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox IMG;
        private System.Windows.Forms.Label TXT;
    }
}
