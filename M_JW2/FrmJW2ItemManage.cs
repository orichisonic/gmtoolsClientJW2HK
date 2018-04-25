using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;

using System.Threading;
using C_Controls.LabelTextBox;
using C_Global;
using C_Event;
using Language;

using System.IO;
using System.Globalization;
namespace M_JW2
{
    [C_Global.CModuleAttribute("用户信息查询", "FrmJW2ItemManage", "用户信息查询", "JW2 Group")]
    public partial class FrmJW2ItemManage : Form
    {
        #region 变量

        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;

        private int iPageCount = 0;//翻页页数
        private static int index = 0;
        int userID = 0;
        string serverIP = null;
        string userName = null;
        string userNick = null;
        int selectChar = 0;   //GrdCharacter中当前选中的行 
        int selectChar2 = 0;
        int selectItem = 0;
        private int currDgSelectRow;
        private int uid;
        string itemID = null;
        bool pageRoleView = false;
        string userGMoney = null;
        private delegate void FillGridDelegate(string[] reader);
        private bool pageItemManage = false;
        Hashtable hItemList = new Hashtable();
        private string batchAddItem = null;
        private bool pageItemManage2 = false;
        private string userSex=null;
        #endregion

        public FrmJW2ItemManage()
        {
            InitializeComponent();
        }

        #region 创建类库中的窗体
        /// <summary>
        /// 创建类库中的窗体
        /// </summary>
        /// <param name="oParent">MDI 程序的父窗体</param>
        /// <param name="oSocket">Socket</param>
        /// <returns>类库中的窗体</returns>
        public Form CreateModule(object oParent, object oEvent)
        {
            //创建登录窗体
            FrmJW2ItemManage mModuleFrm = new FrmJW2ItemManage();
            mModuleFrm.m_ClientEvent = (CSocketEvent)oEvent;
            if (oParent != null)
            {
                mModuleFrm.MdiParent = (Form)oParent;
                mModuleFrm.Show();
            }
            else
            {
                mModuleFrm.ShowDialog();
            }

            return mModuleFrm;
        }
        #endregion

        #region 初始化语言库
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
            this.GrpSearch.Text = config.ReadConfigValue("MSD", "UIC_UI_GrpSearch");
            this.lblServer.Text = config.ReadConfigValue("MSD", "UIC_UI_lblServer");
            this.lblAccount.Text = config.ReadConfigValue("MSD", "UIC_UI_lblAccount");
            this.lblNick.Text = config.ReadConfigValue("MSD", "UIC_UI_lblNick");
            this.btnSearch.Text = config.ReadConfigValue("MSD", "UIC_UI_btnSearch");
            this.btnClose.Text = config.ReadConfigValue("MSD", "UIC_UI_btnClose");


            this.label11.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2ItemManageTip1");
            this.label12.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2ItemManageTip2");
            //this.tpgCharacter.Text = config.ReadConfigValue("MSD", "UIC_UI_tpgCharacter");
            //this.lblStoryState.Text = config.ReadConfigValue("MSD", "UIC_UI_lblPage");
            lblFilePath.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2ItemManagelblFilePath");

            this.tpgCharacter.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmBugleSendLogtpgCharacter");

            this.tpgCoupleInfo.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2ItemManagetpgItemManage");
            this.tpgCoupleLog.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2ItemManagetpgGManage");
            this.tabPage1.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2ItemManageAddItem");


            label10.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2ItemManageQueryType");

            lblRoleView.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            lblHomeItemInfo.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            label1.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2ItemManagePlayerAccount");

            label2.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2ItemManageGNumber");

            label3.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2ItemManageNewGNumber");

            button1.Text = config.ReadConfigValue("MJW2", "NEW_UI_Commit");

            button2.Text = config.ReadConfigValue("MJW2", "NEW_UI_Cancel");

            label4.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2ItemManagePlayerAccount");
            label13.Text = config.ReadConfigValue("MJW2", "NEW_UI_ClothesSex");

            button5.Text = config.ReadConfigValue("MJW2", "UIC_UI_btnSearch");

