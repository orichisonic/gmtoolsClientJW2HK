using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Global;
using C_Event;
using System.Text.RegularExpressions;

namespace M_AU
{
    [C_Global.CModuleAttribute("用户资料查询", "UserAbout", "尽舞团", "AU")]
    public partial class UserAbout : Form
    {
        public UserAbout()
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

        C_Global.CEnum.Message_Body[,] serverIPResult = null;   //ip列表信息
        C_Global.CEnum.Message_Body[,] accountResult = null;    //帐号检索结果
        C_Global.CEnum.Message_Body[,] levelResult = null;      //等级检索结果
        C_Global.CEnum.Message_Body[,] modiInfoResult = null;   //等级检索结果
        C_Global.CEnum.Message_Body[,] equipResult = null;      //玩家装备
        C_Global.CEnum.Message_Body[,] delEquipResult = null;   //删除玩家装备返回结果

        DataTable dgTable = new DataTable();
        DataTable dgTableEquip = new DataTable();

        string _ServerIP = null;    //服务器ip
        string userAccount = null;  //修改的玩家帐号，
        int userSN = 0;             //修改的玩家的编号
        int currDgSelectRow = 0;    //玩家信息datagrid 中当前选中的行

        int currItemSelectRow = 0;  //玩家道具 datagrid 中当前选中的行

        int toDelItemID = 0;    //要删除的道具id


        private int pageIndex = 1;  //发送给服务器的开始条数
        private int pageSize = 20;   //每页显示条数
        private int pageCount = 1;  //总页数
        private int currPage = 0;   //当前页数

        #endregion

        #region 函数
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
                messageBody[0].oContent = m_ClientEvent.GetInfo("GameID_AU");

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 1;

                serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);

                //检测状态
                if (serverIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    //游戏列表为空错误信息
                    //MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }

                //显示内容到列表
                for (int i = 0; i < serverIPResult.GetLength(0); i++)
                {
                    this.cbxServerIP.Items.Add(serverIPResult[i, 1].oContent.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 初始化等级及经验
        /// </summary>
        public void InitializeLevelExp()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[1];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.AU_ServerIP;
                messageBody[0].oContent = _ServerIP;

                levelResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.AU_LEVELEXP_QUERY, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);

                //检测状态
                if (levelResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 修改玩家信息
        /// </summary>
        private void ModiUserInfo()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[7];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.AU_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.AU_Exp;
                messageBody[1].oContent = int.Parse(txtExp.Text.Trim());

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.AU_Level;
                messageBody[2].oContent = int.Parse(cbxLevel.Text);

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].eName = C_Global.CEnum.TagName.AU_Money;
                messageBody[3].oContent = int.Parse(txtMoney.Text.Trim());

                messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[4].eName = C_Global.CEnum.TagName.AU_ACCOUNT;
                messageBody[4].oContent = userAccount;

                messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[5].eName = C_Global.CEnum.TagName.AU_UserSN;
                messageBody[5].oContent = userSN;

                messageBody[6].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[6].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[6].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                modiInfoResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.AU_CHARACTERINFO_UPDATE, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);

                if (modiInfoResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(modiInfoResult[0, 0].oContent.ToString());
                    return;
                }

                if (modiInfoResult[0, 0].oContent.ToString().Equals("FAILURE"))
                {
                    MessageBox.Show("修改玩家" + userAccount + "的信息失败");
                    return;
                }

                if (modiInfoResult[0, 0].oContent.ToString().Equals("SUCESS"))
                {
                    ReadPartFromDB(userAccount);
                    DisDpEdit();
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 读取玩家数据
        /// </summary>
        private void ReadPartFromDB()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];
               
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.AU_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.AU_ACCOUNT;
                messageBody[1].oContent = chkAccount.Checked ? txtAccount.Text.Trim() : "";

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.AU_UserNick;
                messageBody[2].oContent = chkNick.Checked ? txtAccount.Text.Trim() : "";

                accountResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.AU_CHARACTERINFO_QUERY, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);

