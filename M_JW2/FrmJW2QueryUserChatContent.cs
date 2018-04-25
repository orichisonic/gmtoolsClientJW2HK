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
    [C_Global.CModuleAttribute("玩家聊天记录查询", "FrmJW2QueryUserChatContent", "玩家聊天记录查询", "AU Group")] 
    public partial class FrmJW2QueryUserChatContent: Form
    {

        private string result = null;
        private static int index = 0;
        private CEnum.Message_Body[,] mChannelInfo = null;
        private CSocketEvent tmp_ClientEvent = null;
        private CSocketEvent m_ClientEvent = null;
        CEnum.Message_Body[,] GsResult = null;
        private ArrayList paramList = new ArrayList();
        private int iPageCount = 0;
        private int server_index = 0;
        private bool bFirst = false;
        private bool bFirst1 = false;
        //private bool bIsAccount = true;
        private delegate void FillGridDelegate(string[] reader);
        private string sAccount = string.Empty;
        private string sNick = string.Empty;
        private bool ischeck = false;

        string sGsIp = string.Empty;
        string sSrvIp = string.Empty;
        string sServerIp = string.Empty;

        int iAll = 1;
        public FrmJW2QueryUserChatContent()
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
            FrmJW2QueryUserChatContent mModuleFrm = new FrmJW2QueryUserChatContent();
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
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                //e.Result = Operation_Audition.GetResult(m_ClientEvent, CEnum.ServiceKey.Au_User_Msg_Query, (CEnum.Message_Body[])e.Argument);
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
                for (int i = mResult.GetLength(0)-1; i >=0; i--)
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
                //mChannelInfo = Operation_Audition.GetGsServerList(this.m_ClientEvent, mContent);
            }
            if (mChannelInfo[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mChannelInfo[0, 0].oContent.ToString());
                return;
            }

            //this.CmbServer = Operation_Audition.BuildCombox(mChannelInfo, CmbServer);
            bFirst = true;

            //tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_Audition.GetItemAddr(mChannelInfo, CmbServer.Text));

        }
        #endregion

        private void FrmJW2QueryUserChatContent_Load(object sender, EventArgs e)
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

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                //e.Result = Operation_Audition.GetResult(m_ClientEvent, CEnum.ServiceKey.Au_User_Msg_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

                //Operation_Audition.BuildDataTable(this.m_ClientEvent, mResult, this.dataGridView1, out iPageCount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string a = null;
                if (0 == this.listBox1.Items.Count)
                {
                    MessageBox.Show("請選擇資訊！");
                    return;
                }

                for (int i = 0; i < this.listBox1.Items.Count; i++)
                {
                    a += listBox1.Items[i] + "\r\n";
                }

                string strFile = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\" + CmbServer.Text + "_" + "聊天记录_" + DateTime.Now.Ticks.ToString() + ".xls";
                if (!File.Exists(strFile))
                {
                    FileInfo FileInfoCSV = new FileInfo(strFile);
                }
                try
                {
                    using (StreamWriter sw = new StreamWriter(strFile, true, Encoding.UTF8))
                    {
                        sw.WriteLine(a);
                        sw.Flush();
                        sw.Close();
                    }
                }
                catch
                {
                }
                finally
                {
                    MessageBox.Show("導出結束！");
                    this.listBox1.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    string str = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //    //string str = this.dataGridView1.SelectedCells[0].Value.ToString();
            //    if (listBox1.Items.Contains(str))
            //    {
            //        MessageBox.Show("此用户已经存在");
            //    }
            //    else
            //    {
            //        this.listBox1.Items.Add(str);
            //        //listBox1.SelectedIndex = listBox1.Items.Count - 1;
            //    }
            //}
            //catch
            //{ }
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            this.kick_Ban_User();
        }
        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            this.listBox1_DoubleClick(null, null);
        }
        private void menuItem3_Click(object sender, System.EventArgs e)
        {
            this.kick_User();
        }

        private void kick_Ban_User()
        {
            paramList.Clear();
            Cursor = Cursors.AppStarting;
            try
            {
                //ListBox.SelectedObjectCollection objects = this.listBox1.SelectedItems;
                foreach (object item in this.listBox1.SelectedItems)
                {
                    string username = item.ToString();
                    paramList.Add(username);
                }

                if (paramList.Count == 0)
                {
                    MessageBox.Show("請選擇要封停的帳號");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.backgroundWorkerDoLot.RunWorkerAsync();
        }
        private void kick_User()
        {
            paramList.Clear();
            Cursor = Cursors.AppStarting;
            try
            {
                //ListBox.SelectedObjectCollection objects = this.listBox1.SelectedItems;
                foreach (object item in this.listBox1.SelectedItems)
                {
                    string username = item.ToString();
                    paramList.Add(username);
                }

                if (paramList.Count == 0)
                {
                    MessageBox.Show("請選擇要封停的帳號");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.backgroundWorkerDoLot1.RunWorkerAsync();
        }
        private void backgroundWorkerDoLot_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CEnum.Message_Body[,] mResult;
                result = "";
                CEnum.Message_Body[] mContent;

                for (int i = 0; i < paramList.Count; i++)
                {
                    mContent = new CEnum.Message_Body[4];
                    mContent[0].eName = CEnum.TagName.AU_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = mChannelInfo[server_index, 4].oContent;



                    mContent[1].eName = CEnum.TagName.UserByID;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());


                    mContent[2].eName = CEnum.TagName.AU_UserNick;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = paramList[i].ToString();

                    mContent[3].eName = CEnum.TagName.AU_Reason;
                    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[3].oContent = "GM 封停";

                    lock (typeof(C_Event.CSocketEvent))
                    {
                        //mResult = Operation_Audition.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AU_KickPlayerandBan_Req, mContent);
                    }
                    //result += "对[" + paramList[i].ToString() + "]操作结果：" + mResult[0, 0].oContent.ToString() + "\r\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorkerDoLot_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(result);
                listBox1.Items.Clear();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void backgroundWorkerDoLot1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CEnum.Message_Body[,] mResult;
                result = "";
                CEnum.Message_Body[] mContent;

                for (int i = 0; i < paramList.Count; i++)
                {
                    mContent = new CEnum.Message_Body[3];
                    mContent[0].eName = CEnum.TagName.AU_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = mChannelInfo[server_index, 4].oContent;



                    mContent[1].eName = CEnum.TagName.UserByID;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());


                    mContent[2].eName = CEnum.TagName.AU_UserNick;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = paramList[i].ToString();

                    lock (typeof(C_Event.CSocketEvent))
                    {
                        //mResult = Operation_Audition.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AU_KickPlayer_Req, mContent);
                    }
                    //if (mResult[0, 0].oContent.ToString() == "SCUESS")
                    //{
                    //    mResult[0, 0].oContent = "T成功";
                    //}
                    //result += "对[" + paramList[i].ToString() + "]操作结果：" + mResult[0, 0].oContent.ToString() + "\r\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorkerDoLot1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(result);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ArrayList DelUser = new ArrayList();
                foreach (object item in this.listBox1.SelectedItems)
                {
                    string username = item.ToString();
                    DelUser.Add(username);
                }
                for (int i = 0; i < DelUser.Count; i++)
                {
                    this.listBox1.Items.Remove(DelUser[i].ToString());
                }
            }
            catch (Exception ex)
            {
                
            }
            
        }
        /// <summary>
        /// 鼠标右键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                //右键鼠标
                if (e.Button == MouseButtons.Right && e.Clicks == 1)
                {
                    //清楚右键内容
                    this.contextMenu1.MenuItems.Clear();
                    try
                    {
                        int selectIndex = this.listBox1.SelectedIndex;
                        this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                                this.menuItem3,
                                                                                                this.menuItem2});
                    }
                    catch
                    {
                        this.contextMenu1.MenuItems.Add(this.menuItem1);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            foreach (ListBox.SelectedObjectCollection item in this.listBox1.SelectedItems)
            {
                string username = item.ToString();

            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
            }
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
            }
            catch
            { }
        }

        

    }
}