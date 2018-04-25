using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Global;
using C_Event;

namespace M_Audition
{
    [C_Global.CModuleAttribute("道具回收兑换记录", "Frm_Shop_Exchange", "AU Shop管理工具 -- 道具回收兑换记录", "AU Group")] 
    public partial class Frm_Shop_Exchange : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private int iPageCount = 0;
        private bool bFirst = false;

        public Frm_Shop_Exchange()
        {
            InitializeComponent();
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
            Frm_Shop_Exchange mModuleFrm = new Frm_Shop_Exchange();
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

        private void ExchangeFrm_Load(object sender, EventArgs e)
        {
            /*
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 1;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_AU");

            mServerInfo = Operation_Shop.GetServerList(this.m_ClientEvent, mContent);

            CmbServer = Operation_Shop.BuildCombox(mServerInfo, CmbServer);
             * */
            CmbServer.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CmbPage.Items.Clear();

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

            mContent[0].eName = CEnum.TagName.AU_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = "61.152.150.205";

            mContent[1].eName = CEnum.TagName.AuShop_userid;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = TxtName.Text;

            mContent[2].eName = CEnum.TagName.AuShop_BeginDate;
            mContent[2].eTag = CEnum.TagFormat.TLV_DATE;
            mContent[2].oContent = DpkStar.Value;

            mContent[3].eName = CEnum.TagName.AuShop_EndDate;
            mContent[3].eTag = CEnum.TagFormat.TLV_DATE;
            mContent[3].oContent = DptStop.Value;

            mContent[4].eName = CEnum.TagName.Index;
            mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[4].oContent = 1;

            mContent[5].eName = CEnum.TagName.PageSize;
            mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[5].oContent = Operation_Shop.iPageSize;

            CEnum.Message_Body[,] mResult = Operation_Shop.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AUSHOP_AVATARECOVER_QUERY, mContent);

            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            Operation_Shop.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);

            if (iPageCount <= 0)
            {
                PnlPage.Visible = false;
                lblPageCount.Text = "1";
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    CmbPage.Items.Add(i + 1);
                }

                lblPageCount.Text = iPageCount.ToString();
                CmbPage.SelectedIndex = 0;
                bFirst = true;
                PnlPage.Visible = true;
            }

            GrdResult.Columns[3].Visible = false;
        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirst)
            {
                lblCurrPage.Text = CmbPage.Text;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.AU_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = "61.152.150.205";

                mContent[1].eName = CEnum.TagName.AuShop_userid;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = TxtName.Text;

                mContent[2].eName = CEnum.TagName.AuShop_BeginDate;
                mContent[2].eTag = CEnum.TagFormat.TLV_DATE;
                mContent[2].oContent = DpkStar.Value;

                mContent[3].eName = CEnum.TagName.AuShop_EndDate;
                mContent[3].eTag = CEnum.TagFormat.TLV_DATE;
                mContent[3].oContent = DptStop.Value;

                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_Card.iPageSize + 1;

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_Card.iPageSize;

                CEnum.Message_Body[,] mResult = Operation_Shop.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AUSHOP_AVATARECOVER_QUERY, mContent);

                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_Shop.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);

                GrdResult.Columns[3].Visible = false;
            }
            else
            {
                lblCurrPage.Text = "1";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            CmbPage.Items.Clear();

            TxtName.Clear();

            CmbServer.SelectedIndex = 0;
        }

        private void GrdResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataTable mTable = (DataTable)GrdResult.DataSource;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];

                mContent[0].eName = CEnum.TagName.AU_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = "61.152.150.205";

                mContent[1].eName = CEnum.TagName.AuShop_orderid;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = mTable.Rows[e.RowIndex][3].ToString();

                CEnum.Message_Body[,] mResult = Operation_Shop.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AUSHOP_AVATARECOVER_DETAIL_QUERY, mContent);

                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                ExchangeMoreInfo mInfoFrm = new ExchangeMoreInfo(TxtName.Text, mResult, this.m_ClientEvent);
                mInfoFrm.ShowDialog();
            }
            catch
            { 
            
            }
        }
    }
}