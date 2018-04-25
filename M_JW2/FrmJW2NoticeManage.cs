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

namespace M_JW2
{
    [C_Global.CModuleAttribute("公告管理", "FrmJW2NoticeManage", "公告管理", "JW2 Group")]
    public partial class FrmJW2NoticeManage : Form
    {
        #region 变量

        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        //private CSocketEvent tmp_ClientEvent = null;

        private int iPageCount = 0;//翻页页数

        string serverIP = null;
        int typeSend = 1;
        int noticeID = 0;
        int selectNotice = 0;
        string content = null;
        int iBoardID = 0;
        int iIndexID = 0;
        private bool pageNotice = false;//翻页不重复发Query
        bool isCheck = false;

        #endregion

        public FrmJW2NoticeManage()
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
            FrmJW2NoticeManage mModuleFrm = new FrmJW2NoticeManage();
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

        #region 初始化配置信息
        /// <summary>
        ///　文字库
        /// </summary>
        ConfigValue config = null;

        /// <summary>
        /// 初始化配置信息
        /// </summary>
        private void IntiFontLib()
        {
            config = (ConfigValue)m_ClientEvent.GetInfo("INI");
            IntiUI();
        }

        private void IntiUI()
        {
            this.lblServerList.Text = config.ReadConfigValue("MSD", "NM_UI_lblServerList");
            this.btnSelectAll.Text = config.ReadConfigValue("MSD", "NM_UI_btnSelectAll");

            this.btnNoticeInfo.Text = config.ReadConfigValue("MSD", "NM_UI_btnNoticeInfo");
            this.lblNotice.Text = config.ReadConfigValue("MSD", "UIC_UI_lblPage");

            this.chbNoticeImmed.Text = config.ReadConfigValue("MSD", "NM_UI_chbNoticeImme");
            this.lblStartTime.Text = config.ReadConfigValue("MSD", "GI_UI_lblStartTime");
            this.lblEndTime.Text = config.ReadConfigValue("MSD", "NM_UI_lblEndTime");
            this.lblTimeSpan.Text = config.ReadConfigValue("MSD", "NM_UI_lblTimeSpan");
            this.lblType.Text = config.ReadConfigValue("MSD", "NM_UI_lblType");
            cmbType.Items.Clear();
            //cmbType.Items.Add(config.ReadConfigValue("MSD", "NM_UI_cmbNoticeCheck"));
            cmbType.Items.Add(config.ReadConfigValue("MSD", "NM_UI_cmbNoticeCommon"));
            cmbType.Items.Add(config.ReadConfigValue("MSD", "NM_UI_cmbNoticeEvent"));
            cmbType.Items.Add(config.ReadConfigValue("MSD", "NM_UI_cmbNoticeSystem"));
            this.lblContent.Text = config.ReadConfigValue("MSD", "NM_UI_lblContent");
            this.btnAddNotice.Text = config.ReadConfigValue("MSD", "NM_UI_btnAddNotice");
            this.btnReset.Text = config.ReadConfigValue("MSD", "BP_UI_btnReset");


            BtnEdit.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2NoticeManageModiStatus");
            pnlNotice.Visible = false;
            label11.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2NoticeManageStatus");

            lblMin.Text = config.ReadConfigValue("MJW2", "IntervalMinute");
            this.ItmDelete.Text = config.ReadConfigValue("MJW2", "Notice_ModiStatus");
            //btnEditNotice.Enabled = false;
            //btnEditNotice.Visible = false;
        }

        #endregion



        #region 登陆窗体加载(得到游戏服务器列表)
        private void FrmGDNoticeManage_Load(object sender, EventArgs e)
        {
            try
            {
                IntiFontLib();

                this.chbNoticeImmed.Checked = true;
                this.chbNoticeImmed.Enabled = false;
                DptStartTime.Enabled = false;
                DptEndTime.Enabled = false;
                nudTimeSpan.Enabled = false;
                typeSend = 0;
                nudTimeSpan.Enabled = false;
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
            clbServer.Enabled = true;
            clbServer.Items.Clear();
            for (int i = 0; i < mServerInfo.GetLength(0); i++)
            {
                clbServer.Items.Add(mServerInfo[i, 1].oContent.ToString());
            }
            //tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_GD.GetItemAddr(mServerInfo, cmbServer.Text));
        }
        #endregion



        #region 选择所有游戏服务器
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (isCheck == true)
            {
                clbServer.Enabled = true;
                for (int i = 0; i < clbServer.Items.Count; i++)
                {
                    clbServer.SetItemChecked(i, false);
                }
                isCheck = false;
            }
            else if (isCheck == false)
            {
                clbServer.Enabled = false;
                for (int i = 0; i < clbServer.Items.Count; i++)
                {
                    clbServer.SetItemChecked(i, true);
                }
                isCheck = true;
            }
        }
        #endregion



