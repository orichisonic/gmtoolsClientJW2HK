using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using C_Controls.LabelTextBox;
using C_Global;
using C_Event;
using Language;


using System.IO;
namespace M_JW2
{
    [C_Global.CModuleAttribute("玩家登陆房间信息及聊天记录查询", "FrmJW2QueryUserRoomChat", "玩家登陆房间信息及聊天记录查询", "JW2 Group")] 
    public partial class FrmJW2QueryUserRoomChat : Form
    {

        private CSocketEvent tmp_ClientEvent = null;
        private CSocketEvent m_ClientEvent = null;
        
        private int iPageCount = 0;
        private bool bFirst1 = false;
        private bool bFirst2 = false;
        private bool bIsAccount = true;
        private string sAccount = string.Empty;
        private string sNick = string.Empty;
        private static int index = 0;
        private int server_index = 0;
        private CEnum.Message_Body[,] mChannelInfo = null;
        private delegate void FillGridDelegate(string[] reader);
        private bool bFirst = false;

        public FrmJW2QueryUserRoomChat()
        {
            InitializeComponent();
        }

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
            //this.Text = config.ReadConfigValue("MAU", "FSC_UI_Frm_Shop_CardList ");
        }


        #endregion

        #region 创建窗体
        /// <summary>
        /// 创建类库中的窗体
        /// </summary>
        /// <param name="oParent">MDI 程序的父窗体</param>
        /// <param name="oSocket">Socket</param>
        /// <returns>类库中的窗体</returns>
        public Form CreateModule(object oParent, object oEvent)
        {
            //创建登录窗体
            FrmJW2QueryUserRoomChat mModuleFrm = new FrmJW2QueryUserRoomChat();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            index = 0;
            listView1.Items.Clear();
            server_index = CmbServer.SelectedIndex;
            this.BtnSearch.Enabled = false;
            this.Cursor = Cursors.AppStarting;
            getMsgResult(0);
            listView1.ListViewItemSorter = new MonkeyListViewItemComparer(); 
        }

        class MonkeyListViewItemComparer : IComparer
        {
            private int col;

            public MonkeyListViewItemComparer()
            {
                this.col = 0;
            }

            public MonkeyListViewItemComparer(int col)
            {
                this.col = col;
            }

            public int Compare(object x, object y)
            {
                int a = int.Parse(((ListViewItem)y).SubItems[col].Text);
                return a.CompareTo(int.Parse(((ListViewItem)x).SubItems[col].Text));
            }
        }

        private void getMsgResult(int count)
        {
            try
            {

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.AU_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                //mContent[0].oContent = Operation_Shop.GetAu_ServerIp(mChannelInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.AU_GSServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                //mContent[1].oContent = Operation_Shop.GetAu_GsIp(mChannelInfo, CmbServer.Text);

                mContent[2].eName = CEnum.TagName.AuShop_ItemTable;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                //mContent[2].oContent = Operation_Shop.GetAu_ItemTable(mChannelInfo, CmbServer.Text);

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = 200;

                mContent[5].eName = CEnum.TagName.AU_ItemID;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = count;

                this.backgroundWorker1.RunWorkerAsync(mContent);
            }
            catch
            {

            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_JW2.GetResult(m_ClientEvent, CEnum.ServiceKey.Au_User_Msg_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.BtnSearch.Enabled = true;//查询按钮使能
                this.Cursor = Cursors.Default;//改变鼠标状态
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                for (int i = mResult.GetLength(0) - 1; i >= 0; i--)
                {
                    index++;
                    string[] ListResult ={
                                            mResult[i,0].oContent.ToString(),
                                            mResult[i,1].oContent.ToString(),
                                            mResult[i,2].oContent.ToString(),
                                            mResult[i,3].oContent.ToString(),
                                            mResult[i,4].oContent.ToString(),
                                            mResult[i,5].oContent.ToString()
                                            };
                    ThreadPool.QueueUserWorkItem(new WaitCallback(RealTimeProcessing), ListResult);
                    Thread.Sleep(20);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region 处理方法
        private void RealTimeProcessing(object state)
        {
            try
            {
                FillGridDelegate del = new FillGridDelegate(Test);
                this.Invoke(del, state);
                Thread.Sleep(20);
                //Operation_Audition.BuildDataTable(this.m_ClientEvent, mResult, this.dataGridView1, out iPageCount);
            }
            catch (Exception ex)
            { }
        }
        private void Test(string[] reader)
        {
            try
            {
                if (listView1.Items.Count >= 5000)
                {
                    listView1.Items.Clear();
                }
                ListViewItem aa = new ListViewItem(reader);
                this.listView1.Items.Insert(0, aa);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        private void FrmJW2QueryUserRoomChat_Load(object sender, EventArgs e)
        {
            try
            {
                this.listView1.Columns.Add("序號");
                this.listView1.Columns.Add("頻道", 100);
                this.listView1.Columns.Add("用戶名", 150);
                this.listView1.Columns.Add("聊天類型", 100);
                this.listView1.Columns.Add("內容", 250);
                this.listView1.Columns.Add("時間", 120);

                IntiFontLib();
                GetChannelList();
                this.timer1.Enabled = false;
            }
            catch
            { }
        }

        #region 请求频道名称
        /// <summary>
        /// 请求频道名称
        /// </summary>
        private void GetChannelList()
        {

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];

            mContent[0].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 1;

            lock (typeof(C_Event.CSocketEvent))
            {
                mChannelInfo = Operation_JW2.GetGsServerList(this.m_ClientEvent, mContent);
            }
            if (mChannelInfo[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mChannelInfo[0, 0].oContent.ToString());
                return;
            }

            this.CmbServer = Operation_JW2.BuildCombox(mChannelInfo, CmbServer);
            bFirst = true;

            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_JW2.GetItemAddr(mChannelInfo, CmbServer.Text));

        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                getMsgResult(int.Parse(listView1.Items[0].Text.ToString()));
                listView1.ListViewItemSorter = new MonkeyListViewItemComparer();
            }
            catch
            { }
        }

        private void backgroundWorkerDoLot_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorkerDoLot_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void backgroundWorkerDoLot1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorkerDoLot1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            try
            {
                string strContent = listView1.SelectedItems[0].SubItems[2].Text;
                Clipboard.SetDataObject(strContent, true);
            }
            catch
            { }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            listView1.ListViewItemSorter = new MonkeyListViewItemComparer();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string a = listView1.SelectedItems[0].SubItems[2].Text;
                if (listBox1.Items.Contains(a))
                {
                    MessageBox.Show("此用戶已經存在");
                }
                else
                {
                    this.listBox1.Items.Add(a);
                }

                //BrowseMusicName browseMusicName = new BrowseMusicName(int.Parse(dgInfoList[e.ColumnIndex, e.RowIndex].Value.ToString()), _ServerIP, MousePosition.X, MousePosition.Y);
                //browseMusicName.CreateModule(null, m_ClientEvent);
            }
            catch
            { }
        }

    }
}