using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using C_Global;
using C_Event;

namespace M_CR
{
    [C_Global.CModuleAttribute("激活码/帐号查询", "ActivationSearch", "疯狂卡丁车", "CR")]
    public partial class ActivationSearch : Form
    {
        public ActivationSearch()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeServerIP();               //初始化数据库列表
            HideResultLabel();
            DisableAccountSearch();
            chkbxActivation.Checked = true;
        }
       
        #region 状态信息

        private void WriteSearchText(object sender, System.EventArgs e)
        {
            Status.WriteStatusText(this.MdiParent, "正在检测信息,请稍等...");
        }
        #endregion

        #region 自定义函数


        /// <summary>
        /// 使显示查询结果的label不可见
        /// </summary>
        private void HideResultLabel()
        {
            lblResult.Visible = false;
            lblContent.Visible = false;
            lblContent.Text = "";
        }
        private void ShowResultLabel()
        {
            lblResult.Visible = true;
            lblContent.Visible = true;
        }

        /// <summary>
        /// 使激活码查询的相关元素不可用
        /// </summary>
        private void DisableActivationSearch()
        {
            txtActivationCode.Clear();
            txtPwd.Clear();
            txtActivationCode.Enabled = false;
            txtPwd.Enabled = false;
            HideResultLabel();
        }

        /// <summary>
        /// 使帐号查询的相关元素不可用
        /// </summary>
        private void DisableAccountSearch()
        {
            txtAccount.Enabled = false;
            txtAccount.Clear();
            HideResultLabel();
        }

        /// <summary>
        /// 使激活码查询的相关元素可用
        /// </summary>
        private void EnableActivationSearch()
        {
            txtActivationCode.Enabled = true;
            txtPwd.Enabled = true;
        }

        /// <summary>
        /// 使帐号查询的相关元素可用
        /// </summary>
        private void EnableAccountSearch()
        {
            txtAccount.Enabled = true ;
        }

