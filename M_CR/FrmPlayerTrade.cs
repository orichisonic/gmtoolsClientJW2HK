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
    /// <summary>
    /// 
    /// </summary>
    [C_Global.CModuleAttribute("玩家消费记录", "FrmPlayerTrade", "疯狂卡丁车--玩家消费记录", "CR Group")]
    public partial class FrmPlayerTrade : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private int iPageCount = 0;
        private bool bFirst = false;
        public FrmPlayerTrade()
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

        private void BtnSearch_Click(object sender, EventArgs e)
        {
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
                mContent[1].oContent = Operation_Kart.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[2].eName = CEnum.TagName.SDO_MoneyType;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;

                if (CmbType.Text == "M币")
                    mContent[2].oContent = 1;
                else if (CmbType.Text == "G币")
                    mContent[2].oContent = 0;
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
                mContent[6].oContent = Operation_Kart.iPageSize;

                CEnum.Message_Body[,] mResult = Operation_Kart.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_CONSUME_QUERY, mContent);

                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_Kart.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);

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
                mContent[1].oContent = Operation_Kart.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[2].eName = CEnum.TagName.SDO_MoneyType;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;

                if (CmbType.Text == "M币")
                    mContent[2].oContent = 1;
                else if (CmbType.Text == "G币")
                    mContent[2].oContent = 0;
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

                mResult = Operation_Kart.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_USERCONSUMESUM_QUERY, mContent);

               LblTotal.Text = "合计：" + mResult[0, 0].oContent.ToString();
            }
            else
            {
                MessageBox.Show("请输入玩家帐号！");
            }
        }

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
                mContent[1].oContent = Operation_Kart.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[2].eName = CEnum.TagName.SDO_MoneyType;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;

                if (CmbType.Text == "M币")
                    mContent[2].oContent = 1;
                else if (CmbType.Text == "G币")
                    mContent[2].oContent = 0;
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
                mContent[5].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_Kart.iPageSize + 1; ;

                mContent[6].eName = CEnum.TagName.PageSize;
                mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[6].oContent = Operation_Kart.iPageSize;

                CEnum.Message_Body[,] mResult = Operation_Kart.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_CONSUME_QUERY, mContent);

                Operation_Kart.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);
            }
        }

        private void BtnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPlayerTrade_Load(object sender, EventArgs e)
        {
            //服务器列表
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 3;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_SDO");

            mServerInfo = Operation_Kart.GetServerList(this.m_ClientEvent, mContent);

            CmbServer = Operation_Kart.BuildCombox(mServerInfo, CmbServer);

            //货币类型
            CmbType.Items.Add("M币");
            CmbType.Items.Add("G币");
            CmbType.Items.Add("所有类型");

            CmbType.SelectedIndex = 0;

            PnlPage.Visible = false;
            LblTotal.Text = "";
        }


    }
}