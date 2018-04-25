using System;
using System.Reflection;
using System.Collections;

using C_Global;
using C_Socket;
using System.Windows.Forms;

namespace C_Event
{
	/// <summary>
	/// CSocketEvent Socket事件。
	/// </summary>
	public class CSocketEvent
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="strAddress">服务器地址</param>
		/// <param name="iServerPort">服务器端口</param>
		public CSocketEvent(string strAddress, int iServerPort)
		{
			mSocketClient = new CSocketClient();
			
			if (!mSocketClient.Init(strAddress, iServerPort))
			{
				throw new Exception("无法找到服务器!");	
			}

			mSockData = new CSocketData();
		}

		/// <summary>
		/// 析构函数
		/// </summary>
		~CSocketEvent()
		{
			try
			{
				/*
				Message_Body[] mExitBody = new Message_Body[1];
				mExitBody[0].eName = C_Global.TagName.UserByID;
				mExitBody[0].eTag = C_Global.TagFormat.TLV_INTEGER;
				mExitBody[0].oContent = GetInfo("UserID");

				RequestResult(C_Global.ServiceKey.DISCONNECT, C_Global.Msg_Category.COMMON, mExitBody);
				*/

				mSocketClient.finallize();
			}
			catch (Exception)
			{
			
			}
		}

        // <summary>
        /// 封装数据集的消息包
        /// </summary>
        /// <param name="queryList">输入数据列表</param>
        /// <param name="colCnt">输入列数</param>
        /// <returns>返回数据集的消息包</returns>
        public static C_Socket.CSocketData COMMON_MES_RESP(Query_Structure[] queryList, C_Global.CEnum.Msg_Category category, C_Global.CEnum.ServiceKey service, int colCnt)
        {
            uint iPos = 0;
            TLV_Structure[] tlv = new TLV_Structure[queryList.Length * colCnt];
            int pos = 0;

            for (int i = 0; i < queryList.Length; i++)
            {
                for (int j = 0; j < colCnt; j++)
                {
                    //消息元素格式
                    C_Global.CEnum.TagFormat format_ = queryList[i].m_tagList[j].format;
                    //消息元素名称
                    C_Global.CEnum.TagName key_ = queryList[i].m_tagList[j].tag;
                    //消息元素的值
                    byte[] bgMsg_Value = queryList[i].m_tagList[j].tag_buf;
                    //消息的结构体
                    TLV_Structure Msg_Value = new C_Socket.TLV_Structure(key_, format_, (uint)bgMsg_Value.Length, bgMsg_Value);
                    tlv[pos++] = Msg_Value;
                    iPos += Msg_Value.m_uiValueLen;
                }
                if (iPos + 20 >= 7192)
                {
                    pos = i;
                    break;
                }
            }
            //封装消息体
            Packet_Body body = new C_Socket.Packet_Body(tlv, (uint)tlv.Length, (uint)colCnt);
            //封装消息头
            Packet_Head head = new C_Socket.Packet_Head(C_Socket.SeqId_Generator.Instance().GetNewSeqID(), category,service, body.m_uiBodyLen);
            return new C_Socket.CSocketData(new C_Socket.Packet(head, body));
        }

		/// <summary>
		/// 保存指定键的信息
		/// </summary>
		/// <param name="Key">键名</param>
		/// <param name="Data">数据</param>
		/// <returns>T：成功；F：失败</returns>
        public bool SaveInfo(object Key, object Data)
        {
            bool bSuccess = false;

            try
            {
                int iInfoCount = 0;
                bool bNewInfo = false;

                //对象是否存在
                if (this.mSaveInfo == null)
                {
                    this.mSaveInfo = new TSaveInfo[1];
                    this.mSaveInfo[0].oKey = Key;
                    this.mSaveInfo[0].oData = Data;
                }
                else
                {
                    iInfoCount = mSaveInfo.GetLength(0);

                    //检查已有键的值
                    for (int i = 0; i < iInfoCount; i++)
                    {
                        if (this.mSaveInfo[i].oKey.Equals(Key))
                        {
                            //替换
                            bNewInfo = false;

                            this.mSaveInfo[i].oData = Data;
                        }
                        else
                        {
                            //添加
                            bNewInfo = true;

                            this.mTempInfo = new TSaveInfo[iInfoCount + 1];


                            for (int j = 0; j < iInfoCount; j++)
                            {
                                this.mTempInfo[j].oKey = this.mSaveInfo[j].oKey;
                                this.mTempInfo[j].oData = this.mSaveInfo[j].oData;
                            }


                            this.mTempInfo[i].oKey = this.mSaveInfo[i].oKey;
                            this.mTempInfo[i].oData = this.mSaveInfo[i].oData;
                        }
                    }

                    //保存最终结果
                    if (bNewInfo)
                    {
                        //添加新键值
                        this.mTempInfo[iInfoCount].oKey = Key;
                        this.mTempInfo[iInfoCount].oData = Data;

                        //保存最新内容
                        this.mSaveInfo = this.mTempInfo;
                    }
                }

                bSuccess = true;
            }
            catch (Exception e)
            {
                bSuccess = false;

                CEnum.TLogData tLogData = new CEnum.TLogData();

                tLogData.iSort = 5;
                tLogData.strDescribe = "保存关键字内容失败!";
                tLogData.strException = e.Message;
            }

            return bSuccess;
        }

		/// <summary>
		/// 获取保存内容
		/// </summary>
		/// <param name="Key">键名</param>
		/// <returns>指定键的数据</returns>
		public object GetInfo(object Key)
		{
			object oResult = null;

			for (int i=0; i<this.mSaveInfo.GetLength(0); i++)
			{
				if (this.mSaveInfo[i].oKey.Equals(Key))
				{
					oResult = this.mSaveInfo[i].oData;
				}
			}
			
			return oResult;
		}

		/// <summary>
		/// 取得消息结果
		/// </summary>
		/// <param name="mClient">Socket 连接</param>
		/// <param name="eServerKey"></param>
		/// <param name="eMsgCategory"></param>
		/// <param name="tSendContent">发送的消息</param>
		/// <returns>消息结果</returns>
        public CEnum.Message_Body[,] RequestResult(CEnum.ServiceKey eServerKey, CEnum.Msg_Category eMsgCategory, CEnum.Message_Body[] tSendContent)
		{
            CEnum.Message_Body[,] pReturnBody = null;

			try
			{
				CSocketData pSendata = mSockData.SocketSend(eServerKey, eMsgCategory, tSendContent);

				if (mSocketClient.Status())
				{			
					if (this.mSocketClient.SendDate(pSendata.bMsgBuffer))
					{
						pReturnBody = this.ReciveMessage(this.mSocketClient);
					}
					else
					{
                        pReturnBody = new CEnum.Message_Body[1, 1];
						pReturnBody[0,0].eName = CEnum.TagName.ERROR_Msg;
						pReturnBody[0,0].eTag = CEnum.TagFormat.TLV_STRING;
						pReturnBody[0,0].oContent = "失去服务器连接";

                        CEnum.TLogData tLogData = new CEnum.TLogData();

						tLogData.iSort = 4;
						tLogData.strDescribe = "失去服务器连接!";
						tLogData.strException = "N/A";			
					}					
				}
				else
				{
                    pReturnBody = new CEnum.Message_Body[1, 1];
                    pReturnBody[0, 0].eName = CEnum.TagName.ERROR_Msg;
                    pReturnBody[0, 0].eTag = CEnum.TagFormat.TLV_STRING;
					pReturnBody[0, 0].oContent = "失去服务器连接";

                    CEnum.TLogData tLogData = new CEnum.TLogData();

					tLogData.iSort = 4;
					tLogData.strDescribe = "失去服务器连接!";
					tLogData.strException = "N/A";
				}
			}
			catch (Exception e)
			{
                pReturnBody = new CEnum.Message_Body[1, 1];
                pReturnBody[0, 0].eName = CEnum.TagName.ERROR_Msg;
                pReturnBody[0, 0].eTag = CEnum.TagFormat.TLV_STRING;
				pReturnBody[0, 0].oContent = e.Message;//"失去服务器连接";

                CEnum.TLogData tLogData = new CEnum.TLogData();

				tLogData.iSort = 5;
				tLogData.strDescribe = "发送或接收Socket消息失败!";
				tLogData.strException = e.Message;
			}

			return pReturnBody;
		}

        public byte[] RequestResult(byte[] val,int fileSize)
        {
            if (this.mSocketClient.SendDate(val))
            {
                return mSocketClient.ReceiveData(fileSize);
            }

            return null;
        }


		/// <summary>
		///  字段名称
		/// </summary>
		/// <param name="eTagName">TagName</param>
		/// <returns>TagName 对应字段名称</returns>
        public string DecodeFieldName(CEnum.TagName eTagName)
		{
			string strReturn = null;
			
			#region 解析字段名称
            switch (eTagName)
            {
                case CEnum.TagName.UserName:// 0x0101 Format:STRING
                    strReturn = "用户名称";
                    break;
                case CEnum.TagName.PassWord:// 0x0102 Format:STRING
                    strReturn = "用户口令";
                    break;
                case CEnum.TagName.MAC:// 0x0103 Format:STRING
                    strReturn = "MAC地址";
                    break;
                case CEnum.TagName.Limit:// 0x0104Format:DateTime
                    strReturn = "使用时效";
                    break;
                case CEnum.TagName.Status:// 0x0105 Format:STRING 状态信息
                    strReturn = "状态信息";
                    break;
                case CEnum.TagName.UserByID:// 0x0200 Format:NUMBER
                    strReturn = "操作员ID";
                    break;
                case CEnum.TagName.GameID:// 0x0200 Format:NUMBER
                    strReturn = "游戏ID";
                    break;
                case CEnum.TagName.ModuleName:// 0x0201 Format:STRING
                    strReturn = "模块名称";
                    break;
                case CEnum.TagName.ModuleClass:// 0x0202 Format:STRING
                    strReturn = "模块分类";
                    break;
                case CEnum.TagName.ModuleContent:// 0x0203 Format:STRING
                    strReturn = "模块描述";
                    break;
                case CEnum.TagName.Module_ID:// 0x0301 Format:INTEGER
                    strReturn = "模块ID";
                    break;
                case CEnum.TagName.User_ID:// 0x0302 Format:INTEGER
                    strReturn = "用户ID";
                    break;
                case CEnum.TagName.ModuleList:// 0x0302 Format:INTEGER
                    strReturn = "模块列表";
                    break;
                case CEnum.TagName.GameName:// 0x0302 Format:INTEGER
                    strReturn = "游戏名称";
                    break;
                case CEnum.TagName.GameContent:// 0x0302 Format:INTEGER
                    strReturn = "消息描述";
                    break;
                case CEnum.TagName.Letter_ID://0x0602, //Format: String
                    strReturn = "信件ID";
                    break;
                case CEnum.TagName.Letter_Sender://0x0602, //Format: String
                    strReturn = "发送人";
                    break;
                case CEnum.TagName.Letter_Receiver://0x0603, //Format String
                    strReturn = "接收人";
                    break;
                case CEnum.TagName.Letter_Subject://0x0604, //Format: String
                    strReturn = "主题";
                    break;
                case CEnum.TagName.Letter_Text://0x0605, //Format: String
                    strReturn = "内容";
                    break;
                case CEnum.TagName.Send_Date://0x0606, //Format: Date
                    strReturn = "发送日期";
                    break;
                case CEnum.TagName.Process_Man://0x0607, //Format:String
                    strReturn = "处理人";
                    break;
                case CEnum.TagName.Process_Date://0x0608, //Format:Date
                    strReturn = "处理日期";
                    break;
                case CEnum.TagName.Transmit_Man://0x0609, //Format:String
                    strReturn = "周转人";
                    break;
                case CEnum.TagName.Is_Process://0x060A, //Format:Integer
                    strReturn = "是否处理";
                    break;
                case CEnum.TagName.Host_Addr:// 0x0401 Format:STRING
                    strReturn = "主机地址";
                    break;
                case CEnum.TagName.Host_Port:// 0x0402 Format:STRING
                    strReturn = "主机端口";
                    break;
                case CEnum.TagName.Host_Pat:// 0x0403  Format:STRING
                    strReturn = "aaa";
                    break;
                case CEnum.TagName.Conn_Time:// 0x0404 Format:DateTime
                    strReturn = "连接时间";
                    break;
                case CEnum.TagName.Connect_Msg:// 0x0405 Format:STRING
                    strReturn = "连接网络消息";
                    break;
                case CEnum.TagName.DisConnect_Msg:// 0x0406	Format:STRING
                    strReturn = "断开网络消息";
                    break;
                case CEnum.TagName.Author_Msg: // 0x0407 Format: tring 
                    strReturn = "验证信息";
                    break;
                case CEnum.TagName.Index:
                    strReturn = "记录索引";
                    break;
                case CEnum.TagName.PageSize:
                    strReturn = "每页显示数据个数";
                    break;
                case CEnum.TagName.ERROR_Msg:
                    strReturn = "系统错误";
                    break;
                case CEnum.TagName.RealName:
                    strReturn = "姓名";
                    break;
                case CEnum.TagName.DepartID:
                    strReturn = "部门ID";
                    break;
                case CEnum.TagName.DepartName:
                    strReturn = "部门名称";
                    break;
                case CEnum.TagName.DepartRemark:
                    strReturn = "部门描述";
                    break;
                case CEnum.TagName.PageCount:
                    strReturn = "总页数";
                    break;
                case CEnum.TagName.SDO_ChargeSum:
                    strReturn = "合计";
                    break;
                case CEnum.TagName.MJ_Level: // 0x0701, //Format:Integer
                case CEnum.TagName.MJ_Account: // 0x0702, //Format:String
                case CEnum.TagName.MJ_CharName: // 0x0703, //Format:String
                case CEnum.TagName.MJ_Exp: // 0x0704, //Format:Integer
                case CEnum.TagName.MJ_Exp_Next_Level: // 0x0705, //Format:Integer
                case CEnum.TagName.MJ_HP: // 0x0706, //Format:Integer
                case CEnum.TagName.MJ_HP_Max: // 0x0707, //Format:Integer 
                case CEnum.TagName.MJ_MP: // 0x0708, //Format:Integer
                case CEnum.TagName.MJ_MP_Max: // 0x0709, //Format:Integer 
                case CEnum.TagName.MJ_DP: // 0x0710, //Format:Integer
                case CEnum.TagName.MJ_DP_Increase_Ratio: // 0x0711, //Format:Integer 
                case CEnum.TagName.MJ_Exception_Dodge: // 0x0712, //Format:Integer 
                case CEnum.TagName.MJ_Exception_Recovery: // 0x0713, //Format:Integer
                case CEnum.TagName.MJ_Physical_Ability_Max: // 0x0714, //Format:Integer 
                case CEnum.TagName.MJ_Physical_Ability_Min: // 0x0715, //Format:Integer 
                case CEnum.TagName.MJ_Magic_Ability_Max: // 0x0716, //Format:Integer 
                case CEnum.TagName.MJ_Magic_Ability_Min: // 0x0717, //Format:Integer 
                case CEnum.TagName.MJ_Tao_Ability_Max: // 0x0718, //Format:Integer 
                case CEnum.TagName.MJ_Tao_Ability_Min: // 0x0719, //Format:Integer 
                case CEnum.TagName.MJ_Physical_Defend_Max: // 0x0720, //Format:Integer 
                case CEnum.TagName.MJ_Physical_Defend_Min: // 0x0721, //Format:Integer 
                case CEnum.TagName.MJ_Magic_Defend_Max: // 0x0722, //Format:Integer 
                case CEnum.TagName.MJ_Magic_Defend_Min: // 0x0723, //Format:Integer 
                case CEnum.TagName.MJ_Accuracy: // 0x0724, //Format:Integer 
                case CEnum.TagName.MJ_Phisical_Dodge: // 0x0725, //Format:Integer 
                case CEnum.TagName.MJ_Magic_Dodge: // 0x0726, //Format:Integer 
                case CEnum.TagName.MJ_Move_Speed: // 0x0727, //Format:Integer 
                case CEnum.TagName.MJ_Attack_speed: // 0x0728, //Format:Integer 
                case CEnum.TagName.MJ_Max_Beibao: // 0x0729, //Format:Integer 
                case CEnum.TagName.MJ_Max_Wanli: // 0x0730, //Format:Integer 
                case CEnum.TagName.MJ_Max_Fuzhong: // 0x0731, //Format:Integer
                case CEnum.TagName.MJ_ActionType: // = 0x0740,//Format:Integer 玩家ID
                case CEnum.TagName.MJ_Time: // = 0x0741,//Format:TimeStamp  操作时间
                case CEnum.TagName.MJ_CharIndex: // 0x0742,//玩家索引号
                case CEnum.TagName.MJ_CharName_Prefix: // 0x0743,//玩家帮会名称
                case CEnum.TagName.MJ_Exploit_Value: // 0x0744,//玩家功勋值
                case CEnum.TagName.MJ_ServerIP:
                    strReturn = "猛将游戏";
                    break;
                case CEnum.TagName.SDO_ServerIP:  //0x0801,//Format:String 大区IP
                    strReturn = "服务器IP";
                    break;
                case CEnum.TagName.SDO_UserIndexID:  //0x0802,//Format:Integer 玩家用户ID
                    strReturn = "玩家用户ID";
                    break;
                case CEnum.TagName.SDO_Account:  //0x0803,//Format:String 玩家的帐号
                    strReturn = "玩家的帐号";
                    break;
                case CEnum.TagName.SDO_Level:  //0x0804,//Format:Integer 玩家的等级
                    strReturn = "玩家的等级";
                    break;
                case CEnum.TagName.SDO_Exp:  //0x0805,//Format:Integer 玩家的当前经验值
                    strReturn = "当前经验值";
                    break;
                case CEnum.TagName.SDO_GameTotal:  //0x0806,//Format:Integer 总局数
                    strReturn = "总  局  数";
                    break;
                case CEnum.TagName.SDO_GameWin:  //0x0807,//Format:Integer 胜局数
                    strReturn = "胜  局  数";
                    break;
                case CEnum.TagName.SDO_DogFall:  //0x0808,//Format:Integer 平局数
                    strReturn = "平  局  数";
                    break;
                case CEnum.TagName.SDO_GameFall:  //0x0809,//Format:Integer 负局数
                    strReturn = "负  局  数";
                    break;
                case CEnum.TagName.SDO_Reputation:  //0x0810,//Format:Integer 声望值
                    strReturn = "声  望  值";
                    break;
                case CEnum.TagName.SDO_GCash:  //0x0811,//Format:Integer G币
                    strReturn = "玩家G币数量";
                    break;
                case CEnum.TagName.SDO_MCash:  //0x0812,//Format:Integer M币
                    strReturn = "玩家M币数量";
                    break;
                case CEnum.TagName.SDO_Address:  //0x0813,//Format:Integer 地址
                    strReturn = "玩家的地址";
                    break;
                case CEnum.TagName.SDO_Age:  //0x0814,//Format:Integer 年龄
                    strReturn = "玩家的年龄";
                    break;
                case CEnum.TagName.SDO_ProductID:  //0x0815,//Format:Integer 商品编号
                    strReturn = "商品编号";
                    break;
                case CEnum.TagName.SDO_ProductName:  //0x0816,//Format:String 商品名称
                    strReturn = "商品名称";
                    break;
                case CEnum.TagName.SDO_ItemCode:  //0x0817,//Format:Integer 道具编号
                    strReturn = "道具编号";
                    break;
                case CEnum.TagName.SDO_ItemName:  //0x0818,//Format:String 道具名称
                    strReturn = "道具名称";
                    break;
                case CEnum.TagName.SDO_MoneyType:  //0x0819,//Format:Integer 货币类型
                    strReturn = "货币类型";
                    break;
                case CEnum.TagName.SDO_MoneyCost:  //0x0820,//Format:Integer 道具的价格
                    strReturn = "道具价格";
                    break;
                case CEnum.TagName.SDO_ShopTime:  //0x0821,//Format:DateTime 消费时间
                    strReturn = "消费时间";
                    break;
                case CEnum.TagName.SDO_MAINCH:  //0x0822,//Format:Integer 服务器
                    strReturn = "服  务  器";
                    break;
                case CEnum.TagName.SDO_SUBCH:  //0x0823,//Format:Integer 房间
                    strReturn = "房      间";
                    break;
                case CEnum.TagName.SDO_Online:  //0x0824,//Format:Integer 是否在线
                    strReturn = "是否在线";
                    break;
                case CEnum.TagName.SDO_LoginTime:  //0x0825,//Format:DateTime 上线时间
                    strReturn = "上线时间";
                    break;
                case CEnum.TagName.SDO_LogoutTime:  //0x0826,//Format:DateTime 下线时间
                    strReturn = "下线时间";
                    break;
                case CEnum.TagName.SDO_AREANAME:  //0x0827,//Format tring 大区名字
                    strReturn = "服务器名称";
                    break;
                case CEnum.TagName.SDO_NickName:  //0x0836,//呢称
                    strReturn = "呢　　　称";
                    break;
                case CEnum.TagName.SDO_9YouAccount:  //0x0837,//9you的帐
                    strReturn = "9you帐号";
                    break;
                case CEnum.TagName.SDO_SEX:  //0x0838,//性别
                    strReturn = "性　　别";
                    break;
                case CEnum.TagName.SDO_RegistDate:  //0x0839,//注册日期
                    strReturn = "注册日期";
                    break;
                case CEnum.TagName.SDO_FirstLogintime:  //0x0840,//第一次登录时间
                    strReturn = "第一次登录时间";
                    break;
                case CEnum.TagName.SDO_LastLogintime:  //0x0841,//最后一次登录时间
                    strReturn = "最后一次登录时间";
                    break;
                case CEnum.TagName.SDO_Ispad:  //0x0842,//是否已注册跳舞毯
                    strReturn = "跳舞毯状态";
                    break;
                case CEnum.TagName.SDO_Desc:// = 0x0843,//道具描述
                    strReturn = "道具描述";
                    break;
                case CEnum.TagName.SDO_Postion:// = 0x0844,//道具位置
                    strReturn = "道具位置";
                    break;
                case CEnum.TagName.SDO_MinLevel:// = 0x0843,//道具描述
                    strReturn = "所需等级";
                    break;
                case CEnum.TagName.SDO_DateLimit:// = 0x0844,//道具位置
                    strReturn = "日期期限";
                    break;
                case CEnum.TagName.SDO_TimesLimit:// = 0x0844,//道具位置
                    strReturn = "使用次数";
                    break;
                case CEnum.TagName.SDO_City:
                    strReturn = "所在城市";
                    break;
                case CEnum.TagName.SDO_BeginTime: //0x0845,//Format:Date 消费记录开始时间
                    strReturn = "消费记录开始时间";
                    break;
                case CEnum.TagName.SDO_EndTime: //0x0846,//Format:Date 消费记录结束时间
                    strReturn = "消费记录结束时间";
                    break;
                case CEnum.TagName.SDO_SendTime: //0x0847,//Format:Date 道具送人日期
                    strReturn = "道具送人日期";
                    break;
                case CEnum.TagName.SDO_SendIndexID: //0x0848,//Format:Integer 发送人的ID
                    strReturn = "发送人的ID";
                    break;
                case CEnum.TagName.SDO_SendUserID: //0x0849,//Format:String 发送人帐号
                    strReturn = "发送人帐号";
                    break;
                case CEnum.TagName.SDO_ReceiveNick: //0x0850,//Format:String 接受人呢称
                    strReturn = "接受人呢称";
                    break;
                case CEnum.TagName.SDO_BigType: //0x0851,//Format:Integer 道具大类
                    strReturn = "道具大类";
                    break;
                case CEnum.TagName.SDO_SmallType: // 0x0852,//Format:Integer 道具小类
                    strReturn = "道具小类";
                    break;
                case CEnum.TagName.SP_Name: //0x0412,//Format:String 存储过程名
                    strReturn = "存储过程名";
                    break;
                case CEnum.TagName.Real_ACT: //0x0413,//Format:String 操作的内容
                    strReturn = "操作的内容";
                    break;
                case CEnum.TagName.ACT_Time: //0x0414,//Format:TimeStamp 操作时间
                    strReturn = "操作时间";
                    break;
                case CEnum.TagName.BeginTime:// = 0x0415,//Format:Date 开始日期
                    strReturn = "开始日期";
                    break;
                case CEnum.TagName.EndTime:// = 0x0416,//Format:Date 结束日期
                    strReturn = "结束日期";
                    break;
                case CEnum.TagName.SDO_Title:
                    strReturn = "标    题";
                    break;
                case CEnum.TagName.SDO_Context:
                    strReturn = "内　　容";
                    break;
                case CEnum.TagName.SDO_Email:
                    strReturn = "?－?ａ??";
                    break;
                case CEnum.TagName.SDO_StopTime:
                    strReturn = "停封时间";
                    break;
                case CEnum.TagName.AU_ACCOUNT:// = 0x1001,//玩家帐号
                    strReturn = "玩家帐号";
                    break;
                case CEnum.TagName.AU_UserNick:// = 0x1002,//玩家呢称
                    strReturn = "玩家呢称";
                    break;
                case CEnum.TagName.AU_Sex:// = 0x1003,//玩家性别
                    strReturn = "玩家性别";
                    break;
                case CEnum.TagName.AU_State:// = 0x1004,//玩家状态
                    strReturn = "玩家状态";
                    break;
                case CEnum.TagName.AU_STOPSTATUS:// = 0x1005,//劲舞者封停状态
                    strReturn = "劲舞者封停状态";
                    break;
                case CEnum.TagName.AU_Reason:// 0x1006,//封停理由
                    strReturn = "封停理由";
                    break;
                case CEnum.TagName.AU_BanDate:// = 0x1007,//封停日期
                    strReturn = "封停日期";
                    break;
                case CEnum.TagName.AU_ServerIP:// = 0x1008,//劲舞团游戏服务器 Format:String
                    strReturn = "劲舞团游戏服务器";
                    break;
                case CEnum.TagName.CR_ServerIP://0x1101,//服务器IP
                    strReturn = "服务器";
                    break;
                case CEnum.TagName.CR_ACCOUNT://0x1102,//玩家帐号 Format:String
                    strReturn = "玩家帐号";
                    break;
                case CEnum.TagName.CR_Passord://0x1103,//玩家密码 Format:String
                    strReturn = "玩家密码";
                    break;
                case CEnum.TagName.CR_NUMBER://0x1104,//激活码 Format:String
                    strReturn = "激活码";
                    break;
                case CEnum.TagName.CR_ISUSE://0x1105,//是否被使用
                    strReturn = "是否被使用";
                    break;
                case CEnum.TagName.CR_STATUS://0x1106,//玩家状态 Format:Integer
                    strReturn = "玩家状态";
                    break;
                case CEnum.TagName.CR_ActiveIP://0x1107,//激活服务器IP Format:String
                    strReturn = "激活服务器";
                    break;
                case CEnum.TagName.CR_ActiveDate://0x1108,//激活日期 Format:TimeStamp
                    strReturn = "激活日期";
                    break;
                case CEnum.TagName.CR_BoardID://0x1109,//公告ID Format:Integer
                    strReturn = "公告ID";
                    break;
                case CEnum.TagName.CR_BoardContext://0x1110,//公告内容 Format:String
                    strReturn = "公告内容";
                    break;
                case CEnum.TagName.CR_BoardColor://0x1111,//公告颜色 Format:String
                    strReturn = "公告颜色";
                    break;
                case CEnum.TagName.CR_ValidTime://0x1112,//生效时间 Format:TimeStamp
                    strReturn = "生效时间";
                    break;
                case CEnum.TagName.CR_InValidTime://0x1113,//失效时间 Format:TimeStamp
                    strReturn = "失效时间";
                    break;
                case CEnum.TagName.CR_Valid://0x1114,//是否有效 Format:Integer
                    strReturn = "是否有效";
                    break;
                case CEnum.TagName.CR_PublishID://0x1115,//发布人ID Format:Integer
                    strReturn = "发布人ID";
                    break;
                case CEnum.TagName.CR_DayLoop://0x1116,//每天播放 Format:Integer
                    strReturn = "每天播放";
                    break;
                case CEnum.TagName.CR_SPEED:
                    strReturn = "播放速度";
                    break;
                case CEnum.TagName.CR_Mode:
                    strReturn = "播放方式";
                    break;
                case CEnum.TagName.CR_Channel:
                    strReturn = "频道ID";
                    break;
                case CEnum.TagName.CR_ACTION:
                    strReturn = "使用状态";
                    break;
                case CEnum.TagName.CR_Expire:
                    strReturn = "是否有效";
                    break;
                case CEnum.TagName.CR_BoardContext1:
                    strReturn = "是否有效2";
                    break;
                case CEnum.TagName.CR_BoardContext2:
                    strReturn = "是否有效3";
                    break;
                case CEnum.TagName.CARD_PDID:// 0x1202,
                    strReturn = "充值ID";
                    break;
                case CEnum.TagName.CARD_PDkey:// 0x1203,
                    strReturn = "交易号";
                    break;
                case CEnum.TagName.CARD_PDCardType:// 0x1204,
                    strReturn = "充值点卡类型";
                    break;
                case CEnum.TagName.CARD_PDFrom:// 0x1205,
                    strReturn = "充值来源";
                    break;
                case CEnum.TagName.CARD_PDCardNO:// 0x1206,
                    strReturn = "充值卡号";
                    break;
                case CEnum.TagName.CARD_PDCardPASS:// 0x1207,
                    strReturn = "充值卡密码";
                    break;
                case CEnum.TagName.CARD_PDCardPrice:// 0x1208,
                    strReturn = "充值卡面值";
                    break;
                case CEnum.TagName.CARD_PDaction:// 0x1209,
                    strReturn = "充值方式";
                    break;
                case CEnum.TagName.CARD_PDuserid:// 0x1210,
                    strReturn = "充值人ID";
                    break;
                case CEnum.TagName.CARD_PDusername:// 0x1211,
                    strReturn = "充值人";
                    break;
                case CEnum.TagName.CARD_PDgetuserid:// 0x1212,
                    strReturn = "被充值人ID";
                    break;
                case CEnum.TagName.CARD_PDgetusername:// 0x1213,
                    strReturn = "充值对象";
                    break;
                case CEnum.TagName.CARD_PDdate:// 0x1214,
                    strReturn = "操作时间";
                    break;
                case CEnum.TagName.CARD_PDip:// 0x1215,
                    strReturn = "操作者IP";
                    break;
                case CEnum.TagName.CARD_PDstatus:// 0x1216,
                    strReturn = "本次操作状态";
                    break;
                case CEnum.TagName.CARD_UDID:// 0x1217,
                    strReturn = "充值ID";
                    break;
                case CEnum.TagName.CARD_UDkey:// 0x1218,
                    strReturn = "交易号";
                    break;
                case CEnum.TagName.CARD_UDusedo:// 0x1219,
                    strReturn = "消费目的";
                    break;
                case CEnum.TagName.CARD_UDdirect:// 0x1220,
                    strReturn = "是否直充游戏";
                    break;
                case CEnum.TagName.CARD_UDuserid:// 0x1221,
                    strReturn = "使用人ID";
                    break;
                case CEnum.TagName.CARD_UDusername:// 0x1222,
                    strReturn = "消费人";
                    break;
                case CEnum.TagName.CARD_UDgetuserid:// 0x1223,
                    strReturn = "被使用人ID";
                    break;
                case CEnum.TagName.CARD_UDgetusername:// 0x1224,
                    strReturn = "消费对象";
                    break;
                case CEnum.TagName.CARD_UDcoins:// 0x1225,
                    strReturn = "金额";
                    break;
                case CEnum.TagName.CARD_UDtype:// 0x1226,
                    strReturn = "消费方式";
                    break;
                case CEnum.TagName.CARD_UDtargetvalue:// 0x1227,
                    strReturn = "使用目的保留字";
                    break;
                case CEnum.TagName.CARD_UDzone1:// 0x1228,
                    strReturn = "使用服务器参数1";
                    break;
                case CEnum.TagName.CARD_UDzone2:// 0x1229,
                    strReturn = "使用服务器参数2";
                    break;
                case CEnum.TagName.CARD_UDdate:// 0x1230,
                    strReturn = "操作时间";
                    break;
                case CEnum.TagName.CARD_UDip:// 0x1231,
                    strReturn = "操作者IP";
                    break;
                case CEnum.TagName.CARD_UDstatus:// 0x1232,
                    strReturn = "本次操作状态";
                    break;
                case CEnum.TagName.CARD_cardnum:// 0x1233,
                    strReturn = "卡号";
                    break;
                case CEnum.TagName.CARD_cardpass:// 0x1234,
                    strReturn = "密码";
                    break;
                case CEnum.TagName.CARD_serial:// 0x1235,
                    strReturn = "点卡序号";
                    break;
                case CEnum.TagName.CARD_draft:// 0x1236,
                    strReturn = "批号";
                    break;
                case CEnum.TagName.CARD_type1:// 0x1237,
                    strReturn = "类型1";
                    break;
                case CEnum.TagName.CARD_type2:// 0x1238,
                    strReturn = "类型2";
                    break;
                case CEnum.TagName.CARD_type3:// 0x1239,
                    strReturn = "类型3";
                    break;
                case CEnum.TagName.CARD_type4:// 0x1240,
                    strReturn = "类型4";
                    break;
                case CEnum.TagName.CARD_price:// 0x1241,
                    strReturn = "金额";
                    break;
                case CEnum.TagName.CARD_valid_date:// 0x1242,
                    strReturn = "有效期";
                    break;
                case CEnum.TagName.CARD_use_status:// 0x1243,
                    strReturn = "是否使用";
                    break;
                case CEnum.TagName.CARD_cardsent:// 0x1244,
                    strReturn = "????";
                    break;
                case CEnum.TagName.CARD_create_date:// 0x1245,
                    strReturn = "使用时间";
                    break;
                case CEnum.TagName.CARD_use_userid:// 0x1246,
                    strReturn = "使用者ID";
                    break;
                case CEnum.TagName.CARD_use_username:// 0x1247,
                    strReturn = "使用者用户名";
                    break;
                case CEnum.TagName.CARD_partner:// 0x1248,
                    strReturn = "合作厂商ID";
                    break;
                case CEnum.TagName.CARD_skey:// 0x1249,
                    strReturn = "明细帐ID";
                    break;
                case CEnum.TagName.CARD_ActionType:
                    strReturn = "操作类型";
                    break;
                case CEnum.TagName.CARD_id:// 0x1251 ,//TLV_STRING 久之游注册卡号
                    strReturn = "身份证号码";
                    break;
                case CEnum.TagName.CARD_username:// 0x1252,//TLV_STRING 久之游注册用户名
                    strReturn = "注册用户名";
                    break;
                case CEnum.TagName.CARD_nickname:// 0x1253,//TLV_STRING 久之游注册呢称
                    strReturn = "注册呢称";
                    break;
                case CEnum.TagName.CARD_password:// 0x1254,//TLV_STRING 久之游注册密码
                    strReturn = "注册密码";
                    break;
                case CEnum.TagName.CARD_sex:// 0x1255,//TLV_STRING 久之游注册性别
                    strReturn = "注册性别";
                    break;
                case CEnum.TagName.CARD_rdate:// 0x1256,//TLV_Date 久之游注册日期
                    strReturn = "注册日期";
                    break;
                case CEnum.TagName.CARD_rtime:// 0x1257,//TLV_Time 久之游注册时间
                    strReturn = "注册时间";
                    break;
                case CEnum.TagName.CARD_securecode:// 0x1258,//TLV_STRING 安全码
                    strReturn = "安全码";
                    break;
                case CEnum.TagName.CARD_vis:// 0x1259,//TLV_INTEGER
                    strReturn = "~~~";
                    break;
                case CEnum.TagName.CARD_logdate:// 0x1260,//TLV_TimeStamp 日期
                    strReturn = "日期";
                    break;
                case CEnum.TagName.CARD_realname:// 0x1263,//TLV_STRING 真实姓名
                    strReturn = "真实姓名";
                    break;
                case CEnum.TagName.CARD_birthday:// 0x1264,//TLV_Date 出生日期
                    strReturn = "出生日期";
                    break;
                case CEnum.TagName.CARD_cardtype:// 0x1265,//TLV_STRING
                    strReturn = "类型";
                    break;
                case CEnum.TagName.CARD_email:// 0x1267,//TLV_STRING 邮件
                    strReturn = "邮件";
                    break;
                case CEnum.TagName.CARD_occupation:// 0x1268,//TLV_STRING 职业
                    strReturn = "职业";
                    break;
                case CEnum.TagName.CARD_education:// 0x1269,//TLV_STRING 教育程度
                    strReturn = "教育程度";
                    break;
                case CEnum.TagName.CARD_marriage:// 0x1270,//TLV_STRING 婚否
                    strReturn = "婚否";
                    break;
                case CEnum.TagName.CARD_constellation:// 0x1271,//TLV_STRING 星座
                    strReturn = "星座";
                    break;
                case CEnum.TagName.CARD_shx:// 0x1272,//TLV_STRING 生肖
                    strReturn = "生肖";
                    break;
                case CEnum.TagName.CARD_city:// 0x1273,//TLV_STRING 城市
                    strReturn = "城市";
                    break;
                case CEnum.TagName.CARD_address:// 0x1274,//TLV_STRING 联系地址
                    strReturn = "联系地址";
                    break;
                case CEnum.TagName.CARD_phone:// 0x1275,//TLV_STRING 联系电话
                    strReturn = "联系电话";
                    break;
                case CEnum.TagName.CARD_qq:// 0x1276,//TLV_STRING QQ
                    strReturn = "QQ号";
                    break;
                case CEnum.TagName.CARD_intro:// 0x1277,//TLV_STRING 介绍
                    strReturn = "介绍";
                    break;
                case CEnum.TagName.CARD_msn:// 0x1278,//TLV_STRING MSN
                    strReturn = "MSN地址";
                    break;
                case CEnum.TagName.CARD_mobilephone:// 0x1279,//TLV_STRING 移动电话
                    strReturn = "移动电话";
                    break;
                case CEnum.TagName.CARD_SumTotal:
                    strReturn = "合计";
                    break;
                case CEnum.TagName.AuShop_orderid://=0x1301,//int(11)
                    strReturn = "编号";
                    break;

                case CEnum.TagName.AuShop_udmark://=0x1302,//int(8)
                    strReturn = "udmark";
                    break;

                case CEnum.TagName.AuShop_bkey://=0x1303,//varchar(40)
                    strReturn = "bkey";
                    break;

                case CEnum.TagName.AuShop_pkey://=0x1304,//varchar(18)
                    strReturn = "pkey";
                    break;

                case CEnum.TagName.AuShop_userid://=0x1305,//int(11)
                    strReturn = "玩家编号";
                    break;

                case CEnum.TagName.AuShop_username://=0x1306,//varchar(20)
                    strReturn = "用户名";
                    break;

                case CEnum.TagName.AuShop_getuserid://=0x1307,//int(11)
                    strReturn = "获赠玩家编号";
                    break;

                case CEnum.TagName.AuShop_getusername://=0x1308,//varchar(20)
                    strReturn = "赠送给";
                    break;

                case CEnum.TagName.AuShop_pcategory://=0x1309,//smallint(4)
                    strReturn = "种类";
                    break;

                case CEnum.TagName.AuShop_pisgift://=0x1310,//enum('y','n')
                    strReturn = "礼物";
                    break;

                case CEnum.TagName.AuShop_islover://=0x1311,//enum('y','n')
                    strReturn = "情人";
                    break;

                case CEnum.TagName.AuShop_ispresent://=0x1312,//enum('y','n')
                    strReturn = "赠送品";
                    break;

                case CEnum.TagName.AuShop_isbuysong://=0x1313,//enum('y','n')
                    strReturn = "购买歌曲";
                    break;

                case CEnum.TagName.AuShop_prule://=0x1314,//tinyint(1)
                    strReturn = "规则";
                    break;

                case CEnum.TagName.AuShop_psex://=0x1315,//enum('all','m','f')
                    strReturn = "性别";
                    break;

                case CEnum.TagName.AuShop_pbuytimes://=0x1316,//int(11)
                    strReturn = "购买时限";
                    break;

                case CEnum.TagName.AuShop_allprice://=0x1317,//int(11)
                    strReturn = "计价";
                    break;

                case CEnum.TagName.AuShop_allaup://=0x1318,//int(11)
                    strReturn = "商城积分";
                    break;

                case CEnum.TagName.AuShop_buytime://=0x1319,//int(10)
                    strReturn = "道具时限";
                    break;

                case CEnum.TagName.AuShop_buytime2://=0x1320,//datetime
                    strReturn = "购买时间";
                    break;

                case CEnum.TagName.AuShop_buyip://=0x1321,//varchar(15)
                    strReturn = "购买人IP";
                    break;

                case CEnum.TagName.AuShop_zone://=0x1322,//tinyint(2)
                    strReturn = "地区";
                    break;

                case CEnum.TagName.AuShop_status://=0x1323,//tinyint(1)
                    strReturn = "状态";
                    break;

                case CEnum.TagName.AuShop_pid://=0x1324,//int(11)
                    strReturn = "ID";
                    break;

                case CEnum.TagName.AuShop_pname://=0x1326,//varchar(20)
                    strReturn = "道具名称";
                    break;

                case CEnum.TagName.AuShop_pgift://=0x1328,//enum('y','n')
                    strReturn = "礼物";
                    break;

                case CEnum.TagName.AuShop_pscash://=0x1330,//tinyint(2)
                    strReturn = "现金";
                    break;

                case CEnum.TagName.AuShop_pgamecode://=0x1331,//varchar(200)
                    strReturn = "游戏代码";
                    break;

                case CEnum.TagName.AuShop_pnew://=0x1332,//enum('y','n')
                    strReturn = "新";
                    break;

                case CEnum.TagName.AuShop_phot://=0x1333,//enum('y','n')
                    strReturn = "热";
                    break;

                case CEnum.TagName.AuShop_pcheap://=0x1334,//enum('y','n')
                    strReturn = "便宜";
                    break;

                case CEnum.TagName.AuShop_pchstarttime://=0x1335,//int(10)
                    strReturn = "开始时间";
                    break;

                case CEnum.TagName.AuShop_pchstoptime://=0x1336,//int(10)
                    strReturn = "停止时间";
                    break;

                case CEnum.TagName.AuShop_pstorage://=0x1337,//smallint(5)
                    strReturn = "仓库";
                    break;

                case CEnum.TagName.AuShop_pautoprice://=0x1339,//enum('y','n')
                    strReturn = "自定义价格";
                    break;

                case CEnum.TagName.AuShop_price://=0x1340,//int(8)
                    strReturn = "价格";
                    break;

                case CEnum.TagName.AuShop_chprice://=0x1341,//int(8)
                    strReturn = "价格";
                    break;

                case CEnum.TagName.AuShop_aup://=0x1342,//int(8)
                    strReturn = "商城积分";
                    break;

                case CEnum.TagName.AuShop_chaup://=0x1343,//int(8)
                    strReturn = "chaup";
                    break;

                case CEnum.TagName.AuShop_ptimeitem://=0x1344,//varchar(200)
                    strReturn = "ptimeitem";
                    break;

                case CEnum.TagName.AuShop_pricedetail://=0x1345,//varchar(254)
                    strReturn = "价格说明";
                    break;

                case CEnum.TagName.AuShop_pdesc://=0x1347,//text
                    strReturn = "pdesc";
                    break;

                case CEnum.TagName.AuShop_pbuys://=0x1348,//int(8)
                    strReturn = "购买";
                    break;

                case CEnum.TagName.AuShop_pfocus://=0x1349,//tinyint(1)
                    strReturn = "位置";
                    break;

                case CEnum.TagName.AuShop_pmark1://=0x1350,//enum('y','n')
                    strReturn = "标志";
                    break;

                case CEnum.TagName.AuShop_pmark2://=0x1351,//enum('y','n')
                    strReturn = "标志";
                    break;

                case CEnum.TagName.AuShop_pmark3://=0x1352,//enum('y','n')
                    strReturn = "标志";
                    break;

                case CEnum.TagName.AuShop_pinttime://=0x1353,//int(10)
                    strReturn = "兑换时间";
                    break;

                case CEnum.TagName.AuShop_pdate://=0x1354,//int(10)
                    strReturn = "pdate";
                    break;

                case CEnum.TagName.AuShop_pisuse://=0x1355,//enum('y','n')
                    strReturn = "是否使用";
                    break;

                case CEnum.TagName.AuShop_ppic://=0x1356,//varchar(36)
                    strReturn = "形象图片";
                    break;

                case CEnum.TagName.AuShop_ppic1://=0x1357,//varchar(36)
                    strReturn = "形象图片";
                    break;

                case CEnum.TagName.AuShop_usefeesum://=0x1358,//int
                    strReturn = "使用积分总额";
                    break;

                case CEnum.TagName.AuShop_useaupsum://=0x1359,//int
                    strReturn = "使用商城积分总额";
                    break;

                case CEnum.TagName.AuShop_buyitemsum://=0x1360,//int
                    strReturn = "购买道具总额";
                    break;

                case CEnum.TagName.AuShop_BeginDate://=0x1361,//date
                    strReturn = "开始时间";
                    break;

                case CEnum.TagName.AuShop_EndDate://=0x1362,//date
                    strReturn = "结束时间";
                    break;
                
                case CEnum.TagName.AuShop_GCashSum:// = 0x1363,
                    strReturn = "G币总和";
                    break;

                case CEnum.TagName.AuShop_MCashSum:// = 0x1364,
                    strReturn = "M币总和";
                    break;
                case CEnum.TagName.SDO_DaysLimit:
                    strReturn = "天数限制";
                    break;
                case CEnum.TagName.SDO_FirstPadTime:
                    strReturn = "第一次使用跳舞毯时间";
                    break;
                default:
                    strReturn = "未知";
                    break;
			}
			#endregion

			return strReturn;
		}



