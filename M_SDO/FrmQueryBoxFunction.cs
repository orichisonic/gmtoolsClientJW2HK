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
namespace M_SDO
{
    [C_Global.CModuleAttribute("宝箱功能信息", "FrmQueryBoxFunction", "SDO管理工具 -- 宝箱功能信息", "SDO Group")]
    public partial class FrmQueryBoxFunction : Form
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
        private int uid;

        public FrmQueryBoxFunction()
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
            //this.Text = config.ReadConfigValue("MSDO", "IUS_UI_Text");
            this.GrpSearch.Text = config.ReadConfigValue("MSDO", "AF_UI_GrpSearch");
            this.LblServer.Text = config.ReadConfigValue("MSDO", "AF_UI_LblServer");
            
            this.BtnSearch.Text = config.ReadConfigValue("MSDO", "AF_UI_BtnSearch");
            //this.button1.Text = config.ReadConfigValue("MSDO", "AF_UI_BtnReset");
            //this.GrpResult.Text = config.ReadConfigValue("MSDO", "AF_UI_GrpResult");

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
            FrmQueryBoxFunction mModuleFrm = new FrmQueryBoxFunction();
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

        private void FrmQueryBoxFunction_Load(object sender, EventArgs e)
        {
            IntiFontLib();
       
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 1;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_SDO");

            this.backgroundWorkerFormLoad.RunWorkerAsync(mContent);
        }

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
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            /*
             * 清除上一次显示的内容
             */

            this.TbcResult.SelectedIndex = 0;
            if (CmbServer.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "LO_Code_Msg1"));
                return;
            }

            BtnSearch.Enabled = false;
            Cursor = Cursors.WaitCursor;
            RoleInfoView.DataSource = null;

            C_Global.CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];

            mContent[0].eName = CEnum.TagName.SDO_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

            //if (checkBoxSex.Checked)
            //{
            //    mContent[1].eName = CEnum.TagName.SDO_CoupleUserName;
            //    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[1].oContent = TxtAccount.Text.Trim();

            //    mContent[2].eName = CEnum.TagName.SDO_Account;
            //    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[2].oContent = "";
            //}
            //else
            //{
            //    mContent[1].eName = CEnum.TagName.SDO_CoupleUserName;
            //    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[1].oContent = "";

            //    mContent[2].eName = CEnum.TagName.SDO_Account;
            //    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[2].oContent = TxtAccount.Text.Trim();
            //}

            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text));

            this.backgroundWorkerSearch.RunWorkerAsync(mContent);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(m_ClientEvent, CEnum.ServiceKey.SDO_BAOXIANGRate_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnSearch.Enabled = true;
            Cursor = Cursors.Default;
            int pg = 0;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            else
            {
                Operation_SDO.BuildDataTable(tmp_ClientEvent, mResult, RoleInfoView, out pg);
            }
        }

        private void RoleInfoView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                this.TbcResult.SelectedIndex = 1;
                if (e.RowIndex != -1)
                {

                    uid= int.Parse(((DataTable)this.RoleInfoView.DataSource).Rows[e.RowIndex][0].ToString());
               
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void TbcResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (this.TbcResult.SelectedIndex == 1)
                {

                    if (this.RoleInfoView.DataSource != null)
                    {
                        using (DataTable dt = (DataTable)this.RoleInfoView.DataSource)
                        {
                            this.textBox1.Text = dt.Rows[this.RoleInfoView.CurrentCell.RowIndex][0].ToString();
                            this.txtPreValue.Text= dt.Rows[this.RoleInfoView.CurrentCell.RowIndex][2].ToString();
                            this.txtEndValue.Text=dt.Rows[this.RoleInfoView.CurrentCell.RowIndex][3].ToString();
                            this.txtNorProFirst.Text=dt.Rows[this.RoleInfoView.CurrentCell.RowIndex][4].ToString();
                            this.txtNorPro.Text = dt.Rows[this.RoleInfoView.CurrentCell.RowIndex][5].ToString();
                            this.txtSpePro.Text = dt.Rows[this.RoleInfoView.CurrentCell.RowIndex][6].ToString();
                        
                        }




                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.txtPreValue.Text = "";
            this.txtEndValue.Text = "";
            this.txtNorPro.Text = "";
            this.txtNorProFirst.Text = "";
            this.txtSpePro.Text = "";
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                CEnum.Message_Body[] mContent1 = new CEnum.Message_Body[8];
                CEnum.Message_Body[,] mResult;
                mContent1[0].eName = CEnum.TagName.SDO_ServerIP;
                mContent1[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent1[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent1[1].eName = CEnum.TagName.UserByID;
                mContent1[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent1[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent1[2].eName = CEnum.TagName.SDO_baoxiangid;
                mContent1[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent1[2].oContent =uid;

                mContent1[3].eName = CEnum.TagName.SDO_PreValue;
                mContent1[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent1[3].oContent = int.Parse(this.txtPreValue.Text.ToString());

                mContent1[4].eName = CEnum.TagName.SDO_EndValue;
                mContent1[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent1[4].oContent = int.Parse(this.txtEndValue.Text.ToString());

                mContent1[5].eName = CEnum.TagName.SDO_NorProFirst;
                mContent1[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent1[5].oContent = int.Parse(this.txtNorProFirst.Text.ToString());

                mContent1[6].eName = CEnum.TagName.SDO_NorPro;
                mContent1[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent1[6].oContent = int.Parse(this.txtNorPro.Text.ToString());

                mContent1[7].eName = CEnum.TagName.SDO_SpePro;
                mContent1[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent1[7].oContent = int.Parse(this.txtSpePro.Text.ToString());

                button2.Enabled = false;
                lock (typeof(C_Event.CSocketEvent))
                {
                    mResult = Operation_SDO.GetResult(m_ClientEvent, CEnum.ServiceKey.SDO_BAOXIANGRate_Update, mContent1);
                }

                //检测状态


                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg || mResult[0, 0].oContent.ToString() == "操作失败!")
                {
                    MessageBox.Show("操作失败");
                    return;
                }

                if (mResult[0, 0].oContent.ToString() == "FAILURE")
                {
                    MessageBox.Show("操作失败");
                    return;

                }
                else if (mResult[0, 0].oContent.ToString() == "SUCESS")
                {
                    MessageBox.Show("操作成功");
                    button2.Enabled = true;
                    //CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
                    //mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
                    //mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                    //mContent[0].oContent = 1;

                    //mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
                    //mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    //mContent[1].oContent = m_ClientEvent.GetInfo("GameID_MF");

                    //this.backgroundWorkerSearch.RunWorkerAsync(mContent);
                    this.BtnSearch_Click(null,null);
                    return;
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());

            }


        }

        private void txtPreValue_KeyPress(object sender, KeyPressEventArgs e)
        {
       
            base.OnKeyPress(e);//win32键盘响应键值响应数字，设置正确游戏币

            if (((e.KeyChar >= 48 && e.KeyChar <= 57)) || e.KeyChar == 8)
            {

                e.Handled = false;

            }
            else
            {
                e.Handled = true;
            }

        
        }
    }

}