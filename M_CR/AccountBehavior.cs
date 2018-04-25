using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Global;
using C_Event;

namespace M_CR
{
    [C_Global.CModuleAttribute("玩家帐号查询", "AccountBehavior", "疯狂卡丁车", "CR")]
    public partial class AccountBehavior : Form
    {
        public AccountBehavior()
        {
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //SetStyle(ControlStyles.UserPaint, true);

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

        string _ServerIP = null;    //服务器ip
        DataTable dgTable = new DataTable();
        #endregion

        #region 自定义函数


        /// <summary>
        /// 帐号查询　方式失效
        /// </summary>
        private void DisableAccountSearch()
        {
            txtAccount.Clear();
            txtAccount.Enabled = false;
            chkAccount.Checked = false;
        }

        /// <summary>
        /// 昵称查询　方式失效
        /// </summary>
        private void DisableNickSearch()
        {
            txtAccount.Clear();
            txtAccount.Enabled = false;
            chkNick.Checked = false;
        }

        /// <summary>
        /// 启用　帐号查询方式
        /// </summary>
        private void EnableAccountSearch()
        {
            lblIDOrNick.Text = "玩家帐号：";
            chkAccount.Checked = true;
            chkNick.Checked = false;
            chkAllPlayer.Checked = false;
            txtAccount.Enabled = true;
        }

        /// <summary>
        /// 启用　昵称查询
        /// </summary>
        private void EnableNickSearch()
        {
            lblIDOrNick.Text = "玩家昵称：";
            chkAccount.Checked = false;
            chkNick.Checked = true;
            chkAllPlayer.Checked = false;
            txtAccount.Enabled = true;
        }

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

                this.cbxServerIP.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 读取帐号记录
        /// </summary>
        private void ReadFromAccount()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.CR_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.CR_ACCOUNT;
                messageBody[1].oContent = chkAccount.Checked ? txtAccount.Text.Trim() : "";

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.CR_NickName;
                messageBody[2].oContent = chkNick.Checked ? txtAccount.Text.Trim() : "";
             
                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].eName = C_Global.CEnum.TagName.CR_ACTION;
                messageBody[3].oContent = GetCRAction();
                
                accountResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.CR_ACCOUNT_QUERY, C_Global.CEnum.Msg_Category.CR_ADMIN, messageBody);

                if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(accountResult[0, 0].oContent.ToString());
                    return;
                }

                if (accountResult[0, 0].oContent.ToString().Equals("0"))
                {
                    MessageBox.Show("没有找到匹配记录");
                    return;
                }

                dpDGAccountInfo.Visible = true;                 //显示datagrid容器
                dpNoteText.Visible = true;                     //隐藏信息提示
                dgAccountInfo.DataSource = BrowseResultInfo();  //设置datagrid信息源

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 将返回数据转装成DataTable
        /// </summary>
        /// <returns></returns>
        private DataTable BrowseResultInfo()
        {
            //dgTable.Columns.Clear();       //清空头信息

            //dgTable.Rows.Clear();          //清空行记录
            dgTable = new DataTable();

            dgTable.Columns.Add("注册号", typeof(string));
            dgTable.Columns.Add("用户帐号", typeof(string));
            dgTable.Columns.Add("用户昵称", typeof(string));
            dgTable.Columns.Add("性别", typeof(string));
            dgTable.Columns.Add("激活日期", typeof(string));

            for (int i = 0; i < accountResult.GetLength(0); i++)
            {
                DataRow dgRow = dgTable.NewRow();
                dgRow["注册号"] = accountResult[i, 0].oContent.ToString();
                dgRow["用户帐号"] = accountResult[i, 3].oContent.ToString();
                dgRow["用户昵称"] = accountResult[i, 4].oContent.ToString();
                dgRow["性别"] = accountResult[i, 5].oContent.ToString() == "1" ? "男" : "女";
                dgRow["激活日期"] = accountResult[i, 8].oContent.ToString();
                dgTable.Rows.Add(dgRow);
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
            if (chkAllPlayer.Checked)
                returnValue = 3;

            return returnValue;
        }

        #endregion

        private void AccountBehavior_Load(object sender, EventArgs e)
        {
            EnableAccountSearch();              //帐号查询可用
            InitializeServerIP();               //初始化数据库列表
            dpDGAccountInfo.Visible = false;    //隐藏datagrid容器
            dpChangeStatus.Visible = false;     //显示玩家更改状态

            dpNoteText.Visible = false;         //隐藏信息提示
        }

        private void chkAccount_Click(object sender, EventArgs e)
        {
            if (chkAccount.Checked)
            {
                EnableAccountSearch();
            }
            else
            {
                DisableAccountSearch();
            }
        }

        private void chkAllPlayer_Click(object sender, EventArgs e)
        {
            DisableAccountSearch();
            DisableNickSearch();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtAccount.Clear();
            EnableAccountSearch();
            dpDGAccountInfo.Visible = false;    //隐藏datagrid容器
            dpNoteText.Visible = false;         //隐藏信息提示
            dpChangeStatus.Visible = false;     //隐藏玩家更改状态

            dgAccountInfo.DataSource = null;    //设置datagrid为空


        }

        private void chkNick_Click(object sender, EventArgs e)
        {
            if (chkNick.Checked)
            {
                EnableNickSearch();
            }
            else
            {
                DisableNickSearch();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            #region 过滤
            if (!chkAccount.Checked && !chkNick.Checked && !chkAllPlayer.Checked)
            {
                MessageBox.Show("请选择一种查询方式");
                return;
            }
            if (cbxServerIP.Text == null || cbxServerIP.Text == "")
            {
                MessageBox.Show("请选择服务器");
                return;
            }
            if ((chkAccount.Checked || chkNick.Checked) && (txtAccount.Text == null || txtAccount.Text == ""))
            {
                if (chkNick.Checked)
                {
                    MessageBox.Show("请输入玩家昵称");
                    return;
                }
                if (chkAccount.Checked)
                {
                    MessageBox.Show("请输入玩家帐号");
                    return;
                }
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

            dpDGAccountInfo.Visible = false;    //隐藏datagrid容器
            dpNoteText.Visible = false;         //隐藏信息提示
            dgAccountInfo.DataSource = null;    //设置datagrid为空
            dpChangeStatus.Visible = false;     //隐藏玩家更改状态

            ReadFromAccount();                  //查询信息
        }

        private void dgAccountInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //dpChangeStatus.Visible = true;  //显示玩家更改状态

                txtSelectAccount.Text = dgTable.Rows[e.RowIndex]["用户帐号"].ToString();
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}