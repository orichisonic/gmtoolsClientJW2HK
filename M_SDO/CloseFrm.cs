using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using C_Global;
using C_Event;
using Language;
namespace M_SDO
{
    /// <summary>
    /// Frm_SDO_Part 的摘要说明。
    /// </summary>
    [C_Global.CModuleAttribute("帐号解/封停", "Frm_SDO_Close", "SDO管理工具 -- 帐号解/封停", "SDO Group")]        
    public partial class Frm_SDO_Close : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private int iUserID = 0;
        private string strUserNick = null;

        private int iPageCount = 0;
        private bool bFirst = false;

        public Frm_SDO_Close()
        {
            InitializeComponent();
        }

        #region 自定义调用事件
        /// <summary>
        /// 创建类库中的窗体
        /// </summary>
        /// <param name="oParent">MDI 程序的父窗体</param>
        /// <param name="oSocket">Socket</param>
        /// <returns>类库中的窗体</returns>
        public Form CreateModule(object oParent, object oEvent)
        {
            //创建登录窗体
            Frm_SDO_Close mModuleFrm = new Frm_SDO_Close();
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
            this.Text = config.ReadConfigValue("MSDO", "BA_UI_SDO_Close");
            this.GrpSearch.Text = config.ReadConfigValue("MSDO", "BA_UI_GrpSearch");
            this.LblServer.Text = config.ReadConfigValue("MSDO", "BA_UI_LblServer");
            this.Btn_Search.Text = config.ReadConfigValue("MSDO", "BA_UI_Btn_Search");
            this.BtnClose.Text = config.ReadConfigValue("MSDO", "BA_UI_BtnClose");
            this.TpgList.Text = config.ReadConfigValue("MSDO", "BA_UI_TpgList");
            this.TpgClose.Text = config.ReadConfigValue("MSDO", "BA_UI_TpgClose");
            this.TpgOpen.Text = config.ReadConfigValue("MSDO", "BA_UI_TpgOpen");
            this.LblPage.Text = config.ReadConfigValue("MSDO", "BA_UI_LblPage");
            this.lblBandays.Text = config.ReadConfigValue("MSDO", "BA_UI_lblBandays");
           
        }
        #endregion

        private void Frm_SDO_Close_Load(object sender, EventArgs e)
        {
            IntiFontLib();

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 1;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_SDO");

            mServerInfo = Operation_SDO.GetServerList(this.m_ClientEvent, mContent);

            CmbServer = Operation_SDO.BuildCombox(mServerInfo, CmbServer);

            LblUser.Text = "";
            PnlInput.Visible = true;
            GrdList.DataSource = null;
            PnlPage.Visible = false;
            txtBandays.Items.Add(config.ReadConfigValue("MSDO", "AF_Code_3day"));
            txtBandays.Items.Add(config.ReadConfigValue("MSDO", "AF_Code_7day"));
            txtBandays.Items.Add(config.ReadConfigValue("MSDO", "AF_Code_30day"));
            txtBandays.Items.Add(config.ReadConfigValue("MSDO", "AF_Code_Feverday"));
            txtBandays.SelectedIndex = 0;

        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            LblUser.Text = "";
            PnlInput.Visible = true;
            GrdList.DataSource = null;

            CmbPage.Items.Clear();
            TbcResult.SelectedTab = TpgList;

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

            mContent[0].eName = CEnum.TagName.SDO_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[1].eName = CEnum.TagName.Index;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = 1;

            mContent[2].eName = CEnum.TagName.PageSize;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = Operation_SDO.iPageSize;

            CEnum.Message_Body[,] mGetResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_MEMBERBANISHMENT_QUERY, mContent);

