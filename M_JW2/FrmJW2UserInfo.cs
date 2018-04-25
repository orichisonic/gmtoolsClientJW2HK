using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using C_Controls.LabelTextBox;
using C_Global;
using C_Event;
using Language;
namespace M_JW2
{
    [C_Global.CModuleAttribute("用户信息查询", "FrmJW2UserInfo", "用户信息查询", "JW2 Group")]
    public partial class FrmJW2UserInfo : Form
    {
        #region 变量

        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;

        private int iPageCount = 0;//翻页页数

        int userID = 0;
        string serverIP = null;
        string userName = null;
        string userNick = null;
        int selectChar = 0;   //GrdCharacter中当前选中的行 
        int selectItem = 0;

        string itemID = null;
        bool pageRoleView = false;
        bool pageStoryState = false;
        bool pageBodyItem = false;
        bool pageHomeItem = false;
        bool pageBuyPresent = false;
        bool pageConsumerItemUser = false;
        bool pageBugleSendLog = false;
        bool pageUserFamilyInfo = false;
        bool pageInterItem = false;
        int getIndex = 1;
        #endregion

        public FrmJW2UserInfo()
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
            FrmJW2UserInfo mModuleFrm = new FrmJW2UserInfo();
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
            //this.tpgCharacter.Text = config.ReadConfigValue("MSD", "UIC_UI_tpgCharacter");
            //this.lblStoryState.Text = config.ReadConfigValue("MSD", "UIC_UI_lblPage");


            this.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2UserInfo");

            this.label1.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2UserInfoTip");

            this.tpgCharacter.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmBugleSendLogtpgCharacter");
            this.tpgStoryState.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgStoryState");
            this.tpgBodyInfo.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgBodyInfo");
            //this.tpgHomeItemInfo.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgHomeItemInfo");
            //this.tpgBuyPresentInfo.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgBuyPresentInfo");
            //this.tpgConsumerItemUser.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgConsumerItemUser");
            //this.tpgUserFamilyInfo.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgUserFamilyInfo");
            //this.tpgInterItem.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgInterItem");
            //this.tpgInterBodyItem.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgInterBodyItem");
            //this.tpgIntimacyNum.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgIntimacyNum");


            lblRoleView.Text=config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            lblStoryState.Text=config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            lblBodyItemInfo.Text=config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            //lblHomeItemInfo.Text=config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            //lblBuyPresentInfo.Text=config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            //lblComsumerItemUser.Text=config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            //lblUserFamilyInfo.Text=config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            //label3.Text=config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            //label4.Text=config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            //lblIntimacyNum.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");

            tbcResult.Enabled = true;
        }
        #endregion



