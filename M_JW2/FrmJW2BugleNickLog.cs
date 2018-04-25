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

using System.IO;
using Language;

namespace M_JW2
{
    [C_Global.CModuleAttribute("游戏喇叭日志", "FrmJW2BugleNickLog", "游戏喇叭日志", "AU Group")]
    public partial class FrmJW2BugleNickLog : Form
    {

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
        int userSN = 0;
        DataTable dgTable = new DataTable();

        bool bByTime = true;
        string sBeginTime = null;
        string sEndTime = null;
        string sBugleContent = null;
        public FrmJW2BugleNickLog()
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

            //this.GrpResult.Text = config.ReadConfigValue("MSDO", "AF_UI_GrpResult");

            this.GrpSearch.Text = config.ReadConfigValue("MSD", "UIC_UI_GrpSearch");
            this.LblServer.Text = config.ReadConfigValue("MSD", "UIC_UI_lblServer");
            this.BtnSearch.Text = config.ReadConfigValue("MSD", "UIC_UI_btnSearch");
            this.button1.Text = config.ReadConfigValue("MSD", "UIC_UI_btnClose");

            this.LblAccount.Text = config.ReadConfigValue("MJW2", "NEW_UI_BugleMessageContent");
            ChbSearchByAccount.Text = config.ReadConfigValue("MJW2", "NEW_UI_ChbSearchByAccount");
            ChbSearchbyNick.Text = config.ReadConfigValue("MJW2", "NEW_UI_ChbSearchbyNick");
            LblDate.Text = config.ReadConfigValue("MJW2", "NEW_UI_BeginTime");
            label1.Text = config.ReadConfigValue("MJW2", "NEW_UI_EndTime");
            button7.Text = config.ReadConfigValue("MJW2", "NEW_UI_button7");
            chbRefresh.Text = config.ReadConfigValue("MJW2", "NEW_UI_chbRefresh");
            label2.Text = config.ReadConfigValue("MJW2", "NEW_UI_label2Tip");
            button1.Text = config.ReadConfigValue("MJW2", "NEW_UI_button1");
            GrpResult.Text = config.ReadConfigValue("MJW2", "NEW_UI_GrpResult");

            tabPage2.Text = config.ReadConfigValue("MJW2", "NEW_UI_tabPage2");
            LblPage.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
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
            FrmJW2BugleNickLog mModuleFrm = new FrmJW2BugleNickLog();
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
        private void FrmJW2BugleNickLog_Load(object sender, EventArgs e)
        {
            try
            {
                IntiFontLib();
                this.ChbSearchByAccount.Checked = true;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
                mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = 7;

                mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = m_ClientEvent.GetInfo("GameID_AU");

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

        #region 切换游戏服务器
        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text));
        }
        #endregion

        #region 关闭窗口
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion



        #region 查询玩家角色信息
        /// <summary>
        /// 查询玩家角色信息
        /// </summary>
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                 * 清除上一次显示的内容
                 */
                CmbPage.Items.Clear();
                