        #region 利用查询按钮查询公告信息
        private void btnNoticeInfo_Click(object sender, EventArgs e)
        {
            try
            {
                this.label11.Visible = false;
                this.cmbStauas.Visible = false;
                btnAddNotice.Visible = true;
                BtnEdit.Visible = false;
                //this.DptStartTime.Enabled = true;
                //DptEndTime.Enabled = true;
                //nudTimeSpan.Enabled = true;

                this.DptStartTime.Enabled = false;
                DptEndTime.Enabled = false;
                nudTimeSpan.Enabled = false;
                //this.chbNoticeImmed.Checked = true;
                txtContent.Enabled = true;
                btnAddNotice.Enabled = true;

                NoticeList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 查询公告信息
        private void NoticeList()
        {
            try
            {
                this.GrdNotice.DataSource = null;
                pnlNotice.Visible = false;
                cmbNotice.Items.Clear();
                pageNotice = false;

                this.GrpServer.Enabled = false;
                this.GrpNotice.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];

                mContent[0].eName = CEnum.TagName.Index;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = 1;

                mContent[1].eName = CEnum.TagName.PageSize;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = Operation_JW2.iPageSize;

                backgroundWorkerSearch.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 查询公告信息backgroundWorker消息发送
        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_BOARDTASK_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询公告信息backgroundWorker消息接收
        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.GrpServer.Enabled = true;
            this.GrpNotice.Enabled = true;
            this.Cursor = Cursors.Default;//改变鼠标状态

            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
             if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdNotice, out iPageCount);

            if (iPageCount <= 1)
            {
                pnlNotice.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    cmbNotice.Items.Add(i + 1);
                }

                cmbNotice.SelectedIndex = 0;
                pageNotice = true;
                pnlNotice.Visible = true;
            }
        }
        #endregion



        #region 翻页查询公告信息
        private void cmbNotice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pageNotice)
                {
                    this.GrdNotice.DataSource = null;

                    this.GrpServer.Enabled = false;
                    this.GrpNotice.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;//改变鼠标状态

                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];

                    mContent[0].eName = CEnum.TagName.Index;
                    mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[0].oContent = int.Parse(cmbNotice.Text.Trim());

                    mContent[1].eName = CEnum.TagName.PageSize;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = Operation_JW2.iPageSize;

