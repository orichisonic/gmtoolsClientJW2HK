using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Global;
using C_Event;

namespace M_SDO
{
    [C_Global.CModuleAttribute("测试4.0版比赛信息", "testMatchInfo", "测试4.0版比赛信息", "SDO Group")]
    public partial class testMatchInfo : Form
    {
        public testMatchInfo()
        {
            InitializeComponent();
        }

        #region 变量
        private CSocketEvent m_ClientEvent = null;

        C_Global.CEnum.Message_Body[,] serverIPResult = null; //激活码查询结果
        C_Global.CEnum.Message_Body[,] accountResult = null;    //帐号查询结果
        C_Global.CEnum.Message_Body[,] delResult = null;    //帐号查询结果

        private string _ServerIP = null;

        private int pageIndex = 1;  //发送给服务器的开始条数
        private int pageSize = 20;   //每页显示条数
        private int pageCount = 1;  //总页数
        private int currPage = 0;   //当前页数

        private int selectRow = 0;  //默认选中的行

        

        bool needReLoad = false;

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
                messageBody[0].oContent = m_ClientEvent.GetInfo("GameID_SDO");

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 1;

                serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);

                //检测状态
                if (serverIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
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
        /// 读取玩家交易记录
        /// </summary>
        private void ReadInfos()
        {
            dgInfoList.DataSource = null;
            selectRow = 0;
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                if (_ServerIP == null)
                {
                    for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
                    {
                        if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                        {
                            this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                        }
                    }
                }

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.SDO_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.Index;
                messageBody[1].oContent = pageIndex;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.PageSize;
                messageBody[2].oContent = pageSize;

                accountResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_CHALLENGE_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);
               

                if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    toolStripButton2.Enabled = false;
                    toolStripButton3.Enabled = false;
                    btnNextPage.Enabled = false;
                    btnPrevPage.Enabled = false;
                    MessageBox.Show(accountResult[0, 0].oContent.ToString());
                    return;
                }

                pageCount = int.Parse(accountResult[0,21].oContent.ToString());
                tsLblText.Text = "当前页数：" + Convert.ToString(currPage + 1) + "/" + pageCount.ToString();

                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = true;
                toolStripButton3.Enabled = true;
                btnNextPage.Enabled = true;
                btnPrevPage.Enabled = true;

                if (currPage == 0)
                {
                    btnPrevPage.Enabled = false;
                }
                else
                {
                    btnPrevPage.Enabled = true;
                }

                if (currPage + 1 == pageCount)
                {
                    btnNextPage.Enabled = false;
                }
                else
                {
                    btnNextPage.Enabled = true;
                }

