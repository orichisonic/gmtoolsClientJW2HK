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
	/// ModiUserAttribute 的摘要说明。
	/// </summary>
	[C_Global.CModuleAttribute("GM属性编辑", "ModiUserAttribute", "编辑GM用户信息", "User Group")]
	public class ModiUserAttribute : System.Windows.Forms.Form
	{
		private System.Windows.Forms.CheckBox userStatus;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.TextBox txtUser;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnAddUser;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox department;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtRealName;
		private System.Windows.Forms.Label label7;
		private DividerPanel.DividerPanel dividerPanel1;
		private DividerPanel.DividerPanel dividerPanel2;
        private CheckBox chkGMOnLine;
        private CheckBox chkSystmeAdmin;
        private CheckBox chkDeptAdmin;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ModiUserAttribute()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		public ModiUserAttribute(int userID,C_Global.CEnum.Message_Body[] msgUserAttribute)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			this.userID = userID;
			this.msgUserAttribute = msgUserAttribute;

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
            this.userStatus = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.department = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRealName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.chkGMOnLine = new System.Windows.Forms.CheckBox();
            this.chkSystmeAdmin = new System.Windows.Forms.CheckBox();
            this.chkDeptAdmin = new System.Windows.Forms.CheckBox();
            this.dividerPanel1.SuspendLayout();
            this.dividerPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // userStatus
            // 
            this.userStatus.Location = new System.Drawing.Point(12, 204);
            this.userStatus.Name = "userStatus";
            this.userStatus.Size = new System.Drawing.Size(88, 24);
            this.userStatus.TabIndex = 60;
            this.userStatus.Text = "停用该帐户";
            this.userStatus.CheckedChanged += new System.EventHandler(this.userStatus_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 58;
            this.label2.Text = "使用时效：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(104, 168);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(272, 21);
            this.dateTimePicker1.TabIndex = 57;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // txtUser
            // 
            this.txtUser.Enabled = false;
            this.txtUser.Location = new System.Drawing.Point(104, 64);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(272, 21);
            this.txtUser.TabIndex = 53;
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 16);
            this.label8.TabIndex = 49;
            this.label8.Text = "用 户 名：";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(312, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(64, 23);
            this.btnClose.TabIndex = 48;
            this.btnClose.Text = "取消";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(232, 16);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(64, 23);
            this.btnAddUser.TabIndex = 47;
            this.btnAddUser.Text = "确定";
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 16);
            this.label1.TabIndex = 61;
            this.label1.Text = "编辑GM基本信息管理";
            // 
            // department
            // 
            this.department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.department.Location = new System.Drawing.Point(104, 128);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(272, 20);
            this.department.TabIndex = 69;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 16);
            this.label4.TabIndex = 68;
            this.label4.Text = "所在部门：";
            // 
            // txtRealName
            // 
            this.txtRealName.Location = new System.Drawing.Point(104, 96);
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.Size = new System.Drawing.Size(272, 21);
            this.txtRealName.TabIndex = 67;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 16);
            this.label7.TabIndex = 66;
            this.label7.Text = "真实姓名：";
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
            this.dividerPanel1.Size = new System.Drawing.Size(386, 48);
            this.dividerPanel1.TabIndex = 70;
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.BorderSide = System.Windows.Forms.Border3DSide.Top;
            this.dividerPanel2.Controls.Add(this.btnClose);
            this.dividerPanel2.Controls.Add(this.btnAddUser);
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dividerPanel2.Location = new System.Drawing.Point(0, 280);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(386, 48);
            this.dividerPanel2.TabIndex = 71;
            // 
            // chkGMOnLine
            // 
            this.chkGMOnLine.AutoSize = true;
            this.chkGMOnLine.Location = new System.Drawing.Point(12, 230);
            this.chkGMOnLine.Name = "chkGMOnLine";
            this.chkGMOnLine.Size = new System.Drawing.Size(72, 16);
            this.chkGMOnLine.TabIndex = 72;
            this.chkGMOnLine.Text = "用户在线";
            this.chkGMOnLine.UseVisualStyleBackColor = true;
            this.chkGMOnLine.Click += new System.EventHandler(this.chkGMOnLine_Click);
            // 
            // chkSystmeAdmin
            // 
            this.chkSystmeAdmin.AutoSize = true;
            this.chkSystmeAdmin.Location = new System.Drawing.Point(12, 253);
            this.chkSystmeAdmin.Name = "chkSystmeAdmin";
            this.chkSystmeAdmin.Size = new System.Drawing.Size(84, 16);
            this.chkSystmeAdmin.TabIndex = 73;
            this.chkSystmeAdmin.Text = "系统管理员";
            this.chkSystmeAdmin.UseVisualStyleBackColor = true;
            this.chkSystmeAdmin.Click += new System.EventHandler(this.chkSystmeAdmin_Click);
            // 
            // chkDeptAdmin
            // 
            this.chkDeptAdmin.AutoSize = true;
            this.chkDeptAdmin.Location = new System.Drawing.Point(108, 253);
            this.chkDeptAdmin.Name = "chkDeptAdmin";
            this.chkDeptAdmin.Size = new System.Drawing.Size(108, 16);
            this.chkDeptAdmin.TabIndex = 74;
            this.chkDeptAdmin.Text = "部门级别管理员";
            this.chkDeptAdmin.UseVisualStyleBackColor = true;
            this.chkDeptAdmin.Click += new System.EventHandler(this.chkDeptAdmin_Click);
            // 
            // ModiUserAttribute
            // 
            this.AcceptButton = this.btnAddUser;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(386, 328);
            this.Controls.Add(this.chkDeptAdmin);
            this.Controls.Add(this.chkSystmeAdmin);
            this.Controls.Add(this.chkGMOnLine);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Controls.Add(this.department);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRealName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.userStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModiUserAttribute";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户信息";
            this.Load += new System.EventHandler(this.ModiUserAttribute_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void dateTimePicker1_ValueChanged(object sender, System.EventArgs e)
		{
		
		}

		private void label2_Click(object sender, System.EventArgs e)
		{
		
		}

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void userStatus_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void txtConfirm_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void txtPasswd_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void txtContent_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void txtUser_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void label1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void label6_Click(object sender, System.EventArgs e)
		{
		
		}

		private void label7_Click(object sender, System.EventArgs e)
		{
		
		}

		private void label8_Click(object sender, System.EventArgs e)
		{
		
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
		
		}

		private void btnAddUser_Click(object sender, System.EventArgs e)
		{
            //


			C_Global.CEnum.Message_Body[,] resultMsgBody = null;

			C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[8];
			messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
			messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
			messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());
			
			messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
			messageBody[1].eName = C_Global.CEnum.TagName.User_ID;
			messageBody[1].oContent = this.userID;
			
			messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_DATE;
			messageBody[2].eName = C_Global.CEnum.TagName.Limit;
			messageBody[2].oContent = Convert.ToDateTime(this.dateTimePicker1.Text);


			messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
			messageBody[3].eName = C_Global.CEnum.TagName.User_Status;
			messageBody[3].oContent = this.userStatus.Checked ? 0 : 1;

			messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
			messageBody[4].eName = C_Global.CEnum.TagName.RealName;
			messageBody[4].oContent = this.txtRealName.Text.Trim();

			messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
			messageBody[5].eName = C_Global.CEnum.TagName.DepartID;
			messageBody[5].oContent = GetDepartmentID(this.department.SelectedItem.ToString().Trim());

            messageBody[6].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[6].eName = C_Global.CEnum.TagName.OnlineActive;
            messageBody[6].oContent = chkGMOnLine.Checked ? 1 : 0;

            messageBody[7].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[7].eName = C_Global.CEnum.TagName.SysAdmin;
            messageBody[7].oContent = chkSystmeAdmin.Checked ? 1 : chkDeptAdmin.Checked ? 2 : 0;

            

			try
			{
				resultMsgBody = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.USER_UPDATE,C_Global.CEnum.Msg_Category.USER_ADMIN,messageBody);
				//检测状态
				if (resultMsgBody[0,0].eName == C_Global.CEnum.TagName.ERROR_Msg)
				{
					MessageBox.Show(resultMsgBody[0,0].oContent.ToString());
					//Application.Exit();
					return;
				}
				if(resultMsgBody[0,0].oContent.ToString().Trim().ToUpper().Equals("SUCESS"))
				{
					/*
					AccountList accountList = new AccountList();
					this.Close();
					accountList.CreateModule(null,m_ClientEvent);
					*/
					MessageBox.Show(config.ReadConfigValue("MGM", "MU_Code_Succeed"));
					this.Close();	
				}
                if (resultMsgBody[0, 0].oContent.ToString().Trim().ToUpper().Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MGM", "MU_Code_Failed"));
                    return;
                }
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// 窗体载入
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ModiUserAttribute_Load(object sender, System.EventArgs e)
		{
            IntiFontLib();

            if (int.Parse(m_ClientEvent.GetInfo("SysAdminValue").ToString()) == 0)
            {
                chkDeptAdmin.Visible = false;
                chkSystmeAdmin.Visible = false;
            }
            if (int.Parse(m_ClientEvent.GetInfo("SysAdminValue").ToString()) == 2)
            {
                chkSystmeAdmin.Visible = false;
                chkDeptAdmin.Visible = false;
            }

			this.txtUser.Text = msgUserAttribute[1].oContent.ToString();
            int isAdmin = int.Parse(msgUserAttribute[7].oContent.ToString());
            if (isAdmin == 1)
            {
                chkSystmeAdmin.Checked = true;
            }
            else if (isAdmin == 2)
            {
                chkDeptAdmin.Checked = true;
            }
            else
            {
                chkSystmeAdmin.Checked = false;
            }

            if (int.Parse(msgUserAttribute[6].oContent.ToString()) == 1)
            {
                this.chkGMOnLine.Checked = true;
            }
			
			int dateYear = Convert.ToDateTime(msgUserAttribute[2].oContent).Year;
			
			int dateMonth = Convert.ToDateTime(msgUserAttribute[2].oContent).Month;
			int dateDay = Convert.ToDateTime(msgUserAttribute[2].oContent).Day;
			this.dateTimePicker1.Value= this.dateTimePicker1.Value = new System.DateTime(dateYear,dateMonth,dateDay);

			this.txtRealName.Text = msgUserAttribute[4].oContent.ToString();

			if(int.Parse(msgUserAttribute[3].oContent.ToString()) == 0)
				this.userStatus.Checked = true;

            #region 部门列表相关信息
			departmentMsg = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.DEPART_QUERY, C_Global.CEnum.Msg_Category.USER_ADMIN, null);

			if (departmentMsg[0,0].eName == C_Global.CEnum.TagName.ERROR_Msg)
			{
				MessageBox.Show(departmentMsg[0,0].oContent.ToString());
				return;
			}

			string departName = null;//部门名称

			for(int i=0;i<departmentMsg.GetLength(0);i++)
			{
				department.Items.Add(departmentMsg[i,1].oContent.ToString().Trim());
				if (int.Parse(msgUserAttribute[5].oContent.ToString()) == int.Parse(departmentMsg[i,0].oContent.ToString()))
				{
					departName = departmentMsg[i,1].oContent.ToString().Trim();
				}
			}
			//标记选中部门
			int index = department.FindString(departName);
			this.department.SelectedIndex = index;

            /*
                 * 使用情况:权限模块
                 * 分析:登陆帐号为部门级管理者时只能为其本部门添加帐号,所以部门应限定死,不可选择
                 */
            if (int.Parse(m_ClientEvent.GetInfo("SysAdminValue").ToString()) == 2)
            {
                department.Enabled = false;
            }
            #endregion
        }

		private void groupBox1_Enter(object sender, System.EventArgs e)
		{
		
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
			//ModiUserAttribute modiAttrib = new ModiUserAttribute();
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
		//private Message_Body[,] doResult = null;		//执行结果
		private C_Global.CEnum.Message_Body[] msgUserAttribute = null;	//用户的基本信息
		private int userID = 0;							//用户的id
		private C_Global.CEnum.Message_Body[,] departmentMsg = null;

		#endregion


		#region 自定义函数
		private int GetDepartmentID(string DepartmentName)
		{
			int returnValue = 0;
			for(int i=0;i<departmentMsg.GetLength(0);i++)
			{
				if(departmentMsg[i,1].oContent.ToString().Trim() == DepartmentName)
				{
					returnValue = int.Parse(departmentMsg[i,0].oContent.ToString());
				}
			}
			return returnValue;
		}
		#endregion

        private void chkGMOnLine_Click(object sender, EventArgs e)
        {
        }

        private void chkDeptAdmin_Click(object sender, EventArgs e)
        {
            chkSystmeAdmin.Checked = false;
        }

        private void chkSystmeAdmin_Click(object sender, EventArgs e)
        {
            chkDeptAdmin.Checked = false;
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
            this.Text = config.ReadConfigValue("MGM", "NU_UI_Caption");

            this.label1.Text = config.ReadConfigValue("MGM", "MU_UI_Description");

            this.label8.Text = config.ReadConfigValue("MGM", "NU_UI_Account");
            this.label7.Text = config.ReadConfigValue("MGM", "NU_UI_RealName");
            this.label4.Text = config.ReadConfigValue("MGM", "NU_UI_Department");
            this.label2.Text = config.ReadConfigValue("MGM", "NU_UI_TimeLimit");
            this.userStatus.Text = config.ReadConfigValue("MGM", "NU_UI_StopAccount");
            this.chkGMOnLine.Text = config.ReadConfigValue("MGM", "MU_UI_UserOnline");
            this.chkSystmeAdmin.Text = config.ReadConfigValue("MGM", "NU_UI_SysAdmin");
            this.chkDeptAdmin.Text = config.ReadConfigValue("MGM", "NU_UI_DepartAdmin");
            this.btnAddUser.Text = config.ReadConfigValue("MGM", "NU_UI_BtnApply");
            this.btnClose.Text = config.ReadConfigValue("MGM", "NU_UI_BtnCancel");

        }


        #endregion

		
	}
}
