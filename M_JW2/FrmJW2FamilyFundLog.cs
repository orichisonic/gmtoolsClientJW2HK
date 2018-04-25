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
    [C_Global.CModuleAttribute("家族成员信息", "FrmJW2FamilyFundLog", "家族成员信息", "AU Group")]
    public partial class FrmJW2FamilyFundLog : Form
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
        private bool pageFamilyDonationLog=false;
        private bool pageFamilyConsumerLog=false;
        private bool pageFamilyPetFriendLog=false;
        private bool pagePatriarchBuyPetLog=false;
        private string FamilyID;
        DataTable dgTable = new DataTable();
        #endregion

        public FrmJW2FamilyFundLog()
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
            this.GrpSearch.Text = config.ReadConfigValue("MSDO", "AF_UI_GrpSearch");
            this.LblServer.Text = config.ReadConfigValue("MSDO", "AF_UI_LblServer");
            this.BtnSearch.Text = config.ReadConfigValue("MSDO", "AF_UI_BtnSearch");
            this.LblAccount.Text = config.ReadConfigValue("MSD", "UIC_UI_lblAccount");
            this.LblDate.Text = config.ReadConfigValue("MJW2", "NEW_UI_BeginTime");
            this.LblLink.Text = config.ReadConfigValue("MJW2", "NEW_UI_EndTime");
            button1.Text = config.ReadConfigValue("MSD", "UIC_UI_btnClose");
            this.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2FamilyFundLog");
            label1.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            label2.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            label3.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            label4.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            label5.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");

            this.tpgCharacter.Text = config.ReadConfigValue("MJW2", "NEW_UI_FamilyBaseInfo");
            this.tpgFamilyDonationLog.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgFamilyDonationLog");
            this.tpgFamilyConsumerLog.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgFamilyConsumerLog");
            this.tpgFamilyPetFriendLog.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgFamilyPetFriendLog");
            this.tpgPatriarchBuyPetLog.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgPatriarchBuyPetLog");
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
            FrmJW2FamilyFundLog mModuleFrm = new FrmJW2FamilyFundLog();
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
        private void FrmJW2FamilyFundLog_Load(object sender, EventArgs e)
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

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];


                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.JW2_ServerName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = CmbServer.Text.ToString();

                mContent[2].eName = CEnum.TagName.JW2_FAMILYNAME;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.lblAccountOrNick.Text.ToString();

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_JW2.iPageSize;

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
                e.Result = Operation_JW2.GetResult(tmp_ClientEvent, CEnum.ServiceKey.JW2_FAMILYINFO_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询家族信息backgroundWorker消息接收
        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
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

        #region 查询家族信息backgroundworker翻页消息发送
        private void backgroundWorkerReSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(tmp_ClientEvent, CEnum.ServiceKey.JW2_FAMILYINFO_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询家族信息backgroundworker翻页消息接受
        private void backgroundWorkerReSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
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
        #endregion

        #region 查询家族捐赠信息backgroundworker消息发送
        private void backgroundWorkerFamilyDonationLog_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_FamilyFund_Log, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询家族捐赠信息backgroundworker消息接受
        private void backgroundWorkerFamilyDonationLog_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
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
                if (iPageCount <= 1)
                {
                    this.pnlFamilyDonationLog.Visible = false;
                }
                else
                {
                    for (int i = 0; i < iPageCount; i++)
                    {
                        this.cmbFamilyDonationLog.Items.Add(i + 1);
                    }

                    this.cmbFamilyDonationLog.SelectedIndex = 0;
                    this.pageFamilyDonationLog = true;
                    this.pnlFamilyDonationLog.Visible = true;
                }

            }
            catch
            {

            }
        }
        #endregion

        #region 查询家族捐赠信息backgroundworker翻页消息发送
        private void backgroundWorkerReFamilyDonationLog_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_FamilyFund_Log, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询家族捐赠信息backgroundworker翻页消息接受
        private void backgroundWorkerReFamilyDonationLog_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
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
        #endregion

        #region 查询家族消费日志backgroundworker消息发送
        private void backgroundWorkerFamilyConsumerLog_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_FamilyFund_Log, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询家族消费日志backgroundworker消息接受
        private void backgroundWorkerFamilyConsumerLog_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
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
                if (iPageCount <= 1)
                {
                    this.pnlFamilyConsumerLog.Visible = false;
                }
                else
                {
                    for (int i = 0; i < iPageCount; i++)
                    {
                        this.cmbFamilyConsumerLog.Items.Add(i + 1);
                    }
                    this.cmbFamilyConsumerLog.SelectedIndex = 0;
                    this.pageFamilyConsumerLog = true;
                    this.pnlFamilyConsumerLog.Visible = true;
                }
            }
            catch
            {

            }
        }
        #endregion

        #region 查询家族消费日志翻页backgroundworker消息发送
        private void backgroundWorkerReFamilyConsumerLog_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_FamilyFund_Log, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询家族消费日志翻页backgroundworker消息接受
        private void backgroundWorkerReFamilyConsumerLog_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
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
        #endregion

        #region 切换选项卡
        private void tbcResult_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                if (RoleInfoView.DataSource != null)
                {
                    DataTable mTable = (DataTable)RoleInfoView.DataSource;
                 
                    FamilyID = mTable.Rows[currDgSelectRow][0].ToString();//保存玩家帐号ID



                }
                if (this.tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_tpgFamilyDonationLog")))
                {
                    FamilyDonationLog();//查詢家族捐贈日誌
                }
                else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_tpgFamilyConsumerLog")))
                {
                    FamilyConsumerLog();//查詢家族消費日誌

                }
                else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_tpgFamilyPetFriendLog")))
                {
                    GrdFamilyPetFriendLog.DataSource = null;
                    FamilyPetFriendLog();
                }
                else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MJW2", "NEW_UI_tpgPatriarchBuyPetLog")))
                {
                    GrdPatriarchBuyPetLog.DataSource = null;
                    PatriarchBuyPetLog();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
        #endregion

        #region 查询家族捐赠日志信息
        private void FamilyDonationLog()
        {
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

            mContent[0].eName = CEnum.TagName.JW2_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[1].eName = CEnum.TagName.JW2_ServerName;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = CmbServer.Text.ToString();

            mContent[2].eName = CEnum.TagName.JW2_FAMILYID;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = int.Parse(FamilyID);

            mContent[3].eName = CEnum.TagName.Index;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = 1;

            mContent[4].eName = CEnum.TagName.PageSize;
            mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[4].oContent = Operation_JW2.iPageSize;

            mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
            mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[5].oContent = 0;


            mContent[6].eName = CEnum.TagName.BeginTime;
            mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[6].oContent = DtpBegin.Text.ToString();

            mContent[7].eName = CEnum.TagName.EndTime;
            mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[7].oContent = DtpEnd.Text.ToString();
            this.backgroundWorkerFamilyDonationLog.RunWorkerAsync(mContent);

        }
        #endregion

        #region 查询家族消费日志信息
        private void FamilyConsumerLog()
        {

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

            mContent[0].eName = CEnum.TagName.JW2_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[1].eName = CEnum.TagName.JW2_ServerName;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = CmbServer.Text.ToString();

            mContent[2].eName = CEnum.TagName.JW2_FAMILYID;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = int.Parse(FamilyID);

            mContent[3].eName = CEnum.TagName.Index;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = 1;

            mContent[4].eName = CEnum.TagName.PageSize;
            mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[4].oContent = Operation_JW2.iPageSize;

            mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
            mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[5].oContent =1;

            mContent[6].eName = CEnum.TagName.BeginTime;
            mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[6].oContent = DtpBegin.Text.ToString();

            mContent[7].eName = CEnum.TagName.EndTime;
            mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[7].oContent = DtpEnd.Text.ToString();

            this.backgroundWorkerFamilyConsumerLog.RunWorkerAsync(mContent);

        }
        #endregion

        #region 家族捐赠日志信息翻页
        private void cmbFamilyDonationLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageFamilyDonationLog)
            {
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.JW2_ServerName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = CmbServer.Text.ToString();

                mContent[2].eName = CEnum.TagName.JW2_FAMILYID;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = int.Parse(FamilyID);

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = int.Parse(this.cmbFamilyDonationLog.Text.ToString());

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_JW2.iPageSize;

                mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = 0;

                mContent[6].eName = CEnum.TagName.BeginTime;
                mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[6].oContent = DtpBegin.Text.ToString();

                mContent[7].eName = CEnum.TagName.EndTime;
                mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[7].oContent = DtpEnd.Text.ToString();

                this.backgroundWorkerReFamilyConsumerLog.RunWorkerAsync(mContent);
            }
        }
        #endregion

        #region 家族消费日志信息翻页
        private void cmbFamilyConsumerLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageFamilyConsumerLog)
            {
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.JW2_ServerName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = CmbServer.Text.ToString();

                mContent[2].eName = CEnum.TagName.JW2_FAMILYID;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = int.Parse(FamilyID);

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = int.Parse(this.cmbFamilyConsumerLog.Text.ToString());

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_JW2.iPageSize;

                mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = 1;

                mContent[6].eName = CEnum.TagName.BeginTime;
                mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[6].oContent = DtpBegin.Text.ToString();

                mContent[7].eName = CEnum.TagName.EndTime;
                mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[7].oContent = DtpEnd.Text.ToString();

                this.backgroundWorkerReFamilyConsumerLog.RunWorkerAsync(mContent);
            }
        }
        #endregion

        #region 家族基本信息翻页
        private void cmbRoleView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageRoleView)
            {
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.JW2_ServerName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = CmbServer.Text.ToString();

                mContent[2].eName = CEnum.TagName.JW2_FAMILYNAME;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.lblAccountOrNick.Text.ToString();

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = int.Parse(cmbRoleView.Text.ToString());

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_JW2.iPageSize;

                backgroundWorkerReSearch.RunWorkerAsync(mContent);
            }
        }
        #endregion

        #region 单击家族基本信息
        private void RoleInfoView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currDgSelectRow = e.RowIndex;
        }
        #endregion

        #region 双击家族基本信息
        private void RoleInfoView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            currDgSelectRow = e.RowIndex;
            this.tbcResult.SelectedIndex = 1;
        }
        #endregion

        #region 家族宠物交友信息翻页
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageFamilyPetFriendLog)
            {


                CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.JW2_ServerName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = CmbServer.Text.ToString();

                mContent[2].eName = CEnum.TagName.JW2_FAMILYID;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = int.Parse(FamilyID);

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = int.Parse(this.cmbFamilyPetFriendLog.Text.ToString());


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


                this.backgroundWorkerReFamilyPetFriendLog.RunWorkerAsync(mContent);
            }
        }
        #endregion

        #region  族长购买宠物蛋日志
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pagePatriarchBuyPetLog)
            {
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.JW2_ServerName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = CmbServer.Text.ToString();

                mContent[2].eName = CEnum.TagName.JW2_FAMILYID;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = int.Parse(FamilyID);

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = int.Parse(this.cmbPatriarchBuyPetLog.Text.ToString());


                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_JW2.iPageSize;

                mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = 3;

                mContent[6].eName = CEnum.TagName.BeginTime;
                mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[6].oContent = DtpBegin.Text.ToString();

                mContent[7].eName = CEnum.TagName.EndTime;
                mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[7].oContent = DtpEnd.Text.ToString();


                this.backgroundWorkerRePatriarchBuyPetLog.RunWorkerAsync(mContent);
            }
        }
        #endregion

        #region 
        private void backgroundWorkerFamilyPetFriendLog_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_FamilyFund_Log, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion


        private void backgroundWorkerFamilyPetFriendLog_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
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

                    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdFamilyPetFriendLog, out iPageCount);
                }
                if (iPageCount <= 1)
                {
                    this.pnlFamilyPetFriendLog.Visible = false;
                }
                else
                {
                    for (int i = 0; i < iPageCount; i++)
                    {
                        this.cmbFamilyPetFriendLog.Items.Add(i + 1);
                    }

                    this.cmbFamilyPetFriendLog.SelectedIndex = 0;
                    this.pageFamilyPetFriendLog = true;
                    this.pnlFamilyPetFriendLog.Visible = true;
                }

            }
            catch
            {

            }
        }

        private void backgroundWorkerReFamilyPetFriendLog_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_FamilyFund_Log, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReFamilyPetFriendLog_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
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

                    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdFamilyPetFriendLog, out iPageCount);
                }
               

            }
            catch
            {

            }
        }

        private void backgroundWorkerPatriarchBuyPetLog_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_FamilyFund_Log, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerPatriarchBuyPetLog_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
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

                    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdPatriarchBuyPetLog, out iPageCount);
                }
                if (iPageCount <= 1)
                {
                    this.pnlPatriarchBuyPetLog.Visible = false;
                }
                else
                {
                    for (int i = 0; i < iPageCount; i++)
                    {
                        this.cmbPatriarchBuyPetLog.Items.Add(i + 1);
                    }

                    this.cmbPatriarchBuyPetLog.SelectedIndex = 0;
                    this.pagePatriarchBuyPetLog = true;
                    this.pnlPatriarchBuyPetLog.Visible = true;
                }

            }
            catch
            {

            }
        }

        private void backgroundWorkerRePatriarchBuyPetLog_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_FamilyFund_Log, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerRePatriarchBuyPetLog_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
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

                    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdPatriarchBuyPetLog, out iPageCount);
                }
              
            }
            catch
            {

            }
        }

        #region
        private void FamilyPetFriendLog()
        {

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

            mContent[0].eName = CEnum.TagName.JW2_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[1].eName = CEnum.TagName.JW2_ServerName;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = CmbServer.Text.ToString();

            mContent[2].eName = CEnum.TagName.JW2_FAMILYID;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = int.Parse(FamilyID);


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

            this.backgroundWorkerFamilyPetFriendLog.RunWorkerAsync(mContent);

        }
        #endregion

        #region
        private void PatriarchBuyPetLog()
        {

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

            mContent[0].eName = CEnum.TagName.JW2_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[1].eName = CEnum.TagName.JW2_ServerName;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = CmbServer.Text.ToString();

            mContent[2].eName = CEnum.TagName.JW2_FAMILYID;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = int.Parse(FamilyID);




            mContent[3].eName = CEnum.TagName.Index;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = 1;

            mContent[4].eName = CEnum.TagName.PageSize;
            mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[4].oContent = Operation_JW2.iPageSize;

            mContent[5].eName = CEnum.TagName.JW2_GOODSTYPE;
            mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[5].oContent = 3;

            mContent[6].eName = CEnum.TagName.BeginTime;
            mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[6].oContent = DtpBegin.Text.ToString();

            mContent[7].eName = CEnum.TagName.EndTime;
            mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[7].oContent = DtpEnd.Text.ToString();

            this.backgroundWorkerPatriarchBuyPetLog.RunWorkerAsync(mContent);

        }
        #endregion
    }

}