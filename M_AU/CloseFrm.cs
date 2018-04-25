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
    /// <summary>
    /// Frm_SDO_Part 的摘要说明。
    /// </summary>
    [C_Global.CModuleAttribute("帐号解/封停", "Frm_AU_Close", "AU管理工具 -- 帐号解/封停", "AU Group")]
    public partial class Frm_AU_Close : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private int iUserID = 0;
        private string strUserNick = null;

        private int iPageCount = 0;
        private bool bFirst = false;

        public Frm_AU_Close()
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
            Frm_AU_Close mModuleFrm = new Frm_AU_Close();
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

        private void Frm_SDO_Close_Load(object sender, EventArgs e)
        {
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 2;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_AU");

            mServerInfo = Operation_Audition.GetServerList(this.m_ClientEvent, mContent);

            CmbServer = Operation_Audition.BuildCombox(mServerInfo, CmbServer);

            LblUser.Text = "";
            PnlInput.Visible = true;
            GrdList.DataSource = null;
            PnlPage.Visible = false;
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            LblUser.Text = "";
            PnlInput.Visible = true;
            GrdList.DataSource = null;

            CmbPage.Items.Clear();
            TbcResult.SelectedTab = TpgList;

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

            mContent[0].eName = CEnum.TagName.AU_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[1].eName = CEnum.TagName.Index;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = 1;

            mContent[2].eName = CEnum.TagName.PageSize;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = Operation_Audition.iPageSize;

            CEnum.Message_Body[,] mGetResult = Operation_Audition.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AU_ACCOUNTREMOTE_QUERY, mContent);

            //无内容显示
            if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mGetResult[0, 0].oContent.ToString());
                return;
            }

            Operation_Audition.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);

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
            //return;
            
            DataTable mTable = (DataTable)GrdList.DataSource;

            try
            {
                //iUserID = int.Parse(mTable.Rows[e.RowIndex][0].ToString());
                strUserNick = mTable.Rows[e.RowIndex][0].ToString();
                LblUser.Text = "准备解封的帐号为：" + strUserNick;
                TxtNick.Text = strUserNick;
                TbcResult.SelectedTab = TpgClose;

                CEnum.Message_Body[] mMemo = new CEnum.Message_Body[3];

                mMemo[0].eName = CEnum.TagName.AU_ServerIP;
                mMemo[0].eTag = CEnum.TagFormat.TLV_STRING;
                mMemo[0].oContent = Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text);

                mMemo[1].eName = CEnum.TagName.AU_ACCOUNT;
                mMemo[1].eTag = CEnum.TagFormat.TLV_STRING;
                mMemo[1].oContent = strUserNick;

                mMemo[2].eName = CEnum.TagName.UserByID;
                mMemo[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mMemo[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                CEnum.Message_Body[,] mGetResult = Operation_Audition.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AU_ACCOUNTLOCAL_QUERY, mMemo);

                if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    TxtMemo.Text = mGetResult[0, 0].oContent.ToString();
                    label2.Text = "不详";
                }
                else
                {
                    label2.Text = mGetResult[0, 4].oContent.ToString();
                    TxtMemo.Text = mGetResult[0, 3].oContent.ToString();
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
            strUserNick = TxtNick.Text.Trim();
            if (strUserNick != null)
            {
                if (MessageBox.Show("解封帐号", "确认将该用户解封吗？", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CEnum.Message_Body[,] mResult = null;

                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];
                    mContent[0].eName = CEnum.TagName.AU_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.AU_ACCOUNT;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = strUserNick;

                    mContent[2].eName = CEnum.TagName.UserByID;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    mContent[3].eName = CEnum.TagName.AU_Reason;
                    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[3].oContent = TxtContent.Text;

                    mResult = Operation_Audition.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AU_ACCOUNT_QUERY, mContent);

                    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(mResult[0, 0].oContent.ToString());
                        return;
                    }

                    if (mResult[0, 0].eName == CEnum.TagName.Status)
                    {
                        MessageBox.Show(mResult[0, 0].oContent.ToString());
                        return;
                    }

                    mContent = new CEnum.Message_Body[5];
                    mContent[0].eName = CEnum.TagName.AU_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.AU_UserNick;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = mResult[0, 2].oContent.ToString();

                    mContent[2].eName = CEnum.TagName.UserByID;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    mContent[3].eName = CEnum.TagName.AU_Reason;
                    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[3].oContent = TxtContent.Text;

                    mContent[4].eName = CEnum.TagName.AU_ACCOUNT;
                    mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[4].oContent = strUserNick;

                    mResult = Operation_Audition.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AU_ACCOUNT_BANISHMENT_QUERY, mContent);

                    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(mResult[0, 0].oContent.ToString());
                        return;
                    }

                    if (mResult[0, 0].eName == CEnum.TagName.AU_STOPSTATUS && mResult[0, 0].oContent.ToString() == "1")
                    {

                        mResult = Operation_Audition.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AU_ACCOUNT_OPEN, mContent);

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
                            GrdList.DataSource = null;
                            MessageBox.Show("操作成功，该帐号已经成功被解封！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("该玩家没有处于停封状态，解封失败！");
                    }

                    PnlInput.Visible = false;

                    mContent = new CEnum.Message_Body[3];

                    mContent[0].eName = CEnum.TagName.AU_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.Index;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = 1;

                    mContent[2].eName = CEnum.TagName.PageSize;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = Operation_Audition.iPageSize;

                    CEnum.Message_Body[,] mGetResult = Operation_Audition.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AU_ACCOUNTREMOTE_QUERY, mContent);

                    //无内容显示
                    if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(mGetResult[0, 0].oContent.ToString());
                        return;
                    }

                    Operation_Audition.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);

                    TxtAccount.Clear();
                    TxtContent.Clear();
                    TxtMemo.Clear();
                }
            }
            else
            {
                MessageBox.Show("请输入解封原因！");
            }
        }

        private void BtnPost_Click(object sender, EventArgs e)
        {
            if (TxtContent.Text == "" || TxtContent.Text == null)
            {
                MessageBox.Show("请输入封停原因");
                return;
            }
            if (TxtAccount.Text.Trim().Length > 0)
            {
                if (MessageBox.Show("停封帐号", "确认将该用户停封吗？", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CEnum.Message_Body[,] mResult = null;
                    
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];
                    mContent[0].eName = CEnum.TagName.AU_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.AU_ACCOUNT;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = TxtAccount.Text;

                    mContent[2].eName = CEnum.TagName.UserByID;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    mContent[3].eName = CEnum.TagName.AU_Reason;
                    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[3].oContent = TxtContent.Text;

                    mResult = Operation_Audition.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AU_ACCOUNT_QUERY, mContent);

                    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(mResult[0, 0].oContent.ToString());
                        return;
                    }

                    if (mResult[0, 0].eName == CEnum.TagName.Status)
                    {
                        MessageBox.Show(mResult[0, 0].oContent.ToString());
                        return;
                    }

                    mContent = new CEnum.Message_Body[5];
                    mContent[0].eName = CEnum.TagName.AU_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.AU_UserNick;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = mResult[0,2].oContent.ToString();

                    mContent[2].eName = CEnum.TagName.UserByID;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    mContent[3].eName = CEnum.TagName.AU_Reason;
                    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[3].oContent = TxtContent.Text;

                    mContent[4].eName = CEnum.TagName.AU_ACCOUNT;
                    mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[4].oContent = TxtAccount.Text;

                    //有问题
                    mResult = Operation_Audition.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AU_ACCOUNT_BANISHMENT_QUERY, mContent);

                    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(mResult[0, 0].oContent.ToString());
                        return;
                    }

                    if (mResult[0, 0].eName == CEnum.TagName.AU_STOPSTATUS && mResult[0, 0].oContent.ToString() == "0")
                    {
                        mResult = Operation_Audition.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AU_ACCOUNT_CLOSE, mContent);

                        if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                        {
                            //MessageBox.Show("操作失败！");
                            MessageBox.Show(mResult[0, 0].oContent.ToString());
                            return;
                        }
                        if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.Equals("FAILURE"))
                        {
                            MessageBox.Show("封停帐号失败,请稍候尝试！");
                        }
                        else
                        {
                            MessageBox.Show("操作成功，该帐号已经成功被停封！");
                        }

                        TxtAccount.Text = "";
                        TxtContent.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("该帐号已经被停封，不能再次处理！");
                    }

                    mContent = new CEnum.Message_Body[3];

                    mContent[0].eName = CEnum.TagName.AU_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.Index;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = 1;

                    mContent[2].eName = CEnum.TagName.PageSize;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = Operation_Audition.iPageSize;

                    CEnum.Message_Body[,] mGetResult = Operation_Audition.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AU_ACCOUNTREMOTE_QUERY, mContent);

                    //无内容显示
                    if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(mGetResult[0, 0].oContent.ToString());
                        return;
                    }

                    Operation_Audition.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);

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

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtAccount.Text = "";
            TxtContent.Text = "";
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            //TxtMemo.Text = "";
            TxtNick.Clear();
        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirst)
            {
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

                mContent[0].eName = CEnum.TagName.AU_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.Index;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_Audition.iPageSize + 1;

                mContent[2].eName = CEnum.TagName.PageSize;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = Operation_Audition.iPageSize;

                CEnum.Message_Body[,] mGetResult = Operation_Audition.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AU_ACCOUNTREMOTE_QUERY, mContent);

                Operation_Audition.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);
            }
        }
    }
}