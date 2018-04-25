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
    public partial class newPwd : Form
    {
        public newPwd()
        {
            InitializeComponent();
        }

        public newPwd(string _serverIP, string _userAccount, C_Global.CEnum.Message_Body[,] _msgBody)
        {
            InitializeComponent();

            this._userAccount = _userAccount;
            this.searchFrmResult = _msgBody;
            this._serverIP = _serverIP;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region 验证
            if (this.nPwd.Text == null || this.nPwd.Text == "")
            {
                MessageBox.Show("请输入新设密码");
                this.nPwd.Focus();
                return;
            }
            if (this.validPwd.Text == null || this.validPwd.Text == "")
            {
                MessageBox.Show("请再一次输入密码");
                this.validPwd.Focus();
                return;
            }
            if (this.nPwd.Text.Trim() != this.validPwd.Text.Trim())
            {
                MessageBox.Show("两次输入的密码不一致");
                this.validPwd.Focus();
                return;
            }
            else
            {
                _userPwd = this.nPwd.Text.Trim();
            }
            #endregion

            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];

            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
            messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[1].eName = C_Global.CEnum.TagName.MJ_ServerIP;
            messageBody[1].oContent = _serverIP;

            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[2].eName = C_Global.CEnum.TagName.MJ_Account;
            messageBody[2].oContent = _userAccount;

            messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[3].eName = C_Global.CEnum.TagName.MJ_PASSWD;
            messageBody[3].oContent = _userPwd;


            searchFrmResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.MJ_ACCOUNTPASSWD_REMOTE_UPDATE, C_Global.CEnum.Msg_Category.MJ_ADMIN, messageBody);

            //检测状态
            if (searchFrmResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(searchFrmResult[0, 0].oContent.ToString());
                //Application.Exit();
                return;
            }
            if (searchFrmResult[0, 0].oContent.Equals("FAILURE"))
            {
                MessageBox.Show("帐号" + _userAccount + "密码修改失败！");
                //Application.Exit();
                return;
            }
            else
            {
                MessageBox.Show("帐号" + _userAccount + "密码修改完成！");
                this.Close();
                return;
            }
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
        //private C_Global.CEnum.Message_Body[,] doResult = null;
        private C_Global.CEnum.Message_Body[,] searchFrmResult = null;

        private string _userPwd = null;
        private string _userAccount = null;
        private string _serverIP = null;
        #endregion
    }
}