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
using Language;
namespace M_SDO
{
    [C_Global.CModuleAttribute("公告管理系统", "FrmSdoNotice", "SDO管理工具", "SDO Group")] 

    public partial class FrmSdoNotice : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CEnum.Message_Body[,] mChannelInfo = null;
        private CEnum.Message_Body[,] BroadInfo = null;
        private CEnum.Message_Body[,] mResult = null;
        private CSocketEvent m_ClientEvent = null;
        DataTable dgTable = new DataTable();
        private bool ischeck = false;
        private int iIndexID = 0;
        private int iBoardID = -1;
        public FrmSdoNotice()
        {
            InitializeComponent();
            //DptEnd.Value.AddMinutes(10);
        }
        

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
            this.Text = config.ReadConfigValue("MSDO", "FN_UI_FrmSdoNotice");
            this.label2.Text = config.ReadConfigValue("MSDO", "FN_UI_label2");
            this.button2.Text = config.ReadConfigValue("MSDO", "FN_UI_button2");
            this.btnRecord.Text = config.ReadConfigValue("MSDO", "FN_UI_btnRecord");
            this.label3.Text = config.ReadConfigValue("MSDO", "FN_UI_label3");
            this.label4.Text = config.ReadConfigValue("MSDO", "FN_UI_label4");
            this.label5.Text = config.ReadConfigValue("MSDO", "FN_UI_label5");
            this.label11.Text = config.ReadConfigValue("MSDO", "FN_UI_label11");

