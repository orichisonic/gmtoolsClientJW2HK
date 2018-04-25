using System;
using System.Collections;
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
    [C_Global.CModuleAttribute("道具获取比率设置", "FrmStageEdit", "道具获取比率设置", "SDO Group")]
    public partial class FrmStageEdit : Form
    {
        public FrmStageEdit()
        {
            InitializeComponent();
        }

        #region 变量
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;

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
        private string Myitemcode = null;
        private bool isFisrtSearch = true; //在第一次查询并添加页数列表时会再次引发查询,所以设置此开发




        private ActionType actionType = ActionType.New;
        private ListType listType = ListType.list;
        private ArrayList arrItemName = new ArrayList();
        private ArrayList arrItemCode = new ArrayList();
        private Hashtable table = new Hashtable();

        ShortStringDictionary ssd = new ShortStringDictionary();//物品1

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
            //this.Text = config.ReadConfigValue("MSDO", "RE_UI_RateEdit");
            //this.btnSearch.Text = config.ReadConfigValue("MSDO", "RE_UI_btnSearch");
            ////this.toolStripLabel3.Text = config.ReadConfigValue("MSDO", "RE_UI_toolStripLabel3");
            //this.btnAdd.Text = config.ReadConfigValue("MSDO", "RE_UI_btnAdd");
            //this.btnEdit.Text = config.ReadConfigValue("MSDO", "RE_UI_btnEdit");
            //this.btnDel.Text = config.ReadConfigValue("MSDO", "RE_UI_btnDel");
            //this.btnPrevPage.Text = config.ReadConfigValue("MSDO", "RE_UI_btnPrevPage");
            //this.btnNextPage.Text = config.ReadConfigValue("MSDO", "RE_UI_btnNextPage");
            //this.toolStripLabel1.Text = config.ReadConfigValue("MSDO", "RE_UI_toolStripLabel1");
            //this.toolStripLabel2.Text = config.ReadConfigValue("MSDO", "RE_UI_toolStripLabel2");
            //this.label1.Text = config.ReadConfigValue("MSDO", "RE_UI_label1");
            //this.label7.Text = config.ReadConfigValue("MSDO", "RE_UI_label7");
            //this.rbtSexBoy.Text = config.ReadConfigValue("MSDO", "RE_UI_rbtSexBoy");
            //this.rbtSexGirl.Text = config.ReadConfigValue("MSDO", "RE_UI_rbtSexGirl");
            //this.label2.Text = config.ReadConfigValue("MSDO", "RE_UI_label2");
            //this.label3.Text = config.ReadConfigValue("MSDO", "RE_UI_label3");
            //this.label4.Text = config.ReadConfigValue("MSDO", "RE_UI_label4");
            //this.label5.Text = config.ReadConfigValue("MSDO", "RE_UI_label5");
            //this.label6.Text = config.ReadConfigValue("MSDO", "RE_UI_label6");
            //this.btnEditOk.Text = config.ReadConfigValue("MSDO", "RE_UI_btnEditOk");
            //this.btnEditCancel.Text = config.ReadConfigValue("MSDO", "RE_UI_btnEditCancel");
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

                this.backgroundWorkerFormLoad.RunWorkerAsync(messageBody);
                
                //serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);

                ////检测状态



                //if (serverIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
                //    return;
                //}

                ////显示内容到列表



                //for (int i = 0; i < serverIPResult.GetLength(0); i++)
                //{
                //    this.cbxServerIP.Items.Add(serverIPResult[i, 1].oContent.ToString());
                //}

                //cbxServerIP.SelectedIndex = 0;
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
            this.toolStrip1.Enabled = false;
            this.Cursor = Cursors.AppStarting;
            
            dgInfoList.DataSource = null;
            selectRow = 0;
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[1];

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

                //messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                //messageBody[1].eName = C_Global.CEnum.TagName.Index;
                //messageBody[1].oContent = pageIndex;

                //messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                //messageBody[2].eName = C_Global.CEnum.TagName.PageSize;
                //messageBody[2].oContent = pageSize;

                //ArrayList paramList = new ArrayList();
                //paramList.Add("ReadInfos");
                //paramList.Add(messageBody);

                this.backgroundWorkerSearch.RunWorkerAsync(messageBody);

                //accountResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_MEDALITEM_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);


                //if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    btnEdit.Enabled = false;
                //    btnDel.Enabled = false;
                //    btnNextPage.Enabled = false;
                //    btnPrevPage.Enabled = false;

                //    toolStripLabel1.Enabled = false;
                //    toolStripLabel2.Enabled = false;
                //    cbxToPageIndex.Enabled = false;

                //    MessageBox.Show(accountResult[0, 0].oContent.ToString());
                //    return;
                //}

                //pageCount = int.Parse(accountResult[0, 5].oContent.ToString());
                //tsLblText.Text = config.ReadConfigValue("MSDO", "RE_Code_MsgPage") + Convert.ToString(currPage + 1) + "/" + pageCount.ToString();

                //if (cbxToPageIndex.Items.Count == 0)
                //{
                //    for (int i = 1; i <= pageCount; i++)
                //    {
                //        cbxToPageIndex.Items.Add(i);
                //    }
                //    cbxToPageIndex.SelectedIndex = 0;
                //}
                //btnEdit.Enabled = true;
                //btnDel.Enabled = true;
                //btnNextPage.Enabled = true;
                //btnPrevPage.Enabled = true;

                //toolStripLabel1.Enabled = true;
                //toolStripLabel2.Enabled = true;
                //cbxToPageIndex.Enabled = true;

                //if (currPage == 0)
                //{
                //    btnPrevPage.Enabled = false;
                //}
                //else
                //{
                //    btnPrevPage.Enabled = true;
                //}

                //if (currPage + 1 == pageCount)
                //{
                //    btnNextPage.Enabled = false;
                //}
                //else
                //{
                //    btnNextPage.Enabled = true;
                //}

                //dgInfoList.DataSource = BrowseResultInfo();
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
            //this.toolStrip1.Enabled = false;
            //this.Cursor = Cursors.AppStarting;
            
            //dgInfoList.DataSource = null;
            //selectRow = 0;
            //try
            //{
            //    C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];

            //    if (_ServerIP == null)
            //    {
            //        for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            //        {
            //            if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
            //            {
            //                this._ServerIP = serverIPResult[i, 0].oContent.ToString();
            //            }
            //        }
            //    }

            //    messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            //    messageBody[0].eName = C_Global.CEnum.TagName.SDO_ServerIP;
            //    messageBody[0].oContent = _ServerIP;

            //    messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            //    messageBody[1].eName = C_Global.CEnum.TagName.SDO_ItemName;
            //    messageBody[1].oContent = txtItemName.Text.Trim();

               

            //    messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            //    messageBody[2].eName = C_Global.CEnum.TagName.PageSize;
            //    messageBody[2].oContent = pageSize;

            //    messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            //    messageBody[3].eName = C_Global.CEnum.TagName.Index;
            //    messageBody[3].oContent = pageIndex;

            //    ArrayList paramList = new ArrayList();
            //    paramList.Add("ReadInfosBySearch");
            //    paramList.Add(messageBody);

                //this.backgroundWorkerSearch.RunWorkerAsync(paramList);

                //accountResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_MEDALITEM_OWNER_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);


                //if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    btnEdit.Enabled = false;
                //    btnDel.Enabled = false;
                //    btnNextPage.Enabled = false;
                //    btnPrevPage.Enabled = false;

                //    toolStripLabel1.Enabled = false;
                //    toolStripLabel2.Enabled = false;
                //    cbxToPageIndex.Enabled = false;


                //    MessageBox.Show(accountResult[0, 0].oContent.ToString());
                //    return;
                //}


                //pageCount = int.Parse(accountResult[0, 5].oContent.ToString());
                //tsLblText.Text = config.ReadConfigValue("MSDO", "RE_Code_MsgPage") + Convert.ToString(currPage + 1) + "/" + pageCount.ToString();

                //if (cbxToPageIndex.Items.Count == 0)
                //{
                //    for (int i = 1; i <= pageCount; i++)
                //    {
                //        cbxToPageIndex.Items.Add(i);
                //    }
                //    cbxToPageIndex.SelectedIndex = 0;
                //}
                //btnEdit.Enabled = true;
                //btnDel.Enabled = true;
                //btnNextPage.Enabled = true;
                //btnPrevPage.Enabled = true;

                //toolStripLabel1.Enabled = true;
                //toolStripLabel2.Enabled = true;
                //cbxToPageIndex.Enabled = true;

                //if (currPage == 0)
                //{
                //    btnPrevPage.Enabled = false;
                //}
                //else
                //{
                //    btnPrevPage.Enabled = true;
                //}

                //if (currPage + 1 == pageCount)
                //{
                //    btnNextPage.Enabled = false;
                //}
                //else
                //{
                //    btnNextPage.Enabled = true;
                //}

                //dgInfoList.DataSource = BrowseResultInfo();
                
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

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

                dgTable.Columns.Add("ID");
                dgTable.Columns.Add("道具1ID");
                dgTable.Columns.Add("道具1名稱");
                dgTable.Columns.Add("道具1次數");
                dgTable.Columns.Add("道具1期限");
                dgTable.Columns.Add("道具2ID");
                dgTable.Columns.Add("道具2名稱");
                dgTable.Columns.Add("道具2次數");
                dgTable.Columns.Add("道具2期限");
                dgTable.Columns.Add("道具3ID");
                dgTable.Columns.Add("道具3名稱");
                dgTable.Columns.Add("道具3次數");
                dgTable.Columns.Add("道具3期限");
                dgTable.Columns.Add("道具4ID");
                dgTable.Columns.Add("道具4名稱");
                dgTable.Columns.Add("道具4次數");
                dgTable.Columns.Add("道具4期限");
                dgTable.Columns.Add("道具5ID");
                dgTable.Columns.Add("道具5名稱");
                dgTable.Columns.Add("道具5次數");
                dgTable.Columns.Add("道具5期限");

           
               
                for (int i = 0; i < accountResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    dgRow["ID"] = accountResult[i, 0].oContent.ToString();
                    dgRow["道具1ID"] = accountResult[i, 1].oContent.ToString();
                    dgRow["道具1名稱"] = accountResult[i, 2].oContent.ToString();
                    dgRow["道具1次數"] = accountResult[i, 3].oContent.ToString();
                    dgRow["道具1期限"] = accountResult[i, 4].oContent.ToString();
                    dgRow["道具2ID"] = accountResult[i, 5].oContent.ToString();
                    dgRow["道具2名稱"] = accountResult[i, 6].oContent.ToString();
                    dgRow["道具2次數"] = accountResult[i, 7].oContent.ToString();
                    dgRow["道具2期限"] = accountResult[i, 8].oContent.ToString();
                    dgRow["道具3ID"] = accountResult[i, 9].oContent.ToString();
                    dgRow["道具3名稱"] = accountResult[i, 10].oContent.ToString();
                    dgRow["道具3次數"] = accountResult[i, 11].oContent.ToString();
                    dgRow["道具3期限"] = accountResult[i, 12].oContent.ToString();
                    dgRow["道具4ID"] = accountResult[i, 13].oContent.ToString();
                    dgRow["道具4名稱"] = accountResult[i, 14].oContent.ToString();
                    dgRow["道具4次數"] = accountResult[i, 15].oContent.ToString();
                    dgRow["道具4期限"] = accountResult[i, 16].oContent.ToString();
                    dgRow["道具5ID"] = accountResult[i, 17].oContent.ToString();
                    dgRow["道具5名稱"] = accountResult[i, 18].oContent.ToString();
                    dgRow["道具5次數"] = accountResult[i, 19].oContent.ToString();
                    dgRow["道具5期限"] = accountResult[i, 20].oContent.ToString();



                    dgTable.Rows.Add(dgRow);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("排序出錯：\n" + ex.Message);
            }
            return dgTable;
        }

        /// <summary>
        /// 读取道具物品
        /// </summary>
        private void ReadItems()
        {
            //cbxItems.Items.Clear();
            //cbxItems1.Items.Clear();
            //cbxItems2.Items.Clear();
            //cbxItems3.Items.Clear();
            //cbxItems4.Items.Clear();

            CEnum.Message_Body[] mItemContent = new CEnum.Message_Body[5];

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


            if (this.cbxSClass.Text.ToString() == "禮包")
            {
                mItemContent[4].eName = CEnum.TagName.SDO_SEX;
                mItemContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[4].oContent = 2;

            }
            else
            {


                mItemContent[4].eName = CEnum.TagName.SDO_SEX;//1是男的，0是女的
                mItemContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[4].oContent = iSex;

            }

            itemResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_ITEMSHOP_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, mItemContent);

            if (itemResult[0, 0].eName != C_Global.CEnum.TagName.ERROR_Msg)
            {
                for (int i = 0; i < itemResult.GetLength(0); i++)
                {

                    if (!cbxItems.Items.Contains("["+itemResult[i, 2].oContent.ToString()+"]" + itemResult[i, 3].oContent.ToString()))
                    {

                        cbxItems.Items.Add("[" + itemResult[i, 2].oContent.ToString() + "]" + itemResult[i, 3].oContent.ToString());
                        cbxItems1.Items.Add("[" + itemResult[i, 2].oContent.ToString() + "]" + itemResult[i, 3].oContent.ToString());
                        cbxItems2.Items.Add("[" + itemResult[i, 2].oContent.ToString() + "]" + itemResult[i, 3].oContent.ToString());
                        cbxItems3.Items.Add("[" + itemResult[i, 2].oContent.ToString() + "]" + itemResult[i, 3].oContent.ToString());
                        cbxItems4.Items.Add("[" + itemResult[i, 2].oContent.ToString() + "]" + itemResult[i, 3].oContent.ToString());
                    }
                    //ssd.Add(itemResult[i, 3].oContent.ToString());
                    //if(ssd[i].Contains(

                    if (!ssd.contains(itemResult[i, 2].oContent.ToString() + itemResult[i, 3].oContent.ToString()))
                    {
                        ssd.Add("[" + itemResult[i, 2].oContent.ToString() + "]" + itemResult[i, 3].oContent.ToString(), itemResult[i, 2].oContent.ToString());
                    

                    }


                }
               // string strcode = table["Rain的发型"].ToString();
                //cbxItems.SelectedIndex = 0;
                //cbxItems1.SelectedIndex = 0;
                //cbxItems2.SelectedIndex = 0;
                //cbxItems3.SelectedIndex = 0;
                //cbxItems4.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_errMsg"));
            }

            
        }


        private int Getitemcode(CEnum.Message_Body[,] val ,string strtxt)
        {

            int _itemCode = 0;

            for (int i = 0; i < val.GetLength(0); i++)
            {
                if (val[i, 3].oContent.ToString().Equals(strtxt))
                {
                    _itemCode = int.Parse(val[i, 2].oContent.ToString());
                }
            }

            return _itemCode;
        }



        private void WriteRate()
        {
            btnEditOk.Enabled = false;
            Cursor = Cursors.AppStarting;
            CEnum.Message_Body[] mItemContent = new CEnum.Message_Body[18];

            //if (_ServerIP == null)
            //{
                for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
                {
                    if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                    {
                        this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                    }
                }
            //}
            if (actionType == ActionType.New)
            {
                mItemContent[0].eName = CEnum.TagName.SDO_ServerIP;
                mItemContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mItemContent[0].oContent = _ServerIP;

                mItemContent[1].eName = CEnum.TagName.SDO_ItemCode1;
                mItemContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[1].oContent = Convert.ToInt32(ssd[cbxItems.Text]);

                mItemContent[2].eName = CEnum.TagName.SDO_DateLimit1;
                mItemContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[2].oContent = int.Parse(txtDatelimit.Text);

                mItemContent[3].eName = CEnum.TagName.SDO_TimeLimit1;
                mItemContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[3].oContent = int.Parse(txtTimes.Text);

                mItemContent[4].eName = CEnum.TagName.SDO_ItemCode2;
                mItemContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[4].oContent = Convert.ToInt32(ssd[cbxItems1.Text]);

                mItemContent[5].eName = CEnum.TagName.SDO_DateLimit2;
                mItemContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[5].oContent = int.Parse(txtDatelimit1.Text);

                mItemContent[6].eName = CEnum.TagName.SDO_TimeLimit2;
                mItemContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[6].oContent = int.Parse(txtTimes1.Text);

                mItemContent[7].eName = CEnum.TagName.SDO_ItemCode3;
                mItemContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[7].oContent = Convert.ToInt32(ssd[cbxItems2.Text]);

                mItemContent[8].eName = CEnum.TagName.SDO_DateLimit3;
                mItemContent[8].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[8].oContent = int.Parse(txtDatelimit2.Text);

                mItemContent[9].eName = CEnum.TagName.SDO_TimeLimit3;
                mItemContent[9].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[9].oContent = int.Parse(txtTimes2.Text);

                mItemContent[10].eName = CEnum.TagName.SDO_ItemCode4;
                mItemContent[10].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[10].oContent = Convert.ToInt32(ssd[cbxItems3.Text]);

                mItemContent[11].eName = CEnum.TagName.SDO_DateLimit4;
                mItemContent[11].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[11].oContent = int.Parse(txtDatelimit3.Text);

                mItemContent[12].eName = CEnum.TagName.SDO_TimeLimit4;
                mItemContent[12].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[12].oContent = int.Parse(txtTimes3.Text);

                mItemContent[13].eName = CEnum.TagName.SDO_ItemCode5;
                mItemContent[13].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[13].oContent = Convert.ToInt32(ssd[cbxItems4.Text]);

                mItemContent[14].eName = CEnum.TagName.SDO_DateLimit5;
                mItemContent[14].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[14].oContent = int.Parse(txtDatelimit4.Text);

                mItemContent[15].eName = CEnum.TagName.SDO_TimeLimit5;
                mItemContent[15].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[15].oContent = int.Parse(txtTimes4.Text);

                mItemContent[16].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                mItemContent[16].eName = C_Global.CEnum.TagName.UserByID;
                mItemContent[16].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mItemContent[17].eName = CEnum.TagName.SDO_ItemCode;
                mItemContent[17].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[17].oContent = 0;

            }
            else
            {
                mItemContent[0].eName = CEnum.TagName.SDO_ServerIP;
                mItemContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mItemContent[0].oContent = _ServerIP;

                mItemContent[1].eName = CEnum.TagName.SDO_ItemCode1;
                mItemContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[1].oContent = Convert.ToInt32(cbxItems.Tag);

                mItemContent[2].eName = CEnum.TagName.SDO_DateLimit1;
                mItemContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[2].oContent = int.Parse(txtDatelimit.Text);

                mItemContent[3].eName = CEnum.TagName.SDO_TimeLimit1;
                mItemContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[3].oContent = int.Parse(txtTimes.Text);

                mItemContent[4].eName = CEnum.TagName.SDO_ItemCode2;
                mItemContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[4].oContent = Convert.ToInt32(cbxItems1.Tag);

                mItemContent[5].eName = CEnum.TagName.SDO_DateLimit2;
                mItemContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[5].oContent = int.Parse(txtDatelimit1.Text);

                mItemContent[6].eName = CEnum.TagName.SDO_TimeLimit2;
                mItemContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[6].oContent = int.Parse(txtTimes1.Text);

                mItemContent[7].eName = CEnum.TagName.SDO_ItemCode3;
                mItemContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[7].oContent = Convert.ToInt32(cbxItems2.Tag);

                mItemContent[8].eName = CEnum.TagName.SDO_DateLimit3;
                mItemContent[8].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[8].oContent = int.Parse(txtDatelimit2.Text);

                mItemContent[9].eName = CEnum.TagName.SDO_TimeLimit3;
                mItemContent[9].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[9].oContent = int.Parse(txtTimes2.Text);

                mItemContent[10].eName = CEnum.TagName.SDO_ItemCode4;
                mItemContent[10].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[10].oContent = Convert.ToInt32(cbxItems3.Tag);

                mItemContent[11].eName = CEnum.TagName.SDO_DateLimit4;
                mItemContent[11].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[11].oContent = int.Parse(txtDatelimit3.Text);

                mItemContent[12].eName = CEnum.TagName.SDO_TimeLimit4;
                mItemContent[12].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[12].oContent = int.Parse(txtTimes3.Text);

                mItemContent[13].eName = CEnum.TagName.SDO_ItemCode5;
                mItemContent[13].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[13].oContent = Convert.ToInt32(cbxItems4.Tag);

                mItemContent[14].eName = CEnum.TagName.SDO_DateLimit5;
                mItemContent[14].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[14].oContent = int.Parse(txtDatelimit4.Text);

                mItemContent[15].eName = CEnum.TagName.SDO_TimeLimit5;
                mItemContent[15].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[15].oContent = int.Parse(txtTimes4.Text);

                mItemContent[16].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                mItemContent[16].eName = C_Global.CEnum.TagName.UserByID;
                mItemContent[16].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mItemContent[17].eName = CEnum.TagName.SDO_ItemCode;
                mItemContent[17].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[17].oContent = Convert.ToInt32(Myitemcode);
            }

            //this.backgroundWorkerAdd.RunWorkerAsync(mItemContent);

            if (actionType == ActionType.New)
            {
                actionResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_StageAward_Create, C_Global.CEnum.Msg_Category.SDO_ADMIN, mItemContent);

            }
            else
            {
                actionResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_StageAward_Update, C_Global.CEnum.Msg_Category.SDO_ADMIN, mItemContent);
            }
            //检测状态
            if (actionResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            {
                this.btnEditOk.Enabled = true;
                MessageBox.Show(actionResult[0, 0].oContent.ToString());
                return;
            }

            if (actionResult[0, 0].oContent.ToString().Equals("FAILURE"))
            {
                this.btnEditOk.Enabled = true;
                MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_MsgcheckF"));
                return;
            }

            if (actionResult[0, 0].oContent.ToString().Equals("SUCESS"))
            {
                this.btnEditOk.Enabled = true;
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

                this.backgroundWorkerDel.RunWorkerAsync(messageBody);
                
                //delResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SDO_MEDALITEM_DELETE, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);

                ////检测状态



                //if (delResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(delResult[0, 0].oContent.ToString());
                //    return;
                //}

                //if (delResult[0, 0].oContent.ToString().Equals("FAILURE"))
                //{
                //    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_MsgdelF"));
                //    return;
                //}

                //if (delResult[0, 0].oContent.ToString().Equals("SUCESS"))
                //{

                //    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_MsgdelS"));
                //    ReadInfos();
                //}

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
            cbxBClass.Items.Add(config.ReadConfigValue("MSDO", "IC_Code_comItem"));
            cbxBClass.Items.Add(config.ReadConfigValue("MSDO", "IC_Code_comItem1"));
            cbxBClass.Items.Add(config.ReadConfigValue("MSDO", "IC_Code_comItem2"));
            //cbxBClass.Items.Add("套装");
            //btnAdd.Enabled = false;
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
            rbtSexBoy.Checked = true;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.toolStrip1.Enabled = false;
            this.Cursor = Cursors.AppStarting;

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
                MessageBox.Show("請選擇伺服器");
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
            cbxItems1.Enabled = true;
            cbxItems2.Enabled = true;
            cbxItems3.Enabled = true;
            cbxItems4.Enabled = true;

            cbxItems.Items.Clear();
            cbxItems1.Items.Clear();
            cbxItems2.Items.Clear();
            cbxItems3.Items.Clear();
            cbxItems4.Items.Clear();

            cbxItems.Text = "";
            cbxItems1.Text = "";
            cbxItems2.Text = "";
            cbxItems3.Text = "";
            cbxItems4.Text = "";

            txtTimes.Value = 0;
            txtTimes1.Value = 0;
            txtTimes2.Value = 0;
            txtTimes3.Value = 0;
            txtTimes4.Value = 0;

            txtDatelimit.Value = 0;
            txtDatelimit1.Value = 0;
            txtDatelimit2.Value = 0;
            txtDatelimit3.Value = 0;
            txtDatelimit4.Value = 0;
            //txtDays.Text = "";
            //txtTimes.Text = "";
            //txtRate.Text = "";


        }

        private void btnEdit_Click(object sender, EventArgs e)
        {



            //if (selectRow == -1)
            //{
            //    MessageBox.Show(config.ReadConfigValue("MSDO", "FYI_Code_MSG1"));
            //    return;
            //}
            //else
            //{
            //    dpEditContainer.Visible = true;
            //    cbxBClass.Enabled = true;
            //    cbxSClass.Enabled = true;
            //    //rbtSexBoy.Enabled = true;
            //    //rbtSexGirl.Enabled = true;
            //    actionType = ActionType.Modi;
            //    cbxItems.SelectedIndex = cbxItems.Items.IndexOf(((DataTable)dgInfoList.DataSource).Rows[selectRow][1].ToString());
            //    numericLevel.Value = decimal.Parse(((DataTable)dgInfoList.DataSource).Rows[selectRow][2].ToString());
            //    numericLevPerc.Value = decimal.Parse(((DataTable)dgInfoList.DataSource).Rows[selectRow][3].ToString());
            //    numericPerc.Value = decimal.Parse(((DataTable)dgInfoList.DataSource).Rows[selectRow][4].ToString());
            //    numericTimes.Value = decimal.Parse(((DataTable)dgInfoList.DataSource).Rows[selectRow][5].ToString());
            //    numericDays.Value = decimal.Parse(((DataTable)dgInfoList.DataSource).Rows[selectRow][6].ToString());
            //}
            try
            {
                if (selectRow == -1)
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "FYI_Code_MSG1"));
                    return;
                }
                else
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
                    cbxItems1.Enabled = false;
                    cbxItems2.Enabled = false;
                    cbxItems3.Enabled = false;
                    cbxItems4.Enabled = false;

                    cbxItems.Items.Clear();
                    Myitemcode = ((DataTable)dgInfoList.DataSource).Rows[selectRow][0].ToString();
                    cbxItems.Tag = ((DataTable)dgInfoList.DataSource).Rows[selectRow][1].ToString();
                    cbxItems.Text = ((DataTable)dgInfoList.DataSource).Rows[selectRow][2].ToString();
                    txtTimes.Value = decimal.Parse(((DataTable)dgInfoList.DataSource).Rows[selectRow][3].ToString());
                    txtDatelimit.Value = decimal.Parse(((DataTable)dgInfoList.DataSource).Rows[selectRow][4].ToString());

                    cbxItems1.Tag = ((DataTable)dgInfoList.DataSource).Rows[selectRow][5].ToString();
                    cbxItems1.Text = ((DataTable)dgInfoList.DataSource).Rows[selectRow][6].ToString();
                    txtTimes1.Value = decimal.Parse(((DataTable)dgInfoList.DataSource).Rows[selectRow][7].ToString());
                    txtDatelimit1.Value = decimal.Parse(((DataTable)dgInfoList.DataSource).Rows[selectRow][8].ToString());


                    cbxItems2.Tag = ((DataTable)dgInfoList.DataSource).Rows[selectRow][9].ToString();
                    cbxItems2.Text = ((DataTable)dgInfoList.DataSource).Rows[selectRow][10].ToString();
                    txtTimes2.Value = decimal.Parse(((DataTable)dgInfoList.DataSource).Rows[selectRow][11].ToString());
                    txtDatelimit2.Value = decimal.Parse(((DataTable)dgInfoList.DataSource).Rows[selectRow][12].ToString());

                    cbxItems3.Tag = ((DataTable)dgInfoList.DataSource).Rows[selectRow][13].ToString();
                    cbxItems3.Text = ((DataTable)dgInfoList.DataSource).Rows[selectRow][14].ToString();
                    txtTimes3.Value = decimal.Parse(((DataTable)dgInfoList.DataSource).Rows[selectRow][15].ToString());
                    txtDatelimit3.Value = decimal.Parse(((DataTable)dgInfoList.DataSource).Rows[selectRow][16].ToString());

                    cbxItems4.Tag = ((DataTable)dgInfoList.DataSource).Rows[selectRow][17].ToString();
                    cbxItems4.Text = ((DataTable)dgInfoList.DataSource).Rows[selectRow][18].ToString();
                    txtTimes4.Value = decimal.Parse(((DataTable)dgInfoList.DataSource).Rows[selectRow][19].ToString());
                    txtDatelimit4.Value = decimal.Parse(((DataTable)dgInfoList.DataSource).Rows[selectRow][20].ToString());


                    //cbxItems.SelectedIndex = 0;
                }
            }
            catch { }

           // txtRate.Text = accountResult[selectRow, 2].oContent.ToString();
            //txtTimes.Text = accountResult[selectRow, 3].oContent.ToString();
            //txtRate.Text = accountResult[selectRow, 2].oContent.ToString();
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msginfo"), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.OK)
                {
                    this.toolStrip1.Enabled = false;
                    this.Cursor = Cursors.AppStarting;
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
            //if(cbxBClass.Text=="套装")
            //{
            //    cbxSClass.Enabled = true;
            
            //    iType = 2;
            //    cbxSClass.Items.AddRange(new object[] { "套装","礼包" });
           
            //}
            if (cbxBClass.Text == "服裝")
            {


                if (iSex == 1)
                    cbxSClass.Items.AddRange(new object[] { config.ReadConfigValue("MSDO", "RE_Code_head"), config.ReadConfigValue("MSDO", "RE_Code_hair"), config.ReadConfigValue("MSDO", "RE_Code_body"), config.ReadConfigValue("MSDO", "RE_Code_leg"), config.ReadConfigValue("MSDO", "RE_Code_hand"), config.ReadConfigValue("MSDO", "RE_Code_feet"), config.ReadConfigValue("MSDO", "RE_Code_face"), config.ReadConfigValue("MSDO", "RE_Code_glass") });
                else
                    cbxSClass.Items.AddRange(new object[] { config.ReadConfigValue("MSDO", "RE_Code_head"), config.ReadConfigValue("MSDO", "RE_Code_hair"), config.ReadConfigValue("MSDO", "RE_Code_body"), config.ReadConfigValue("MSDO", "RE_Code_leg"), config.ReadConfigValue("MSDO", "RE_Code_hand"), config.ReadConfigValue("MSDO", "RE_Code_feet"), config.ReadConfigValue("MSDO", "RE_Code_face"), config.ReadConfigValue("MSDO", "RE_Code_glass")});
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
            //else if (cbxSClass.Text.Trim() == "明星臉")
            //{
            //    iSort = 51;
            //}
            //else if (cbxSClass.Text.Trim() == "面具")
            //{
            //    iSort = 57;
            //}
            //else if (cbxSClass.Text.Trim() == "翅膀")
            //{
            //    iSort = 8;
            //}
            //else if (cbxSClass.Text.Trim() == "項鏈")
            //{
            //    iSort = 9;

            //}

            if (iSex == 0)
            {
                iSort = iSort + 100;
            }

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

                    //    cbxSClass.Items.AddRange(new object[] { "头", "头发", "身体", "腿", "手", "脚", "表情"});
                //else
                    //    cbxSClass.Items.AddRange(new object[] { "头", "头发", "身体", "腿", "手", "脚", "表情", "连衣裙"});

                    cbxSClass.Items.AddRange(new object[] { config.ReadConfigValue("MSDO", "RE_Code_head"), config.ReadConfigValue("MSDO", "RE_Code_hair"), config.ReadConfigValue("MSDO", "RE_Code_body"), config.ReadConfigValue("MSDO", "RE_Code_leg"), config.ReadConfigValue("MSDO", "RE_Code_hand"), config.ReadConfigValue("MSDO", "RE_Code_feet"), config.ReadConfigValue("MSDO", "RE_Code_face"), config.ReadConfigValue("MSDO", "RE_Code_glass")});
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

                    //    cbxSClass.Items.AddRange(new object[] { "头", "头发", "身体", "腿", "手", "脚", "表情"});
                    //else
                    //    cbxSClass.Items.AddRange(new object[] { "头", "头发", "身体", "腿", "手", "脚", "表情", "连衣裙"});
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

                if (cbxItems1.Text == null || cbxItems1.Text == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msgchitem"));
                    cbxItems1.Focus();
                    return;
                }

                if (cbxItems2.Text == null || cbxItems2.Text == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msgchitem"));
                    cbxItems2.Focus();
                    return;
                }

                if (cbxItems3.Text == null || cbxItems3.Text == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msgchitem"));
                    cbxItems3.Focus();
                    return;
                }

                if (cbxItems4.Text == null || cbxItems4.Text == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msgchitem"));
                    cbxItems4.Focus();
                    return;
                }

                if (txtTimes.Text == null || txtTimes.Text == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msglimit"));
                    return;
                }
                if (txtTimes1.Text == null || txtTimes1.Text == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msglimit"));
                    return;
                }
                if (txtTimes2.Text == null || txtTimes2.Text == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msglimit"));
                    return;
                }
                if (txtTimes3.Text == null || txtTimes3.Text == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msglimit"));
                    return;
                }
                if (txtTimes4.Text == null || txtTimes4.Text == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msglimit"));
                    return;
                }

                if (txtDatelimit.Text == null || txtDatelimit.Text == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msglimit"));
                    return;
                }

                if (txtDatelimit1.Text == null || txtDatelimit.Text == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msglimit"));

                    return;
                }

                if (txtDatelimit2.Text == null || txtDatelimit2.Text == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msglimit"));

                    return;
                }

                if (txtDatelimit3.Text == null || txtDatelimit3.Text == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msglimit"));

                    return;
                }

                if (txtDatelimit4.Text == null || txtDatelimit4.Text == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msglimit"));

                    return;
                }
                
            }

            //if (txtRate.Text == null || txtRate.Text == "")
            //{
            //    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msgrate"));
            //    txtRate.Focus();
            //    return;
            //}


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
            //string txt = txtRate.Text.Trim();
            //Regex rx = new Regex(@"[^\d]");
            //txtRate.Text = rx.Replace(txt, "");
        }

        private void txtRate_KeyUp(object sender, KeyEventArgs e)
        {
            //string txt = txtRate.Text.Trim();
            //Regex rx = new Regex(@"[^\d]");
            //txtRate.Text = rx.Replace(txt, "");
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
            //string txt = txtDays.Text.Trim();
            //Regex rx = new Regex(@"[^\d]");
            //txtDays.Text = rx.Replace(txt, "");
        }

        private void txtDays_KeyUp(object sender, KeyEventArgs e)
        {
            //string txt = txtDays.Text.Trim();
            //Regex rx = new Regex(@"[^\d]");
            //txtDays.Text = rx.Replace(txt, "");
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
            //if (txtItemName.Text == null || txtItemName.Text == "")
            //{
            //    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_MsgItemname"));
            //    txtItemName.Focus();
            //    return;
            //}

            //this.toolStrip1.Enabled = false;
            //this.Cursor = Cursors.AppStarting;
            //listType = ListType.itemNameSearch;

            //pageIndex = 1;  //发送给服务器的开始条数



            //pageSize = 20;   //每页显示条数
            //pageCount = 1;  //总页数



            //currPage = 0;   //当前页数

            //isFisrtSearch = true;

            //btnEdit.Enabled = false;
            //btnDel.Enabled = false;
            //btnNextPage.Enabled = false;
            //btnPrevPage.Enabled = false;

            //toolStripLabel1.Enabled = false;
            //toolStripLabel2.Enabled = false;
            //cbxToPageIndex.Enabled = false;

            //cbxToPageIndex.Items.Clear();

            //ReadInfosBySearch();
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

        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
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

            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(serverIPResult, cbxServerIP.Text));
            
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {

                lock (typeof(C_Event.CSocketEvent))
                {
                    //accountResult = tmp_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_StageAward_Query, C_Global.CEnum.Msg_Category.SDO_ADMIN, (CEnum.Message_Body[])e.Argument);

                    accountResult = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_StageAward_Query, (CEnum.Message_Body[])e.Argument);
                }
     
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.toolStrip1.Enabled = true;
            this.Cursor = Cursors.Default;
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

            pageCount = 1; 
            //int.Parse(accountResult[0, 3].oContent.ToString());
            tsLblText.Text = config.ReadConfigValue("MSDO", "RE_Code_MsgPage") + Convert.ToString(currPage + 1) + "/" + pageCount.ToString();

            if (cbxToPageIndex.Items.Count == 0)
            {
                for (int i = 1; i <= pageCount; i++)
                {
                    cbxToPageIndex.Items.Add(i);
                }
                cbxToPageIndex.SelectedIndex = 0;
            }
            this.toolStrip1.Enabled = true;
            this.Cursor = Cursors.Default;
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

        private void backgroundWorkerDel_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                delResult = tmp_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SDO_StageAward_Delete, C_Global.CEnum.Msg_Category.SDO_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerDel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.toolStrip1.Enabled = true;
            this.Cursor = Cursors.Default;
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

        private void backgroundWorkerAdd_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                if (actionType == ActionType.New)
                {
                    actionResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_StageAward_Create, C_Global.CEnum.Msg_Category.SDO_ADMIN, (CEnum.Message_Body[])e.Argument);

                }
                else
                {
                    actionResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_StageAward_Update, C_Global.CEnum.Msg_Category.SDO_ADMIN, (CEnum.Message_Body[])e.Argument);
                }
            }
        }

        private void backgroundWorkerAdd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnEditOk.Enabled = true;
            Cursor = Cursors.Default;
            
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

        private void cbxServerIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(serverIPResult, cbxServerIP.Text));
        }

        private void dpEditContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTimes4_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            //itemEx item1 = new itemEx("2", "已经领取");
            //this.cbxItems.Items.Add(item1);
            //itemEx item=(itemEx)this.cbxItems.SelectedItem;

            cbxItems.Tag = null;

            cbxItems.Tag = Getitemcode(itemResult, cbxItems.Text);
        }

        private void cbxItems1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxItems1.Tag = null;
           
            cbxItems1.Tag = Getitemcode(itemResult, cbxItems1.Text);
        }

        private void cbxItems2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxItems2.Tag = null;
        
            cbxItems2.Tag = Getitemcode(itemResult, cbxItems2.Text);

        }

        private void cbxItems3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxItems3.Tag = null;
           
            cbxItems3.Tag = Getitemcode(itemResult, cbxItems3.Text);
        }

        private void cbxItems4_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxItems4.Tag = null;
         
            cbxItems4.Tag = Getitemcode(itemResult, cbxItems4.Text);
        }

        private void cbxServerIP_Click(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(serverIPResult, cbxServerIP.Text));
        }

        private void txtDatelimit_ValueChanged(object sender, EventArgs e)
        {

        }




    }

    struct itemEx
    {
        public string Tag;
        public string Text;
        public itemEx(string tag, string text)
        {
            this.Tag = tag;
            this.Text = text;
        }
        public override string ToString()
        {
            return this.Text;
        }
    }


}