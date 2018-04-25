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
namespace M_RC
{
    [C_Global.CModuleAttribute("MCash??查?", "FrmQueryMCashLog", "MCash??查?", "raycity")]
    public partial class FrmQueryMCashLog : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private int iPageCount = 0;
        private string strCharIDX = null;
        private string strCarIDX = null;
        private bool  bFirst = false;


        public FrmQueryMCashLog()
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
            FrmQueryMCashLog mModuleFrm = new FrmQueryMCashLog();
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
            //this.Text = config.ReadConfigValue("MRC", "FRC_CODE_FrmQueryMCashLog");
            //this.GrpSearch.Text = config.ReadConfigValue("MRC", "FRC_UI_GrpSearch");
            //this.LblServer.Text = config.ReadConfigValue("MRC", "FRC_UI_LblServer");
            //this.label2.Text = config.ReadConfigValue("MRC", "FRC_UI_LblAccount");
            //this.label1.Text = config.ReadConfigValue("MRC", "FRC_UI_LbNickName");
            //LblAccount.Text = config.ReadConfigValue("MRC", "FRC_CODE_BEGINTIME");
            //LblNickName.Text = config.ReadConfigValue("MRC", "FRC_CODE_ENDTIME");
            //label4.Text = config.ReadConfigValue("MRC", "FRC_CODE_Tip8");
         

        }


        #endregion

        #region
        private void FrmQueryMailLog_Load(object sender, EventArgs e)
        {
            try
            {
                IntiFontLib();
                PnlPage.Visible = false;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
                mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = 1;

                mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = m_ClientEvent.GetInfo("GameID_RC");

                this.backgroundWorkerFormLoad.RunWorkerAsync(mContent);
            }
            catch
            { }
        }
        #endregion

        #region
        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mServerInfo = Operation_RCode.GetServerList(this.m_ClientEvent, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbServer = Operation_RCode.BuildCombox(mServerInfo, CmbServer);
        }
        #endregion

        #region
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex =0;
            if (TxtAccount.Text.Length > 0 || TxtNick.Text.Length > 0)
            {
                this.BtnSearch.Enabled = false;
                this.RoleInfoView.DataSource = null;
                this.CmbPage.Items.Clear();
                this.comboBox2.Items.Clear();
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.RayCity_NyUserID;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtAccount.Text;

                mContent[1].eName = CEnum.TagName.RayCity_ServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Operation_RCode.GetItemAddr(mServerInfo, CmbServer.Text);


                mContent[2].eName = CEnum.TagName.RayCity_NyNickName;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = TxtNick.Text;


                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_RCode.iPageSize;

                backgroundWorkerSerch.RunWorkerAsync(mContent);
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MRC", "FQP_Code_inputid"));
            }

        }
        #endregion

        #region
        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region
        private void backgroundWorkerSerch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_RCode.GetResult(tmp_ClientEvent, CEnum.ServiceKey.RayCity_BasicAccount_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
        private void backgroundWorkerSerch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnSearch.Enabled = true;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                BtnSearch.Enabled = true;
                return;
            }
            else
            {
                Operation_RCode.BuildDataTable(this.m_ClientEvent, mResult, dataGridView1, out iPageCount);
            }

            if (iPageCount <= 1)
            {
                PnlPage.Visible = false;
                this.label3.Visible = false;
                this.comboBox2.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    comboBox2.Items.Add(i + 1);
                }

                comboBox2.SelectedIndex = 0;
                bFirst = true;
                PnlPage.Visible = true;
                this.label3.Visible =true;
                this.comboBox2.Visible = true;
            }



        }
        #endregion

        #region
        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (bFirst)
                {
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                    mContent[0].eName = CEnum.TagName.RayCity_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_RCode.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.RayCity_BeginDate;
                    mContent[1].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                    mContent[1].oContent = DptStart.Value;

                    mContent[2].eName = CEnum.TagName.RayCity_EndDate;
                    mContent[2].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                    mContent[2].oContent = DptEnd.Value;

                    mContent[3].eName = CEnum.TagName.Index;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(CmbPage.Text);

                    mContent[4].eName = CEnum.TagName.PageSize;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = Operation_RCode.iPageSize;

                    mContent[5].eName = CEnum.TagName.RayCity_CharacterID;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = int.Parse(strCarIDX);

                    CEnum.Message_Body[,] mResult = null;
                    lock (typeof(C_Event.CSocketEvent))
                    {
                        mResult = Operation_RCode.GetResult(tmp_ClientEvent, CEnum.ServiceKey.RayCity_ItemConsume_Query, mContent);
                    }
                                     
                    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(mResult[0, 0].oContent.ToString());

                        return;
                    }
                    else
                    {
                        Operation_RCode.BuildDataTable(this.m_ClientEvent, mResult, RoleInfoView, out iPageCount);

                    }

                }
            }
            catch
            { }
        }
        #endregion

        #region
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CmbPage.Items.Clear();
            this.tabControl1.SelectedIndex = 1;
            if (e.RowIndex >= 0 && dataGridView1.DataSource != null)
            {
                using (DataTable dt = (DataTable)dataGridView1.DataSource)
                {

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];
                mContent[0].eName = CEnum.TagName.RayCity_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_RCode.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.RayCity_BeginDate;
                mContent[1].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                mContent[1].oContent = DptStart.Value;

                mContent[2].eName = CEnum.TagName.RayCity_EndDate;
                mContent[2].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                mContent[2].oContent = DptEnd.Value;

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_RCode.iPageSize;

                mContent[5].eName = CEnum.TagName.RayCity_CharacterID;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = int.Parse(dt.Rows[e.RowIndex][2].ToString());
                strCarIDX = dt.Rows[e.RowIndex][2].ToString();


                CEnum.Message_Body[,] mMailLog = null;
                lock (typeof(C_Event.CSocketEvent))
                {
                    mMailLog = Operation_RCode.GetResult(tmp_ClientEvent, CEnum.ServiceKey.RayCity_ItemConsume_Query, mContent);
                }
              
                    if (mMailLog[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(mMailLog[0, 0].oContent.ToString());

                        return;
                    }
                    else
                    {
                        Operation_RCode.BuildDataTable(this.m_ClientEvent, mMailLog, RoleInfoView, out iPageCount);

                    }

                if (iPageCount <= 1)
                {
                    PnlPage.Visible = false;
                    label3.Visible = false;
                    comboBox2.Visible = false;
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
                    label3.Visible = true;
                    comboBox2.Visible = true;

                }


                 tabControl1.SelectedIndex = 1;
                    


                }
            }
            
            else
            {
                return;
            }
        }
        #endregion

        #region
        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_RCode.GetItemAddr(mServerInfo, CmbServer.Text));
        }
        #endregion

        #region
        private void RoleInfoView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0 && RoleInfoView.DataSource != null)
                {
                 using (DataTable dt = (DataTable)RoleInfoView.DataSource)
                    {
                        CEnum.Message_Body[,] mResult = null;
                        CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
                        mContent[0].eName = CEnum.TagName.RayCity_ServerIP;
                        mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[0].oContent = Operation_RC.GetItemAddr(mServerInfo, CmbServer.Text);

                        mContent[1].eName = CEnum.TagName.RayCity_CashItemLogIDX;
                        mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[1].oContent = int.Parse(dt.Rows[e.RowIndex][0].ToString());


                        CEnum.Message_Body[,] result = Operation_RCode.GetResult(tmp_ClientEvent, CEnum.ServiceKey.RayCity_CashItemDetailLog_Query, mContent);

                        if (result[0, 0].eName == CEnum.TagName.ERROR_Msg)
                        {
                            MessageBox.Show(result[0, 0].oContent.ToString());
                            return;
                        }

                        else
                        {
                            BrowseMusicName browseMusicName = new BrowseMusicName(result, iPageCount, MousePosition.X, MousePosition.Y);
                            browseMusicName.CreateModule(null, m_ClientEvent);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (bFirst)
                {
                    this.CmbPage.Enabled = false;
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];
                    CEnum.Message_Body[,] mResult = null;
                    mContent[0].eName = CEnum.TagName.RayCity_NyUserID;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = TxtAccount.Text;

                    mContent[1].eName = CEnum.TagName.RayCity_ServerIP;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = Operation_RCode.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[2].eName = CEnum.TagName.RayCity_NyNickName;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = TxtNick.Text;

                    mContent[3].eName = CEnum.TagName.Index;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(this.comboBox2.Text.ToString());


                    mContent[4].eName = CEnum.TagName.PageSize;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = Operation_RCode.iPageSize;

                    lock (typeof(C_Event.CSocketEvent))
                    {
                        mResult = Operation_RCode.GetResult(tmp_ClientEvent, CEnum.ServiceKey.RayCity_BasicAccount_Query, mContent);
                    }
                    CmbPage.Enabled = true;

                    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(mResult[0, 0].oContent.ToString());
                        return;
                    }
                    else
                    {
                        Operation_RCode.BuildDataTable(this.m_ClientEvent, mResult, RoleInfoView, out iPageCount);

                    }

                }
            }
            catch
            { }
        }
        #endregion
    }

}