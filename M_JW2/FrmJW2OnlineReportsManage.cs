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
    [C_Global.CModuleAttribute("用户信息查询", "FrmJW2OnlineReportsManage", "用户信息查询", "JW2 Group")]
    public partial class FrmJW2OnlineReportsManage : Form
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
        bool pageWaiguaInfo = false;
        bool pageWaiguaNick = false;
        bool pageWeiguiRoom = false;
        bool pageChatContent = false;
        bool pageBannerInfo = false;
        bool pageBugleContent = false;
        bool pageWeiguiPetName = false;
        bool pageWeiguiFamilyName = false;
        bool pageHome = false;
        bool pageWeiguiMingpianInfo = false;
        bool pageWeiguiFamilyInfo = false;
        #endregion

        public FrmJW2OnlineReportsManage()
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
            FrmJW2OnlineReportsManage mModuleFrm = new FrmJW2OnlineReportsManage();
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
           
            this.btnSearch.Text = config.ReadConfigValue("MSD", "UIC_UI_btnSearch");
            this.btnClose.Text = config.ReadConfigValue("MSD", "UIC_UI_btnClose");

            LblDate.Text = config.ReadConfigValue("MJW2", "NEWNEW_UI_BeginTime");
            LblLink.Text = config.ReadConfigValue("MJW2", "NEW_UI_EndTime");

            this.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2OnlineReportsManage");

            this.tpgWaiguaInfo.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgWaiguaInfo");


            this.tpgWeiguiNick.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgWeiguiNick");


            this.tpgWeiguiRoom.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgWeiguiRoom");


            this.tpgChatContent.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgChatContent");

            this.tpgBugleInfo.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgBugleInfo");
            this.tpgBannerInfo.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgBannerInfo");
            this.tpgWeiguiPetName.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgWeiguiPetName");
            this.tpgWeiguiFamilyName.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgWeiguiFamilyName");
            this.tpgWeiguiMingpianInfo.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgWeiguiMingpianInfo");
            this.tpgHome.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgHome");
            this.tpgWeiguiFamilyInfo.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgWeiguiFamilyInfo");


            lblwaiguaInfo.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            lblWaiguaNick.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            lblWeiguiRoom.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            lblChatContent.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            lblBugleContent.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            lblBannerInfo.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            lblWeiguiPetName.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            lblWeiguiFamilyName.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            lblWeiguiMingpianInfo.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            lblHome.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            lblWeiguiFamilyInfo.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            //this.tpgWaiguaInfo.Text = config.ReadConfigValue("MSD", "UIC_UI_tpgCharacter");
          

            tbcResult.Enabled = true;
        }
        #endregion



        #region 登陆窗体加载(得到游戏服务器列表)
        private void FrmJW2OnlineReportsManage_Load(object sender, EventArgs e)
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
                //if (GrdRoleView.DataSource != null)
                //{
                //    DataTable mTable = (DataTable)GrdRoleView.DataSource;
                //    serverIP = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);
                //    userID = int.Parse(mTable.Rows[selectChar][config.ReadConfigValue("GLOBAL", "JW2_UserSN")].ToString());//保存玩家帐号ID
                //    userName = mTable.Rows[selectChar][config.ReadConfigValue("GLOBAL", "JW2_UserID")].ToString();
                if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_tpgWaiguaInfo")))
                {
                    this.GrdWaiguaInfo.DataSource = null;
                    WaiguaInfo();//查詢舉報外掛資訊
                }
                if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_tpgWeiguiNick")))
                {
                    this.GrdWaiguaNick.DataSource = null;
                    WaiguaNick();//查詢舉報違規昵稱
                }
                else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_tpgWeiguiRoom")))
                {
                    this.GrdWeiguiRoom.DataSource = null;
                    WeiguiRoom();//查詢舉報違規房間名
                }
                else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_tpgChatContent")))
                {
                    this.GrdChatContent.DataSource = null;
                    ChatContent();//查詢舉報聊天記錄
                }
                else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_tpgBugleInfo")))
                {
                    this.GrdBugleContent.DataSource = null;
                    this.bugleContent();//查詢舉報大小喇叭內容
                }
                else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_tpgBannerInfo")))
                {
                    this.GrdBannerInfo.DataSource = null;
                    BannerInfo();//查詢舉報橫幅內容
                }
                else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_tpgWeiguiPetName")))
                {
                    this.GrdWeiguiPetName.DataSource = null;
                    WeiguiPetName();//查詢舉報違規寵物名
                }
                else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_tpgWeiguiFamilyName")))
                {
                    this.GrdWeiguiFamilyName.DataSource = null;
                    WeiguiFamilyName();//查詢舉報違規家族名
                }
                else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_tpgWeiguiMingpianInfo")))
                {
                    this.GrdWeiguiMingpianInfo.DataSource = null;
                    WeiguiMingpianInfo();//查詢舉報違規名片資訊

                }
                else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_tpgHome")))
                {
                    this.GrdWeiguiMingpianInfo.DataSource = null;
                    WeiguiHome();//查詢舉報違規名片資訊

                }
                else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_tpgWeiguiFamilyInfo")))
                {
                    this.GrdWeiguiMingpianInfo.DataSource = null;
                    this.WeiguiFamilyInfo();//查詢舉報違規名片資訊

                }


            //    else
            //    {
            //        GrdWaiguaInfo.DataSource = null;
            //        pnlStoryState.Visible = false;



            //        GrdWaiguaNick.DataSource = null;
            //        pnlBugleSendLog.Visible = false;

            //        GrdWeiguiRoom.DataSource = null;
            //        pnlUserFamilyInfo.Visible = false;

            //        GrdChatContent.DataSource = null;
            //        pnlBodyItemInfo.Visible = false;

            //        GrdBugleContent.DataSource = null;
            //        pnlHomeItemInfo.Visible = false;


            //        this.GrdBannerInfo.DataSource = null;
            //        this.pnlBannerInfo.Visible = false;

            //        this.GrdWeiguiPetName.DataSource = null;
            //        this.pnlWeiguiPetName.Visible = false;

            //        this.GrdWeiguiFamilyName.DataSource = null;
            //        this.pnlWeiguiFamilyName.Visible = false;

            //        this.GrdWeiguiMingpianInfo.DataSource = null;
            //        this.pnlWeiguiMingpianInfo.Visible = false;
            //    //}

            //}
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bugleContent()
        {
            try
            {

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

                mContent[1].eName = CEnum.TagName.BeginTime;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = DtpBegin.Text.ToString();

                mContent[2].eName = CEnum.TagName.EndTime;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.DtpEnd.Text.ToString();

                mContent[3].eName = CEnum.TagName.JW2_Type;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 4;


                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = 1;

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_JW2.iPageSize;

                this.backgroundWorkerBugleInfo.RunWorkerAsync(mContent);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void WaiguaInfo()
        {
            try
            {

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

                mContent[1].eName = CEnum.TagName.BeginTime;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = DtpBegin.Text.ToString();

                mContent[2].eName = CEnum.TagName.EndTime;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.DtpEnd.Text.ToString();

                mContent[3].eName = CEnum.TagName.JW2_Type;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;


                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = 1;

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_JW2.iPageSize;

                this.backgroundWorkerWaiguaInfo.RunWorkerAsync(mContent);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void WaiguaNick()
        {
            try
            {

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

                mContent[1].eName = CEnum.TagName.BeginTime;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = DtpBegin.Text.ToString();

                mContent[2].eName = CEnum.TagName.EndTime;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.DtpEnd.Text.ToString();

                mContent[3].eName = CEnum.TagName.JW2_Type;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;


                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = 1;

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_JW2.iPageSize;

                this.backgroundWorkerWeiguiNick.RunWorkerAsync(mContent);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void WeiguiRoom()
        {
            try
            {

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

                mContent[1].eName = CEnum.TagName.BeginTime;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = DtpBegin.Text.ToString();

                mContent[2].eName = CEnum.TagName.EndTime;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.DtpEnd.Text.ToString();

                mContent[3].eName = CEnum.TagName.JW2_Type;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 2;


                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = 1;

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_JW2.iPageSize;

                this.backgroundWorkerWeiguiRoom.RunWorkerAsync(mContent);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void ChatContent()
        {
            try
            {

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

                mContent[1].eName = CEnum.TagName.BeginTime;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = DtpBegin.Text.ToString();

                mContent[2].eName = CEnum.TagName.EndTime;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.DtpEnd.Text.ToString();

                mContent[3].eName = CEnum.TagName.JW2_Type;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 64;


                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = 1;

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_JW2.iPageSize;

                this.backgroundWorkerChatContent.RunWorkerAsync(mContent);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
      
        private void BannerInfo()
        {

            try
            {

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

                mContent[1].eName = CEnum.TagName.BeginTime;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = DtpBegin.Text.ToString();

                mContent[2].eName = CEnum.TagName.EndTime;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.DtpEnd.Text.ToString();

                mContent[3].eName = CEnum.TagName.JW2_Type;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 8;


                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = 1;

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_JW2.iPageSize;

                this.backgroundWorkerBannerInfo.RunWorkerAsync(mContent);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
             
       private void WeiguiPetName()
       {
           try
           {

               CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

               mContent[0].eName = CEnum.TagName.JW2_ServerIP;
               mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
               mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

               mContent[1].eName = CEnum.TagName.BeginTime;
               mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
               mContent[1].oContent = DtpBegin.Text.ToString();

               mContent[2].eName = CEnum.TagName.EndTime;
               mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
               mContent[2].oContent = this.DtpEnd.Text.ToString();

               mContent[3].eName = CEnum.TagName.JW2_Type;
               mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
               mContent[3].oContent = 16;


               mContent[4].eName = CEnum.TagName.Index;
               mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
               mContent[4].oContent = 1;

               mContent[5].eName = CEnum.TagName.PageSize;
               mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
               mContent[5].oContent = Operation_JW2.iPageSize;

               this.backgroundWorkerWeiguiPetName.RunWorkerAsync(mContent);
           }
           catch (System.Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }
       }
       

       private void  WeiguiFamilyName()
       {
           try
           {

               CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

               mContent[0].eName = CEnum.TagName.JW2_ServerIP;
               mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
               mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

               mContent[1].eName = CEnum.TagName.BeginTime;
               mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
               mContent[1].oContent = DtpBegin.Text.ToString();

               mContent[2].eName = CEnum.TagName.EndTime;
               mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
               mContent[2].oContent = this.DtpEnd.Text.ToString();

               mContent[3].eName = CEnum.TagName.JW2_Type;
               mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
               mContent[3].oContent = 32;


               mContent[4].eName = CEnum.TagName.Index;
               mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
               mContent[4].oContent = 1;

               mContent[5].eName = CEnum.TagName.PageSize;
               mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
               mContent[5].oContent = Operation_JW2.iPageSize;

               this.backgroundWorkerWeiguiFamilyName.RunWorkerAsync(mContent);
           }
           catch (System.Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }
       }
                  
       private void WeiguiMingpianInfo()
       {
           try
           {

               CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

               mContent[0].eName = CEnum.TagName.JW2_ServerIP;
               mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
               mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

               mContent[1].eName = CEnum.TagName.BeginTime;
               mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
               mContent[1].oContent = DtpBegin.Text.ToString();

               mContent[2].eName = CEnum.TagName.EndTime;
               mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
               mContent[2].oContent = this.DtpEnd.Text.ToString();

               mContent[3].eName = CEnum.TagName.JW2_Type;
               mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
               mContent[3].oContent = 128;


               mContent[4].eName = CEnum.TagName.Index;
               mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
               mContent[4].oContent = 1;

               mContent[5].eName = CEnum.TagName.PageSize;
               mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
               mContent[5].oContent = Operation_JW2.iPageSize;

               this.backgroundWorkerWeiguiMingpianInfo.RunWorkerAsync(mContent);
           }
           catch (System.Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }

       }

        private void WeiguiHome()
        {
            try
            {

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

                mContent[1].eName = CEnum.TagName.BeginTime;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = DtpBegin.Text.ToString();

                mContent[2].eName = CEnum.TagName.EndTime;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.DtpEnd.Text.ToString();

                mContent[3].eName = CEnum.TagName.JW2_Type;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 256;


                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = 1;

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_JW2.iPageSize;

                this.backgroundWorkerReHome.RunWorkerAsync(mContent);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        
        }
        private void WeiguiFamilyInfo()
        {
            try
            {

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

                mContent[1].eName = CEnum.TagName.BeginTime;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = DtpBegin.Text.ToString();

                mContent[2].eName = CEnum.TagName.EndTime;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.DtpEnd.Text.ToString();

                mContent[3].eName = CEnum.TagName.JW2_Type;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 512;


                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = 1;

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_JW2.iPageSize;

                this.backgroundWorkerWeiguiFamilyInfo.RunWorkerAsync(mContent);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        
        }
                
        private void backgroundWorkerWaiguaInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_JB_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerWaiguaInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
                //this.tbcResult.SelectedIndex = 0;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdWaiguaInfo, out iPageCount);

                if (iPageCount <= 1)
                {
                    this.pnlWaiguaInfo.Visible = false;
                }
                else
                {
                    for (int i = 0; i < iPageCount; i++)
                    {
                        this.cmbWaiguaInfo.Items.Add(i + 1);
                    }

                    this.cmbWaiguaInfo.SelectedIndex = 0;
                    this.pageWaiguaInfo = true;
                    this.pnlWaiguaInfo.Visible = true;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorkerReWaiguaInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_JB_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReWaiguaInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
                //this.tbcResult.SelectedIndex = 0;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdWaiguaInfo, out iPageCount);

               
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorkerWeiguiNick_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_JB_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerWeiguiNick_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdWaiguaNick, out iPageCount);

                if (iPageCount <= 1)
                {
                    this.pnlWaiguaNick.Visible = false;
                }
                else
                {
                    for (int i = 0; i < iPageCount; i++)
                    {
                        this.cmbWaiguaNick.Items.Add(i + 1);
                    }

                    this.cmbWaiguaNick.SelectedIndex = 0;
                    this.pageWaiguaNick = true;
                    this.pnlWaiguaNick.Visible = true;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void backgroundWorkerReWeiguiNick_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_JB_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReWeiguiNick_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
                //this.tbcResult.SelectedIndex = 0;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdWaiguaNick, out iPageCount);

             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorkerWeiguiRoom_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_JB_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerWeiguiRoom_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
                //this.tbcResult.SelectedIndex = 0;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdWeiguiRoom, out iPageCount);

                if (iPageCount <= 1)
                {
                    this.pnlWeiguiRoom.Visible = false;
                }
                else
                {
                    for (int i = 0; i < iPageCount; i++)
                    {
                        this.cmbWeiguiRoom.Items.Add(i + 1);
                    }

                    this.cmbWeiguiRoom.SelectedIndex = 0;
                    this.pageWeiguiRoom = true;
                    this.pnlWeiguiRoom.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorkerReWeiguiRoom_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_JB_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReWeiguiRoom_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
                //this.tbcResult.SelectedIndex = 0;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdWeiguiRoom, out iPageCount);

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorkerBugleInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_JB_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerBugleInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
                //this.tbcResult.SelectedIndex = 0;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdBugleContent, out iPageCount);
                if (iPageCount <= 1)
                {
                    this.pnlBugleContent.Visible = false;
                }
                else
                {
                    for (int i = 0; i < iPageCount; i++)
                    {
                        this.cmbBugleContent.Items.Add(i + 1);
                    }

                    this.cmbBugleContent.SelectedIndex = 0;
                    this.pageBugleContent = true;
                    this.pnlBugleContent.Visible = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorkerReBugleInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_JB_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReBugleInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
                //this.tbcResult.SelectedIndex = 0;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdBugleContent, out iPageCount);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorkerBannerInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_JB_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerBannerInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
                //this.tbcResult.SelectedIndex = 0;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdBannerInfo, out iPageCount);
                if (iPageCount <= 1)
                {
                    this.pnlBannerInfo.Visible = false;
                }
                else
                {
                    for (int i = 0; i < iPageCount; i++)
                    {
                        this.cmbBannerInfo.Items.Add(i + 1);
                    }

                    this.cmbBannerInfo.SelectedIndex = 0;
                    this.pageBannerInfo = true;
                    this.pnlBannerInfo.Visible = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorkerReBannerInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_JB_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReBannerInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdBannerInfo, out iPageCount);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorkerWeiguiFamilyName_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_JB_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerWeiguiFamilyName_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdWeiguiFamilyName, out iPageCount);
                if (iPageCount <= 1)
                {
                    this.pnlWeiguiFamilyName.Visible = false;
                }
                else
                {
                    for (int i = 0; i < iPageCount; i++)
                    {
                        this.cmbWeiguiFamilyName.Items.Add(i + 1);
                    }

                    this.cmbWeiguiFamilyName.SelectedIndex = 0;
                    this.pageWeiguiFamilyName = true;
                    this.pnlWeiguiFamilyName.Visible = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorkerReWeiguiFamilyName_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_JB_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReWeiguiFamilyName_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdWeiguiFamilyName, out iPageCount);
          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorkerChatContent_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_JB_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerChatContent_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdChatContent, out iPageCount);

                if (iPageCount <= 1)
                {
                    this.pnlChatContent.Visible = false;
                }
                else
                {
                    for (int i = 0; i < iPageCount; i++)
                    {
                        this.cmbChatContent.Items.Add(i + 1);
                    }

                    this.cmbChatContent.SelectedIndex = 0;
                    this.pageChatContent = true;
                    this.pnlChatContent.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorkerReChatContent_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_JB_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReChatContent_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdChatContent, out iPageCount);

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorkerWeiguiPetName_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_JB_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerWeiguiPetName_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
                //this.tbcResult.SelectedIndex = 0;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdWeiguiPetName, out iPageCount);

                if (iPageCount <= 1)
                {
                    this.pnlWeiguiPetName.Visible = false;
                }
                else
                {
                    for (int i = 0; i < iPageCount; i++)
                    {
                        this.cmbWeiguiPetName.Items.Add(i + 1);
                    }

                    this.cmbWeiguiPetName.SelectedIndex = 0;
                    this.pageWeiguiPetName = true;
                    this.pnlWeiguiPetName.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorkerReWeiguiPetName_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_JB_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReWeiguiPetName_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
            //this.tbcResult.SelectedIndex = 0;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdWeiguiPetName, out iPageCount);

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorkerHome_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_JB_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerHome_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
                //this.tbcResult.SelectedIndex = 0;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdHome, out iPageCount);

                if (iPageCount <= 1)
                {
                    this.pnlHome.Visible = false;
                }
                else
                {
                    for (int i = 0; i < iPageCount; i++)
                    {
                        this.cmbHome.Items.Add(i + 1);
                    }

                    this.cmbHome.SelectedIndex = 0;
                    this.pageHome = true;
                    this.pnlHome.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorkerReHome_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_JB_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReHome_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
                //this.tbcResult.SelectedIndex = 0;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdHome, out iPageCount);

           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorkerWeiguiMingpianInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_JB_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerWeiguiMingpianInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
                //this.tbcResult.SelectedIndex = 0;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdWeiguiMingpianInfo, out iPageCount);

                if (iPageCount <= 1)
                {
                    this.pnlWeiguiMingpianInfo.Visible = false;
                }
                else
                {
                    for (int i = 0; i < iPageCount; i++)
                    {
                        this.cmbWeiguiMingpianInfo.Items.Add(i + 1);
                    }

                    this.cmbWeiguiMingpianInfo.SelectedIndex = 0;
                    this.pageWeiguiMingpianInfo = true;
                    this.pnlWeiguiMingpianInfo.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorkerReWeiguiMingpianInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_JB_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReWeiguiMingpianInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
                //this.tbcResult.SelectedIndex = 0;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdWeiguiMingpianInfo, out iPageCount);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorkerWeiguiFamilyInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_JB_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerWeiguiFamilyInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
                //this.tbcResult.SelectedIndex = 0;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdWeiguiFamilyInfo, out iPageCount);

                if (iPageCount <= 1)
                {
                    this.pnlWeiguiFamilyInfo.Visible = false;
                }
                else
                {
                    for (int i = 0; i < iPageCount; i++)
                    {
                        this.cmbWeiguiFamilyInfo.Items.Add(i + 1);
                    }

                    this.cmbWeiguiFamilyInfo.SelectedIndex = 0;
                    this.pageWeiguiFamilyInfo = true;
                    this.pnlWeiguiFamilyInfo.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorkerReWeiguiFamilyInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_JB_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReWeiguiFamilyInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
                //this.tbcResult.SelectedIndex = 0;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdWeiguiFamilyInfo, out iPageCount);

              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
            
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

            mContent[0].eName = CEnum.TagName.JW2_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

            mContent[1].eName = CEnum.TagName.BeginTime;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = DtpBegin.Text.ToString();

            mContent[2].eName = CEnum.TagName.EndTime;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = this.DtpEnd.Text.ToString();

            mContent[3].eName = CEnum.TagName.JW2_Type;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = 1024;
         

            mContent[4].eName = CEnum.TagName.Index;
            mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[4].oContent = 1;

            mContent[5].eName = CEnum.TagName.PageSize;
            mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[5].oContent = Operation_JW2.iPageSize;

            

            this.backgroundWorkerWaiguaInfo.RunWorkerAsync(mContent);
        }
        catch (System.Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        }

        private void cmbWaiguaInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(pageWaiguaInfo)
            {

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

                mContent[1].eName = CEnum.TagName.BeginTime;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = DtpBegin.Text.ToString();

                mContent[2].eName = CEnum.TagName.EndTime;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.DtpEnd.Text.ToString();

                mContent[3].eName = CEnum.TagName.JW2_Type;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1024;


                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = int.Parse(this.cmbWaiguaInfo.Text.ToString());

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_JW2.iPageSize;



                this.backgroundWorkerReWaiguaInfo.RunWorkerAsync(mContent);


            }
        }

        private void cmbWaiguaNick_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageWaiguaNick)
            {
            
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

            mContent[0].eName = CEnum.TagName.JW2_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

            mContent[1].eName = CEnum.TagName.BeginTime;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = DtpBegin.Text.ToString();

            mContent[2].eName = CEnum.TagName.EndTime;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = this.DtpEnd.Text.ToString();

            mContent[3].eName = CEnum.TagName.JW2_Type;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = 1;


            mContent[4].eName = CEnum.TagName.Index;
            mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[4].oContent = int.Parse(this.cmbWaiguaNick.Text.ToString());

            mContent[5].eName = CEnum.TagName.PageSize;
            mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[5].oContent = Operation_JW2.iPageSize;

            this.backgroundWorkerWeiguiNick.RunWorkerAsync(mContent);
                }
        }

        private void cmbWeiguiRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageWeiguiRoom)
            {

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

                mContent[1].eName = CEnum.TagName.BeginTime;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = DtpBegin.Text.ToString();

                mContent[2].eName = CEnum.TagName.EndTime;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.DtpEnd.Text.ToString();

                mContent[3].eName = CEnum.TagName.JW2_Type;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 2;


                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = int.Parse(this.cmbWeiguiRoom.Text.ToString());

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_JW2.iPageSize;

                this.backgroundWorkerReWeiguiRoom.RunWorkerAsync(mContent);
            }
        }

        private void cmbChatContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageChatContent)
            {

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

                mContent[1].eName = CEnum.TagName.BeginTime;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = DtpBegin.Text.ToString();

                mContent[2].eName = CEnum.TagName.EndTime;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.DtpEnd.Text.ToString();

                mContent[3].eName = CEnum.TagName.JW2_Type;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 64;


                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = int.Parse(this.cmbChatContent.Text.ToString());

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_JW2.iPageSize;

                this.backgroundWorkerReChatContent.RunWorkerAsync(mContent);
            }
        }

        private void cmbBugleContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageBugleContent)
            {

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

                mContent[1].eName = CEnum.TagName.BeginTime;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = DtpBegin.Text.ToString();

                mContent[2].eName = CEnum.TagName.EndTime;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.DtpEnd.Text.ToString();

                mContent[3].eName = CEnum.TagName.JW2_Type;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 4;


                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = int.Parse(this.cmbBugleContent.Text.ToString());

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_JW2.iPageSize;

                this.backgroundWorkerReChatContent.RunWorkerAsync(mContent);
            }
        }

        private void cmbBannerInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageBannerInfo)
            {

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

                mContent[1].eName = CEnum.TagName.BeginTime;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = DtpBegin.Text.ToString();

                mContent[2].eName = CEnum.TagName.EndTime;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.DtpEnd.Text.ToString();

                mContent[3].eName = CEnum.TagName.JW2_Type;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 8;


                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = int.Parse(this.cmbBannerInfo.Text.ToString());

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_JW2.iPageSize;

                this.backgroundWorkerReBugleInfo.RunWorkerAsync(mContent);
            }
        }

        private void cmbWeiguiPetName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageWeiguiPetName)
            {

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

                mContent[1].eName = CEnum.TagName.BeginTime;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = DtpBegin.Text.ToString();

                mContent[2].eName = CEnum.TagName.EndTime;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.DtpEnd.Text.ToString();

                mContent[3].eName = CEnum.TagName.JW2_Type;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 16;


                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = int.Parse(this.cmbWeiguiPetName.Text.ToString());

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_JW2.iPageSize;

                this.backgroundWorkerReWeiguiPetName.RunWorkerAsync(mContent);
            }
        }

        private void cmbWeiguiFamilyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageWeiguiFamilyName)
            {

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

                mContent[1].eName = CEnum.TagName.BeginTime;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = DtpBegin.Text.ToString();

                mContent[2].eName = CEnum.TagName.EndTime;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.DtpEnd.Text.ToString();

                mContent[3].eName = CEnum.TagName.JW2_Type;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 32;


                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = int.Parse(this.cmbWeiguiFamilyName.Text.ToString());

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_JW2.iPageSize;

                this.backgroundWorkerReWeiguiFamilyName.RunWorkerAsync(mContent);
            }
        }

        private void cmbWeiguiMingpianInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageWeiguiMingpianInfo)
            {

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

                mContent[1].eName = CEnum.TagName.BeginTime;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = DtpBegin.Text.ToString();

                mContent[2].eName = CEnum.TagName.EndTime;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.DtpEnd.Text.ToString();

                mContent[3].eName = CEnum.TagName.JW2_Type;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 128;


                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = int.Parse(this.cmbWeiguiMingpianInfo.Text.ToString());

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_JW2.iPageSize;

                this.backgroundWorkerReWeiguiMingpianInfo.RunWorkerAsync(mContent);
            }
        }

        private void cmbHome_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageHome)
            {

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

                mContent[1].eName = CEnum.TagName.BeginTime;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = DtpBegin.Text.ToString();

                mContent[2].eName = CEnum.TagName.EndTime;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.DtpEnd.Text.ToString();

                mContent[3].eName = CEnum.TagName.JW2_Type;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 256;


                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = int.Parse(this.cmbHome.Text.ToString());

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_JW2.iPageSize;

                this.backgroundWorkerReHome.RunWorkerAsync(mContent);
            }
        }

        private void cmbWeiguiFamilyInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageHome)
            {

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

                mContent[1].eName = CEnum.TagName.BeginTime;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = DtpBegin.Text.ToString();

                mContent[2].eName = CEnum.TagName.EndTime;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.DtpEnd.Text.ToString();

                mContent[3].eName = CEnum.TagName.JW2_Type;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 512;


                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = int.Parse(this.cmbWeiguiFamilyInfo.Text.ToString());

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_JW2.iPageSize;

                this.backgroundWorkerReWeiguiFamilyInfo.RunWorkerAsync(mContent);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

    }
}