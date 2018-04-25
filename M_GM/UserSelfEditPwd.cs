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
using Language;

namespace M_GM
{
    [C_Global.CModuleAttribute("修改密码", "UserSelfEditPwd", "修改密码", "User Group")]
    public partial class UserSelfEditPwd : Form
    {
        public UserSelfEditPwd()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.oldPwd.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "UEP_Code_InputOldPwd"));
                this.oldPwd.Focus();
                return;
            }
            if (this.newPwd.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "UEP_Code_InputNewPwd"));
                this.newPwd.Focus();
                return;
            }
            if (this.validatePwd.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "UEP_Code_InputConfPwd"));
                this.validatePwd.Focus();
                return;
            }
            if (!this.newPwd.Text.Trim().Equals(this.validatePwd.Text.Trim()))
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "UEP_Code_PwdErr"));
                this.validatePwd.Focus();
                return;
            }
            if (convertToMD5(this.oldPwd.Text.Trim()) != this.password)
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "UEP_Code_OldPwdErr"));
                this.oldPwd.Focus();
                return;
            }

            try
            {
                //执行操作的返回结果
                C_Global.CEnum.Message_Body[,] resultMsgBody = null;
                //传入的Message_Body
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.User_ID;
                messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.PassWord;
                messageBody[2].oContent = this.newPwd.Text.ToString().Trim();

                resultMsgBody = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.USER_PASSWD_MODIF, C_Global.CEnum.Msg_Category.USER_ADMIN, messageBody);
                //检测状态
                if (resultMsgBody[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(resultMsgBody[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }
                //int a=1;
                if (resultMsgBody[0, 0].oContent.ToString().Trim().ToUpper().Equals("SUCESS"))
                {
                    m_ClientEvent.SaveInfo("USERPASSWORD", convertToMD5(this.newPwd.Text.Trim()));
                    MessageBox.Show(config.ReadConfigValue("MGM", "UEP_Code_Succeed"));
                    this.newPwd.Text = "";
                    this.oldPwd.Text = "";
                    this.validatePwd.Text = "";
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string convertToMD5(string source)
        {
            byte[] md5 = System.Text.UTF8Encoding.UTF8.GetBytes(source.Trim());
            System.Security.Cryptography.MD5CryptoServiceProvider objMD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] output = objMD5.ComputeHash(md5, 0, md5.Length);
            return BitConverter.ToString(output);
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
            //ModiUserPwd modi = new ModiUserPwd();
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
        private string password = null;
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserSelfEditPwd_Load(object sender, EventArgs e)
        {
            IntiFontLib();

            this.password = m_ClientEvent.GetInfo("USERPASSWORD").ToString();
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
            this.Text = config.ReadConfigValue("MGM", "UEP_UI_Caption");

            this.label1.Text = config.ReadConfigValue("MGM", "UEP_UI_Content");
            this.label2.Text = config.ReadConfigValue("MGM", "UEP_UI_OldPwd");
            this.label3.Text = config.ReadConfigValue("MGM", "UEP_UI_NewPwd");
            this.label4.Text = config.ReadConfigValue("MGM", "UEP_UI_ConfPwd");

            this.button1.Text = config.ReadConfigValue("MGM", "UEP_UI_BtnCancel");
            this.button2.Text = config.ReadConfigValue("MGM", "UEP_UI_BtnApply");
        }


        #endregion
    }
}