            this.label10.Text = config.ReadConfigValue("MSDO", "FN_UI_label10");
            this.label6.Text = config.ReadConfigValue("MSDO", "FN_UI_label6");
            this.btnMod.Text = config.ReadConfigValue("MSDO", "FN_UI_btnMod");
            this.button1.Text = config.ReadConfigValue("MSDO", "FN_UI_button1");
            this.ItmEdit.Text = config.ReadConfigValue("MSDO", "FN_UI_EditRs");



        }
        #endregion
        /// <summary>
        /// 请求频道名称
        /// </summary>
        private void GetChannelList()
        {
            
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 2;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_SDO");

            mChannelInfo = Operation_SDO.GetServerList(this.m_ClientEvent, mContent);

            if (mChannelInfo[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mChannelInfo[0, 0].oContent.ToString());
                return;
            }

            for (int i = 0; i < mChannelInfo.GetLength(0); i++)
            {
                TxtCode.Items.Add(mChannelInfo[i, 1].oContent.ToString());
            }

        }
        /// <summary>
        /// 公告记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecord_Click(object sender, EventArgs e)

        {
            ItmEdit.Enabled = true;
            //ItmDelete.Enabled = false;
            GrdList.DataSource = null;
            CEnum.Message_Body[] mContent = null;
            mResult = null;
            mResult = Operation_SDO.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_BOARDTASK_QUERY, mContent);

            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            GrdList.DataSource = BrowseResultInfo();
            //ItmEdit.Enabled = true;
            //ItmDelete.Enabled = true;
        }
        /// <summary>
        /// 生成公告信息内容
        /// </summary>
        /// <returns>DataTable公告信息内容</returns>
        private DataTable BrowseResultInfo()
        {
            try
            {

                dgTable = new DataTable();
                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "FN_Code_Id"), typeof(string));
                //dgTable.Columns.Add("服务器大区", typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "FN_Code_stime"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "FN_Code_etime"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "FN_Code_inteveal"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "FN_Code_state"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "FN_Code_text"), typeof(string));

                for (int i = 0; i < mResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    //currSelectPSTID = int.Parse(accountResult[i, 2].oContent.ToString());
                    dgRow[config.ReadConfigValue("MSDO", "FN_Code_Id")] = mResult[i, 0].oContent.ToString();
                    //dgRow["服务器大区"] = mResult[i, 1].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSDO", "FN_Code_stime")] = mResult[i, 1].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSDO", "FN_Code_etime")] = mResult[i, 2].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSDO", "FN_Code_inteveal")] = mResult[i, 3].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSDO", "FN_Code_state")] = ReturnStauas(int.Parse(mResult[i, 4].oContent.ToString()));
                    dgRow[config.ReadConfigValue("MSDO", "FN_Code_text")] = mResult[i, 5].oContent.ToString();
                    dgTable.Rows.Add(dgRow);
                }

            }
            catch
            {
            }
            return dgTable;
        }
        /// <summary>
        /// 添加公告信息内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {

            int vailnum = Getcishu();
            if (vailnum <= 0)
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_checktime"));
                return;
            }
            else
            {
                Txtcishu.Text = vailnum.ToString();
            }
            //Txtcishu.Text = Getcishu();
            if(TxtConnet.Text == "" || TxtConnet.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_checktext"));
                return;
            }

            if (TxtCode.CheckedItems.Count <= 0)
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_checkip"));
                return;
            }

            if (MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_msgaddnotice"), config.ReadConfigValue("MSDO", "FN_Code_msgnote"), MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {

                //Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);


                CEnum.Message_Body[] mContent = new CEnum.Message_Body[7];

                mContent[0].eName = CEnum.TagName.SDO_BeginTime;
                mContent[0].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                mContent[0].oContent = Convert.ToDateTime(DptStart.Text);

                mContent[1].eName = CEnum.TagName.SDO_EndTime;
                mContent[1].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                mContent[1].oContent = Convert.ToDateTime(DptEnd.Text);

                mContent[2].eName = CEnum.TagName.SDO_Interval;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = Convert.ToInt32(NumMinnute.Value);

                mContent[3].eName = CEnum.TagName.SDO_TimesLimit;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = Convert.ToInt32(Txtcishu.Text);

                mContent[4].eName = CEnum.TagName.SDO_BoardMessage;
                mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[4].oContent = TxtConnet.Text.Trim();

                mContent[5].eName = CEnum.TagName.SDO_ServerIP;
                mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[5].oContent = ReturnSeverip();

                mContent[6].eName = CEnum.TagName.UserByID;
                mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[6].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());



                CEnum.Message_Body[,] mResult1 = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,ReturnSeverip()), CEnum.ServiceKey.SDO_BOARDTASK_INSERT, mContent);

                if (mResult1[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult1[0, 0].oContent.ToString());
                    return;
                }

                if (mResult1[0, 0].eName == CEnum.TagName.Status && mResult1[0, 0].oContent.Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_addfail"));
                }
                else
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_addsucces"));

                    GrdList.DataSource = null;
                    CEnum.Message_Body[] mContent1 = null;
                    mResult = null;
                    mResult = Operation_SDO.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_BOARDTASK_QUERY, mContent1);

                    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(mResult[0, 0].oContent.ToString());
                        return;
                    }

                    GrdList.DataSource = BrowseResultInfo();
                    Setdefault();

                }


            }
            

        }
        /// <summary>
        /// 恢复默认值
        /// </summary>
        private void Setdefault()
        {   
            DptStart.Value = DateTime.Now;
            DptEnd.Value = DateTime.Now;
            NumMinnute.Value = 10;
            TxtConnet.Clear();
            for (int i = 0; i < TxtCode.Items.Count; i++)
            {
                TxtCode.SetItemChecked(i, false);

            }

        }
        /// <summary>
        /// 返回用","分割的服务器ip字符串
        /// </summary>
        /// <returns>ip字符串</returns>
        private string ReturnSeverip()
        {
            ArrayList ServerNames = new ArrayList();
            ArrayList Serverips = new ArrayList();
            string Strseverip = null;

            for (int i = 0; i < TxtCode.CheckedItems.Count; i++)
            {

                ServerNames.Add(TxtCode.CheckedItems[i].ToString());

            }
            for (int i = 0; i < ServerNames.Count; i++)
            {
                Serverips.Add(Operation_SDO.GetItemAddr(mChannelInfo, ServerNames[i].ToString()));
            }

            for (int i = 0; i < Serverips.Count; i++)
            {
                Strseverip = Serverips[i].ToString() + "," + Strseverip;
            }

            return Strseverip;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int Getcishu()
        {   


                int intcishu = Convert.ToInt32(NumMinnute.Value);

                int noticeMin = Convert.ToInt32((DptEnd.Value - DptStart.Value).TotalMinutes);

                int txtcishu = noticeMin / intcishu;

                return txtcishu;
 


        }
        private void btnrefush_Click(object sender, EventArgs e)
        {

        }

        private void FrmSdoNotice_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            cmbStauas.Items.Add(config.ReadConfigValue("MSDO", "FN_Code_infostate"));
            cmbStauas.Items.Add(config.ReadConfigValue("MSDO", "FN_Code_infostate1"));
            cmbStauas.Items.Add(config.ReadConfigValue("MSDO", "FN_Code_infostate2"));
            GetChannelList();
       
        }

        private void ItmEdit_Click(object sender, EventArgs e)
        {
            try
            {
                btnOk.Enabled = false;
                btnOk.Visible = false;

                btnMod.Enabled = true;
                btnMod.Visible = true;

                label11.Visible = true;
                cmbStauas.Visible = true;
                DataTable mBoard = (DataTable)GrdList.DataSource;


                CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];

                mContent[0].eName = CEnum.TagName.SDO_TaskID;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = iBoardID;

                CEnum.Message_Body[,] mResult1 = Operation_SDO.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_BOARDMESSAGE_REQ, mContent);

                if (mResult1[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_quaryIpfail"));
                    return;
                }

                if (mResult1[0, 0].eName == CEnum.TagName.Status && mResult1[0, 0].oContent.Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_quaryIpfail"));
                    return;
                }
                else
                {
                    string[] arrChannel = mResult1[0, 0].oContent.ToString().Split(',');
                    
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

                if (mBoard.Rows[iIndexID][4].ToString() == config.ReadConfigValue("MSDO", "FN_Code_infostate"))
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_noticefail"));
                    return;
                }
                if (mBoard.Rows[iIndexID][4].ToString() == config.ReadConfigValue("MSDO", "FN_Code_infostate1"))
                {
                    iBoardID = int.Parse(mBoard.Rows[iIndexID][0].ToString());
                    DptStart.Text = mBoard.Rows[iIndexID][1].ToString();
                    DptEnd.Text = mBoard.Rows[iIndexID][2].ToString();

                    NumMinnute.Value = Convert.ToDecimal(mBoard.Rows[iIndexID][3].ToString());
                    cmbStauas.Text = mBoard.Rows[iIndexID][4].ToString();
                    TxtConnet.Text = mBoard.Rows[iIndexID][5].ToString();
                }
                else if (mBoard.Rows[iIndexID][4].ToString() == config.ReadConfigValue("MSDO", "FN_Code_infostate2"))
                {
                    iBoardID = int.Parse(mBoard.Rows[iIndexID][0].ToString());
                    DptStart.Text = mBoard.Rows[iIndexID][1].ToString();
                    DptStart.Enabled = false;
                    DptEnd.Text = mBoard.Rows[iIndexID][2].ToString();
                    DptEnd.Enabled = false;
                    NumMinnute.Value = Convert.ToDecimal(mBoard.Rows[iIndexID][3].ToString());
                    NumMinnute.Enabled = false;
                    cmbStauas.Text = mBoard.Rows[iIndexID][4].ToString();
                    TxtConnet.Text = mBoard.Rows[iIndexID][5].ToString();
                    TxtConnet.Enabled = false;
                }


                
            }
            catch
            { }


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

        private void CheckedTxt(int itemindex)
        {
            for (int i = 0; i < TxtCode.Items.Count; i++)
            {
                TxtCode.SetItemChecked(i, false);

            }

            for (int i = 0; i < TxtCode.Items.Count; i++)
            {

               if (i == itemindex)
                  {
                     TxtCode.SetItemChecked(i, true);
                  }

            }
        }

        private void ItmDelete_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("是否删除公告?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            //{

            //    Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);
            //    DataTable mBoard = (DataTable)GrdList.DataSource;

            //    CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];



            //    mContent[0].eName = CEnum.TagName.SDO_Status;
            //    mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[0].oContent = ReturnStauas(mBoard.Rows[iIndexID][4].ToString().Trim()); ;

            //    mContent[1].eName = CEnum.TagName.UserByID;
            //    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            //    mContent[2].eName = CEnum.TagName.SDO_TaskID;
            //    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[2].oContent = iBoardID;


            //    CEnum.Message_Body[,] mResult1 = Operation_SDO.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_BOARDTASK_UPDATE, mContent);

            //    if (mResult1[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //    {
            //        MessageBox.Show(mResult1[0, 0].oContent.ToString());
            //        return;
            //    }
            //}
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void GrdList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnMod_Click(object sender, EventArgs e)
        {
             int vailnum = Getcishu();
            if (vailnum <= 0)
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_checktime"));
                return;
            }
            else
            {
                Txtcishu.Text = vailnum.ToString();
            }
            //Txtcishu.Text = Getcishu();
            if(TxtConnet.Text == "" || TxtConnet.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_checktext"));
                return;
            }
            if (cmbStauas.Text == "" || cmbStauas.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_checkip"));
                return;
            }

            if (TxtCode.CheckedItems.Count <= 0)
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_msgchoosestate"));
                return;
            }

            if (MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_msgupdatenotice"), config.ReadConfigValue("MSDO", "FN_Code_msgnote"), MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {

                //Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);
                

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

                mContent[0].eName = CEnum.TagName.SDO_BeginTime;
                mContent[0].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                mContent[0].oContent = Convert.ToDateTime(DptStart.Text);

                mContent[1].eName = CEnum.TagName.SDO_EndTime;
                mContent[1].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                mContent[1].oContent = Convert.ToDateTime(DptEnd.Text);

                mContent[2].eName = CEnum.TagName.SDO_Interval;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = Convert.ToInt32(NumMinnute.Value);

                mContent[3].eName = CEnum.TagName.SDO_Status;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = ReturnStauas(cmbStauas.Text.Trim());

                mContent[4].eName = CEnum.TagName.SDO_BoardMessage;
                mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[4].oContent = TxtConnet.Text.Trim();

                mContent[5].eName = CEnum.TagName.SDO_ServerIP;
                mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[5].oContent = ReturnSeverip();

                mContent[6].eName = CEnum.TagName.UserByID;
                mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[6].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent[7].eName = CEnum.TagName.SDO_TaskID;
                mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[7].oContent = iBoardID;


                CEnum.Message_Body[,] mResult1 = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,ReturnSeverip()), CEnum.ServiceKey.SDO_BOARDTASK_UPDATE, mContent);

                if (mResult1[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult1[0, 0].oContent.ToString());
                    return;
                }

                if (mResult1[0, 0].eName == CEnum.TagName.Status && mResult1[0, 0].oContent.Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_addfail"));
                }
                else
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_addsucces"));

                    GrdList.DataSource = null;
                    CEnum.Message_Body[] mContent1 = null;
                    mResult = null;
                    mResult = Operation_SDO.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_BOARDTASK_QUERY, mContent1);

                    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(mResult[0, 0].oContent.ToString());
                        return;
                    }

                    GrdList.DataSource = BrowseResultInfo();
                    Setdefault();

                    btnOk.Enabled = true;
                    btnOk.Visible = true;

                    btnMod.Enabled = false;
                    btnMod.Visible = false;

                    label11.Visible = false;
                    cmbStauas.Visible = false;

                    DptStart.Enabled = true;
                    DptEnd.Enabled = true;
                    TxtConnet.Enabled = true;
                    NumMinnute.Enabled = true;


                }
            }
        }
        private int ReturnStauas(string strStauas)
        {
           int IntStauas = -1;
            if( strStauas == config.ReadConfigValue("MSDO", "FN_Code_infostate1"))
            {
                IntStauas = 0;
            }
            else if(strStauas == config.ReadConfigValue("MSDO", "FN_Code_infostate2"))
            {
                IntStauas = 2;
            }
            else if (strStauas == config.ReadConfigValue("MSDO", "FN_Code_infostate2"))
            {
                IntStauas = 1;
            }

            return IntStauas;
        }

        private string ReturnStauas(int intStauas)
        {
            string Stauas = null;
            switch (intStauas)
            {
                case 0:
                    Stauas = config.ReadConfigValue("MSDO", "FN_Code_infostate1");
                    break;
                case 2 :
                    Stauas = config.ReadConfigValue("MSDO", "FN_Code_infostate2");
                    break;
                case 1:
                    Stauas = config.ReadConfigValue("MSDO", "FN_Code_infostate");
                    break;
            }
            return Stauas;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Setdefault();
            btnOk.Enabled = true;
            btnOk.Visible = true;

            btnMod.Enabled = false;
            btnMod.Visible = false;

            label11.Visible = false;
            cmbStauas.Visible = false;

            DptStart.Enabled = true;
            DptEnd.Enabled = true;
            TxtConnet.Enabled = true;
            NumMinnute.Enabled = true;

        }

        private void GrdList_CellClick_1(object sender, DataGridViewCellEventArgs e)
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
    }
}