        /// <summary>
        /// 获取CSocketEvent中已存的ServersCount、IpForServer + i、(CSocketEvent)(Server + i)
        /// 
        /// </summary>
        /// <param name="m_ClientEvent"></param>
        /// <returns></returns>
        public CSocketEvent GetSocket(CSocketEvent m_ClientEvent, string sCurrServerIp)
        {
            CSocketEvent returnValue = null;

            if (sCurrServerIp == null)
            {
                return m_ClientEvent;
            }

            int ServersCount = int.Parse(m_ClientEvent.GetInfo("ServersCount").ToString());

            for (int i = 1; i <= ServersCount; i++)
            {
                if ((m_ClientEvent.GetInfo("IpForServer" + i).ToString()).IndexOf(sCurrServerIp) != -1)
                {
                    returnValue = (CSocketEvent)m_ClientEvent.GetInfo("Server" + i);
                    break;
                }
            }

            if (returnValue == null)
                returnValue = m_ClientEvent;


            return returnValue;

        }

		#region 私有变量
		private struct TSaveInfo
		{
			public object oKey;
			public object oData;
		}
		private TSaveInfo[] mSaveInfo = null;
		private TSaveInfo[] mTempInfo = null;
		private CSocketClient mSocketClient = null;
		private CSocketData mSockData = null;

