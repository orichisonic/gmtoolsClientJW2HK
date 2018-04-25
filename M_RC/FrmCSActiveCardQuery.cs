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
    /// <summary>
    /// Frm_SDO_Part 的摘要说明。
    /// </summary>
    [C_Global.CModuleAttribute("活動卡資訊查詢", "FrmCSActiveCardQuery", "活動卡資訊查詢", "CS Group")]
    public partial class FrmCSActiveCardQuery : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private CEnum.Message_Body[,] mResult = null;
        private CEnum.Message_Body[,] mItemResult = null;
        private int RolePage = 0;
        private int RoleIndex = 0;
        private int iIndexID = 0;
        private bool RoleFirst = false;
        private int iPageCount = 0;
        private int intMoney;
        private bool bFirst = false;
        private int uid;
        struct itemEx//combobox每个选项tag绑定
        {
            public string Tag;
            public string Text;
            public itemEx(string tag, string text)
            {
                this.Tag = tag;
                this.Text = text;
            }
            public override string ToString()
            {
                return this.Text;
            }
        }
        public FrmCSActiveCardQuery()
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
            FrmCSActiveCardQuery mModuleFrm = new FrmCSActiveCardQuery();
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
            //this.Text = config.ReadConfigValue("MRC", "FRC_CODE_FrmCSActiveCardQuery");
            //this.GrpSearch.Text = config.ReadConfigValue("MRC", "FRC_UI_GrpSearch");
            //LblServer.Text = config.ReadConfigValue("MRC", "FRC_UI_LblServer");
            //LblAccount.Text = config.ReadConfigValue("MRC", "FRC_UI_LblAccount");
            //label1.Text = config.ReadConfigValue("MRC", "FRC_CODE_Series");
            //ChbSearchByAccount.Text = config.ReadConfigValue("MRC", "FRC_CODE_ChbSearchByAccount");
            //ChbSearchbyNick.Text = config.ReadConfigValue("MRC", "FRC_CODE_ChbSearchbyNick");
            //this.BtnSearch.Text = config.ReadConfigValue("MRC", "FRC_UI_BtnSearch");
            //this.button1.Text = config.ReadConfigValue("MRC", "FRC_UI_BtnClose");
          
        }


        #endregion

        #region
        private void FrmCSActiveCardQuery_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            this.ChbSearchByAccount.Checked = true;
            this.TxtAccount.Enabled = true;
            this.TxtNick.Enabled = false;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 1;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_RC");

            this.backgroundWorkerFormLoad.RunWorkerAsync(mContent);

        }
        #endregion

        #region
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (CmbServer.Text == "")
            {
                return;
            }

            TbcResult.SelectedTab = TpgCharacter;

            this.RoleInfoView.DataSource = null;

            if (TxtAccount.Text.Trim().Length > 0 || TxtNick.Text.Length > 0)
            {
                this.BtnSearch.Enabled = false;
                this.TbcResult.Enabled = false;
                this.Cursor = Cursors.AppStarting;
                RoleIndex = 1;
                RoleFirst = false;
                if (this.ChbSearchByAccount.Checked == true)

                    PartInfo();
                else
                    PartInfo2();
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "CI_Code_inPutAccont"));
            }
        }
        #endregion

        #region
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    

        private void PartInfo2()
        {
            this.RoleInfoView.DataSource = null;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];

            mContent[0].eName = CEnum.TagName.RayCity_activename;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = this.TxtNick.Text;


            mContent[1].eName = CEnum.TagName.RayCity_ActionType;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent =2;


            this.backgroundWorkerAnotherSearch.RunWorkerAsync(mContent);



        }

        #region
        private void PartInfo()
        {
            this.RoleInfoView.DataSource = null;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];

            mContent[0].eName = CEnum.TagName.RayCity_activename;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = TxtAccount.Text;


            mContent[1].eName = CEnum.TagName.RayCity_ActionType;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = 1;


            this.backgroundWorkerSearch.RunWorkerAsync(mContent);

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
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_RCode.GetItemAddr(mServerInfo, CmbServer.Text));
        }
        #endregion

        #region
        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_RCode.GetItemAddr(mServerInfo, CmbServer.Text));
        }
        #endregion

        #region
        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_RCode.GetResult(tmp_ClientEvent, CEnum.ServiceKey.RayCity_ActiveCard_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            try
            {
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                Operation_RCode.BuildDataTable(tmp_ClientEvent, mResult, this.RoleInfoView, out RolePage);



            }
            catch
            {

            }
            finally
            {
                this.BtnSearch.Enabled = true;
                this.TbcResult.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

       

        private void RoleInfoView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.TbcResult.SelectedIndex = 1;
        }

      

        private void backgroundWorkerReSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_RCode.GetResult(tmp_ClientEvent, CEnum.ServiceKey.CS_Accountbyid_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }


                Operation_RCode.BuildDataTable(tmp_ClientEvent, mResult, this.RoleInfoView, out RolePage);

            }
            catch
            {

            }
            finally
            {
                this.BtnSearch.Enabled = true;
                this.TbcResult.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void ChbSearchByAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ChbSearchByAccount.Checked == true)
            {
                this.ChbSearchbyNick.Checked = false;
                this.TxtAccount.Text = "";
                this.TxtNick.Text = "";
                this.TxtNick.Enabled = false;
                this.TxtAccount.Enabled = true;
            }
            else
            {
                if (this.ChbSearchbyNick.Checked != true)
                {
                    MessageBox.Show("請選擇查詢");
                    this.ChbSearchByAccount.Checked = true;
                    return;
                }
                this.TxtNick.Enabled = true;
                this.TxtAccount.Enabled = true;
            }
        }

        private void ChbSearchbyNick_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ChbSearchbyNick.Checked == true)
            {
                this.ChbSearchByAccount.Checked = false;
                this.TxtAccount.Text = "";
                this.TxtNick.Text = "";
                this.TxtAccount.Enabled = false;
                this.TxtNick.Enabled = true;
            }
            else
            {
                if (this.ChbSearchByAccount.Checked != true)
                {
                    MessageBox.Show("請選擇查詢");
                    this.ChbSearchbyNick.Checked = true;
                    return;
                }
                this.TxtNick.Enabled = true;
                this.TxtAccount.Enabled = true;
            }
        }

      
       


        private void backgroundWorkerAnotherSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_RCode.GetResult(tmp_ClientEvent, CEnum.ServiceKey.RayCity_ActiveCard_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerAnotherSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
             if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }


                Operation_RCode.BuildDataTable(tmp_ClientEvent, mResult, this.RoleInfoView, out RolePage);

            }
            catch
            {

            }
            finally
            {
                this.BtnSearch.Enabled = true;
                this.TbcResult.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

     

    }
}