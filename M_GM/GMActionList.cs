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

namespace M_GM
{
    [C_Global.CModuleAttribute("GM操作记录", "GMActionList", "GM操作记录", "User Group")]
    public partial class GMActionList : Form
    {
        public GMActionList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.userID.Text == "" || this.userID.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "LOG_UI_ChooseGM"));
                this.userID.Focus();
                return;
            }

            currPage = 0;
            pageIndex = 1;

            #region 查询GM ID
            for (int i = 0; i < this.GMListResult.GetLength(0); i++)
            {
                if (GMListResult[i, 5].oContent.ToString().Trim().Equals(this.userID.Text.Trim()))
                {
                    this._userID = int.Parse(GMListResult[i, 0].oContent.ToString());
                }
            }
            #endregion

            this.InitializeActionList();
        }

        private void GMActionList_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            InitializeListView();
        }

        #region 自定义函数
        /// <summary>
		/// 初始化ＧＭ帐号列表
		/// </summary>
        public void InitializeListView()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.Index;
                messageBody[0].oContent = 1;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.PageSize;
                messageBody[1].oContent = 20;

                GMListResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.USER_QUERY, C_Global.CEnum.Msg_Category.USER_ADMIN, messageBody);

                //检测状态
                if (GMListResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(GMListResult[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }

                //显示内容到列表
                for (int i = 0; i < GMListResult.GetLength(0); i++)
                {
                    this.userID.Items.Add(GMListResult[i, 5].oContent.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void InitializeActionList()
        {
            try
            {
                //移除上次显示列表
                this.listViewSortOrder.Items.Clear();

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[6];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.User_ID;
                messageBody[1].oContent = _userID;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_DATE;
                messageBody[2].eName = C_Global.CEnum.TagName.BeginTime;
                messageBody[2].oContent = Convert.ToDateTime(this.beginDate.Text);

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_DATE;
                messageBody[3].eName = C_Global.CEnum.TagName.EndTime;
                messageBody[3].oContent = Convert.ToDateTime(this.endDate.Text);

                messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[4].eName = C_Global.CEnum.TagName.PageSize;
                messageBody[4].oContent = pageSize;

                messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[5].eName = C_Global.CEnum.TagName.Index;
                messageBody[5].oContent = pageIndex;

                mResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.GMTOOLS_OperateLog_Query, C_Global.CEnum.Msg_Category.COMMON, messageBody);
                
                //检测状态
                if (mResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }

                //总页数
                pageCount = int.Parse(mResult[0, 5].oContent.ToString());

                //显示内容到列表
                string[] rowInfo = new string[6];


                for (int i = 0; i < mResult.GetLength(0); i++)
                {

                    //行编号
                    rowInfo[0] = Convert.ToString(i + 1);
                    //ＧＭ名称	
                    rowInfo[1] = mResult[i, 0].oContent.ToString();
                    //游戏名称	
                    rowInfo[2] = mResult[i, 1].oContent.ToString();
                    //服务器
                    rowInfo[3] = mResult[i, 2].oContent.ToString();
                    //操作日期
                    rowInfo[4] = mResult[i, 4].oContent.ToString();
                    //操作内容
                    rowInfo[5] = mResult[i, 3].oContent.ToString();
                    ListViewItem mlistViewItem = new ListViewItem(rowInfo, -1);
                    listViewSortOrder.Items.Add(mlistViewItem);
                    //listViewSortOrder.Items[i].Tag = mResult[i, 0].oContent.ToString();

                }


                //listViewAcoount = GMAdmin.DisplayView(m_ClientEvent, listViewAcoount, mResult,true);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        #endregion

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

        #region 变量
        private CSocketEvent m_ClientEvent = null;
        private C_Global.CEnum.Message_Body[,] GMListResult = null;
        private C_Global.CEnum.Message_Body[,] mResult = null;


        private int _userID = 0;

        private int pageIndex = 1;  //发送给服务器的开始条数
        private int pageSize = 30;   //每页显示条数
        private int pageCount = 1;  //总页数
        private int currPage = 0;   //当前页数

        #endregion


        private void ITC_Next_ITC_CLICIK(object sender)
        {
            if (currPage < pageCount-1)
            {
                currPage += 1;
                pageIndex = currPage * pageSize + 1;
                this.InitializeActionList();
            }
        }

        private void ITC_Prev_ITC_CLICIK(object sender)
        {
            if (currPage > 0)
            {
                currPage -= 1;
                pageIndex = currPage * pageSize + 1;
                this.InitializeActionList();
            }
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
            this.Text = config.ReadConfigValue("MGM", "LOG_UI_Caption");


            this.label2.Text = config.ReadConfigValue("MGM", "LOG_UI_BeginDate");
            this.label4.Text = config.ReadConfigValue("MGM", "LOG_UI_EndDate");
            this.label1.Text = config.ReadConfigValue("MGM", "LOG_UI_Account");
            this.button1.Text = config.ReadConfigValue("MGM", "LOG_UI_BtnView");
            this.ITC_Prev.ITXT_TEXT = config.ReadConfigValue("MGM", "LOG_UI_ITC_PrevPage");
            this.ITC_Next.ITXT_TEXT = config.ReadConfigValue("MGM", "LOG_UI_ITC_NextPage");

            this.id.Text = config.ReadConfigValue("MGM", "LOG_UI_LV_ID");
            this.account.Text = config.ReadConfigValue("MGM", "LOG_UI_LV_Name");
            this.columnHeader1.Text = config.ReadConfigValue("MGM", "LOG_UI_LV_Game");
            this.char_name.Text = config.ReadConfigValue("MGM", "LOG_UI_LV_Server");
            this.type_id.Text = config.ReadConfigValue("MGM", "LOG_UI_LV_Date");
            this.level.Text = config.ReadConfigValue("MGM", "LOG_UI_LV_Content");
        }


        #endregion
    }
}