using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

using C_Global;
using C_Event;

namespace FRM_MJ
{
	/// <summary>
	/// userInfoOrder 的摘要说明。
	/// </summary>
    [C_Global.CModuleAttribute("猛将排名", "userInfoOrder", "猛将排名", "MJ Group")]
    public class userInfoOrder : System.Windows.Forms.Form
    {
		private System.Windows.Forms.Button search;
		private System.Windows.Forms.ComboBox orderType;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox userType;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListView listViewSortOrder;
		private System.Windows.Forms.ColumnHeader account;
		private System.Windows.Forms.ColumnHeader char_name;
		private System.Windows.Forms.ColumnHeader type_id;
		private System.Windows.Forms.ColumnHeader level;
		private System.Windows.Forms.ColumnHeader exp;
        private System.Windows.Forms.ColumnHeader money;
        private ColumnHeader id;
        private Label label3;
        private ComboBox serverIP;
        private DividerPanel.DividerPanel dividerPanel1;
        private DividerPanel.DividerPanel dividerPanel2;
        private DividerPanel.DividerPanel dividerPanel3;
        private IContainer components;

		public userInfoOrder()
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
            this.serverIP = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.Button();
            this.orderType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.userType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewSortOrder = new System.Windows.Forms.ListView();
            this.id = new System.Windows.Forms.ColumnHeader();
            this.account = new System.Windows.Forms.ColumnHeader();
            this.char_name = new System.Windows.Forms.ColumnHeader();
            this.type_id = new System.Windows.Forms.ColumnHeader();
            this.level = new System.Windows.Forms.ColumnHeader();
            this.exp = new System.Windows.Forms.ColumnHeader();
            this.money = new System.Windows.Forms.ColumnHeader();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.dividerPanel3 = new DividerPanel.DividerPanel();
            this.dividerPanel1.SuspendLayout();
            this.dividerPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // serverIP
            // 
            this.serverIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serverIP.FormattingEnabled = true;
            this.serverIP.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.serverIP.Location = new System.Drawing.Point(81, 10);
            this.serverIP.Name = "serverIP";
            this.serverIP.Size = new System.Drawing.Size(165, 20);
            this.serverIP.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "区域：";
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(261, 7);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(74, 23);
            this.search.TabIndex = 4;
            this.search.Text = "查看";
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // orderType
            // 
            this.orderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.orderType.Items.AddRange(new object[] {
            "金钱",
            "等级"});
            this.orderType.Location = new System.Drawing.Point(81, 55);
            this.orderType.Name = "orderType";
            this.orderType.Size = new System.Drawing.Size(165, 20);
            this.orderType.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "排名类型：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // userType
            // 
            this.userType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userType.Items.AddRange(new object[] {
            "所有职业",
            "战士",
            "法师",
            "道士"});
            this.userType.Location = new System.Drawing.Point(81, 33);
            this.userType.Name = "userType";
            this.userType.Size = new System.Drawing.Size(165, 20);
            this.userType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(34, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "角色：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listViewSortOrder
            // 
            this.listViewSortOrder.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewSortOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.account,
            this.char_name,
            this.type_id,
            this.level,
            this.exp,
            this.money});
            this.listViewSortOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSortOrder.FullRowSelect = true;
            this.listViewSortOrder.GridLines = true;
            this.listViewSortOrder.Location = new System.Drawing.Point(2, 2);
            this.listViewSortOrder.MultiSelect = false;
            this.listViewSortOrder.Name = "listViewSortOrder";
            this.listViewSortOrder.Size = new System.Drawing.Size(639, 210);
            this.listViewSortOrder.TabIndex = 7;
            this.listViewSortOrder.UseCompatibleStateImageBehavior = false;
            this.listViewSortOrder.View = System.Windows.Forms.View.Details;
            this.listViewSortOrder.SelectedIndexChanged += new System.EventHandler(this.listViewAcoount_SelectedIndexChanged);
            // 
            // id
            // 
            this.id.Text = "编号";
            this.id.Width = 49;
            // 
            // account
            // 
            this.account.Text = "帐号";
            // 
            // char_name
            // 
            this.char_name.Text = "角色名";
            this.char_name.Width = 105;
            // 
            // type_id
            // 
            this.type_id.Text = "角色";
            // 
            // level
            // 
            this.level.Text = "等级";
            // 
            // exp
            // 
            this.exp.Text = "经验值";
            // 
            // money
            // 
            this.money.Text = "金钱数";
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.serverIP);
            this.dividerPanel1.Controls.Add(this.label2);
            this.dividerPanel1.Controls.Add(this.label3);
            this.dividerPanel1.Controls.Add(this.label1);
            this.dividerPanel1.Controls.Add(this.search);
            this.dividerPanel1.Controls.Add(this.userType);
            this.dividerPanel1.Controls.Add(this.orderType);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(643, 85);
            this.dividerPanel1.TabIndex = 6;
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 95);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(643, 10);
            this.dividerPanel2.TabIndex = 7;
            // 
            // dividerPanel3
            // 
            this.dividerPanel3.AllowDrop = true;
            this.dividerPanel3.Controls.Add(this.listViewSortOrder);
            this.dividerPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel3.Location = new System.Drawing.Point(10, 105);
            this.dividerPanel3.Name = "dividerPanel3";
            this.dividerPanel3.Padding = new System.Windows.Forms.Padding(2);
            this.dividerPanel3.Size = new System.Drawing.Size(643, 214);
            this.dividerPanel3.TabIndex = 8;
            // 
            // userInfoOrder
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(663, 329);
            this.Controls.Add(this.dividerPanel3);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "userInfoOrder";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "排行榜";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.userInfoOrder_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel1.PerformLayout();
            this.dividerPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        #region 自定义函数
        /// <summary>
        /// 初始化游戏服务器列表
        /// </summary>
        public void InitializeServerIP()
        {
            try
            {
                this.serverIP.Items.Clear();

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
                    //Application.Exit();
                    return;
                }

                //显示内容到列表
                for (int i = 0; i < serverIPResult.GetLength(0); i++)
                {
                    this.serverIP.Items.Add(serverIPResult[i, 1].oContent.ToString());
                }
                //listViewAcoount = GMAdmin.DisplayView(m_ClientEvent, listViewAcoount, searchFrmResult,true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 读取数据，刷新列表
        /// </summary>
        public void InitializeListView()
        {
            try
            {
                //正式信息
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[1];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.MJ_ServerIP;
                messageBody[0].oContent = this._srhServerIP;

                searchFrmResult = m_ClientEvent.RequestResult(this._srhServiceKey, C_Global.CEnum.Msg_Category.MJ_ADMIN, messageBody);

                //检测状态
                if (searchFrmResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(searchFrmResult[0, 0].oContent.ToString());
                    this.Invoke(new EventHandler(WriteStatus));
                    return;
                }

                //刷新列表
                this.Invoke(new EventHandler(RefreshListContent));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 刷新列表内容
        /// </summary>
        private void RefreshListContent(object sender, System.EventArgs e)
        {
            try
            {
                //显示内容到列表
                string[] rowInfo = new string[7];
                for (int i = 0; i < searchFrmResult.GetLength(0); i++)
                {
                    //行编号
                    rowInfo[0] = Convert.ToString(i + 1);
                    //帐号	
                    rowInfo[1] = searchFrmResult[i, 0].oContent.ToString();
                    //昵称
                    rowInfo[2] = searchFrmResult[i, 1].oContent.ToString();
                    //角色
                    rowInfo[3] = GetUserType(int.Parse(searchFrmResult[i, 2].oContent.ToString()));
                    //等级
                    rowInfo[4] = searchFrmResult[i, 3].oContent.ToString();
                    //经验值
                    rowInfo[5] = searchFrmResult[i, 4].oContent.ToString();
                    //金钱数
                    rowInfo[6] = searchFrmResult[i, 5].oContent.ToString();
                    ListViewItem mlistViewItem = new ListViewItem(rowInfo, -1);
                    listViewSortOrder.Items.Add(mlistViewItem);
                    listViewSortOrder.Items[i].Tag = searchFrmResult[i, 0].oContent.ToString();
                }
                this.search.Enabled = true;
                Status.WriteStatusText(_parent, "完毕");
            }
            catch (Exception ex)
            {
                this.search.Enabled = true;
                Status.WriteStatusText(_parent, "完毕");
            }
        }

        public void WriteStatus(object sender, System.EventArgs e)
        {
            this.search.Enabled = true;
            Status.WriteStatusText(_parent, "完毕");
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
                _parent = (Form)oParent;
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


        private string _srhServerIP = null;
        private string _srhUserType = null;
        private string _srhOrderType = null;
        private C_Global.CEnum.ServiceKey _srhServiceKey = CEnum.ServiceKey.MJ_LEVELSORT_QUERY;

        private Form _parent = null;

        private bool threadFinish = true;
        private Thread thread1 = null;
        #endregion

        #region 自定义函数
        private string GetUserType(int typeID)
        {
            string returnValue = null;
            switch (typeID)
            {
                case 1:
                    returnValue = "男战士";
                    break;
                case 2:
                    returnValue = "女战士";
                    break;
                case 3:
                    returnValue = "男法师";
                    break;
                case 4:
                    returnValue = "女法师";
                    break;
                case 5:
                    returnValue = "男道士";
                    break;
                case 6:
                    returnValue = "女道士";
                    break;
            }
            return returnValue;
        }
        #endregion

        #region 事件
        private void WJToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listViewAcoount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void userInfoOrder_Load(object sender, EventArgs e)
        {
            InitializeServerIP();
        }

        private void search_Click(object sender, EventArgs e)
        {
            if (this.serverIP.Text == null || this.serverIP.Text == "")
            {
                MessageBox.Show("请选择要查看的区域");
                return;
            }

            if (this.userType.Text == null || this.userType.Text == "")
            {
                MessageBox.Show("请选择角色类型");
                return;
            }

            if (this.orderType.Text == null || this.orderType.Text == "")
            {
                MessageBox.Show("请选择排名类型");
                return;
            }

            //更新界面
            this.listViewSortOrder.Items.Clear();
            this.search.Enabled = false;
            Status.WriteStatusText(_parent, "正在读取\"" + this.serverIP.Text + this.userType.Text + this.orderType.Text + "\"排行榜数据,请等待...");


            _srhUserType = this.userType.Text.Trim();
            _srhOrderType = this.orderType.Text.Trim();

            #region 查询ｉｐ
            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.serverIP.Text.Trim()))
                {
                    this._srhServerIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion            

            #region 获取ServiceKey
            switch (_srhOrderType)
            {
                case "金钱":
                    switch (_srhUserType)
                    {
                        case "所有职业":
                            _srhServiceKey = CEnum.ServiceKey.MJ_MONEYSORT_QUERY;
                            break;
                        case "战士":
                            _srhServiceKey = CEnum.ServiceKey.MJ_MONEYFIGHTERSORT_QUERY;
                            break;
                        case "法师":
                            _srhServiceKey = CEnum.ServiceKey.MJ_MONEYRABBISORT_QUERY;
                            break;
                        case "道士":
                            _srhServiceKey = CEnum.ServiceKey.MJ_MONEYTAOISTSORT_QUERY;
                            break;
                    }
                    break;
                case "等级":
                    switch (_srhUserType)
                    {
                        case "所有职业":
                            _srhServiceKey = CEnum.ServiceKey.MJ_LEVELSORT_QUERY;
                            break;
                        case "战士":
                            _srhServiceKey = CEnum.ServiceKey.MJ_LEVELFIGHTERSORT_QUERY;
                            break;
                        case "法师":
                            _srhServiceKey = CEnum.ServiceKey.MJ_LEVELRABBISORT_QUERY;
                            break;
                        case "道士":
                            _srhServiceKey = CEnum.ServiceKey.MJ_LEVELTAOISTSORT_QUERY;
                            break;
                    }
                    break;
            }
            #endregion

            thread1 = new Thread(new ThreadStart(InitializeListView));
            thread1.Start();

        }
        #endregion

    }
}
