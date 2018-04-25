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
    [C_Global.CModuleAttribute("技能資?", "FrmQueryPlayerSkill", "技能資?", "raycity")]
    public partial class FrmQueryPlayerSkill : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private int iPageCount = 0;
        private string strCharIDX = null;
        private string strCarIDX = null;
        private int introwIDX = -1;
        private ShortStringDictionary ssd = new ShortStringDictionary();


        public FrmQueryPlayerSkill()
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
            FrmQueryPlayerSkill mModuleFrm = new FrmQueryPlayerSkill();
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
            //this.Text = config.ReadConfigValue("MRC", "FRC_CODE_FrmQueryPlayerSkill");
            //GrpSearch.Text = config.ReadConfigValue("MRC", "FRC_UI_GrpSearch");
            //this.LblAccount.Text = config.ReadConfigValue("MRC", "FRC_UI_LblAccount");
            //this.label8.Text = config.ReadConfigValue("MRC", "FRC_UI_LblPlayNickName");
           
            //tabPage1.Text = config.ReadConfigValue("MRC", "FRC_CODE_FrmQueryPlayerSkill");
            //btnDel.Text = config.ReadConfigValue("MRC", "FRC_CODE_Del");
            //LblPage.Text = config.ReadConfigValue("MRC", "FRC_UI_LblSelectedPage");
            //label4.Text = config.ReadConfigValue("MRC", "FRC_CODE_Tip11");
            //BtnSearch.Text = config.ReadConfigValue("MRC", "FRC_UI_BtnSerch");
        }


        #endregion

        #region
        private void FrmQueryPlayerID_Load(object sender, EventArgs e)
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

                this.backgroundWorkerFormLoad.RunWorkerAsync(mContent);
            }
            catch
            { }
        }
        #endregion

        #region
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtAccount.Text.Length > 0 || TxtNick.Text.Length > 0)
            {
                this.BtnSearch.Enabled = false;
                this.RoleInfoView.DataSource = null;
                this.CmbPage.Items.Clear();

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.RayCity_NyUserID;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtAccount.Text;

                mContent[1].eName = CEnum.TagName.RayCity_ServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Operation_RCode.GetItemAddr(mServerInfo, CmbServer.Text);

                if (TxtNick.Text.Length > 0)
                {
                    mContent[2].eName = CEnum.TagName.RayCity_NyNickName;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = TxtNick.Text + "%%%%%";
                }
                else
                {
                    mContent[2].eName = CEnum.TagName.RayCity_NyNickName;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = TxtNick.Text;
                }

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent =1;


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
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];

            mContent[0].eName = CEnum.TagName.RayCity_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_RCode.GetItemAddr(mServerInfo, CmbServer.Text);

            CEnum.Message_Body[,] result = Operation_RCode.GetResult(tmp_ClientEvent, CEnum.ServiceKey.RayCity_Skill_Query, mContent);

            if (result[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
             return;
            }
            else
            {
                this.CmbPlayerItem = Operation_RCode.BuildCombox(result, CmbPlayerItem, ssd);
            }
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
            else
            {
                strCharIDX = mResult[0, 2].oContent.ToString();
                strCarIDX = mResult[0, 3].oContent.ToString();
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

                mContent[0].eName = CEnum.TagName.RayCity_CharacterID;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = int.Parse(strCharIDX);

                mContent[1].eName = CEnum.TagName.RayCity_ServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Operation_RCode.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[2].eName = CEnum.TagName.UserByID;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());


                CEnum.Message_Body[,] result = Operation_RCode.GetResult(tmp_ClientEvent, CEnum.ServiceKey.RayCity_PlayerSkill_Query, mContent);

                if (result[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(result[0, 0].oContent.ToString());
                    return;
                }
                else
                {
                    Operation_RCode.BuildDataTable(this.m_ClientEvent, result, RoleInfoView, out iPageCount);
                    
                }


            }


            //Operation_RCode.BuildDataTable(this.m_ClientEvent, mResult, RoleInfoView, out iPageCount);
        }
        #endregion

        #region
        private void RoleInfoView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (introwIDX >= 0 && RoleInfoView.DataSource != null)
            {
                using (DataTable dt = (DataTable)RoleInfoView.DataSource)
                {
                    if (MessageBox.Show("絋龟埃赣兜м盾", "矗ボ埃", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        CEnum.Message_Body[,] mResult = null;

                        CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                        mContent[0].eName = CEnum.TagName.RayCity_CharacterID;
                        mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[0].oContent = int.Parse(strCharIDX);

                        mContent[1].eName = CEnum.TagName.RayCity_SkillID;
                        mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[1].oContent = int.Parse(dt.Rows[introwIDX][0].ToString());

                        mContent[2].eName = CEnum.TagName.UserByID;
                        mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                        mContent[3].eName = CEnum.TagName.RayCity_ServerIP;
                        mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[3].oContent = Operation_RC.GetItemAddr(mServerInfo, CmbServer.Text);

                        mContent[4].eName = CEnum.TagName.RayCity_NyUserID;
                        mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[4].oContent = TxtAccount.Text;

                        lock (typeof(C_Event.CSocketEvent))
                        {
                            mResult = Operation_RCode.GetResult(tmp_ClientEvent, CEnum.ServiceKey.RayCity_PlayerSkill_Delete, mContent);
                        }
                        if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                        {
                            MessageBox.Show(mResult[0, 0].oContent.ToString());
                            return;
                        }
                        if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.ToString() == "SUCCESS")
                        {
                            MessageBox.Show("埃Θ");
                            

                        }
                        else
                        {
                            MessageBox.Show("埃ア毖");
                        }
                        this.BtnSearch_Click(null, null);

                    }
                    else
                    {
                        return;
                    }
                }

            }
            else
            {
                return;
            }
        }
        #endregion

        #region
        private void BtnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbPlayerItem.Items.Count > 0 && TxtCharinfo.Text.Length > 0)
                {
                    if (MessageBox.Show("絋龟睰埃赣兜м盾", "絋龟睰", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        CEnum.Message_Body[,] mResult = null;

                        CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                        mContent[0].eName = CEnum.TagName.RayCity_CharacterID;
                        mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[0].oContent = int.Parse(TxtCharinfo.Text.Trim());

                        mContent[1].eName = CEnum.TagName.RayCity_SkillID;
                        mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[1].oContent = int.Parse(ssd[CmbPlayerItem.Text.ToString()]);

                        mContent[2].eName = CEnum.TagName.UserByID;
                        mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                        mContent[3].eName = CEnum.TagName.RayCity_ServerIP;
                        mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[3].oContent = Operation_RC.GetItemAddr(mServerInfo, CmbServer.Text);

                        mContent[4].eName = CEnum.TagName.RayCity_NyUserID;
                        mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[4].oContent = TxtAccount.Text;

                        mContent[5].eName = CEnum.TagName.RayCity_SkillLevel;
                        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[5].oContent = int.Parse(numericUpDown1.Value.ToString());

                        lock (typeof(C_Event.CSocketEvent))
                        {
                            mResult = Operation_RCode.GetResult(tmp_ClientEvent, CEnum.ServiceKey.RayCity_PlayerSkill_Insert, mContent);
                        }
                        if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                        {
                            MessageBox.Show(mResult[0, 0].oContent.ToString());
                            return;
                        }
                        if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.ToString() == "SUCCESS")
                        {
                            MessageBox.Show("睰Θ");

                        }
                        else
                        {
                            MessageBox.Show("睰ア毖");
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
        }
        #endregion

        #region
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1 && strCharIDX != null)
            {
                TxtCharinfo.Text = strCharIDX;
                txtName.Text = strCarIDX;
            }
        }
        #endregion

        #region
        private void RoleInfoView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            introwIDX = e.RowIndex;
        }
        #endregion

        #region
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (introwIDX >= 0 && RoleInfoView.DataSource != null)

            {
                using (DataTable dt = (DataTable)RoleInfoView.DataSource)
                {
                    if (MessageBox.Show("確認刪除技能?", "刪除技能", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        CEnum.Message_Body[,] mResult = null;

                        CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                        mContent[0].eName = CEnum.TagName.RayCity_CharacterID;
                        mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[0].oContent = int.Parse(strCharIDX);

                        mContent[1].eName = CEnum.TagName.RayCity_SkillID;
                        mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[1].oContent = int.Parse(dt.Rows[introwIDX][0].ToString());

                        mContent[2].eName = CEnum.TagName.UserByID;
                        mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                        mContent[3].eName = CEnum.TagName.RayCity_ServerIP;
                        mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[3].oContent = Operation_RC.GetItemAddr(mServerInfo, CmbServer.Text);

                        mContent[4].eName = CEnum.TagName.RayCity_NyUserID;
                        mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[4].oContent = TxtAccount.Text;

                        lock (typeof(C_Event.CSocketEvent))
                        {
                            mResult = Operation_RCode.GetResult(tmp_ClientEvent, CEnum.ServiceKey.RayCity_PlayerSkill_Delete, mContent);
                        }
                        if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                        {
                            MessageBox.Show(mResult[0, 0].oContent.ToString());
                            return;
                        }
                        if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.ToString() == "SUCCESS")
                        {
                            MessageBox.Show("操作成功");

                        }
                        else
                        {
                            MessageBox.Show("操作失敗");
                        }


                    }
                    else
                    {
                        return;
                    }
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

    }
}