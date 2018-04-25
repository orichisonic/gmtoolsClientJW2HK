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

namespace M_GD
{
    [C_Global.CModuleAttribute("道具删除查询", "FrmGDItemDelInfo", "道具删除查询", "GD Group")]
    public partial class FrmGDItemDelInfo : Form
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
        string userAccount = null;
        int selectChar = 0;   //GrdCharacter中当前选中的行 

        bool pageNonLoanToRentBody = false;
        bool pageShopPurchaseBody = false;
        bool pageSynthesisDrawings = false;
        bool pageFightConsumer = false;
        bool pageAdjutant = false;
  
       
        
        int currDgSelectRow = 0;    //玩家信息datagrid 中当前选中的行
        #endregion

        public FrmGDItemDelInfo()
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
            FrmGDItemDelInfo mModuleFrm = new FrmGDItemDelInfo();
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
            //this.GrpSearch.Text = config.ReadConfigValue("MSD", "UIC_UI_GrpSearch");
            //this.lblServer.Text = config.ReadConfigValue("MSD", "UIC_UI_lblServer");
            //this.lblAccount.Text = config.ReadConfigValue("MSD", "UIC_UI_lblAccount");
            //this.lblNick.Text = config.ReadConfigValue("MSD", "UIC_UI_lblNick");
            //this.btnSearch.Text = config.ReadConfigValue("MSD", "UIC_UI_btnSearch");
            //this.btnClose.Text = config.ReadConfigValue("MSD", "UIC_UI_btnClose");

            //this.tpgCharacter.Text = config.ReadConfigValue("MSD", "UIC_UI_tpgCharacter");

            //this.tpgPurchaseLog.Text = config.ReadConfigValue("MSD", "UIC_UI_tpgMixTreeItems");
            //this.lblMixItems.Text = config.ReadConfigValue("MSD", "UIC_UI_lblPage");

            //this.tpgUserUnits.Text = config.ReadConfigValue("MSD", "UIC_UI_tpgUserUnits");
            //this.lblUnits.Text = config.ReadConfigValue("MSD", "UIC_UI_lblPage");

            //this.tpgCombatItems.Text = config.ReadConfigValue("MSD", "UIC_UI_tpgCombatItems");
            //this.lblCombatItems.Text = config.ReadConfigValue("MSD", "UIC_UI_lblPage");

            //this.tpgOperators.Text = config.ReadConfigValue("MSD", "UIC_UI_tpgOperators");
            //this.lblOperators.Text = config.ReadConfigValue("MSD", "UIC_UI_lblPage");

            //this.tpgSkillItems.Text = config.ReadConfigValue("MSD", "UIC_UI_tpgSkillItems");
            //this.lblSkillItems.Text = config.ReadConfigValue("MSD", "UIC_UI_lblPage");

            //this.tpgPaintItems.Text = config.ReadConfigValue("MSD", "UIC_UI_tpgPaintItems");
            //this.lblPaintItems.Text = config.ReadConfigValue("MSD", "UIC_UI_lblPage");

            //this.tpgStickItems.Text = config.ReadConfigValue("MSD", "UIC_UI_tpgStickerItems");
            //this.lblStickerItems.Text = config.ReadConfigValue("MSD", "UIC_UI_lblPage");

