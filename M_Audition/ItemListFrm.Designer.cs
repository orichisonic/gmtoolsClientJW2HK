namespace M_Audition
{
    partial class ItemListFrm
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
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.ChkGift = new System.Windows.Forms.CheckBox();
            this.ChkStar = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChkLove = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.CmbResult = new System.Windows.Forms.ComboBox();
            this.CmbDisplay = new System.Windows.Forms.ComboBox();
            this.LblDisplay = new System.Windows.Forms.Label();
            this.CmbSort = new System.Windows.Forms.ComboBox();
            this.LblSort = new System.Windows.Forms.Label();
            this.LblLike = new System.Windows.Forms.CheckBox();
            this.TxtPrice = new System.Windows.Forms.TextBox();
            this.LblPrice = new System.Windows.Forms.Label();
            this.TxtCode = new System.Windows.Forms.TextBox();
            this.LblCode = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.LblName = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.LblPage = new System.Windows.Forms.Label();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.GrdResult = new System.Windows.Forms.DataGridView();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.lblCurrPage = new System.Windows.Forms.Label();
            this.GrpSearch.SuspendLayout();
            this.dividerPanel1.SuspendLayout();
            this.dividerPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdResult)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.ChkGift);
            this.GrpSearch.Controls.Add(this.ChkStar);
            this.GrpSearch.Controls.Add(this.label1);
            this.GrpSearch.Controls.Add(this.ChkLove);
            this.GrpSearch.Controls.Add(this.checkBox2);
            this.GrpSearch.Controls.Add(this.checkBox1);
            this.GrpSearch.Controls.Add(this.BtnReset);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Controls.Add(this.CmbResult);
            this.GrpSearch.Controls.Add(this.CmbDisplay);
            this.GrpSearch.Controls.Add(this.LblDisplay);
            this.GrpSearch.Controls.Add(this.CmbSort);
            this.GrpSearch.Controls.Add(this.LblSort);
            this.GrpSearch.Controls.Add(this.LblLike);
            this.GrpSearch.Controls.Add(this.TxtPrice);
            this.GrpSearch.Controls.Add(this.LblPrice);
            this.GrpSearch.Controls.Add(this.TxtCode);
            this.GrpSearch.Controls.Add(this.LblCode);
            this.GrpSearch.Controls.Add(this.TxtName);
            this.GrpSearch.Controls.Add(this.LblName);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(10, 10);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(635, 148);
            this.GrpSearch.TabIndex = 0;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索条件";
            // 
            // ChkGift
            // 
            this.ChkGift.AutoSize = true;
            this.ChkGift.Location = new System.Drawing.Point(357, 38);
            this.ChkGift.Name = "ChkGift";
            this.ChkGift.Size = new System.Drawing.Size(48, 16);
            this.ChkGift.TabIndex = 7;
            this.ChkGift.Text = "礼包";
            this.ChkGift.UseVisualStyleBackColor = true;
            // 
            // ChkStar
            // 
            this.ChkStar.AutoSize = true;
            this.ChkStar.Location = new System.Drawing.Point(357, 62);
            this.ChkStar.Name = "ChkStar";
            this.ChkStar.Size = new System.Drawing.Size(72, 16);
            this.ChkStar.TabIndex = 8;
            this.ChkStar.Text = "明星套装";
            this.ChkStar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(355, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "其他条件：";
            // 
            // ChkLove
            // 
            this.ChkLove.AutoSize = true;
            this.ChkLove.Location = new System.Drawing.Point(357, 84);
            this.ChkLove.Name = "ChkLove";
            this.ChkLove.Size = new System.Drawing.Size(60, 16);
            this.ChkLove.TabIndex = 9;
            this.ChkLove.Text = "情侣装";
            this.ChkLove.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(73, 103);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 16);
            this.checkBox2.TabIndex = 20;
            this.checkBox2.Text = "模糊搜索";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(74, 62);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "模糊搜索";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // BtnReset
            // 
            this.BtnReset.Location = new System.Drawing.Point(463, 50);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(75, 23);
            this.BtnReset.TabIndex = 17;
            this.BtnReset.Text = "重置";
            this.BtnReset.UseVisualStyleBackColor = true;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(463, 19);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 16;
            this.BtnSearch.Text = "搜索";
            this.BtnSearch.UseVisualStyleBackColor = true;
            // 
            // CmbResult
            // 
            this.CmbResult.FormattingEnabled = true;
            this.CmbResult.Location = new System.Drawing.Point(173, 37);
            this.CmbResult.Name = "CmbResult";
            this.CmbResult.Size = new System.Drawing.Size(154, 20);
            this.CmbResult.TabIndex = 15;
            // 
            // CmbDisplay
            // 
            this.CmbDisplay.FormattingEnabled = true;
            this.CmbDisplay.Location = new System.Drawing.Point(173, 79);
            this.CmbDisplay.Name = "CmbDisplay";
            this.CmbDisplay.Size = new System.Drawing.Size(154, 20);
            this.CmbDisplay.TabIndex = 14;
            // 
            // LblDisplay
            // 
            this.LblDisplay.AutoSize = true;
            this.LblDisplay.Location = new System.Drawing.Point(171, 63);
            this.LblDisplay.Name = "LblDisplay";
            this.LblDisplay.Size = new System.Drawing.Size(65, 12);
            this.LblDisplay.TabIndex = 13;
            this.LblDisplay.Text = "显示方式：";
            // 
            // CmbSort
            // 
            this.CmbSort.FormattingEnabled = true;
            this.CmbSort.Location = new System.Drawing.Point(173, 105);
            this.CmbSort.Name = "CmbSort";
            this.CmbSort.Size = new System.Drawing.Size(154, 20);
            this.CmbSort.TabIndex = 12;
            // 
            // LblSort
            // 
            this.LblSort.AutoSize = true;
            this.LblSort.Location = new System.Drawing.Point(171, 21);
            this.LblSort.Name = "LblSort";
            this.LblSort.Size = new System.Drawing.Size(65, 12);
            this.LblSort.TabIndex = 11;
            this.LblSort.Text = "道具类别：";
            // 
            // LblLike
            // 
            this.LblLike.AutoSize = true;
            this.LblLike.Location = new System.Drawing.Point(74, 19);
            this.LblLike.Name = "LblLike";
            this.LblLike.Size = new System.Drawing.Size(72, 16);
            this.LblLike.TabIndex = 10;
            this.LblLike.Text = "模糊搜索";
            this.LblLike.UseVisualStyleBackColor = true;
            // 
            // TxtPrice
            // 
            this.TxtPrice.Location = new System.Drawing.Point(8, 119);
            this.TxtPrice.Name = "TxtPrice";
            this.TxtPrice.Size = new System.Drawing.Size(138, 21);
            this.TxtPrice.TabIndex = 5;
            // 
            // LblPrice
            // 
            this.LblPrice.AutoSize = true;
            this.LblPrice.Location = new System.Drawing.Point(6, 104);
            this.LblPrice.Name = "LblPrice";
            this.LblPrice.Size = new System.Drawing.Size(65, 12);
            this.LblPrice.TabIndex = 4;
            this.LblPrice.Text = "道具价格：";
            // 
            // TxtCode
            // 
            this.TxtCode.Location = new System.Drawing.Point(8, 78);
            this.TxtCode.Name = "TxtCode";
            this.TxtCode.Size = new System.Drawing.Size(138, 21);
            this.TxtCode.TabIndex = 3;
            // 
            // LblCode
            // 
            this.LblCode.AutoSize = true;
            this.LblCode.Location = new System.Drawing.Point(6, 63);
            this.LblCode.Name = "LblCode";
            this.LblCode.Size = new System.Drawing.Size(65, 12);
            this.LblCode.TabIndex = 2;
            this.LblCode.Text = "游戏代码：";
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(8, 36);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(138, 21);
            this.TxtName.TabIndex = 1;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(6, 21);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(65, 12);
            this.LblName.TabIndex = 0;
            this.LblName.Text = "道具名称：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(193, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(54, 20);
            this.comboBox1.TabIndex = 6;
            // 
            // LblPage
            // 
            this.LblPage.AutoSize = true;
            this.LblPage.Location = new System.Drawing.Point(4, 18);
            this.LblPage.Name = "LblPage";
            this.LblPage.Size = new System.Drawing.Size(269, 12);
            this.LblPage.TabIndex = 3;
            this.LblPage.Text = "共　　页，当前第　　页，转到第　　　　　　页";
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel1.Controls.Add(this.lblCurrPage);
            this.dividerPanel1.Controls.Add(this.lblPageCount);
            this.dividerPanel1.Controls.Add(this.comboBox1);
            this.dividerPanel1.Controls.Add(this.LblPage);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 158);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(635, 36);
            this.dividerPanel1.TabIndex = 3;
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Controls.Add(this.GrdResult);
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 194);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(635, 337);
            this.dividerPanel2.TabIndex = 4;
            // 
            // GrdResult
            // 
            this.GrdResult.AllowUserToAddRows = false;
            this.GrdResult.AllowUserToDeleteRows = false;
            this.GrdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdResult.Location = new System.Drawing.Point(0, 0);
            this.GrdResult.Name = "GrdResult";
            this.GrdResult.ReadOnly = true;
            this.GrdResult.RowTemplate.Height = 23;
            this.GrdResult.Size = new System.Drawing.Size(635, 337);
            this.GrdResult.TabIndex = 2;
            // 
            // lblPageCount
            // 
            this.lblPageCount.AutoSize = true;
            this.lblPageCount.ForeColor = System.Drawing.Color.Red;
            this.lblPageCount.Location = new System.Drawing.Point(25, 18);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(11, 12);
            this.lblPageCount.TabIndex = 7;
            this.lblPageCount.Text = "1";
            // 
            // lblCurrPage
            // 
            this.lblCurrPage.AutoSize = true;
            this.lblCurrPage.ForeColor = System.Drawing.Color.Red;
            this.lblCurrPage.Location = new System.Drawing.Point(110, 18);
            this.lblCurrPage.Name = "lblCurrPage";
            this.lblCurrPage.Size = new System.Drawing.Size(11, 12);
            this.lblCurrPage.TabIndex = 8;
            this.lblCurrPage.Text = "1";
            // 
            // ItemListFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 541);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Controls.Add(this.GrpSearch);
            this.Name = "ItemListFrm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "ItemListFrm";
            this.Load += new System.EventHandler(this.ItemListFrm_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel1.PerformLayout();
            this.dividerPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.CheckBox LblLike;
        private System.Windows.Forms.CheckBox ChkLove;
        private System.Windows.Forms.CheckBox ChkStar;
        private System.Windows.Forms.CheckBox ChkGift;
        private System.Windows.Forms.TextBox TxtPrice;
        private System.Windows.Forms.Label LblPrice;
        private System.Windows.Forms.TextBox TxtCode;
        private System.Windows.Forms.Label LblCode;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label LblDisplay;
        private System.Windows.Forms.ComboBox CmbSort;
        private System.Windows.Forms.Label LblSort;
        private System.Windows.Forms.ComboBox CmbResult;
        private System.Windows.Forms.ComboBox CmbDisplay;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Label LblPage;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private DividerPanel.DividerPanel dividerPanel1;
        private DividerPanel.DividerPanel dividerPanel2;
        private System.Windows.Forms.Label lblCurrPage;
        private System.Windows.Forms.Label lblPageCount;
        private System.Windows.Forms.DataGridView GrdResult;
    }
}