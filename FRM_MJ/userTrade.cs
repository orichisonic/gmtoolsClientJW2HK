using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Global;
using C_Event;

namespace FRM_MJ
{
    [C_Global.CModuleAttribute("玩家日志记录", "userTrade", "猛将排名", "玩家日志记录")]
    public partial class userTrade : Form
    {
        public userTrade()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.serverIP.Text == "")
            {
                MessageBox.Show("请选择服务器");
                return;
            }
            if (this.userName.Text == "")
            {
                MessageBox.Show("请输入玩家帐号");
                return;
            }
            if (this.beginDate.Text == "")
            {
                MessageBox.Show("请选择开始日期");
                return;
            }
            if (this.endDate.Text == "")
            {
                MessageBox.Show("请选择结束日期");
                return;
            }
            #region 查询ｉｐ
            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.serverIP.Text.Trim()))
                {
                    this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion            

            InitializeListView(_ServerIP, this.userName.Text.Trim(), Convert.ToDateTime(this.beginDate.Text.Trim()), Convert.ToDateTime(this.endDate.Text.Trim()));
        }

        #region 自定义函数

        /// <summary>
        /// 初始化游戏服务器列表
        /// </summary>
        public void InitializeServerIP()
        {
            try
            {
                this.serverIP.Items.Clear();

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.ServerInfo_GameID;
                messageBody[0].oContent = 2;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 3;

                serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);

                //检测状态
                if (serverIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }

                //显示内容到列表
                for (int i = 0; i < serverIPResult.GetLength(0); i++)
                {
                    this.serverIP.Items.Add(serverIPResult[i, 1].oContent.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void InitializeListView(string prmServerIP,string _userID,DateTime _beginDate,DateTime _endDate)
        {
            
            try
            {
                listViewSortOrder.Items.Clear();
                //正式信息

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[5];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.MJ_ServerIP;
                messageBody[1].oContent = prmServerIP;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.MJ_Account;
                messageBody[2].oContent = _userID;

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_DATE;
                messageBody[3].eName = C_Global.CEnum.TagName.BeginTime;
                messageBody[3].oContent = _beginDate;

                messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_DATE;
                messageBody[4].eName = C_Global.CEnum.TagName.EndTime;
                messageBody[4].oContent = _endDate;

                searchFrmResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.MJ_ITEMLOG_QUERY, C_Global.CEnum.Msg_Category.MJ_ADMIN, messageBody);

                //检测状态
                if (searchFrmResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(searchFrmResult[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }

                //显示内容到列表
                string[] rowInfo = new string[5];
                
                for (int i = 0; i < searchFrmResult.GetLength(0); i++)
                {
                    
                    //行编号
                    rowInfo[0] = Convert.ToString(i + 1);
                    //帐号	
                    rowInfo[1] = searchFrmResult[i, 0].oContent.ToString();
                    //昵称
                    rowInfo[2] = searchFrmResult[i, 1].oContent.ToString();
                    //操作内容
                    rowInfo[3] = ParseAction(int.Parse(searchFrmResult[i, 2].oContent.ToString()));
                    //操作日期
                    rowInfo[4] = searchFrmResult[i, 3].oContent.ToString();
                    ListViewItem mlistViewItem = new ListViewItem(rowInfo, -1);
                    listViewSortOrder.Items.Add(mlistViewItem);
                    listViewSortOrder.Items[i].Tag = searchFrmResult[i, 0].oContent.ToString();
                    
                }
                
                //listViewAcoount = GMAdmin.DisplayView(m_ClientEvent, listViewAcoount, searchFrmResult,true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
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
        private CSocketEvent m_ClientEvent = null;
        private C_Global.CEnum.Message_Body[,] serverIPResult = null;
        private C_Global.CEnum.Message_Body[,] searchFrmResult = null;


        private string _ServerIP = null;
        #endregion

        #region 操作信息
        private string ParseAction(int number)
        {
            string returnValue = null;
            switch (number)
            {
                case 0:
                    returnValue = "IACT_UNINITED";
                    break;
                case 1:
                    returnValue = "IACT_LOADED";
                    break;
                case 2:
                    returnValue = "IACT_CREATE";
                    break;
                case 3:
                    returnValue = "IACT_GET_FROM_WAREHOUSE";
                    break;
                case 4:
                    returnValue = "IACT_GET_FROM_SHOP";
                    break;
                case 5:
                    returnValue = "IACT_GET_FROM_STALL";
                    break;
                case 6:
                    returnValue = "IACT_PUT_BY_SCRIPT";
                    break;
                case 7:
                    returnValue = "IACT_PICK";
                    break;
                case 8:
                    returnValue = "IACT_INNERMOVE";
                    break;
                case 9:
                    returnValue = "IACT_EQUIP";
                    break;
                case 10:
                    returnValue = "IACT_UNEQUIP";
                    break;
                case 11:
                    returnValue = "IACT_USE";
                    break;
                case 12:
                    returnValue = "IACT_EXCHANGE";
                    break;
                case 13:
                    returnValue = "IACT_THROW";
                    break;
                case 14:
                    returnValue = "IACT_PUNISH_DROP";
                    break;
                case 15:
                    returnValue = "IACT_DESTROY";
                    break;
                case 16:
                    returnValue = "IACT_PUT_TO_WAREHOUSE";
                    break;
                case 17:
                    returnValue = "IACT_SELL_TO_SHOP";
                    break;
                case 18:
                    returnValue = "IACT_SELL_BY_STALL";
                    break;
                case 19:
                    returnValue = "IACT_ROLLBACK";
                    break;
                case 20:
                    returnValue = "IACT_MAP_CLEANUP";
                    break;
                case 21:
                    returnValue = "IACT_MONEY_PICKUP";
                    break;
                case 22:
                    returnValue = "IACT_REPARE_BROKEN";
                    break;
                case 23:
                    returnValue = "IACT_GIVE_TO_NPC";
                    break;
                case 24:
                    returnValue = "IACT_SKILL_CONSUME";
                    break;
                case 25:
                    returnValue = "IACT_SAVED";
                    break;
            }
            return returnValue;
        }
        #endregion

        private void userTrade_Load(object sender, EventArgs e)
        {
            InitializeServerIP();
        }
    }
}