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

namespace M_CR
{
    [C_Global.CModuleAttribute("玩家角色信息操作", "PartBehavior", "疯狂卡丁车", "CR")]
    public partial class PartBehavior : Form
    {
        public PartBehavior()
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
        C_Global.CEnum.Message_Body[,] accountResult = null;   //帐号检索结果

        C_Global.CEnum.Message_Body[,] modiResult = null;   //帐号检索结果

        string _ServerIP = null;    //服务器ip
        DataTable dgTable = new DataTable();

        int currSelectPSTID = 0;            //当前选中玩家的注册号
        string currUserAccount = null;      //在修改的玩家id
        string UserNickname = null;
        bool blChkAccount = false;
        bool blChkNick = false;
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
                cbxServerIP.SelectedIndex = 0;
            }
            catch
            {
            }
        }

        /// <summary>
        /// 修改选中玩家信息
        /// </summary>
        private void ModiUserInfo()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[7];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.CR_ServerIP;
                messageBody[1].oContent = _ServerIP;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.CR_PSTID;
                messageBody[2].oContent = currSelectPSTID;


                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].eName = C_Global.CEnum.TagName.CR_EXP;
                messageBody[3].oContent = int.Parse(txtExp.Text.Trim());

                messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[4].eName = C_Global.CEnum.TagName.CR_Money;
                messageBody[4].oContent = int.Parse(txtG.Text.Trim());

                messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[5].eName = C_Global.CEnum.TagName.CR_RMB;
                messageBody[5].oContent = int.Parse(TxtM.Text.Trim());

                messageBody[6].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[6].eName = C_Global.CEnum.TagName.CR_License;
                messageBody[6].oContent = GetLevelValue(cbxLevel.Text.Trim());

                modiResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.CR_CHARACTERINFO_UPDATE, C_Global.CEnum.Msg_Category.CR_ADMIN, messageBody);

                if (modiResult[0, 0].oContent.ToString().Equals("SUCESS"))
                {
                    MessageBox.Show("修改玩家" + txtPlayerID.Text + "信息成功");
                    ReadFromAccount();          //刷新列表
                    dpModi.Visible = false;     //隐藏修改容器
                    return;
                }

                if (modiResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(modiResult[0, 0].oContent.ToString());
                    return;
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// 读取帐号记录
        /// </summary>
        private void ReadFromAccount()
        {
            try
            {
                currUserAccount = txtAccount.Text.ToString();

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.CR_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.CR_ACCOUNT;
                messageBody[1].oContent = blChkAccount ? currUserAccount : "";


                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.CR_NickName;
                messageBody[2].oContent = blChkNick ? currUserAccount : "";

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].eName = C_Global.CEnum.TagName.CR_ACTION;
                messageBody[3].oContent = GetCRAction();

                accountResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.CR_CHARACTERINFO_QUERY, C_Global.CEnum.Msg_Category.CR_ADMIN, messageBody);

                if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(accountResult[0, 0].oContent.ToString());
                    return;
                }

                dgAccountInfo.DataSource = BrowseResultInfo();      //设置datagrid数据源

                dpDataGrid.Visible = true;                          //显示datagrid容器
                dpNoteText.Visible = true;                          //显示文本提示
            }
            catch
            {
            }
        }

        /// <summary>
        /// 将返回数据转装成DataTable
        /// </summary>
        /// <returns></returns>
        private DataTable BrowseResultInfo()
        {
            try
            {
                //dgTable.Columns.Clear();       //清空头信息

                //dgTable.Rows.Clear();          //清空行记录


                dgTable = new DataTable();

                dgTable.Columns.Add("注册号", typeof(string));
                dgTable.Columns.Add("用户ID", typeof(string));

                dgTable.Columns.Add("用户昵称", typeof(string));
                dgTable.Columns.Add("性别", typeof(string));
                dgTable.Columns.Add("驾照等级", typeof(string));
                //dgTable.Columns.Add("玩家称号", typeof(string));
                dgTable.Columns.Add("玩家经验", typeof(string));
                dgTable.Columns.Add("胜利次数", typeof(string));
                dgTable.Columns.Add("失败次数", typeof(string));
                dgTable.Columns.Add("G币", typeof(string));
                dgTable.Columns.Add("M币", typeof(string));
                for (int i = 0; i < accountResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    currSelectPSTID = int.Parse(accountResult[i, 2].oContent.ToString());

                    dgRow["注册号"] = accountResult[i, 2].oContent.ToString();
                    dgRow["用户ID"] = accountResult[i, 0].oContent.ToString();
                    dgRow["用户昵称"] = accountResult[i, 1].oContent.ToString();
                    dgRow["性别"] = accountResult[i, 6].oContent.ToString() == "1" ? "男" : "女";
                    dgRow["驾照等级"] = GetLevelName(int.Parse(accountResult[i, 7].oContent.ToString()));
                    //dgRow["玩家称号"] = accountResult[i, 1].oContent.ToString();
                    dgRow["玩家经验"] = accountResult[i, 3].oContent.ToString();
                    dgRow["胜利次数"] = accountResult[i, 9].oContent.ToString();
                    dgRow["失败次数"] = int.Parse(accountResult[i, 8].oContent.ToString()) - int.Parse(accountResult[i, 9].oContent.ToString());
                    dgRow["G币"] = accountResult[i, 4].oContent.ToString();
                    dgRow["M币"] = accountResult[i, 5].oContent.ToString();
                    dgTable.Rows.Add(dgRow);
                }

            }
            catch
            {
            }
            return dgTable;
        }

        /// <summary>
        /// 返回操作编号　
        /// 1  帐号查询
        /// 2  昵称查询
        /// 3  所有玩家

        /// 4  未激活玩家

        /// </summary>
        /// <returns></returns>
        private int GetCRAction()
        {
            int returnValue = 0;
            if (chkAccount.Checked)
                returnValue = 1;
            if (chkNick.Checked)
                returnValue = 2;
            return returnValue;
        }

        /// <summary>
        /// 获取驾照等级值

        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        private int GetLevelValue(string levelName)
        {
            int levelValue = 0;
            switch (levelName)
            {
                case "白驾照":
                    levelValue = 104;
                    break;
                case "黄驾照":
                    levelValue = 109;
                    break;
                case "蓝驾照":
                    levelValue = 115;
                    break;
                case "绿驾照":
                    levelValue = 122;
                    break;
                case "红驾照":
                    levelValue = 130;
                    break;
                case "彩色驾照":
                    levelValue = 139;
                    break;
                default:
                    levelValue = 0;
                    break;
                }
                return levelValue;
        }

        /// <summary>
        /// 获取驾照等级表示文字
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        private string GetLevelName(int levelValue)
        {
            string levelName = null;
            if (levelValue >= 104 && levelValue < 109)
            {
                levelName = "白驾照";
            }
            else if (levelValue >= 109 && levelValue < 115)
            {
                levelName = "黄驾照";
            }
            else if (levelValue >= 115 && levelValue < 122)
            {
                levelName = "蓝驾照";
            }
            else if (levelValue >= 122 && levelValue < 130)
            {
                levelName = "绿驾照";
            }
            else if (levelValue >= 130 && levelValue < 139)
            {
                levelName = "红驾照";
            }
            else if (levelValue >= 139)
            {
                levelName = "彩色驾照";
            }
            else
            {
                levelName = "";
            }

            return levelName;
        }
        #endregion

        private void PartBehavior_Load(object sender, EventArgs e)
        {
            InitializeServerIP();

            dpDataGrid.Visible = false;     //隐藏datagrid容器 
            dpNoteText.Visible = false;     //隐藏信息提示
            dpModi.Visible = false;         //隐藏信息修改
        }

        private void btnModiPwd_Click(object sender, EventArgs e)
        {
            ModiPwd modiPwd = new ModiPwd();
            modiPwd.CreateModule(null, m_ClientEvent);
        }

        private void chkAccount_Click(object sender, EventArgs e)
        {
            lblIDOrNick.Text = "玩家帐号";
            chkNick.Checked = false;
        }

        private void chkNick_Click(object sender, EventArgs e)
        {
            lblIDOrNick.Text = "玩家昵称";
            chkAccount.Checked = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            #region 检测

            if (!chkAccount.Checked && !chkNick.Checked)
            {
                MessageBox.Show("请选择一种查询方式");
                return;
            }

            if (cbxServerIP.Text == "" || cbxServerIP.Text == null)
            {
                MessageBox.Show("请选择服务器");
                return;
            }

            if (txtAccount.Text == "" || txtAccount.Text == null)
            {
                if (chkAccount.Checked)
                {
                    MessageBox.Show("请输入玩家帐号");
                }
                if (chkNick.Checked)
                {
                    MessageBox.Show("请输入玩家昵称");
                }
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

            dpDataGrid.Visible = false;     //隐藏datagrid容器 
            dpNoteText.Visible = false;     //隐藏信息提示
            dpModi.Visible = false;         //隐藏信息修改

            blChkAccount = chkAccount.Checked;  //表示是否选中帐号
            blChkNick = chkNick.Checked;        //表示是否选中昵称

            ReadFromAccount();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //当前用户
                txtPlayerID.Text = dgTable.Rows[e.RowIndex]["用户ID"].ToString();
                currUserAccount = dgTable.Rows[e.RowIndex]["用户ID"].ToString();
                //驾照等级
                if (dgTable.Rows[e.RowIndex]["驾照等级"] != null && dgTable.Rows[e.RowIndex]["驾照等级"] != "")
                {
                    int cbxLevelSelIndex = cbxLevel.FindString(dgTable.Rows[e.RowIndex]["驾照等级"].ToString());
                    cbxLevel.SelectedIndex = cbxLevelSelIndex;
                }
                //玩家经验
                txtExp.Text = dgTable.Rows[e.RowIndex]["玩家经验"].ToString();
                //G币

                txtG.Text = dgTable.Rows[e.RowIndex]["G币"].ToString();
                //M币
                TxtM.Text = dgTable.Rows[e.RowIndex]["M币"].ToString();
                //
                txtnickname.Text = dgTable.Rows[e.RowIndex]["用户昵称"].ToString();
                UserNickname = txtnickname.Text;
                //显示修改容器
                dpModi.Visible = true;
            }
            catch
            {
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dpDataGrid.Visible = false;     //隐藏datagrid容器 
            dpNoteText.Visible = false;     //隐藏信息提示
            dpModi.Visible = false;         //隐藏信息修改
        }

        private void btnModiCancel_Click(object sender, EventArgs e)
        {
            dpModi.Visible = false;
        }

        private void btnModiApply_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认修改玩家" + txtPlayerID.Text + "的信息？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (txtExp.Text == null || txtExp.Text == "")
                {
                    txtExp.Text = "0";
                }
                if (txtG.Text == null || txtG.Text == "")
                {
                    txtG.Text = "0";
                }
                //修改信息
                ModiUserInfo();
            }
        }

        private void txtExp_KeyUp(object sender, KeyEventArgs e)
        {
            string txt = txtExp.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtExp.Text = rx.Replace(txt,"");
        }

        private void txtG_KeyUp(object sender, KeyEventArgs e)
        {
            string txt = txtG.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtG.Text = rx.Replace(txt, "");
        }

        private void txtG_MouseUp(object sender, MouseEventArgs e)
        {
            string txt = txtG.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtG.Text = rx.Replace(txt, "");
        }

        private void txtExp_MouseUp(object sender, MouseEventArgs e)
        {
            string txt = txtExp.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtExp.Text = rx.Replace(txt, "");
        }

        private void dgAccountInfo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataView dgTableView = new DataView();
            dgTableView = dgTable.DefaultView;
            string AorD = dgAccountInfo.SortedColumn.Index.ToString() == "1" ? "asc" : "desc";
            string sortType = dgAccountInfo.SortedColumn.Name + " " + AorD;
            dgTableView.Sort = sortType;
        }

        private void TxtM_MouseUp(object sender, MouseEventArgs e)
        {
            string txt = TxtM.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            TxtM.Text = rx.Replace(txt, "");
        }

        private void TxtM_KeyUp(object sender, KeyEventArgs e)
        {
            string txt = TxtM.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            TxtM.Text = rx.Replace(txt, "");
        }

        private void btnModNickName_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认修改玩家" + txtPlayerID.Text + "的昵称？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                //if (txtnickname.Text == null || txtnickname.Text == "")
                //{
                //    return;
                //}
                this.txtnickname.ReadOnly = false;
                btnNickname.Enabled = true;
                btnNicknameCanel.Enabled = true;
                btnModNickName.Enabled = false;
            }
        }

        private void btnNicknameCanel_Click(object sender, EventArgs e)
        {
            txtnickname.Text = UserNickname;
            txtnickname.ReadOnly = true;

            btnNickname.Enabled = false;
            btnNicknameCanel.Enabled = false;
            btnModNickName.Enabled = true;
        }

        private void btnNickname_Click(object sender, EventArgs e)
        {
            #region IP检索

            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                {
                    this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion
            if (MessageBox.Show("确认修改玩家" + txtPlayerID.Text + "的昵称？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                ModUserNickname();
            }
        }
        /// <summary>
        /// 修改玩家昵称
        /// </summary>
        private void ModUserNickname()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.CR_ServerIP;
                messageBody[1].oContent = _ServerIP;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.CR_PSTID;
                messageBody[2].oContent = currSelectPSTID;

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[3].eName = C_Global.CEnum.TagName.CR_NickName;
                messageBody[3].oContent = this.txtnickname.Text.Trim();

                C_Global.CEnum.Message_Body[,] modResult = null;

                modResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.CR_NICKNAME_QUERY, C_Global.CEnum.Msg_Category.CR_ADMIN, messageBody);

                if (modResult[0, 0].oContent.ToString().Equals("SUCESS"))
                {
                    MessageBox.Show("修改玩家" + txtPlayerID.Text + "信息成功");
                    ReadFromAccount();          //刷新列表
                    dpModi.Visible = false;     //隐藏修改容器
                    txtnickname.ReadOnly = true;
                    btnNickname.Enabled = false;
                    btnNicknameCanel.Enabled = false;
                    btnModNickName.Enabled = true;
                    return;
                }

                if (modResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(modResult[0, 0].oContent.ToString());
                    return;
                }
            }
            catch
            {
 
            }
        }

    }
}