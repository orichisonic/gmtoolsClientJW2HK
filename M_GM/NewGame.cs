using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using C_Event;
using C_Global;
using C_Socket;
using Language;

namespace M_GM
{
	/// <summary>
	/// NewGame 的摘要说明。
	/// </summary>
	[C_Global.CModuleAttribute("游戏添加", "NewGame", "添加游戏信息", "User Group")]
	public class NewGame : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox gameName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox gameDescription;
        private DividerPanel.DividerPanel dividerPanel1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NewGame()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		public NewGame(bool isModify,C_Global.CEnum.Message_Body[] msgBody)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			this.isModify = isModify;
			this.msgBody = msgBody;
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
            this.gameName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gameDescription = new System.Windows.Forms.TextBox();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.dividerPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameName
            // 
            this.gameName.Location = new System.Drawing.Point(80, 16);
            this.gameName.Name = "gameName";
            this.gameName.Size = new System.Drawing.Size(288, 21);
            this.gameName.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "描　　述：";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "游戏名称：";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(299, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "取消";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(211, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "确认";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gameDescription
            // 
            this.gameDescription.Location = new System.Drawing.Point(80, 56);
            this.gameDescription.Name = "gameDescription";
            this.gameDescription.Size = new System.Drawing.Size(288, 21);
            this.gameDescription.TabIndex = 13;
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.BorderSide = System.Windows.Forms.Border3DSide.Top;
            this.dividerPanel1.Controls.Add(this.button2);
            this.dividerPanel1.Controls.Add(this.button1);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dividerPanel1.Location = new System.Drawing.Point(0, 97);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(378, 46);
            this.dividerPanel1.TabIndex = 14;
            // 
            // NewGame
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(378, 143);
            this.Controls.Add(this.dividerPanel1);
            this.Controls.Add(this.gameDescription);
            this.Controls.Add(this.gameName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewGame";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "游戏设置";
            this.Load += new System.EventHandler(this.NewGame_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region 事件处理
		private void button1_Click(object sender, System.EventArgs e)
		{		
			C_Global.CEnum.Message_Body[,] resultMsgBody = null;

			try
			{
				//try
				//{
				if (!isModify)
				{
					C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

					messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
					messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
					messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

					messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
					messageBody[1].eName = C_Global.CEnum.TagName.GameName;
					messageBody[1].oContent = this.gameName.Text.Trim();

					messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
					messageBody[2].eName = C_Global.CEnum.TagName.GameContent;
					messageBody[2].oContent = this.gameDescription.Text.Trim();

					resultMsgBody = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.GAME_CREATE,C_Global.CEnum.Msg_Category.GAME_ADMIN,messageBody);
					//检测状态
					if (resultMsgBody[0,0].eName == C_Global.CEnum.TagName.ERROR_Msg)
					{
						MessageBox.Show(resultMsgBody[0,0].oContent.ToString());
						//Application.Exit();
						return;
					}
				}
				else
				{
					C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];

					messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
					messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
					messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

					messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
					messageBody[1].eName = C_Global.CEnum.TagName.GameID;
					messageBody[1].oContent = int.Parse(msgBody[0].oContent.ToString());

					messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
					messageBody[2].eName = C_Global.CEnum.TagName.GameName;
					messageBody[2].oContent = this.gameName.Text.Trim();

					messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
					messageBody[3].eName = C_Global.CEnum.TagName.GameContent;
					messageBody[3].oContent = this.gameDescription.Text.Trim();

					resultMsgBody = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.GAME_UPDATE,C_Global.CEnum.Msg_Category.GAME_ADMIN,messageBody);
					//检测状态
					if (resultMsgBody[0,0].eName == C_Global.CEnum.TagName.ERROR_Msg)
					{
						MessageBox.Show(resultMsgBody[0,0].oContent.ToString());
						//Application.Exit();
						return;
					}
				}
				//}
				//catch(Exception ex)
				//{
					//MessageBox.Show(ex.Message);
				//}

				if(resultMsgBody[0,0].oContent.ToString().Trim().ToUpper().Equals("SUCESS"))
				{
					if(!isModify)
					{
                        MessageBox.Show(config.ReadConfigValue("MGM", "NG_Code_Succeed"));
					}
					else
					{
                        MessageBox.Show(config.ReadConfigValue("MGM", "NG_Code_Failed"));
					}
					this.Close();	
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
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

		bool isModify = false;			//游戏编辑状态
		C_Global.CEnum.Message_Body[] msgBody = null;
		#endregion

		private void NewGame_Load(object sender, System.EventArgs e)
		{
            IntiFontLib();

			//游戏编辑
			if(isModify)
			{
				//msgBody
				this.gameName.Text = msgBody[1].oContent.ToString().Trim();
				this.gameDescription.Text = msgBody[2].oContent.ToString().Trim();
			}
		}

        #region 语言库
        /// <summary>
        ///　文字库
        /// </summary>
        ConfigValue config = null;

        /// <summary>
        /// 初始化华文字语言库
        /// </summary>
        private void IntiFontLib()
        {
            config = (ConfigValue)m_ClientEvent.GetInfo("INI");
            IntiUI();
        }

        private void IntiUI()
        {
            this.Text = config.ReadConfigValue("MGM", "NG_UI_Caption");

            this.label1.Text = config.ReadConfigValue("MGM", "NG_UI_LvGameName");
            this.label2.Text = config.ReadConfigValue("MGM", "NG_UI__Description");

            this.button1.Text = config.ReadConfigValue("MGM", "NG_UI_BtnApply");
            this.button2.Text = config.ReadConfigValue("MGM", "NG_UI_BtnCancel");

        }


        #endregion
	}
}
