using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using C_Global;
using C_Event;

namespace M_CR
{
    class Operation_Kart
    {
        public static int iPageSize = 15;
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
                mEvent.RequestResult(mKey, CEnum.Msg_Category.CR_ADMIN, mContent);

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

        public static DataTable BuildDataTable(CSocketEvent mEvent, CEnum.Message_Body[,] val, System.Windows.Forms.DataGridView mGrid, out int PageCount)
        {
            DataTable mDataTable = BuildColumn(mEvent, val);

            if (mGrid.Name == "GrdGift")
            {
                for (int i = 0; i < val.GetLength(0); i++)
                {
                    for (int j = 0; j < val.GetLength(1); j++)
                    {
                        if (val[i, j].eName == CEnum.TagName.SDO_BigType)
                        {
                            if (val[i, j].oContent.ToString() == "0")
                                val[i, j].oContent = "服装";
                            if (val[i, j].oContent.ToString() == "1")
                                val[i, j].oContent = "道具";
                        }

                        if (val[i, j].eName == CEnum.TagName.SDO_SmallType)
                        {
                            if (val[i, j].oContent.ToString() == "0")
                            {
                                if (val[i, j - 1].eName == CEnum.TagName.SDO_BigType && val[i, j - 1].oContent.ToString() == "0")
                                    val[i, j].oContent = "头";
                                else
                                    val[i, j].oContent = "道具";
                            }

                            if (val[i, j].oContent.ToString() == "100")
                                val[i, j].oContent = "头";

                            if (val[i, j].oContent.ToString() == "1" || val[i, j].oContent.ToString() == "101")
                                val[i, j].oContent = "头发";
                            if (val[i, j].oContent.ToString() == "2" || val[i, j].oContent.ToString() == "102")
                                val[i, j].oContent = "身体";
                            if (val[i, j].oContent.ToString() == "3" || val[i, j].oContent.ToString() == "103")
                                val[i, j].oContent = "腿";
                            if (val[i, j].oContent.ToString() == "4" || val[i, j].oContent.ToString() == "104")
                                val[i, j].oContent = "手";
                            if (val[i, j].oContent.ToString() == "5" || val[i, j].oContent.ToString() == "105")
                                val[i, j].oContent = "脚";
                            if (val[i, j].oContent.ToString() == "6" || val[i, j].oContent.ToString() == "106")
                                val[i, j].oContent = "表情";
                            if (val[i, j].oContent.ToString() == "150")
                                val[i, j].oContent = "连衣裙";
                        }
                    }
                }
            }

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

        public static string ConvertHex(string value)
        {
            string sReturn = string.Empty;
            try
            {

                while (int.Parse(value) > 16)
                {
                    int v = int.Parse(value);
                    sReturn = GetHexChar((v % 16).ToString()) + sReturn;
                    value = Math.Floor(Convert.ToDouble(v / 16)).ToString();
                }
                sReturn = GetHexChar(value) + sReturn;

                if (sReturn.Length < 2)
                {
                    sReturn = "0" + sReturn;
                }
            }
            catch
            {
                sReturn = "FFFFFF";
            }

            return sReturn;
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

            for (int i = 0; i < val.GetLength(1); i++)
            {
                if (val[0, i].eName != CEnum.TagName.PageCount)
                {
                    mDataTable.Columns.Add((string)mEvent.DecodeFieldName(val[0, i].eName), typeof(string));
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
        private static DataTable BuildRow(CSocketEvent mEvent, CEnum.Message_Body[,] val, DataTable mTable, out int PageCount)
        {
            PageCount = 0;
            for (int i = 0; i < val.GetLength(0); i++)
            {
                DataRow mRow = mTable.NewRow();

                for (int j = 0; j < val.GetLength(1); j++)
                {
                    if (val[i, j].eName != CEnum.TagName.PageCount)
                    {
                        if (val[i, j].eName == CEnum.TagName.SDO_MoneyType)
                        {
                            if (val[i, j].oContent.ToString() == "1")
                            {
                                val[i, j].oContent = "M";
                            }
                            else
                            {
                                val[i, j].oContent = "G";
                            }
                        }

                        if (val[i, j].eName == CEnum.TagName.SDO_SEX)
                        {
                            if (val[i, i].oContent.Equals("0"))
                                mRow[(string)mEvent.DecodeFieldName(val[i, j].eName)] = "女";
                            else
                                mRow[(string)mEvent.DecodeFieldName(val[i, j].eName)] = "男";
                        }

                        if (val[i, j].oContent == null)
                        {
                            mRow[(string)mEvent.DecodeFieldName(val[i, j].eName)] = "N/A";
                        }
                        else
                        {
                            mRow[(string)mEvent.DecodeFieldName(val[i, j].eName)] = val[i, j].oContent;
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

        private static string GetHexChar(string value)
        {
            string sReturn = string.Empty;
            switch (value)
            {
                case "10":
                    sReturn = "A";
                    break;
                case "11":
                    sReturn = "B";
                    break;
                case "12":
                    sReturn = "C";
                    break;
                case "13":
                    sReturn = "D";
                    break;
                case "14":
                    sReturn = "E";
                    break;
                case "15":
                    sReturn = "F";
                    break;
                default:
                    sReturn = value;
                    break;
            }
            return sReturn;
        }
        #endregion
    }
}
