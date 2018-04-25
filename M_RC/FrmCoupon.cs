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
    [C_Global.CModuleAttribute("玩家序列号查询", "FrmCoupon", " 玩家序列号查询", "RC_Group")]
    public partial class FrmCoupon : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        Regex rgx = new Regex(@"^\d{5}-\d{5}-\d{5}-\d[5]-\d[5]$");
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
        public FrmCoupon()
        {
            InitializeComponent();
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
            //this.Text = config.ReadConfigValue("MRC", "FRC_UI_FrmCoupon");
            //this.LblServer.Text = config.ReadConfigValue("MRC", "FRC_UI_LblServer");
            //this.LblCoupon.Text = config.ReadConfigValue("MRC", "FRC_UI_LblCoupon");
            //this.BtnSearch.Text = config.ReadConfigValue("MRC", "FRC_UI_BtnSearch");
            //this.BtnClose.Text = config.ReadConfigValue("MRC", "FRC_UI_button1");
          
            //this.LblPage.Text = config.ReadConfigValue("MRC", "FRC_UI_LblSelectedPage");
        }
        #endregion

        private void FrmCoupon_Load(object sender, EventArgs e)
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
        #region 服务器列表
        private void backgroundWorkerServer_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mServerInfo = Operation_RC.GetServerList(this.m_ClientEvent, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 服务器列表结果
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
            FrmCoupon mModuleFrm = new FrmCoupon();
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

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbServer.Text == "")
                {
                    return;
                }
                //if (!rgx.IsMatch(TxtCoupon.Text) && TxtCoupon.Text != "")
                //{
                //    MessageBox.Show("请输入正确的序列号");
                //    return;
                //}
                //清除控件
                tabControl1.SelectedTab = TpgCharacter;
                this.comboBox2.Items.Clear();
                this.RoleInfoView.DataSource = null;
                this.BtnSearch.Enabled = false;
                this.RoleInfoView.DataSource = null;
                CEnum.Message_Body[,] mResult = null;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

                mContent[0].eName = CEnum.TagName.RayCity_CouponNumber;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                if (TxtCoupon.Text.Trim().Length == 0)
                {
                    mContent[0].oContent = "";
                }
                else
                {
                    mContent[0].eName = CEnum.TagName.RayCity_CouponNumber;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = TxtCoupon.Text.ToString();
                }
                mContent[1].eName = CEnum.TagName.RayCity_ServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Operation_RC.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[2].eName = CEnum.TagName.Index;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = 1;

                mContent[3].eName = CEnum.TagName.PageSize;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = Operation_RCode.iPageSize;

                this.backgroundWorkerSerch.RunWorkerAsync(mContent);
            }
            catch (Exception Exp)
            {
                this.BtnSearch.Enabled = true;
                MessageBox.Show(Exp.Message);
            }
        }
        #region
        private void backgroundWorkerSerch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_RCode.GetResult(tmp_ClientEvent, CEnum.ServiceKey.RayCity_Coupon_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
        private void backgroundWorkerSerch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
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
                    bFirst = true;
                    comboBox2.SelectedIndex = 0;
                    PnlPage.Visible = true;
                }
            }
            catch (Exception Exp1)
            {
                MessageBox.Show(Exp1.Message);
            }

        }
        #endregion


        #region 加载tmp_ClientEvent
        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_RCode.GetItemAddr(mServerInfo, CmbServer.Text));
        }
        #endregion

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (!rgx.IsMatch(TxtCoupon.Text) && TxtCoupon.Text!="")
                //{
                //    MessageBox.Show("请输入正确的序列号");
                //    return;
                //}
                if (!bFirst)
                {
                    this.comboBox2.Enabled = false;
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];
                    CEnum.Message_Body[,] mResult = null;
                    mContent[0].eName = CEnum.TagName.RayCity_CouponNumber;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    if (TxtCoupon.Text.Trim().Length == 0)
                    {
                        mContent[0].oContent = "";
                    }
                    else 
                    {
                        mContent[0].oContent = TxtCoupon.Text.ToString();
                    }
                    mContent[1].eName = CEnum.TagName.RayCity_ServerIP;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = Operation_RC.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[2].eName = CEnum.TagName.Index;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = int.Parse(this.comboBox2.Text.ToString());

                    mContent[3].eName = CEnum.TagName.PageSize;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = Operation_RCode.iPageSize;

                    this.backgroundWorkerPage.RunWorkerAsync(mContent);
                }
                bFirst = false;
            }
            catch(Exception Exp)
            {
                this.comboBox2.Enabled = true;
                MessageBox.Show(Exp.Message);
            }
        }

        private void backgroundWorkerPage_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_RCode.GetResult(tmp_ClientEvent, CEnum.ServiceKey.RayCity_Coupon_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerPage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try 
            {
                this.comboBox2.Enabled = true;

                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
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
            catch(Exception Exp)
            {
                this.comboBox2.Enabled = true;
                MessageBox.Show(Exp.Message);
            }
            
        }
        #region 窗体关闭
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}