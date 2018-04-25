
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using C_Global;
using C_Event;
using Language;
using System.Windows.Forms;

namespace M_RC
{
    class Operation_RC
    {
        public CSocketEvent m_ClientEvent = null;
        public static int iPageSize = 50;
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
        }

        #endregion

        public static string GetGsip(CEnum.Message_Body[,] val, string Condition)
        {
            string strResult = null;

            for (int i = 0; i < val.GetLength(0); i++)
            {
                for (int j = 0; j < val.GetLength(1); j++)
                {
                    if (val[i, j].eName == CEnum.TagName.AU_GSName && val[i, j].oContent.Equals(Condition))
                    {
                        strResult = val[i, j + 1].oContent.ToString();
                    }
                }
            }

            return strResult;
        }

        public static object DecodeContent(CEnum.TagFormat mFormat, string mContent)
        {
            object mObject = null;

            switch (mFormat)
            {
                case CEnum.TagFormat.TLV_BOOLEAN:
                    mObject = Convert.ToBoolean(mContent);
                    break;
                case CEnum.TagFormat.TLV_INTEGER:
                    mObject = Convert.ToInt32(mContent);
                    break;
                case CEnum.TagFormat.TLV_DATE:
                    mObject = Convert.ToDateTime(mContent).Date;
                    break;
                case CEnum.TagFormat.TLV_TIME:
                    mObject = Convert.ToDateTime(mContent).TimeOfDay;
                    break;
                case CEnum.TagFormat.TLV_EXTEND:
                case CEnum.TagFormat.TLV_MONEY:
                    mObject = Convert.ToDouble(mContent);
                    break;
                case CEnum.TagFormat.TLV_NUMBER:
                    mObject = Convert.ToInt32(mContent);
                    break;
                case CEnum.TagFormat.TLV_STRING:
                    mObject = mContent;
                    break;
                case CEnum.TagFormat.TLV_TIMESTAMP:
                    mObject = Convert.ToDateTime(mContent);
                    break;
            }

            return mObject;
        }

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
                mEvent.RequestResult(mKey, CEnum.Msg_Category.RC_ADMIN, mContent);

