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

using System.IO;
using System.Globalization;

namespace M_JW2
{
    [C_Global.CModuleAttribute("用户信息查询", "FrmJW2UserManage", "用户信息查询", "JW2 Group")]
    public partial class FrmJW2UserManage : Form
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
        bool pageRoleView = false;
        string userLevel;
        string userExp;
        int currDgSelectRow = 0;    //玩家信息datagrid 中当前选中的行
        //string userNick=null;
        #endregion

        public FrmJW2UserManage()
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
            FrmJW2UserManage mModuleFrm = new FrmJW2UserManage();
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
            this.btnClose.Text = config.ReadConfigValue("MSD", "UIC_UI_btnClose");
            this.BtnSearch.Text = config.ReadConfigValue("MSD", "UIC_UI_btnSearch");
            //this.tpgCharacter.Text = config.ReadConfigValue("MSD", "UIC_UI_tpgCharacter");


            this.tpgCharacter.Text= config.ReadConfigValue("MJW2", "UIC_UI_btnSearch");
            this.tpgModifyPass.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgModifyPass");
            this.tpgModifyUser.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgModifyUser");


            lblBodyItemInfo.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");

            label3.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgModifyContent");

            label2.Text = config.ReadConfigValue("MJW2", "NEW_UI_RoleNick");

            label4.Text = config.ReadConfigValue("MJW2", "NEW_UI_NowLevel");


            button1.Text = config.ReadConfigValue("MJW2", "NEW_UI_Commit");

            button2.Text = config.ReadConfigValue("MJW2", "BP_UI_btnReset");

            label6.Text = config.ReadConfigValue("MJW2", "NEW_UI_AccountNumber");

            label7.Text = config.ReadConfigValue("MJW2", "NEW_UI_NewPassword");

            button3.Text = config.ReadConfigValue("MJW2", "NEW_UI_tpgModifyPass");
            button4.Text = config.ReadConfigValue("MJW2", "NEW_UI_RecoverPassword");

            button5.Text = config.ReadConfigValue("MJW2", "NEW_UI_QueryPassword");

