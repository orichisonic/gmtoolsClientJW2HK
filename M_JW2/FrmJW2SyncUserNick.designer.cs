namespace M_AU
{
    partial class FrmJW2SyncUserNick
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbxServerIP = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNYNick = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAUNick = new System.Windows.Forms.TextBox();
            this.gbNickResult = new System.Windows.Forms.GroupBox();
            this.btnSync = new System.Windows.Forms.Button();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSync = new System.ComponentModel.BackgroundWorker();
            this.gbNickResult.SuspendLayout();
            this.gbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "伺服器：";
            // 
            // cbxServerIP
            // 
            this.cbxServerIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServerIP.FormattingEnabled = true;
            this.cbxServerIP.Location = new System.Drawing.Point(10, 37);
            this.cbxServerIP.Name = "cbxServerIP";
            this.cbxServerIP.Size = new System.Drawing.Size(238, 20);
            this.cbxServerIP.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "玩家帳號：";
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(10, 85);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(238, 21);
            this.txtAccount.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "9you昵稱：";
            // 
            // txtNYNick
            // 
            this.txtNYNick.Location = new System.Drawing.Point(14, 36);
            this.txtNYNick.Name = "txtNYNick";
            this.txtNYNick.Size = new System.Drawing.Size(234, 21);
            this.txtNYNick.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "AU昵稱：";
            // 
            // txtAUNick
            // 
            this.txtAUNick.Location = new System.Drawing.Point(14, 82);
            this.txtAUNick.Name = "txtAUNick";
            this.txtAUNick.Size = new System.Drawing.Size(234, 21);
            this.txtAUNick.TabIndex = 7;
            // 
            // gbNickResult
            // 
            this.gbNickResult.Controls.Add(this.btnSync);
            this.gbNickResult.Controls.Add(this.label3);
            this.gbNickResult.Controls.Add(this.txtAUNick);
            this.gbNickResult.Controls.Add(this.txtNYNick);
            this.gbNickResult.Controls.Add(this.label4);
            this.gbNickResult.Location = new System.Drawing.Point(21, 189);
            this.gbNickResult.Name = "gbNickResult";
            this.gbNickResult.Size = new System.Drawing.Size(259, 145);
            this.gbNickResult.TabIndex = 8;
            this.gbNickResult.TabStop = false;
            this.gbNickResult.Text = "昵稱";
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(14, 111);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(94, 23);
            this.btnSync.TabIndex = 8;
            this.btnSync.Text = "同步AU昵稱";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.button1);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Controls.Add(this.label1);
            this.gbSearch.Controls.Add(this.cbxServerIP);
            this.gbSearch.Controls.Add(this.txtAccount);
            this.gbSearch.Controls.Add(this.label2);
            this.gbSearch.Location = new System.Drawing.Point(21, 21);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(259, 152);
            this.gbSearch.TabIndex = 9;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "查詢";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "重置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(10, 115);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查詢";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // backgroundWorkerFormLoad
            // 
            this.backgroundWorkerFormLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFormLoad_DoWork);
            this.backgroundWorkerFormLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFormLoad_RunWorkerCompleted);
            // 
            // backgroundWorkerSearch
            // 
            this.backgroundWorkerSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSearch_DoWork);
            this.backgroundWorkerSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSearch_RunWorkerCompleted);
            // 
            // backgroundWorkerSync
            // 
            this.backgroundWorkerSync.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSync_DoWork);
            this.backgroundWorkerSync.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSync_RunWorkerCompleted);
            // 
            // FrmJW2SyncUserNick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 392);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.gbNickResult);
            this.Name = "FrmJW2SyncUserNick";
            this.Text = "昵稱同步[勁舞團2]";
            this.Load += new System.EventHandler(this.FrmJW2SyncUserNick_Load);
            this.gbNickResult.ResumeLayout(false);
            this.gbNickResult.PerformLayout();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxServerIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNYNick;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAUNick;
        private System.Windows.Forms.GroupBox gbNickResult;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSync;
    }
}