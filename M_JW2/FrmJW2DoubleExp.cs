using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C_Global;
using C_Event;
using Language;

using System.IO;
using System.Globalization;

namespace M_JW2
{
    [C_Global.CModuleAttribute("设置金钱经验翻倍", "FrmJW2DoubleExp", "设置金钱经验翻倍", "JW2 Group")] 

    public partial class FrmJW2DoubleExp: Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CEnum.Message_Body[,] mChannelInfo = null;
        private CEnum.Message_Body[,] BroadInfo = null;
        private CEnum.Message_Body[,] mResult = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        DataTable dgTable = new DataTable();

        private CEnum.Message_Body[,] addResult = null;
        ArrayList ipAddress = new ArrayList();
        private bool ischeck = false;
        private int iIndexID = 0;
        private int iBoardID = -1;
        string ServerIP = "";
        string serverIP = "";

        private static FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);


        public FrmJW2DoubleExp()
        {
            InitializeComponent();
            //DptEnd.Value.AddMinutes(10);
        }
        

        #region 调用函数
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
          //  this.Text = config.ReadConfigValue("MSDO", "FN_UI_FrmSdoNotice");
          //  this.label2.Text = config.ReadConfigValue("MSDO", "FN_UI_label2");
          //  this.button2.Text = config.ReadConfigValue("MSDO", "FN_UI_button2");
          //  this.btnRecord.Text = config.ReadConfigValue("MSDO", "FN_UI_btnRecord");
          //  this.label3.Text = config.ReadConfigValue("MSDO", "FN_UI_label3");
          //  this.label4.Text = config.ReadConfigValue("MSDO", "FN_UI_label4");
          //  this.label5.Text = config.ReadConfigValue("MSDO", "FN_UI_label5");
          //// this.label11.Text = config.ReadConfigValue("MSDO", "FN_UI_label11");

          //  this.label10.Text = config.ReadConfigValue("MSDO", "FN_UI_label10");
          // // this.label6.Text = config.ReadConfigValue("MSDO", "FN_UI_label6");
          // // this.label7.Text = config.ReadConfigValue("MSDO", "FN_UI_label7");
          //  this.btnMod.Text = config.ReadConfigValue("MSDO", "FN_UI_btnMod");
          //  this.button1.Text = config.ReadConfigValue("MSDO", "FN_UI_button1");
          //  this.ItmEdit.Text = config.ReadConfigValue("MSDO", "Mnu_ItmEdit");
          //  this.ItmDelete.Text = config.ReadConfigValue("MSDO", "Mnu_ItmDelete");
          //  this.btnOk.Text = config.ReadConfigValue("MSDO", "FN_UI_btnok");

            this.Text = config.ReadConfigValue("MJW2", "NEW_UI_FrmJW2DoubleExp");
            this.lblServer.Text = config.ReadConfigValue("MSD", "UIC_UI_lblServer");
            this.label2.Text = config.ReadConfigValue("MJW2", "NEW_UI_ZoneName");
            button2.Text = config.ReadConfigValue("MJW2", "NEW_UI_AllSelect");
            label3.Text = config.ReadConfigValue("MJW2", "NEW_UI_ModiContent");
            label5.Text = config.ReadConfigValue("MJW2", "NEW_UI_ExperienceMultiple");

            btnOk.Text = config.ReadConfigValue("MJW2", "NEW_UI_Modi");
            button1.Text = config.ReadConfigValue("MJW2", "NEW_UI_Reset");
        }
        #endregion
        /// <summary>
        /// 请求频道名称
        /// </summary>
        private void GetChannelList()
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
                mContent[1].oContent = m_ClientEvent.GetInfo("GameID_JW2");

                this.backgroundWorkerFormLoad.RunWorkerAsync(mContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            //mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            //mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            //mContent[0].oContent = 1;

            //mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            //mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            //mContent[1].oContent = m_ClientEvent.GetInfo("GameID_JW2");

            //mChannelInfo = Operation_JW2.GetServerList(this.m_ClientEvent, mContent);

            //if (mChannelInfo[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mChannelInfo[0, 0].oContent.ToString());
            //    return;
            //}

            //for (int i = 0; i < mChannelInfo.GetLength(0); i++)
            //{
            //    TxtCode.Items.Add(mChannelInfo[i, 1].oContent.ToString());
            //}

        }
        /// <summary>
        /// 公告记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecord_Click(object sender, EventArgs e)

        {
            //ItmEdit.Enabled = true;
            ////ItmDelete.Enabled = false;
            //GrdList.DataSource = null;
            //CEnum.Message_Body[] mContent = null;
            //mResult = null;
            //mResult = Operation_SDO.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_BOARDTASK_QUERY, mContent);

            //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mResult[0, 0].oContent.ToString());
            //    return;
            //}

            //GrdList.DataSource = BrowseResultInfo();
            //ItmEdit.Enabled = true;
            //ItmDelete.Enabled = true;
        }
        /// <summary>
        /// 生成公告信息内容
        /// </summary>
        /// <returns>DataTable公告信息内容</returns>
        private DataTable BrowseResultInfo()
        {
            try
            {

                dgTable = new DataTable();
                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "FN_Code_Id"), typeof(string));
                //dgTable.Columns.Add("服务器大区", typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "FN_Code_stime"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "FN_Code_etime"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "FN_Code_inteveal"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "FN_Code_state"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "FN_Code_text"), typeof(string));

                for (int i = 0; i < mResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();
                    dgRow[config.ReadConfigValue("MSDO", "FN_Code_Id")] = mResult[i, 0].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSDO", "FN_Code_stime")] = mResult[i, 1].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSDO", "FN_Code_etime")] = mResult[i, 2].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSDO", "FN_Code_inteveal")] = mResult[i, 3].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSDO", "FN_Code_state")] = ReturnStauas(int.Parse(mResult[i, 4].oContent.ToString()));
                    dgRow[config.ReadConfigValue("MSDO", "FN_Code_text")] = mResult[i, 5].oContent.ToString();
                    dgTable.Rows.Add(dgRow);
                }

            }
            catch
            {
            }
            return dgTable;
        }

        #region
        /// <summary>
        /// 添加公告信息内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {

            try
            {
     
                serverIP = "";
                for (int i = 0; i < TxtCode.CheckedItems.Count; i++)
                    {
                        serverIP += TxtCode.CheckedItems[i].ToString() + "," + Operation_JW2.GetGSServerIp(mChannelInfo, TxtCode.CheckedItems[i].ToString()) + "," + Operation_JW2.Getserverno(mChannelInfo, TxtCode.CheckedItems[i].ToString()) + "," + Operation_JW2.GetSeverPort(mChannelInfo, TxtCode.CheckedItems[i].ToString());
                        serverIP += "|";
                    }
              
                if (TxtCode.CheckedItems.Count <= 0)
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_checkip"));
                    return;
                }

        
                btnOk.Enabled = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.JW2_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, this.cmbServer.Text);

           

                mContent[1].eName = CEnum.TagName.JW2_ServerName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = serverIP;

          

                mContent[2].eName = CEnum.TagName.UserByID;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());



                if (this.comboBox1.Text.ToString() ==config.ReadConfigValue("MJW2", "NEW_UI_ExperienceMultiple"))
                {
                    if (int.Parse(NumMinnute.Value.ToString()) == 2)
                    {


                        mContent[3].eName = CEnum.TagName.JW2_Exp;
                        mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[3].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 1)
                    {


                        mContent[3].eName = CEnum.TagName.JW2_Exp;
                        mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[3].oContent = int.Parse(NumMinnute.Value.ToString());
                    }

                    else if (int.Parse(NumMinnute.Value.ToString()) ==3)
                    {


                        mContent[3].eName = CEnum.TagName.JW2_Exp;
                        mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[3].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 4)
                    {


                        mContent[3].eName = CEnum.TagName.JW2_Exp;
                        mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[3].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 5)
                    {


                        mContent[3].eName = CEnum.TagName.JW2_Exp;
                        mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[3].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 6)
                    {


                        mContent[3].eName = CEnum.TagName.JW2_Exp;
                        mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[3].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 7)
                    {


                        mContent[3].eName = CEnum.TagName.JW2_Exp;
                        mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[3].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 8)
                    {


                        mContent[3].eName = CEnum.TagName.JW2_Exp;
                        mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[3].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 9)
                    {


                        mContent[3].eName = CEnum.TagName.JW2_Exp;
                        mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[3].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 10)
                    {


                        mContent[3].eName = CEnum.TagName.JW2_Exp;
                        mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[3].oContent = int.Parse(NumMinnute.Value.ToString());
                    }


                    mContent[4].eName = CEnum.TagName.JW2_Money;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent =0;

                    mContent[5].eName = CEnum.TagName.JW2_Type;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = 1;

                    this.backgroundWorkAdd.RunWorkerAsync(mContent);
                }

                else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_MoneyMultple"))
                {

                    mContent[3].eName = CEnum.TagName.JW2_Exp;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = 0;

                    if (int.Parse(NumMinnute.Value.ToString()) == 2)
                    {

                        mContent[4].eName = CEnum.TagName.JW2_Money;
                        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[4].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 1)
                    {

                        mContent[4].eName = CEnum.TagName.JW2_Money;
                        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[4].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 3)
                    {

                        mContent[4].eName = CEnum.TagName.JW2_Money;
                        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[4].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 4)
                    {

                        mContent[4].eName = CEnum.TagName.JW2_Money;
                        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[4].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 5)
                    {

                        mContent[4].eName = CEnum.TagName.JW2_Money;
                        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[4].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 6)
                    {

                        mContent[4].eName = CEnum.TagName.JW2_Money;
                        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[4].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 7)
                    {

                        mContent[4].eName = CEnum.TagName.JW2_Money;
                        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[4].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 8)
                    {

                        mContent[4].eName = CEnum.TagName.JW2_Money;
                        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[4].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 9)
                    {

                        mContent[4].eName = CEnum.TagName.JW2_Money;
                        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[4].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 10)
                    {

                        mContent[4].eName = CEnum.TagName.JW2_Money;
                        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[4].oContent = int.Parse(NumMinnute.Value.ToString());
                    }

                    mContent[5].eName = CEnum.TagName.JW2_Type;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent =0;



                    this.backgroundWorkAdd.RunWorkerAsync(mContent);
                }
                else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_ExperienceMoneyMultple"))
                {
                    mContent[3].eName = CEnum.TagName.JW2_Exp;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(NumMinnute.Value.ToString());

                    if (int.Parse(NumMinnute.Value.ToString()) == 2)
                    {

                        mContent[4].eName = CEnum.TagName.JW2_Money;
                        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[4].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 1)
                    {

                        mContent[4].eName = CEnum.TagName.JW2_Money;
                        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[4].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 3)
                    {

                        mContent[4].eName = CEnum.TagName.JW2_Money;
                        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[4].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 4)
                    {

                        mContent[4].eName = CEnum.TagName.JW2_Money;
                        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[4].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 5)
                    {

                        mContent[4].eName = CEnum.TagName.JW2_Money;
                        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[4].oContent = int.Parse(NumMinnute.Value.ToString());

                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 6)
                    {

                        mContent[4].eName = CEnum.TagName.JW2_Money;
                        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[4].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 7)
                    {

                        mContent[4].eName = CEnum.TagName.JW2_Money;
                        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[4].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 8)
                    {

                        mContent[4].eName = CEnum.TagName.JW2_Money;
                        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[4].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 9)
                    {

                        mContent[4].eName = CEnum.TagName.JW2_Money;
                        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[4].oContent = int.Parse(NumMinnute.Value.ToString());
                    }
                    else if (int.Parse(NumMinnute.Value.ToString()) == 10)
                    {

                        mContent[4].eName = CEnum.TagName.JW2_Money;
                        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[4].oContent = int.Parse(NumMinnute.Value.ToString());
                    }

                    mContent[5].eName = CEnum.TagName.JW2_Type;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent =2;

                    this.backgroundWorkAdd.RunWorkerAsync(mContent);
                }
               
            }
            catch
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_DoubleipErr"));
            }

        }
        #endregion


        /// <summary>
        /// 恢复默认值
        /// </summary>
        private void Setdefault()
        {   
          
            NumMinnute.Value = 10;
         
            for (int i = 0; i < TxtCode.Items.Count; i++)
            {
                TxtCode.SetItemChecked(i, false);

            }

        }
        /// <summary>
        /// 返回用","分割的服务器ip字符串
        /// </summary>
        /// <returns>ip字符串</returns>
        private ArrayList ReturnSeverip()
        {
            ArrayList ServerNames = new ArrayList();
            ArrayList Serverips = new ArrayList();
            string Strseverip = null;

            for (int i = 0; i < TxtCode.CheckedItems.Count; i++)
            {

                ServerNames.Add(TxtCode.CheckedItems[i].ToString());

            }
            for (int i = 0; i < ServerNames.Count; i++)
            {
                Serverips.Add(Operation_JW2.GetItemAddr(mChannelInfo, ServerNames[i].ToString()));
            }


            return Serverips;
        }

        #region
        private void FrmSdoNotice_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            GetChannelList();
            this.comboBox1.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_ExperienceMultiple"));
            this.comboBox1.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_MoneyMultple"));
            this.comboBox1.Items.Add(config.ReadConfigValue("MJW2", "NEW_UI_ExperienceMoneyMultple"));
            this.comboBox1.SelectedIndex = 0;

        }
        #endregion

        #region
        private ArrayList ChannelIndex(string[] ChannelValue)
        {
            ArrayList channel = new ArrayList();
            for (int i = 0; i < ChannelValue.Length; i++)
            {
                int chIndex = this.TxtCode.Items.IndexOf(ChannelValue[i]);
                channel.Add(chIndex);
            }

            return channel;
        }
        #endregion

        #region
        private void CheckedTxt(int itemindex)
        {
            for (int i = 0; i < TxtCode.Items.Count; i++)
            {
                TxtCode.SetItemChecked(i, false);

            }

            for (int i = 0; i < TxtCode.Items.Count; i++)
            {

               if (i == itemindex)
                  {
                     TxtCode.SetItemChecked(i, true);
                  }

            }
        }
        #endregion

        #region
        private void button2_Click(object sender, EventArgs e)
        {
            if (ischeck == true)
            {
                for (int i = 0; i < TxtCode.Items.Count; i++)
                {
                    TxtCode.SetItemChecked(i, false);

                }
                ischeck = false;
            }
            else if (ischeck == false)
            {
                for (int i = 0; i < TxtCode.Items.Count; i++)
                {
                    TxtCode.SetItemChecked(i, true);
                }
                ischeck = true;
            }

        }
        #endregion

        #region
        private int ReturnStauas(string strStauas)
        {
           int IntStauas = -1;
            if( strStauas == config.ReadConfigValue("MSDO", "FN_Code_infostate1").Trim())
            {
                IntStauas = 0;
            }
            else if(strStauas == config.ReadConfigValue("MSDO", "FN_Code_infostate2").Trim())
            {
                IntStauas = 2;
            }
            else if (strStauas == config.ReadConfigValue("MSDO", "FN_Code_infostate").Trim())
            {
                IntStauas = 1;
            }

            return IntStauas;
        }
        #endregion


        #region
        private string ReturnStauas(int intStauas)
        {
            string Stauas = null;
            switch (intStauas)
            {
                case 0:
                    Stauas = config.ReadConfigValue("MSDO", "FN_Code_infostate1");
                    break;
                case 2 :
                    Stauas = config.ReadConfigValue("MSDO", "FN_Code_infostate2");
                    break;
                case 1:
                    Stauas = config.ReadConfigValue("MSDO", "FN_Code_infostate");
                    break;
            }
            return Stauas;
        }
        #endregion

        #region
        private void button1_Click(object sender, EventArgs e)
        {
       
            for (int i = 0; i < TxtCode.Items.Count; i++)
            {
                TxtCode.SetItemChecked(i, false);

            }
        }
        #endregion

        #region
        private void backgroundWorkAdd_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_ChangeServerExp_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
        private void backgroundWorkAdd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnOk.Enabled = true;
            try
            {
               this.Cursor = Cursors.Default;//改变鼠标状态
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
              if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                    streamWriter.Flush();
                    fs.Close();
                   
                    //Operation_JW2.errLog.WriteLog(mResult[0, 0].oContent.ToString());
                    return;
                }
                else if (mResult[0, 0].oContent.ToString() == "SCUESS")
                {
                    MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_ExperienceMoneyMultpleSetSuccess"));
                    FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                    streamWriter.Flush();
                    fs.Close();
                    //Operation_JW2.errLog.WriteLog("设置经验倍数成功");
                    return;
                }
                else
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\errLog\\log.txt", FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + mResult[0, 0].oContent.ToString());
                    streamWriter.Flush();
                    fs.Close();
                    //Operation_JW2.errLog.WriteLog(mResult[0, 0].oContent.ToString());
                }

                GetChannelList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //Operation_JW2.errLog.WriteLog(mResult[0, 0].oContent.ToString());
            }
        }
        #endregion

        #region
        private string CheckIP(string strip)
        {
            try
            {
                bool isadd = false;
                System.Net.IPAddress ipAddress = System.Net.IPAddress.Parse(strip);
                isadd = strip.StartsWith("192.168.");
                if (isadd)
                {
                    return strip = "";
                }
                else
                {
                    return strip;
                }
            }
            catch
            {
                return strip = "";
            }
        }
        #endregion

        #region
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_ExperienceMultiple"))
            {
                label5.Text = config.ReadConfigValue("MJW2", "NEW_UI_ExperienceMultiple");
            }
            else if (this.comboBox1.Text.ToString() == config.ReadConfigValue("MJW2", "NEW_UI_MoneyMultple"))
            {
                label5.Text = config.ReadConfigValue("MJW2", "NEW_UI_MoneyMultple");
            }   

        }
        #endregion

        #region
        private void cmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                TxtCode.Items.Clear();

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];
            mContent[0].eName = CEnum.TagName.JW2_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text);

            this.backgroundWorkerGSServer.RunWorkerAsync(mContent);
        }
        catch (System.Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
        #endregion

        #region
    private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mServerInfo = Operation_JW2.GetServerList(this.m_ClientEvent, (CEnum.Message_Body[])e.Argument);
            }
        }
    #endregion

        #region
        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmbServer = Operation_JW2.BuildCombox(mServerInfo, cmbServer);
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_JW2.GetItemAddr(mServerInfo, cmbServer.Text));
        }
        #endregion

        #region
        private void backgroundWorkerGSServer_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_GSSvererList_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
        private void backgroundWorkerGSServer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           mChannelInfo = (CEnum.Message_Body[,])e.Result;
            if (mChannelInfo[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mChannelInfo[0, 0].oContent.ToString());
                return;
            }

            for (int i = 0; i < mChannelInfo.GetLength(0); i++)
            {
                TxtCode.Items.Add(mChannelInfo[i, 1].oContent.ToString());
            }
        }
        #endregion

        #region
        private void backgroundWorkDel_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.JW2_ChangeServerMoney_Query, (CEnum.Message_Body[])e.Argument);
            }
        }
        #endregion

        #region
        private void backgroundWorkDel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnOk.Enabled = true;
            try
            {
           
                this.Cursor = Cursors.Default;//改变鼠标状态
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                else if (mResult[0, 0].oContent.ToString() == "SCUESS")
                {
                    MessageBox.Show(config.ReadConfigValue("MJW2", "NEW_UI_ControlSuccess"));

                    return;
                }
                else
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
    }
}