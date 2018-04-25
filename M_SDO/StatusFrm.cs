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
namespace M_SDO
{
    /// <summary>
    /// 
    /// </summary>
    [C_Global.CModuleAttribute("玩家状态信息", "Frm_SDO_Status", "SDO管理工具 -- 玩家状态信息", "SDO Group")]
    public partial class Frm_SDO_Status : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        
        public Frm_SDO_Status()
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
            Frm_SDO_Status mModuleFrm = new Frm_SDO_Status();
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

        private void Frm_SDO_Status_Load(object sender, EventArgs e)
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
            this.Text = config.ReadConfigValue("MSDO", "SS_UI_SdoStatus");
            this.GrpSearch.Text = config.ReadConfigValue("MSDO", "SS_UI_GrpSearch");
            this.LblServer.Text = config.ReadConfigValue("MSDO", "SS_UI_LblServer");
            this.LblAccount.Text = config.ReadConfigValue("MSDO", "SS_UI_LblAccount");
            this.BtnSearch.Text = config.ReadConfigValue("MSDO", "SS_UI_BtnSearch");
            this.button1.Text = config.ReadConfigValue("MSDO", "SS_UI_button1");
            this.GrpResult.Text = config.ReadConfigValue("MSDO", "SS_UI_GrpResult");
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

                CEnum.Message_Body[,] mResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_USERLOGIN_STATUS_QUERY, mContent);

                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    LblStatus.Text = config.ReadConfigValue("MSDO", "SS_Code_UseroutLine");
                }
                else
                {
                    LblStatus.Text = config.ReadConfigValue("MSDO", "SS_Code_UseronLine").Replace("{Id}", mResult[0, 1].oContent.ToString()).Replace("{Room}", mResult[0, 2].oContent.ToString());
                        //"当前用户在线，位于第 " + mResult[0, 1].oContent.ToString() + " 个服务器第 " + mResult[0, 2].oContent.ToString() + " 个房间。";
                }
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "SS_Code_Msginfo"));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}