            return mReturn;
        }

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
            catch
            {

            }

            return mCmbBox;
        }

        public static System.Windows.Forms.ComboBox BuildComboxs(CSocketEvent mEvent, CEnum.Message_Body[,] val, System.Windows.Forms.ComboBox mCmbBox)
        {
            //try
            //{
            //    for (int i = 0; i < val.GetLength(0); i++)
            //    {
            //        mCmbBox.Items.Add(val[i, 1].oContent + "(" + val[i, 3].oContent + ")");
            //    }

            //    mCmbBox.SelectedIndex = 0;
            //}
            //catch
            //{

            //}

            //return mCmbBox;
            ConfigValue config = (ConfigValue)mEvent.GetInfo("INI");
            try
            {

                ArrayList All = new ArrayList();
                ArrayList DayLimitList = new ArrayList();
                ArrayList ItemCodeList = new ArrayList();
                for (int i = 0; i < val.GetLength(0); i++)
                {
                    mCmbBox.Items.Add((val[i, 5].oContent.ToString() == "0") ? ("(" + val[i, 3].oContent + ")" + config.ReadConfigValue("MSDO", "OP_Code_perpetuity")) : ("(" + val[i, 3].oContent + ")" + "[" + val[i, 5].oContent + config.ReadConfigValue("MSDO", "OP_Code_days")) + "]");
                    //mCmbBox.Items.Add(val[i, 1].oContent + "(" + val[i, 3].oContent + ")");
                    DayLimitList.Add(val[i, 5].oContent.ToString());
                    ItemCodeList.Add(val[i, 2].oContent.ToString());
                }
                All.Add(DayLimitList);
                All.Add(ItemCodeList);
                mCmbBox.SelectedIndex = 0;
                mCmbBox.Tag = All;
            }
            catch
            {

            }

            return mCmbBox;
        }

        public static DataTable BuildDataTable(CSocketEvent mEvent, CEnum.Message_Body[,] val, System.Windows.Forms.DataGridView mGrid, out int PageCount)
        {
            ConfigValue config = (ConfigValue)mEvent.GetInfo("INI");

            DataTable mDataTable = BuildColumn(mEvent, val);


            mGrid.DataSource = BuildRow(mEvent, val, mDataTable, out PageCount);


            return null;
        }

        public static object GetTimes(CEnum.Message_Body[,] val, string iItemID)
        {
            object oResult = null;
            for (int i = 0; i < val.GetLength(0); i++)
            {
                if (iItemID.Equals(val[i, 0].oContent.ToString()))
                {
                    oResult = val[i, 2].oContent;
                    break;
                }
            }

            return oResult;
        }

       //public static string ReturnClientIp()
        //{
            //string ClientIp = "";
            //System.Net.IPAddress[] addressList = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList;
            //ClientIp = addressList[0].ToString();
            //return ClientIp;
        //}

        public static object GetLimit(CEnum.Message_Body[,] val, string iItemID)
        {
            object oResult = null;
            for (int i = 0; i < val.GetLength(0); i++)
            {
                if (iItemID.Equals(val[i, 0].oContent.ToString()))
                {
                    oResult = val[i, 3].oContent;
                    break;
                }
            }

            return oResult;
        }

        #region 私有函数
        /// <summary>
        /// 构造 DataGridView 列
        /// </summary>
        /// <param name="val">数据</param>
        /// <param name="mDataTable">DataTable</param>
        /// <returns>DataTable</returns>
        private static DataTable BuildColumn(CSocketEvent mEvent, CEnum.Message_Body[,] val)
        {
            DataTable mDataTable = new DataTable();
            ConfigValue config = (ConfigValue)mEvent.GetInfo("INI");

            for (int i = 0; i < val.GetLength(1); i++)
            {
                if (val[0, i].eName != CEnum.TagName.PageCount && val[0, i].eName != CEnum.TagName.FJ_BoardFlag)
                {

                    mDataTable.Columns.Add((string)config.ReadConfigValue("GLOBAL", val[0, i].eName.ToString()), typeof(string));

                    //mDataTable.Columns.Add((string)mEvent.DecodeFieldName(val[0, i].eName), typeof(string));
                }
            }

            return mDataTable;
        }

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
                        if (val[i, j].eName != CEnum.TagName.PageCount && val[i, j].eName != CEnum.TagName.FJ_BoardFlag)
                        {

                            if (val[i, j].eName == CEnum.TagName.FJ_Sex)
                            {
                                if (val[i, j].oContent.ToString().Equals("0"))
                                    val[i, j].oContent = config.ReadConfigValue("MSDO", "OP_Code_Msex");
                                //mRow[(string)mEvent.DecodeFieldName(val[i, j].eName)] = config.ReadConfigValue("MSDO", "OP_Code_Fsex");
                                else
                                    val[i, j].oContent = config.ReadConfigValue("MSDO", "OP_Code_Fsex");
                                //mRow[(string)mEvent.DecodeFieldName(val[i, j].eName)] = config.ReadConfigValue("MSDO", "OP_Code_Msex");
                            }

                            if (val[i, j].oContent == null)
                            {
                                mRow[(string)config.ReadConfigValue("GLOBAL", val[i, j].eName.ToString())] = "N/A";
                                //mRow[(string)mEvent.DecodeFieldName(val[i, j].eName)] = "N/A";
                            }
                            else
                            {
                                mRow[(string)config.ReadConfigValue("GLOBAL", val[i, j].eName.ToString())] = val[i, j].oContent.ToString();
                                //mRow[(string)mEvent.DecodeFieldName(val[i, j].eName)] = val[i, j].oContent;
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
                return null;
            }

        }

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

        public static int GetItemID(CEnum.Message_Body[,] val, string Condition)
        {
            int iResult = 0;

            for (int i = 0; i < val.GetLength(0); i++)
            {
                for (int j = 0; j < val.GetLength(1); j++)
                {
                    if (val[i, j].eName == CEnum.TagName.SDO_ItemCode && val[i, j + 1].oContent.Equals(Condition))
                    {
                        iResult = int.Parse(val[i, j].oContent.ToString());
                    }
                }
            }

            return iResult;
        }

        public static int GetItemID(CEnum.Message_Body[,] val, int Condition)
        {
            int iResult = 0;

            try
            {
                iResult = int.Parse(val[Condition, 0].oContent.ToString());
            }
            catch
            {
                iResult = 0;
            }

            return iResult;
        }
        #endregion


    }

    class Operation_RCode
    {
        public CSocketEvent m_ClientEvent = null;
        public static int iPageSize = 40;
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
        }

        #endregion
        public static string GetGsip(CEnum.Message_Body[,] val, string Condition)
        {
            string strResult = null;

            for (int i = 0; i < val.GetLength(0); i++)
            {
                for (int j = 0; j < val.GetLength(1); j++)
                {
                    if (val[i, j].eName == CEnum.TagName.AU_GSName && val[i, j].oContent.Equals(Condition))
                    {
                        strResult = val[i, j + 1].oContent.ToString();
                    }
                }
            }

            return strResult;
        }
        public static object DecodeContent(CEnum.TagFormat mFormat, string mContent)
        {
            object mObject = null;

            switch (mFormat)
            {
                case CEnum.TagFormat.TLV_BOOLEAN:
                    mObject = Convert.ToBoolean(mContent);
                    break;
                case CEnum.TagFormat.TLV_INTEGER:
                    mObject = Convert.ToInt32(mContent);
                    break;
                case CEnum.TagFormat.TLV_DATE:
                    mObject = Convert.ToDateTime(mContent).Date;
                    break;
                case CEnum.TagFormat.TLV_TIME:
                    mObject = Convert.ToDateTime(mContent).TimeOfDay;
                    break;
                case CEnum.TagFormat.TLV_EXTEND:
                case CEnum.TagFormat.TLV_MONEY:
                    mObject = Convert.ToDouble(mContent);
                    break;
                case CEnum.TagFormat.TLV_NUMBER:
                    mObject = Convert.ToInt32(mContent);
                    break;
                case CEnum.TagFormat.TLV_STRING:
                    mObject = mContent;
                    break;
                case CEnum.TagFormat.TLV_TIMESTAMP:
                    mObject = Convert.ToDateTime(mContent);
                    break;
            }

            return mObject;
        }

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
                mEvent.RequestResult(mKey, CEnum.Msg_Category.RAYCITY_ADMIN, mContent);

            return mReturn;
        }

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
            catch
            {

            }

            return mCmbBox;
        }

        public static System.Windows.Forms.ComboBox BuildComboxs(CSocketEvent mEvent, CEnum.Message_Body[,] val, System.Windows.Forms.ComboBox mCmbBox)
        {
            //try
            //{
            //    for (int i = 0; i < val.GetLength(0); i++)
            //    {
            //        mCmbBox.Items.Add(val[i, 1].oContent + "(" + val[i, 3].oContent + ")");
            //    }

            //    mCmbBox.SelectedIndex = 0;
            //}
            //catch
            //{

            //}

            //return mCmbBox;
            ConfigValue config = (ConfigValue)mEvent.GetInfo("INI");
            try
            {

                ArrayList All = new ArrayList();
                ArrayList DayLimitList = new ArrayList();
                ArrayList ItemCodeList = new ArrayList();
                for (int i = 0; i < val.GetLength(0); i++)
                {
                    mCmbBox.Items.Add((val[i, 5].oContent.ToString() == "0") ? ("(" + val[i, 3].oContent + ")" + config.ReadConfigValue("MSDO", "OP_Code_perpetuity")) : ("(" + val[i, 3].oContent + ")" + "[" + val[i, 5].oContent + config.ReadConfigValue("MSDO", "OP_Code_days")) + "]");
                    //mCmbBox.Items.Add(val[i, 1].oContent + "(" + val[i, 3].oContent + ")");
                    DayLimitList.Add(val[i, 5].oContent.ToString());
                    ItemCodeList.Add(val[i, 2].oContent.ToString());
                }
                All.Add(DayLimitList);
                All.Add(ItemCodeList);
                mCmbBox.SelectedIndex = 0;
                mCmbBox.Tag = All;
            }
            catch
            {

            }

            return mCmbBox;
        }

        public static DataTable BuildDataTable(CSocketEvent mEvent, CEnum.Message_Body[,] val, System.Windows.Forms.DataGridView mGrid, out int PageCount)
        {
            ConfigValue config = (ConfigValue)mEvent.GetInfo("INI");

            DataTable mDataTable = BuildColumn(mEvent, val);


            mGrid.DataSource = BuildRow(mEvent, val, mDataTable, out PageCount);


            return null;
        }

        public static DataTable GetDataTable(CSocketEvent mEvent, CEnum.Message_Body[,] val,out int PageCount)
        {
            ConfigValue config = (ConfigValue)mEvent.GetInfo("INI");

            DataTable mDataTable = BuildColumn(mEvent, val);

            return BuildRow(mEvent, val, mDataTable, out PageCount);
        }

        public static object GetTimes(CEnum.Message_Body[,] val, string iItemID)
        {
            object oResult = null;
            for (int i = 0; i < val.GetLength(0); i++)
            {
                if (iItemID.Equals(val[i, 0].oContent.ToString()))
                {
                    oResult = val[i, 2].oContent;
                    break;
                }
            }

            return oResult;
        }

       // public static string ReturnClientIp()
        //{
            //string ClientIp = "";
            //System.Net.IPAddress[] addressList = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList;
            //ClientIp = addressList[0].ToString();
            //return ClientIp;
       // }

        public static object GetLimit(CEnum.Message_Body[,] val, string iItemID)
        {
            object oResult = null;
            for (int i = 0; i < val.GetLength(0); i++)
            {
                if (iItemID.Equals(val[i, 0].oContent.ToString()))
                {
                    oResult = val[i, 3].oContent;
                    break;
                }
            }

            return oResult;
        }

        #region 私有函数
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
                    if (val[0, i].eName != CEnum.TagName.PageCount && val[0, i].eName != CEnum.TagName.FJ_BoardFlag)
                    {

                        mDataTable.Columns.Add((string)config.ReadConfigValue("GLOBAL", val[0, i].eName.ToString()), typeof(string));

                        //mDataTable.Columns.Add((string)mEvent.DecodeFieldName(val[0, i].eName), typeof(string));
                    }
                }
            }
            catch
            { }

            return mDataTable;
        }

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
                        if (val[i, j].eName != CEnum.TagName.PageCount && val[i, j].eName != CEnum.TagName.FJ_BoardFlag)
                        {
                            if (val[i, j].eName == CEnum.TagName.RayCity_ActionType)
                            {
                                if (val[i, j].oContent.ToString().Equals("0"))
                                    val[i, j].oContent = config.ReadConfigValue("MRC", "OP_Code_loginout");
                                else
                                    val[i, j].oContent = config.ReadConfigValue("MRC", "OP_Code_login");
                            }

                            if (val[i, j].eName == CEnum.TagName.RayCity_ChargeState)
                            {
                                if (val[i, j].oContent.ToString().Equals("0"))
                                    val[i, j].oContent = "未知";
                                else if (val[i, j].oContent.ToString().Equals("1"))
                                    val[i, j].oContent = "已領取";
                                else if (val[i, j].oContent.ToString().Equals("2"))
                                    val[i, j].oContent = "未領取";
                            }

                            if (val[i, j].eName == CEnum.TagName.RayCity_NyGender)
                            {
                                if (val[i, j].oContent.ToString().Equals("1"))
                                    val[i, j].oContent = config.ReadConfigValue("MRC", "OP_Code_Fsex");
                                //mRow[(string)mEvent.DecodeFieldName(val[i, j].eName)] = config.ReadConfigValue("MSDO", "OP_Code_Fsex");
                                else
                                    val[i, j].oContent = config.ReadConfigValue("MRC", "OP_Code_Msex");
                                //mRow[(string)mEvent.DecodeFieldName(val[i, j].eName)] = config.ReadConfigValue("MSDO", "OP_Code_Msex");
                            }

                            if (val[i, j].eName == CEnum.TagName.RayCity_IsLogin)
                            {
                                if (val[i, j].oContent.ToString().Equals("0"))
                                    val[i, j].oContent = config.ReadConfigValue("MRC", "OP_Code_no");
                                //mRow[(string)mEvent.DecodeFieldName(val[i, j].eName)] = config.ReadConfigValue("MSDO", "OP_Code_Fsex");
                                else
                                    val[i, j].oContent = config.ReadConfigValue("MRC", "OP_Code_yes");
                                //mRow[(string)mEvent.DecodeFieldName(val[i, j].eName)] = config.ReadConfigValue("MSDO", "OP_Code_Msex");
                            }
                            if (val[i, j].eName == CEnum.TagName.RayCity_use_state)
                            {
                                if (val[i, j].oContent.ToString().Equals("0"))
                                    val[i, j].oContent = "已使用";
                                else
                                    val[i, j].oContent = "未使用";
                            }
                            if (val[i, j].oContent == null)
                            {
                                mRow[(string)config.ReadConfigValue("GLOBAL", val[i, j].eName.ToString())] = "N/A";
                                //mRow[(string)mEvent.DecodeFieldName(val[i, j].eName)] = "N/A";
                            }
                            else
                            {
                                mRow[(string)config.ReadConfigValue("GLOBAL", val[i, j].eName.ToString())] = val[i, j].oContent.ToString();
                                //mRow[(string)mEvent.DecodeFieldName(val[i, j].eName)] = val[i, j].oContent;
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
                return null;
            }

        }

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

        public static int GetItemID(CEnum.Message_Body[,] val, string Condition)
        {
            int iResult = 0;

            for (int i = 0; i < val.GetLength(0); i++)
            {
                for (int j = 0; j < val.GetLength(1); j++)
                {
                    if (val[i, j].eName == CEnum.TagName.SDO_ItemCode && val[i, j + 1].oContent.Equals(Condition))
                    {
                        iResult = int.Parse(val[i, j].oContent.ToString());
                    }
                }
            }

            return iResult;
        }

        public static int GetItemID(CEnum.Message_Body[,] val, int Condition)
        {
            int iResult = 0;

            try
            {
                iResult = int.Parse(val[Condition, 0].oContent.ToString());
            }
            catch
            {
                iResult = 0;
            }

            return iResult;
        }

        /// <summary>
        /// 构造 ComboBox 内容
        /// </summary>
        /// <param name="val">ComboBox 内容</param>
        /// <param name="mCmbBox">ComboBox 控件</param>
        /// <param name="ssd">存放ItemId</param>
        /// <returns></returns>
        public static System.Windows.Forms.ComboBox BuildCombox(CEnum.Message_Body[,] val, System.Windows.Forms.ComboBox mCmbBox, ShortStringDictionary ssd)
        {
            try
            {
                mCmbBox.Items.Clear();
                for (int i = 0; i < val.GetLength(0); i++)
                {
                    mCmbBox.Items.Add(val[i, 1].oContent);
                    ssd.Add(val[i, 1].oContent.ToString(), val[i, 0].oContent.ToString());
                }

                mCmbBox.SelectedIndex = 0;
            }
            catch
            {

            }

            return mCmbBox;
        }


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="val"></param>
        ///// <param name="mDataGridView"></param>
        ///// <returns></returns>
        //public static System.Windows.Forms.DataGridView BuildDataGridView(CEnum.Message_Body[,] val,System.Windows.Forms.DataGridView mDataGridView,int Index,System.ComponentModel.BackgroundWorker mBackgroundWorker)
        //{
        //    try
        //    {
        //        CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

        //        mContent[0].eName = CEnum.TagName.RayCity_NyUserID;
        //        mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
        //        mContent[0].oContent = TxtAccount.Text;

        //        mContent[1].eName = CEnum.TagName.RayCity_ServerIP;
        //        mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
        //        mContent[1].oContent = Operation_RC.GetItemAddr(mServerInfo, CmbServer.Text);

        //        mContent[2].eName = CEnum.TagName.RayCity_NyNickName;
        //        mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
        //        mContent[2].oContent = TxtNick.Text;

        //        mContent[3].eName = CEnum.TagName.Index;
        //        mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
        //        mContent[3].oContent =Index;

        //        mContent[4].eName = CEnum.TagName.PageSize;
        //        mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
        //        mContent[4].oContent =Operation_RCode.iPageSize;

        //        mBackgroundWorker.RunWorkerAsync(mContent);

        //    }
        //    catch
        //    { 
            
            
        //    }
        
        
        //}


        //public bool StartTask(DelegateGetResultApi getResultApi, Enum.ServiceKey mkey, Enum.MsgCategory msgcategory, Enum.Message_Body[] mContent)
        //{
        //    bool result = false;
        //    lock (this)
        //    {
        //        if (IsStop && getResultApi != null)
        //        {
        //            _result = null;
        //            System.Threading.Thread _callThread = System.Threading.Thread.CurrentThread;
        //            HashTread.Add(System.Threading.Thread.CurrentThread.ManagedThreadId, _iServer);
        //            // 开始工作方法进程,异步开启,传送回调方法
        //            getResultApi.BeginInvoke(mkey, msgcategory, mContent, new AsyncCallback(EndWorkBackApi), getResultApi);
        //            result = true;
        //        }
        //    }
        //    return result;
        //}

        //protected void EndWorkBackApi(IAsyncResult ar)
        //{

        //    try
        //    {
        //        DelegateGetResultApi del = (DelegateGetResultApi)ar.AsyncState;
        //        _result = del.EndInvoke(ar);
        //        _form.Invoke(_iServer, _result);
        //        System.Threading.Thread _workThread = System.Threading.Thread.CurrentThread;
        //        //_workThread.Abort();  
        //    }
        //    catch
        //    { }

        //}
        #endregion
    }
}