            //无内容显示
            if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mGetResult[0, 0].oContent.ToString());
                return;
            }

            Operation_SDO.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);

            if (iPageCount <= 0)
            {
                PnlPage.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    CmbPage.Items.Add(i+1);
                }

                CmbPage.SelectedIndex = 0;
                bFirst = true;
                PnlPage.Visible = true;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GrdList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable mTable = (DataTable)GrdList.DataSource;

            try
            {
                iUserID = int.Parse(mTable.Rows[e.RowIndex][0].ToString());
                strUserNick = mTable.Rows[e.RowIndex][1].ToString();
                LblUser.Text = config.ReadConfigValue("MSDO", "BA_Code_Msginfo").Replace("{Nickname}", strUserNick);
                TxtNick.Text = strUserNick;
                TbcResult.SelectedTab = TpgClose;

                CEnum.Message_Body[] mMemo = new CEnum.Message_Body[2];

                mMemo[0].eName = CEnum.TagName.SDO_ServerIP;
                mMemo[0].eTag = CEnum.TagFormat.TLV_STRING;
                mMemo[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                mMemo[1].eName = CEnum.TagName.SDO_Account;
                mMemo[1].eTag = CEnum.TagFormat.TLV_STRING;
                mMemo[1].oContent = strUserNick;

                CEnum.Message_Body[,] mGetResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_MEMBERLOCAL_BANISHMENT, mMemo);

                if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    TxtMemo.Text = mGetResult[0, 0].oContent.ToString();
                }
                else
                {
                    TxtMemo.Text = mGetResult[0, 2].oContent.ToString();
                }


                if (strUserNick != null)
                {
                    PnlInput.Visible = true;
                }
            }
            catch
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsginfoUser"));
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            strUserNick = TxtNick.Text.Trim();
            if (strUserNick != null && strUserNick != "")
            {
                if (MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsgAccont"), config.ReadConfigValue("MSDO", "BA_Code_MsgUnlock"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];
                    mContent[0].eName = CEnum.TagName.SDO_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.SDO_Account;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = strUserNick;

                    mContent[2].eName = CEnum.TagName.UserByID;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    CEnum.Message_Body[,] mResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_ACCOUNT_OPEN, mContent);

                    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(mResult[0, 0].oContent.ToString());
                        return;
                    }

                    if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.Equals("FAILURE"))
                    {
                        MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsgopFailure"));
                    }
                    else
                    {
                        MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsgopSucces1"));
                    }

                    PnlInput.Visible = false;

                    mContent = new CEnum.Message_Body[3];

                    mContent[0].eName = CEnum.TagName.SDO_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.Index;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = 1;

                    mContent[2].eName = CEnum.TagName.PageSize;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = Operation_SDO.iPageSize;

                    CEnum.Message_Body[,] mGetResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_MEMBERBANISHMENT_QUERY, mContent);

                    //无内容显示
                    if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(mGetResult[0, 0].oContent.ToString());
                        return;
                    }

                    Operation_SDO.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);

                    TxtAccount.Clear();
                    TxtContent.Clear();
                    TxtMemo.Clear();
                }
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsgopSucces"));
            }
        }
        private int ReturnBanDays(string strDays)
        {   
            int intdays = 0;
            if (strDays == config.ReadConfigValue("MSDO", "AF_Code_3day"))
            {
                intdays = 3;
            }
            else if (strDays == config.ReadConfigValue("MSDO", "AF_Code_7day"))
            {
                intdays = 7;
            }
            else if (strDays == config.ReadConfigValue("MSDO", "AF_Code_30day"))
            {
                intdays = 30;
            }
            else if (strDays == config.ReadConfigValue("MSDO", "AF_Code_Feverday"))
            {
                intdays = 3650;
            }
            return intdays;
        }
        private void BtnPost_Click(object sender, EventArgs e)
        {
            if (TxtAccount.Text.Trim().Length > 0 && txtBandays.Text.Trim().Length > 0 && TxtContent.Text.Trim().Length > 0)
            {

                if (MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsgServer").Replace("{Server}", CmbServer.Text).Replace("{Account}", TxtAccount.Text), config.ReadConfigValue("MSDO", "BA_Code_MsgBan"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {   
                    CEnum.Message_Body[,] mResult = null;
                    
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];
                    mContent[0].eName = CEnum.TagName.SDO_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.SDO_Account;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = TxtAccount.Text;

                    mContent[2].eName = CEnum.TagName.UserByID;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    mContent[3].eName = CEnum.TagName.SDO_REASON;
                    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[3].oContent = TxtContent.Text.Trim();

                    mContent[4].eName = CEnum.TagName.SDO_BanDate;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = ReturnBanDays(txtBandays.Text.Trim());


                    mResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_MEMBERSTOPSTATUS_QUERY, mContent);

                    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        //MessageBox.Show("操作失败！");
                        MessageBox.Show(mResult[0, 0].oContent.ToString());
                        return;
                    }

                    if (mResult[0, 0].eName == CEnum.TagName.SDO_StopStatus && mResult[0, 0].oContent.ToString() == "0")
                    {
                        mResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_ACCOUNT_CLOSE, mContent);

                        if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                        {
                            //MessageBox.Show("操作失败！");
                            MessageBox.Show(mResult[0, 0].oContent.ToString());
                            return;
                        }

                        if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.Equals("FAILURE"))
                        //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                        {
                            MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsgopFailure"));
                            return;
                        }
                        else
                        {
                            MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsgopSucces"));

                            TxtAccount.Text = "";
                            TxtContent.Text = "";
                            //txtBandays.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsgUnoperation"));
                    }

                    mContent = new CEnum.Message_Body[3];

                    mContent[0].eName = CEnum.TagName.SDO_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.Index;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = 1;

                    mContent[2].eName = CEnum.TagName.PageSize;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = Operation_SDO.iPageSize;

                    CEnum.Message_Body[,] mGetResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_MEMBERBANISHMENT_QUERY, mContent);

                    //无内容显示
                    if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(mGetResult[0, 0].oContent.ToString());
                        return;
                    }

                    Operation_SDO.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);

                    TxtAccount.Clear();
                    TxtContent.Clear();
                    TxtMemo.Clear();
                }
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsginputAccont"));
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtAccount.Text = "";
            TxtContent.Text = "";
            txtBandays.Text = "";
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            //TxtMemo.Text = "";
            TxtNick.Clear();
        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirst)
            {
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

                mContent[0].eName = CEnum.TagName.SDO_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.Index;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_SDO.iPageSize + 1;

                mContent[2].eName = CEnum.TagName.PageSize;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = Operation_SDO.iPageSize;

                CEnum.Message_Body[,] mGetResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_MEMBERBANISHMENT_QUERY, mContent);

                Operation_SDO.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);
            }
        }

        private void txtBandays_KeyUp(object sender, KeyEventArgs e)
        {

            string txt = txtBandays.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtBandays.Text = rx.Replace(txt, "");

        }
    }
}