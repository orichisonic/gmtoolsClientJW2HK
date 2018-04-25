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
using Language;
namespace M_SDO
{
    [C_Global.CModuleAttribute("道具获取比率设置", "RateEdit", "道具获取比率设置", "SDO Group")]
    public partial class RateEdit : Form
    {
        public RateEdit()
        {
            InitializeComponent();
        }

        #region 变量
        private CSocketEvent m_ClientEvent = null;

        C_Global.CEnum.Message_Body[,] serverIPResult = null; //激活码查询结果
        C_Global.CEnum.Message_Body[,] accountResult = null;    
        C_Global.CEnum.Message_Body[,] itemResult = null;    //物品查询结果
        C_Global.CEnum.Message_Body[,] actionResult = null;  //操作结果
        C_Global.CEnum.Message_Body[,] delResult = null;    //帐号查询结果

        private string _ServerIP = null;

        private int pageIndex = 1;  //发送给服务器的开始条数
        private int pageSize = 20;   //每页显示条数
        private int pageCount = 1;  //总页数
        private int currPage = 0;   //当前页数

        private int selectRow = 0;  //默认选中的行

        bool needReLoad = false;

        private int iType = 0;
        private int iSex = 1;//默认,男生
        private int iSort = 0;

        private bool isFisrtSearch = true; //在第一次查询并添加页数列表时会再次引发查询,所以设置此开发

        private ActionType actionType = ActionType.New;
        private ListType listType = ListType.list;

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
            this.Text = config.ReadConfigValue("MSDO", "RE_UI_RateEdit");
            this.btnSearch.Text = config.ReadConfigValue("MSDO", "RE_UI_btnSearch");
            this.toolStripLabel3.Text = config.ReadConfigValue("MSDO", "RE_UI_toolStripLabel3");
            this.btnAdd.Text = config.ReadConfigValue("MSDO", "RE_UI_btnAdd");
            this.btnEdit.Text = config.ReadConfigValue("MSDO", "RE_UI_btnEdit");
            this.btnDel.Text = config.ReadConfigValue("MSDO", "RE_UI_btnDel");
            this.btnPrevPage.Text = config.ReadConfigValue("MSDO", "RE_UI_btnPrevPage");
            this.btnNextPage.Text = config.ReadConfigValue("MSDO", "RE_UI_btnNextPage");
            this.toolStripLabel1.Text = config.ReadConfigValue("MSDO", "RE_UI_toolStripLabel1");
            this.toolStripLabel2.Text = config.ReadConfigValue("MSDO", "RE_UI_toolStripLabel2");
            this.label1.Text = config.ReadConfigValue("MSDO", "RE_UI_label1");
            this.label7.Text = config.ReadConfigValue("MSDO", "RE_UI_label7");
            this.rbtSexBoy.Text = config.ReadConfigValue("MSDO", "RE_UI_rbtSexBoy");
            this.rbtSexGirl.Text = config.ReadConfigValue("MSDO", "RE_UI_rbtSexGirl");
            this.label2.Text = config.ReadConfigValue("MSDO", "RE_UI_label2");
            this.label3.Text = config.ReadConfigValue("MSDO", "RE_UI_label3");
            this.label4.Text = config.ReadConfigValue("MSDO", "RE_UI_label4");
            this.label5.Text = config.ReadConfigValue("MSDO", "RE_UI_label5");
            this.label6.Text = config.ReadConfigValue("MSDO", "RE_UI_label6");
            this.btnEditOk.Text = config.ReadConfigValue("MSDO", "RE_UI_btnEditOk");
            this.btnEditCancel.Text = config.ReadConfigValue("MSDO", "RE_UI_btnEditCancel");
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

                accountResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_MEDALITEM_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);


                if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    btnEdit.Enabled = false;
                    btnDel.Enabled = false;
                    btnNextPage.Enabled = false;
                    btnPrevPage.Enabled = false;

