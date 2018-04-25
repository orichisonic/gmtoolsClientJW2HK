using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Event;
using C_Global;
using C_Socket;

namespace FRM_MJ
{
    [C_Global.CModuleAttribute("猛将玩家帐号操作", "accountBehavior", "猛将玩家帐号操作", "MJ Group")]
    public partial class accountBehavior : Form
    {
        public accountBehavior()
        {
            InitializeComponent();
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

        /// <summary>
        /// 读取数据，刷新列表
        /// </summary>
        public void InitializeListView()
        {
            lock (this)
            {
                try
                {
                    //发送接受数据
                    lockUserResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.MJ_ACCOUNT_LOCAL_QUERY, C_Global.CEnum.Msg_Category.MJ_ADMIN, null);

                    //检测状态
                    if (lockUserResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(lockUserResult[0, 0].oContent.ToString());
                        return;
                    }

                    
                    //显示内容到列表
                    string[] rowInfo = new string[5];

                    for (int i = 0; i < lockUserResult.GetLength(0); i++)
                    {

                        //行号
                        rowInfo[0] = Convert.ToString(i + 1);
                        //MJ_CharName
                        rowInfo[1] = lockUserResult[i, 0].oContent.ToString();
                        //MJ_CharName_Prefix
                        rowInfo[2] = lockUserResult[i, 1].oContent.ToString();
                        //MJ_Exploit_Value
                        rowInfo[3] = lockUserResult[i, 2].oContent.ToString();
                        //MJ_Exploit_Value
                        rowInfo[4] = lockUserResult[i, 3].oContent.ToString();

                        ListViewItem mlistViewItem = new ListViewItem(rowInfo, -1);
                        //this.Invoke(new EventHandler(RefreshListContent));
                        this.listViewSortOrder.Items.Add(mlistViewItem);
                        this.listViewSortOrder.Items[i].Tag = lockUserResult[i, 0].oContent.ToString();
                    }
                   
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }

        }

        /// <summary>
        /// 保存帐号
        /// </summary>
        public bool SaveAccountToLocal()
        {
            bool returnValue = true;
            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];

            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
            messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[1].eName = C_Global.CEnum.TagName.MJ_ServerIP;
            messageBody[1].oContent = this._serverIP;

            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[2].eName = C_Global.CEnum.TagName.MJ_Account;
            messageBody[2].oContent = this._userName;

            messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[3].eName = C_Global.CEnum.TagName.MJ_Reason;
            messageBody[3].oContent = this.tbLockReson.Text;



            mResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.MJ_ACCOUNT_LOCAL_CREATE, C_Global.CEnum.Msg_Category.MJ_ADMIN, messageBody);

            //检测状态
            if (mResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                //Application.Exit();
                returnValue = false;
            }
            else if (mResult[0, 0].oContent.Equals("FAILURE"))
            {
                returnValue = false;
            }
            else
            {
                //MessageBox.Show("帐号" + this._userName + _actionType + "操作完成！");
                returnValue = true;
            }
            return returnValue;
        }

        /// <summary>
        /// 执行操作
        /// </summary>
        /// <param name="prmServerIP"></param>
        /// <param name="userAccount"></param>
        /// <param name="prmServiceKey"></param>
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

                



                mResult = m_ClientEvent.RequestResult(prmServiceKey, C_Global.CEnum.Msg_Category.MJ_ADMIN, messageBody);

                //检测状态
                if (mResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }
                else if (mResult[0, 0].oContent.Equals("FAILURE"))
                {
                    MessageBox.Show("操作失败");
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
        private C_Global.CEnum.Message_Body[,] mResult = null;
        private C_Global.CEnum.Message_Body[,] lockUserResult = null;


        private string _serverIP = null;
        private string _actionType = null;
        private string _userName = null;

        private C_Global.CEnum.ServiceKey _actionServiceKey = CEnum.ServiceKey.MJ_CHARACTERINFO_UPDATE;
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.serverIP.Text == "")
            {
                MessageBox.Show("请选择服务器");
                this.serverIP.Focus();
                return;
            }
            if (this.actionType.Text == "")
            {
                MessageBox.Show("请选择操作");
                this.actionType.Focus();
                return;
            }
            if (this.userName.Text == "")
            {
                MessageBox.Show("请输入玩家帐号");
                this.userName.Focus();
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
                case "解封帐号":
                    _actionServiceKey = CEnum.ServiceKey.MJ_ACCOUNT_REMOTE_RESTORE;
                    break;
                case "永久封停":
                    if (SaveAccountToLocal())
                    {
                        _actionServiceKey = CEnum.ServiceKey.MJ_ACCOUNT_REMOTE_DELETE;
                    }
                    else
                    {
                        MessageBox.Show("封停失败");
                        return;
                    }
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

        private void accountBehavior_Load(object sender, EventArgs e)
        {
            //加载服务器
            InitializeServerIP();
            //永久停封列表
            InitializeListView();
        }
    }
}