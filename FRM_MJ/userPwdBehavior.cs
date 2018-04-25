using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Global;
using C_Event;

namespace FRM_MJ
{
    [C_Global.CModuleAttribute("猛将玩家密码操作", "userPwdBehavior", "猛将玩家密码操作", "MJ Group")]
    public partial class userPwdBehavior : Form
    {
        public userPwdBehavior()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.serverIP.Text == "")
            {
                MessageBox.Show("请选择服务器！");
                return;
            }
            if (this.actionType.Text == "")
            {
                MessageBox.Show("请选择操作方式！");
                return;
            }
            if (this.userName.Text == "")
            {
                MessageBox.Show("请输入玩家帐号！");
                return;
            }
            _actionType = this.actionType.Text.Trim();
            _userName = this.userName.Text.Trim();

            #region 查询ｉｐ
            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.serverIP.Text.Trim()))
                {
                    this._serverIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion

            #region servicekey
            switch (_actionType)
            {
                case "保存玩家密码":
                    _actionServiceKey = CEnum.ServiceKey.MJ_ACCOUNTPASSWD_LOCAL_CREATE;
                    break;
                case "修改玩家密码":
                    _actionServiceKey = CEnum.ServiceKey.MJ_ACCOUNTPASSWD_LOCAL_CREATE;
                    if (DoAction(_serverIP, _userName, _actionServiceKey, true))
                    {

                        //_actionServiceKey = CEnum.ServiceKey.MJ_ACCOUNTPASSWD_REMOTE_UPDATE;
                        newPwd nPwd = new newPwd(_serverIP, _userName, searchFrmResult);
                        nPwd.CreateModule(null, m_ClientEvent);
                    }
                    else
                    {
                        MessageBox.Show("备份帐号密码失败，请重新修改");
                    }
                    break;
                case "恢复玩家密码":
                    _actionServiceKey = CEnum.ServiceKey.MJ_ACCOUNTPASSWD_REMOTE_RESTORE;
                    break;

            }
            #endregion

            try
            {
                DoAction(_serverIP, _userName, _actionServiceKey);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void userPwdBehavior_Load(object sender, EventArgs e)
        {
            InitializeServerIP();
        }

        #region 自定义函数
        /// <summary>
        /// 初始化游戏服务器列表
        /// </summary>
        public void InitializeServerIP()
        {
            try
            {
                this.serverIP.Items.Clear();

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.ServerInfo_GameID;
                messageBody[0].oContent = 2;

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
                    this.serverIP.Items.Add(serverIPResult[i, 1].oContent.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void DoAction(string prmServerIP, string userAccount, C_Global.CEnum.ServiceKey prmServiceKey)
        {
            try
            {

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.MJ_ServerIP;
                messageBody[1].oContent = prmServerIP;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.MJ_Account;
                messageBody[2].oContent = userAccount;

                searchFrmResult = m_ClientEvent.RequestResult(prmServiceKey, C_Global.CEnum.Msg_Category.MJ_ADMIN, messageBody);

                //检测状态
                if (searchFrmResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(searchFrmResult[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }
                else
                {
                    MessageBox.Show("帐号" + userAccount + _actionType + "操作完成！");
                    return;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool DoAction(string prmServerIP, string userAccount, C_Global.CEnum.ServiceKey prmServiceKey,bool canViewError)
        {
            bool returnValue = true;
            try
            {

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.MJ_ServerIP;
                messageBody[1].oContent = prmServerIP;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.MJ_Account;
                messageBody[2].oContent = userAccount;

                searchFrmResult = m_ClientEvent.RequestResult(prmServiceKey, C_Global.CEnum.Msg_Category.MJ_ADMIN, messageBody);

                //检测状态
                if (searchFrmResult[0, 0].oContent.Equals("FAILURE"))
                {
                    returnValue = false;
                }
                else
                {
                    //MessageBox.Show("帐号" + userAccount + _actionType + "操作完成！");
                    returnValue = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return returnValue;
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
        private C_Global.CEnum.Message_Body[,] serverIPResult = null;
        private C_Global.CEnum.Message_Body[,] searchFrmResult = null;

        private string _serverIP = null;
        private string _actionType = null;
        private string _userName = null;

        private C_Global.CEnum.ServiceKey _actionServiceKey = CEnum.ServiceKey.MJ_CHARACTERINFO_UPDATE;
        #endregion

        
    }
}