        #region 登陆窗体加载(得到游戏服务器列表)
        private void FrmJW2UserInfo_Load(object sender, EventArgs e)
        {
            try
            {
                IntiFontLib();

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
                mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = 1;

                mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = m_ClientEvent.GetInfo("GameID_JW2");

                this.backgroundWorkerFormLoad.RunWorkerAsync(mContent);
                //this.tbcResult.TabPages.Remove(this.tpgIntimacyNum);
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



        #region 切换不同的游戏服务器
        private void cmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text));
        }
        #endregion

        private void tbcResult_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                if (GrdRoleView.DataSource != null)
                {
                    DataTable mTable = (DataTable)GrdRoleView.DataSource;
                    serverIP = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);
                    userID = int.Parse(mTable.Rows[selectChar][config.ReadConfigValue("GLOBAL", "JW2_UserSN")].ToString());//保存玩家帐号ID
                    userName = mTable.Rows[selectChar][config.ReadConfigValue("GLOBAL", "JW2_UserID")].ToString();
                    if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_tpgStoryState")))
                    {
                        StoryState();//查?故事劇情狀態
                    }
                    else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_tpgBodyInfo")))
                    {
                        this.GrdBodyItemInfo.DataSource = null;
                        BodyItemInfo();//查?身上道具資?
                    }
                    //else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_tpgHomeItemInfo")))
                    //{
                    //    this.GrdHomeItemInfo.DataSource = null;
                    //    HomeItemInfo();//查?家庭道具資?
                    //}
                    //else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_tpgBuyPresentInfo")))
                    //{
                    //    this.GrdBuyPresentInfo.DataSource = null;
                    //    BuyPresentLog();//查??物送禮??
                    //    cmbBuyPresentInfo.Items.Clear();
                    //}
                    //else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_tpgConsumerItemUser")))
                    //{
                    //    this.GrdConsumerItemUser.DataSource = null;
                    //    ConsumerItemUser();//查?消耗性道具使用
                    //}
                    //else if (tbcResult.SelectedTab.Text.Equals("小喇叭發送??"))
                    //{
                    //    //this.GrdBuglerSendLog.DataSource = null;
                    //    BugleSendLog();//小喇叭發送??
                    //}
                    //else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_tpgUserFamilyInfo")))
                    //{
                    //    this.GrdUserFamilyInfo.DataSource = null;
                    //    UserFamilyInfo();//用戶家族資?
                    //}
                    //else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_tpgInterItem")))
                    //{
                    //    this.GrdUserFamilyInfo.DataSource = null;
                    //    InterItem();//中間件背包道具
                    //}
                    //else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_tpgInterBodyItem")))
                    //{
                    //    this.GrdUserFamilyInfo.DataSource = null;
                    //    InterBodyItem();//中間件身上道具

                    //}

                }
                
                else
                {
                    GrdStoryState.DataSource = null;
                    pnlStoryState.Visible = false;

                    

                    //GrdBuglerSendLog.DataSource = null;
                    //pnlBugleSendLog.Visible = false;

                    //GrdUserFamilyInfo.DataSource = null;
                    //pnlUserFamilyInfo.Visible = false;

                    GrdBodyItemInfo.DataSource = null;
                    pnlBodyItemInfo.Visible = false;

                    //GrdHomeItemInfo.DataSource = null;
                    //pnlHomeItemInfo.Visible = false;

                    //GrdBuyPresentInfo.DataSource = null;
                    //pnlBuyPresentInfo.Visible = false;

                    //GrdConsumerItemUser.DataSource = null;
                    //pnlComsumerItemUser.Visible = false;


                 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #region 查询故事剧情状态
        private void StoryState()
        {
            try
            {

                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                //this.GrdMixItems.DataSource = null;

                //this.pnlMixItems.Visible = false;
                //this.cmbMixItems.Items.Clear();
                this.pageStoryState = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

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

                backgroundWorkerStoryState.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        #region 查询身上道具信息
        private void BodyItemInfo()
        {
            try
            {
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                this.GrdBodyItemInfo.DataSource = null;
                //this.GrdMixItems.DataSource = null;

                //this.pnlMixItems.Visible = false;
                //this.cmbMixItems.Items.Clear();
                this.pageBodyItem = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

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

                backgroundWorkerBodyItemInfo.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion



        #region 查询家庭道具信息
        private void HomeItemInfo()
        {
            try
            {
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                //this.GrdMixItems.DataSource = null;

                //this.pnlMixItems.Visible = false;
                //this.cmbMixItems.Items.Clear();
                this.pageHomeItem = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

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

                backgroundWorkerHomeItemInfo.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        #region 查询家庭道具信息
        private void BuyPresentLog()
        {
            //comboBox1.SelectedIndex = 0;
            pageBuyPresent = false;
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

            mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
            mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[5].oContent = 1;
            this.backgroundWorkerBuyPresentLog.RunWorkerAsync(mContent);
        }
        #endregion


        #region 查询家庭道具信息
        private void BugleSendLog()
        {
            try
            {
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                //this.GrdMixItems.DataSource = null;

                //this.pnlMixItems.Visible = false;
                //this.cmbMixItems.Items.Clear();
                this.pageBugleSendLog = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

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

                backgroundWorkerBugleSendLog.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 查询家庭道具信息
        private void ConsumerItemUser()
        {
            try
            {
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                //this.GrdMixItems.DataSource = null;

                //this.pnlMixItems.Visible = false;
                //this.cmbMixItems.Items.Clear();
                this.pageConsumerItemUser = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

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

                backgroundWorkerConsumerItemUser.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 查询中间件背包道具
        private void InterItem()
        {
            try
            {
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                //this.GrdMixItems.DataSource = null;

                //this.pnlMixItems.Visible = false;
                //this.cmbMixItems.Items.Clear();
                this.pageUserFamilyInfo = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

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

                this.backgroundWorkerInterIntem.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        #region 查询中间件身上道具
        private void InterBodyItem()
        {
            try
            {
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                //this.GrdMixItems.DataSource = null;

                //this.pnlMixItems.Visible = false;
                //this.cmbMixItems.Items.Clear();
                this.pageUserFamilyInfo = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

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

                this.backgroundWorkerInterBodyItem.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        private void UserFamilyInfo()
        {
            try
            {
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                //this.GrdMixItems.DataSource = null;

                //this.pnlMixItems.Visible = false;
                //this.cmbMixItems.Items.Clear();
                this.pageUserFamilyInfo = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

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

                backgroundWorkerUserFamilyInfo.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorkerStoryState_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(tmp_ClientEvent, CEnum.ServiceKey.JW2_RPG_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerStoryState_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdStoryState, out iPageCount);

                if (iPageCount <= 1)
                {
                    this.pnlStoryState.Visible = false;
                }
                else
                {
                    for (int i = 0; i < iPageCount; i++)
                    {
                        this.cmbStorySate.Items.Add(i + 1);
                    }

                    this.cmbStorySate.SelectedIndex = 0;
                    this.pageStoryState = true;
                    this.pnlStoryState.Visible = true;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorkerBodyItemInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_ITEMSHOP_BYOWNER_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerBodyItemInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdBodyItemInfo, out iPageCount);

                if (iPageCount <= 1)
                {
                    this.pnlBodyItemInfo.Visible = false;
                }
                else
                {
                    for (int i = 0; i < iPageCount; i++)
                    {
                        this.cmbBodyItemInfo.Items.Add(i + 1);
                    }

                    this.cmbBodyItemInfo.SelectedIndex = 0;
                    this.pageBodyItem = true;
                    this.pnlBodyItemInfo.Visible = true;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorkerHomeItemInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_HOME_ITEM_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerHomeItemInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //try
            //{
            //    //this.GrdHomeItemInfo.DataSource = null;
            //    this.GrpSearch.Enabled = true;
            //    this.tbcResult.Enabled = true;
            //    this.Cursor = Cursors.Default;//改变鼠标状态

            //    CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            //    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //    {
            //        MessageBox.Show(mResult[0, 0].oContent.ToString());
            //        return;
            //    }

            //    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdHomeItemInfo, out iPageCount);

            //    if (iPageCount <= 1)
            //    {
            //        this.pnlHomeItemInfo.Visible = false;
            //    }
            //    else
            //    {
            //        for (int i = 0; i < iPageCount; i++)
            //        {
            //            this.cmbHomeItemInfo.Items.Add(i + 1);
            //        }

            //        this.cmbHomeItemInfo.SelectedIndex = 0;
            //        this.pageHomeItem = true;
            //        this.pnlHomeItemInfo.Visible = true;
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void backgroundWorkerBuyPresentLog_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_SMALL_PRESENT_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerBuyPresentLog_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //try
            //{

            //    this.GrpSearch.Enabled = true;
            //    this.tbcResult.Enabled = true;
            //    this.Cursor = Cursors.Default;//改变鼠标状态

            //    CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            //    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //    {
            //        MessageBox.Show(mResult[0, 0].oContent.ToString());
            //        return;
            //    }

            //    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdBuyPresentInfo, out iPageCount);

            //    //if (iPageCount <= 1)
            //    //{
            //    //    this.pnlBuyPresentInfo.Visible = false;
            //    //}
            //    //else
            //    //{
            //        for (int i = 0; i < iPageCount; i++)
            //        {
            //            this.cmbBuyPresentInfo.Items.Add(i + 1);
            //        }

            //        this.cmbBuyPresentInfo.SelectedIndex = 0;
            //        this.pageBuyPresent = true;
            //        this.pnlBuyPresentInfo.Visible = true;
            //    //}
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void backgroundWorkerBugleSendLog_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_SMALL_BUGLE_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerBugleSendLog_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

                //Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdBuglerSendLog, out iPageCount);

                //if (iPageCount <= 1)
                //{
                //    this.pnlBugleSendLog.Visible = false;
                //}
                //else
                //{
                //    for (int i = 0; i < iPageCount; i++)
                //    {
                //        this.cmbBugleSendLog.Items.Add(i + 1);
                //    }

                //    this.cmbBugleSendLog.SelectedIndex = 0;
                //    this.pageBugleSendLog = true;
                //    this.pnlBugleSendLog.Visible = true;
                //}
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorkerConsumerItemUser_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_WASTE_ITEM_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerConsumerItemUser_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //try
            //{

            //    this.GrpSearch.Enabled = true;
            //    this.tbcResult.Enabled = true;
            //    this.Cursor = Cursors.Default;//改变鼠标状态

            //    CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            //    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //    {
            //        MessageBox.Show(mResult[0, 0].oContent.ToString());
            //        return;
            //    }

            //    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdConsumerItemUser, out iPageCount);

            //    if (iPageCount <= 1)
            //    {
            //        this.pnlComsumerItemUser.Visible = false;
            //    }
            //    else
            //    {
            //        for (int i = 0; i < iPageCount; i++)
            //        {
            //            this.cmbConsumerItemUser.Items.Add(i + 1);
            //        }

            //        this.cmbConsumerItemUser.SelectedIndex = 0;
            //        this.pageConsumerItemUser = true;
            //        this.pnlComsumerItemUser.Visible = true;
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void backgroundWorkerUserFamilyInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_User_Family_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerUserFamilyInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //try
            //{

            //    this.GrpSearch.Enabled = true;
            //    this.tbcResult.Enabled = true;
            //    this.Cursor = Cursors.Default;//改变鼠标状态

            //    CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            //    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //    {
            //        MessageBox.Show(mResult[0, 0].oContent.ToString());
            //        return;
            //    }

            //    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdUserFamilyInfo, out iPageCount);

            //    if (iPageCount <= 1)
            //    {
            //        this.pnlUserFamilyInfo.Visible = false;
            //    }
            //    else
            //    {
            //        for (int i = 0; i < iPageCount; i++)
            //        {
            //            this.cmbConsumerItemUser.Items.Add(i + 1);
            //        }

            //        this.cmbConsumerItemUser.SelectedIndex = 0;
            //        this.pageConsumerItemUser = true;
            //        this.pnlComsumerItemUser.Visible = true;
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void backgroundWorkerReStoryState_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_RPG_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReStoryState_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdStoryState, out iPageCount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());


            }
        }

        private void backgroundWorkerReBodyItemInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_ITEMSHOP_BYOWNER_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReBodyItemInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdBodyItemInfo, out iPageCount);
        }

        private void backgroundWorkerReHomeItemInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_HOME_ITEM_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReHomeItemInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //this.GrpSearch.Enabled = true;
            //this.tbcResult.Enabled = true;
            //this.Cursor = Cursors.Default;//改变鼠标状态

            //CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mResult[0, 0].oContent.ToString());
            //    return;
            //}

            //Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdHomeItemInfo, out iPageCount);
        }

        private void backgroundWorkerReBuyPresentLog_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(tmp_ClientEvent, CEnum.ServiceKey.JW2_SMALL_PRESENT_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReBuyPresentLog_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            //this.GrpSearch.Enabled = true;
            //this.tbcResult.Enabled = true;
            //this.Cursor = Cursors.Default;//改变鼠标状态

            //CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mResult[0, 0].oContent.ToString());
            //    return;
            //}

            //Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdBuyPresentInfo, out iPageCount);
        }

        private void backgroundWorkerReBugleSendLog_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_SMALL_BUGLE_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReBugleSendLog_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            //Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdBuglerSendLog, out iPageCount);
        }

        private void backgroundWorkerReConsumerItemUser_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_WASTE_ITEM_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReConsumerItemUser_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //this.GrpSearch.Enabled = true;
            //this.tbcResult.Enabled = true;
            //this.Cursor = Cursors.Default;//改变鼠标状态

            //CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mResult[0, 0].oContent.ToString());
            //    return;
            //}

            //Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdConsumerItemUser, out iPageCount);
        }

        private void backgroundWorkerReUserFamilyInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_FAMILYINFO_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReUserFamilyInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //this.GrpSearch.Enabled = true;
            //this.tbcResult.Enabled = true;
            //this.Cursor = Cursors.Default;//改变鼠标状态

            //CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mResult[0, 0].oContent.ToString());
            //    return;
            //}

            //Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdUserFamilyInfo, out iPageCount);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态
           
                this.pageStoryState = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

                mContent[1].eName = CEnum.TagName.JW2_ServerName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = cmbServer.Text.ToString();

                mContent[2].eName = CEnum.TagName.JW2_ACCOUNT;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.txtAccount.Text;


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

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_ACCOUNT_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
                this.tbcResult.SelectedIndex = 0;
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

        private void backgroundWorkerReSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_ACCOUNT_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

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

        private void cmbRoleView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageRoleView)
            {


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
                mContent[4].oContent = int.Parse(cmbRoleView.Text.ToString());

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_JW2.iPageSize;



                backgroundWorkerReSearch.RunWorkerAsync(mContent);
            }
        }

        private void GrdRoleView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.tbcResult.SelectedIndex = 1;
        }

        private void cmbStorySate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageStoryState)
            {


               

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

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
                mContent[3].oContent = int.Parse(cmbStorySate.Text.ToString());

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_JW2.iPageSize;

                backgroundWorkerReStoryState.RunWorkerAsync(mContent);
            }
        }

        private void cmbBodyItemInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageBodyItem)
            {


                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

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
                mContent[3].oContent = int.Parse(cmbBodyItemInfo.Text.ToString());

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_JW2.iPageSize;
                backgroundWorkerReBodyItemInfo.RunWorkerAsync(mContent);
            }
        }

        private void cmbHomeItemInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (pageHomeItem)
            //{


            //    CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

            //    mContent[0].eName = CEnum.TagName.JW2_ServerIP;
            //    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[0].oContent = serverIP;

            //    mContent[1].eName = CEnum.TagName.JW2_UserSN;
            //    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[1].oContent = userID;

            //    mContent[2].eName = CEnum.TagName.JW2_UserID;
            //    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[2].oContent = userName;

            //    mContent[3].eName = CEnum.TagName.Index;
            //    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[3].oContent = int.Parse(cmbHomeItemInfo.Text.ToString());

            //    mContent[4].eName = CEnum.TagName.PageSize;
            //    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[4].oContent = Operation_JW2.iPageSize;

            //    backgroundWorkerReHomeItemInfo.RunWorkerAsync(mContent);
            //}
        }

        private void cmbBuyPresentInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (pageBuyPresent)
            //{


            //    if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_UserMGPurchase"))
            //    {
            //        CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

            //        mContent[0].eName = CEnum.TagName.JW2_ServerIP;
            //        mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            //        mContent[0].oContent = serverIP;

            //        mContent[1].eName = CEnum.TagName.JW2_UserSN;
            //        mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            //        mContent[1].oContent = userID;

            //        mContent[2].eName = CEnum.TagName.JW2_UserID;
            //        mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            //        mContent[2].oContent = userName;

            //        mContent[3].eName = CEnum.TagName.Index;
            //        mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            //        mContent[3].oContent = int.Parse(cmbBuyPresentInfo.Text.ToString());

            //        mContent[4].eName = CEnum.TagName.PageSize;
            //        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            //        mContent[4].oContent = Operation_JW2.iPageSize;

            //        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
            //        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            //        mContent[5].oContent = 1;
            //        this.backgroundWorkerReBuyPresentLog.RunWorkerAsync(mContent);

            //    }
            //    else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_UserMPurchase"))
            //    {
            //        CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

            //        mContent[0].eName = CEnum.TagName.JW2_ServerIP;
            //        mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            //        mContent[0].oContent = serverIP;

            //        mContent[1].eName = CEnum.TagName.JW2_UserSN;
            //        mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            //        mContent[1].oContent = userID;

            //        mContent[2].eName = CEnum.TagName.JW2_UserID;
            //        mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            //        mContent[2].oContent = userName;

            //        mContent[3].eName = CEnum.TagName.Index;
            //        mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            //        mContent[3].oContent = int.Parse(cmbBuyPresentInfo.Text.ToString());

            //        mContent[4].eName = CEnum.TagName.PageSize;
            //        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            //        mContent[4].oContent = Operation_JW2.iPageSize;

            //        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
            //        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            //        mContent[5].oContent = 2;
            //        this.backgroundWorkerReBuyPresentLog.RunWorkerAsync(mContent);
            //    }

            //    else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_UserGPurchase"))
            //    {
            //        CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

            //        mContent[0].eName = CEnum.TagName.JW2_ServerIP;
            //        mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            //        mContent[0].oContent = serverIP;

            //        mContent[1].eName = CEnum.TagName.JW2_UserSN;
            //        mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            //        mContent[1].oContent = userID;

            //        mContent[2].eName = CEnum.TagName.JW2_UserID;
            //        mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            //        mContent[2].oContent = userName;

            //        mContent[3].eName = CEnum.TagName.Index;
            //        mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            //        mContent[3].oContent = int.Parse(cmbBuyPresentInfo.Text.ToString());

            //        mContent[4].eName = CEnum.TagName.PageSize;
            //        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            //        mContent[4].oContent = Operation_JW2.iPageSize;

            //        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
            //        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            //        mContent[5].oContent = 3;
            //        this.backgroundWorkerReBuyPresentLog.RunWorkerAsync(mContent);
            //    }

            //}
        }

        private void cmbConsumerItemUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (pageConsumerItemUser)
            //{


            //    CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];
            //    mContent[0].eName = CEnum.TagName.JW2_ServerIP;
            //    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[0].oContent = serverIP;

            //    mContent[1].eName = CEnum.TagName.JW2_UserSN;
            //    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[1].oContent = userID;

            //    mContent[2].eName = CEnum.TagName.JW2_UserID;
            //    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[2].oContent = userName;

            //    mContent[3].eName = CEnum.TagName.Index;
            //    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[3].oContent = int.Parse(cmbConsumerItemUser.Text.ToString());

            //    mContent[4].eName = CEnum.TagName.PageSize;
            //    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[4].oContent = Operation_JW2.iPageSize;
            //    backgroundWorkerReConsumerItemUser.RunWorkerAsync(mContent);
            //}
        }

        private void cmbBugleSendLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageBugleSendLog)
            {


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
                //mContent[3].oContent = int.Parse(cmbBugleSendLog.Text.ToString());

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_JW2.iPageSize;

                backgroundWorkerReBugleSendLog.RunWorkerAsync(mContent);
            }
        }

        private void cmbUserFamilyInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (pageUserFamilyInfo)
            //{


            //    CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

            //    mContent[0].eName = CEnum.TagName.JW2_ServerIP;
            //    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[0].oContent = serverIP;

            //    mContent[1].eName = CEnum.TagName.JW2_UserSN;
            //    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[1].oContent = userID;

            //    mContent[2].eName = CEnum.TagName.JW2_UserID;
            //    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[2].oContent = userName;

            //    mContent[3].eName = CEnum.TagName.Index;
            //    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[3].oContent = int.Parse(cmbUserFamilyInfo.Text.ToString());

            //    mContent[4].eName = CEnum.TagName.PageSize;
            //    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[4].oContent = Operation_JW2.iPageSize;

            //    backgroundWorkerReUserFamilyInfo.RunWorkerAsync(mContent);
            //}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //try
            //{
            //    if (pageBuyPresent)
            //    {


            //        if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_UserMGPurchase"))
            //        {
            //            CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

            //            mContent[0].eName = CEnum.TagName.JW2_ServerIP;
            //            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            //            mContent[0].oContent = serverIP;

            //            mContent[1].eName = CEnum.TagName.JW2_UserSN;
            //            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            //            mContent[1].oContent = userID;

            //            mContent[2].eName = CEnum.TagName.JW2_UserID;
            //            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            //            mContent[2].oContent = userName;

            //            mContent[3].eName = CEnum.TagName.Index;
            //            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            //            mContent[3].oContent = 1;

            //            mContent[4].eName = CEnum.TagName.PageSize;
            //            mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            //            mContent[4].oContent = Operation_JW2.iPageSize;

            //            mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
            //            mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            //            mContent[5].oContent = 1;
            //            this.backgroundWorkerBuyPresentLog.RunWorkerAsync(mContent);

            //        }
            //        else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_UserMPurchase"))
            //        {
            //            CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

            //            mContent[0].eName = CEnum.TagName.JW2_ServerIP;
            //            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            //            mContent[0].oContent = serverIP;

            //            mContent[1].eName = CEnum.TagName.JW2_UserSN;
            //            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            //            mContent[1].oContent = userID;

            //            mContent[2].eName = CEnum.TagName.JW2_UserID;
            //            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            //            mContent[2].oContent = userName;

            //            mContent[3].eName = CEnum.TagName.Index;
            //            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            //            mContent[3].oContent = 1;

            //            mContent[4].eName = CEnum.TagName.PageSize;
            //            mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            //            mContent[4].oContent = Operation_JW2.iPageSize;

            //            mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
            //            mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            //            mContent[5].oContent = 2;
            //            this.backgroundWorkerBuyPresentLog.RunWorkerAsync(mContent);
            //        }

            //        else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_UserGPurchase"))
            //        {
            //            CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

            //            mContent[0].eName = CEnum.TagName.JW2_ServerIP;
            //            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            //            mContent[0].oContent = serverIP;

            //            mContent[1].eName = CEnum.TagName.JW2_UserSN;
            //            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            //            mContent[1].oContent = userID;

            //            mContent[2].eName = CEnum.TagName.JW2_UserID;
            //            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            //            mContent[2].oContent = userName;

            //            mContent[3].eName = CEnum.TagName.Index;
            //            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            //            mContent[3].oContent = 1;

            //            mContent[4].eName = CEnum.TagName.PageSize;
            //            mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            //            mContent[4].oContent = Operation_JW2.iPageSize;

            //            mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
            //            mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            //            mContent[5].oContent = 3;
            //            this.backgroundWorkerBuyPresentLog.RunWorkerAsync(mContent);
            //        }
            //    }
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}

        }

        private void backgroundWorkerInterIntem_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_CenterAvAtarItem_Bag_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerInterIntem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //try
            //{

            //    this.GrpSearch.Enabled = true;
            //    this.tbcResult.Enabled = true;
            //    this.Cursor = Cursors.Default;//改变鼠标状态
            //    this.tbcResult.SelectedIndex = 8;
            //    CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            //    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //    {
            //        MessageBox.Show(mResult[0, 0].oContent.ToString());
            //        return;
            //    }

            //    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdInterItem, out iPageCount);

            //    if (iPageCount <= 1)
            //    {
            //        this.pnlInterItem.Visible = false;
            //    }
            //    else
            //    {
            //        for (int i = 0; i < iPageCount; i++)
            //        {
            //            this.cmbInterItem.Items.Add(i + 1);
            //        }

            //        this.cmbInterItem.SelectedIndex = 0;
            //        this.pageInterItem = true;
            //        this.pnlInterItem.Visible = true;
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void backgroundWorkerReInterIntem_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_CenterAvAtarItem_Bag_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReInterIntem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //try
            //{

            //    this.GrpSearch.Enabled = true;
            //    this.tbcResult.Enabled = true;
            //    this.Cursor = Cursors.Default;//改变鼠标状态
           
            //    CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            //    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //    {
            //        MessageBox.Show(mResult[0, 0].oContent.ToString());
            //        return;
            //    }

            //    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdInterItem, out iPageCount);

             
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void cmbInterItem_SelectedIndexChanged(object sender, EventArgs e)
        {
           //backgroundWorkerInterIntem

            //if (this.pageInterItem)
            //{


            //    CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];
            //    mContent[0].eName = CEnum.TagName.JW2_ServerIP;
            //    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[0].oContent = serverIP;

            //    mContent[1].eName = CEnum.TagName.JW2_UserSN;
            //    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[1].oContent = userID;

            //    mContent[2].eName = CEnum.TagName.JW2_UserID;
            //    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[2].oContent = userName;

            //    mContent[3].eName = CEnum.TagName.Index;
            //    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[3].oContent = int.Parse(cmbConsumerItemUser.Text.ToString());

            //    mContent[4].eName = CEnum.TagName.PageSize;
            //    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[4].oContent = Operation_JW2.iPageSize;
            //    backgroundWorkerReInterIntem.RunWorkerAsync(mContent);
            //}
        }

        private void backgroundWorkerInterBodyItem_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_CenterAvAtarItem_Equip_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerInterBodyItem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //try
            //{

            //    this.GrpSearch.Enabled = true;
            //    this.tbcResult.Enabled = true;
            //    this.Cursor = Cursors.Default;//改变鼠标状态
            //    //this.tbcResult.SelectedIndex = 8;
            //    CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            //    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //    {
            //        MessageBox.Show(mResult[0, 0].oContent.ToString());
            //        return;
            //    }

            //    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdBodyItem, out iPageCount);

            //    if (iPageCount <= 1)
            //    {
            //        this.pnlBodyItem.Visible = false;
            //    }
            //    else
            //    {
            //        for (int i = 0; i < iPageCount; i++)
            //        {
            //            this.cmbBodyItem.Items.Add(i + 1);
            //        }

            //        this.cmbBodyItem.SelectedIndex = 0;
            //        this.pageBodyItem = true;
            //        this.pnlBodyItem.Visible = true;
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void cmbBodyItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (this.pageBodyItem)
            //{


            //    CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];
            //    mContent[0].eName = CEnum.TagName.JW2_ServerIP;
            //    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[0].oContent = serverIP;

            //    mContent[1].eName = CEnum.TagName.JW2_UserSN;
            //    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[1].oContent = userID;

            //    mContent[2].eName = CEnum.TagName.JW2_UserID;
            //    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[2].oContent = userName;

            //    mContent[3].eName = CEnum.TagName.Index;
            //    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[3].oContent = int.Parse(this.cmbBodyItem.Text.ToString());

            //    mContent[4].eName = CEnum.TagName.PageSize;
            //    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[4].oContent = Operation_JW2.iPageSize;

            //    backgroundWorkerReInterBodyItem.RunWorkerAsync(mContent);
            //}
        }

        private void backgroundWorkerReBodyInterIntem_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_CenterAvAtarItem_Bag_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReBodyInterIntem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //try
            //{

            //    this.GrpSearch.Enabled = true;
            //    this.tbcResult.Enabled = true;
            //    this.Cursor = Cursors.Default;//改变鼠标状态
            //    this.tbcResult.SelectedIndex = 8;
            //    CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            //    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //    {
            //        MessageBox.Show(mResult[0, 0].oContent.ToString());
            //        return;
            //    }

            //    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdBodyItem, out iPageCount);

             
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void backgroundWorkerReInterBodyItem_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_CenterAvAtarItem_Equip_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReInterBodyItem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //try
            //{

            //    this.GrpSearch.Enabled = true;
            //    this.tbcResult.Enabled = true;
            //    this.Cursor = Cursors.Default;//改变鼠标状态
            //    this.tbcResult.SelectedIndex = 8;
            //    CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            //    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //    {
            //        MessageBox.Show(mResult[0, 0].oContent.ToString());
            //        return;
            //    }

            //    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdBodyItem, out iPageCount);


            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //getIndex = int.Parse(comboBox1.Text.ToString());
            tbcResult.SelectTab(1);
            //this.GrdIntimacyNum.DataSource = null;
            IntimacyNumLog(getIndex);//兑换魔法经验记录
        }



        public void IntimacyNumLog(int index)
        {
            btnSearch.Enabled = false;
            Cursor = Cursors.WaitCursor;

            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[7];
            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[0].eName = C_Global.CEnum.TagName.AU_ACCOUNT;
            //messageBody[0].oContent = lblAccountOrNick.Text.Trim();

            //if (this.comboBox4.Text == "一个月内")
            //{
            //    messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            //    messageBody[1].eName = C_Global.CEnum.TagName.AU_Datetype;
            //    messageBody[1].oContent = 1;
            //}
            //else
            //{
            //    messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            //    messageBody[1].eName = C_Global.CEnum.TagName.AU_Datetype;
            //    messageBody[1].oContent = 2;

            //}

            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_TIMESTAMP;
            messageBody[2].eName = C_Global.CEnum.TagName.AU_Log_start;
            //messageBody[2].oContent = this.DtpBegin.Value;

            messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_TIMESTAMP;
            messageBody[3].eName = C_Global.CEnum.TagName.AU_Log_end;
            //messageBody[3].oContent = this.DtpEnd.Value;


            messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[4].eName = C_Global.CEnum.TagName.AU_UTP;
            messageBody[4].oContent = 1;

            messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[5].eName = C_Global.CEnum.TagName.Index;
            messageBody[5].oContent = index;

            messageBody[6].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[6].eName = C_Global.CEnum.TagName.PageSize;
            //messageBody[6].oContent = Operation_Audition.iPageSize;
            //this.backgroundWorkerMagicExpLog.RunWorkerAsync(messageBody);
        }
    
        
       
    }
}