		/// <summary>
		/// 解析字段内容
		/// </summary>
		/// <param name="iRow">行标签</param>
		/// <param name="iField">字段标签</param>
		/// <param name="tTlv">消息体</param>
		/// <param name="tBody">消息内容</param>
		/// <returns>消息内容</returns>
        private CEnum.Message_Body[,] DecodeRecive(int iRow, int iField, TLV_Structure tTlv, CEnum.Message_Body[,] tBody)
		{
            #region 解析字段内容
            switch (tTlv.m_Tag)
            {
                case CEnum.TagName.UserName:// 0x0101 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.PassWord:// 0x0102 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.MAC:// 0x0103 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Limit:// 0x0104Format:DateTime
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_DATE;
                    tBody[iRow, iField].oContent = tTlv.toDate();
                    break;
                case CEnum.TagName.User_Status:// 0x0103 Format:INT
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.UserByID:// 0x0104Format:DateTime
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.GameID:// 0x0200 Format:INT
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.ModuleName:// 0x0201 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.ModuleClass:// 0x0202 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.ModuleContent:// 0x0203 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Module_ID:// 0x0301 Format:INTEGER
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.User_ID:// 0x0302 Format:INTEGER
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.ModuleList:// 0x0302 Format:INTEGER
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.GameName:// 0x0302 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.GameContent:// 0x0302 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Letter_ID://0x0602, //Format: String
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.Letter_Sender://0x0602, //Format: String
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Letter_Receiver://0x0603, //Format String
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Letter_Subject://0x0604, //Format: String
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Letter_Text://0x0605, //Format: String
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Send_Date://0x0606, //Format: Date
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_DATE;
                    tBody[iRow, iField].oContent = tTlv.toDate();
                    break;
                case CEnum.TagName.Process_Man://0x0607, //Format:String
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Process_Date://0x0608, //Format:Date
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_DATE;
                    tBody[iRow, iField].oContent = tTlv.toDate();
                    break;
                case CEnum.TagName.Transmit_Man://0x0609, //Format:String
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Is_Process://0x060A, //Format:Integer
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.Host_Addr:// 0x0401 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Host_Port:// 0x0402 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Host_Pat:// 0x0403  Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Conn_Time:// 0x0404 Format:DateTime
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_DATE;
                    tBody[iRow, iField].oContent = tTlv.toDate();
                    break;
                case CEnum.TagName.Connect_Msg:// 0x0405 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.DisConnect_Msg:// 0x0406	Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Status://0x0408 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Index:
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.PageSize:
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.RealName://0x0408 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.DepartID://0x0408 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.DepartName://0x0408 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.DepartRemark://0x0408 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Author_Msg:// 0x0407	Format:STRING
                case CEnum.TagName.ERROR_Msg:	//0xFFFF Format:String
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.PageCount://0x0408 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_Level: // 0x0701, //Format:Integer
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_Account: // 0x0702, //Format:String
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.MJ_CharName: // 0x0703, //Format:String
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.MJ_Exp: // 0x0704, //Format:Integer
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_Exp_Next_Level: // 0x0705, //Format:Integer
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_HP: // 0x0706, //Format:Integer
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_HP_Max: // 0x0707, //Format:Integer 
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_MP: // 0x0708, //Format:Integer
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_MP_Max: // 0x0709, //Format:Integer
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_DP: // 0x0710, //Format:Integer
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_DP_Increase_Ratio: // 0x0711, //Format:Integer 
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_Exception_Dodge: // 0x0712, //Format:Integer 
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_Exception_Recovery: // 0x0713, //Format:Integer
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_Physical_Ability_Max: // 0x0714, //Format:Integer
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_Physical_Ability_Min: // 0x0715, //Format:Integer 
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_Magic_Ability_Max: // 0x0716, //Format:Integer
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_Magic_Ability_Min: // 0x0717, //Format:Integer 
                case CEnum.TagName.MJ_Tao_Ability_Max: // 0x0718, //Format:Integer 
                case CEnum.TagName.MJ_Tao_Ability_Min: // 0x0719, //Format:Integer 
                case CEnum.TagName.MJ_Physical_Defend_Max: // 0x0720, //Format:Integer 
                case CEnum.TagName.MJ_Physical_Defend_Min: // 0x0721, //Format:Integer 
                case CEnum.TagName.MJ_Magic_Defend_Max: // 0x0722, //Format:Integer 
                case CEnum.TagName.MJ_Magic_Defend_Min: // 0x0723, //Format:Integer 
                case CEnum.TagName.MJ_Accuracy: // 0x0724, //Format:Integer 
                case CEnum.TagName.MJ_Phisical_Dodge: // 0x0725, //Format:Integer 
                case CEnum.TagName.MJ_Magic_Dodge: // 0x0726, //Format:Integer 
                case CEnum.TagName.MJ_Move_Speed: // 0x0727, //Format:Integer 
                case CEnum.TagName.MJ_Attack_speed: // 0x0728, //Format:Integer 
                case CEnum.TagName.MJ_Max_Beibao: // 0x0729, //Format:Integer 
                case CEnum.TagName.MJ_Max_Wanli: // 0x0730, //Format:Integer 
                case CEnum.TagName.MJ_Max_Fuzhong: // 0x0731, //Format:Integer
                case CEnum.TagName.MJ_TypeID:
                case CEnum.TagName.MJ_Money:
                case CEnum.TagName.MJ_ActionType: // = 0x0740,//Format:Integer 玩家ID
                case CEnum.TagName.SDO_9YouAccount://0x0837,//9you的帐号
                case CEnum.TagName.MJ_CharIndex: // 0x0742,//玩家索引号
                case CEnum.TagName.MJ_Exploit_Value: // 0x0744,//玩家功勋值
                case CEnum.TagName.CR_SPEED:// = 0x1129,//播放速度Format:Integer
                
                case CEnum.TagName.CR_PSTID:// = 0x1117,//注册号 Format:Integer
                case CEnum.TagName.CR_SEX:// = 0x1118,//性别 Format:Integer
                case CEnum.TagName.CR_LEVEL:// = 0x1119,//等级 Format:Integer
                case CEnum.TagName.CR_EXP:// = 0x1120,//经验 Format:Integer
                case CEnum.TagName.CR_License:// = 0x1121,//驾照Format:Integer
                case CEnum.TagName.CR_Money:// = 0x1122,//金钱Format:Integer
                case CEnum.TagName.CR_RMB:// = 0x1123,//人民币Format:Integer
                case CEnum.TagName.CR_RaceTotal:// = 0x1124,//比赛总数Format:Integer
                case CEnum.TagName.CR_RaceWon:// = 0x1125,//胜利场数Format:Integer
                case CEnum.TagName.CR_ExpOrder:// = 0x1126,//经验排名Format:Integer
                case CEnum.TagName.CR_WinRateOrder:// = 0x1127,//胜率排名Format:Integer
                case CEnum.TagName.CR_WinNumOrder:// = 0x1128,//胜利场数排名Format:Integer
                case CEnum.TagName.CR_Channel:// = 0x1133,//频道ID
                case CEnum.TagName.CR_Expire:// = 0x1137,//生效格式
                case CEnum.TagName.CR_ChannelID:
                ////////////////////////////
                case CEnum.TagName.UpdateFileSize:// = 0x0115//Format:Integer 文件大小]
                case CEnum.TagName.AuShop_GCashSum:// = 0x1363,
                case CEnum.TagName.AuShop_MCashSum:// = 0x1364,
                case CEnum.TagName.CARD_use_userid:// 0x1246
                ///
                
                case CEnum.TagName.o2jam_SenderIndexID://=0x1410,//int
                case CEnum.TagName.o2jam_ReceiverIndexID://=0x1413,//int




                case CEnum.TagName.o2jam_GEM://=0x1422,//int
                case CEnum.TagName.o2jam_MCASH://=0x1423,//int
                case CEnum.TagName.o2jam_O2CASH://=0x1424,//int
                case CEnum.TagName.o2jam_MUSICCASH://=0x1425,//int
                case CEnum.TagName.o2jam_ITEMCASH://=0x1426,//int
                case CEnum.TagName.o2jam_USER_INDEX_ID://=0x1427,//int
                case CEnum.TagName.o2jam_ITEM_INDEX_ID://=0x1428,//int
                case CEnum.TagName.o2jam_USED_COUNT://=0x1429,//int

                case CEnum.TagName.o2jam_OLD_USED_COUNT://=0x1431,//int
                case CEnum.TagName.o2jam_CURRENT_CASH://=0x1433,//int
                case CEnum.TagName.o2jam_CHARGED_CASH://=0x1434,//int

                case CEnum.TagName.o2jam_KIND://=0x1438,//int
                case CEnum.TagName.o2jam_PLANET://=0x1439,//int
                case CEnum.TagName.o2jam_VAL://=0x1440,//int
                case CEnum.TagName.o2jam_EFFECT://=0x1441,//int
                case CEnum.TagName.o2jam_JUSTICE://=0x1442,//int
                case CEnum.TagName.o2jam_LIFE://=0x1443,//int
                case CEnum.TagName.o2jam_PRICE_KIND://=0x1444,//int
                case CEnum.TagName.o2jam_Exp://=0x1445,//Int
                case CEnum.TagName.o2jam_Battle://=0x1446,//Int
                case CEnum.TagName.o2jam_POSITION://=0x1448,//int
                case CEnum.TagName.o2jam_COMPANY_ID://=0x1449,//int

                case CEnum.TagName.o2jam_ITEM_USE_COUNT://=0x1454,//int
                case CEnum.TagName.o2jam_ITEM_ATTR_KIND://=0x1455,//int
                case CEnum.TagName.O2JAM_BuyType:// = 0x1509,//TLV_INTEGER

                case CEnum.TagName.O2JAM_EQUIP1://=0x1463,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP2://=0x1464,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP3://=0x1465,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP4://=0x1466,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP5://=0x1467,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP6://=0x1468,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP7://=0x1469,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP8://=0x1470,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP9://=0x1471,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP10://=0x1472,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP11://=0x1473,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP12://=0x1474,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP13://=0x1475,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP14://=0x1476,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP15://=0x1477,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP16://=0x1478,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG1://=0x1479,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG2://=0x1480,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG3://=0x1481,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG4://=0x1482,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG5://=0x1483,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG6://=0x1484,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG7://=0x1485,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG8://=0x1486,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG9://=0x1487,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG10://=0x1488,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG11://=0x1489,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG12://=0x1490,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG13://=0x1491,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG14://=0x1492,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG15://=0x1493,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG16://=0x1494,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG17://=0x1495,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG18://=0x1496,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG19://=0x1497,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG20://=0x1498,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG21://=0x1499,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG22://=0x1500,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG23://=0x1501,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG24://=0x1502,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG25://=0x1503,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG26://=0x1504,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG27://=0x1505,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG28://=0x1506,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG29://=0x1507,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG30://=0x1508,//TLV_STRING

                
		        case CEnum.TagName.O2JAM2_Rdate:// = 0x1606,//TLV_Date
                case CEnum.TagName.O2JAM2_IsUse:// = 0x1607,//TLV_Integer
                case CEnum.TagName.O2JAM2_Status:// = 0x1608,//TLV_Integer
                case CEnum.TagName.SysAdmin:

                case CEnum.TagName.SDO_SenceID://= 0x0858,
                case CEnum.TagName.SDO_WeekDay://= 0x0859,
                case CEnum.TagName.SDO_MatPtHR://= 0x0860,
                case CEnum.TagName.SDO_MatPtMin://= 0x0861,
                case CEnum.TagName.SDO_StPtHR://= 0x0862,
                case CEnum.TagName.SDO_StPtMin://= 0x0863,
                case CEnum.TagName.SDO_EdPtHR://= 0x0864,
                case CEnum.TagName.SDO_EdPtMin://= 0x0865,
                case CEnum.TagName.SDO_GCash://= 0x0866,
                case CEnum.TagName.SDO_MCash://= 0x0867,
                
                case CEnum.TagName.SDO_MusicID1://= 0x0869,

                case CEnum.TagName.SDO_LV1://= 0x0871,
                case CEnum.TagName.SDO_MusicID2://= 0x0872,

                case CEnum.TagName.SDO_LV2://= 0x0874,
                case CEnum.TagName.SDO_MusicID3://= 0x0875,

                case CEnum.TagName.SDO_LV3://= 0x0877,
                case CEnum.TagName.SDO_MusicID4://= 0x0878,

                case CEnum.TagName.SDO_LV4://= 0x0880,
                case CEnum.TagName.SDO_MusicID5://= 0x0881,

                case CEnum.TagName.SDO_LV5://= 0x0883,

                case CEnum.TagName.SDO_Precent:// = 0x0884,

                case CEnum.TagName.O2JAM2_UserIndexID://= 0x1609,//TLV_Integer
                case CEnum.TagName.O2JAM2_Level://= 0x1612,//Format:TLV_INTEGER 等级
                case CEnum.TagName.O2JAM2_Win://= 0x1613,//Format:TLV_INTEGER 胜
                case CEnum.TagName.O2JAM2_Draw://= 0x1614,//Format:TLV_INTEGER 平
                case CEnum.TagName.O2JAM2_Lose://= 0x1615,//Format:TLV_INTEGER 负
                case CEnum.TagName.O2JAM2_Exp://= 0x1616,//Format:TLV_INTEGER 经验
                case CEnum.TagName.O2JAM2_TOTAL://= 0x1617,//Format:TLV_INTEGER 总局数
                case CEnum.TagName.O2JAM2_GCash://= 0x1618,//Format:TLV_INTEGER G币
                case CEnum.TagName.O2JAM2_MCash://= 0x1619,//Format:TLV_INTEGER M币
                case CEnum.TagName.O2JAM2_ItemCode://= 0x1620,//Format:TLV_INTEGER
                case CEnum.TagName.O2JAM2_Position://= 0x1625,//int
                case CEnum.TagName.O2JAM2_MoneyType://= 0x1628,//int
                case CEnum.TagName.O2JAM2_ItemSource://= 0x1624,//int
                case CEnum.TagName.O2JAM2_DayLimit:
                case CEnum.TagName.O2JAM2_StopStatus:// = 0x1635,//int

                case CEnum.TagName.SDO_wPlanetID:// = 0x0893, 
		        case CEnum.TagName.SDO_wChannelID:// = 0x0894,
	            case CEnum.TagName.SDO_iLimitUser:// = 0x0895, 
	            case CEnum.TagName.SDO_iCurrentUser:// = 0x0896,
                case CEnum.TagName.Soccer_charidx://角色序列号 (ExSoccer.dbo.t_character[idx])
		        case CEnum.TagName.Soccer_charexp: //经验值
                case CEnum.TagName.Soccer_charlevel://等级
                case CEnum.TagName.Soccer_charpoint://G点数 
                case CEnum.TagName.Soccer_match ://比赛数
                case CEnum.TagName.Soccer_win://
                case CEnum.TagName.Soccer_lose://失败
                case CEnum.TagName.Soccer_draw://平局
                case CEnum.TagName.Soccer_drop://平局		
                case CEnum.TagName.Soccer_charpos://位置
                case CEnum.TagName.SDO_IsBattle:

                case CEnum.TagName.SDO_ItemCode1:
                case CEnum.TagName.SDO_ItemCode2:
                case CEnum.TagName.SDO_ItemCode3:
                case CEnum.TagName.SDO_ItemCode4:
                case CEnum.TagName.SDO_ItemCode5:



                case CEnum.TagName.RayCity_ConnectionLogIDX:
                case CEnum.TagName.RayCity_ConnectionLogKey:
                case CEnum.TagName.RayCity_CharacterMileage:
                case CEnum.TagName.RayCity_CarMileage:
                case CEnum.TagName.RayCity_CarIDX:
                case CEnum.TagName.RayCity_ItemBuySellLogIDX:
                case CEnum.TagName.RayCity_MissionLogIDX:
                case CEnum.TagName.RayCity_MoneyLogIDX:
                case CEnum.TagName.RayCity_RaceLogIDX:
                case CEnum.TagName.RayCity_CurMailCount:
                case CEnum.TagName.RayCity_TargetTradeSessionIDX:
                case CEnum.TagName.RayCity_CashItemLogIDX:
                case CEnum.TagName.FJ_Sex: //TLV_INTEGER
                case CEnum.TagName.FJ_BoardFlag://Format:INT 状态



                #region 光线飞车
                /// <summary>
                /// 光线飞车
                /// </summary>
                //case CEnum.TagName.RC_ICurrentVehicleID:

                case CEnum.TagName.RC_Rank:
                case CEnum.TagName.RC_ID:
                case CEnum.TagName.RC_isAdult:
                case CEnum.TagName.RC_State:
                case CEnum.TagName.RC_Sex:
                case CEnum.TagName.RC_Vehicle:
                case CEnum.TagName.RC_Level:
                case CEnum.TagName.RC_MatchNum:
                case CEnum.TagName.RC_9YOUPointer:
                case CEnum.TagName.RC_Money:
                case CEnum.TagName.RC_PlayCounter:
                case CEnum.TagName.RC_UserIndexID:
                case CEnum.TagName.RayCity_StartNum:
                case CEnum.TagName.RayCity_EndNum:
                case CEnum.TagName.RayCity_TradeWaitItemIDX:
                case CEnum.TagName.RayCity_CarInventoryItemIDX:
                case CEnum.TagName.RayCity_TradeWaitCellNo:
                case CEnum.TagName.RayCity_TargetCarInventoryIDX:
                case CEnum.TagName.RayCity_TargetInventoryCellNo:
                case CEnum.TagName.RayCity_TradeWaitItemState:
                case CEnum.TagName.RayCity_TradeSessionIDX:
                case CEnum.TagName.RayCity_TargetCharacterID:
                case CEnum.TagName.RayCity_TradeMoney:
                case CEnum.TagName.RayCity_TradeSessionState:
                case CEnum.TagName.RayCity_SoloRaceWin:
                case CEnum.TagName.RayCity_SoloRaceLose:
                case CEnum.TagName.RayCity_SoloRaceRetire:
                case CEnum.TagName.RayCity_TeamRaceWin:
                case CEnum.TagName.RayCity_TeamRaceLose:
                case CEnum.TagName.RayCity_FieldSoloRaceWin:
                case CEnum.TagName.RayCity_FieldSoloRaceLose:
                case CEnum.TagName.RayCity_FieldSoloRaceRetire:
                case CEnum.TagName.RayCity_FieldTeamRaceWin:
                case CEnum.TagName.RayCity_FieldTeamRaceLose:
                case CEnum.TagName.RayCity_ItemIDX:
                case CEnum.TagName.RayCity_Bonding:
                case CEnum.TagName.RayCity_MaxEndurance:
                case CEnum.TagName.RayCity_CurEndurance:
                case CEnum.TagName.RayCity_ItemOption1:
                case CEnum.TagName.RayCity_ItemOption2:
                case CEnum.TagName.RayCity_ItemOption3:
                case CEnum.TagName.RayCity_ItemState:
                case CEnum.TagName.RayCity_ItemPrice:
                case CEnum.TagName.RayCity_BeforeCharacterMoney:
                case CEnum.TagName.RayCity_AfterCharacterMoney:
                case CEnum.TagName.RayCity_MoneyType:
                case CEnum.TagName.RayCity_ServerID:
                case CEnum.TagName.RayCity_ActionType:
                case CEnum.TagName.RayCity_NyGender:
                case CEnum.TagName.RayCity_CharacterID:
                case CEnum.TagName.RayCity_CarID:
                case CEnum.TagName.RayCity_CarType:
                case CEnum.TagName.RayCity_LastEquipInventoryIDX:
                case CEnum.TagName.RayCity_CarState:
                case CEnum.TagName.RayCity_AccountID:
                case CEnum.TagName.RayCity_RecentMailIDX:
                case CEnum.TagName.RayCity_RecentGiftIDX:
                case CEnum.TagName.RayCity_LastUseCarIDX:
                case CEnum.TagName.RayCity_GarageIDX:
                case CEnum.TagName.RayCity_LastTutorialID:
                case CEnum.TagName.RayCity_CharacterState:
                case CEnum.TagName.RayCity_FriendIDX:
                case CEnum.TagName.RayCity_FriendCharacterID:
                case CEnum.TagName.RayCity_FriendGroupIDX:
                case CEnum.TagName.RayCity_FriendState:
                case CEnum.TagName.RayCity_FriendGroupType:
                case CEnum.TagName.RayCity_FriendGroupState:
                case CEnum.TagName.RayCity_CarInventoryIDX:
                case CEnum.TagName.RayCity_InventoryType:
                case CEnum.TagName.RayCity_MaxInventorySize:
                case CEnum.TagName.RayCity_CurrentInventorySize:
                case CEnum.TagName.RayCity_QuestLogIDX:
                case CEnum.TagName.RayCity_QuestID:
                case CEnum.TagName.RayCity_QuestState:
                case CEnum.TagName.RayCity_DealLogIDX:
                case CEnum.TagName.RayCity_ItemID:
                case CEnum.TagName.RayCity_BuyDealClientID:
                case CEnum.TagName.RayCity_SellDealClientID:
                case CEnum.TagName.RayCity_BuyPrice:
                case CEnum.TagName.RayCity_SellPrice:
                case CEnum.TagName.RayCity_DealLogState:
                case CEnum.TagName.RayCity_QuestOJTLogIDX:
                case CEnum.TagName.RayCity_QuestOJTIDX:
                case CEnum.TagName.RayCity_TaskValue:
                case CEnum.TagName.RayCity_ExecuteCount:
                case CEnum.TagName.RayCity_QuestOJTState:
                case CEnum.TagName.RayCity_CharacterLevel:
                case CEnum.TagName.RayCity_CharacterExp:
                case CEnum.TagName.RayCity_CharacterMoney:
                case CEnum.TagName.RayCity_MaxCombo:
                case CEnum.TagName.RayCity_MaxSP:
                case CEnum.TagName.RayCity_MaxMailCount:
                case CEnum.TagName.RayCity_CurrentRP:
                case CEnum.TagName.RayCity_AccumulatedRP:
                case CEnum.TagName.RayCity_RelaxGauge:
                case CEnum.TagName.RayCity_StartPos_TownCode:
                case CEnum.TagName.RayCity_StartPos_FieldCode:
                case CEnum.TagName.RayCity_DealInventoryItemIDX:
                case CEnum.TagName.RayCity_InventoryCellNo:
                case CEnum.TagName.RayCity_DealInventoryItemState:
                case CEnum.TagName.RayCity_CarLevel:
                case CEnum.TagName.RayCity_CarExp:
                case CEnum.TagName.RayCity_FuelQuantity:
                case CEnum.TagName.RayCity_MissionID:
                case CEnum.TagName.RayCity_TotMissionCnt:
                case CEnum.TagName.RayCity_TotMissionSuccessCnt:
                case CEnum.TagName.RayCity_TotMissionFailCnt:
                case CEnum.TagName.RayCity_TotEXP:
                case CEnum.TagName.RayCity_TotCarEXP:
                case CEnum.TagName.RayCity_TotIncoming:
                case CEnum.TagName.RayCity_BingoCardIDX:
                case CEnum.TagName.RayCity_BingoCardID:
                case CEnum.TagName.RayCity_BingoRewardType:
                case CEnum.TagName.RayCity_BingoRewardValue:
                case CEnum.TagName.RayCity_BingoRewardAmount:
                case CEnum.TagName.RayCity_BingoCardState:
                case CEnum.TagName.RayCity_AccountState:
                case CEnum.TagName.RayCity_CharacterType:
                case CEnum.TagName.RayCity_TotPlayTime:
                case CEnum.TagName.RayCity_LoginCount:
                case CEnum.TagName.RayCity_IsLogin:
                case CEnum.TagName.RayCity_GuildMemberIDX:
                case CEnum.TagName.RayCity_GuildGroupIDX:
                case CEnum.TagName.RayCity_GuildMemberState:
                case CEnum.TagName.RayCity_GuildGroupRole:
                case CEnum.TagName.RayCity_GuildGroupState:
                case CEnum.TagName.RayCity_GuildIDX:
                case CEnum.TagName.RayCity_MaxGuildMember:
                case CEnum.TagName.RayCity_CurGuildMember:
                case CEnum.TagName.RayCity_IncreaseItemCount:
                case CEnum.TagName.RayCity_TrackRaceWin:
                case CEnum.TagName.RayCity_TrackRaceLose:
                case CEnum.TagName.RayCity_FieldRaceWin:
                case CEnum.TagName.RayCity_FieldRaceLose:
                case CEnum.TagName.RayCity_GuildState:
                case CEnum.TagName.RayCity_NyBirthYear:
                case CEnum.TagName.RayCity_RewardExp:
                case CEnum.TagName.RayCity_RewardCarExp:
                case CEnum.TagName.RayCity_RewardMoney:
                case CEnum.TagName.RayCity_MissionGrade:
                case CEnum.TagName.RayCity_MissionResult:
                case CEnum.TagName.RayCity_Duration:
                case CEnum.TagName.RayCity_AdjustType:
                case CEnum.TagName.RayCity_UpdateSource:
                case CEnum.TagName.RayCity_MoneyAmount:
                case CEnum.TagName.RayCity_RaceID:
                case CEnum.TagName.RayCity_RaceType:
                case CEnum.TagName.RayCity_TrackID:
                case CEnum.TagName.RayCity_RewardRP_RankBase:
                case CEnum.TagName.RayCity_RewardRP_TimeBase:
                case CEnum.TagName.RayCity_RaceResult:
                case CEnum.TagName.RayCity_Rank:
                case CEnum.TagName.RayCity_RaceTime:
                case CEnum.TagName.RayCity_ItemTypeID:
                case CEnum.TagName.RayCity_SkillID:
                case CEnum.TagName.RayCity_SkillLevel:
                case CEnum.TagName.RayCity_SkillIDX:
                case CEnum.TagName.RayCity_NyCashChargeLogIDX:
                case CEnum.TagName.RayCity_NyPayID:
                case CEnum.TagName.RayCity_ChargeAmount:
                case CEnum.TagName.RayCity_ChargeState:

                case CEnum.TagName.RayCity_CouponIDX:   //0x2200,//Format:Integer 玩家序列号
                case CEnum.TagName.RayCity_IssueCount:
                case CEnum.TagName.RayCity_CouponState:
                case CEnum.TagName.RayCity_IssueCouponIDX:
                case CEnum.TagName.RC_SenderID:
                case CEnum.TagName.RC_ReceiverID:
                case CEnum.TagName.RC_SenderOperation:
                case CEnum.TagName.RC_ReceiverOperation:
                case CEnum.TagName.RayCity_StockID:
                case CEnum.TagName.RayCity_GiftState:
                case CEnum.TagName.RayCity_FromCharacterID:
                case CEnum.TagName.RayCity_PaymentType:
                //case CEnum.TagName.车辆等级:
                //case CEnum.TagName.车辆损伤情况:
                //case CEnum.TagName.液氮能力等级:
                case CEnum.TagName.RC_PlayerID:
                case CEnum.TagName.RC_PlayerOperation:


                case CEnum.TagName.RC_state_number:
                case CEnum.TagName.RC_ItemCode:
                case CEnum.TagName.RC_TimeLoop:
                case CEnum.TagName.RC_ChannelServerID:
                case CEnum.TagName.RC_MultipleType:
                case CEnum.TagName.RC_MultipleValue:
                case CEnum.TagName.RC_IGroup:

                case CEnum.TagName.RayCity_Interval:
                case CEnum.TagName.RayCity_NoticeID:
                case CEnum.TagName.RayCity_Repeat:

                case CEnum.TagName.RC_Split_IForce://TLV_INTEGER 阵营
                case CEnum.TagName.RC_IRunDistance://TLV_INTEGER 总行驶距离
                case CEnum.TagName.RC_ILostConnection://TLV_INTEGER 掉线次数
                case CEnum.TagName.RC_IEscapeCounter://TLV_INTEGER 跳跑次数
                case CEnum.TagName.RC_IWinCounter://TLV_INTEGER 获胜的次数
                case CEnum.TagName.RC_IGameMoney://TLV_INTEGER 游戏币
                case CEnum.TagName.RC_AllOnlineTime://TLV_INTEGER 在线时长
                case CEnum.TagName.RayCity_NyCashBalance://余额 INT
                #endregion

                #region SD敢达online
                case CEnum.TagName.f_idx://玩家ID int
                case CEnum.TagName.f_gender://性别 int 0女1男
                case CEnum.TagName.f_adult://是否成年 0成年1未成年
                case CEnum.TagName.f_level://级别 int
                case CEnum.TagName.f_Exp://经验 int
                case CEnum.TagName.f_shootCnt://击破数 int
                case CEnum.TagName.f_collectCnt://收集数 int
                case CEnum.TagName.f_fightCnt://战斗数 int
                case CEnum.TagName.f_winCnt://胜利 int
                case CEnum.TagName.f_loseCnt://失败 int
                case CEnum.TagName.f_drawCnt://平局 int
                case CEnum.TagName.SD_ban://封停 int
                case CEnum.TagName.SD_NeedExp://升级需要的经验 int
                case CEnum.TagName.SD_GC://G币 int
                case CEnum.TagName.SD_GP://M币 int
                case CEnum.TagName.SD_KillNum://被杀次数 int

                case CEnum.TagName.SD_SlotNumber://栏数 int                 
                case CEnum.TagName.SD_ItemID://道具ID int                  
                case CEnum.TagName.SD_RemainCount://剩余数量 int 
                case CEnum.TagName.SD_BuyType://购买类型 int



                case CEnum.TagName.SD_CustomLvMax://机体最大合成次数
                case CEnum.TagName.SD_CustomPoint://机体合成点数

                case CEnum.TagName.SD_Limit://间隔 int
                case CEnum.TagName.SD_Type://类型 int                
                case CEnum.TagName.SD_Number://数量 int

                case CEnum.TagName.SD_FromIdx://发送用户id int
                case CEnum.TagName.SD_ToIdx://接受用户id int

                case CEnum.TagName.SD_ItemID1://道具ID1 int                
                case CEnum.TagName.SD_ItemID2://道具ID2 int                
                case CEnum.TagName.SD_ItemID3://道具ID3 int
                case CEnum.TagName.SD_Number1://数量1 int
                case CEnum.TagName.SD_Number2://数量2 int
                case CEnum.TagName.SD_Number3://数量3 int
                case CEnum.TagName.SD_N10://礼物发送后剩余的point int                
                case CEnum.TagName.SD_N12://结算方式(0.point 1.cash) int
                case CEnum.TagName.SD_SendType://发送公告类型 int
                case CEnum.TagName.SD_Status://发送公告状态 int
                case CEnum.TagName.SD_N11://使用在礼物购买上的point int
                case CEnum.TagName.SD_QusetID://任务ID int
                case CEnum.TagName.SD_UColor_1://颜色1 string
                case CEnum.TagName.SD_UColor_2://颜色2 string
                case CEnum.TagName.SD_UColor_3://颜色3 string
                case CEnum.TagName.SD_UColor_4://颜色4 string
                case CEnum.TagName.SD_UColor_5://颜色5 string
                case CEnum.TagName.SD_UColor_6://颜色6 string
                case CEnum.TagName.SD_RewardCount://任务奖励 int
                case CEnum.TagName.SD_Star://机体星级
                case CEnum.TagName.SD_Money_Old://修改前的钱 int
               

                #endregion

                #region 劲舞团2
                /// <summary>
                /// 劲舞团2定义
                /// </summary>


                case CEnum.TagName.JW2_State://玩家状态 Format:Integer
                case CEnum.TagName.JW2_UserSN://Format:Integer 用户序列号
                case CEnum.TagName.JW2_Sex://玩家性别 Format:Integer
                case CEnum.TagName.JW2_AvatarItem: //Format:Integer 道具ID
                case CEnum.TagName.JW2_Exp://Format:Integer 玩家经验
                case CEnum.TagName.JW2_Money: //Format:Integer 金钱
                case CEnum.TagName.JW2_Cash: //Format:Integer 现金
                case CEnum.TagName.JW2_Level: //Format:Integer 等级
                case CEnum.TagName.JW2_UseItem://Format:Integer是否在使用中，1用0不用
                case CEnum.TagName.JW2_RemainCount://Format:Integer剩余次数，0为无限次
                case CEnum.TagName.JW2_TaskID://任务号Format:Integer
                case CEnum.TagName.JW2_Status://是否完成状态Format:Integer
                case CEnum.TagName.JW2_Interval://间隔时间Format:Integer
                case CEnum.TagName.JW2_POWER://权限，普通用户是0，管理员为1 Format:Integer
                case CEnum.TagName.JW2_GoldMedal://金牌 Format:Integer
                case CEnum.TagName.JW2_SilverMedal://银牌 Format:Integer
                case CEnum.TagName.JW2_CopperMedal://铜牌 Format:Integer
                case CEnum.TagName.JW2_PARA://结婚任务用的一个参数 Format:Integer
                case CEnum.TagName.JW2_ATONCE://是否立即发送Format:Integer
                case CEnum.TagName.JW2_BOARDSN://大小喇叭，横幅记录唯一标示Format:Integer
                case CEnum.TagName.JW2_BUGLETYPE://类型0mb发小喇叭,1积分发小喇叭,1mb发大喇叭,11积分发大喇叭,20及20以上是横幅Format:Integer
                //情节///////////
                case CEnum.TagName.JW2_Chapter://章节 int
                case CEnum.TagName.JW2_CurStage://目前等级 int
                case CEnum.TagName.JW2_MaxStage://最大等级 int
                case CEnum.TagName.JW2_Stage0://关卡1 int
                case CEnum.TagName.JW2_Stage1:// int
                case CEnum.TagName.JW2_Stage2:// int
                case CEnum.TagName.JW2_Stage3://int
                case CEnum.TagName.JW2_Stage4:// int
                case CEnum.TagName.JW2_Stage5:// int
                case CEnum.TagName.JW2_Stage6:// int
                case CEnum.TagName.JW2_Stage7:// int
                case CEnum.TagName.JW2_Stage8: //int
                case CEnum.TagName.JW2_Stage9:// int
                case CEnum.TagName.JW2_Stage10:// int
                case CEnum.TagName.JW2_Stage11:// int
                case CEnum.TagName.JW2_Stage12: //int
                case CEnum.TagName.JW2_Stage13:// int
                case CEnum.TagName.JW2_Stage14: //int
                case CEnum.TagName.JW2_Stage15://int
                case CEnum.TagName.JW2_Stage16: //int
                case CEnum.TagName.JW2_Stage17:// int
                case CEnum.TagName.JW2_Stage18://int
                case CEnum.TagName.JW2_Stage19://关卡20 int
                //情节end///////////
                case CEnum.TagName.JW2_BUYSN://购买SN int
                case CEnum.TagName.JW2_GOODSTYPE://购买类型 int
                case CEnum.TagName.JW2_RECESN://接受人的SN（如果相同是本人） int 
                case CEnum.TagName.JW2_GOODSINDEX://物品编号 int
                case CEnum.TagName.JW2_RECEID://接受人的ID（如果相同是本人） int
                case CEnum.TagName.JW2_MALESN://男性SN int
                case CEnum.TagName.JW2_FEMAILESN://女性SN int
                case CEnum.TagName.JW2_RINGLEVEL://戒指等级 int
                case CEnum.TagName.JW2_REDHEARTNUM://红心数量 int
                case CEnum.TagName.JW2_WEDDINGNO://婚姻序号 int
                case CEnum.TagName.JW2_KISSNUM://kiss次数 int
                case CEnum.TagName.JW2_BREAKSN://提出SN int

                case CEnum.TagName.JW2_FAMILYID://家族ID int
                case CEnum.TagName.JW2_DUTYID://职业号 int
                case CEnum.TagName.JW2_COUPLESN://情侣序号 int 

                case CEnum.TagName.JW2_POINT://积分 int
                case CEnum.TagName.JW2_LOGINTYPE://类型0登入，1登出 int
                case CEnum.TagName.JW2_AvatarItemType://物品类型（头发等）int
                case CEnum.TagName.JW2_ItemPos://物品位置(0,身上,1,物品栏,2,礼物栏) int
                case CEnum.TagName.JW2_ItemNo://物品序号 int

                case CEnum.TagName.JW2_FamilyLevel://等级 int

                case CEnum.TagName.JW2_ItemCode://道具ID int
                case CEnum.TagName.JW2_Productid://商品ID int
                case CEnum.TagName.JW2_FamilyPoint://家族点数 int
                case CEnum.TagName.JW2_PetSn://宠物ID int
                case CEnum.TagName.JW2_PetLevel://宠物等级 int
                case CEnum.TagName.JW2_PetExp://宠物经验 int 
                case CEnum.TagName.JW2_PetEvol://进阶阶段 int
                case CEnum.TagName.JW2_MailSn://序列号 int

                case CEnum.TagName.JW2_Num://数量 int


                case CEnum.TagName.JW2_BeforeCash://消费前金额 int 
                case CEnum.TagName.JW2_AfterCash://消费后金额 int


                case CEnum.TagName.JW2_Center_Avatarid://中间件道具ID,int

                case CEnum.TagName.JW2_Center_State://状态 int(0装备，2未装备)
                case CEnum.TagName.JW2_ZoneID://服务器ID int
                case CEnum.TagName.JW2_VailedDay://时限（7天，30天，65535=无限） int
                case CEnum.TagName.JW2_IntRo://状态（1自己购买/0别人赠送） int
                case CEnum.TagName.JW2_SubGameID://子游戏ID int

                case CEnum.TagName.JW2_Forever://(1永久，0非永久) int

                case CEnum.TagName.JW2_ReportSn://举报ID int
                case CEnum.TagName.JW2_ReporterSn://举报人ID int 
                case CEnum.TagName.JW2_ReportType://举报类型 int 
                case CEnum.TagName.JW2_MissionID://任务ID int



                case CEnum.TagName.jw2_goodsprice://购买价格 int
                case CEnum.TagName.jw2_beforemoney://购买前金钱数 int
                case CEnum.TagName.jw2_aftermoney://购买后金钱数 int

                case CEnum.TagName.jw2_serverno://GS序号 int
                case CEnum.TagName.jw2_port://GS端口int

                case CEnum.TagName.jw2_MultiDays://连续活跃天数 int
                case CEnum.TagName.jw2_TodayActivePoint://今天获得的活跃度点数 int

                case CEnum.TagName.jw2_Wedding_Home:


                case CEnum.TagName.jw2_frmLove://亲密度 int
                case CEnum.TagName.jw2_petaggID://宠物蛋ID	int

                case CEnum.TagName.jw2_FirstFamilySN://申请方家族id int
                case CEnum.TagName.jw2_SecondFamilySN://被申请方家族id int 
                case CEnum.TagName.jw2_PetID:// 宠物ID	int 

                case CEnum.TagName.jw2_EggNum://宠物蛋数量 int
                case CEnum.TagName.jw2_PetAggID_Small:// 小宠物蛋ID	int 
                case CEnum.TagName.AU_UseNum://消耗数量 int
                case CEnum.TagName.AU_BadgeID://徽章ID int 


                case CEnum.TagName.AU_famid://家族ID int 

                case CEnum.TagName.Magic_Sex:
                case CEnum.TagName.Magic_GuildID:

                case CEnum.TagName.AU_UTP://查询用户类型 (char 1) [1: Send; 2: Recv]
                #endregion

                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_CharName_Prefix: // 0x0743,//玩家帮会名称
                case CEnum.TagName.SDO_ServerIP:  //0x0801,//Format:String 大区IP
                case CEnum.TagName.SDO_Account:  //0x0803,//Format:String 玩家的帐号
                case CEnum.TagName.SDO_ProductName:  //0x0816,//Format:String 商品名称
                case CEnum.TagName.SDO_ItemName:  //0x0818,//Format:String 道具名称
                case CEnum.TagName.SDO_AREANAME:  //0x0827,//Format:String 大区名字
                case CEnum.TagName.SDO_NickName:  //0x0836,//呢称
                case CEnum.TagName.SDO_Address:  //0x0813,//Format:Integer 地址
                case CEnum.TagName.SDO_Desc:    // = 0x0843,//道具描述
                case CEnum.TagName.SDO_City:
                case CEnum.TagName.SDO_SendUserID: //0x0849,//Format:String 发送人帐号
                case CEnum.TagName.SDO_ReceiveNick: //0x0850,//Format:String 接受人呢称
                case CEnum.TagName.SDO_Title:
                case CEnum.TagName.SDO_Context:
                case CEnum.TagName.SDO_REASON:// = 0x0853,//Format:String 停封理由
                case CEnum.TagName.SDO_Email:
                ////////
                case CEnum.TagName.ServerInfo_IP:// = 0x0901,//Format tring 服务器IP
                case CEnum.TagName.ServerInfo_City:// = 0x0902,//Format tring 城市
                case CEnum.TagName.ServerInfo_GameName:// = 0x0904,//Format tring 游戏名
                ///////
                case CEnum.TagName.SP_Name: //0x0412,//Format:String 存储过程名
                case CEnum.TagName.Real_ACT: //0x0413,//Format:String 操作的内容
                case CEnum.TagName.MJ_Reason://0x0745,//停封理由
                case CEnum.TagName.MJ_ServerIP:
                ///
                case CEnum.TagName.UpdateFileName:// = 0x0112,//Format:String 文件名
                case CEnum.TagName.UpdateFileVersion:// = 0x0113,//Format:String 文件版本
                case CEnum.TagName.UpdateFilePath:// = 0x0114,//Format:String 文件路径
                //////////
                case CEnum.TagName.CR_ServerIP:// = 0x1101,//服务器IP
                case CEnum.TagName.CR_ACCOUNT:// = 0x1102,//玩家帐号 Format tring
                case CEnum.TagName.CR_Passord:// = 0x1103,//玩家密码 Format tring
                case CEnum.TagName.CR_NUMBER:// = 0x1104,//激活码 Format tring
                case CEnum.TagName.CR_ISUSE:// = 0x1105,//是否被使用
                case CEnum.TagName.CR_ActiveIP:// = 0x1107,//激活服务器IP Format:String
                case CEnum.TagName.CR_BoardContext:// = 0x1110,//公告内容 Format:String
                case CEnum.TagName.CR_BoardColor:// = 0x1111,//公告颜色 Format:String
                case CEnum.TagName.CR_NickName:// = 0x1132://,//呢称 Format:String
                case CEnum.TagName.CR_BoardContext1:// = 0x1135,//内容1
                case CEnum.TagName.CR_BoardContext2:// = 0x1136,//内容2
                case CEnum.TagName.CR_ChannelName:
                case CEnum.TagName.CR_UserName:// = 0x1636,//string  
                ///////
                case CEnum.TagName.AU_ACCOUNT://=0x1001://,//玩家帐号Format:String
                case CEnum.TagName.AU_UserNick://=0x1002://,//玩家呢称Format:String
                case CEnum.TagName.AU_Reason://=0x1006://,//封停理由Format:String
                case CEnum.TagName.AU_ServerIP://=0x1008://,//劲舞团游戏服务器Format:String
                case CEnum.TagName.AU_EquipState://=0x1011://,//Format:String
                case CEnum.TagName.AU_BuyNick://=0x1013://,//Format:String购买呢称
                case CEnum.TagName.AU_SendNick://=0x1019://,//Format:String赠送呢称
                
                case CEnum.TagName.AU_RecvNick://=0x1021://,//Format:String接受人呢称
                case CEnum.TagName.AU_Memo://=0x1029://,//Format:String备注
                case CEnum.TagName.AU_UserID://=0x1030://,//Format:String玩家ID
                case CEnum.TagName.AU_Password://=0x1040://,//Format:String密码
                case CEnum.TagName.AU_UserName://=0x1041://,//Format:String用户名
                case CEnum.TagName.AU_UserGender://=0x1042://,//Format:String
                case CEnum.TagName.AU_UserRegion://=0x1044://,//Format:String
                case CEnum.TagName.AU_UserEMail://=0x1045://,//Format:String用户电子邮件
                case CEnum.TagName.AU_ItemName:// = 0x1047,//道具名
                case CEnum.TagName.AU_ItemStyle:// = 0x1048,//道具类型
                case CEnum.TagName.AU_Demo:// = 0x1049,//描述 
                case CEnum.TagName.AU_BeginTime:// = 0x1050,//开始时间
                case CEnum.TagName.AU_EndTime:// = 0x1051,//结束时间
                case CEnum.TagName.AU_SendUserID:// = 0x1052,//发送人帐号
                case CEnum.TagName.AU_RecvUserID:// = 0x1053,//接受人帐号 
                case CEnum.TagName.AU_Sex://=0x1003://,//玩家性别Format:Integer
                case CEnum.TagName.AU_GSName:
                ///////
                ///////
                case CEnum.TagName.CARD_PDkey:// 0x1203
                case CEnum.TagName.CARD_PDCardType:// 0x1204　
                case CEnum.TagName.CARD_PDFrom:// 0x1205
                case CEnum.TagName.CARD_PDCardNO:// 0x1206
                case CEnum.TagName.CARD_PDCardPASS:// 0x1207
                case CEnum.TagName.CARD_PDaction:// 0x1209
                case CEnum.TagName.CARD_PDuserid:// 0x1210
                case CEnum.TagName.CARD_PDusername:// 0x1211
                case CEnum.TagName.CARD_PDgetusername:// 0x1213
                
                case CEnum.TagName.CARD_PDip:// 0x1215
                case CEnum.TagName.CARD_PDstatus:// 0x1216
                case CEnum.TagName.CARD_UDkey:// 0x1218 
                case CEnum.TagName.CARD_UDusedo:// 0x1219
                case CEnum.TagName.CARD_UDdirect:// 0x1220
                case CEnum.TagName.CARD_UDusername:// 0x1222 
                case CEnum.TagName.CARD_UDgetuserid:// 0x1223 //TLV_STRING
                case CEnum.TagName.CARD_UDgetusername:// 0x1224 //TLV_STRING
                case CEnum.TagName.CARD_UDtype:// 0x1226 //TLV_STRING
                case CEnum.TagName.CARD_UDtargetvalue:// 0x1227
                case CEnum.TagName.CARD_UDzone1:// 0x1228
                case CEnum.TagName.CARD_UDzone2:// 0x1229
                case CEnum.TagName.CARD_UDip:// 0x1231
                case CEnum.TagName.CARD_UDstatus:// 0x1232
                case CEnum.TagName.CARD_cardnum:// 0x1233
                case CEnum.TagName.CARD_cardpass:// 0x1234
                case CEnum.TagName.CARD_serial:// 0x1235
                case CEnum.TagName.CARD_draft:// 0x1236
                case CEnum.TagName.CARD_type1:// 0x1237
                case CEnum.TagName.CARD_type2:// 0x1238
                case CEnum.TagName.CARD_type3:// 0x1239
                case CEnum.TagName.CARD_type4:// 0x1240
                case CEnum.TagName.CARD_valid_date:// 0x1242
                case CEnum.TagName.CARD_use_status:// 0x1243
                case CEnum.TagName.CARD_cardsent:// 0x1244
                case CEnum.TagName.CARD_create_date:// 0x1245
                
                case CEnum.TagName.CARD_use_username:// 0x1247
                case CEnum.TagName.CARD_partner:// 0x1248
                case CEnum.TagName.CARD_skey:// 0x1249
                ////////
                case CEnum.TagName.CARD_id:// 0x1251 ,//TLV_STRING 久之游注册卡号
                case CEnum.TagName.CARD_username:// 0x1252,//TLV_STRING 久之游注册用户名
                case CEnum.TagName.CARD_nickname:// 0x1253,//TLV_STRING 久之游注册呢称
                case CEnum.TagName.CARD_password:// 0x1254,//TLV_STRING 久之游注册密码
                case CEnum.TagName.CARD_sex:// 0x1255,//TLV_STRING 久之游注册性别
                case CEnum.TagName.CARD_securecode:// 0x1258,//TLV_STRING 安全码
                case CEnum.TagName.CARD_vis:// 0x1259,//TLV_INTEGER
                case CEnum.TagName.CARD_realname:// 0x1263,//TLV_STRING 真实姓名
                case CEnum.TagName.CARD_cardtype:// 0x1265,//TLV_STRING
                case CEnum.TagName.CARD_email:// 0x1267,//TLV_STRING 邮件
                case CEnum.TagName.CARD_occupation:// 0x1268,//TLV_STRING 职业
                case CEnum.TagName.CARD_education:// 0x1269,//TLV_STRING 教育程度
                case CEnum.TagName.CARD_marriage:// 0x1270,//TLV_STRING 婚否
                case CEnum.TagName.CARD_constellation:// 0x1271,//TLV_STRING 星座
                case CEnum.TagName.CARD_shx:// 0x1272,//TLV_STRING 生肖
                case CEnum.TagName.CARD_city:// 0x1273,//TLV_STRING 城市
                case CEnum.TagName.CARD_address:// 0x1274,//TLV_STRING 联系地址
                case CEnum.TagName.CARD_phone:// 0x1275,//TLV_STRING 联系电话
                case CEnum.TagName.CARD_qq:// 0x1276,//TLV_STRING QQ
                case CEnum.TagName.CARD_intro:// 0x1277,//TLV_STRING 介绍
                case CEnum.TagName.CARD_msn:// 0x1278,//TLV_STRING MSN
                case CEnum.TagName.CARD_mobilephone:// 0x1279,//TLV_STRING 移动电话
                ///
                case CEnum.TagName.AuShop_bkey://=0x1303,//varchar(40)
                case CEnum.TagName.AuShop_pkey://=0x1304,//varchar(18)

                case CEnum.TagName.AuShop_username://=0x1306,//varchar(20)

                case CEnum.TagName.AuShop_getusername://=0x1308,//varchar(20)

                case CEnum.TagName.AuShop_pisgift://=0x1310,//enum('y','n')
                case CEnum.TagName.AuShop_islover://=0x1311,//enum('y','n')
                case CEnum.TagName.AuShop_ispresent://=0x1312,//enum('y','n')
                case CEnum.TagName.AuShop_isbuysong://=0x1313,//enum('y','n')
                case CEnum.TagName.AuShop_psex://=0x1315,//enum('all','m','f')

                case CEnum.TagName.AuShop_zone://=0x1322,//tinyint(2)
                case CEnum.TagName.AuShop_buyip://=0x1321,//varchar(15)
                case CEnum.TagName.AuShop_pname://=0x1326,//varchar(20)
                case CEnum.TagName.AuShop_pgift://=0x1328,//enum('y','n')
                case CEnum.TagName.AuShop_pgamecode://=0x1331,//varchar(200)
                case CEnum.TagName.AuShop_pnew://=0x1332,//enum('y','n')
                case CEnum.TagName.AuShop_phot://=0x1333,//enum('y','n')
                case CEnum.TagName.AuShop_pcheap://=0x1334,//enum('y','n')
                case CEnum.TagName.AuShop_pautoprice://=0x1339,//enum('y','n')
                case CEnum.TagName.AuShop_ptimeitem://=0x1344,//varchar(200)
                case CEnum.TagName.AuShop_pricedetail://=0x1345,//varchar(254)
                case CEnum.TagName.AuShop_pdesc://=0x1347,//text
                case CEnum.TagName.AuShop_pmark1://=0x1350,//enum('y','n')
                case CEnum.TagName.AuShop_pmark2://=0x1351,//enum('y','n')
                case CEnum.TagName.AuShop_pmark3://=0x1352,//enum('y','n')
                case CEnum.TagName.AuShop_pisuse://=0x1355,//enum('y','n')
                case CEnum.TagName.AuShop_ppic://=0x1356,//varchar(36)
                case CEnum.TagName.AuShop_ppic1://=0x1357,//varchar(36)
                case CEnum.TagName.CARD_price:// 0x1241
                //////
                case CEnum.TagName.o2jam_ServerIP://=0x1401,//Format:TLV_STRINGIP
                case CEnum.TagName.o2jam_UserID://=0x1402,//Format:TLV_STRING用户帐号
                case CEnum.TagName.o2jam_UserNick://=0x1403,//Format:TLV_STRING用户呢称



                
                


                case CEnum.TagName.o2jam_USER_ID://=0x1457,//varchar
                case CEnum.TagName.o2jam_USER_NICKNAME://=0x1458,//varchar
                
                case CEnum.TagName.o2jam_SenderID://=0x1409,//varchar

                case CEnum.TagName.o2jam_SenderNickName://=0x1411,//varchar
                case CEnum.TagName.o2jam_ReceiverID://=0x1412,//varchar

                case CEnum.TagName.o2jam_ReceiverNickName://=0x1414,//varchar
                case CEnum.TagName.o2jam_Title://=0x1415,//varchar
                case CEnum.TagName.o2jam_Content://=0x1416,//varchar

                case CEnum.TagName.o2jam_ReadFlag://=0x1419,//char
                case CEnum.TagName.o2jam_TypeFlag://=0x1420,//char
                case CEnum.TagName.o2jam_KIND_CASH://=0x1435,//char
                case CEnum.TagName.o2jam_NAME://=0x1437,//varchar
                case CEnum.TagName.o2jam_DESCRIBE://=0x1450,//varchar

                case CEnum.TagName.o2jam_ITEM_NAME://=0x1453,//varchar

                case CEnum.TagName.AuShop_buytime://=0x1319,//int(10)

                case CEnum.TagName.Process_Reason:// = 0x060B,//Format tring

                case CEnum.TagName.O2JAM2_ServerIP:// = 0x1601,//TLV_STRING
		        case CEnum.TagName.O2JAM2_UserID:// = 0x1602,//TLV_STRING
                case CEnum.TagName.O2JAM2_UserName:// = 0x1603,//TLV_STRING
                case CEnum.TagName.O2JAM2_Id1:// = 0x1604,//TLV_Integer
                case CEnum.TagName.O2JAM2_Id2:// = 0x1605,//TLV_Integer
                case CEnum.TagName.o2jam2_consumetype:// = 0x1631
                
                ///////
                case CEnum.TagName.SDO_MusicName1:// = 0x0870,
                case CEnum.TagName.SDO_MusicName2:// = 0x0873,
                case CEnum.TagName.SDO_MusicName3:// = 0x0876,
                case CEnum.TagName.SDO_MusicName4:// = 0x0879,
                case CEnum.TagName.SDO_MusicName5:// = 0x0882,

                case CEnum.TagName.SDO_Sence://= 0x0868,
                case CEnum.TagName.SDO_KeyID:// = 0x0885,
		        case CEnum.TagName.SDO_KeyWord:// = 0x0886,
		        case CEnum.TagName.SDO_MasterID:// = 0x0887,
		        case CEnum.TagName.SDO_Master:// = 0x0888,
		        case CEnum.TagName.SDO_SlaverID:// = 0x0889,
                case CEnum.TagName.SDO_Slaver:// = 0x0890,


                case CEnum.TagName.O2JAM2_UserNick://= 0x1610,//Format:TLV_STRING 用户呢称
                case CEnum.TagName.O2JAM2_ItemName://= 0x1621,//Format:TLV_String
                case CEnum.TagName.O2JAM2_Title://= 0x1629,
                case CEnum.TagName.O2JAM2_Context://= 0x1630,
                case CEnum.TagName.O2JAM2_REASON:// = 0x1636,//string
                case CEnum.TagName.SDO_ChannelList:
                case CEnum.TagName.SDO_BoardMessage:
                case CEnum.TagName.SDO_ipaddr:// = 0x0897,
                case CEnum.TagName.SDO_MAIN_CH:
                case CEnum.TagName.SDO_SUB_CH:// = 0x0897,

                case CEnum.TagName.SDO_FirstPadTime:
                case CEnum.TagName.Soccer_charname: //角色名
               
                case CEnum.TagName.Soccer_Type: //查询类型
                case CEnum.TagName.Soccer_String: //查询值 
                case CEnum.TagName.Soccer_deleted_date ://删除日期
		        case CEnum.TagName.Soccer_status ://状态
                case CEnum.TagName.Soccer_ServerIP:
                case CEnum.TagName.Soccer_loginId: //Login ID
                case CEnum.TagName.Soccer_charsex:// 
                case CEnum.TagName.Soccer_admid:
                case CEnum.TagName.Soccer_regDate://玩家注册日期 string 
		        case CEnum.TagName.Soccer_c_date://角色创建日期 string 
                case CEnum.TagName.Soccer_kind:
                case CEnum.TagName.SDO_Lock_Status:
                case CEnum.TagName.SDO_State://TLV_STRING  状态
                case CEnum.TagName.SDO_ItemName1://TLV_STRING  道具名1
		        case CEnum.TagName.SDO_ItemName2://TLV_STRING  道具ID2
		        case CEnum.TagName.SDO_ItemName3://TLV_STRING  道具ID3
                case CEnum.TagName.SDO_ItemName4://TLV_STRING  道具ID4
		        case CEnum.TagName.SDO_ItemName5://TLV_STRING  道具ID5
                case CEnum.TagName.SD_UserName_Old://修改前用户名 string
                #region 光线飞车
                case CEnum.TagName.RayCity_ServerIP:
                case CEnum.TagName.RayCity_GuildName:
                case CEnum.TagName.RayCity_GuildMessage:
                case CEnum.TagName.RayCity_GuildGroupName:
                case CEnum.TagName.RayCity_LastLoginIPPrv:
                case CEnum.TagName.RayCity_LastLoginIPPub:
                case CEnum.TagName.RayCity_NyPassword:
                case CEnum.TagName.RayCity_NyNickName:
                case CEnum.TagName.RayCity_FriendGroupName:
                case CEnum.TagName.RayCity_CarName:
                case CEnum.TagName.RayCity_CharacterName:
                case CEnum.TagName.RayCity_FriendCharacterName:
                case CEnum.TagName.RayCity_NyUserID:
                case CEnum.TagName.RayCity_StartPos_X:
                case CEnum.TagName.RayCity_StartPos_Y:
                case CEnum.TagName.RayCity_StartPos_Z:
                case CEnum.TagName.RayCity_IPAddress:
                case CEnum.TagName.RayCity_ItemName:
                case CEnum.TagName.RayCity_ItemTypeName:
                case CEnum.TagName.RayCity_Title:
                case CEnum.TagName.RayCity_Message:
                case CEnum.TagName.RayCity_ActionTypeName:
                case CEnum.TagName.RayCity_SkillName:
                case CEnum.TagName.RayCity_TargetName:
                case CEnum.TagName.RayCity_GiftMessage:
                case CEnum.TagName.RayCity_FromCharacterName:
                case CEnum.TagName.RayCity_QuestName:
                case CEnum.TagName.RayCity_CountryCode:
                case CEnum.TagName.RayCity_CouponNumber:
                case CEnum.TagName.RayCity_rccdkey:
                case CEnum.TagName.RayCity_getuser:
                case CEnum.TagName.RayCity_gettime:
                case CEnum.TagName.RayCity_use_state:
                case CEnum.TagName.RayCity_activename:

                case CEnum.TagName.FJ_descr:
                #endregion

                #region SD敢达online
                case CEnum.TagName.SD_GoldAccount:
                case CEnum.TagName.SD_IsUsed:
                case CEnum.TagName.SD_UserName:
                case CEnum.TagName.SD_UseDate:
                case CEnum.TagName.SD_ActiceCode:

                case CEnum.TagName.f_passWd://密码 string
                case CEnum.TagName.f_pilot://绰号 string
                case CEnum.TagName.f_levelname://级别名称 string

                case CEnum.TagName.SD_ItemName://道具名 string 

                case CEnum.TagName.SD_UnitName://机体名 string
                case CEnum.TagName.SD_UnitNickName://机体呢称 string
                case CEnum.TagName.SD_StateSaleIntention://是否可以买卖 string
                case CEnum.TagName.SD_BatItemName://战斗道具名称 string
                case CEnum.TagName.SD_OperatorNickname://副官呢称 string

                case CEnum.TagName.SD_ServerIP://服务器IP string
                case CEnum.TagName.SD_ServerName://服务器名称 string                
                case CEnum.TagName.SD_Content://封停内容 string
                case CEnum.TagName.SD_Title://标题 string

                case CEnum.TagName.SD_TmpPWD://临时密码 string
                case CEnum.TagName.SD_passWd://真实密码 string
                case CEnum.TagName.SD_TempPassWord://密码 string

                case CEnum.TagName.SD_ItemName1://道具名1 string
                case CEnum.TagName.SD_ItemName2://道具名2 string
                case CEnum.TagName.SD_ItemName3://道具名3 string
                case CEnum.TagName.SD_FromUser://发送用户 string
                case CEnum.TagName.SD_ToUser://接受用户 string
                case CEnum.TagName.SD_Make://内容 string
                case CEnum.TagName.SD_LastMoney://剩余金钱 string
                case CEnum.TagName.SD_UseMoney://删除时得到金钱 string
                case CEnum.TagName.SD_DeleteResult://删除原因 string
                case CEnum.TagName.SD_UnitType://机体类型 string
                case CEnum.TagName.SD_ShopType://商店购买机体与否 string
                case CEnum.TagName.SD_LimitType://租赁期间到期与否 string
                case CEnum.TagName.SD_ChangeBody://改装部位 string
                case CEnum.TagName.SD_ChangeItem://改装道具 string
                case CEnum.TagName.SD_CombPic://合成图纸 string
                case CEnum.TagName.SD_CombItem://合成素材 string
                case CEnum.TagName.SD_Time://时间 string
                case CEnum.TagName.SD_QuestionName://任务名称 string
                case CEnum.TagName.SD_Questionlevel://任务难度 int

                case CEnum.TagName.SD_QuestionGetItem://任务奖励获得情况 string
                case CEnum.TagName.SD_Msg://内容 string 
                case CEnum.TagName.SD_FirendName://好友 string
                case CEnum.TagName.SD_GetMoney://得到金钱 string
                case CEnum.TagName.SD_State://状态 int
                case CEnum.TagName.SD_QusetName://任务名称 string
                case CEnum.TagName.SD_ClearedDate://完成时间 string 
                case CEnum.TagName.SD_UnitLevelNumber://机体等级 int
                case CEnum.TagName.SD_UnitExp://机体经验 int  
                case CEnum.TagName.SD_HP://string
                case CEnum.TagName.SD_DashLevel://string
                case CEnum.TagName.SD_StrikingPower://string
                case CEnum.TagName.SD_FatalAttack://string
                case CEnum.TagName.SD_DefensivePower://string
                case CEnum.TagName.SD_MotivePower://string


                case CEnum.TagName.SD_SkillName://技能 string

                case CEnum.TagName.SD_UDecal_1://标签1 string
                case CEnum.TagName.SD_UDecal_2://标签2 string
                case CEnum.TagName.SD_UDecal_3://标签3 string
                case CEnum.TagName.SD_UnitLevelName://机体等级
                case CEnum.TagName.SD_TypeName://类型
            
                case CEnum.TagName.SD_LostCodeMoney://剩余代币 string
                case CEnum.TagName.SD_UseCodeMoney://使用代币 string
                case CEnum.TagName.SD_LostMoney://消耗的G币
                case CEnum.TagName.SD_GuildName://工会名字 guildName
                case CEnum.TagName.SD_GuildBass://工会基地 string
                case CEnum.TagName.SD_Oldvalue://扣除前金额 string
                case CEnum.TagName.SD_Newvalue://扣除后金额 string 
                #endregion

                #region 劲舞团2
                case CEnum.TagName.JW2_ACCOUNT://玩家帐号 Format:String

                case CEnum.TagName.JW2_ServerName://服务器名称
                case CEnum.TagName.JW2_ServerIP://游戏服务器 Format:String
                case CEnum.TagName.JW2_Reason://封停理由 Format:String
                case CEnum.TagName.JW2_GSServerIP://星球 Format:String
                case CEnum.TagName.JW2_UserID: //Format:String 玩家ID
                case CEnum.TagName.JW2_BoardMessage://公告内容,喇叭发送内容Format:String
                case CEnum.TagName.JW2_Region://地区 Format:String
                case CEnum.TagName.JW2_QQ://QQ号 Format:String
                case CEnum.TagName.JW2_AvatarItemName://道具名称 Format:String
                case CEnum.TagName.JW2_MALEUSERNAME://男性用户名 string
                case CEnum.TagName.JW2_MALEUSERNICK://男性昵称 string 
                case CEnum.TagName.JW2_FEMALEUSERNAME://女性用户名 string
                case CEnum.TagName.JW2_FEMAILEUSERNICK://女性昵称 string
                case CEnum.TagName.JW2_WEDDINGNAME://婚礼名称 string
                case CEnum.TagName.JW2_WEDDINGVOW://婚礼誓言string
                case CEnum.TagName.JW2_CONFIRMSN://见证者SN string
                case CEnum.TagName.JW2_CONFIRMUSERNAME://见证者用户名 string
                case CEnum.TagName.JW2_CONFIRMUSERNICK://见证者昵称 string
                case CEnum.TagName.JW2_BREAKUSERNAME://提出用户名 string
                case CEnum.TagName.JW2_BREAKUSERNICK://提出昵称 string
                case CEnum.TagName.JW2_FAMILYNAME://名称 string
                case CEnum.TagName.JW2_DUTYNAME://职业名 string
                case CEnum.TagName.JW2_IP://IP地址 string
                case CEnum.TagName.JW2_PWD://密码 string 
                case CEnum.TagName.JW2_MailTitle://邮件主题 string 
                case CEnum.TagName.JW2_MailContent://邮件内容 string 
                case CEnum.TagName.JW2_Repute://声望 string
                case CEnum.TagName.JW2_ItemName://道具名称 string
                case CEnum.TagName.JW2_ProductName://商品名称 string
                case CEnum.TagName.JW2_PetName://宠物名称 string
                case CEnum.TagName.JW2_PetNick://宠物自定义名称 string
                case CEnum.TagName.JW2_SendNick://发件人昵称 string 
                case CEnum.TagName.JW2_ShaikhNick://族长名称 string
                case CEnum.TagName.JW2_SubFamilyName://隶属家族名称 string

                case CEnum.TagName.JW2_LASTLOGINDATE://最后登陆时间 date
                case CEnum.TagName.JW2_REGISTDATE://激活时间 date
                case CEnum.TagName.JW2_COUPLEDATE://情侣日期 date
                case CEnum.TagName.JW2_WEDDINGDATE://结婚时间 date
                case CEnum.TagName.JW2_BREAKDATE://分手时间 date
                case CEnum.TagName.JW2_CMBREAKDATE://确认分手时间 date
                case CEnum.TagName.JW2_LASTKISSDATE://最后一次Kiss时间 date
                case CEnum.TagName.JW2_TIME://时间 date
                case CEnum.TagName.JW2_ATTENDTIME://加入时间 date
                case CEnum.TagName.JW2_SendDate://发送日期 date
                case CEnum.TagName.JW2_ExpireDate://Format:TimesStamp  过期日期

                case CEnum.TagName.JW2_FCMSTATUS://防沉迷状态 int
                case CEnum.TagName.JW2_NowTitle://称号 int


                case CEnum.TagName.JW2_Rate://男女比例 int
                case CEnum.TagName.JW2_CNT://人数 int

                case CEnum.TagName.JW2_sNum://数量STRING


                case CEnum.TagName.JW2_AttendRank://人气排名 int
                case CEnum.TagName.JW2_MoneyRank://财富排名 int
                case CEnum.TagName.JW2_PowerRank://实力排名 int
                case CEnum.TagName.JW2_MessengerName://Messenger称号
                case CEnum.TagName.JW2_TmpPWD://临时密码 string 
                case CEnum.TagName.JW2_Type://类型 string
                case CEnum.TagName.JW2_SendUser://购买用户 string 
                case CEnum.TagName.JW2_RecUser://接收用户 string

                case CEnum.TagName.JW2_Center_AvatarName://中间件道具名 string
                case CEnum.TagName.JW2_LOGDATE://时间 date
                case CEnum.TagName.JW2_Last_Op_Time://最后使用时间 date

                case CEnum.TagName.JW2_Center_EndTime://過期時間 date

                case CEnum.TagName.JW2_Family_Money://捐献金钱 string 
                case CEnum.TagName.JW2_ReporterNick://举报人昵称 string
                case CEnum.TagName.JW2_ReportedNick://被举报人昵称 string
                case CEnum.TagName.JW2_Memo://举报说明 string 

                case CEnum.TagName.JW2_OLD_FAMILYNAME://老家族名 string
                case CEnum.TagName.JW2_OLD_PETNAME://老宠物自定义名
                case CEnum.TagName.JW2_BuyLimitDay://道具期限 string
                case CEnum.TagName.JW2_BuyMoneyCost://真实价格 string
                case CEnum.TagName.JW2_BuyOrgCost://原始价格 string 

                case CEnum.TagName.JW2_MissionName://任务名字 string
                case CEnum.TagName.jw2_MaterialCode://合成材料 string
                case CEnum.TagName.jw2_activepoint://活跃度 int

                case CEnum.TagName.TIMEBegin:
                case CEnum.TagName.TIMEEend:

                case CEnum.TagName.jw2_pic_Name://图片名称 string 


                case CEnum.TagName.jw2_petaggName://宠物蛋名 string

                case CEnum.TagName.jw2_petGetTime://孵化时间  string

                case CEnum.TagName.jw2_getTime://兑换时间	 string

                case CEnum.TagName.jw2_FirstFamilyName://申请方家族名 string
                case CEnum.TagName.jw2_SecondFamilyName://被申请方家族名 string
                case CEnum.TagName.jw2_FirstFamilyMaster://申请方家族族长名 string
                case CEnum.TagName.jw2_SecondFamilyMaster://被申请方族长名 string
                case CEnum.TagName.jw2_FirstFamilyUseMoneyr://申请方消耗基金 string
                case CEnum.TagName.jw2_SecondFamilyUseMoneyr://被申请方消耗基金 string
                case CEnum.TagName.jw2_ApplyDate:// 申请时间  string
                case CEnum.TagName.jw2_grade:
                case CEnum.TagName.jw2_ApplyState:// 申请状态  string


                case CEnum.TagName.jw2_PetAggName_Small:// 小宠物蛋名字	string 
                case CEnum.TagName.jw2_OverTimes://兑换时间 string 

                case CEnum.TagName.jw2_useLove://消耗亲密度 string


                case CEnum.TagName.AU_GSServerIP:
                case CEnum.TagName.AuShop_ItemTable:
                case CEnum.TagName.AU_BroadMsg://喇叭内容 string

                case CEnum.TagName.Magic_category://日志大类
                case CEnum.TagName.Magic_action://日志小类
                case CEnum.TagName.Magic_Dates://日期
             
                #endregion

                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                
                    break;

                case CEnum.TagName.JW2_UserNick://玩家呢称 Format:String
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_UNICODE;
                    tBody[iRow, iField].oContent = tTlv.toUnicode();
                    break;


                case CEnum.TagName.SDO_UserIndexID:  //0x0802,//Format:Integer 玩家用户ID
                case CEnum.TagName.SDO_Level:  //0x0804,//Format:Integer 玩家的等级
                case CEnum.TagName.SDO_Exp:  //0x0805,//Format:Integer 玩家的当前经验值
                case CEnum.TagName.SDO_GameTotal:  //0x0806,//Format:Integer 总局数
                case CEnum.TagName.SDO_GameWin:  //0x0807,//Format:Integer 胜局数
                case CEnum.TagName.SDO_DogFall:  //0x0808,//Format:Integer 平局数
                case CEnum.TagName.SDO_GameFall:  //0x0809,//Format:Integer 负局数
                case CEnum.TagName.SDO_Reputation:  //0x0810,//Format:Integer 声望值

                case CEnum.TagName.SDO_Age:  //0x0814,//Format:Integer 年龄
                case CEnum.TagName.SDO_ProductID:  //0x0815,//Format:Integer 商品编号
                case CEnum.TagName.SDO_ItemCode:  //0x0817,//Format:Integer 道具编号
                case CEnum.TagName.SDO_MoneyType:  //0x0819,//Format:Integer 货币类型
                case CEnum.TagName.SDO_MoneyCost:  //0x0820,//Format:Integer 道具的价格
                case CEnum.TagName.SDO_MAINCH:  //0x0822,//Format:Integer 服务器
                case CEnum.TagName.SDO_SUBCH:  //0x0823,//Format:Integer 房间
                case CEnum.TagName.SDO_Online:  //0x0824,//Format:Integer 是否在线
                case CEnum.TagName.SDO_ActiveStatus:
                case CEnum.TagName.SDO_SEX:  //0x0838,//性别
                case CEnum.TagName.SDO_Ispad:  //0x0842,//是否已注册跳舞毯
                case CEnum.TagName.SDO_Postion:// = 0x0844,//道具位置
                case CEnum.TagName.SDO_MinLevel:
                case CEnum.TagName.SDO_TimesLimit:
                case CEnum.TagName.SDO_SendIndexID: //0x0848,//Format:Integer 发送人的ID
                case CEnum.TagName.SDO_BigType: //0x0851,//Format:Integer 道具大类
                case CEnum.TagName.SDO_SmallType: // 0x0852,//Format:Integer 道具小类
                case CEnum.TagName.SDO_StopStatus:
                case CEnum.TagName.SDO_DaysLimit:// = 0x0855,//Format:Integer 使用天数
                case CEnum.TagName.SDO_ChargeSum:
                case CEnum.TagName.SDO_Interval:
                case CEnum.TagName.SDO_TaskID:
                case CEnum.TagName.SDO_Status:
                case CEnum.TagName.SDO_BanDate:
                ///
                case CEnum.TagName.ServerInfo_GameID:// = 0x0903,//Format:Integer 游戏ID
                case CEnum.TagName.ServerInfo_GameDBID:// = 0x0905,//Format:Integer 游戏数据库类型
                case CEnum.TagName.ServerInfo_GameFlag:// = 0x0906,//Format:Integer 游戏服务器状态
                case CEnum.TagName.ServerInfo_Idx:// = 0x0907,//format:Integer
                ///
                case CEnum.TagName.OnlineActive:
                /////
                
                case CEnum.TagName.CR_STATUS:// = 0x1106,//玩家状态 Format:Integer
                case CEnum.TagName.CR_BoardID:// = 0x1109,//公告ID Format:Integer
                case CEnum.TagName.CR_Valid:// = 0x1114,//是否有效 Format:Integer
                case CEnum.TagName.CR_PublishID:// = 0x1115,//发布人ID Format:Integer
                case CEnum.TagName.CR_DayLoop:// = 0x1116,//每天播放 Format:Integer
                case CEnum.TagName.CR_Mode://= 0x1130,//播放方式 Format:Integer
                case CEnum.TagName.CR_ACTION:// = 0x1131,//查询动作　Format:Integer
                case CEnum.TagName.CR_UserID:// = 0x1134,//用户ID
                case CEnum.TagName.CR_Last_Playing_Time:
                case CEnum.TagName.CR_Total_Time:
                ///
                
                case CEnum.TagName.AU_State://=0x1004://,//玩家状态Format:Integer
                case CEnum.TagName.AU_STOPSTATUS://=0x1005://,//劲舞者封停状态Format:Integer
                case CEnum.TagName.AU_Id9you://=0x1009://,//Format:Integer9youID
                case CEnum.TagName.AU_UserSN://=0x1010://,//Format:Integer用户序列号
                case CEnum.TagName.AU_AvatarItem://=0x1012://,//Format:Integer
                case CEnum.TagName.AU_BuyType://=0x1016://,//Format:Integer购买类型
                case CEnum.TagName.AU_PresentID://=0x1017://,//Format:Integer赠送ID
                case CEnum.TagName.AU_SendSN://=0x1018://,//Format:Integer赠送SN
                case CEnum.TagName.AU_RecvSN://=0x1020://,//Format:String接受人SN
                case CEnum.TagName.AU_Kind://=0x1022://,//Format:Integer类型
                case CEnum.TagName.AU_ItemID://=0x1023://,//Format:Integer道具ID
                case CEnum.TagName.AU_Period://=0x1024://,//Format:Integer期间
                case CEnum.TagName.AU_BeforeCash://=0x1025://,//Format:Integer消费之前金额
                case CEnum.TagName.AU_AfterCash://=0x1026://,//Format:Integer消费之后金额
                case CEnum.TagName.AU_Exp://=0x1031://,//Format:Integer玩家经验
                case CEnum.TagName.AU_Point://=0x1032://,//Format:Integer玩家位置
                case CEnum.TagName.AU_Money://=0x1033://,//Format:Integer金钱
                case CEnum.TagName.AU_Cash://=0x1034://,//Format:Integer现金
                case CEnum.TagName.AU_Level://=0x1035://,//Format:Integer等级
                case CEnum.TagName.AU_Ranking://=0x1036://,//Format:Integer银行
                case CEnum.TagName.AU_IsAllowMsg://=0x1037://,//Format:Integer允许发消息
                case CEnum.TagName.AU_IsAllowInvite://=0x1038://,//Format:Integer允许邀请
                case CEnum.TagName.AU_UserPower://=0x1043://,//Format:Integer
                case CEnum.TagName.AU_SexIndex:// = 0x1054,//性别
                ///
                case CEnum.TagName.CARD_PDID:// 0x1202
                case CEnum.TagName.CARD_PDgetuserid:// 0x1212
                case CEnum.TagName.CARD_UDID:// 0x1217 //TLV_INTEGER
                case CEnum.TagName.CARD_UDuserid:// 0x1221 //TLV_INTEGER
                case CEnum.TagName.CARD_UDcoins:// 0x1225 //TLV_INTEGER
                ///
                case CEnum.TagName.AuShop_orderid://=0x1301,//int(11)
                case CEnum.TagName.AuShop_udmark://=0x1302,//int(8)
                case CEnum.TagName.AuShop_userid://=0x1305,//int(11)
                case CEnum.TagName.AuShop_getuserid://=0x1307,//int(11)
                case CEnum.TagName.AuShop_pcategory://=0x1309,//smallint(4)
                case CEnum.TagName.AuShop_prule://=0x1314,//tinyint(1)
                case CEnum.TagName.AuShop_pbuytimes://=0x1316,//int(11)
                case CEnum.TagName.AuShop_allprice://=0x1317,//int(11)
                case CEnum.TagName.AuShop_allaup://=0x1318,//int(11)
                
                case CEnum.TagName.AuShop_status://=0x1323,//tinyint(1)
                case CEnum.TagName.AuShop_pid://=0x1324,//int(11)
                case CEnum.TagName.AuShop_pscash://=0x1330,//tinyint(2)
                case CEnum.TagName.AuShop_pchstarttime://=0x1335,//int(10)
                case CEnum.TagName.AuShop_pchstoptime://=0x1336,//int(10)
                case CEnum.TagName.AuShop_pstorage://=0x1337,//smallint(5)
                case CEnum.TagName.AuShop_price://=0x1340,//int(8)
                case CEnum.TagName.AuShop_chprice://=0x1341,//int(8)
                case CEnum.TagName.AuShop_aup://=0x1342,//int(8)
                case CEnum.TagName.AuShop_chaup://=0x1343,//int(8)
                case CEnum.TagName.AuShop_pbuys://=0x1348,//int(8)
                case CEnum.TagName.AuShop_pfocus://=0x1349,//tinyint(1)
                case CEnum.TagName.AuShop_pdate://=0x1354,//int(10)
                
                case CEnum.TagName.AuShop_usefeesum://=0x1358,//int
                case CEnum.TagName.AuShop_useaupsum://=0x1359,//int
                case CEnum.TagName.AuShop_buyitemsum://=0x1360,//int

                case CEnum.TagName.o2jam_Level://=0x1405,//Format:TLV_STRING等级

                case CEnum.TagName.o2jam_Sex://=0x1404,//Format:TLV_INTEGER性别

                case CEnum.TagName.o2jam_Win://=0x1406,//Format:TLV_STRING胜
                case CEnum.TagName.o2jam_Draw://=0x1407,//Format:TLV_STRING平
                case CEnum.TagName.o2jam_Lose://=0x1408,//Format:TLV_STRING负
                case CEnum.TagName.o2jam_SEX://=0x1459,//char
                case CEnum.TagName.o2jam_WriteDate://=0x1417,//datetime
                case CEnum.TagName.O2JAM2_ComsumeCode:// = 0x1632,
                case CEnum.TagName.O2JAM2_Timeslimt://= 0x1622,
                case CEnum.TagName.Soccer_m_id://玩家序列号 int
		        case CEnum.TagName.Soccer_m_auth://玩家是否被停封 int
                case CEnum.TagName.Soccer_char_max:
                case CEnum.TagName.Soccer_char_cnt:
                case CEnum.TagName.Soccer_ret:
                case CEnum.TagName.SDO_LevPercent:
                case CEnum.TagName.SDO_ItemCodeBy:
                case CEnum.TagName.SDO_mood://TLV_INTEGER 心情值
                case CEnum.TagName.SDO_Food://TLV_INTEGER 饱食度
                case CEnum.TagName.SDO_DateLimit1://TLV_INTEGER 日期限制
		        case CEnum.TagName.SDO_TimeLimit1://TLV_INTEGER 次数限制
                case CEnum.TagName.SDO_DateLimit2://TLV_INTEGER 日期限制
		        case CEnum.TagName.SDO_TimeLimit2://TLV_INTEGER 次数限制
                case CEnum.TagName.SDO_DateLimit3://TLV_INTEGER 日期限制
		        case CEnum.TagName.SDO_TimeLimit3://TLV_INTEGER 次数限制
                case CEnum.TagName.SDO_DateLimit4://TLV_INTEGER 日期限制
		        case CEnum.TagName.SDO_TimeLimit4://TLV_INTEGER 次数限制
	            case CEnum.TagName.SDO_DateLimit5://TLV_INTEGER 日期限制
		        case CEnum.TagName.SDO_TimeLimit5://TLV_INTEGER 次数限制
                
                case CEnum.TagName.SDO_PreValue://最小值
                case CEnum.TagName.SDO_EndValue://最大值
                case CEnum.TagName.SDO_NorProFirst://第一次打开的概率
                case CEnum.TagName.SDO_NorPro://普通宝箱的概率
                case CEnum.TagName.SDO_SpePro://特殊宝箱的概率
                case CEnum.TagName.SDO_baoxiangid://id int
                case CEnum.TagName.SDO_Mark://标识 int
                case CEnum.TagName.SD_ID://id INT

                case CEnum.TagName.LORD_Gold://金币
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;



                case CEnum.TagName.MJ_Time: // = 0x0741,//Format:TimeStamp  操作时间
                case CEnum.TagName.SD_QuestionTime://任务完成时间 string

                case CEnum.TagName.jw2_LastGetPointDate:

                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_DATE;
                    tBody[iRow, iField].oContent = tTlv.toDate();
                    break;
                
                case CEnum.TagName.SDO_DateLimit:
                case CEnum.TagName.SDO_LoginTime:  //0x0825,//Format:DateTime 上线时间
                case CEnum.TagName.SDO_LogoutTime:  //0x0826,//Format:DateTime 下线时间
                case CEnum.TagName.SDO_ShopTime:  //0x0821,//Format:DateTime 消费时间
                case CEnum.TagName.SDO_StopTime:// = 0x0854,//Format:TimeStamp 停封时间
                ///////
                case CEnum.TagName.ACT_Time: //0x0414,//Format:TimeStamp 操作时间
                ///
                case CEnum.TagName.CR_ActiveDate:// = 0x1108,//激活日期 Format:TimeStamp        
                case CEnum.TagName.CR_ValidTime:// = 0x1112,//生效时间 Format:TimeStamp
                case CEnum.TagName.CR_InValidTime:// = 0x1113,//失效时间 Format:TimeStamp
                ///
                case CEnum.TagName.AU_BanDate://=0x1007://,//封停日期Format:TimeStamp
                case CEnum.TagName.AU_BuyDate://=0x1014://,//Format:Timestamp购买日期
                case CEnum.TagName.AU_ExpireDate://=0x1015://,//Format:TimesStamp过期日期
                case CEnum.TagName.AU_SendDate://=0x1027://,//Format:TimeStamp发送日期
                case CEnum.TagName.AU_RecvDate://=0x1028://,//Format:TimeStamp接受日期
                case CEnum.TagName.AU_LastLoginTime://=0x1039://,//Format:TimeStamp最后登录时间
                case CEnum.TagName.AU_RegistedTime://=0x1046://,//Format:TimeStamp注册时间
                case CEnum.TagName.AuShop_buytime2://=0x1320,//datetime
                ///
                case CEnum.TagName.CARD_UDdate:// 0x1230 timestamp
                case CEnum.TagName.AuShop_pinttime://=0x1353,//int(10)
                case CEnum.TagName.o2jam_ReadDate://=0x1418,//datetime
                case CEnum.TagName.o2jam_Ban_Date://=0x1421,//datetime
                case CEnum.TagName.o2jam_REG_DATE://=0x1430,//datetime
                case CEnum.TagName.o2jam_CREATE_TIME://=0x1460,//datetime
                case CEnum.TagName.o2jam_UPDATE_TIME://=0x1451,//datetime
                case CEnum.TagName.o2jam_BeginDate:// = 0x1461,
                case CEnum.TagName.o2jam_EndDate:// = 0x1462,
                case CEnum.TagName.CARD_PDdate:// 0x1214

                case CEnum.TagName.BeginTime:// = 0x0415,//Format:Date 开始日期
                case CEnum.TagName.EndTime:// = 0x0416,//Format:Date 结束日期
                case CEnum.TagName.SDO_RegistDate:  //0x0839,//注册日期
                case CEnum.TagName.SDO_FirstLogintime:  //0x0840,//第一次登录时间
                case CEnum.TagName.SDO_LastLogintime:  //0x0841,//最后一次登录时间
                case CEnum.TagName.SDO_BeginTime: //0x0845,//Format:Date 消费记录开始时间
                case CEnum.TagName.SDO_EndTime: //0x0846,//Format:Date 消费记录结束时间
                case CEnum.TagName.SDO_SendTime: //0x0847,//Format:Date 道具送人日期
                ///
                case CEnum.TagName.CARD_rdate:// 0x1256,//TLV_Date 久之游注册日期
                case CEnum.TagName.CARD_birthday:// 0x1264,//TLV_Date 出生日期
                ///
                case CEnum.TagName.AuShop_BeginDate://=0x1361,//date
                case CEnum.TagName.AuShop_EndDate://=0x1362,//
                ///
                ///
                
                case CEnum.TagName.O2JAM2_DateLimit://= 0x1623,
                case CEnum.TagName.O2JAM2_BeginDate://= 0x1626,
                case CEnum.TagName.O2JAM2_ENDDate://= 0x1627,
                case CEnum.TagName.O2JAM2_StopTime:// = 0x1634,//date
                case CEnum.TagName.CR_Last_Login:// = 0x1634,//date
                case CEnum.TagName.CR_Last_Logout:// = 0x1634,//date

                #region 光线飞车
                /// <summary>
                /// 光线飞车
                /// </summary>
                case CEnum.TagName.RC_OnlineTime:
                case CEnum.TagName.RC_OfflineTime:
                case CEnum.TagName.RC_BeginDate:
                case CEnum.TagName.RC_EndDate:
                case CEnum.TagName.RC_BanDate:
                case CEnum.TagName.RC_Sys_timeLastLogout://TLV_TimeStamp 最后一次退出时间
                case CEnum.TagName.RC_CreatDate:
                case CEnum.TagName.RayCity_TodayPlayTime:
                case CEnum.TagName.RayCity_TodayOfflineTime:
                case CEnum.TagName.RayCity_LastLoginTime:
                case CEnum.TagName.RayCity_LastLogoutTime:
                case CEnum.TagName.RayCity_BeginDate:
                case CEnum.TagName.RayCity_EndDate:
                case CEnum.TagName.RayCity_ExpireDate:
                case CEnum.TagName.RayCity_FixedTime:
                case CEnum.TagName.RayCity_CreateDate:
                case CEnum.TagName.RayCity_LastUpdateDate:
                case CEnum.TagName.RayCity_StartDate:
                case CEnum.TagName.RayCity_SendDate://发送日期
                case CEnum.TagName.RC_BuyTime:
              
                case CEnum.TagName.RC_ReceiveTime:
                case CEnum.TagName.RC_OperationTime:
                case CEnum.TagName.RC_ActiveTime:
                #endregion
                ///
                #region 敢达online
                case CEnum.TagName.f_regDate://注册日期 timestamp
                case CEnum.TagName.f_loginDate://最后登陆日期 timestamp
                case CEnum.TagName.f_logoutDate://最后登出日期 timestamp
                case CEnum.TagName.f_bandate://封停日期 timestamp
                case CEnum.TagName.SD_GetTime://获得时间 timestamp
                case CEnum.TagName.SD_DateEnd://到期时间 timestamp
                case CEnum.TagName.SD_StartTime://起始时间  timestamp
                case CEnum.TagName.SD_EndTime://结束时间 timestamp
                case CEnum.TagName.SD_SendTime://发送时间 dateTime
                case CEnum.TagName.SD_DelTime://删除时间 timestamp
                case CEnum.TagName.SD_LevelUpTime://升级时间 timestamp

                #endregion


                case CEnum.TagName.AU_Log_start://查询开始时间 (char 14) [YYYYMMDDHHIISS]
                case CEnum.TagName.AU_Log_end://查询结束时间 (char 14) [YYYYMMDDHHIISS]
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                    tBody[iRow, iField].oContent = tTlv.toTimeStamp();
                    break;
                case CEnum.TagName.CARD_PDCardPrice:// 0x1208
                
                case CEnum.TagName.CARD_SumTotal:
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_MONEY;
                    tBody[iRow, iField].oContent = tTlv.toMoney();
                    break;

                case CEnum.TagName.O2JAM2_Sex://= 0x1611,//Format:TLV_BOOLEAN 性别
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_BOOLEAN;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                default:
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = "无法获得标签";
                    break;
			}
			#endregion

			return tBody;
		}
		/// <summary>
		/// 接收消息
		/// </summary>
        private CEnum.Message_Body[,] ReciveMessage(CSocketClient pSocketClient)
		{
			int iField = 0;
            CEnum.Message_Body[,] p_ReturnBody = null;

			Packet mPacket = null;
			Packet_Head mPacketHead = null;
			Packet_Body mPacketbody = null;
			
			try
			{
				CSocketData mReciveData = new CSocketData();

				mReciveData = mSockData.SocketRecive(pSocketClient.ReceiveData());

				if (System.Text.Encoding.Unicode.GetString(mReciveData.bMsgBuffer).Equals("FAILURE"))
				{
                    p_ReturnBody = new CEnum.Message_Body[1, 1];
					p_ReturnBody[0,0].eName = CEnum.TagName.ERROR_Msg;
					p_ReturnBody[0,0].eTag = CEnum.TagFormat.TLV_STRING;
					p_ReturnBody[0,0].oContent = "服务器超时";

					return p_ReturnBody;
				}

				if (!mReciveData.bValidMsag)
				{
                    p_ReturnBody = new CEnum.Message_Body[1, 1];
                    p_ReturnBody[0, 0].eName = CEnum.TagName.ERROR_Msg;
                    p_ReturnBody[0, 0].eTag = CEnum.TagFormat.TLV_STRING;
					p_ReturnBody[0,0].oContent = "数据解析异常";

					return p_ReturnBody;
				}

				mPacket = mReciveData.m_Packet;
				mPacketHead = mReciveData.m_Packet.m_Head;
				mPacketbody = mReciveData.m_Packet.m_Body;	

				#region 解析 MessageID
				switch (mReciveData.GetMessageID())
                {
                    #region ---
                    /*
                    case CEnum.Message_Tag_ID.CONNECT: //0x800001,
                    case CEnum.Message_Tag_ID.CONNECT_RESP: //0x808001,
                    case CEnum.Message_Tag_ID.DISCONNECT: //0x800002,
                    case CEnum.Message_Tag_ID.DISCONNECT_RESP: //0x808002,
                    case CEnum.Message_Tag_ID.ACCOUNT_AUTHOR: //0x800003,
                    case CEnum.Message_Tag_ID.ACCOUNT_AUTHOR_RESP: //0x808003,
                    case CEnum.Message_Tag_ID.USER_CREATE: //0x810001,
                    case CEnum.Message_Tag_ID.USER_CREATE_RESP: //0x818001,
                    case CEnum.Message_Tag_ID.USER_UPDATE: //0x810002,
                    case CEnum.Message_Tag_ID.USER_UPDATE_RESP: //0x818002,
                    case CEnum.Message_Tag_ID.USER_DELETE: //0x810003,
                    case CEnum.Message_Tag_ID.USER_DELETE_RESP: //0x818003,
                    case CEnum.Message_Tag_ID.USER_QUERY: //0x810004,
                    case CEnum.Message_Tag_ID.USER_PASSWD_MODIF: //0x810005
                    case CEnum.Message_Tag_ID.USER_PASSWD_MODIF_RESP: //0x818005
                    case CEnum.Message_Tag_ID.MODULE_CREATE: //0x820001,
                    case CEnum.Message_Tag_ID.MDDULE_CREATE_RESP: //0x828001,
                    case CEnum.Message_Tag_ID.MODULE_UPDATE: //0x820002,
                    case CEnum.Message_Tag_ID.MODULE_UPDATE_RESP: //0x828002,
                    case CEnum.Message_Tag_ID.MODULE_DELETE: //0x820003,
                    case CEnum.Message_Tag_ID.MODULE_DELETE_RESP: //0x828003,
                    case CEnum.Message_Tag_ID.MODULE_QUERY: //0x820004,
                    case CEnum.Message_Tag_ID.USER_MODULE_CREATE: //0x830001,
                    case CEnum.Message_Tag_ID.USER_MODULE_CREATE_RESP: //0x838001,
                    case CEnum.Message_Tag_ID.USER_MODULE_UPDATE: //0x830002,
                    case CEnum.Message_Tag_ID.USER_MODULE_UPDATE_RESP: //0x838002,
                    case CEnum.Message_Tag_ID.USER_MODULE_DELETE: //0x830003,
                    case CEnum.Message_Tag_ID.USER_MODULE_DELETE_RESP: //0x838003,
                    case CEnum.Message_Tag_ID.GAME_CREATE: //0x840001,//创建GM帐号请求
                    case CEnum.Message_Tag_ID.GAME_CREATE_RESP: //0x848001,//创建GM帐号响应
                    case CEnum.Message_Tag_ID.GAME_UPDATE: //0x840002,//更新GM帐号信息请求
                    case CEnum.Message_Tag_ID.GAME_UPDATE_RESP: //0x848002,//更新GM帐号信息响应
                    case CEnum.Message_Tag_ID.GAME_DELETE: //0x840003,//删除GM帐号信息请求
                    case CEnum.Message_Tag_ID.GAME_DELETE_RESP: //0x848003,//删除GM帐号信息响应
                    case CEnum.Message_Tag_ID.GAME_QUERY:
                    case CEnum.Message_Tag_ID.GAME_MODULE_QUERY:
                    case CEnum.Message_Tag_ID.NOTDEFINED: //0x0,
                    case CEnum.Message_Tag_ID.NOTES_LETTER_PROCESS://  0x850002, //邮件处理
                    case CEnum.Message_Tag_ID.NOTES_LETTER_PROCESS_RESP://  0x858002,//邮件处理
                    case CEnum.Message_Tag_ID.ERROR: //0xFFFFFFFF
                    case CEnum.Message_Tag_ID.UPDATE_ACTIVEUSER://更新在线用户状态
                    case CEnum.Message_Tag_ID.UPDATE_ACTIVEUSER_RESP://更新在线用户状态响应
                    case CEnum.Message_Tag_ID.LINK_SERVERIP_CREATE:// = 0x0007,
                    case CEnum.Message_Tag_ID.LINK_SERVERIP_CREATE_RESP:// = 0x8007,
                    
                    ////////////////////////游戏管理消息 -- 猛将////////////////////////
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_UPDATE: //0x860002,//修改玩家状态
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_UPDATE_RESP: //0x868002,//修改玩家状态响应
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_EXPLOIT_UPDATE: //0x860004,//修改功勋值
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_EXPLOIT_UPDATE_RESP: //0x868004,//修改功勋值响应
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_FRIEND_CREATE: //0x860006,//添加好友
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_FRIEND_CREATE_RESP: //0x868006,//添加好友响应
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_FRIEND_DELETE: //0x860007,//删除好友
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_FRIEND_DELETE_RESP: //0x868007,//删除好友响应
                    case CEnum.Message_Tag_ID.MJ_GUILDTABLE_UPDATE: //0x860008,//修改服务器所有已存在帮会
                    case CEnum.Message_Tag_ID.MJ_GUILDTABLE_UPDATE_RESP: //0x868008,//修改服务器所有已存在帮会响应
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_LOCAL_CREATE: //0x860009,//将服务器上的account表里的玩家信息保存到本地服务器的
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_LOCAL_CREATE_RESP: //0x868009,//将服务器上的account表里的玩家信息保存到本地服务器的响应
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_REMOTE_DELETE: //0x860009,//永久封停帐号
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_REMOTE_DELETE_RESP: //0x868009,//永久封停帐号的响应
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_REMOTE_RESTORE: //0x860010,//解封帐号
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_REMOTE_RESTORE_RESP: //0x868010,//解封帐号响应
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_LIMIT_RESTORE: //0x860011,//有时限的封停
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_LIMIT_RESTORE_RESP: //0x868011,//有时限的封停响应
                    case CEnum.Message_Tag_ID.MJ_ACCOUNTPASSWD_LOCAL_CREATE: //0x860012,//保存玩家密码到本地 
                    case CEnum.Message_Tag_ID.MJ_ACCOUNTPASSWD_LOCAL_CREATE_RESP: //0x868012,//保存玩家密码到本地
                    case CEnum.Message_Tag_ID.MJ_ACCOUNTPASSWD_REMOTE_UPDATE: //0x860013,//修改玩家密码 
                    case CEnum.Message_Tag_ID.MJ_ACCOUNTPASSWD_REMOTE_UPDATE_RESP: //0x868013,//修改玩家密码
                    case CEnum.Message_Tag_ID.MJ_ACCOUNTPASSWD_REMOTE_RESTORE: //0x860014,//恢复玩家密码
                    case CEnum.Message_Tag_ID.MJ_ACCOUNTPASSWD_REMOTE_RESTORE_RESP: //0x868014,//恢复玩家密码
                    
                    ////////////////////////游戏管理消息 -- 超级舞者////////////////////////
                    case CEnum.Message_Tag_ID.SDO_ACCOUNT_CLOSE:  //0x870028,//封停帐户的权限信息
                    case CEnum.Message_Tag_ID.SDO_ACCOUNT_CLOSE_RESP:  //0x878028,//封停帐户的权限信息响应
                    case CEnum.Message_Tag_ID.SDO_ACCOUNT_OPEN:  //0x870029,//解封帐户的权限信息
                    case CEnum.Message_Tag_ID.SDO_ACCOUNT_OPEN_RESP:  //0x878029,//解封帐户的权限信息响应
                    case CEnum.Message_Tag_ID.SDO_PASSWORD_RECOVERY:  //0x870030,//玩家找回密码
                    case CEnum.Message_Tag_ID.SDO_PASSWORD_RECOVERY_RESP:  //0x878030,//玩家找回密码响应
                    case CEnum.Message_Tag_ID.SDO_CHARACTERINFO_UPDATE:  //0x870034,//修改玩家的账号信息
                    case CEnum.Message_Tag_ID.SDO_CHARACTERINFO_UPDATE_RESP:  //0x878034,//修改玩家的账号信息响应

						iField = 1;
                        p_ReturnBody = new CEnum.Message_Body[mPacketbody.TLVCount, iField];
						
						for (int i=0; i<mPacketbody.TLVCount; i++)
						{
							TLV_Structure mStruct = new TLV_Structure(mPacketbody.getTLVByIndex(i).m_Tag, mPacketbody.getTLVByIndex(i).m_uiValueLen, mPacketbody.getTLVByIndex(i).m_bValueBuffer);
							
							p_ReturnBody[i,0].eName = mPacketbody.getTLVByIndex(i).m_Tag;
							p_ReturnBody = DecodeRecive(i, iField - 1, mStruct, p_ReturnBody);
						}					
						break;
                    case CEnum.Message_Tag_ID.MODULE_QUERY_RESP: //0x828004,
                    case CEnum.Message_Tag_ID.USER_MODULE_QUERY:// 0x830004:查询用户所对应模块请求
                    case CEnum.Message_Tag_ID.USER_MODULE_QUERY_RESP://0x838004:查询用户所对应模块响应
                    case CEnum.Message_Tag_ID.NOTES_LETTER_TRANSFER: //0x850001, //取得邮件列表
                    case CEnum.Message_Tag_ID.NOTES_LETTER_TRANSFER_RESP: //0x858001,//取得邮件列表的响应
                    case CEnum.Message_Tag_ID.USER_QUERY_RESP: //0x818004,
                    case CEnum.Message_Tag_ID.GAME_QUERY_RESP: //0x818004,
                    case CEnum.Message_Tag_ID.GAME_MODULE_QUERY_RESP: //0x848005,
                    case CEnum.Message_Tag_ID.USER_QUERY_ALL: //0x818004,
                    case CEnum.Message_Tag_ID.USER_QUERY_ALL_RESP: //0x848005,
                    case CEnum.Message_Tag_ID.NOTES_LETTER_TRANSMIT: //0x818004,
                    case CEnum.Message_Tag_ID.NOTES_LETTER_TRANSMIT_RESP: //0x848005,
                    case CEnum.Message_Tag_ID.DEPART_QUERY: //0x818004,
                    case CEnum.Message_Tag_ID.DEPART_QUERY_RESP: //0x848005,
                    case CEnum.Message_Tag_ID.SERVERINFO_IP_QUERY:
                    case CEnum.Message_Tag_ID.SERVERINFO_IP_QUERY_RESP:
                    case CEnum.Message_Tag_ID.SERVERINFO_IP_ALL_QUERY:// = 0x0006,//查询所有游戏服务IP
                    case CEnum.Message_Tag_ID.SERVERINFO_IP_ALL_QUERY_RESP:// = 0x8006,//查询所有游戏服务IP响应
                    ////////////////////////游戏管理消息 -- 猛将////////////////////////
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_QUERY: //0x860001,//检查玩家状态
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_QUERY_RESP: //0x868001,//检查玩家状态响应
                    case CEnum.Message_Tag_ID.MJ_LOGINTABLE_QUERY: //0x860003,//检查玩家是否在线
                    case CEnum.Message_Tag_ID.MJ_LOGINTABLE_QUERY_RESP: //0x868003,//检查玩家是否在线响应
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_FRIEND_QUERY: //0x860005,//列出好友名单
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_FRIEND_QUERY_RESP: //0x868005,//列出好有名单响应
                    case CEnum.Message_Tag_ID.MJ_ITEMLOG_QUERY: //0x860015,//检查该用户交易记录
                    case CEnum.Message_Tag_ID.MJ_ITEMLOG_QUERY_RESP: //0x868015,//检查该用户交易记录
                    case CEnum.Message_Tag_ID.MJ_GMTOOLS_LOG_QUERY: //0x860016,//检查使用者操作记录
                    case CEnum.Message_Tag_ID.MJ_GMTOOLS_LOG_QUERY_RESP: //0x868016,//检查使用者操作记录
                    case CEnum.Message_Tag_ID.MJ_MONEYFIGHTERSORT_QUERY:
                    case CEnum.Message_Tag_ID.MJ_MONEYFIGHTERSORT_QUERY_RESP:
                    case CEnum.Message_Tag_ID.MJ_MONEYRABBISORT_QUERY:
                    case CEnum.Message_Tag_ID.MJ_MONEYRABBISORT_QUERY_RESP:
                    case CEnum.Message_Tag_ID.MJ_MONEYSORT_QUERY:
                    case CEnum.Message_Tag_ID.MJ_MONEYSORT_QUERY_RESP:
                    case CEnum.Message_Tag_ID.MJ_MONEYTAOISTSORT_QUERY:
                    case CEnum.Message_Tag_ID.MJ_MONEYTAOISTSORT_QUERY_RESP:
                    case CEnum.Message_Tag_ID.MJ_LEVELFIGHTERSORT_QUERY:
                    case CEnum.Message_Tag_ID.MJ_LEVELFIGHTERSORT_QUERY_RESP:
                    case CEnum.Message_Tag_ID.MJ_LEVELRABBISORT_QUERY:
                    case CEnum.Message_Tag_ID.MJ_LEVELRABBISORT_QUERY_RESP:
                    case CEnum.Message_Tag_ID.MJ_LEVELSORT_QUERY:
                    case CEnum.Message_Tag_ID.MJ_LEVELSORT_QUERY_RESP:
                    case CEnum.Message_Tag_ID.MJ_LEVELTAOISTSORT_QUERY:
                    case CEnum.Message_Tag_ID.MJ_LEVELTAOISTSORT_QUERY_RESP:
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_LOCAL_QUERY:// = 0x860027,//查询猛将本地帐号
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_LOCAL_QUERY_RESP:// = 0x868027,//查询猛将本地帐号响应
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_QUERY:// = 0x0026,//猛将帐号查询
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_QUERY_RESP:// = 0x8026,//猛将帐号查询响应
                    ////////////////////////游戏管理消息 -- 超级舞者////////////////////////
                    case CEnum.Message_Tag_ID.SDO_ACCOUNT_QUERY:  //0x870026,//查看玩家的帐号信息
                    case CEnum.Message_Tag_ID.SDO_ACCOUNT_QUERY_RESP:  //0x878026,//查看玩家的帐号信息响应
                    case CEnum.Message_Tag_ID.SDO_CHARACTERINFO_QUERY:  //0x870027,//查看任务资料的信息
                    case CEnum.Message_Tag_ID.SDO_CHARACTERINFO_QUERY_RESP:  //0x878027,//查看人物资料的信息响应
                    case CEnum.Message_Tag_ID.SDO_CONSUME_QUERY:  //0x870031,//查看玩家的消费记录
                    case CEnum.Message_Tag_ID.SDO_CONSUME_QUERY_RESP:  //0x878031,//查看玩家的消费记录响应
                    case CEnum.Message_Tag_ID.SDO_USERONLINE_QUERY:  //0x870032,//查看玩家上下线状态
                    case CEnum.Message_Tag_ID.SDO_USERONLINE_QUERY_RESP:  //0x878032,//查看玩家上下线状态响应
                    case CEnum.Message_Tag_ID.SDO_USERTRADE_QUERY:  //0x870033,//查看玩家交易状态
                    case CEnum.Message_Tag_ID.SDO_USERTRADE_QUERY_RESP:  //0x878033,//查看玩家交易状态响应
                    case CEnum.Message_Tag_ID.SDO_ITEMSHOP_QUERY:  //0x870033,//查看玩家交易状态
                    case CEnum.Message_Tag_ID.SDO_ITEMSHOP_QUERY_RESP:  //0x878033,//查看玩家交易状态响应
                    case CEnum.Message_Tag_ID.SDO_GIFTBOX_CREATE:
                    case CEnum.Message_Tag_ID.SDO_GIFTBOX_CREATE_RESP:
                    case CEnum.Message_Tag_ID.SDO_ITEMSHOP_DELETE:
                    case CEnum.Message_Tag_ID.SDO_ITEMSHOP_DELETE_RESP:
                    case CEnum.Message_Tag_ID.SDO_USERLOGIN_STATUS_QUERY:
                    case CEnum.Message_Tag_ID.SDO_USERLOGIN_STATUS_QUERY_RESP:
                    case CEnum.Message_Tag_ID.SDO_ITEMSHOP_BYOWNER_QUERY:
                    case CEnum.Message_Tag_ID.SDO_ITEMSHOP_BYOWNER_QUERY_RESP:
                    case CEnum.Message_Tag_ID.SDO_ITEMSHOP_TRADE_QUERY:// 0x870040,//查看玩家交易记录信息
                    case CEnum.Message_Tag_ID.SDO_ITEMSHOP_TRADE_QUERY_RESP:// 0x878040,//查看玩家交易记录信息的响应
                    case CEnum.Message_Tag_ID.SDO_MEMBERSTOPSTATUS_QUERY:// = 0x870041,//查看该帐号状态
                    case CEnum.Message_Tag_ID.SDO_MEMBERSTOPSTATUS_QUERY_RESP:// = 0x878041,///查看该帐号状态的响应
                    case CEnum.Message_Tag_ID.SDO_GIFTBOX_QUERY:// = 0x870042,//查看玩家礼物盒的道具
                    case CEnum.Message_Tag_ID.SDO_GIFTBOX_QUERY_RESP:// = 0x878042,//查看玩家礼物盒的道具响应
                    case CEnum.Message_Tag_ID.SDO_MEMBERBANISHMENT_QUERY: //0x870044,//查看所有停封的帐号
                    case CEnum.Message_Tag_ID.SDO_MEMBERBANISHMENT_QUERY_RESP: //0x878044,//查看所有停封的帐号响应
                    case CEnum.Message_Tag_ID.SDO_USERMCASH_QUERY: //0x870045,//玩家充值记录查询
                    case CEnum.Message_Tag_ID.SDO_USERMCASH_QUERY_RESP: //0x878045,//玩家充值记录查询响应
                    case CEnum.Message_Tag_ID.SDO_USERGCASH_UPDATE: //0x870046,//补偿玩家G币
                    case CEnum.Message_Tag_ID.SDO_USERGCASH_UPDATE_RESP: //0x878046,//补偿玩家G币的响应
                    case CEnum.Message_Tag_ID.SDO_MEMBERLOCAL_BANISHMENT://= 0x870047,//本地保存停封信息
                    case CEnum.Message_Tag_ID.SDO_MEMBERLOCAL_BANISHMENT_RESP: //0x878047,//本地保存停封信息响应
                    //////////////////////////GM 操作日志///////////////////////////////////
                    case CEnum.Message_Tag_ID.GMTOOLS_OperateLog_Query:// 0x800005,//查看工具操作记录
                    case CEnum.Message_Tag_ID.GMTOOLS_OperateLog_Query_RESP:// 0x808005,//查看工具操作记录响应
                    //////////////////////////升级//////////////////////////////////////////
	                case CEnum.Message_Tag_ID.CLIENT_PATCH_COMPARE:// = 0x0008,//客户端版本升级
                    case CEnum.Message_Tag_ID.CLIENT_PATCH_COMPARE_RESP:// = 0x8008,//客户端版本升级
                    */
                    #endregion
                        /// <summary>
                        /// 公共模块(0x80)
                        /// </summary>
                        case CEnum.Message_Tag_ID.CONNECT:// 0x800001://连接请求
                        case CEnum.Message_Tag_ID.CONNECT_RESP:// 0x808001://连接响应
                        case CEnum.Message_Tag_ID.DISCONNECT:// 0x800002://断开请求
                        case CEnum.Message_Tag_ID.DISCONNECT_RESP:// 0x808002://断开响应
                        case CEnum.Message_Tag_ID.ACCOUNT_AUTHOR:// 0x800003://用户身份验证请求
                        case CEnum.Message_Tag_ID.ACCOUNT_AUTHOR_RESP:// 0x808003://用户身份验证响应
                        case CEnum.Message_Tag_ID.SERVERINFO_IP_QUERY:// 0x800004:
                        case CEnum.Message_Tag_ID.SERVERINFO_IP_QUERY_RESP:// 0x808004:
                        case CEnum.Message_Tag_ID.GMTOOLS_OperateLog_Query:// 0x800005://查看工具操作记录
                        case CEnum.Message_Tag_ID.GMTOOLS_OperateLog_Query_RESP:// 0x808005://查看工具操作记录响应
                        case CEnum.Message_Tag_ID.SERVERINFO_IP_ALL_QUERY:// 0x800006:
                        case CEnum.Message_Tag_ID.SERVERINFO_IP_ALL_QUERY_RESP:// 0x808006:
                        case CEnum.Message_Tag_ID.LINK_SERVERIP_CREATE:// 0x800007:
                        case CEnum.Message_Tag_ID.LINK_SERVERIP_CREATE_RESP:// 0x808007:
                        case CEnum.Message_Tag_ID.CLIENT_PATCH_COMPARE:// 0x800008:
                        case CEnum.Message_Tag_ID.CLIENT_PATCH_COMPARE_RESP:// 0x808008:
                        case CEnum.Message_Tag_ID.CLIENT_PATCH_UPDATE:// 0x800009:
                        case CEnum.Message_Tag_ID.CLIENT_PATCH_UPDATE_RESP:// 0x808009:

                        /// <summary>
                        /// 用户管理模块(0x81)
                        /// </summary>
                        case CEnum.Message_Tag_ID.USER_CREATE:// 0x810001://创建GM帐号请求
                        case CEnum.Message_Tag_ID.USER_CREATE_RESP:// 0x818001://创建GM帐号响应
                        case CEnum.Message_Tag_ID.USER_UPDATE:// 0x810002://更新GM帐号信息请求
                        case CEnum.Message_Tag_ID.USER_UPDATE_RESP:// 0x818002://更新GM帐号信息响应
                        case CEnum.Message_Tag_ID.USER_DELETE:// 0x810003://删除GM帐号信息请求
                        case CEnum.Message_Tag_ID.USER_DELETE_RESP:// 0x818003://删除GM帐号信息响应
                        case CEnum.Message_Tag_ID.USER_QUERY:// 0x810004://查询GM帐号信息请求
                        case CEnum.Message_Tag_ID.USER_QUERY_RESP:// 0x818004://查询GM帐号信息响应
                        case CEnum.Message_Tag_ID.USER_PASSWD_MODIF:// 0x810005://密码修改请求
                        case CEnum.Message_Tag_ID.USER_PASSWD_MODIF_RESP:// 0x818005: //密码修改信息响应
                        case CEnum.Message_Tag_ID.USER_QUERY_ALL:// 0x810006://查询所有GM帐号信息
                        case CEnum.Message_Tag_ID.USER_QUERY_ALL_RESP:// 0x818006://查询所有GM帐号信息响应
                        case CEnum.Message_Tag_ID.DEPART_QUERY:// 0x810007: //查询部门列表
                        case CEnum.Message_Tag_ID.DEPART_QUERY_RESP:// 0x818007://查询部门列表响应
                        case CEnum.Message_Tag_ID.UPDATE_ACTIVEUSER:// 0x810008://更新在线用户状态
                        case CEnum.Message_Tag_ID.UPDATE_ACTIVEUSER_RESP:// 0x818008://更新在线用户状态响应

                        /// <summary>
                        /// 模块管理(0x82)
                        /// </summary>
                        case CEnum.Message_Tag_ID.MODULE_CREATE:// 0x820001://创建模块信息请求
                        case CEnum.Message_Tag_ID.MDDULE_CREATE_RESP:// 0x828001://创建模块信息响应
                        case CEnum.Message_Tag_ID.MODULE_UPDATE://0x820002://更新模块信息请求
                        case CEnum.Message_Tag_ID.MODULE_UPDATE_RESP:// 0x828002://更新模块信息响应
                        case CEnum.Message_Tag_ID.MODULE_DELETE:// 0x820003://删除模块请求
                        case CEnum.Message_Tag_ID.MODULE_DELETE_RESP:// 0x828003://删除模块响应
                        case CEnum.Message_Tag_ID.MODULE_QUERY:// 0x820004://查询模块信息的请求
                        case CEnum.Message_Tag_ID.MODULE_QUERY_RESP:// 0x828004://查询模块信息的响应

                        /// <summary>
                        /// 用户与模块管理(0x83)
                        /// </summary>
                        case CEnum.Message_Tag_ID.USER_MODULE_CREATE:// 0x830001://创建用户与模块请求
                        case CEnum.Message_Tag_ID.USER_MODULE_CREATE_RESP:// 0x838001://创建用户与模块响应
                        case CEnum.Message_Tag_ID.USER_MODULE_UPDATE:// 0x830002://更新用户与模块的请求
                        case CEnum.Message_Tag_ID.USER_MODULE_UPDATE_RESP:// 0x838002://更新用户与模块的响应
                        case CEnum.Message_Tag_ID.USER_MODULE_DELETE:// 0x830003://删除用户与模块请求
                        case CEnum.Message_Tag_ID.USER_MODULE_DELETE_RESP:// 0x838003://删除用户与模块响应
                        case CEnum.Message_Tag_ID.USER_MODULE_QUERY:// 0x830004://查询用户所对应模块请求
                        case CEnum.Message_Tag_ID.USER_MODULE_QUERY_RESP:// 0x838004://查询用户所对应模块响应

                        /// <summary>
                        /// 游戏管理(0x84)
                        /// </summary>
                        case CEnum.Message_Tag_ID.GAME_CREATE:// 0x840001://创建GM帐号请求
                        case CEnum.Message_Tag_ID.GAME_CREATE_RESP:// 0x848001://创建GM帐号响应
                        case CEnum.Message_Tag_ID.GAME_UPDATE:// 0x840002://更新GM帐号信息请求
                        case CEnum.Message_Tag_ID.GAME_UPDATE_RESP:// 0x848002://更新GM帐号信息响应
                        case CEnum.Message_Tag_ID.GAME_DELETE:// 0x840003://删除GM帐号信息请求
                        case CEnum.Message_Tag_ID.GAME_DELETE_RESP:// 0x848003://删除GM帐号信息响应
                        case CEnum.Message_Tag_ID.GAME_QUERY:// 0x840004://查询GM帐号信息请求
                        case CEnum.Message_Tag_ID.GAME_QUERY_RESP:// 0x848004://查询GM帐号信息响应
                        case CEnum.Message_Tag_ID.GAME_MODULE_QUERY:// 0x840005://查询游戏的模块列表
                        case CEnum.Message_Tag_ID.GAME_MODULE_QUERY_RESP:// 0x848005://查询游戏的模块列表响应


                        /// <summary>
                        /// NOTES管理(0x85)
                        /// </summary>
                        case CEnum.Message_Tag_ID.NOTES_LETTER_TRANSFER:// 0x850001: //取得邮件列表
                        case CEnum.Message_Tag_ID.NOTES_LETTER_TRANSFER_RESP:// 0x858001://取得邮件列表的响应
                        case CEnum.Message_Tag_ID.NOTES_LETTER_PROCESS:// 0x850002: //邮件处理
                        case CEnum.Message_Tag_ID.NOTES_LETTER_PROCESS_RESP:// 0x858002://邮件处理
                        case CEnum.Message_Tag_ID.NOTES_LETTER_TRANSMIT:// 0x850003: //邮件转发列表
                        case CEnum.Message_Tag_ID.NOTES_LETTER_TRANSMIT_RESP:// 0x858003://邮件转发列表

                        /// <summary>
                        /// 猛将GM工具(0x86)
                        /// </summary>
                        case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_QUERY:// 0x860001://检查玩家状态
                        case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_QUERY_RESP:// 0x868001://检查玩家状态响应
                        case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_UPDATE:// 0x860002://修改玩家状态
                        case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_UPDATE_RESP:// 0x868002://修改玩家状态响应
                        case CEnum.Message_Tag_ID.MJ_LOGINTABLE_QUERY:// 0x860003://检查玩家是否在线
                        case CEnum.Message_Tag_ID.MJ_LOGINTABLE_QUERY_RESP:// 0x868003://检查玩家是否在线响应
                        case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_EXPLOIT_UPDATE:// 0x860004://修改功勋值
                        case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_EXPLOIT_UPDATE_RESP:// 0x868004://修改功勋值响应
                        case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_FRIEND_QUERY:// 0x860005://列出好友名单
                        case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_FRIEND_QUERY_RESP:// 0x868005://列出好有名单响应
                        case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_FRIEND_CREATE:// 0x860006://添加好友
                        case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_FRIEND_CREATE_RESP:// 0x868006://添加好友响应
                        case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_FRIEND_DELETE:// 0x860007://删除好友
                        case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_FRIEND_DELETE_RESP:// 0x868007://删除好友响应
                        case CEnum.Message_Tag_ID.MJ_GUILDTABLE_UPDATE:// 0x860008://修改服务器所有已存在帮会
                        case CEnum.Message_Tag_ID.MJ_GUILDTABLE_UPDATE_RESP:// 0x868008://修改服务器所有已存在帮会响应
                        case CEnum.Message_Tag_ID.MJ_ACCOUNT_LOCAL_CREATE:// 0x860009://将服务器上的account表里的玩家信息保存到本地服务器的
                        case CEnum.Message_Tag_ID.MJ_ACCOUNT_LOCAL_CREATE_RESP:// 0x868009://将服务器上的account表里的玩家信息保存到本地服务器的响应
                        case CEnum.Message_Tag_ID.MJ_ACCOUNT_REMOTE_DELETE:// 0x860010://永久封停帐号
                        case CEnum.Message_Tag_ID.MJ_ACCOUNT_REMOTE_DELETE_RESP:// 0x868010://永久封停帐号的响应
                        case CEnum.Message_Tag_ID.MJ_ACCOUNT_REMOTE_RESTORE:// 0x860011://解封帐号
                        case CEnum.Message_Tag_ID.MJ_ACCOUNT_REMOTE_RESTORE_RESP:// 0x868011://解封帐号响应
                        case CEnum.Message_Tag_ID.MJ_ACCOUNT_LIMIT_RESTORE:// 0x860012://有时限的封停
                        case CEnum.Message_Tag_ID.MJ_ACCOUNT_LIMIT_RESTORE_RESP:// 0x868012://有时限的封停响应
                        case CEnum.Message_Tag_ID.MJ_ACCOUNTPASSWD_LOCAL_CREATE:// 0x860013://保存玩家密码到本地 
                        case CEnum.Message_Tag_ID.MJ_ACCOUNTPASSWD_LOCAL_CREATE_RESP:// 0x868013://保存玩家密码到本地
                        case CEnum.Message_Tag_ID.MJ_ACCOUNTPASSWD_REMOTE_UPDATE:// 0x860014://修改玩家密码 
                        case CEnum.Message_Tag_ID.MJ_ACCOUNTPASSWD_REMOTE_UPDATE_RESP:// 0x868014://修改玩家密码
                        case CEnum.Message_Tag_ID.MJ_ACCOUNTPASSWD_REMOTE_RESTORE:// 0x860015://恢复玩家密码
                        case CEnum.Message_Tag_ID.MJ_ACCOUNTPASSWD_REMOTE_RESTORE_RESP:// 0x868015://恢复玩家密码
                        case CEnum.Message_Tag_ID.MJ_ITEMLOG_QUERY:// 0x860016://检查该用户交易记录
                        case CEnum.Message_Tag_ID.MJ_ITEMLOG_QUERY_RESP:// 0x868016://检查该用户交易记录
                        case CEnum.Message_Tag_ID.MJ_GMTOOLS_LOG_QUERY:// 0x860017://检查使用者操作记录
                        case CEnum.Message_Tag_ID.MJ_GMTOOLS_LOG_QUERY_RESP:// 0x868017://检查使用者操作记录
                        case CEnum.Message_Tag_ID.MJ_MONEYSORT_QUERY:// 0x860018://根据金钱排序
                        case CEnum.Message_Tag_ID.MJ_MONEYSORT_QUERY_RESP:// 0x868018://根据金钱排序的响应
                        case CEnum.Message_Tag_ID.MJ_LEVELSORT_QUERY:// 0x860019://根据等级排序
                        case CEnum.Message_Tag_ID.MJ_LEVELSORT_QUERY_RESP:// 0x868019://根据等级排序的响应
                        case CEnum.Message_Tag_ID.MJ_MONEYFIGHTERSORT_QUERY:// 0x860020://根据不同职业金钱排序
                        case CEnum.Message_Tag_ID.MJ_MONEYFIGHTERSORT_QUERY_RESP:// 0x868020://根据不同职业金钱排序的响应
                        case CEnum.Message_Tag_ID.MJ_LEVELFIGHTERSORT_QUERY:// 0x860021://根据不同职业等级排序
                        case CEnum.Message_Tag_ID.MJ_LEVELFIGHTERSORT_QUERY_RESP:// 0x868021://根据不同职业等级排序的响应
                        case CEnum.Message_Tag_ID.MJ_MONEYTAOISTSORT_QUERY:// 0x860022://根据道士金钱排序
                        case CEnum.Message_Tag_ID.MJ_MONEYTAOISTSORT_QUERY_RESP:// 0x868022://根据道士金钱排序的响应
                        case CEnum.Message_Tag_ID.MJ_LEVELTAOISTSORT_QUERY:// 0x860023://根据道士等级排序
                        case CEnum.Message_Tag_ID.MJ_LEVELTAOISTSORT_QUERY_RESP:// 0x868023://根据道士等级排序的响应
                        case CEnum.Message_Tag_ID.MJ_MONEYRABBISORT_QUERY:// 0x860024://根据法师金钱排序
                        case CEnum.Message_Tag_ID.MJ_MONEYRABBISORT_QUERY_RESP:// 0x868024://根据法师金钱排序的响应
                        case CEnum.Message_Tag_ID.MJ_LEVELRABBISORT_QUERY:// 0x860025://根据法师等级排序
                        case CEnum.Message_Tag_ID.MJ_LEVELRABBISORT_QUERY_RESP:// 0x868025://根据法师等级排序的响应
                        case CEnum.Message_Tag_ID.MJ_ACCOUNT_QUERY://  0x860026://猛将帐号查询
                        case CEnum.Message_Tag_ID.MJ_ACCOUNT_QUERY_RESP:// 0x868026://猛将帐号查询响应
                        case CEnum.Message_Tag_ID.MJ_ACCOUNT_LOCAL_QUERY:// 0x860027://查询猛将本地帐号
                        case CEnum.Message_Tag_ID.MJ_ACCOUNT_LOCAL_QUERY_RESP:// 0x868027://查询猛将本地帐号响应
                        case CEnum.Message_Tag_ID.SDO_ACCOUNT_QUERY:// 0x870026://查看玩家的帐号信息
                        case CEnum.Message_Tag_ID.SDO_ACCOUNT_QUERY_RESP:// 0x878026://查看玩家的帐号信息响应
                        case CEnum.Message_Tag_ID.SDO_CHARACTERINFO_QUERY:// 0x870027://查看任务资料的信息
                        case CEnum.Message_Tag_ID.SDO_CHARACTERINFO_QUERY_RESP:// 0x878027://查看人物资料的信息响应
                        case CEnum.Message_Tag_ID.SDO_ACCOUNT_CLOSE:// 0x870028://封停帐户的权限信息
                        case CEnum.Message_Tag_ID.SDO_ACCOUNT_CLOSE_RESP:// 0x878028://封停帐户的权限信息响应
                        case CEnum.Message_Tag_ID.SDO_ACCOUNT_OPEN:// 0x870029://解封帐户的权限信息
                        case CEnum.Message_Tag_ID.SDO_ACCOUNT_OPEN_RESP:// 0x878029://解封帐户的权限信息响应
                        case CEnum.Message_Tag_ID.SDO_PASSWORD_RECOVERY:// 0x870030://玩家找回密码
                        case CEnum.Message_Tag_ID.SDO_PASSWORD_RECOVERY_RESP:// 0x878030://玩家找回密码响应
                        case CEnum.Message_Tag_ID.SDO_CONSUME_QUERY:// 0x870031://查看玩家的消费记录
                        case CEnum.Message_Tag_ID.SDO_CONSUME_QUERY_RESP:// 0x878031://查看玩家的消费记录响应
                        case CEnum.Message_Tag_ID.SDO_USERONLINE_QUERY:// 0x870032://查看玩家上下线状态
                        case CEnum.Message_Tag_ID.SDO_USERONLINE_QUERY_RESP:// 0x878032://查看玩家上下线状态响应
                        case CEnum.Message_Tag_ID.SDO_USERTRADE_QUERY:// 0x870033://查看玩家交易状态
                        case CEnum.Message_Tag_ID.SDO_USERTRADE_QUERY_RESP:// 0x878033://查看玩家交易状态响应
                        case CEnum.Message_Tag_ID.SDO_CHARACTERINFO_UPDATE:// 0x870034://修改玩家的账号信息
                        case CEnum.Message_Tag_ID.SDO_CHARACTERINFO_UPDATE_RESP:// 0x878034://修改玩家的账号信息响应
                        case CEnum.Message_Tag_ID.SDO_ITEMSHOP_QUERY:// 0x870035://查看游戏里面所有道具信息
                        case CEnum.Message_Tag_ID.SDO_ITEMSHOP_QUERY_RESP:// 0x878035://查看游戏里面所有道具信息响应
                        case CEnum.Message_Tag_ID.SDO_ITEMSHOP_DELETE:// 0x870036://删除玩家道具信息
                        case CEnum.Message_Tag_ID.SDO_ITEMSHOP_DELETE_RESP:// 0x878036://删除玩家道具信息响应
                        case CEnum.Message_Tag_ID.SDO_GIFTBOX_CREATE:// 0x870037://添加玩家礼物盒道具信息
                        case CEnum.Message_Tag_ID.SDO_GIFTBOX_CREATE_RESP:// 0x878037://添加玩家礼物盒道具信息响应
                        case CEnum.Message_Tag_ID.SDO_GIFTBOX_QUERY:// 0x870038://查看玩家礼物盒的道具
                        case CEnum.Message_Tag_ID.SDO_GIFTBOX_QUERY_RESP:// 0x878038://查看玩家礼物盒的道具响应
                        case CEnum.Message_Tag_ID.SDO_GIFTBOX_DELETE:// 0x870039://删除玩家礼物盒的道具
                        case CEnum.Message_Tag_ID.SDO_GIFTBOX_DELETE_RESP:// 0x878039://删除玩家礼物盒的道具响应
                        case CEnum.Message_Tag_ID.SDO_USERLOGIN_STATUS_QUERY:// 0x870040://查看玩家登录状态
                        case CEnum.Message_Tag_ID.SDO_USERLOGIN_STATUS_QUERY_RESP:// 0x878040://查看玩家登录状态响应
                        case CEnum.Message_Tag_ID.SDO_ITEMSHOP_BYOWNER_QUERY:// 0x870041:////查看玩家身上道具信息
                        case CEnum.Message_Tag_ID.SDO_ITEMSHOP_BYOWNER_QUERY_RESP:// 0x878041:////查看玩家身上道具信息
                        case CEnum.Message_Tag_ID.SDO_ITEMSHOP_TRADE_QUERY:// 0x870042://查看玩家交易记录信息
                        case CEnum.Message_Tag_ID.SDO_ITEMSHOP_TRADE_QUERY_RESP:// 0x878042://查看玩家交易记录信息的响应
                        case CEnum.Message_Tag_ID.SDO_MEMBERSTOPSTATUS_QUERY:// 0x870043://查看该帐号状态
                        case CEnum.Message_Tag_ID.SDO_MEMBERSTOPSTATUS_QUERY_RESP:// 0x878043:///查看该帐号状态的响应
                        case CEnum.Message_Tag_ID.SDO_MEMBERBANISHMENT_QUERY:// 0x870044://查看所有停封的帐号
                        case CEnum.Message_Tag_ID.SDO_MEMBERBANISHMENT_QUERY_RESP:// 0x878044://查看所有停封的帐号响应
                        case CEnum.Message_Tag_ID.SDO_USERMCASH_QUERY:// 0x870045://玩家充值记录查询
                        case CEnum.Message_Tag_ID.SDO_USERMCASH_QUERY_RESP:// 0x878045://玩家充值记录查询响应
                        case CEnum.Message_Tag_ID.SDO_USERGCASH_UPDATE:// 0x870046://补偿玩家G币
                        case CEnum.Message_Tag_ID.SDO_USERGCASH_UPDATE_RESP:// 0x878046://补偿玩家G币的响应
                        case CEnum.Message_Tag_ID.SDO_MEMBERLOCAL_BANISHMENT:// = 0x870047://本地保存停封信息
                        case CEnum.Message_Tag_ID.SDO_MEMBERLOCAL_BANISHMENT_RESP:// 0x878047://本地保存停封信息响应
                        case CEnum.Message_Tag_ID.SDO_EMAIL_QUERY:// 0x870048://得到玩家的EMAIL
                        case CEnum.Message_Tag_ID.SDO_EMAIL_QUERY_RESP:// 0x878048://得到玩家的EMAIL响应
                        case CEnum.Message_Tag_ID.SDO_USERCHARAGESUM_QUERY:// 0x870049://得到充值记录总和
                        case CEnum.Message_Tag_ID.SDO_USERCHARAGESUM_QUERY_RESP:// 0x878049://得到充值记录总和响应
                        case CEnum.Message_Tag_ID.SDO_USERCONSUMESUM_QUERY:// 0x870050://得到消费记录总和
                        case CEnum.Message_Tag_ID.SDO_USERCONSUMESUM_QUERY_RESP:// 0x878050://得到消费记录总和响应
                        case CEnum.Message_Tag_ID.SDO_USERGCASH_QUERY:// = 0x870051,//玩家?币记录查询
                        case CEnum.Message_Tag_ID.SDO_USERGCASH_QUERY_RESP:// = 0x878051,//玩家?币记录查询响应
                        case CEnum.Message_Tag_ID.SDO_USERNICK_UPDATE:// =0x870069, 
                        case CEnum.Message_Tag_ID.SDO_USERNICK_UPDATE_RESP:// =0x878069, 
                        case CEnum.Message_Tag_ID.SDO_BOARDMESSAGE_REQ:// = 0x870071,
                        case CEnum.Message_Tag_ID.SDO_BOARDMESSAGE_REQ_RESP:// = 0x878071,
                        case CEnum.Message_Tag_ID.SDO_CHANNELLIST_QUERY:// =  0x870072,
		                case CEnum.Message_Tag_ID.SDO_CHANNELLIST_QUERY_RESP:// = 0x878072,
		                case CEnum.Message_Tag_ID.SDO_ALIVE_REQ:// = 0x870073,
                        case CEnum.Message_Tag_ID.SDO_ALIVE_REQ_RESP:// = 0x878073,
                        case CEnum.Message_Tag_ID.SDO_BOARDTASK_INSERT:
                        case CEnum.Message_Tag_ID.SDO_BOARDTASK_INSERT_RESP:
                        case CEnum.Message_Tag_ID.SDO_DAYSLIMIT_QUERY:
                        case CEnum.Message_Tag_ID.SDO_DAYSLIMIT_QUERY_RESP:

                        case CEnum.Message_Tag_ID.SDO_FRIENDS_QUERY:
                        case CEnum.Message_Tag_ID.SDO_FRIENDS_QUERY_RESP: 
                        case CEnum.Message_Tag_ID.SDO_USERLOGIN_DEL:
                        case CEnum.Message_Tag_ID.SDO_USERLOGIN_DEL_RESP :
                        case CEnum.Message_Tag_ID.SDO_USERLOGIN_CLEAR :
                        case CEnum.Message_Tag_ID.SDO_USERLOGIN_CLEAR_RESP:
                        case CEnum.Message_Tag_ID.SDO_GATEWAY_QUERY:
                        case CEnum.Message_Tag_ID.SDO_GATEWAY_QUERY_RESP:
                        case CEnum.Message_Tag_ID.CR_ACCOUNT_QUERY:
                        case CEnum.Message_Tag_ID.CR_ACCOUNT_QUERY_RESP:
                        case CEnum.Message_Tag_ID.CR_ACCOUNTACTIVE_QUERY:
                        case CEnum.Message_Tag_ID.CR_ACCOUNTACTIVE_QUERY_RESP:
                        case CEnum.Message_Tag_ID.CR_CALLBOARD_QUERY:// = 0x890003,//公告信息查询
                        case CEnum.Message_Tag_ID.CR_CALLBOARD_QUERY_RESP:// = 0x898003,//公告信息查询响应
                        case CEnum.Message_Tag_ID.CR_CALLBOARD_CREATE:// = 0x890003,//发布公告
                        case CEnum.Message_Tag_ID.CR_CALLBOARD_CREATE_RESP:// = 0x898003,//发布公告响应
                        case CEnum.Message_Tag_ID.CR_CALLBOARD_UPDATE:// = 0x890004,//更新公告信息
                        case CEnum.Message_Tag_ID.CR_CALLBOARD_UPDATE_RESP:// = 0x898004,//更新公告信息的响应
                        case CEnum.Message_Tag_ID.CR_CALLBOARD_DELETE:// = 0x890005,//删除公告信息
                        case CEnum.Message_Tag_ID.CR_CALLBOARD_DELETE_RESP:// = 0x898005,//删除公告信息的响应
                        case CEnum.Message_Tag_ID.CR_CHARACTERINFO_QUERY:// = 0x890007,//玩家角色信息查询
                        case CEnum.Message_Tag_ID.CR_CHARACTERINFO_QUERY_RESP:// = 0x898007,//玩家角色信息查询的响应
                        case CEnum.Message_Tag_ID.CR_CHARACTERINFO_UPDATE:// = 0x890008,//玩家角色信息查询
                        case CEnum.Message_Tag_ID.CR_CHARACTERINFO_UPDATE_RESP:// = 0x898008,//玩家角色信息查询的响应
                        case CEnum.Message_Tag_ID.CR_CHANNEL_QUERY:// = 0x890009,//公告频道查询
                        case CEnum.Message_Tag_ID.CR_CHANNEL_QUERY_RESP:// = 0x898009,//公告频道查询的响应
                        case CEnum.Message_Tag_ID.CR_NICKNAME_QUERY:// = 0x890009,//公告频道查询
                        case CEnum.Message_Tag_ID.CR_NICKNAME_QUERY_RESP:// = 0x898009,//公告频道查询的响应
                        case CEnum.Message_Tag_ID.CR_LOGIN_LOGOUT_QUERY:// = 0x890009,//公告频道查询
                        case CEnum.Message_Tag_ID.CR_LOGIN_LOGOUT_QUERY_RESP:// = 0x898009,//公告频道查询的响应
                        case CEnum.Message_Tag_ID.CR_ERRORCHANNEL_QUERY ://补充错误公告频道查询
                        case CEnum.Message_Tag_ID.CR_ERRORCHANNEL_QUERY_RESP ://补充错误公告频道查询的响应

                        case CEnum.Message_Tag_ID.AU_ACCOUNT_QUERY://=0x880001,//玩家帐号信息查询
                        case CEnum.Message_Tag_ID.AU_ACCOUNT_QUERY_RESP://=0x888001,//玩家帐号信息查询响应
                        case CEnum.Message_Tag_ID.AU_ACCOUNTREMOTE_QUERY://=0x880002,//游戏服务器封停的玩家帐号查询
                        case CEnum.Message_Tag_ID.AU_ACCOUNTREMOTE_QUERY_RESP://=0x888002,//游戏服务器封停的玩家帐号查询响应
                        case CEnum.Message_Tag_ID.AU_ACCOUNTLOCAL_QUERY://=0x880003,//本地封停的玩家帐号查询
                        case CEnum.Message_Tag_ID.AU_ACCOUNTLOCAL_QUERY_RESP://=0x888003,//本地封停的玩家帐号查询响应
                        case CEnum.Message_Tag_ID.AU_ACCOUNT_CLOSE://=0x880004,//封停的玩家帐号
                        case CEnum.Message_Tag_ID.AU_ACCOUNT_CLOSE_RESP://=0x888004,//封停的玩家帐号响应
                        case CEnum.Message_Tag_ID.AU_ACCOUNT_OPEN://=0x880005,//解封的玩家帐号
                        case CEnum.Message_Tag_ID.AU_ACCOUNT_OPEN_RESP://=0x888005,//解封的玩家帐号响应
                        case CEnum.Message_Tag_ID.AU_ACCOUNT_BANISHMENT_QUERY://=0x880006,//玩家封停帐号查询
                        case CEnum.Message_Tag_ID.AU_ACCOUNT_BANISHMENT_QUERY_RESP://=0x888006,//玩家封停帐号查询响应
                        case CEnum.Message_Tag_ID.AU_CHARACTERINFO_QUERY://=0x880007,//查询玩家的账号信息
                        case CEnum.Message_Tag_ID.AU_CHARACTERINFO_QUERY_RESP://=0x888007,//查询玩家的账号信息响应
                        case CEnum.Message_Tag_ID.AU_CHARACTERINFO_UPDATE://=0x880008,//修改玩家的账号信息
                        case CEnum.Message_Tag_ID.AU_CHARACTERINFO_UPDATE_RESP://=0x888008,//修改玩家的账号信息响应
                        case CEnum.Message_Tag_ID.AU_ITEMSHOP_QUERY://=0x880009,//查看游戏里面所有道具信息
                        case CEnum.Message_Tag_ID.AU_ITEMSHOP_QUERY_RESP://=0x888009,//查看游戏里面所有道具信息响应
                        case CEnum.Message_Tag_ID.AU_ITEMSHOP_DELETE://=0x880010,//删除玩家道具信息
                        case CEnum.Message_Tag_ID.AU_ITEMSHOP_DELETE_RESP://=0x888010,//删除玩家道具信息响应
                        case CEnum.Message_Tag_ID.AU_ITEMSHOP_BYOWNER_QUERY://=0x880011,////查看玩家身上道具信息
                        case CEnum.Message_Tag_ID.AU_ITEMSHOP_BYOWNER_QUERY_RESP://=0x888011,////查看玩家身上道具信息
                        case CEnum.Message_Tag_ID.AU_ITEMSHOP_TRADE_QUERY://=0x880012,//查看玩家交易记录信息
                        case CEnum.Message_Tag_ID.AU_ITEMSHOP_TRADE_QUERY_RESP://=0x888012,//查看玩家交易记录信息的响应
                        case CEnum.Message_Tag_ID.AU_ITEMSHOP_CREATE://=0x880013,//添加玩家礼物盒道具信息
                        case CEnum.Message_Tag_ID.AU_ITEMSHOP_CREATE_RESP://=0x888013,//添加玩家礼物盒道具信息响应
                        case CEnum.Message_Tag_ID.AU_LEVELEXP_QUERY://=0x880014,//查看玩家等级经验
                        case CEnum.Message_Tag_ID.AU_LEVELEXP_QUERY_RESP://=0x888014,////查看玩家等级经验响应
                        case CEnum.Message_Tag_ID.AU_USERLOGIN_STATUS_QUERY://=0x880015,//查看玩家登录状态
                        case CEnum.Message_Tag_ID.AU_USERLOGIN_STATUS_QUERY_RESP://=0x888015,//查看玩家登录状态响应
                        case CEnum.Message_Tag_ID.AU_USERCHARAGESUM_QUERY://=0x880016,//得到充值记录总和
                        case CEnum.Message_Tag_ID.AU_USERCHARAGESUM_QUERY_RESP://=0x888016,//得到充值记录总和响应
                        case CEnum.Message_Tag_ID.AU_CONSUME_QUERY://=0x880017,//查看玩家的消费记录
                        case CEnum.Message_Tag_ID.AU_CONSUME_QUERY_RESP://=0x888017,//查看玩家的消费记录响应
                        case CEnum.Message_Tag_ID.AU_USERCONSUMESUM_QUERY://=0x880018,//得到消费记录总和
                        case CEnum.Message_Tag_ID.AU_USERCONSUMESUM_QUERY_RESP://=0x888018,//得到消费记录总和响应
                        case CEnum.Message_Tag_ID.AU_USERMCASH_QUERY://=0x880019,//玩家充值记录查询
                        case CEnum.Message_Tag_ID.AU_USERMCASH_QUERY_RESP://=0x888019,//玩家充值记录查询响应
                        case CEnum.Message_Tag_ID.AU_USERGCASH_QUERY://=0x880020,//玩家?币记录查询
                        case CEnum.Message_Tag_ID.AU_USERGCASH_QUERY_RESP://=0x888020,//玩家?币记录查询响应
                        case CEnum.Message_Tag_ID.AU_USERGCASH_UPDATE://=0x880021,//补偿玩家G币
                        case CEnum.Message_Tag_ID.AU_USERGCASH_UPDATE_RESP://=0x888021,//补偿玩家G币的响应

                    case CEnum.Message_Tag_ID.Au_User_Msg_Query: //查询玩家在游戏中的聊天记录 
                    case CEnum.Message_Tag_ID.Au_User_Msg_Query_Resp://查询玩家在游戏中的聊天记录    

                    case CEnum.Message_Tag_ID.Au_BroaditeminfoNow_Query ://当前时间用户发送喇叭日志
                    case CEnum.Message_Tag_ID.Au_BroaditeminfoNow_Query_Resp://当前时间用户发送喇叭日志

                    case CEnum.Message_Tag_ID.Au_BroaditeminfoBymsg_Query://内容模糊查询用户发送喇叭日志
                    case CEnum.Message_Tag_ID.Au_BroaditeminfoBymsg_Query_Resp://内容模糊查询用户发送喇叭日志

                    case CEnum.Message_Tag_ID.AU_MsgServerinfo_Query :
                    case CEnum.Message_Tag_ID.AU_MsgServerinfo_Query_RESP :
                    case CEnum.Message_Tag_ID.MAGIC_Account_Query: //角色基本资料
                    case CEnum.Message_Tag_ID.MAGIC_Account_Query_Resp:
                        case CEnum.Message_Tag_ID.CARD_USERCHARGEDETAIL_QUERY:// 0x900001,// 卡通查询
                        case CEnum.Message_Tag_ID.CARD_USERCHARGEDETAIL_QUERY_RESP:// 0x908001,// 卡通查询响应
                        case CEnum.Message_Tag_ID.CARD_USERCONSUME_QUERY:// = 0x900003,//休闲币消费查询
                        case CEnum.Message_Tag_ID.CARD_USERCONSUME_QUERY_RESP:// = 0x908003,//休闲币消费查询响应
                        case CEnum.Message_Tag_ID.CARD_VNETCHARGE_QUERY:// 0x900005,//互联星空充值查询
                        case CEnum.Message_Tag_ID.CARD_VNETCHARGE_QUERY_RESP:// 0x908005,//互联星空充值查询响应
                        case CEnum.Message_Tag_ID.CARD_USERDETAIL_SUM_QUERY:// = 0x900005,//充值合计查询
                        case CEnum.Message_Tag_ID.CARD_USERDETAIL_SUM_QUERY_RESP:// = 0x908005,//充值合计查询响应
                        case CEnum.Message_Tag_ID.CARD_USERCONSUME_SUM_QUERY:// = 0x900006,//消费合计查询
                        case CEnum.Message_Tag_ID.CARD_USERCONSUME_SUM_QUERY_RESP:// = 0x908006,//消费合计响应
                        case CEnum.Message_Tag_ID.CARD_USERINFO_QUERY:// = 0x900007,//玩家注册信息查询
                        case CEnum.Message_Tag_ID.CARD_USERINFO_QUERY_RESP:// = 0x908007,//玩家注册信息查询响应
                        case CEnum.Message_Tag_ID.CARD_USERINFO_CLEAR:// = 0x900008,
                        case CEnum.Message_Tag_ID.CARD_USERINFO_CLEAR_RESP:// = 0x908008,
                        case CEnum.Message_Tag_ID.CARD_USERNICK_QUERY:// = 0x0010,
                        case CEnum.Message_Tag_ID.CARD_USERNICK_QUERY_RESP:// = 0x8010,
                    case CEnum.Message_Tag_ID.CARD_USERINITACTIVE_QUERY://激活游戏
                    case CEnum.Message_Tag_ID.CARD_USERINITACTIVE_QUERY_RESP:
                        case CEnum.Message_Tag_ID.AU_USERNICK_UPDATE:// = 0x900011,
                        case CEnum.Message_Tag_ID.AU_USERNICK_UPDATE_RESP:// = 0x908011,


                        case CEnum.Message_Tag_ID.AUSHOP_USERGPURCHASE_QUERY:// = 0x910001,//用户G币购买记录
                        case CEnum.Message_Tag_ID.AUSHOP_USERGPURCHASE_QUERY_RESP:// = 0x918001,//用户G币购买记录
                        case CEnum.Message_Tag_ID.AUSHOP_USERMPURCHASE_QUERY:// = 0x910002,//用户M币购买记录
                        case CEnum.Message_Tag_ID.AUSHOP_USERMPURCHASE_QUERY_RESP:// = 0x918002,//用户M币购买记录
                        case CEnum.Message_Tag_ID.AUSHOP_AVATARECOVER_QUERY:// = 0x910003,//道具回收兑换记
                        case CEnum.Message_Tag_ID.AUSHOP_AVATARECOVER_QUERY_RESP:// = 0x918003,//道具回收兑换记
                        case CEnum.Message_Tag_ID.AUSHOP_USERINTERGRAL_QUERY:// = 0x910004,//用户积分记录
                        case CEnum.Message_Tag_ID.AUSHOP_USERINTERGRAL_QUERY_RESP:// = 0x918004,//用户积分记录

                        case CEnum.Message_Tag_ID.AUSHOP_USERGPURCHASE_SUM_QUERY:// = 0x0005,//用户G币购买记录合计
                        case CEnum.Message_Tag_ID.AUSHOP_USERGPURCHASE_SUM_QUERY_RESP:// = 0x8005,//用户G币购买记录合计响应
                        case CEnum.Message_Tag_ID.AUSHOP_USERMPURCHASE_SUM_QUERY:// = 0x0006,//用户M币购买记录合计
                        case CEnum.Message_Tag_ID.AUSHOP_USERMPURCHASE_SUM_QUERY_RESP:// = 0x8006,//用户M币购买记录合计响应
                        case CEnum.Message_Tag_ID.AUSHOP_AVATARECOVER_DETAIL_QUERY:// = 0x910007,// 具回收兑换详细记录
                        case CEnum.Message_Tag_ID.AUSHOP_AVATARECOVER_DETAIL_QUERY_RESP:// = 0x918007,// 具回收兑换详细记录

                        case CEnum.Message_Tag_ID.DEPARTMENT_CREATE:// = 0x810009,//部门创建
                        case CEnum.Message_Tag_ID.DEPARTMENT_CREATE_RESP:// = 0x818009,//部门创建响应
                        case CEnum.Message_Tag_ID.DEPARTMENT_UPDATE:// = 0x810010,//部门修改
                        case CEnum.Message_Tag_ID.DEPARTMENT_UPDATE_RESP:// = 0x818010,//部门修改响应
                        case CEnum.Message_Tag_ID.DEPARTMENT_DELETE:// = 0x810011,//部门删除
                        case CEnum.Message_Tag_ID.DEPARTMENT_DELETE_RESP:// = 0x818011,//部门删除响应
                        case CEnum.Message_Tag_ID.DEPARTMENT_ADMIN:// = 0x810012,//部门管理
                        case CEnum.Message_Tag_ID.DEPARTMENT_ADMIN_RESP:// = 0x818012,//部门管理响应
                        case CEnum.Message_Tag_ID.DEPARTMENT_RELATE_QUERY:// = 0x810013,//部门关联查询
                        case CEnum.Message_Tag_ID.DEPARTMENT_RELATE_QUERY_RESP:// = 0x818013,//部门关联查询

                        case CEnum.Message_Tag_ID.O2JAM_CHARACTERINFO_QUERY://= 0x920001,//玩家角色信息查询
                        case CEnum.Message_Tag_ID.O2JAM_CHARACTERINFO_QUERY_RESP://= 0x928001,//玩家角色信息查询
                        case CEnum.Message_Tag_ID.O2JAM_CHARACTERINFO_UPDATE://= 0x920002,//玩家角色信息更新
                        case CEnum.Message_Tag_ID.O2JAM_CHARACTERINFO_UPDATE_RESP://= 0x928002,//玩家角色信息更新
                        case CEnum.Message_Tag_ID.O2JAM_ITEM_QUERY://= 0x920001,//玩家道具信息查询
                        case CEnum.Message_Tag_ID.O2JAM_ITEM_QUERY_RESP://= 0x928001,//玩家角色信息查询
                        case CEnum.Message_Tag_ID.O2JAM_ITEM_UPDATE://= 0x920002,//玩家道具信息更新
                        case CEnum.Message_Tag_ID.O2JAM_ITEM_UPDATE_RESP://= 0x928002,//玩家道具信息更新
                        case CEnum.Message_Tag_ID.O2JAM_CONSUME_QUERY://= 0x920001,//玩家消费信息查询
                        case CEnum.Message_Tag_ID.O2JAM_CONSUME_QUERY_RESP://= 0x928001,//玩家消费信息查询
                        case CEnum.Message_Tag_ID.O2JAM_ITEMDATA_QUERY://= 0x920001,//玩家交易信息查询
                        case CEnum.Message_Tag_ID.O2JAM_ITEMDATA_QUERY_RESP://= 0x928001,//玩家交易信息查询
                        case CEnum.Message_Tag_ID.O2JAM_GIFTBOX_QUERY:// = 0x920007://,//玩家礼物盒查询
		                case CEnum.Message_Tag_ID.O2JAM_GIFTBOX_QUERY_RESP:// = 0x928007,//玩家礼物盒查询
		                case CEnum.Message_Tag_ID.O2JAM_USERGCASH_UPDATE:// = 0x920008,//补偿玩家G币
		                case CEnum.Message_Tag_ID.O2JAM_USERGCASH_UPDATE_RESP:// = 0x928008,//补偿玩家G币的响应
		                case CEnum.Message_Tag_ID.O2JAM_CONSUME_SUM_QUERY://= 0x920009,//玩家消费信息查询
		                case CEnum.Message_Tag_ID.O2JAM_CONSUME_SUM_QUERY_RESP://= 0x928009,//玩家消费信息查询
                        case CEnum.Message_Tag_ID.O2JAM_GIFTBOX_CREATE_QUERY://= 0x920010,//玩家交易信息查询
                        case CEnum.Message_Tag_ID.O2JAM_GIFTBOX_CREATE_QUERY_RESP://= 0x928010,//玩家交易信息查询
                        case CEnum.Message_Tag_ID.O2JAM_ITEMNAME_QUERY:// = 0x920011,
                        case CEnum.Message_Tag_ID.O2JAM_ITEMNAME_QUERY_RESP:// = 0x928011,
                        case CEnum.Message_Tag_ID.O2JAM_GIFTBOX_DELETE:// = 0x920012,
                        case CEnum.Message_Tag_ID.O2JAM_GIFTBOX_DELETE_RESP://  =0x928012,



                        case CEnum.Message_Tag_ID.DEPART_RELATE_GAME_QUERY:// = 0x810014,
                        case CEnum.Message_Tag_ID.DEPART_RELATE_GAME_QUERY_RESP:// = 0x818014,
                        case CEnum.Message_Tag_ID.USER_SYSADMIN_QUERY:// = 0x810015,
                        case CEnum.Message_Tag_ID.USER_SYSADMIN_QUERY_RESP:// = 0x818015,

                        case CEnum.Message_Tag_ID.CARD_USERSECURE_CLEAR:// = 0x900009,//重置玩家安全码信息
                        case CEnum.Message_Tag_ID.CARD_USERSECURE_CLEAR_RESP:// = 0x908009,//重置玩家安全码信息响应


                        case CEnum.Message_Tag_ID.O2JAM2_ACCOUNT_QUERY:// = 0x930001,//玩家帐号信息查询
                        case CEnum.Message_Tag_ID.O2JAM2_ACCOUNT_QUERY_RESP:// = 0x938001,//玩家帐号信息查询响应
                        case CEnum.Message_Tag_ID.O2JAM2_ACCOUNTACTIVE_QUERY:// = 0x930002,//玩家帐号激活信息
                        case CEnum.Message_Tag_ID.O2JAM2_ACCOUNTACTIVE_QUERY_RESP:// = 0x938002,//玩家帐号激活响应


                        case CEnum.Message_Tag_ID.O2JAM2_CHARACTERINFO_QUERY://= 0x930003,//用户信息查询
                        case CEnum.Message_Tag_ID.O2JAM2_CHARACTERINFO_QUERY_RESP://= 0x938003,
                        case CEnum.Message_Tag_ID.O2JAM2_CHARACTERINFO_UPDATE://= 0x930004,//用户信息修改
                        case CEnum.Message_Tag_ID.O2JAM2_CHARACTERINFO_UPDATE_RESP://= 0x938004,
                        case CEnum.Message_Tag_ID.O2JAM2_ITEMSHOP_QUERY://= 0x930005,
                        case CEnum.Message_Tag_ID.O2JAM2_ITEMSHOP_QUERY_RESP://= 0x938005,
                        case CEnum.Message_Tag_ID.O2JAM2_ITEMSHOP_DELETE://= 0x930006,
                        case CEnum.Message_Tag_ID.O2JAM2_ITEMSHOP_DELETE_RESP://= 0x938006,
                        case CEnum.Message_Tag_ID.O2JAM2_MESSAGE_QUERY://= 0x930007,
                        case CEnum.Message_Tag_ID.O2JAM2_MESSAGE_QUERY_RESP://= 0x938007,
                        case CEnum.Message_Tag_ID.O2JAM2_MESSAGE_CREATE://= 0x930008,
                        case CEnum.Message_Tag_ID.O2JAM2_MESSAGE_CREATE_RESP://= 0x938008,
                        case CEnum.Message_Tag_ID.O2JAM2_MESSAGE_DELETE://= 0x930009,
                        case CEnum.Message_Tag_ID.O2JAM2_MESSAGE_DELETE_RESP://= 0x938009,
                        case CEnum.Message_Tag_ID.O2JAM2_CONSUME_QUERY://= 0x930010,
                        case CEnum.Message_Tag_ID.O2JAM2_CONUMSE_QUERY_RESP://= 0x938010,
                        case CEnum.Message_Tag_ID.O2JAM2_CONSUME_SUM_QUERY://= 0x930011,
                        case CEnum.Message_Tag_ID.O2JAM2_CONUMSE_QUERY_SUM_RESP://= 0x938011,
                        case CEnum.Message_Tag_ID.O2JAM2_TRADE_QUERY://= 0x930012,
                        case CEnum.Message_Tag_ID.O2JAM2_TRADE_QUERY_RESP://= 0x938012,
                        case CEnum.Message_Tag_ID.O2JAM2_TRADE_SUM_QUERY://= 0x930013,
                        case CEnum.Message_Tag_ID.O2JAM2_TRADE_QUERY_SUM_RESP://= 0x938013,
                        case CEnum.Message_Tag_ID.O2JAM2_AVATORLIST_QUERY:// = 0x930014,
                        case CEnum.Message_Tag_ID.O2JAM2_AVATORLIST_QUERY_RESP:// = 0x938014,


                        case CEnum.Message_Tag_ID.SDO_CHALLENGE_QUERY:// = 0x870052,
                        case CEnum.Message_Tag_ID.SDO_CHALLENGE_QUERY_RESP:// = 0x878052,
                        case CEnum.Message_Tag_ID.SDO_CHALLENGE_INSERT:// = 0x870053,
                        case CEnum.Message_Tag_ID.SDO_CHALLENGE_INSERT_RESP:// = 0x878053,
                        case CEnum.Message_Tag_ID.SDO_CHALLENGE_UPDATE:// = 0x870054,
                        case CEnum.Message_Tag_ID.SDO_CHALLENGE_UPDATE_RESP:// = 0x878054,
                        case CEnum.Message_Tag_ID.SDO_CHALLENGE_DELETE:// = 0x870055,
                        case CEnum.Message_Tag_ID.SDO_CHALLENGE_DELETE_RESP:// = 0x878055,
                        case CEnum.Message_Tag_ID.SDO_MUSICDATA_QUERY:// = 0x870056,
                        case CEnum.Message_Tag_ID.SDO_MUSICDATA_QUERY_RESP:// = 0x878056,

                        case CEnum.Message_Tag_ID.SDO_MUSICDATA_OWN_QUERY:// = 0x870057,
                        case CEnum.Message_Tag_ID.SDO_MUSICDATA_OWN_QUERY_RESP:// = 0x878057,

                        case CEnum.Message_Tag_ID.SDO_CHALLENGE_SCENE_QUERY:// = 0x870058,
		                case CEnum.Message_Tag_ID.SDO_CHALLENGE_SCENE_QUERY_RESP://  = 0x878058,
		                case CEnum.Message_Tag_ID.SDO_CHALLENGE_SCENE_CREATE://  = 0x870059,
		                case CEnum.Message_Tag_ID.SDO_CHALLENGE_SCENE_CREATE_RESP://  = 0x878059,
		                case CEnum.Message_Tag_ID.SDO_CHALLENGE_SCENE_UPDATE://  = 0x870060,
		                case CEnum.Message_Tag_ID.SDO_CHALLENGE_SCENE_UPDATE_RESP://  = 0x878060,
		                case CEnum.Message_Tag_ID.SDO_CHALLENGE_SCENE_DELETE://  = 0x870061,
                        case CEnum.Message_Tag_ID.SDO_CHALLENGE_SCENE_DELETE_RESP://  = 0x878061,
                        case CEnum.Message_Tag_ID.SDO_StageAward_Query:
                        case CEnum.Message_Tag_ID.SDO_StageAward_Query_RESP:
                        case CEnum.Message_Tag_ID.SDO_StageAward_Create:	
                        case CEnum.Message_Tag_ID.SDO_StageAward_Create_RESP:
                        case CEnum.Message_Tag_ID.SDO_StageAward_Delete:
                        case CEnum.Message_Tag_ID.SDO_StageAward_Delete_RESP:
                        case CEnum.Message_Tag_ID.SDO_StageAward_Update:
                        case CEnum.Message_Tag_ID.SDO_StageAward_Update_RESP:

                        case CEnum.Message_Tag_ID.SDO_MEDALITEM_CREATE:// = 0x870062://,
                        case CEnum.Message_Tag_ID.SDO_MEDALITEM_CREATE_RESP:// = 0x878062://,
                        case CEnum.Message_Tag_ID.SDO_MEDALITEM_UPDATE:// = 0x870063://,
                        case CEnum.Message_Tag_ID.SDO_MEDALITEM_UPDATE_RESP:// = 0x878063://,
                        case CEnum.Message_Tag_ID.SDO_MEDALITEM_DELETE:// = 0x870064://,
                        case CEnum.Message_Tag_ID.SDO_MEDALITEM_DELETE_RESP:// = 0x878064://,
                        case CEnum.Message_Tag_ID.SDO_MEDALITEM_QUERY:// = 0x870065,
                        case CEnum.Message_Tag_ID.SDO_MEDALITEM_QUERY_RESP:// = 0x878065,

                        case CEnum.Message_Tag_ID.SDO_MEDALITEM_OWNER_QUERY:// = 0x870066,
                        case CEnum.Message_Tag_ID.SDO_MEDALITEM_OWNER_QUERY_RESP:// = 0x878066,

                        case CEnum.Message_Tag_ID.SDO_MEMBERDANCE_OPEN:// = 0x870067,
                        case CEnum.Message_Tag_ID.SDO_MEMBERDANCE_OPEN_RESP:// = 0x878067,
                        case CEnum.Message_Tag_ID.SDO_MEMBERDANCE_CLOSE:// = 0x870068,
                        case CEnum.Message_Tag_ID.SDO_MEMBERDANCE_CLOSE_RESP:// = 0x878068,

                        case CEnum.Message_Tag_ID.SDO_PADKEYWORD_QUERY:// = 0x870070,
                        case CEnum.Message_Tag_ID.SDO_PADKEYWORD_QUERY_RESP:// = 0x878070,
                        case CEnum.Message_Tag_ID.SDO_BOARDTASK_QUERY:
                        case CEnum.Message_Tag_ID.SDO_BOARDTASK_QUERY_RESP:
                        case CEnum.Message_Tag_ID.SDO_BOARDTASK_UPDATE:
                        case CEnum.Message_Tag_ID.SDO_BOARDTASK_UPDATE_RESP:
                        case CEnum.Message_Tag_ID.SDO_USERINTEGRAL_QUERY:
                        case CEnum.Message_Tag_ID.SDO_USERINTEGRAL_QUERY_RESP:
                        case CEnum.Message_Tag_ID.SDO_YYHAPPYITEM_QUERY:
                        case CEnum.Message_Tag_ID.SDO_YYHAPPYITEM_QUERY_RESP:
                        case CEnum.Message_Tag_ID.SDO_YYHAPPYITEM_CREATE :
                        case CEnum.Message_Tag_ID.SDO_YYHAPPYITEM_CREATE_RESP:
                        case CEnum.Message_Tag_ID.SDO_YYHAPPYITEM_UPDATE:
                        case CEnum.Message_Tag_ID.SDO_YYHAPPYITEM_UPDATE_RESP:
                        case CEnum.Message_Tag_ID.SDO_YYHAPPYITEM_DELETE:
                        case CEnum.Message_Tag_ID.SDO_YYHAPPYITEM_DELETE_RESP:
            		    case CEnum.Message_Tag_ID.SDO_PetInfo_Query:
                        case CEnum.Message_Tag_ID.SDO_PetInfo_Query_RESP:
                        case CEnum.Message_Tag_ID.SDO_BAOXIANGRate_Query:
                        case CEnum.Message_Tag_ID.SDO_BAOXIANGRate_Query_RESP:
                        case CEnum.Message_Tag_ID.SDO_BAOXIANGRate_Update:
                        case CEnum.Message_Tag_ID.SDO_BAOXIANGRate_Update_RESP:
                        case CEnum.Message_Tag_ID.O2JAM2_ACCOUNT_CLOSE:// = 0x930015,//封停帐户的权限信息
                        case CEnum.Message_Tag_ID.O2JAM2_ACCOUNT_CLOSE_RESP:// = 0x938015,//封停帐户的权限信息响应
                        case CEnum.Message_Tag_ID.O2JAM2_ACCOUNT_OPEN:// = 0x930016,//解封帐户的权限信息
                        case CEnum.Message_Tag_ID.O2JAM2_ACCOUNT_OPEN_RESP:// = 0x938016,//解封帐户的权限信息响应
                        case CEnum.Message_Tag_ID.O2JAM2_MEMBERBANISHMENT_QUERY:
                        case CEnum.Message_Tag_ID.O2JAM2_MEMBERBANISHMENT_QUERY_RESP:
                        case CEnum.Message_Tag_ID.O2JAM2_MEMBERSTOPSTATUS_QUERY:
                        case CEnum.Message_Tag_ID.O2JAM2_MEMBERSTOPSTATUS_QUERY_RESP:
                        case CEnum.Message_Tag_ID.O2JAM2_MEMBERLOCAL_BANISHMENT:
                        case CEnum.Message_Tag_ID.O2JAM2_MEMBERLOCAL_BANISHMENT_RESP:
                        case CEnum.Message_Tag_ID.O2JAM2_USERLOGIN_DELETE:
                        case CEnum.Message_Tag_ID.O2JAM2_USERLOGIN_DELETE_RESP:

                        case CEnum.Message_Tag_ID.SOCCER_CHARACTERINFO_QUERY:
                        case CEnum.Message_Tag_ID.SOCCER_CHARACTERINFO_QUERY_RESP:
                        case CEnum.Message_Tag_ID.SOCCER_CHARCHECK_QUERY:
                        case CEnum.Message_Tag_ID.SOCCER_CHARCHECK_QUERY_RESP:
                        case CEnum.Message_Tag_ID.SOCCER_CHARITEMS_RECOVERY_QUERY:
                        case CEnum.Message_Tag_ID.SOCCER_CCHARITEMS_RECOVERY_QUERY_RESP:
                        case CEnum.Message_Tag_ID.SOCCER_CHARPOINT_QUERY:
                        case CEnum.Message_Tag_ID.SOCCER_CHARPOINT_QUERY_RESP:
                        case CEnum.Message_Tag_ID.SOCCER_DELETEDCHARACTERINFO_QUERY:
                        case CEnum.Message_Tag_ID.SOCCER_DELETEDCHARACTERINFO_QUERY_RESP:
                        case CEnum.Message_Tag_ID.SOCCER_CHARACTERSTATE_MODIFY://停封角色
                        case CEnum.Message_Tag_ID.SOCCER_CHARACTERSTATE_MODIFY_RESP:
                        case CEnum.Message_Tag_ID.SOCCER_ACCOUNTSTATE_MODIFY ://停封玩家
                        case CEnum.Message_Tag_ID.SOCCER_ACCOUNTSTATE_MODIFY_RESP :
                        case CEnum.Message_Tag_ID.SOCCER_CHARACTERSTATE_QUERY ://停封角色查询
                        case CEnum.Message_Tag_ID.SOCCER_CHARACTERSTATE_QUERY_RESP :
                        case CEnum.Message_Tag_ID.SOCCER_ACCOUNTSTATE_QUERY ://停封玩家查询
                        case CEnum.Message_Tag_ID.SOCCER_ACCOUNTSTATE_QUERY_RESP: 
                        case CEnum.Message_Tag_ID.NOTDEFINED:// 0x0:

                        #region 敢达
                        /// <summary>
                        ///敢达
                        /// </summary>
                        case CEnum.Message_Tag_ID.SD_ActiveCode_Query:
                        case CEnum.Message_Tag_ID.SD_ActiveCode_Query_Resp:
                        case CEnum.Message_Tag_ID.SD_Account_Query://帐号查询
                        case CEnum.Message_Tag_ID.SD_Account_Query_Resp:
                        case CEnum.Message_Tag_ID.SD_UserIteminfo_Query://用户道具信息查询
                        case CEnum.Message_Tag_ID.SD_UserIteminfo_Query_Resp:

                        case CEnum.Message_Tag_ID.SD_UserLoginfo_Query://用户登陆信息查询
                        case CEnum.Message_Tag_ID.SD_UserLoginfo_Query_Resp:
                        case CEnum.Message_Tag_ID.SD_UserMailinfo_Query://用户邮件信息查询
                        case CEnum.Message_Tag_ID.SD_UserMailinfo_Query_Resp:
                        case CEnum.Message_Tag_ID.SD_UserGuildinfo_Query://用户公会信息查询
                        case CEnum.Message_Tag_ID.SD_UserGuildinfo_Query_Resp:
                        case CEnum.Message_Tag_ID.SD_UserStorageinfo_Query://用户仓库信息查询
                        case CEnum.Message_Tag_ID.SD_UserStorageinfo_Query_Resp:
                        case CEnum.Message_Tag_ID.SD_UserAdditem_Add://添加道具
                        case CEnum.Message_Tag_ID.SD_UserAdditem_Add_Resp:
                        case CEnum.Message_Tag_ID.SD_UserAdditem_Del://删除道具
                        case CEnum.Message_Tag_ID.SD_UserAdditem_Del_Resp:
                        case CEnum.Message_Tag_ID.SD_BanUser_Query://查询封停用户
                        case CEnum.Message_Tag_ID.SD_BanUser_Query_Resp:
                        case CEnum.Message_Tag_ID.SD_BanUser_Ban://封停用户
                        case CEnum.Message_Tag_ID.SD_BanUser_Ban_Resp:
                        case CEnum.Message_Tag_ID.SD_BanUser_UnBan://解封用户
                        case CEnum.Message_Tag_ID.SD_BanUser_UnBan_Resp:
                        case CEnum.Message_Tag_ID.SD_AccountDetail_Query://帐号详细信息查询
                        case CEnum.Message_Tag_ID.SD_AccountDetail_Query_Resp:
                        case CEnum.Message_Tag_ID.SD_Item_MixTree_Query: //玩家机体组合
                        case CEnum.Message_Tag_ID.SD_Item_MixTree_Query_Resp:
                        case CEnum.Message_Tag_ID.SD_Item_UserUnits_Query:	//玩家机体信息
                        case CEnum.Message_Tag_ID.SD_Item_UserUnits_Query_Resp:
                        case CEnum.Message_Tag_ID.SD_Item_UserCombatitems_Query:	//玩家战斗道具
                        case CEnum.Message_Tag_ID.SD_Item_UserCombatitems_Query_Resp:
                        case CEnum.Message_Tag_ID.SD_Item_Operator_Query://玩家副官道具
                        case CEnum.Message_Tag_ID.SD_Item_Operator_Query_Resp:
                        case CEnum.Message_Tag_ID.SD_Item_Paint_Query://玩家涂料道具
                        case CEnum.Message_Tag_ID.SD_Item_Paint_Query_Resp:
                        case CEnum.Message_Tag_ID.SD_Item_Skill_Query://玩家技能道具
                        case CEnum.Message_Tag_ID.SD_Item_Skill_Query_Resp://玩家技能道具
                        case CEnum.Message_Tag_ID.SD_Item_Sticker_Query://玩家标签道具
                        case CEnum.Message_Tag_ID.SD_Item_Sticker_Query_Resp://玩家标签道具
                        case CEnum.Message_Tag_ID.SD_UserGrift_Query://礼物信息查询
                        case CEnum.Message_Tag_ID.SD_UserGrift_Query_Resp://礼物信息查询
                        case CEnum.Message_Tag_ID.SD_KickUser_Query://踢用户下线
                        case CEnum.Message_Tag_ID.SD_KickUser_Query_Resp://踢用户下线
                        case CEnum.Message_Tag_ID.SD_SendNotes_Query://发送公告
                        case CEnum.Message_Tag_ID.SD_SendNotes_Query_Resp://发送公告
                        case CEnum.Message_Tag_ID.SD_SeacrhNotes_Query://公告信息查询
                        case CEnum.Message_Tag_ID.SD_SeacrhNotes_Query_Resp://公告信息查询
                        case CEnum.Message_Tag_ID.SD_ItemType_Query://获取道具类型
                        case CEnum.Message_Tag_ID.SD_ItemType_Query_Resp://获取道具类型
                        case CEnum.Message_Tag_ID.SD_ItemList_Query://获取道具列表
                        case CEnum.Message_Tag_ID.SD_ItemList_Query_Resp://获取道具列表
                        case CEnum.Message_Tag_ID.SD_TmpPassWord_Query://临时密码
                        case CEnum.Message_Tag_ID.SD_TmpPassWord_Query_Resp://临时密码
                        case CEnum.Message_Tag_ID.SD_ReTmpPassWord_Query://恢复临时密码
                        case CEnum.Message_Tag_ID.SD_ReTmpPassWord_Query_Resp://恢复临时密码
                        case CEnum.Message_Tag_ID.SD_SearchPassWord_Query://查询临时密码
                        case CEnum.Message_Tag_ID.SD_SearchPassWord_Query_Resp://查询临时密码
                        case CEnum.Message_Tag_ID.SD_UpdateExp_Query://修改等级
                        case CEnum.Message_Tag_ID.SD_UpdateExp_Query_Resp://修改等级
                        case CEnum.Message_Tag_ID.SD_Grift_FromUser_Query://发送人礼物信息查询
                        case CEnum.Message_Tag_ID.SD_Grift_FromUser_Query_Resp://发送人礼物信息查询
                        case CEnum.Message_Tag_ID.SD_Grift_ToUser_Query://发送人礼物信息查询
                        case CEnum.Message_Tag_ID.SD_Grift_ToUser_Query_Resp://发送人礼物信息查询
                        case CEnum.Message_Tag_ID.SD_TaskList_Update://修改公告
                        case CEnum.Message_Tag_ID.SD_TaskList_Update_Resp://修改公告
                        case CEnum.Message_Tag_ID.SD_Account_Active_Query://通过帐号查询激活信息
                        case CEnum.Message_Tag_ID.SD_Account_Active_Query_Resp://通过帐号查询激活信息

                        case CEnum.Message_Tag_ID.SD_BuyLog_Query://玩家购买道具
                        case CEnum.Message_Tag_ID.SD_BuyLog_Query_Resp://玩家购买道具
                        case CEnum.Message_Tag_ID.SD_Delete_ItemLog_Query://玩家删除道具记录
                        case CEnum.Message_Tag_ID.SD_Delete_ItemLog_Query_Resp://玩家删除道具记录
                        case CEnum.Message_Tag_ID.SD_LogInfo_Query://玩家日志记录
                        case CEnum.Message_Tag_ID.SD_LogInfo_Query_Resp://玩家日志记录
                        case CEnum.Message_Tag_ID.SD_Firend_Query://玩家好友查询
                        case CEnum.Message_Tag_ID.SD_Firend_Query_Resp://玩家好友查询
                        case CEnum.Message_Tag_ID.SD_UserRank_query://玩家排名查询
                        case CEnum.Message_Tag_ID.SD_UserRank_query_Resp://玩家排名查询
                        case CEnum.Message_Tag_ID.SD_UpdateUnitsExp_Query://修改玩家机体等级
                        case CEnum.Message_Tag_ID.SD_UpdateUnitsExp_Query_Resp://修改玩家机体等级
                        case CEnum.Message_Tag_ID.SD_UnitsItem_Query://查询机体道具
                        case CEnum.Message_Tag_ID.SD_UnitsItem_Query_Resp://查询机体道具
                        case CEnum.Message_Tag_ID.SD_GetGmAccount_Query://查询GM账号
                        case CEnum.Message_Tag_ID.SD_GetGmAccount_Query_Resp://查询GM账号
                        case CEnum.Message_Tag_ID.SD_UpdateGmAccount_Query://修改GM账号
                        case CEnum.Message_Tag_ID.SD_UpdateGmAccount_Query_Resp://修改GM账号
                        case CEnum.Message_Tag_ID.SD_UpdateMoney_Query://修改G币
                        case CEnum.Message_Tag_ID.SD_UpdateMoney_Query_Resp://修改G币
                        case CEnum.Message_Tag_ID.SD_Card_Info_Query://新手/钻石卡查询
                        case CEnum.Message_Tag_ID.SD_Card_Info_Query_Resp://新手/钻石卡查询
                        case CEnum.Message_Tag_ID.SD_UserAdditem_Add_All://批量添加道具
                        case CEnum.Message_Tag_ID.SD_UserAdditem_Add_All_Resp://批量添加道具
                        //case CEnum.Message_Tag_ID.SDO_Family_CONSUME_QUERY://家族消费查询
                        //case CEnum.Message_Tag_ID.SDO_Family_CONSUME_QUERY_RESP://家族消费查询
                        case CEnum.Message_Tag_ID.SD_ReGetUnits_Query://恢复机体
                        case CEnum.Message_Tag_ID.SD_ReGetUnits_Query_Resp://恢复机体
                        #endregion


                        #region 疯狂飙车
                        /// <summary>
                        ///疯狂飙车
                        /// </summary>
                        case CEnum.Message_Tag_ID.RC_Character_Query:
                        case CEnum.Message_Tag_ID.RC_Character_Query_Resp:
                        case CEnum.Message_Tag_ID.RC_UserLoginOut_Query:
                        case CEnum.Message_Tag_ID.RC_UserLoginOut_Query_Resp:
                        case CEnum.Message_Tag_ID.RC_UserLogin_Del:
                        case CEnum.Message_Tag_ID.RC_UserLogin_Del_Resp:
                        case CEnum.Message_Tag_ID.RC_RcCode_Query:
                        case CEnum.Message_Tag_ID.RC_RcCode_Query_Resp:
                        case CEnum.Message_Tag_ID.RC_RcUser_Query:
                        case CEnum.Message_Tag_ID.RC_RcUser_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_Character_Query:
                        case CEnum.Message_Tag_ID.RayCity_Character_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_CharacterState_Query:
                        case CEnum.Message_Tag_ID.RayCity_CharacterState_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_RaceState_Query:
                        case CEnum.Message_Tag_ID.RayCity_RaceState_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_InventoryList_Query:
                        case CEnum.Message_Tag_ID.RayCity_InventoryList_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_InventoryDetail_Query:
                        case CEnum.Message_Tag_ID.RayCity_InventoryDetail_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_CarList_Query:
                        case CEnum.Message_Tag_ID.RayCity_CarList_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_Guild_Query:
                        case CEnum.Message_Tag_ID.RayCity_Guild_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_QuestLog_Query:
                        case CEnum.Message_Tag_ID.RayCity_QuestLog_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_MissionLog_Query:
                        case CEnum.Message_Tag_ID.RayCity_MissionLog_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_DealLog_Query:
                        case CEnum.Message_Tag_ID.RayCity_DealLog_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_FriendList_Query:
                        case CEnum.Message_Tag_ID.RayCity_FriendList_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_BasicAccount_Query:
                        case CEnum.Message_Tag_ID.RayCity_BasicAccount_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_GuildMember_Query:
                        case CEnum.Message_Tag_ID.RayCity_GuildMember_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_BasicCharacter_Query:
                        case CEnum.Message_Tag_ID.RayCity_BasicCharacter_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_BuyCar_Query:
                        case CEnum.Message_Tag_ID.RayCity_BuyCar_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_ConnectionLog_Query:
                        case CEnum.Message_Tag_ID.RayCity_ConnectionLog_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_CarInventory_Query:
                        case CEnum.Message_Tag_ID.RayCity_CarInventory_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_ConnectionState_Query:
                        case CEnum.Message_Tag_ID.RayCity_ConnectionState_Resp:
                        case CEnum.Message_Tag_ID.RayCity_ItemShop_Insert:
                        case CEnum.Message_Tag_ID.RayCity_ItemShop_Insert_Resp:
                        case CEnum.Message_Tag_ID.RayCity_ItemShop_Query:
                        case CEnum.Message_Tag_ID.RayCity_ItemShop_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_MoneyLog_Query:
                        case CEnum.Message_Tag_ID.RayCity_MoneyLog_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_RaceLog_Query:
                        case CEnum.Message_Tag_ID.RayCity_RaceLog_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_AddMoney:
                        case CEnum.Message_Tag_ID.RayCity_AddMoney_Resp:
                        case CEnum.Message_Tag_ID.RayCity_Skill_Query:
                        case CEnum.Message_Tag_ID.RayCity_Skill_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_PlayerSkill_Query:
                        case CEnum.Message_Tag_ID.RayCity_PlayerSkill_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_PlayerSkill_Delete:
                        case CEnum.Message_Tag_ID.RayCity_PlayerSkill_Delete_Resp:
                        case CEnum.Message_Tag_ID.RayCity_PlayerSkill_Insert:
                        case CEnum.Message_Tag_ID.RayCity_PlayerSkill_Insert_Resp:
                        case CEnum.Message_Tag_ID.RayCity_ItemType_Query:
                        case CEnum.Message_Tag_ID.RayCity_ItemType_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_TradeInfo_Query:
                        case CEnum.Message_Tag_ID.RayCity_TradeInfo_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_TradeDetail_Query:
                        case CEnum.Message_Tag_ID.RayCity_TradeDetail_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_SetPos_Update:
                        case CEnum.Message_Tag_ID.RayCity_SetPos_Update_Resp:
                        case CEnum.Message_Tag_ID.RayCity_GMUser_Query:
                        case CEnum.Message_Tag_ID.RayCity_GMUser_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_GMUser_Update:
                        case CEnum.Message_Tag_ID.RayCity_GMUser_Update_Resp:
                        case CEnum.Message_Tag_ID.RayCity_PlayerAccount_Create:
                        case CEnum.Message_Tag_ID.RayCity_PlayerAccount_Create_Resp:
                        case CEnum.Message_Tag_ID.RayCity_WareHousePwd_Update:
                        case CEnum.Message_Tag_ID.RayCity_WareHousePwd_Update_Resp:
                        case CEnum.Message_Tag_ID.RayCity_BingoCard_Query:
                        case CEnum.Message_Tag_ID.RayCity_BingoCard_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_UserCharge_Query:
                        case CEnum.Message_Tag_ID.RayCity_UserCharge_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_ItemConsume_Query:
                        case CEnum.Message_Tag_ID.RayCity_ItemConsume_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_UserMails_Query:
                        case CEnum.Message_Tag_ID.RayCity_UserMails_Query_Resp:
                       case CEnum.Message_Tag_ID.RayCity_CashItemDetailLog_Query:
                        case CEnum.Message_Tag_ID.RayCity_CashItemDetailLog_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_Coupon_Query:
                        case CEnum.Message_Tag_ID.RayCity_Coupon_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_ActiveCard_Query:
                        case CEnum.Message_Tag_ID.RayCity_ActiveCard_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_BoardList_Query:
                        case CEnum.Message_Tag_ID.RayCity_BoardList_Query_Resp:
                        case CEnum.Message_Tag_ID.RayCity_BoardList_Insert:
                        case CEnum.Message_Tag_ID.RayCity_BoardList_Insert_Resp:
                        case CEnum.Message_Tag_ID.RayCity_BoardList_Delete:
                        case CEnum.Message_Tag_ID.RayCity_BoardList_Delete_Resp:
                      
                        #endregion

                        #region 光线飞车
                        /// <summary>
                        ///光线飞车
                        /// </summary>
                        
                        case CEnum.Message_Tag_ID.RC_Character_Update:
                        case CEnum.Message_Tag_ID.RC_Character_Update_Resp:
                        


                        #endregion


                        #region 劲舞团2

                        case CEnum.Message_Tag_ID.JW2_ACCOUNT_QUERY://玩家帐号信息查询（1.2.3.4.5.8）
                        case CEnum.Message_Tag_ID.JW2_ACCOUNT_QUERY_RESP://玩家帐号信息查询响应（1.2.3.4.5.8）
                        /////////////封停类/////////////////////////////////////////
                        case CEnum.Message_Tag_ID.JW2_ACCOUNTREMOTE_QUERY://游戏服务器封停的玩家帐号查询
                        case CEnum.Message_Tag_ID.JW2_ACCOUNTREMOTE_QUERY_RESP://游戏服务器封停的玩家帐号查询响应

                        case CEnum.Message_Tag_ID.JW2_ACCOUNTLOCAL_QUERY://本地封停的玩家帐号查询
                        case CEnum.Message_Tag_ID.JW2_ACCOUNTLOCAL_QUERY_RESP://本地封停的玩家帐号查询响应

                        case CEnum.Message_Tag_ID.JW2_ACCOUNT_CLOSE://封停的玩家帐号
                        case CEnum.Message_Tag_ID.JW2_ACCOUNT_CLOSE_RESP://封停的玩家帐号响应
                        case CEnum.Message_Tag_ID.JW2_ACCOUNT_OPEN://解封的玩家帐号
                        case CEnum.Message_Tag_ID.JW2_ACCOUNT_OPEN_RESP://解封的玩家帐号响应
                        case CEnum.Message_Tag_ID.JW2_ACCOUNT_BANISHMENT_QUERY://玩家封停帐号查询
                        case CEnum.Message_Tag_ID.JW2_ACCOUNT_BANISHMENT_QUERY_RESP://玩家封停帐号查询响应
                        ////////////////////////////
                        case CEnum.Message_Tag_ID.JW2_BANISHPLAYER://踢人
                        case CEnum.Message_Tag_ID.JW2_BANISHPLAYER_RESP://踢人响应
                        case CEnum.Message_Tag_ID.JW2_BOARDMESSAGE://公告
                        case CEnum.Message_Tag_ID.JW2_BOARDMESSAGE_RESP://公告响应

                        case CEnum.Message_Tag_ID.JW2_LOGINOUT_QUERY://玩家人物登入/登出信息
                        case CEnum.Message_Tag_ID.JW2_LOGINOUT_QUERY_RESP://玩家人物登入/登出信息响应
                        case CEnum.Message_Tag_ID.JW2_RPG_QUERY://查询故事情节（6）
                        case CEnum.Message_Tag_ID.JW2_RPG_QUERY_RESP://查询故事情节响应（6）

                        case CEnum.Message_Tag_ID.JW2_ITEMSHOP_BYOWNER_QUERY:////查看玩家身上道具信息（7－7）
                        case CEnum.Message_Tag_ID.JW2_ITEMSHOP_BYOWNER_QUERY_RESP:////查看玩家身上道具信息响应（7－7）


                        case CEnum.Message_Tag_ID.JW2_DUMMONEY_QUERY:////查询点数和虚拟币（7－8）
                        case CEnum.Message_Tag_ID.JW2_DUMMONEY_QUERY_RESP:////查询点数和虚拟币响应（7－8）
                        case CEnum.Message_Tag_ID.JW2_HOME_ITEM_QUERY:////查看房间物品清单与期限（7－9）
                        case CEnum.Message_Tag_ID.JW2_HOME_ITEM_QUERY_RESP:////查看房间物品清单与期限响应（7－9）
                        case CEnum.Message_Tag_ID.JW2_SMALL_PRESENT_QUERY:////查看购物，送礼（7－10）
                        case CEnum.Message_Tag_ID.JW2_SMALL_PRESENT_QUERY_RESP:////查看购物，送礼响应（7－10）
                        case CEnum.Message_Tag_ID.JW2_WASTE_ITEM_QUERY:////查看消耗性道具（7－11）
                        case CEnum.Message_Tag_ID.JW2_WASTE_ITEM_QUERY_RESP:////查看消耗性道具响应（7－11）
                        case CEnum.Message_Tag_ID.JW2_SMALL_BUGLE_QUERY:////查看小喇叭（7－12）
                        case CEnum.Message_Tag_ID.JW2_SMALL_BUGLE_QUERY_RESP:////查看小喇叭响应（7－12）

                        case CEnum.Message_Tag_ID.JW2_WEDDINGINFO_QUERY://婚姻信息
                        case CEnum.Message_Tag_ID.JW2_WEDDINGINFO_QUERY_RESP:
                        case CEnum.Message_Tag_ID.JW2_WEDDINGLOG_QUERY://婚姻历史
                        case CEnum.Message_Tag_ID.JW2_WEDDINGLOG_QUERY_RESP:
                        case CEnum.Message_Tag_ID.JW2_WEDDINGGROUND_QUERY://结婚信息
                        case CEnum.Message_Tag_ID.JW2_WEDDINGGROUND_QUERY_RESP:
                        case CEnum.Message_Tag_ID.JW2_COUPLEINFO_QUERY://情人信息
                        case CEnum.Message_Tag_ID.JW2_COUPLEINFO_QUERY_RESP:
                        case CEnum.Message_Tag_ID.JW2_COUPLELOG_QUERY://情人历史
                        case CEnum.Message_Tag_ID.JW2_COUPLELOG_QUERY_RESP:


                        case CEnum.Message_Tag_ID.JW2_FAMILYINFO_QUERY://家族信息
                        case CEnum.Message_Tag_ID.JW2_FAMILYINFO_QUERY_RESP:
                        case CEnum.Message_Tag_ID.JW2_FAMILYMEMBER_QUERY://家族成员信息
                        case CEnum.Message_Tag_ID.JW2_FAMILYMEMBER_QUERY_RESP:
                        case CEnum.Message_Tag_ID.JW2_SHOP_QUERY://商城信息
                        case CEnum.Message_Tag_ID.JW2_SHOP_QUERY_RESP:
                        case CEnum.Message_Tag_ID.JW2_User_Family_Query://用户家族信息
                        case CEnum.Message_Tag_ID.JW2_User_Family_Query_Resp:

                        case CEnum.Message_Tag_ID.JW2_FamilyItemInfo_Query://家族道具信息
                        case CEnum.Message_Tag_ID.JW2_FamilyItemInfo_Query_Resp:

                        case CEnum.Message_Tag_ID.JW2_FamilyBuyLog_Query://家族购买日志
                        case CEnum.Message_Tag_ID.JW2_FamilyBuyLog_Query_Resp:

                        case CEnum.Message_Tag_ID.JW2_FamilyTransfer_Query://家族转让信息
                        case CEnum.Message_Tag_ID.JW2_FamilyTransfer_Query_Resp:

                        case CEnum.Message_Tag_ID.JW2_FriendList_Query://好友列表
                        case CEnum.Message_Tag_ID.JW2_FriendList_Query_Resp:

                        case CEnum.Message_Tag_ID.JW2_BasicInfo_Query://基地信息查询
                        case CEnum.Message_Tag_ID.JW2_BasicInfo_Query_Resp:

                        case CEnum.Message_Tag_ID.JW2_FamilyMember_Applying://申请中成员
                        case CEnum.Message_Tag_ID.JW2_FamilyMember_Applying_Resp:

                        case CEnum.Message_Tag_ID.JW2_BasicRank_Query://基地等级
                        case CEnum.Message_Tag_ID.JW2_BasicBank_Query_Resp:


                        ///////////公告////////////////////////////
                        case CEnum.Message_Tag_ID.JW2_BOARDTASK_INSERT://公告添加
                        case CEnum.Message_Tag_ID.JW2_BOARDTASK_INSERT_RESP://公告添加响应
                        case CEnum.Message_Tag_ID.JW2_BOARDTASK_QUERY://公告查询
                        case CEnum.Message_Tag_ID.JW2_BOARDTASK_QUERY_RESP://公告查询响应
                        case CEnum.Message_Tag_ID.JW2_BOARDTASK_UPDATE://公告更新
                        case CEnum.Message_Tag_ID.JW2_BOARDTASK_UPDATE_RESP://公告更新响应

                        case CEnum.Message_Tag_ID.JW2_ITEM_DEL://道具删除（身上0，物品栏1，礼盒2）
                        case CEnum.Message_Tag_ID.JW2_ITEM_DEL_RESP://道具删除（身上0，物品栏1，礼盒2）

                        case CEnum.Message_Tag_ID.JW2_MODIFYSEX_QUERY://修改角色性别
                        case CEnum.Message_Tag_ID.JW2_MODIFYSEX_QUERY_RESP:

                        case CEnum.Message_Tag_ID.JW2_MODIFYLEVEL_QUERY://修改等级
                        case CEnum.Message_Tag_ID.JW2_MODIFYLEVEL_QUERY_RESP:

                        case CEnum.Message_Tag_ID.JW2_MODIFYEXP_QUERY://修改经验
                        case CEnum.Message_Tag_ID.JW2_MODIFYEXP_QUERY_RESP:

                        case CEnum.Message_Tag_ID.JW2_BAN_BIGBUGLE://禁用大喇叭
                        case CEnum.Message_Tag_ID.JW2_BAN_BIGBUGLE_RESP:

                        case CEnum.Message_Tag_ID.JW2_BAN_SMALLBUGLE://禁用小喇叭
                        case CEnum.Message_Tag_ID.JW2_BAN_SMALLBUGLE_RESP:

                        case CEnum.Message_Tag_ID.JW2_DEL_CHARACTER://删除角色
                        case CEnum.Message_Tag_ID.JW2_DEL_CHARACTER_RESP:

                        case CEnum.Message_Tag_ID.JW2_RECALL_CHARACTER://恢复角色
                        case CEnum.Message_Tag_ID.JW2_RECALL_CHARACTER_RESP:

                        case CEnum.Message_Tag_ID.JW2_MODIFY_MONEY://修改金钱
                        case CEnum.Message_Tag_ID.JW2_MODIFY_MONEY_RESP:

                        case CEnum.Message_Tag_ID.JW2_ADD_ITEM://增加道具
                        case CEnum.Message_Tag_ID.JW2_ADD_ITEM_RESP:

                        case CEnum.Message_Tag_ID.JW2_CREATE_GM://每个大区创建GM
                        case CEnum.Message_Tag_ID.JW2_CREATE_GM_RESP:

                        case CEnum.Message_Tag_ID.JW2_MODIFY_PWD://修改密码
                        case CEnum.Message_Tag_ID.JW2_MODIFY_PWD_RESP:

                        case CEnum.Message_Tag_ID.JW2_RECALL_PWD://恢复密码
                        case CEnum.Message_Tag_ID.JW2_RECALL_PWD_RESP:


                        case CEnum.Message_Tag_ID.JW2_ItemInfo_Query:
                        case CEnum.Message_Tag_ID.JW2_ItemInfo_Query_Resp://


                        case CEnum.Message_Tag_ID.JW2_ITEM_SELECT://道具模糊查询
                        case CEnum.Message_Tag_ID.JW2_ITEM_SELECT_RESP://

                        case CEnum.Message_Tag_ID.JW2_PetInfo_Query://宠物信息
                        case CEnum.Message_Tag_ID.JW2_PetInfo_Query_Resp:

                        case CEnum.Message_Tag_ID.JW2_Messenger_Query://称号查询
                        case CEnum.Message_Tag_ID.JW2_Messenger_Query_Resp:

                        case CEnum.Message_Tag_ID.JW2_Wedding_Paper://结婚证书
                        case CEnum.Message_Tag_ID.JW2_Wedding_Paper_Resp:

                        case CEnum.Message_Tag_ID.JW2_CoupleParty_Card://情侣派对卡
                        case CEnum.Message_Tag_ID.JW2_CoupleParty_Card_Resp:


                        case CEnum.Message_Tag_ID.JW2_MailInfo_Query://纸箱信息
                        case CEnum.Message_Tag_ID.JW2_MailInfo_Query_Resp:

                        case CEnum.Message_Tag_ID.JW2_MoneyLog_Query://金钱日志查询
                        case CEnum.Message_Tag_ID.JW2_MoneyLog_Query_Resp:

                        case CEnum.Message_Tag_ID.JW2_FamilyFund_Log://基金日志
                        case CEnum.Message_Tag_ID.JW2_FamilyFund_Log_Resp:

                        case CEnum.Message_Tag_ID.JW2_FamilyItem_Log://家族道具日志
                        case CEnum.Message_Tag_ID.JW2_FamilyItem_Log_Resp:

                        case CEnum.Message_Tag_ID.JW2_Item_Log://道具日志
                        case CEnum.Message_Tag_ID.JW2_Item_Log_Resp:


                        case CEnum.Message_Tag_ID.JW2_ADD_ITEM_ALL://增加道具(批量)
                        case CEnum.Message_Tag_ID.JW2_ADD_ITEM_ALL_RESP:

                        case CEnum.Message_Tag_ID.JW2_CashMoney_Log://消费日志
                        case CEnum.Message_Tag_ID.JW2_CashMoney_Log_Resp:


                        case CEnum.Message_Tag_ID.JW2_SearchPassWord_Query://查询临时密码
                        case CEnum.Message_Tag_ID.JW2_SearchPassWord_Query_Resp://查询临时密码

                        case CEnum.Message_Tag_ID.JW2_CenterAvAtarItem_Bag_Query://中间背包道具
                        case CEnum.Message_Tag_ID.JW2_CenterAvAtarItem_Bag_Query_Resp://中间背包道具

                        case CEnum.Message_Tag_ID.JW2_CenterAvAtarItem_Equip_Query://中间身上道具
                        case CEnum.Message_Tag_ID.JW2_CenterAvAtarItem_Equip_Query_Resp://中间身上道具

                        case CEnum.Message_Tag_ID.JW2_House_Query://小黑屋
                        case CEnum.Message_Tag_ID.JW2_House_Query_Resp://小黑屋

                        case CEnum.Message_Tag_ID.JW2_GM_Update://GM狀態修改
                        case CEnum.Message_Tag_ID.JW2_GM_Update_Resp://GM狀態修改
                        case CEnum.Message_Tag_ID.JW2_JB_Query://舉報信息查?
                        case CEnum.Message_Tag_ID.JW2_JB_Query_Resp://舉報信息查?

                        case CEnum.Message_Tag_ID.JW2_UpDateFamilyName_Query://修改家族名
                        case CEnum.Message_Tag_ID.JW2_UpDateFamilyName_Query_Resp://修改家族名

                        case CEnum.Message_Tag_ID.JW2_UpdatePetName_Query://修改?物名
                        case CEnum.Message_Tag_ID.JW2_UpdatePetName_Query_Resp://修改?物名

                        case CEnum.Message_Tag_ID.JW2_Act_Card_Query://活动卡查询
                        case CEnum.Message_Tag_ID.JW2_Act_Card_Query_Resp://活动卡查询

                        case CEnum.Message_Tag_ID.JW2_Center_Kick_Query://中間件踢人
                        case CEnum.Message_Tag_ID.JW2_Center_Kick_Query_Resp://中間件踢人


                        case CEnum.Message_Tag_ID.JW2_ChangeServerExp_Query://修改服務器??倍數
                        case CEnum.Message_Tag_ID.JW2_ChangeServerExp_Query_Resp://修改服務器??倍數

                        case CEnum.Message_Tag_ID.JW2_ChangeServerMoney_Query://修改服務器金钱倍數
                        case CEnum.Message_Tag_ID.JW2_ChangeServerMoney_Query_Resp://修改服務器金钱倍數

                        case CEnum.Message_Tag_ID.JW2_MissionInfoLog_Query://任务LOG查询
                        case CEnum.Message_Tag_ID.JW2_MissionInfoLog_Query_Resp://任务LOG查询

                        case CEnum.Message_Tag_ID.JW2_AgainBuy_Query://重复购买退款
                        case CEnum.Message_Tag_ID.JW2_AgainBuy_Query_Resp://重复购买退款

                        case CEnum.Message_Tag_ID.JW2_GSSvererList_Query://服务器列表GS
                        case CEnum.Message_Tag_ID.JW2_GSSvererList_Query_Resp://服务器列表GS

                        case CEnum.Message_Tag_ID.JW2_Materiallist_Query://用戶合成材料查询
                        case CEnum.Message_Tag_ID.JW2_Materiallist_Query_Resp://用戶合成材料查询

                        case CEnum.Message_Tag_ID.JW2_MaterialHistory_Query://用戶合成记录
                        case CEnum.Message_Tag_ID.JW2_MaterialHistory_Query_Resp://用戶合成记录

                        case CEnum.Message_Tag_ID.JW2_ACTIVEPOINT_QUERY://活跃度查询	
                        case CEnum.Message_Tag_ID.JW2_ACTIVEPOINT_QUERY_Resp://活跃度查询

                        case CEnum.Message_Tag_ID.JW2_GETPIC_Query://获得需要审核的图片列表
                        case CEnum.Message_Tag_ID.JW2_GETPIC_Query_Resp://获得需要审核的图片列表

                        case CEnum.Message_Tag_ID.JW2_CHKPIC_Query://审核图片 2审核通过，3审核不通过 
                        case CEnum.Message_Tag_ID.JW2_CHKPIC_Query_Resp://审核图片 2审核通过，3审核不通过

                        case CEnum.Message_Tag_ID.JW2_PicCard_Query://圖片上傳卡使用
                        case CEnum.Message_Tag_ID.JW2_PicCard_Query_Resp://圖片上傳卡使用

                        case CEnum.Message_Tag_ID.JW2_FamilyPet_Query://家族宠物查询
                        case CEnum.Message_Tag_ID.JW2_FamilyPet_Query_Resp://家族宠物查询


                        case CEnum.Message_Tag_ID.JW2_BuyPetAgg_Query://族长购买宠物蛋查询
                        case CEnum.Message_Tag_ID.JW2_BuyPetAgg_Query_Resp://族长购买宠物蛋查询

                        case CEnum.Message_Tag_ID.JW2_PetFirend_Query://家族宠物交友查询
                        case CEnum.Message_Tag_ID.JW2_PetFirend_Query_Resp://家族宠物交友查询

                        case CEnum.Message_Tag_ID.JW2_SmallPetAgg_Query://家族成员领取小宠物信息查询
                        case CEnum.Message_Tag_ID.JW2_SmallPetAgg_Query_Resp://家族成员领取小宠物信息查询
                        #endregion


                        case CEnum.Message_Tag_ID.ERROR:// 0xFFFFFF:

						#region 解析数据行和字段
						int iCount = 0;		//重复个数

						System.Collections.ArrayList t_StructCount = mPacketbody.m_TLVList;
						System.Collections.ArrayList t_StructUsed = (System.Collections.ArrayList)t_StructCount.Clone();

						for (int i=0; i<t_StructCount.Count; i++)
						{
							for (int j=i+1; j<t_StructCount.Count; j++)
							{
								if (((TLV_Structure)t_StructCount[i]).m_Tag != ((TLV_Structure)t_StructCount[j]).m_Tag)
								{
									iCount++;
									t_StructCount.RemoveAt(j);
									j--;
								}
							}
						}

						//无记录判断
						if (t_StructCount.Count == 0)
						{
                            p_ReturnBody = new CEnum.Message_Body[1, 1];
                            p_ReturnBody[0, 0].eName = CEnum.TagName.ERROR_Msg;
                            p_ReturnBody[0, 0].eTag = CEnum.TagFormat.TLV_STRING;
							p_ReturnBody[0,0].oContent = "无数据!";

							return p_ReturnBody;
						}
						iField = t_StructUsed.Count / t_StructCount.Count;
						#endregion

                        p_ReturnBody = new CEnum.Message_Body[t_StructUsed.Count - iCount, iField];

						#region 消息解析 -- 数组消息
						int iTemp = 0;
						for (int i=0; i<t_StructCount.Count; i++)
						{
							for (int j=i*iField; j<t_StructUsed.Count; j++)
							{								
								//设置字段标签
								if (iTemp == iField)
								{
									iTemp = 0;
									break;
								}
								
								TLV_Structure mStruct = (TLV_Structure)t_StructUsed[j];

								p_ReturnBody[i,iTemp].eName = mStruct.m_Tag;
								p_ReturnBody = DecodeRecive(i, iTemp, mStruct, p_ReturnBody);

								iTemp++;
							}
						}
						#endregion						
						
						break;
				}
				#endregion

				return p_ReturnBody;
			}
			catch (Exception e)
			{
                p_ReturnBody = new CEnum.Message_Body[1, 1];
                p_ReturnBody[0, 0].eName = CEnum.TagName.ERROR_Msg;
                p_ReturnBody[0, 0].eTag = CEnum.TagFormat.TLV_STRING;
				p_ReturnBody[0,0].oContent = "数据解析异常";

                CEnum.TLogData tLogData = new CEnum.TLogData();

				tLogData.iSort = 5;
				tLogData.strDescribe = "解析Socket消息失败!";
				tLogData.strException = e.Message;

				return p_ReturnBody;
			}
		}
		#endregion
	}
}
