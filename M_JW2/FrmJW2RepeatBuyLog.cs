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
    [C_Global.CModuleAttribute("重复购买道具退款", "FrmJW2RepeatBuyItem", "重复购买道具退款", "JW2 Group")]
    public partial class FrmJW2RepeatBuyItem : Form
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
        int selectChar = 0;
        int selectChar2 = 0;//GrdCharacter中当前选中的行 
        int selectItem = 0;

        string itemID = null;
        bool pageRoleView = false;
        bool pagePetInfo = false;
        bool pageRepeatBuyItem = false;
        string userPet = null;
        string userPetSn = null;
        string userBuySN = null;
        string userItemName = null;
        string userCash = null;
        string userLimit = null;
        #endregion

        public FrmJW2RepeatBuyItem()
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
            FrmJW2RepeatBuyItem mModuleFrm = new FrmJW2RepeatBuyItem();
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

            LblDate.Text = config.ReadConfigValue("MJW2", "NEWNEW_UI_BeginTime");
            LblLink.Text = config.ReadConfigValue("MJW2", "NEW_UI_EndTime");

            this.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2RepeatBuyLog");
            this.tpgCharacter.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmBugleSendLogtpgCharacter");
            this.tpgBuyLog.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgBuyLog");
            //this.tpgCharacter.Text = config.ReadConfigValue("MSD", "UIC_UI_tpgCharacter");

            lblRoleView.Text= config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            lblRepeatBuyItem.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            //label6 = config.ReadConfigValue("MJW2", "NEW_UI_tpgBuyLog");
            label6.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneytype");
            label3.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2RepeatBuyLogTip");
            tbcResult.Enabled = true;
        }
        #endregion



        #region 登陆窗体加载(得到游戏服务器列表)
        private void FrmJW2RepeatBuyLog_Load(object sender, EventArgs e)
        {
            try
            {
                IntiFontLib();
                this.comboBox2.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneySender"));
                this.comboBox2.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyReceiver"));
                this.comboBox2.SelectedIndex = 0;

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
                if (GrdRoleView.DataSource != null)
                {
                    DataTable mTable = (DataTable)GrdRoleView.DataSource;
                    serverIP = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);
                    userID = int.Parse(mTable.Rows[selectChar][config.ReadConfigValue("GLOBAL", "JW2_UserSN")].ToString());//保存玩家帐号ID
                    userName = mTable.Rows[selectChar][config.ReadConfigValue("GLOBAL", "JW2_UserID")].ToString();

                    if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_tpgBuyLog")))
                    {
                        this.GrdRepeatBuyItem.DataSource = null;

                        BuyItemInfo();//查询重复购买道具信息
                    }
                 

                }

                else
                {
                    //GrdPet.DataSource = null;
                    //pnlPet.Visible = false;





                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BuyItemInfo()
        {
            try
            {
                this.btnSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.GrdRepeatBuyItem.DataSource = null;
                Cursor = Cursors.WaitCursor;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[9];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, this.cmbServer.Text);

                mContent[1].eName = CEnum.TagName.JW2_ServerName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = this.cmbServer.Text.ToString();

                mContent[2].eName = CEnum.TagName.JW2_UserSN;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = userID;

                if (comboBox2.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneySender"))
                {
                    mContent[8].eName = CEnum.TagName.JW2_Type;
                    mContent[8].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[8].oContent = 1;
                }
                else if (comboBox2.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyReceiver"))
                {
                    mContent[8].eName = CEnum.TagName.JW2_Type;
                    mContent[8].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[8].oContent = 2;
                }

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_JW2.iPageSize;

              
                mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = 2;
           
              

                mContent[6].eName = CEnum.TagName.BeginTime;
                mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[6].oContent = DtpBegin.Text.ToString();

                mContent[7].eName = CEnum.TagName.EndTime;
                mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[7].oContent = DtpEnd.Text.ToString();
                this.backgroundWorkerBuyItemInfo.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        
        
        }

        private void cmbRepeatBuyItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pageRepeatBuyItem)
                {

                    this.btnSearch.Enabled = false;
                    this.tbcResult.Enabled = false;
                    this.GrdRepeatBuyItem.DataSource = null;
                    Cursor = Cursors.WaitCursor;


                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[9];

                    mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, this.cmbServer.Text);

                    mContent[1].eName = CEnum.TagName.JW2_ServerName;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = this.cmbServer.Text.ToString();

                    mContent[2].eName = CEnum.TagName.JW2_UserSN;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = userID;

                    if (comboBox2.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneySender"))
                    {
                        mContent[8].eName = CEnum.TagName.JW2_Type;
                        mContent[8].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[8].oContent = 1;
                    }
                    else if (comboBox2.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyReceiver"))
                    {
                        mContent[8].eName = CEnum.TagName.JW2_Type;
                        mContent[8].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[8].oContent = 2;
                    }


                    mContent[3].eName = CEnum.TagName.Index;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(this.cmbRepeatBuyItem.Text.ToString());

                    mContent[4].eName = CEnum.TagName.PageSize;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = Operation_JW2.iPageSize;

                  
                    mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = 2;
                  
                    mContent[6].eName = CEnum.TagName.BeginTime;
                    mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[6].oContent = DtpBegin.Text.ToString();

                    mContent[7].eName = CEnum.TagName.EndTime;
                    mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[7].oContent = DtpEnd.Text.ToString();



                    this.backgroundWorkerReBuyItemInfo.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pageRepeatBuyItem)
                {

                    this.btnSearch.Enabled = false;
                    this.tbcResult.Enabled = false;
                    this.GrdRepeatBuyItem.DataSource = null;
                    Cursor = Cursors.WaitCursor;


                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[9];

                    mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, this.cmbServer.Text);

                    mContent[1].eName = CEnum.TagName.JW2_ServerName;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = cmbServer.Text.ToString();

                    mContent[2].eName = CEnum.TagName.JW2_UserSN;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = userID;

                    if (comboBox2.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneySender"))
                    {
                        mContent[8].eName = CEnum.TagName.JW2_Type;
                        mContent[8].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[8].oContent = 1;
                    }
                    else if (comboBox2.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyReceiver"))
                    {
                        mContent[8].eName = CEnum.TagName.JW2_Type;
                        mContent[8].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[8].oContent = 2;
                    }


                    mContent[3].eName = CEnum.TagName.Index;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(this.cmbRepeatBuyItem.Text.ToString());

                    mContent[4].eName = CEnum.TagName.PageSize;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = Operation_JW2.iPageSize;

                   
                    mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = 2;
                 

                    mContent[6].eName = CEnum.TagName.BeginTime;
                    mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[6].oContent = DtpBegin.Text.ToString();

                    mContent[7].eName = CEnum.TagName.EndTime;
                    mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[7].oContent = DtpEnd.Text.ToString();



                    this.backgroundWorkerReBuyItemInfo.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void backgroundWorkerBuyItemInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_MoneyLog_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerBuyItemInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.btnSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                Cursor = Cursors.Default;
                int pg = 0;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                else
                {

                    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdRepeatBuyItem, out iPageCount);
                }
                //if (iPageCount <= 1)
                //{
                //    this.pnlFamilyDonationLog.Visible = false;
                //}
                //else
                //{
                for (int i = 0; i < iPageCount; i++)
                {
                    this.cmbRepeatBuyItem.Items.Add(i + 1);
                }

                this.cmbRepeatBuyItem.SelectedIndex = 0;
                this.pageRepeatBuyItem = true;
                this.pnlRepeatBuyItem.Visible = true;
                //}

            }
            catch
            {

            }
        }

        private void backgroundWorkerReBuyItemInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_MoneyLog_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReBuyItemInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.btnSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                Cursor = Cursors.Default;
                int pg = 0;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                else
                {

                    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, this.GrdRepeatBuyItem, out iPageCount);
                }
               
            }
            catch
            {

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GrdRepeatBuyItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (GrdRepeatBuyItem.DataSource != null)
                {
                    DataTable mTable1 = (DataTable)GrdRepeatBuyItem.DataSource;
                    serverIP = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);
                    //userID = int.Parse(mTable1.Rows[selectChar][config.ReadConfigValue("GLOBAL", "JW2_UserSN")].ToString());//保存玩家帐号ID
                    //userName = mTable1.Rows[selectChar][config.ReadConfigValue("GLOBAL", "JW2_UserID")].ToString();
                    userBuySN = mTable1.Rows[selectChar2][0].ToString();
                    userItemName = mTable1.Rows[selectChar2][7].ToString();
                    userCash = mTable1.Rows[selectChar2][9].ToString();
                    userLimit = mTable1.Rows[selectChar2][8].ToString();
                }
                if (MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_BuyItemReback"), config.ReadConfigValue("MJW2", "NEW_UI_BuyItemRebacktitle"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                
                {

                    if (userLimit != config.ReadConfigValue("MJW2", "NEW_UI_BuyItemRebackPermanent"))
                    {
                        MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_NoPermanentItemReback"));
                        return;

                    }
                    else
                    {
                        this.GrpSearch.Enabled = false;
                        this.tbcResult.Enabled = false;
                        this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                        //DataTable mTable1 = (DataTable)GrdRepeatBuyItem.DataSource;
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

                        mContent[5].eName = CEnum.TagName.JW2_BUYSN;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = int.Parse(userBuySN);


                        mContent[6].eName = CEnum.TagName.JW2_ItemName;
                        mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[6].oContent = userItemName;

                        mContent[7].eName = CEnum.TagName.JW2_Cash;
                        mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[7].oContent = int.Parse(userCash);


                        mContent[8].eName = CEnum.TagName.UserByID;
                        mContent[8].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[8].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                        //mContent[7].eName = CEnum.TagName.JW2_AvatarItemName;
                        //mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                        //mContent[7].oContent = mTable1.Rows[selectChar2][2].ToString();

                        //mContent[8].eName = CEnum.TagName.JW2_AvatarItem;
                        //mContent[8].eTag = CEnum.TagFormat.TLV_INTEGER;
                        //mContent[8].oContent = int.Parse(mTable1.Rows[selectChar2][1].ToString());

                        this.backgroundWorkerRepeatBuyLogDel.RunWorkerAsync(mContent);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorkerRepeatBuyLogDel_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_AgainBuy_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerRepeatBuyLogDel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                    this.btnSearch_Click(null, null);
                    return;
                }
                else if (mResult[0, 0].oContent.ToString() == "SCUESS")
                {
                    MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_ControlSuccess"));
                    this.btnSearch_Click(null, null);
                    return;
                }
                else
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                }
                this.btnSearch_Click(null, null);
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
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态

                //this.pageStoryState = false;

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
                this.tbcResult.SelectedIndex = 0;
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

        private void GrdRoleView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectChar = e.RowIndex;
            this.tbcResult.SelectedIndex = 1;
        }

        private void GrdRepeatBuyItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectChar2 = e.RowIndex;
        }

    }
}