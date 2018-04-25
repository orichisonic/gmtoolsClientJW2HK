using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using C_Global;
using C_Event;
using Language;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using STONE.HU.HELPER.UTIL;

namespace M_JW2
{
    class Operation_JW2
    {
        public CSocketEvent m_ClientEvent = null;
        public static int iPageSize = 50;

    
        
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
           
        }

        #endregion

        #region 获取服务器地址列表
        /// <summary>
        /// 获取服务器地址列表
        /// </summary>
        /// <param name="mEvent">Socket事件</param>
        /// <param name="mContent">消息内容</param>
        /// <returns>请求结果</returns>
        public static CEnum.Message_Body[,] GetServerList(CSocketEvent mEvent, CEnum.Message_Body[] mContent)
        {
            CEnum.Message_Body[,] mReturn = null;
          
            mReturn =
                mEvent.RequestResult(CEnum.ServiceKey.SERVERINFO_IP_QUERY, CEnum.Msg_Category.COMMON, mContent);
           
            return mReturn;
        }
        #endregion

        #region 获取信息列表
        /// <summary>
        /// 获取信息列表
        /// </summary>
        /// <param name="mEvent">Socket事件</param>
        /// <param name="mKey">请求标记</param>
        /// <param name="mContent">消息内容</param>
        /// <returns>请求结果</returns>
        public static CEnum.Message_Body[,] GetResult(CSocketEvent mEvent, CEnum.ServiceKey mKey, CEnum.Message_Body[] mContent)
        {
            CEnum.Message_Body[,] mReturn = null;

            mReturn =
                mEvent.RequestResult(mKey, CEnum.Msg_Category.JW2_ADMIN, mContent);

            return mReturn;
        }
        #endregion

