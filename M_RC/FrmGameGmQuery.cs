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
    [C_Global.CModuleAttribute("公會資?查?", "FrmGameGmQuery", "公會資?查?", "raycity")]
    public partial class FrmGameGmQuery : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CEnum.Message_Body[,] mResult = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private int iPageCount = 0;
        private bool bFirst = false;
        DataTable dgTable = new DataTable();

        public FrmGameGmQuery()
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
            FrmGameGmQuery mModuleFrm = new FrmGameGmQuery();
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
            dgTable = new DataTable();
            dgTable.Columns.Add("跋");
            dgTable.Columns.Add("IndexID");
            dgTable.Columns.Add("眀腹");
        }

        private void IntiUI()
        {
            //this.Text = config.ReadConfigValue("MRC", "FRC_CODE_FrmGameGmQuery");
            //this.GrpSearch.Text = config.ReadConfigValue("MRC", "FRC_CODE_GrpSearch");
            //this.LblServer.Text = config.ReadConfigValue("MRC", "FRC_CODE_LblServerGame");
            //LblPage.Text = config.ReadConfigValue("MRC", "FRC_UI_LblSelectedPage");
            //tabPage1.Text = config.ReadConfigValue("MRC", "FRC_CODE_tabControl1");
            //BtnSearch.Text = config.ReadConfigValue("MRC", "FRC_UI_BtnSearch");
            //BtnClear.Text = config.ReadConfigValue("MRC", "FRC_UI_BtnClear");
        }


        #endregion

        #region
        private void FrmQueryPlayerID_Load(object sender, EventArgs e)
        {
            try
            {
                IntiFontLib();
                CmbServer.SelectedIndex = 0;
                BtnSearch.Enabled = false;
                PnlPage.Visible = false;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
                mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = 1;

        
                mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = m_ClientEvent.GetInfo("GameID_RC");

                lock (typeof(C_Event.CSocketEvent))
                {
                    mServerInfo = Operation_RCode.GetServerList(this.m_ClientEvent, mContent);
                }
                BtnSearch.Enabled = true;
            }
            catch
            {
            }
        }
        #endregion

        #region
        private void BtnSearch_Click(object sender, EventArgs e)
        {


            this.RoleInfoView.DataSource = null;
            this.CmbPage.Items.Clear();
            this.BtnSearch.Enabled = false;

            PartInfo();
            

        }
        private void PartInfo()
        {
            #region 查询
            dgTable.Clear();
            for (int i = 0; i <= mServerInfo.GetLength(0); i++)
            {

                try
                {
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                    mContent[0].eName = CEnum.TagName.RayCity_NyUserID;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = "";

                    mContent[1].eName = CEnum.TagName.RayCity_ServerIP;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = mServerInfo[i, 0].oContent.ToString();

                    mContent[2].eName = CEnum.TagName.RayCity_AccountState;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = 255;


                    mContent[3].eName = CEnum.TagName.Index;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = 1;

                    mContent[4].eName = CEnum.TagName.PageSize;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = 100;

                    lock (typeof(C_Event.CSocketEvent))
                    {
                        mResult = Operation_RCode.GetResult(m_ClientEvent, CEnum.ServiceKey.RayCity_GMUser_Query, mContent);

                    }

                    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        //RoleInfoView.DataSource = dgTable;
                        //MessageBox.Show(mResult[0, 0].oContent.ToString());
                        //return;
                    }
                    else
                    {
                        for (int k = 0; k < mResult.GetLength(0); k++)
                        {
                            DataRow dgRow = dgTable.NewRow();
                            dgRow["跋"] = mServerInfo[i, 1].oContent.ToString();
                            dgRow["IndexID"] = mResult[k, 0].oContent.ToString();
                            dgRow["眀腹"] = mResult[k, 1].oContent.ToString();

                            dgTable.Rows.Add(dgRow);
                        }
                        this.BtnSearch.Enabled = true;
                    }
                }
                catch
                { }


            }

            RoleInfoView.DataSource = dgTable;
            #endregion
        }
        #endregion
       
        #region
        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region
        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }
        #endregion

        #region
        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //CmbServer = Operation_RCode.BuildCombox(mServerInfo, CmbServer);
           // BtnSearch.Enabled = true;
        }
        #endregion

        #region
        private void backgroundWorkerSerch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_RCode.GetResult(m_ClientEvent, CEnum.ServiceKey.RayCity_Guild_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
        private void backgroundWorkerSerch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.BtnSearch.Enabled = true;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            Operation_RCode.BuildDataTable(this.m_ClientEvent, mResult, RoleInfoView, out iPageCount);

            if (iPageCount <= 1)
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
        #endregion

        #region
        private void RoleInfoView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            //if (e.RowIndex >= 0 && RoleInfoView.DataSource != null)
            //{
            //    using (DataTable dt = (DataTable)RoleInfoView.DataSource)
            //    {

            //      CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

            //        mContent[0].eName = CEnum.TagName.RayCity_GuildIDX;
            //        mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            //        mContent[0].oContent = int.Parse(dt.Rows[e.RowIndex][0].ToString());

            //        mContent[1].eName = CEnum.TagName.RayCity_ServerIP;
            //        mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            //        mContent[1].oContent = Operation_RCode.GetItemAddr(mServerInfo, CmbServer.Text);

            //        mContent[2].eName = CEnum.TagName.UserByID;
            //        mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            //        mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());


            //        CEnum.Message_Body[,] result = Operation_RCode.GetResult(tmp_ClientEvent, CEnum.ServiceKey.RayCity_GuildMember_Query, mContent);

            //        if (result[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //        {
            //            MessageBox.Show(result[0, 0].oContent.ToString());
            //            return;
            //        }
            //        else
            //        {
            //            Operation_RCode.BuildDataTable(this.m_ClientEvent, result, dataGridView1, out iPageCount);
            //            tabControl1.SelectedIndex = 1;
            //        }
            //    }
            //}
            //else
            //{
            //    return;
            //}
        }
        #endregion

        #region
        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (bFirst)
            //{
            //    CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

            //    mContent[0].eName = CEnum.TagName.RayCity_CharacterID;
            //    mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[0].oContent = 0;

            //    mContent[1].eName = CEnum.TagName.RayCity_ServerIP;
            //    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[1].oContent = Operation_RCode.GetItemAddr(mServerInfo, CmbServer.Text);

            //    mContent[2].eName = CEnum.TagName.UserByID;
            //    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            //    mContent[3].eName = CEnum.TagName.RayCity_GuildName;
            //    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[3].oContent =this.txtGuildName.Text.ToString();

            //    mContent[4].eName = CEnum.TagName.Index;
            //    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[4].oContent = int.Parse(CmbPage.Text);

            //    mContent[5].eName = CEnum.TagName.PageSize;
            //    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[5].oContent = Operation_RCode.iPageSize;
               

            //    CEnum.Message_Body[,] result = Operation_RCode.GetResult(tmp_ClientEvent, CEnum.ServiceKey.RayCity_Guild_Query, mContent);

            //    if (result[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //    {
            //        MessageBox.Show(result[0, 0].oContent.ToString());
            //        return;
            //    }
            //    else
            //    {
            //        Operation_RCode.BuildDataTable(this.m_ClientEvent, result, RoleInfoView, out iPageCount);
            //    }
            //}
        }
        #endregion

        #region
        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_RCode.GetItemAddr(mServerInfo, CmbServer.Text));
        }
        #endregion

        private void chbRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chbRefresh.Checked)
            {
                this.timer1.Enabled = true;

            }
            else
            {
                this.timer1.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.RoleInfoView.DataSource = null;
            this.CmbPage.Items.Clear();
            this.BtnSearch.Enabled = false;

            PartInfo();
        }
    }
}