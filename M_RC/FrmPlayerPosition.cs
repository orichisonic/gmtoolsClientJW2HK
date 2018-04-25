using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;
using C_Global;
using C_Event;
using Language;
using System.IO;


namespace M_RC
{
     /// <summary>
    /// 
    /// </summary>
    [C_Global.CModuleAttribute("玩家角色位置重置", "FrmPlayerPosition", " 玩家角色位置重置", "FJ_Group")]
    public partial class FrmPlayerPosition : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private int iPageCount = 2;
        private bool bFirst = false;
        private string _ServerIP;
        string userAccount = null; //玩家角色Id
        string userAccount2 = null;//玩价角色名称

        int currDgSelectRow = 0;    //玩家信息datagrid 中当前选中的行
        private CEnum.Message_Body[,] mType = null;

        private ShortStringDictionary ssd = new ShortStringDictionary();
        private CEnum.Message_Body[,] ItemBClass = null;
        private CEnum.Message_Body[,] ItemAClass = null;
        struct itemEx
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

        public FrmPlayerPosition()
        {
            InitializeComponent();
            FrmPlayGiftInfo.CheckForIllegalCrossThreadCalls = false;
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
            FrmPlayerPosition mModuleFrm = new FrmPlayerPosition();
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


        private void Frm_FJ_Item_Load(object sender, EventArgs e)
        {
            IntiFontLib();
     
        }
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
            //this.Text = config.ReadConfigValue("MRC", "FRC_UI_FrmPlayerPosition");
            //this.LblServer.Text = config.ReadConfigValue("MRC", "FRC_UI_LblServer");
            //this.LblAccount.Text = config.ReadConfigValue("MRC", "FRC_UI_LblPlayAccount");
            //this.BtnSearch.Text = config.ReadConfigValue("MRC", "FRC_UI_BtnSearch");
            //this.BtnClose.Text = config.ReadConfigValue("MRC", "FRC_UI_button1");
            //label1.Text = config.ReadConfigValue("MRC", "FRC_CODE_Tip6");
            //LblPage.Text = config.ReadConfigValue("MRC", "FRC_UI_LblSelectedPage");
        }


        #endregion

        #region
        private void FrmPlayerPosition_Load(object sender, EventArgs e)
        {
            try
            {
                IntiFontLib();
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
                mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = 1;

                mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = m_ClientEvent.GetInfo("GameID_RC");

                this.backgroundWorkerServerLoad.RunWorkerAsync(mContent);
            }
            catch
            { }
        }
        #endregion

        #region
        private void backgroundWorkerServer_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mServerInfo = Operation_RC.GetServerList(this.m_ClientEvent, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
        private void backgroundWorkerServer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbServer.Items.Clear();
            for (int i = 0; i < mServerInfo.GetLength(0); i++)
            {
                CmbServer.Items.Add(mServerInfo[i, 1].oContent);
            }

            CmbServer.SelectedIndex = 0;
            bFirst = true;
        }
        #endregion

        #region
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (CmbServer.Text == "")
            {
                return;
            }
            //清除控件

            tabControl1.SelectedTab = TpgCharacter;
            this.comboBox2.Items.Clear();
            this.RoleInfoView.DataSource = null;

            if (TxtAccount.Text.Trim().Length > 0 || TxtNick.Text.Length > 0)
            {
                this.BtnSearch.Enabled = false;
                PartInfo();
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MRC", "FQP_Code_inputid"));
                return;
            }
        }
        #endregion

        #region
        private void PartInfo()
        {
            this.RoleInfoView.DataSource = null;
            CEnum.Message_Body[,] mResult = null;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

            mContent[0].eName = CEnum.TagName.RayCity_NyUserID;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = TxtAccount.Text;

            mContent[1].eName = CEnum.TagName.RayCity_ServerIP;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = Operation_RC.GetItemAddr(mServerInfo, CmbServer.Text);
        
            mContent[2].eName = CEnum.TagName.RayCity_NyNickName;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = TxtNick.Text;


            mContent[3].eName = CEnum.TagName.Index;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = 1;

            mContent[4].eName = CEnum.TagName.PageSize;
            mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[4].oContent = Operation_RCode.iPageSize;

            this.backgroundWorkerSerch.RunWorkerAsync(mContent);

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
                    comboBox2.Items.Add(i + 1);
                }

                comboBox2.SelectedIndex = 0;
                bFirst = true;
                PnlPage.Visible = true;
            }
        }
        #endregion

        #region
        private void RoleInfoView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    DataTable mTable = (DataTable)RoleInfoView.DataSource;
                    userAccount = mTable.Rows[currDgSelectRow]["眀腹ID"].ToString();
                    DataTable dt2 = (DataTable)RoleInfoView.DataSource;

                    if (MessageBox.Show("絋﹚竚產à︹盾?", "竚產à︹", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        CEnum.Message_Body[,] mResult = null;
                        CEnum.Message_Body[] mContent2 = new CEnum.Message_Body[4];

                        mContent2[0].eName = CEnum.TagName.RayCity_ServerIP;
                        mContent2[0].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent2[0].oContent = Operation_RC.GetItemAddr(mServerInfo, CmbServer.Text);

                        mContent2[1].eName = CEnum.TagName.RayCity_CharacterID;
                        mContent2[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent2[1].oContent = int.Parse(userAccount);

                        mContent2[2].eName = CEnum.TagName.UserByID;
                        mContent2[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent2[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                        mContent2[3].eName = CEnum.TagName.RayCity_NyUserID;
                        mContent2[3].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent2[3].oContent = TxtAccount.Text;

                        lock (typeof(C_Event.CSocketEvent))
                        {
                            mResult = Operation_RCode.GetResult(tmp_ClientEvent, CEnum.ServiceKey.RayCity_SetPos_Update, mContent2);
                        }
                        if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                        {
                            MessageBox.Show("巨ア毖");
                            return;
                        }
                        else if (mResult[0, 0].oContent.ToString() == "SUCCESS")
                        {
                            MessageBox.Show("巨Θ");
                           
                            return;
                        }
                        else
                        {
                            MessageBox.Show("巨ア毖");
                            return;
                        }

                    }
                }
                if (e.RowIndex >= 0 && RoleInfoView.DataSource != null)
                {
                    tabControl1.SelectedIndex = 1;
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            { }
        }
        #endregion

        #region
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region
        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_RCode.GetItemAddr(mServerInfo, CmbServer.Text));
        }
        #endregion

        #region
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (bFirst)
                {
                    this.comboBox2.Enabled = false;
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
                    this.comboBox2.Enabled = true;

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