                    toolStripLabel1.Enabled = false;
                    toolStripLabel2.Enabled = false;
                    cbxToPageIndex.Enabled = false;

                    MessageBox.Show(accountResult[0, 0].oContent.ToString());
                    return;
                }

                pageCount = int.Parse(accountResult[0, 5].oContent.ToString());
                tsLblText.Text = config.ReadConfigValue("MSDO", "RE_Code_MsgPage") + Convert.ToString(currPage + 1) + "/" + pageCount.ToString();

                if (cbxToPageIndex.Items.Count == 0)
                {
                    for (int i = 1; i <= pageCount; i++)
                    {
                        cbxToPageIndex.Items.Add(i);
                    }
                    cbxToPageIndex.SelectedIndex = 0;
                }
                btnEdit.Enabled = true;
                btnDel.Enabled = true;
                btnNextPage.Enabled = true;
                btnPrevPage.Enabled = true;

                toolStripLabel1.Enabled = true;
                toolStripLabel2.Enabled = true;
                cbxToPageIndex.Enabled = true;

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        /// <summary>
        /// 读取玩家交易记录
        /// </summary>
        private void ReadInfosBySearch()
        {
            dgInfoList.DataSource = null;
            selectRow = 0;
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];

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

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.SDO_ItemName;
                messageBody[1].oContent = txtItemName.Text;

               

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.PageSize;
                messageBody[2].oContent = pageSize;

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].eName = C_Global.CEnum.TagName.Index;
                messageBody[3].oContent = pageIndex;


                accountResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_MEDALITEM_OWNER_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);


                if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    btnEdit.Enabled = false;
                    btnDel.Enabled = false;
                    btnNextPage.Enabled = false;
                    btnPrevPage.Enabled = false;

                    toolStripLabel1.Enabled = false;
                    toolStripLabel2.Enabled = false;
                    cbxToPageIndex.Enabled = false;


                    MessageBox.Show(accountResult[0, 0].oContent.ToString());
                    return;
                }


                pageCount = int.Parse(accountResult[0, 5].oContent.ToString());
                tsLblText.Text = config.ReadConfigValue("MSDO", "RE_Code_MsgPage") + Convert.ToString(currPage + 1) + "/" + pageCount.ToString();

                if (cbxToPageIndex.Items.Count == 0)
                {
                    for (int i = 1; i <= pageCount; i++)
                    {
                        cbxToPageIndex.Items.Add(i);
                    }
                    cbxToPageIndex.SelectedIndex = 0;
                }
                btnEdit.Enabled = true;
                btnDel.Enabled = true;
                btnNextPage.Enabled = true;
                btnPrevPage.Enabled = true;

                toolStripLabel1.Enabled = true;
                toolStripLabel2.Enabled = true;
                cbxToPageIndex.Enabled = true;

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


                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "RE_Code_dtitems"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "RE_Code_dtrait"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "RE_Code_dtlimie"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "RE_Code_dtdays"), typeof(string));
               
                for (int i = 0; i < accountResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    dgRow[config.ReadConfigValue("MSDO", "RE_Code_dtitems")] = accountResult[i, 1].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSDO", "RE_Code_dtrait")] = accountResult[i, 2].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSDO", "RE_Code_dtlimie")] = accountResult[i, 3].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSDO", "RE_Code_dtdays")] = accountResult[i, 4].oContent.ToString();

                    dgTable.Rows.Add(dgRow);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("排序出错：\n" + ex.Message);
            }
            return dgTable;
        }

        /// <summary>
        /// 读取道具物品
        /// </summary>
        private void ReadItems()
        {
            cbxItems.Items.Clear();
            CEnum.Message_Body[] mItemContent = new CEnum.Message_Body[4];

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

            mItemContent[0].eName = CEnum.TagName.SDO_ServerIP;
            mItemContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mItemContent[0].oContent = _ServerIP;

            mItemContent[1].eName = CEnum.TagName.SDO_BigType;
            mItemContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mItemContent[1].oContent = iType;

            mItemContent[2].eName = CEnum.TagName.SDO_SmallType;
            mItemContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mItemContent[2].oContent = iSort;
            mItemContent[3].eName = CEnum.TagName.SDO_ItemName;
            mItemContent[3].eTag = CEnum.TagFormat.TLV_STRING;
            mItemContent[3].oContent = "";

            itemResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_ITEMSHOP_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, mItemContent);

            if (itemResult[0, 0].eName != C_Global.CEnum.TagName.ERROR_Msg)
            {
                for (int i = 0; i < itemResult.GetLength(0); i++)
                {
                    cbxItems.Items.Add(itemResult[i, 3].oContent.ToString());
                }
                cbxItems.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_errMsg"));
            }

            
        }


        private void WriteRate()
        {
            CEnum.Message_Body[] mItemContent = new CEnum.Message_Body[6];

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

            mItemContent[0].eName = CEnum.TagName.SDO_ServerIP;
            mItemContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mItemContent[0].oContent = _ServerIP;

            mItemContent[1].eName = CEnum.TagName.SDO_Precent;
            mItemContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mItemContent[1].oContent = int.Parse(txtRate.Text);

            mItemContent[2].eName = CEnum.TagName.SDO_TimesLimit;
            mItemContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mItemContent[2].oContent = int.Parse(txtTimes.Text);

            mItemContent[3].eName = CEnum.TagName.SDO_DaysLimit;
            mItemContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mItemContent[3].oContent = int.Parse(txtDays.Text);

            int _itemCode = 0;
            if (actionType == ActionType.New)
            {
                for (int i = 0; i < itemResult.GetLength(0); i++)
                {
                    if (itemResult[i, 3].oContent.ToString().Equals(cbxItems.Text))
                    {
                        _itemCode = int.Parse(itemResult[i, 2].oContent.ToString());
                    }
                }
            }
            else
            {
                _itemCode = int.Parse(accountResult[selectRow,0].oContent.ToString());
            }
            mItemContent[4].eName = CEnum.TagName.SDO_ItemCode;
            mItemContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            mItemContent[4].oContent = _itemCode;

            mItemContent[5].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            mItemContent[5].eName = C_Global.CEnum.TagName.UserByID;
            mItemContent[5].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            if (actionType == ActionType.New)
            {
                actionResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_MEDALITEM_CREATE, C_Global.CEnum.Msg_Category.SDO_ADMIN, mItemContent);

            }
            else
            {
                actionResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_MEDALITEM_UPDATE, C_Global.CEnum.Msg_Category.SDO_ADMIN, mItemContent);
            }
            //检测状态
            if (actionResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(actionResult[0, 0].oContent.ToString());
                return;
            }

            if (actionResult[0, 0].oContent.ToString().Equals("FAILURE"))
            {

                MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_MsgcheckF"));
                return;
            }

            if (actionResult[0, 0].oContent.ToString().Equals("SUCESS"))
            {
                dpEditContainer.Visible = false;
                MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_MsgcheckS"));
                ReadInfos();
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

                int _itemCode = 0;
                _itemCode = int.Parse(accountResult[selectRow, 0].oContent.ToString());

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.SDO_ItemCode;
                messageBody[1].oContent = _itemCode;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                delResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SDO_MEDALITEM_DELETE, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);

                //检测状态
                if (delResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(delResult[0, 0].oContent.ToString());
                    return;
                }

                if (delResult[0, 0].oContent.ToString().Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_MsgdelF"));
                    return;
                }

                if (delResult[0, 0].oContent.ToString().Equals("SUCESS"))
                {

                    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_MsgdelS"));
                    ReadInfos();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion



        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            dpEditContainer.Visible = false;
            dpDgContainer.Dock = DockStyle.Fill;
            dividerPanel3.Visible = false;
        }

        private void RateEdit_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            //btnAdd.Enabled = false;
            //cbxBClass.Items.Add(config.ReadConfigValue("MSDO", "IC_Code_comItem"));
            //cbxBClass.Items.Add(config.ReadConfigValue("MSDO", "IC_Code_comItem1"));
            cbxBClass.Items.Add(config.ReadConfigValue("MSDO", "IC_Code_comItem2"));
            btnEdit.Enabled = false;
            btnDel.Enabled = false;

            btnPrevPage.Enabled = false;
            btnNextPage.Enabled = false;

            dpEditContainer.Visible = false;

            toolStripLabel1.Enabled = false;
            toolStripLabel2.Enabled = false;
            cbxToPageIndex.Enabled = false;

            tsLblText.Text = null;

            dpDgContainer.Dock = DockStyle.Fill;
            dividerPanel3.Visible = false;

            InitializeServerIP();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            listType = ListType.list;
            pageIndex = 1;  //发送给服务器的开始条数
            pageSize = 20;   //每页显示条数
            pageCount = 1;  //总页数
            currPage = 0;   //当前页数

            isFisrtSearch = true;

            btnEdit.Enabled = false;
            btnDel.Enabled = false;

            btnPrevPage.Enabled = false;
            btnNextPage.Enabled = false;

            dpEditContainer.Visible = false;

            tsLblText.Text = null;
            cbxToPageIndex.Items.Clear();

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dpDgContainer.Dock = DockStyle.Top;
            dividerPanel3.Visible = true;

            actionType = ActionType.New;
            dpEditContainer.Visible = true;
            cbxBClass.Enabled = true;
            cbxSClass.Enabled = true;
            rbtSexBoy.Enabled = true;
            rbtSexGirl.Enabled = true;
            cbxItems.Enabled = true;
            cbxItems.Items.Clear();
            txtDays.Text = "";
            txtTimes.Text = "";
            txtRate.Text = "";


        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            dpDgContainer.Dock = DockStyle.Top;
            dividerPanel3.Visible = true;
            
            actionType = ActionType.Modi;
            dpEditContainer.Visible = true;
            cbxBClass.Enabled = false;
            cbxSClass.Enabled = false;
            rbtSexBoy.Enabled = false;
            rbtSexGirl.Enabled = false;
            cbxItems.Enabled = false;

            cbxItems.Items.Clear();
            cbxItems.Items.Add(dgInfoList[0, selectRow].Value);
            cbxItems.SelectedIndex = 0;

            txtDays.Text = accountResult[selectRow, 4].oContent.ToString();
            txtTimes.Text = accountResult[selectRow, 3].oContent.ToString();
            txtRate.Text = accountResult[selectRow, 2].oContent.ToString();
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msginfo"), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.OK)
                {
                    Del();
                }
            }
            catch
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_MsgResult"));
            }
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

        private void cbxBClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxSClass.Items.Clear();
            if (cbxBClass.Text == config.ReadConfigValue("MSDO", "RE_Code_Dress"))
            {
                iType = 0;
                cbxSClass.Enabled = true;
                if (rbtSexBoy.Checked)

                    cbxSClass.Items.AddRange(new object[] { config.ReadConfigValue("MSDO", "RE_Code_head"), config.ReadConfigValue("MSDO", "RE_Code_hair"), config.ReadConfigValue("MSDO", "RE_Code_body"), config.ReadConfigValue("MSDO", "RE_Code_leg"), config.ReadConfigValue("MSDO", "RE_Code_hand"), config.ReadConfigValue("MSDO", "RE_Code_feet"), config.ReadConfigValue("MSDO", "RE_Code_face"), config.ReadConfigValue("MSDO", "RE_Code_glass") });
                else
                    cbxSClass.Items.AddRange(new object[] { config.ReadConfigValue("MSDO", "RE_Code_head"), config.ReadConfigValue("MSDO", "RE_Code_hair"), config.ReadConfigValue("MSDO", "RE_Code_body"), config.ReadConfigValue("MSDO", "RE_Code_leg"), config.ReadConfigValue("MSDO", "RE_Code_hand"), config.ReadConfigValue("MSDO", "RE_Code_feet"), config.ReadConfigValue("MSDO", "RE_Code_face"), config.ReadConfigValue("MSDO", "RE_Code_glass"), config.ReadConfigValue("MSDO", "RE_Code_onedress") });
            }
            else if (cbxBClass.Text == config.ReadConfigValue("MSDO", "RE_Code_Item"))
            {
                iType = 1;
                cbxSClass.Enabled = true;
                cbxSClass.Items.AddRange(new object[] { config.ReadConfigValue("MSDO", "RE_Code_eff"), config.ReadConfigValue("MSDO", "RE_Code_fitem") });
            }
            else
            {
                iType = 3;
                iSort = 0;
                cbxSClass.Enabled = false;
                ReadItems();
            }


        }

        private void cbxSClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSClass.Text.Trim() == config.ReadConfigValue("MSDO", "RE_Code_head").Trim())
            {
                iSort = 0;
            }
            else if (cbxSClass.Text.Trim() == config.ReadConfigValue("MSDO", "RE_Code_hair").Trim())
            {
                iSort = 1;
            }
            else if (cbxSClass.Text.Trim() == config.ReadConfigValue("MSDO", "RE_Code_body").Trim())
            {
                iSort = 2;
            }
            else if (cbxSClass.Text.Trim() == config.ReadConfigValue("MSDO", "RE_Code_leg").Trim())
            {
                iSort = 3;
            }
            else if (cbxSClass.Text.Trim() == config.ReadConfigValue("MSDO", "RE_Code_hand").Trim())
            {
                iSort = 4;
            }
            else if (cbxSClass.Text.Trim() == config.ReadConfigValue("MSDO", "RE_Code_feet").Trim())
            {
                iSort = 5;
            }
            else if (cbxSClass.Text.Trim() == config.ReadConfigValue("MSDO", "RE_Code_face").Trim())
            {
                iSort = 6;
            }
            else if (cbxSClass.Text.Trim() == config.ReadConfigValue("MSDO", "RE_Code_glass").Trim())
            {
                iSort = 7;
            }
            else if (cbxSClass.Text.Trim() == config.ReadConfigValue("MSDO", "RE_Code_onedress").Trim())
            {
                iSort = 50;
            }

            //switch (cbxSClass.Text)
            //{
            //    case "头":
            //        iSort = 0;
            //        break;
            //    case "头发":
            //        iSort = 1;
            //        break;
            //    case "身体":
            //        iSort = 2;
            //        break;
            //    case "腿":
            //        iSort = 3;
            //        break;
            //    case "手":
            //        iSort = 4;
            //        break;
            //    case "脚":
            //        iSort = 5;
            //        break;
            //    case "表情":
            //        iSort = 6;
            //        break;
            //    case "眼镜":
            //        iSort = 7;
            //        break;
            //    case "连衣裙":
            //        iSort = 50;
            //        break;
            //}

            if (iSex == 0)
            {
                iSort = iSort + 100;
            }

            //switch (cbxSClass.Text)
            //{
            //    case "特效":
            //    case "功能道具":
            //        iSort = 0;
            //        break;
            //}
            if (cbxSClass.Text.Trim() == config.ReadConfigValue("MSDO", "RE_Code_eff").Trim())
            {
                iSort = 0;
            }
            else if (cbxSClass.Text.Trim() == config.ReadConfigValue("MSDO", "RE_Code_fitem").Trim())
            {
                iSort = 0;
            }

            ReadItems();
        }

        private void rbtSexBoy_Click(object sender, EventArgs e)
        {
            iSex = 1;

            cbxSClass.Items.Clear();
            if (cbxBClass.Text == config.ReadConfigValue("MSDO", "RE_Code_Dress"))
            {
                iType = 0;
                if (rbtSexBoy.Checked)

                //    cbxSClass.Items.AddRange(new object[] { "头", "头发", "身体", "腿", "手", "脚", "表情" });
                //else
                //    cbxSClass.Items.AddRange(new object[] { "头", "头发", "身体", "腿", "手", "脚", "表情", "连衣裙" });

                   cbxSClass.Items.AddRange(new object[] { config.ReadConfigValue("MSDO", "RE_Code_head"), config.ReadConfigValue("MSDO", "RE_Code_hair"), config.ReadConfigValue("MSDO", "RE_Code_body"), config.ReadConfigValue("MSDO", "RE_Code_leg"), config.ReadConfigValue("MSDO", "RE_Code_hand"), config.ReadConfigValue("MSDO", "RE_Code_feet"), config.ReadConfigValue("MSDO", "RE_Code_face"), config.ReadConfigValue("MSDO", "RE_Code_glass") });
                else
                    cbxSClass.Items.AddRange(new object[] { config.ReadConfigValue("MSDO", "RE_Code_head"), config.ReadConfigValue("MSDO", "RE_Code_hair"), config.ReadConfigValue("MSDO", "RE_Code_body"), config.ReadConfigValue("MSDO", "RE_Code_leg"), config.ReadConfigValue("MSDO", "RE_Code_hand"), config.ReadConfigValue("MSDO", "RE_Code_feet"), config.ReadConfigValue("MSDO", "RE_Code_face"), config.ReadConfigValue("MSDO", "RE_Code_glass"), config.ReadConfigValue("MSDO", "RE_Code_onedress") });
            }
            else
            {
                iType = 1;
                cbxSClass.Items.AddRange(new object[] { config.ReadConfigValue("MSDO", "RE_Code_eff"), config.ReadConfigValue("MSDO", "RE_Code_fitem") });
            }
        }

        private void rbtSexGirl_Click(object sender, EventArgs e)
        {
            iSex = 0;

            cbxSClass.Items.Clear();
            if (cbxBClass.Text == config.ReadConfigValue("MSDO", "RE_Code_Dress"))
            {
                iType = 0;
                if (rbtSexBoy.Checked)

                //    cbxSClass.Items.AddRange(new object[] { "头", "头发", "身体", "腿", "手", "脚", "表情" });
                //else
                //    cbxSClass.Items.AddRange(new object[] { "头", "头发", "身体", "腿", "手", "脚", "表情", "连衣裙" });
                    cbxSClass.Items.AddRange(new object[] { config.ReadConfigValue("MSDO", "RE_Code_head"), config.ReadConfigValue("MSDO", "RE_Code_hair"), config.ReadConfigValue("MSDO", "RE_Code_body"), config.ReadConfigValue("MSDO", "RE_Code_leg"), config.ReadConfigValue("MSDO", "RE_Code_hand"), config.ReadConfigValue("MSDO", "RE_Code_feet"), config.ReadConfigValue("MSDO", "RE_Code_face"), config.ReadConfigValue("MSDO", "RE_Code_glass") });
                else
                    cbxSClass.Items.AddRange(new object[] { config.ReadConfigValue("MSDO", "RE_Code_head"), config.ReadConfigValue("MSDO", "RE_Code_hair"), config.ReadConfigValue("MSDO", "RE_Code_body"), config.ReadConfigValue("MSDO", "RE_Code_leg"), config.ReadConfigValue("MSDO", "RE_Code_hand"), config.ReadConfigValue("MSDO", "RE_Code_feet"), config.ReadConfigValue("MSDO", "RE_Code_face"), config.ReadConfigValue("MSDO", "RE_Code_glass"), config.ReadConfigValue("MSDO", "RE_Code_onedress") });
            }
            else
            {
                iType = 1;
                cbxSClass.Items.AddRange(new object[] { config.ReadConfigValue("MSDO", "RE_Code_eff"), config.ReadConfigValue("MSDO", "RE_Code_fitem") });
            }
        }

        private void btnEditOk_Click(object sender, EventArgs e)
        {

            if (actionType == ActionType.New)
            {
                if (cbxBClass.Text == null || cbxBClass.Text == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msgbig"));
                    cbxBClass.Focus();
                    return;
                }
                if (cbxSClass.Enabled == true)
                {
                    if (cbxSClass.Text == null || cbxSClass.Text == "")
                    {
                        MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msgsmall"));
                        cbxSClass.Focus();
                        return;
                    }
                }

                if (cbxItems.Text == null || cbxItems.Text == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msgchitem"));
                    cbxItems.Focus();
                    return;
                }
                
            }

            if (txtRate.Text == null || txtRate.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msgrate"));
                txtRate.Focus();
                return;
            }

            if (txtTimes.Text == null || txtTimes.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msglimit"));
                txtTimes.Focus();
                return;
            }

            if (txtDays.Text == null || txtDays.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msglimit"));
                txtDays.Focus();
                return;
            }
            WriteRate();
        }

        private void dgInfoList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectRow = e.RowIndex;
            dpEditContainer.Visible = false;

            dividerPanel3.Visible = false;
            dpDgContainer.Dock = DockStyle.Fill;
        }

        private void txtRate_MouseUp(object sender, MouseEventArgs e)
        {
            string txt = txtRate.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtRate.Text = rx.Replace(txt, "");
        }

        private void txtRate_KeyUp(object sender, KeyEventArgs e)
        {
            string txt = txtRate.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtRate.Text = rx.Replace(txt, "");
        }

        private void txtTimes_KeyUp(object sender, KeyEventArgs e)
        {
            //string txt = txtTimes.Text.Trim();
            //Regex rx = new Regex(@"[^\d]");
            //txtTimes.Text = rx.Replace(txt, "");
        }

        private void txtTimes_MouseUp(object sender, MouseEventArgs e)
        {
            //string txt = txtTimes.Text.Trim();
            //Regex rx = new Regex(@"[^\d]");
            //txtTimes.Text = rx.Replace(txt, "");
        }

        private void txtDays_MouseUp(object sender, MouseEventArgs e)
        {
            string txt = txtDays.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtDays.Text = rx.Replace(txt, "");
        }

        private void txtDays_KeyUp(object sender, KeyEventArgs e)
        {
            string txt = txtDays.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtDays.Text = rx.Replace(txt, "");
        }



        private void cbxToPageIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            currPage = int.Parse(cbxToPageIndex.Text) - 1;
            pageIndex = (currPage) * pageSize + 1;
            
            if (!isFisrtSearch)
            {
                if (listType == ListType.list)
                {
                    ReadInfos();
                }
                else
                {
                    ReadInfosBySearch();
                }
            }
            isFisrtSearch = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (txtItemName.Text == null || txtItemName.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_MsgItemname"));
                txtItemName.Focus();
                return;
            }

            listType = ListType.itemNameSearch;

            pageIndex = 1;  //发送给服务器的开始条数
            pageSize = 20;   //每页显示条数
            pageCount = 1;  //总页数
            currPage = 0;   //当前页数

            isFisrtSearch = true;

            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            btnNextPage.Enabled = false;
            btnPrevPage.Enabled = false;

            toolStripLabel1.Enabled = false;
            toolStripLabel2.Enabled = false;
            cbxToPageIndex.Enabled = false;

            cbxToPageIndex.Items.Clear();

            ReadInfosBySearch();
        }

        private void dgInfoList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            needReLoad = true;
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

    public enum ActionType
    {
        New,
        Modi
    }

    public enum ListType
    {
        list,
        itemNameSearch
    }
}