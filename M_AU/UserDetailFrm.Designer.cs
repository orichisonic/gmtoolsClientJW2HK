namespace M_Audition
{
    partial class Frm_YOU_UserDetail
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
            this.BtnSearch = new System.Windows.Forms.Button();
            this.TxtID = new System.Windows.Forms.TextBox();
            this.LblID = new System.Windows.Forms.Label();
            this.GrpResult = new System.Windows.Forms.GroupBox();
            this.PnlResult = new System.Windows.Forms.Panel();
            this.BtnReset = new System.Windows.Forms.Button();
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.TxtUser = new System.Windows.Forms.TextBox();
            this.LblUser = new System.Windows.Forms.Label();
            this.btnResetV = new System.Windows.Forms.Button();
            this.btnRestIDCode = new System.Windows.Forms.Button();
            this.GrpResult.SuspendLayout();
            this.GrpSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(215, 17);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 8;
            this.BtnSearch.Text = "查    找";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TxtID
            // 
            this.TxtID.Location = new System.Drawing.Point(88, 19);
            this.TxtID.Name = "TxtID";
            this.TxtID.Size = new System.Drawing.Size(121, 21);
            this.TxtID.TabIndex = 3;
            // 
            // LblID
            // 
            this.LblID.AutoSize = true;
            this.LblID.Location = new System.Drawing.Point(17, 57);
            this.LblID.Name = "LblID";
            this.LblID.Size = new System.Drawing.Size(65, 12);
            this.LblID.TabIndex = 2;
            this.LblID.Text = "昵    称：";
            // 
            // GrpResult
            // 
            this.GrpResult.Controls.Add(this.PnlResult);
            this.GrpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpResult.Location = new System.Drawing.Point(10, 105);
            this.GrpResult.Name = "GrpResult";
            this.GrpResult.Size = new System.Drawing.Size(647, 287);
            this.GrpResult.TabIndex = 17;
            this.GrpResult.TabStop = false;
            this.GrpResult.Text = "查询结果";
            // 
            // PnlResult
            // 
            this.PnlResult.AutoScroll = true;
            this.PnlResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlResult.Location = new System.Drawing.Point(3, 17);
            this.PnlResult.Name = "PnlResult";
            this.PnlResult.Size = new System.Drawing.Size(641, 267);
            this.PnlResult.TabIndex = 0;
            // 
            // BtnReset
            // 
            this.BtnReset.Location = new System.Drawing.Point(215, 52);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(75, 23);
            this.BtnReset.TabIndex = 9;
            this.BtnReset.Text = "重    置";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.btnResetV);
            this.GrpSearch.Controls.Add(this.btnRestIDCode);
            this.GrpSearch.Controls.Add(this.BtnReset);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Controls.Add(this.TxtUser);
            this.GrpSearch.Controls.Add(this.LblUser);
            this.GrpSearch.Controls.Add(this.TxtID);
            this.GrpSearch.Controls.Add(this.LblID);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(10, 10);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(647, 95);
            this.GrpSearch.TabIndex = 16;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索条件";
            // 
            // TxtUser
            // 
            this.TxtUser.Location = new System.Drawing.Point(88, 54);
            this.TxtUser.Name = "TxtUser";
            this.TxtUser.Size = new System.Drawing.Size(121, 21);
            this.TxtUser.TabIndex = 7;
            // 
            // LblUser
            // 
            this.LblUser.AutoSize = true;
            this.LblUser.Location = new System.Drawing.Point(17, 23);
            this.LblUser.Name = "LblUser";
            this.LblUser.Size = new System.Drawing.Size(65, 12);
            this.LblUser.TabIndex = 6;
            this.LblUser.Text = "用 户 名：";
            // 
            // btnResetV
            // 
            this.btnResetV.Enabled = false;
            this.btnResetV.Location = new System.Drawing.Point(309, 46);
            this.btnResetV.Name = "btnResetV";
            this.btnResetV.Size = new System.Drawing.Size(128, 23);
            this.btnResetV.TabIndex = 11;
            this.btnResetV.Text = "重置验证码";
            this.btnResetV.UseVisualStyleBackColor = true;
            this.btnResetV.Click += new System.EventHandler(this.btnResetV_Click);
            // 
            // btnRestIDCode
            // 
            this.btnRestIDCode.Enabled = false;
            this.btnRestIDCode.Location = new System.Drawing.Point(309, 17);
            this.btnRestIDCode.Name = "btnRestIDCode";
            this.btnRestIDCode.Size = new System.Drawing.Size(128, 23);
            this.btnRestIDCode.TabIndex = 10;
            this.btnRestIDCode.Text = "重置身份证及其类型";
            this.btnRestIDCode.UseVisualStyleBackColor = true;
            this.btnRestIDCode.Click += new System.EventHandler(this.btnRestIDCode_Click);
            // 
            // Frm_YOU_UserDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 402);
            this.Controls.Add(this.GrpResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "Frm_YOU_UserDetail";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "9you用户信息[充值消费]";
            this.Load += new System.EventHandler(this.Frm_YOU_UserDetail_Load);
            this.GrpResult.ResumeLayout(false);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox TxtID;
        private System.Windows.Forms.Label LblID;
        private System.Windows.Forms.GroupBox GrpResult;
        private System.Windows.Forms.Panel PnlResult;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.TextBox TxtUser;
        private System.Windows.Forms.Label LblUser;
        private System.Windows.Forms.Button btnResetV;
        private System.Windows.Forms.Button btnRestIDCode;
    }
}