        /// <summary>
        /// 激活码查询
        /// </summary>
        private void ChkActivation(object sender, System.EventArgs e)
        {
            try
            {
                C_Global.CEnum.Message_Body[] msgBody = new C_Global.CEnum.Message_Body[2];

                msgBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                msgBody[0].eName = C_Global.CEnum.TagName.CR_NUMBER;
                msgBody[0].oContent = txtActivationCode.Text.Trim();

                msgBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                msgBody[1].eName = C_Global.CEnum.TagName.CR_Passord;
                msgBody[1].oContent = txtPwd.Text.Trim();

                activationResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.CR_ACCOUNTACTIVE_QUERY, C_Global.CEnum.Msg_Category.CR_ADMIN, msgBody);

                switch (activationResult[0, 0].oContent.ToString())
                {
                    case "1":
                        lblContent.Text = "激活码 " + txtActivationCode.Text + " 不存在";
                        break;
                    case "2":
                        lblContent.Text = "输入的密码错误，正确的密码应为：" + activationResult[0, 1].oContent.ToString();
                        break;
                    case "3":
                        lblContent.Text = "激活码 " + txtActivationCode.Text + " 暂未使用";
                        break;
                    case "4":
                        lblContent.Text = "激活码 " + txtActivationCode.Text + " 已被使用，使用者ID：" + activationResult[0, 1].oContent.ToString();
                        break;
                    default:
                        lblContent.Text = activationResult[0, 0].oContent.ToString();
                        break;
                }
                ShowResultLabel();
                Status.WriteStatusText(this.MdiParent, "完毕");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 帐号查询
        /// </summary>
        private void ChkAccount(object sender, System.EventArgs e)
        {
            try
            {
                C_Global.CEnum.Message_Body[] msgBody = new C_Global.CEnum.Message_Body[3];

                msgBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                msgBody[0].eName = C_Global.CEnum.TagName.CR_ServerIP;
                msgBody[0].oContent = _ServerIP;

                msgBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                msgBody[1].eName = C_Global.CEnum.TagName.CR_ACCOUNT;
                msgBody[1].oContent = txtAccount.Text.Trim();

                msgBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                msgBody[2].eName = C_Global.CEnum.TagName.CR_ACTION;
                msgBody[2].oContent = 1;


          

                accountResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.CR_ACCOUNT_QUERY, C_Global.CEnum.Msg_Category.CR_ADMIN, msgBody);

                switch (accountResult[0, 0].oContent.ToString())
                {
                    case "0":
                        lblContent.Text = "帐号 " + txtAccount.Text + " 不存在";
                        break;
                    default:
                        if (accountResult[0, 6].oContent.ToString() != "")
                        {
                            lblContent.Text = "帐号 " + txtAccount.Text + " 已激活,使用激活码：" + accountResult[0, 6].oContent.ToString() + ",密码：" + accountResult[0, 1].oContent.ToString();
                        }
                        else if (accountResult[0, 1].oContent.ToString()=="")
                        {
                            lblContent.Text = "帐号 " + txtAccount.Text + " 暂未激活";
                        }
                        else
                        {
                            lblContent.Text = "帐号 " + txtAccount.Text + " 不存在";
                        }
                        break;
                }
                ShowResultLabel();
                Status.WriteStatusText(this.MdiParent, "完毕");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region 线程
        /// <summary>
        /// 激活码查询
        /// </summary>
        private void InvokeChkActivation()
        {
            Invoke(new EventHandler(ChkActivation));
        }
        /// <summary>
        /// 帐号查询
        /// </summary>
        private void InvokeChkAccount()
        {
            Invoke(new EventHandler(ChkAccount));
        }
        #endregion

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

        C_Global.CEnum.Message_Body[,] activationResult = null; //激活码查询结果
        C_Global.CEnum.Message_Body[,] accountResult = null;    //帐号查询结果
        C_Global.CEnum.Message_Body[,] serverIPResult = null;   //ip列表信息
        string _ServerIP = null;    //服务器ip
        #endregion

        #region 线程
        private void InvokeWriteSearchText()
        {
            Invoke(new EventHandler(WriteSearchText));
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (chkbxActivation.Checked)
            {
                txtActivationCode.Clear();
                txtPwd.Clear();
            }
            if (chkbxAccount.Checked)
            {
                txtAccount.Clear();
            }
            HideResultLabel();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            HideResultLabel();

            #region 内容检测

            if (chkbxActivation.Checked)
            {
                if (txtActivationCode.Text == "" || txtActivationCode.Text == null)
                {
                    txtActivationCode.Focus();
                    MessageBox.Show("请输入激活码");
                    return;
                }
                if (txtPwd.Text == "" || txtPwd.Text == null)
                {
                    txtPwd.Focus();
                    MessageBox.Show("请输入密码");
                    return;
                }
            }
            if (chkbxAccount.Checked)
            {
                if (txtAccount.Text == "" || txtAccount.Text == null)
                {
                    txtAccount.Focus();
                    MessageBox.Show("请输入帐号");
                    return;
                }
            }
            #endregion

            Thread thdStatus = new Thread(new ThreadStart(InvokeWriteSearchText));
            thdStatus.Start();

            if (chkbxActivation.Checked)
            {
                Thread thdChk = new Thread(new ThreadStart(InvokeChkActivation));
                thdChk.Start();
            }
            if (chkbxAccount.Checked)
            {
                Thread thdChk = new Thread(new ThreadStart(InvokeChkAccount));
                thdChk.Start();
            }

            #region IP检索


            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                {
                    this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion
            
        }

        /// <summary>
        /// 初始化游戏服务器列表
        /// </summary>
        public void InitializeServerIP()
        {
            try
            {
                this.cbxServerIP.Items.Clear();

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.ServerInfo_GameID;
                messageBody[0].oContent = m_ClientEvent.GetInfo("GameID_CR");

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 2;

                serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);

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

                this.cbxServerIP.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkbxAccount_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkbxAccount.Checked)
            {
                EnableAccountSearch();
                if (chkbxActivation.Checked)
                {
                    chkbxActivation.Checked = false;
                    DisableActivationSearch();
                }
            }
            else
            {
                DisableAccountSearch();

            }
        }

        private void chkbxActivation_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkbxActivation.Checked)
            {
                EnableActivationSearch();
                if (chkbxAccount.Checked)
                {
                    chkbxAccount.Checked = false;
                    DisableAccountSearch();
                }
            }
            else
            {
                DisableActivationSearch();
            }
        }
    }
}