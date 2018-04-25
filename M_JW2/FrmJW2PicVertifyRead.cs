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
    [C_Global.CModuleAttribute("玩家日志信息", "FrmJW2PicVertifyRead", "玩家日志信息", "JW2 Group")]
    public partial class FrmJW2PicVertifyRead : Form
    {

        #region 变量

        private CEnum.Message_Body[,] mServerInfo = null;
        private CEnum.Message_Body[,] mResult = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;

        private int selectChar;
        private int currDgSelectRow;
        private string userId = null;
        private int iPageCount = 0;//翻页页数
        private bool bFirst;
        private string userAccount;
        private int selectAttri = 0;//查询属性道具


        private string FromUserID = null;
        private string ToUserID = null;

        private string FromUserName = null;
        private string ToUserName = null;

        private string FromPetID = null;
        private string ToPetID = null;

        private string FromPetName = null;
        private string ToPetName = null;

        private string begintime = null;
        private string logtime = null;

        private string bigType = null;
        private string smallType = null;

        private bool pageRoleView = false;
        private string strUrl;
        private string strUrlNoPin;
        private string struserId;
        private string strUsername;
        #endregion

        public FrmJW2PicVertifyRead()
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
            FrmJW2PicVertifyRead mModuleFrm = new FrmJW2PicVertifyRead();
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

            this.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2PicVertifyRead");
            label1.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2PicVertifytip");
            this.tpgCharacter.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmBugleSendLogtpgCharacter");

            lblRoleView.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            //this.chbSelect.Visible = false;
            //this.chbSelect.Checked = false;
        }


        #endregion



        #region 登陆窗体加载(得到游戏服务器列表)
        private void FrmJW2PicVertifyRead_Load(object sender, EventArgs e)
        {
            try
            {
                IntiFontLib();
                //TbcResult.Enabled = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
                mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = 12;

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



        #region 用搜索按钮查询玩家的基本信息
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                cmbRoleView.Items.Clear();
                if (cmbServer.Text == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MMagic", "UIA_Hint_selectServer"));
                    this.txtAccount.Text = "";
                    this.txtNick.Text = "";
                    this.GrdRoleView.DataSource = null;
                    return;
                }
                //清除控件
                this.tbcResult.SelectedTab = this.tpgCharacter;//选择角色信息选项卡
                this.GrdRoleView.DataSource = null;
                //if (txtAccount.Text.Trim().Length > 0 || txtNick.Text.Trim().Length > 0)
                //{
                    PartInfo();
                //}
                //else
                //{
                //    MessageBox.Show(config.ReadConfigValue("MMagic", "UIA_Hint_inPutAccont"));
                //    return;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 查询玩家资料信息
        private void PartInfo()
        {
            this.btnSearch.Enabled = false;//禁用搜索按钮
            //this.TbcResult.Enabled = false;
            this.Cursor = Cursors.WaitCursor;//改变鼠标状态
            this.GrdRoleView.DataSource = null;

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];
            //查询玩家角色信息
            mContent[0].eName = CEnum.TagName.JW2_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

            mContent[1].eName = CEnum.TagName.JW2_ACCOUNT;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = this.txtAccount.Text.ToString().Trim();

            mContent[2].eName = CEnum.TagName.JW2_UserNick;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = this.txtNick.Text.ToString().Trim();

            mContent[3].eName = CEnum.TagName.Index;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = 1;

            mContent[4].eName = CEnum.TagName.PageSize;
            mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[4].oContent =Operation_JW2.iPageSize;

            backgroundWorkerSearch.RunWorkerAsync(mContent);

        }
        #endregion

        #region 查询玩家资料信息backgroundWorker消息发送
        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_GETPIC_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询玩家资料信息backgroundWorker消息接收
        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.btnSearch.Enabled = true;//查询按钮使能
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, this.GrdRoleView, out iPageCount);

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion



        #region 单击玩家基本信息保存当前行号
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currDgSelectRow = e.RowIndex;
        }
        #endregion

        #region 双击玩家基本信息查询日志信息
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.tbcResult.SelectedIndex = 1;
            //this.dataGridView2.DataSource = null;
        }
        #endregion

        private void GrdRoleView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectChar=e.RowIndex;
            this.tbcResult.SelectedIndex = 1;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text));
        }

        private void backgroundWorkerReSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_GETPIC_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.btnSearch.Enabled = true;//查询按钮使能
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, this.GrdRoleView, out iPageCount);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmbRoleView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageRoleView)
            {
                //this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态

                this.pageRoleView = false;

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
                mContent[4].oContent = int.Parse(this.cmbRoleView.Text.ToString());

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_JW2.iPageSize;

                backgroundWorkerReSearch.RunWorkerAsync(mContent);
            }
        }

        private void tbcResult_Selected(object sender, TabControlEventArgs e)
        {

            try
            {
                if (GrdRoleView.DataSource != null)
                {
                    DataTable mTable = (DataTable)GrdRoleView.DataSource;

                    strUrl = mTable.Rows[selectChar][2].ToString();
                    strUrlNoPin = strUrl;
                    strUrl = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text).ToString() + "/" + strUrl + ".jpg";
                    struserId = mTable.Rows[selectChar][0].ToString();
                    strUsername = mTable.Rows[selectChar][1].ToString();
                    //webBrowser1.Navigate("about:blank");
                    if (this.tbcResult.SelectedIndex == 1)
                    {
                        //if (strUrl != "")
                            //this.webBrowser1.Navigate(strUrl);
                        //webBrowser1.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);


                mContent[1].eName = CEnum.TagName.JW2_UserSN;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent =int.Parse(struserId);


                mContent[3].eName = CEnum.TagName.JW2_UserID;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = strUsername;

                mContent[4].eName = CEnum.TagName.UserByID;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent[5].eName = CEnum.TagName.JW2_ItemPos;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = 2;

                mContent[2].eName = CEnum.TagName.jw2_pic_Name;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = strUrlNoPin;

                this.backgroundWorkerPicVertify.RunWorkerAsync(mContent);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void backgroundWorkerPicVertify_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_CHKPIC_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerPicVertify_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态

                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

                if (mResult[0, 0].oContent.ToString().Trim() == "SCUESS")
                {
                    MessageBox.Show("設置審核通過成功");
                    //FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                    //StreamWriter streamWriter = new StreamWriter(fs);
                    //streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    //streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                    //streamWriter.Flush();
                    //fs.Close();

                    //Operation_JW2.errLog.WriteLog("设置GM权限成功");
                }
                else if (mResult[0, 0].oContent.ToString().Trim() == "FAILURE")
                {
                    MessageBox.Show("設置審核通過失敗");
                    //FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                    //StreamWriter streamWriter = new StreamWriter(fs);
                    //streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    //streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                    //streamWriter.Flush();
                    //fs.Close();
                    //Operation_JW2.errLog.WriteLog("设置GM权限失败");
                }
                else
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString().Trim());
                    //FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                    //StreamWriter streamWriter = new StreamWriter(fs);
                    //streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    //streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                    //streamWriter.Flush();
                    //fs.Close();
                }
                this.btnSearch_Click(null, null);
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

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);


                mContent[1].eName = CEnum.TagName.JW2_UserSN;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = int.Parse(struserId);


                mContent[3].eName = CEnum.TagName.JW2_UserID;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = strUsername;

                mContent[4].eName = CEnum.TagName.UserByID;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent[5].eName = CEnum.TagName.JW2_ItemPos;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = 3;

                mContent[2].eName = CEnum.TagName.jw2_pic_Name;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = strUrlNoPin;

                this.backgroundWorkerPicVertify.RunWorkerAsync(mContent);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}