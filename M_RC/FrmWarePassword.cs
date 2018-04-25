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
namespace M_RC
{
    [C_Global.CModuleAttribute("獲取密碼", "FrmWarePassword", "SDO管理工具-- 獲取密碼", "AU Group")]
    public partial class FrmWarePassword : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent tmp_ClientEvent = null;
        private CSocketEvent m_ClientEvent = null;
        private CEnum.Message_Body[,] CharinfoID = null;
        public FrmWarePassword()
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
            FrmWarePassword mModuleFrm = new FrmWarePassword();
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
            //this.Text = config.ReadConfigValue("MSDO", "Pd_UI_SDOPwd");
            //this.LblAccount.Text = config.ReadConfigValue("MSDO", "Pd_UI_LblAccount");
            //this.label1.Text = config.ReadConfigValue("MSDO", "Pd_UI_label1");
         
            //this.BtnGetMail.Text = config.ReadConfigValue("MSDO", "Pd_UI_BtnGetMail");
            //this.BtnSearch.Text = config.ReadConfigValue("MSDO", "Pd_UI_BtnSearch");
            //this.BtnClose.Text = config.ReadConfigValue("MSDO", "Pd_UI_BtnClose");
            
        }


        #endregion

        #region
        private void Frm_SDO_Pwd_Load(object sender, EventArgs e)
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
                mContent[1].oContent = m_ClientEvent.GetInfo("GameID_RC");

                mServerInfo = Operation_RCode.GetServerList(this.m_ClientEvent, mContent);

                if (mServerInfo[0, 0].eName != CEnum.TagName.ERROR_Msg)
                {
                    CmbServer = Operation_RCode.BuildCombox(mServerInfo, CmbServer);
                    CmbServer.SelectedIndex = 0;
                }
            }
            catch
            { }

            BtnSearch.Enabled = false;
        }
        #endregion

        #region
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtAccount.Text.Trim().Length > 0)
            {
                //发送获取密码请求
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];
                mContent[0].eName = CEnum.TagName.RayCity_NyUserID;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtAccount.Text;

                mContent[1].eName = CEnum.TagName.RayCity_ServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Operation_RCode.GetItemAddr(mServerInfo, CmbServer.Text.Trim());

                mContent[2].eName = CEnum.TagName.SDO_Email;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = TxtMail.Text;

                mContent[3].eName = CEnum.TagName.UserByID;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent[4].eName = CEnum.TagName.RayCity_CharacterID;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = int.Parse(CharinfoID[0,2].oContent.ToString());


                CEnum.Message_Body[,] mResult = null;
                lock (typeof(C_Event.CSocketEvent))
                {
                    mResult = Operation_RCode.GetResult(m_ClientEvent, CEnum.ServiceKey.RayCity_WareHousePwd_Update, mContent);
                }

                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.ToString() == "FAILURE")
                {
                    MessageBox.Show("密碼發送失敗！");
                    TxtAccount.Clear();
                    TxtMail.Clear();
                    return;
                }
                else
                {
                    MessageBox.Show("密碼發送完成！");
                }

                TxtAccount.Enabled = true;
                BtnSearch.Enabled = false;
                BtnGetMail.Enabled = true;
                TxtAccount.Clear();
                TxtMail.Clear();
                mContent = null;
             
            }
            else
            {
                MessageBox.Show("請輸入要發送口令的帳號!");
            }
        }
        #endregion

        #region
        private void BtnClose_Click(object sender, EventArgs e)
        {
            TxtAccount.Clear();
            TxtMail.Clear();
            BtnGetMail.Enabled = true;
            BtnSearch.Enabled = false;
            TxtAccount.Enabled = true;
        }
        #endregion

        #region
        private void BtnGetMail_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtAccount.Text.Trim().Length > 0)
                {

                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];

                    mContent[0].eName = CEnum.TagName.SDO_Account;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = TxtAccount.Text;

                    CEnum.Message_Body[,] mResult = null;
                    lock (typeof(C_Event.CSocketEvent))
                    {
                    mResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_EMAIL_QUERY, CEnum.Msg_Category.SDO_ADMIN, mContent);
                    }

                    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(mResult[0, 0].oContent.ToString());
                        BtnGetMail.Enabled = true;
                        return;
                    }

                    try
                    {
                        TxtMail.Text = mResult[0, 0].oContent.ToString();
                    }
                    catch
                    {
                        TxtMail.Text = "";
                    }


                    CEnum.Message_Body[] mContent1 = new CEnum.Message_Body[5];

                    mContent1[0].eName = CEnum.TagName.RayCity_NyUserID;
                    mContent1[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent1[0].oContent = TxtAccount.Text;

                    mContent1[1].eName = CEnum.TagName.RayCity_ServerIP;
                    mContent1[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent1[1].oContent = Operation_RCode.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent1[2].eName = CEnum.TagName.RayCity_NyNickName;
                    mContent1[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent1[2].oContent = "";

                    mContent1[3].eName = CEnum.TagName.Index;
                    mContent1[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent1[3].oContent = 1;

                    mContent1[4].eName = CEnum.TagName.PageSize;
                    mContent1[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent1[4].oContent = 1;

                    lock (typeof(C_Event.CSocketEvent))
                    {
                        CharinfoID = Operation_RCode.GetResult(tmp_ClientEvent, CEnum.ServiceKey.RayCity_BasicAccount_Query, mContent1);

                    }
                    if (CharinfoID[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show("該玩家帳號不存在");
                        BtnSearch.Enabled = false;
                        return;
                    }


                    TxtAccount.Enabled = false;
                    BtnGetMail.Enabled = false;
                    BtnSearch.Enabled = true;
                }
                else
                {
                    MessageBox.Show(config.ReadConfigValue("MRC", "FQP_Code_inputid"));
                }
            }
            catch { }
        }
        #endregion

        #region
        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_RCode.GetItemAddr(mServerInfo, CmbServer.Text));
        }
        #endregion
    }
}