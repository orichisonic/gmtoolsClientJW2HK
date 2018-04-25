using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Controls.LabelTextBox;
using C_Global;
using C_Event;
using Language;

namespace M_GD
{
    [C_Global.CModuleAttribute("玩家帐号管理", "FrmGDAccountManage", "玩家帐号管理", "GD Group")]
    public partial class FrmGDAccountManage : Form
    {
        #region 变量

        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;

        private int iPageCount = 0;//翻页页数

        int userID = 0;
        string serverIP = null;
        string serverName = null;
        string userName = null;
        string userNick = null;
        int selectChar = 0;   //GrdCharacter中当前选中的行 

        #endregion

        public FrmGDAccountManage()
        {
            InitializeComponent();
        }

        #region 创建类库中的窗体
        /// <summary>
        /// 创建类库中的窗体
        /// </summary>
        /// <param name="oParent">MDI 程序的父窗体</param>
        /// <param name="oSocket">Socket</param>
        /// <returns>类库中的窗体</returns>
        public Form CreateModule(object oParent, object oEvent)
        {
            //创建登录窗体
            FrmGDAccountManage mModuleFrm = new FrmGDAccountManage();
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

        #region 初始化语言库
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
            //this.GrpSearch.Text = config.ReadConfigValue("MSD", "UIC_UI_GrpSearch");
            //this.lblServer.Text = config.ReadConfigValue("MSD", "UIC_UI_lblServer");
            //this.lblAccount.Text = config.ReadConfigValue("MSD", "UIC_UI_lblAccount");
            //this.lblNick.Text = config.ReadConfigValue("MSD", "UIC_UI_lblNick");
            //this.btnSearch.Text = config.ReadConfigValue("MSD", "UIC_UI_btnSearch");
            //this.btnClose.Text = config.ReadConfigValue("MSD", "UIC_UI_btnClose");

            //this.tpgCharacter.Text = config.ReadConfigValue("MSD", "UIC_UI_tpgCharacter");

            //this.tpgModiLvl.Text = config.ReadConfigValue("MSD", "AM_UI_tpgModiLvl");
            //this.lblCharLvl.Text = config.ReadConfigValue("MSD", "UIC_UI_lblAccount");
            //this.lblNewLvl.Text = config.ReadConfigValue("MSD", "AM_UI_lblNewLvl");
            //this.btnModiLvl.Text = config.ReadConfigValue("MSD", "AM_UI_btnModiLvl");
            //this.btnResetLvl.Text = config.ReadConfigValue("MSD", "BP_UI_btnReset");

            //this.tpgAddMoney.Text = config.ReadConfigValue("MSD", "AM_UI_tpgAddMoney");
            //this.lblCharMoney.Text = config.ReadConfigValue("MSD", "UIC_UI_lblAccount");
            //this.lblMoney.Text = config.ReadConfigValue("MSD", "AM_UI_lblMoney");
            //this.btnAddMoney.Text = config.ReadConfigValue("MSD", "AM_UI_btnAddMoney");
            //this.btnResetMoney.Text = config.ReadConfigValue("MSD", "BP_UI_btnReset");

            //this.tpgModiPwd.Text = config.ReadConfigValue("MSD", "AM_UI_tpgModiPwd");
            //this.lblCharPwd.Text = config.ReadConfigValue("MSD", "UIC_UI_lblAccount");
            //this.lblTempPwd.Text = config.ReadConfigValue("MSD", "AM_UI_lblTempPwd");
            //this.btnModiPwd.Text = config.ReadConfigValue("MSD", "AM_UI_btnModiPwd");
            //this.btnRecoverPwd.Text = config.ReadConfigValue("MSD", "AM_UI_btnRecoverPwd");
            //this.btnTempPwd.Text = config.ReadConfigValue("MSD", "AM_UI_btnTempPwd");

            tbcResult.Enabled = false;
        }
        #endregion



