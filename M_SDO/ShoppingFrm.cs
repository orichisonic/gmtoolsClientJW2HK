using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using C_Global;
using C_Event;
using Language;
namespace M_SDO
{
    /// <summary>
    /// 
    /// </summary>
    [C_Global.CModuleAttribute("玩家消费信息", "Frm_SDO_Shopping", "SDO管理工具 -- 玩家消费信息", "SDO Group")]
    public partial class Frm_SDO_Shopping : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private int iPageCount = 0;
        private bool bFirst = false;
        private string _ServerIP;

        public Frm_SDO_Shopping()
        {
            InitializeComponent();
            Frm_SDO_Shopping.CheckForIllegalCrossThreadCalls = false;
        }

        #region 自定义调用事件
        /// <summary>
        /// 创建类库中的窗体
        /// </summary>
        /// <param name="oParent">MDI 程序的父窗体</param>
        /// <param name="oSocket">Socket</param>
        /// <returns>类库中的窗体</returns>
        public Form CreateModule(object oParent, object oEvent)
        {
            //创建登录窗体
            Frm_SDO_Shopping mModuleFrm = new Frm_SDO_Shopping();
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

        private void Frm_SDO_Shopping_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            //服务器列表
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 3;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_SDO");

            mServerInfo = Operation_SDO.GetServerList(this.m_ClientEvent, mContent);

            CmbServer = Operation_SDO.BuildCombox(mServerInfo, CmbServer);

            //货币类型
            CmbType.Items.Add(config.ReadConfigValue("MSDO", "SP_Code_Mtype"));
            CmbType.Items.Add(config.ReadConfigValue("MSDO", "SP_Code_Gtype"));
            CmbType.Items.Add(config.ReadConfigValue("MSDO", "SP_Code_Jifen"));
            CmbType.Items.Add(config.ReadConfigValue("MSDO", "SP_Code_Alltype"));

            CmbType.SelectedIndex = 0;

            PnlPage.Visible = false;
            LblTotal.Text = "";
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
            this.Text = config.ReadConfigValue("MSDO", "SP_UI_SdoShopping");
            this.GrpSearch.Text = config.ReadConfigValue("MSDO", "SP_UI_GrpSearch");
            this.LblServer.Text = config.ReadConfigValue("MSDO", "SP_UI_LblServer");
            this.LblAccount.Text = config.ReadConfigValue("MSDO", "SP_UI_LblAccount");
            this.LblDate.Text = config.ReadConfigValue("MSDO", "SP_UI_LblDate");
            this.LblLink.Text = config.ReadConfigValue("MSDO", "SP_UI_LblLink");
            this.LblType.Text = config.ReadConfigValue("MSDO", "SP_UI_LblType");
            this.BtnSearch.Text = config.ReadConfigValue("MSDO", "SP_UI_BtnSearch");
            this.BtnClose.Text = config.ReadConfigValue("MSDO", "SP_UI_BtnClose");
            this.GrpResult.Text = config.ReadConfigValue("MSDO", "SP_UI_GrpResult");
            this.LblPage.Text = config.ReadConfigValue("MSDO", "SP_UI_LblPage");
        }


        #endregion

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //Thread doSearch = new Thread(new ThreadStart(this.search));
            //doSearch.Start();
            GrdResult.DataSource = null;
            CmbPage.Items.Clear();
            LblTotal.Text = "";

            if (TxtAccount.Text.Trim().Length > 0)
            {
                GrdResult.DataSource = null;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[7];

                mContent[0].eName = CEnum.TagName.SDO_Account;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtAccount.Text;

                mContent[1].eName = CEnum.TagName.SDO_ServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);
                this._ServerIP = mContent[1].oContent.ToString();

                mContent[2].eName = CEnum.TagName.SDO_MoneyType;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;

                if (CmbType.Text == config.ReadConfigValue("MSDO", "SP_Code_Mtype"))
                    mContent[2].oContent = 1;
                else if (CmbType.Text == config.ReadConfigValue("MSDO", "SP_Code_Gtype"))
                    mContent[2].oContent = 0;
                else if (CmbType.Text == config.ReadConfigValue("MSDO", "SP_Code_Jifen"))
                    mContent[2].oContent = 4;
                else
                    mContent[2].oContent = 2;

