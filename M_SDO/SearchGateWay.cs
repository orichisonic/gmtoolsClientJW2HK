using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using C_Global;
using C_Event;
using Language;

namespace M_SDO
{
    [C_Global.CModuleAttribute("查询GateWay", "SearchGateWay", "查询GateWay", "SDO Group")]
    public partial class SearchGateWay : Form
    {
        public SearchGateWay()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
        public CSocketEvent m_ClientEvent = null;
        private CEnum.Message_Body[,] mServerInfo = null;
        private CEnum.Message_Body[,] serverIPResult = null;
        private CSocketEvent tmp_ClientEvent = null;
        private string _ServerIP = null;

        private int pageIndex = 1;
        private int pageSize = 30;
        private int pageCount = 0;
        private bool bFirst = false;
        #endregion

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
            this.Text = config.ReadConfigValue("MSDO", "GW_UI_SearchGateWay");
            this.GrpResult.Text = config.ReadConfigValue("MSDO", "GW_UI_GrpResult");
            this.LblPage.Text = config.ReadConfigValue("MSDO", "GW_UI_LblPage");
            this.GrpSearch.Text = config.ReadConfigValue("MSDO", "GW_UI_GrpSearch");
            this.LblServer.Text = config.ReadConfigValue("MSDO", "GW_UI_LblServer");
            this.BtnClose.Text = config.ReadConfigValue("MSDO", "GW_UI_BtnClose");
            this.BtnSearch.Text = config.ReadConfigValue("MSDO", "GW_UI_BtnSearch");
            this.LblIP.Text = config.ReadConfigValue("MSDO", "GW_UI_LblIP");
            this.buttonClear.Text = config.ReadConfigValue("MSDO", "GW_UI_buttonClear");

        }


        #endregion


