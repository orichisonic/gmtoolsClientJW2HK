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
    [C_Global.CModuleAttribute("游戏数据库设置", "SetServer", "游戏数据库设置", "User Group")]
    public partial class SetServer : Form
    {
        public SetServer()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private C_Global.CEnum.Message_Body[,] mResult = null;		//列表信息
        private C_Global.CEnum.Message_Body[,] mGameResult = null;		//列表信息
        private CSocketEvent m_ClientEvent = null;
        private string password = null;
        private int _gameID = 0;
        private string _gameName = null;
        private int _gameDBID = 0;

        private int _dbUse = 1; //可用
        #endregion

        #region 自定义函数
        /// <summary>
        /// 初始化列表
        /// </summary>
        public void InitializeListView()
        {
            try
            {
                //Thread thread = new Thread();
                //listViewAcoount.Columns.Clear();
                listViewDBInfo.Items.Clear();
                //正式信息

                mResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_ALL_QUERY, C_Global.CEnum.Msg_Category.COMMON, null);

                //检测状态
                if (mResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }

                //显示内容到列表
                string[] rowInfo = new string[6];
                for (int i = 0; i < mResult.GetLength(0); i++)
                {
                    //行编号
                    rowInfo[0] = Convert.ToString(i + 1);
                    //服务器ip	
                    rowInfo[1] = mResult[i, 1].oContent.ToString();
                    //大区名称
                    rowInfo[2] = mResult[i, 2].oContent.ToString();
                    //游戏名称
                    rowInfo[3] = mResult[i, 4].oContent.ToString();
                    //数据库类型 1,2,3
                    rowInfo[4] = mResult[i, 5].oContent.ToString();
                    //游戏状态
                    rowInfo[5] = mResult[i, 6].oContent.ToString();

                    ListViewItem mlistViewItem = new ListViewItem(rowInfo, -1);
                    this.listViewDBInfo.Items.Add(mlistViewItem);
                    listViewDBInfo.Items[i].Tag = mResult[i, 0].oContent.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 游戏列表
        /// </summary>
        public void InitializeGame()
        {
            try
            {

                //正式信息
                mGameResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.GAME_QUERY, C_Global.CEnum.Msg_Category.GAME_ADMIN, null);

                //检测状态
                if (mGameResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mGameResult[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }

                //显示内容到列表
                for (int i = 0; i < mGameResult.GetLength(0); i++)
                {
                    if (mGameResult[i, 0].oContent.ToString() != "1")
                    {
                        this.cbxGameName.Items.Add(mGameResult[i, 1].oContent.ToString());
                    }
                }
               
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 保存数据库信息
        /// </summary>
        private void SaveDBInfo()
        {
            try
            {

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[8];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_IP;
                messageBody[1].oContent = this.tbxDBIP.Text.Trim();

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.UserName;
                messageBody[2].oContent = this.tbxDBName.Text.Trim();

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[3].eName = C_Global.CEnum.TagName.PassWord;
                messageBody[3].oContent = this.tbxDBPwd.Text.Trim();

                messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[4].eName = C_Global.CEnum.TagName.ServerInfo_GameID;
                messageBody[4].oContent = _gameID;

                messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[5].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[5].oContent = _gameDBID;

                messageBody[6].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[6].eName = C_Global.CEnum.TagName.ServerInfo_City;
                messageBody[6].oContent = this.cbxGameCity.Text.Trim();

                messageBody[7].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[7].eName = C_Global.CEnum.TagName.ServerInfo_GameFlag;
                messageBody[7].oContent = _dbUse;
                







                mResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.LINK_SERVERIP_CREATE, C_Global.CEnum.Msg_Category.COMMON, messageBody);

                //检测状态
                if (mResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }
                else if (mResult[0, 0].oContent.Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MGM", "SS_Code_Failed"));
                    return;
                }
                else
                {
                    InitializeListView();
                    MessageBox.Show(config.ReadConfigValue("MGM", "SS_Code_Succeed"));
                    this.tabControl1.SelectedTab = this.tabControl1.TabPages[1];
                    return;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        private void SetServer_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            InitializeListView();
            InitializeGame();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (this.cbxGameName.Text == null || this.cbxGameName.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "SS_Code_ChooseGame"));
                this.cbxGameName.Focus();
                return;
            }

            if (this.cbxGameType.Text == null || this.cbxGameType.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "SS_Code_ChooseDataBaseType"));
                this.cbxGameType.Focus();
                return;
            }

            if (this.cbxGameCity.Text == null || this.cbxGameCity.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "SS_Code_ChooseRegion"));
                this.cbxGameCity.Focus();
                return;
            }

            if (this.tbxDBIP.Text == null || this.tbxDBIP.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "SS_Code_ChooseIP"));
                this.tbxDBIP.Focus();
                return;
            }

            if (this.tbxDBName.Text == null || this.tbxDBName.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "SS_Code_InputLoginUser"));
                this.tbxDBName.Focus();
                return;
            }

            if (this.tbxDBPwd.Text == null || this.tbxDBPwd.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "SS_Code_InputLoginPwd"));
                this.tbxDBName.Focus();
                return;
            }

            if (this.cbxDBType.Text == null || this.cbxDBType.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "SS_Code_InputStatus"));
                this.cbxDBType.Focus();
                return;
            }

            

            #region 查询游戏ｉｄ
            for (int i = 0; i < this.mGameResult.GetLength(0); i++)
            {
                if (mGameResult[i, 1].oContent.ToString().Trim().Equals(this.cbxGameName.Text.Trim()))
                {
                    this._gameID = int.Parse(mGameResult[i, 0].oContent.ToString());
                }
            }
            #endregion

            #region 查询DB类型
            switch (this.cbxGameType.Text.Trim())
            {
                case "LogDB":
                    this._gameDBID = 3;
                    break;
                case "GameDB":
                    this._gameDBID = 1;
                    break;
                case "MemberDB":
                    this._gameDBID = 2;
                    break;
            }
            #endregion

            #region 获取数据库状态
            if (this.cbxDBType.Text.Trim() == config.ReadConfigValue("MGM", "SS_UI_Enabled"))
            {
                this._dbUse = 1;
            }
            else
            {
                this._dbUse = 0;
            }


            //switch (this.cbxDBType.Text.Trim())
            //{
            //    case "可用":
            //        this._dbUse = 1;
            //        break;
            //    default:
            //        this._dbUse = 0;
            //        break;
            //}
            
            #endregion

            this.SaveDBInfo();
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
            this.Text = config.ReadConfigValue("MGM", "SS_UI_Caption");

            this.tabPage1.Text = config.ReadConfigValue("MGM", "SS_UI_Tab_DataBaseSet");
            this.tabPage2.Text = config.ReadConfigValue("MGM", "SS_UI_Tab_DataBaseInfo");


            this.label1.Text = config.ReadConfigValue("MGM", "SS_UI_GameName");
            this.label6.Text = config.ReadConfigValue("MGM", "SS_UI_GameType");
            this.label5.Text = config.ReadConfigValue("MGM", "SS_UI_Region");
            this.label2.Text = config.ReadConfigValue("MGM", "SS_UI_SqlIp");
            this.label3.Text = config.ReadConfigValue("MGM", "SS_UI_LoginUser");
            this.label4.Text = config.ReadConfigValue("MGM", "SS_UI_LoginPwd");
            this.label7.Text = config.ReadConfigValue("MGM", "SS_UI_Status");
            this.cbxDBType.Text = config.ReadConfigValue("MGM", "SS_UI_Enabled");
            this.btnApply.Text = config.ReadConfigValue("MGM", "SS_UI_BtnApply");
            this.btnCancel.Text = config.ReadConfigValue("MGM", "SS_UI_BtnCancel");


            this.columnHeader1.Text = config.ReadConfigValue("MGM", "SS_UI_LV_ID");
            this.serverIP.Text = config.ReadConfigValue("MGM", "SS_UI_LV_ServerIP");
            this.city.Text = config.ReadConfigValue("MGM", "SS_UI_LV_Region");
            this.gameName.Text = config.ReadConfigValue("MGM", "SS_UI_LV_Game");
            this.dbType.Text = config.ReadConfigValue("MGM", "SS_UI_LV_DataBaseType");
            this.dbFlag.Text = config.ReadConfigValue("MGM", "SS_UI_LV_DataBaseStatus");

        }


        #endregion



    }
}