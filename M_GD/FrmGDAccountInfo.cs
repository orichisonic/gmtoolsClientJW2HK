using System;
using System.Collections;
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
    [C_Global.CModuleAttribute("用户信息查询", "FrmGDAccountInfo", "用户信息查询", "GD Group")]
    public partial class FrmGDAccountInfo : Form
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
        bool pageMixItems = false;
        bool pageUnits = false;
        bool pageCombat = false;
        bool pageOperator = false;
        bool pagePaint = false;
        bool pageSkill = false;
        bool pageSticker = false;
        bool pageUserUnitsDetail=false;
        bool pageStraightRanking = false;
        bool pageComplexRank = false;
        #endregion

        public FrmGDAccountInfo()
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
            FrmGDAccountInfo mModuleFrm = new FrmGDAccountInfo();
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

            //this.tpgMixTreeItems.Text = config.ReadConfigValue("MSD", "UIC_UI_tpgMixTreeItems");
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

            tbcResult.Enabled = true;
        }
        #endregion



        #region 登陆窗体加载(得到游戏服务器列表)
        private void FrmGDAccountInfo_Load(object sender, EventArgs e)
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
            cmbServer = Operation_GD.BuildCombox(mServerInfo, cmbServer);
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_GD.GetItemAddr(mServerInfo, cmbServer.Text));
        }
        #endregion



        #region 切换不同的游戏服务器
        private void cmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_GD.GetItemAddr(mServerInfo, cmbServer.Text));
        }
        #endregion



        #region 查询玩家资料信息
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                tbcResult.SelectedTab = tpgCharacter;//选择角色信息选项卡
                this.GrdCharacter.DataSource = null;

                if (cmbServer.Text == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSD", "UIA_Hint_selectServer"));
                    return;
                }

                serverIP = Operation_GD.GetItemAddr(mServerInfo, cmbServer.Text);
                userName = txtAccount.Text.Trim();
                userNick = txtNick.Text.Trim();

                if (txtAccount.Text.Trim().Length > 0 || txtNick.Text.Trim().Length > 0)
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
                e.Result = Operation_GD.GetResult(m_ClientEvent, CEnum.ServiceKey.SD_Account_Query, (CEnum.Message_Body[])e.Argument);
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



        #region 单击玩家基本信息保存当前行号
        private void GrdCharacter_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)//单击某一列
                {
                    selectChar = int.Parse(e.RowIndex.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 双击玩家基本信息查看机体组合信息
        private void GrdCharacter_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)//双击列名触发
                {
                    selectChar = int.Parse(e.RowIndex.ToString());//保存列
                    if (GrdCharacter.DataSource != null)
                    {
                        tbcResult.SelectedTab = tpgMixTreeItems;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 切换选项卡进行操作
        private void tbcResult_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                if (GrdCharacter.DataSource != null)
                {
                    DataTable mTable = (DataTable)GrdCharacter.DataSource;
                    userID = int.Parse(mTable.Rows[selectChar][config.ReadConfigValue("GLOBAL", "f_idx")].ToString());//保存玩家帐号ID
                    userName = mTable.Rows[selectChar][config.ReadConfigValue("GLOBAL", "SD_UserName")].ToString();
                    if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("GLOBAL", "UIC_UI_tpgMixTreeItems")))
                    {
                        MixTreeItems();//查询机体组合
                    }
                    else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("GLOBAL", "UIC_UI_tpgUserUnits")))
                    {
                        UnitsItem();//查询机体信息
                    }
                    else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("GLOBAL", "UIC_UI_tpgCombatItems")))
                    {
                        CombatItems();//查询战斗道具
                    }
                    else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("GLOBAL", "UIC_UI_tpgOperators")))
                    {
                        OperaterInfo();//查询副官信息
                    }
                    else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("GLOBAL", "UIC_UI_tpgPaintItems")))
                    {
                        PaintItems();//查询涂装道具
                    }
                    else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("GLOBAL", "UIC_UI_tpgSkillItems")))
                    {
                        SkillItems();//查询技能道具
                    }
                    else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("GLOBAL", "UIC_UI_tpgStickerItems")))
                    {
                        StickerItems();//查询标签道具
                    }
                
                    //else if (tbcResult.SelectedTab.Text.Equals("机体详细信息"))
                    //{
                    //    UserUnitsDetail();//查询机体详细信息
                    
                    //}
                }
                    //else if(tbcResult.SelectedTab.Text.Equals("综合排名"))
                    //{
                    //    ComplexRank();//查询综合排名
                    //}
                    //else if (tbcResult.SelectedTab.Text.Equals("获胜排名"))
                    //{
                    //    StraightRanking();//查询综合排名
                    //}
                else
                {
                    GrdMixItems.DataSource = null;
                    pnlMixItems.Visible = false;

                    GrdUnits.DataSource = null;
                    pnlUnits.Visible = false;

                    GrdCombatItems.DataSource = null;
                    pnlCombatItems.Visible = false;

                    GrdOperators.DataSource = null;
                    pnlOperators.Visible = false;

                    GrdPaintItems.DataSource = null;
                    pnlPaintItems.Visible = false;

                    GrdSkillItems.DataSource = null;
                    pnlSkillItems.Visible = false;

                    GrdStickerItems.DataSource = null;
                    pnlStickerItems.Visible = false;

                    //GrdStraightRanking.DataSource = null;
                    //pnlStraightRanking.Visible = false;

                    //GrdComplexRank.DataSource = null;
                    //pnlComplexRank.Visible= false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion



        #region 查询机体组合信息
        private void MixTreeItems()
        {
            try
            {
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                this.GrdMixItems.DataSource = null;

                this.pnlMixItems.Visible = false;
                this.cmbMixItems.Items.Clear();
                this.pageMixItems = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.SD_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = serverIP;

                mContent[1].eName = CEnum.TagName.f_idx;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = userID;

                mContent[2].eName = CEnum.TagName.SD_UserName;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = userName;

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_GD.iPageSize;

                backgroundWorkerMixTree.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 查询机体组合信息backgroundWorker消息发送
        private void backgroundWorkerMixTree_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Item_MixTree_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询机体组合信息backgroundWorker消息接收
        private void backgroundWorkerMixTree_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdMixItems, out iPageCount);

            if (iPageCount <= 1)
            {
                this.pnlMixItems.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    this.cmbMixItems.Items.Add(i + 1);
                }

                cmbMixItems.SelectedIndex = 0;
                pageMixItems = true;
                pnlMixItems.Visible = true;
            }
        }
        #endregion



        #region 翻页查询机体组合信息
        private void cmbMixItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pageMixItems)
                {
                    this.GrpSearch.Enabled = false;
                    this.tbcResult.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                    this.GrdMixItems.DataSource = null;

                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                    mContent[0].eName = CEnum.TagName.SD_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = serverIP;

                    mContent[1].eName = CEnum.TagName.f_idx;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = userID;

                    mContent[2].eName = CEnum.TagName.SD_UserName;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = userName;

                    mContent[3].eName = CEnum.TagName.Index;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(cmbMixItems.Text.Trim());

                    mContent[4].eName = CEnum.TagName.PageSize;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = Operation_GD.iPageSize;

                    backgroundWorkerReMixTree.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 翻页查询机体组合信息backgroundWorker消息发送
        private void backgroundWorkerReMixTree_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Item_MixTree_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 翻页查询机体组合信息backgroundWorker消息接收
        private void backgroundWorkerReMixTree_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdMixItems, out iPageCount);
        }
        #endregion



        #region 查询机体信息
        private void UnitsItem()
        {
            try
            {
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                this.GrdUnits.DataSource = null;

                this.pnlUnits.Visible = false;
                this.cmbUnits.Items.Clear();
                this.pageUnits = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.SD_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = serverIP;

                mContent[1].eName = CEnum.TagName.f_idx;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = userID;

                mContent[2].eName = CEnum.TagName.SD_UserName;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = userName;

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_GD.iPageSize;

                backgroundWorkerUnits.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 查询机体信息backgroundWorker消息发送
        private void backgroundWorkerUnits_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Item_UserUnits_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询机体信息backgroundWorker消息接收
        private void backgroundWorkerUnits_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdUnits, out iPageCount);

            if (iPageCount <= 1)
            {
                this.pnlUnits.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    this.cmbUnits.Items.Add(i + 1);
                }

                cmbUnits.SelectedIndex = 0;
                pageUnits = true;
                pnlUnits.Visible = true;
            }
        }
        #endregion



        #region 翻页查询机体信息
        private void cmbUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pageUnits)
                {
                    this.GrpSearch.Enabled = false;
                    this.tbcResult.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                    this.GrdUnits.DataSource = null;

                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                    mContent[0].eName = CEnum.TagName.SD_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = serverIP;

                    mContent[1].eName = CEnum.TagName.f_idx;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = userID;

                    mContent[2].eName = CEnum.TagName.SD_UserName;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = userName;

                    mContent[3].eName = CEnum.TagName.Index;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(cmbUnits.Text.Trim());

                    mContent[4].eName = CEnum.TagName.PageSize;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = Operation_GD.iPageSize;

                    backgroundWorkerReUnits.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 翻页查询机体信息backgroundWorker消息发送
        private void backgroundWorkerReUnits_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Item_UserUnits_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 翻页查询机体信息backgroundWorker消息接收
        private void backgroundWorkerReUnits_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdUnits, out iPageCount);
        }
        #endregion



        #region 查询战斗道具信息
        private void CombatItems()
        {
            try
            {
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                this.GrdCombatItems.DataSource = null;

                this.pnlCombatItems.Visible = false;
                this.cmbCombatItems.Items.Clear();
                this.pageCombat = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.SD_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = serverIP;

                mContent[1].eName = CEnum.TagName.f_idx;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = userID;

                mContent[2].eName = CEnum.TagName.SD_UserName;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = userName;

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_GD.iPageSize;

                backgroundWorkerCombatItems.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 查询战斗道具信息backgroundWorker消息发送
        private void backgroundWorkerCombatItems_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Item_UserCombatitems_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询战斗道具信息backgroundWorker消息接收
        private void backgroundWorkerCombatItems_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdCombatItems, out iPageCount);

            if (iPageCount <= 1)
            {
                this.pnlCombatItems.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    this.cmbCombatItems.Items.Add(i + 1);
                }

                cmbCombatItems.SelectedIndex = 0;
                pageCombat = true;
                pnlCombatItems.Visible = true;
            }
        }
        #endregion



        #region 翻页查询战斗道具信息
        private void cmbCombatItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pageCombat)
                {
                    this.GrpSearch.Enabled = false;
                    this.tbcResult.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                    this.GrdCombatItems.DataSource = null;

                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                    mContent[0].eName = CEnum.TagName.SD_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = serverIP;

                    mContent[1].eName = CEnum.TagName.f_idx;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = userID;

                    mContent[2].eName = CEnum.TagName.SD_UserName;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = userName;

                    mContent[3].eName = CEnum.TagName.Index;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(cmbCombatItems.Text.Trim());

                    mContent[4].eName = CEnum.TagName.PageSize;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = Operation_GD.iPageSize;

                    backgroundWorkerReCombatItems.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 翻页查询战斗道具信息backgroundWorker消息发送
        private void backgroundWorkerReCombatItems_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Item_UserCombatitems_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 翻页查询战斗道具信息backgroundWorker消息接收
        private void backgroundWorkerReCombatItems_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdCombatItems, out iPageCount);
        }
        #endregion



        #region 查询副官信息
        private void OperaterInfo()
        {
            try
            {
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                this.GrdOperators.DataSource = null;

                this.pnlOperators.Visible = false;
                this.cmbOperators.Items.Clear();
                this.pageOperator = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.SD_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = serverIP;

                mContent[1].eName = CEnum.TagName.f_idx;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = userID;

                mContent[2].eName = CEnum.TagName.SD_UserName;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = userName;

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_GD.iPageSize;

                backgroundWorkerOperators.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 查询副官信息backgroundWorker消息发送
        private void backgroundWorkerOperators_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Item_Operator_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询副官信息backgroundWorker消息接收
        private void backgroundWorkerOperators_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdOperators, out iPageCount);

            if (iPageCount <= 1)
            {
                this.pnlOperators.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    this.cmbOperators.Items.Add(i + 1);
                }

                cmbOperators.SelectedIndex = 0;
                pageOperator = true;
                pnlOperators.Visible = true;
            }
        }
        #endregion



        #region 翻页查询副官信息
        private void cmbOperators_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pageOperator)
                {
                    this.GrpSearch.Enabled = false;
                    this.tbcResult.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                    this.GrdOperators.DataSource = null;

                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                    mContent[0].eName = CEnum.TagName.SD_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = serverIP;

                    mContent[1].eName = CEnum.TagName.f_idx;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = userID;

                    mContent[2].eName = CEnum.TagName.SD_UserName;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = userName;

                    mContent[3].eName = CEnum.TagName.Index;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(cmbOperators.Text.Trim());

                    mContent[4].eName = CEnum.TagName.PageSize;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = Operation_GD.iPageSize;

                    backgroundWorkerReOperators.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 翻页查询副官信息backgroundWorker消息发送
        private void backgroundWorkerReOperators_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Item_Operator_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 翻页查询副官信息backgroundWorker消息接收
        private void backgroundWorkerReOperators_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdOperators, out iPageCount);
        }
        #endregion



        #region 查询涂装道具
        private void PaintItems()
        {
            try
            {
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                this.GrdPaintItems.DataSource = null;

                this.pnlPaintItems.Visible = false;
                this.cmbPaintItems.Items.Clear();
                this.pagePaint = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.SD_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = serverIP;

                mContent[1].eName = CEnum.TagName.f_idx;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = userID;

                mContent[2].eName = CEnum.TagName.SD_UserName;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = userName;

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_GD.iPageSize;

                backgroundWorkerPaintItems.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 查询涂装道具backgroundWorker消息发送
        private void backgroundWorkerPaintItems_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Item_Paint_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询涂装道具backgroundWorker消息接收
        private void backgroundWorkerPaintItems_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdPaintItems, out iPageCount);

            if (iPageCount <= 1)
            {
                this.pnlPaintItems.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    this.cmbPaintItems.Items.Add(i + 1);
                }

                cmbPaintItems.SelectedIndex = 0;
                pagePaint = true;
                pnlPaintItems.Visible = true;
            }
        }
        #endregion



        #region 翻页查询涂装道具
        private void cmbPaintItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pagePaint)
                {
                    this.GrpSearch.Enabled = false;
                    this.tbcResult.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                    this.GrdPaintItems.DataSource = null;

                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                    mContent[0].eName = CEnum.TagName.SD_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = serverIP;

                    mContent[1].eName = CEnum.TagName.f_idx;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = userID;

                    mContent[2].eName = CEnum.TagName.SD_UserName;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = userName;

                    mContent[3].eName = CEnum.TagName.Index;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(cmbPaintItems.Text.Trim());

                    mContent[4].eName = CEnum.TagName.PageSize;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = Operation_GD.iPageSize;

                    backgroundWorkerRePaintItems.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 翻页查询涂装道具backgroundWorker消息发送
        private void backgroundWorkerRePaintItems_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Item_Paint_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 翻页查询涂装道具backgroundWorker消息接收
        private void backgroundWorkerRePaintItems_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdPaintItems, out iPageCount);
        }
        #endregion



        #region 查询技能道具
        private void SkillItems()
        {
            try
            {
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                this.GrdSkillItems.DataSource = null;

                this.pnlSkillItems.Visible = false;
                this.cmbSkillItems.Items.Clear();
                this.pageSkill = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.SD_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = serverIP;

                mContent[1].eName = CEnum.TagName.f_idx;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = userID;

                mContent[2].eName = CEnum.TagName.SD_UserName;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = userName;

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_GD.iPageSize;

                backgroundWorkerSkillItems.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 查询技能道具backgroundWorker消息发送
        private void backgroundWorkerSkillItems_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Item_Skill_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询技能道具backgroundWorker消息接收
        private void backgroundWorkerSkillItems_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdSkillItems, out iPageCount);

            if (iPageCount <= 1)
            {
                this.pnlSkillItems.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    this.cmbSkillItems.Items.Add(i + 1);
                }

                cmbSkillItems.SelectedIndex = 0;
                pageSkill = true;
                pnlSkillItems.Visible = true;
            }
        }
        #endregion



        #region 翻页查询技能道具
        private void cmbSkillItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pageSkill)
                {
                    this.GrpSearch.Enabled = false;
                    this.tbcResult.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                    this.GrdSkillItems.DataSource = null;

                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                    mContent[0].eName = CEnum.TagName.SD_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = serverIP;

                    mContent[1].eName = CEnum.TagName.f_idx;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = userID;

                    mContent[2].eName = CEnum.TagName.SD_UserName;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = userName;

                    mContent[3].eName = CEnum.TagName.Index;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(cmbSkillItems.Text.Trim());

                    mContent[4].eName = CEnum.TagName.PageSize;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = Operation_GD.iPageSize;

                    backgroundWorkerReSkillItems.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 翻页查询技能道具backgroundWorker消息发送
        private void backgroundWorkerReSkillItems_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Item_Skill_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 翻页查询技能道具backgroundWorker消息接收
        private void backgroundWorkerReSkillItems_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdSkillItems, out iPageCount);
        }
        #endregion



        #region 查询标签道具
        private void StickerItems()
        {
            try
            {
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                this.GrdStickerItems.DataSource = null;

                this.pnlStickerItems.Visible = false;
                this.cmbStickerItems.Items.Clear();
                this.pageSticker = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.SD_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = serverIP;

                mContent[1].eName = CEnum.TagName.f_idx;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = userID;

                mContent[2].eName = CEnum.TagName.SD_UserName;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = userName;

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_GD.iPageSize;

                backgroundWorkerStickerItems.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 查询标签道具backgroundWorker消息发送
        private void backgroundWorkerStickerItems_DoWork(object sender, DoWorkEventArgs e)        
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Item_Sticker_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询标签道具backgroundWorker消息接收
        private void backgroundWorkerStickerItems_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdStickerItems, out iPageCount);

            if (iPageCount <= 1)
            {
                this.pnlStickerItems.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    this.cmbStickerItems.Items.Add(i + 1);
                }

                cmbStickerItems.SelectedIndex = 0;
                pageSticker = true;
                pnlStickerItems.Visible = true;
            }
        }
        #endregion



        #region 翻页查询标签道具
        private void cmbStickerItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pageSticker)
                {
                    this.GrpSearch.Enabled = false;
                    this.tbcResult.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                    this.GrdStickerItems.DataSource = null;

                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                    mContent[0].eName = CEnum.TagName.SD_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = serverIP;

                    mContent[1].eName = CEnum.TagName.f_idx;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = userID;

                    mContent[2].eName = CEnum.TagName.SD_UserName;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = userName;

                    mContent[3].eName = CEnum.TagName.Index;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(cmbStickerItems.Text.Trim());

                    mContent[4].eName = CEnum.TagName.PageSize;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = Operation_GD.iPageSize;

                    backgroundWorkerReStickerItems.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 翻页查询标签道具backgroundWorker消息发送
        private void backgroundWorkerReStickerItems_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Item_Sticker_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 翻页查询标签道具backgroundWorker消息接收
        private void backgroundWorkerReStickerItems_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdStickerItems, out iPageCount);
        }
        #endregion

       




        #region 窗体关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 查询综合排名backgroundWorker消息发送
        private void backgroundWorkerComplexRank_DoWork(object sender, DoWorkEventArgs e)
        {
            //lock (typeof(C_Event.CSocketEvent))
            //{
            //    e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_UserRank_query, (CEnum.Message_Body[])e.Argument);
            //}
        }
        #endregion

        #region 查询综合排名backgroundWorker消息接受
        private void backgroundWorkerComplexRank_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            //Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdComplexRank, out iPageCount);

            //if (iPageCount <= 1)
            //{
            //    this.pnlComplexRank.Visible = false;
            //}
            //else
            //{
            //    for (int i = 0; i < iPageCount; i++)
            //    {
            //        this.cmbComplexRank.Items.Add(i + 1);
            //    }

            //    this.cmbComplexRank.SelectedIndex = 0;
            //    pageComplexRank = true;
            //    this.pnlComplexRank.Visible = true;
            //}
        }
        #endregion

        #region
        private void cmbComplexRank_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (pageComplexRank)
            //    {
            //        this.GrpSearch.Enabled = false;
            //        this.tbcResult.Enabled = false;
            //        this.Cursor = Cursors.WaitCursor;//改变鼠标状态
            //        this.GrdComplexRank.DataSource = null;

            //        CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

            //        mContent[0].eName = CEnum.TagName.SD_ServerIP;
            //        mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            //        mContent[0].oContent = Operation_GD.GetItemAddr(mServerInfo, cmbServer.Text);

            //        //mContent[1].eName = CEnum.TagName.f_idx;
            //        //mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            //        //mContent[1].oContent = userID;

            //        //mContent[2].eName = CEnum.TagName.SD_UserName;
            //        //mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            //        //mContent[2].oContent = userName;

            //        mContent[1].eName = CEnum.TagName.Index;
            //        mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            //        mContent[1].oContent = int.Parse(this.cmbComplexRank.Text.Trim());

            //        mContent[2].eName = CEnum.TagName.PageSize;
            //        mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            //        mContent[2].oContent = Operation_GD.iPageSize;

            //        mContent[3].eName = CEnum.TagName.SD_Type;
            //        mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            //        mContent[3].oContent =1;
            //        this.backgroundWorkerReComplexRank.RunWorkerAsync(mContent);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        #endregion

        #region
        private void backgroundWorkerReComplexRank_DoWork(object sender, DoWorkEventArgs e)
        {
            //lock (typeof(C_Event.CSocketEvent))
            //{
            //    e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_UserRank_query, (CEnum.Message_Body[])e.Argument);
            //}
        }
        #endregion

        #region
        private void backgroundWorkerReComplexRank_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            //Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdComplexRank, out iPageCount);
        }
        #endregion

        #region
        private void UserUnitsDetail()
        {
            try
            {
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                //this.GrdUserUnitsDetail.DataSource = null;

                //this.pnlUserUnitsDetail.Visible = false;
                //this.cmbUserUnitsDetail.Items.Clear();
                this.pageUserUnitsDetail = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.SD_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = serverIP;

                mContent[1].eName = CEnum.TagName.f_idx;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = userID;

                mContent[2].eName = CEnum.TagName.SD_UserName;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = userName;

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_GD.iPageSize;

                backgroundWorkerMixTree.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
        #endregion

        private void backgroundWorkerUserUnitsDetail_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Item_Sticker_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerUserUnitsDetail_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            //Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdUserUnitsDetail, out iPageCount);

            //if (iPageCount <= 1)
            //{
            //    this.pnlUserUnitsDetail.Visible = false;
            //}
            //else
            //{
            //    for (int i = 0; i < iPageCount; i++)
            //    {
            //        this.cmbUserUnitsDetail.Items.Add(i + 1);
            //    }

            //    cmbUserUnitsDetail.SelectedIndex = 0;
            //    pageUserUnitsDetail = true;
            //    this.pnlUserUnitsDetail.Visible = true;
            //}
        }

        private void cmbUserUnitsDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (pageUserUnitsDetail)
            //    {
            //        this.GrpSearch.Enabled = false;
            //        this.tbcResult.Enabled = false;
            //        this.Cursor = Cursors.WaitCursor;//改变鼠标状态
            //        this.GrdUserUnitsDetail.DataSource = null;

            //        CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

            //        mContent[0].eName = CEnum.TagName.SD_ServerIP;
            //        mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            //        mContent[0].oContent = serverIP;

            //        mContent[1].eName = CEnum.TagName.f_idx;
            //        mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            //        mContent[1].oContent = userID;

            //        mContent[2].eName = CEnum.TagName.SD_UserName;
            //        mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            //        mContent[2].oContent = userName;

            //        mContent[3].eName = CEnum.TagName.Index;
            //        mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            //        mContent[3].oContent = int.Parse(cmbUnits.Text.Trim());

            //        mContent[4].eName = CEnum.TagName.PageSize;
            //        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            //        mContent[4].oContent = Operation_GD.iPageSize;

            //        this.backgroundWorkerReUserUnitsDetail.RunWorkerAsync(mContent);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void backgroundWorkerReUserUnitsDetail_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Item_Sticker_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReUserUnitsDetail_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            //Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdUserUnitsDetail, out iPageCount);

           
        }

    
        private void backgroundWorkerStraightRanking_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_UserRank_query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerStraightRanking_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            //Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdStraightRanking, out iPageCount);

            //if (iPageCount <= 1)
            //{
            //    this.pnlStraightRanking.Visible = false;
            //}
            //else
            //{
            //    for (int i = 0; i < iPageCount; i++)
            //    {
            //        this.cmbStraightRanking.Items.Add(i + 1);
            //    }

            //    this.cmbStraightRanking.SelectedIndex = 0;
            //    pageStraightRanking = true;
            //    this.pnlStraightRanking.Visible = true;
            //}
        }

        private void backgroundWorkerReStraightRanking_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_UserRank_query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReStraightRanking_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            //Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdStraightRanking, out iPageCount);

           
        }

        private void cmbStraightRanking_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void GrdUnits_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)//双击列名触发
                {
                    selectItem = int.Parse(e.RowIndex.ToString());//保存列
                    if (this.GrdUnits.DataSource != null)
                    {
                        DataTable sTable = (DataTable)GrdUnits.DataSource;
                        itemID =sTable.Rows[selectItem][4].ToString();//保存玩家帐号ID
                        //itemName = sTable.Rows[selectItem][config.ReadConfigValue("GLOBAL", "SD_ItemName")].ToString();
                        //if (itemName == "无道具")
                        //{
                        //    MessageBox.Show(config.ReadConfigValue("MSD", "AI_Hint_NoItemToDelete"));
                        //    return;
                        //}
                        if (MessageBox.Show("是否显示玩家机体装备信息？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            this.GrpSearch.Enabled = false;
                            this.tbcResult.Enabled = false;
                            this.Cursor = Cursors.WaitCursor;//改变鼠标状态

                            CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

                            mContent[0].eName = CEnum.TagName.SD_ServerIP;
                            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                            mContent[0].oContent = serverIP;

                            //mContent[1].eName = CEnum.TagName.UserByID;
                            //mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                            //mContent[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                            mContent[1].eName = CEnum.TagName.f_idx;
                            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                            mContent[1].oContent = userID;

                            mContent[2].eName = CEnum.TagName.SD_UserName;
                            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                            mContent[2].oContent = userName;

                            //mContent[4].eName = CEnum.TagName.SD_ID;
                            //mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                            //mContent[4].oContent = itemID;

                            mContent[3].eName = CEnum.TagName.SD_ItemID;
                            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                            mContent[3].oContent =int.Parse(itemID);

                            //mContent[6].eName = CEnum.TagName.SD_Type;
                            //mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                            //mContent[6].oContent = 1;

                            backgroundWorkerUnitsEquipment.RunWorkerAsync(mContent);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_UnitsItem_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.GrpSearch.Enabled = true;
            this.tbcResult.Enabled = true;
            //this.GrdUnitEquipment.DataSource = null;
            //this.tbcResult.SelectedTab = this.tpgUserUnitsEquipment;
            this.Cursor = Cursors.Default;//改变鼠标状态

            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            //Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdUnitEquipment, out iPageCount);
        }

    }
}