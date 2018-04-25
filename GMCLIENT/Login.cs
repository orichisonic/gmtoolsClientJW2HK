using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Management;
using System.Threading;

using System.IO;
using Language;



namespace GMCLIENT
{
    
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.cbxGMID.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MAIN", "Login_Code_InputGmId"));
                return;
            }
            if (this.txtPwd.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MAIN", "Login_Code_InputPwd"));
                return;
            }

            Thread thdLogin = new Thread(new ThreadStart(InvokeLogin));
            thdLogin.Start();
        }


        #region 自定义函数
        /// <summary>
		/// 获取本地机器的mac码
		/// </summary>
		/// <returns></returns>
		public string getMac()
		{
			string mac =null;
			ManagementClass mc;
			mc=new ManagementClass("Win32_NetworkAdapterConfiguration");
			ManagementObjectCollection moc=mc.GetInstances();
			foreach(ManagementObject mo in moc)
			{
				if(mo["IPEnabled"].ToString()=="True")
					mac=mo["MacAddress"].ToString();                    
			}
			return mac;
		}
        #endregion

        #region 变量
        private C_Event.CSocketEvent m_ClientEvent = null;
        private C_Global.CEnum.Message_Body[] mPublicBody = null;
        private C_Global.CEnum.Message_Body[,] sysAdminResult = null;
        private string LANGUAGE_DIR = null;
        C_Global.CIniFile lang_ini_file = null;
        string strPath = null;
        ConfigValue config = null;
        #endregion

        #region MD5
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
        #endregion

        #region 线程
        private void AboutLogin(object sender, System.EventArgs e)
        {
            //发送给服务器的信息
            mPublicBody = new C_Global.CEnum.Message_Body[3];
            C_Global.CEnum.Message_Body[,] connBody = null;
            C_Global.CEnum.Message_Body[,] bakServerConn = null;
            C_Global.CEnum.Message_Body[,] bakServerResult = null;
            C_Global.CEnum.Message_Body[,] resultBody = null;

            C_Event.CSocketEvent bakClientEvent = null;
            //应用程序执行路径
            //strPath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            //读服务器信息
            C_Global.CIniFile mIniFile = new C_Global.CIniFile(strPath + @"\Schmem\Schmem.INI");
            string strServer = mIniFile.ReadValue("SERVER", "Address");
            int iPort = int.Parse(mIniFile.ReadValue("SERVER", "Port"));


            




            //连接、检测服务器状态
            try
            {
                m_ClientEvent = new C_Event.CSocketEvent(strServer, iPort);
            }
            catch
            {
                lblStatusText.Text = config.ReadConfigValue("MAIN", "Login_Code_LostServer");
                //MessageBox.Show("服务器连接失败,请联系管理员!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Application.Exit();
                return;
            }



            



            mPublicBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            mPublicBody[0].eName = C_Global.CEnum.TagName.UserName;
            mPublicBody[0].oContent = this.cbxGMID.Text.ToString().Trim();

            mPublicBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            mPublicBody[1].eName = C_Global.CEnum.TagName.PassWord;
            mPublicBody[1].oContent = this.txtPwd.Text.ToString().Trim();

            mPublicBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            mPublicBody[2].eName = C_Global.CEnum.TagName.MAC;
            mPublicBody[2].oContent = this.getMac();


            #region 备选服务器设置
            int iServersCount = int.Parse(mIniFile.ReadValue("SERVER", "Count"));
            m_ClientEvent.SaveInfo("ServersCount", iServersCount);

            if (iServersCount != 0)
            {
                for (int i = 1; i <= iServersCount; i++)
                {
                    m_ClientEvent.SaveInfo("IpForServer" + i, mIniFile.ReadValue("SERVER", "IpForServer" + i));

                    try
                    {
                        bakClientEvent = new C_Event.CSocketEvent(mIniFile.ReadValue("SERVER" + i, "Address"), int.Parse(mIniFile.ReadValue("SERVER" + i, "Port")));
                        m_ClientEvent.SaveInfo("Server" + i, bakClientEvent);

                        bakServerConn = bakClientEvent.RequestResult(C_Global.CEnum.ServiceKey.CONNECT, C_Global.CEnum.Msg_Category.COMMON, mPublicBody);

                        if (bakServerConn[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                        {
                            MessageBox.Show(bakServerConn[0, 0].oContent.ToString());
                        }

                        //会员查询请求
                        bakServerResult = bakClientEvent.RequestResult(C_Global.CEnum.ServiceKey.ACCOUNT_AUTHOR, C_Global.CEnum.Msg_Category.COMMON, mPublicBody);
                        //检测状态
                        if (bakServerResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                        {
                            MessageBox.Show(bakServerResult[0, 0].oContent.ToString());
                        }
                        else
                        {

                            if (bakServerResult[0, 1].oContent.ToString().ToUpper() != "PASS")
                            {
                                MessageBox.Show(config.ReadConfigValue("MAIN", "Login_Code_BakServer_LoginErr").Replace("{ACCOUNT}", this.cbxGMID.Text.ToString()).Replace("{SERVER}", mIniFile.ReadValue("SERVER" + i, "Address")));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //"创建服务器" + mIniFile.ReadValue("SERVER" + i, "Address") + "的通信连接时失败\n这可能导致部分功能无法正常使用\n请与管理员联系"
                        MessageBox.Show(config.ReadConfigValue("MAIN", "Login_Code_BakServer_CreatSocketErr").Replace("{SERVER}",mIniFile.ReadValue("SERVER" + i, "Address")));
                    }
                }
            }
            #endregion



            //连接服务器
            connBody = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.CONNECT, C_Global.CEnum.Msg_Category.COMMON, mPublicBody);
            //检测状态
            if (connBody[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            {
                lblStatusText.Text = connBody[0, 0].oContent.ToString();
                //MessageBox.Show(connBody[0, 0].oContent.ToString(), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //会员查询请求
            resultBody = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.ACCOUNT_AUTHOR, C_Global.CEnum.Msg_Category.COMMON, mPublicBody);
            //检测状态
            if (resultBody[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            {
                lblStatusText.Text = resultBody[0, 0].oContent.ToString();
                //MessageBox.Show(resultBody[0, 0].oContent.ToString(), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (resultBody[0, 1].oContent.ToString().ToUpper())
            {
                case "MISS":
                    lblStatusText.Text = config.ReadConfigValue("MAIN", "Login_Code_UserOnLine");
                    //MessageBox.Show("您使用的登陆帐号已在线", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //return;
                    break;
                case "FAILURE":
                    lblStatusText.Text = config.ReadConfigValue("MAIN", "Login_Code_LoginFailed");
                    //MessageBox.Show("登录失败...", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //return;
                    break;
                case "PASS":
                case "䅐卓":
                    //保存用户id
                    m_ClientEvent.SaveInfo("USERID", int.Parse(resultBody[0, 0].oContent.ToString()));

                    

                    //获取用户SysAdmin的值
                    C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[1];
                    messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                    messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
                    messageBody[0].oContent = int.Parse(resultBody[0, 0].oContent.ToString());
                    sysAdminResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.USER_SYSADMIN_QUERY, C_Global.CEnum.Msg_Category.USER_ADMIN, messageBody);

                    m_ClientEvent.SaveInfo("SysAdminValue", int.Parse(sysAdminResult[0, 0].oContent.ToString()));
                    m_ClientEvent.SaveInfo("UserInDepart", sysAdminResult[0, 1].oContent.ToString());
                    
                    //保存用户密码
                    m_ClientEvent.SaveInfo("USERPASSWORD", convertToMD5(this.txtPwd.Text.Trim()));
                    //保存语言内容
                    m_ClientEvent.SaveInfo("INI", (object)config);

                    this.Hide();

                    Main main = new Main(m_ClientEvent, strPath);
                    main.Show();
                    break;
            }
        }

        private void ShowStatus()
        {
            Invoke(new EventHandler(ShowStatusControl));
        }

        private void InvokeLogin()
        {
            Thread thdStatus = new Thread(new ThreadStart(ShowStatus));
            thdStatus.Start();
            Invoke(new EventHandler(AboutLogin));
        }


        private void HideStatus()
        {
            this.Size = new Size(302, 201);
            dpStatus.Visible = false;
            this.Invalidate();
        }

        private void ShowStatusControl(object sender, System.EventArgs e)
        {
            this.lblStatusText.Text = config.ReadConfigValue("MAIN", "Login_Code_ConnectServer");
            this.Size = new Size(302, 233);
            dpStatus.Visible = true;
            this.Invalidate();
        }

        /// <summary>
        /// 初始化界面文字
        /// </summary>
        private void IntiUI()
        {
            this.Text = config.ReadConfigValue("MAIN", "Login_UI_Caption");
            this.label1.Text = config.ReadConfigValue("MAIN", "Login_UI_Lbl_GMID");
            this.label2.Text = config.ReadConfigValue("MAIN", "Login_UI_Lbl_Pwd");
            this.btnLogin.Text = config.ReadConfigValue("MAIN", "Login_UI_Btn_Login");
            this.btnCancel.Text = config.ReadConfigValue("MAIN", "Login_UI_Btn_Cancel");
            this.label2.Location = new Point(this.label1.Right - this.label2.Width, this.label2.Location.Y);
        }
        #endregion

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                //应用程序执行路径
                strPath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);

                config = new ConfigValue();
                //string currentOsLanguage = System.Globalization.CultureInfo.CurrentUICulture.IetfLanguageTag;
                string currentOsLanguage = "zh-TW";
                LANGUAGE_DIR = strPath + @"\Lang\" + currentOsLanguage + @"\";

                string[] dlls = new string[] {
                    "GAMES.ini",
                    "MAIN.ini", 
                    "MSDO.ini",
                    "GLOBAL.ini",
                    "MAU.ini",
                    "MAUDITION.ini",
                    "MBAF.ini",
                    "MCR.ini",
                    "MGM.ini",
                    "MO2JAM.ini",
                    "MSOCCER.ini",
                    "MRC.ini",
                    "MJW2.ini",
                    "MSD.ini"
                };


                for (int i = 0; i < dlls.Length; i++)
                {
                    lang_ini_file = new C_Global.CIniFile(LANGUAGE_DIR + dlls[i]);

                    config.Add(dlls[i].Split(new char[] { '.' })[0], lang_ini_file);
                }

                //config.ReadConfigValue("MAIN","Main_UI_Menu_SystemManage")

                IntiUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}