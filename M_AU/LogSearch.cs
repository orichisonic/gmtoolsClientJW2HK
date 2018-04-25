using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Global;
using C_Event;

namespace M_AU
{
    [C_Global.CModuleAttribute("交易/消费记录查询", "LogSearch", "劲舞团", "AU")]
    public partial class LogSearch : Form
    {
        public LogSearch()
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

        C_Global.CEnum.Message_Body[,] paidResult = null;   //帐号检索结果

        string _ServerIP = null;    //服务器ip
        DataTable dgTable = new DataTable();


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
        /// 读取玩家交易记录
        /// </summary>
        private void ReadTradeFromDB()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[9];
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.AU_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.AU_SendUserID;
                messageBody[1].oContent = (chkAccount.Checked ? (chkSend.Checked ? txtAccount.Text.Trim() : "") : "");

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.AU_SendNick;
                messageBody[2].oContent = (chkNick.Checked ? (chkSend.Checked ? txtAccount.Text.Trim() : "") : "");

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[3].eName = C_Global.CEnum.TagName.AU_RecvUserID;
                messageBody[3].oContent = (chkAccount.Checked ? (chkRecv.Checked ? txtAccount.Text.Trim() : "" ) : "");

                messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[4].eName = C_Global.CEnum.TagName.AU_RecvNick;
                messageBody[4].oContent = (chkNick.Checked ? (chkRecv.Checked ? txtAccount.Text.Trim() : "") : "");

                messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_DATE;
                messageBody[5].eName = C_Global.CEnum.TagName.AU_BeginTime;
                messageBody[5].oContent = Convert.ToDateTime(beginDate.Text);

                messageBody[6].eTag = C_Global.CEnum.TagFormat.TLV_DATE;
                messageBody[6].eName = C_Global.CEnum.TagName.AU_EndTime;
                messageBody[6].oContent =Convert.ToDateTime(endDate.Text);

                messageBody[7].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[7].eName = C_Global.CEnum.TagName.Index;
                messageBody[7].oContent = pageIndex;

                messageBody[8].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[8].eName = C_Global.CEnum.TagName.PageSize;
                messageBody[8].oContent = pageSize;

                accountResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.AU_ITEMSHOP_TRADE_QUERY, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);
                paidResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.AU_USERCHARAGESUM_QUERY, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);

                if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    lblTextDes.Visible = false;
                    lblCurrPage.Visible = false;
                    lblPageCount.Visible = false;
                    cbxToPageIndex.Visible = false;
                    cbxToPageIndex.Items.Clear();
                    lblPaidAll.Text = null;

                    MessageBox.Show(accountResult[0, 0].oContent.ToString());
                    return;
                }

                lblPaidAll.Text = "合计：" + paidResult[0, 0].oContent.ToString();

                //总页数
                pageCount = int.Parse(accountResult[0, 7].oContent.ToString());

                lblPageCount.Text = Convert.ToString(pageCount);
                lblCurrPage.Text = Convert.ToString(currPage + 1);

                if (cbxToPageIndex.Items.Count == 0)
                {
                    for (int i = 1; i <= pageCount; i++)
                    {
                        cbxToPageIndex.Items.Add(i);
                    }
                    cbxToPageIndex.SelectedIndex = 0;
                    //cbxToPageIndex.SelectedText = Convert.ToString(currPage + 1);
                }


                dpCase.Visible = true;   //显示datagrid容器
                dgInfoList.DataSource = BrowseTradeResultInfo();//设置datagrid信息源
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 读取玩家消费记录
        /// </summary>
        private void ReadConsumeFromDB()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[8];
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.AU_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.AU_SendUserID;
                messageBody[1].oContent = (chkAccount.Checked ? txtAccount.Text.Trim() : "");

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.AU_SendNick;
                messageBody[2].oContent = (chkNick.Checked ? txtAccount.Text.Trim()  : "");

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[3].eName = C_Global.CEnum.TagName.AU_RecvNick;
                messageBody[3].oContent = (chkNick.Checked ? (chkRecv.Checked ? txtAccount.Text.Trim() : "") : "");

                messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_DATE;
                messageBody[4].eName = C_Global.CEnum.TagName.AU_BeginTime;
                messageBody[4].oContent = Convert.ToDateTime(beginDate.Text);

                messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_DATE;
                messageBody[5].eName = C_Global.CEnum.TagName.AU_EndTime;
                messageBody[5].oContent = Convert.ToDateTime(endDate.Text);

                messageBody[6].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[6].eName = C_Global.CEnum.TagName.Index;
                messageBody[6].oContent = pageIndex;

                messageBody[7].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[7].eName = C_Global.CEnum.TagName.PageSize;
                messageBody[7].oContent = pageSize;

                accountResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.AU_CONSUME_QUERY, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);
                paidResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.AU_USERCONSUMESUM_QUERY, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);

                if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    lblTextDes.Visible = false;
                    lblCurrPage.Visible = false;
                    lblPageCount.Visible = false;
                    cbxToPageIndex.Visible = false;
                    cbxToPageIndex.Items.Clear();
                    lblPaidAll.Text = null;

                    MessageBox.Show(accountResult[0, 0].oContent.ToString());
                    return;
                }


                lblPaidAll.Text = "合计：" + paidResult[0, 0].oContent.ToString();

                //总页数
                pageCount = int.Parse(accountResult[0, 7].oContent.ToString());

                lblPageCount.Text = Convert.ToString(pageCount);
                lblCurrPage.Text = Convert.ToString(currPage + 1);

                if (cbxToPageIndex.Items.Count == 0)
                {
                    for (int i = 1; i <= pageCount; i++)
                    {
                        cbxToPageIndex.Items.Add(i);
                    }
                    cbxToPageIndex.SelectedIndex = 0;
                    //cbxToPageIndex.SelectedText = Convert.ToString(currPage + 1);
                }

                dpCase.Visible = true;                              //显示datagrid容器
                dgInfoList.DataSource = BrowseConsumeResultInfo();  //设置datagrid信息源
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 将返回数据转装成DataTable
        /// </summary>
        /// <returns></returns>
        private DataTable BrowseTradeResultInfo()
        {
            dgTable.Columns.Clear();       //清空头信息
            dgTable.Rows.Clear();          //清空行记录
            dgTable.Columns.Add("赠送人昵称", typeof(string));
            dgTable.Columns.Add("接受人昵称", typeof(string));
            dgTable.Columns.Add("消费日期", typeof(string));
            dgTable.Columns.Add("购买道具", typeof(string));
            dgTable.Columns.Add("G币", typeof(string));

            for (int i = 0; i < accountResult.GetLength(0); i++)
            {
                DataRow dgRow = dgTable.NewRow();
                dgRow["赠送人昵称"] = accountResult[i, 2].oContent.ToString();
                dgRow["接受人昵称"] = accountResult[i, 3].oContent.ToString();
                dgRow["消费日期"] = accountResult[i, 4].oContent.ToString();
                dgRow["购买道具"] = accountResult[i, 5].oContent.ToString();
                dgRow["G币"] = accountResult[i, 6].oContent.ToString();
                dgTable.Rows.Add(dgRow);
            }
            return dgTable;
        }

        /// <summary>
        /// 将返回数据转装成DataTable
        /// </summary>
        /// <returns></returns>
        private DataTable BrowseConsumeResultInfo()
        {
            dgTable.Columns.Clear();       //清空头信息
            dgTable.Rows.Clear();          //清空行记录
            dgTable.Columns.Add("玩家昵称", typeof(string));
            dgTable.Columns.Add("消费日期", typeof(string));
            dgTable.Columns.Add("购买道具", typeof(string));
            dgTable.Columns.Add("G币", typeof(string));

            for (int i = 0; i < accountResult.GetLength(0); i++)
            {
                DataRow dgRow = dgTable.NewRow();
                dgRow["玩家昵称"] = accountResult[i, 2].oContent.ToString();
                dgRow["消费日期"] = accountResult[i, 4].oContent.ToString();
                dgRow["购买道具"] = accountResult[i, 5].oContent.ToString();
                dgRow["G币"] = accountResult[i, 6].oContent.ToString();
                dgTable.Rows.Add(dgRow);
            }
            return dgTable;
        }

        #endregion

        private void LogSearch_Load(object sender, EventArgs e)
        {
            InitializeServerIP();
            dpCase.Visible = false; //隐藏datagrid列表

            lblTextDes.Visible = false;
            lblCurrPage.Visible = false;
            lblPageCount.Visible = false;
            cbxToPageIndex.Visible = false;
            lblPaidAll.Text = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            #region 检测
            if (cbxServerIP.Text == "" || cbxServerIP.Text == null)
            {
                MessageBox.Show("请选择服务器");
                return;
            }
            if (chkTrade.Checked == false && chkConsume.Checked == false)
            {
                MessageBox.Show("请选择要查询的记录类型");
                return;
            }
            if (!chkAccount.Checked && !chkNick.Checked)
            {
                MessageBox.Show("请选择帐号或昵称查询");
            }
            if (chkTrade.Checked)
            {
                if (!chkSend.Checked && !chkRecv.Checked)
                {
                    MessageBox.Show("请选择发送人还是接受人查询");
                    return;
                }
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

            lblTextDes.Visible = true;
            lblCurrPage.Visible = true;
            lblPageCount.Visible = true;
            cbxToPageIndex.Visible = true;

            dpCase.Visible = true;         //隐藏datagrid列表
            dgInfoList.DataSource = null;   //清空datagrid内容


            #region IP检索
            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                {
                    this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion

            if (chkTrade.Checked)
            {
                ReadTradeFromDB();      //查询玩家交易记录
            }
            else
            {
                ReadConsumeFromDB();    //查询玩家消费记录
            }

            

        }

        private void chkTrade_Click(object sender, EventArgs e)
        {
            dpCase.Visible = false;         //隐藏datagrid列表
            dgInfoList.DataSource = null;   //清空datagrid内容
            txtAccount.Clear();             //清空搜索内容
            lblTextDes.Visible = false;
            lblCurrPage.Visible = false;
            lblPageCount.Visible = false;
            cbxToPageIndex.Visible = false;
            cbxToPageIndex.Items.Clear();
            lblPaidAll.Text = null;

            pageIndex = 1;  //发送给服务器的开始条数
            pageCount = 1;  //总页数
            currPage = 0;   //当前页数

            if (chkConsume.Checked)
            {
                chkConsume.Checked = false;
            }

            if (chkTrade.Checked)
            {
                gbSendRecv.Visible = true; //显示掉选择发送人/接收人复选框
            }
            else
            {
                gbSendRecv.Visible = false; //隐藏掉选择发送人/接收人复选框
            }
        }

        private void chkConsume_Click(object sender, EventArgs e)
        {
            dpCase.Visible = false;         //隐藏datagrid列表
            dgInfoList.DataSource = null;   //清空datagrid内容
            txtAccount.Clear();             //清空搜索内容
            lblTextDes.Visible = false;
            lblCurrPage.Visible = false;
            lblPageCount.Visible = false;
            cbxToPageIndex.Visible = false;
            cbxToPageIndex.Items.Clear();
            lblPaidAll.Text = null;

            pageIndex = 1;  //发送给服务器的开始条数
            pageCount = 1;  //总页数
            currPage = 0;   //当前页数

            if (chkTrade.Checked)
            {
                chkTrade.Checked = false;
                gbSendRecv.Visible = false; //隐藏掉选择发送人/接收人复选框


            }
        }

        private void chkAccount_Click(object sender, EventArgs e)
        {
            if (chkAccount.Checked)
            {
                lblAccountOrNick.Text = "玩家帐号：";
                chkNick.Checked = false;
            }
        }

        private void chkNick_Click(object sender, EventArgs e)
        {
            if (chkNick.Checked)
            {
                lblAccountOrNick.Text = "玩家昵称：";
                chkAccount.Checked = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dpCase.Visible = false;         //隐藏datagrid列表
            dgInfoList.DataSource = null;   //清空datagrid内容
            txtAccount.Clear();             //清空搜索内容

            lblTextDes.Visible = false;
            lblCurrPage.Visible = false;
            lblPageCount.Visible = false;
            cbxToPageIndex.Visible = false;
            cbxToPageIndex.Items.Clear();
            lblPaidAll.Text = null;
        }

        private void chkSend_Click(object sender, EventArgs e)
        {
            chkRecv.Checked = false;
        }

        private void chkRecv_Click(object sender, EventArgs e)
        {
            chkSend.Checked = false;
        }

        private void cbxToPageIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            currPage = int.Parse(cbxToPageIndex.Text) - 1;
            pageIndex = (currPage) * pageSize + 1;

            if (chkTrade.Checked)
            {
                ReadTradeFromDB();      //查询玩家交易记录
            }
            else
            {
                ReadConsumeFromDB();    //查询玩家消费记录
            }
        }

    }
}