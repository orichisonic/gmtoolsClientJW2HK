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
    [C_Global.CModuleAttribute("玩家交易记录", "FrmPlayerConsume", "疯狂卡丁车--玩家交易记录", "Cr Group")]
       public partial class FrmPlayerConsume : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private int iPageCount = 0;
        private bool bFirst = false;

        public FrmPlayerConsume()
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

            if (TxtSenderAccount.Text.Trim().Length > 0 || TxtReciveAccount.Text.Trim().Length > 0)
            {               
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.SDO_SendUserID;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtReciveAccount.Text;

                mContent[1].eName = CEnum.TagName.SDO_ReceiveNick;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = TxtSenderAccount.Text;

                mContent[2].eName = CEnum.TagName.SDO_ServerIP;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = Operation_Kart.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_Kart.iPageSize;

                CEnum.Message_Body[,] mResult = Operation_Kart.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_ITEMSHOP_TRADE_QUERY, mContent);

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
            }
            else
            {
                MessageBox.Show("请输入要发送口令的帐号!");
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
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.SDO_SendUserID;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtReciveAccount.Text;

                mContent[1].eName = CEnum.TagName.SDO_ReceiveNick;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = TxtSenderAccount.Text;

                mContent[2].eName = CEnum.TagName.SDO_ServerIP;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = Operation_Kart.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_Kart.iPageSize + 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_Kart.iPageSize;

                CEnum.Message_Body[,] mResult = Operation_Kart.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_ITEMSHOP_TRADE_QUERY, mContent);

                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_Kart.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);
            }
        }

           private void FrmPlayerConsume_Load(object sender, EventArgs e)
           {
               CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
               mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
               mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
               mContent[0].oContent = 3;

               mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
               mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
               mContent[1].oContent = m_ClientEvent.GetInfo("GameID_CR");

               mServerInfo = Operation_Kart.GetServerList(this.m_ClientEvent, mContent);

               CmbServer = Operation_Kart.BuildCombox(mServerInfo, CmbServer);

               PnlPage.Visible = false;
           }
    }
}