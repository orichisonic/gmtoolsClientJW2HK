using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using C_Global;
using C_Event;

using Language;

namespace M_JW2
{
    [C_Global.CModuleAttribute("家族道具信息", "FrmJW2FamilyItemInfo", "家族道具信息", "JW2 Group")]
    public partial class FrmJW2FamilyItemInfo : Form
    {
        #region 变量
        private CSocketEvent m_ClientEvent = null;
        private CEnum.Message_Body[,] mServerInfo = null;
        private int pageSize = 30;   //每页显示条数
        private int pageCount = 1;  //总页数
        private int iPageCount = 0;
        private int currentExp = 0;
        private int currectLevel = 0;
        private int currentSN = 0;
        private int tempi3 = 0;
        private int num = 0;
        private bool bFirst = false;
        private CSocketEvent tmp_ClientEvent = null;
        string _ServerIP = null;    //服务器ip
        string userAccount = null;  //修改的玩家帐号，
        C_Global.CEnum.Message_Body[,] accountResult = null;    //帐号检索结果
        private bool pageRoleView = false;
        private int currDgSelectRow;
        private string FamilyID;
        private bool pageFamilyItem = false;

        #endregion

        public FrmJW2FamilyItemInfo()
        {
            InitializeComponent();
        }

        #region 创建窗体
        /// <summary>
        /// 创建类库中的窗体
        /// </summary>
        /// <param name="oParent">MDI 程序的父窗体</param>
        /// <param name="oSocket">Socket</param>
        /// <returns>类库中的窗体</returns>
        public Form CreateModule(object oParent, object oEvent)
        {
            //创建登录窗体
            FrmJW2FamilyItemInfo mModuleFrm = new FrmJW2FamilyItemInfo();
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
            this.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2FamilyItemInfo");
            this.GrpSearch.Text = config.ReadConfigValue("MSDO", "AF_UI_GrpSearch");
            this.LblServer.Text = config.ReadConfigValue("MSDO", "AF_UI_LblServer");
            this.BtnSearch.Text = config.ReadConfigValue("MSDO", "AF_UI_BtnSearch");

            this.GrpResult.Text = config.ReadConfigValue("MSDO", "AF_UI_GrpResult");

            LblAccount.Text = config.ReadConfigValue("MJW2", "NEW_UI_FamilyName");
            button1.Text = config.ReadConfigValue("MJW2", "NEW_UI_button1");


            this.tpgFamilyInfo.Text = config.ReadConfigValue("MJW2", "NEW_UI_FamilyInfo");


            this.tpgFamilyItemInfo.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2FamilyItemInfo");

            label2.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");

            label1.Text = config.ReadConfigValue("MJW2", "NEW_UI_lblRoleView");
            //this.Text = config.ReadConfigValue("MAU", "FSC_UI_Frm_FrmMarried");
            //this.LblServer.Text = config.ReadConfigValue("MAU", "FSC_UI_LblServer");
            //this.lblAccount.Text = config.ReadConfigValue("MAU", "FSC_UI_LblPlayerAccount");

            //this.btnSearch.Text = config.ReadConfigValue("MAU", "FSC_UI_btnSearch");
            //this.btnClose.Text = config.ReadConfigValue("MAU", "FSC_UI_BtnClose");
            //this.TabMarriageInfo.Text = config.ReadConfigValue("MAU", "FSC_UI_TabMarriageInfo");
            //this.TabMarriageLog.Text = config.ReadConfigValue("MAU", "FSC_UI_TabMarriageLog");


        }


        #endregion



