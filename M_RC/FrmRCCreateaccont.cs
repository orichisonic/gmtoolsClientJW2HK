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

namespace M_RC
{
    [C_Global.CModuleAttribute("GM帳號信息", "FrmRCCreateaccont", "GM帳號信息", "Gm Group")]
    public partial class FrmRCCreateaccont : Form
    {
        public FrmRCCreateaccont()
        {
            InitializeComponent();
        }


        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;

        private int iPageCount = 0;
        private bool bFirst = false;

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
            FrmRCCreateaccont mModuleFrm = new FrmRCCreateaccont();
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
        
        }


        #endregion

        #region
        private void FrmGmaccont_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            //comboBox1.SelectedIndex = 0;
            //PnlPage.Visible = false;
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
            try
            {
                if (CmbServer.Text == "")
                {
                    return;
                }
                if (TxtAccount.Text == "")
                {
                    MessageBox.Show("請輸入帳號首碼");
                    return;
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("請輸入要設定的密碼");
                    return;
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("請輸入要設定的密碼");
                    return;
                }
                if (textBox3.Text == "")
                {
                    MessageBox.Show("請輸入開始序號");
                    return;
                }
                if (textBox3.Text == "0")
                {
                    MessageBox.Show("開始序號不能為0");
                    return;
                }
                if (textBox4.Text == "")
                {
                    MessageBox.Show("請輸入結束序號");
                    return;
                }

                if (int.Parse(textBox3.Text) > int.Parse(textBox3.Text))
                {
                    MessageBox.Show("結束序號應該大於開始序號");
                    return;
                }

                BtnSearch.Enabled = false;
                //this.RoleInfoView.DataSource = null;
                CEnum.Message_Body[] mContent1 = new CEnum.Message_Body[4];

                mContent1[0].eName = CEnum.TagName.RayCity_NyUserID;
                mContent1[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent1[0].oContent = TxtAccount.Text.Trim()+"%%%%%";

                mContent1[1].eName = CEnum.TagName.RayCity_ServerIP;
                mContent1[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent1[1].oContent = Operation_RC.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent1[2].eName = CEnum.TagName.Index;
                mContent1[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent1[2].oContent = 1;

                mContent1[3].eName = CEnum.TagName.PageSize;
                mContent1[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent1[3].oContent = Operation_RCode.iPageSize;

                CEnum.Message_Body[,] result = Operation_RCode.GetResult(tmp_ClientEvent, CEnum.ServiceKey.RayCity_BasicAccount_Query, mContent1);

                if (result[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {

                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                    mContent[0].eName = CEnum.TagName.RayCity_NyUserID;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = TxtAccount.Text;

                    mContent[1].eName = CEnum.TagName.RayCity_ServerIP;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = Operation_RCode.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[2].eName = CEnum.TagName.RayCity_NyPassword;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = textBox2.Text;

                    mContent[3].eName = CEnum.TagName.RayCity_StartNum;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(textBox3.Text);

                    mContent[4].eName = CEnum.TagName.RayCity_EndNum;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = int.Parse(textBox4.Text);

                    mContent[5].eName = CEnum.TagName.UserByID;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    backgroundWorkerSearch.RunWorkerAsync(mContent);
                }
                else
                {
                    MessageBox.Show("此首碼已有玩家使用過");
                    BtnSearch.Enabled = true;
                    return;
                }



            }
            catch
            {
                MessageBox.Show("序號格式錯誤");
                return;
            }

        }
        #endregion

        #region
        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_RCode.GetResult(tmp_ClientEvent, CEnum.ServiceKey.RayCity_PlayerAccount_Create, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnSearch.Enabled = true;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            else if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.ToString() == "SUCCESS")
            {
                MessageBox.Show("操作成功");
                return;
            }
            else
            {
                MessageBox.Show("操作失敗");
                return;
            }
        }
        #endregion

        #region
        private int ReturnNum(string strtxt)
        {
            int num = -1;
            if (strtxt == "開通GM帳號")
            {
                num = 255;
            }
            else if (strtxt == "關閉GM帳號")
            {
                num = 999;
            }
            else if (strtxt == "解封帳號")
            {
                num = 1;
            }

            else if (strtxt == "封停帳號")
            {
                num = 999;
            }

            return num;

        }
        #endregion

        #region
        private void backgroundWorkerSearch1_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_RCode.GetResult(tmp_ClientEvent, CEnum.ServiceKey.RayCity_GMUser_Query, (CEnum.Message_Body[])e.Argument);
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