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
    /// Frm_SDO_Part 的摘要说明。
    /// </summary>
    [C_Global.CModuleAttribute("帐号解/封停", "FrmPlayerBan", "疯狂卡丁车 -- 帐号解/封停", "CR Group")]        
    public partial class FrmPlayerBan : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private int iUserID = 0;
        private string strUserNick = null;

        private int iPageCount = 0;
        private bool bFirst = false;

        public FrmPlayerBan()
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

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            LblUser.Text = "";
            PnlInput.Visible = true;
            GrdList.DataSource = null;

            CmbPage.Items.Clear();
            TbcResult.SelectedTab = TpgList;

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

            mContent[0].eName = CEnum.TagName.SDO_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_Kart.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[1].eName = CEnum.TagName.Index;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = 1;

            mContent[2].eName = CEnum.TagName.PageSize;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = Operation_Kart.iPageSize;

            CEnum.Message_Body[,] mGetResult = Operation_Kart.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_MEMBERBANISHMENT_QUERY, mContent);

            //无内容显示
            if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mGetResult[0, 0].oContent.ToString());
                return;
            }

            Operation_Kart.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);

            if (iPageCount <= 0)
            {
                PnlPage.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    CmbPage.Items.Add(i+1);
                }

                CmbPage.SelectedIndex = 0;
                bFirst = true;
                PnlPage.Visible = true;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GrdList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable mTable = (DataTable)GrdList.DataSource;

            try
            {
                iUserID = int.Parse(mTable.Rows[e.RowIndex][0].ToString());
                strUserNick = mTable.Rows[e.RowIndex][1].ToString();
                LblUser.Text = "准备封停的帐号为：" + strUserNick;
                TxtNick.Text = strUserNick;
                TbcResult.SelectedTab = TpgClose;

                CEnum.Message_Body[] mMemo = new CEnum.Message_Body[2];

                mMemo[0].eName = CEnum.TagName.SDO_ServerIP;
                mMemo[0].eTag = CEnum.TagFormat.TLV_STRING;
                mMemo[0].oContent = Operation_Kart.GetItemAddr(mServerInfo, CmbServer.Text);

                mMemo[1].eName = CEnum.TagName.SDO_Account;
                mMemo[1].eTag = CEnum.TagFormat.TLV_STRING;
                mMemo[1].oContent = strUserNick;

                CEnum.Message_Body[,] mGetResult = Operation_Kart.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_MEMBERLOCAL_BANISHMENT, mMemo);

                if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    TxtMemo.Text = mGetResult[0, 0].oContent.ToString();
                }
                else
                {
                    TxtMemo.Text = mGetResult[0, 2].oContent.ToString();
                }


                if (strUserNick != null)
                {
                    PnlInput.Visible = true;
                }
            }
            catch
            {
                MessageBox.Show("请重新选择一个用户！");
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnPost_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {

        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            //TxtMemo.Text = "";
           
        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirst)
            {
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

                mContent[0].eName = CEnum.TagName.SDO_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_Kart.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.Index;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_Kart.iPageSize + 1;

                mContent[2].eName = CEnum.TagName.PageSize;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = Operation_Kart.iPageSize;

                CEnum.Message_Body[,] mGetResult = Operation_Kart.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_MEMBERBANISHMENT_QUERY, mContent);

                Operation_Kart.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);
            }
        }

        private void FrmPlayerBan_Load(object sender, EventArgs e)
        {
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 1;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_SDO");

            mServerInfo = Operation_Kart.GetServerList(this.m_ClientEvent, mContent);

            CmbServer = Operation_Kart.BuildCombox(mServerInfo, CmbServer);

            LblUser.Text = "";
            PnlInput.Visible = true;
            GrdList.DataSource = null;
            PnlPage.Visible = false;
        }

        private void BtnSave_Click_1(object sender, EventArgs e)
        {
            strUserNick = TxtNick.Text.Trim();
            if (strUserNick != null && strUserNick != "")
            {
                if (MessageBox.Show("解封帐号", "确认将该用户解封吗？", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];
                    mContent[0].eName = CEnum.TagName.SDO_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_Kart.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.SDO_Account;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = strUserNick;

                    mContent[2].eName = CEnum.TagName.UserByID;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    CEnum.Message_Body[,] mResult = Operation_Kart.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_ACCOUNT_OPEN, mContent);

                    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(mResult[0, 0].oContent.ToString());
                        return;
                    }

                    if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.Equals("FAILURE"))
                    {
                        MessageBox.Show("操作失败！");
                    }
                    else
                    {
                        MessageBox.Show("操作成功，该帐号已经成功被解封！");
                    }

                    PnlInput.Visible = false;

                    mContent = new CEnum.Message_Body[3];

                    mContent[0].eName = CEnum.TagName.SDO_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_Kart.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.Index;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = 1;

                    mContent[2].eName = CEnum.TagName.PageSize;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = Operation_Kart.iPageSize;

                    CEnum.Message_Body[,] mGetResult = Operation_Kart.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_MEMBERBANISHMENT_QUERY, mContent);

                    //无内容显示
                    if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(mGetResult[0, 0].oContent.ToString());
                        return;
                    }

                    Operation_Kart.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);

                    TxtAccount.Clear();
                    TxtContent.Clear();
                    TxtMemo.Clear();
                }
            }
            else
            {
                MessageBox.Show("请输入帐号名称！");
            }
        }

        private void BtnReset_Click_1(object sender, EventArgs e)
        {
            TxtNick.Clear();
        }

        private void BtnPost_Click_1(object sender, EventArgs e)
        {
            if (TxtAccount.Text.Trim().Length > 0)
            {
                if (MessageBox.Show("确认将服务器" + CmbServer.Text + "中的帐号" + TxtAccount.Text + "停封吗？", "停封帐号", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CEnum.Message_Body[,] mResult = null;

                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];
                    mContent[0].eName = CEnum.TagName.SDO_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_Kart.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.SDO_Account;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = TxtAccount.Text;

                    mContent[2].eName = CEnum.TagName.UserByID;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    mContent[3].eName = CEnum.TagName.SDO_REASON;
                    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[3].oContent = TxtContent.Text;

                    mResult = Operation_Kart.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_MEMBERSTOPSTATUS_QUERY, mContent);

                    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        //MessageBox.Show("操作失败！");
                        MessageBox.Show(mResult[0, 0].oContent.ToString());
                        return;
                    }

                    if (mResult[0, 0].eName == CEnum.TagName.SDO_StopStatus && mResult[0, 0].oContent.ToString() == "0")
                    {
                        mResult = Operation_Kart.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_ACCOUNT_CLOSE, mContent);

                        if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                        {
                            //MessageBox.Show("操作失败！");
                            MessageBox.Show(mResult[0, 0].oContent.ToString());
                            return;
                        }

                        if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.Equals("FAILURE"))
                        //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                        {
                            MessageBox.Show("操作失败！");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("操作成功，该帐号已经成功被停封！");

                            TxtAccount.Text = "";
                            TxtContent.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("该帐号已经被停封，不能再次处理！");
                    }

                    mContent = new CEnum.Message_Body[3];

                    mContent[0].eName = CEnum.TagName.SDO_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_Kart.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.Index;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = 1;

                    mContent[2].eName = CEnum.TagName.PageSize;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = Operation_Kart.iPageSize;

                    CEnum.Message_Body[,] mGetResult = Operation_Kart.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_MEMBERBANISHMENT_QUERY, mContent);

                    //无内容显示
                    if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(mGetResult[0, 0].oContent.ToString());
                        return;
                    }

                    Operation_Kart.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);

                    TxtAccount.Clear();
                    TxtContent.Clear();
                    TxtMemo.Clear();
                }
            }
            else
            {
                MessageBox.Show("请输入帐号!");
            }
        }

        private void BtnClear_Click_1(object sender, EventArgs e)
        {
            TxtAccount.Text = "";
            TxtContent.Text = "";
        }
    }
}