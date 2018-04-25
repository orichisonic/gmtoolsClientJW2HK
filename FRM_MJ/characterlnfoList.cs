using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using C_Event;
using C_Global;

namespace FRM_MJ
{
	/// <summary>
	/// characterlnfoList 的摘要说明。
	/// </summary>
    public class characterlnfoList : System.Windows.Forms.Form
    {
        private DividerPanel.DividerPanel dividerPanel1;
        private Label label1;
        private DividerPanel.DividerPanel dividerPanel2;
        private Button button2;
        private Button button1;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel4;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private LinkLabel linkLabel7;
        private LinkLabel linkLabel6;
        private LinkLabel linkLabel5;
        private GroupBox groupBox4;
        private LinkLabel linkLabel9;
        private LinkLabel linkLabel8;
        private LinkLabel linkLabel10;
        private LinkLabel linkLabel11;
        private LinkLabel linkLabel14;
        private LinkLabel linkLabel13;
        private LinkLabel linkLabel12;
        private GroupBox groupBox5;
        private LinkLabel linkLabel15;
        private LinkLabel linkLabel16;
        private C_Controls.LabelTextBox.LabelTextBox labelTextBox2;
        private C_Controls.LabelTextBox.LabelTextBox labelTextBox1;
        private C_Controls.LabelTextBox.LabelTextBox labelTextBox4;
        private C_Controls.LabelTextBox.LabelTextBox labelTextBox3;
        private C_Controls.LabelTextBox.LabelTextBox labelTextBox5;
        private C_Controls.LabelTextBox.LabelTextBox labelTextBox6;
        private GroupBox groupBox6;
        private C_Controls.LabelTextBox.LabelTextBox labelTextBox8;
        private C_Controls.LabelTextBox.LabelTextBox labelTextBox7;
        private Button button3;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public characterlnfoList()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.linkLabel7 = new System.Windows.Forms.LinkLabel();
            this.linkLabel6 = new System.Windows.Forms.LinkLabel();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.linkLabel14 = new System.Windows.Forms.LinkLabel();
            this.linkLabel13 = new System.Windows.Forms.LinkLabel();
            this.linkLabel12 = new System.Windows.Forms.LinkLabel();
            this.linkLabel11 = new System.Windows.Forms.LinkLabel();
            this.linkLabel10 = new System.Windows.Forms.LinkLabel();
            this.linkLabel9 = new System.Windows.Forms.LinkLabel();
            this.linkLabel8 = new System.Windows.Forms.LinkLabel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.linkLabel16 = new System.Windows.Forms.LinkLabel();
            this.linkLabel15 = new System.Windows.Forms.LinkLabel();
            this.labelTextBox1 = new C_Controls.LabelTextBox.LabelTextBox();
            this.labelTextBox2 = new C_Controls.LabelTextBox.LabelTextBox();
            this.labelTextBox3 = new C_Controls.LabelTextBox.LabelTextBox();
            this.labelTextBox4 = new C_Controls.LabelTextBox.LabelTextBox();
            this.labelTextBox5 = new C_Controls.LabelTextBox.LabelTextBox();
            this.labelTextBox6 = new C_Controls.LabelTextBox.LabelTextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.labelTextBox8 = new C_Controls.LabelTextBox.LabelTextBox();
            this.labelTextBox7 = new C_Controls.LabelTextBox.LabelTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.dividerPanel1.SuspendLayout();
            this.dividerPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.dividerPanel1.BorderSide = System.Windows.Forms.Border3DSide.Bottom;
            this.dividerPanel1.Controls.Add(this.label1);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(0, 0);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(702, 57);
            this.dividerPanel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "某某某帐号信息\r\n\r\n玩家目前不在线，可对其进行编辑";
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.BorderSide = System.Windows.Forms.Border3DSide.Top;
            this.dividerPanel2.Controls.Add(this.button2);
            this.dividerPanel2.Controls.Add(this.button1);
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dividerPanel2.Location = new System.Drawing.Point(0, 534);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(702, 37);
            this.dividerPanel2.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(615, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(534, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(6, 37);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(77, 12);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "玩家状态属性";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(6, 57);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(77, 12);
            this.linkLabel2.TabIndex = 15;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "玩家物品装备";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(6, 77);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(53, 12);
            this.linkLabel3.TabIndex = 16;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "玩家仓库";
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(6, 17);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(101, 12);
            this.linkLabel4.TabIndex = 17;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "玩家所在帮会信息";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelTextBox5);
            this.groupBox1.Controls.Add(this.labelTextBox4);
            this.groupBox1.Controls.Add(this.labelTextBox3);
            this.groupBox1.Controls.Add(this.labelTextBox2);
            this.groupBox1.Controls.Add(this.labelTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(14, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 185);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.linkLabel4);
            this.groupBox2.Controls.Add(this.linkLabel1);
            this.groupBox2.Controls.Add(this.linkLabel3);
            this.groupBox2.Controls.Add(this.linkLabel2);
            this.groupBox2.Location = new System.Drawing.Point(490, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 109);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.linkLabel7);
            this.groupBox3.Controls.Add(this.linkLabel6);
            this.groupBox3.Controls.Add(this.linkLabel5);
            this.groupBox3.Location = new System.Drawing.Point(490, 191);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 82);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // linkLabel7
            // 
            this.linkLabel7.AutoSize = true;
            this.linkLabel7.Location = new System.Drawing.Point(8, 39);
            this.linkLabel7.Name = "linkLabel7";
            this.linkLabel7.Size = new System.Drawing.Size(53, 12);
            this.linkLabel7.TabIndex = 2;
            this.linkLabel7.TabStop = true;
            this.linkLabel7.Text = "添加好友";
            // 
            // linkLabel6
            // 
            this.linkLabel6.AutoSize = true;
            this.linkLabel6.Location = new System.Drawing.Point(8, 57);
            this.linkLabel6.Name = "linkLabel6";
            this.linkLabel6.Size = new System.Drawing.Size(53, 12);
            this.linkLabel6.TabIndex = 1;
            this.linkLabel6.TabStop = true;
            this.linkLabel6.Text = "帮会信息";
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.Location = new System.Drawing.Point(8, 21);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(53, 12);
            this.linkLabel5.TabIndex = 0;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "好友名单";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.linkLabel14);
            this.groupBox4.Controls.Add(this.linkLabel13);
            this.groupBox4.Controls.Add(this.linkLabel12);
            this.groupBox4.Controls.Add(this.linkLabel11);
            this.groupBox4.Controls.Add(this.linkLabel10);
            this.groupBox4.Controls.Add(this.linkLabel9);
            this.groupBox4.Controls.Add(this.linkLabel8);
            this.groupBox4.Location = new System.Drawing.Point(490, 282);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 170);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // linkLabel14
            // 
            this.linkLabel14.AutoSize = true;
            this.linkLabel14.Location = new System.Drawing.Point(7, 147);
            this.linkLabel14.Name = "linkLabel14";
            this.linkLabel14.Size = new System.Drawing.Size(77, 12);
            this.linkLabel14.TabIndex = 6;
            this.linkLabel14.TabStop = true;
            this.linkLabel14.Text = "恢复玩家密码";
            // 
            // linkLabel13
            // 
            this.linkLabel13.AutoSize = true;
            this.linkLabel13.Location = new System.Drawing.Point(7, 126);
            this.linkLabel13.Name = "linkLabel13";
            this.linkLabel13.Size = new System.Drawing.Size(77, 12);
            this.linkLabel13.TabIndex = 5;
            this.linkLabel13.TabStop = true;
            this.linkLabel13.Text = "修改玩家密码";
            // 
            // linkLabel12
            // 
            this.linkLabel12.AutoSize = true;
            this.linkLabel12.Location = new System.Drawing.Point(7, 105);
            this.linkLabel12.Name = "linkLabel12";
            this.linkLabel12.Size = new System.Drawing.Size(77, 12);
            this.linkLabel12.TabIndex = 4;
            this.linkLabel12.TabStop = true;
            this.linkLabel12.Text = "保存玩家密码";
            // 
            // linkLabel11
            // 
            this.linkLabel11.AutoSize = true;
            this.linkLabel11.Location = new System.Drawing.Point(7, 84);
            this.linkLabel11.Name = "linkLabel11";
            this.linkLabel11.Size = new System.Drawing.Size(77, 12);
            this.linkLabel11.TabIndex = 3;
            this.linkLabel11.TabStop = true;
            this.linkLabel11.Text = "设置临时密码";
            // 
            // linkLabel10
            // 
            this.linkLabel10.AutoSize = true;
            this.linkLabel10.Location = new System.Drawing.Point(7, 63);
            this.linkLabel10.Name = "linkLabel10";
            this.linkLabel10.Size = new System.Drawing.Size(53, 12);
            this.linkLabel10.TabIndex = 2;
            this.linkLabel10.TabStop = true;
            this.linkLabel10.Text = "帐号禁言";
            // 
            // linkLabel9
            // 
            this.linkLabel9.AutoSize = true;
            this.linkLabel9.Location = new System.Drawing.Point(7, 42);
            this.linkLabel9.Name = "linkLabel9";
            this.linkLabel9.Size = new System.Drawing.Size(77, 12);
            this.linkLabel9.TabIndex = 1;
            this.linkLabel9.TabStop = true;
            this.linkLabel9.Text = "保存帐号信息";
            // 
            // linkLabel8
            // 
            this.linkLabel8.AutoSize = true;
            this.linkLabel8.Location = new System.Drawing.Point(7, 21);
            this.linkLabel8.Name = "linkLabel8";
            this.linkLabel8.Size = new System.Drawing.Size(83, 12);
            this.linkLabel8.TabIndex = 0;
            this.linkLabel8.TabStop = true;
            this.linkLabel8.Text = "停封/解封帐号";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.linkLabel16);
            this.groupBox5.Controls.Add(this.linkLabel15);
            this.groupBox5.Location = new System.Drawing.Point(490, 459);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 68);
            this.groupBox5.TabIndex = 23;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "groupBox5";
            // 
            // linkLabel16
            // 
            this.linkLabel16.AutoSize = true;
            this.linkLabel16.Location = new System.Drawing.Point(8, 40);
            this.linkLabel16.Name = "linkLabel16";
            this.linkLabel16.Size = new System.Drawing.Size(89, 12);
            this.linkLabel16.TabIndex = 1;
            this.linkLabel16.TabStop = true;
            this.linkLabel16.Text = "使用者操作记录";
            // 
            // linkLabel15
            // 
            this.linkLabel15.AutoSize = true;
            this.linkLabel15.Location = new System.Drawing.Point(10, 21);
            this.linkLabel15.Name = "linkLabel15";
            this.linkLabel15.Size = new System.Drawing.Size(77, 12);
            this.linkLabel15.TabIndex = 0;
            this.linkLabel15.TabStop = true;
            this.linkLabel15.Text = "用户交易记录";
            // 
            // labelTextBox1
            // 
            this.labelTextBox1.LabelText = "职业：　　";
            this.labelTextBox1.Location = new System.Drawing.Point(19, 24);
            this.labelTextBox1.Name = "labelTextBox1";
            this.labelTextBox1.Position = C_Controls.LabelTextBox.LabelTextBox.ELABELPOSITION.LEFT;
            this.labelTextBox1.ReadOnly = false;
            this.labelTextBox1.Size = new System.Drawing.Size(434, 24);
            this.labelTextBox1.sMargin = 0;
            this.labelTextBox1.TabIndex = 0;
            this.labelTextBox1.TextBoxText = "";
            // 
            // labelTextBox2
            // 
            this.labelTextBox2.LabelText = "等级：　　";
            this.labelTextBox2.Location = new System.Drawing.Point(19, 54);
            this.labelTextBox2.Name = "labelTextBox2";
            this.labelTextBox2.Position = C_Controls.LabelTextBox.LabelTextBox.ELABELPOSITION.LEFT;
            this.labelTextBox2.ReadOnly = false;
            this.labelTextBox2.Size = new System.Drawing.Size(434, 24);
            this.labelTextBox2.sMargin = 0;
            this.labelTextBox2.TabIndex = 1;
            this.labelTextBox2.TextBoxText = "";
            // 
            // labelTextBox3
            // 
            this.labelTextBox3.LabelText = "经验：　　";
            this.labelTextBox3.Location = new System.Drawing.Point(19, 84);
            this.labelTextBox3.Name = "labelTextBox3";
            this.labelTextBox3.Position = C_Controls.LabelTextBox.LabelTextBox.ELABELPOSITION.LEFT;
            this.labelTextBox3.ReadOnly = false;
            this.labelTextBox3.Size = new System.Drawing.Size(434, 24);
            this.labelTextBox3.sMargin = 0;
            this.labelTextBox3.TabIndex = 2;
            this.labelTextBox3.TextBoxText = "";
            // 
            // labelTextBox4
            // 
            this.labelTextBox4.LabelText = "技能点：　";
            this.labelTextBox4.Location = new System.Drawing.Point(19, 115);
            this.labelTextBox4.Name = "labelTextBox4";
            this.labelTextBox4.Position = C_Controls.LabelTextBox.LabelTextBox.ELABELPOSITION.LEFT;
            this.labelTextBox4.ReadOnly = false;
            this.labelTextBox4.Size = new System.Drawing.Size(434, 24);
            this.labelTextBox4.sMargin = 0;
            this.labelTextBox4.TabIndex = 3;
            this.labelTextBox4.TextBoxText = "";
            // 
            // labelTextBox5
            // 
            this.labelTextBox5.LabelText = "金钱：　　";
            this.labelTextBox5.Location = new System.Drawing.Point(19, 143);
            this.labelTextBox5.Name = "labelTextBox5";
            this.labelTextBox5.Position = C_Controls.LabelTextBox.LabelTextBox.ELABELPOSITION.LEFT;
            this.labelTextBox5.ReadOnly = false;
            this.labelTextBox5.Size = new System.Drawing.Size(434, 24);
            this.labelTextBox5.sMargin = 0;
            this.labelTextBox5.TabIndex = 4;
            this.labelTextBox5.TextBoxText = "";
            // 
            // labelTextBox6
            // 
            this.labelTextBox6.LabelText = "所在城市：";
            this.labelTextBox6.Location = new System.Drawing.Point(20, 20);
            this.labelTextBox6.Name = "labelTextBox6";
            this.labelTextBox6.Position = C_Controls.LabelTextBox.LabelTextBox.ELABELPOSITION.LEFT;
            this.labelTextBox6.ReadOnly = false;
            this.labelTextBox6.Size = new System.Drawing.Size(434, 24);
            this.labelTextBox6.sMargin = 0;
            this.labelTextBox6.TabIndex = 5;
            this.labelTextBox6.TextBoxText = "";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.labelTextBox6);
            this.groupBox6.Controls.Add(this.button3);
            this.groupBox6.Controls.Add(this.labelTextBox8);
            this.groupBox6.Controls.Add(this.labelTextBox7);
            this.groupBox6.Location = new System.Drawing.Point(13, 265);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(471, 146);
            this.groupBox6.TabIndex = 24;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "groupBox6";
            // 
            // labelTextBox8
            // 
            this.labelTextBox8.LabelText = "HP：　　　";
            this.labelTextBox8.Location = new System.Drawing.Point(20, 83);
            this.labelTextBox8.Name = "labelTextBox8";
            this.labelTextBox8.Position = C_Controls.LabelTextBox.LabelTextBox.ELABELPOSITION.LEFT;
            this.labelTextBox8.ReadOnly = false;
            this.labelTextBox8.Size = new System.Drawing.Size(434, 24);
            this.labelTextBox8.sMargin = 0;
            this.labelTextBox8.TabIndex = 9;
            this.labelTextBox8.TextBoxText = "";
            // 
            // labelTextBox7
            // 
            this.labelTextBox7.LabelText = "MP：　　　";
            this.labelTextBox7.Location = new System.Drawing.Point(20, 52);
            this.labelTextBox7.Name = "labelTextBox7";
            this.labelTextBox7.Position = C_Controls.LabelTextBox.LabelTextBox.ELABELPOSITION.LEFT;
            this.labelTextBox7.ReadOnly = false;
            this.labelTextBox7.Size = new System.Drawing.Size(434, 24);
            this.labelTextBox7.sMargin = 0;
            this.labelTextBox7.TabIndex = 8;
            this.labelTextBox7.TextBoxText = "";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(379, 116);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "修改";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // characterlnfoList
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(702, 571);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "characterlnfoList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "characterlnfoList";
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel1.PerformLayout();
            this.dividerPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        #region 自定义函数
        /// <summary>
        /// 初始化游戏服务器列表
        /// </summary>
        /*
        public void InitializeUserInfo()
        {
            try
            {

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.ServerInfo_GameID;
                messageBody[0].oContent = 2;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 1;

                serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);

                //检测状态
                if (serverIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
                    Application.Exit();
                    return;
                }

                //显示内容到列表
                for (int i = 0; i < serverIPResult.GetLength(0); i++)
                {
                    this.serverIP.Items.Add(serverIPResult[i, 1].oContent.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        */
        #endregion

        #region 调用函数
        /// <summary>
        /// 创建类库中的窗体
        /// </summary>
        /// <param name="oParent">MDI 程序的父窗体</param>
        /// <param name="oSocket">Socket</param>
        /// <returns>类库中的窗体</returns>
        public Form CreateModule(object oParent, object oEvent)
        {
            this.m_ClientEvent = (CSocketEvent)oEvent;

            if (oParent != null)
            {
                this.MdiParent = (Form)oParent;
                this.Show();
            }
            else
            {
                this.ShowDialog();
            }

            return this;

        }



        #endregion

        #region 变量
        private CSocketEvent m_ClientEvent = null;
        private C_Global.CEnum.Message_Body[,] serverIPResult = null;
        private C_Global.CEnum.Message_Body[,] searchFrmResult = null;

        #endregion

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            userGoodsList uGoodsList = new userGoodsList();
            uGoodsList.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            userStatusAttribute uStatusAttribute = new userStatusAttribute();
            uStatusAttribute.ShowDialog();
        }
	}
}