                if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(accountResult[0, 0].oContent.ToString());
                    return;
                }

                if (accountResult[0, 0].oContent.ToString().Equals("0"))
                {
                    MessageBox.Show("没有玩家交易记录");
                    return;
                }

                dgPartInfoList.DataSource = BrowsePartResultInfo();//设置datagrid信息源
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 读取玩家数据
        /// </summary>
        private void ReadPartFromDB(string userAccount)
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.AU_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.AU_ACCOUNT;
                messageBody[1].oContent = userAccount;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.AU_UserNick;
                messageBody[2].oContent = "";

                accountResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.AU_CHARACTERINFO_QUERY, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);

                if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(accountResult[0, 0].oContent.ToString());
                    return;
                }

                dgPartInfoList.DataSource = BrowsePartResultInfo();//设置datagrid信息源
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 获取玩家装备
        /// </summary>
        /// <param name="userAccount"></param>
        private void ReadEquipFromDB(int userSN)
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.AU_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.AU_UserSN;
                messageBody[1].oContent = userSN;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.Index;
                messageBody[2].oContent = pageIndex;

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].eName = C_Global.CEnum.TagName.PageSize;
                messageBody[3].oContent = pageSize;

                equipResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.AU_ITEMSHOP_BYOWNER_QUERY, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);

                if (equipResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(equipResult[0, 0].oContent.ToString());
                    return;
                }

                //总页数
                pageCount = int.Parse(equipResult[0, 5].oContent.ToString());
                //显示内容
                dgEquipList.DataSource = BrowseEquipResultInfo();

                lblPageCount.Text = Convert.ToString(pageCount);
                lblCurrPage.Text = Convert.ToString(currPage + 1);

                //cbxToPageIndex.Items.Clear();
                if (cbxToPageIndex.Items.Count == 0)
                {
                    for (int i = 1; i <= pageCount; i++)
                    {
                        cbxToPageIndex.Items.Add(i);
                    }
                    cbxToPageIndex.SelectedIndex = 0;
                }
                cbxToPageIndex.SelectedText = Convert.ToString(currPage + 1);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 删除玩家装备
        /// </summary>
        /// <param name="userAccount"></param>
        private void DelPlayerEquip()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.AU_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.AU_UserSN;
                messageBody[1].oContent = userSN;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.AU_ItemID;
                messageBody[2].oContent = toDelItemID;

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[3].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                delEquipResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.AU_ITEMSHOP_DELETE, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);

                if (delEquipResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(delEquipResult[0, 0].oContent.ToString());
                    return;
                }

                if (delEquipResult[0, 0].oContent.ToString().Equals("FAILURE"))
                {
                    MessageBox.Show("删除失败");
                    return;
                }

                if (delEquipResult[0, 0].oContent.ToString().Equals("SUCESS"))
                {
                    MessageBox.Show("删除成功");
                    return;
                }

                



                //清空要删除的道具的id
                toDelItemID = 0;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 显示玩家信息到datagrid中
        /// </summary>
        /// <returns></returns>
        private DataTable BrowseEquipResultInfo()
        {
            dgTableEquip.Columns.Clear();       //清空头信息
            dgTableEquip.Rows.Clear();          //清空行记录
            dgTableEquip.Columns.Add("装备名称", typeof(string));
            dgTableEquip.Columns[0].MaxLength = 100;


            for (int i = 0; i < equipResult.GetLength(0); i++)
            {
                DataRow dgRow = dgTableEquip.NewRow();
                dgRow["装备名称"] = equipResult[i, 2].oContent.ToString();
                
                dgTableEquip.Rows.Add(dgRow);
            }
            return dgTableEquip;
        }
        


        private DataTable BrowsePartResultInfo()
        {
            dgTable.Columns.Clear();       //清空头信息
            dgTable.Rows.Clear();          //清空行记录
            dgTable.Columns.Add("玩家序列号", typeof(string));
            dgTable.Columns.Add("玩家帐号", typeof(string));
            dgTable.Columns.Add("玩家昵称", typeof(string));
            dgTable.Columns.Add("性别", typeof(string));
            dgTable.Columns.Add("Email", typeof(string));
            dgTable.Columns.Add("等级", typeof(string));
            dgTable.Columns.Add("经验值", typeof(string));
            dgTable.Columns.Add("玩家位置", typeof(string));
            dgTable.Columns.Add("金钱", typeof(string));
            dgTable.Columns.Add("现金", typeof(string));
            dgTable.Columns.Add("银行", typeof(string));



            for (int i = 0; i < accountResult.GetLength(0); i++)
            {
                DataRow dgRow = dgTable.NewRow();
                dgRow["玩家序列号"] = accountResult[i, 0].oContent.ToString();
                dgRow["玩家帐号"] = accountResult[i, 1].oContent.ToString();
                dgRow["玩家昵称"] = accountResult[i, 2].oContent.ToString();
                dgRow["性别"] = accountResult[i, 9].oContent.ToString() == "F" ? "女" : "男";
                dgRow["Email"] = accountResult[i, 10].oContent.ToString();

                dgRow["等级"] = accountResult[i, 3].oContent.ToString();
                dgRow["经验值"] = accountResult[i, 4].oContent.ToString();
                dgRow["玩家位置"] = accountResult[i, 5].oContent.ToString();
                dgRow["金钱"] = accountResult[i, 6].oContent.ToString();

                dgRow["现金"] = accountResult[i, 7].oContent.ToString();
                dgRow["银行"] = accountResult[i, 8].oContent.ToString();
                dgTable.Rows.Add(dgRow);
            }
            return dgTable;
        }

        /// <summary>
        /// 定位玩家等级在MessagBody中的位置
        /// </summary>
        /// <param name="Exp"></param>
        /// <returns></returns>
        private int ChkUserLevel(int pLevel)
        {
            int levelPos = 0;
            for (int i = 0; i < levelResult.GetLength(0); i++)
            {
                if (int.Parse(levelResult[i, 0].oContent.ToString()) == pLevel)
                {
                    levelPos = i;
                    break;
                }
            }
            return levelPos;
        }

        /// <summary>
        /// 获得等级对应的经验值
        /// </summary>
        /// <param name="pLevel"></param>
        /// <returns></returns>
        private int GetExpFromLevel(int pLevel)
        {
            int expValue = 0;
            for (int i = 0; i < levelResult.GetLength(0); i++)
            {
                if (int.Parse(levelResult[i, 0].oContent.ToString()) == pLevel)
                {
                    expValue = int.Parse(levelResult[i, 1].oContent.ToString());
                    break;
                }
            }
            return expValue;
        }

        /// <summary>
        /// 根据经验值获取等级
        /// </summary>
        /// <param name="pExp"></param>
        /// <returns></returns>
        private int GetLevelFromExp(int pExp)
        {
            int levelValue = 0;       //返回结果
            int currLevelExp = 0;    //当前等级经验
            int currLevel = 0;       //当前等级
            int nextLevelExp = 0;    //下一级经验值

            for (int i = 0; i < levelResult.GetLength(0); i++)
            {
                //获取下一级经验值
                if (i == levelResult.GetLength(0)-1)
                {
                    nextLevelExp = int.Parse(levelResult[i, 1].oContent.ToString());
                }
                else
                {
                    nextLevelExp = int.Parse(levelResult[i + 1, 1].oContent.ToString());
                }
                //获取当前级别经验值
                currLevelExp = int.Parse(levelResult[i, 1].oContent.ToString());
                currLevel = int.Parse(levelResult[i, 0].oContent.ToString());

                if (pExp >= currLevelExp && pExp < nextLevelExp)
                {
                    levelValue = currLevel;
                    break;
                }
            }
            return levelValue;
        }

        /// <summary>
        /// 清楚dpEdit中元素的内容及隐藏dpEdit
        /// </summary>
        private void DisDpEdit()
        {
            dpEdit.Visible = false;
            txtUserNick.Text = "";
            cbxLevel.SelectedIndex = 0;
            txtExp.Text = "";
            txtMoney.Text = "";
        }

        #endregion

        private void UserAbout_Load(object sender, EventArgs e)
        {
            InitializeServerIP();
            

            dpEdit.Visible = false;  //隐藏信息编辑容器
        }

        private void chkNick_Click(object sender, EventArgs e)
        {
            chkAccount.Checked = false;
            lblAccountOrNick.Text = "玩家昵称：";
        }

        private void chkAccount_Click(object sender, EventArgs e)
        {
            chkNick.Checked = false;
            lblAccountOrNick.Text = "玩家帐号：";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            #region 检测
            if (cbxServerIP.Text == "" || cbxServerIP.Text == null)
            {
                MessageBox.Show("请选择服务器");
                return;
            }
            if (!chkAccount.Checked && !chkNick.Checked)
            {
                MessageBox.Show("请选择帐号或昵称查询");
            }
            if (txtAccount.Text == "" || txtAccount.Text == null)
            {
                txtAccount.Focus();
                if (chkAccount.Checked)
                    MessageBox.Show("请输入玩家帐号");
                if (chkNick.Checked)
                    MessageBox.Show("请输入玩家昵称");
                return;
            }
            #endregion

            #region IP检索
            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                {
                    this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion

            ReadPartFromDB();
            InitializeLevelExp();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dgPartInfoList.DataSource = null;   //清空显示内容
            dgTable.Columns.Clear();            //清空头信息
            dgTable.Rows.Clear();               //清空行记录

            /*
             * 清空上一次查询后保存在本地的数据
             * 并同显示一起清除
             * */
            equipResult = null;
            dgEquipList.DataSource = null;
            lblCurrPage.Text = "1";
            lblPageCount.Text = "1";
            cbxToPageIndex.Items.Clear();
        }

        private void dgPartInfoList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //cbxToPageIndex.Items.Clear();
            currDgSelectRow = int.Parse(e.RowIndex.ToString());
        }

        private void cbxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtExp.Text = GetExpFromLevel(int.Parse(cbxLevel.Text)).ToString();
        }

        private void txtExp_KeyUp(object sender, KeyEventArgs e)
        {
            string txt = txtExp.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtExp.Text = rx.Replace(txt, "");

            int txtExpValue = int.Parse(txtExp.Text == "" ? "0" : txtExp.Text.Trim());
            cbxLevel.SelectedIndex = ChkUserLevel(GetLevelFromExp(txtExpValue));
            txtExp.Text = txtExpValue.ToString();
        }

        private void btnModiOk_Click(object sender, EventArgs e)
        {
            ModiUserInfo();
        }

        private void txtMoney_KeyUp(object sender, KeyEventArgs e)
        {
            string txt = txtMoney.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtMoney.Text = rx.Replace(txt, "");
        }

        private void btnModiCancel_Click(object sender, EventArgs e)
        {
            DisDpEdit();
        }

        private void linkEquipment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dgPartInfoList.DataSource == null)
                {
                    MessageBox.Show("请先使用玩家帐号查询，然后点击查看\"身上装备\"");
                    return;
                }

                /*
                 * 清空上一次查询后保存在本地的数据
                 * 并同显示一起清除
                 * */
                equipResult = null;
                dgEquipList.DataSource = null;
                lblCurrPage.Text = "1";
                lblPageCount.Text = "1";
                cbxToPageIndex.Items.Clear();

                /*
                 * 有可能在默认情况（即显示出来的结果默认选中第一行）下，点击事件
                 * 故应在此处放置
                 * */
                userAccount = dgTable.Rows[currDgSelectRow]["玩家帐号"].ToString();
                userSN = int.Parse(dgTable.Rows[currDgSelectRow]["玩家序列号"].ToString());

                ReadEquipFromDB(userSN);

                //转到＂玩家身上装备＂页
                tcInfoCard.SelectedTab = equipList;
            }
            catch
            {
                /*
                 * 当未作查询而点击取消按钮时会出错，此处将该错误过滤
                 * */
            }
        }

        private void linkEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dgPartInfoList.DataSource == null)
                {
                    MessageBox.Show("请先使用玩家帐号查询，然后点击此处修改玩家信息");
                    return;
                }

                dpEdit.Visible = true;  //显示信息编辑容器

                userAccount = dgTable.Rows[currDgSelectRow]["玩家帐号"].ToString();
                userSN = int.Parse(dgTable.Rows[currDgSelectRow]["玩家序列号"].ToString());

                #region 写信息到等级列表
                cbxLevel.Items.Clear();
                for (int i = 0; i < levelResult.GetLength(0); i++)
                {
                    cbxLevel.Items.Add(levelResult[i, 0].oContent.ToString().Trim());
                }
                #endregion

                txtUserNick.Text = dgTable.Rows[currDgSelectRow]["玩家昵称"].ToString();
                cbxLevel.SelectedIndex = ChkUserLevel(int.Parse(dgTable.Rows[currDgSelectRow]["等级"].ToString()));
                txtExp.Text = dgTable.Rows[currDgSelectRow]["经验值"].ToString();
                txtMoney.Text = dgTable.Rows[currDgSelectRow]["金钱"].ToString();
            }
            catch
            {
            }
        }

        private void cbxToPageIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            currPage = int.Parse(cbxToPageIndex.Text) - 1;
            pageIndex = (currPage) * pageSize + 1;
            ReadEquipFromDB(userSN);
        }

        private void tcInfoCard_Click(object sender, EventArgs e)
        {
            try
            {
                cbxToPageIndex.Items.Clear();

                if (tcInfoCard.SelectedTab.Text.Equals("身上装备"))
                {
                    /*
                     * 清空上一次查询后保存在本地的数据
                     * 并同显示一起清除
                     * */
                    equipResult = null;
                    dgEquipList.DataSource = null;
                    lblCurrPage.Text = "1";
                    lblPageCount.Text = "1";
                    cbxToPageIndex.Items.Clear();

                    /*
                     * 有可能在默认情况（即显示出来的结果默认选中第一行）下，点击事件
                     * 故应在此处放置
                     * */
                    userAccount = dgTable.Rows[currDgSelectRow]["玩家帐号"].ToString();
                    userSN = int.Parse(dgTable.Rows[currDgSelectRow]["玩家序列号"].ToString());

                    ReadEquipFromDB(userSN);
                }
            }
            catch
            {
                /*
                 * 当未作查询而点击取消按钮时会出错，此处将该错误过滤
                 * */
            }
        }

        private void dgEquipList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currItemSelectRow = e.RowIndex;
        }

        private void imgtxtctrl1_ITC_CLICIK(object sender)
        {
            /*
             * 如果在玩家身上没有道具的情况下
             * 则点击删除按钮失效
             * */
            if (dgEquipList.DataSource == null)
            {
                return;
            }

            if (MessageBox.Show("确认删除选中道具？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                /*
                 * 执行删除道具操作
                 * */
                toDelItemID = int.Parse(equipResult[currItemSelectRow, 1].oContent.ToString());

                DelPlayerEquip();

                //重新显示内容
                ReadEquipFromDB(userSN);
            }
        }

    }
}