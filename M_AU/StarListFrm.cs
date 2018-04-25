using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Global;
using C_Event;

namespace M_Audition
{
    [C_Global.CModuleAttribute("互联星空交易查询", "Frm_Shop_StarList", "AU Shop管理工具 -- 互联星空交易查询", "AU Group")] 
    public partial class Frm_Shop_StarList : Form
    {
        private CSocketEvent m_ClientEvent = null;

        public Frm_Shop_StarList()
        {
            InitializeComponent();
        }

        #region 自定义调用事件
        /// <summary>
        /// 创建类库中的窗体
        /// </summary>
        /// <param name="oParent">MDI 程序的父窗体</param>
        /// <param name="oSocket">Socket</param>
        /// <returns>类库中的窗体</returns>
        public Form CreateModule(object oParent, object oEvent)
        {
            //创建登录窗体
            Frm_Shop_StarList mModuleFrm = new Frm_Shop_StarList();
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

        private void Frm_Shop_StarList_Load(object sender, EventArgs e)
        {

        }
    }
}