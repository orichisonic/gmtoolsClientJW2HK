using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using C_Global;
using C_Event;
using C_Socket;

using Language;

namespace M_GM
{
	/// <summary>
	/// ModuleList 的摘要说明。
	/// </summary>
	[C_Global.CModuleAttribute("模块管理", "ModuleList", "管理模块信息", "User Group")]
	public class ModuleList : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader ColumnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.ColumnHeader columnHeader5;
        private DividerPanel.DividerPanel dividerPanel1;
        private DividerPanel.DividerPanel dividerPanel2;
        private DividerPanel.DividerPanel dividerPanel3;
        private ImageTextControl.IMGTXTCTRL ITC_NewModule;
        private ImageTextControl.IMGTXTCTRL ITC_EditModule;
        private ImageTextControl.IMGTXTCTRL ITC_DelModule;
        private ImageTextControl.IMGTXTCTRL ITC_Prev;
        private ImageTextControl.IMGTXTCTRL ITC_Next;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ModuleList()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModuleList));
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.ITC_Next = new ImageTextControl.IMGTXTCTRL();
            this.ITC_Prev = new ImageTextControl.IMGTXTCTRL();
            this.ITC_DelModule = new ImageTextControl.IMGTXTCTRL();
            this.ITC_EditModule = new ImageTextControl.IMGTXTCTRL();
            this.ITC_NewModule = new ImageTextControl.IMGTXTCTRL();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.dividerPanel3 = new DividerPanel.DividerPanel();
            this.dividerPanel1.SuspendLayout();
            this.dividerPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuItem2
            // 
            this.menuItem2.Index = -1;
            this.menuItem2.Text = "编辑";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "描述";
            this.columnHeader4.Width = 195;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.ColumnHeader2,
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader4});
            this.listView1.ContextMenu = this.contextMenu1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(2, 2);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listView1.Size = new System.Drawing.Size(658, 253);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "编号";
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "模块名称";
            this.ColumnHeader2.Width = 105;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "模块类名";
            this.columnHeader3.Width = 118;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "所属游戏";
            this.columnHeader1.Width = 120;
            // 
            // menuItem1
            // 
            this.menuItem1.Index = -1;
            this.menuItem1.Text = "新建";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = -1;
            this.menuItem3.Text = "删除";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.ITC_Next);
            this.dividerPanel1.Controls.Add(this.ITC_Prev);
            this.dividerPanel1.Controls.Add(this.ITC_DelModule);
            this.dividerPanel1.Controls.Add(this.ITC_EditModule);
            this.dividerPanel1.Controls.Add(this.ITC_NewModule);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(662, 38);
            this.dividerPanel1.TabIndex = 2;
            // 
            // ITC_Next
            // 
            this.ITC_Next.ControlPoint = new System.Drawing.Point(0, 0);
            this.ITC_Next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ITC_Next.IMG_SRC = ((System.Drawing.Image)(resources.GetObject("ITC_Next.IMG_SRC")));
            this.ITC_Next.ITXT_ForeColor = System.Drawing.Color.Blue;
            this.ITC_Next.ITXT_MouseHoverColor = System.Drawing.Color.Red;
            this.ITC_Next.ITXT_TEXT = "下一页";
            this.ITC_Next.Location = new System.Drawing.Point(403, 10);
            this.ITC_Next.Name = "ITC_Next";
            this.ITC_Next.Size = new System.Drawing.Size(66, 20);
            this.ITC_Next.TabIndex = 4;
            this.ITC_Next.ITC_CLICIK += new ImageTextControl.ITCEventHandler(this.ITC_Next_ITC_CLICIK);
            // 
            // ITC_Prev
            // 
            this.ITC_Prev.ControlPoint = new System.Drawing.Point(0, 0);
            this.ITC_Prev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ITC_Prev.IMG_SRC = ((System.Drawing.Image)(resources.GetObject("ITC_Prev.IMG_SRC")));
            this.ITC_Prev.ITXT_ForeColor = System.Drawing.Color.Blue;
            this.ITC_Prev.ITXT_MouseHoverColor = System.Drawing.Color.Red;
            this.ITC_Prev.ITXT_TEXT = "上一页";
            this.ITC_Prev.Location = new System.Drawing.Point(331, 10);
            this.ITC_Prev.Name = "ITC_Prev";
            this.ITC_Prev.Size = new System.Drawing.Size(66, 20);
            this.ITC_Prev.TabIndex = 3;
            this.ITC_Prev.ITC_CLICIK += new ImageTextControl.ITCEventHandler(this.ITC_Prev_ITC_CLICIK);
            // 
            // ITC_DelModule
            // 
            this.ITC_DelModule.ControlPoint = new System.Drawing.Point(0, 0);
            this.ITC_DelModule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ITC_DelModule.IMG_SRC = ((System.Drawing.Image)(resources.GetObject("ITC_DelModule.IMG_SRC")));
            this.ITC_DelModule.ITXT_ForeColor = System.Drawing.Color.Black;
            this.ITC_DelModule.ITXT_MouseHoverColor = System.Drawing.Color.Red;
            this.ITC_DelModule.ITXT_TEXT = "删除模块";
            this.ITC_DelModule.Location = new System.Drawing.Point(176, 10);
            this.ITC_DelModule.Name = "ITC_DelModule";
            this.ITC_DelModule.Size = new System.Drawing.Size(76, 18);
            this.ITC_DelModule.TabIndex = 2;
            this.ITC_DelModule.ITC_CLICIK += new ImageTextControl.ITCEventHandler(this.ITC_DelModule_ITC_CLICIK);
            // 
            // ITC_EditModule
            // 
            this.ITC_EditModule.ControlPoint = new System.Drawing.Point(0, 0);
            this.ITC_EditModule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ITC_EditModule.IMG_SRC = ((System.Drawing.Image)(resources.GetObject("ITC_EditModule.IMG_SRC")));
            this.ITC_EditModule.ITXT_ForeColor = System.Drawing.Color.Black;
            this.ITC_EditModule.ITXT_MouseHoverColor = System.Drawing.Color.Red;
            this.ITC_EditModule.ITXT_TEXT = "编辑模块";
            this.ITC_EditModule.Location = new System.Drawing.Point(94, 10);
            this.ITC_EditModule.Name = "ITC_EditModule";
            this.ITC_EditModule.Size = new System.Drawing.Size(76, 18);
            this.ITC_EditModule.TabIndex = 1;
            this.ITC_EditModule.ITC_CLICIK += new ImageTextControl.ITCEventHandler(this.ITC_EditModule_ITC_CLICIK);
            // 
            // ITC_NewModule
            // 
            this.ITC_NewModule.ControlPoint = new System.Drawing.Point(0, 0);
            this.ITC_NewModule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ITC_NewModule.IMG_SRC = ((System.Drawing.Image)(resources.GetObject("ITC_NewModule.IMG_SRC")));
            this.ITC_NewModule.ITXT_ForeColor = System.Drawing.Color.Black;
            this.ITC_NewModule.ITXT_MouseHoverColor = System.Drawing.Color.Red;
            this.ITC_NewModule.ITXT_TEXT = "创建模块";
            this.ITC_NewModule.Location = new System.Drawing.Point(12, 10);
            this.ITC_NewModule.Name = "ITC_NewModule";
            this.ITC_NewModule.Size = new System.Drawing.Size(76, 18);
            this.ITC_NewModule.TabIndex = 0;
            this.ITC_NewModule.ITC_CLICIK += new ImageTextControl.ITCEventHandler(this.ITC_NewModule_ITC_CLICIK);
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 48);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(662, 10);
            this.dividerPanel2.TabIndex = 3;
            // 
            // dividerPanel3
            // 
            this.dividerPanel3.AllowDrop = true;
            this.dividerPanel3.Controls.Add(this.listView1);
            this.dividerPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel3.Location = new System.Drawing.Point(10, 58);
            this.dividerPanel3.Name = "dividerPanel3";
            this.dividerPanel3.Padding = new System.Windows.Forms.Padding(2);
            this.dividerPanel3.Size = new System.Drawing.Size(662, 257);
            this.dividerPanel3.TabIndex = 4;
            // 
            // ModuleList
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(682, 325);
            this.Controls.Add(this.dividerPanel3);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "ModuleList";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "模块列表";
            this.Load += new System.EventHandler(this.ModuleList_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region 事件
		
		/// <summary>
		/// 新建模块
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem1_Click(object sender, System.EventArgs e)
		{
            this.NewModule();
		}

		/// <summary>
		/// 编辑选定模块
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem2_Click(object sender, System.EventArgs e)
		{
            this.EditModule();
		}
		
		/// <summary>
		/// 删除模块
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem3_Click(object sender, System.EventArgs e)
		{
            this.DelModule();
		}

        private void ITC_DelModule_ITC_CLICIK(object sender)
        {
            this.DelModule();
        }

        private void ITC_EditModule_ITC_CLICIK(object sender)
        {
            this.EditModule();
        }

        private void ITC_NewModule_ITC_CLICIK(object sender)
        {
            this.NewModule();
        }

		/// <summary>
		/// 载入窗体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ModuleList_Load(object sender, System.EventArgs e)
		{
            IntiFontLib();
			InitializeListView();
		}




		/// <summary>
		/// 鼠标右键
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listView1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//右键鼠标
			if(e.Button == MouseButtons.Right && e.Clicks == 1)
			{
				//清楚右键内容
				this.contextMenu1.MenuItems.Clear();
				try
				{
					int selectIndex = this.listView1.GetItemAt(e.X,e.Y).Index;
					this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																								 this.menuItem1,
																								 this.menuItem2,
																								 this.menuItem3});
				}
				catch
				{
					this.contextMenu1.MenuItems.Add(this.menuItem1);
				}
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
			ModuleList moduleList = new ModuleList();
			moduleList.m_ClientEvent = (CSocketEvent)oEvent;

			if (oParent != null)
			{
				moduleList.MdiParent = (Form)oParent;
				moduleList.Show();
			}
			else
			{
				moduleList.ShowDialog();
			}

			return moduleList;
			
		}
		#endregion

		#region 变量
		private CSocketEvent m_ClientEvent = null;

		private C_Global.CEnum.Message_Body[,] mResult = null;

        private int pageIndex = 1;  //发送给服务器的开始条数
        private int pageSize = 30;   //每页显示条数
        private int pageCount = 1;  //总页数
        private int currPage = 0;   //当前页数
		#endregion

		#region 自定义函数
		/// <summary>
		/// 初始化列表
		/// </summary>
		public void InitializeListView()
		{
			try
			{
				//listView1.Columns.Clear();
				listView1.Items.Clear();

				C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

				messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
				messageBody[0].eName = C_Global.CEnum.TagName.Index;
                messageBody[0].oContent = pageIndex;

				messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
				messageBody[1].eName = C_Global.CEnum.TagName.PageSize;
                messageBody[1].oContent = pageSize;
			
				//正式信息
				mResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.MODULE_QUERY, C_Global.CEnum.Msg_Category.MODULE_ADMIN, messageBody);
				//检测状态
				if (mResult[0,0].eName == C_Global.CEnum.TagName.ERROR_Msg)
				{
					MessageBox.Show(mResult[0,0].oContent.ToString());
					//Application.Exit();
					return;
				}
                //总页数
                pageCount = int.Parse(mResult[0, 6].oContent.ToString());

				//显示内容到列表
				string[] rowInfo = new string[5];
				for (int i=0; i<mResult.GetLength(0); i++)
				{
					//编号
					rowInfo[0] = Convert.ToString(i+1);
					//模块名称
					rowInfo[1] = mResult[i,3].oContent.ToString();
					//模块类名
					rowInfo[2] = mResult[i,4].oContent.ToString();
					//所属游戏
					rowInfo[3] = mResult[i,2].oContent.ToString();
					//描述
					rowInfo[4] = mResult[i,5].oContent.ToString();
					ListViewItem mlistViewItem = new ListViewItem(rowInfo, -1);
					listView1.Items.Add(mlistViewItem);
					listView1.Items[i].Tag = mResult[i,1].oContent.ToString();				
				}	
				//listView1 = GMAdmin.DisplayView(m_ClientEvent, listView1, mResult,true);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		#endregion		

        #region 事件函数
        /// <summary>
        /// 新建游戏模块
        /// </summary>
        private void NewModule()
        {
            NewModule newModule = new NewModule();
            newModule.CreateModule(null, m_ClientEvent);
            InitializeListView();
        }


        /// <summary>
        /// 编辑游戏模块
        /// </summary>
        private void EditModule()
        {
            //要更改模块的所在行
            int selectIndex = 0;

            try
            {
                selectIndex = this.listView1.SelectedItems[0].Index;
            }
            catch
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "ML_Code_ChooseModule"), "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                //要更改的模块id
                int moduleID = int.Parse(this.listView1.Items[selectIndex].Tag.ToString());
                //传送到属性窗体的用户信息
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[5];

                for (int i = 0; i < mResult.GetLength(0); i++)
                {
                    if (int.Parse(mResult[i, 0].oContent.ToString()) == moduleID)
                    {
                        messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                        messageBody[0].eName = C_Global.CEnum.TagName.Module_ID;
                        messageBody[0].oContent = moduleID;

                        messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                        messageBody[1].eName = C_Global.CEnum.TagName.GameName;
                        messageBody[1].oContent = mResult[i, 2].oContent.ToString().Trim();

                        messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                        messageBody[2].eName = C_Global.CEnum.TagName.ModuleName;
                        messageBody[2].oContent = mResult[i, 3].oContent.ToString().Trim();

                        messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                        messageBody[3].eName = C_Global.CEnum.TagName.ModuleClass;
                        messageBody[3].oContent = mResult[i, 4].oContent.ToString().Trim();

                        messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                        messageBody[4].eName = C_Global.CEnum.TagName.ModuleContent;
                        messageBody[4].oContent = mResult[i, 5].oContent.ToString().Trim();

                        NewModule newModule = null;
                        try
                        {
                            newModule = new NewModule(true, messageBody);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        try
                        {
                            newModule.CreateModule(null, m_ClientEvent);
                            InitializeListView();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 删除模块
        /// </summary>
        private void DelModule()
        {
            //要删除的模块所在行
            int selectIndex = 0;

            try
            {
                selectIndex = this.listView1.SelectedItems[0].Index;
            }
            catch
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "ML_Code_ChooseModule"), "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                if (MessageBox.Show(config.ReadConfigValue("MGM", "ML_Code_SureToDeleteModule"), "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }

                
                //要删除的模块id
                int moduleID = int.Parse(this.listView1.Items[selectIndex].Tag.ToString());
                //执行操作的返回结果
                C_Global.CEnum.Message_Body[,] resultMsgBody = null;
                //发送的信息
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.Module_ID;
                messageBody[1].oContent = moduleID;


                resultMsgBody = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.MODULE_DELETE, C_Global.CEnum.Msg_Category.MODULE_ADMIN, messageBody);
                //检测状态
                if (resultMsgBody[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(resultMsgBody[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }
                if (resultMsgBody[0, 1].oContent.ToString().Trim().ToUpper().Equals("SUCESS"))
                {
                    //this.listView1.Items[selectIndex].Remove();
                    InitializeListView();
                    MessageBox.Show(config.ReadConfigValue("MGM", "ML_Code_Succeed"));
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void ITC_Prev_ITC_CLICIK(object sender)
        {
            if (currPage > 0)
            {
                currPage -= 1;
                pageIndex = currPage * pageSize + 1;
                this.InitializeListView();
            }
        }

        private void ITC_Next_ITC_CLICIK(object sender)
        {
            if (currPage < pageCount - 1)
            {
                currPage += 1;
                pageIndex = currPage * pageSize + 1;
                this.InitializeListView();
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
            this.Text = config.ReadConfigValue("MGM", "ML_UI_Caption");

            this.ITC_NewModule.ITXT_TEXT = config.ReadConfigValue("MGM", "ML_UI_ITC_NewModule");
            this.ITC_EditModule.ITXT_TEXT = config.ReadConfigValue("MGM", "ML_UI_ITC_EditModule");
            this.ITC_DelModule.ITXT_TEXT = config.ReadConfigValue("MGM", "ML_UI_ITC_DelModule");

            this.ITC_Prev.ITXT_TEXT = config.ReadConfigValue("MGM", "ML_UI_ITC_PrevPage");
            this.ITC_Next.ITXT_TEXT = config.ReadConfigValue("MGM", "ML_UI_ITC_NextPage");

            this.menuItem1.Text = config.ReadConfigValue("MGM", "ML_UI_ITC_NewModule");
            this.menuItem2.Text = config.ReadConfigValue("MGM", "ML_UI_ITC_EditModule");
            this.menuItem3.Text = config.ReadConfigValue("MGM", "ML_UI_ITC_DelModule");

        }


        #endregion




    }
}
