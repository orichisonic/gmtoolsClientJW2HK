namespace M_GD
{
    partial class FrmGDActiveCode
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtCondition = new System.Windows.Forms.TextBox();
            this.lblCondition = new System.Windows.Forms.Label();
            this.GrdActive = new System.Windows.Forms.DataGridView();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerActiveCode = new System.ComponentModel.BackgroundWorker();
            this.chbCondition = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.GrpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdActive)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.checkBox1);
            this.GrpSearch.Controls.Add(this.chbCondition);
            this.GrpSearch.Controls.Add(this.btnClose);
            this.GrpSearch.Controls.Add(this.btnSearch);
            this.GrpSearch.Controls.Add(this.txtCondition);
            this.GrpSearch.Controls.Add(this.lblCondition);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(730, 108);
            this.GrpSearch.TabIndex = 14;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索条件";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(569, 56);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(569, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCondition
            // 
            this.txtCondition.Location = new System.Drawing.Point(120, 29);
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(168, 21);
            this.txtCondition.TabIndex = 1;
            // 
            // lblCondition
            // 
            this.lblCondition.AutoSize = true;
            this.lblCondition.Location = new System.Drawing.Point(12, 32);
            this.lblCondition.Name = "lblCondition";
            this.lblCondition.Size = new System.Drawing.Size(89, 12);
            this.lblCondition.TabIndex = 0;
            this.lblCondition.Text = "通过卡号查询：";
            // 
            // GrdActive
            // 
            this.GrdActive.AllowUserToAddRows = false;
            this.GrdActive.AllowUserToDeleteRows = false;
            this.GrdActive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdActive.Location = new System.Drawing.Point(0, 108);
            this.GrdActive.Name = "GrdActive";
            this.GrdActive.ReadOnly = true;
            this.GrdActive.RowTemplate.Height = 23;
            this.GrdActive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdActive.Size = new System.Drawing.Size(730, 414);
            this.GrdActive.TabIndex = 16;
            // 
            // backgroundWorkerSearch
            // 
            this.backgroundWorkerSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSearch_DoWork);
            this.backgroundWorkerSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSearch_RunWorkerCompleted);
            // 
            // backgroundWorkerActiveCode
            // 
            this.backgroundWorkerActiveCode.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerActiveCode_DoWork);
            this.backgroundWorkerActiveCode.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerActiveCode_RunWorkerCompleted);
            // 
            // chbCondition
            // 
            this.chbCondition.AutoSize = true;
            this.chbCondition.Location = new System.Drawing.Point(331, 53);
            this.chbCondition.Name = "chbCondition";
            this.chbCondition.Size = new System.Drawing.Size(108, 16);
            this.chbCondition.TabIndex = 9;
            this.chbCondition.Text = "通过用户名查询";
            this.chbCondition.UseVisualStyleBackColor = true;
            this.chbCondition.CheckedChanged += new System.EventHandler(this.chbCondition_CheckedChanged_1);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(331, 31);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "通过卡号查询";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.chbCondition_CheckedChanged);
            // 
            // FrmGDActiveCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 522);
            this.Controls.Add(this.GrdActive);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmGDActiveCode";
            this.Text = "黄金新手卡使用查询";
            this.Load += new System.EventHandler(this.FrmGDActiveCode_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdActive)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtCondition;
        private System.Windows.Forms.Label lblCondition;
        private System.Windows.Forms.DataGridView GrdActive;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerActiveCode;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chbCondition;
    }
}