        #region 登陆窗体加载(得到游戏服务器列表)
        private void FrmGDAccountManage_Load(object sender, EventArgs e)
        {
            try
            {
                IntiFontLib();

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
                mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = 1;

                mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = m_ClientEvent.GetInfo("GameID_SD");

                this.backgroundWorkerFormLoad.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 加载游戏服务器列表backgroundWorker消息发送
        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mServerInfo = Operation_GD.GetServerList(this.m_ClientEvent, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 加载游戏服务器列表backgroundWorker消息接收
        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmbServer = Operation_GD.BuildCombox(mServerInfo, cmbServer);
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_GD.GetItemAddr(mServerInfo, cmbServer.Text));
        }
        #endregion



        #region 切换不同的游戏服务器
        private void cmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_GD.GetItemAddr(mServerInfo, cmbServer.Text));
        }
        #endregion



        #region 查询玩家资料信息
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                tbcResult.SelectedTab = tpgCharacter;//选择角色信息选项卡
                this.GrdCharacter.DataSource = null;

                if (cmbServer.Text == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSD", "UIA_Hint_selectServer"));
                    return;
                }

                serverIP = Operation_GD.GetItemAddr(mServerInfo, cmbServer.Text);
                serverName = cmbServer.Text.Trim();
                userName = txtAccount.Text.Trim();
                userNick = txtNick.Text.Trim();

                if (txtAccount.Text.Trim().Length > 0 || txtNick.Text.Trim().Length > 0)
                {
                    PartInfo();
                }
                else
                {
                    MessageBox.Show(config.ReadConfigValue("MMagic", "UIA_Hint_inPutAccont"));
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 查询角色资料信息
        private void PartInfo()
        {
            try
            {
                tbcResult.SelectedTab = tpgCharacter;//选择角色信息选项卡
                this.GrdCharacter.DataSource = null;

                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];
                //查询玩家角色信息
                mContent[0].eName = CEnum.TagName.SD_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = serverIP;

                mContent[1].eName = CEnum.TagName.SD_UserName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = userName;

                mContent[2].eName = CEnum.TagName.f_pilot;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = userNick;

                backgroundWorkerSearch.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 查询角色资料信息backgroundWorker消息发送
        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_Account_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查询角色资料信息backgroundWorker消息接收
        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.GrpSearch.Enabled = true;
            this.tbcResult.Enabled = true;
            this.Cursor = Cursors.Default;//改变鼠标状态
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, GrdCharacter, out iPageCount);
        }
        #endregion



