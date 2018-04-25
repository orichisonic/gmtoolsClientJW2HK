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
    /// <summary>
    /// 编辑还是创建部门
    /// </summary>
    enum DepartAction
    {
        newDepart,
        modiDepart
    }

    [C_Global.CModuleAttribute("部门管理", "NewDepartment", "部门管理", "User Group")]
    public partial class NewDepartment : Form
    {
        public NewDepartment()
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

        #region 变量
        private CSocketEvent m_ClientEvent = null;

        private C_Global.CEnum.Message_Body[,] departmentsResult = null;    //部门列表
        private C_Global.CEnum.Message_Body[,] gameListsResult = null;       //游戏列表
        private C_Global.CEnum.Message_Body[,] roleResult = null;       //权限

        private C_Global.CEnum.Message_Body[,] createResult = null;       //游戏列表
        private C_Global.CEnum.Message_Body[,] delResult = null;       //游戏列表


        DataTable dgTable = new DataTable();

        int selectDepartRow = -1;   //选择的部门

        string gameRoles = null;    //部门所拥有的游戏权限　format:1,2,3,4

        int selectDepartID = 0;       //当前选中的部门ｉｄ

        DepartAction dAction = DepartAction.newDepart;  //定位当前操作（添加／修改）

        #endregion

        #region 函数
        /// <summary>
        /// 获取部门信息列表
        /// </summary>
        private void GetDepartmentList()
        {
            //部门
            departmentsResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.DEPART_QUERY, C_Global.CEnum.Msg_Category.USER_ADMIN, null);

            dgDepartList.DataSource = BrowseDepartResultInfo();
        }

        /// <summary>
        /// 获取部门权限
        /// </summary>
        private void GetDepartmentRoles(int deptID)
        {
            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[1];
            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[0].eName = C_Global.CEnum.TagName.DepartID;
            messageBody[0].oContent = deptID;

            roleResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.DEPARTMENT_RELATE_QUERY, C_Global.CEnum.Msg_Category.USER_ADMIN, messageBody);
        }

        /// <summary>
        /// 获取游戏列表
        /// </summary>
        private void GetGameList()
        {
            //获取游戏列表
            gameListsResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.GAME_QUERY, C_Global.CEnum.Msg_Category.GAME_ADMIN, null);
        }

        /// <summary>
        /// 将返回数据转装成DataTable
        /// </summary>
        /// <returns></returns>
        private DataTable BrowseDepartResultInfo()
        {
            dgTable.Columns.Clear();       //清空头信息
            dgTable.Rows.Clear();          //清空行记录
            dgTable.Columns.Add(config.ReadConfigValue("MGM", "ND_Code_DeaprtName"), typeof(string));

            for (int i = 0; i < departmentsResult.GetLength(0); i++)
            {
                DataRow dgRow = dgTable.NewRow();
                dgRow[config.ReadConfigValue("MGM", "ND_Code_DeaprtName")] = departmentsResult[i, 1].oContent.ToString();
                dgTable.Rows.Add(dgRow);
            }
            return dgTable;
        }


        /// <summary>
        /// 游戏列表
        /// </summary>
        private void InitializeGameList()
        {
            lstGameRole.Items.Clear();

            //获取部门游戏权限
            if (dAction == DepartAction.modiDepart)
            {
                int selectDepartID = int.Parse(departmentsResult[selectDepartRow, 0].oContent.ToString());
                GetDepartmentRoles(selectDepartID);
            }


            ListViewItem listViewItem;
            
            try
            {
                for (int i = 0; i < gameListsResult.GetLength(0); i++)
                {
                    //当前游戏id
                    int currGameID = int.Parse(gameListsResult[i, 0].oContent.ToString());
                    //当前游戏名称
                    string currGameName = gameListsResult[i, 1].oContent.ToString();

                    listViewItem = new ListViewItem(currGameName, -1);
                    this.lstGameRole.Items.Add(listViewItem);
                    this.lstGameRole.Items[i].Tag = currGameID;

                    /*
                     * 检测部门是否拥有权限，有则选中
                     * 
                     * 获取当前选中修改的部门的现有权限
                     * 将所获得部门权限与当前的游戏ｉｄ作比较
                     * */
                    if (dAction == DepartAction.modiDepart)
                    {
                        if (roleResult[0, 0].eName != CEnum.TagName.ERROR_Msg)
                        {
                            for (int j = 0; j < roleResult.GetLength(0); j++)
                            {
                                if (currGameID == int.Parse(roleResult[j, 0].oContent.ToString()))
                                {
                                    this.lstGameRole.Items[i].Checked = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        /// <summary>
        /// 添加部门
        /// </summary>
        private void AddNewDepart()
        {
            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];
            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
            messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[1].eName = C_Global.CEnum.TagName.DepartName;
            messageBody[1].oContent = txtDeptName.Text;

            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[2].eName = C_Global.CEnum.TagName.DepartRemark;
            messageBody[2].oContent = txtRemark.Text;

            messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[3].eName = C_Global.CEnum.TagName.GameContent;
            messageBody[3].oContent = gameRoles;



            createResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.DEPARTMENT_CREATE, C_Global.CEnum.Msg_Category.USER_ADMIN, messageBody);

            if (createResult[0, 0].oContent.Equals("FAILURE"))
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "ND_Code_CreatFailed"));
                return;
            }

            if (createResult[0, 0].oContent.Equals("SUCESS"))
            {
                GetDepartmentList();
                dpSet.Visible = false;
                dpVerticalLine.Visible = false;
                MessageBox.Show(config.ReadConfigValue("MGM", "ND_Code_CreatSucceed"));
                return;
            }
        }

        /// <summary>
        /// 修改部门信息
        /// </summary>
        private void ModiDepart()
        {
            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[5];
            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
            messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[1].eName = C_Global.CEnum.TagName.DepartName;
            messageBody[1].oContent = txtDeptName.Text;

            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[2].eName = C_Global.CEnum.TagName.DepartRemark;
            messageBody[2].oContent = txtRemark.Text;

            messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[3].eName = C_Global.CEnum.TagName.GameContent;
            messageBody[3].oContent = gameRoles;

            messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[4].eName = C_Global.CEnum.TagName.DepartID;
            messageBody[4].oContent = selectDepartID;



            createResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.DEPARTMENT_UPDATE, C_Global.CEnum.Msg_Category.USER_ADMIN, messageBody);

            if (createResult[0, 0].oContent.Equals("FAILURE"))
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "ND_Code_ModiFailed"));
                return;
            }

            if (createResult[0, 0].oContent.Equals("SUCESS"))
            {
                GetDepartmentList();
                dpSet.Visible = false;
                dpVerticalLine.Visible = false;
                MessageBox.Show(config.ReadConfigValue("MGM", "ND_Code_ModiSucceed"));
                return;
            }
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        private void DelDepart()
        {
            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];
            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
            messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[1].eName = C_Global.CEnum.TagName.DepartID;
            messageBody[1].oContent = selectDepartID;


            delResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.DEPARTMENT_DELETE, C_Global.CEnum.Msg_Category.USER_ADMIN, messageBody);

            if (delResult[0, 0].oContent.Equals("FAILURE"))
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "ND_Code_DelFailed"));
                return;
            }

            if (delResult[0, 0].oContent.Equals("SUCESS"))
            {
                GetDepartmentList();
                MessageBox.Show(config.ReadConfigValue("MGM", "ND_Code_DelSucceed"));
                return;
            }
        }

        #endregion

        private void NewDepartment_Load(object sender, EventArgs e)
        {
            IntiFontLib();

            dpSet.Visible = false;
            dpVerticalLine.Visible = false;
            txtDeptName.Clear();
            lstGameRole.Items.Clear();

            GetDepartmentList();
            GetGameList();

        }

        private void dgDepartList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectDepartRow = e.RowIndex;
            
            
            if (selectDepartRow == -1)
            {
                ibtEditDepart.ITXT_TEXT = config.ReadConfigValue("MGM", "ND_UI_IbtEditDepart");
            }
            try
            {

                ibtEditDepart.ITXT_TEXT = config.ReadConfigValue("MGM", "ND_Code_EditDepartInfo").Replace("{Depart}", departmentsResult[selectDepartRow, 1].oContent.ToString());
                
            }
            catch
            {
            }
        }

        private void dgDepartList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CEnum.Message_Body[,] tmpMsg = new CEnum.Message_Body[departmentsResult.GetLength(0),departmentsResult.GetLength(1)];
            int num = 0;

            for (int i = 0; i < dgDepartList.Rows.Count; i++)
            {
                for (int k = 0; k < departmentsResult.GetLength(0); k++)
                {
                    if (departmentsResult[k, 1].oContent.ToString().Equals(dgDepartList.Rows[i].Cells[0].Value))
                    {
                        for (int j = 0; j < departmentsResult.GetLength(1); j++)
                        {
                            tmpMsg[num, j].eName = departmentsResult[k, j].eName;
                            tmpMsg[num, j].eTag = departmentsResult[k, j].eTag;
                            tmpMsg[num, j].oContent = departmentsResult[k, j].oContent;
                        }
                        num += 1;
                    }
                }
            }

            departmentsResult = tmpMsg;

        }

        private void ibtNewDepart_ITC_CLICIK(object sender)
        {
            dAction = DepartAction.newDepart;   //操作行为：新建

            txtDeptName.Clear();
            txtRemark.Clear();
            InitializeGameList();

            dpSet.Visible = true;
            dpVerticalLine.Visible = true;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dpSet.Visible = false;
            dpVerticalLine.Visible = false;
            txtDeptName.Clear();
            lstGameRole.Items.Clear();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            gameRoles = "";
            for (int i=0;i< lstGameRole.Items.Count;i++)
            {
                if (lstGameRole.Items[i].Checked)
                {
                    gameRoles += lstGameRole.Items[i].Tag + ",";
                }
            }
            if (dAction == DepartAction.newDepart)
            {
                AddNewDepart();
            }
            else
            {
                ModiDepart();
            }
        }

        private void ibtDelDepart_ITC_CLICIK(object sender)
        {
            if (selectDepartRow == -1)
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "ND_Code_ChooseDelDepartment"));
                return;
            }
            DelDepart();
        }

        private void ibtEditDepart_ITC_CLICIK(object sender)
        {
            dAction = DepartAction.modiDepart;  //操作行为：修改

            try
            {
                selectDepartID = int.Parse(departmentsResult[selectDepartRow, 0].oContent.ToString());
                InitializeGameList();

                txtDeptName.Text = departmentsResult[selectDepartRow,1].oContent.ToString();
                txtRemark.Text = departmentsResult[selectDepartRow,2].oContent.ToString();
                dpSet.Visible = true;
                dpVerticalLine.Visible = true;
            }
            catch
            {
                dpSet.Visible = false;
                dpVerticalLine.Visible = false;
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
            this.Text = config.ReadConfigValue("MGM", "ND_UI_Caption");

            this.ibtNewDepart.ITXT_TEXT = config.ReadConfigValue("MGM", "ND_UI_IbtNewDepart");
            this.ibtEditDepart.ITXT_TEXT = config.ReadConfigValue("MGM", "ND_UI_IbtEditDepart");
            this.ibtDelDepart.ITXT_TEXT = config.ReadConfigValue("MGM", "ND_UI_IbtDelDepart");


            this.label1.Text = config.ReadConfigValue("MGM", "ND_UI_DepartName");
            this.label3.Text = config.ReadConfigValue("MGM", "ND_UI_Remark");
            this.label2.Text = config.ReadConfigValue("MGM", "ND_UI_CanManageGame");

            this.columnHeader1.Text = config.ReadConfigValue("MGM", "ND_UI_LV_Game");

            this.btnOK.Text = config.ReadConfigValue("MGM", "ND_UI_BtnApply");
            this.btnCancel.Text = config.ReadConfigValue("MGM", "ND_UI_BtnCancel");


        }


        #endregion
    }
}