                mContent[3].eName = CEnum.TagName.SDO_BeginTime;
                mContent[3].eTag = CEnum.TagFormat.TLV_DATE;
                mContent[3].oContent = DtpBegin.Value;

                mContent[4].eName = CEnum.TagName.SDO_EndTime;
                mContent[4].eTag = CEnum.TagFormat.TLV_DATE;
                mContent[4].oContent = DtpEnd.Value;

                mContent[5].eName = CEnum.TagName.Index;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = 1;

                mContent[6].eName = CEnum.TagName.PageSize;
                mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[6].oContent = Operation_SDO.iPageSize;

                CEnum.Message_Body[,] mResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_CONSUME_QUERY, mContent);

                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_SDO.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);

                if (iPageCount <= 0)
                {
                    PnlPage.Visible = false;
                }
                else
                {
                    for (int i = 0; i < iPageCount; i++)
                    {
                        CmbPage.Items.Add(i + 1);
                    }

                    CmbPage.SelectedIndex = 0;
                    bFirst = true;
                    PnlPage.Visible = true;
                }

                //合计
                mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.SDO_Account;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtAccount.Text;

                mContent[1].eName = CEnum.TagName.SDO_ServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[2].eName = CEnum.TagName.SDO_MoneyType;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;

                if (CmbType.Text == config.ReadConfigValue("MSDO", "SP_Code_Mtype"))
                    mContent[2].oContent = 1;
                else if (CmbType.Text == config.ReadConfigValue("MSDO", "SP_Code_Gtype"))
                    mContent[2].oContent = 0;
                else if (CmbType.Text == config.ReadConfigValue("MSDO", "SP_Code_Jifen"))
                    mContent[2].oContent = 4;
                else
                    mContent[2].oContent = 2;

                mContent[3].eName = CEnum.TagName.SDO_BeginTime;
                mContent[3].eTag = CEnum.TagFormat.TLV_DATE;
                mContent[3].oContent = DtpBegin.Value;

                mContent[4].eName = CEnum.TagName.SDO_EndTime;
                mContent[4].eTag = CEnum.TagFormat.TLV_DATE;
                mContent[4].oContent = DtpEnd.Value;

                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                mResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_USERCONSUMESUM_QUERY, mContent);

                LblTotal.Text = config.ReadConfigValue("MSDO", "SP_Code_Sum") + mResult[0, 0].oContent.ToString();
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "SP_Code_Msginfo"));
            }
        }



        //private void search()
        //{
        //    GrdResult.DataSource = null;
        //    CmbPage.Items.Clear();
        //    LblTotal.Text = "";


        //    if (TxtAccount.Text.Trim().Length > 0)
        //    {
        //        GrdResult.DataSource = null;

        //        CEnum.Message_Body[] mContent = new CEnum.Message_Body[7];

        //        mContent[0].eName = CEnum.TagName.SDO_Account;
        //        mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
        //        mContent[0].oContent = TxtAccount.Text;

        //        mContent[1].eName = CEnum.TagName.SDO_ServerIP;
        //        mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
        //        mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);
        //        this._ServerIP = mContent[1].oContent.ToString();

        //        mContent[2].eName = CEnum.TagName.SDO_MoneyType;
        //        mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;

        //        if (CmbType.Text == "Ｍ币")
        //            mContent[2].oContent = 1;
        //        else if (CmbType.Text == "Ｇ币")
        //            mContent[2].oContent = 0;
        //        else if (CmbType.Text == "积分")
        //            mContent[2].oContent = 4;
        //        else
        //            mContent[2].oContent = 2;

        //        mContent[3].eName = CEnum.TagName.SDO_BeginTime;
        //        mContent[3].eTag = CEnum.TagFormat.TLV_DATE;
        //        mContent[3].oContent = DtpBegin.Value;

        //        mContent[4].eName = CEnum.TagName.SDO_EndTime;
        //        mContent[4].eTag = CEnum.TagFormat.TLV_DATE;
        //        mContent[4].oContent = DtpEnd.Value;

        //        mContent[5].eName = CEnum.TagName.Index;
        //        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
        //        mContent[5].oContent = 1;

        //        mContent[6].eName = CEnum.TagName.PageSize;
        //        mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
        //        mContent[6].oContent = Operation_SDO.iPageSize;

        //        CEnum.Message_Body[,] mResult = Operation_SDO.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_CONSUME_QUERY, mContent);

        //        if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
        //        {
        //            MessageBox.Show(mResult[0, 0].oContent.ToString());
        //            return;
        //        }

        //        Operation_SDO.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);

        //        if (iPageCount <= 0)
        //        {
        //            PnlPage.Visible = false;
        //        }
        //        else
        //        {
        //            for (int i = 0; i < iPageCount; i++)
        //            {
        //                CmbPage.Items.Add(i + 1);
        //            }

        //            CmbPage.SelectedIndex = 0;
        //            bFirst = true;
        //            PnlPage.Visible = true;
        //        }

        //        //合计
        //        mContent = new CEnum.Message_Body[5];

        //        mContent[0].eName = CEnum.TagName.SDO_Account;
        //        mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
        //        mContent[0].oContent = TxtAccount.Text;

        //        mContent[1].eName = CEnum.TagName.SDO_ServerIP;
        //        mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
        //        mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

        //        mContent[2].eName = CEnum.TagName.SDO_MoneyType;
        //        mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;

        //        if (CmbType.Text == "Ｍ币")
        //            mContent[2].oContent = 1;
        //        else if (CmbType.Text == "Ｇ币")
        //            mContent[2].oContent = 0;
        //        else if (CmbType.Text == "积分")
        //            mContent[2].oContent = 4;
        //        else
        //            mContent[2].oContent = 2;

        //        mContent[3].eName = CEnum.TagName.SDO_BeginTime;
        //        mContent[3].eTag = CEnum.TagFormat.TLV_DATE;
        //        mContent[3].oContent = DtpBegin.Value;

        //        mContent[4].eName = CEnum.TagName.SDO_EndTime;
        //        mContent[4].eTag = CEnum.TagFormat.TLV_DATE;
        //        mContent[4].oContent = DtpEnd.Value;

        //        if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
        //        {
        //            MessageBox.Show(mResult[0, 0].oContent.ToString());
        //            return;
        //        }

        //        mResult = Operation_SDO.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_USERCONSUMESUM_QUERY, mContent);

        //        LblTotal.Text = "合计：" + mResult[0, 0].oContent.ToString();
        //    }
        //    else
        //    {
        //        MessageBox.Show("请输入玩家帐号！");
        //    }
        //}

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirst)
            {
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[7];

                mContent[0].eName = CEnum.TagName.SDO_Account;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtAccount.Text;

                mContent[1].eName = CEnum.TagName.SDO_ServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[2].eName = CEnum.TagName.SDO_MoneyType;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;

                if (CmbType.Text == config.ReadConfigValue("MSDO", "SP_Code_Mtype"))
                    mContent[2].oContent = 1;
                else if (CmbType.Text == config.ReadConfigValue("MSDO", "SP_Code_Gtype"))
                    mContent[2].oContent = 0;
                else if (CmbType.Text == config.ReadConfigValue("MSDO", "SP_Code_Jifen"))
                    mContent[2].oContent = 4;
                else
                    mContent[2].oContent = 2;

                mContent[3].eName = CEnum.TagName.SDO_BeginTime;
                mContent[3].eTag = CEnum.TagFormat.TLV_DATE;
                mContent[3].oContent = DtpBegin.Value;

                mContent[4].eName = CEnum.TagName.SDO_EndTime;
                mContent[4].eTag = CEnum.TagFormat.TLV_DATE;
                mContent[4].oContent = DtpEnd.Value;

                mContent[5].eName = CEnum.TagName.Index;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_SDO.iPageSize + 1; ;

                mContent[6].eName = CEnum.TagName.PageSize;
                mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[6].oContent = Operation_SDO.iPageSize;

                CEnum.Message_Body[,] mResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_CONSUME_QUERY, mContent);

                Operation_SDO.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);
            }
        }

        private void GrpSearch_Enter(object sender, EventArgs e)
        {

        }

        private void GrdResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GrdResult_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int selectRow = e.RowIndex;
                BrowseDaysLimit browseDaysLimit = new BrowseDaysLimit(int.Parse(GrdResult[config.ReadConfigValue("MSDO", "SP_Code_Msginfo1"), e.RowIndex].Value.ToString()), _ServerIP, MousePosition.X, MousePosition.Y);
                browseDaysLimit.CreateModule(null, m_ClientEvent);

            }
            catch
            {
            }
        }






    }
}