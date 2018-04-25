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

namespace M_CR
{
    /// <summary>
    /// Frm_SDO_Part 的摘要说明。
    /// </summary>
    [C_Global.CModuleAttribute("公告管理系统", "Frm_Kart_Board", "Kart管理工具 -- 公告管理系统", "Kart Group")]     
    public partial class Frm_Kart_Board : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CEnum.Message_Body[,] mChannelInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private int iIndexID = 0;
        private int iPageCount = 0;
        private bool bFirst = false;
        private int iBoardID = -1;
        private int iOperation = -1;
        private bool ischeck = false;
        public Frm_Kart_Board()
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
            Frm_Kart_Board mModuleFrm = new Frm_Kart_Board();
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

        private void Frm_Kart_Board_Load(object sender, EventArgs e)
        {
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 2;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_CR");

            mServerInfo = Operation_Kart.GetServerList(this.m_ClientEvent, mContent);

            CmbServer = Operation_Kart.BuildCombox(mServerInfo, CmbServer);

            PnlPage.Visible = false;
            iOperation = 1;

            TxtCode.Items.Clear();
        }

        private void ItmEdit_Click(object sender, EventArgs e)
        {
            TxtCode.Items.Clear();

            //for (int i = 1; i < 21; i++)
            //{
            //    TxtCode.Items.Add(i.ToString());
            //}            
            for (int i = 0; i < mChannelInfo.GetLength(0); i++)
            {
                TxtCode.Items.Add(mChannelInfo[i, 0].oContent.ToString());
            }
            try
            {
                DataTable mBoard = (DataTable)GrdList.DataSource;

                if (mBoard.Rows[iIndexID][11].ToString() == "1")
                {
                    MessageBox.Show("该公告已经生效，不能进行更改！");
                    return;
                }

                iBoardID = int.Parse(mBoard.Rows[iIndexID][0].ToString());
                TxtContent.Text = mBoard.Rows[iIndexID][1].ToString();
                TxtColor.Text = mBoard.Rows[iIndexID][2].ToString() + mBoard.Rows[iIndexID][3].ToString() + mBoard.Rows[iIndexID][4].ToString();
                TxtIID.Text = mBoard.Rows[iIndexID][5].ToString();
                TxtIID.Enabled = false;
                if (mBoard.Rows[iIndexID][6].ToString() == "0")
                {
                    ChkPlay.Checked = false;
                }
                else
                {
                    ChkPlay.Checked = true;
                }
                DptStart.Value = Convert.ToDateTime(mBoard.Rows[iIndexID][7].ToString());
                DptStop.Value = Convert.ToDateTime(mBoard.Rows[iIndexID][8].ToString());
                TxtSpeed.Text = mBoard.Rows[iIndexID][9].ToString();
                if (mBoard.Rows[iIndexID][10].ToString() == "0")
                {
                    ChkStatus.Checked = false;
                }
                else
                {
                    ChkStatus.Checked = true;
                }
                //TxtCode.Text = mBoard.Rows[iIndexID][8].ToString();

                GrpInput.Visible = true;
                button1.Text = "更  新";
                iOperation = 2;
            }
            catch
            {
                MessageBox.Show("请选择一条真实的纪录!");
            }
        }