                    backgroundWorkerReSearch.RunWorkerAsync(mContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 翻页查询公告信息backgroundWorker消息发送
        private void backgroundWorkerReSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.SD_SeacrhNotes_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 翻页查询公告信息backgroundWorker消息接收
        private void backgroundWorkerReSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.GrpServer.Enabled = true;
            this.GrpNotice.Enabled = true;
            this.Cursor = Cursors.Default;//改变鼠标状态

            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, GrdNotice, out iPageCount);
        }
        #endregion



        #region 双击公告信息进行删除
        private void GrdNotice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)//双击列名触发
                {
                    selectNotice = int.Parse(e.RowIndex.ToString());//保存列
                    if (GrdNotice.DataSource != null)
                    {
                        DataTable mTable = (DataTable)GrdNotice.DataSource;
                        noticeID = int.Parse(mTable.Rows[selectNotice][config.ReadConfigValue("GLOBAL", "SD_ID")].ToString());
                        //serverIP = mTable.Rows[selectNotice][config.ReadConfigValue("GLOBAL", "SD_ServerIP")].ToString();

                        if (MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_SubmitKickPlayer"), config.ReadConfigValue("MJW2", "NEW_UI_FrmJw2KickPlayerTip"), MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            this.GrpServer.Enabled = false;
                            this.GrpNotice.Enabled = false;
                            this.Cursor = Cursors.WaitCursor;//改变鼠标状态

                            CEnum.Message_Body[] mContent = new CEnum.Message_Body[9];

                            //mContent[0].eName = CEnum.TagName.SD_ServerIP;
                            //mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                            //mContent[0].oContent = serverIP;

                            mContent[0].eName = CEnum.TagName.UserByID;
                            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                            mContent[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                            mContent[1].eName = CEnum.TagName.SD_Limit;
                            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                            mContent[1].oContent = int.Parse(mTable.Rows[selectNotice][config.ReadConfigValue("GLOBAL", "SD_Limit")].ToString());

                            mContent[2].eName = CEnum.TagName.SD_Content;
                            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                            mContent[2].oContent = mTable.Rows[selectNotice][config.ReadConfigValue("GLOBAL", "SD_Content")].ToString();

                            mContent[3].eName = CEnum.TagName.SD_EndTime;
                            mContent[3].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                            mContent[3].oContent = Convert.ToDateTime(mTable.Rows[selectNotice][config.ReadConfigValue("GLOBAL", "SD_EndTime")].ToString());

                            mContent[4].eName = CEnum.TagName.SD_StartTime;
                            mContent[4].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                            mContent[4].oContent = Convert.ToDateTime(mTable.Rows[selectNotice][config.ReadConfigValue("GLOBAL", "SD_StartTime")].ToString());

                            mContent[5].eName = CEnum.TagName.SD_Type;
                            mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                            mContent[5].oContent = 2;

                            mContent[6].eName = CEnum.TagName.SD_SendType;
                            mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                            mContent[6].oContent = 1;

                            mContent[7].eName = CEnum.TagName.SD_Status;
                            mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                            mContent[7].oContent = 1;

                            mContent[8].eName = CEnum.TagName.SD_ID;
                            mContent[8].eTag = CEnum.TagFormat.TLV_INTEGER;
                            mContent[8].oContent = noticeID;

                            backgroundWorkerDeleteNotice.RunWorkerAsync(mContent);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 删除公告信息backgroundWorker消息发送
        private void backgroundWorkerDeleteNotice_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.SD_TaskList_Update, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 删除公告信息backgroundWorker消息接收
        private void backgroundWorkerDeleteNotice_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.GrpServer.Enabled = true;
            this.GrpNotice.Enabled = true;
            this.Cursor = Cursors.Default;//改变鼠标状态

            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

            Operation_JW2.showResult(mResult);
            NoticeList();
        }
        #endregion



        #region 单击公告信息保存当前行号
        private void GrdNotice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                iIndexID = e.RowIndex;
                DataTable mBoardInfo = (DataTable)GrdNotice.DataSource;

                if (mBoardInfo.Rows.Count > 0)
                {
                    iBoardID = int.Parse(mBoardInfo.Rows[iIndexID][0].ToString());
                }
            }
            catch
            { }
        }
        #endregion
            
        #region 右键点击公告信息进行编辑
        private void cmsEditNotice_Click(object sender, EventArgs e)
        {
            try
            {
                if (GrdNotice.DataSource != null)
                {
                    btnAddNotice.Enabled = false;
                    btnAddNotice.Visible = false;

                    BtnEdit.Enabled = true;
                    BtnEdit.Visible = true;

                    DataTable mTable = (DataTable)GrdNotice.DataSource;
                    noticeID = int.Parse(mTable.Rows[selectNotice][config.ReadConfigValue("GLOBAL", "JW2_TASKID")].ToString());

                    chbNoticeImmed.Checked = false;
                    DptStartTime.Value = Convert.ToDateTime(mTable.Rows[selectNotice][config.ReadConfigValue("GLOBAL", "JW2_BeginTime")].ToString());
                    DptEndTime.Value = Convert.ToDateTime(mTable.Rows[selectNotice][config.ReadConfigValue("GLOBAL", "jw2_endtime")].ToString());
                    if (int.Parse(mTable.Rows[selectNotice][config.ReadConfigValue("GLOBAL", "jw2_interval")].ToString()) == 0)
                        nudTimeSpan.Value = 1;
                    else
                        nudTimeSpan.Value = int.Parse(mTable.Rows[selectNotice][config.ReadConfigValue("GLOBAL", "jw2_interval")].ToString());
                    txtContent.Text = mTable.Rows[selectNotice][config.ReadConfigValue("GLOBAL", "JW2_BoardMessage ")].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                btnAddNotice.Enabled = true;
                btnAddNotice.Visible = true;

                BtnEdit.Enabled = false;
                BtnEdit.Visible = false;
            }
        }
        #endregion
        
        #region 选择是否立即发送
        private void chbNoticeImmed_CheckedChanged(object sender, EventArgs e)
        {
            if (chbNoticeImmed.Checked)
            {
                DptStartTime.Enabled = false;
                DptEndTime.Enabled = false;
                nudTimeSpan.Enabled = false;
                typeSend = 0;
                nudTimeSpan.Enabled = false;
                chbNoticeImmed.Text = config.ReadConfigValue("MSD", "NM_UI_chbNoticeNorm");
            }
            else
            {
                nudTimeSpan.Enabled = true;
                DptStartTime.Enabled = true;
                DptEndTime.Enabled = true;
                typeSend = 1;
                chbNoticeImmed.Text = config.ReadConfigValue("MSD", "NM_UI_chbNoticeImme");
            }
        }
        #endregion



        #region 发送公告
        private void btnAddNotice_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.clbServer.CheckedItems.Count <= 0)
                {
                    MessageBox.Show(config.ReadConfigValue("MJW2", "NM_Hint_selectServer"));
                    return;
                }
                if (chbNoticeImmed.Checked == false && nudTimeSpan.Value < 5)
                {
                    MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_SendIntervalNotbelowfive"));
                    return;
                }
                if (chbNoticeImmed.Checked != true)
                    if (Convert.ToInt32((DptEndTime.Value - DptStartTime.Value).TotalMinutes) < int.Parse(nudTimeSpan.Value.ToString()))
                    {
                        MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_StartandEndBelowInterval"));
                        return;
                    }
                if (typeSend == 1)
                {                    
                    if (DptStartTime.Value > DptEndTime.Value)
                    {
                        MessageBox.Show(config.ReadConfigValue("MJW2", "NM_Hint_TimeSpan"));
                        return;
                    }
                    if (DptEndTime.Value <= DateTime.Now)
                    {
                        MessageBox.Show(config.ReadConfigValue("MJW2", "NM_Hint_EndTime"));
                        return;
                    }
                }
                //if(cmbType.Text== "" )
                //{
                //    MessageBox.Show(config.ReadConfigValue("MJW2", "NM_Hint_typeNull"));
                //    return;
                //}
                if (this.txtContent.Text.Trim() == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MJW2", "NM_Hint_txtContent"));
                    return;
                }
                if (this.txtContent.Text.Trim().Length >= 512)
                {
                    MessageBox.Show(config.ReadConfigValue("MSD", "NM_Hint_contentLength"));
                    return;
                }

                serverIP = null;
                if (isCheck)
                {
                    serverIP = "255.255.255.255|";
                }
                else
                {
                    for (int i = 0; i < clbServer.CheckedItems.Count; i++)
                    {
                        serverIP += Operation_JW2.GetItemAddr(mServerInfo, clbServer.CheckedItems[i].ToString());
                        serverIP += "|";
                    }
                }

                int noticeType = 0;
                if (cmbType.Text == config.ReadConfigValue("MJW2", "NM_UI_cmbNoticeCheck"))
                {
                    noticeType = 0;
                }
                else if (cmbType.Text == config.ReadConfigValue("MJW2", "NM_UI_cmbNoticeCommon"))
                {
                    noticeType = 1;
                }
                else if (cmbType.Text == config.ReadConfigValue("MJW2", "NM_UI_cmbNoticeEvent"))
                {
                    noticeType = 2;
                }
                else if (cmbType.Text == config.ReadConfigValue("MJW2", "NM_UI_cmbNoticeSystem"))
                {
                    noticeType = 3;
                }

                content = txtContent.Text.Trim().Replace("\n", "\\");

                this.GrpServer.Enabled = false;
                this.GrpNotice.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[7];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = serverIP;

                mContent[1].eName = CEnum.TagName.JW2_GSServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = "255.255.255.255";

                mContent[2].eName = CEnum.TagName.UserByID;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent[3].eName = CEnum.TagName.JW2_Interval;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                if (typeSend == 0)
                    mContent[3].oContent = typeSend;
                else
                    mContent[3].oContent = int.Parse(nudTimeSpan.Value.ToString());


                mContent[4].eName = CEnum.TagName.JW2_BoardMessage;
                mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[4].oContent = content;

                mContent[5].eName = CEnum.TagName.JW2_EndTime;
                mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[5].oContent = DptEndTime.Value.ToString();

                mContent[6].eName = CEnum.TagName.JW2_BeginTime;
                mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[6].oContent = DptStartTime.Value.ToString();

                backgroundWorkerSendNotice.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 发送公告backgroundWorker消息发送
        private void backgroundWorkerSendNotice_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_BOARDTASK_INSERT, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 发送公告backgroundWorker消息接收
        private void backgroundWorkerSendNotice_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.GrpServer.Enabled = true;
            this.GrpNotice.Enabled = true;
            this.clbServer.Enabled = true;
            this.panel1.Enabled = true;
            this.btnNoticeInfo.Enabled = true;
            this.Cursor = Cursors.Default;//改变鼠标状态

            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

            if (mResult[0, 0].oContent.ToString().Trim() == "SCUESS")
            {
                MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_ControlSuccess"));
                //Operation_JW2.errLog.WriteLog(val[0,0].oContent.ToString());
            }
            else if (mResult[0, 0].oContent.ToString().Trim() == "FAILURE")
            {
                MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_ControlFailure"));
                //Operation_JW2.errLog.WriteLog(val[0, 0].oContent.ToString());
            }
            else
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString().Trim());
                //Operation_JW2.errLog.WriteLog(val[0, 0].oContent.ToString());
            }
            //chbNoticeImmed.Checked = false;
            //DptStartTime.Value = DateTime.Now;
            //DptStartTime.Enabled = true;
            //DptEndTime.Value = DateTime.Now;
            //DptEndTime.Enabled = true;
            //nudTimeSpan.Value = 1;
            //nudTimeSpan.Enabled = true;
            cmbType.Items.Clear();
            cmbType.Items.Add(config.ReadConfigValue("MJW2", "NM_UI_cmbNoticeCheck"));
            cmbType.Items.Add(config.ReadConfigValue("MJW2", "NM_UI_cmbNoticeCommon"));
            cmbType.Items.Add(config.ReadConfigValue("MJW2", "NM_UI_cmbNoticeEvent"));
            cmbType.Items.Add(config.ReadConfigValue("MJW2", "NM_UI_cmbNoticeSystem"));
            txtContent.Text = "";
            NoticeList();            
        }
        #endregion



        #region 编辑公告
        private void btnEditNotice_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.clbServer.CheckedItems.Count <= 0)
                {
                    MessageBox.Show(config.ReadConfigValue("MSD", "NM_Hint_selectServer"));
                    return;
                }
                if (DptStartTime.Value > DptEndTime.Value)
                {
                    MessageBox.Show(config.ReadConfigValue("MSD", "NM_Hint_TimeSpan"));
                    return;
                }
                if (DptEndTime.Value <= DateTime.Now)
                {
                    MessageBox.Show(config.ReadConfigValue("MSD", "NM_Hint_EndTime"));
                    return;
                }
                if (cmbType.Text == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSD", "NM_Hint_typeNull"));
                    return;
                }
                if (this.txtContent.Text.Trim() == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSD", "NM_Hint_txtContent"));
                    return;
                }
                if (this.txtContent.Text.Trim().Length >= 512)
                {
                    MessageBox.Show(config.ReadConfigValue("MSD", "NM_Hint_contentLength"));
                    return;
                }

                serverIP = null;
                if (isCheck)
                {
                    serverIP = "255.255.255.255,";
                }
                else
                {
                    for (int i = 0; i < clbServer.CheckedItems.Count; i++)
                    {
                        serverIP += Operation_JW2.GetItemAddr(mServerInfo, clbServer.CheckedItems[i].ToString());
                        serverIP += ",";
                    }
                }

                int noticeType = 0;
                if (cmbType.Text == config.ReadConfigValue("MSD", "NM_UI_cmbNoticeCheck"))
                {
                    noticeType = 0;
                }
                else if (cmbType.Text == config.ReadConfigValue("MSD", "NM_UI_cmbNoticeCommon"))
                {
                    noticeType = 1;
                }
                else if (cmbType.Text == config.ReadConfigValue("MSD", "NM_UI_cmbNoticeEvent"))
                {
                    noticeType = 2;
                }
                else if (cmbType.Text == config.ReadConfigValue("MSD", "NM_UI_cmbNoticeSystem"))
                {
                    noticeType = 3;
                }

                content = txtContent.Text.Trim().Replace("\n", "\\");

                this.GrpServer.Enabled = false;
                this.GrpNotice.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[10];

                mContent[0].eName = CEnum.TagName.SD_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = serverIP;

                mContent[1].eName = CEnum.TagName.UserByID;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent[2].eName = CEnum.TagName.SD_Limit;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = int.Parse(nudTimeSpan.Value.ToString());

                mContent[3].eName = CEnum.TagName.SD_Content;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = content;

                mContent[4].eName = CEnum.TagName.SD_EndTime;
                mContent[4].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                mContent[4].oContent = DptEndTime.Value;

                mContent[5].eName = CEnum.TagName.SD_StartTime;
                mContent[5].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                mContent[5].oContent = DptStartTime.Value;

                mContent[6].eName = CEnum.TagName.SD_Type;
                mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[6].oContent = noticeType;

                mContent[7].eName = CEnum.TagName.SD_SendType;
                mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[7].oContent = typeSend;

                mContent[8].eName = CEnum.TagName.SD_ID;
                mContent[8].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[8].oContent = noticeID;

                mContent[9].eName = CEnum.TagName.SD_Status;
                mContent[9].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[9].oContent = 0;

                backgroundWorkerEditNotice.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 编辑公告backgroundWorker消息发送
        private void backgroundWorkerEditNotice_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.SD_TaskList_Update, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 编辑公告backgroundWorker消息接收
        private void backgroundWorkerEditNotice_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.GrpServer.Enabled = true;
            this.GrpNotice.Enabled = true;
            this.Cursor = Cursors.Default;//改变鼠标状态

            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

            Operation_JW2.showResult(mResult);

            btnAddNotice.Enabled = true;
            btnAddNotice.Visible = true;

            BtnEdit.Enabled = false;
            BtnEdit.Visible = false;

            chbNoticeImmed.Checked = false;
            DptStartTime.Value = DateTime.Now;
            DptStartTime.Enabled = true;
            DptEndTime.Value = DateTime.Now;
            DptEndTime.Enabled = true;
            nudTimeSpan.Value = 1;
            nudTimeSpan.Enabled = true;
            cmbType.Items.Clear();
            cmbType.Items.Add(config.ReadConfigValue("MSD", "NM_UI_cmbNoticeCheck"));
            cmbType.Items.Add(config.ReadConfigValue("MSD", "NM_UI_cmbNoticeCommon"));
            cmbType.Items.Add(config.ReadConfigValue("MSD", "NM_UI_cmbNoticeEvent"));
            cmbType.Items.Add(config.ReadConfigValue("MSD", "NM_UI_cmbNoticeSystem"));
            txtContent.Text = "";
            NoticeList();
        }
        #endregion



        #region 重置信息
        private void btnReset_Click(object sender, EventArgs e)
        {
            DptStartTime.Value = DateTime.Now;
            DptEndTime.Value = DateTime.Now;
            nudTimeSpan.Value = 1;
            txtContent.Text = "";
            chbNoticeImmed.Checked = false;
        }
        #endregion
        
        #region 窗体关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void ItmDelete_Click(object sender, EventArgs e)
        {
            btnAddNotice.Enabled = false;
            btnAddNotice.Visible = false;

            BtnEdit.Enabled = true;
            BtnEdit.Visible = true;

            lblType.Visible = true;
            cmbType.Visible = true;
            DataTable mBoard = (DataTable)GrdNotice.DataSource;

            if (mBoard.Rows[iIndexID][4].ToString() == config.ReadConfigValue("MSDO", "FN_Code_infostate"))
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_noticefail"));
                return;
            }
            if (mBoard.Rows[iIndexID][4].ToString() == config.ReadConfigValue("MSDO", "FN_Code_infostate1"))
            {
                iBoardID = int.Parse(mBoard.Rows[iIndexID][0].ToString());
                DptStartTime.Text = mBoard.Rows[iIndexID][1].ToString();
                this.DptEndTime.Text = mBoard.Rows[iIndexID][2].ToString();
                cmbType.Text = mBoard.Rows[iIndexID][4].ToString();
                txtContent.Text = mBoard.Rows[iIndexID][5].ToString();
            }
            else if (mBoard.Rows[iIndexID][4].ToString() == config.ReadConfigValue("MSDO", "FN_Code_infostate2"))
            {
                iBoardID = int.Parse(mBoard.Rows[iIndexID][0].ToString());
                DptStartTime.Text = mBoard.Rows[iIndexID][1].ToString();
                DptStartTime.Enabled = false;
                DptEndTime.Text = mBoard.Rows[iIndexID][2].ToString();
                DptEndTime.Enabled = false;
                cmbType.Text = mBoard.Rows[iIndexID][4].ToString();
                txtContent.Text = mBoard.Rows[iIndexID][5].ToString();
                txtContent.Enabled = false;
                nudTimeSpan.Value = Convert.ToDecimal(mBoard.Rows[iIndexID][3].ToString());
                nudTimeSpan.Enabled = false;

            }

        }
        private int ReturnStauas(string strStauas)
        {
            int IntStauas = -1;
            if (strStauas == config.ReadConfigValue("MSDO", "FN_Code_infostate1").Trim())
            {
                IntStauas = 0;
            }
            else if (strStauas == config.ReadConfigValue("MSDO", "FN_Code_infostate2").Trim())
            {
                IntStauas = 2;
            }
            else if (strStauas == config.ReadConfigValue("MSDO", "FN_Code_infostate").Trim())
            {
                IntStauas = 1;
            }

            return IntStauas;
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            //this.cmbStauas.Items.Clear();
            //this.cmbStauas.Items.Add(config.ReadConfigValue("MJW2", "FN_Code_msgNoSendupdatenotice"));
            //this.cmbStauas.Items.Add(config.ReadConfigValue("MJW2", "FN_Code_msgSendingupdatenotice"));
            //this.cmbStauas.Items.Add(config.ReadConfigValue("MJW2", "FN_Code_msgSendedupdatenotice"));
            //this.cmbStauas.SelectedIndex = 0;


            if (MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_msgupdatenotice"), config.ReadConfigValue("MSDO", "FN_Code_msgnote"), MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (chbNoticeImmed.Checked == false && nudTimeSpan.Value < 5)
                {
                    MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_SendIntervalNotbelowfive"));
                    return;
                }
                if (chbNoticeImmed.Checked != true)
                    if (Convert.ToInt32((DptEndTime.Value - DptStartTime.Value).TotalMinutes) < int.Parse(nudTimeSpan.Value.ToString()))
                    {
                        MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_StartandEndBelowInterval"));
                        return;
                    }


                CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];



                mContent[0].eName = CEnum.TagName.JW2_Status;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = ReturnStauas(cmbStauas.Text.Trim());

                mContent[1].eName = CEnum.TagName.JW2_BoardMessage;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = txtContent.Text.Trim();

                mContent[2].eName = CEnum.TagName.UserByID;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent[3].eName = CEnum.TagName.JW2_TaskID;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = iBoardID;

                mContent[4].eName = CEnum.TagName.JW2_BeginTime;
                mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[4].oContent = DptStartTime.Text.ToString();

                mContent[5].eName = CEnum.TagName.JW2_EndTime;
                mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[5].oContent = DptEndTime.Text.ToString();

                mContent[6].eName = CEnum.TagName.JW2_Interval;
                mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[6].oContent = Convert.ToInt32(nudTimeSpan.Value);


                mContent[7].eName = CEnum.TagName.JW2_ServerIP;
                mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[7].oContent = "";
                //mContent[7].eName = CEnum.TagName.JW2_TaskID;
                //mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                //mContent[7].oContent = iBoardID;


                CEnum.Message_Body[,] mResult1 = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_BOARDTASK_UPDATE, mContent);

                if (mResult1[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult1[0, 0].oContent.ToString());
                    return;
                }

                if (mResult1[0, 0].eName == CEnum.TagName.Status && mResult1[0, 0].oContent.Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_ModiFailure"));
                    return;
                    this.cmbStauas.Visible = false;
                    this.label11.Visible = false;

                    this.label11.Visible = false;
                    this.cmbStauas.Visible = false;

                }
                else
                {
                    MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_ModiSuccess"));
                    cmbType.Visible = false;
                    lblType.Visible = false;

                    BtnEdit.Visible = false;
                    btnAddNotice.Visible = true;
                    this.label11.Visible = false;
                    this.cmbStauas.Visible = false;
                    Setdefault();

                    btnAddNotice.Enabled = true;
                    btnAddNotice.Visible = true;

                    this.cmbStauas.Enabled = false;
                    this.label11.Enabled = false;

                    //lblserver.Visible = false;

                    DptStartTime.Enabled = true;
                    DptEndTime.Enabled = true;
                    txtContent.Enabled = true;
                    nudTimeSpan.Enabled = true;
                }
            }
        }
        #region 恢复默认值
        /// <summary>
        /// 恢复默认值
        /// </summary>
        private void Setdefault()
        {
            DptStartTime.Value = DateTime.Now;
            DptEndTime.Value = DateTime.Now;
            nudTimeSpan.Value = 5;
            txtContent.Clear();
            //for (int i = 0; i < TxtCode.Items.Count; i++)
            //{
            //    TxtCode.SetItemChecked(i, false);

            //}

            isCheck = false;

        }
        #endregion
        private void txtContent_TextChanged(object sender, EventArgs e)
        {

        }

        private void 编辑公告信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
           
            btnAddNotice.Enabled = false;
            btnAddNotice.Visible = false;

            BtnEdit.Enabled = true;
            BtnEdit.Visible = true;
            cmbType.Enabled = true;
            txtContent.Enabled = true;
            this.label11.Visible = true;
            this.cmbStauas.Visible = true;
            cmbStauas.Enabled = true;
            this.label11.Enabled = true;
            DataTable mBoard = (DataTable)GrdNotice.DataSource;

            if (mBoard.Rows[iIndexID][4].ToString() == config.ReadConfigValue("MSDO", "FN_Code_infostate"))
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_noticefail"));
                return;
            }
            if (mBoard.Rows[iIndexID][4].ToString() == config.ReadConfigValue("MSDO", "FN_Code_infostate1"))
            {
                iBoardID = int.Parse(mBoard.Rows[iIndexID][0].ToString());
                DptStartTime.Text = mBoard.Rows[iIndexID][1].ToString();
                this.DptEndTime.Text = mBoard.Rows[iIndexID][2].ToString();
                cmbStauas.Text = mBoard.Rows[iIndexID][4].ToString();
                txtContent.Text = mBoard.Rows[iIndexID][5].ToString();
            }
            else if (mBoard.Rows[iIndexID][4].ToString() == config.ReadConfigValue("MSDO", "FN_Code_infostate2"))
            {
                iBoardID = int.Parse(mBoard.Rows[iIndexID][0].ToString());
                DptStartTime.Text = mBoard.Rows[iIndexID][1].ToString();
                DptStartTime.Enabled = false;
                DptEndTime.Text = mBoard.Rows[iIndexID][2].ToString();
                DptEndTime.Enabled = false;
                cmbStauas.Text = mBoard.Rows[iIndexID][4].ToString();
                txtContent.Text = mBoard.Rows[iIndexID][5].ToString();
                txtContent.Enabled = false;
                nudTimeSpan.Value = Convert.ToDecimal(mBoard.Rows[iIndexID][3].ToString());
                nudTimeSpan.Enabled = false;

            }
        }
        catch (System.Exception ex)
        {

        }
        }

        private void lblType_Click(object sender, EventArgs e)
        {

        }
    }
}