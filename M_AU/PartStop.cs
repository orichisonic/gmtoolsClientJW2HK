using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Global;
using C_Event;

namespace M_AU
{
    [C_Global.CModuleAttribute("玩家角色停封", "PartStop", "尽舞团", "AU")]
    public partial class PartStop : Form
    {
        public PartStop()
        {
            InitializeComponent();
        }

        private void PartStop_Load(object sender, EventArgs e)
        {

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
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}