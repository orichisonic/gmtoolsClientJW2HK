namespace M_RC
{
    partial class FrmRCNotice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtCode = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAllselect = new System.Windows.Forms.Button();
            this.lblserver = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.CheckCurSend = new System.Windows.Forms.CheckBox();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbStauas = new System.Windows.Forms.ComboBox();
            this.DptStart = new System.Windows.Forms.DateTimePicker();
            this.DptEnd = new System.Windows.Forms.DateTimePicker();
            this.BtnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblConet = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.TxtConnet = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.NumMinnute = new System.Windows.Forms.NumericUpDown();
            this.lblstart = new System.Windows.Forms.Label();
            this.lblend = new System.Windows.Forms.Label();
            this.lblinv = new System.Windows.Forms.Label();
            this.GrdList = new System.Windows.Forms.DataGridView();
            this.MnuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ItmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRecord = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.dividerPanel1.SuspendLayout();
            this.dividerPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumMinnute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdList)).BeginInit();
            this.MnuGrid.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtCode);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 644);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // TxtCode
            // 
            this.TxtCode.CheckOnClick = true;
            this.TxtCode.ColumnWidth = 150;
            this.TxtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtCode.FormattingEnabled = true;
            this.TxtCode.HorizontalExtent = 10;
            this.TxtCode.Location = new System.Drawing.Point(3, 61);
            this.TxtCode.MultiColumn = true;
            this.TxtCode.Name = "TxtCode";
            this.TxtCode.Size = new System.Drawing.Size(216, 580);
            this.TxtCode.TabIndex = 24;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAllselect);
            this.panel1.Controls.Add(this.lblserver);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 44);
            this.panel1.TabIndex = 0;
            // 
            // btnAllselect
            // 
            this.btnAllselect.Location = new System.Drawing.Point(113, 12);
            this.btnAllselect.Name = "btnAllselect";
            this.btnAllselect.Size = new System.Drawing.Size(76, 24);
            this.btnAllselect.TabIndex = 15;
            this.btnAllselect.Text = "全選";
            this.btnAllselect.UseVisualStyleBackColor = true;
            this.btnAllselect.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblserver
            // 
            this.lblserver.AutoSize = true;
            this.lblserver.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblserver.Location = new System.Drawing.Point(3, 22);
            this.lblserver.Name = "lblserver";
            this.lblserver.Size = new System.Drawing.Size(77, 14);
            this.lblserver.TabIndex = 14;
            this.lblserver.Text = "伺服器列表";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dividerPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(222, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(744, 644);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.dividerPanel2);
            this.dividerPanel1.Controls.Add(this.GrdList);
            this.dividerPanel1.Controls.Add(this.panel2);
            this.dividerPanel1.Controls.Add(this.label1);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel1.Location = new System.Drawing.Point(3, 17);
            this.dividerPanel1.Name = "dpStatus";
            this.dividerPanel1.Size = new System.Drawing.Size(738, 624);
            this.dividerPanel1.TabIndex = 1;
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Controls.Add(this.label2);
            this.dividerPanel2.Controls.Add(this.CheckCurSend);
            this.dividerPanel2.Controls.Add(this.BtnEdit);
            this.dividerPanel2.Controls.Add(this.label11);
            this.dividerPanel2.Controls.Add(this.cmbStauas);
            this.dividerPanel2.Controls.Add(this.DptStart);
            this.dividerPanel2.Controls.Add(this.DptEnd);
            this.dividerPanel2.Controls.Add(this.BtnClear);
            this.dividerPanel2.Controls.Add(this.btnAdd);
            this.dividerPanel2.Controls.Add(this.lblConet);
            this.dividerPanel2.Controls.Add(this.lblMin);
            this.dividerPanel2.Controls.Add(this.TxtConnet);
            this.dividerPanel2.Controls.Add(this.label9);
            this.dividerPanel2.Controls.Add(this.NumMinnute);
            this.dividerPanel2.Controls.Add(this.lblstart);
            this.dividerPanel2.Controls.Add(this.lblend);
            this.dividerPanel2.Controls.Add(this.lblinv);
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel2.Location = new System.Drawing.Point(0, 270);
            this.dividerPanel2.Name = "dpStatus";
            this.dividerPanel2.Size = new System.Drawing.Size(738, 354);
            this.dividerPanel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "秒";
            // 
            // CheckCurSend
            // 
            this.CheckCurSend.AutoSize = true;
            this.CheckCurSend.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CheckCurSend.Location = new System.Drawing.Point(114, 14);
            this.CheckCurSend.Name = "CheckCurSend";
            this.CheckCurSend.Size = new System.Drawing.Size(82, 18);
            this.CheckCurSend.TabIndex = 21;
            this.CheckCurSend.Text = "立即發送";
            this.CheckCurSend.UseVisualStyleBackColor = true;
            this.CheckCurSend.Visible = false;
            this.CheckCurSend.CheckedChanged += new System.EventHandler(this.CheckCurSend_CheckedChanged);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(178, 306);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(84, 24);
            this.BtnEdit.TabIndex = 20;
            this.BtnEdit.Text = "修改狀態";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Visible = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(318, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 14);
            this.label11.TabIndex = 19;
            this.label11.Text = "狀態:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Visible = false;
            // 
            // cmbStauas
            // 
            this.cmbStauas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStauas.FormattingEnabled = true;
            this.cmbStauas.Items.AddRange(new object[] {
            "未发送",
            "发送中",
            "已发送"});
            this.cmbStauas.Location = new System.Drawing.Point(366, 42);
            this.cmbStauas.Name = "cmbStauas";
            this.cmbStauas.Size = new System.Drawing.Size(84, 20);
            this.cmbStauas.TabIndex = 18;
            this.cmbStauas.Visible = false;
            // 
            // DptStart
            // 
            this.DptStart.CustomFormat = "yyyy-MM-dd HH:mm";
            this.DptStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DptStart.Location = new System.Drawing.Point(112, 42);
            this.DptStart.Name = "DptStart";
            this.DptStart.ShowUpDown = true;
            this.DptStart.Size = new System.Drawing.Size(125, 21);
            this.DptStart.TabIndex = 15;
            // 
            // DptEnd
            // 
            this.DptEnd.CustomFormat = "yyyy-MM-dd HH:mm";
            this.DptEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DptEnd.Location = new System.Drawing.Point(112, 74);
            this.DptEnd.Name = "DptEnd";
            this.DptEnd.ShowUpDown = true;
            this.DptEnd.Size = new System.Drawing.Size(125, 21);
            this.DptEnd.TabIndex = 14;
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(353, 306);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(84, 24);
            this.BtnClear.TabIndex = 1;
            this.BtnClear.Text = "取消";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(111, 306);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "添加記錄";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblConet
            // 
            this.lblConet.AutoSize = true;
            this.lblConet.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblConet.Location = new System.Drawing.Point(21, 135);
            this.lblConet.Name = "lblConet";
            this.lblConet.Size = new System.Drawing.Size(70, 14);
            this.lblConet.TabIndex = 13;
            this.lblConet.Text = "發送內容:";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMin.Location = new System.Drawing.Point(203, 79);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(35, 14);
            this.lblMin.TabIndex = 11;
            this.lblMin.Text = "分钟";
            // 
            // TxtConnet
            // 
            this.TxtConnet.Location = new System.Drawing.Point(111, 137);
            this.TxtConnet.MaxLength = 500;
            this.TxtConnet.Name = "TxtConnet";
            this.TxtConnet.Size = new System.Drawing.Size(618, 154);
            this.TxtConnet.TabIndex = 1;
            this.TxtConnet.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 12);
            this.label9.TabIndex = 0;
            // 
            // NumMinnute
            // 
            this.NumMinnute.Location = new System.Drawing.Point(112, 103);
            this.NumMinnute.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumMinnute.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumMinnute.Name = "NumMinnute";
            this.NumMinnute.Size = new System.Drawing.Size(84, 21);
            this.NumMinnute.TabIndex = 2;
            this.NumMinnute.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblstart
            // 
            this.lblstart.AutoSize = true;
            this.lblstart.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblstart.Location = new System.Drawing.Point(21, 44);
            this.lblstart.Name = "lblstart";
            this.lblstart.Size = new System.Drawing.Size(70, 14);
            this.lblstart.TabIndex = 1;
            this.lblstart.Text = "開始時間:";
            this.lblstart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblend
            // 
            this.lblend.AutoSize = true;
            this.lblend.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblend.Location = new System.Drawing.Point(21, 74);
            this.lblend.Name = "lblend";
            this.lblend.Size = new System.Drawing.Size(70, 14);
            this.lblend.TabIndex = 2;
            this.lblend.Text = "結束時間:";
            this.lblend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblinv
            // 
            this.lblinv.AutoSize = true;
            this.lblinv.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblinv.Location = new System.Drawing.Point(21, 103);
            this.lblinv.Name = "lblinv";
            this.lblinv.Size = new System.Drawing.Size(70, 14);
            this.lblinv.TabIndex = 7;
            this.lblinv.Text = "發送間隔:";
            this.lblinv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GrdList
            // 
            this.GrdList.AllowUserToAddRows = false;
            this.GrdList.AllowUserToDeleteRows = false;
            this.GrdList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrdList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GrdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdList.ContextMenuStrip = this.MnuGrid;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrdList.DefaultCellStyle = dataGridViewCellStyle2;
            this.GrdList.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrdList.Location = new System.Drawing.Point(0, 36);
            this.GrdList.MultiSelect = false;
            this.GrdList.Name = "GrdList";
            this.GrdList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrdList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.GrdList.RowTemplate.Height = 23;
            this.GrdList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdList.Size = new System.Drawing.Size(738, 234);
            this.GrdList.TabIndex = 16;
            this.GrdList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdList_CellDoubleClick);
            this.GrdList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdList_CellClick);
            // 
            // MnuGrid
            // 
            this.MnuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItmDelete});
            this.MnuGrid.Name = "MnuGrid";
            this.MnuGrid.Size = new System.Drawing.Size(119, 26);
            // 
            // ItmDelete
            // 
            this.ItmDelete.Name = "ItmDelete";
            this.ItmDelete.Size = new System.Drawing.Size(118, 22);
            this.ItmDelete.Text = "修改状态";
            this.ItmDelete.Click += new System.EventHandler(this.ItmDelete_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRecord);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(738, 36);
            this.panel2.TabIndex = 1;
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(112, 6);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(103, 24);
            this.btnRecord.TabIndex = 4;
            this.btnRecord.Text = "公告記錄查詢";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 0;
            // 
            // FrmRCNotice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 644);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmRCNotice";
            this.Text = "光線飛車公告";
            this.Load += new System.EventHandler(this.FrmRCNotice_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel1.PerformLayout();
            this.dividerPanel2.ResumeLayout(false);
            this.dividerPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumMinnute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdList)).EndInit();
            this.MnuGrid.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox TxtCode;
        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblend;
        private System.Windows.Forms.Label lblstart;
        private System.Windows.Forms.NumericUpDown NumMinnute;
        private System.Windows.Forms.Label lblinv;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Button btnRecord;
        private DividerPanel.DividerPanel dividerPanel2;
        private System.Windows.Forms.RichTextBox TxtConnet;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Label lblConet;
        private System.Windows.Forms.ContextMenuStrip MnuGrid;
        private System.Windows.Forms.ToolStripMenuItem ItmDelete;
        private System.Windows.Forms.DateTimePicker DptStart;
        private System.Windows.Forms.DateTimePicker DptEnd;
        private System.Windows.Forms.DataGridView GrdList;
        private System.Windows.Forms.Label lblserver;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.CheckBox CheckCurSend;
        private System.Windows.Forms.ComboBox cmbStauas;
        private System.Windows.Forms.Button btnAllselect;
        private System.Windows.Forms.Label label2;

    }
}