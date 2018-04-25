using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Global;
using C_Event;

namespace M_AU
{
    [C_Global.CModuleAttribute("昵称同步", "SyncUserNick", "劲舞团", "AU")]
    public partial class SyncUserNick : Form
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

                cbxServerIP.SelectedIndex = 0;
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


            accountResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.AU_ACCOUNT_QUERY, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);

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


            accountResultNY = m_ClientEvent.RequestResult(CEnum.ServiceKey.CARD_USERNICK_QUERY, C_Global.CEnum.Msg_Category.CARD_ADMIN, messageBody);

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

            doResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.AU_USERNICK_UPDATE, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);

            if (doResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(doResult[0, 0].oContent.ToString());
                return;
            }

            if (doResult[0, 0].oContent.ToString().ToUpper().Equals("SUCESS"))
            {
                MessageBox.Show("成功");

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
                MessageBox.Show("失败");
                return;
            }
            

        }



       
        #endregion


        public SyncUserNick()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtAccount.Text == null || txtAccount.Text == "")
            {
                MessageBox.Show("请输入玩家帐号");
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

            if (ReadAuNickName() && ReadNYNickName())
            {
                gbNickResult.Enabled = true;
                txtAccount.Enabled = false;
                btnSearch.Enabled = false;
                cbxServerIP.Enabled = false;
            }
            else
            {
                gbNickResult.Enabled = false;
                MessageBox.Show("数据库中记录不存在");
            }


            
        }

        private void SyncUserNick_Load(object sender, EventArgs e)
        {
            gbNickResult.Enabled = false;

            txtAUNick.ReadOnly = true;
            txtNYNick.ReadOnly = true;

            InitializeServerIP();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
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
    }
}