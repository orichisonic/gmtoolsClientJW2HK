namespace M_SDO
{
    partial class MatchInfoEdit
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cbxDay = new System.Windows.Forms.ComboBox();
            this.txtMCash = new System.Windows.Forms.TextBox();
            this.cbxScene = new System.Windows.Forms.ComboBox();
            this.cbxSong1 = new System.Windows.Forms.ComboBox();
            this.cbxSong2 = new System.Windows.Forms.ComboBox();
            this.cbxSong3 = new System.Windows.Forms.ComboBox();
            this.cbxSong4 = new System.Windows.Forms.ComboBox();
            this.cbxSong5 = new System.Windows.Forms.ComboBox();
            this.cbxLevel1 = new System.Windows.Forms.ComboBox();
            this.cbxLevel2 = new System.Windows.Forms.ComboBox();
            this.cbxLevel3 = new System.Windows.Forms.ComboBox();
            this.cbxLevel4 = new System.Windows.Forms.ComboBox();
            this.cbxLevel5 = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.txtMinutes = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.dpContent = new DividerPanel.DividerPanel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.dptEndTime = new System.Windows.Forms.TextBox();
            this.dptBeginTime = new System.Windows.Forms.TextBox();
            this.txtGCash = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.btnIPCancel = new System.Windows.Forms.Button();
            this.btnIpOk = new System.Windows.Forms.Button();
            this.cbxServerIP = new System.Windows.Forms.ComboBox();
            this.backgroundWorkerAddMatch = new System.ComponentModel.BackgroundWorker();
            this.dpContent.SuspendLayout();
            this.dividerPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "星期几：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "比赛时间（小时）：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "比赛时间（分钟）：";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "大赛频道开放的开始时间：\r\n";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "此次比赛需要收取的G币：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "此次比赛需要收取的M币：";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "此次比赛所用场景：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(392, 460);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "第一首曲子：";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(421, 483);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "等级：";
            this.label9.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(428, 537);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "等级：";
            this.label10.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(392, 512);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 9;
            this.label11.Text = "第二首曲子：";
            this.label11.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(428, 587);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 12;
            this.label12.Text = "等级：";
            this.label12.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(392, 562);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 12);
            this.label13.TabIndex = 11;
            this.label13.Text = "第三首曲子：";
            this.label13.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(428, 637);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 14;
            this.label14.Text = "等级：";
            this.label14.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(392, 612);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 12);
            this.label15.TabIndex = 13;
            this.label15.Text = "第四首曲子：";
            this.label15.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(299, 345);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 16;
            this.label16.Text = "等级：";
            this.label16.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(392, 663);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 12);
            this.label17.TabIndex = 15;
            this.label17.Text = "第五首曲子：";
            this.label17.Visible = false;
            // 
            // cbxDay
            // 
            this.cbxDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDay.FormattingEnabled = true;
            this.cbxDay.Location = new System.Drawing.Point(180, 11);
            this.cbxDay.Name = "cbxDay";
            this.cbxDay.Size = new System.Drawing.Size(330, 20);
            this.cbxDay.TabIndex = 17;
            // 
            // txtMCash
            // 
            this.txtMCash.Location = new System.Drawing.Point(180, 113);
            this.txtMCash.Name = "txtMCash";
            this.txtMCash.Size = new System.Drawing.Size(329, 21);
            this.txtMCash.TabIndex = 22;
            this.txtMCash.Text = "0";
            this.txtMCash.Visible = false;
            // 
            // cbxScene
            // 
            this.cbxScene.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxScene.FormattingEnabled = true;
            this.cbxScene.Location = new System.Drawing.Point(180, 113);
            this.cbxScene.Name = "cbxScene";
            this.cbxScene.Size = new System.Drawing.Size(329, 20);
            this.cbxScene.TabIndex = 23;
            // 
            // cbxSong1
            // 
            this.cbxSong1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSong1.FormattingEnabled = true;
            this.cbxSong1.Location = new System.Drawing.Point(486, 456);
            this.cbxSong1.Name = "cbxSong1";
            this.cbxSong1.Size = new System.Drawing.Size(329, 20);
            this.cbxSong1.TabIndex = 24;
            this.cbxSong1.Visible = false;
            // 
            // cbxSong2
            // 
            this.cbxSong2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSong2.FormattingEnabled = true;
            this.cbxSong2.Location = new System.Drawing.Point(487, 508);
            this.cbxSong2.Name = "cbxSong2";
            this.cbxSong2.Size = new System.Drawing.Size(329, 20);
            this.cbxSong2.TabIndex = 25;
            this.cbxSong2.Visible = false;
            // 
            // cbxSong3
            // 
            this.cbxSong3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSong3.FormattingEnabled = true;
            this.cbxSong3.Location = new System.Drawing.Point(487, 558);
            this.cbxSong3.Name = "cbxSong3";
            this.cbxSong3.Size = new System.Drawing.Size(329, 20);
            this.cbxSong3.TabIndex = 26;
            this.cbxSong3.Visible = false;
            // 
            // cbxSong4
            // 
            this.cbxSong4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSong4.FormattingEnabled = true;
            this.cbxSong4.Location = new System.Drawing.Point(486, 608);
            this.cbxSong4.Name = "cbxSong4";
            this.cbxSong4.Size = new System.Drawing.Size(329, 20);
            this.cbxSong4.TabIndex = 27;
            this.cbxSong4.Visible = false;
            // 
            // cbxSong5
            // 
            this.cbxSong5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSong5.FormattingEnabled = true;
            this.cbxSong5.Location = new System.Drawing.Point(486, 658);
            this.cbxSong5.Name = "cbxSong5";
            this.cbxSong5.Size = new System.Drawing.Size(329, 20);
            this.cbxSong5.TabIndex = 28;
            this.cbxSong5.Visible = false;
            // 
            // cbxLevel1
            // 
            this.cbxLevel1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLevel1.FormattingEnabled = true;
            this.cbxLevel1.Items.AddRange(new object[] {
            "easy",
            "normal",
            "hard"});
            this.cbxLevel1.Location = new System.Drawing.Point(487, 481);
            this.cbxLevel1.Name = "cbxLevel1";
            this.cbxLevel1.Size = new System.Drawing.Size(329, 20);
            this.cbxLevel1.TabIndex = 29;
            this.cbxLevel1.Visible = false;
            // 
            // cbxLevel2
            // 
            this.cbxLevel2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLevel2.FormattingEnabled = true;
            this.cbxLevel2.Items.AddRange(new object[] {
            "easy",
            "normal",
            "hard"});
            this.cbxLevel2.Location = new System.Drawing.Point(487, 533);
            this.cbxLevel2.Name = "cbxLevel2";
            this.cbxLevel2.Size = new System.Drawing.Size(329, 20);
            this.cbxLevel2.TabIndex = 30;
            this.cbxLevel2.Visible = false;
            // 
            // cbxLevel3
            // 
            this.cbxLevel3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLevel3.FormattingEnabled = true;
            this.cbxLevel3.Items.AddRange(new object[] {
            "easy",
            "normal",
            "hard"});
            this.cbxLevel3.Location = new System.Drawing.Point(486, 583);
            this.cbxLevel3.Name = "cbxLevel3";
            this.cbxLevel3.Size = new System.Drawing.Size(329, 20);
            this.cbxLevel3.TabIndex = 31;
            this.cbxLevel3.Visible = false;
            // 
            // cbxLevel4
            // 
            this.cbxLevel4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLevel4.FormattingEnabled = true;
            this.cbxLevel4.Items.AddRange(new object[] {
            "easy",
            "normal",
            "hard"});
            this.cbxLevel4.Location = new System.Drawing.Point(487, 633);
            this.cbxLevel4.Name = "cbxLevel4";
            this.cbxLevel4.Size = new System.Drawing.Size(329, 20);
            this.cbxLevel4.TabIndex = 32;
            this.cbxLevel4.Visible = false;
            // 
            // cbxLevel5
            // 
            this.cbxLevel5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLevel5.FormattingEnabled = true;
            this.cbxLevel5.Items.AddRange(new object[] {
            "easy",
            "normal",
            "hard"});
            this.cbxLevel5.Location = new System.Drawing.Point(358, 341);
            this.cbxLevel5.Name = "cbxLevel5";
            this.cbxLevel5.Size = new System.Drawing.Size(329, 20);
            this.cbxLevel5.TabIndex = 33;
            this.cbxLevel5.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 322);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(12, 322);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtHours
            // 
            this.txtHours.Location = new System.Drawing.Point(180, 36);
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(329, 21);
            this.txtHours.TabIndex = 36;
            this.txtHours.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtHours_KeyUp);
            this.txtHours.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtHours_MouseUp);
            // 
            // txtMinutes
            // 
            this.txtMinutes.Location = new System.Drawing.Point(180, 61);
            this.txtMinutes.Name = "txtMinutes";
            this.txtMinutes.Size = new System.Drawing.Size(329, 21);
            this.txtMinutes.TabIndex = 37;
            this.txtMinutes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMinutes_KeyUp);
            this.txtMinutes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtMinutes_MouseUp);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(14, 117);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(149, 12);
            this.label18.TabIndex = 39;
            this.label18.Text = "大赛频道开放的结束时间：\r\n";
            this.label18.Visible = false;
            // 
            // dpContent
            // 
            this.dpContent.AllowDrop = true;
            this.dpContent.Controls.Add(this.comboBox1);
            this.dpContent.Controls.Add(this.label20);
            this.dpContent.Controls.Add(this.dptEndTime);
            this.dpContent.Controls.Add(this.dptBeginTime);
            this.dpContent.Controls.Add(this.label1);
            this.dpContent.Controls.Add(this.label18);
            this.dpContent.Controls.Add(this.label2);
            this.dpContent.Controls.Add(this.label3);
            this.dpContent.Controls.Add(this.txtMinutes);
            this.dpContent.Controls.Add(this.label4);
            this.dpContent.Controls.Add(this.txtHours);
            this.dpContent.Controls.Add(this.label5);
            this.dpContent.Controls.Add(this.label6);
            this.dpContent.Controls.Add(this.label7);
            this.dpContent.Controls.Add(this.label8);
            this.dpContent.Controls.Add(this.cbxLevel4);
            this.dpContent.Controls.Add(this.label9);
            this.dpContent.Controls.Add(this.cbxLevel3);
            this.dpContent.Controls.Add(this.label11);
            this.dpContent.Controls.Add(this.cbxLevel2);
            this.dpContent.Controls.Add(this.label10);
            this.dpContent.Controls.Add(this.cbxLevel1);
            this.dpContent.Controls.Add(this.label13);
            this.dpContent.Controls.Add(this.cbxSong5);
            this.dpContent.Controls.Add(this.label12);
            this.dpContent.Controls.Add(this.cbxSong4);
            this.dpContent.Controls.Add(this.label15);
            this.dpContent.Controls.Add(this.cbxSong3);
            this.dpContent.Controls.Add(this.label14);
            this.dpContent.Controls.Add(this.cbxSong2);
            this.dpContent.Controls.Add(this.label17);
            this.dpContent.Controls.Add(this.cbxSong1);
            this.dpContent.Controls.Add(this.cbxScene);
            this.dpContent.Controls.Add(this.cbxDay);
            this.dpContent.Controls.Add(this.txtMCash);
            this.dpContent.Controls.Add(this.txtGCash);
            this.dpContent.Location = new System.Drawing.Point(10, 77);
            this.dpContent.Name = "dividerPanel2";
            this.dpContent.Size = new System.Drawing.Size(528, 227);
            this.dpContent.TabIndex = 40;
            this.dpContent.Paint += new System.Windows.Forms.PaintEventHandler(this.dpContent_Paint);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(181, 143);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(329, 20);
            this.comboBox1.TabIndex = 80;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(98, 146);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 79;
            this.label20.Text = "比赛模式：";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dptEndTime
            // 
            this.dptEndTime.Location = new System.Drawing.Point(179, 114);
            this.dptEndTime.Name = "dptEndTime";
            this.dptEndTime.Size = new System.Drawing.Size(330, 21);
            this.dptEndTime.TabIndex = 41;
            this.dptEndTime.Visible = false;
            // 
            // dptBeginTime
            // 
            this.dptBeginTime.Location = new System.Drawing.Point(179, 87);
            this.dptBeginTime.Name = "dptBeginTime";
            this.dptBeginTime.Size = new System.Drawing.Size(330, 21);
            this.dptBeginTime.TabIndex = 40;
            this.dptBeginTime.Visible = false;
            // 
            // txtGCash
            // 
            this.txtGCash.Location = new System.Drawing.Point(181, 86);
            this.txtGCash.Name = "txtGCash";
            this.txtGCash.Size = new System.Drawing.Size(329, 21);
            this.txtGCash.TabIndex = 21;
            this.txtGCash.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(11, 11);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(209, 12);
            this.label19.TabIndex = 0;
            this.label19.Text = "请先选择要建立的比赛所在的服务器：";
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Controls.Add(this.btnIPCancel);
            this.dividerPanel2.Controls.Add(this.btnIpOk);
            this.dividerPanel2.Controls.Add(this.cbxServerIP);
            this.dividerPanel2.Controls.Add(this.label19);
            this.dividerPanel2.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(528, 61);
            this.dividerPanel2.TabIndex = 41;
            // 
            // btnIPCancel
            // 
            this.btnIPCancel.Location = new System.Drawing.Point(361, 25);
            this.btnIPCancel.Name = "btnIPCancel";
            this.btnIPCancel.Size = new System.Drawing.Size(75, 23);
            this.btnIPCancel.TabIndex = 3;
            this.btnIPCancel.Text = "重置";
            this.btnIPCancel.UseVisualStyleBackColor = true;
            this.btnIPCancel.Click += new System.EventHandler(this.btnIPCancel_Click);
            // 
            // btnIpOk
            // 
            this.btnIpOk.Location = new System.Drawing.Point(280, 25);
            this.btnIpOk.Name = "btnIpOk";
            this.btnIpOk.Size = new System.Drawing.Size(75, 23);
            this.btnIpOk.TabIndex = 2;
            this.btnIpOk.Text = "确认";
            this.btnIpOk.UseVisualStyleBackColor = true;
            this.btnIpOk.Click += new System.EventHandler(this.btnIpOk_Click);
            // 
            // cbxServerIP
            // 
            this.cbxServerIP.FormattingEnabled = true;
            this.cbxServerIP.Location = new System.Drawing.Point(13, 28);
            this.cbxServerIP.Name = "cbxServerIP";
            this.cbxServerIP.Size = new System.Drawing.Size(251, 20);
            this.cbxServerIP.TabIndex = 1;
            // 
            // backgroundWorkerAddMatch
            // 
            this.backgroundWorkerAddMatch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerAddMatch_DoWork);
            this.backgroundWorkerAddMatch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerAddMatch_RunWorkerCompleted);
            // 
            // MatchInfoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 366);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dpContent);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cbxLevel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MatchInfoEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "挑战信息编辑";
            this.Load += new System.EventHandler(this.MatchInfoEdit_Load);
            this.dpContent.ResumeLayout(false);
            this.dpContent.PerformLayout();
            this.dividerPanel2.ResumeLayout(false);
            this.dividerPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbxDay;
        private System.Windows.Forms.TextBox txtMCash;
        private System.Windows.Forms.ComboBox cbxScene;
        private System.Windows.Forms.ComboBox cbxSong1;
        private System.Windows.Forms.ComboBox cbxSong2;
        private System.Windows.Forms.ComboBox cbxSong3;
        private System.Windows.Forms.ComboBox cbxSong4;
        private System.Windows.Forms.ComboBox cbxSong5;
        private System.Windows.Forms.ComboBox cbxLevel1;
        private System.Windows.Forms.ComboBox cbxLevel2;
        private System.Windows.Forms.ComboBox cbxLevel3;
        private System.Windows.Forms.ComboBox cbxLevel4;
        private System.Windows.Forms.ComboBox cbxLevel5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.TextBox txtMinutes;
        private System.Windows.Forms.Label label18;
        private DividerPanel.DividerPanel dpContent;
        private System.Windows.Forms.Label label19;
        private DividerPanel.DividerPanel dividerPanel2;
        private System.Windows.Forms.Button btnIpOk;
        private System.Windows.Forms.ComboBox cbxServerIP;
        private System.Windows.Forms.Button btnIPCancel;
        private System.Windows.Forms.TextBox dptBeginTime;
        private System.Windows.Forms.TextBox dptEndTime;
        private System.Windows.Forms.TextBox txtGCash;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label20;
        private System.ComponentModel.BackgroundWorker backgroundWorkerAddMatch;
    }
}