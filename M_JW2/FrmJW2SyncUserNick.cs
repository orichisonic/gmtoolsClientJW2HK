using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Global;
using C_Event;

using Language;

namespace M_AU
{
    [C_Global.CModuleAttribute("昵称同步", "SyncUserNick", "劲舞团2", "JW2")]
    public partial class FrmJW2SyncUserNick : Form
    {
        #region 调用函数
        /// <summary>
        /// 创建类库中的窗体
        /// </summary>
        /// <param name="oParent">MDI 程序的父窗体</param>
        /// <param name="oSocket">Socket</param>
        /// <returns>类库中的窗体</returns>
        public Form CreateModule(object oParent, object oEvent)
        {
            this.m_ClientEvent = (CSocketEvent)oEvent;
            if (oParent != null)
            {
                this.MdiParent = (Form)oParent;
                this.Show();
            }
            else
            {
                this.ShowDialog();
            }
            return this;
        }
        #endregion

        #region 变量
        private CSocketEvent m_ClientEvent = null;

        string _serverIP = null;    //服务器ip

        C_Global.CEnum.Message_Body[,] serverIPResult = null;    //ip列表信息


        C_Global.CEnum.Message_Body[,] accountResultNY = null;    //玩家信息列表
        C_Global.CEnum.Message_Body[,] accountResult = null;    //玩家信息列表
        C_Global.CEnum.Message_Body[,] doResult = null;    //玩家信息列表

        #endregion

        #region 函数

