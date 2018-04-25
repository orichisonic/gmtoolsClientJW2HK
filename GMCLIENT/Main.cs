using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using System.Threading;

using C_Event;
using C_Global;
using C_Socket;
using Language;

namespace GMCLIENT
{
    public partial class Main : Form
    {
      
        #region 自定义函数

        /// <summary>
        /// 创建treenode
        /// </summary>
        /// <param name="nodeValue"></param>
        /// <param name="tag"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private TreeNode GetTreeNode(string nodeValue, string tag)
        {
            TreeNode stafferNode = new TreeNode(nodeValue);
            stafferNode.Tag = tag;
            return stafferNode;
        }

        /// <summary>
        /// 创建子窗体

        /// </summary>
        /// <param name="sender">发送控件</param>
        /// <param name="e">控件事件</param>
        private void CallForm(object sender, System.EventArgs e)
        {
            C_Event.CFormEvent m_FormEvent = new C_Event.CFormEvent(m_Apps);
            //lblitle.Text = m_FormEvent.GetModuleClass(5, ((MenuItem)sender).Text, mSocketResule);
            //string sss = m_FormEvent.GetModuleClass(4, ((MenuStrip)sender).Text, mSocketResule).ToString();
            //this.lblStatus.Text = "正在打开窗体\"" + ((ToolStripMenuItem)sender).Text.ToString() + "\",请稍等...";
            m_FormEvent.CallForm(mParentForm, m_FormEvent.GetModuleClass(4, ((ToolStripMenuItem)sender).Text.ToString(), mSocketResule), m_ClientEvent);
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
        private Hashtable m_Apps = null;
        private System.Windows.Forms.Form mParentForm = null;
        private C_Event.CSocketEvent m_ClientEvent = null;
        private C_Global.CEnum.Message_Body[,] mSocketResule = null;
        string strPath = null;  //应用程序执行路径
        bool leftOpen = true;   //左边listview是否打开
        int seconds = 0;    //窗体启动描述

        string txtStatusValue = null;

        string currSelectNodeTag = null;    //tree select node tag
        string lastSelectNodeTage = null;
        ConfigValue config = null;
        #endregion

        #region 方法
        private void IntiUI()
        {
            this.Text = config.ReadConfigValue("MAIN", "Main_UI_Captaion");
            this.MtmGM.Text = config.ReadConfigValue("MAIN", "Main_UI_Menu_SystemManage");
            this.MtmGame.Text = config.ReadConfigValue("MAIN", "Main_UI_Menu_GameManage");
        }
        #endregion

        #region 属性

        public string STATUSTEXT
        {
            set
            {
                this.lblStatus.Text = value;
            }
        }
        #endregion

        #region 状态栏刷新

        private void WriteChkUpdateText(object sender, System.EventArgs e)
        {
            Status.WriteStatusText(this, config.ReadConfigValue("MAIN", "Main_Code_CheckingUpdateFile"));
        }

        private void WriteFinish(object sender, System.EventArgs e)
        {
            Status.WriteStatusText(this, config.ReadConfigValue("MAIN", "Main_Code_Finish"));
        }

        private void WriteLoadMenuText(object sender, System.EventArgs e)
        {
            Status.WriteStatusText(this, config.ReadConfigValue("MAIN", "Main_Code_LoadingMenu"));
        }

        private void InvokeWriteLoadMenuText()
        {
            Invoke(new EventHandler(WriteLoadMenuText));
        }

        private void InvokeWriteChkUpdateText()
        {
            Invoke(new EventHandler(WriteChkUpdateText));
        }

        #endregion

        #region 菜单加载
        private void InvokeLoadMenu()
        {
            Thread thdLoadText = new Thread(new ThreadStart(InvokeWriteLoadMenuText));
            thdLoadText.Start();
            Invoke(new EventHandler(LoadMenu));
        }

        private void LoadMenu(object sender, System.EventArgs e)
        {            
            ArrayList gameMenu = new ArrayList();       //一维菜单  格式:"猛将"
            bool gameMenuNotExist = true;               //一维菜单是否已存在
            int gameIndex = 0;                          //菜单内容所在维数


            //获取游戏名称
            //C_Global.CIniFile mIniFile = new C_Global.CIniFile(strPath + @"\Schmem\Schmem.INI");
            //string game_sdo = mIniFile.ReadValue("GAMES", "Game_Sdo");

            //获取用户模块
            C_Global.CEnum.Message_Body[] mModuleBody = new C_Global.CEnum.Message_Body[1];
            mModuleBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            mModuleBody[0].eName = C_Global.CEnum.TagName.User_ID;
            mModuleBody[0].oContent = m_ClientEvent.GetInfo("USERID");

            //用户权限内的模块
            mSocketResule = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.USER_MODULE_QUERY, C_Global.CEnum.Msg_Category.USER_MODULE_ADMIN, mModuleBody);
            //检测状态

            if (mSocketResule[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mSocketResule[0, 0].oContent.ToString());
                Application.Exit();
                return;
            }
            //读模块信息

            m_Apps = C_Global.CModule.Module(strPath + @"\Modules", "dll");

            bool bNodeOfGm = false;
            bool isFirstLoad = true;
            for (int i = 0; i < mSocketResule.GetLength(0); i++)
            {
                if (mSocketResule[i, 0].oContent.ToString() == "1")
                {
                    bNodeOfGm = true;
                    MtmGM.Visible = true;

                    try
                    {
                        //加载tree
                        if (isFirstLoad)
                        {
                            TrvMenu.Nodes.Add(mSocketResule[i, 2].oContent.ToString());
                            isFirstLoad = false;
                        }
                        TrvMenu.Nodes[0].Nodes.Add(this.GetTreeNode(mSocketResule[i, 3].oContent.ToString(), mSocketResule[i, 4].oContent.ToString()));

                        //加载menu
                        MtmGM.DropDownItems.Add(mSocketResule[i, 3].oContent.ToString());
                        MtmGM.DropDownItems[MtmGM.DropDownItems.Count - 1].Click += new System.EventHandler(CallForm);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                else if (mSocketResule[i, 0].eName == C_Global.CEnum.TagName.GameID && mSocketResule[i, 0].oContent.ToString() != "1")
                {
                    try
                    {
                        if (isFirstLoad)
                        {
                            TrvMenu.Nodes.Add(config.ReadConfigValue("MAIN","Main_UI_Tree_Top"));
                            isFirstLoad = false;
                        }

                        MtmGame.Visible = true;

                        int iIndexOfMenu = MtmGame.DropDownItems.Count;
                        int iIndexOfGame = Int32.Parse(mSocketResule[i, 0].oContent.ToString());

                        if (gameMenu.Count == 0)//第一次加载菜单时
                        {
                            //加载treeview
                            TrvMenu.Nodes.Add(mSocketResule[i, 2].oContent.ToString());
                            TrvMenu.Nodes[TrvMenu.Nodes.Count - 1].Nodes.Add(this.GetTreeNode(mSocketResule[i, 3].oContent.ToString(), mSocketResule[i, 4].oContent.ToString()));

                            MtmGame.DropDownItems.Add(mSocketResule[i, 2].oContent.ToString());
                            ((ToolStripMenuItem)(MtmGame.DropDownItems[0])).DropDownItems.Add(mSocketResule[i, 3].oContent.ToString());
                            ((ToolStripMenuItem)(MtmGame.DropDownItems[0])).DropDownItems[((ToolStripMenuItem)(MtmGame.DropDownItems[0])).DropDownItems.Count - 1].Click += new System.EventHandler(CallForm);
                            //保存已加载的一维菜单

                            gameMenu.Add(mSocketResule[i, 2].oContent.ToString());
                            //保存游戏ｉｄ

                            if (mSocketResule[i, 2].oContent.ToString().Trim() == config.ReadConfigValue("GAMES", "G_MJ"))
                            {
                                m_ClientEvent.SaveInfo("GameID_MJ", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                            }
                            else if (mSocketResule[i, 2].oContent.ToString().Trim() == config.ReadConfigValue("GAMES", "G_SDO"))
                            {
                                m_ClientEvent.SaveInfo("GameID_SDO", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                            }
                            else if (mSocketResule[i, 2].oContent.ToString().Trim() == config.ReadConfigValue("GAMES", "G_CR"))
                            {
                                m_ClientEvent.SaveInfo("GameID_CR", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                            }
                            else if (mSocketResule[i, 2].oContent.ToString().Trim() == config.ReadConfigValue("GAMES", "G_AU"))
                            {
                                m_ClientEvent.SaveInfo("GameID_AU", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                            }
                            else if (mSocketResule[i, 2].oContent.ToString().Trim() == config.ReadConfigValue("GAMES", "G_O2JAM"))
                            {
                                m_ClientEvent.SaveInfo("GameID_O2jam", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                            }
                            else if (mSocketResule[i, 2].oContent.ToString().Trim() == config.ReadConfigValue("GAMES", "G_BAF"))
                            {
                                m_ClientEvent.SaveInfo("GameID_O2jam2", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                            }
                            else if (mSocketResule[i, 2].oContent.ToString().Trim() == config.ReadConfigValue("GAMES", "G_SOCCER"))
                            {
                                m_ClientEvent.SaveInfo("GameID_Soccer", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                            }
                            else if (mSocketResule[i, 2].oContent.ToString().Trim() == config.ReadConfigValue("GAMES", "G_RC"))
                            {
                                m_ClientEvent.SaveInfo("GameID_RC", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                            }
                            else if (mSocketResule[i, 2].oContent.ToString().Trim() == config.ReadConfigValue("GAMES", "G_SD"))
                            {
                                m_ClientEvent.SaveInfo("GameID_SD", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                            }
                            else if (mSocketResule[i, 2].oContent.ToString().Trim() == config.ReadConfigValue("GAMES", "G_JW2"))
                            {
                                m_ClientEvent.SaveInfo("GameID_JW2", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                            }
                            //switch (mSocketResule[i, 2].oContent.ToString().Trim())
                            //{
                            //    case "猛将":
                            //        m_ClientEvent.SaveInfo("GameID_MJ", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                            //        break;
                            //    case "超级舞者":
                            //        m_ClientEvent.SaveInfo("GameID_SDO", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                            //        break;
                            //    case "疯狂卡丁车":
                            //        m_ClientEvent.SaveInfo("GameID_CR", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                            //        break;
                            //    case "劲舞团":
                            //        m_ClientEvent.SaveInfo("GameID_AU", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                            //        break;
                            //    case "劲乐团":
                            //        m_ClientEvent.SaveInfo("GameID_O2jam", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                            //        break;
                            //    case "超级乐者":
                            //        m_ClientEvent.SaveInfo("GameID_O2jam2", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                            //        break;
                            //    case "劲爆足球":
                            //        m_ClientEvent.SaveInfo("GameID_Soccer", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                            //        break;

                            //}
                        }
                        else
                        {
                            gameMenuNotExist = true;   //初始化游戏菜单存在值,存在
                            for (int iIndex = 0; iIndex < gameMenu.Count; iIndex++)
                            {
                                //检测游戏是否存在

                                if (gameMenu[iIndex].ToString() == mSocketResule[i, 2].oContent.ToString())
                                {
                                    gameMenuNotExist = false;
                                    gameIndex = iIndex;//获取游戏所在维数

                                }
                            }
                            if (gameMenuNotExist)//一维菜单中游戏不存在则加载
                            {
                                //加载treeview
                                TrvMenu.Nodes.Add(mSocketResule[i, 2].oContent.ToString());
                                TrvMenu.Nodes[TrvMenu.Nodes.Count - 1].Nodes.Add(this.GetTreeNode(mSocketResule[i, 3].oContent.ToString(), mSocketResule[i, 4].oContent.ToString()));
                                //加载menu
                                MtmGame.DropDownItems.Add(mSocketResule[i, 2].oContent.ToString());
                                ((ToolStripMenuItem)(MtmGame.DropDownItems[gameMenu.Count])).DropDownItems.Add(mSocketResule[i, 3].oContent.ToString());
                                ((ToolStripMenuItem)(MtmGame.DropDownItems[gameMenu.Count])).DropDownItems[((ToolStripMenuItem)(MtmGame.DropDownItems[gameMenu.Count])).DropDownItems.Count - 1].Click += new System.EventHandler(CallForm);
                                //保存已加载的一维菜单

                                gameMenu.Add(mSocketResule[i, 2].oContent.ToString());
                                //保存游戏ｉｄ

                                if (mSocketResule[i, 2].oContent.ToString().Trim() == config.ReadConfigValue("GAMES", "G_MJ"))
                                {
                                    m_ClientEvent.SaveInfo("GameID_MJ", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                                }
                                else if (mSocketResule[i, 2].oContent.ToString().Trim() == config.ReadConfigValue("GAMES", "G_SDO"))
                                {
                                    m_ClientEvent.SaveInfo("GameID_SDO", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                                }
                                else if (mSocketResule[i, 2].oContent.ToString().Trim() == config.ReadConfigValue("GAMES", "G_CR"))
                                {
                                    m_ClientEvent.SaveInfo("GameID_CR", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                                }
                                else if (mSocketResule[i, 2].oContent.ToString().Trim() == config.ReadConfigValue("GAMES", "G_AU"))
                                {
                                    m_ClientEvent.SaveInfo("GameID_AU", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                                }
                                else if (mSocketResule[i, 2].oContent.ToString().Trim() == config.ReadConfigValue("GAMES", "G_O2JAM"))
                                {
                                    m_ClientEvent.SaveInfo("GameID_O2jam", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                                }
                                else if (mSocketResule[i, 2].oContent.ToString().Trim() == config.ReadConfigValue("GAMES", "G_BAF"))
                                {
                                    m_ClientEvent.SaveInfo("GameID_O2jam2", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                                }
                                else if (mSocketResule[i, 2].oContent.ToString().Trim() == config.ReadConfigValue("GAMES", "G_SOCCER"))
                                {
                                    m_ClientEvent.SaveInfo("GameID_Soccer", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                                }
                                else if (mSocketResule[i, 2].oContent.ToString().Trim() == config.ReadConfigValue("GAMES", "G_RC"))
                                {
                                    m_ClientEvent.SaveInfo("GameID_RC", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                                }
                                else if (mSocketResule[i, 2].oContent.ToString().Trim() == config.ReadConfigValue("GAMES", "G_SD"))
                                {
                                    m_ClientEvent.SaveInfo("GameID_SD", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                                }
                                else if (mSocketResule[i, 2].oContent.ToString().Trim() == config.ReadConfigValue("GAMES", "G_JW2"))
                                {
                                    m_ClientEvent.SaveInfo("GameID_JW2", int.Parse(mSocketResule[i, 0].oContent.ToString()));
                                }
                            }
                            else
                            {
                                TrvMenu.Nodes[gameIndex + 1].Nodes.Add(this.GetTreeNode(mSocketResule[i, 3].oContent.ToString(), mSocketResule[i, 4].oContent.ToString()));

                                ((ToolStripMenuItem)(MtmGame.DropDownItems[gameIndex])).DropDownItems.Add(mSocketResule[i, 3].oContent.ToString());
                                ((ToolStripMenuItem)(MtmGame.DropDownItems[gameIndex])).DropDownItems[((ToolStripMenuItem)(MtmGame.DropDownItems[gameIndex])).DropDownItems.Count - 1].Click += new System.EventHandler(CallForm);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                else
                {
                    //无权限处理

                }
            }

            if (!bNodeOfGm)
            {
                TrvMenu.Nodes[0].Remove();
            }
            this.Invoke(new EventHandler(WriteFinish));
        }
        #endregion

        #region 升级文件
        private void InvokeUpdateFiles()
        {
            Thread thdLoadText = new Thread(new ThreadStart(InvokeWriteChkUpdateText));
            thdLoadText.Start();
            Invoke(new EventHandler(UpdateFiles));
        }

        private void UpdateFiles(object sender, System.EventArgs e)
        {
            try
            {
                //Thread thdLoadMenu = new Thread(new ThreadStart(InvokeLoadMenu));
                //thdLoadMenu.Start();

                FileUpdateChk fileUpdateChk = new FileUpdateChk();
                string[,] dllFilesInfoRoot = null;
                string[,] dllFilesInfoModule = null;
                string strRootSplit = null;
                string strModuleSplit = null;
                string[,] exeFilesInfoRoot = null;

                dllFilesInfoRoot = fileUpdateChk.GetLocalDllFile(strPath);                  //根目录下dll文件
                exeFilesInfoRoot = fileUpdateChk.GetLocalExeFile(strPath);                  //根目录下exe文件
                dllFilesInfoModule = fileUpdateChk.GetLocalDllFile(strPath + @"\Modules");  //Modules子目录下dll文件
                try
                {
                    for (int i = 0; i < dllFilesInfoRoot.GetLength(0); i++)
                    {
                        //文件名

                        strRootSplit += dllFilesInfoRoot[i, 0] + ",";
                        strRootSplit += dllFilesInfoRoot[i, 1] + ";";
                    }
                    for (int i = 0; i < exeFilesInfoRoot.GetLength(0); i++)
                    {
                        //文件名

                        strRootSplit += exeFilesInfoRoot[i, 0] + ",";
                        strRootSplit += exeFilesInfoRoot[i, 1] + ";";
                    }
                    for (int j = 0; j < dllFilesInfoModule.GetLength(0); j++)
                    {
                        //文件名

                        strModuleSplit += dllFilesInfoModule[j, 0] + ",";
                        strModuleSplit += dllFilesInfoModule[j, 1] + ";";
                    }

                    C_Global.CEnum.Message_Body[] mContent = new C_Global.CEnum.Message_Body[2];

                    mContent[0].eName = C_Global.CEnum.TagName.UpdateFileName;
                    mContent[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = strRootSplit;

                    mContent[1].eName = C_Global.CEnum.TagName.UpdateFilePath;
                    mContent[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = strModuleSplit;

                    C_Global.CEnum.Message_Body[,] mResult = this.m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.CLIENT_PATCH_COMPARE, C_Global.CEnum.Msg_Category.COMMON, mContent);



                    if (!mResult[0, 0].oContent.ToString().Equals("FAILURE"))
                    {
                        UpdateFrm updateFrm = new UpdateFrm(mResult);
                        updateFrm.CreateModule(null, m_ClientEvent);
                    }
                    else
                    {
                        Thread thdLoadMenu = new Thread(new ThreadStart(InvokeLoadMenu));
                        thdLoadMenu.Start();
                    }
                }
                catch
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        #endregion

        #region tab for children windows
        private void FormMain_MdiChildActivate(object sender, System.EventArgs e)
        {
            System.Windows.Forms.Form frm = this.MdiChildren[this.MdiChildren.Length - 1];
            // if Mdiform creation
            if (frm.Tag == null)// add_Tab
            {
                frm.WindowState = FormWindowState.Maximized;
                // search an unique caption for the form and the tabpage
                string frm_caption = frm.Text;
                int cpt = 2;
                while (this.check_if_tab_exist(frm_caption))
                {
                    frm_caption = frm.Text + " (" + cpt + ")";
                    cpt++;
                }
                frm.Text = frm_caption;
                TabPage tp = new TabPage(frm.Text);
                // add close image on the tabpage
                tp.ImageIndex = 0;// unselected state
                frm.Tag = tp;// associate mdi child window and tabpage
                
                // add tab page
                this.tabControl_mdichild.TabPages.Add(tp);
                // add event handler on the mdi child
                frm.Closed += new EventHandler(MdiChild_Closed);
                frm.TextChanged += new EventHandler(MdiChild_TextChanged);
                // check if it is the first mdichild
                if (this.MdiChildren.Length == 1)
                {
                    // show tabcontrol
                    this.panel_mdi_tab.Visible = true;
                }
                this.tabControl_mdichild.SelectedTab = tp;
            }
            else // activate corresponding tabpage
            {
                if (this.ActiveMdiChild == null)
                    return;
                frm = this.ActiveMdiChild;
                if (!(frm.Tag is TabPage))
                    return;
                // unactivate old tabpage image selection
                this.tabControl_set_close_image_state(false);
                // activate associated tabpage
                TabPage tp = (TabPage)frm.Tag;
                this.tabControl_mdichild.SelectedTab = tp;
            }
            //this.lblStatus.Text = "完毕";
        }
        /// <summary>
        /// check if caption already exist for another tab/mdiChildForm
        /// </summary>
        /// <param name="caption"></param>
        /// <returns></returns>
        private bool check_if_tab_exist(string caption)
        {
            for (int cpt = 0; cpt < this.tabControl_mdichild.TabPages.Count; cpt++)
                if (this.tabControl_mdichild.TabPages[cpt].Text == caption)
                    return true;
            return false;
        }
        private void MdiChild_Closed(object sender, EventArgs e)
        {
            if (!(sender is System.Windows.Forms.Form))
                return;
            // remove tab
            this.tabControl_mdichild.TabPages.Remove((TabPage)((System.Windows.Forms.Form)sender).Tag);
            if (this.tabControl_mdichild.TabPages.Count == 0)
                //hide tab control
                this.panel_mdi_tab.Visible = false;
        }
        private void MdiChild_TextChanged(object sender, EventArgs e)
        {
            if (!(sender is System.Windows.Forms.Form))
                return;
            System.Windows.Forms.Form frm = (System.Windows.Forms.Form)sender;
            if (!(frm.Tag is TabPage))
                return;
            TabPage tp = (TabPage)frm.Tag;
            tp.Text = frm.Text;
        }
        private void tabControl_mdichild_Click(object sender, EventArgs e)
        {
            // activate mdi child associated with the tabpage
            TabPage tp = this.tabControl_mdichild.SelectedTab;
            System.Windows.Forms.Form mdic = this.tabControl_get_associated_form(tp);
            if (mdic == null)
                return;
            mdic.Activate();
        }
        /// <summary>
        /// get the mdi child form associated with the TabPage
        /// </summary>
        /// <param name="tp"></param>
        /// <returns></returns>
        private System.Windows.Forms.Form tabControl_get_associated_form(TabPage tp)
        {
            for (int cpt = 0; cpt < this.MdiChildren.Length; cpt++)
            {
                if ((TabPage)this.MdiChildren[cpt].Tag == tp)
                {
                    return this.MdiChildren[cpt];
                }
            }
            return null;
        }
        /// <summary>
        /// used as mouseclick. MouseUp is used to get mouse position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl_mdichild_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // close associated form if exist
            if (!this.tabControl_is_mouse_on_close_image(e))
                return;
            System.Windows.Forms.Form mdic = this.tabControl_get_associated_form(this.tabControl_mdichild.SelectedTab);
            if (mdic == null)
                return;
            mdic.Close();
        }
        private void tabControl_mdichild_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // check if mouse is over the close image, and if it is, change close image
            this.tabControl_set_close_image_state(this.tabControl_is_mouse_on_close_image(e));
        }
        private void tabControl_set_close_image_state(bool b_active)
        {
            if (this.tabControl_mdichild.SelectedTab == null)
                return;
            // if active state
            if (b_active)
            {
                if (this.tabControl_mdichild.SelectedTab.ImageIndex != 1)
                    this.tabControl_mdichild.SelectedTab.ImageIndex = 1;
            }
            // else
            else if (this.tabControl_mdichild.SelectedTab.ImageIndex != 0)
                this.tabControl_mdichild.SelectedTab.ImageIndex = 0;
        }
        private void tabControl_mdichild_MouseLeave(object sender, System.EventArgs e)
        {
            // restore unselected image
            this.tabControl_set_close_image_state(false);
        }
        private bool tabControl_is_mouse_on_close_image(System.Windows.Forms.MouseEventArgs e)
        {
            // position of image in tab control
            byte image_left = 6;
            byte image_top = 1;
            // check if mouse is other the image
            if (
                (e.X < image_left + this.imageList_tabpage_icons.ImageSize.Width + this.tabControl_mdichild.GetTabRect(this.tabControl_mdichild.SelectedIndex).X)
                && (e.X > image_left + this.tabControl_mdichild.GetTabRect(this.tabControl_mdichild.SelectedIndex).X)
                && (e.Y < image_top + this.imageList_tabpage_icons.ImageSize.Height + this.tabControl_mdichild.GetTabRect(this.tabControl_mdichild.SelectedIndex).Y)
                && (e.Y > image_top + this.tabControl_mdichild.GetTabRect(this.tabControl_mdichild.SelectedIndex).Y)
                )
                return true;
            else
                return false;
        }
        #endregion

        public Main()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.leftOpen)
            {
                this.dPanelLeft.Visible = true;
            }
            else
            {
                this.dPanelLeft.Visible = false;
            }
        }

        public Main(C_Event.CSocketEvent mClientEvent,string execPath)
        {
            InitializeComponent();
            this.m_ClientEvent = mClientEvent;
            this.strPath = execPath;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            /////////////////////////////////////////
            // 获取语言文字库                      //
            /////////////////////////////////////////
            config = (ConfigValue)m_ClientEvent.GetInfo("INI");
            /////////////////////////////////////////
            // 初始化界面文字                      //
            /////////////////////////////////////////
            IntiUI();


            //设置父窗体
            this.mParentForm = this;
            //隐藏tab控件
            this.panel_mdi_tab.Visible = false;
            //设隐藏左边listview的图片的位置
            this.picOpenClose.Location = new Point(1, this.dpMiddle.Location.Y + this.dpMiddle.Height / 2 - this.picOpenClose.Height);



        }

        private void TrvMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            try
            {
                currSelectNodeTag = e.Node.Tag.ToString();
                
                if (lastSelectNodeTage == null)
                {
                    lastSelectNodeTage = e.Node.Tag.ToString();
                }

                C_Event.CFormEvent m_FormEvent = new C_Event.CFormEvent(m_Apps);
                if (e.Node.Tag != null)
                {
                    //this.lblStatus.Text = "正在打开窗体\"" + e.Node.Text.ToString() + "\",请稍等...";
                }      
                m_FormEvent.CallForm(mParentForm, m_FormEvent.GetModuleClass(4, e.Node.Tag.ToString(), mSocketResule), m_ClientEvent);
            }
            catch
            {
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.leftOpen)
            {
                leftOpen = false;
                this.picOpenClose.Image = global::GMCLIENT.Properties.Resources.left_right;
            }
            else
            {
                leftOpen = true;
                this.picOpenClose.Image = global::GMCLIENT.Properties.Resources.left_right2;
            }
            this.Invalidate();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            //设隐藏左边listview的图片的位置
            this.picOpenClose.Location = new Point(1, this.dpMiddle.Location.Y + this.dpMiddle.Height / 2 - this.picOpenClose.Height);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                seconds += 1;
                if (seconds == 1)
                {
                    Thread thdUpdateFile = new Thread(new ThreadStart(InvokeLoadMenu));
                    thdUpdateFile.Start();
                    timer1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void TrvMenu_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (lastSelectNodeTage == currSelectNodeTag)
                {
                    C_Event.CFormEvent m_FormEvent = new C_Event.CFormEvent(m_Apps);
                    m_FormEvent.CallForm(mParentForm, m_FormEvent.GetModuleClass(4, currSelectNodeTag, mSocketResule), m_ClientEvent);
                }
                else
                {
                    lastSelectNodeTage = currSelectNodeTag;
                }
                
            }
            catch
            {
            }
            
        }
    }

}