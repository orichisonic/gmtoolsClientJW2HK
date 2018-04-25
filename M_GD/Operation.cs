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

namespace M_GD
{
    class Operation_GD
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
                mEvent.RequestResult(mKey, CEnum.Msg_Category.SD_ADMIN, mContent);

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
                            //if (val[i, j].eName == CEnum.TagName.Magic_Sex)
                            //{
                            //    val[i, j].oContent = val[i, j].oContent.ToString() == "0" ? config.ReadConfigValue("MLord", "UIC_Code_male") : config.ReadConfigValue("MLord", "UIC_Code_female");
                            //}
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
                                    val[i, j].oContent = config.ReadConfigValue("GLOBAL", "NM_UI_cmbNoticeCheck");
                                }
                                if (val[i, j].oContent.ToString() == "1")
                                {
                                    val[i, j].oContent = config.ReadConfigValue("GLOBAL", "NM_UI_cmbNoticeCommon");
                                }
                                if (val[i, j].oContent.ToString() == "2")
                                {
                                    val[i, j].oContent = config.ReadConfigValue("GLOBAL", "NM_UI_cmbNoticeEvent");
                                }
                                if (val[i, j].oContent.ToString() == "3")
                                {
                                    val[i, j].oContent = config.ReadConfigValue("GLOBAL", "NM_UI_cmbNoticeSystem");
                                }
                            }
                            if (val[i, j].eName == CEnum.TagName.SD_BuyType)
                            {
                                if (val[i, j].oContent.ToString() == "0")
                                {
                                    val[i, j].oContent = config.ReadConfigValue("GLOBAL", "NM_UI_cmbBuyGet");
                                }
                                if (val[i, j].oContent.ToString() == "1")
                                {
                                    val[i, j].oContent = config.ReadConfigValue("GLOBAL", "NM_UI_cmbComboxGet");
                                }
                                if (val[i, j].oContent.ToString() == "99")
                                {
                                    val[i, j].oContent = config.ReadConfigValue("GLOBAL", "NM_UI_cmbOfficeSend");
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
                             
                            if (val[i, j].eName == CEnum.TagName.f_gender)
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
                            if (val[i, j].eName == CEnum.TagName.SD_Status)
                            {
                                if (val[i, j].oContent.ToString() == "0")
                                {
                                    val[i, j].oContent = "未发送";
                                }
                                if (val[i, j].oContent.ToString() == "1")
                                {
                                    val[i, j].oContent = "已发送";
                                }
                                if (val[i, j].oContent.ToString() == "2")
                                {
                                    val[i, j].oContent = "发送中";
                                }
                            }
                            //if (val[i, j].eName == CEnum.TagName.Magic_GuildID)
                            //{
                            //    if (val[i, j].oContent.ToString() == "0")
                            //    {
                            //        val[i, j].oContent = config.ReadConfigValue("MLord", "UIC_Code_NoGuild");
                            //    }
                            //    else
                            //    {
                            //        mRow[(string)config.ReadConfigValue("GLOBAL", val[i, j].eName.ToString())] = val[i, j].oContent.ToString();
                            //    }
                            //}
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

        #region 显示操作结果
        public static void showResult(CEnum.Message_Body[,] val)
        {
            if (val[0, 0].oContent.ToString().Trim() == "SCUESS")
            {
                MessageBox.Show("操作成功");
            }
            else if (val[0, 0].oContent.ToString().Trim() == "FAILURE")
            {
                MessageBox.Show("操作失败");
            }
            else
            {
                MessageBox.Show(val[0, 0].oContent.ToString().Trim());
            }
        }
        #endregion
    }
}
