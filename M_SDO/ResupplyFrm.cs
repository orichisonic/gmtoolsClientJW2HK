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
    [C_Global.CModuleAttribute("补Ｇ币", "Frm_SDO_Resupply", "SDO管理工具 -- 补Ｇ币", "SDO Group")]
    public partial class Frm_SDO_Resupply : Form
    {
        private int iTotal = 0;
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;        
        
        public Frm_SDO_Resupply()
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
            Frm_SDO_Resupply mModuleFrm = new Frm_SDO_Resupply();
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
            this.Text = config.ReadConfigValue("MSDO", "SG_UI_SdoResupply");
            this.GrpSearch.Text = config.ReadConfigValue("MSDO", "SG_UI_GrpSearch");
            this.LblServer.Text = config.ReadConfigValue("MSDO", "SG_UI_LblServer");
            this.label1.Text = config.ReadConfigValue("MSDO", "SG_UI_label1");

            this.LblMoney.Text = config.ReadConfigValue("MSDO", "SG_UI_LblMoney");
            this.LblAccount.Text = config.ReadConfigValue("MSDO", "SG_UI_LblAccount");
            this.BtnSearch.Text = config.ReadConfigValue("MSDO", "SG_UI_BtnSearch");
            this.BtnClose.Text = config.ReadConfigValue("MSDO", "SG_UI_BtnClose");
            this.button1.Text = config.ReadConfigValue("MSDO", "SG_UI_button1");
        
        }


        #endregion


        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtAccount.Text.Trim().Length > 0)
            {
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];

                mContent[0].eName = CEnum.TagName.SDO_Account;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtAccount.Text;

                mContent[1].eName = CEnum.TagName.SDO_ServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                CEnum.Message_Body[,] mResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_USERGCASH_QUERY, mContent);

                try
                {
                    LblMoney.Text = config.ReadConfigValue("MSDO", "SG_Code_lbltxtg") + mResult[0, 0].oContent.ToString();
                    iTotal = int.Parse(mResult[0, 0].oContent.ToString());
                }
                catch
                {
                    MessageBox.Show("数据异常，请咨询管理人员！");
                    return;
                }

                TxtAccount.Enabled = false;
                BtnSearch.Enabled = false;
                BtnClose.Enabled = true;
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "SG_Code_MsgAccont"));
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                int.Parse(TxtMoeny.Text.Trim());
            }
            catch
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "SG_Code_MsgSupplyg"));
                return;
            }

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

            mContent[0].eName = CEnum.TagName.SDO_Account;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = TxtAccount.Text;

            mContent[1].eName = CEnum.TagName.SDO_GCash;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = int.Parse(TxtMoeny.Text.Trim());

            mContent[2].eName = CEnum.TagName.SDO_ServerIP;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[3].eName = CEnum.TagName.UserByID;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            CEnum.Message_Body[,] mResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_USERGCASH_UPDATE, mContent);

            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            if (mResult[0, 0].oContent.Equals("FAILURE"))
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "SG_Code_MsgUpfail"));
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "SG_Code_MsgUpsucces"));
            }

            //LblMoney.Text = "当前G币金额：" + Convert.ToString(int.Parse(TxtMoeny.Text.Trim()) + iTotal);

            LblMoney.Text = config.ReadConfigValue("MSDO", "SG_Code_lbltxtg");
            BtnSearch.Enabled = true;
            BtnClose.Enabled = false;
            TxtAccount.Enabled = true;
            TxtAccount.Clear();
            TxtMoeny.Clear();
        }

        private void Frm_SDO_Resupply_Load(object sender, EventArgs e)
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

            BtnClose.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BtnClose.Enabled = false;
            TxtAccount.Clear();
            TxtAccount.Enabled = true;
            BtnSearch.Enabled = true;
            TxtMoeny.Clear();
            LblMoney.Text = config.ReadConfigValue("MSDO", "SG_Code_lbltxtg");
        }
    }
}