            label6.Text = config.ReadConfigValue("MJW2", "NEW_UI_ItemNum");

            label8.Text = config.ReadConfigValue("MJW2", "NEW_UI_MailTitle");


            label9.Text = config.ReadConfigValue("MJW2", "NEW_UI_MailContent");

            label7.Text = config.ReadConfigValue("MJW2", "NEW_UI_MailList");

            button7.Text = config.ReadConfigValue("MJW2", "NEW_UI_Reset");
            tbcResult.Enabled = true;
        }
        #endregion



        #region 登陆窗体加载(得到游戏服务器列表)
        private void FrmJW2ItemManage_Load(object sender, EventArgs e)
        {
            try
            {
                IntiFontLib();
                //增加listview数据源属性
                listViewAddItem.FullRowSelect = true;//要选择就是一行   
                listViewAddItem.View = View.Details;//定义列表显示的方式  
                listViewAddItem.Scrollable = true;//需要时候显示滚动条  
                listViewAddItem.MultiSelect = false; // 不可以多行选择   
                listViewAddItem.HeaderStyle = ColumnHeaderStyle.Clickable;
                listViewAddItem.Visible = true;//lstView可见  

                //增加listview数据目的地属性
                listView1.FullRowSelect = true;//要选择就是一行   
                listView1.View = View.Details;//定义列表显示的方式  
                listView1.Scrollable = true;//需要时候显示滚动条  
                listView1.MultiSelect = false; // 不可以多行选择   
                listView1.HeaderStyle = ColumnHeaderStyle.Clickable;
                listView1.Visible = true;//lstView可见  

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
                mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = 1;

                mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = m_ClientEvent.GetInfo("GameID_JW2");



                this.backgroundWorkerFormLoad.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 加载游戏服务器列表backgroundWorker消息发送
        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mServerInfo = Operation_JW2.GetServerList(this.m_ClientEvent, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 加载游戏服务器列表backgroundWorker消息接收
        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmbServer = Operation_JW2.BuildCombox(mServerInfo, cmbServer);
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text));
        }
        #endregion

        #region
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                this.tbcResult.SelectedIndex = 0;
                this.pageRoleView = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

                mContent[1].eName = CEnum.TagName.JW2_ServerName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = cmbServer.Text.ToString();

                mContent[2].eName = CEnum.TagName.JW2_ACCOUNT;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.txtAccount.Text.ToString();


                mContent[3].eName = CEnum.TagName.JW2_UserNick;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = txtNick.Text.ToString();

                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = 1;

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_JW2.iPageSize;