                dgInfoList.DataSource = BrowseResultInfo();
                //总页数
                /*
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
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        private void Del()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.SDO_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.SDO_SenceID;
                messageBody[1].oContent = int.Parse(accountResult[selectRow,0].oContent.ToString());

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                delResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SDO_CHALLENGE_DELETE, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);

                //检测状态
                if (delResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(delResult[0, 0].oContent.ToString());
                    return;
                }

                if (delResult[0, 0].oContent.ToString().Equals("FAILURE"))
                {
                    MessageBox.Show("删除失败");
                    return;
                }

                if (delResult[0, 0].oContent.ToString().Equals("SUCESS"))
                {
                    
                    MessageBox.Show("删除成功");
                    ReadInfos();
                }

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
        private DataTable BrowseResultInfo()
        {
            DataTable dgTable = new DataTable();
            try
            {
                dgTable.Columns.Clear();       //清空头信息
                dgTable.Rows.Clear();          //清空行记录

                dgTable.Columns.Add("星期几", typeof(string));
                dgTable.Columns.Add("比赛时间（小时）", typeof(string));
                dgTable.Columns.Add("比赛时间（分钟）", typeof(string));
                dgTable.Columns.Add("开放开始时间（小时）", typeof(string));
                dgTable.Columns.Add("开放开始时间（分钟）", typeof(string));
                dgTable.Columns.Add("开放结束时间（小时）", typeof(string));
                dgTable.Columns.Add("开放结束时间（分钟）", typeof(string));
                dgTable.Columns.Add("G币", typeof(string));
                dgTable.Columns.Add("M币", typeof(string));
                dgTable.Columns.Add("场景", typeof(string));
                dgTable.Columns.Add("曲子1", typeof(string));
                dgTable.Columns.Add("等级1", typeof(string));
                dgTable.Columns.Add("曲子2", typeof(string));
                dgTable.Columns.Add("等级2", typeof(string));
                dgTable.Columns.Add("曲子3", typeof(string));
                dgTable.Columns.Add("等级3", typeof(string));
                dgTable.Columns.Add("曲子4", typeof(string));
                dgTable.Columns.Add("等级4", typeof(string));
                dgTable.Columns.Add("曲子5", typeof(string));
                dgTable.Columns.Add("等级5", typeof(string));


                for (int i = 0; i < accountResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    dgRow["星期几"] = GetDay(accountResult[i, 1].oContent.ToString());
                    dgRow["比赛时间（小时）"] = accountResult[i, 2].oContent.ToString();
                    dgRow["比赛时间（分钟）"] = accountResult[i, 3].oContent.ToString();
                    dgRow["开放开始时间（小时）"] = accountResult[i, 4].oContent.ToString();
                    dgRow["开放开始时间（分钟）"] = accountResult[i, 5].oContent.ToString();
                    dgRow["开放结束时间（小时）"] = accountResult[i, 6].oContent.ToString();
                    dgRow["开放结束时间（分钟）"] = accountResult[i, 7].oContent.ToString();
                    dgRow["G币"] = accountResult[i, 8].oContent.ToString();
                    dgRow["M币"] = accountResult[i, 9].oContent.ToString();
                    dgRow["场景"] = accountResult[i, 10].oContent.ToString();
                    dgRow["曲子1"] = accountResult[i, 11].oContent.ToString();
                    dgRow["等级1"] = accountResult[i, 12].oContent.ToString();
                    dgRow["曲子2"] = accountResult[i, 13].oContent.ToString();
                    dgRow["等级2"] = accountResult[i, 14].oContent.ToString();
                    dgRow["曲子3"] = accountResult[i, 15].oContent.ToString();
                    dgRow["等级3"] = accountResult[i, 16].oContent.ToString();
                    dgRow["曲子4"] = accountResult[i, 17].oContent.ToString();
                    dgRow["等级4"] = accountResult[i, 18].oContent.ToString();
                    dgRow["曲子5"] = accountResult[i, 19].oContent.ToString();
                    dgRow["等级5"] = accountResult[i, 20].oContent.ToString();

                    if (dgTable == null)
                    {
                        dgTable = new DataTable();
                    }
                    dgTable.Rows.Add(dgRow);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("排序出错：\n" + ex.Message);
            }
            return dgTable;
        }

        private string GetDay(string value)
        {
            string day = null;
            switch (value)
            {
                case "0":
                    day = "星期日";
                    break;
                case "1":
                    day = "星期一";
                    break;
                case "2":
                    day = "星期二";
                    break;
                case "3":
                    day = "星期三";
                    break;
                case "4":
                    day = "星期四";
                    break;
                case "5":
                    day = "星期五";
                    break;
                case "6":
                    day = "星期六";
                    break;                    
            }
            return day;
        }
        #endregion

        private void MatchInfo_Load(object sender, EventArgs e)
        {
            
            //toolStripButton1.Enabled = false;
            toolStripButton2.Enabled = false;
            toolStripButton3.Enabled = false;
            btnNextPage.Enabled = false;
            btnPrevPage.Enabled = false;

            tsLblText.Text = null;
            InitializeServerIP();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            C_Global.Betweenness btwnValue = new Betweenness(C_Global.BetweennessValue.FAILURE);
            testMatchInfoEdit matchInfoEdit = new testMatchInfoEdit(false, cbxServerIP.Text.ToString(), btwnValue);
            matchInfoEdit.CreateModule(null, m_ClientEvent);
            if (btwnValue.BtwnValue == C_Global.BetweennessValue.SUCESS)
            {
                ReadInfos();
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            #region 过滤
            if (cbxServerIP.Text == null || cbxServerIP.Text == "")
            {
                MessageBox.Show("请选择服务器");
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

            ReadInfos();
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            currPage -= 1;
            pageIndex = (currPage) * pageSize + 1;

            ReadInfos();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            currPage += 1;
            pageIndex = (currPage) * pageSize + 1;

            ReadInfos();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.OK)
            {
                Del();
            }
           
        }

        private void dgInfoList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectRow = e.RowIndex;

                if (e.ColumnIndex == 10 || e.ColumnIndex == 12 || e.ColumnIndex == 14 || e.ColumnIndex == 16 || e.ColumnIndex == 18)
                {
                    BrowseMusicName browseMusicName = new BrowseMusicName(int.Parse(dgInfoList[e.ColumnIndex, e.RowIndex].Value.ToString()), _ServerIP, MousePosition.X, MousePosition.Y);
                    browseMusicName.CreateModule(null, m_ClientEvent);
                }
            }
            catch
            {
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            C_Global.Betweenness btwnValue = new Betweenness(C_Global.BetweennessValue.FAILURE);

            testMatchInfoEdit matchInfoEdit = new testMatchInfoEdit(true, btwnValue);
            matchInfoEdit.SceneID = int.Parse(accountResult[selectRow,0].oContent.ToString());
            matchInfoEdit.ServerIP = _ServerIP;
            matchInfoEdit.WeekDAY = int.Parse(accountResult[selectRow, 1].oContent.ToString());
            matchInfoEdit.MatPt_hr = int.Parse(accountResult[selectRow, 2].oContent.ToString());
            matchInfoEdit.MatPt_min = int.Parse(accountResult[selectRow, 3].oContent.ToString());
            matchInfoEdit.StPt_hr = int.Parse(accountResult[selectRow, 4].oContent.ToString());
            matchInfoEdit.StPt_min = int.Parse(accountResult[selectRow, 5].oContent.ToString());
            matchInfoEdit.EdPt_hr = int.Parse(accountResult[selectRow, 6].oContent.ToString());
            matchInfoEdit.EdPt_min = int.Parse(accountResult[selectRow, 7].oContent.ToString());
            matchInfoEdit.Gcash = int.Parse(accountResult[selectRow, 8].oContent.ToString());
            matchInfoEdit.Mcash = int.Parse(accountResult[selectRow, 9].oContent.ToString());
            matchInfoEdit.Scene = accountResult[selectRow, 10].oContent.ToString();
            matchInfoEdit.MusicName1 = accountResult[selectRow, 11].oContent.ToString();
            matchInfoEdit.Lv1 = int.Parse(accountResult[selectRow, 12].oContent.ToString());
            matchInfoEdit.MusicName2 = accountResult[selectRow, 13].oContent.ToString();
            matchInfoEdit.Lv2 = int.Parse(accountResult[selectRow, 14].oContent.ToString());
            matchInfoEdit.MusicName3 = accountResult[selectRow, 15].oContent.ToString();
            matchInfoEdit.Lv3 = int.Parse(accountResult[selectRow, 16].oContent.ToString());
            matchInfoEdit.MusicName4 = accountResult[selectRow, 17].oContent.ToString();
            matchInfoEdit.Lv4 = int.Parse(accountResult[selectRow, 18].oContent.ToString());
            matchInfoEdit.MusicName5 = accountResult[selectRow, 19].oContent.ToString();
            matchInfoEdit.Lv5 = int.Parse(accountResult[selectRow, 20].oContent.ToString());
            matchInfoEdit.CreateModule(null, m_ClientEvent);
            
            if (btwnValue.BtwnValue == C_Global.BetweennessValue.SUCESS)
            {
                ReadInfos();
            }
        }

        private void dgInfoList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            needReLoad = true;
            //dgInfoList.
            /*
            DataView dgTableView = new DataView();
            dgTableView = dgTable.DefaultView;
            string AorD = dgInfoList.SortedColumn.Index.ToString() == "1" ? "asc" : "desc";
            string sortType = dgInfoList.SortedColumn.Name + " " + AorD;
            dgTableView.Sort = sortType;


            //int i = 0;


           
            
            CEnum.Message_Body[,] tmpMsg = new CEnum.Message_Body[accountResult.GetLength(0), accountResult.GetLength(1)];
            
            for (int k = 0; k < accountResult.GetLength(0); k++)//行
            {
                for (int j = 0; j < accountResult.GetLength(1); j++)//列
                {
                    tmpMsg[k, j].eName = accountResult[0, j].eName;
                    tmpMsg[k, j].eTag = accountResult[0, j].eTag;
                    tmpMsg[k, j].oContent = int.Parse(dgTable.DefaultView[k].Row[j].ToString());
                }
            }
            accountResult = tmpMsg;
            */

           
        }

        private void dgInfoList_MouseUp(object sender, MouseEventArgs e)
        {
            if (needReLoad)
            {
                dgInfoList.DataSource = BrowseResultInfo();
                //dgInfoList.DataSource = dgTable;
                needReLoad = false;
            }
        }
    }
}