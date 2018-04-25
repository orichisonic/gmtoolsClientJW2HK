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
namespace M_SDO
{
    /// <summary>
    /// 
    /// </summary>
    [C_Global.CModuleAttribute("玩家交易记录", "Frm_SDO_Trade", "SDO管理工具 -- 玩家交易记录", "SDO Group")]
    public partial class Frm_SDO_Trade : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private int iPageCount = 0;
        private bool bFirst = false;

        public Frm_SDO_Trade()
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
            Frm_SDO_Trade mModuleFrm = new Frm_SDO_Trade();
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

        private void Frm_SDO_Trade_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 3;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_SDO");

            mServerInfo = Operation_SDO.GetServerList(this.m_ClientEvent, mContent);

            CmbServer = Operation_SDO.BuildCombox(mServerInfo, CmbServer);

            PnlPage.Visible = false;
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
            this.Text = config.ReadConfigValue("MSDO", "TD_UI_SdoTrade");
            this.GrpSearch.Text = config.ReadConfigValue("MSDO", "TD_UI_GrpSearch");
            this.LblServer.Text = config.ReadConfigValue("MSDO", "TD_UI_LblServer");
            this.label1.Text = config.ReadConfigValue("MSDO", "TD_UI_label1");
            this.LblAccount.Text = config.ReadConfigValue("MSDO", "TD_UI_LblAccount");
            this.BtnSearch.Text = config.ReadConfigValue("MSDO", "TD_UI_BtnSearch");
            this.BtnClose.Text = config.ReadConfigValue("MSDO", "TD_UI_BtnClose");

            this.GrpResult.Text = config.ReadConfigValue("MSDO", "TD_UI_GrpResult");
            this.LblPage.Text = config.ReadConfigValue("MSDO", "TD_UI_LblPage");
   
        }


        #endregion

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            GrdResult.DataSource = null;
            CmbPage.Items.Clear();

            if (TxtSenderAccount.Text.Trim().Length > 0 || TxtReciveAccount.Text.Trim().Length > 0)
            {               
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.SDO_SendUserID;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtReciveAccount.Text;

                mContent[1].eName = CEnum.TagName.SDO_ReceiveNick;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = TxtSenderAccount.Text;

                mContent[2].eName = CEnum.TagName.SDO_ServerIP;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_SDO.iPageSize;

                CEnum.Message_Body[,] mResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_ITEMSHOP_TRADE_QUERY, mContent);

                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_SDO.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);

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
                }
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "TD_Code_Msg"));
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirst)
            {
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.SDO_SendUserID;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtReciveAccount.Text;

                mContent[1].eName = CEnum.TagName.SDO_ReceiveNick;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = TxtSenderAccount.Text;

                mContent[2].eName = CEnum.TagName.SDO_ServerIP;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_SDO.iPageSize + 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_SDO.iPageSize;

                CEnum.Message_Body[,] mResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_ITEMSHOP_TRADE_QUERY, mContent);

                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_SDO.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);
            }
        }
    }
}