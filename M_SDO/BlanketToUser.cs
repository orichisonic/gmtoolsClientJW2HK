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
    [C_Global.CModuleAttribute("跳舞毯查询", "BlanketToUser", "超级舞者", "SDO")]
    public partial class BlanketToUser : Form
    {
        public BlanketToUser()
        {
            InitializeComponent();
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
        private CSocketEvent m_ClientEvent = null;

        C_Global.CEnum.Message_Body[,] doResult = null;    //玩家信息列表

        #endregion

        #region 函数


        /// <summary>
        /// 读取
        /// </summary>
        private void ReadKeyWords()
        {
            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[0].eName = C_Global.CEnum.TagName.SDO_KeyID;
            messageBody[0].oContent = chkKeyID.Checked ? txtKeyOrCode.Text.Trim() : "";

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[1].eName = C_Global.CEnum.TagName.SDO_KeyWord;
            messageBody[1].oContent = chkCode.Checked ? txtKeyOrCode.Text.Trim() : "";

            doResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_PADKEYWORD_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);

            if (doResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(doResult[0, 0].oContent.ToString());
                return;
            }
            else
            {
                dpInfos.Visible = true;
                txtCode.Text = doResult[0,1].oContent.ToString();
                txtKeyID.Text = doResult[0,0].oContent.ToString();
                txtMaster.Text = doResult[0, 2].oContent.ToString();
                if (chkKeyID.Checked)
                {
                    txtMaster.Visible = false;
                    label3.Visible = false;
                }
                else
                {
                    txtMaster.Visible = true;
                    label3.Visible = true;
                }

            }
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
            this.Text = config.ReadConfigValue("MSDO", "BT_UI_BlanketToUser");
            this.lblKeyOrCode.Text = config.ReadConfigValue("MSDO", "BT_UI_lblKeyOrCode");
            this.btnSearch.Text = config.ReadConfigValue("MSDO", "BT_UI_btnSearch");
            this.chkKeyID.Text = config.ReadConfigValue("MSDO", "BT_UI_chkKeyID");
            this.chkCode.Text = config.ReadConfigValue("MSDO", "BT_UI_chkCode");
            this.label1.Text = config.ReadConfigValue("MSDO", "BT_UI_label1");
            this.label2.Text = config.ReadConfigValue("MSDO", "BT_UI_label2");
            this.label3.Text = config.ReadConfigValue("MSDO", "BT_UI_label3");
        }
        #endregion
        private void BlanketToUser_Load(object sender, EventArgs e)
        {
            dpInfos.Visible = false;
            IntiFontLib();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!chkKeyID.Checked && !chkCode.Checked)
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "AF_Code_InputAccount"));
                chkCode.Focus();
                return;
            }

            if (txtKeyOrCode.Text == "" || txtKeyOrCode.Text == null)
            {
                MessageBox.Show(chkCode.Checked ? config.ReadConfigValue("MSDO", "BT_Code_InputKeyID") : config.ReadConfigValue("MSDO", "BT_Code_InputCode"));
                txtKeyOrCode.Focus();
                return;
            }

            dpInfos.Visible = false;

            ReadKeyWords();

        }

        private void chkCode_Click(object sender, EventArgs e)
        {
            chkKeyID.Checked = false;
            lblKeyOrCode.Text = config.ReadConfigValue("MSDO", "BT_Code_KeyID");
        }

        private void chkKeyID_Click(object sender, EventArgs e)
        {
            chkCode.Checked = false;
            lblKeyOrCode.Text = config.ReadConfigValue("MSDO", "BT_Code_Code");
        }
    }
}