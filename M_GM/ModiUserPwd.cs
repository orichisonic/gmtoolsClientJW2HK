using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using C_Global;
using C_Event;

using Language;

namespace M_GM
{
	/// <summary>
	/// ModiUserPwd 的摘要说明。
	/// </summary>
	[C_Global.CModuleAttribute("GM用户密码修改", "ModiUserPwd", "修改GM用户信息", "User Group")]
	public class ModiUserPwd : System.Windows.Forms.Form
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ModiUserPwd()
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
		/// 构造函数,传入Pwd
		/// </summary>
		public ModiUserPwd(int userID,string password)
		{
			InitializeComponent();
			this.userID = userID;
			this.password = password;
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtValidPwd = new System.Windows.Forms.TextBox();
            this.txtNewPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(192, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "确认";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtValidPwd
            // 
            this.txtValidPwd.Location = new System.Drawing.Point(80, 51);
            this.txtValidPwd.Name = "txtValidPwd";
            this.txtValidPwd.PasswordChar = '*';
            this.txtValidPwd.Size = new System.Drawing.Size(272, 21);
            this.txtValidPwd.TabIndex = 13;
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Location = new System.Drawing.Point(80, 11);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.PasswordChar = '*';
            this.txtNewPwd.Size = new System.Drawing.Size(272, 21);
            this.txtNewPwd.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "确认密码：";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "新密码：";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(277, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "取消";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ModiUserPwd
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(362, 115);
            this.Controls.Add(this.txtValidPwd);
            this.Controls.Add(this.txtNewPwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModiUserPwd";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置密码";
            this.Load += new System.EventHandler(this.ModiUserPwd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		#region 调用函数
		/// <summary>
		/// 创建类库中的窗体
		/// </summary>
		/// <param name="oParent">MDI 程序的父窗体</param>
		/// <param name="oSocket">Socket</param>
		/// <returns>类库中的窗体</returns>
		public Form CreateModule(object oParent, object oEvent)
		{
			//ModiUserPwd modi = new ModiUserPwd();
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
		private string password = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtValidPwd;
        private System.Windows.Forms.TextBox txtNewPwd;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button2;
		private int userID = 0;
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			#region 检测
			if(this.txtNewPwd.Text == null || this.txtNewPwd.Text == "")
			{
                MessageBox.Show(config.ReadConfigValue("MGM", "MP_Code_InputNewPwd"));
				txtNewPwd.Focus();
				return;
			}
			
			if(this.txtValidPwd.Text == null || this.txtValidPwd.Text == "")
			{
                MessageBox.Show(config.ReadConfigValue("MGM", "MP_Code_InputConfPwd"));
				txtValidPwd.Focus();
				return;
			}

			if(!this.txtNewPwd.Text.Trim().Equals(this.txtValidPwd.Text.Trim()))
			{
                MessageBox.Show(config.ReadConfigValue("MGM", "MP_Code_PwdErr"));
				txtValidPwd.Focus();
				return;
			}
			#endregion

			try
			{
				//执行操作的返回结果
				C_Global.CEnum.Message_Body[,] resultMsgBody = null;
				//传入的Message_Body
				C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

				messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
				messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
				messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

				messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
				messageBody[1].eName = C_Global.CEnum.TagName.User_ID;
				messageBody[1].oContent = this.userID;

				messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
				messageBody[2].eName = C_Global.CEnum.TagName.PassWord;
				messageBody[2].oContent = this.txtNewPwd.Text.ToString().Trim();

				resultMsgBody = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.USER_PASSWD_MODIF,C_Global.CEnum.Msg_Category.USER_ADMIN,messageBody);
				//检测状态
				if (resultMsgBody[0,0].eName == C_Global.CEnum.TagName.ERROR_Msg)
				{
					MessageBox.Show(resultMsgBody[0,0].oContent.ToString());
					//Application.Exit();
					return;
				}
				//int a=1;
				if(resultMsgBody[0,0].oContent.ToString().Trim().ToUpper().Equals("SUCESS"))
				{
					MessageBox.Show(config.ReadConfigValue("MGM", "MP_Code_Succeed"));
					this.Close();	
				}

			}
			catch(Exception ex)
			{
				//MessageBox.Show(ex.Message);
			}


		}

		private void ModiUserPwd_Load(object sender, System.EventArgs e)
		{
            IntiFontLib();
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
            this.Text = config.ReadConfigValue("MGM", "MP_UI_Caption");

            this.label2.Text = config.ReadConfigValue("MGM", "MP_UI_NewPwd");
            this.label3.Text = config.ReadConfigValue("MGM", "MP_UI_ConfPwd");

            this.button1.Text = config.ReadConfigValue("MGM", "MP_UI_BtnApply");
            this.button2.Text = config.ReadConfigValue("MGM", "MP_UI_BtnCancel");

        }


        #endregion
	}
}
