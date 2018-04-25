using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Global;
using C_Event;

namespace M_SDO
{
    [C_Global.CModuleAttribute("跳舞毯查询", "BlanketSearch", "超级舞者", "SDO")]
    public partial class BlanketSearch : Form
    {
        public BlanketSearch()
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

        string _serverIP = null;    //服务器ip

        C_Global.CEnum.Message_Body[,] serverIPResult = null;    //ip列表信息

        C_Global.CEnum.Message_Body[,] doResult = null;    //玩家信息列表

        #endregion

        #region 函数


        /// <summary>
        /// 读取
        /// </summary>
        private void ReadKeyWords()
        {
            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[1];

            //messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            //messageBody[0].eName = C_Global.CEnum.TagName.SDO_ServerIP;
            //messageBody[0].oContent = _serverIP;

            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[0].eName = C_Global.CEnum.TagName.SDO_NickName;
            messageBody[0].oContent = txtID.Text;


            doResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_PADKEYWORD_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);

            if (doResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(doResult[0, 0].oContent.ToString());
                return;
            }
            else
            {
                dividerPanel1.Visible = true;
                lblKeyWords.Text = doResult[0, 0].oContent.ToString();

            }
        }     



        #endregion

        private void BlanketSearch_Load(object sender, EventArgs e)
        {
            dividerPanel1.Visible = false;
            //InitializeServerIP();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtID.Text == null || txtID.Text == "")
            {
                MessageBox.Show("请输入ID");
                txtID.Focus();
                return;
            }


            dividerPanel1.Visible = false;

            #region IP检索
            /*
            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                {
                    _serverIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            */
            #endregion

            ReadKeyWords();

        }
    }
}