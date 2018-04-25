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
    [C_Global.CModuleAttribute("Notes已处理信息查看", "NotesToMe", "管理Notes信息", "User Group")]
    public partial class NotesToMe : Form
    {
        public NotesToMe()
        {
            InitializeComponent();
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

        #region 自定义函数

        /// <summary>
        /// 将返回数据转装成DataTable
        /// </summary>
        /// <returns></returns>
        private System.Data.DataTable BrowseResultInfo()
        {
            System.Data.DataTable dgTable = new System.Data.DataTable();
            try
            {
                dgTable.Columns.Clear();       //清空头信息
                dgTable.Rows.Clear();          //清空行记录

                dgTable.Columns.Add(config.ReadConfigValue("MGM", "NTM_Code_Sender"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MGM", "NTM_Code_Reciver"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MGM", "NTM_Code_Object"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MGM", "NTM_Code_Content"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MGM", "NTM_Code_SendDate"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MGM", "NTM_Code_ProcessDate"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MGM", "NTM_Code_People"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MGM", "NTM_Code_Description"), typeof(string));

                for (int i = 0; i < mResult.GetLength(0); i++)
                {
                    System.Data.DataRow dgRow = dgTable.NewRow();

                    dgRow[config.ReadConfigValue("MGM", "NTM_Code_Sender")] = mResult[i, 1].oContent.ToString();
                    dgRow[config.ReadConfigValue("MGM", "NTM_Code_Reciver")] = mResult[i, 2].oContent.ToString();
                    dgRow[config.ReadConfigValue("MGM", "NTM_Code_Object")] = mResult[i, 3].oContent.ToString();
                    dgRow[config.ReadConfigValue("MGM", "NTM_Code_Content")] = mResult[i, 4].oContent.ToString();
                    dgRow[config.ReadConfigValue("MGM", "NTM_Code_SendDate")] = mResult[i, 5].oContent.ToString();
                    dgRow[config.ReadConfigValue("MGM", "NTM_Code_ProcessDate")] = mResult[i, 6].oContent.ToString();
                    dgRow[config.ReadConfigValue("MGM", "NTM_Code_People")] = mResult[i, 8].oContent.ToString();
                    dgRow[config.ReadConfigValue("MGM", "NTM_Code_Description")] = mResult[i, 9].oContent.ToString();

                    dgTable.Rows.Add(dgRow);
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            return dgTable;
        }

        public void InitializeMyListView()
        {

            try
            {
                //获取记录集
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.Index;
                messageBody[0].oContent = pageIndex;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.PageSize;
                messageBody[1].oContent = pageSize;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                this.mResult = this.m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.NOTES_LETTER_TRANSMIT, C_Global.CEnum.Msg_Category.NOTES_ADMIN, messageBody);



                if (mResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    dpPage.Visible = false;
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    
                    return;
                }


                dpPage.Visible = true;
                pageCount = int.Parse(mResult[0, 10].oContent.ToString());
                lblPageCount.Text = Convert.ToString(pageCount);
                lblCurrPage.Text = Convert.ToString(currPage + 1);
                if (cbxToPage.Items.Count == 0)
                {
                    for (int i = 1; i <= pageCount; i++)
                    {
                        cbxToPage.Items.Add(i);
                    }
                    cbxToPage.SelectedIndex = 0;
                }

                dataGrid.DataSource = BrowseResultInfo();
                
                //this.LstView = GMAdmin.DisplayView(this.m_ClientEvent, this.LstView, this.mResult,true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion


        #region 变量
        private CSocketEvent m_ClientEvent = null;

        private C_Global.CEnum.Message_Body[,] mResult = null;

        private int pageIndex = 1;  //发送给服务器的开始条数
        private int pageSize = 20;   //每页显示条数
        private int pageCount = 1;  //总页数
        private int currPage = 0;   //当前页数


        #endregion

        private void NotesToMe_Load(object sender, EventArgs e)
        {
            dpPage.Visible = false;
            cbxToPage.Items.Clear();
            InitializeMyListView();
        }

        private void cbxToPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            currPage = int.Parse(cbxToPage.Text) - 1;
            pageIndex = (currPage) * pageSize + 1;

            InitializeMyListView();
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //要处理的的notes所在行
                int selectIndex = e.RowIndex;
                //要处理的notes的id
                //int notesID = int.Parse(this.LstView.Items[selectIndex].Tag.ToString());

                string notesTitle = mResult[selectIndex, 3].oContent.ToString();
                string notesContent = mResult[selectIndex, 4].oContent.ToString();
                string notesProcesser = mResult[selectIndex, 8].oContent.ToString();
                string notesProcessDate = mResult[selectIndex, 6].oContent.ToString();
                string notesProcessContent = mResult[selectIndex, 9].oContent.ToString();

                int xPos = MousePosition.X;
                int yPos = MousePosition.Y;

                //if (isOpenPInfoWindow)
                //{
                //notesProcessInfoClone.Close();    
                //}

                NoteProcessInfo notesProcessInfo = new NoteProcessInfo(notesTitle, notesContent, notesProcesser, notesProcessDate, notesProcessContent, xPos, yPos,config);
                //notesProcessInfoClone = notesProcessInfo;

                notesProcessInfo.NotesTitle = notesTitle;
                notesProcessInfo.NotesContent = notesContent;
                notesProcessInfo.NotesProcesser = notesProcesser;
                notesProcessInfo.NotesProcessDate = notesProcessDate;
                notesProcessInfo.NotesProcessContent = notesProcessContent;
                notesProcessInfo.XPos = xPos;
                notesProcessInfo.YPos = yPos;
                notesProcessInfo.ShowDialog();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
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
            this.Text = config.ReadConfigValue("MGM", "NTM_UI_Caption");
            this.lblText.Text = config.ReadConfigValue("MGM", "NTM_UI_ToPage");

        }


        #endregion


    }
}