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
    [C_Global.CModuleAttribute("M币消费记录", "FrmJW2MMoney", "M币消费记录", "JW2 Group")]
    public partial class FrmJW2MMoney : Form
    {
        #region 变量
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private CEnum.Message_Body[,] mResult = null;
        private CEnum.Message_Body[,] mItemResult = null;
        private int RolePage = 0;
        private int RoleIndex = 0;
        private int iIndexID = 0;
        private bool RoleFirst = false;
        private int iPageCount = 0;
        private bool bFirst = false;
        private int uid;
        private string gradename;
        private int currDgSelectRow;
        private bool pageRoleView;
        private bool pageFamilyDonationLog;
        private bool pageFamilyConsumerLog;
        private string FamilyID;
        private string serverIP;
        private string userName;
        private int userID;
         
        DataTable dgTable = new DataTable();

        private bool pageConsumerType = false;
        #endregion

        public FrmJW2MMoney()
        {
            InitializeComponent();
        }

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
            //this.GrpSearch.Text = config.ReadConfigValue("MSDO", "AF_UI_GrpSearch");
            //this.LblServer.Text = config.ReadConfigValue("MSDO", "AF_UI_LblServer");
            //this.BtnSearch.Text = config.ReadConfigValue("MSDO", "AF_UI_BtnSearch");
            this.GrpSearch.Text = config.ReadConfigValue("MSD", "UIC_UI_GrpSearch");
            this.LblServer.Text = config.ReadConfigValue("MSD", "UIC_UI_lblServer");
            this.lblAccount.Text = config.ReadConfigValue("MSD", "UIC_UI_lblAccount");
            this.lblNick.Text = config.ReadConfigValue("MSD", "UIC_UI_lblNick");
            this.BtnSearch.Text = config.ReadConfigValue("MSD", "UIC_UI_btnSearch");
            this.button1.Text = config.ReadConfigValue("MSD", "UIC_UI_btnClose");
            LblDate.Text = config.ReadConfigValue("MJW2", "NEWNEW_UI_BeginTime");
            LblLink.Text = config.ReadConfigValue("MJW2", "NEW_UI_EndTime");

            this.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoney");


            tpgCharacter.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmBugleSendLogtpgCharacter");

            tpgFamilyDonationLog.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyMoneyLog");
            this.tpgFamilyDonationLog.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyConsumerLog");

            label1.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");

            label2.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");

            label3.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");

            button3.Text = config.ReadConfigValue("MJW2", "UIC_UI_btnSearch");
            checkBox2.Text = config.ReadConfigValue("MJW2", "NEW_UI_QueryByItemName");

            label6.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneytype");

            label5.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyMoneytype");

            lblHint.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneytip");
            //this.GrpResult.Text = config.ReadConfigValue("MSDO", "AF_UI_GrpResult");
        }


        #endregion

        #region 创建窗体
        /// <summary>
        /// 创建类库中的窗体
        /// </summary>
        /// <param name="oParent">MDI 程序的父窗体</param>
        /// <param name="oSocket">Socket</param>
        /// <returns>类库中的窗体</returns>
        public Form CreateModule(object oParent, object oEvent)
        {
            //创建登录窗体
            FrmJW2MMoney mModuleFrm = new FrmJW2MMoney();
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

        #region 登陆窗体加载(得到游戏服务器列表)
        private void FrmJW2MMoney_Load(object sender, EventArgs e)
        {
            try
            {
                this.cmbMoneyType.Items.Clear();
                this.cmbMoneyType.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyAll"));//mapleM幣和G幣
                this.cmbMoneyType.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyMMoney"));
                this.cmbMoneyType.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyGMoney"));
                //maple add
                this.cmbMoneyType.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyGoldMoney"));

                this.cmbMoneyType.SelectedIndex = 0;

                this.comboBox1.Items.Clear();
                //this.comboBox1.Items.Add("喂养宠物");
                //this.comboBox1.Items.Add("进化宠物");
                //this.comboBox1.Items.Add("买动作");
                //this.comboBox1.Items.Add("信纸");
                //this.comboBox1.Items.Add("创建家族");
                //this.comboBox1.Items.Add("换肤色");
                //this.comboBox1.Items.Add("中间件");
                //this.comboBox1.Items.Add("DIY衣服");
                //this.comboBox1.Items.Add("素材兑换");

                this.comboBox1.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyPet"));
                this.comboBox1.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyPetConvert"));
                this.comboBox1.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyPetBuyAction"));
                this.comboBox1.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyStationery"));
                this.comboBox1.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneySendMail"));
                this.comboBox1.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyInterface"));
                this.comboBox1.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyMakeup"));
                this.comboBox1.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneydiy"));
                this.comboBox1.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneymbExchangematerial"));
                this.comboBox1.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyWeddingBook"));
                this.comboBox1.SelectedIndex = 0;

                this.comboBox2.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneySender"));
                this.comboBox2.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyReceiver"));

                this.comboBox2.SelectedIndex = 0;



                IntiFontLib();
                //this.cmbMoneyType.Items.Clear();

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
                mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = 1;

                mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = m_ClientEvent.GetInfo("GameID_JW2");

                this.backgroundWorkerFormLoad.RunWorkerAsync(mContent);
            }
            catch
            { }
        }
        #endregion

        #region 窗体服务器列表backgroundWorker消息发送
        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mServerInfo = Operation_JW2.GetServerList(this.m_ClientEvent, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 窗体服务器列表backgroundWorker消息接收
        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbServer = Operation_JW2.BuildCombox(mServerInfo, CmbServer);
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text));
        }
        #endregion



        #region 查询家族信息
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.cmbFamilyDonationLog.Items.Clear();
                this.cmbFamilyConsumerLog.Items.Clear();
                this.cmbRoleView.Items.Clear();
                this.tbcResult.SelectedIndex = 0;
                /*
                 * 清除上一次显示的内容
                 */
                if (CmbServer.Text == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "LO_Code_Msg1"));
                    return;
                }

                BtnSearch.Enabled = false;
                Cursor = Cursors.WaitCursor;
                RoleInfoView.DataSource = null;
                GrdFamilyDonationLog.DataSource = null;
                GrdFamilyConsumerLog.DataSource = null;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, this.CmbServer.Text);

                mContent[1].eName = CEnum.TagName.JW2_ServerName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = this.CmbServer.Text.ToString();

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


                tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text));

 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
        #endregion

        #region 查询家族信息backgroundWorker消息发送
        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_ACCOUNT_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询家族信息backgroundWorker消息接收
        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
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

                    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, RoleInfoView, out iPageCount);
                }
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
            catch
            {

            }
        }
        #endregion



        #region 切换游戏服务器
        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text));
        }
        #endregion



        #region 关闭窗体
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

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
                BtnSearch.Enabled = true;
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

                    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdRoleView, out iPageCount);
                }
                
            }
            catch
            {

            }
        }

        private void backgroundWorkerFamilyDonationLog_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_MoneyLog_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerFamilyDonationLog_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
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

                    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdFamilyDonationLog, out iPageCount);
                }
                //if (iPageCount <= 1)
                //{
                //    this.pnlFamilyDonationLog.Visible = false;
                //}
                //else
                //{
                    for (int i = 0; i < iPageCount; i++)
                    {
                        this.cmbFamilyDonationLog.Items.Add(i + 1);
                    }

                    this.cmbFamilyDonationLog.SelectedIndex = 0;
                    this.pageFamilyDonationLog = true;
                    this.pnlFamilyDonationLog.Visible = true;
                //}

            }
            catch
            {

            }
        }

        private void backgroundWorkerReFamilyDonationLog_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_MoneyLog_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReFamilyDonationLog_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
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

                    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdFamilyDonationLog, out iPageCount);
                }
               

            }
            catch
            {

            }
        }

        private void backgroundWorkerFamilyConsumerLog_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_CashMoney_Log, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerFamilyConsumerLog_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
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

                    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdFamilyConsumerLog, out iPageCount);
                }
                //if (iPageCount <= 1)
                //{
                //    this.pnlFamilyConsumerLog.Visible = false;
                //}
                //else
                //{
                this.cmbFamilyConsumerLog.Items.Clear();
                    for (int i = 0; i < iPageCount; i++)
                    {
                        this.cmbFamilyConsumerLog.Items.Add(i + 1);
                    }

                    this.cmbFamilyConsumerLog.SelectedIndex = 0;
                    this.pageFamilyConsumerLog = true;
                    this.pnlFamilyDonationLog.Visible = true;
                //}

            }
            catch
            {

            }
        }

        private void backgroundWorkerReFamilyConsumerLog_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_CashMoney_Log, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReFamilyConsumerLog_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
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

                    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdFamilyConsumerLog, out iPageCount);
                }
               
            }
            catch
            {

            }
        }

        private void tbcResult_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
         
                GrdFamilyDonationLog.DataSource = null;
                GrdFamilyConsumerLog.DataSource = null;
                if (RoleInfoView.DataSource != null)
                {
                    DataTable mTable = (DataTable)RoleInfoView.DataSource;
                    serverIP = Operation_JW2.GetItemAddr(mServerInfo, this.CmbServer.Text);
                    userID = int.Parse(mTable.Rows[currDgSelectRow][config.ReadConfigValue("GLOBAL", "JW2_UserSN")].ToString());//保存玩家帐号ID
                    userName = mTable.Rows[currDgSelectRow][config.ReadConfigValue("GLOBAL", "JW2_UserID")].ToString();



                }
                if (this.tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyMoneyLog")))
                {
                    checkBox2.Checked = false;
                    this.cmbFamilyDonationLog.Items.Clear();
                    this.cmbFamilyConsumerLog.Items.Clear();
                    FamilyDonationLog();//查詢家族成員資訊
                }
                else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyConsumerLog")))
                {

                    this.cmbFamilyDonationLog.Items.Clear();

                    FamilyConsumerLog();//查詢基地資訊
                    this.pageConsumerType = true;

                }
              



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void FamilyDonationLog()
        {
            try
            {
                BtnSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                GrdFamilyDonationLog.DataSource = null;
                Cursor = Cursors.WaitCursor;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[10];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.JW2_ServerName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = CmbServer.Text.ToString();

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

                if (this.cmbMoneyType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyAll"))//M幣和G幣
                {
                    mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = 1;
                }
                else if (this.cmbMoneyType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyMMoney"))
                {
                    mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = 2;
                }
                else if (this.cmbMoneyType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyGMoney"))
                {
                    mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = 3;
                }
                //maple add
                else if (this.cmbMoneyType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyGoldMoney"))
                {
                    mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = 4;//maple temp define
                }

                mContent[6].eName = CEnum.TagName.BeginTime;
                mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[6].oContent = DtpBegin.Text.ToString();

                mContent[7].eName = CEnum.TagName.EndTime;
                mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[7].oContent = DtpEnd.Text.ToString();

                mContent[9].eName = CEnum.TagName.JW2_ItemName;
                mContent[9].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[9].oContent = textBox1.Text.ToString();
                this.backgroundWorkerFamilyDonationLog.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        
        }

        private void FamilyConsumerLog()
        {

            try
            {
                BtnSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.GrdFamilyConsumerLog.DataSource = null;
                Cursor = Cursors.WaitCursor;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[9];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.JW2_ServerName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = CmbServer.Text.ToString();

                mContent[2].eName = CEnum.TagName.JW2_UserSN;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = userID;


                mContent[8].eName = CEnum.TagName.JW2_UserID;
                mContent[8].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[8].oContent = userName;


                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_JW2.iPageSize;




                if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyPet"))
                {
                    mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = 0;
                }
                else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyPetConvert"))
                {
                    mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = 1;
                }
                else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyPetBuyAction"))
                {
                    mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = 2;
                }
                else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyStationery"))
                {
                    mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = 3;
                }
                else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneySendMail"))
                {
                    mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = 4;
                }
                else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyMakeup"))
                {
                    mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = 7;
                }
                else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyInterface"))
                {
                    mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = 6;
                }
                else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneydiy"))
                {
                    mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = 8;
                }
                else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneymbExchangematerial"))
                {
                    mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = 9;
                }

                else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyWeddingBook"))
                {
                    mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = 15;
                }

                mContent[6].eName = CEnum.TagName.BeginTime;
                mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[6].oContent = DtpBegin.Text.ToString();

                mContent[7].eName = CEnum.TagName.EndTime;
                mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[7].oContent = DtpEnd.Text.ToString();

               
                this.backgroundWorkerFamilyConsumerLog.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

        private void cmbFamilyDonationLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pageFamilyDonationLog)
                {

                    BtnSearch.Enabled = false;
                    this.tbcResult.Enabled = false;
                    GrdFamilyDonationLog.DataSource = null;
                    Cursor = Cursors.WaitCursor;


                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[10];

                    mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.JW2_ServerName;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = CmbServer.Text.ToString();

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
                    mContent[3].oContent = int.Parse(this.cmbFamilyDonationLog.Text.ToString());

                    mContent[4].eName = CEnum.TagName.PageSize;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = Operation_JW2.iPageSize;

                    if (this.cmbMoneyType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyAll"))//M幣和G幣
                    {
                        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 1;
                    }
                    else if (this.cmbMoneyType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyMMoney"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 2;
                    }
                    else if (this.cmbMoneyType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyGMoney"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 3;
                    }
                    //maple add
                    else if (this.cmbMoneyType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyGoldMoney"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 4;//maple temp define
                    }



                    mContent[6].eName = CEnum.TagName.BeginTime;
                    mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[6].oContent = DtpBegin.Text.ToString();

                    mContent[7].eName = CEnum.TagName.EndTime;
                    mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[7].oContent = DtpEnd.Text.ToString();


                    mContent[9].eName = CEnum.TagName.JW2_ItemName;
                    mContent[9].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[9].oContent = textBox1.Text.ToString();
                    this.backgroundWorkerReFamilyDonationLog.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void cmbFamilyConsumerLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pageFamilyConsumerLog)
                {

                    BtnSearch.Enabled = false;
                    this.tbcResult.Enabled = false;
                    this.GrdFamilyConsumerLog.DataSource = null;
                    Cursor = Cursors.WaitCursor;
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[9];

                    mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.JW2_ServerName;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = CmbServer.Text.ToString();

                    mContent[2].eName = CEnum.TagName.JW2_UserSN;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = userID;

                    mContent[8].eName = CEnum.TagName.JW2_UserID;
                    mContent[8].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[8].oContent = userName;

                    mContent[3].eName = CEnum.TagName.Index;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(this.cmbFamilyConsumerLog.Text.ToString());


                    mContent[4].eName = CEnum.TagName.PageSize;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = Operation_JW2.iPageSize;

                    if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyPet"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 0;
                    }
                    else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyPetConvert"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 1;
                    }
                    else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyPetBuyAction"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 2;
                    }
                    else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyStationery"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 3;
                    }
                    else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneySendMail"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 4;
                    }



                    else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyInterface"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 6;
                    }
                    else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyMakeup"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 7;
                    }
                    else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneydiy"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 8;
                    }
                    else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneymbExchangematerial"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 9;
                    }


                    mContent[6].eName = CEnum.TagName.BeginTime;
                    mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[6].oContent = DtpBegin.Text.ToString();

                    mContent[7].eName = CEnum.TagName.EndTime;
                    mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[7].oContent = DtpEnd.Text.ToString();

                 

                    this.backgroundWorkerReFamilyConsumerLog.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void cmbRoleView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (pageRoleView)
                {


                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                    mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, this.CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.JW2_ServerName;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = CmbServer.Text.ToString();

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void RoleInfoView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currDgSelectRow = e.RowIndex;
            
          
        }

        private void RoleInfoView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            currDgSelectRow = e.RowIndex;
            this.tbcResult.SelectedIndex = 1;
        }

        private void cmbMoneyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pageFamilyDonationLog)
                {



                    BtnSearch.Enabled = false;
                    this.tbcResult.Enabled = false;
                    GrdFamilyDonationLog.DataSource = null;
                    Cursor = Cursors.WaitCursor;
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[10];

                    mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.JW2_ServerName;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = CmbServer.Text.ToString();

                    mContent[2].eName = CEnum.TagName.JW2_UserSN;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = userID;

                    mContent[3].eName = CEnum.TagName.Index;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(this.cmbFamilyDonationLog.Text.ToString());

                    mContent[4].eName = CEnum.TagName.PageSize;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = Operation_JW2.iPageSize;

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

                    mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    if (this.cmbMoneyType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyAll"))//M幣和G幣
                    {
                        mContent[5].oContent = 1;
                    }
                    else if (this.cmbMoneyType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyMMoney"))
                    {

                        mContent[5].oContent = 2;
                    }
                    else if (this.cmbMoneyType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyGMoney"))
                    {

                        mContent[5].oContent = 3;
                    }
                    //maple
                    else if (this.cmbMoneyType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyGoldMoney"))
                    {
                        mContent[5].oContent = 4;//maple temp define
                    }



                    mContent[6].eName = CEnum.TagName.BeginTime;
                    mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[6].oContent = DtpBegin.Text.ToString();

                    mContent[7].eName = CEnum.TagName.EndTime;
                    mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[7].oContent = DtpEnd.Text.ToString();


                    mContent[9].eName = CEnum.TagName.JW2_ItemName;
                    mContent[9].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[9].oContent = textBox1.Text.ToString();
                    this.backgroundWorkerReFamilyDonationLog.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pageConsumerType)
                {


                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[9];

                    mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.JW2_ServerName;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = CmbServer.Text.ToString();

                    mContent[2].eName = CEnum.TagName.JW2_UserSN;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = userID;

                    mContent[8].eName = CEnum.TagName.JW2_UserID;
                    mContent[8].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[8].oContent = userName;

                    mContent[3].eName = CEnum.TagName.Index;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = 1;


                    mContent[4].eName = CEnum.TagName.PageSize;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = Operation_JW2.iPageSize;

                    if (this.comboBox1.Text.ToString() ==  config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyPet"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 0;
                    }
                    else if (this.comboBox1.Text.ToString() ==  config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyPetConvert"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 1;
                    }
                    else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyPetBuyAction"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 2;
                    }
                    else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyStationery"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 3;
                    }
                    else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneySendMail"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 4;
                    }

                    else if (this.comboBox1.Text.ToString() ==  config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyInterface"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 6;
                    }
                    else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyMakeup"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 7;
                    }
                    else if (this.comboBox1.Text.ToString() ==  config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneydiy"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 8;
                    }
                    else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneymbExchangematerial"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 9;
                    }
                    else if (this.comboBox1.Text.ToString() ==  config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyWeddingBook"))
                    {
                        mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = 15;
                    }


                    mContent[6].eName = CEnum.TagName.BeginTime;
                    mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[6].oContent = DtpBegin.Text.ToString();

                    mContent[7].eName = CEnum.TagName.EndTime;
                    mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[7].oContent = DtpEnd.Text.ToString();


                    this.backgroundWorkerFamilyConsumerLog.RunWorkerAsync(mContent);
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
                if (pageFamilyDonationLog)
                {



                    BtnSearch.Enabled = false;
                    this.tbcResult.Enabled = false;
                    GrdFamilyDonationLog.DataSource = null;
                    Cursor = Cursors.WaitCursor;
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[10];

                    mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.JW2_ServerName;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = CmbServer.Text.ToString();

                    mContent[2].eName = CEnum.TagName.JW2_UserSN;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = userID;

                    mContent[3].eName = CEnum.TagName.Index;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(this.cmbFamilyDonationLog.Text.ToString());

                    mContent[4].eName = CEnum.TagName.PageSize;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = Operation_JW2.iPageSize;


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

                    mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    if (this.cmbMoneyType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyAll"))//M幣和G幣
                    {
                        mContent[5].oContent = 1;
                    }
                    else if (this.cmbMoneyType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyMMoney"))
                    {

                        mContent[5].oContent = 2;
                    }
                    else if (this.cmbMoneyType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyGMoney"))
                    {

                        mContent[5].oContent = 3;
                    }
                    //maple add
                    else if (this.cmbMoneyType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyGoldMoney"))
                    {
                        mContent[5].oContent = 4;
                    }



                    mContent[6].eName = CEnum.TagName.BeginTime;
                    mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[6].oContent = DtpBegin.Text.ToString();

                    mContent[7].eName = CEnum.TagName.EndTime;
                    mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[7].oContent = DtpEnd.Text.ToString();

                    mContent[9].eName = CEnum.TagName.JW2_ItemName;
                    mContent[9].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[9].oContent = textBox1.Text.ToString();

                    this.backgroundWorkerReFamilyDonationLog.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                BtnSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                GrdFamilyDonationLog.DataSource = null;
                Cursor = Cursors.WaitCursor;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[10];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.JW2_ServerName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = CmbServer.Text.ToString();

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

                if (this.cmbMoneyType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyAll"))//M幣和G幣
                {
                    mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = 1;
                }
                else if (this.cmbMoneyType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyMMoney"))
                {
                    mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = 2;
                }
                else if (this.cmbMoneyType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyGMoney"))
                {
                    mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = 3;
                }
                //maple add
                else if (this.cmbMoneyType.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2MMoneyGoldMoney"))
                {
                    mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = 4;//maple temp define
                }




                mContent[6].eName = CEnum.TagName.BeginTime;
                mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[6].oContent = DtpBegin.Text.ToString();

                mContent[7].eName = CEnum.TagName.EndTime;
                mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[7].oContent = DtpEnd.Text.ToString();

                mContent[9].eName = CEnum.TagName.JW2_ItemName;
                mContent[9].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[9].oContent = textBox1.Text.ToString();
                this.backgroundWorkerFamilyDonationLog.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(this.checkBox2.Checked==true)
            {
                textBox1.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                textBox1.Enabled = true;
                button3.Enabled = true;
            }
        }

       
     
      
    }

}