            //tbcResult.Enabled = false;
        }
        #endregion



        #region 登陆窗体加载(得到游戏服务器列表)
        private void FrmGDItemDelInfo_Load(object sender, EventArgs e)
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
                mContent[1].oContent = m_ClientEvent.GetInfo("GameID_SD");

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
                mServerInfo = Operation_GD.GetServerList(this.m_ClientEvent, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 加载游戏服务器列表backgroundWorker消息接收
        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbServer = Operation_GD.BuildCombox(mServerInfo, CmbServer);
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_GD.GetItemAddr(mServerInfo, CmbServer.Text));
        }
        #endregion



        #region 切换不同的游戏服务器
        private void cmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_GD.GetItemAddr(mServerInfo, CmbServer.Text));
        }
        #endregion



        #region 查询玩家资料信息
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                tbcResult.SelectedTab = tpgCharacter;//选择角色信息选项卡
                this.GrdCharacter.DataSource = null;

                if (CmbServer.Text == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSD", "UIA_Hint_selectServer"));
                    return;
                }

                serverIP = Operation_GD.GetItemAddr(mServerInfo, CmbServer.Text);
                userName = TxtAccount.Text.Trim();
                userNick = txtNick.Text.Trim();

                if (TxtAccount.Text.Trim().Length > 0 || txtNick.Text.Trim().Length > 0)
                {
                    this.GrpSearch.Enabled = false;
                    this.tbcResult.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;//改变鼠标状态

                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];
                    //查询玩家角色信息
                    mContent[0].eName = CEnum.TagName.SD_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = serverIP;

                    mContent[1].eName = CEnum.TagName.SD_UserName;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = userName;

                    mContent[2].eName = CEnum.TagName.f_pilot;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = userNick;


                    backgroundWorkerSearch.RunWorkerAsync(mContent);
                }
                else
                {
                    MessageBox.Show(config.ReadConfigValue("MMagic", "UIA_Hint_inPutAccont"));
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 查询角色资料信息backgroundWorker消息发送
        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Account_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询角色资料信息backgroundWorker消息接收
        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdCharacter, out iPageCount);
        }
        #endregion

        #region
        private void GrdCharacter_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currDgSelectRow = int.Parse(e.RowIndex.ToString());//保存列
        }
        #endregion

        #region 切换选项卡
        private void tbcResult_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                CmbNonLoanToRentBody.Items.Clear();
                this.CmbNonLoanToRentBody.Items.Clear();
                this.CmbShopPurchaseBody.Items.Clear();
                this.CmbSynthesisDrawings.Items.Clear();
                this.CmbAdjutant.Items.Clear();
                //this.CmbFightConsumer.Items.Clear();
                //bFirst = false;//翻页不重复发Query
                this.pageAdjutant = false;
                this.pageFightConsumer = false;
                this.pageNonLoanToRentBody = false;
                this.pageShopPurchaseBody = false;
                this.pageSynthesisDrawings = false;
                if (GrdCharacter.DataSource != null)
                {
                    DataTable mTable = (DataTable)GrdCharacter.DataSource;
                    userAccount = mTable.Rows[currDgSelectRow][0].ToString();//保存玩家帐号id
                    userID = int.Parse(mTable.Rows[selectChar][config.ReadConfigValue("GLOBAL", "f_idx")].ToString());//保存玩家帐号ID
                    userName = mTable.Rows[selectChar][config.ReadConfigValue("GLOBAL", "SD_UserName")].ToString();
                    //guildName = mTable.Rows[currDgSelectRow][config.ReadConfigValue("MFj", "FQA_UI_GuildName")].ToString();//保存玩家角色昵称
                    //Occupation_id = int.Parse(mTable.Rows[currDgSelectRow][config.ReadConfigValue("GLOBAL", "FJ_Occupation_id")].ToString());//保存职业
                }
                else
                {
                    //this.groupBox1.Enabled = false;
                    //this.groupBox2.Enabled = false;
                    return;
                }
                if (userAccount != null)
                {
                    if (tbcResult.SelectedTab.Text.Equals("非租贷机体"))
                    {
                        NonLoanToRentBodyQuery();//非租贷机体
                    }
                    else if (tbcResult.SelectedTab.Text.Equals("商店购买机体"))
                    {
                        ShopPurchaseBodyQuery();//商店购买机体
                    }
                    else if (tbcResult.SelectedTab.Text.Equals("合成图纸"))
                    {
                        SynthesisDrawingsQuery();//合成图纸
                    }
                    else if (tbcResult.SelectedTab.Text.Equals("副官"))
                    {
                        AdjutantQuery();//副官
                    }
                    else if (tbcResult.SelectedTab.Text.Equals("战斗消耗"))
                    {
                        FightConsumerQuery();//战斗消耗
                    }
                  
                }
                else
                {
                    MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_Msg1"));
                }
            }
            catch
            {
                MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_Msg1"));
                userAccount = null;
            }
        }
        #endregion

        #region 查询非租赁机体
        private void NonLoanToRentBodyQuery()
        {
            tbcResult.Enabled = false;
            this.GrdNonLoanToRentBody.DataSource = null;


            CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];
            //查询身上道具
            mContent[0].eName = CEnum.TagName.SD_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = serverIP;

            mContent[1].eName = CEnum.TagName.f_idx;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = userID;

            mContent[2].eName = CEnum.TagName.SD_UserName;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = userName;

            mContent[3].eName = CEnum.TagName.SD_StartTime;
            mContent[3].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
            mContent[3].oContent = DtpBegin.Value;

            mContent[4].eName = CEnum.TagName.SD_EndTime;
            mContent[4].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
            mContent[4].oContent = DtpEnd.Value;

            mContent[5].eName = CEnum.TagName.Index;
            mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[5].oContent = 1;

            mContent[6].eName = CEnum.TagName.PageSize;
            mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[6].oContent = Operation_GD.iPageSize;
            //mContent[6].oContent =1;

            mContent[7].eName = CEnum.TagName.SD_Type;
            mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[7].oContent = 1;
          
            backgroundWorkerNonLoanToRentBodyQuery.RunWorkerAsync(mContent);
        }
        #endregion

        #region　查询非租赁机体
        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.pageNonLoanToRentBody)
                {
                    //this.GrpSearch.Enabled = false;
                    this.tbcResult.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                    this.GrdNonLoanToRentBody.DataSource = null;

                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

                    mContent[0].eName = CEnum.TagName.SD_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = serverIP;

                    mContent[1].eName = CEnum.TagName.f_idx;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = userID;

                    mContent[2].eName = CEnum.TagName.SD_UserName;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = userName;

                    mContent[3].eName = CEnum.TagName.SD_StartTime;
                    mContent[3].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                    mContent[3].oContent = DtpBegin.Value;

                    mContent[4].eName = CEnum.TagName.SD_EndTime;
                    mContent[4].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                    mContent[4].oContent = DtpEnd.Value;

                    mContent[5].eName = CEnum.TagName.Index;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = int.Parse(this.CmbNonLoanToRentBody.Text.ToString());

                    mContent[6].eName = CEnum.TagName.PageSize;
                    mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[6].oContent = Operation_GD.iPageSize;
                    //mContent[6].oContent = 1;

                    mContent[7].eName = CEnum.TagName.SD_Type;
                    mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[7].oContent = 1;

                    this.backgroundWorkerReNonLoanToRentBodyQuery.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 查询商店购买机体
        private void ShopPurchaseBodyQuery()
         {
             tbcResult.Enabled = false;
             this.GrdShopPurchaseBody.DataSource = null;


             CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];
             //查询身上道具
             mContent[0].eName = CEnum.TagName.SD_ServerIP;
             mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
             mContent[0].oContent = serverIP;

             mContent[1].eName = CEnum.TagName.f_idx;
             mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
             mContent[1].oContent = userID;

             mContent[2].eName = CEnum.TagName.SD_UserName;
             mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
             mContent[2].oContent = userName;

             mContent[3].eName = CEnum.TagName.SD_StartTime;
             mContent[3].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
             mContent[3].oContent = DtpBegin.Value;

             mContent[4].eName = CEnum.TagName.SD_EndTime;
             mContent[4].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
             mContent[4].oContent = DtpEnd.Value;

             mContent[5].eName = CEnum.TagName.Index;
             mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
             mContent[5].oContent =1;

             mContent[6].eName = CEnum.TagName.PageSize;
             mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
             mContent[6].oContent = Operation_GD.iPageSize;
           

             mContent[7].eName = CEnum.TagName.SD_Type;
             mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
             mContent[7].oContent = 2;

             backgroundWorkerShopPurchaseBodyQuery.RunWorkerAsync(mContent);
         }
        #endregion

         #region 查询合成图纸
         private void SynthesisDrawingsQuery()
        {
            tbcResult.Enabled = false;
            this.GrdSynthesisDrawings.DataSource = null;
            this.pnlSynthesisDrawings.Visible = false;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];
            //查询身上道具
            mContent[0].eName = CEnum.TagName.SD_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = serverIP;

            mContent[1].eName = CEnum.TagName.f_idx;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = userID;

            mContent[2].eName = CEnum.TagName.SD_UserName;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = userName;

            mContent[3].eName = CEnum.TagName.SD_StartTime;
            mContent[3].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
            mContent[3].oContent = DtpBegin.Value;

            mContent[4].eName = CEnum.TagName.SD_EndTime;
            mContent[4].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
            mContent[4].oContent = DtpEnd.Value;

            mContent[5].eName = CEnum.TagName.Index;
            mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[5].oContent = 1;

            mContent[6].eName = CEnum.TagName.PageSize;
            mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[6].oContent = Operation_GD.iPageSize;

            mContent[7].eName = CEnum.TagName.SD_Type;
            mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[7].oContent = 3;

      
            backgroundWorkerSynthesisDrawingsQuery.RunWorkerAsync(mContent);
        }
        #endregion

        #region 查询副官
        private void AdjutantQuery()
        {
            tbcResult.Enabled = false;
            this.GrdNonLoanToRentBody.DataSource = null;


            CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];
            //查询身上道具
            mContent[0].eName = CEnum.TagName.SD_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = serverIP;

            mContent[1].eName = CEnum.TagName.f_idx;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = userID;

            mContent[2].eName = CEnum.TagName.SD_UserName;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = userName;

            mContent[3].eName = CEnum.TagName.SD_StartTime;
            mContent[3].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
            mContent[3].oContent = DtpBegin.Value;

            mContent[4].eName = CEnum.TagName.SD_EndTime;
            mContent[4].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
            mContent[4].oContent = DtpEnd.Value;

            mContent[5].eName = CEnum.TagName.Index;
            mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[5].oContent = 1;

            mContent[6].eName = CEnum.TagName.PageSize;
            mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[6].oContent = Operation_GD.iPageSize;

            mContent[7].eName = CEnum.TagName.SD_Type;
            mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[7].oContent = 4;


            this.backgroundWorkerAdjutantQuery.RunWorkerAsync(mContent);
        }
        #endregion

        #region 查询战斗消耗
        private void FightConsumerQuery()
        {
               tbcResult.Enabled = false;
            this.GrdNonLoanToRentBody.DataSource = null;


            CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];
            //查询身上道具
            mContent[0].eName = CEnum.TagName.SD_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = serverIP;

            mContent[1].eName = CEnum.TagName.f_idx;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = userID;

            mContent[2].eName = CEnum.TagName.SD_UserName;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = userName;

            mContent[3].eName = CEnum.TagName.SD_StartTime;
            mContent[3].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
            mContent[3].oContent = DtpBegin.Value;

            mContent[4].eName = CEnum.TagName.SD_EndTime;
            mContent[4].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
            mContent[4].oContent = DtpEnd.Value;

            mContent[5].eName = CEnum.TagName.Index;
            mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[5].oContent = 1;

            mContent[6].eName = CEnum.TagName.PageSize;
            mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[6].oContent = Operation_GD.iPageSize;

            mContent[7].eName = CEnum.TagName.SD_Type;
            mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[7].oContent = 5;


            backgroundWorkerFightConsumerQuery.RunWorkerAsync(mContent);
        }
        #endregion

        #region 查询非租赁机体backgroundworker消息发送
        private void backgroundWorkerNonLoanToRentBodyQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Delete_ItemLog_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询非租赁机体backgroundworker消息接受
        private void backgroundWorkerNonLoanToRentBodyQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdNonLoanToRentBody, out iPageCount);

            if (iPageCount <= 1)
            {
                this.PnlNonLoanToRentBody.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    this.CmbNonLoanToRentBody.Items.Add(i + 1);
                }

                this.CmbNonLoanToRentBody.SelectedIndex = 0;
                this.pageNonLoanToRentBody = true;
                this.PnlNonLoanToRentBody.Visible = true;
            }
        }
        #endregion

        #region 查询商店购买机体backgoundworker消息发送
        private void backgroundWorkerShopPurchaseBodyQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Delete_ItemLog_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询商店购买机体backgroundworker消息接受
        private void backgroundWorkerShopPurchaseBodyQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdShopPurchaseBody, out iPageCount);

            if (iPageCount <= 1)
            {
                this.pnlShopPurchaseBody.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    this.CmbShopPurchaseBody.Items.Add(i + 1);
                }

                this.CmbShopPurchaseBody.SelectedIndex = 0;
                this.pageShopPurchaseBody = true;
                this.pnlShopPurchaseBody.Visible = true;
            }
        }
        #endregion

        #region 查询合成图纸backgroundworker消息发送
        private void backgroundWorkerSynthesisDrawingsQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Delete_ItemLog_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询合成图纸backgroundworker消息接受
        private void backgroundWorkerSynthesisDrawingsQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdSynthesisDrawings, out iPageCount);

            if (iPageCount <= 1)
            {
                this.pnlSynthesisDrawings.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    this.CmbSynthesisDrawings.Items.Add(i + 1);
                }

                this.CmbSynthesisDrawings.SelectedIndex = 0;
                this.pageSynthesisDrawings = true;
                this.pnlSynthesisDrawings.Visible = true;
            }
        }
        #endregion

        #region 查询战斗消耗backgroundworker消息发送
        private void backgroundWorkerFightConsumerQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Delete_ItemLog_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询战斗消耗backgroundworker消息接受 
        private void backgroundWorkerFightConsumerQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        #endregion

        #region 查询副官backgroundworker消息发送
        private void backgroundWorkerAdjutantQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Delete_ItemLog_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询副官backgroundworker消息接受
        private void backgroundWorkerAdjutantQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.tbcResult.Enabled = true;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                this.pnlAdjutant.Visible = false;//隐藏翻页功能
                return;
            }

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdAdjutant, out iPageCount);
            if (iPageCount <= 0)
            {
                this.pnlAdjutant.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    this.CmbAdjutant.Items.Add(i + 1);
                }

                this.CmbAdjutant.SelectedIndex = 0;
                this.pageAdjutant = true;
                this.pnlAdjutant.Visible = true;
            }
        }
        #endregion

        #region 窗体关闭
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region 商店购买机体翻页backgroundworker消息发送
        private void backgroundWorkerReShopPurchaseBodyQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Delete_ItemLog_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 商店购买机体翻页backgroundworker消息接受
        private void backgroundWorkerReShopPurchaseBodyQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdShopPurchaseBody, out iPageCount);

        }
        #endregion

        #region 非租赁机体翻页backgroundworker消息发送
        private void backgroundWorkerReNonLoanToRentBodyQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Delete_ItemLog_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 非租赁机体翻页backgroundworker消息接受
        private void backgroundWorkerReNonLoanToRentBodyQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdNonLoanToRentBody, out iPageCount);

        
        }
        #endregion

        #region 翻页查询副官backgroundworker消息发送
        private void backgroundWorkerReAdjutantQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Delete_ItemLog_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 翻页查询副官backgroundworker消息接受
        private void backgroundWorkerReAdjutantQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdAdjutant, out iPageCount);
        }
        #endregion

        #region 翻页查询战斗消耗backgroundworker消息发送
        private void backgroundWorkerReFightConsumerQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Delete_ItemLog_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion


        #region 翻页查询战斗消耗backgroundworker消息接受
        private void backgroundWorkerReFightConsumerQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            //Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdFightConsumer, out iPageCount);

        
        }
        #endregion

        #region 翻页查询合成图纸backgroundworker消息发送
        private void backgroundWorkerReSynthesisDrawingsQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Delete_ItemLog_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 翻页查询合成图纸backgroundworker消息接受
        private void backgroundWorkerReSynthesisDrawingsQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdSynthesisDrawings, out iPageCount);
        }
        #endregion

        #region 翻页查询商店购买机体
        private void CmbShopPurchaseBody_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.pageShopPurchaseBody)
                {
                    //this.GrpSearch.Enabled = false;
                    this.tbcResult.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                    this.GrdShopPurchaseBody.DataSource = null;

                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

                    mContent[0].eName = CEnum.TagName.SD_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = serverIP;

                    mContent[1].eName = CEnum.TagName.f_idx;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = userID;

                    mContent[2].eName = CEnum.TagName.SD_UserName;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = userName;

                    mContent[3].eName = CEnum.TagName.SD_StartTime;
                    mContent[3].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                    mContent[3].oContent = DtpBegin.Value;

                    mContent[4].eName = CEnum.TagName.SD_EndTime;
                    mContent[4].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                    mContent[4].oContent = DtpEnd.Value;

                    mContent[5].eName = CEnum.TagName.Index;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = int.Parse(this.CmbShopPurchaseBody.Text.ToString());

                    mContent[6].eName = CEnum.TagName.PageSize;
                    mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[6].oContent = Operation_GD.iPageSize;

                    mContent[7].eName = CEnum.TagName.SD_Type;
                    mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[7].oContent =2;


                    this.backgroundWorkerReShopPurchaseBodyQuery.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 开始时间与当前时间差45天
        private void DtpBegin_ValueChanged(object sender, EventArgs e)
        {
         
        }
        #endregion

        #region 双击角色信息查询非租赁机体
        private void GrdCharacter_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)//双击列名触发
                {
                    selectChar = int.Parse(e.RowIndex.ToString());//保存列
                    if (GrdCharacter.DataSource != null)
                    {
                        tbcResult.SelectedTab = TpgNonLoanToRentBody;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 合成图纸翻页
        private void CmbSynthesisDrawings_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.pageSynthesisDrawings)
                {
                    //this.GrpSearch.Enabled = false;
                    this.tbcResult.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                    this.GrdShopPurchaseBody.DataSource = null;

                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

                    mContent[0].eName = CEnum.TagName.SD_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = serverIP;

                    mContent[1].eName = CEnum.TagName.f_idx;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = userID;

                    mContent[2].eName = CEnum.TagName.SD_UserName;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = userName;

                    mContent[3].eName = CEnum.TagName.SD_StartTime;
                    mContent[3].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                    mContent[3].oContent = DtpBegin.Value;

                    mContent[4].eName = CEnum.TagName.SD_EndTime;
                    mContent[4].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                    mContent[4].oContent = DtpEnd.Value;

                    mContent[5].eName = CEnum.TagName.Index;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = int.Parse(this.CmbSynthesisDrawings.Text.ToString());

                    mContent[6].eName = CEnum.TagName.PageSize;
                    mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[6].oContent = Operation_GD.iPageSize;

                    mContent[7].eName = CEnum.TagName.SD_Type;
                    mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[7].oContent = 3;

                    this.backgroundWorkerReSynthesisDrawingsQuery.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 副官翻页
        private void CmbAdjutant_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.pageAdjutant)
                {
                    //this.GrpSearch.Enabled = false;
                    this.tbcResult.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                    this.GrdAdjutant.DataSource = null;

                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

                    mContent[0].eName = CEnum.TagName.SD_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = serverIP;

                    mContent[1].eName = CEnum.TagName.f_idx;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = userID;

                    mContent[2].eName = CEnum.TagName.SD_UserName;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = userName;

                    mContent[3].eName = CEnum.TagName.SD_StartTime;
                    mContent[3].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                    mContent[3].oContent = DtpBegin.Value;

                    mContent[4].eName = CEnum.TagName.SD_EndTime;
                    mContent[4].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                    mContent[4].oContent = DtpEnd.Value;

                    mContent[5].eName = CEnum.TagName.Index;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = int.Parse(this.CmbAdjutant.Text.ToString());

                    mContent[6].eName = CEnum.TagName.PageSize;
                    mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[6].oContent = Operation_GD.iPageSize;

                    mContent[7].eName = CEnum.TagName.SD_Type;
                    mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[7].oContent =4;

                    this.backgroundWorkerReAdjutantQuery.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void CmbFightConsumer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.pageSynthesisDrawings)
                {
                    //this.GrpSearch.Enabled = false;
                    this.tbcResult.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                    this.GrdShopPurchaseBody.DataSource = null;

                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

                    mContent[0].eName = CEnum.TagName.SD_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = serverIP;

                    mContent[1].eName = CEnum.TagName.f_idx;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = userID;

                    mContent[2].eName = CEnum.TagName.SD_UserName;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = userName;

                    mContent[3].eName = CEnum.TagName.SD_StartTime;
                    mContent[3].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                    mContent[3].oContent = DtpBegin.Value;

                    mContent[4].eName = CEnum.TagName.SD_EndTime;
                    mContent[4].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                    mContent[4].oContent = DtpEnd.Value;

                    mContent[5].eName = CEnum.TagName.Index;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = int.Parse(this.CmbAdjutant.Text.ToString());

                    mContent[6].eName = CEnum.TagName.PageSize;
                    mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[6].oContent = Operation_GD.iPageSize;

                    mContent[7].eName = CEnum.TagName.SD_Type;
                    mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[7].oContent = 5;

                    this.backgroundWorkerReFightConsumerQuery.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #region 开始时间与当前时间差45天
        private void DtpBegin_Leave(object sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan();
            ts =(this.DtpBegin.Value.Date - System.DateTime.Now.Date);
            if ( System.Math.Abs(ts.TotalDays) > 45)
            {
                MessageBox.Show("购买记录保留时间不超过45天！");
                this.DtpBegin.Text = System.DateTime.Now.Date.ToString();
            }
        }
        #endregion


    }
}