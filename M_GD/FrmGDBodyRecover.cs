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
    [C_Global.CModuleAttribute("机体恢复信息查询", "FrmGDBodyRecover", "机体恢复信息查询", "GD Group")]
    public partial class FrmGDBodyRecover : Form
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
        private string SD_ID;

        private bool pageDistintegrationOfTheBody = false;
        private string userId=null;
        private string userTime;
        //bool pageLuckyCapsulePickedLog = false;
        int currDgSelectRow = 0;    //玩家信息datagrid 中当前选中的行
        #endregion

        public FrmGDBodyRecover()
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
            FrmGDBodyRecover mModuleFrm = new FrmGDBodyRecover();
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
        
        }
        #endregion

        #region 登陆窗体加载(得到游戏服务器列表)
        private void FrmGDPlayerLog_Load(object sender, EventArgs e)
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

        #region 查询玩家日志信息
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                TbcResult.SelectedTab = TpgCharacter;//选择角色信息选项卡
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
                    this.TbcResult.Enabled = false;
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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void TbcResult_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                if (GrdCharacter.DataSource != null)
                {
                    DataTable mTable = (DataTable)GrdCharacter.DataSource;
                    userID = int.Parse(mTable.Rows[selectChar][config.ReadConfigValue("GLOBAL", "f_idx")].ToString());//保存玩家帐号ID
                    userName = mTable.Rows[selectChar][config.ReadConfigValue("GLOBAL", "SD_UserName")].ToString();
                    
                    if (TbcResult.SelectedTab.Text.Equals("机体解体记录"))
                    {
                        DistintegrationOfTheBody();//机体解体记录
                    }
                    
                }
                else
                {


                    this.GrdDistintegrationOfTheBody.DataSource = null;
                    this.pnlDistintegrationOfTheBody.Visible = false;

              

                }
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
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Account_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.GrpSearch.Enabled = true;
            this.TbcResult.Enabled = true;
            this.Cursor = Cursors.Default;//改变鼠标状态
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdCharacter, out iPageCount);
        }

        #region 查询机体解体记录
        private void DistintegrationOfTheBody()
        {
            try
            {
                this.GrpSearch.Enabled = false;
                this.TbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                this.GrdDistintegrationOfTheBody.DataSource = null;

                this.pnlDistintegrationOfTheBody.Visible = false;
                this.CmbDistintegrationOfTheBody.Items.Clear();
                this.pageDistintegrationOfTheBody = false;

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

                mContent[4].eName = CEnum.TagName.SD_StartTime;
                mContent[4].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                mContent[4].oContent = DtpBegin.Value;

                mContent[5].eName = CEnum.TagName.SD_EndTime;
                mContent[5].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                mContent[5].oContent = DtpEnd.Value;

                mContent[6].eName = CEnum.TagName.PageSize;
                mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[6].oContent = Operation_GD.iPageSize;

                mContent[7].eName = CEnum.TagName.SD_Type;
                mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[7].oContent = 9;

                //mContent[7].eName = CEnum.TagName.SD_ID;
                //mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                //mContent[7].oContent = 9;
                this.backgroundWorkerDistintegrationOfTheBody.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void backgroundWorkerDistintegrationOfTheBody_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(m_ClientEvent, CEnum.ServiceKey.SD_LogInfo_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerDistintegrationOfTheBody_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.GrpSearch.Enabled = true;
            this.TbcResult.Enabled = true;
            this.Cursor = Cursors.Default;//改变鼠标状态

            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdDistintegrationOfTheBody, out iPageCount);

            if (iPageCount <= 1)
            {
                this.pnlDistintegrationOfTheBody.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    this.CmbDistintegrationOfTheBody.Items.Add(i + 1);
                }

                this.CmbDistintegrationOfTheBody.SelectedIndex = 0;
                this.pageDistintegrationOfTheBody = true;
                this.pnlDistintegrationOfTheBody.Visible = true;
            }
        }

        private void backgroundWorkerReDistintegrationOfTheBody_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(m_ClientEvent, CEnum.ServiceKey.SD_LogInfo_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReDistintegrationOfTheBody_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.GrpSearch.Enabled = true;
            this.TbcResult.Enabled = true;
            this.Cursor = Cursors.Default;//改变鼠标状态

            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdDistintegrationOfTheBody, out iPageCount);

        }

        private void GrdDistintegrationOfTheBody_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
               if (e.RowIndex != -1)//双击列名触发
                {
                    using (DataTable dt = (DataTable)GrdDistintegrationOfTheBody.DataSource)
                    {
                        userTime = dt.Rows[e.RowIndex][10].ToString();
                        SD_ID = dt.Rows[e.RowIndex][0].ToString();
                if (MessageBox.Show("恢复机体解体记录！", "恢复机体", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

                    mContent[0].eName = CEnum.TagName.f_idx;
                    mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[0].oContent = userID;

                    mContent[1].eName = CEnum.TagName.SD_UserName;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = userName;




                    mContent[2].eName = CEnum.TagName.SD_ServerIP;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = Operation_GD.GetItemAddr(mServerInfo, CmbServer.Text);


                    mContent[3].eName = CEnum.TagName.SD_ItemID;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(dt.Rows[e.RowIndex][4].ToString());

                    mContent[4].eName = CEnum.TagName.UserByID;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    mContent[5].eName = CEnum.TagName.SD_ItemName;
                    mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[5].oContent = dt.Rows[e.RowIndex][5].ToString();

                    mContent[6].eName = CEnum.TagName.BeginTime;
                    mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[6].oContent = userTime;

                    mContent[7].eName = CEnum.TagName.SD_ID;
                    mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[7].oContent =int.Parse(SD_ID);

                    CEnum.Message_Body[,] result = Operation_GD.GetResult(m_ClientEvent, CEnum.ServiceKey.SD_ReGetUnits_Query, mContent);
                    if (result[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(config.ReadConfigValue("MFj", "FM_Code_Msg1"));
                    }
                    else
                    {
                        MessageBox.Show(result[0, 0].oContent.ToString());

                        if (GrdDistintegrationOfTheBody.DataSource != null)
                        {
                            DataTable dt2 = (DataTable)GrdDistintegrationOfTheBody.DataSource;

                            for (int i = 0; i < dt2.Rows.Count; i++)
                            {
                                if (dt2.Rows[i].ItemArray[0].ToString() == SD_ID)
                                {
                                    this.GrdDistintegrationOfTheBody.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                                }
                            }
                        }
                        //this.comboBoxGuild.Enabled = false;
                        //this.buttonAdd.Enabled = false;
                        //this.buttonQuit.Enabled = true;
                    }
                    //else if (result[0, 0].oContent.ToString() == "FAILURE")
                    //{
                    //    MessageBox.Show("恢复机体失败！");
                    //}

                  
                
                        }
                    } 
            //}
            //else
            //{
            //    MessageBox.Show(config.ReadConfigValue("MSDO", "CI_Code_inPutAccont"));
            //}

               }

        }

        private void CmbDistintegrationOfTheBody_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.pageDistintegrationOfTheBody)
                {
                    this.GrpSearch.Enabled = false;
                    this.TbcResult.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;//改变鼠标状态
                    this.GrdDistintegrationOfTheBody.DataSource = null;

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
                    mContent[3].oContent = int.Parse(this.CmbDistintegrationOfTheBody.Text.ToString());

                    mContent[4].eName = CEnum.TagName.SD_StartTime;
                    mContent[4].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                    mContent[4].oContent = DtpBegin.Value;

                    mContent[5].eName = CEnum.TagName.SD_EndTime;
                    mContent[5].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                    mContent[5].oContent = DtpEnd.Value;

                    mContent[6].eName = CEnum.TagName.PageSize;
                    mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[6].oContent = Operation_GD.iPageSize;

                    mContent[7].eName = CEnum.TagName.SD_Type;
                    mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[7].oContent = 9;

                    this.backgroundWorkerReDistintegrationOfTheBody.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GrdCharacter_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)//双击列名触发
                {
                    using (DataTable dt2 = (DataTable)GrdCharacter.DataSource)
                    {
                        userId=dt2.Rows[e.RowIndex][0].ToString();

                    }
                    this.TbcResult.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}