            this.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2UserManage");
            tbcResult.Enabled = true;
        }
        #endregion



        #region 登陆窗体加载(得到游戏服务器列表)
        private void FrmJW2UserManage_Load(object sender, EventArgs e)
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
            CmbServer = Operation_JW2.BuildCombox(mServerInfo, CmbServer);
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text));
        }
        #endregion



        #region 切换不同的游戏服务器
        private void cmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text));
        }
        #endregion

        #region
        private void tbcResult_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                if (this.RoleGridView.DataSource != null)
                {
                    DataTable mTable = (DataTable)RoleGridView.DataSource;
                    serverIP = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);
                    userID = int.Parse(mTable.Rows[selectChar][config.ReadConfigValue("GLOBAL", "JW2_UserSN")].ToString());//保存玩家帐号ID
                    userName = mTable.Rows[selectChar][config.ReadConfigValue("GLOBAL", "JW2_UserID")].ToString();
                    userNick = mTable.Rows[selectChar][2].ToString();
                    userLevel = mTable.Rows[selectChar][5].ToString();
                    userExp = mTable.Rows[selectChar][6].ToString();
                    if(this.tbcResult.SelectedIndex==1)
                    {
                        this.cmbModiContent.Items.Clear();
                        this.cmbModiContent.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_ModiLevel"));
                        this.cmbModiContent.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_ModiEXP"));

                        this.cmbModiContent.SelectedIndex = 0;

                        this.textBox1.Text = userName;

                        this.textBox2.Text = userLevel;

                    }
                    else if(this.tbcResult.SelectedIndex==2)
                    {
                        this.textBox4.Text = userNick;
                    }


                }

                else
                {
                




                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim().Length <= 0)
                {
                    MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_PleaseSelectRoleFirest"));
                   

                    return;
                }
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.JW2_ServerName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = CmbServer.Text.ToString();

                mContent[2].eName = CEnum.TagName.JW2_UserSN;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = userID;


                mContent[4].eName = CEnum.TagName.JW2_UserID;
                mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[4].oContent = userName;

                mContent[5].eName = CEnum.TagName.UserByID;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());
                if (this.cmbModiContent.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_ModiEXP"))
                {
                    mContent[3].eName = CEnum.TagName.JW2_Exp;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(this.textBox3.Text);

                    this.backgroundWorkerModiExp.RunWorkerAsync(mContent);
                }
                else if (this.cmbModiContent.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_ModiLevel"))
                {
                    mContent[3].eName = CEnum.TagName.JW2_Level;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(this.textBox3.Text);

                    backgroundWorkerModiLvl.RunWorkerAsync(mContent);
                }


              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region
        private void button2_Click(object sender, EventArgs e)
        {
            this.cmbModiContent.SelectedIndex = 0;
            textBox3.Text = "";

        }
        #endregion

        #region
        private void backgroundWorkerModiExp_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_MODIFYEXP_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
        private void backgroundWorkerModiExp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态

                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

                if (mResult[0, 0].oContent.ToString().Trim() == "SCUESS")
                {
                    MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_ControlSuccess"));

                    FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                    streamWriter.Flush();
                    fs.Close();
                    //Operation_JW2.errLog.WriteLog("修改用戶成功");
                }
                else if (mResult[0, 0].oContent.ToString().Trim() == "FAILURE")
                {
                    MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_ControlFailure"));


                    FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                    streamWriter.Flush();
                    fs.Close();
                    //Operation_JW2.errLog.WriteLog("修改用戶失敗");
                }
                else
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString().Trim());


                    FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                    streamWriter.Flush();
                    fs.Close();
                }

                this.BtnSearch_Click(null, null);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region
        private void backgroundWorkerModiLvl_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_MODIFYLEVEL_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
        private void backgroundWorkerModiLvl_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
            
            this.GrpSearch.Enabled = true;
            this.tbcResult.Enabled = true;
            this.Cursor = Cursors.Default;//改变鼠标状态

            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

            if (mResult[0, 0].oContent.ToString().Trim() == "SCUESS")
            {
                MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_ModiLevelSuccess"));

                FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                StreamWriter streamWriter = new StreamWriter(fs);
                streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                streamWriter.Flush();
                fs.Close();
                //Operation_JW2.errLog.WriteLog("修改等級成功");
            }
            else if (mResult[0, 0].oContent.ToString().Trim() == "FAILURE")
            {
                MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_ModiLevelFailure"));


                FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                StreamWriter streamWriter = new StreamWriter(fs);
                streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                streamWriter.Flush();
                fs.Close();
                //Operation_JW2.errLog.WriteLog("修改等級失敗");
            }
            else
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString().Trim());

                FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                StreamWriter streamWriter = new StreamWriter(fs);
                streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                streamWriter.Flush();
                fs.Close();
            }

            this.BtnSearch_Click(null, null);
        }
        catch (System.Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
        #endregion

        #region
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态

                this.pageRoleView = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

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
        #endregion

        #region
        private void cmbBodyItemInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageRoleView)
            {


                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

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
        #endregion

        #region
        private void cmbModiContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbModiContent.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_ModiLevel"))
            {
                label4.Text = config.ReadConfigValue("MJW2", "NEW_UI_NowLevel");
                label5.Text = config.ReadConfigValue("MJW2", "NEW_UI_NewLevel");

                textBox2.Text = userLevel;

            }
            else if (this.cmbModiContent.Text.ToString() == "修改經驗")
            {
                label4.Text = config.ReadConfigValue("MJW2", "NEW_UI_NowEXP");
                label5.Text = config.ReadConfigValue("MJW2", "NEW_UI_newEXP");

                textBox2.Text = userExp;

            }

        }
        #endregion

        #region
        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_ACCOUNT_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
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

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, RoleGridView, out iPageCount);

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
        #endregion

        #region
        private void backgroundWorkerReSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_ACCOUNT_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
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

                Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, RoleGridView, out iPageCount);

               
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region
        private void RoleGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            currDgSelectRow = e.RowIndex;
            this.tbcResult.SelectedIndex = 1;
        }
        #endregion

        #region
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBox4.Text.Trim() == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSD", "AM_Hint_selectChar"));
                    return;
                }

                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.JW2_ServerName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = CmbServer.Text.ToString();

                mContent[2].eName = CEnum.TagName.JW2_UserSN;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = userID;


                mContent[4].eName = CEnum.TagName.JW2_UserID;
                mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[4].oContent = userName;

                mContent[5].eName = CEnum.TagName.UserByID;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent[3].eName = CEnum.TagName.JW2_TmpPWD;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = this.textBox5.Text.ToString();

                this.backgroundWorkerRecoverPassword.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text.Trim().Length <= 0)
                {
                    MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_PleaseSelectRoleFirest"));


                    return;
                }
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.JW2_ServerName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = CmbServer.Text.ToString();

                mContent[2].eName = CEnum.TagName.JW2_UserSN;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = userID;


                mContent[4].eName = CEnum.TagName.JW2_UserID;
                mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[4].oContent = userName;

                mContent[5].eName = CEnum.TagName.UserByID;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent[3].eName = CEnum.TagName.JW2_TmpPWD;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = this.textBox5.Text.ToString();


                backgroundWorkerModiPassword.RunWorkerAsync(mContent);

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
    
            }
        }
        #endregion

        #region

        private void backgroundWorkerModiPassword_DoWork(object sender, DoWorkEventArgs e)
        {
           lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_MODIFY_PWD, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
        private void backgroundWorkerModiPassword_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态

                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

                if (mResult[0, 0].oContent.ToString().Trim() == "SCUESS")
                {
                    MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_modiPassSuccess"));


                    FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                    streamWriter.Flush();
                    fs.Close();
                    //Operation_JW2.errLog.WriteLog("修改密码成功");
                }
                else if (mResult[0, 0].oContent.ToString().Trim() == "FAILURE")
                {
                    MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_modiPassFailure"));


                    FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                    streamWriter.Flush();
                    fs.Close();

                    //Operation_JW2.errLog.WriteLog("修改密码失败");
                }
                else
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString().Trim());


                    FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                    streamWriter.Flush();
                    fs.Close();

                    //Operation_JW2.errLog.WriteLog(mResult[0, 0].oContent.ToString().Trim());
                }
                this.BtnSearch_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region
        private void backgroundWorkerRecoverPassword_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_RECALL_PWD, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
        private void backgroundWorkerRecoverPassword_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.GrpSearch.Enabled = true;
                this.tbcResult.Enabled = true;
                this.Cursor = Cursors.Default;//改变鼠标状态

                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

                if (mResult[0, 0].oContent.ToString().Trim() == "SCUESS")
                {
                    MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_recoverPassSuccess"));
                    FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                    streamWriter.Flush();
                    fs.Close();
                    //Operation_JW2.errLog.WriteLog("恢复密码成功");
                }
                else if (mResult[0, 0].oContent.ToString().Trim() == "FAILURE")
                {
                    MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_recoverPassFailure"));

                    FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                    streamWriter.Flush();
                    fs.Close();
                    //Operation_JW2.errLog.WriteLog("恢复密码失败");
                }
                else
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString().Trim());

                    FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                    streamWriter.Flush();
                    fs.Close();
                    //Operation_JW2.errLog.WriteLog(mResult[0, 0].oContent.ToString().Trim());

                }
                this.BtnSearch_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.JW2_ServerName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = CmbServer.Text.ToString();

                mContent[2].eName = CEnum.TagName.JW2_UserSN;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = userID;


                mContent[4].eName = CEnum.TagName.JW2_UserID;
                mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[4].oContent = userName;

              

                mContent[3].eName = CEnum.TagName.JW2_TmpPWD;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = this.textBox5.Text.ToString();


                backgroundWorkerCheckPwd.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
              
            }
        }
        #endregion

        #region
        private void backgroundWorkerCheckPwd_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(tmp_ClientEvent, CEnum.ServiceKey.JW2_SearchPassWord_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
        private void backgroundWorkerCheckPwd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.GrpSearch.Enabled = true;
            this.tbcResult.Enabled = true;
            this.Cursor = Cursors.Default;//改变鼠标状态

            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                //Operation_JW2.errLog.WriteLog(mResult[0, 0].oContent.ToString());
                return;
            }

            textBox5.Text = mResult[0, 0].oContent.ToString().Trim();
        }
        #endregion


    }
}