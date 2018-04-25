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
    [C_Global.CModuleAttribute("获取密码", "Frm_SDO_Pwd", "SDO管理工具 -- 获取密码", "AU Group")]
    public partial class Frm_SDO_Pwd : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        
        public Frm_SDO_Pwd()
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
            Frm_SDO_Pwd mModuleFrm = new Frm_SDO_Pwd();
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
            this.Text = config.ReadConfigValue("MSDO", "Pd_UI_SDOPwd");
            this.LblAccount.Text = config.ReadConfigValue("MSDO", "Pd_UI_LblAccount");
            this.label1.Text = config.ReadConfigValue("MSDO", "Pd_UI_label1");
            this.label2.Text = config.ReadConfigValue("MSDO", "Pd_UI_label2");
            this.BtnGetMail.Text = config.ReadConfigValue("MSDO", "Pd_UI_BtnGetMail");
            this.BtnSearch.Text = config.ReadConfigValue("MSDO", "Pd_UI_BtnSearch");
            this.BtnClose.Text = config.ReadConfigValue("MSDO", "Pd_UI_BtnClose");
            
        }


        #endregion
        private void Frm_SDO_Pwd_Load(object sender, EventArgs e)
        {
            IntiFontLib();/*
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 1;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_SDO");

            mServerInfo = Operation_SDO.GetServerList(this.m_ClientEvent, mContent);

            CmbServer = Operation_SDO.BuildCombox(mServerInfo, CmbServer);
            */

            BtnSearch.Enabled = false;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtAccount.Text.Trim().Length > 0)
            {
                //发送获取密码请求
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];
                //mContent[0].eName = CEnum.TagName.SDO_ServerIP;
                //mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                //mContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[0].eName = CEnum.TagName.SDO_Account;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtAccount.Text;

                mContent[1].eName = CEnum.TagName.SDO_Email;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = TxtMail.Text;

                mContent[2].eName = CEnum.TagName.PassWord;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = TxtPwd.Text;

                mContent[3].eName = CEnum.TagName.UserByID;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                CEnum.Message_Body[,] mResult = Operation_SDO.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_PASSWORD_RECOVERY, mContent);

                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.ToString() == "FAILURE")
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "Pd_Code_Sendpwdfail"));
                }
                else
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "Pd_Code_Sendpwdsucces"));
                }

                TxtAccount.Enabled = true;
                BtnSearch.Enabled = false;
                BtnGetMail.Enabled = true;
                TxtAccount.Clear();
                TxtMail.Clear();
                TxtPwd.Text = "123456";
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "Pd_Code_NeedAccont"));
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            TxtAccount.Clear();
            TxtMail.Clear();
            TxtPwd.Text = "123456";
            BtnGetMail.Enabled = true;
            BtnSearch.Enabled = false;
            TxtAccount.Enabled = true;
        }

        private void BtnGetMail_Click(object sender, EventArgs e)
        {
            if (TxtAccount.Text.Trim().Length > 0)
            {
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];

                mContent[0].eName = CEnum.TagName.SDO_Account;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtAccount.Text;

                CEnum.Message_Body[,] mResult = Operation_SDO.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_EMAIL_QUERY, mContent);

                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
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

                TxtAccount.Enabled = false;
                BtnGetMail.Enabled = false;
                BtnSearch.Enabled = true;
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "Pd_Code_NeedAccont"));
            }
        }
    }
}