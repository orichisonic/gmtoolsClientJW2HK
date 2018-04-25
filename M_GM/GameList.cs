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
	/// GameList 的摘要说明。
	/// </summary>
	[C_Global.CModuleAttribute("游戏管理", "GameList", "管理游戏信息", "User Group")]
	public class GameList : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.ListView listViewGameList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
        private DividerPanel.DividerPanel dividerPanel1;
        private DividerPanel.DividerPanel dividerPanel2;
        private DividerPanel.DividerPanel dividerPanel3;
        private ImageTextControl.IMGTXTCTRL ITC_NewGame;
        private ImageTextControl.IMGTXTCTRL ITC_EditGame;
        private ImageTextControl.IMGTXTCTRL ITC_DelGame;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GameList()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameList));
            this.listViewGameList = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.ITC_DelGame = new ImageTextControl.IMGTXTCTRL();
            this.ITC_EditGame = new ImageTextControl.IMGTXTCTRL();
            this.ITC_NewGame = new ImageTextControl.IMGTXTCTRL();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.dividerPanel3 = new DividerPanel.DividerPanel();
            this.dividerPanel1.SuspendLayout();
            this.dividerPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewGameList
            // 
            this.listViewGameList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2});
            this.listViewGameList.ContextMenu = this.contextMenu1;
            this.listViewGameList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewGameList.FullRowSelect = true;
            this.listViewGameList.GridLines = true;
            this.listViewGameList.Location = new System.Drawing.Point(2, 2);
            this.listViewGameList.MultiSelect = false;
            this.listViewGameList.Name = "listViewGameList";
            this.listViewGameList.Size = new System.Drawing.Size(544, 269);
            this.listViewGameList.TabIndex = 1;
            this.listViewGameList.UseCompatibleStateImageBehavior = false;
            this.listViewGameList.View = System.Windows.Forms.View.Details;
            this.listViewGameList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewGameList_MouseDown);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "编号";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "游戏名称";
            this.columnHeader1.Width = 116;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "描述";
            this.columnHeader2.Width = 353;
            // 
            // menuItem1
            // 
            this.menuItem1.Index = -1;
            this.menuItem1.Text = "新建游戏";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = -1;
            this.menuItem2.Text = "-";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = -1;
            this.menuItem3.Text = "删除";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = -1;
            this.menuItem5.Text = "-";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = -1;
            this.menuItem6.Text = "编辑";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.ITC_DelGame);
            this.dividerPanel1.Controls.Add(this.ITC_EditGame);
            this.dividerPanel1.Controls.Add(this.ITC_NewGame);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(548, 38);
            this.dividerPanel1.TabIndex = 2;
            // 
            // ITC_DelGame
            // 
            this.ITC_DelGame.ControlPoint = new System.Drawing.Point(0, 0);
            this.ITC_DelGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ITC_DelGame.IMG_SRC = ((System.Drawing.Image)(resources.GetObject("ITC_DelGame.IMG_SRC")));
            this.ITC_DelGame.ITXT_ForeColor = System.Drawing.Color.Black;
            this.ITC_DelGame.ITXT_MouseHoverColor = System.Drawing.Color.Red;
            this.ITC_DelGame.ITXT_TEXT = "删除游戏";
            this.ITC_DelGame.Location = new System.Drawing.Point(176, 10);
            this.ITC_DelGame.Name = "ITC_DelGame";
            this.ITC_DelGame.Size = new System.Drawing.Size(76, 18);
            this.ITC_DelGame.TabIndex = 2;
            this.ITC_DelGame.ITC_CLICIK += new ImageTextControl.ITCEventHandler(this.ITC_DelGame_ITC_CLICIK);
            // 
            // ITC_EditGame
            // 
            this.ITC_EditGame.ControlPoint = new System.Drawing.Point(0, 0);
            this.ITC_EditGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ITC_EditGame.IMG_SRC = ((System.Drawing.Image)(resources.GetObject("ITC_EditGame.IMG_SRC")));
            this.ITC_EditGame.ITXT_ForeColor = System.Drawing.Color.Black;
            this.ITC_EditGame.ITXT_MouseHoverColor = System.Drawing.Color.Red;
            this.ITC_EditGame.ITXT_TEXT = "编辑游戏";
            this.ITC_EditGame.Location = new System.Drawing.Point(94, 10);
            this.ITC_EditGame.Name = "ITC_EditGame";
            this.ITC_EditGame.Size = new System.Drawing.Size(76, 18);
            this.ITC_EditGame.TabIndex = 1;
            this.ITC_EditGame.ITC_CLICIK += new ImageTextControl.ITCEventHandler(this.ITC_EditGame_ITC_CLICIK);
            // 
            // ITC_NewGame
            // 
            this.ITC_NewGame.ControlPoint = new System.Drawing.Point(0, 0);
            this.ITC_NewGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ITC_NewGame.IMG_SRC = ((System.Drawing.Image)(resources.GetObject("ITC_NewGame.IMG_SRC")));
            this.ITC_NewGame.ITXT_ForeColor = System.Drawing.Color.Black;
            this.ITC_NewGame.ITXT_MouseHoverColor = System.Drawing.Color.Red;
            this.ITC_NewGame.ITXT_TEXT = "创建游戏";
            this.ITC_NewGame.Location = new System.Drawing.Point(12, 10);
            this.ITC_NewGame.Name = "ITC_NewGame";
            this.ITC_NewGame.Size = new System.Drawing.Size(76, 18);
            this.ITC_NewGame.TabIndex = 0;
            this.ITC_NewGame.ITC_CLICIK += new ImageTextControl.ITCEventHandler(this.ITC_NewGame_ITC_CLICIK);
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 48);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(548, 10);
            this.dividerPanel2.TabIndex = 3;
            // 
            // dividerPanel3
            // 
            this.dividerPanel3.AllowDrop = true;
            this.dividerPanel3.Controls.Add(this.listViewGameList);
            this.dividerPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel3.Location = new System.Drawing.Point(10, 58);
            this.dividerPanel3.Name = "dividerPanel3";
            this.dividerPanel3.Padding = new System.Windows.Forms.Padding(2);
            this.dividerPanel3.Size = new System.Drawing.Size(548, 273);
            this.dividerPanel3.TabIndex = 4;
            // 
            // GameList
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(568, 341);
            this.Controls.Add(this.dividerPanel3);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "GameList";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "游戏列表";
            this.Load += new System.EventHandler(this.GameList_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

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
			GameList gameList = new GameList();
			gameList.m_ClientEvent = (CSocketEvent)oEvent;

			if (oParent != null)
			{
				gameList.MdiParent = (Form)oParent;
				gameList.Show();
			}
			else
			{
				gameList.ShowDialog();
			}

			return gameList;
			
		}
		#endregion

		#region 变量
		private CSocketEvent m_ClientEvent = null;

		private C_Global.CEnum.Message_Body[,] mResult = null;
		#endregion

		#region 事件

		/// <summary>
		/// 初始化窗体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GameList_Load(object sender, System.EventArgs e)
		{
            IntiFontLib();
			InitializeListView();
		}

		/// <summary>
		/// 新建游戏
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem1_Click(object sender, System.EventArgs e)
		{
            this.NewGame();
		}

        /// <summary>
        /// 删除游戏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void menuItem3_Click(object sender, System.EventArgs e)
		{
            this.DelGame();
		}


		/// <summary>
		/// 修改游戏
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem6_Click(object sender, System.EventArgs e)
		{
            this.EditGame();
		}

        private void ITC_NewGame_ITC_CLICIK(object sender)
        {
            this.NewGame();
        }

        /// <summary>
        /// 鼠标右键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewGameList_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //右键鼠标
            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                //清楚右键内容
                this.contextMenu1.MenuItems.Clear();
                try
                {
                    int selectIndex = this.listViewGameList.GetItemAt(e.X, e.Y).Index;
                    this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																								 this.menuItem1,
																								 this.menuItem2,
																								 this.menuItem3,
																								 this.menuItem5,
																								 this.menuItem6});
                }
                catch
                {
                    this.contextMenu1.MenuItems.Add(this.menuItem1);
                }
            }
        }
		
        #endregion

		#region 自定义函数
		/// <summary>
		/// 初始化列表
		/// </summary>
		public void InitializeListView()
		{
			try
			{
				//listViewGameList.Columns.Clear();
				listViewGameList.Items.Clear();
			
				C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

				messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
				messageBody[0].eName = C_Global.CEnum.TagName.Index;
				messageBody[0].oContent = 1;

				messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
				messageBody[1].eName = C_Global.CEnum.TagName.PageSize;
				messageBody[1].oContent = 20;

				//正式信息
				mResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.GAME_QUERY, C_Global.CEnum.Msg_Category.GAME_ADMIN, messageBody);

				//检测状态
				if (mResult[0,0].eName == C_Global.CEnum.TagName.ERROR_Msg)
				{
					MessageBox.Show(mResult[0,0].oContent.ToString());
					//Application.Exit();
					return;
				}	

				//显示内容到列表
				string[] rowInfo = new string[3];
				for (int i=0; i<mResult.GetLength(0); i++)
				{
					//编号
					rowInfo[0] = Convert.ToString(i+1);
					//游戏名称	
					rowInfo[1] = mResult[i,1].oContent.ToString();
					//描述
					rowInfo[2] = mResult[i,2].oContent.ToString();
					ListViewItem mlistViewItem = new ListViewItem(rowInfo, -1);
					listViewGameList.Items.Add(mlistViewItem);
					listViewGameList.Items[i].Tag = mResult[i,0].oContent.ToString();				
				}	
				//listViewGameList = GMAdmin.DisplayView(m_ClientEvent, listViewGameList, mResult,true);
			}
			catch(Exception ex)
			{
				//MessageBox.Show(ex.Message);
			}
		}
		#endregion		

        #region 事件函数
        /// <summary>
        /// 新建游戏
        /// </summary>
        private void NewGame()
        {
            NewGame newGame = new NewGame();
            newGame.CreateModule(null, m_ClientEvent);
            InitializeListView();
        }

        /// <summary>
        /// 编辑游戏
        /// </summary>
        private void EditGame()
        {
            int selectIndex = 0;

            try
            {
                //要更改游戏的所在行
                selectIndex = this.listViewGameList.SelectedItems[0].Index;
            }
            catch
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "GL_UI_ChooseGame"), "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                
                //要更改的游戏id
                int gameID = int.Parse(this.listViewGameList.Items[selectIndex].Tag.ToString());
                //传送到属性窗体的用户信息
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                for (int i = 0; i < mResult.GetLength(0); i++)
                {
                    if (int.Parse(mResult[i, 0].oContent.ToString()) == gameID)
                    {
                        messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                        messageBody[0].eName = C_Global.CEnum.TagName.GameID;
                        messageBody[0].oContent = gameID;

                        messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                        messageBody[1].eName = C_Global.CEnum.TagName.GameName;
                        messageBody[1].oContent = mResult[i, 1].oContent.ToString().Trim();

                        messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                        messageBody[2].eName = C_Global.CEnum.TagName.GameContent;
                        messageBody[2].oContent = mResult[i, 2].oContent.ToString().Trim();

                        NewGame newGame = null;
                        try
                        {
                            newGame = new NewGame(true, messageBody);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        try
                        {
                            newGame.CreateModule(null, m_ClientEvent);
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
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 删除游戏
        /// </summary>
        private void DelGame()
        {
            int selectIndex = 0;

            try
            {
                //要删除的游戏所在行
                selectIndex = this.listViewGameList.SelectedItems[0].Index;
            }
            catch
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "GL_UI_ChooseGame"), "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                if (MessageBox.Show(config.ReadConfigValue("MGM", "GL_UI_SureToDeleteGame"), "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }

                
                //要删除的游戏id
                int gameID = int.Parse(this.listViewGameList.Items[selectIndex].Tag.ToString());
                //执行操作的返回结果
                C_Global.CEnum.Message_Body[,] resultMsgBody = null;
                //发送的信息
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.GameID;
                messageBody[1].oContent = gameID;


                resultMsgBody = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.GAME_DELETE, C_Global.CEnum.Msg_Category.GAME_ADMIN, messageBody);
                //检测状态
                if (resultMsgBody[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(resultMsgBody[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }

                if (resultMsgBody[0, 0].oContent.ToString().Trim().ToUpper().Equals("SUCESS"))
                {
                    InitializeListView();
                    //this.listViewGameList.Items[selectIndex].Remove();
                    MessageBox.Show(config.ReadConfigValue("MGM", "GL_UI_Succeed"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void ITC_EditGame_ITC_CLICIK(object sender)
        {
            this.EditGame();
        }

        private void ITC_DelGame_ITC_CLICIK(object sender)
        {
            this.DelGame();
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
            this.Text = config.ReadConfigValue("MGM", "GL_UI_Caption");

            this.ITC_NewGame.Text = config.ReadConfigValue("MGM", "GL_UI_ITC_NewGame");
            this.ITC_EditGame.Text = config.ReadConfigValue("MGM", "GL_UI_ITC_EditGame");

            this.ITC_DelGame.Text = config.ReadConfigValue("MGM", "GL_UI_ITC_DelGame");
            this.columnHeader3.Text = config.ReadConfigValue("MGM", "GL_UI_DG_ID");

            this.columnHeader1.Text = config.ReadConfigValue("MGM", "GL_UI_DG_GameName");
            this.columnHeader2.Text = config.ReadConfigValue("MGM", "GL_UI_DG_Description");

            this.menuItem1.Text = config.ReadConfigValue("MGM", "GL_UI_ITC_NewGame");
            this.menuItem3.Text = config.ReadConfigValue("MGM", "GL_UI_ITC_DelGame");
            this.menuItem6.Text = config.ReadConfigValue("MGM", "GL_UI_ITC_EditGame");

        }


        #endregion



    }
}