                this.tabControl1.SelectedIndex = 0;
                if (CmbServer.Text == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "LO_Code_Msg1"));
                    return;
                }

                BtnSearch.Enabled = false;
                
                dgvMission.DataSource = null;
                if (this.ChbSearchbyNick.Checked == true)
                {
                    if (this.lblAccountOrNick.Text == "")
                    {
                        MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_PleaseInputBugleMessage"));
                        this.BtnSearch.Enabled = true;
                        return; 
                    }
                }
                if (this.ChbSearchByAccount.Checked == true)
                {
                    bByTime = true;                    
                }
                else
                {
                    bByTime = false;
                    sBugleContent = lblAccountOrNick.Text.ToString();

                }

                sBeginTime = DtpBegin.Text.ToString();
                sEndTime = this.DtpEnd.Text.ToString();

                if (bByTime)
                {
                    C_Global.CEnum.Message_Body[] mContent = new C_Global.CEnum.Message_Body[5];

                    mContent[0].eName = CEnum.TagName.AU_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.Index;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = 1;

                    mContent[2].eName = CEnum.TagName.PageSize;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = 50;


                    mContent[3].eName = CEnum.TagName.BeginTime;
                    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[3].oContent = sBeginTime;

                    mContent[4].eName = CEnum.TagName.EndTime;
                    mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[4].oContent = sEndTime;



                    tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text));

                    this.backgroundWorkerSearch.RunWorkerAsync(mContent);
                }
                else
                {
                    C_Global.CEnum.Message_Body[] mContent = new C_Global.CEnum.Message_Body[6];

                    mContent[0].eName = CEnum.TagName.AU_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.Index;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = 1;

                    mContent[2].eName = CEnum.TagName.PageSize;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = 50;

                    mContent[3].eName = CEnum.TagName.BeginTime;
                    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[3].oContent = sBeginTime;

                    mContent[4].eName = CEnum.TagName.AU_BroadMsg;
                    mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[4].oContent = sBugleContent;

                    mContent[5].eName = CEnum.TagName.EndTime;
                    mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[5].oContent = sEndTime;

                    tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text));

                    this.backgroundWorkerAnotherFamilyLog.RunWorkerAsync(mContent);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region 查询玩家角色信息backgroundWorker消息发送
        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(tmp_ClientEvent, CEnum.ServiceKey.Au_BroaditeminfoNow_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询玩家角色信息backgroundWorker消息接收
        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
                Cursor = Cursors.Default;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
             if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                else
                {

                    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, dgvMission, out iPageCount);
                    if (iPageCount <= 0)
                    {
                        PnlPage.Visible = false;
                    }
                    else
                    {
                        for (int i = 0; i < iPageCount; i++)
                        {
                            CmbPage.Items.Add(i + 1);
                        }

                        CmbPage.SelectedIndex = 0;
                        bFirst = true;
                        PnlPage.Visible = true;
                        this.CmbPage.Enabled = true;
                    }

                    string result = "";
                    for (int j = 0; j < mResult.GetLength(0); j++)
                    {
                        for (int i = 0; i < mResult.GetLength(1); i++)
                        {

                            if (mResult[j, i].eName != CEnum.TagName.PageCount)
                            {
                                result += config.ReadConfigValue("GLOBAL", mResult[j, i].eName.ToString()) + ":";
                                result += mResult[j, i].oContent.ToString();
                                result += "\r\n";
                            }
                        
                        }
                    }
                    FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + this.Name + ".txt", FileMode.Create, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(result);
                    sw.Close();
                    fs.Close();
                }
            }
            catch
            {

            }
        }
        #endregion


        #region 废弃
        #region 双击玩家角色，得到游戏喇叭日志
        //private void RoleInfoView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        this.tabControl1.SelectedIndex = 1;
        //        currDgSelectRow = e.RowIndex;
        //        if (e.RowIndex != -1)
        //        {
        //            CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];


        //            //using (DataTable dt = (DataTable)RoleInfoView.DataSource)
        //            //{
        //            //    userSN = int.Parse(dt.Rows[currDgSelectRow][0].ToString());//保存玩家SN
        //            //}

        //            //查询玩家喇叭日志信息
        //            mContent[0].eName = CEnum.TagName.AU_ServerIP;
        //            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
        //            mContent[0].oContent = Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text);

        //            mContent[1].eName = CEnum.TagName.AU_UserSN;
        //            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
        //            mContent[1].oContent = userSN;

        //            mContent[2].eName = CEnum.TagName.BeginTime;
        //            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
        //            mContent[2].oContent = DtpBegin.Value.ToString();

        //            mContent[3].eName = CEnum.TagName.EndTime;
        //            mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
        //            mContent[3].oContent = DtpEnd.Value.ToString();

        //            mContent[4].eName = CEnum.TagName.Index;
        //            mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
        //            mContent[4].oContent = 1;

        //            mContent[5].eName = CEnum.TagName.PageSize;
        //            mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
        //            mContent[5].oContent = Operation_Audition.iPageSize;


        //            this.backgroundWorkerFamilyLog.RunWorkerAsync(mContent);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}
        #endregion

        #region 查询游戏喇叭日志backgroundWorker消息发送
        private void backgroundWorkerFamilyLog_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(tmp_ClientEvent, CEnum.ServiceKey.Au_BroaditeminfoBymsg_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询游戏喇叭日志backgroundWorker消息接收
        private void backgroundWorkerFamilyLog_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
                Cursor = Cursors.Default;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                else
                {

                    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, dgvMission, out iPageCount);
                    if (iPageCount <= 1)
                    {
                        PnlPage.Visible = false;//一页隐藏翻页功能
                    }
                    else
                    {
                        for (int i = 0; i < iPageCount; i++)
                        {
                            CmbPage.Items.Add(i + 1);//显示页数
                        }

                        CmbPage.SelectedIndex = 0;//默认选择首页
                        bFirst = true;//允许翻页查询
                        PnlPage.Visible = true;//显示翻页功能
                        this.CmbPage.Enabled = true;
                    }

                    string result = "";
                    for (int j = 0; j < mResult.GetLength(0); j++)
                    {
                        for (int i = 0; i < mResult.GetLength(1); i++)
                        {

                            if (mResult[j, i].eName != CEnum.TagName.PageCount)
                            {
                                result += config.ReadConfigValue("GLOBAL", mResult[j, i].eName.ToString()) + ":";
                                result += mResult[j, i].oContent.ToString();
                                result += "\r\n";
                            }

                        }
                    }
                    FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + this.Name + ".txt", FileMode.Create, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(result);
                    sw.Close();
                    fs.Close();

                    tabControl1.SelectedIndex = 1;//选择日志信息选项卡
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR");
            }


        }
        #endregion
        #endregion


        #region 翻页查询游戏喇叭日志
        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (bFirst)
                {
                    if (bByTime)
                    {
                        CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];
                        //查询玩家喇叭日志信息
                        mContent[0].eName = CEnum.TagName.AU_ServerIP;
                        mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                        mContent[1].eName = CEnum.TagName.BeginTime;
                        mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[1].oContent = sBeginTime;

                        mContent[2].eName = CEnum.TagName.Index;
                        mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[2].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_JW2.iPageSize + 1;

                        mContent[3].eName = CEnum.TagName.PageSize;
                        mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[3].oContent = 50;

                        mContent[4].eName = CEnum.TagName.EndTime;
                        mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[4].oContent = sEndTime;


                        this.backgroundWorkerReSearch.RunWorkerAsync(mContent);
                    }
                    else
                    {
                        C_Global.CEnum.Message_Body[] mContent = new C_Global.CEnum.Message_Body[6];

                        mContent[0].eName = CEnum.TagName.AU_ServerIP;
                        mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                        mContent[1].eName = CEnum.TagName.Index;
                        mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[1].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_JW2.iPageSize + 1;

                        mContent[2].eName = CEnum.TagName.PageSize;
                        mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[2].oContent = 50;

                        mContent[3].eName = CEnum.TagName.BeginTime;
                        mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[3].oContent = sBeginTime;

                        mContent[4].eName = CEnum.TagName.AU_BroadMsg;
                        mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[4].oContent = sBugleContent;

                        mContent[5].eName = CEnum.TagName.EndTime;
                        mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[5].oContent = sEndTime;
                        

                        //tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text));

                        this.backgroundWorkerReAnotherFamilyLog.RunWorkerAsync(mContent);
                      
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
        #endregion

        #region 翻页查询游戏喇叭日志backgroundWorker消息发送
        private void backgroundWorkerReFamilyLog_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(tmp_ClientEvent, CEnum.ServiceKey.Au_BroaditeminfoBymsg_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 翻页查询游戏喇叭日志backgroundWorker消息接收
        private void backgroundWorkerReFamilyLog_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
                Cursor = Cursors.Default;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, dgvMission, out iPageCount);

                //tabControl1.SelectedIndex = 1;//选择日志信息选项卡
                if (iPageCount <= 0)
                {
                    PnlPage.Visible = false;
                }
                else
                {
                    for (int i = 0; i < iPageCount; i++)
                    {
                        CmbPage.Items.Add(i + 1);
                    }

                    CmbPage.SelectedIndex = 0;
                    bFirst = true;
                    PnlPage.Visible = true;
                    this.CmbPage.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR");
            }

        }
        #endregion

        private void ChbSearchByAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ChbSearchByAccount.Checked == true)
            {
                this.ChbSearchbyNick.Checked = false;
                this.lblAccountOrNick.Text = "";

                this.lblAccountOrNick.Enabled = false;
            }
            else
            {
                if (this.ChbSearchbyNick.Checked != true)
                {
                    MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_PleaseSelectQuery"));
                    this.ChbSearchByAccount.Checked = true;
                    return;
                }

                this.lblAccountOrNick.Enabled = false;
            }
        }

        private void ChbSearchbyNick_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ChbSearchbyNick.Checked == true)
            {
                this.ChbSearchByAccount.Checked = false;
                this.lblAccountOrNick.Text = "";

                this.lblAccountOrNick.Enabled = true;
         
            }
            else
            {
                if (this.ChbSearchByAccount.Checked != true)
                {
                    MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_PleaseSelectQuery"));
                    this.ChbSearchbyNick.Checked = true;
                    return;
                }

                this.lblAccountOrNick.Enabled = true;
            }
        }

        private void backgroundWorkerReSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(tmp_ClientEvent, CEnum.ServiceKey.Au_BroaditeminfoNow_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
                Cursor = Cursors.Default;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                else
                {

                    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, dgvMission, out iPageCount);
                    string result = "";
                    for (int j = 0; j < mResult.GetLength(0); j++)
                    {
                        for (int i = 0; i < mResult.GetLength(1); i++)
                        {

                            if (mResult[j, i].eName != CEnum.TagName.PageCount)
                            {
                                result += config.ReadConfigValue("GLOBAL", mResult[j, i].eName.ToString()) + ":";
                                result += mResult[j, i].oContent.ToString();
                                result += "\r\n";
                            }

                        }
                    }
                    FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + this.Name + ".txt", FileMode.Create, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(result);
                    sw.Close();
                    fs.Close();
                  
                }
            }
            catch
            {

            }
        }

        private void backgroundWorkerReAnotherFamilyLog_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(tmp_ClientEvent, CEnum.ServiceKey.Au_BroaditeminfoBymsg_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReAnotherFamilyLog_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
                Cursor = Cursors.Default;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                else
                {

                    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, dgvMission, out iPageCount);
                    string result = "";
                    for (int j = 0; j < mResult.GetLength(0); j++)
                    {
                        for (int i = 0; i < mResult.GetLength(1); i++)
                        {

                            if (mResult[j, i].eName != CEnum.TagName.PageCount)
                            {
                                result += config.ReadConfigValue("GLOBAL", mResult[j, i].eName.ToString()) + ":";
                                result += mResult[j, i].oContent.ToString();
                                result += "\r\n";
                            }

                        }
                    }
                    FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + this.Name + ".txt", FileMode.Create, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(result);
                    sw.Close();
                    fs.Close();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void chbRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chbRefresh.Checked)
            { this.timer1.Enabled = true; }
            else
            { this.timer1.Enabled = false; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                BtnSearch.Enabled = false;                
                this.DtpEnd.Value = DateTime.Now;
                sEndTime = this.DtpEnd.Value.ToString();

                if (bByTime)
                {
                    C_Global.CEnum.Message_Body[] mContent = new C_Global.CEnum.Message_Body[5];

                    mContent[0].eName = CEnum.TagName.AU_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.Index;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = 1;

                    mContent[2].eName = CEnum.TagName.PageSize;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = 50;


                    mContent[3].eName = CEnum.TagName.BeginTime;
                    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[3].oContent = sBeginTime;

                    mContent[4].eName = CEnum.TagName.EndTime;
                    mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[4].oContent = sEndTime;



                    tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text));

                    this.backgroundWorkerSearch.RunWorkerAsync(mContent);
                }
                else
                {
                    C_Global.CEnum.Message_Body[] mContent = new C_Global.CEnum.Message_Body[6];

                    mContent[0].eName = CEnum.TagName.AU_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.Index;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = 1;

                    mContent[2].eName = CEnum.TagName.PageSize;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = 50;

                    mContent[3].eName = CEnum.TagName.BeginTime;
                    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[3].oContent = sBeginTime;

                    mContent[4].eName = CEnum.TagName.AU_BroadMsg;
                    mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[4].oContent = sBugleContent;

                    mContent[5].eName = CEnum.TagName.EndTime;
                    mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[5].oContent = sEndTime;

                    tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text));

                    this.backgroundWorkerAnotherFamilyLog.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("notepad", AppDomain.CurrentDomain.SetupInformation.ApplicationBase + this.Name + ".txt");
            }
            catch
            {

            }
        }

       
  
    }
}