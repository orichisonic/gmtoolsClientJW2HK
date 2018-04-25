using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Controls.LabelTextBox;
using C_Global;
using C_Event;
using Language;
namespace M_SDO
{
    /// <summary>
    /// Frm_SDO_Part 的摘要说明。
    /// </summary>
    [C_Global.CModuleAttribute("玩家角色信息", "Frm_SDO_Part", "SDO管理工具 -- 玩家角色信息", "SDO Group")]    
    public partial class Frm_SDO_Part : Form
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
        private bool bFirst = false;
        private bool bFirst3 = false;
        public Frm_SDO_Part()
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
            Frm_SDO_Part mModuleFrm = new Frm_SDO_Part();
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
            this.Text = config.ReadConfigValue("MSDO", "CI_UI_Frm_SDO_Part");
            this.GrpSearch.Text = config.ReadConfigValue("MSDO", "CI_UI_GrpSearch");
            this.LblServer.Text = config.ReadConfigValue("MSDO", "CI_UI_LblServer");
            this.LblAccount.Text = config.ReadConfigValue("MSDO", "CI_UI_LblAccount");
            this.label1.Text = config.ReadConfigValue("MSDO", "CI_UI_label1");
            //this.TpgCharacter.Text = config.ReadConfigValue("MSDO", "CI_UI_TpgCharacter");
            //this.TpgItem.Text = config.ReadConfigValue("MSDO", "CI_UI_TpgItem");
            this.BtnSearch.Text = config.ReadConfigValue("MSDO", "CI_UI_BtnSearch");
            this.button1.Text = config.ReadConfigValue("MSDO", "CI_UI_button1");
            //this.LblPage.Text = config.ReadConfigValue("MSDO", "CI_UI_LblPage");
            //this.labelRolePage.Text = config.ReadConfigValue("MSDO", "CI_UI_LblPage");
            //this.textBoxNotice.Text = config.ReadConfigValue("MSDO", "CI_UI_Notice");
        }


        #endregion

        private void Frm_SDO_Part_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            iIndexID = 0;
            PnlPage.Visible = false;
            panelRolePage.Visible = false;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 1;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_SDO");

            this.backgroundWorkerFormLoad.RunWorkerAsync(mContent);

            //mServerInfo = Operation_SDO.GetServerList(this.m_ClientEvent, mContent);

            //CmbServer = Operation_SDO.BuildCombox(mServerInfo, CmbServer);

            //PnlPage.Visible = false;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (CmbServer.Text == ""||this.backgroundWorkerPageChanged.IsBusy)
            {
                return;
            }
            //清除控件
            iIndexID = 0;
            PnlPage.Visible = false;
            this.panelRolePage.Visible = false;
            this.panelRolePage.Enabled = false;
            CmbPage.Items.Clear();
            this.comboBoxRolePage.Items.Clear();
            TbcResult.SelectedTab = TpgCharacter;

            //foreach (Control df in PnlDetail.Controls.Find("LabelTextBox", true))
            //{
            //    df.Dispose();
            //}

            GrdItemResult.DataSource = null;
            this.RoleInfoView.DataSource = null;
            
            if (TxtAccount.Text.Trim().Length > 0 || TxtNick.Text.Length > 0)
            {
                this.BtnSearch.Enabled = false;
                this.TbcResult.Enabled = false;
                this.Cursor = Cursors.AppStarting;
                RoleIndex = 1;
                RoleFirst = false;
                PartDelegat mPartDelegat = new PartDelegat(DelegatInfo);
                mPartDelegat.BeginInvoke(null, null);
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "CI_Code_inPutAccont"));
            }

            //TxtAccount.Clear();
            //TxtNick.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TbcResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            //foreach (Control m in PnlDetail.Controls.Find("LabelTextBox", true))
            //{
            //    ((LabelTextBox)m).ReadOnly = true;
            //    ((LabelTextBox)m).Refresh();
            //}
            try
            {
                this.dataGridView1.DataSource = null;
               // this.dataGridView2.DataSource = null;
                if (this.TbcResult.SelectedIndex == 1)
                {
                    if (iIndexID != 0)
                    {
                        CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];
                        mContent[0].eName = CEnum.TagName.SDO_UserIndexID;
                        mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[0].oContent = iIndexID;

                        mContent[1].eName = CEnum.TagName.SDO_ServerIP;
                        mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                        mContent[2].eName = CEnum.TagName.Index;
                        mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[2].oContent = 1;

                        mContent[3].eName = CEnum.TagName.PageSize;
                        mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[3].oContent = Operation_SDO.iPageSize;

                        this.backgroundWorkerShowItem.RunWorkerAsync(mContent);
                    }
                    else
                    {
                        MessageBox.Show("請選擇一條角色記錄");
                        return;
                    
                    }
                }
                else if (this.TbcResult.SelectedIndex == 2)
                {

                    if (iIndexID != 0)
                    {
                        dataGridView1.DataSource = null;
                        //this.comboBox1.Items.Clear();
                        TbcResult.SelectedTab = this.TpgPet;
                        TbcResult.Enabled = false;
                        this.Cursor = Cursors.WaitCursor;
                        bFirst3 = false;

                        CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];
                        mContent[0].eName = CEnum.TagName.SDO_UserIndexID;
                        mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[0].oContent = iIndexID;

                        mContent[1].eName = CEnum.TagName.SDO_ServerIP;
                        mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                        mContent[2].eName = CEnum.TagName.Index;
                        mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[2].oContent = 1;

                        mContent[3].eName = CEnum.TagName.PageSize;
                        mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[3].oContent = Operation_SDO.iPageSize;

                        this.backgroundWorkerShowPet.RunWorkerAsync(mContent);
                    }
                    else
                    {
                        MessageBox.Show("請選擇一條角色記錄");
                        return;

                    }
                }
                //else if (this.TbcResult.SelectedIndex == 3)
                //{
                //    if (iIndexID != 0)
                //    {
                //        dataGridView1.DataSource = null;
                //        //this.comboBox1.Items.Clear();
                //        //TbcResult.SelectedTab = this.TpgPet;
                //        TbcResult.Enabled = false;
                //        this.Cursor = Cursors.WaitCursor;


                //        CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
                //        mContent[0].eName = CEnum.TagName.SDO_UserIndexID;
                //        mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                //        mContent[0].oContent = iIndexID;

                //        mContent[1].eName = CEnum.TagName.SDO_ServerIP;
                //        mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                //        mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                //        this.backgroundWorkerShowPetDel.RunWorkerAsync(mContent);
                //    }
                //    else
                //    {
                //        MessageBox.Show("请选择某个角色记录");
                //        return;

                //    }
                //}
                else dataGridView1.DataSource = null;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (bFirst)
                {
                    this.Cursor = Cursors.AppStarting;
                    this.CmbPage.Enabled = false;
                    this.GrdItemResult.DataSource = null;
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];
                    mContent[0].eName = CEnum.TagName.SDO_UserIndexID;
                    mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[0].oContent = iIndexID;

                    mContent[1].eName = CEnum.TagName.SDO_ServerIP;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[2].eName = CEnum.TagName.Index;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_SDO.iPageSize + 1;

                    mContent[3].eName = CEnum.TagName.PageSize;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = Operation_SDO.iPageSize;

                    this.backgroundWorkerPageChanged.RunWorkerAsync(mContent);

                    //CEnum.Message_Body[,] mGetResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_ITEMSHOP_BYOWNER_QUERY, mContent);

                    //Operation_SDO.BuildDataTable(this.m_ClientEvent, mGetResult, GrdItemResult, out iPageCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #region 托管代码
        //预备托管
        private delegate void PartDelegat();
        private void DelegatInfo()
        {
            try
            {
                BeginInvoke(new BuildPart(PartInfo));
            }
            catch
            {

            }
        }

        //构建信息
        private delegate void BuildPart();
        private void PartInfo()
        {
            this.RoleInfoView.DataSource = null;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

            mContent[0].eName = CEnum.TagName.SDO_Account;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = TxtAccount.Text;

            mContent[1].eName = CEnum.TagName.SDO_ServerIP;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[2].eName = CEnum.TagName.SDO_NickName;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = TxtNick.Text;

            mContent[3].eName = CEnum.TagName.PageSize;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = Operation_SDO.iPageSize;

            mContent[4].eName = CEnum.TagName.Index;
            mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[4].oContent = RoleIndex;

            ArrayList paramList = new ArrayList();
            paramList.Add(mContent);

            //CEnum.Message_Body[,] mResult = null;
            //mResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_CHARACTERINFO_QUERY, mContent);

            //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mResult[0, 0].oContent.ToString());
            //    return;
            //}

            ////角色信息
            //for (int i = 0; i < mResult.GetLength(1); i++)
            //{
            //    LabelTextBox mDisplay = new LabelTextBox();

            //    mDisplay.Parent = PnlDetail;
            //    mDisplay.Position = C_Controls.LabelTextBox.LabelTextBox.ELABELPOSITION.LEFT;
            //    mDisplay.TextBoxText = null;

            //    if (i % 2 == 0)
            //    {
            //        mDisplay.Top = 20 * i + 11;
            //        mDisplay.Left = 44;
            //    }
            //    else
            //    {
            //        mDisplay.Top = 20 * (i - 1) + 11;
            //        mDisplay.Left = mDisplay.Width + 111;
            //    }

            //    try
            //    {
            //        mDisplay.LabelText = config.ReadConfigValue("GLOBAL", mResult[0, i].eName.ToString()) + ":";
            //            //this.m_ClientEvent.DecodeFieldName(mResult[0, i].eName) + ":";

            //        if (mResult[0, i].eName == CEnum.TagName.SDO_UserIndexID)
            //        {
            //            iIndexID = int.Parse(mResult[0, i].oContent.ToString());
            //        }

            //        mDisplay.TextBoxText = mResult[0, i].oContent.ToString();
            //    }
            //    catch
            //    {
            //        mDisplay.TextBoxText = "";
            //    }

            //    if (mResult[0, i].eName == CEnum.TagName.SDO_SEX)
            //    {
            //        if (mResult[0, i].oContent.Equals("0"))
            //            mDisplay.TextBoxText = config.ReadConfigValue("MSDO", "CI_Code_Sdofsex");
            //        else
            //            mDisplay.TextBoxText = config.ReadConfigValue("MSDO", "CI_Code_Sdomsex");
            //    }
            //}

            //foreach (Control m in PnlDetail.Controls.Find("LabelTextBox", true))
            //{
            //    ((LabelTextBox)m).ReadOnly = true;
            //    ((LabelTextBox)m).Refresh();
            //}

            //PnlDetail.Visible = true;
            //PnlDetail.Refresh();

            //物品信息
            mContent = new CEnum.Message_Body[4];
            mContent[0].eName = CEnum.TagName.SDO_UserIndexID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = iIndexID;

            mContent[1].eName = CEnum.TagName.SDO_ServerIP;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[2].eName = CEnum.TagName.Index;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = 1;

            mContent[3].eName = CEnum.TagName.PageSize;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = Operation_SDO.iPageSize;

            paramList.Add(mContent);
            this.backgroundWorkerSearch.RunWorkerAsync(paramList);

            //CEnum.Message_Body[,] mItemResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_ITEMSHOP_BYOWNER_QUERY, mContent);

            //if (mItemResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    return;
            //}

            //Operation_SDO.BuildDataTable(this.m_ClientEvent, mItemResult, GrdItemResult, out iPageCount);

            //if (iPageCount <= 0)
            //{
            //    PnlPage.Visible = false;
            //}
            //else
            //{
            //    for (int i = 0; i < iPageCount; i++)
            //    {
            //        CmbPage.Items.Add(i + 1);
            //    }

            //    CmbPage.SelectedIndex = 0;
            //    bFirst = true;
            //    PnlPage.Visible = true;
            //}
        }
        #endregion

        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mServerInfo = Operation_SDO.GetServerList(this.m_ClientEvent, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbServer = Operation_SDO.BuildCombox(mServerInfo, CmbServer);

            PnlPage.Visible = false;
      
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            ArrayList paramList = (ArrayList)e.Argument;
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_CHARACTERINFO_QUERY, (CEnum.Message_Body[])paramList[0]);
                //for (int i = 0; i < mResult.GetLength(1); i++)
                //{
                //    if (mResult[0, i].eName == CEnum.TagName.SDO_UserIndexID)
                //    {
                //        iIndexID = int.Parse(mResult[0, i].oContent.ToString());
                //        ((CEnum.Message_Body[])paramList[1])[0].oContent = iIndexID;
                //    }
                //}
                //mItemResult = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_ITEMSHOP_BYOWNER_QUERY, (CEnum.Message_Body[])paramList[1]);
            }
            //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mResult[0, 0].oContent.ToString());
            //    e.Cancel = true;
            //    return;
            //}
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            try
            {
                
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                Operation_SDO.BuildDataTable(tmp_ClientEvent, mResult, this.RoleInfoView, out RolePage);
                this.panelRolePage.Visible = true;
                this.panelRolePage.Enabled = true;
                this.BtnSearch.Enabled = true;
                this.TbcResult.Enabled = true;
                this.Cursor = Cursors.Default;
                if (this.comboBoxRolePage.Items.Count == 0)
                {
                    for (int i = 1; i <= RolePage; i++)
                    {
                        this.comboBoxRolePage.Items.Add(i);
                    }
                    this.comboBoxRolePage.SelectedIndex = 0;
                    RoleFirst = true;
                }

                ////角色信息
                //for (int i = 0; i < mResult.GetLength(1); i++)
                //{
                //    LabelTextBox mDisplay = new LabelTextBox();

                //    mDisplay.Parent = PnlDetail;
                //    mDisplay.Position = C_Controls.LabelTextBox.LabelTextBox.ELABELPOSITION.LEFT;
                //    mDisplay.TextBoxText = null;

                //    if (i % 2 == 0)
                //    {
                //        mDisplay.Top = 20 * i + 11;
                //        mDisplay.Left = 44;
                //    }
                //    else
                //    {
                //        mDisplay.Top = 20 * (i - 1) + 11;
                //        mDisplay.Left = mDisplay.Width + 111;
                //    }

                //    try
                //    {
                //        mDisplay.LabelText = config.ReadConfigValue("GLOBAL", mResult[0, i].eName.ToString()) + ":";
                //            //this.m_ClientEvent.DecodeFieldName(mResult[0, i].eName) + ":";

                //        if (mResult[0, i].eName == CEnum.TagName.SDO_UserIndexID)
                //        {
                //            iIndexID = int.Parse(mResult[0, i].oContent.ToString());
                //        }

                //        mDisplay.TextBoxText = mResult[0, i].oContent.ToString();
                //    }
                //    catch
                //    {
                //        mDisplay.TextBoxText = "";
                //    }

                //    if (mResult[0, i].eName == CEnum.TagName.SDO_SEX)
                //    {
                //        if (mResult[0, i].oContent.ToString().Equals("0"))
                //            mDisplay.TextBoxText = config.ReadConfigValue("MSDO", "CI_Code_Sdofsex");
                //        else
                //            mDisplay.TextBoxText = config.ReadConfigValue("MSDO", "CI_Code_Sdomsex");
                //    }
                //}

                //foreach (Control m in PnlDetail.Controls.Find("LabelTextBox", true))
                //{
                //    ((LabelTextBox)m).ReadOnly = true;
                //    ((LabelTextBox)m).Refresh();
                //}

                //PnlDetail.Visible = true;
                //PnlDetail.Refresh();

                //if (mItemResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    return;
                //}

                //Operation_SDO.BuildDataTable(this.m_ClientEvent, mItemResult, GrdItemResult, out iPageCount);

                //if (iPageCount <= 0)
                //{
                //    PnlPage.Visible = false;
                //}
                //else
                //{
                //    for (int i = 0; i < iPageCount; i++)
                //    {
                //        CmbPage.Items.Add(i + 1);
                //    }

                //    CmbPage.SelectedIndex = 0;
                //    bFirst = true;
                //    PnlPage.Visible = true;
                //}
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

        private void backgroundWorkerPageChanged_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_ITEMSHOP_BYOWNER_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerPageChanged_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.CmbPage.Enabled = true;
                this.Cursor = Cursors.Default;
                Operation_SDO.BuildDataTable(tmp_ClientEvent, (CEnum.Message_Body[,])e.Result, GrdItemResult, out iPageCount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            
            }
        }

        private void comboBoxRolePage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RoleFirst)
            {
                RoleIndex = (int.Parse(this.comboBoxRolePage.Text) - 1) * 10 + 1;
                this.panelRolePage.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                this.PartInfo();
            }
        }

        private void RoleInfoView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                try
                {
                    GrdItemResult.DataSource = null;
                    this.CmbPage.Items.Clear();
                    TbcResult.SelectedTab = TpgItem;
                    TbcResult.Enabled = false;
                   // this.Cursor = Cursors.WaitCursor;
                    bFirst = false;
                    iIndexID = int.Parse(((DataTable)this.RoleInfoView.DataSource).Rows[e.RowIndex][0].ToString());
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];
                    mContent[0].eName = CEnum.TagName.SDO_UserIndexID;
                    mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[0].oContent = iIndexID;

                    mContent[1].eName = CEnum.TagName.SDO_ServerIP;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[2].eName = CEnum.TagName.Index;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = 1;

                    mContent[3].eName = CEnum.TagName.PageSize;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = Operation_SDO.iPageSize;

                    this.backgroundWorkerShowItem.RunWorkerAsync(mContent);
                }
                catch
                {

                }
            }
        }

        private void backgroundWorkerShowItem_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mItemResult = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_ITEMSHOP_BYOWNER_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerShowItem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                TbcResult.Enabled = true;
                this.Cursor = Cursors.Default;

                if (mItemResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mItemResult[0, 0].oContent.ToString());
                    return;
                }
                else
                {
                    Operation_SDO.BuildDataTable(this.m_ClientEvent, mItemResult, GrdItemResult, out iPageCount);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            
            }
        }

        private void backgroundWorkerShowPet_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult= Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_PetInfo_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerShowPet_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                TbcResult.Enabled = true;
                this.Cursor = Cursors.Default;

                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                else
                {
                    Operation_SDO.BuildDataTable(this.m_ClientEvent, mResult, dataGridView1, out iPageCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorkerShowPetDel_DoWork(object sender, DoWorkEventArgs e)
        {
            //lock (typeof(C_Event.CSocketEvent))
            //{
            //    mResult = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_PetDrop_Query, (CEnum.Message_Body[])e.Argument);
            //}
        }

        private void backgroundWorkerShowPetDel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //try
            //{
            //    TbcResult.Enabled = true;
            //    this.Cursor = Cursors.Default;

            //    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //    {
            //        MessageBox.Show(mResult[0, 0].oContent.ToString());
            //        return;
            //    }
            //    else
            //    {
            //        Operation_SDO.BuildDataTable(this.m_ClientEvent, mResult, dataGridView2, out iPageCount);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void RoleInfoView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                try
                {
                 
                    iIndexID = int.Parse(((DataTable)this.RoleInfoView.DataSource).Rows[e.RowIndex][0].ToString());
                  
                }
                catch
                {

                }
            }
        }
    }
}