        #region 构造 ComboBox 内容
        /// <summary>
        /// 构造 ComboBox 内容
        /// </summary>
        /// <param name="val">ComboBox 内容</param>
        /// <param name="mCmbBox">ComboBox 控件</param>
        /// <returns>ComboBox 控件</returns>
        public static System.Windows.Forms.ComboBox BuildCombox(CEnum.Message_Body[,] val, System.Windows.Forms.ComboBox mCmbBox)
        {
            try
            {
                mCmbBox.Items.Clear();
                for (int i = 0; i < val.GetLength(0); i++)
                {
                    mCmbBox.Items.Add(val[i, 1].oContent);
                }

                mCmbBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return mCmbBox;
        }

        public static System.Windows.Forms.ComboBox BuildComboxs(CEnum.Message_Body[,] val, System.Windows.Forms.ComboBox mCmbBox)
        {
            try
            {
                mCmbBox.Items.Clear();
                for (int i = 0; i < val.GetLength(0); i++)
                {
                    mCmbBox.Items.Add(val[i, 1].oContent);
                }

                //mCmbBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return mCmbBox;
        }

        public static System.Windows.Forms.ComboBox BuildComboxAno(CEnum.Message_Body[,] val, System.Windows.Forms.ComboBox mCmbBox)
        {
            try
            {
                mCmbBox.Items.Clear();
                for (int i = 1; i < val.GetLength(0); i++)
                {
                    mCmbBox.Items.Add(val[i, 1].oContent);
                }

                mCmbBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return mCmbBox;
        }

        #endregion

        public static CEnum.Message_Body[,] GetGsServerList(CSocketEvent mEvent, CEnum.Message_Body[] mContent)
        {
            CEnum.Message_Body[,] mReturn = null;

            mReturn =
                mEvent.RequestResult(CEnum.ServiceKey.AU_MsgServerinfo_Query, CEnum.Msg_Category.COMMON, mContent);

            return mReturn;
        }

        #region 构造 DataGridView内容
        public static DataTable BuildDataTable(CSocketEvent mEvent, CEnum.Message_Body[,] val, System.Windows.Forms.DataGridView mGrid, out int PageCount)
        {
            ConfigValue config = (ConfigValue)mEvent.GetInfo("INI");

            DataTable mDataTable = BuildColumn(mEvent, val);

            mGrid.DataSource = BuildRow(mEvent, val, mDataTable, out PageCount);

            return null;
        }
        #endregion

        #region 构造 DataGridView列
        /// <summary>
        /// 构造 DataGridView 列
        /// </summary>
        /// <param name="val">数据</param>
        /// <param name="mDataTable">DataTable</param>
        /// <returns>DataTable</returns>
        private static DataTable BuildColumn(CSocketEvent mEvent, CEnum.Message_Body[,] val)
        {
            DataTable mDataTable = new DataTable();
            try
            {

                ConfigValue config = (ConfigValue)mEvent.GetInfo("INI");

                for (int i = 0; i < val.GetLength(1); i++)
                {
                    if (val[0, i].eName != CEnum.TagName.PageCount)
                    {
                        string middle = (string)config.ReadConfigValue("GLOBAL", val[0, i].eName.ToString());
                        mDataTable.Columns.Add(middle, typeof(string));

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return mDataTable;
        }
        #endregion

        #region 构造 DataGridView行
        /// <summary>
        /// 构造 DataGridView 列
        /// </summary>
        /// <param name="val">数据</param>
        /// <param name="mDataRow">DataRow</param>
        /// <returns>DataRow</returns>
        private static DataTable BuildRow(CSocketEvent mEvent, CEnum.Message_Body[,] m_val, DataTable mTable, out int PageCount)
        {
            try
            {
                PageCount = 0;
                ConfigValue config = (ConfigValue)mEvent.GetInfo("INI");
                CEnum.Message_Body[,] val = m_val;
                for (int i = 0; i < val.GetLength(0); i++)
                {
                    DataRow mRow = mTable.NewRow();

                    for (int j = 0; j < val.GetLength(1); j++)
                    {
                        if (val[i, j].eName != CEnum.TagName.PageCount)
                        {
                            if (val[i, j].eName == CEnum.TagName.Magic_Sex)
                            {
                                val[i, j].oContent = val[i, j].oContent.ToString() == "0" ? config.ReadConfigValue("MLord", "UIC_Code_male") : config.ReadConfigValue("MLord", "UIC_Code_female");
                            }
                            if (val[i, j].eName == CEnum.TagName.SD_N12)
                            {
                                if (val[i, j].oContent.ToString() == "0")
                                {
                                    val[i, j].oContent = "G币";
                                }
                                else if (val[i, j].oContent.ToString() == "1")
                                {
                                    val[i, j].oContent = "M币";
                                }
                            }
                            if (val[i, j].eName == CEnum.TagName.SD_ItemName)
                            {
                                if (val[i, j].oContent.ToString() == "")
                                {
                                    val[i, j].oContent = "无道具";
                                }
                                else
                                {
                                    mRow[(string)config.ReadConfigValue("GLOBAL", val[i, j].eName.ToString())] = val[i, j].oContent.ToString();
                                }
                            }

                            if (val[i, j].eName == CEnum.TagName.SD_ItemName1)
                            {
                                if (val[i, j].oContent.ToString() == "")
                                {
                                    val[i, j].oContent = "无道具";
                                }
                                else
                                {
                                    mRow[(string)config.ReadConfigValue("GLOBAL", val[i, j].eName.ToString())] = val[i, j].oContent.ToString();
                                }
                            }

                            if (val[i, j].eName == CEnum.TagName.SD_ItemName2)
                            {
                                if (val[i, j].oContent.ToString() == "")
                                {
                                    val[i, j].oContent = "无道具";
                                }
                                else
                                {
                                    mRow[(string)config.ReadConfigValue("GLOBAL", val[i, j].eName.ToString())] = val[i, j].oContent.ToString();
                                }
                            }

                            if (val[i, j].eName == CEnum.TagName.SD_ItemName3)
                            {
                                if (val[i, j].oContent.ToString() == "")
                                {
                                    val[i, j].oContent = "无道具";
                                }
                                else
                                {
                                    mRow[(string)config.ReadConfigValue("GLOBAL", val[i, j].eName.ToString())] = val[i, j].oContent.ToString();
                                }
                            }
                            if (val[i, j].eName == CEnum.TagName.SD_Type)
                            {
                                if (val[i, j].oContent.ToString() == "0")
                                {
                                    val[i, j].oContent = config.ReadConfigValue("MSD", "NM_UI_cmbNoticeCheck");
                                }
                                if (val[i, j].oContent.ToString() == "1")
                                {
                                    val[i, j].oContent = config.ReadConfigValue("MSD", "NM_UI_cmbNoticeCommon");
                                }
                                if (val[i, j].oContent.ToString() == "2")
                                {
                                    val[i, j].oContent = config.ReadConfigValue("MSD", "NM_UI_cmbNoticeEvent");
                                }
                                if (val[i, j].oContent.ToString() == "3")
                                {
                                    val[i, j].oContent = config.ReadConfigValue("MSD", "NM_UI_cmbNoticeSystem");
                                }
                            }
                            if (val[i, j].eName == CEnum.TagName.SD_BuyType)
                            {
                                if (val[i, j].oContent.ToString() == "0")
                                {
                                    val[i, j].oContent = config.ReadConfigValue("MSD", "NM_UI_cmbBuyGet");
                                }
                                if (val[i, j].oContent.ToString() == "1")
                                {
                                    val[i, j].oContent = config.ReadConfigValue("MSD", "NM_UI_cmbComboxGet");
                                }
                                if (val[i, j].oContent.ToString() == "99")
                                {
                                    val[i, j].oContent = config.ReadConfigValue("MSD", "NM_UI_cmbOfficeSend");
                                }
                            }
                            if (val[i, j].eName == CEnum.TagName.SD_Star)
                            {
                                if (val[i, j].oContent.ToString() == "2")
                                {
                                    val[i, j].oContent = "C级";
                                }
                                if (val[i, j].oContent.ToString() == "4")
                                {
                                    val[i, j].oContent = "A级";
                                }
                                if (val[i, j].oContent.ToString() == "5")
                                {
                                    val[i, j].oContent = "S级";
                                }
                                if (val[i, j].oContent.ToString() == "3")
                                {
                                    val[i, j].oContent = "B级";
                                }
                            }
                             
                            if (val[i, j].eName == CEnum.TagName.JW2_Sex)
                            {
                                if (val[i, j].oContent.ToString() == "1")
                                {
                                    val[i, j].oContent ="男";
                                }
                                else if(val[i, j].oContent.ToString() == "0")
                                {
                                    val[i, j].oContent = "女";
                                }
                            }


                            if (val[i, j].eName == CEnum.TagName.JW2_IntRo)
                            {
                                if (val[i, j].oContent.ToString() == "1")
                                {
                                    val[i, j].oContent = "别人赠送";
                                }
                                else if (val[i, j].oContent.ToString() == "0")
                                {
                                    val[i, j].oContent = "自己购买";
                                }
                            }


                            if (val[i, j].eName == CEnum.TagName.JW2_VailedDay)
                            {
                                if (val[i, j].oContent.ToString() == "65535")
                                {
                                    val[i, j].oContent = "无限次";
                                }
                              
                            }

                            if (val[i, j].eName == CEnum.TagName.JW2_Center_State)
                            {
                                if (val[i, j].oContent.ToString() == "0")
                                {
                                    val[i, j].oContent = "装备";
                                }
                                else if(val[i, j].oContent.ToString() == "2")
                                {
                                    val[i, j].oContent = "未装备";
                                }
                            }
                            //if (val[i, j].eName == CEnum.TagName.SD_Type)
                            //{
                            //    if (val[i, j].oContent.ToString() == "0")
                            //    {
                            //        val[i, j].oContent = "point";
                            //    }
                            //    if (val[i, j].oContent.ToString() == "1")
                            //    {
                            //        val[i, j].oContent = "cash";
                            //    }
                            //}
                            if (val[i, j].eName == CEnum.TagName.JW2_Status)
                            {
                                

                                if (val[i, j].oContent.ToString() == "0")
                                {
                                    val[i, j].oContent = config.ReadConfigValue("MJW2", "FN_Code_msgNoSendupdatenotice");
                                }
                                if (val[i, j].oContent.ToString() == "1")
                                {
                                    val[i, j].oContent = config.ReadConfigValue("MJW2", "FN_Code_msgSendedupdatenotice");
                                }
                                if (val[i, j].oContent.ToString() == "2")
                                {
                                    val[i, j].oContent = config.ReadConfigValue("MJW2", "FN_Code_msgSendingupdatenotice");
                                }
                            }
                            if (val[i, j].eName == CEnum.TagName.Magic_GuildID)
                            {
                                if (val[i, j].oContent.ToString() == "0")
                                {
                                    val[i, j].oContent = config.ReadConfigValue("MLord", "UIC_Code_NoGuild");
                                }
                                else
                                {
                                    mRow[(string)config.ReadConfigValue("GLOBAL", val[i, j].eName.ToString())] = val[i, j].oContent.ToString();
                                }
                            }

                            if (val[i, j].eName == CEnum.TagName.JW2_BuyLimitDay)
                            {
                                if (val[i, j].oContent.ToString() == "0")
                                {
                                    val[i, j].oContent = "永久";
                                }
                              
                            }
                            
                            if (val[i, j].eName == CEnum.TagName.JW2_UseItem)
                            {
                                if (val[i, j].oContent.ToString() == "1")
                                {
                                    val[i, j].oContent = "使用中";
                                }
                                else if (val[i, j].oContent.ToString() == "0")
                                {
                                    val[i, j].oContent = "不使用";
                                }
                            }

                            if (val[i, j].eName == CEnum.TagName.JW2_RemainCount)
                            {
                                if (val[i, j].oContent.ToString() == "0")
                                {
                                    val[i, j].oContent = "无限次";
                                }
                            
                            }

                            if (val[i, j].eName == CEnum.TagName.JW2_LOGINTYPE)
                            {
                                if (val[i, j].oContent.ToString() == "0")
                                {
                                    val[i, j].oContent = "登出";
                                }
                                else if(val[i, j].oContent.ToString() == "1")
                                {
                                    val[i, j].oContent = "登入";
                                }
                            }


                            if (val[i, j].eName == CEnum.TagName.JW2_GOODSTYPE)
                            {
                                if (val[i, j].oContent.ToString() == "0")
                                {
                                    val[i, j].oContent = "宠物喂食";
                                }
                                else if(val[i, j].oContent.ToString() == "1")
                                {
                                    val[i, j].oContent = "宠物进化";
                                }
                                else if (val[i, j].oContent.ToString() == "2")
                                {
                                    val[i, j].oContent = "宠物买动作";
                                }
                                else if (val[i, j].oContent.ToString() == "3")
                                {
                                    val[i, j].oContent = "信纸";
                                }
                                else if (val[i, j].oContent.ToString() == "4")
                                {
                                    val[i, j].oContent = "发信";
                                }
                                else if (val[i, j].oContent.ToString() == "7")
                                {
                                    val[i, j].oContent = "化妆";
                                }
                                else if (val[i, j].oContent.ToString() == "6")
                                {
                                    val[i, j].oContent = "中间件";
                                }
                                else if (val[i, j].oContent.ToString() == "8")
                                {
                                    val[i, j].oContent = "diy";
                                }
                                else if (val[i, j].oContent.ToString() == "9")
                                {
                                    val[i, j].oContent = "mb兑换素材";
                                }
                                else if(val[i, j].oContent.ToString() == "15")
                                {
                                    val[i, j].oContent = "婚礼预定";
                                }
                            }
                            

                            if (val[i, j].eName == CEnum.TagName.JW2_ItemPos)
                            {
                                if (val[i, j].oContent.ToString() == "0")
                                {
                                    val[i, j].oContent = "身上";
                                }
                                else if (val[i, j].oContent.ToString() == "1")
                                {
                                    val[i, j].oContent = "物品栏";
                                }
                                else if (val[i, j].oContent.ToString() == "2")
                                {
                                    val[i, j].oContent = "礼物栏";
                                }
                            }
                            if (val[i, j].eName == CEnum.TagName.JW2_BUGLETYPE)
                            {
                                if (val[i, j].oContent.ToString() == "0")
                                {
                                    val[i, j].oContent = "m币小喇叭";
                                }
                                else if (val[i, j].oContent.ToString() == "1")
                                {
                                    val[i, j].oContent = "m币大喇叭";
                                }
                                else if (val[i, j].oContent.ToString() == "2")
                                {
                                    val[i, j].oContent = "m币炫彩小喇叭";
                                }
                                else if (val[i, j].oContent.ToString() == "3")
                                {
                                    val[i, j].oContent = "m币炫彩大喇叭";
                                }
                                else if (val[i, j].oContent.ToString() == "10")
                                {
                                    val[i, j].oContent = "积分小喇叭";
                                }
                                else if (val[i, j].oContent.ToString() == "11")
                                {
                                    val[i, j].oContent = "积分大喇叭";
                                }
                                else if (val[i, j].oContent.ToString() == "12")
                                {
                                    val[i, j].oContent = "积分炫彩小喇叭";
                                }
                                else if (val[i, j].oContent.ToString() == "13")
                                {
                                    val[i, j].oContent = "积分炫彩大喇叭";
                                }
                                else if (val[i, j].oContent.ToString() == "20")
                                {
                                    val[i, j].oContent = "告白横幅";
                                }
                                else if (val[i, j].oContent.ToString() == "21")
                                {
                                    val[i, j].oContent = "生日横幅";
                                }
                                else if (val[i, j].oContent.ToString() == "22")
                                {
                                    val[i, j].oContent = "春节横幅";
                                }
                                else if (val[i, j].oContent.ToString() == "23")
                                {
                                    val[i, j].oContent = "召唤横幅";
                                }
                                else if (val[i, j].oContent.ToString() == "24")
                                {
                                    val[i, j].oContent = "热恋横幅";
                                }
                                else if (val[i, j].oContent.ToString() == "25")
                                {
                                    val[i, j].oContent = "怨念横幅";
                                }
                               
                                else if (val[i, j].oContent.ToString() == "40")
                                {
                                    val[i, j].oContent = "告白横幅";
                                }
                                else if (val[i, j].oContent.ToString() == "41")
                                {
                                    val[i, j].oContent = "生日横幅";
                                }
                                else if (val[i, j].oContent.ToString() == "42")
                                {
                                    val[i, j].oContent = "春节横幅";
                                }
                                else if (val[i, j].oContent.ToString() == "43")
                                {
                                    val[i, j].oContent = "召唤横幅";
                                }
                                else if (val[i, j].oContent.ToString() == "44")
                                {
                                    val[i, j].oContent = "热恋横幅";
                                }
                                else if (val[i, j].oContent.ToString() == "45")
                                {
                                    val[i, j].oContent = "怨念横幅";
                                }
                                //else if (int.Parse(val[i, j].oContent.ToString()) >=20)
                                //{
                                //    val[i, j].oContent = "横幅";
                                //}
                            }

                            if (val[i, j].eName == CEnum.TagName.JW2_Forever)
                            {
                                if (val[i, j].oContent.ToString() == "1")
                                {
                                    val[i, j].oContent = "永久";
                                }
                                else if (val[i, j].oContent.ToString() == "0")
                                {
                                    val[i, j].oContent = "非永久";
                                }
                               
                            }
                            if (val[i, j].eName == CEnum.TagName.JW2_SubGameID)
                            {
                                if (val[i, j].oContent.ToString() == "1")
                                {
                                    val[i, j].oContent = "劲舞团2";
                                }
                                else if(val[i, j].oContent.ToString() == "0")
                                {
                                    val[i, j].oContent = "吉堂";
                                }
                            }

                            if (val[i, j].eName == CEnum.TagName.JW2_Sex)
                            {
                                if (val[i, j].oContent.ToString() == "1")
                                {
                                    val[i, j].oContent = "男";
                                }
                                else if (val[i, j].oContent.ToString() == "2")
                                {
                                    val[i, j].oContent = "女";
                                }
                            }

                            if (val[i, j].eName == CEnum.TagName.JW2_SubGameID)
                            {
                                if (val[i, j].oContent.ToString() == "0")
                                {
                                    val[i, j].oContent = "吉堂";
                                }
                                else if (val[i, j].oContent.ToString() == "1")
                                {
                                    val[i, j].oContent = "劲舞团2";
                                }
                            }
                            if (val[i, j].eName == CEnum.TagName.JW2_ReportType)
                            {
                                if (val[i, j].oContent.ToString() == "1")
                                {
                                    val[i, j].oContent = "昵称有问题";
                                }
                                else if (val[i, j].oContent.ToString() == "2")
                                {
                                    val[i, j].oContent = "房间名有问题";
                                }
                                else if (val[i, j].oContent.ToString() == "4")
                                {
                                    val[i, j].oContent = "大小喇叭有问题";
                                }
                                else if (val[i, j].oContent.ToString() == "8")
                                {
                                    val[i, j].oContent = "横幅内容有问题";
                                }
                                else if (val[i, j].oContent.ToString() == "16")
                                {
                                    val[i, j].oContent = "宠物名字有问题";
                                }
                                else if (val[i, j].oContent.ToString() == "32")
                                {
                                    val[i, j].oContent = "家族名有问题";
                                }
                                else if (val[i, j].oContent.ToString() == "64")
                                {
                                    val[i, j].oContent = "聊天内容有问题";
                                }
                                else if (val[i, j].oContent.ToString() == "128")
                                {
                                    val[i, j].oContent = "名片信息有问题";
                                }
                                else if (val[i, j].oContent.ToString() == "256")
                                {
                                    val[i, j].oContent = "小屋留言板有问题";
                                }
                                else if (val[i, j].oContent.ToString() == "512")
                                {
                                    val[i, j].oContent = "家族论坛有问题";
                                }
                                else if (val[i, j].oContent.ToString() == "1024")
                                {
                                    val[i, j].oContent = "外挂";
                                }


                            }

                            //JW2_Level

                            if (val[i, j].eName == CEnum.TagName.JW2_FamilyLevel)
                            {
                            
                                if (val[i, j].oContent.ToString() == "0")
                                {
                                    val[i, j].oContent = "基本";
                                }
                                else if (val[i, j].oContent.ToString() == "1")
                                {
                                    val[i, j].oContent = "初级";
                                }
                                else if (val[i, j].oContent.ToString() == "2")
                                {
                                    val[i, j].oContent = "中级";
                                }
                                else if (val[i, j].oContent.ToString() == "3")
                                {
                                    val[i, j].oContent = "高级";
                                }
                                else if (val[i, j].oContent.ToString() == "4")
                                {
                                    val[i, j].oContent = "豪华";
                                }
                                else if (val[i, j].oContent.ToString() == "5")
                                {
                                    val[i, j].oContent = "水晶";
                                }
                                else if (val[i, j].oContent.ToString() == "6")
                                {
                                    val[i, j].oContent = "钻石";
                                }

                            }
                            if (val[i, j].eName == CEnum.TagName.JW2_Type)
                            {
                                if (val[i, j].oContent.ToString() == "1")
                                {
                                    val[i, j].oContent = "未审核";
                                }
                                else if(val[i, j].oContent.ToString() == "2")
                                {
                                    val[i, j].oContent = "审核通过";
                                }
                                else if (val[i, j].oContent.ToString() == "3")
                                {
                                    val[i, j].oContent = "审核未通过";
                                }
                            }


                            if (val[i, j].eName == CEnum.TagName.jw2_Wedding_Home)
                            {
                                if (val[i, j].oContent.ToString() == "500")
                                {
                                    val[i, j].oContent = "浪漫小屋";
                                }
                                else if (val[i, j].oContent.ToString() == "1000")
                                {
                                    val[i, j].oContent = "豪华宫殿";
                                }
                                else if (val[i, j].oContent.ToString() == "700")
                                {
                                    val[i, j].oContent = "温馨小筑";
                                }
                            }
                            if (val[i, j].eName == CEnum.TagName.JW2_DUTYNAME)
                            {
                                if (val[i, j].oContent.ToString() == "0")
                                {
                                    val[i, j].oContent = "申请加入";
                                }
                                else if (val[i, j].oContent.ToString() == "1")
                                {
                                    val[i, j].oContent = "家族成员";
                                }
                                else if (val[i, j].oContent.ToString() == "2")
                                {
                                    val[i, j].oContent = "家族执政官";
                                }
                                else if (val[i, j].oContent.ToString() == "3")
                                {
                                    val[i, j].oContent = "高级执政官";
                                }
                                else if (val[i, j].oContent.ToString() == "4")
                                {
                                    val[i, j].oContent = "家族副族长";
                                }
                                else if (val[i, j].oContent.ToString()=="255")
                                {
                                    val[i, j].oContent = "家族族长 ";
                                }
                               
                            }
                            if (val[i, j].oContent == null)
                            {
                                mRow[(string)config.ReadConfigValue("GLOBAL", val[i, j].eName.ToString())] = "N/A";
                            }
                            else
                            {
                                mRow[(string)config.ReadConfigValue("GLOBAL", val[i, j].eName.ToString())] = val[i, j].oContent.ToString();
                            }
                        }
                        else
                        {
                            PageCount = int.Parse(val[i, j].oContent.ToString());
                        }
                    }

                    mTable.Rows.Add(mRow);

                }

                return mTable;
            }
            catch (Exception ex)
            {
                PageCount = 0;
                MessageBox.Show(ex.Message);
                return null;
            }

        }
        #endregion

        #region 获取 ComboBox 选定项索引
        /// <summary>
        /// 获取 ComboBox 选定项索引
        /// </summary>
        /// <param name="val">记录集</param>
        /// <param name="Condition">搜索条件</param>
        /// <returns></returns>
        public static string GetItemAddr(CEnum.Message_Body[,] val, string Condition)
        {
            string strResult = null;

            for (int i = 0; i < val.GetLength(0); i++)
            {
                for (int j = 0; j < val.GetLength(1); j++)
                {
                    if (val[i, j].eName == CEnum.TagName.ServerInfo_IP && val[i, j + 1].oContent.Equals(Condition))
                    {
                        strResult = val[i, j].oContent.ToString();
                    }
                }
            }

            return strResult;
        }
        #endregion

        #region 根据ComboBox选定项获取所需ID
        /// <summary>
        /// 根据ComboBox选定项获取所需ID
        /// </summary>
        /// <param name="val">记录集</param>
        /// <param name="Condition">搜索条件</param>
        /// <returns></returns>
        public static string GetContent(CEnum.Message_Body[,] val, string Condition)
        {
            string strResult = null;

            for (int i = 0; i < val.GetLength(0); i++)
            {
                for (int j = 0; j < val.GetLength(1); j++)
                {
                    if (val[i, j + 1].oContent.Equals(Condition))
                    {
                        strResult = val[i, j].oContent.ToString();
                        break;
                    }
                }
            }

            return strResult;
        }
        #endregion

        public static int GetSeverPort(CEnum.Message_Body[,] val, string Condition)
        {
            string strResult = null;

            for (int i = 0; i < val.GetLength(0); i++)
            {
                for (int j = 0; j < val.GetLength(1); j++)
                {
                    if (val[i, 1].oContent.Equals(Condition))
                    {
                        strResult = val[i,3].oContent.ToString();
                        break;
                    }
                }
            }

            return int.Parse(strResult);
        }


        public static int Getserverno(CEnum.Message_Body[,] val, string Condition)
        {
            string strResult = null;

            for (int i = 0; i < val.GetLength(0); i++)
            {
                for (int j = 0; j < val.GetLength(1); j++)
                {
                    if (val[i, 1].oContent.Equals(Condition))
                    {
                        strResult = val[i, 0].oContent.ToString();
                        break;
                    }
                }
            }

            return int.Parse(strResult);
        }

        public static string GetGSServerIp(CEnum.Message_Body[,] val, string Condition)
        {
            string strResult = null;

            for (int i = 0; i < val.GetLength(0); i++)
            {
                for (int j = 0; j < val.GetLength(1); j++)
                {
                    if (val[i, 1].oContent.Equals(Condition))
                    {
                        strResult = val[i, 2].oContent.ToString();
                        break;
                    }
                }
            }

            return strResult;
        }
        #region 显示操作结果
        public static void showResult(CEnum.Message_Body[,] val)
        {
            if (val[0, 0].oContent.ToString().Trim() == "SCUESS")
            {
                MessageBox.Show("巨Θ");
                //Operation_JW2.errLog.WriteLog(val[0,0].oContent.ToString());
            }
            else if (val[0, 0].oContent.ToString().Trim() == "FAILURE")
            {
                MessageBox.Show("巨ア毖");
                //Operation_JW2.errLog.WriteLog(val[0, 0].oContent.ToString());
            }
            else
            {
                MessageBox.Show(val[0, 0].oContent.ToString().Trim());
                //Operation_JW2.errLog.WriteLog(val[0, 0].oContent.ToString());
            }
        }
        #endregion
    }
}