        /// <summary>
        /// 初始化道具所在服务器列表
        /// </summary>
        public void InitializeServerIP()
        {
            try
            {
                this.cbxServerIP.Items.Clear();

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.ServerInfo_GameID;
                messageBody[0].oContent = m_ClientEvent.GetInfo("GameID_AU");

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 2;

                this.backgroundWorkerFormLoad.RunWorkerAsync(messageBody);

                //lock (typeof(C_Event.CSocketEvent))
                //{
                //    serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);
                //} 

                ////检测状态
                //if (serverIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
                //    //Application.Exit();
                //    return;
                //}

                ////显示内容到列表
                //for (int i = 0; i < serverIPResult.GetLength(0); i++)
                //{
                //    this.cbxServerIP.Items.Add(serverIPResult[i, 1].oContent.ToString());
                //}

                //cbxServerIP.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 读取玩家Ａｕ帐号
        /// </summary>
        private bool ReadAuNickName()
        {
            bool isExistNick = true;
            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[0].eName = C_Global.CEnum.TagName.AU_ServerIP;
            messageBody[0].oContent = _serverIP;

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[1].eName = C_Global.CEnum.TagName.AU_ACCOUNT;
            messageBody[1].oContent = txtAccount.Text;

            lock (typeof(C_Event.CSocketEvent))
            {
                accountResult = m_ClientEvent.GetSocket(m_ClientEvent, _serverIP).RequestResult(CEnum.ServiceKey.AU_ACCOUNT_QUERY, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);
            }
            if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                isExistNick = false;
            }
            else
            {
                isExistNick = true;
                txtAUNick.Text = accountResult[0, 2].oContent.ToString();
            }

            return isExistNick;
        }



        /// <summary>
        /// 读取玩家９ｙｏｕ帐号
        /// </summary>
        private bool ReadNYNickName()
        {
            bool isExistNick = true;
            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[1];

            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[0].eName = C_Global.CEnum.TagName.UserName;
            messageBody[0].oContent = txtAccount.Text;

            lock (typeof(C_Event.CSocketEvent))
            {
                accountResultNY = m_ClientEvent.RequestResult(CEnum.ServiceKey.CARD_USERNICK_QUERY, C_Global.CEnum.Msg_Category.CARD_ADMIN, messageBody);
            }
            if (accountResultNY[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                isExistNick = false;
            }
            else
            {
                isExistNick = true;
                txtNYNick.Text = accountResultNY[0, 0].oContent.ToString();
            }

            return isExistNick;

        }

        /// <summary>
        /// 同步昵称
        /// </summary>
        /// <returns></returns>
        private void SyncAuUserNick()
        {
            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];

            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[0].eName = C_Global.CEnum.TagName.AU_ServerIP;
            messageBody[0].oContent = _serverIP;

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[1].eName = C_Global.CEnum.TagName.AU_ACCOUNT;
            messageBody[1].oContent = txtAccount.Text;

            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[2].eName = C_Global.CEnum.TagName.AU_UserNick;
            messageBody[2].oContent = txtNYNick.Text;

            messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[3].eName = C_Global.CEnum.TagName.UserByID;
            messageBody[3].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            this.backgroundWorkerSync.RunWorkerAsync(messageBody);

            //lock (typeof(C_Event.CSocketEvent))
            //{
            //    doResult = m_ClientEvent.GetSocket(m_ClientEvent, _serverIP).RequestResult(CEnum.ServiceKey.AU_USERNICK_UPDATE, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);
            //}
            //if (doResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(doResult[0, 0].oContent.ToString());
            //    return;
            //}

            //if (doResult[0, 0].oContent.ToString().ToUpper().Equals("SUCESS"))
            //{
            //    MessageBox.Show("成功");

            //    txtAccount.Enabled = true;
            //    btnSearch.Enabled = true;
            //    cbxServerIP.Enabled = true;
            //    gbNickResult.Enabled = false;
            //    txtAccount.Clear();
            //    txtAUNick.Clear();
            //    txtNYNick.Clear();


            //    return;
            //}

            //if (doResult[0, 0].oContent.ToString().ToUpper().Equals("FAILURE"))
            //{
            //    MessageBox.Show("失败");
            //    return;
            //}
            

        }



       
        #endregion


        public FrmJW2SyncUserNick()
        {
            InitializeComponent();
        }

        #region 语言库
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
            //this.Text = config.ReadConfigValue("MAU", "SU_UI_frmname");
            //this.label1.Text = config.ReadConfigValue("MAU", "SU_UI_label1");
            //this.label2.Text = config.ReadConfigValue("MAU", "SU_UI_label2");
            //this.label3.Text = config.ReadConfigValue("MAU", "SU_UI_label3");
            //this.label4.Text = config.ReadConfigValue("MAU", "SU_UI_label4");
            //this.gbNickResult.Text = config.ReadConfigValue("MAU", "SU_UI_gbNickResult");
            //this.btnSync.Text = config.ReadConfigValue("MAU", "SU_UI_btnSync");
            //this.gbSearch.Text = config.ReadConfigValue("MAU", "SU_UI_gbSearch");

            //this.button1.Text = config.ReadConfigValue("MAU", "SU_UI_button1");
            //this.btnSearch.Text = config.ReadConfigValue("MAU", "SU_UI_btnSearch");

            this.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2SyncUserNick");

            gbSearch.Text = config.ReadConfigValue("MJW2", "UIC_UI_btnSearch");
            label1.Text = config.ReadConfigValue("MJW2", "NEW_UI_ServerName");

            btnSearch.Text = config.ReadConfigValue("MJW2", "UIC_UI_btnSearch");
            button1.Text = config.ReadConfigValue("MJW2", "BP_UI_btnReset");

            gbNickResult.Text = config.ReadConfigValue("MJW2", "BP_UI_btnReset");

            label3.Text = config.ReadConfigValue("MJW2", "NEW_UI_9YouNickName");

            btnSync.Text = config.ReadConfigValue("MJW2", "NEW_UI_SynAUNickName");
        }


        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtAccount.Text == null || txtAccount.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "SU_Code_inputaccont"));
                txtAccount.Focus();
                return;
            }

            #region IP检索
            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                {
                    _serverIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion
            btnSearch.Enabled = false;
            Cursor = Cursors.WaitCursor;

            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[0].eName = C_Global.CEnum.TagName.AU_ServerIP;
            messageBody[0].oContent = _serverIP;

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[1].eName = C_Global.CEnum.TagName.AU_ACCOUNT;
            messageBody[1].oContent = txtAccount.Text;

            this.backgroundWorkerSearch.RunWorkerAsync(messageBody);

            //if (ReadAuNickName() && ReadNYNickName())
            //{
            //    gbNickResult.Enabled = true;
            //    txtAccount.Enabled = false;
            //    btnSearch.Enabled = false;
            //    cbxServerIP.Enabled = false;
            //}
            //else
            //{
            //    gbNickResult.Enabled = false;
            //    MessageBox.Show(config.ReadConfigValue("MAU", "SU_Code_err"));
            //}


            
        }

        private void FrmJW2SyncUserNick_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            gbNickResult.Enabled = false;

            txtAUNick.ReadOnly = true;
            txtNYNick.ReadOnly = true;

            InitializeServerIP();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            btnSync.Enabled = false;
            Cursor = Cursors.WaitCursor;
            SyncAuUserNick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtAccount.Enabled = true;
            txtAccount.Clear();
            btnSearch.Enabled = true;
            cbxServerIP.Enabled = true;
            gbNickResult.Enabled = false;
            txtAUNick.Clear();
            txtNYNick.Clear();
        }

        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //检测状态

            if (serverIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
                //Application.Exit();
                return;
            }

            //显示内容到列表

            for (int i = 0; i < serverIPResult.GetLength(0); i++)
            {
                this.cbxServerIP.Items.Add(serverIPResult[i, 1].oContent.ToString());
            }

            cbxServerIP.SelectedIndex = 0;
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            C_Global.CEnum.Message_Body[] messageBody = new CEnum.Message_Body[1];
            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[0].eName = C_Global.CEnum.TagName.UserName;
            messageBody[0].oContent = ((CEnum.Message_Body[])e.Argument)[1].oContent.ToString();

            lock (typeof(C_Event.CSocketEvent))
            {
                accountResult = m_ClientEvent.GetSocket(m_ClientEvent, _serverIP).RequestResult(CEnum.ServiceKey.AU_ACCOUNT_QUERY, C_Global.CEnum.Msg_Category.AU_ADMIN, (CEnum.Message_Body[])e.Argument);
                accountResultNY = m_ClientEvent.RequestResult(CEnum.ServiceKey.CARD_USERNICK_QUERY, C_Global.CEnum.Msg_Category.CARD_ADMIN, messageBody);
            }
            if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg || accountResultNY[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                e.Cancel = true;
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSearch.Enabled = true;
            Cursor = Cursors.Default;
            if (!e.Cancelled)
            {
                txtNYNick.Text = accountResultNY[0, 0].oContent.ToString();
                txtAUNick.Text = accountResult[0, 2].oContent.ToString();
                gbNickResult.Enabled = true;
                txtAccount.Enabled = false;
                btnSearch.Enabled = false;
                cbxServerIP.Enabled = false;
            }
            else
            {
                gbNickResult.Enabled = false;
                MessageBox.Show(config.ReadConfigValue("MAU", "SU_Code_err"));
            }
        }

        private void backgroundWorkerSync_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                doResult = m_ClientEvent.GetSocket(m_ClientEvent, _serverIP).RequestResult(CEnum.ServiceKey.AU_USERNICK_UPDATE, C_Global.CEnum.Msg_Category.AU_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSync_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSync.Enabled = true;
            Cursor = Cursors.Default;
            if (doResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(doResult[0, 0].oContent.ToString());
                return;
            }

            if (doResult[0, 0].oContent.ToString().ToUpper().Equals("SUCESS"))
            {
                MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_ControlSuccess"));

                txtAccount.Enabled = true;
                btnSearch.Enabled = true;
                cbxServerIP.Enabled = true;
                gbNickResult.Enabled = false;
                txtAccount.Clear();
                txtAUNick.Clear();
                txtNYNick.Clear();


                return;
            }

            if (doResult[0, 0].oContent.ToString().ToUpper().Equals("FAILURE"))
            {
                MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_ControlFailure"));
                return;
            }
        }
    }
}