        #region 单击玩家基本信息保存当前行号
        private void GrdCharacter_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)//单击某一列
                {
                    selectChar = int.Parse(e.RowIndex.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 双击玩家基本信息修改等级
        private void GrdCharacter_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)//双击列名触发
                {
                    selectChar = int.Parse(e.RowIndex.ToString());//保存列
                    if (GrdCharacter.DataSource != null)
                    {
                        tbcResult.SelectedTab = tpgModiLvl;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 切换选项卡进行操作
        private void tbcResult_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                if (GrdCharacter.DataSource != null)
                {
                    DataTable mTable = (DataTable)GrdCharacter.DataSource;
                    userID = int.Parse(mTable.Rows[selectChar][config.ReadConfigValue("GLOBAL", "f_idx")].ToString());//保存玩家帐号ID
                    userName = mTable.Rows[selectChar][config.ReadConfigValue("GLOBAL", "SD_UserName")].ToString();
                    userNick = mTable.Rows[selectChar][config.ReadConfigValue("GLOBAL", "f_pilot")].ToString();
                    if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MSD", "AM_UI_tpgModiLvl")))
                    {
                        txtCharLvl.Text = userName;
                        //NudNewLvl.Value = 1;
                        NudNewLvl.Items.Clear();
                        NudNewLvl.Items.Add("二等兵");
                        NudNewLvl.Items.Add("一等兵");
                        NudNewLvl.Items.Add("上等兵");
                        NudNewLvl.Items.Add("兵长");
                        NudNewLvl.Items.Add("下士");
                        NudNewLvl.Items.Add("中士");
                        NudNewLvl.Items.Add("上士");
                        NudNewLvl.Items.Add("士官长");
                        NudNewLvl.Items.Add("准尉");
                        NudNewLvl.Items.Add("少尉");
                        NudNewLvl.Items.Add("中尉");
                        NudNewLvl.Items.Add("上尉");
                        NudNewLvl.Items.Add("少校");
                        NudNewLvl.Items.Add("中校");
                        NudNewLvl.Items.Add("上校");
                        NudNewLvl.Items.Add("准将");
                        NudNewLvl.Items.Add("少将");
                        NudNewLvl.Items.Add("中将");
                        NudNewLvl.Items.Add("上将");
                        NudNewLvl.Items.Add("元帅");
                        NudNewLvl.SelectedIndex = 0;
                    }
                    else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MSD", "AM_UI_tpgAddMoney")))
                    {
                        txtCharMoney.Text = userName;
                        NudMoney.Value = 1;
                        txtTitle.Text = "";
                        txtContent.Text = "";
                    }
                    else if (tbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MSD", "AM_UI_tpgModiPwd")))
                    {
                        txtCharPwd.Text = userName;
                        txtTempPwd.Text = "";
                    }
                }
                else
                {
                    txtCharLvl.Text = "";
                    //NudNewLvl.Value = 1;
                    NudNewLvl.SelectedIndex= 0;
                    txtCharMoney.Text = "";
                    NudMoney.Value = 1;
                    txtTitle.Text = "";
                    txtContent.Text = "";

                    txtCharPwd.Text = "";
                    txtTempPwd.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion



        #region 修改玩家等级
        private void btnModiLvl_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtCharLvl.Text.Trim() == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSD", "AM_Hint_inputName"));
                    return;
                }

                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.SD_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = serverIP;

                mContent[1].eName = CEnum.TagName.UserByID;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent[2].eName = CEnum.TagName.f_idx;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = userID;

                mContent[3].eName = CEnum.TagName.SD_UserName;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = txtCharLvl.Text.Trim();

              
                if (NudNewLvl.Text.ToString() == "二等兵")
                {
                    mContent[4].eName = CEnum.TagName.f_level;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = 1;
                }
                else if (NudNewLvl.Text.ToString() == "一等兵")
                {
                    mContent[4].eName = CEnum.TagName.f_level;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = 2;
                }
                else if (NudNewLvl.Text.ToString() == "上等兵")
                {
                    mContent[4].eName = CEnum.TagName.f_level;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = 3;
                }
                else if (NudNewLvl.Text.ToString() == "兵长")
                {
                    mContent[4].eName = CEnum.TagName.f_level;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = 4;
                }
                else if (NudNewLvl.Text.ToString() == "下士")
                {
                    mContent[4].eName = CEnum.TagName.f_level;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = 5;
                }
                else if (NudNewLvl.Text.ToString() == "中士")
                {
                    mContent[4].eName = CEnum.TagName.f_level;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = 6;
                }
                else if (NudNewLvl.Text.ToString() == "上士")
                {
                    mContent[4].eName = CEnum.TagName.f_level;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = 7;
                }
                else if (NudNewLvl.Text.ToString() == "士官长")
                {
                    mContent[4].eName = CEnum.TagName.f_level;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = 8;
                }
                else if (NudNewLvl.Text.ToString() == "准尉")
                {
                    mContent[4].eName = CEnum.TagName.f_level;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = 9;
                }
                else if (NudNewLvl.Text.ToString() == "少尉")
                {
                    mContent[4].eName = CEnum.TagName.f_level;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = 10;
                }
                else if (NudNewLvl.Text.ToString() == "中尉")
                {
                    mContent[4].eName = CEnum.TagName.f_level;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = 11;
                }
                else if (NudNewLvl.Text.ToString() == "上尉")
                {
                    mContent[4].eName = CEnum.TagName.f_level;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = 12;

                }
                else if (NudNewLvl.Text.ToString() == "少校")
                {
                    mContent[4].eName = CEnum.TagName.f_level;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = 13;
                }
                else if (NudNewLvl.Text.ToString() == "中校")
                {
                    mContent[4].eName = CEnum.TagName.f_level;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = 14;
                }
                else if (NudNewLvl.Text.ToString() == "上校")
                {
                    mContent[4].eName = CEnum.TagName.f_level;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = 15;
                }
                else if (NudNewLvl.Text.ToString() == "准将")
                {
                    mContent[4].eName = CEnum.TagName.f_level;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = 16;
                }
                else if (NudNewLvl.Text.ToString() == "少将")
                {
                    mContent[4].eName = CEnum.TagName.f_level;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = 17;
                }
                else if (NudNewLvl.Text.ToString() == "中将")
                {
                    mContent[4].eName = CEnum.TagName.f_level;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = 18;
                }
                else if (NudNewLvl.Text.ToString() == "上将")
                {
                    mContent[4].eName = CEnum.TagName.f_level;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = 19;
                }
                else if (NudNewLvl.Text.ToString() == "元帅")
                {
                    mContent[4].eName = CEnum.TagName.f_level;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = 20;
                }
               


                mContent[5].eName = CEnum.TagName.SD_ServerName;
                mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[5].oContent = serverName;

                backgroundWorkerModiLvl.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 修改玩家等级backgroundWorker消息发送
        private void backgroundWorkerModiLvl_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_UpdateExp_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 修改玩家等级backgroundWorker消息接收
        private void backgroundWorkerModiLvl_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.GrpSearch.Enabled = true;
            this.tbcResult.Enabled = true;
            this.Cursor = Cursors.Default;//改变鼠标状态

            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

            Operation_GD.showResult(mResult);

            PartInfo();
            this.txtCharLvl.Text = "";
            this.NudNewLvl.SelectedIndex =0;
        }
        #endregion



        #region 添加金钱
        private void btnAddMoney_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtCharMoney.Text.Trim() == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSD", "AM_Hint_inputName"));
                    return;
                }
                if (txtContent.Text.Trim() == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSD", "AI_Hint_contentNull"));
                    return;
                }

                string itemComb = null;
                itemComb = "1070001 " + NudMoney.Value.ToString().Trim() + " G币|";

                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

                mContent[0].eName = CEnum.TagName.SD_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = serverIP;

                mContent[1].eName = CEnum.TagName.UserByID;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent[2].eName = CEnum.TagName.f_idx;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = userID;

                mContent[3].eName = CEnum.TagName.SD_UserName;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = userName;

                mContent[4].eName = CEnum.TagName.SD_ItemName;
                mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[4].oContent = itemComb;

                mContent[5].eName = CEnum.TagName.SD_Title;
                mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[5].oContent = txtTitle.Text.Trim();

                mContent[6].eName = CEnum.TagName.SD_Content;
                mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[6].oContent = txtContent.Text.Trim();

                mContent[7].eName = CEnum.TagName.f_pilot;
                mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[7].oContent = userNick;

                backgroundWorkerAddMoney.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 添加金钱backgroundWorker消息发送
        private void backgroundWorkerAddMoney_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_UserAdditem_Add, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 添加金钱backgroundWorker消息接收
        private void backgroundWorkerAddMoney_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.GrpSearch.Enabled = true;
            this.tbcResult.Enabled = true;
            this.Cursor = Cursors.Default;//改变鼠标状态

            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

            Operation_GD.showResult(mResult);

            PartInfo();
            this.txtCharMoney.Text = "";
            this.NudMoney.Value = 1;
            this.txtTitle.Text = "";
            this.txtContent.Text = "";
        }
        #endregion



        #region 修改玩家临时密码
        private void btnModiPwd_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtCharPwd.Text.Trim() == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSD", "AM_Hint_selectChar"));
                    return;
                }

                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.SD_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = serverIP;

                mContent[1].eName = CEnum.TagName.UserByID;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent[2].eName = CEnum.TagName.f_idx;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = userID;

                mContent[3].eName = CEnum.TagName.SD_UserName;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = txtCharPwd.Text.Trim();

                mContent[4].eName = CEnum.TagName.SD_TmpPWD;
                mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[4].oContent = txtTempPwd.Text.Trim();

                mContent[5].eName = CEnum.TagName.SD_ServerName;
                mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[5].oContent = serverName;

                backgroundWorkerModiPwd.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 修改玩家临时密码backgroundWorker消息发送
        private void backgroundWorkerModiPwd_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_TmpPassWord_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 修改玩家临时密码backgroundWorker消息接收
        private void backgroundWorkerModiPwd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.GrpSearch.Enabled = true;
            this.tbcResult.Enabled = true;
            this.Cursor = Cursors.Default;//改变鼠标状态

            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

            Operation_GD.showResult(mResult);

            PartInfo();
            this.txtTempPwd.Text = "";
        }
        #endregion



        #region 恢复玩家密码
        private void btnRecoverPwd_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtCharPwd.Text.Trim() == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSD", "AM_Hint_selectChar"));
                    return;
                }

                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.SD_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = serverIP;

                mContent[1].eName = CEnum.TagName.UserByID;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent[2].eName = CEnum.TagName.f_idx;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = userID;

                mContent[3].eName = CEnum.TagName.SD_UserName;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = txtCharPwd.Text.Trim();

                mContent[4].eName = CEnum.TagName.SD_ServerName;
                mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[4].oContent = serverName;

                backgroundWorkerRecoverPwd.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 恢复玩家密码backgroundWorker消息发送
        private void backgroundWorkerRecoverPwd_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_ReTmpPassWord_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 恢复玩家密码backgroundWorker消息接收
        private void backgroundWorkerRecoverPwd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.GrpSearch.Enabled = true;
            this.tbcResult.Enabled = true;
            this.Cursor = Cursors.Default;//改变鼠标状态

            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

            Operation_GD.showResult(mResult);

            PartInfo();
            this.txtTempPwd.Text = "";
        }
        #endregion



        #region 查看玩家临时密码
        private void btnTempPwd_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtCharPwd.Text.Trim() == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSD", "AM_Hint_selectChar"));
                    return;
                }

                this.GrpSearch.Enabled = false;
                this.tbcResult.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.SD_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = serverIP;

                mContent[1].eName = CEnum.TagName.UserByID;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent[2].eName = CEnum.TagName.f_idx;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = userID;

                mContent[3].eName = CEnum.TagName.SD_UserName;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = txtCharPwd.Text.Trim();

                mContent[4].eName = CEnum.TagName.SD_ServerName;
                mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[4].oContent = serverName;

                backgroundWorkerCheckPwd.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 查看玩家临时密码backgroundWorker消息发送
        private void backgroundWorkerCheckPwd_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SD_SearchPassWord_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 查看玩家临时密码backgroundWorker消息接收
        private void backgroundWorkerCheckPwd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.GrpSearch.Enabled = true;
            this.tbcResult.Enabled = true;
            this.Cursor = Cursors.Default;//改变鼠标状态

            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            txtTempPwd.Text = mResult[0, 0].oContent.ToString().Trim();
        }
        #endregion



        #region 重置信息
        private void btnResetLvl_Click(object sender, EventArgs e)
        {
            this.NudNewLvl.SelectedIndex = 0;
        }

        private void btnResetMoney_Click(object sender, EventArgs e)
        {
            this.NudMoney.Value = 1;
            this.txtTitle.Text = "";
            this.txtContent.Text = "";
        }
        #endregion



        #region 窗体关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        private void backgroundWorkerBodyModiLvl_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorkerBodyModiLvl_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}