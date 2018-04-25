using System;
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
    [C_Global.CModuleAttribute("啟動大區查詢", "FrmRcActiveQuery", "啟動大區查詢", "raycity")]    
    public partial class FrmRcActiveQuery : Form
    {
        public FrmRcActiveQuery()
        {
            InitializeComponent();
        }

        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private CEnum.Message_Body[,] mResult = null;
        private CEnum.Message_Body[,] mItemResult = null;

        private int iPageCount = 0;
        private int level = 0;

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
            FrmRcActiveQuery mModuleFrm = new FrmRcActiveQuery();
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

        #region
        private void FrmRcCodeQuery_Load(object sender, EventArgs e)
        {
            IntiFontLib();
        }
        #endregion

        #region
        private void QueryActiveCode()
        {
            BtnSearch.Enabled = false;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];

            mContent[0].eName = CEnum.TagName.RC_ActiveCode;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = TxtAccount.Text;


            backgroundWorkerQuery.RunWorkerAsync(mContent);
        }
        #endregion

        #region
        private void QueryPlayerAccont()
        {
            BtnSearch.Enabled = false;
            CEnum.Message_Body[] messageBody = new CEnum.Message_Body[2];

            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[0].eName = C_Global.CEnum.TagName.CARD_username;
            messageBody[0].oContent = TxtAccount.Text.Trim();

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[1].eName = C_Global.CEnum.TagName.GameID;
            messageBody[1].oContent = 20 ;


            backgroundWorkerAccont.RunWorkerAsync(messageBody);
        }
        #endregion

        #region
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtAccount.Text.Length <= 0)
            {
                MessageBox.Show(config.ReadConfigValue("MRC", "CI_Code_inPutAccont"));
                return;
            }
            RoleInfoView.DataSource = null;
            if (!checkBoxBat.Checked)
            {
                QueryPlayerAccont();
            }
            else
            {
                QueryActiveCode();
            }
        }
        #endregion

        #region
        private void backgroundWorkerQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_RC.GetResult(m_ClientEvent, CEnum.ServiceKey.RC_RcCode_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
        private void backgroundWorkerQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnSearch.Enabled = true;
            Cursor = Cursors.Default;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            else
                Operation_RC.BuildDataTable(m_ClientEvent, mResult, RoleInfoView, out iPageCount);
        }
        #endregion

        #region
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region
        private void checkBoxBat_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBat.Checked)
            {

                LblAccount.Text = config.ReadConfigValue("MRC", "ActiveCode");
                checkBoxBat.Text = config.ReadConfigValue("MRC", "QueryPlayerAccont");

            }
            else
            {
                LblAccount.Text = config.ReadConfigValue("MRC", "PlayerAccont");
                checkBoxBat.Text = config.ReadConfigValue("MRC", "QueryActiveCode");
            }
        }
        #endregion

        #region
        private void backgroundWorkerAccont_DoWork(object sender, DoWorkEventArgs e)
        {

            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.CARD_USERINITACTIVE_QUERY, CEnum.Msg_Category.CARD_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
        private void backgroundWorkerAccont_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnSearch.Enabled = true;
            Cursor = Cursors.Default;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            else if (mResult[0, 0].oContent.ToString() == "FAILURE")
            {
                MessageBox.Show("沒有符合條件資料");
                return;
            }
            else
                BuildGameTable(mResult);

        }
        #endregion

        #region
        private void BuildGameTable(CEnum.Message_Body[,] mResult)
        {
            try
            {
                DataTable mTable = new DataTable();
                mTable.Columns.AddRange(new DataColumn[] { new DataColumn(config.ReadConfigValue("MRC", "GHP_CODE_ID")), 
                    new DataColumn(config.ReadConfigValue("MRC", "GHP_CODE_Game")), 
                    new DataColumn(config.ReadConfigValue("MRC", "GHP_CODE_ActiveDate")) });
                for (int i = 0; i < mResult.GetLength(0); i++)
                {
                    DataRow row = mTable.NewRow();
                    for (int j = 0; j < mResult.GetLength(1); j++)
                    {
                        row[j] = mResult[i, j].oContent.ToString();
                    }
                    mTable.Rows.Add(row);
                }
                this.RoleInfoView.DataSource = mTable;
            }
            catch
            {
                this.RoleInfoView.DataSource = null;
            }
        }
        #endregion
    }
}