        #region 函数
        /// <summary>
        /// 初始化游戏服务器列表
        /// </summary>
        public void InitializeServerIP()
        {
            try
            {
                this.CmbServer.Items.Clear();

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.ServerInfo_GameID;
                messageBody[0].oContent = m_ClientEvent.GetInfo("GameID_SDO");

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 1;

                this.backgroundWorkerFormLoad.RunWorkerAsync(messageBody);

            //    serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);

            //    //检测状态

            //    if (serverIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            //    {
            //        //游戏列表为空错误信息
            //        //MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
            //        //Application.Exit();
            //        return;
            //    }

            //    //显示内容到列表

            //    for (int i = 0; i < serverIPResult.GetLength(0); i++)
            //    {
            //        this.CmbServer.Items.Add(serverIPResult[i, 1].oContent.ToString());
            //    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (this.TxtIP.Text.Trim() == "" || this.CmbServer.Text =="")
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "GW_Code_Msg1"));
                return;
            }
            if (this.backgroundWorkerPageChanged.IsBusy)
            {
                return;
            }
            #region IP检索

            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.CmbServer.Text.Trim()))
                {
                    this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion

            this.CmbPage.Items.Clear();
            this.GrdResult.DataSource = null;
            this.bFirst = false;
            this.pageIndex = 1;
            this.BtnSearch.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

            mContent[0].eName = CEnum.TagName.SDO_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = _ServerIP;

            mContent[1].eName = CEnum.TagName.SDO_Address;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = this.TxtIP.Text.Trim();

            mContent[2].eName = CEnum.TagName.PageSize;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = this.pageSize;

            mContent[3].eName = CEnum.TagName.Index;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = this.pageIndex;

            this.backgroundWorkerSearch.RunWorkerAsync(mContent);
        }

        private void SeachGateWay_Load(object sender, EventArgs e)
        {
            IntiFontLib();

            InitializeServerIP();
            
        }

        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                this.serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PnlPage.Visible = false;
            //检测状态

            if (serverIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            {
                //游戏列表为空错误信息
                MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
                //Application.Exit();
                return;
            }

            //显示内容到列表

            for (int i = 0; i < serverIPResult.GetLength(0); i++)
            {
                this.CmbServer.Items.Add(serverIPResult[i, 1].oContent.ToString());
            }
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(serverIPResult, CmbServer.Text));
        }

        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(serverIPResult, CmbServer.Text));
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(this.tmp_ClientEvent, CEnum.ServiceKey.SDO_GATEWAY_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                this.Cursor = Cursors.Default;
                this.BtnSearch.Enabled = true;
                return;
            }
            this.GrpResult.Visible = true;
            this.PnlPage.Visible = true;
            if (this.CmbPage.Items.Count == 0)
            {
                this.pageCount = int.Parse(mResult[0, 1].oContent.ToString());
                for (int i = 0; i < pageCount; i++)
                {
                    CmbPage.Items.Add(i + 1);
                }
                
                CmbPage.SelectedIndex = 0;
                bFirst = true;
            }
            Operation_SDO.BuildDataTable(tmp_ClientEvent, mResult, this.GrdResult, out this.pageCount);
            this.Cursor = Cursors.Default;
            this.BtnSearch.Enabled = true;
            
        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirst)
            {
                if (this.backgroundWorkerSearch.IsBusy)
                {
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                this.CmbPage.Enabled = false;
                this.GrdResult.DataSource = null;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

                mContent[0].eName = CEnum.TagName.SDO_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = _ServerIP;

                mContent[1].eName = CEnum.TagName.SDO_Address;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = this.TxtIP.Text.Trim();

                mContent[2].eName = CEnum.TagName.PageSize;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = this.pageSize;

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = (int.Parse(CmbPage.Text) - 1) * this.pageSize + 1;

                this.backgroundWorkerPageChanged.RunWorkerAsync(mContent);
            }
        }

        private void backgroundWorkerPageChanged_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(this.tmp_ClientEvent, CEnum.ServiceKey.SDO_GATEWAY_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerPageChanged_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                this.Cursor = Cursors.Default;
                this.CmbPage.Enabled = true;
                return;
            }
            this.PnlPage.Visible = true;
            if (this.CmbPage.Items.Count == 0)
            {
                this.pageCount = int.Parse(mResult[0, 1].oContent.ToString());
                for (int i = 0; i < pageCount; i++)
                {
                    CmbPage.Items.Add(i + 1);
                }

                CmbPage.SelectedIndex = 0;
                bFirst = true;
            }
            Operation_SDO.BuildDataTable(tmp_ClientEvent, mResult, this.GrdResult, out this.pageCount);
            this.Cursor = Cursors.Default;
            this.CmbPage.Enabled = true;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.buttonClear.Enabled = false;
            this.BtnSearch.Enabled = false;
            this.CmbPage.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

            mContent[0].eName = CEnum.TagName.UserByID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = int.Parse(tmp_ClientEvent.GetInfo("USERID").ToString()); ;

            mContent[1].eName = CEnum.TagName.SDO_Address;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = this.TxtIP.Text.Trim();

            mContent[2].eName = CEnum.TagName.SDO_ServerIP;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = _ServerIP;

            this.backgroundWorkerClear.RunWorkerAsync(mContent);
        }

        private void backgroundWorkerClear_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(this.tmp_ClientEvent, CEnum.ServiceKey.SDO_USERLOGIN_CLEAR, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerClear_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.buttonClear.Enabled = true;
            this.BtnSearch.Enabled = true;
            this.CmbPage.Enabled = true;
            this.Cursor = Cursors.Default;
            if (((CEnum.Message_Body[,])e.Result)[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(((CEnum.Message_Body[,])e.Result)[0, 0].oContent.ToString());

                return;
            }
            else
            {
                MessageBox.Show(((CEnum.Message_Body[,])e.Result)[0, 0].oContent.ToString());
                this.GrpResult.Visible = false;
            }
        }
    }
}