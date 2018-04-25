namespace C_Controls.LabelTextBox
{
    partial class LabelTextBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblText = new System.Windows.Forms.Label();
            this.TxtContent = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // LblText
            // 
            this.LblText.AutoSize = true;
            this.LblText.Location = new System.Drawing.Point(2, 6);
            this.LblText.Name = "LblText";
            this.LblText.Size = new System.Drawing.Size(47, 12);
            this.LblText.TabIndex = 0;
            this.LblText.Text = "LblText";
            // 
            // TxtContent
            // 
            this.TxtContent.Location = new System.Drawing.Point(54, 3);
            this.TxtContent.Name = "TxtContent";
            this.TxtContent.Size = new System.Drawing.Size(100, 21);
            this.TxtContent.TabIndex = 1;
            this.TxtContent.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TxtContent_PreviewKeyDown);
            this.TxtContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtContent_KeyDown);
            this.TxtContent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtContent_KeyPress);
            this.TxtContent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtContent_KeyUp);
            // 
            // LabelTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TxtContent);
            this.Controls.Add(this.LblText);
            this.Name = "LabelTextBox";
            this.Size = new System.Drawing.Size(164, 27);
            this.Load += new System.EventHandler(this.LabelTextBox_Load);
            this.SizeChanged += new System.EventHandler(this.LabelTextBox_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblText;
        private System.Windows.Forms.MaskedTextBox TxtContent;
    }
}