        #region 登陆窗体加载(得到游戏服务器列表)
        private void FrmJW2FamilyItemInfo_Load(object sender, EventArgs e)
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
                mContent[1].oContent = m_ClientEvent.GetInfo("GameID_JW2");
                this.backgroundWorkerFormLoad.RunWorkerAsync(mContent);

            }
            catch
            { }
        }
        #endregion

        #region 窗体服务器列表backgroundWorker消息发送
        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mServerInfo = Operation_JW2.GetServerList(this.m_ClientEvent, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 窗体服务器列表backgroundWorker消息接收
        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbServer = Operation_JW2.BuildCombox(mServerInfo, CmbServer);
        }
        #endregion

        #region 切换游戏服务器
        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text));
        }
        #endregion

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            /*
            * 清除上一次显示的内容
            */
            if (CmbServer.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "LO_Code_Msg1"));
                return;
            }

            BtnSearch.Enabled = false;
            Cursor = Cursors.WaitCursor;
            dataGridView2.DataSource = null;

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

            mContent[0].eName = CEnum.TagName.JW2_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[1].eName = CEnum.TagName.JW2_ServerName;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = CmbServer.Text.ToString();

            mContent[2].eName = CEnum.TagName.JW2_FAMILYNAME;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = this.lblAccountOrNick.Text.ToString();




            mContent[3].eName = CEnum.TagName.Index;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = 1;

            mContent[4].eName = CEnum.TagName.PageSize;
            mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[4].oContent = Operation_JW2.iPageSize;

            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text));

            this.backgroundWorkerSearch.RunWorkerAsync(mContent);
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(tmp_ClientEvent, CEnum.ServiceKey.JW2_FAMILYINFO_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
                Cursor = Cursors.Default;
                int pg = 0;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                else
                {

                    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, dataGridView2, out iPageCount);
                }

                if (iPageCount <= 1)
                {
                    this.pnlRoleView.Visible = false;
                }
                else
                {
                    for (int i = 0; i < iPageCount; i++)
                    {
                        this.cmbRoleView.Items.Add(i + 1);
                    }

                    this.cmbRoleView.SelectedIndex = 0;
                    this.pageRoleView = true;
                    this.pnlRoleView.Visible = true;
                }
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TbcResult_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (dataGridView2.DataSource != null)
                {
                    DataTable mTable = (DataTable)dataGridView2.DataSource;
                    //serverIP = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);
                    FamilyID = mTable.Rows[currDgSelectRow][0].ToString();//保存玩家帐号ID



                }

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];
                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.JW2_ServerName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = CmbServer.Text.ToString();

                mContent[2].eName = CEnum.TagName.JW2_FAMILYID;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = int.Parse(FamilyID);




                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_JW2.iPageSize;

                this.backgroundWorkerFamilyItemInfo.RunWorkerAsync(mContent);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void backgroundWorkerFamilyItemInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(tmp_ClientEvent, CEnum.ServiceKey.JW2_FamilyItemInfo_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerFamilyItemInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
                Cursor = Cursors.Default;
                int pg = 0;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                else
                {

                    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, FamilyItemGridView, out iPageCount);

                    if (iPageCount <= 1)
                    {
                        this.GbPage.Visible = false;
                    }
                    else
                    {
                        for (int i = 0; i < iPageCount; i++)
                        {
                            this.CbPage.Items.Add(i + 1);
                        }

                        this.CbPage.SelectedIndex = 0;
                        this.pageFamilyItem = true;
                        this.GbPage.Visible = true;
                    }
                }
            }
            catch
            {

            }
        }

        private void backgroundWorkerReFamilyItemInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(tmp_ClientEvent, CEnum.ServiceKey.JW2_FamilyItemInfo_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReFamilyItemInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
                Cursor = Cursors.Default;
                int pg = 0;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                else
                {

                    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, FamilyItemGridView, out iPageCount);
                }
            }
            catch
            {

            }
        }

        private void backgroundWorkerReSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_FAMILYINFO_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
                Cursor = Cursors.Default;
                int pg = 0;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                else
                {

                    Operation_JW2.BuildDataTable(this.m_ClientEvent, mResult, dataGridView2, out iPageCount);
                }
            }
            catch
            {

            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.TbcResult.SelectedIndex = 1;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currDgSelectRow = e.RowIndex;
        }

        private void CbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageFamilyItem)
            {
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];
                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.JW2_ServerName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = CmbServer.Text.ToString();

                mContent[2].eName = CEnum.TagName.JW2_FAMILYID;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = int.Parse(FamilyID);




                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = int.Parse(CbPage.Text.ToString());

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_JW2.iPageSize;
                this.backgroundWorkerReFamilyItemInfo.RunWorkerAsync(mContent);
            }

        }

     
    }

}