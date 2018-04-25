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
    [C_Global.CModuleAttribute("玩家礼物信息", "FrmGDGiftInfo", "玩家礼物信息", "GD Group")]
    public partial class FrmGDGiftInfo : Form
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

        int SenderID = 0;
        int ReceiverID = 0;
        string SenderName = null;
        string ReceiverName = null;        
        DateTime sendTime;
        string itemName = null;
        int giftID = 0;

        int selectChar = 0;   //GrdCharacter中当前选中的行 
        int selectGift = 0;
        int selectRecv = 0;

        int type=1;

        DateTime startTime;
        DateTime endTime;

        bool pageGiftBase = false;
        bool pageGiftInfo = false;
        bool pageRecvGift = false;

        #endregion

        public FrmGDGiftInfo()
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
            FrmGDGiftInfo mModuleFrm = new FrmGDGiftInfo();
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

            //this.chbRecvOrSend.Text = config.ReadConfigValue("MSD", "GI_UI_chbRecv");
            //this.lblStartTime.Text = config.ReadConfigValue("MSD", "GI_UI_lblStartTime");
            //this.lblEndTime.Text = config.ReadConfigValue("MSD", "GI_UI_lblEndTime");

            //this.tpgCharacter.Text = config.ReadConfigValue("MSD", "UIC_UI_tpgCharacter");

            //this.tpgGiftBase.Text = config.ReadConfigValue("MSD", "GI_UI_tpgGiftBase");
            //this.lblGiftBase.Text = config.ReadConfigValue("MSD", "UIC_UI_lblPage");

            //this.tpgGiftInfo.Text = config.ReadConfigValue("MSD", "GI_UI_tpgGiftInfo");
            //this.lblGiftInfo.Text = config.ReadConfigValue("MSD", "UIC_UI_lblPage");

            //this.tpgRecvGift.Text = config.ReadConfigValue("MSD", "GI_UI_tpgRecvGift");
            //this.lblRecvGift.Text = config.ReadConfigValue("MSD", "UIC_UI_lblPage");

            tbcResult.Enabled = false;
        }
        #endregion



        #region 登陆窗体加载(得到游戏服务器列表)
        private void FrmGDGiftInfo_Load(object sender, EventArgs e)
        {
            try
            {
                IntiFontLib();
                this.lblAccount.Text = "接收人帐号";
                this.lblNick.Text = "接收人昵称";
                this.chbRecvOrSend.Checked = true;
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

        #region 双击玩家基本信息查看礼物信息
        private void GrdCharacter_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)//双击列名触发
                {
                    selectChar = int.Parse(e.RowIndex.ToString());//保存列
                    if (GrdCharacter.DataSource != null)
                    {
                        tbcResult.SelectedTab = tpgGiftBase;
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
                if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MSD", "UIC_UI_tpgCharacter")))
                {
                    this.GrdGiftBase.DataSource = null;
                    this.pnlGiftBase.Visible = false;
                    this.pageGiftBase = false;

                    this.GrdGiftInfo.DataSource = null;
                    this.pnlGiftInfo.Visible = false;
                    this.pageGiftInfo = false;

                    this.GrdRecvGift.DataSource = null;
                    this.pnlRecvGift.Visible = false;
                    this.pageRecvGift = false;
                }
                else
                {
                    if (GrdCharacter.DataSource != null)
                    {
                        DataTable mTable = (DataTable)GrdCharacter.DataSource;
                        userID = int.Parse(mTable.Rows[selectChar][config.ReadConfigValue("GLOBAL", "f_idx")].ToString());//保存玩家帐号ID
                        userName = mTable.Rows[selectChar][config.ReadConfigValue("GLOBAL", "SD_UserName")].ToString();
                        if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MSD", "GI_UI_tpgGiftBase")))
                        {
                            GiftBase();
                        }
                        else
                        {
                            if (GrdGiftBase.DataSource != null)
                            {
                                DataTable sTable = (DataTable)GrdGiftBase.DataSource;
                                SenderID = int.Parse(sTable.Rows[selectGift][config.ReadConfigValue("GLOBAL", "SD_FromIdx")].ToString());
                                ReceiverID = int.Parse(sTable.Rows[selectGift][config.ReadConfigValue("GLOBAL", "SD_ToIdx")].ToString());
                                SenderName = sTable.Rows[selectGift][config.ReadConfigValue("GLOBAL", "SD_FromUser")].ToString();
                                ReceiverName = sTable.Rows[selectGift][config.ReadConfigValue("GLOBAL", "SD_ToUser")].ToString();
                                sendTime = Convert.ToDateTime(sTable.Rows[selectGift][config.ReadConfigValue("GLOBAL", "SD_SendTime")].ToString());
                                if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MSD", "GI_UI_tpgGiftInfo")))
                                {
                                    GiftInfo();
                                }
                                else
                                {
                                    if (GrdGiftInfo.DataSource != null)
                                    {
                                        DataTable nTable = (DataTable)GrdGiftInfo.DataSource;
                                        itemName = nTable.Rows[selectRecv][config.ReadConfigValue("GLOBAL", "SD_ItemID")].ToString() + "|" + nTable.Rows[selectRecv][config.ReadConfigValue("GLOBAL", "SD_ItemID1")].ToString() + "|" + nTable.Rows[selectRecv][config.ReadConfigValue("GLOBAL", "SD_ItemID2")].ToString() + "|" + nTable.Rows[selectRecv][config.ReadConfigValue("GLOBAL", "SD_ItemID3")].ToString() + "|";
                                        giftID = int.Parse(nTable.Rows[selectRecv][config.ReadConfigValue("GLOBAL", "SD_ID")].ToString());
                                        if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MSD", "GI_UI_tpgRecvGift")))
                                        {
                                            RecvGift();
                                        }
                                    }
                                    else
                                    {
                                        this.GrdRecvGift.DataSource = null;
                                        this.pnlRecvGift.Visible = false;
                                        this.pageRecvGift = false;
                                    }
                                }
                            }
                            else
                            {
                                this.GrdGiftInfo.DataSource = null;
                                this.pnlGiftInfo.Visible = false;
                                this.pageGiftInfo = false;

                                this.GrdRecvGift.DataSource = null;
                                this.pnlRecvGift.Visible = false;
                                this.pageRecvGift = false;
                            }
                        }
                    }
                    else
                    {
                        this.GrdGiftBase.DataSource = null;
                        this.pnlGiftBase.Visible = false;
                        this.pageGiftBase = false;

                        this.GrdGiftInfo.DataSource = null;
                        this.pnlGiftInfo.Visible = false;
                        this.pageGiftInfo = false;

                        this.GrdRecvGift.DataSource = null;
                        this.pnlRecvGift.Visible = false;
                        this.pageRecvGift = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion



        #region 选择按照发送人还是接收人进行查询
        private void chbRecvOrSend_CheckedChanged(object sender, EventArgs e)
        {
            if (chbRecvOrSend.Checked)
            {
                this.chbRecvOrSend.Text = config.ReadConfigValue("MSD", "GI_UI_chbRecv");
                type = 2;
                this.lblAccount.Text = "接收人帐号";
                this.lblNick.Text = "接收人昵称";

            }
            else
            {
                this.chbRecvOrSend.Text = config.ReadConfigValue("MSD", "GI_UI_chbSend");
                this.lblAccount.Text = "发送人帐号";
                this.lblNick.Text = "发送人昵称";

            
                type = 1;
                
            }
        }
        #endregion



        #region 玩家礼物基本信息
        private void GiftBase()
        {
            try
            {
                this.GrdGiftBase.DataSource = null;
                this.pnlGiftBase.Visible = false;
                this.cmbGiftBase.Items.Clear();
                this.pageGiftBase = false;

                if (DptStartTime.Value >= DateTime.Now)
                {
                    MessageBox.Show(config.ReadConfigValue("MSD", "GI_Hint_StartTime"));
                    return;
                }

                if (DptEndTime.Value <= DptStartTime.Value)
                {
                    MessageBox.Show(config.ReadConfigValue("MSD", "GI_Hint_TimeSpan"));
                    return;
                }

                if (DptStartTime.Value.AddDays(45) <= DateTime.Now)
                {
                    MessageBox.Show(config.ReadConfigValue("MSD", "GI_Hint_TimeLength"));
                    return;
                }

                startTime = DptStartTime.Value;
                endTime = DptEndTime.Value;


                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态


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

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_GD.iPageSize;

                mContent[5].eName = CEnum.TagName.SD_StartTime;
                mContent[5].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                mContent[5].oContent = startTime;

                mContent[6].eName = CEnum.TagName.SD_EndTime;
                mContent[6].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                mContent[6].oContent = endTime;

                mContent[7].eName = CEnum.TagName.SD_Type;
                mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[7].oContent = type;

                backgroundWorkerGiftBase.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 玩家礼物基本信息backgroundWorker消息发送
        private void backgroundWorkerGiftBase_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_UserGrift_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 玩家礼物基本信息backgroundWorker消息接收
        private void backgroundWorkerGiftBase_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdGiftBase, out iPageCount);

            if (iPageCount <= 1)
            {
                this.pnlGiftBase.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    this.cmbGiftBase.Items.Add(i + 1);
                }

                cmbGiftBase.SelectedIndex = 0;
                pageGiftBase = true;
                pnlGiftBase.Visible = true;
            }
        }
        #endregion



        #region 翻页查询玩家礼物基本信息
        private void cmbGiftBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pageGiftBase)
                {
                    this.GrpSearch.Enabled = false;
                    this.tbcResult.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                    this.GrdGiftBase.DataSource = null;

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

                    mContent[3].eName = CEnum.TagName.Index;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(cmbGiftBase.Text.Trim());

                    mContent[4].eName = CEnum.TagName.PageSize;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = Operation_GD.iPageSize;

                    mContent[5].eName = CEnum.TagName.SD_StartTime;
                    mContent[5].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                    mContent[5].oContent = startTime;

                    mContent[6].eName = CEnum.TagName.SD_EndTime;
                    mContent[6].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                    mContent[6].oContent = endTime;

                    mContent[7].eName = CEnum.TagName.SD_Type;
                    mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[7].oContent = type;

                    backgroundWorkerReGiftBase.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 翻页查询玩家礼物基本信息backgroundWorker消息发送
        private void backgroundWorkerReGiftBase_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_UserGrift_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 翻页查询玩家礼物基本信息backgroundWorker消息接收
        private void backgroundWorkerReGiftBase_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdGiftBase, out iPageCount);
        }
        #endregion



        #region 单击礼物信息保存当前行号
        private void GrdGiftBase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)//单击某一列
                {
                    selectGift = int.Parse(e.RowIndex.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 双击礼物信息查询详细发送信息
        private void GrdGiftBase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)//双击列名触发
                {
                    selectGift = int.Parse(e.RowIndex.ToString());//保存列
                    if (this.GrdGiftBase.DataSource != null)
                    {
                        tbcResult.SelectedTab = tpgGiftInfo;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion



        #region 玩家礼物详细信息
        private void GiftInfo()
        {
            try
            {
                this.GrdGiftInfo.DataSource = null;
                this.pnlGiftInfo.Visible = false;
                this.cmbGiftInfo.Items.Clear();
                this.pageGiftInfo = false;

                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

                mContent[0].eName = CEnum.TagName.SD_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = serverIP;

                mContent[1].eName = CEnum.TagName.SD_ToUser;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = ReceiverName;

                mContent[2].eName = CEnum.TagName.SD_FromUser;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = SenderName;

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_GD.iPageSize;

                mContent[5].eName = CEnum.TagName.SD_FromIdx;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = SenderID;

                mContent[6].eName = CEnum.TagName.SD_ToIdx;
                mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[6].oContent = ReceiverID;

                mContent[7].eName = CEnum.TagName.SD_SendTime;
                mContent[7].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                mContent[7].oContent = sendTime;

                backgroundWorkerGiftInfo.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 玩家礼物详细信息backgroundWorker消息发送
        private void backgroundWorkerGiftInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Grift_FromUser_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 玩家礼物详细信息backgroundWorker消息接收
        private void backgroundWorkerGiftInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdGiftInfo, out iPageCount);

            if (iPageCount <= 1)
            {
                this.pnlGiftInfo.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    this.cmbGiftInfo.Items.Add(i + 1);
                }

                cmbGiftInfo.SelectedIndex = 0;
                pageGiftInfo = true;
                pnlGiftInfo.Visible = true;
            }
        }
        #endregion



        #region 翻页查询玩家礼物详细信息
        private void cmbGiftInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pageGiftInfo)
                {
                    this.GrpSearch.Enabled = false;
                    this.tbcResult.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                    this.GrdGiftInfo.DataSource = null;

                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

                    mContent[0].eName = CEnum.TagName.SD_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = serverIP;

                    mContent[1].eName = CEnum.TagName.SD_ToUser;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = ReceiverName;

                    mContent[2].eName = CEnum.TagName.SD_FromUser;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = SenderName;

                    mContent[3].eName = CEnum.TagName.Index;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(cmbGiftInfo.Text.Trim());

                    mContent[4].eName = CEnum.TagName.PageSize;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = Operation_GD.iPageSize;

                    mContent[5].eName = CEnum.TagName.SD_FromIdx;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = SenderID;

                    mContent[6].eName = CEnum.TagName.SD_ToIdx;
                    mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[6].oContent = ReceiverID;

                    mContent[7].eName = CEnum.TagName.SD_SendTime;
                    mContent[7].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                    mContent[7].oContent = sendTime;

                    backgroundWorkerReGiftInfo.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 翻页查询玩家礼物详细信息backgroundWorker消息发送
        private void backgroundWorkerReGiftInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Grift_FromUser_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 翻页查询玩家礼物详细信息backgroundWorker消息接收
        private void backgroundWorkerReGiftInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdGiftInfo, out iPageCount);
        }
        #endregion



        #region 单击发送礼物信息保存当前行号
        private void GrdGiftInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)//单击某一列
                {
                    selectRecv = int.Parse(e.RowIndex.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 双击发送礼物信息查询接收礼物信息
        private void GrdGiftInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)//双击列名触发
                {
                    selectRecv = int.Parse(e.RowIndex.ToString());//保存列
                    if (this.GrdGiftInfo.DataSource != null)
                    {
                        tbcResult.SelectedTab = tpgRecvGift;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion



        #region 接收礼物详细信息
        private void RecvGift()
        {
            try
            {
                this.GrdRecvGift.DataSource = null;
                this.pnlRecvGift.Visible = false;
                this.cmbRecvGift.Items.Clear();
                this.pageRecvGift = false;

                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[10];

                mContent[0].eName = CEnum.TagName.SD_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = serverIP;

                mContent[1].eName = CEnum.TagName.SD_ToUser;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = ReceiverName;

                mContent[2].eName = CEnum.TagName.SD_FromUser;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = SenderName;

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_GD.iPageSize;

                mContent[5].eName = CEnum.TagName.SD_FromIdx;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = SenderID;

                mContent[6].eName = CEnum.TagName.SD_ToIdx;
                mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[6].oContent = ReceiverID;

                mContent[7].eName = CEnum.TagName.SD_SendTime;
                mContent[7].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                mContent[7].oContent = sendTime;

                mContent[8].eName = CEnum.TagName.SD_ItemName;
                mContent[8].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[8].oContent = itemName;

                mContent[9].eName = CEnum.TagName.SD_ID;
                mContent[9].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[9].oContent = giftID;

                backgroundWorkerRecvGift.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 接收礼物详细信息backgroundWorker消息发送
        private void backgroundWorkerRecvGift_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Grift_ToUser_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 接收礼物详细信息backgroundWorker消息接收
        private void backgroundWorkerRecvGift_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdRecvGift, out iPageCount);

            if (iPageCount <= 1)
            {
                this.pnlRecvGift.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    this.cmbRecvGift.Items.Add(i + 1);
                }

                cmbRecvGift.SelectedIndex = 0;
                pageRecvGift = true;
                pnlRecvGift.Visible = true;
            }
        }
        #endregion



        #region 翻页查询接收礼物详细信息
        private void cmbRecvGift_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pageRecvGift)
                {
                    this.GrpSearch.Enabled = false;
                    this.tbcResult.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                    this.GrdRecvGift.DataSource = null;

                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[10];

                    mContent[0].eName = CEnum.TagName.SD_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = serverIP;

                    mContent[1].eName = CEnum.TagName.SD_ToUser;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = ReceiverName;

                    mContent[2].eName = CEnum.TagName.SD_FromUser;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = SenderName;

                    mContent[3].eName = CEnum.TagName.Index;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(cmbRecvGift.Text.Trim());

                    mContent[4].eName = CEnum.TagName.PageSize;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = Operation_GD.iPageSize;

                    mContent[5].eName = CEnum.TagName.SD_FromIdx;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = SenderID;

                    mContent[6].eName = CEnum.TagName.SD_ToIdx;
                    mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[6].oContent = ReceiverID;

                    mContent[7].eName = CEnum.TagName.SD_SendTime;
                    mContent[7].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                    mContent[7].oContent = sendTime;

                    mContent[8].eName = CEnum.TagName.SD_ItemName;
                    mContent[8].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[8].oContent = itemName;

                    mContent[9].eName = CEnum.TagName.SD_ID;
                    mContent[9].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[9].oContent = giftID;

                    backgroundWorkerReRecvGift.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 翻页查询接收礼物详细信息backgroundWorker消息发送
        private void backgroundWorkerReRecvGift_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Grift_ToUser_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 翻页查询接收礼物详细信息backgroundWorker消息接收
        private void backgroundWorkerReRecvGift_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdRecvGift, out iPageCount);
        }
        #endregion



        #region 窗体关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 
    }
}