                backgroundWorkerSearch.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region
        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_ACCOUNT_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态

                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdRoleView, out iPageCount);

                if (iPageCount <= 1)
                {
                    this.pnlRoleView.Visible = false;
                }
                else
                {
                    for (int i = 0; i < iPageCount; i++)
                    {
                        this.cmbRoleView.Items.Add(i + 1);
                    }

                    this.cmbRoleView.SelectedIndex = 0;
                    this.pageRoleView = true;
                    this.pnlRoleView.Visible = true;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region
        private void cmbRoleView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(pageRoleView)
            {
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态
              
                this.pageRoleView = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

                mContent[1].eName = CEnum.TagName.JW2_ServerName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = cmbServer.Text.ToString();

                mContent[2].eName = CEnum.TagName.JW2_ACCOUNT;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.txtAccount.Text.ToString();


                mContent[3].eName = CEnum.TagName.JW2_UserNick;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = txtNick.Text.ToString();

                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = int.Parse(this.cmbRoleView.Text.ToString());

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_JW2.iPageSize;

                this.backgroundWorkerReSearch.RunWorkerAsync(mContent);
            }
        }
        #endregion

        #region
        private void backgroundWorkerReSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_ACCOUNT_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
        private void backgroundWorkerReSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态

                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdRoleView, out iPageCount);

                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region
        private void GrdRoleView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectChar = e.RowIndex;
            this.tbcResult.SelectedIndex = 1;
        }
        #endregion

        #region
        private void tbcResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                this.cmbQueryType.Items.Clear();
                this.cmbQueryType.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_Body"));
                this.cmbQueryType.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_ItemList"));
                this.cmbQueryType.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_PresentList"));
                this.cmbQueryType.SelectedIndex = 0;

                //this.comboBox1.Items.Clear();
                //this.comboBox1.Items.Add("男裝");
                //this.comboBox1.Items.Add("女裝");
                //this.comboBox1.Items.Add("通用裝");
                //this.comboBox1.SelectedIndex = 0;
                if (GrdRoleView.DataSource != null)
                {
                    DataTable mTable = (DataTable)GrdRoleView.DataSource;
                    serverIP = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);
                    userID = int.Parse(mTable.Rows[selectChar][config.ReadConfigValue("GLOBAL", "JW2_UserSN")].ToString());//保存玩家帳號ID
                    userName = mTable.Rows[selectChar][config.ReadConfigValue("GLOBAL", "JW2_UserID")].ToString();
                    userGMoney = mTable.Rows[selectChar][8].ToString();
                    userSex = mTable.Rows[selectChar][3].ToString();
                    if (this.userSex == config.ReadConfigValue("MJW2", "NEW_UI_Man"))
                    {
                        this.comboBox1.Items.Clear();
                        this.comboBox1.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_ManClothes"));
                        //this.comboBox1.Items.Add("女裝");
                        this.comboBox1.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_NormalClothes"));
                        this.comboBox1.SelectedIndex = 0;
                    }
                    else if (this.userSex == config.ReadConfigValue("MJW2", "NEW_UI_WoMan"))
                    {
                        this.comboBox1.Items.Clear();
                        //this.comboBox1.Items.Add("男裝");
                        this.comboBox1.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_WoManClothes"));
                        this.comboBox1.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_NormalClothes"));
                        this.comboBox1.SelectedIndex = 0;
                    }

                    if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2ItemManagetpgItemManage")))
                    {
                        ItemManage();//查詢道具管理
                    }
                    else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2ItemManageGNumber")))
                    {
                        textBox1.Text = userName;
                        textBox2.Text = userGMoney;

                    }
                    else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2ItemManageAddItem")))
                    {

                        textBox4.Text = userName;
                        comboBox2.Items.Clear();
                        comboBox2.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_QueryByItemName"));
                        comboBox2.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_QueryByItemId"));
                        comboBox2.SelectedIndex = 0;
                    }

                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
        #endregion

        #region
        private void GrdRoleView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currDgSelectRow = int.Parse(e.RowIndex.ToString());//保存列
        }
        #endregion

        #region
        private void ItemManage()
        {
            try
            {

                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态
      
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = serverIP;

                mContent[1].eName = CEnum.TagName.JW2_UserSN;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = userID;

                mContent[2].eName = CEnum.TagName.JW2_UserID;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = userName;

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_JW2.iPageSize;

                if (this.cmbQueryType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_Body"))
                {
                    mContent[5].eName = CEnum.TagName.JW2_ItemPos;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = 0;
                }
                else if (this.cmbQueryType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_ItemList"))
                {
                    mContent[5].eName = CEnum.TagName.JW2_ItemPos;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = 1;

                }
                else if (this.cmbQueryType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_PresentList"))
                {
                    mContent[5].eName = CEnum.TagName.JW2_ItemPos;
                    mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[5].oContent = 2;

                }


                this.backgroundWorkerItemManage.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.textBox7.Text.Trim() == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MMagic", "AI_Hint_inputName"));
                    return;
                }
                if (this.listView1.Items.Count == 0)
                {
                    MessageBox.Show(config.ReadConfigValue("MMagic", "AI_Hint_AddItem"));
                    return;
                }
                if (this.txtUnBindReason.Text.Trim() == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MMagic", "AI_Hint_contentNull"));
                    return;
                }
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, this.cmbServer.Text);

                mContent[1].eName = CEnum.TagName.JW2_ServerName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = this.cmbServer.Text.ToString();

                mContent[2].eName = CEnum.TagName.JW2_UserSN;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = userID;


                mContent[3].eName = CEnum.TagName.JW2_UserID;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = userName;

                mContent[4].eName = CEnum.TagName.UserByID;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());
              
                mContent[5].eName = CEnum.TagName.JW2_MailContent;
                mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[5].oContent = this.txtUnBindReason.Text.ToString();

                mContent[6].eName = CEnum.TagName.JW2_MailTitle;
                mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[6].oContent = this.textBox7.Text.ToString();
               
                mContent[7].eName = CEnum.TagName.JW2_AvatarItemName;
                mContent[7].eTag = CEnum.TagFormat.TLV_STRING;

                foreach (DictionaryEntry dEnum in hItemList)
                {
                    mContent[7].oContent += dEnum.Key.ToString()+",";
                    mContent[7].oContent += dEnum.Value.ToString();
                    mContent[7].oContent += "|";
                }

            this.backgroundWorkerAddItem.RunWorkerAsync(mContent);
          
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region
        private void backgroundWorkerItemManage_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_ItemInfo_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
        private void backgroundWorkerItemManage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
                this.GrdItemManage.DataSource = null;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdItemManage, out iPageCount);

                    for (int i = 0; i < iPageCount; i++)
                    {
                        this.cmbItemManage.Items.Add(i + 1);
                    }

                    this.cmbItemManage.SelectedIndex = 0;
                    this.pageItemManage = true;
               
                    this.pnlItemManage.Visible = true;
        
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region
        private void backgroundWorkerAddGMoney_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_MODIFY_MONEY, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
        private void backgroundWorkerAddGMoney_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    //Operation_JW2.errLog.WriteLog("添加G币成功");
                    return;
                }
                else if (mResult[0, 0].oContent.ToString() == "SCUESS")
                {
                    MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_AddGMoneySuccess"));
                    //Operation_JW2.errLog.WriteLog("添加G币成功");

                    return;
                }
                else
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                btnSearch_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region
        private void backgroundWorkerQueryItemList_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_ITEM_SELECT, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
        private void backgroundWorkerQueryItemList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态

                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                for (int i = mResult.GetLength(0) - 1; i >= 0; i--)
                {
                    index++;
                    string[] ListResult ={
                                            mResult[i,0].oContent.ToString(),
                                            mResult[i,1].oContent.ToString(),
                                            mResult[i,2].oContent.ToString(),
                                            mResult[i,3].oContent.ToString(),
                                           
                                            };
                    ThreadPool.QueueUserWorkItem(new WaitCallback(RealTimeProcessing), ListResult);
                    Thread.Sleep(20);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion
        #region 处理方法
        private void RealTimeProcessing(object state)
        {
            try
            {
                FillGridDelegate del = new FillGridDelegate(Test);
                this.Invoke(del, state);
                Thread.Sleep(20);
                //Operation_Audition.BuildDataTable(this.m_ClientEvent, mResult, this.dataGridView1, out iPageCount);
            }
            catch (Exception ex)
            { }
        }
        private void Test(string[] reader)
        {
            try
            {
                if (listView1.Items.Count >= 5000)
                {
                    listView1.Items.Clear();
                }
                ListViewItem aa = new ListViewItem(reader);
                this.listViewAddItem.Items.Insert(0, aa);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region
        private void backgroundWorkerAddItem_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_ADD_ITEM, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
        private void backgroundWorkerAddItem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                    streamWriter.Flush();
                    fs.Close();

                    //Operation_JW2.errLog.WriteLog(mResult[0, 0].oContent.ToString());
                    
                }
                else if (mResult[0, 0].oContent.ToString() == "SCUESS")
                {
                    MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_AddGMoneySuccess"));

                    FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                    streamWriter.Flush();
                    fs.Close();
                    //Operation_JW2.errLog.WriteLog("添加G币成功");
                  
                }
                else
                { 
                    MessageBox.Show(mResult[0, 0].oContent.ToString());

                    FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                    streamWriter.Flush();
                    fs.Close();
                    //Operation_JW2.errLog.WriteLog(mResult[0, 0].oContent.ToString());
                }

                this.btnSearch_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region
        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }
        #endregion

        #region
        private void cmbHomeItemInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
        
            if(pageItemManage)
            {

           
            this.GrpSearch.Enabled = false;
            this.tbcResult.Enabled = false;
            this.Cursor = Cursors.WaitCursor;//改变鼠标状态
  

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

            mContent[0].eName = CEnum.TagName.JW2_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = serverIP;

            mContent[1].eName = CEnum.TagName.JW2_UserSN;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = userID;

            mContent[2].eName = CEnum.TagName.JW2_UserID;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = userName;

            mContent[3].eName = CEnum.TagName.Index;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = int.Parse(this.cmbItemManage.Text.ToString());

            mContent[4].eName = CEnum.TagName.PageSize;
            mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[4].oContent = Operation_JW2.iPageSize;

            if (this.cmbQueryType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_Body"))
            {
                mContent[5].eName = CEnum.TagName.JW2_ItemPos;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = 0;
            }
            else if (this.cmbQueryType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_ItemList"))
            {
                mContent[5].eName = CEnum.TagName.JW2_ItemPos;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = 1;

            }
            else if (this.cmbQueryType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_PresentList"))
            {
                mContent[5].eName = CEnum.TagName.JW2_ItemPos;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = 2;

            }
            this.backgroundWorkerReItemManage.RunWorkerAsync(mContent);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.ToString());
    }


        }
        #endregion


        #region
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text.Trim().Length <= 0)
                {
                    MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_PleaseSelectRoleFirest"));


                    return;
                }
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, this.cmbServer.Text);

                mContent[1].eName = CEnum.TagName.JW2_ServerName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = this.cmbServer.Text.ToString();

                mContent[2].eName = CEnum.TagName.JW2_Money;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent =int.Parse(textBox3.Text.ToString());

                mContent[3].eName = CEnum.TagName.JW2_UserSN;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = userID;

                mContent[4].eName = CEnum.TagName.JW2_UserID;
                mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[4].oContent = userName;

                mContent[5].eName = CEnum.TagName.UserByID;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());
                this.backgroundWorkerAddGMoney.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region
        private void backgroundWorkerReItemManage_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_ItemInfo_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
        private void backgroundWorkerReItemManage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
                GrdItemManage.DataSource = null;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdItemManage, out iPageCount);

              
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region
        private void cmbQueryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (pageItemManage)
                {


                    this.GrpSearch.Enabled = false;
                    this.tbcResult.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                 
                    GrdItemManage.DataSource = null;
                
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                    mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = serverIP;

                    mContent[1].eName = CEnum.TagName.JW2_UserSN;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = userID;

                    mContent[2].eName = CEnum.TagName.JW2_UserID;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = userName;

                    mContent[3].eName = CEnum.TagName.Index;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(this.cmbItemManage.Text.ToString());

                    mContent[4].eName = CEnum.TagName.PageSize;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = Operation_JW2.iPageSize;
                    if (this.cmbQueryType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_Body"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_ItemPos;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 0;
                    }
                    else if (this.cmbQueryType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_ItemList"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_ItemPos;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 1;

                    }
                    else if (this.cmbQueryType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_PresentList"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_ItemPos;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 2;

                    }

                    this.backgroundWorkerReItemManage.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region
        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                this.listViewAddItem.Items.Clear();

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

            mContent[0].eName = CEnum.TagName.JW2_ItemName;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = this.textBox5.Text.ToString();


            mContent[1].eName = CEnum.TagName.Index;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = 1;

            mContent[2].eName = CEnum.TagName.PageSize;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = Operation_JW2.iPageSize;

            if (comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_ManClothes"))
            {

                mContent[3].eName = CEnum.TagName.JW2_GOODSTYPE;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = "M";

            }
            else if (comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_WoManClothes"))
            {


                mContent[3].eName = CEnum.TagName.JW2_GOODSTYPE;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = "F";

            }
            else if (comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_NormalClothes"))
            {

                mContent[3].eName = CEnum.TagName.JW2_GOODSTYPE;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = "B";

            }
            if (comboBox2.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_QueryByItemName"))
            {


                mContent[4].eName = CEnum.TagName.JW2_ItemPos;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = 0;
            }
            else if (comboBox2.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_QueryByItemId"))
            {
                mContent[4].eName = CEnum.TagName.JW2_ItemPos;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = 1;
            }


            backgroundWorkerQueryItemList.RunWorkerAsync(mContent);

        }
        catch (System.Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
        #endregion

        #region
    private void button3_Click(object sender, EventArgs e)
        {
            try
            {
          
                string[] ListResult ={
                                            listViewAddItem.SelectedItems[0].SubItems[0].Text,
                                           listViewAddItem.SelectedItems[0].SubItems[1].Text,
                                       
                                            textBox6.Text
                                           
                                            };

                
                bool isEXIT = true;
                
                foreach (DictionaryEntry dEnum in hItemList)
                { 
                    if(dEnum.Key.ToString().Equals(listViewAddItem.SelectedItems[0].SubItems[0].Text))
                    {
                        MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_ItemHasBeenAdded"));
                        isEXIT = false;
                        break;
                    }
                }
                if (isEXIT==true)
                {
                    hItemList.Add(listViewAddItem.SelectedItems[0].SubItems[0].Text, textBox6.Text);
                    ListViewItem aa = new ListViewItem(ListResult);
                    this.listView1.Items.Insert(0, aa);
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            
            }
        }
    #endregion

        #region
        private void button7_Click(object sender, EventArgs e)
        {
            this.textBox7.Text = "";
            this.txtUnBindReason.Text = "";
            this.textBox6.Text = "1";
            this.textBox5.Text = "";
        }
        #endregion

        #region
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Selected)
                    {
                        listView1.BeginUpdate();
                        hItemList.Remove(listView1.SelectedItems[0].Text);
                        listView1.Items.Remove(listView1.SelectedItems[0]);
                        listView1.EndUpdate();
                        return;
                    }
                }
                MessageBox.Show(config.ReadConfigValue("MMagic", "AI_Hint_deleteItem"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        #region 浏览.xls文件路径
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDlgBatch.Filter = "*.xls|*.*|所有文件|*.*";

            if (openFileDlgBatch.ShowDialog() == DialogResult.OK)
            {
                this.txtFilePath.Text = openFileDlgBatch.FileName;
            }
        }
        #endregion

        #region 批量添加道具
        private void btnBatchAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtFilePath.Text.Trim().Length <= 0)
                {
                    MessageBox.Show(config.ReadConfigValue("MMagic", "AI_Hint_HintFilePath"));
                    return;
                }

                batchAddItem = null;

                string Path = this.txtFilePath.Text;
                DataSet ds = null;
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();//打开connection对象
                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
                string strExcel = "";
                OleDbDataAdapter myCommand = null;//配置OLEDB适配器

                strExcel = "select * from [" + dt.Rows[0][2].ToString().Trim() + "]";
                myCommand = new OleDbDataAdapter(strExcel, strConn);//COMMAND对象
                ds = new DataSet();
                myCommand.Fill(ds, "counts");//填充DataSet

                for (int i = 0; i < ds.Tables["counts"].Rows.Count; i++)
                {
                    //新建DataRow行
                    //paramList.Add(ds.Tables[0].Rows[i].ItemArray[0].ToString().Trim());
                    batchAddItem += ds.Tables[0].Rows[i].ItemArray[0].ToString().Trim();
                    batchAddItem += ",";
                    batchAddItem += ds.Tables[0].Rows[i].ItemArray[1].ToString().Trim();
                    batchAddItem += ",";
                    batchAddItem += ds.Tables[0].Rows[i].ItemArray[2].ToString().Trim();
                    batchAddItem += "|";                   
                }
                if (batchAddItem.Length <= 0)
                {
                    MessageBox.Show(config.ReadConfigValue("MMagic", "AI_Error_FilePath"));
                    return;
                }
                if (this.textBox7.Text.Trim() == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MMagic", "AI_Hint_inputName"));
                    return;
                }
                if (this.txtUnBindReason.Text.Trim() == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MMagic", "AI_Hint_contentNull"));
                    return;
                }

                Cursor = Cursors.WaitCursor;
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, this.cmbServer.Text);

                mContent[1].eName = CEnum.TagName.JW2_AvatarItemName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = batchAddItem.Trim();

                mContent[2].eName = CEnum.TagName.UserByID;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent[3].eName = CEnum.TagName.JW2_ServerName;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = cmbServer.Text.Trim();

                mContent[4].eName = CEnum.TagName.JW2_MailContent;
                mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[4].oContent = this.txtUnBindReason.Text.ToString();

                mContent[5].eName = CEnum.TagName.JW2_MailTitle;
                mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[5].oContent = this.textBox7.Text.ToString();

                this.backgroundWorkerBatchAdd.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 批量添加道具backgroundWorker消息发送
        private void backgroundWorkerBatchAdd_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(tmp_ClientEvent, CEnum.ServiceKey.JW2_ADD_ITEM_ALL, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion


        #region 批量添加道具backgroundWorker消息接收
        private void backgroundWorkerBatchAdd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());

                    FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                    streamWriter.Flush();
                    fs.Close();
                    return;
                }
                else if (mResult[0, 0].oContent.ToString() == "SCUESS")
                {
                    MessageBox.Show(config.ReadConfigValue("MMagic", "NEW_UI_AddItemBatchSuccess"));

                    FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                    streamWriter.Flush();
                    fs.Close();

                    return;
                }
                else
                { 
                    MessageBox.Show(mResult[0, 0].oContent.ToString());

                    FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                    streamWriter.Flush();
                    fs.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region 双击道具管理删除道具
        private void GrdItemManage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_ConsumerDelItem"), config.ReadConfigValue("MJW2", "NEW_UI_ItemDel"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    this.GrpSearch.Enabled = false;
                    this.tbcResult.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                    DataTable mTable1 = (DataTable)GrdItemManage.DataSource;
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[9];

                    mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = serverIP;

                    mContent[1].eName = CEnum.TagName.JW2_UserSN;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = userID;

                    mContent[2].eName = CEnum.TagName.JW2_UserID;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = userName;

                    mContent[3].eName = CEnum.TagName.Index;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = 1;

                    mContent[4].eName = CEnum.TagName.PageSize;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = Operation_JW2.iPageSize;

                    if (this.cmbQueryType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_Body"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_ItemPos;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 0;
                    }
                    else if (this.cmbQueryType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_ItemList"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_ItemPos;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 1;

                    }
                    else if (this.cmbQueryType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_PresentList"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_ItemPos;
                        mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[5].oContent = 2;

                    }

                    mContent[6].eName = CEnum.TagName.UserByID;
                    mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[6].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    mContent[7].eName = CEnum.TagName.JW2_AvatarItemName;
                    mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[7].oContent = mTable1.Rows[selectChar2][2].ToString();

                    mContent[8].eName = CEnum.TagName.JW2_AvatarItem;
                    mContent[8].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[8].oContent = int.Parse(mTable1.Rows[selectChar2][1].ToString());

                    this.backgroundWorkerItemDel.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion


        #region backgroundworker删除道具发送消息
        private void backgroundWorkerItemDel_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_ITEM_DEL, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region backgroundworker删除道具接受消息
        private void backgroundWorkerItemDel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                    streamWriter.Flush();
                    fs.Close();
                    return;
                }
                else if (mResult[0, 0].oContent.ToString() == "SCUESS")
                {
                    MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_DelItemSuccess"));
                    FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                    streamWriter.Flush();
                    fs.Close();
                    return;
                }
                else
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());

                    FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                    streamWriter.Flush();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region 单击道具管理选择某一行数据
        private void GrdItemManage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectChar2 = e.RowIndex;
        }
        #endregion

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}