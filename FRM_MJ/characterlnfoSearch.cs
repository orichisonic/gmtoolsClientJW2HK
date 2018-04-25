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
	/// characterlnfoSearch 的摘要说明。
	/// </summary>
    [C_Global.CModuleAttribute("猛将玩家搜索", "characterlnfoSearch", "猛将玩家搜索", "MJ Group")]
    public class characterlnfoSearch : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox searchContent;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox searchType;
        private Label label4;
        private ComboBox serverIP;
        private ListView listViewSortOrder;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
        private ColumnHeader columnHeader17;
        private ColumnHeader columnHeader18;
        private ColumnHeader columnHeader19;
        private ColumnHeader columnHeader20;
        private ColumnHeader columnHeader21;
        private ColumnHeader columnHeader22;
        private ColumnHeader columnHeader23;
        private DividerPanel.DividerPanel dividerPanel1;
        private DividerPanel.DividerPanel dividerPanel2;
        private DividerPanel.DividerPanel dividerPanel3;
        private IContainer components;

		public characterlnfoSearch()
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.searchContent = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.searchType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.serverIP = new System.Windows.Forms.ComboBox();
            this.listViewSortOrder = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader21 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader22 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader23 = new System.Windows.Forms.ColumnHeader();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.dividerPanel3 = new DividerPanel.DividerPanel();
            this.dividerPanel1.SuspendLayout();
            this.dividerPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "搜索类型：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "搜索内容：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // searchContent
            // 
            this.searchContent.Location = new System.Drawing.Point(81, 63);
            this.searchContent.Name = "searchContent";
            this.searchContent.Size = new System.Drawing.Size(174, 21);
            this.searchContent.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(262, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 4;
            this.button1.Text = "查找";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // searchType
            // 
            this.searchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchType.Items.AddRange(new object[] {
            "帐号",
            "角色名"});
            this.searchType.Location = new System.Drawing.Point(81, 36);
            this.searchType.Name = "searchType";
            this.searchType.Size = new System.Drawing.Size(174, 20);
            this.searchType.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "服务器：";
            // 
            // serverIP
            // 
            this.serverIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serverIP.FormattingEnabled = true;
            this.serverIP.Location = new System.Drawing.Point(81, 9);
            this.serverIP.Name = "serverIP";
            this.serverIP.Size = new System.Drawing.Size(175, 20);
            this.serverIP.TabIndex = 10;
            // 
            // listViewSortOrder
            // 
            this.listViewSortOrder.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewSortOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23});
            this.listViewSortOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSortOrder.FullRowSelect = true;
            this.listViewSortOrder.GridLines = true;
            this.listViewSortOrder.Location = new System.Drawing.Point(2, 2);
            this.listViewSortOrder.MultiSelect = false;
            this.listViewSortOrder.Name = "listViewSortOrder";
            this.listViewSortOrder.Size = new System.Drawing.Size(567, 255);
            this.listViewSortOrder.TabIndex = 8;
            this.listViewSortOrder.UseCompatibleStateImageBehavior = false;
            this.listViewSortOrder.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "编号";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "角色名称";
            this.columnHeader3.Width = 75;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "当前称号";
            this.columnHeader4.Width = 130;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "（国家）贡献值";
            this.columnHeader5.Width = 130;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "等级";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "金钱";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "经验值";
            this.columnHeader8.Width = 80;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "下一等级经验值";
            this.columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "生命值";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "生命值上限";
            this.columnHeader11.Width = 80;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "魔法值";
            this.columnHeader12.Width = 70;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "魔法值上限";
            this.columnHeader13.Width = 70;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "物理能力上限";
            this.columnHeader14.Width = 100;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "物理能力下限";
            this.columnHeader15.Width = 100;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "魔法能力上限";
            this.columnHeader16.Width = 100;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "魔法能力下限";
            this.columnHeader17.Width = 100;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "道术能力上限";
            this.columnHeader18.Width = 100;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "道术能力下限";
            this.columnHeader19.Width = 100;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "物防上限";
            this.columnHeader20.Width = 100;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "物防下限";
            this.columnHeader21.Width = 100;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "魔防上限";
            this.columnHeader22.Width = 100;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "魔防下限";
            this.columnHeader23.Width = 100;
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.label4);
            this.dividerPanel1.Controls.Add(this.label2);
            this.dividerPanel1.Controls.Add(this.serverIP);
            this.dividerPanel1.Controls.Add(this.searchContent);
            this.dividerPanel1.Controls.Add(this.button1);
            this.dividerPanel1.Controls.Add(this.searchType);
            this.dividerPanel1.Controls.Add(this.label1);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(571, 95);
            this.dividerPanel1.TabIndex = 12;
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 105);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(571, 10);
            this.dividerPanel2.TabIndex = 13;
            // 
            // dividerPanel3
            // 
            this.dividerPanel3.AllowDrop = true;
            this.dividerPanel3.Controls.Add(this.listViewSortOrder);
            this.dividerPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel3.Location = new System.Drawing.Point(10, 115);
            this.dividerPanel3.Name = "dividerPanel3";
            this.dividerPanel3.Padding = new System.Windows.Forms.Padding(2);
            this.dividerPanel3.Size = new System.Drawing.Size(571, 259);
            this.dividerPanel3.TabIndex = 14;
            // 
            // characterlnfoSearch
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(591, 384);
            this.Controls.Add(this.dividerPanel3);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "characterlnfoSearch";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "玩家信息检索";
            this.Load += new System.EventHandler(this.characterlnfoSearch_Load);
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
            lock (this)
            {
                try
                {
                    C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                    messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                    messageBody[0].eName = C_Global.CEnum.TagName.MJ_ServerIP;
                    messageBody[0].oContent = this._ServerIP;

                    messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                    messageBody[1].eName = C_Global.CEnum.TagName.MJ_Account;
                    messageBody[1].oContent = (this._searchType == "帐号") ? this._searchContent : "";

                    messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                    messageBody[2].eName = C_Global.CEnum.TagName.MJ_CharName;
                    messageBody[2].oContent = (this._searchType == "角色名") ? this._searchContent : "";

                    //发送接受数据
                    searchFrmResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.MJ_CHARACTERINFO_QUERY, C_Global.CEnum.Msg_Category.MJ_ADMIN, messageBody);

                    //检测状态
                    if (searchFrmResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                    {
                        this.Invoke(new EventHandler(WriteStatus));
                        MessageBox.Show(searchFrmResult[0, 0].oContent.ToString());
                        return;
                    }
                    //刷新列表
                    this.Invoke(new EventHandler(RefreshListContent));
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }

        }

        /// <summary>
        /// 标记模块状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void WriteStatus(object sender, System.EventArgs e)
        {
            this.button1.Enabled = true;
            Status.WriteStatusText(_parent, "完毕");
        }

        /// <summary>
        /// 刷新数据列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshListContent(object sender, System.EventArgs e)
        {
            try
            {
                //显示内容到列表
                string[] rowInfo = new string[22];

                for (int i = 0; i < searchFrmResult.GetLength(0); i++)
                {

                    //行号
                    rowInfo[0] = Convert.ToString(i + 1);
                    //MJ_CharIndex	
                    //rowInfo[1] = mResult[i, 0].oContent.ToString();
                    //MJ_CharName
                    rowInfo[1] = searchFrmResult[i, 1].oContent.ToString();
                    //MJ_CharName_Prefix
                    rowInfo[2] = searchFrmResult[i, 2].oContent.ToString();
                    //MJ_Exploit_Value
                    rowInfo[3] = searchFrmResult[i, 3].oContent.ToString();
                    //MJ_Level
                    rowInfo[4] = searchFrmResult[i, 4].oContent.ToString();
                    //MJ_Money
                    rowInfo[5] = searchFrmResult[i, 5].oContent.ToString();
                    //MJ_Exp
                    rowInfo[6] = searchFrmResult[i, 6].oContent.ToString();
                    //MJ_Exp_Next_Level
                    rowInfo[7] = searchFrmResult[i, 7].oContent.ToString();
                    //MJ_HP
                    rowInfo[8] = searchFrmResult[i, 8].oContent.ToString();
                    //MJ_HP_Max
                    rowInfo[9] = searchFrmResult[i, 9].oContent.ToString();
                    //MJ_MP
                    rowInfo[10] = searchFrmResult[i, 10].oContent.ToString();
                    //MJ_MP_Max
                    rowInfo[11] = searchFrmResult[i, 11].oContent.ToString();
                    //MJ_Physical_Ability_Max
                    rowInfo[12] = searchFrmResult[i, 12].oContent.ToString();
                    //MJ_Physical_Ability_Min
                    rowInfo[13] = searchFrmResult[i, 13].oContent.ToString();
                    //MJ_Magic_Ability_Max
                    rowInfo[14] = searchFrmResult[i, 14].oContent.ToString();
                    //MJ_Magic_Ability_Min
                    rowInfo[15] = searchFrmResult[i, 15].oContent.ToString();
                    //MJ_Tao_Ability_Max
                    rowInfo[16] = searchFrmResult[i, 16].oContent.ToString();
                    //MJ_Tao_Ability_Min
                    rowInfo[17] = searchFrmResult[i, 17].oContent.ToString();
                    //MJ_Physical_Defend_Max
                    rowInfo[18] = searchFrmResult[i, 18].oContent.ToString();
                    //MJ_Physical_Defend_Min
                    rowInfo[19] = searchFrmResult[i, 19].oContent.ToString();
                    //MJ_Magic_Defend_Max
                    rowInfo[20] = searchFrmResult[i, 20].oContent.ToString();
                    //MJ_Magic_Defend_Min
                    rowInfo[21] = searchFrmResult[i, 21].oContent.ToString();

                    mlistViewItem = new ListViewItem(rowInfo, -1);
                    //this.Invoke(new EventHandler(RefreshListContent));
                    this.listViewSortOrder.Items.Add(mlistViewItem);
                    this.listViewSortOrder.Items[i].Tag = searchFrmResult[i, 0].oContent.ToString();

                }
                this.button1.Enabled = true;
                Status.WriteStatusText(_parent, "完毕");
            }
            catch
            {
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

        private string _ServerIP = null;
        private string _searchContent = null;
        private string _searchType = null;

        private Form _parent = null;

        private ListViewItem mlistViewItem = null;
        #endregion

        #region 事件
        private void button1_Click(object sender, EventArgs e)
        {
            #region 检测
            if (this.serverIP.Text == "" || this.serverIP.Text == null)
            {
                MessageBox.Show("请选择搜索区域");
                return;
            }
            if (this.searchType.Text == "" || this.searchType.Text == null)
            {
                MessageBox.Show("请选择搜索类型");
                return;
            }
            if (this.searchContent.Text == "" || this.searchContent.Text == null)
            {
                MessageBox.Show("请输入搜索内容");
                return;
            }
            #endregion


            this.listViewSortOrder.Items.Clear();
            this.button1.Enabled = false;

            Status.WriteStatusText(_parent, "正在检索玩家" + searchContent.Text + "的信息,请等待...");

            #region 查询ｉｐ
            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.serverIP.Text.Trim()))
                {
                    this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion
            this._searchType = this.searchType.Text.Trim();
            this._searchContent = this.searchContent.Text.Trim();

            Thread thread1 = new Thread(new ThreadStart(InitializeListView));
            thread1.Start();

        }

        private void characterlnfoSearch_Load(object sender, EventArgs e)
        {
            InitializeServerIP();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
