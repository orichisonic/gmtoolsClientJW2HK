using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Global;
using C_Event;
using System.Text.RegularExpressions;
using Language;
namespace M_SDO
{
    [C_Global.CModuleAttribute("场景设置", "SenceEdit", "大赛频道的比赛的场景信息", "SDO Group")]
    public partial class SenceEdit : Form
    {
        public SenceEdit()
        {
            InitializeComponent();
        }

        #region 变量
        private CSocketEvent m_ClientEvent = null;

        C_Global.CEnum.Message_Body[,] senceResult = null;
        C_Global.CEnum.Message_Body[,] newOrModiResult = null; 

        private int selectRow = 0;  //默认选中的行

        private ModiOrNew mn = ModiOrNew.New;

        private bool needReLoad = false;

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
            this.Text = config.ReadConfigValue("MSDO", "SE_UI_SenceEdit");
            this.toolStripButton1.Text = config.ReadConfigValue("MSDO", "SE_UI_toolStripButton1");
            this.toolStripButton2.Text = config.ReadConfigValue("MSDO", "SE_UI_toolStripButton2");
            this.toolStripButton3.Text = config.ReadConfigValue("MSDO", "SE_UI_toolStripButton3");
            this.label1.Text = config.ReadConfigValue("MSDO", "SE_UI_label1");
            this.label2.Text = config.ReadConfigValue("MSDO", "SE_UI_label2");
            this.btnOK.Text = config.ReadConfigValue("MSDO", "SE_UI_btnOK");
            this.btnCancel.Text = config.ReadConfigValue("MSDO", "SE_UI_btnCancel");
        }


        #endregion
        #region 函数
        /// <summary>
        /// 读取记录
        /// </summary>
        private void ReadInfos()
        {
            dgInfoList.DataSource = null;
            selectRow = 0;
            try
            {

                senceResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_CHALLENGE_SCENE_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, null);


                if (senceResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    toolStripButton2.Enabled = false;
                    toolStripButton3.Enabled = false;
                    MessageBox.Show(senceResult[0, 0].oContent.ToString());
                    return;
                }


                toolStripButton2.Enabled = true;
                toolStripButton3.Enabled = true;
                dgInfoList.DataSource = BrowseResultInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        /// <summary>
        /// 将返回数据转装成DataTable
        /// </summary>
        /// <returns></returns>
        private DataTable BrowseResultInfo()
        {
            DataTable dgTable = new DataTable();
            try
            {
                dgTable.Columns.Clear();       //清空头信息

                dgTable.Rows.Clear();          //清空行记录


                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "SE_Code_SceneId"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "SE_Code_SceneName"), typeof(string));


                for (int i = 0; i < senceResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    dgRow[config.ReadConfigValue("MSDO", "SE_Code_SceneId")] = senceResult[i, 0].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSDO", "SE_Code_SceneName")] = senceResult[i, 1].oContent.ToString();
                    
                    dgTable.Rows.Add(dgRow);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("排序出错：\n" + ex.Message);
            }
            return dgTable;
        }
        #endregion

        private void SenceEdit_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            toolStripButton2.Enabled = false;
            toolStripButton3.Enabled = false;
            dpEdit.Visible = false;
            ReadInfos();
            
        }

        private void dgInfoList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectRow = e.RowIndex;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dpEdit.Visible = true;
            mn = ModiOrNew.New;

            txtSenceID.Text = "";
            txtSenceName.Text = "";


        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtSenceID.Text == "" || txtSenceID.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "SE_Code_MsgSceneId"));
                return;
            }
            if (txtSenceName.Text == "" || txtSenceName.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "SE_Code_MsgSceneName"));
                return;
            }

            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.SDO_SenceID;
                messageBody[0].oContent = int.Parse(txtSenceID.Text);

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.SDO_Sence;
                messageBody[1].oContent = txtSenceName.Text;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                if (mn == ModiOrNew.New)
                {
                    newOrModiResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_CHALLENGE_SCENE_CREATE, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);
                }
                else
                {
                    newOrModiResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_CHALLENGE_SCENE_UPDATE, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);
                }

                if (newOrModiResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(newOrModiResult[0, 0].oContent.ToString());
                    return;
                }

                if (newOrModiResult[0, 0].oContent.ToString().Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "SE_Code_MsgF"));
                    return;
                }

                if (newOrModiResult[0, 0].oContent.ToString().Equals("SUCESS"))
                {
                    dpEdit.Visible = false;
                    MessageBox.Show(config.ReadConfigValue("MSDO", "SE_Code_MsgS"));
                    ReadInfos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            dpEdit.Visible = true;
            mn = ModiOrNew.Edit;

            txtSenceID.Text = senceResult[selectRow, 0].oContent.ToString();
            txtSenceName.Text = senceResult[selectRow, 1].oContent.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dpEdit.Visible = false;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(config.ReadConfigValue("MSDO", "SE_Code_Msg"), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.Cancel)
            {
                return;
            }

            dpEdit.Visible = false;
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.SDO_SenceID;
                messageBody[0].oContent = int.Parse(senceResult[selectRow,0].oContent.ToString());

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                newOrModiResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_CHALLENGE_SCENE_DELETE, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);

                if (newOrModiResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(newOrModiResult[0, 0].oContent.ToString());
                    return;
                }

                if (newOrModiResult[0, 0].oContent.ToString().Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "SE_Code_MsgF"));
                    return;
                }

                if (newOrModiResult[0, 0].oContent.ToString().Equals("SUCESS"))
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "SE_Code_MsgS"));
                    ReadInfos();
                }
            }
            catch 
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "SE_Code_MsgchooseDel"));
            }
        }


        private void dgInfoList_MouseUp(object sender, MouseEventArgs e)
        {
            if (needReLoad)
            {
                dgInfoList.DataSource = BrowseResultInfo();
                needReLoad = false;
            }
        }

        private void dgInfoList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            needReLoad = true;
        }

        private void txtSenceID_KeyUp(object sender, KeyEventArgs e)
        {
            string txt = txtSenceID.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtSenceID.Text = rx.Replace(txt, "");
        }

        private void txtSenceID_MouseUp(object sender, MouseEventArgs e)
        {
            string txt = txtSenceID.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtSenceID.Text = rx.Replace(txt, "");
        }
    }

    public enum ModiOrNew
    {
        New,
        Edit
    }
}