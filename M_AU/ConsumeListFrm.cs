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
    [C_Global.CModuleAttribute("游戏币消费明细", "Frm_Shop_ConsumeList", "AU Shop管理工具 -- 游戏币消费明细", "AU Group")] 
    public partial class Frm_Shop_ConsumeList : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private int iSort = 0;
        private int iPageCount = 0;
        private bool bFirst = false;
        
        public Frm_Shop_ConsumeList()
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
            Frm_Shop_ConsumeList mModuleFrm = new Frm_Shop_ConsumeList();
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

        private void Frm_Shop_ConsumeList_Load(object sender, EventArgs e)
        {
            CmbSort.SelectedIndex = 0;
            GrdResult.DataSource = null;
            PnlPage.Visible = false;
            LblSum.Text = "";
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            
            if (TxtName.Text.Trim().Length <= 0)
            {
                MessageBox.Show("请输入需要查询的用户名!");
                return;
            }
            GrdResult.DataSource = null;
            PnlPage.Visible = false;
            LblSum.Text = "";
            bFirst = false;

            //获取查询类型

            switch (CmbSort.Text)
            {
                case "金币消费明细":
                    iSort = 1;
                    break;
                case "休闲币消费明细":
                    iSort = 2;
                    break;
                default:
                    iSort = 1;
                    break;
            }
            LblSum.Text = "";
            CmbPage.Items.Clear();

            //构造查询条件
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

            mContent[0].eName = CEnum.TagName.CARD_ActionType;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = iSort;

            mContent[1].eName = CEnum.TagName.CARD_username;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = TxtName.Text;

            mContent[2].eName = CEnum.TagName.Index;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = 1;

            mContent[3].eName = CEnum.TagName.PageSize;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = Operation_Card.iPageSize;

            CEnum.Message_Body[,] mResult = Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USERCONSUME_QUERY, mContent);

            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            Operation_Card.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);

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
            CEnum.Message_Body[,] mResultSum = Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USERCONSUME_SUM_QUERY, mContent);

            if (mResultSum[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            LblSum.Text = "合计：" + mResultSum[0, 0].oContent.ToString();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            CmbSort.SelectedIndex = 0;
            GrdResult.DataSource = null;

            TxtName.Clear();
            CmbPage.Items.Clear();
        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirst)
            {
                if (bFirst)
                {
                    //构造查询条件
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

                    mContent[0].eName = CEnum.TagName.CARD_ActionType;
                    mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[0].oContent = iSort;

                    mContent[1].eName = CEnum.TagName.CARD_username;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = TxtName.Text;

                    mContent[2].eName = CEnum.TagName.Index;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_Card.iPageSize + 1;

                    mContent[3].eName = CEnum.TagName.PageSize;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = Operation_Card.iPageSize;

                    CEnum.Message_Body[,] mResult = Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USERCONSUME_QUERY, mContent);

                    Operation_Card.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);
                }
            }
        }
    }
}