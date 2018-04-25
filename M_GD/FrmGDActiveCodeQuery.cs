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

namespace M_GD
{
    [C_Global.CModuleAttribute("激活码查询", "FrmGDActiveCodeQuery", "激活码查询", "GD Group")]
    public partial class FrmGDActiveCodeQuery : Form
    {
        #region 变量

        private CSocketEvent m_ClientEvent = null;
        private int iPageCount = 0;//翻页页数

        #endregion

        public FrmGDActiveCodeQuery()
        {
            InitializeComponent();
        }

        #region 创建类库中的窗体
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

        #region 初始化语言库
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
            //this.GrpSearch.Text = config.ReadConfigValue("MSD", "UIC_UI_GrpSearch");
            //this.lblCondition.Text = config.ReadConfigValue("MSD", "UIC_UI_lblAccount");
            //this.btnSearch.Text = config.ReadConfigValue("MSD", "UIC_UI_btnSearch");
            //this.btnClose.Text = config.ReadConfigValue("MSD", "UIC_UI_btnClose");
            //this.chbCondition.Text = config.ReadConfigValue("MSD", "AA_UI_chbActive");
        }

        #endregion



        #region 登陆窗体加载
        private void FrmGDActiveCodeQuery_Load(object sender, EventArgs e)
        {
            IntiFontLib();
        }
        #endregion



        #region 切换checkBox改变查询条件
        private void chbCondition_CheckedChanged(object sender, EventArgs e)
        {
            if (chbCondition.Checked)
            {
                lblCondition.Text = config.ReadConfigValue("MSD", "AA_UI_lblAccount");
                chbCondition.Text = config.ReadConfigValue("MSD", "AA_UI_chbAccount");
                txtCondition.Text = "";
                dgvResult.DataSource = null;
            }
            else
            {
                lblCondition.Text = config.ReadConfigValue("MSD", "UIC_UI_lblAccount");
                chbCondition.Text = config.ReadConfigValue("MSD", "AA_UI_chbActive");
                txtCondition.Text = "";
                dgvResult.DataSource = null;
            }
        }
        #endregion



        #region 查询帐号激活信息
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (chbCondition.Checked)
                {
                    ActiveSearch();
                }
                else
                {
                    AccountSearch();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion



        #region 通过帐号查询激活信息
        private void AccountSearch()
        {
            try
            {
                this.dgvResult.DataSource = null;

                if ("" == txtCondition.Text.Trim())
                {
                    MessageBox.Show(config.ReadConfigValue("MSD", "AA_Hint_inPutAccont"));
                    return;
                }

                this.GrpSearch.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态                

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];

                mContent[0].eName = CEnum.TagName.SD_UserName;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = txtCondition.Text.Trim();

                backgroundWorkerSearch.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 通过帐号查询激活信息backgroundWorker消息发送
        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(m_ClientEvent, CEnum.ServiceKey.SD_Account_Active_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 通过帐号查询激活信息backgroundWorker消息接收
        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.GrpSearch.Enabled = true;
            this.Cursor = Cursors.Default;//改变鼠标状态
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, dgvResult, out iPageCount);
        }
        #endregion



        #region 通过激活码查询激活信息
        private void ActiveSearch()
        {
            try
            {
                this.dgvResult.DataSource = null;

                if ("" == txtCondition.Text.Trim())
                {
                    MessageBox.Show(config.ReadConfigValue("MSD", "AA_Hint_inPutActive"));
                    return;
                }

                this.GrpSearch.Enabled = false;
                this.Cursor = Cursors.WaitCursor;//改变鼠标状态


                CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];

                mContent[0].eName = CEnum.TagName.SD_ActiceCode;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = txtCondition.Text.Trim();

                backgroundWorkerActiveCode.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 通过激活码查询激活信息backgroundWorker消息发送
        private void backgroundWorkerActiveCode_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_GD.GetResult(m_ClientEvent, CEnum.ServiceKey.SD_ActiveCode_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region 通过激活码查询激活信息backgroundWorker消息接收
        private void backgroundWorkerActiveCode_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.GrpSearch.Enabled = true;
            this.Cursor = Cursors.Default;//改变鼠标状态
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            Operation_GD.BuildDataTable(this.m_ClientEvent, mResult, dgvResult, out iPageCount);
        }
        #endregion



        #region 窗体关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion    
    }
}