        private void ItmDelete_Click(object sender, EventArgs e)
        {
            if (iBoardID == -1)
            {
                MessageBox.Show("请选择一条记录！");
                return;
            }

            C_Global.CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

            mContent[0].eName = CEnum.TagName.CR_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_Kart.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[1].eName = CEnum.TagName.UserByID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            mContent[2].eName = CEnum.TagName.CR_BoardID;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = iBoardID;

            CEnum.Message_Body[,] mResult = Operation_Kart.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CR_CALLBOARD_DELETE, mContent);

            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.Equals("FAILURE"))
            {
                MessageBox.Show("公告删除失败,请稍候再试！");
            }
            else
            {
                MessageBox.Show("公告删除成功！");

                GetGridContent();
            }
        }

        private void ItmAdd_Click(object sender, EventArgs e)
        {
            iOperation = 1;
            GrpInput.Visible = true;

            TxtIID.Enabled = true;

            TxtCode.Items.Clear();

            GetChannelList();

            button1.Text = "发　布";

            //DptStart.Value = Convert.ToDateTime(DateTime.Now.Date.ToString() + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + Convert.ToString(DateTime.Now.Second + 30));
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            GrpInput.Visible = false;
            GetGridContent();

            /*
            if (TxtID.Text.Trim().Length <= 0 || TxtName.Text.Trim().Length <= 0)
            {
                
            }
            else
            {
                MessageBox.Show("请输入发布人ID或姓名!");
            }
             * */
        }

        private void button1_Click(object sender, EventArgs e)
        {          
            CEnum.Message_Body[] mContent;

            if (iOperation == 1)
            {
                mContent = new CEnum.Message_Body[14];
            }
            else if (iOperation == 2)
            {     
                mContent = new CEnum.Message_Body[15];
            }
            else
            {
                MessageBox.Show("请检查您的操作步骤!");
                return;
            }

            if (Operation_Kart.GetItemAddr(mServerInfo, CmbServer.Text) != null)
            {
                mContent[0].eName = CEnum.TagName.CR_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_Kart.GetItemAddr(mServerInfo, CmbServer.Text);
            }
            else
            {
                MessageBox.Show("请先选择一个服务器！");
                return;
            }

            mContent[1].eName = CEnum.TagName.CR_ValidTime;
            mContent[1].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
            mContent[1].oContent = Convert.ToDateTime(DptStart.Text);

            mContent[2].eName = CEnum.TagName.CR_InValidTime;
            mContent[2].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
            mContent[2].oContent = Convert.ToDateTime(DptStop.Text);

            if (TxtColor.Text.Trim().Length <= 0)
            {
                MessageBox.Show("请选择公告的颜色!");
                return;
            }
            mContent[3].eName = CEnum.TagName.CR_BoardColor;
            mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[3].oContent = TxtColor.Text;

            mContent[4].eName = CEnum.TagName.CR_DayLoop;
            mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;

            if (ChkPlay.Checked)
            {
                mContent[4].oContent = 1;
            }
            else
            {
                mContent[4].oContent = 0;
            }

            try
            {
                mContent[5].eName = CEnum.TagName.CR_PublishID;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());
            }
            catch
            {
                MessageBox.Show("请输入发布人ＩＤ，只能为数字！");
                return;
            }

            try
            {
                mContent[6].eName = CEnum.TagName.CR_SPEED;
                mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[6].oContent = int.Parse(TxtSpeed.Text.Trim());
            }
            catch
            {
                MessageBox.Show("请输入播放速度，只能为数字！");
                return;
            }

            try
            {
                mContent[7].eName = CEnum.TagName.CR_Mode;
                mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[7].oContent = int.Parse(TxtCode.Text.Trim());
            }
            catch
            {
                mContent[7].eName = CEnum.TagName.CR_Mode;
                mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[7].oContent = 0;
            }

            try
            {
                mContent[8].eName = CEnum.TagName.CR_BoardContext;
                mContent[8].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[8].oContent = TxtContent.Text.Trim().Substring(0, 75);
            }
            catch
            {
                mContent[8].eName = CEnum.TagName.CR_BoardContext;
                mContent[8].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[8].oContent = TxtContent.Text.Trim();
            }

            try
            {
                mContent[9].eName = CEnum.TagName.CR_BoardContext1;
                mContent[9].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[9].oContent = TxtContent.Text.Trim().Substring(75, 150);
            }
            catch
            {
                try
                {
                    mContent[9].eName = CEnum.TagName.CR_BoardContext1;
                    mContent[9].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[9].oContent = TxtContent.Text.Trim().Substring(75, TxtContent.Text.Trim().Length - 75);
                }
                catch
                {
                    mContent[9].eName = CEnum.TagName.CR_BoardContext1;
                    mContent[9].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[9].oContent = "";
                }
            }

            try
            {
                mContent[10].eName = CEnum.TagName.CR_BoardContext2;
                mContent[10].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[10].oContent = TxtContent.Text.Trim().Substring(150, 220);
            }
            catch
            {
                try
                {
                    mContent[10].eName = CEnum.TagName.CR_BoardContext2;
                    mContent[10].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[10].oContent = TxtContent.Text.Trim().Substring(150, TxtContent.Text.Trim().Length - 220);
                }
                catch
                {
                    mContent[10].eName = CEnum.TagName.CR_BoardContext2;
                    mContent[10].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[10].oContent = "";
                }
            }

            mContent[11].eName = CEnum.TagName.UserByID;
            mContent[11].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[11].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            mContent[12].eName = CEnum.TagName.CR_STATUS;
            mContent[12].eTag = CEnum.TagFormat.TLV_INTEGER;

            if (ChkStatus.Checked)
            {
                mContent[12].oContent = 1;
            }
            else
            {
                mContent[12].oContent = 0;
            }

            if (TxtCode.CheckedItems.Count <= 0)
            {
                MessageBox.Show("请选择要发布的频道!");
                return;
            }

            mContent[13].eName = CEnum.TagName.CR_Channel;
            mContent[13].eTag = CEnum.TagFormat.TLV_STRING;
            for (int i = 0; i < TxtCode.CheckedItems.Count; i++)
            {
                /*
                if (i == TxtCode.CheckedItems.Count || i == 0)
                {
                    mContent[11].oContent = mContent[11].oContent + TxtCode.CheckedItems[i].ToString();
                }
                else
                {
                    mContent[11].oContent = mContent[11].oContent + "," + TxtCode.CheckedItems[i].ToString();
                }GetChannelID
                */
                mContent[13].oContent = TxtCode.CheckedItems[i].ToString() + "," + mContent[13].oContent;
                //mContent[13].oContent = GetChannelID(TxtCode.CheckedItems[i].ToString()) + "," + mContent[13].oContent;
            }

            CEnum.Message_Body[,] mResult = null;
            string strMessageS = string.Empty;
            string strMessageF = string.Empty;

            if (iOperation == 1)
            {
                mResult = Operation_Kart.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CR_CALLBOARD_CREATE, mContent);
                strMessageF = "添加公告失败！";
                strMessageS = "信息添加成功！";
            }
            else if (iOperation == 2)
            {
                mContent[14].eName = CEnum.TagName.CR_BoardID;
                mContent[14].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[14].oContent = iBoardID;
                
                mResult = Operation_Kart.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CR_CALLBOARD_UPDATE, mContent);
                strMessageF = "修改公告失败！";
                strMessageS = "信息修改成功！";
            }
            else
            {
                MessageBox.Show("请检查你的操作步骤！");
                return;
            }

            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            if (mResult[0, 0].oContent.ToString() != "FAILURE" && mResult[0, 0].oContent.ToString() != "SUCESS" || mResult == null)
            {
                MessageBox.Show("添加频道"+mResult[0, 0].oContent.ToString().Remove(0,2)+"失败,请选择公告ID和频道号再次添加");
                label2.Text = "添加频道"+mResult[0,0].oContent.ToString().Remove(0, 2)+"失败";
                string[] arrChannel = mResult[0,0].oContent.ToString().Remove(0, 2).Split(',');
                GetGridContent();
                button4.Visible = true;
                for (int i = 0; i < TxtCode.Items.Count; i++)
                {
                    TxtCode.SetItemChecked(i, false);

                }
                ArrayList arr = new ArrayList();
                arr = ChannelIndex(arrChannel);
                for (int i = 0; i < TxtCode.Items.Count; i++)
                {
                    for (int x = 0; x < arr.Count; x++)
                    {
                        if (i == int.Parse(arr[x].ToString()))
                        {
                            TxtCode.SetItemChecked(i, true);
                        }
                    }
                        
                }
            }
            else
            {
                MessageBox.Show(strMessageS);
                label2.Text = "";
                GetChannelList();

                TxtContent.Clear();
                TxtIID.Clear();
                TxtSpeed.Clear();
                TxtColor.Clear();
                ChkPlay.Checked = false;
                ChkStatus.Checked = false;

                GrpInput.Visible = false;

                GetGridContent();
                button4.Visible = false;
            }
        }
        private ArrayList ChannelIndex(string[] ChannelValue)
        {   
            ArrayList channel = new ArrayList();
            for (int i = 0; i < ChannelValue.Length; i++)
            {
                int chIndex = this.TxtCode.Items.IndexOf(ChannelValue[i]);
                channel.Add(chIndex);
            }

            return channel;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("您确定要保存公告信息吗？", "提示信息：", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
            //{ 
            
            //}
            //请求频道名称
            GetChannelList();

            TxtContent.Clear();
            TxtIID.Clear();
            TxtSpeed.Clear();
            ChkPlay.Checked = false;
            ChkStatus.Checked = false;
            TxtColor.Clear();
            GrpInput.Visible = false;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            TxtID.Clear();
            TxtName.Clear();
            ChkClose.Checked = false;
            ChkOpen.Checked = false;
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            if (DlgColor.ShowDialog() == DialogResult.OK)
            {
                TxtColor.Text = Operation_Kart.ConvertHex(DlgColor.Color.R.ToString()) + Operation_Kart.ConvertHex(DlgColor.Color.G.ToString()) + Operation_Kart.ConvertHex(DlgColor.Color.B.ToString());
            }
        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirst)
            {
                C_Global.CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.CR_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_Kart.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.CR_ValidTime;
                mContent[1].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                mContent[1].oContent = Convert.ToDateTime(DtpDate.Text);

                try
                {
                    mContent[2].eName = CEnum.TagName.CR_PublishID;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = int.Parse(TxtID.Text.Trim());
                }
                catch
                {
                    mContent[2].eName = CEnum.TagName.CR_PublishID;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = 0;
                }

                mContent[3].eName = CEnum.TagName.CR_ACTION;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                if (ChkOpen.Checked && !ChkClose.Checked)
                {
                    mContent[3].oContent = 1;
                }
                else if (!ChkOpen.Checked && ChkClose.Checked)
                {
                    mContent[3].oContent = 0;
                }
                else if (ChkOpen.Checked && ChkClose.Checked)
                {
                    mContent[3].oContent = 2;
                }
                else
                {
                    mContent[3].oContent = 2;
                }

                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_Kart.iPageSize + 1;

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_Kart.iPageSize;

                CEnum.Message_Body[,] mResult = Operation_Kart.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CR_CALLBOARD_QUERY, mContent);

                Operation_Kart.BuildDataTable(this.m_ClientEvent, mResult, GrdList, out iPageCount);

                GrdList.Columns[11].Visible = false;
                GrdList.Columns[2].Visible = false;
                GrdList.Columns[3].Visible = false;
            }
        }

        private void GrdList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                iIndexID = e.RowIndex;
                DataTable mBoardInfo = (DataTable)GrdList.DataSource;

                if (mBoardInfo.Rows.Count > 0)
                {
                    iBoardID = int.Parse(mBoardInfo.Rows[iIndexID][0].ToString());
                } 
            }
            catch
            { }
        }

        private void GetGridContent()
        {
            try
            {
                GrdList.DataSource = null;
                CmbPage.Items.Clear();
                bFirst = false;
                ItmEdit.Enabled = false;
                ItmDelete.Enabled = false;

                C_Global.CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.CR_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_Kart.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.CR_ValidTime;
                mContent[1].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                mContent[1].oContent = Convert.ToDateTime(DtpDate.Text);


                try
                {
                    mContent[2].eName = CEnum.TagName.CR_PublishID;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = int.Parse(TxtID.Text.Trim());
                }
                catch
                {
                    mContent[2].eName = CEnum.TagName.CR_PublishID;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = 0;
                }

                mContent[3].eName = CEnum.TagName.CR_ACTION;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                if (ChkOpen.Checked && !ChkClose.Checked)
                {
                    mContent[3].oContent = 1;
                }
                else if (!ChkOpen.Checked && ChkClose.Checked)
                {
                    mContent[3].oContent = 0;
                }
                else if (ChkOpen.Checked && ChkClose.Checked)
                {
                    mContent[3].oContent = 2;
                }
                else
                {
                    mContent[3].oContent = 2;
                }

                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = 1;

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_Kart.iPageSize;

                CEnum.Message_Body[,] mResult = Operation_Kart.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CR_CALLBOARD_QUERY, mContent);

                if (mResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_Kart.BuildDataTable(this.m_ClientEvent, mResult, GrdList, out iPageCount);

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

                ItmEdit.Enabled = true;
                ItmDelete.Enabled = true;

                GrdList.Columns[10].HeaderText = "发布状态";
                GrdList.Columns[11].Visible = false;
                GrdList.Columns[2].Visible = false;
                GrdList.Columns[3].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChkPlay_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkPlay.Checked)
            {
                DptStart.Enabled = false;
            }
            else
            {
                DptStart.Enabled = true;
            }
        }

        private void GetChannelList()
        {
            //请求频道名称
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];
            mContent[0].eName = CEnum.TagName.CR_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_Kart.GetItemAddr(mServerInfo, CmbServer.Text);

            mChannelInfo = Operation_Kart.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CR_CHANNEL_QUERY, mContent);

            if (mChannelInfo[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mChannelInfo[0, 0].oContent.ToString());
                return;
            }

            for (int i = 0; i < mChannelInfo.GetLength(0); i++)
            {
                TxtCode.Items.Add(mChannelInfo[i,0].oContent.ToString());
            }
        }

        private string GetChannelID(string val)
        {
            string sss = null;
            for (int i = 0; i < mChannelInfo.GetLength(0); i++)
            {
                if (mChannelInfo[i, 0].oContent.ToString().Equals(val))
                {
                    sss = mChannelInfo[i, 0].oContent.ToString();
                }
            }
            return sss;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (ischeck == true)
            {
                for (int i = 0; i < TxtCode.Items.Count; i++)
                {
                    TxtCode.SetItemChecked(i, false);

                }
                ischeck = false;
            }
            else if (ischeck == false)
            {
                for (int i = 0; i < TxtCode.Items.Count; i++)
                {
                    TxtCode.SetItemChecked(i, true);
                }
                ischeck = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (iBoardID == -1)
            {
                MessageBox.Show("请选择一条记录！");
                return;
            }

            C_Global.CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

            mContent[0].eName = CEnum.TagName.CR_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_Kart.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[1].eName = CEnum.TagName.UserByID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            mContent[2].eName = CEnum.TagName.CR_BoardID;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = iBoardID;

            mContent[3].eName = CEnum.TagName.CR_Channel;
            mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
            for (int i = 0; i < TxtCode.CheckedItems.Count; i++)
            {
                mContent[3].oContent = TxtCode.CheckedItems[i].ToString() + "," + mContent[3].oContent;
            }
            CEnum.Message_Body[,] mResult = Operation_Kart.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CR_ERRORCHANNEL_QUERY, mContent);

            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            if (mResult[0, 0].oContent.ToString() != "FAILURE" && mResult[0, 0].oContent.ToString() != "SUCESS" || mResult == null)
            {
                MessageBox.Show("添加频道" + mResult[0, 0].oContent.ToString().Remove(0, 2) + "失败,请选择公告ID和频道号再次添加");
                label2.Text = "添加频道" + mResult[0, 0].oContent.ToString().Remove(0, 2) + "失败";
                string[] arrChannel = mResult[0, 0].oContent.ToString().Remove(0, 2).Split(',');
                GetGridContent();
                for (int i = 0; i < TxtCode.Items.Count; i++)
                {
                    TxtCode.SetItemChecked(i, false);

                }
                ArrayList arr = new ArrayList();
                arr = ChannelIndex(arrChannel);
                for (int i = 0; i < TxtCode.Items.Count; i++)
                {
                    for (int x = 0; x < arr.Count; x++)
                    {
                        if (i == int.Parse(arr[x].ToString()))
                        {
                            TxtCode.SetItemChecked(i, true);
                        }
                    }

                }
                button4.Visible = true;
            }
            else
            {
                MessageBox.Show("重置频道信息成功");
                label2.Text = "";
                GetChannelList();

                TxtContent.Clear();
                TxtIID.Clear();
                TxtSpeed.Clear();
                TxtColor.Clear();
                ChkPlay.Checked = false;
                ChkStatus.Checked = false;

                GrpInput.Visible = false;

                GetGridContent();
                button4.Visible = false;
            }
        }
    }
}