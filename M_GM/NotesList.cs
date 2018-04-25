using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using C_Global;
using C_Event;

using Language;

namespace M_GM
{
	/// <summary>
	/// NotesList 的摘要说明。
	/// </summary>
	[C_Global.CModuleAttribute("Notes管理", "NotesList", "管理Notes信息", "User Group")]
	public class NotesList : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ColumnHeader columnName;
		private System.Windows.Forms.ColumnHeader columnFullName;
        private System.Windows.Forms.ColumnHeader columnDescription;

		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
        private DividerPanel.DividerPanel dpPage;
        private DividerPanel.DividerPanel dividerPanel2;
        private DividerPanel.DividerPanel dividerPanel3;
        private Label label1;
        private Label lblCurrPage;
        private Label lblPageCount;
        private DataGridView dataGrid;
        private ComboBox cbxToPage;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem ToolStripMenuItem;
        private IContainer components;

		public NotesList()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		public NotesList(CSocketEvent clientEvent)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			this.m_ClientEvent = clientEvent;
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.columnName = new System.Windows.Forms.ColumnHeader();
            this.columnFullName = new System.Windows.Forms.ColumnHeader();
            this.columnDescription = new System.Windows.Forms.ColumnHeader();
            this.dpPage = new DividerPanel.DividerPanel();
            this.cbxToPage = new System.Windows.Forms.ComboBox();
            this.lblCurrPage = new System.Windows.Forms.Label();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.dividerPanel3 = new DividerPanel.DividerPanel();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dpPage.SuspendLayout();
            this.dividerPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dpPage
            // 
            this.dpPage.AllowDrop = true;
            this.dpPage.Controls.Add(this.cbxToPage);
            this.dpPage.Controls.Add(this.lblCurrPage);
            this.dpPage.Controls.Add(this.lblPageCount);
            this.dpPage.Controls.Add(this.label1);
            this.dpPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.dpPage.Location = new System.Drawing.Point(10, 10);
            this.dpPage.Name = "dividerPanel1";
            this.dpPage.Size = new System.Drawing.Size(629, 38);
            this.dpPage.TabIndex = 2;
            // 
            // cbxToPage
            // 
            this.cbxToPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxToPage.FormattingEnabled = true;
            this.cbxToPage.Location = new System.Drawing.Point(170, 10);
            this.cbxToPage.Name = "cbxToPage";
            this.cbxToPage.Size = new System.Drawing.Size(67, 20);
            this.cbxToPage.TabIndex = 10;
            this.cbxToPage.SelectedIndexChanged += new System.EventHandler(this.cbxToPage_SelectedIndexChanged);
            // 
            // lblCurrPage
            // 
            this.lblCurrPage.AutoSize = true;
            this.lblCurrPage.ForeColor = System.Drawing.Color.Red;
            this.lblCurrPage.Location = new System.Drawing.Point(108, 13);
            this.lblCurrPage.Name = "lblCurrPage";
            this.lblCurrPage.Size = new System.Drawing.Size(11, 12);
            this.lblCurrPage.TabIndex = 9;
            this.lblCurrPage.Text = "1";
            // 
            // lblPageCount
            // 
            this.lblPageCount.AutoSize = true;
            this.lblPageCount.ForeColor = System.Drawing.Color.Red;
            this.lblPageCount.Location = new System.Drawing.Point(33, 13);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(11, 12);
            this.lblPageCount.TabIndex = 8;
            this.lblPageCount.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "共   页,当前第    页,转到　　　　　　页";
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 48);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(629, 10);
            this.dividerPanel2.TabIndex = 3;
            // 
            // dividerPanel3
            // 
            this.dividerPanel3.AllowDrop = true;
            this.dividerPanel3.Controls.Add(this.dataGrid);
            this.dividerPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel3.Location = new System.Drawing.Point(10, 58);
            this.dividerPanel3.Name = "dividerPanel3";
            this.dividerPanel3.Padding = new System.Windows.Forms.Padding(2);
            this.dividerPanel3.Size = new System.Drawing.Size(629, 335);
            this.dividerPanel3.TabIndex = 4;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(2, 2);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowTemplate.Height = 23;
            this.dataGrid.Size = new System.Drawing.Size(625, 331);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(110, 26);
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.ToolStripMenuItem.Text = "处理";
            this.ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // NotesList
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(649, 403);
            this.Controls.Add(this.dividerPanel3);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dpPage);
            this.Name = "NotesList";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Notes列表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.NotesList_Load);
            this.dpPage.ResumeLayout(false);
            this.dpPage.PerformLayout();
            this.dividerPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

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
			NotesList mNodesFrm = new NotesList();
			mNodesFrm.m_ClientEvent = (CSocketEvent)oEvent;

			if (oParent != null)
			{
				mNodesFrm.MdiParent = (Form)oParent;
				mNodesFrm.Show();
			}
			else
			{
				mNodesFrm.ShowDialog();
			}

			return this;
			
		}
		#endregion

		#region 事件
		private void NotesList_Load(object sender, System.EventArgs e)
		{
            IntiFontLib();
			InitializeListView();
		}

		/// <summary>
		/// 处理Notes
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			
		}
		#endregion
        
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

                dgTable.Columns.Add(config.ReadConfigValue("MGM", "NL_Code_Sender"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MGM", "NL_Code_Reciver"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MGM", "NL_Code_Title"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MGM", "NL_Code_Content"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MGM", "NL_Code_Date"), typeof(DateTime));

                for (int i = 0; i < mResult.GetLength(0); i++)
                {
                    System.Data.DataRow dgRow = dgTable.NewRow();

                    dgRow[config.ReadConfigValue("MGM", "NL_Code_Sender")] = mResult[i, 1].oContent.ToString();
                    dgRow[config.ReadConfigValue("MGM", "NL_Code_Reciver")] = mResult[i, 2].oContent.ToString();
                    dgRow[config.ReadConfigValue("MGM", "NL_Code_Title")] = mResult[i, 3].oContent.ToString();
                    dgRow[config.ReadConfigValue("MGM", "NL_Code_Content")] = mResult[i, 4].oContent.ToString();
                    dgRow[config.ReadConfigValue("MGM", "NL_Code_Date")] = mResult[i, 5].oContent.ToString();
                
                    dgTable.Rows.Add(dgRow);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dgTable;
        }
       
		#region 自定义函数
		/// <summary>
		/// 刷新listview
		/// </summary>
		public void InitializeListView()
		{
			try
			{

                dataGrid.DataSource = null;
				

				C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];
				
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
				messageBody[0].eName = C_Global.CEnum.TagName.Index;
                messageBody[0].oContent = pageIndex;

				messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
				messageBody[1].eName = C_Global.CEnum.TagName.PageSize;
                messageBody[1].oContent = pageSize;

				this.mResult = this.m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.NOTES_LETTER_TRANSFER, C_Global.CEnum.Msg_Category.NOTES_ADMIN, messageBody);

				if (mResult[0,0].eName == C_Global.CEnum.TagName.ERROR_Msg)
				{
                    dpPage.Visible = false;
					MessageBox.Show(mResult[0,0].oContent.ToString());
					return;
				}

                //总页数
                pageCount = int.Parse(mResult[0, 6].oContent.ToString());
                lblPageCount.Text = pageCount.ToString();
                lblCurrPage.Text = Convert.ToString(currPage + 1);


                dpPage.Visible = true;
                if (cbxToPage.Items.Count == 0)
                {
                    for (int i = 1; i <= pageCount; i++)
                    {
                        cbxToPage.Items.Add(i);
                    }
                    cbxToPage.SelectedIndex = 0;
                }

                dataGrid.DataSource = BrowseResultInfo();
			}
			catch(Exception ex)
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
        private int currPage = 0;

        int selectIndex = 0;


        

		#endregion

        private void cbxToPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            currPage = int.Parse(cbxToPage.Text) - 1;
            pageIndex = (currPage) * pageSize + 1;

            InitializeListView();
        }   

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //要处理的的notes所在行
                //int selectIndex = this.dataGrid.SelectedRows[0].Index;
                //要处理的notes的id
                int notesID = int.Parse(mResult[selectIndex,0].oContent.ToString());
                //调用处理窗体
                NotesProcess notesProcess = new NotesProcess(notesID);
                notesProcess.CreateModule(null, m_ClientEvent);
                InitializeListView();
            }
            catch
            {
                MessageBox.Show("请选择要处理的NOTES");
            }
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectIndex = e.RowIndex;

            try
            {
                string notesTitle = mResult[selectIndex, 3].oContent.ToString();
                string notesContent = mResult[selectIndex, 4].oContent.ToString();
                string notesProcesser = "";
                string notesProcessDate = "";
                string notesProcessContent = "";

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
                notesProcessInfo.NotesProcesser = "";
                notesProcessInfo.NotesProcessDate = "";
                notesProcessInfo.NotesProcessContent = "";
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
            this.Text = config.ReadConfigValue("MGM", "NL_UI_Caption");


            this.label1.Text = config.ReadConfigValue("MGM", "NL_UI_PageTo");
        }


        #endregion



        

		
	}
}
