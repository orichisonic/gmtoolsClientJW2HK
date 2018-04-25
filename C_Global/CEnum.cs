  using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace C_Global
{
    public class CEnum
    {
        #region Socket 消息定义
        /// <summary>
        /// 参数内容标签
        /// </summary>
        public enum TagName : ushort
        {
            ///////////////////////////////////////////////////////////////////////
            Magic_Dates = 0x5736,//日期
            UserName = 0x0101, //Format:STRING 用户名
            PassWord = 0x0102, //Format:STRING 密码
            MAC = 0x0103, //Format:STRING  MAC码
            Limit = 0x0104,//Format:DateTime GM帐号使用时效
            User_Status = 0x0105,//Format:INT 状态信息
            UserByID = 0x0106,//Format:INT 操作员ID
            RealName = 0x0107,//Format:STRING 中文名
            DepartID = 0x0108,//Format:INT 部门ID
            DepartName = 0x0109,//Format:STRING 部门名称
            DepartRemark = 0x0110,//Format:STRING 部门描述
            OnlineActive = 0x0111,//Format:Integer 在线状态
            UpdateFileName = 0x0112,//Format:String 文件名
            UpdateFileVersion = 0x0113,//Format:String 文件版本
            UpdateFilePath = 0x0114,//Format:String 文件路径
            UpdateFileSize = 0x0115,//Format:Integer 文件大小

            Process_Reason = 0x060B,//Format tring
            ///////////////////////////////////////////////////////////////////////
            GameID = 0x0200, //Format:INTEGER 消息ID
            ModuleName = 0x0201, //Format:STRING 模块名称
            ModuleClass = 0x0202, //Format:STRING 模块分类
            ModuleContent = 0x0203, //Format:STRING 模块描述
            ///////////////////////////////////////////////////////////////////////
            Module_ID = 0x0301, //Format:INTEGER 模块ID
            User_ID = 0x0302, //Format:INTEGER 用户ID
            ModuleList = 0x0303, //Format:String 模块列表
            SysAdmin = 0x0116,//Format:Integer 是否是系统管理员
            ///////////////////////////////////////////////////////////////////////
            Host_Addr = 0x0401, //Format:STRING
            Host_Port = 0x0402, //Format:STRING
            Host_Pat = 0x0403,  //Format:STRING
            Conn_Time = 0x0404, //Format:DateTime 请求和响应时间
            Connect_Msg = 0x0405,//Format:STRING 请求连接信息
            DisConnect_Msg = 0x0406,//Format:STRING	 请求端开信息
            Author_Msg = 0x0407, //Format:STRING 验证用户的信息
            Status = 0x0408,//Format:STRING 操作结果
            Index = 0x0409, //Format:Integer 记录集序号
            PageSize = 0x0410,//Format:Integer 记录页显示长度
            PageCount = 0x0411,//Format:Integer 显示总页数
            SP_Name = 0x0412,//Format:Integer 存储过程名
            Real_ACT = 0x0413,//Format:String 操作的内容
            ACT_Time = 0x0414,//Format:TimeStamp 操作时间
            BeginTime = 0x0415,//Format:Date 开始日期
            EndTime = 0x0416,//Format:Date 结束日期
            ///////////////////////////////////////////////////////////////////////
            GameName = 0x0501, //Format:STRING 游戏名称
            GameContent = 0x0502, //Format:STRING 消息描述
            ///////////////////////////////////////////////////////////////////////
            Letter_ID = 0x0601, //Format:Integer 
            Letter_Sender = 0x0602, //Format:String
            Letter_Receiver = 0x0603, //Format:String
            Letter_Subject = 0x0604, //Format:String
            Letter_Text = 0x0605, //Format:String
            Send_Date = 0x0606, //Format:Date
            Process_Man = 0x0607, //Format:Integer
            Process_Date = 0x0608, //Format:Date
            Transmit_Man = 0x0609, //Format:Integer
            Is_Process = 0x060A, //Format:Integer
            ///////////////////////////////////////////////////////////////////////
            MJ_Level = 0x0701, //Format:Integer 玩家等级
            MJ_Account = 0x0702, //Format:String 玩家帐号
            MJ_CharName = 0x0703, //Format:String 玩家呢称
            MJ_Exp = 0x0704, //Format:Integer 玩家当前经验
            MJ_Exp_Next_Level = 0x0705, //Format:Integer 玩家下次升级的经验 
            MJ_HP = 0x0706, //Format:Integer 玩家HP值
            MJ_HP_Max = 0x0707, //Format:Integer 玩家最大的HP值
            MJ_MP = 0x0708, //Format:Integer 玩家MP值
            MJ_MP_Max = 0x0709, //Format:Integer 玩家最大的MP值
            MJ_DP = 0x0710, //Format:Integer 玩家DP值
            MJ_DP_Increase_Ratio = 0x0711, //Format:Integer 玩家最大的DP值
            MJ_Exception_Dodge = 0x0712, //Format:Integer 异常状态回避
            MJ_Exception_Recovery = 0x0713, //Format:Integer 异常状态回复
            MJ_Physical_Ability_Max = 0x0714, //Format:Integer 物理能力最大值
            MJ_Physical_Ability_Min = 0x0715, //Format:Integer 物理能力最小值
            MJ_Magic_Ability_Max = 0x0716, //Format:Integer 魔法能力最大值
            MJ_Magic_Ability_Min = 0x0717, //Format:Integer 魔法能力最小值
            MJ_Tao_Ability_Max = 0x0718, //Format:Integer 道术能力最大值
            MJ_Tao_Ability_Min = 0x0719, //Format:Integer 道术能力最小值
            MJ_Physical_Defend_Max = 0x0720, //Format:Integer 物防最大值
            MJ_Physical_Defend_Min = 0x0721, //Format:Integer 物防最小值
            MJ_Magic_Defend_Max = 0x0722, //Format:Integer 魔防最大值
            MJ_Magic_Defend_Min = 0x0723, //Format:Integer 魔防最小值
            MJ_Accuracy = 0x0724, //Format:Integer 命中率
            MJ_Phisical_Dodge = 0x0725, //Format:Integer 物理回避率
            MJ_Magic_Dodge = 0x0726, //Format:Integer 魔法回避率
            MJ_Move_Speed = 0x0727, //Format:Integer 移动速度
            MJ_Attack_speed = 0x0728, //Format:Integer 攻击速度
            MJ_Max_Beibao = 0x0729, //Format:Integer 背包上限
            MJ_Max_Wanli = 0x0730, //Format:Integer 腕力上限
            MJ_Max_Fuzhong = 0x0731, //Format:Integer 负重上限
            MJ_PASSWD = 0x0732,//Format:String 玩家密码
            MJ_ServerIP = 0x0733,//Format:String 玩家所在服务器
            MJ_TongID = 0x0734,//Format:Integer 帮会ID
            MJ_TongName = 0x0735,//Format:String 帮会名称
            MJ_TongLevel = 0x0736,//Format:Integer 帮会等级
            MJ_TongMemberCount = 0x0737,//Format:Integer 帮会人数
            MJ_Money = 0x0738,//Format:Money 玩家金钱
            MJ_TypeID = 0x0739,//Format:Integer 玩家角色类型ID
            MJ_ActionType = 0x0740,//Format:Integer 玩家ID
            MJ_Time = 0x0741,//Format:TimeStamp  操作时间
            MJ_CharIndex = 0x0742,//玩家索引号
            MJ_CharName_Prefix = 0x0743,//玩家帮会名称
            MJ_Exploit_Value = 0x0744,//玩家功勋值
            MJ_Reason = 0x0745,//停封理由

            ///////////////////////////////////////////////////////////////////////
            SDO_ServerIP = 0x0801,//Format:String 大区IP
            SDO_UserIndexID = 0x0802,//Format:Integer 玩家用户ID
            SDO_Account = 0x0803,//Format:String 玩家的帐号
            SDO_Level = 0x0804,//Format:Integer 玩家的等级
            SDO_Exp = 0x0805,//Format:Integer 玩家的当前经验值
            SDO_GameTotal = 0x0806,//Format:Integer 总局数
            SDO_GameWin = 0x0807,//Format:Integer 胜局数
            SDO_DogFall = 0x0808,//Format:Integer 平局数
            SDO_GameFall = 0x0809,//Format:Integer 负局数
            SDO_Reputation = 0x0810,//Format:Integer 声望值
            SDO_GCash = 0x0811,//Format:Integer G币
            SDO_MCash = 0x0812,//Format:Integer M币
            SDO_Address = 0x0813,//Format:Integer 地址
            SDO_Age = 0x0814,//Format:Integer 年龄
            SDO_ProductID = 0x0815,//Format:Integer 商品编号
            SDO_ProductName = 0x0816,//Format:String 商品名称
            SDO_ItemCode = 0x0817,//Format:Integer 道具编号
            SDO_ItemName = 0x0818,//Format:String 道具名称
            SDO_TimesLimit = 0x0819,//Format:Integer 使用次数
            SDO_DateLimit = 0x0820,//Format:Integer 使用时效
            SDO_MoneyType = 0x0821,//Format:Integer 货币类型
            SDO_MoneyCost = 0x0822,//Format:Integer 道具的价格
            SDO_ShopTime = 0x0823,//Format:DateTime 消费时间
            SDO_MAINCH = 0x0824,//Format:Integer 服务器
            SDO_SUBCH = 0x0825,//Format:Integer 房间
            SDO_Online = 0x0826,//Format:Integer 是否在线
            SDO_LoginTime = 0x0827,//Format:DateTime 上线时间
            SDO_LogoutTime = 0x0828,//Format:DateTime 下线时间
            SDO_AREANAME = 0x0829,//Format:String 大区名字
            SDO_City = 0x0830,//Format:String 玩家所住城市
            SDO_Title = 0x0831,//Format:String 道具主题
            SDO_Context = 0x0832,//Format:String 道具描述
            SDO_MinLevel = 0x0833,//Format:Integer 所带道具的最小等级
            SDO_ActiveStatus = 0x0834,//Format:Integer 激活状态
            SDO_StopStatus = 0x0835,//Format:Integer 封停状态
            SDO_NickName = 0x0836,//Format:String 呢称
            SDO_9YouAccount = 0x0837,//Format:Integer 9you的帐号
            SDO_SEX = 0x0838,//Format:Integer 性别
            SDO_RegistDate = 0x0839,//Format:Date 注册日期
            SDO_FirstLogintime = 0x0840,//Format:Date 第一次登录时间
            SDO_LastLogintime = 0x0841,//Format:Date 最后一次登录时间
            SDO_Ispad = 0x0842,//Format:Integer 是否已注册跳舞毯
            SDO_Desc = 0x0843,//Format:String 道具描述
            SDO_Postion = 0x0844,//Format:Integer 道具位置
            SDO_BeginTime = 0x0845,//Format:Date 消费记录开始时间
            SDO_EndTime = 0x0846,//Format:Date 消费记录结束时间
            SDO_SendTime = 0x0847,//Format:Date 道具送人日期
            SDO_SendIndexID = 0x0848,//Format:Integer 发送人的ID
            SDO_SendUserID = 0x0849,//Format:String 发送人帐号
            SDO_ReceiveNick = 0x0850,//Format:String 接受人呢称
            SDO_BigType = 0x0851,//Format:Integer 道具大类
            SDO_SmallType = 0x0852,//Format:Integer 道具小类
            SDO_REASON = 0x0853,//Format:String 停封理由
            SDO_StopTime = 0x0854,//Format:TimeStamp 停封时间
            SDO_DaysLimit = 0x0855,//Format:Integer 使用天数
            SDO_Email = 0x0856,//Format:String 邮件
            SDO_ChargeSum = 0x0857,//Format:String 充值合计
            SDO_KeyID = 0x0885,
            SDO_KeyWord = 0x0886,
            SDO_MasterID = 0x0887,
            SDO_Master = 0x0888,
            SDO_SlaverID = 0x0889,
            SDO_Slaver = 0x0890,
            SDO_ChannelList = 0x0891,
            SDO_BoardMessage = 0x0892,

            SDO_wPlanetID = 0x0893,
            SDO_wChannelID = 0x0894,
            SDO_iLimitUser = 0x0895,
            SDO_iCurrentUser = 0x0896,
            SDO_ipaddr = 0x0897,
            SDO_Interval = 0x0898,
            SDO_TaskID = 0x0899,
            SDO_Status = 0x08100,
            SDO_Score = 0x08101,//积分
            SDO_FirstPadTime = 0x08102,
            SDO_MAIN_CH = 0x08104,// 服务器
            SDO_SUB_CH = 0x08105,// 房间
            SDO_BanDate = 0x08103,//停封多少天
            SDO_Lock_Status = 0x08196,

            SDO_LevPercent = 0x08106,
            SDO_ItemCodeBy = 0x08107,
            SDO_IsBattle = 0x8131,

            SDO_ItemCode1 = 0x8137,//TLV_STRING  道具ID
            SDO_DateLimit1 = 0x8138,//TLV_INTEGER 日期限制
            SDO_TimeLimit1 = 0x8139,//TLV_INTEGER 次数限制
            SDO_ItemCode2 = 0x8140,//TLV_STRING  道具ID
            SDO_DateLimit2 = 0x8141,//TLV_INTEGER 日期限制
            SDO_TimeLimit2 = 0x8142,//TLV_INTEGER 次数限制
            SDO_ItemCode3 = 0x8143,//TLV_STRING  道具ID
            SDO_DateLimit3 = 0x8144,//TLV_INTEGER 日期限制
            SDO_TimeLimit3 = 0x8145,//TLV_INTEGER 次数限制
            SDO_ItemCode4 = 0x8146,//TLV_STRING  道具ID
            SDO_DateLimit4 = 0x8147,//TLV_INTEGER 日期限制
            SDO_TimeLimit4 = 0x8148,//TLV_INTEGER 次数限制
            SDO_ItemCode5 = 0x8149,//TLV_STRING  道具ID
            SDO_DateLimit5 = 0x8150,//TLV_INTEGER 日期限制
            SDO_TimeLimit5 = 0x8151,//TLV_INTEGER 次数限制
            SDO_ItemName1 = 0x8152,//TLV_STRING  道具名1
            SDO_ItemName2 = 0x8153,//TLV_STRING  道具ID2
            SDO_ItemName3 = 0x8154,//TLV_STRING  道具ID3
            SDO_ItemName4 = 0x8155,//TLV_STRING  道具ID4
            SDO_ItemName5 = 0x8156,//TLV_STRING  道具ID5


            ServerInfo_IP = 0x0901,//Format:String 服务器IP
            ServerInfo_City = 0x0902,//Format:String 城市
            ServerInfo_GameID = 0x0903,//Format:Integer 游戏ID
            ServerInfo_GameName = 0x0904,//Format:String 游戏名
            ServerInfo_GameDBID = 0x0905,//Format:Integer 游戏数据库类型
            ServerInfo_GameFlag = 0x0906,//Format:Integer 游戏服务器状态
            ServerInfo_Idx = 0x0907,
            ServerInfo_DBName = 0x0908,
            ///////////////////////////////////////////////////////////////////////
            /// <summary>
            /// 劲舞团定义
            /// </summary>
            AU_ACCOUNT = 0x1001,//玩家帐号 Format:String
            AU_UserNick = 0x1002,//玩家呢称 Format:String
            AU_Sex = 0x1003,//玩家性别 Format:Integer
            AU_State = 0x1004,//玩家状态 Format:Integer
            AU_STOPSTATUS = 0x1005,//劲舞者封停状态 Format:Integer
            AU_Reason = 0x1006,//封停理由 Format:String
            AU_BanDate = 0x1007,//封停日期 Format:TimeStamp
            AU_ServerIP = 0x1008,//劲舞团游戏服务器 Format:String
            AU_Id9you = 0x1009, //Format:Integer 9youID
            AU_UserSN = 0x1010, //Format:Integer 用户序列号
            AU_EquipState = 0x1011, //Format:String 
            AU_AvatarItem = 0x1012, //Format:Integer
            AU_BuyNick = 0x1013, //Format:String 购买呢称
            AU_BuyDate = 0x1014,//Format:Timestamp 购买日期
            AU_ExpireDate = 0x1015,//Format:TimesStamp  过期日期
            AU_BuyType = 0x1016, // Format:Integer 购买类型

            AU_PresentID = 0x1017, //Format:Integer 赠送ID
            AU_SendSN = 0x1018, //Format:Integer  赠送SN
            AU_SendNick = 0x1019, //Format:String 赠送呢称
            AU_RecvSN = 0x1020, //Format:String 接受人SN
            AU_RecvNick = 0x1021, //Format:String 接受人呢称
            AU_Kind = 0x1022, //Format:Integer 类型
            AU_ItemID = 0x1023, //Format:Integer 道具ID
            AU_Period = 0x1024, //Format:Integer 期间
            AU_BeforeCash = 0x1025, //Format:Integer 消费之前金额
            AU_AfterCash = 0x1026, //Format:Integer 消费之后金额
            AU_SendDate = 0x1027, //Format:TimeStamp 发送日期
            AU_RecvDate = 0x1028,//Format:TimeStamp 接受日期
            AU_Memo = 0x1029,//Format:String 备注
            AU_UserID = 0x1030, //Format:String 玩家ID
            AU_Exp = 0x1031, //Format:Integer 玩家经验
            AU_Point = 0x1032, //Format:Integer 玩家位置
            AU_Money = 0x1033, //Format:Integer 金钱
            AU_Cash = 0x1034, //Format:Integer 现金
            AU_Level = 0x1035, //Format:Integer 等级
            AU_Ranking = 0x1036, //Format:Integer 银行
            AU_IsAllowMsg = 0x1037, //Format:Integer 允许发消息
            AU_IsAllowInvite = 0x1038, //Format:Integer 允许邀请
            AU_LastLoginTime = 0x1039, //Format:TimeStamp 最后登录时间
            AU_Password = 0x1040, //Format:String 密码
            AU_UserName = 0x1041, //Format:String 用户名
            AU_UserGender = 0x1042, //Format:String 
            AU_UserPower = 0x1043, //Format:Integer
            AU_UserRegion = 0x1044, //Format:String 
            AU_UserEMail = 0x1045, //Format:String 用户电子邮件
            AU_RegistedTime = 0x1046, //Format:TimeStamp 注册时间

            AU_ItemName = 0x1047,//道具名
            AU_ItemStyle = 0x1048,//道具类型
            AU_Demo = 0x1049,//描述 
            AU_BeginTime = 0x1050,//开始时间
            AU_EndTime = 0x1051,//结束时间
            AU_SendUserID = 0x1052,//发送人帐号
            AU_RecvUserID = 0x1053,//接受人帐号 
            AU_SexIndex = 0x1054,//性别
            AU_GSName = 0x1084,

            AU_UseNum = 0x2296,//消耗数量 int
            AU_BadgeID = 0x2292,//徽章ID int 



            AU_famid = 0x2219,//家族ID int 
            AU_GSServerIP = 0x1085,
            AuShop_ItemTable = 0x1376,
            AU_BroadMsg = 0x2242,//喇叭内容 string
            Magic_Sex = 0x5005,// 性别
            Magic_GuildID = 0x5068, //公会ID
            AU_Log_start = 0x2276,//查询开始时间 (char 14) [YYYYMMDDHHIISS]
            AU_Log_end = 0x2277,//查询结束时间 (char 14) [YYYYMMDDHHIISS]
            AU_UTP = 0x2274,//查询用户类型 (char 1) [1: Send; 2: Recv]
  
            Magic_category = 0x5071,//日志大类
            Magic_action = 0x5072,//日志小类


            /// <summary>
            /// 疯狂卡丁车定义
            /// </summary>
            CR_ServerIP = 0x1101,//服务器IP
            CR_ACCOUNT = 0x1102,//玩家帐号 Format tring
            CR_Passord = 0x1103,//玩家密码 Format tring
            CR_NUMBER = 0x1104,//激活码 Format tring
            CR_ISUSE = 0x1105,//是否被使用
            CR_STATUS = 0x1106,//玩家状态 Format:Integer
            CR_ActiveIP = 0x1107,//激活服务器IP Format:String
            CR_ActiveDate = 0x1108,//激活日期 Format:TimeStamp
            CR_BoardID = 0x1109,//公告ID Format:Integer
            CR_BoardContext = 0x1110,//公告内容 Format:String
            CR_BoardColor = 0x1111,//公告颜色 Format:String
            CR_ValidTime = 0x1112,//生效时间 Format:TimeStamp
            CR_InValidTime = 0x1113,//失效时间 Format:TimeStamp
            CR_Valid = 0x1114,//是否有效 Format:Integer
            CR_PublishID = 0x1115,//发布人ID Format:Integer
            CR_DayLoop = 0x1116,//每天播放 Format:Integer
            CR_PSTID = 0x1117,//注册号 Format:Integer
            CR_SEX = 0x1118,//性别 Format:Integer
            CR_LEVEL = 0x1119,//等级 Format:Integer
            CR_EXP = 0x1120,//经验 Format:Integer
            CR_License = 0x1121,//驾照Format:Integer
            CR_Money = 0x1122,//金钱Format:Integer
            CR_RMB = 0x1123,//人民币Format:Integer
            CR_RaceTotal = 0x1124,//比赛总数Format:Integer
            CR_RaceWon = 0x1125,//胜利场数Format:Integer
            CR_ExpOrder = 0x1126,//经验排名Format:Integer
            CR_WinRateOrder = 0x1127,//胜率排名Format:Integer
            CR_WinNumOrder = 0x1128,//胜利场数排名Format:Integer
            CR_SPEED = 0x1129,//播放速度Format:Integer
            CR_Mode = 0x1130,//播放方式 Format:Integer
            CR_ACTION = 0x1131,//查询动作　Format:Integer
            CR_NickName = 0x1132,//呢称 Format:String
            CR_Channel = 0x1133,//频道ID
            CR_UserID = 0x1134,//用户ID
            CR_BoardContext1 = 0x1135,//内容1
            CR_BoardContext2 = 0x1136,//内容2
            CR_Expire = 0x1137,//生效格式
            CR_ChannelID = 0x1138,//频道ID
            CR_ChannelName = 0x1139,//频道名称
            CR_Last_Login = 0x1140,//上次登入时间		
            CR_Last_Logout = 0x1141,//上次登出时间		
            CR_Last_Playing_Time = 0x1142,//上次游戏时长		
            CR_Total_Time = 0x1143,//总的游戏时长    
            CR_UserName = 0x1144,//玩家姓名
            /// <summary>
            /// 
            /// </summary>
            CARD_PDID = 0x1202,
            CARD_PDkey = 0x1203,
            CARD_PDCardType = 0x1204,
            CARD_PDFrom = 0x1205,
            CARD_PDCardNO = 0x1206,
            CARD_PDCardPASS = 0x1207,
            CARD_PDCardPrice = 0x1208,
            CARD_PDaction = 0x1209,
            CARD_PDuserid = 0x1210,
            CARD_PDusername = 0x1211,
            CARD_PDgetuserid = 0x1212,
            CARD_PDgetusername = 0x1213,
            CARD_PDdate = 0x1214,
            CARD_PDip = 0x1215,
            CARD_PDstatus = 0x1216,
            CARD_UDID = 0x1217,
            CARD_UDkey = 0x1218,
            CARD_UDusedo = 0x1219,
            CARD_UDdirect = 0x1220,
            CARD_UDuserid = 0x1221,
            CARD_UDusername = 0x1222,
            CARD_UDgetuserid = 0x1223,
            CARD_UDgetusername = 0x1224,
            CARD_UDcoins = 0x1225,
            CARD_UDtype = 0x1226,
            CARD_UDtargetvalue = 0x1227,
            CARD_UDzone1 = 0x1228,
            CARD_UDzone2 = 0x1229,
            CARD_UDdate = 0x1230,
            CARD_UDip = 0x1231,
            CARD_UDstatus = 0x1232,
            CARD_cardnum = 0x1233,
            CARD_cardpass = 0x1234,
            CARD_serial = 0x1235,
            CARD_draft = 0x1236,
            CARD_type1 = 0x1237,
            CARD_type2 = 0x1238,
            CARD_type3 = 0x1239,
            CARD_type4 = 0x1240,
            CARD_price = 0x1241,
            CARD_valid_date = 0x1242,
            CARD_use_status = 0x1243,
            CARD_cardsent = 0x1244,
            CARD_create_date = 0x1245,
            CARD_use_userid = 0x1246,
            CARD_use_username = 0x1247,
            CARD_partner = 0x1248,
            CARD_skey = 0x1249,
            CARD_ActionType = 0x1250,
            CARD_id = 0x1251,//TLV_STRING 久之游注册卡号
            CARD_username = 0x1252,//TLV_STRING 久之游注册用户名
            CARD_nickname = 0x1253,//TLV_STRING 久之游注册呢称
            CARD_password = 0x1254,//TLV_STRING 久之游注册密码
            CARD_sex = 0x1255,//TLV_STRING 久之游注册性别
            CARD_rdate = 0x1256,//TLV_Date 久之游注册日期
            CARD_rtime = 0x1257,//TLV_Time 久之游注册时间
            CARD_securecode = 0x1258,//TLV_STRING 安全码
            CARD_vis = 0x1259,//TLV_INTEGER
            CARD_logdate = 0x1260,//TLV_TimeStamp 日期
            CARD_realname = 0x1263,//TLV_STRING 真实姓名
            CARD_birthday = 0x1264,//TLV_Date 出生日期
            CARD_cardtype = 0x1265,//TLV_STRING
            CARD_email = 0x1267,//TLV_STRING 邮件
            CARD_occupation = 0x1268,//TLV_STRING 职业
            CARD_education = 0x1269,//TLV_STRING 教育程度
            CARD_marriage = 0x1270,//TLV_STRING 婚否
            CARD_constellation = 0x1271,//TLV_STRING 星座
            CARD_shx = 0x1272,//TLV_STRING 生肖
            CARD_city = 0x1273,//TLV_STRING 城市
            CARD_address = 0x1274,//TLV_STRING 联系地址
            CARD_phone = 0x1275,//TLV_STRING 联系电话
            CARD_qq = 0x1276,//TLV_STRING QQ
            CARD_intro = 0x1277,//TLV_STRING 介绍
            CARD_msn = 0x1278,//TLV_STRING MSN
            CARD_mobilephone = 0x1279,//TLV_STRING 移动电话
            CARD_SumTotal = 0x1280,//TLV_INTEGER 合计

            /// <summary>
            /// 
            /// </summary>
            AuShop_orderid = 0x1301,//int(11) 
            AuShop_udmark = 0x1302,//int(8) 
            AuShop_bkey = 0x1303,//varchar(40) 
            AuShop_pkey = 0x1304,//varchar(18) 
            AuShop_userid = 0x1305,//int(11) 
            AuShop_username = 0x1306,//varchar(20) 
            AuShop_getuserid = 0x1307,//int(11) 
            AuShop_getusername = 0x1308,//varchar(20) 
            AuShop_pcategory = 0x1309,//smallint(4) 
            AuShop_pisgift = 0x1310,//enum('y','n') 
            AuShop_islover = 0x1311,//enum('y','n') 
            AuShop_ispresent = 0x1312,//enum('y','n') 
            AuShop_isbuysong = 0x1313,//enum('y','n') 
            AuShop_prule = 0x1314,//tinyint(1) 
            AuShop_psex = 0x1315,//enum('all','m','f') 
            AuShop_pbuytimes = 0x1316,//int(11) 
            AuShop_allprice = 0x1317,//int(11) 
            AuShop_allaup = 0x1318,//int(11)
            AuShop_buytime = 0x1319,//int(10) 
            AuShop_buytime2 = 0x1320,//datetime 
            AuShop_buyip = 0x1321,//varchar(15) 
            AuShop_zone = 0x1322,//tinyint(2) 
            AuShop_status = 0x1323,//tinyint(1) 
            AuShop_pid = 0x1324,//int(11) 
            AuShop_pname = 0x1326,//varchar(20) 
            AuShop_pgift = 0x1328,//enum('y','n') 
            AuShop_pscash = 0x1330,//tinyint(2) 
            AuShop_pgamecode = 0x1331,//varchar(200) 
            AuShop_pnew = 0x1332,//enum('y','n') 
            AuShop_phot = 0x1333,//enum('y','n') 
            AuShop_pcheap = 0x1334,//enum('y','n') 
            AuShop_pchstarttime = 0x1335,//int(10) 
            AuShop_pchstoptime = 0x1336,//int(10) 
            AuShop_pstorage = 0x1337,//smallint(5) 
            AuShop_pautoprice = 0x1339,//enum('y','n') 
            AuShop_price = 0x1340,//int(8) 
            AuShop_chprice = 0x1341,//int(8) 
            AuShop_aup = 0x1342,//int(8) 
            AuShop_chaup = 0x1343,//int(8) 
            AuShop_ptimeitem = 0x1344,//varchar(200) 
            AuShop_pricedetail = 0x1345,//varchar(254) 
            AuShop_pdesc = 0x1347,//text
            AuShop_pbuys = 0x1348,//int(8) 
            AuShop_pfocus = 0x1349,//tinyint(1) 
            AuShop_pmark1 = 0x1350,//enum('y','n') 
            AuShop_pmark2 = 0x1351,//enum('y','n') 
            AuShop_pmark3 = 0x1352,//enum('y','n') 
            AuShop_pinttime = 0x1353,//int(10) 
            AuShop_pdate = 0x1354,//int(10) 
            AuShop_pisuse = 0x1355,//enum('y','n') 
            AuShop_ppic = 0x1356,//varchar(36) 
            AuShop_ppic1 = 0x1357,//varchar(36) 
            AuShop_usefeesum = 0x1358,//int
            AuShop_useaupsum = 0x1359,//int
            AuShop_buyitemsum = 0x1360,//int
            AuShop_BeginDate = 0x1361,//date
            AuShop_EndDate = 0x1362,//

            AuShop_GCashSum = 0x1363,//int
            AuShop_MCashSum = 0x1364,//int


            /// <summary>
            /// 
            /// </summary>
            /// <summary>
            /// 劲乐团
            /// </summary>
            o2jam_ServerIP = 0x1401,//Format:TLV_STRING IP
            o2jam_UserID = 0x1402,//Format:TLV_STRING 用户帐号
            o2jam_UserNick = 0x1403,//Format:TLV_STRING 用户呢称
            o2jam_Sex = 0x1404,//Format:TLV_INTEGER 性别
            o2jam_Level = 0x1405,//Format:TLV_STRING 等级
            o2jam_Win = 0x1406,//Format:TLV_STRING 胜
            o2jam_Draw = 0x1407,//Format:TLV_STRING 平
            o2jam_Lose = 0x1408,//Format:TLV_STRING 负
            o2jam_SenderID = 0x1409,				//varchar
            o2jam_SenderIndexID = 0x1410,				//int
            o2jam_SenderNickName = 0x1411,				//varchar
            o2jam_ReceiverID = 0x1412,				//varchar
            o2jam_ReceiverIndexID = 0x1413,				//int
            o2jam_ReceiverNickName = 0x1414,				//varchar
            o2jam_Title = 0x1415,				//varchar
            o2jam_Content = 0x1416,				//varchar
            o2jam_WriteDate = 0x1417,				//datetime
            o2jam_ReadDate = 0x1418,				//datetime
            o2jam_ReadFlag = 0x1419,				//char
            o2jam_TypeFlag = 0x1420,				//char
            o2jam_Ban_Date = 0x1421,				//datetime
            o2jam_GEM = 0x1422,				//int
            o2jam_MCASH = 0x1423,				//int
            o2jam_O2CASH = 0x1424,				//int
            o2jam_MUSICCASH = 0x1425,				//int
            o2jam_ITEMCASH = 0x1426,				//int
            o2jam_USER_INDEX_ID = 0x1427,				//int
            o2jam_ITEM_INDEX_ID = 0x1428,				//int
            o2jam_USED_COUNT = 0x1429,				//int
            o2jam_REG_DATE = 0x1430,				//datetime
            o2jam_OLD_USED_COUNT = 0x1431,				//int
            o2jam_CURRENT_CASH = 0x1433,				//int
            o2jam_CHARGED_CASH = 0x1434,				//int
            o2jam_KIND_CASH = 0x1435,				//char
            o2jam_NAME = 0x1437,				//varchar
            o2jam_KIND = 0x1438,				//int
            o2jam_PLANET = 0x1439,				//int
            o2jam_VAL = 0x1440,				//int
            o2jam_EFFECT = 0x1441,				//int
            o2jam_JUSTICE = 0x1442,				//int
            o2jam_LIFE = 0x1443,				//int
            o2jam_PRICE_KIND = 0x1444,				//int
            o2jam_Exp = 0x1445, //Int
            o2jam_Battle = 0x1446,//Int
            o2jam_POSITION = 0x1448,				//int
            o2jam_COMPANY_ID = 0x1449,				//int
            o2jam_DESCRIBE = 0x1450,				//varchar
            o2jam_UPDATE_TIME = 0x1451,				//datetime
            o2jam_ITEM_NAME = 0x1453,				//varchar
            o2jam_ITEM_USE_COUNT = 0x1454,				//int
            o2jam_ITEM_ATTR_KIND = 0x1455,				//int
            o2jam_USER_ID = 0x1457,				//varchar
            o2jam_USER_NICKNAME = 0x1458,				//varchar
            o2jam_SEX = 0x1459,				//char
            o2jam_CREATE_TIME = 0x1460,				//datetime
            o2jam_BeginDate = 0x1461,
            o2jam_EndDate = 0x1462,
            O2JAM_BuyType = 0x1509,//TLV_INTEGER


            O2JAM_EQUIP1 = 0x1463,		//TLV_STRING,
            O2JAM_EQUIP2 = 0x1464,	//TLV_STRING,
            O2JAM_EQUIP3 = 0x1465,	//TLV_STRING,
            O2JAM_EQUIP4 = 0x1466,	//TLV_STRING,
            O2JAM_EQUIP5 = 0x1467,	//TLV_STRING,
            O2JAM_EQUIP6 = 0x1468,	//TLV_STRING,
            O2JAM_EQUIP7 = 0x1469,	//TLV_STRING,
            O2JAM_EQUIP8 = 0x1470,	//TLV_STRING,
            O2JAM_EQUIP9 = 0x1471,	//TLV_STRING,
            O2JAM_EQUIP10 = 0x1472,		//TLV_STRING,
            O2JAM_EQUIP11 = 0x1473,	//TLV_STRING,
            O2JAM_EQUIP12 = 0x1474,	//TLV_STRING,
            O2JAM_EQUIP13 = 0x1475,	//TLV_STRING,
            O2JAM_EQUIP14 = 0x1476,	//TLV_STRING,
            O2JAM_EQUIP15 = 0x1477,	//TLV_STRING,
            O2JAM_EQUIP16 = 0x1478,		//TLV_STRING,
            O2JAM_BAG1 = 0x1479,		//TLV_STRING,
            O2JAM_BAG2 = 0x1480,	//TLV_STRING,
            O2JAM_BAG3 = 0x1481,	//TLV_STRING,
            O2JAM_BAG4 = 0x1482,	//TLV_STRING,
            O2JAM_BAG5 = 0x1483,		//TLV_STRING,
            O2JAM_BAG6 = 0x1484,	//TLV_STRING,
            O2JAM_BAG7 = 0x1485,	//TLV_STRING,
            O2JAM_BAG8 = 0x1486,	//TLV_STRING,
            O2JAM_BAG9 = 0x1487,	//TLV_STRING,
            O2JAM_BAG10 = 0x1488,	//TLV_STRING,
            O2JAM_BAG11 = 0x1489,	//TLV_STRING,
            O2JAM_BAG12 = 0x1490,	//TLV_STRING,
            O2JAM_BAG13 = 0x1491,	//TLV_STRING,
            O2JAM_BAG14 = 0x1492,	//TLV_STRING,
            O2JAM_BAG15 = 0x1493,	//TLV_STRING,
            O2JAM_BAG16 = 0x1494,	//TLV_STRING,
            O2JAM_BAG17 = 0x1495,	//TLV_STRING,
            O2JAM_BAG18 = 0x1496,	//TLV_STRING,
            O2JAM_BAG19 = 0x1497,	//TLV_STRING,
            O2JAM_BAG20 = 0x1498,	//TLV_STRING,
            O2JAM_BAG21 = 0x1499,	//TLV_STRING,
            O2JAM_BAG22 = 0x1500,	//TLV_STRING,
            O2JAM_BAG23 = 0x1501,	//TLV_STRING,
            O2JAM_BAG24 = 0x1502,	//TLV_STRING,
            O2JAM_BAG25 = 0x1503,	//TLV_STRING,
            O2JAM_BAG26 = 0x1504,	//TLV_STRING,
            O2JAM_BAG27 = 0x1505,	//TLV_STRING,
            O2JAM_BAG28 = 0x1506,	//TLV_STRING,
            O2JAM_BAG29 = 0x1507,	//TLV_STRING,
            O2JAM_BAG30 = 0x1508,	//TLV_STRING



            /// <summary>
            /// 劲乐团II
            /// </summary>
            O2JAM2_ServerIP = 0x1601,//TLV_STRING
            O2JAM2_UserID = 0x1602,//TLV_STRING
            O2JAM2_UserName = 0x1603,//TLV_STRING
            O2JAM2_Id1 = 0x1604,//TLV_Integer
            O2JAM2_Id2 = 0x1605,//TLV_Integer
            O2JAM2_Rdate = 0x1606,//TLV_Date
            O2JAM2_IsUse = 0x1607,//TLV_Integer
            O2JAM2_Status = 0x1608,//TLV_Integer


            O2JAM2_UserIndexID = 0x1609,//TLV_Integer
            O2JAM2_UserNick = 0x1610,//Format:TLV_STRING 用户呢称
            O2JAM2_Sex = 0x1611,//Format:TLV_BOOLEAN 性别
            O2JAM2_Level = 0x1612,//Format:TLV_INTEGER 等级
            O2JAM2_Win = 0x1613,//Format:TLV_INTEGER 胜
            O2JAM2_Draw = 0x1614,//Format:TLV_INTEGER 平
            O2JAM2_Lose = 0x1615,//Format:TLV_INTEGER 负
            O2JAM2_Exp = 0x1616,//Format:TLV_INTEGER 经验
            O2JAM2_TOTAL = 0x1617,//Format:TLV_INTEGER 总局数
            O2JAM2_GCash = 0x1618,//Format:TLV_INTEGER G币
            O2JAM2_MCash = 0x1619,//Format:TLV_INTEGER M币
            O2JAM2_ItemCode = 0x1620,//Format:TLV_INTEGER
            O2JAM2_ItemName = 0x1621,//Format:TLV_String
            O2JAM2_Timeslimt = 0x1622,
            O2JAM2_DateLimit = 0x1623,
            O2JAM2_ItemSource = 0x1624,
            O2JAM2_Position = 0x1625,//int
            O2JAM2_BeginDate = 0x1626,
            O2JAM2_ENDDate = 0x1627,
            O2JAM2_MoneyType = 0x1628,//int
            O2JAM2_Title = 0x1629,
            O2JAM2_Context = 0x1630,
            o2jam2_consumetype = 0x1631,//int
            O2JAM2_ComsumeCode = 0x1632,//int
            O2JAM2_DayLimit = 0x1633,//int

            O2JAM2_StopTime = 0x1634,//date
            O2JAM2_StopStatus = 0x1635,//int
            O2JAM2_REASON = 0x1636,//string




            SDO_SenceID = 0x0858,
            SDO_WeekDay = 0x0859,
            SDO_MatPtHR = 0x0860,
            SDO_MatPtMin = 0x0861,
            SDO_StPtHR = 0x0862,
            SDO_StPtMin = 0x0863,
            SDO_EdPtHR = 0x0864,
            SDO_EdPtMin = 0x0865,

            SDO_Sence = 0x0868,
            SDO_MusicID1 = 0x0869,
            SDO_MusicName1 = 0x0870,
            SDO_LV1 = 0x0871,
            SDO_MusicID2 = 0x0872,
            SDO_MusicName2 = 0x0873,
            SDO_LV2 = 0x0874,
            SDO_MusicID3 = 0x0875,
            SDO_MusicName3 = 0x0876,
            SDO_LV3 = 0x0877,
            SDO_MusicID4 = 0x0878,
            SDO_MusicName4 = 0x0879,
            SDO_LV4 = 0x0880,
            SDO_MusicID5 = 0x0881,
            SDO_MusicName5 = 0x0882,
            SDO_LV5 = 0x0883,
            SDO_Precent = 0x0884,
            SDO_State = 0x8134,//TLV_STRING  状态
            SDO_mood = 0x8135,//TLV_INTEGER 心情值
            SDO_Food = 0x8136,//TLV_INTEGER 饱食度


            SDO_PreValue = 0x8160,//最小值
            SDO_EndValue = 0x8161,//最大值
            SDO_NorProFirst = 0x8162,//第一次打开的概率
            SDO_NorPro = 0x8163,//普通宝箱的概率
            SDO_SpePro = 0x8164,//特殊宝箱的概率
            SDO_baoxiangid = 0x8165,//id int
            SDO_Mark = 0x8166,//标识 int
            //SDO_FirstPadTime = 0x0885,
            Soccer_ServerIP = 0x1701,
            Soccer_loginId = 0x1702,//Login ID
            Soccer_charsex = 0x1703,// 
            Soccer_charidx = 0x1704,//角色序列号 (ExSoccer.dbo.t_character[idx])
            Soccer_charexp = 0x1705,//经验值
            Soccer_charlevel = 0x1706,//等级
            Soccer_charpoint = 0x1707,//G点数 
            Soccer_match = 0x1708,//比赛数
            Soccer_win = 0x1709,//
            Soccer_lose = 0x1710,//失败
            Soccer_draw = 0x1711,//平局
            Soccer_drop = 0x1712,//平局		
            Soccer_charname = 0x1713,//角色名
            Soccer_charpos = 0x1714,//位置
            Soccer_Type = 0x1715,//查询类型
            Soccer_String = 0x1716,//查询值 
            Soccer_admid = 0x1717,//管理者ID
            Soccer_deleted_date = 0x1718,//删除日期
            Soccer_status = 0x1719,//状态
            Soccer_m_id = 0x1720,//玩家序列号 int
            Soccer_m_auth = 0x1721,//玩家是否被停封 int
            Soccer_regDate = 0x1722,//玩家注册日期 string 
            Soccer_c_date = 0x1723,//角色创建日期 string 
            Soccer_char_max = 0x1724,//tinyint
            Soccer_char_cnt = 0x1725,//int
            Soccer_ret = 0x1726,//int
            Soccer_kind = 0x1727,//socket,name string

            #region 敢达Online
            SD_GoldAccount = 0x4401,//TLV_STRING是否高级帐号
            SD_IsUsed = 0x4402,//是否使用
            SD_UserName = 0x4403,//玩家帐号
            SD_UseDate = 0x4404,//使用日期
            SD_ActiceCode = 0x4405,//激活码


            f_passWd = 0x4406,//密码 string
            f_gender = 0x4407,//性别 int 0女1男
            f_adult = 0x4408,//是否成年 0成年1未成年
            f_regDate = 0x4409,//注册日期 timestamp
            f_loginDate = 0x4410,//最后登陆日期 timestamp
            f_logoutDate = 0x4411,//最后登出日期 timestamp
            f_bandate = 0x4412,//封停日期 timestamp
            f_pilot = 0x4413,//绰号 string
            f_level = 0x4414,//级别 int
            f_levelname = 0x4415,//级别名称 string
            f_Exp = 0x4416,//经验 int
            f_shootCnt = 0x4417,//击破数 int
            f_collectCnt = 0x4418,//收集数 int
            f_fightCnt = 0x4419,//战斗数 int
            f_winCnt = 0x4420,//胜利 int
            f_loseCnt = 0x4421,//失败 int
            f_drawCnt = 0x4422,//平局 int
            f_idx = 0x4423, //玩家ID int

            SD_ban = 0x4424,//封停 int
            SD_NeedExp = 0x4425,//升级需要的经验 int
            SD_GC = 0x4426,//G币 int
            SD_GP = 0x4427,//M币 int
            SD_KillNum = 0x4428,//被杀次数 int

            SD_SlotNumber = 0x4429,//栏数 int 
            SD_ItemName = 0x4430,//道具名 string 
            SD_ItemID = 0x4431,//道具ID int 
            SD_GetTime = 0x4432,//获得时间 timestamp 
            SD_RemainCount = 0x4433,//剩余数量 int 
            SD_BuyType = 0x4434,//购买类型 int

            SD_DateEnd = 0x4435,//到期时间 timestamp
            SD_UnitName = 0x4436,//机体名 string
            SD_UnitNickName = 0x4437,//机体呢称 string
            SD_UnitLevelNumber = 0x4438,//机体等级 int
            SD_UnitExp = 0x4439,//机体经验 int
            SD_StateSaleIntention = 0x4440,//是否可以买卖 string
            SD_CustomLvMax = 0x4441,//机体最大合成次数
            SD_CustomPoint = 0x4442,//机体合成点数
            SD_BatItemName = 0x4443,//战斗道具名称 string
            SD_OperatorNickname = 0x4444,//副官呢称 string

            SD_ServerIP = 0x4445,//服务器IP string

            SD_StartTime = 0x4446,//起始时间  DateTime
            SD_EndTime = 0x4447,//结束时间 DateTime
            SD_ServerName = 0x4448,//服务器名称 string
            SD_ID = 0x4449,//id INT
            SD_Content = 0x4450,//封停内容 string
            SD_Limit = 0x4451,//间隔 int
            SD_Type = 0x4452,//类型 int
            SD_Title = 0x4453,//标题 string
            SD_Number = 0x4454,//数量 int
            SD_TmpPWD = 0x4455,//临时密码 string
            SD_passWd = 0x4456,//真实密码 string
            SD_TempPassWord = 0x4457,//密码 string

            SD_FromIdx = 0x4458,//发送用户id int
            SD_ToIdx = 0x4459,//接受用户id int

            SD_ItemName1 = 0x4460,//道具名1 string
            SD_ItemID1 = 0x4461,//道具ID1 int
            SD_ItemName2 = 0x4462,//道具名2 string
            SD_ItemID2 = 0x4463,//道具ID2 int
            SD_ItemName3 = 0x4464,//道具名3 string
            SD_ItemID3 = 0x4465,//道具ID3 int
            SD_Number1 = 0x4466,//数量1 int
            SD_Number2 = 0x4467,//数量2 int
            SD_Number3 = 0x4468,//数量3 int

            SD_N10 = 0x4469,//礼物发送后剩余的point int
            SD_N11 = 0x4470,//使用在礼物购买上的point int
            SD_N12 = 0x4471,//结算方式(0.point 1.cash) int
            SD_SendTime = 0x4472,//发送时间 dateTime
            SD_FromUser = 0x4473,//发送用户 string
            SD_ToUser = 0x4474,//接受用户 string
            SD_Make = 0x4475,//内容 string
            SD_SendType = 0x4476,//发送公告类型 int 0:即时发送 1:普通发送
            SD_Status = 0x4477,//发送公告状态 int

            SD_LastMoney = 0x4478,//剩余金钱 string
            SD_UseMoney = 0x4479,//删除时得到金钱 string
            SD_DeleteResult = 0x4480,//删除原因 string
            SD_UnitType = 0x4481,//机体类型 string
            SD_ShopType = 0x4482,//商店购买机体与否 string
            SD_LimitType = 0x4483,//租赁期间到期与否 string
            SD_ChangeBody = 0x4484,//改装部位 string
            SD_ChangeItem = 0x4485,//改装道具 string
            SD_CombPic = 0x4486,//合成图纸 string
            SD_CombItem = 0x4487,//合成素材 string
            SD_Time = 0x4488,//时间 string
            SD_QuestionName = 0x4489,//任务名称 string
            SD_Questionlevel = 0x4490,//任务难度 int
            SD_QuestionTime = 0x4491,//任务完成时间 string
            SD_QuestionGetItem = 0x4492,//任务奖励获得情况 string
            SD_Msg = 0x4493,//内容 string 
            SD_FirendName = 0x4494,//好友 string
            SD_GetMoney = 0x4495,//得到金钱 string
            SD_State = 0x4496,//状态 int
            SD_QusetID = 0x4497,//任务ID int
            SD_QusetName = 0x4498,//任务名称 string
            SD_ClearedDate = 0x4499,//完成时间 string 
            SD_HP = 0x4500,//string
            SD_DashLevel = 0x4501,//string
            SD_StrikingPower = 0x4502,//string
            SD_FatalAttack = 0x4503,//string
            SD_DefensivePower = 0x4504,//string
            SD_MotivePower = 0x4505,//string
            SD_DelTime = 0x4506,//删除时间 timestamp

            SD_SkillName = 0x4507,//技能 string
            SD_UColor_1 = 0x4508,//颜色1 string
            SD_UColor_2 = 0x4509,//颜色2 string
            SD_UColor_3 = 0x4510,//颜色3 string
            SD_UColor_4 = 0x4511,//颜色4 string
            SD_UColor_5 = 0x4512,//颜色5 string
            SD_UColor_6 = 0x4513,//颜色6 string
            SD_UDecal_1 = 0X4514,//标签1 string
            SD_UDecal_2 = 0X4515,//标签2 string
            SD_UDecal_3 = 0X4516,//标签3 string
            SD_RewardCount = 0x4518,
            SD_UnitLevelName = 0x4519,//机体等级         
            SD_TypeName = 0x4520,//类型
            SD_Star = 0x4521,//机体星级
            SD_LevelUpTime = 0x4523,//升级时间 timestamp
            SD_Money_Old = 0x4524,//修改前的钱 int
            SD_UserName_Old = 0x4522,//修改前用户名 string
            SD_LostCodeMoney = 0x4525,//剩余代币 string
            SD_UseCodeMoney = 0x4526,//使用代币 string
            SD_LostMoney = 0x4527,//消耗的G币

            SD_GuildName = 0x4539,//工会名字 guildName
            SD_GuildBass = 0x4547,//工会基地 string 
            SD_Oldvalue = 0x4549, //扣除前金额 string
            SD_Newvalue = 0x4550,//扣除后金额 string 
            #endregion

            #region 劲舞团2
            /// <summary>
            /// 劲舞团2定义
            /// </summary>
            LORD_Gold = 0x6206,//金币
            JW2_ACCOUNT = 0x7001,//玩家帐号 Format:String
            JW2_UserNick = 0x7002,//玩家呢称 Format:String
            JW2_ServerName = 0x7003,//服务器名称
            JW2_ServerIP = 0x7004,//游戏服务器 Format:String
            JW2_State = 0x7005,//玩家状态 Format:Integer
            JW2_Reason = 0x7006,//封停理由 Format:String
            JW2_BanDate = 0x7007,//封停日期 Format:dataTime
            JW2_UserSN = 0x7008, //Format:Integer 用户序列号
            JW2_GSServerIP = 0x7009,//星球 Format:String
            JW2_UserID = 0x7010, //Format:String 玩家ID
            JW2_Sex = 0x7011,//玩家性别 Format:Integer
            JW2_AvatarItem = 0x7012, //Format:Integer 道具ID
            JW2_ExpireDate = 0x7013,//Format:TimesStamp  过期日期
            JW2_Exp = 0x7014, //Format:Integer 玩家经验
            JW2_Money = 0x7015, //Format:Integer 金钱
            JW2_Cash = 0x7016, //Format:Integer 现金
            JW2_Level = 0x7017, //Format:Integer 等级
            JW2_UseItem = 0x7018,//Format:Integer是否在使用中，1用0不用
            JW2_RemainCount = 0x7019,//Format:Integer剩余次数，0为无限次
            JW2_BeginTime = 0x7020,//开始时间Format:DATE
            JW2_EndTime = 0x7021,//结束时间Format:DATE
            JW2_BoardMessage = 0x7022,//公告内容,喇叭发送内容Format:String
            JW2_TaskID = 0x7023,//任务号Format:Integer
            JW2_Status = 0x7024,//是否完成状态Format:Integer
            JW2_Interval = 0x7025,//间隔时间Format:Integer
            JW2_UseTime = 0x7026,//使用时间 TLV_DATE
            JW2_POWER = 0x7027,//权限，普通用户是0，管理员为1 Format:Integer
            JW2_GoldMedal = 0x7028,//金牌 Format:Integer
            JW2_SilverMedal = 0x7029,//银牌 Format:Integer
            JW2_CopperMedal = 0x7030,//铜牌 Format:Integer
            JW2_Region = 0x7031,//地区 Format:String
            JW2_QQ = 0x7032,//QQ号 Format:String
            JW2_PARA = 0x7033,//结婚任务用的一个参数 Format:Integer
            JW2_ATONCE = 0x7034,//是否立即发送Format:Integer
            JW2_BOARDSN = 0x7035,//大小喇叭，横幅记录唯一标示Format:Integer
            JW2_BUGLETYPE = 0x7036,//类型0mb发小喇叭,1积分发小喇叭,1mb发大喇叭,11积分发大喇叭,20及20以上是横幅Format:Integer
            //情节///////////
            JW2_Chapter = 0x7037,//章节
            JW2_CurStage = 0x7038,//目前等级
            JW2_MaxStage = 0x7039,//最大等级
            JW2_Stage0 = 0x7040,//关卡1
            JW2_Stage1 = 0x7041,
            JW2_Stage2 = 0x7042,
            JW2_Stage3 = 0x7043,
            JW2_Stage4 = 0x7044,
            JW2_Stage5 = 0x7045,
            JW2_Stage6 = 0x7046,
            JW2_Stage7 = 0x7047,
            JW2_Stage8 = 0x7048,
            JW2_Stage9 = 0x7049,
            JW2_Stage10 = 0x7050,
            JW2_Stage11 = 0x7051,
            JW2_Stage12 = 0x7052,
            JW2_Stage13 = 0x7053,
            JW2_Stage14 = 0x7054,
            JW2_Stage15 = 0x7055,
            JW2_Stage16 = 0x7056,
            JW2_Stage17 = 0x7057,
            JW2_Stage18 = 0x7058,
            JW2_Stage19 = 0x7059,//关卡20
            //情节end///////////
            JW2_BUYSN = 0x7060,//购买SN
            JW2_GOODSTYPE = 0x7061,//购买类型
            JW2_RECESN = 0x7062,//接受人的SN（如果相同是本人）
            JW2_GOODSINDEX = 0x7063,//物品编号
            JW2_BUYDATE = 0x7064,//购买日期
            JW2_RECEID = 0x7065,//接受人的ID（如果相同是本人）
            JW2_AvatarItemName = 0x7066, //道具名称 Format:String
            JW2_MALESN = 0x7067,//男性SN
            JW2_MALEUSERNAME = 0x7068,//男性用户名
            JW2_MALEUSERNICK = 0x7069,//男性昵称
            JW2_FEMAILESN = 0x7070,//女性SN
            JW2_FEMALEUSERNAME = 0x7071,//女性用户名
            JW2_FEMAILEUSERNICK = 0x7072,//女性昵称
            JW2_WEDDINGDATE = 0x7073,//结婚时间
            JW2_UNWEDDINGDATE = 0x7074,//离婚时间
            JW2_WEDDINGNAME = 0x7075,//婚礼名称
            JW2_WEDDINGVOW = 0x7076,//婚礼誓言
            JW2_RINGLEVEL = 0x7077,//戒指等级
            JW2_REDHEARTNUM = 0x7078,//红心数量
            JW2_WEDDINGNO = 0x7079,//婚姻序号
            JW2_CONFIRMSN = 0x7080,//见证者SN
            JW2_CONFIRMUSERNAME = 0x7081,//见证者用户名
            JW2_CONFIRMUSERNICK = 0x7082,//见证者昵称
            JW2_COUPLEDATE = 0x7083,//情侣日期
            JW2_KISSNUM = 0x7084,//kiss次数
            JW2_LASTKISSDATE = 0x7085,//最后一次Kiss时间
            JW2_BREAKDATE = 0x7088,//分手时间
            JW2_CMBREAKDATE = 0x7089,//确认分手时间
            JW2_BREAKSN = 0x7090,//提出SN
            JW2_BREAKUSERNAME = 0x7091,//提出用户名
            JW2_BREAKUSERNICK = 0x7092,//提出昵称
            JW2_LASTLOGINDATE = 0x7093,//最后登陆时间
            JW2_REGISTDATE = 0x7094,//激活时间
            JW2_FCMSTATUS = 0x7095,//防沉迷状态
            JW2_FAMILYID = 0x7096,//家族ID
            JW2_FAMILYNAME = 0x7097,//名称
            JW2_DUTYID = 0x7098,//职业号
            JW2_DUTYNAME = 0x7099,//职业名
            JW2_ATTENDTIME = 0x7100,//加入时间
            JW2_COUPLESN = 0x7101,//情侣序号
            JW2_CREATETIME = 0x7102,//创建时间
            JW2_CNT = 0x7103,//人数
            JW2_POINT = 0x7104,//积分
            JW2_LOGINTYPE = 0x7105,//类型0登入，1登出
            JW2_TIME = 0x7106,//时间
            JW2_IP = 0x7107,//IP地址
            JW2_PWD = 0x7108,//密码
            JW2_AvatarItemType = 0x7109,//物品类型（头发等）
            JW2_ItemPos = 0x7110,//物品位置(0,身上,1,物品栏,2,礼物栏)
            JW2_MailTitle = 0x7111,//邮件主题
            JW2_MailContent = 0x7112,//邮件内容
            JW2_ItemNo = 0x7113,//物品序号
            JW2_Repute = 0x7115,//声望
            JW2_NowTitle = 0x7116,//称号
            JW2_FamilyLevel = 0x7117,//等级
            JW2_AttendRank = 0x7118,//人气排名
            JW2_MoneyRank = 0x7119,//财富排名
            JW2_PowerRank = 0x7120,//实力排名
            JW2_ItemCode = 0x7121,//道具ID
            JW2_ItemName = 0x7122,//道具名称
            JW2_Productid = 0x7123,//商品ID
            JW2_ProductName = 0x7124,//商品名称
            JW2_FamilyPoint = 0x7125,//家族点数
            JW2_PetSn = 0x7126,//宠物ID
            JW2_PetName = 0x7127,//宠物名称
            JW2_PetNick = 0x7128,//宠物自定义名称
            JW2_PetLevel = 0x7129,//宠物等级
            JW2_PetExp = 0x7130,//宠物经验
            JW2_PetEvol = 0x7131,//进阶阶段
            JW2_MailSn = 0x7132,//序列号
            JW2_SendNick = 0x7133,//发件人昵称
            JW2_SendDate = 0x7134,//发送日期
            JW2_Num = 0x7135,//数量
            JW2_Rate = 0x7136,//男女比例
            JW2_ShaikhNick = 0x7137,//族长名称
            JW2_SubFamilyName = 0x7138,//隶属家族名称
            JW2_sNum = 0x7139,//数量STRING
            JW2_MessengerName = 0x7140,//Messenger称号
            JW2_TmpPWD = 0x7141,//临时密码 string 
            JW2_Type = 0x7142,//类型 string
            JW2_SendUser = 0x7143,//购买用户 string 
            JW2_RecUser = 0x7144,//接收用户 string
            JW2_BeforeCash = 0x7145,//消费前金额 int 
            JW2_AfterCash = 0x7146,//消费后金额 int
            JW2_Center_Avatarid = 0x7147,//中间件道具ID,int
            JW2_Center_AvatarName = 0x7148,//中间件道具名 string
            JW2_Center_State = 0x7149,//状态 int(0装备，2未装备)
            JW2_Last_Op_Time = 0x7150,//最后使用时间 date
            JW2_LOGDATE = 0x7151,//时间 date
            JW2_ZoneID = 0x7152,//服务器ID int
            JW2_VailedDay = 0x7153,//时限（7天，30天，65535=无限） int
            JW2_IntRo = 0x7154,//状态（1自己购买，0是别人赠送） int
            JW2_SubGameID = 0x7155,//子游戏ID int
            JW2_Center_EndTime = 0x7156,//過期時間 date
            JW2_Forever = 0x7157,//(1永久，0非永久) int
            JW2_Family_Money = 0x7159,//捐献金钱 string 
            JW2_ReportSn = 0x7160,//举报ID int
            JW2_ReporterSn = 0x7161,//举报人ID int 
            JW2_ReporterNick = 0x7162,//举报人昵称 string
            JW2_ReportedNick = 0x7163,//被举报人昵称 string
            JW2_Memo = 0x7164,//举报说明 string
            JW2_ReportType = 0x7165,//举报类型 int 
            JW2_OLD_FAMILYNAME = 0x7166,//老家族名 string
            JW2_OLD_PETNAME = 0x7167,//老宠物自定义名
            JW2_BuyLimitDay = 0x7168,//道具期限 string
            JW2_BuyMoneyCost = 0x7169,//真实价格 string
            JW2_BuyOrgCost = 0x7170,//原始价格 string 

            JW2_MissionID = 0x7171,//任务ID int
            JW2_MissionName = 0x7172,//任务名字 string


            jw2_goodsprice = 0x7173,//购买价格 int
            jw2_beforemoney = 0x7174,//购买前金钱数 int
            jw2_aftermoney = 0x7175,//购买后金钱数 int



            jw2_serverno = 0x7176,//GS序号 int
            jw2_port = 0x7177,//GS端口int

            jw2_MaterialCode = 0x7178,//合成材料 string

            jw2_LastGetPointDate = 0x7179,//最后一次获得活跃度的日期 data
            jw2_MultiDays = 0x7180,//连续活跃天数 int
            jw2_TodayActivePoint = 0x7181,//今天获得的活跃度点数 int
            jw2_activepoint = 0x7182,//活跃度 int

            TIMEBegin = 0x0633,
            TIMEEend = 0x0634,

            jw2_pic_Name = 0x7183,//图片名称 string 

            jw2_Wedding_Home = 0x7184,//礼堂名称 int (500,浪漫小屋;700,温馨小筑;1000,豪华宫殿)

            jw2_frmLove = 0x7185,//亲密度 int
            jw2_petaggName = 0x7186,//宠物蛋名 string
            jw2_petaggID = 0x7187,//宠物蛋ID	int
            jw2_petGetTime = 0x7188,//孵化时间  string
            jw2_useLove = 0x7189,//消耗亲密度 int
            jw2_getTime = 0x7190,//兑换时间	 string
            jw2_FirstFamilySN = 0x7191,//申请方家族id int
            jw2_SecondFamilySN = 0x7192,//被申请方家族id int 
            jw2_FirstFamilyName = 0x7193,//申请方家族名 string
            jw2_SecondFamilyName = 0x7194,//被申请方家族名 string
            jw2_FirstFamilyMaster = 0x7195,//申请方家族族长名 string
            jw2_SecondFamilyMaster = 0x7196,//被申请方族长名 string
            jw2_FirstFamilyUseMoneyr = 0x7197,//申请方消耗基金 string
            jw2_SecondFamilyUseMoneyr = 0x7198,//被申请方消耗基金 string
            jw2_ApplyDate = 0x7199,// 申请时间  string 
            jw2_ApplyState = 0x7200,// 申请状态  string

            jw2_PetID = 0x7201,// 宠物ID	int 
            jw2_grade = 0x7202,//宠物进阶段 string 
            jw2_EggNum = 0x7203,//宠物蛋数量 int

            jw2_PetAggID_Small = 0x7204,// 小宠物蛋ID	int 
            jw2_PetAggName_Small = 0x7205,// 小宠物蛋名字	string 
            jw2_OverTimes = 0x7206,//兑换时间 string 
            
            #endregion

            #region 光线飞车
            /// <summary>
            /// 光线飞车
            /// </summary>
            RC_ServerIP = 0x0001,//TLV_String
            RC_Account = 0x0002,//TLV_String
            RC_CharName = 0x0003,//TLV_String
            RC_isPlatinum = 0x0020,//TLV_String
            RC_isUse = 0x0021,//TLV_String
            RC_Rank = 0x0005,//TLV_String
            RC_LoginIP = 0x0017,//TLV_String
            RC_Vehicle = 0x0006,//TLV_INTEGER
            RC_Level = 0x0007,//TLV_INTEGER
            RC_Sex = 0x0004,//TLV_INTEGER
            RC_Exp = 0x0008,//TLV_Money
            RC_MatchNum = 0x0009,//TLV_INTEGER
            RC_9YOUPointer = 0x0010,//TLV_INTEGER
            RC_IGroup = 0x0011,//TLV_INTEGER
            RC_Money = 0x0012,//TLV_INTEGER
            RC_PlayCounter = 0x0015,//TLV_INTEGER
            RC_UserIndexID = 0x0016,//TLV_INTEGER
            RC_ActiveCode = 0x0022,
            RC_BeginDate = 0x0018,//TLV_TimeStamp
            RC_EndDate = 0x0019,//TLV_TimeStamp
            RC_OnlineTime = 0x0013,//TLV_TimeStamp
            RC_OfflineTime = 0x0014,//TLV_TimeStamp
            RC_UseDate = 0x0023,
            RC_Split_IForce = 0x0024,//TLV_INTEGER 阵营
            RC_IRunDistance = 0x0025,//TLV_INTEGER 总行驶距离
            RC_ILostConnection = 0x0026,//TLV_INTEGER 掉线次数
            RC_IEscapeCounter = 0x0027,//TLV_INTEGER 跳跑次数
            RC_IWinCounter = 0x0028,//TLV_INTEGER 获胜的次数
            RC_IGameMoney = 0x0029,//TLV_INTEGER 游戏币
            RC_AllOnlineTime = 0x0030,//TLV_INTEGER 在线时长
            RC_Sys_timeLastLogout = 0x0031,//TLV_TimeStamp 最后一次退出时间
            RC_Sys_ILastLoginIp = 0x0032,//TLV_String 最后一次登陆IP
            RC_BanDate = 0x0033,//TLV_DATE 封停时间
            RC_BanReason = 0x0034,//TLV_string 封停理由
            RC_State = 0x0035,
            RC_ID = 0x0036,
            RC_chName = 0x0063,
            RC_chAccount = 0x0064,
            RC_Car_Level = 0x0037,
            RC_Pref_DM = 0x0038,
            RC_Add_Nos = 0x0039,
            RC_Pref_TS = 0x0040,
            RC_Pref_OS = 0x0041,
            RC_Pref_TR = 0x0042,
            RC_Pref_AF = 0x0043,
            RC_Pref_AB = 0x0044,
            RC_BodyKit = 0x0045,
            RC_BodyKit_Front = 0x0046,
            RC_BodyKit_Middle = 0x0047,
            RC_BodyKit_Rear = 0x0048,
            RC_BodyKit_Hood = 0x0049,
            RC_BodyKit_Wing = 0x0050,
            RC_BodyKit_Wheel = 0x0051,
            RC_Tex_TailLogo = 0x0052,
            RC_Tex_Diffuse = 0x0053,
            RC_Color_Body = 0x0054,
            RC_Color_Wheel = 0x0055,
            RC_Color_Glass = 0x0056,
            RC_Color_Tyre = 0x0057,
            RC_isAdult = 0x0058,
            RC_CreatDate = 0x0059,
            RC_UserNick = 0x0060,
            RC_playerSectionInfo = 0x0071,
            RC_changedValue = 0x0072,
            RC_ItemType = 0x0073,
            RC_ItemID = 0x0074,
            RC_BuyTime = 0x0075,
            RC_ItemName = 0x0062,
            RC_ItemCode = 0x0061,
            RayCity_GuildPoint = 0x2198,
            RayCity_CarIDX = 0x2001,
            RayCity_CharacterID = 0x2002,
            RayCity_CarID = 0x2003,
            RayCity_CarName = 0x2004,
            RayCity_CarType = 0x2005,
            RayCity_LastEquipInventoryIDX = 0x2006,
            RayCity_CarState = 0x2007,
            RayCity_CreateDate = 0x2008,
            RayCity_LastUpdateDate = 0x2009,
            RayCity_AccountID = 0x2011,
            RayCity_CharacterName = 0x2012,
            RayCity_RecentMailIDX = 0x2013,
            RayCity_RecentGiftIDX = 0x2014,
            RayCity_LastUseCarIDX = 0x2015,
            RayCity_GarageIDX = 0x2016,
            RayCity_LastTutorialID = 0x2017,
            RayCity_CharacterState = 0x2018,
            RayCity_FriendIDX = 0x2019,
            RayCity_FriendCharacterID = 0x2020,
            RayCity_FriendCharacterName = 0x2021,
            RayCity_FriendGroupIDX = 0x2022,
            RayCity_FriendState = 0x2023,
            RayCity_FriendGroupName = 0x2024,
            RayCity_FriendGroupType = 0x2025,
            RayCity_FriendGroupState = 0x2026,
            RayCity_CarInventoryIDX = 0x2028,
            RayCity_InventoryType = 0x2029,
            RayCity_MaxInventorySize = 0x2030,
            RayCity_CurrentInventorySize = 0x2031,
            RayCity_QuestLogIDX = 0x2032,
            RayCity_QuestID = 0x2033,
            RayCity_QuestState = 0x2034,
            RayCity_DealLogIDX = 0x2010,
            RayCity_ItemID = 0x2035,
            RayCity_BuyDealClientID = 0x2036,
            RayCity_SellDealClientID = 0x2037,
            RayCity_BuyPrice = 0x2038,
            RayCity_SellPrice = 0x2039,
            RayCity_DealLogState = 0x2040,
            RayCity_QuestOJTLogIDX = 0x2041,
            RayCity_QuestOJTIDX = 0x2042,
            RayCity_TaskValue = 0x2043,
            RayCity_ExecuteCount = 0x2044,
            RayCity_QuestOJTState = 0x2045,
            RayCity_CharacterLevel = 0x2046,
            RayCity_CharacterExp = 0x2047,
            RayCity_CharacterMoney = 0x2048,
            RayCity_CharacterMileage = 0x2049,
            RayCity_MaxCombo = 0x2050,
            RayCity_MaxSP = 0x2051,
            RayCity_MaxMailCount = 0x2052,
            RayCity_CurMailCount = 0x2053,
            RayCity_CurrentRP = 0x2054,
            RayCity_AccumulatedRP = 0x2055,
            RayCity_RelaxGauge = 0x2056,
            RayCity_StartPos_TownCode = 0x2057,
            RayCity_StartPos_FieldCode = 0x2058,
            RayCity_StartPos_X = 0x2059,
            RayCity_StartPos_Y = 0x2060,
            RayCity_StartPos_Z = 0x2061,
            RayCity_DealInventoryItemIDX = 0x2062,
            RayCity_InventoryCellNo = 0x2063,
            RayCity_DealInventoryItemState = 0x2065,
            RayCity_CarLevel = 0x2066,
            RayCity_CarExp = 0x2067,
            RayCity_CarMileage = 0x2068,
            RayCity_FuelQuantity = 0x2069,
            RayCity_MissionLogIDX = 0x2070,
            RayCity_MissionID = 0x2071,
            RayCity_TotMissionCnt = 0x2072,
            RayCity_TotMissionSuccessCnt = 0x2073,
            RayCity_TotMissionFailCnt = 0x2074,
            RayCity_TotEXP = 0x2075,
            RayCity_TotCarEXP = 0x2076,
            RayCity_TotIncoming = 0x2077,
            RayCity_BingoCardIDX = 0x2078,
            RayCity_BingoCardID = 0x2079,
            RayCity_BingoRewardType = 0x2080,
            RayCity_BingoRewardValue = 0x2081,
            RayCity_BingoRewardAmount = 0x2082,
            RayCity_BingoCardState = 0x2083,
            RayCity_NyUserID = 0x2084,
            RayCity_NyPassword = 0x2085,
            RayCity_NyNickName = 0x2086,
            RayCity_NyGender = 0x2087,
            RayCity_NyBirthYear = 0x2088,
            RayCity_AccountState = 0x2089,
            RayCity_CharacterType = 0x2090,
            RayCity_TotPlayTime = 0x2092,
            RayCity_LoginCount = 0x2093,
            RayCity_LastLoginTime = 0x2094,
            RayCity_LastLogoutTime = 0x2095,
            RayCity_LastLoginIPPrv = 0x2096,
            RayCity_LastLoginIPPub = 0x2097,
            RayCity_TodayPlayTime = 0x2098,
            RayCity_TodayOfflineTime = 0x2099,
            RayCity_IsLogin = 0x2100,
            RayCity_GuildMemberIDX = 0x2101,
            RayCity_GuildGroupIDX = 0x2102,
            RayCity_GuildMemberState = 0x2103,
            RayCity_GuildGroupName = 0x2104,
            RayCity_GuildGroupRole = 0x2105,
            RayCity_GuildGroupState = 0x2106,
            RayCity_GuildIDX = 0x2107,
            RayCity_GuildName = 0x2108,
            RayCity_GuildMessage = 0x2109,
            RayCity_MaxGuildMember = 0x2110,
            RayCity_CurGuildMember = 0x2111,
            RayCity_IncreaseItemCount = 0x2112,
            RayCity_TrackRaceWin = 0x2113,
            RayCity_TrackRaceLose = 0x2114,
            RayCity_FieldRaceWin = 0x2115,
            RayCity_FieldRaceLose = 0x2116,
            RayCity_GuildState = 0x2117,
            RayCity_ServerIP = 0x2118,
            RayCity_SoloRaceWin = 0x2119,
            RayCity_SoloRaceLose = 0x2120,
            RayCity_SoloRaceRetire = 0x2121,
            RayCity_TeamRaceWin = 0x2122,
            RayCity_TeamRaceLose = 0x2123,
            RayCity_FieldSoloRaceWin = 0x2124,
            RayCity_FieldSoloRaceLose = 0x2125,
            RayCity_FieldSoloRaceRetire = 0x2126,
            RayCity_FieldTeamRaceWin = 0x2127,
            RayCity_FieldTeamRaceLose = 0x2128,
            RayCity_ConnectionLogIDX = 0x2129,
            RayCity_ConnectionLogKey = 0x2130,
            RayCity_ServerID = 0x2131,
            RayCity_IPAddress = 0x2132,
            RayCity_ActionType = 0x2133,
            RayCity_ItemName = 0x2134,
            RayCity_BeginDate = 0x2135,
            RayCity_EndDate = 0x2136,
            RayCity_Title = 0x2137,
            RayCity_Message = 0x2138,
            RayCity_ItemIDX = 0x2139,
            RayCity_Bonding = 0x2140,
            RayCity_MaxEndurance = 0x2141,
            RayCity_CurEndurance = 0x2142,
            RayCity_ExpireDate = 0x2143,
            RayCity_ItemOption1 = 0x2144,
            RayCity_ItemOption2 = 0x2145,
            RayCity_ItemOption3 = 0x2146,
            RayCity_ItemState = 0x2147,
            RayCity_ItemPrice = 0x2148,
            RayCity_BeforeCharacterMoney = 0x2149,
            RayCity_AfterCharacterMoney = 0x2150,
            RayCity_MoneyType = 0x2151,
            RayCity_ItemBuySellLogIDX = 0x2152,
            RayCity_RewardExp = 0x2153,
            RayCity_RewardCarExp = 0x2154,
            RayCity_RewardMoney = 0x2155,
            RayCity_MissionGrade = 0x2156,
            RayCity_MissionResult = 0x2157,
            RayCity_Duration = 0x2158,
            RayCity_MoneyLogIDX = 0x2159,
            RayCity_AdjustType = 0x2160,
            RayCity_UpdateSource = 0x2161,
            RayCity_MoneyAmount = 0x2162,
            RayCity_RaceLogIDX = 0x2163,
            RayCity_RaceID = 0x2164,
            RayCity_RaceType = 0x2165,
            RayCity_TrackID = 0x2166,
            RayCity_RewardRP_RankBase = 0x2167,
            RayCity_RewardRP_TimeBase = 0x2168,
            RayCity_Rank = 0x2170,
            RayCity_RaceTime = 0x2171,
            RayCity_RaceResult = 0x2172,
            RayCity_FixedTime = 0x2173,
            RayCity_SkillID = 0x2174,
            RayCity_SkillName = 0x2175,
            RayCity_SkillLevel = 0x2176,
            RayCity_SkillIDX = 0x2177,
            RayCity_ItemTypeID = 0x2178,
            RayCity_ItemTypeName = 0x2179,
            RayCity_TradeWaitItemIDX = 0x2180,
            RayCity_CarInventoryItemIDX = 0x2181,
            RayCity_TradeWaitCellNo = 0x2182,
            RayCity_TargetCarInventoryIDX = 0x2183,
            RayCity_TargetInventoryCellNo = 0x2184,
            RayCity_TradeWaitItemState = 0x2185,
            RayCity_TradeSessionIDX = 0x2186,
            RayCity_TargetTradeSessionIDX = 0x2187,
            RayCity_TargetCharacterID = 0x2188,
            RayCity_TradeMoney = 0x2189,
            RayCity_TradeSessionState = 0x2190,
            RayCity_ActionTypeName = 0x2191,
            RayCity_StartNum = 0x2192,
            RayCity_EndNum = 0x2193,
            RayCity_NyCashChargeLogIDX = 0x2194,
            RayCity_NyPayID = 0x2195,
            RayCity_ChargeAmount = 0x2196,
            RayCity_ChargeState = 0x2197,
            RayCity_SendDate = 0x3150,//发送日期
            RayCity_FromCharacterID = 0x3143,
            RayCity_FromCharacterName = 0x3144,
            RayCity_PaymentType = 0x3145,
            RayCity_CashItemLogIDX = 0x3146,
            RayCity_StockID = 0x3147,
            RayCity_GiftMessage = 0x3148,
            RayCity_GiftState = 0x3149,
            RayCity_QuestName = 0x3142,
            RayCity_NyCashBalance = 0x2091, //余额 INT
            RayCity_TargetName = 0x2199,

            RayCity_CouponIDX = 0x3151, //序列号
            RayCity_CountryCode = 0x3152,
            RayCity_CouponName = 0x3153,
            RayCity_IssueCount = 0x3154,
            RayCity_StartDate = 0x3155,
            RayCity_CouponState = 0x3156,
            RayCity_CouponNumber = 0x3157,
            RayCity_IssueCouponIDX = 0x3158,

            RayCity_rccdkey = 0x3159,
            RayCity_getuser = 0x3160,
            RayCity_gettime = 0x3161,
            RayCity_use_state = 0x3162,
            RayCity_activename = 0x3163,
            RayCity_Interval = 0x3164,//TLV_INTEGER
            RayCity_NoticeID = 0x3165,//TLV_INTEGER
            RayCity_Repeat = 0x3166,//TLV_INTEGER  重复次数
            RC_ItemInstanceID = 0x9015,
            RC_SenderID = 0x9016,
            RC_SenderOperation = 0x9017,
            RC_ReceiverID = 0x9018,
            RC_ReceiveTime = 0x9019,
            RC_ReceiverOperation = 0x9020,

            RC_PlayerID = 0x9021,
            RC_PlayerOperation = 0x9022,
            RC_OperationTime = 0x9023,
            RC_MoneyCount = 0x9024,
            RC_login_account = 0x9025,
            RC_state_number = 0x9026,
            RC_usernick = 0x9027,
            RC_DBname = 0x9028,
            RC_TimeLoop = 0x9029,
            RC_Text = 0x9030,
            RC_ChannelServerID = 0x9031,
            RC_MultipleType = 0x9032,
            RC_MultipleValue = 0x9033,
            RC_UseAccount = 0x9034,
            RC_GlobalAccount = 0x9035,
            RC_UseTime = 0x9036,
            RC_ActiveTime = 0x9037,
            RC_chNotes = 0x9039,

            RC_CurrentPartnerID = 0x9041, //int
            RC_CurrentTitleID = 0x9042,
            RC_I9youMoney = 0x9043,//int M币 

            RC_OperationType = 0x9056,//int
            RC_ItemBigType = 0x9057,//int
            RC_TeamID = 0x9058,
            RC_Job = 0x9060,
            RC_JoinTime = 0x9061,
            RC_Name = 0x9062,
            RC_TeamLevel = 0x9063,
            RC_FoundTime = 0x9064,
            RC_Founder = 0x9065,
            RC_Picture = 0x9066,
            RC_OnlinePercent = 0x9067,
            RC_Distance = 0x9068,
            RC_Pronouncement = 0x9069,
            RC_Bulletin = 0x9070,
            #endregion
            FJ_BoardFlag = 0x1858,//Format:INT 状态
            FJ_Sex = 0x1803,
            FJ_descr = 0x1958,

            ERROR_Msg = 0xFFFF //Format:STRING  验证用户的信息
        }
        /// <summary>
        /// 参数类型标签
        /// </summary>
        public enum TagFormat : byte
        {
            TLV_STRING = 0,
            TLV_MONEY = 1,
            TLV_DATE = 2,
            TLV_INTEGER = 3,
            TLV_EXTEND = 4,
            TLV_NUMBER = 5,
            TLV_TIME = 6,
            TLV_TIMESTAMP = 7,
            TLV_BOOLEAN = 8,
            TLV_UNICODE = 9,
        }
        /// <summary>
        /// 操作命令标签
        /// </summary>
        public enum ServiceKey : ushort
        {
            /// <summary>
            /// 公共模块(0x80)
            /// </summary>
            CONNECT = 0x0001,
            CONNECT_RESP = 0x8001,
            DISCONNECT = 0x0002,
            DISCONNECT_RESP = 0x8002,
            ACCOUNT_AUTHOR = 0x0003,
            ACCOUNT_AUTHOR_RESP = 0x8003,

            SERVERINFO_IP_QUERY = 0x0004,
            SERVERINFO_IP_QUERY_RESP = 0x8004,
            GMTOOLS_OperateLog_Query = 0x0005,//查看工具操作记录
            GMTOOLS_OperateLog_Query_RESP = 0x8005,//查看工具操作记录响应
            SERVERINFO_IP_ALL_QUERY = 0x0006,//查看所有游戏服务器地址
            SERVERINFO_IP_ALL_QUERY_RESP = 0x8006,//查看所有游戏服务器地址响应
            LINK_SERVERIP_CREATE = 0x0007,//添加游戏链接数据库
            LINK_SERVERIP_CREATE_RESP = 0x8007,//添加游戏链接数据库响应
            CLIENT_PATCH_COMPARE = 0x0008,
            CLIENT_PATCH_COMPARE_RESP = 0x8008,
            CLIENT_PATCH_UPDATE = 0x0009,
            CLIENT_PATCH_UPDATE_RESP = 0x8009,

            /// <summary>
            ///用户管理模块(0x81) 
            /// </summary>
            USER_CREATE = 0x0001,
            USER_CREATE_RESP = 0x8001,
            USER_UPDATE = 0x0002,
            USER_UPDATE_RESP = 0x8002,
            USER_DELETE = 0x0003,
            USER_DELETE_RESP = 0x8003,
            USER_QUERY = 0x0004,
            USER_QUERY_RESP = 0x8004,
            USER_PASSWD_MODIF = 0x0005,
            USER_PASSWD_MODIF_RESP = 0x8005,
            USER_QUERY_ALL = 0x0006,
            USER_QUERY_ALL_RESP = 0x8006,
            DEPART_QUERY = 0x0007,
            DEPART_QUERY_RESP = 0x8007,
            UPDATE_ACTIVEUSER = 0x0008,//更新在线用户状态
            UPDATE_ACTIVEUSER_RESP = 0x8008,//更新在线用户状态响应

            /// <summary>
            /// 模块管理(0x82)
            /// </summary>
            MODULE_CREATE = 0x0001,
            MODULE_CREATE_RESP = 0x8001,
            MODULE_UPDATE = 0x0002,
            MODULE_UPDATE_RESP = 0x8002,
            MODULE_DELETE = 0x0003,
            MODULE_DELETE_RESP = 0x8003,
            MODULE_QUERY = 0x0004,
            MODULE_QUERY_RESP = 0x8004,

            /// <summary>
            /// 用户与模块(0x83) 
            /// </summary>
            USER_MODULE_CREATE = 0x0001,
            USER_MODULE_CREATE_RESP = 0x8001,
            USER_MODULE_UPDATE = 0x0002,
            USER_MODULE_UPDATE_RESP = 0x8002,
            USER_MODULE_DELETE = 0x0003,
            USER_MODULE_DELETE_RESP = 0x8003,
            USER_MODULE_QUERY = 0x0004,
            USER_MODULE_QUERY_RESP = 0x8004,

            /// <summary>
            /// 游戏管理(0x84) 
            /// </summary>
            GAME_CREATE = 0x0001,
            GAME_CREATE_RESP = 0x8001,
            GAME_UPDATE = 0x0002,
            GAME_UPDATE_RESP = 0x8002,
            GAME_DELETE = 0x0003,
            GAME_DELETE_RESP = 0x8003,
            GAME_QUERY = 0x0004,
            GAME_QUERY_RESP = 0x8004,
            GAME_MODULE_QUERY = 0x0005,
            GAME_MODULE_QUERY_RESP = 0x8005,

            /// <summary>
            /// NOTES管理(0x85) 
            /// </summary>
            NOTES_LETTER_TRANSFER = 0x0001,
            NOTES_LETTER_TRANSFER_RESP = 0x8001,
            NOTES_LETTER_PROCESS = 0x0002, //邮件处理
            NOTES_LETTER_PROCESS_RESP = 0x8002,//邮件处理
            NOTES_LETTER_TRANSMIT = 0x0003,//邮件转发
            NOTES_LETTER_TRANSMIT_RESP = 0x8003,//邮件转发响应

            /// <summary>
            /// 猛将GM工具管理(0x86)
            /// </summary>
            MJ_CHARACTERINFO_QUERY = 0x0001,//检查玩家状态
            MJ_CHARACTERINFO_QUERY_RESP = 0x8001,//检查玩家状态响应
            MJ_CHARACTERINFO_UPDATE = 0x0002,//修改玩家状态
            MJ_CHARACTERINFO_UPDATE_RESP = 0x8002,//修改玩家状态响应
            MJ_LOGINTABLE_QUERY = 0x0003,//检查玩家是否在线
            MJ_LOGINTABLE_QUERY_RESP = 0x8003,//检查玩家是否在线响应
            MJ_CHARACTERINFO_EXPLOIT_UPDATE = 0x0004,//修改功勋值
            MJ_CHARACTERINFO_EXPLOIT_UPDATE_RESP = 0x8004,//修改功勋值响应
            MJ_CHARACTERINFO_FRIEND_QUERY = 0x0005,//列出好友名单
            MJ_CHARACTERINFO_FRIEND_QUERY_RESP = 0x8005,//列出好有名单响应
            MJ_CHARACTERINFO_FRIEND_CREATE = 0x0006,//添加好友
            MJ_CHARACTERINFO_FRIEND_CREATE_RESP = 0x8006,//添加好友响应
            MJ_CHARACTERINFO_FRIEND_DELETE = 0x0007,//删除好友
            MJ_CHARACTERINFO_FRIEND_DELETE_RESP = 0x8007,//删除好友响应
            MJ_GUILDTABLE_UPDATE = 0x0008,//修改服务器所有已存在帮会
            MJ_GUILDTABLE_UPDATE_RESP = 0x8008,//修改服务器所有已存在帮会响应
            MJ_ACCOUNT_LOCAL_CREATE = 0x0009,//将服务器上的account表里的玩家信息保存到本地服务器的
            MJ_ACCOUNT_LOCAL_CREATE_RESP = 0x8009,//将服务器上的account表里的玩家信息保存到本地服务器的响应
            MJ_ACCOUNT_REMOTE_DELETE = 0x0010,//永久封停帐号
            MJ_ACCOUNT_REMOTE_DELETE_RESP = 0x8010,//永久封停帐号的响应
            MJ_ACCOUNT_REMOTE_RESTORE = 0x0011,//解封帐号
            MJ_ACCOUNT_REMOTE_RESTORE_RESP = 0x8011,//解封帐号响应
            MJ_ACCOUNT_LIMIT_RESTORE = 0x0012,//有时限的封停
            MJ_ACCOUNT_LIMIT_RESTORE_RESP = 0x8012,//有时限的封停响应
            MJ_ACCOUNTPASSWD_LOCAL_CREATE = 0x0013,//保存玩家密码到本地 
            MJ_ACCOUNTPASSWD_LOCAL_CREATE_RESP = 0x8013,//保存玩家密码到本地
            MJ_ACCOUNTPASSWD_REMOTE_UPDATE = 0x0014,//修改玩家密码 
            MJ_ACCOUNTPASSWD_REMOTE_UPDATE_RESP = 0x8014,//修改玩家密码
            MJ_ACCOUNTPASSWD_REMOTE_RESTORE = 0x0015,//恢复玩家密码
            MJ_ACCOUNTPASSWD_REMOTE_RESTORE_RESP = 0x8015,//恢复玩家密码
            MJ_ITEMLOG_QUERY = 0x0016,//检查该用户交易记录
            MJ_ITEMLOG_QUERY_RESP = 0x8016,//检查该用户交易记录
            MJ_GMTOOLS_LOG_QUERY = 0x0017,//检查使用者操作记录
            MJ_GMTOOLS_LOG_QUERY_RESP = 0x8017,//检查使用者操作记录
            MJ_MONEYSORT_QUERY = 0x0018,//根据金钱排序
            MJ_MONEYSORT_QUERY_RESP = 0x8018,//根据金钱排序的响应
            MJ_LEVELSORT_QUERY = 0x0019,//根据等级排序
            MJ_LEVELSORT_QUERY_RESP = 0x8019,//根据等级排序的响应
            MJ_MONEYFIGHTERSORT_QUERY = 0x0020,//根据不同职业金钱排序
            MJ_MONEYFIGHTERSORT_QUERY_RESP = 0x8020,//根据不同职业金钱排序的响应
            MJ_LEVELFIGHTERSORT_QUERY = 0x0021,//根据不同职业等级排序
            MJ_LEVELFIGHTERSORT_QUERY_RESP = 0x8021,//根据不同职业等级排序的响应
            MJ_MONEYTAOISTSORT_QUERY = 0x0022,//根据道士金钱排序
            MJ_MONEYTAOISTSORT_QUERY_RESP = 0x8022,//根据道士金钱排序的响应
            MJ_LEVELTAOISTSORT_QUERY = 0x0023,//根据道士等级排序
            MJ_LEVELTAOISTSORT_QUERY_RESP = 0x8023,//根据道士等级排序的响应
            MJ_MONEYRABBISORT_QUERY = 0x0024,//根据法师金钱排序
            MJ_MONEYRABBISORT_QUERY_RESP = 0x8024,//根据法师金钱排序的响应
            MJ_LEVELRABBISORT_QUERY = 0x0025,//根据法师等级排序
            MJ_LEVELRABBISORT_QUERY_RESP = 0x8025,//根据法师等级排序的响应
            MJ_ACCOUNT_QUERY = 0x0026,//猛将帐号查询
            MJ_ACCOUNT_QUERY_RESP = 0x8026,//猛将帐号查询响应
            MJ_ACCOUNT_LOCAL_QUERY = 0x0027,//查询猛将本地帐号
            MJ_ACCOUNT_LOCAL_QUERY_RESP = 0x8027,//查询猛将本地帐号响应

            /// <summary>
            /// SDO_ADMIN 超级舞者工具操作消息集
            /// </summary>
            SDO_ACCOUNT_QUERY = 0x0026,//查看玩家的帐号信息
            SDO_ACCOUNT_QUERY_RESP = 0x8026,//查看玩家的帐号信息响应
            SDO_CHARACTERINFO_QUERY = 0x0027,//查看任务资料的信息
            SDO_CHARACTERINFO_QUERY_RESP = 0x8027,//查看人物资料的信息响应
            SDO_ACCOUNT_CLOSE = 0x0028,//封停帐户的权限信息
            SDO_ACCOUNT_CLOSE_RESP = 0x8028,//封停帐户的权限信息响应
            SDO_ACCOUNT_OPEN = 0x0029,//解封帐户的权限信息
            SDO_ACCOUNT_OPEN_RESP = 0x8029,//解封帐户的权限信息响应
            SDO_PASSWORD_RECOVERY = 0x0030,//玩家找回密码
            SDO_PASSWORD_RECOVERY_RESP = 0x8030,//玩家找回密码响应
            SDO_CONSUME_QUERY = 0x0031,//查看玩家的消费记录
            SDO_CONSUME_QUERY_RESP = 0x8031,//查看玩家的消费记录响应
            SDO_USERONLINE_QUERY = 0x0032,//查看玩家上下线状态
            SDO_USERONLINE_QUERY_RESP = 0x8032,//查看玩家上下线状态响应
            SDO_USERTRADE_QUERY = 0x0033,//查看玩家交易状态
            SDO_USERTRADE_QUERY_RESP = 0x8033,//查看玩家交易状态响应
            SDO_CHARACTERINFO_UPDATE = 0x0034,//修改玩家的账号信息
            SDO_CHARACTERINFO_UPDATE_RESP = 0x8034,//修改玩家的账号信息响应
            SDO_ITEMSHOP_QUERY = 0x0035,//查看游戏里面所有道具信息
            SDO_ITEMSHOP_QUERY_RESP = 0x8035,//查看游戏里面所有道具信息响应
            SDO_ITEMSHOP_DELETE = 0x0036,//删除玩家道具信息
            SDO_ITEMSHOP_DELETE_RESP = 0x8036,//删除玩家道具信息响应
            SDO_GIFTBOX_CREATE = 0x0037,//添加玩家礼物盒道具信息
            SDO_GIFTBOX_CREATE_RESP = 0x8037,//添加玩家礼物盒道具信息响应
            SDO_GIFTBOX_QUERY = 0x0038,//查看玩家礼物盒的道具
            SDO_GIFTBOX_QUERY_RESP = 0x8038,//查看玩家礼物盒的道具响应
            SDO_GIFTBOX_DELETE = 0x0039,//删除玩家礼物盒的道具
            SDO_GIFTBOX_DELETE_RESP = 0x8039,//删除玩家礼物盒的道具响应
            SDO_USERLOGIN_STATUS_QUERY = 0x0040,//查看玩家登录状态
            SDO_USERLOGIN_STATUS_QUERY_RESP = 0x8040,//查看玩家登录状态响应
            SDO_ITEMSHOP_BYOWNER_QUERY = 0x0041,////查看玩家身上道具信息
            SDO_ITEMSHOP_BYOWNER_QUERY_RESP = 0x8041,////查看玩家身上道具信息
            SDO_ITEMSHOP_TRADE_QUERY = 0x0042,//查看玩家交易记录信息
            SDO_ITEMSHOP_TRADE_QUERY_RESP = 0x8042,//查看玩家交易记录信息的响应
            SDO_MEMBERSTOPSTATUS_QUERY = 0x0043,//查看该帐号状态
            SDO_MEMBERSTOPSTATUS_QUERY_RESP = 0x8043,///查看该帐号状态的响应
            SDO_MEMBERBANISHMENT_QUERY = 0x0044,//查看所有停封的帐号
            SDO_MEMBERBANISHMENT_QUERY_RESP = 0x8044,//查看所有停封的帐号响应
            SDO_USERMCASH_QUERY = 0x0045,//玩家充值记录查询
            SDO_USERMCASH_QUERY_RESP = 0x8045,//玩家充值记录查询响应
            SDO_USERGCASH_UPDATE = 0x0046,//补偿玩家G币
            SDO_USERGCASH_UPDATE_RESP = 0x8046,//补偿玩家G币的响应
            SDO_MEMBERLOCAL_BANISHMENT = 0x0047,//本地保存停封信息
            SDO_MEMBERLOCAL_BANISHMENT_RESP = 0x8047,//本地保存停封信息响应
            SDO_EMAIL_QUERY = 0x0048,//得到玩家的EMAIL
            SDO_EMAIL_QUERY_RESP = 0x8048,//得到玩家的EMAIL响应
            SDO_USERCHARAGESUM_QUERY = 0x0049,//得到充值记录总和
            SDO_USERCHARAGESUM_QUERY_RESP = 0x8049,//得到充值记录总和响应
            SDO_USERCONSUMESUM_QUERY = 0x0050,//得到消费记录总和
            SDO_USERCONSUMESUM_QUERY_RESP = 0x8050,//得到消费记录总和响应
            SDO_USERGCASH_QUERY = 0x0051,//玩家?币记录查询
            SDO_USERGCASH_QUERY_RESP = 0x8051,//玩家?币记录查询响应

            SDO_USERNICK_UPDATE = 0x0069,
            SDO_USERNICK_UPDATE_RESP = 0x8069,

            SDO_PADKEYWORD_QUERY = 0x0070,
            SDO_PADKEYWORD_QUERY_RESP = 0x8070,

            SDO_BOARDMESSAGE_REQ = 0x0071,
            SDO_BOARDMESSAGE_REQ_RESP = 0x8071,

            SDO_CHANNELLIST_QUERY = 0x0072,
            SDO_CHANNELLIST_QUERY_RESP = 0x8072,
            SDO_ALIVE_REQ = 0x0073,
            SDO_ALIVE_REQ_RESP = 0x8073,

            SDO_BOARDTASK_QUERY = 0x0074,
            SDO_BOARDTASK_QUERY_RESP = 0x8074,

            SDO_BOARDTASK_UPDATE = 0x0075,
            SDO_BOARDTASK_UPDATE_RESP = 0x8075,

            SDO_BOARDTASK_INSERT = 0x0076,
            SDO_BOARDTASK_INSERT_RESP = 0x8076,
            SDO_DAYSLIMIT_QUERY = 0x0077,//有效期查询
            SDO_DAYSLIMIT_QUERY_RESP = 0x8077,
            SDO_FRIENDS_QUERY = 0x0078,//
            SDO_FRIENDS_QUERY_RESP = 0x8078,

            SDO_USERLOGIN_DEL = 0x0079,
            SDO_USERLOGIN_DEL_RESP = 0x8079,
            SDO_USERLOGIN_CLEAR = 0x0080,
            SDO_USERLOGIN_CLEAR_RESP = 0x8080,
            SDO_GATEWAY_QUERY = 0x0081,
            SDO_GATEWAY_QUERY_RESP = 0x8081,

            SDO_USERINTEGRAL_QUERY = 0x0082,
            SDO_USERINTEGRAL_QUERY_RESP = 0x8082,

            SDO_StageAward_Query = 0x0111,
            SDO_StageAward_Query_RESP = 0x8111,
            SDO_StageAward_Create = 0x0112,
            SDO_StageAward_Create_RESP = 0x8112,
            SDO_StageAward_Delete = 0x0113,
            SDO_StageAward_Delete_RESP = 0x8113,
            SDO_StageAward_Update = 0x0114,
            SDO_StageAward_Update_RESP = 0x8114,
            SDO_BAOXIANGRate_Query = 0x0120,
            SDO_BAOXIANGRate_Query_RESP = 0x8120,
            SDO_BAOXIANGRate_Update = 0x0121,
            SDO_BAOXIANGRate_Update_RESP = 0x8121,
            /// <summary>
            /// AU_ADMIN 劲舞团工具操作消息集
            /// </summary>
            AU_ACCOUNT_QUERY = 0x0001,//玩家帐号信息查询
            AU_ACCOUNT_QUERY_RESP = 0x8001,//玩家帐号信息查询响应
            AU_ACCOUNTREMOTE_QUERY = 0x0002,//游戏服务器封停的玩家帐号查询
            AU_ACCOUNTREMOTE_QUERY_RESP = 0x8002,//游戏服务器封停的玩家帐号查询响应
            AU_ACCOUNTLOCAL_QUERY = 0x0003,//本地封停的玩家帐号查询
            AU_ACCOUNTLOCAL_QUERY_RESP = 0x8003,//本地封停的玩家帐号查询响应
            AU_ACCOUNT_CLOSE = 0x0004,//封停的玩家帐号
            AU_ACCOUNT_CLOSE_RESP = 0x8004,//封停的玩家帐号响应
            AU_ACCOUNT_OPEN = 0x0005,//解封的玩家帐号
            AU_ACCOUNT_OPEN_RESP = 0x8005,//解封的玩家帐号响应
            AU_ACCOUNT_BANISHMENT_QUERY = 0x0006,//玩家封停帐号查询
            AU_ACCOUNT_BANISHMENT_QUERY_RESP = 0x8006,//玩家封停帐号查询响应
            AU_CHARACTERINFO_QUERY = 0x0007,//查询玩家的账号信息
            AU_CHARACTERINFO_QUERY_RESP = 0x8007,//查询玩家的账号信息响应
            AU_CHARACTERINFO_UPDATE = 0x0008,//修改玩家的账号信息
            AU_CHARACTERINFO_UPDATE_RESP = 0x8008,//修改玩家的账号信息响应
            AU_ITEMSHOP_QUERY = 0x0009,//查看游戏里面所有道具信息
            AU_ITEMSHOP_QUERY_RESP = 0x8009,//查看游戏里面所有道具信息响应
            AU_ITEMSHOP_DELETE = 0x0010,//删除玩家道具信息
            AU_ITEMSHOP_DELETE_RESP = 0x8010,//删除玩家道具信息响应
            AU_ITEMSHOP_BYOWNER_QUERY = 0x0011,////查看玩家身上道具信息
            AU_ITEMSHOP_BYOWNER_QUERY_RESP = 0x8011,////查看玩家身上道具信息
            AU_ITEMSHOP_TRADE_QUERY = 0x0012,//查看玩家交易记录信息
            AU_ITEMSHOP_TRADE_QUERY_RESP = 0x8012,//查看玩家交易记录信息的响应
            AU_ITEMSHOP_CREATE = 0x0013,//添加玩家礼物盒道具信息
            AU_ITEMSHOP_CREATE_RESP = 0x8013,//添加玩家礼物盒道具信息响应
            AU_LEVELEXP_QUERY = 0x0014,//查看玩家等级经验
            AU_LEVELEXP_QUERY_RESP = 0x8014,////查看玩家等级经验响应
            AU_USERLOGIN_STATUS_QUERY = 0x0015,//查看玩家登录状态
            AU_USERLOGIN_STATUS_QUERY_RESP = 0x8015,//查看玩家登录状态响应
            AU_USERCHARAGESUM_QUERY = 0x0016,//得到充值记录总和
            AU_USERCHARAGESUM_QUERY_RESP = 0x8016,//得到充值记录总和响应
            AU_CONSUME_QUERY = 0x0017,//查看玩家的消费记录
            AU_CONSUME_QUERY_RESP = 0x8017,//查看玩家的消费记录响应
            AU_USERCONSUMESUM_QUERY = 0x0018,//得到消费记录总和
            AU_USERCONSUMESUM_QUERY_RESP = 0x8018,//得到消费记录总和响应
            AU_USERMCASH_QUERY = 0x0019,//玩家充值记录查询
            AU_USERMCASH_QUERY_RESP = 0x8019,//玩家充值记录查询响应
            AU_USERGCASH_QUERY = 0x0020,//玩家?币记录查询
            AU_USERGCASH_QUERY_RESP = 0x8020,//玩家?币记录查询响应
            AU_USERGCASH_UPDATE = 0x0021,//补偿玩家G币
            AU_USERGCASH_UPDATE_RESP = 0x8021,//补偿玩家G币的响应


            Au_User_Msg_Query = 0x0062, //查询玩家在游戏中的聊天记录 
            Au_User_Msg_Query_Resp = 0x8062,//查询玩家在游戏中的聊天记录    

            Au_BroaditeminfoNow_Query = 0x0059,//当前时间用户发送喇叭日志
            Au_BroaditeminfoNow_Query_Resp = 0x8059,//当前时间用户发送喇叭日志

            Au_BroaditeminfoBymsg_Query = 0x0060,//内容模糊查询用户发送喇叭日志
            Au_BroaditeminfoBymsg_Query_Resp = 0x8060,//内容模糊查询用户发送喇叭日志

            AU_MsgServerinfo_Query = 0x0018,
            AU_MsgServerinfo_Query_RESP = 0x8018,
            /// <summary>
            /// CR_ADMIN 疯狂卡丁车工具操作消息集
            /// </summary>
            CR_ACCOUNT_QUERY = 0x0001,//玩家帐号信息查询
            CR_ACCOUNT_QUERY_RESP = 0x8001,//玩家帐号信息查询响应
            CR_ACCOUNTACTIVE_QUERY = 0x0002,//玩家帐号激活信息
            CR_ACCOUNTACTIVE_QUERY_RESP = 0x8002,//玩家帐号激活响应
            CR_CALLBOARD_QUERY = 0x0003,//公告信息查询
            CR_CALLBOARD_QUERY_RESP = 0x8003,//公告信息查询响应
            CR_CALLBOARD_CREATE = 0x0004,//发布公告
            CR_CALLBOARD_CREATE_RESP = 0x8004,//发布公告响应
            CR_CALLBOARD_UPDATE = 0x0005,//更新公告信息
            CR_CALLBOARD_UPDATE_RESP = 0x8005,//更新公告信息的响应
            CR_CALLBOARD_DELETE = 0x0006,//删除公告信息
            CR_CALLBOARD_DELETE_RESP = 0x8006,//删除公告信息的响应

            CR_CHARACTERINFO_QUERY = 0x0007,//玩家角色信息查询
            CR_CHARACTERINFO_QUERY_RESP = 0x8007,//玩家角色信息查询的响应
            CR_CHARACTERINFO_UPDATE = 0x0008,//玩家角色信息查询
            CR_CHARACTERINFO_UPDATE_RESP = 0x8008,//玩家角色信息查询的响应
            CR_CHANNEL_QUERY = 0x0009,//公告频道查询
            CR_CHANNEL_QUERY_RESP = 0x8009,//公告频道查询的响应
            CR_NICKNAME_QUERY = 0x0010,//玩家昵称查询
            CR_NICKNAME_QUERY_RESP = 0x8010,//玩家昵称的响应
            CR_LOGIN_LOGOUT_QUERY = 0x0011,//玩家上线、下线时间查询
            CR_LOGIN_LOGOUT_QUERY_RESP = 0x8011,//玩家上线、下线时间查询的响应
            CR_ERRORCHANNEL_QUERY = 0x0012,//补充错误公告频道查询
            CR_ERRORCHANNEL_QUERY_RESP = 0x8012,//补充错误公告频道查询的响应


            /// <summary>
            /// 充值消费GM工具(0x90)
            /// </summary>
            CARD_USERCHARGEDETAIL_QUERY = 0x0001,//一卡通查询
            CARD_USERCHARGEDETAIL_QUERY_RESP = 0x8001,//一卡通查询响应
            CARD_USERDETAIL_QUERY = 0x0002,//久之游用户注册信息查询
            CARD_USERDETAIL_QUERY_RESP = 0x8002,//久之游用户注册信息查询响应
            CARD_USERCONSUME_QUERY = 0x0003,//休闲币消费查询
            CARD_USERCONSUME_QUERY_RESP = 0x8003,//休闲币消费查询响应
            CARD_VNETCHARGE_QUERY = 0x0004,//互联星空充值查询
            CARD_VNETCHARGE_QUERY_RESP = 0x8004,//互联星空充值查询响应
            CARD_USERDETAIL_SUM_QUERY = 0x0005,//充值合计查询
            CARD_USERDETAIL_SUM_QUERY_RESP = 0x8005,//充值合计查询响应
            CARD_USERCONSUME_SUM_QUERY = 0x0006,//消费合计查询
            CARD_USERCONSUME_SUM_QUERY_RESP = 0x8006,//消费合计响应
            CARD_USERINFO_QUERY = 0x0007,//玩家注册信息查询
            CARD_USERINFO_QUERY_RESP = 0x8007,//玩家注册信息查询响应
            CARD_USERINFO_CLEAR = 0x0008,
            CARD_USERINFO_CLEAR_RESP = 0x8008,
            CARD_USERINITACTIVE_QUERY = 0x0015,//激活游戏
            CARD_USERINITACTIVE_QUERY_RESP = 0x8015,

            /// <summary>
            /// 劲舞团商城(0x91)
            /// </summary>
            AUSHOP_USERGPURCHASE_QUERY = 0x0001,//用户G币购买记录
            AUSHOP_USERGPURCHASE_QUERY_RESP = 0x8001,//用户G币购买记录
            AUSHOP_USERMPURCHASE_QUERY = 0x0002,//用户M币购买记录
            AUSHOP_USERMPURCHASE_QUERY_RESP = 0x8002,//用户M币购买记录
            AUSHOP_AVATARECOVER_QUERY = 0x0003,//道具回收兑换记
            AUSHOP_AVATARECOVER_QUERY_RESP = 0x8003,//道具回收兑换记
            AUSHOP_USERINTERGRAL_QUERY = 0x0004,//用户积分记录
            AUSHOP_USERINTERGRAL_QUERY_RESP = 0x8004,//用户积分记录

            AUSHOP_USERGPURCHASE_SUM_QUERY = 0x0005,//用户G币购买记录合计
            AUSHOP_USERGPURCHASE_SUM_QUERY_RESP = 0x8005,//用户G币购买记录合计响应
            AUSHOP_USERMPURCHASE_SUM_QUERY = 0x0006,//用户M币购买记录合计
            AUSHOP_USERMPURCHASE_SUM_QUERY_RESP = 0x8006,//用户M币购买记录合计响应

            AUSHOP_AVATARECOVER_DETAIL_QUERY = 0x0007,// 具回收兑换详细记录
            AUSHOP_AVATARECOVER_DETAIL_QUERY_RESP = 0x8007,// 具回收兑换详细记录


            DEPARTMENT_CREATE = 0x0009,//部门创建
            DEPARTMENT_CREATE_RESP = 0x8009,//部门创建响应
            DEPARTMENT_UPDATE = 0x0010,//部门修改
            DEPARTMENT_UPDATE_RESP = 0x8010,//部门修改响应
            DEPARTMENT_DELETE = 0x0011,//部门删除
            DEPARTMENT_DELETE_RESP = 0x8011,//部门删除响应
            DEPARTMENT_ADMIN = 0x0012,//部门管理
            DEPARTMENT_ADMIN_RESP = 0x8012,//部门管理响应

            /// <summary>
            /// 劲乐团工具(0x92)
            /// </summary>
            O2JAM_CHARACTERINFO_QUERY = 0x0001,//玩家角色信息查询
            O2JAM_CHARACTERINFO_QUERY_RESP = 0x8001,//玩家角色信息查询
            O2JAM_CHARACTERINFO_UPDATE = 0x0002,//玩家角色信息更新
            O2JAM_CHARACTERINFO_UPDATE_RESP = 0x8002,//玩家角色信息更新
            O2JAM_ITEM_QUERY = 0x0003,//玩家道具信息查询
            O2JAM_ITEM_QUERY_RESP = 0x8003,//玩家角色信息查询
            O2JAM_ITEM_UPDATE = 0x0004,//玩家道具信息更新
            O2JAM_ITEM_UPDATE_RESP = 0x8004,//玩家道具信息更新
            O2JAM_CONSUME_QUERY = 0x0005,//玩家消费信息查询
            O2JAM_CONSUME_QUERY_RESP = 0x8005,//玩家消费信息查询
            O2JAM_ITEMDATA_QUERY = 0x0006,// 具列表查询
            O2JAM_ITEMDATA_QUERY_RESP = 0x8006,// 具列表信息查询
            O2JAM_GIFTBOX_QUERY = 0x0007,//玩家礼物盒查询
            O2JAM_GIFTBOX_QUERY_RESP = 0x8007,//玩家礼物盒查询
            O2JAM_USERGCASH_UPDATE = 0x0008,//补偿玩家G币
            O2JAM_USERGCASH_UPDATE_RESP = 0x8008,//补偿玩家G币的响应
            O2JAM_CONSUME_SUM_QUERY = 0x0009,//玩家消费信息查询
            O2JAM_CONSUME_SUM_QUERY_RESP = 0x8009,//玩家消费信息查询
            O2JAM_GIFTBOX_CREATE_QUERY = 0x0010,//添加玩家礼物盒 具
            O2JAM_GIFTBOX_CREATE_QUERY_RESP = 0x8010,//添加玩家礼物盒 具
            O2JAM_ITEMNAME_QUERY = 0x0011,
            O2JAM_ITEMNAME_QUERY_RESP = 0x8011,

            O2JAM_GIFTBOX_DELETE = 0x0012,
            O2JAM_GIFTBOX_DELETE_RESP = 0x8012,

            DEPARTMENT_RELATE_QUERY = 0x0013,//部门关联查询
            DEPARTMENT_RELATE_QUERY_RESP = 0x8013,//部门关联查询


            DEPART_RELATE_GAME_QUERY = 0x0014,
            DEPART_RELATE_GAME_QUERY_RESP = 0x8014,
            USER_SYSADMIN_QUERY = 0x0015,
            USER_SYSADMIN_QUERY_RESP = 0x8015,
            CARD_USERSECURE_CLEAR = 0x0009,//重置玩家安全码信息
            CARD_USERSECURE_CLEAR_RESP = 0x8009,//重置玩家安全码信息响应


            /// <summary>
            /// 劲乐团IIGM工具(0x93)
            /// </summary>
            O2JAM2_ACCOUNT_QUERY = 0x0001,//玩家帐号信息查询
            O2JAM2_ACCOUNT_QUERY_RESP = 0x8001,//玩家帐号信息查询响应
            O2JAM2_ACCOUNTACTIVE_QUERY = 0x0002,//玩家帐号激活信息
            O2JAM2_ACCOUNTACTIVE_QUERY_RESP = 0x8002,//玩家帐号激活响应

            O2JAM2_CHARACTERINFO_QUERY = 0x0003,//用户信息查询
            O2JAM2_CHARACTERINFO_QUERY_RESP = 0x8003,
            O2JAM2_CHARACTERINFO_UPDATE = 0x0004,//用户信息修改
            O2JAM2_CHARACTERINFO_UPDATE_RESP = 0x8004,
            O2JAM2_ITEMSHOP_QUERY = 0x0005,
            O2JAM2_ITEMSHOP_QUERY_RESP = 0x8005,
            O2JAM2_ITEMSHOP_DELETE = 0x0006,
            O2JAM2_ITEMSHOP_DELETE_RESP = 0x8006,
            O2JAM2_MESSAGE_QUERY = 0x0007,
            O2JAM2_MESSAGE_QUERY_RESP = 0x8007,
            O2JAM2_MESSAGE_CREATE = 0x0008,
            O2JAM2_MESSAGE_CREATE_RESP = 0x8008,
            O2JAM2_MESSAGE_DELETE = 0x0009,
            O2JAM2_MESSAGE_DELETE_RESP = 0x8009,
            O2JAM2_CONSUME_QUERY = 0x0010,
            O2JAM2_CONUMSE_QUERY_RESP = 0x8010,
            O2JAM2_CONSUME_SUM_QUERY = 0x0011,
            O2JAM2_CONUMSE_QUERY_SUM_RESP = 0x8011,
            O2JAM2_TRADE_QUERY = 0x0012,
            O2JAM2_TRADE_QUERY_RESP = 0x8012,
            O2JAM2_TRADE_SUM_QUERY = 0x0013,
            O2JAM2_TRADE_QUERY_SUM_RESP = 0x8013,
            O2JAM2_AVATORLIST_QUERY = 0x0014,
            O2JAM2_AVATORLIST_QUERY_RESP = 0x8014,

            O2JAM2_ACCOUNT_CLOSE = 0x0015,//封停帐户的权限信息
            O2JAM2_ACCOUNT_CLOSE_RESP = 0x8015,//封停帐户的权限信息响应

            O2JAM2_ACCOUNT_OPEN = 0x0016,//解封帐户的权限信息
            O2JAM2_ACCOUNT_OPEN_RESP = 0x8016,//解封帐户的权限信息响应
            O2JAM2_MEMBERBANISHMENT_QUERY = 0x0017,
            O2JAM2_MEMBERBANISHMENT_QUERY_RESP = 0x8017,
            O2JAM2_MEMBERSTOPSTATUS_QUERY = 0x0018,
            O2JAM2_MEMBERSTOPSTATUS_QUERY_RESP = 0x8018,
            O2JAM2_MEMBERLOCAL_BANISHMENT = 0x0019,
            O2JAM2_MEMBERLOCAL_BANISHMENT_RESP = 0x8019,
            O2JAM2_USERLOGIN_DELETE = 0x0020,
            O2JAM2_USERLOGIN_DELETE_RESP = 0x8020,




            SDO_CHALLENGE_QUERY = 0x0052,
            SDO_CHALLENGE_QUERY_RESP = 0x8052,
            SDO_CHALLENGE_INSERT = 0x0053,
            SDO_CHALLENGE_INSERT_RESP = 0x8053,
            SDO_CHALLENGE_UPDATE = 0x0054,
            SDO_CHALLENGE_UPDATE_RESP = 0x8054,
            SDO_CHALLENGE_DELETE = 0x0055,
            SDO_CHALLENGE_DELETE_RESP = 0x8055,
            SDO_MUSICDATA_QUERY = 0x0056,
            SDO_MUSICDATA_QUERY_RESP = 0x8056,

            SDO_MUSICDATA_OWN_QUERY = 0x0057,
            SDO_MUSICDATA_OWN_QUERY_RESP = 0x8057,


            SDO_CHALLENGE_SCENE_QUERY = 0x0058,
            SDO_CHALLENGE_SCENE_QUERY_RESP = 0x8058,
            SDO_CHALLENGE_SCENE_CREATE = 0x0059,
            SDO_CHALLENGE_SCENE_CREATE_RESP = 0x8059,
            SDO_CHALLENGE_SCENE_UPDATE = 0x0060,
            SDO_CHALLENGE_SCENE_UPDATE_RESP = 0x8060,
            SDO_CHALLENGE_SCENE_DELETE = 0x0061,
            SDO_CHALLENGE_SCENE_DELETE_RESP = 0x8061,


            SDO_MEDALITEM_CREATE = 0x0062,
            SDO_MEDALITEM_CREATE_RESP = 0x8062,
            SDO_MEDALITEM_UPDATE = 0x0063,
            SDO_MEDALITEM_UPDATE_RESP = 0x8063,
            SDO_MEDALITEM_DELETE = 0x0064,
            SDO_MEDALITEM_DELETE_RESP = 0x8064,
            SDO_MEDALITEM_QUERY = 0x0065,
            SDO_MEDALITEM_QUERY_RESP = 0x8065,

            SDO_MEDALITEM_OWNER_QUERY = 0x0066,
            SDO_MEDALITEM_OWNER_QUERY_RESP = 0x8066,


            SDO_MEMBERDANCE_OPEN = 0x0067,
            SDO_MEMBERDANCE_OPEN_RESP = 0x8067,
            SDO_MEMBERDANCE_CLOSE = 0x0068,
            SDO_MEMBERDANCE_CLOSE_RESP = 0x8068,

            SDO_YYHAPPYITEM_QUERY = 0x0084,
            SDO_YYHAPPYITEM_QUERY_RESP = 0x8084,
            SDO_YYHAPPYITEM_CREATE = 0x0085,
            SDO_YYHAPPYITEM_CREATE_RESP = 0x8085,
            SDO_YYHAPPYITEM_UPDATE = 0x0086,
            SDO_YYHAPPYITEM_UPDATE_RESP = 0x8086,
            SDO_YYHAPPYITEM_DELETE = 0x0087,
            SDO_YYHAPPYITEM_DELETE_RESP = 0x8087,
            SDO_PetInfo_Query = 0x0088,
            SDO_PetInfo_Query_RESP = 0x8088,
            /// <summary>
            /// 劲爆足球
            /// </summary>
            SOCCER_CHARACTERINFO_QUERY = 0x0001,//用户信息查询
            SOCCER_CHARACTERINFO_QUERY_RESP = 0x8001,
            SOCCER_CHARCHECK_QUERY = 0x0002,//用户NameCheck,SocketCheck
            SOCCER_CHARCHECK_QUERY_RESP = 0x8002,
            SOCCER_CHARITEMS_RECOVERY_QUERY = 0x0003,//用户启用
            SOCCER_CCHARITEMS_RECOVERY_QUERY_RESP = 0x8003,
            SOCCER_CHARPOINT_QUERY = 0x0004,//用户G币修改
            SOCCER_CHARPOINT_QUERY_RESP = 0x8004,
            SOCCER_DELETEDCHARACTERINFO_QUERY = 0x0005,//删除用户查询
            SOCCER_DELETEDCHARACTERINFO_QUERY_RESP = 0x8005,

            SOCCER_CHARACTERSTATE_MODIFY = 0x0006,//停封角色
            SOCCER_CHARACTERSTATE_MODIFY_RESP = 0x8006,
            SOCCER_ACCOUNTSTATE_MODIFY = 0x0007,//停封玩家
            SOCCER_ACCOUNTSTATE_MODIFY_RESP = 0x8007,
            SOCCER_CHARACTERSTATE_QUERY = 0x0008,//停封角色查询
            SOCCER_CHARACTERSTATE_QUERY_RESP = 0x8008,
            SOCCER_ACCOUNTSTATE_QUERY = 0x0009,//停封玩家查询
            SOCCER_ACCOUNTSTATE_QUERY_RESP = 0x8009,

            CARD_USERNICK_QUERY = 0x0010,
            CARD_USERNICK_QUERY_RESP = 0x8010,

            AU_USERNICK_UPDATE = 0x0022,
            AU_USERNICK_UPDATE_RESP = 0x8022,

            LINK_SERVERIP_DELETE = 0x0010,
            LINK_SERVERIP_DELETE_RESP = 0x8010,

            #region 敢达
            /// <summary>
            /// 敢达(Ox70)
            /// </summary>
            SD_ActiveCode_Query = 0x0001,
            SD_ActiveCode_Query_Resp = 0x8001,
            SD_Account_Query = 0x0002,//帐号查询
            SD_Account_Query_Resp = 0x8002,

            SD_UserLoginfo_Query = 0x0013,//用户登陆信息查询
            SD_UserLoginfo_Query_Resp = 0x8013,
            SD_UserMailinfo_Query = 0x0004,//用户邮件信息查询
            SD_UserMailinfo_Query_Resp = 0x8004,
            SD_UserGuildinfo_Query = 0x0005,//用户公会信息查询
            SD_UserGuildinfo_Query_Resp = 0x8005,
            SD_UserStorageinfo_Query = 0x0006,//用户仓库信息查询
            SD_UserStorageinfo_Query_Resp = 0x8006,
            SD_UserAdditem_Add = 0x0007,//添加道具
            SD_UserAdditem_Add_Resp = 0x8007,
            SD_UserAdditem_Del = 0x0011,//删除道具
            SD_UserAdditem_Del_Resp = 0x8011,
            SD_BanUser_Query = 0x0008,//查询封停用户
            SD_BanUser_Query_Resp = 0x8008,
            SD_BanUser_Ban = 0x0009,//封停用户
            SD_BanUser_Ban_Resp = 0x8009,
            SD_BanUser_UnBan = 0x0010,//解封用户
            SD_BanUser_UnBan_Resp = 0x8010,
            SD_AccountDetail_Query = 0x0012,//帐号详细信息查询
            SD_AccountDetail_Query_Resp = 0x8012,

            SD_UserIteminfo_Query = 0x0003,//用户道具信息查询
            SD_UserIteminfo_Query_Resp = 0x8003,

            SD_Item_UserUnits_Query = 0x0014,	//玩家机体信息
            SD_Item_UserUnits_Query_Resp = 0x8014,
            SD_Item_UserCombatitems_Query = 0x0015,	//玩家战斗道具
            SD_Item_UserCombatitems_Query_Resp = 0x8015,
            SD_Item_Operator_Query = 0x0016,	//玩家副官道具
            SD_Item_Operator_Query_Resp = 0x8016,
            SD_Item_Paint_Query = 0x0017,	//玩家涂料道具
            SD_Item_Paint_Query_Resp = 0x8017,
            SD_Item_Skill_Query = 0x0018,//玩家技能道具
            SD_Item_Skill_Query_Resp = 0x8018,//玩家技能道具
            SD_Item_Sticker_Query = 0x0019,//玩家标签道具
            SD_Item_Sticker_Query_Resp = 0x8019,//玩家标签道具

            SD_Item_MixTree_Query = 0x0020,	//玩家机体组合
            SD_Item_MixTree_Query_Resp = 0x8020,

            SD_UserGrift_Query = 0x0022,//礼物信息查询
            SD_UserGrift_Query_Resp = 0x8022,//礼物信息查询
            SD_KickUser_Query = 0x0021,//踢用户下线
            SD_KickUser_Query_Resp = 0x8021,//踢用户下线
            SD_SendNotes_Query = 0x0023,//发送公告
            SD_SendNotes_Query_Resp = 0x8023,//发送公告
            SD_SeacrhNotes_Query = 0x0024,//公告信息查询
            SD_SeacrhNotes_Query_Resp = 0x8024,//公告信息查询
            SD_ItemType_Query = 0x0025,//获取道具类型
            SD_ItemType_Query_Resp = 0x8025,//获取道具类型
            SD_ItemList_Query = 0x0026,//获取道具列表
            SD_ItemList_Query_Resp = 0x8026,//获取道具列表

            SD_TmpPassWord_Query = 0x0027,//临时密码
            SD_TmpPassWord_Query_Resp = 0x8027,//临时密码
            SD_ReTmpPassWord_Query = 0x0028,//恢复临时密码
            SD_ReTmpPassWord_Query_Resp = 0x8028,//恢复临时密码
            SD_SearchPassWord_Query = 0x0029,//查询临时密码
            SD_SearchPassWord_Query_Resp = 0x8029,//查询临时密码
            SD_UpdateExp_Query = 0x0030,//修改等级
            SD_UpdateExp_Query_Resp = 0x8030,//修改等级

            SD_Grift_FromUser_Query = 0x0031,//发送人礼物信息查询
            SD_Grift_FromUser_Query_Resp = 0x8031,//发送人礼物信息查询
            SD_Grift_ToUser_Query = 0x0032,//发送人礼物信息查询
            SD_Grift_ToUser_Query_Resp = 0x8032,//发送人礼物信息查询

            SD_TaskList_Update = 0x0033,//修改公告
            SD_TaskList_Update_Resp = 0x8033,//修改公告

            SD_Account_Active_Query = 0x0034,//通过帐号查询激活信息
            SD_Account_Active_Query_Resp = 0x8034,//通过帐号查询激活信息

            SD_BuyLog_Query = 0x0035,//玩家购买道具
            SD_BuyLog_Query_Resp = 0x8035,//玩家购买道具
            SD_Delete_ItemLog_Query = 0x0036,//玩家删除道具记录
            SD_Delete_ItemLog_Query_Resp = 0x8036,//玩家删除道具记录
            SD_LogInfo_Query = 0x0037,//玩家日志记录
            SD_LogInfo_Query_Resp = 0x8037,//玩家日志记录
            SD_Firend_Query = 0x0038,//玩家好友查询
            SD_Firend_Query_Resp = 0x8038,//玩家好友查询
            SD_UserRank_query = 0x0039,//玩家排名查询
            SD_UserRank_query_Resp = 0x8039,//玩家排名查询
            SD_UpdateUnitsExp_Query = 0x0040,//修改玩家机体等级
            SD_UpdateUnitsExp_Query_Resp = 0x8040,//修改玩家机体等级

            SD_UnitsItem_Query = 0x0041,//查询机体道具
            SD_UnitsItem_Query_Resp = 0x8041,//查询机体道具

            SD_GetGmAccount_Query = 0x0042,//查询GM账号
            SD_GetGmAccount_Query_Resp = 0x8042,//查询GM账号
            SD_UpdateGmAccount_Query = 0x0043,//修改GM账号
            SD_UpdateGmAccount_Query_Resp = 0x8043,//修改GM账号


            SD_UpdateMoney_Query = 0x0044,//修改G币
            SD_UpdateMoney_Query_Resp = 0x8044,//修改G币

            SD_Card_Info_Query = 0x0045,//新手/钻石卡查询
            SD_Card_Info_Query_Resp = 0x8045,//新手/钻石卡查询

            SD_UserAdditem_Add_All = 0x0046,//批量添加道具
            SD_UserAdditem_Add_All_Resp = 0x8046,//批量添加道具

            SD_ReGetUnits_Query = 0x0047,//恢复机体
            SD_ReGetUnits_Query_Resp = 0x8047,//恢复机体
            #endregion


            #region 劲舞团2
            JW2_ACCOUNT_QUERY = 0x0001,//玩家帐号信息查询（1.2.3.4.5.8）
            JW2_ACCOUNT_QUERY_RESP = 0x8001,//玩家帐号信息查询响应（1.2.3.4.5.8）
            /////////////封停类/////////////////////////////////////////
            JW2_ACCOUNTREMOTE_QUERY = 0x0002,//游戏服务器封停的玩家帐号查询
            JW2_ACCOUNTREMOTE_QUERY_RESP = 0x8002,//游戏服务器封停的玩家帐号查询响应

            JW2_ACCOUNTLOCAL_QUERY = 0x0003,//本地封停的玩家帐号查询
            JW2_ACCOUNTLOCAL_QUERY_RESP = 0x8003,//本地封停的玩家帐号查询响应

            JW2_ACCOUNT_CLOSE = 0x0004,//封停的玩家帐号
            JW2_ACCOUNT_CLOSE_RESP = 0x8004,//封停的玩家帐号响应
            JW2_ACCOUNT_OPEN = 0x0005,//解封的玩家帐号
            JW2_ACCOUNT_OPEN_RESP = 0x8005,//解封的玩家帐号响应
            JW2_ACCOUNT_BANISHMENT_QUERY = 0x0006,//玩家封停帐号查询
            JW2_ACCOUNT_BANISHMENT_QUERY_RESP = 0x8006,//玩家封停帐号查询响应
            ////////////////////////////
            JW2_BANISHPLAYER = 0x0007,//踢人
            JW2_BANISHPLAYER_RESP = 0x8007,//踢人响应
            JW2_BOARDMESSAGE = 0x0008,//公告
            JW2_BOARDMESSAGE_RESP = 0x8008,//公告响应

            JW2_LOGINOUT_QUERY = 0x0009,//玩家人物登入/登出信息
            JW2_LOGINOUT_QUERY_RESP = 0x8009,//玩家人物登入/登出信息响应

            JW2_RPG_QUERY = 0x0010,//查询故事情节（6）
            JW2_RPG_QUERY_RESP = 0x8010,//查询故事情节响应（6）

            JW2_ITEMSHOP_BYOWNER_QUERY = 0x0011,////查看玩家身上道具信息（7－7）
            JW2_ITEMSHOP_BYOWNER_QUERY_RESP = 0x8011,////查看玩家身上道具信息响应（7－7）


            JW2_DUMMONEY_QUERY = 0x0012,////查询点数和虚拟币（7－8）
            JW2_DUMMONEY_QUERY_RESP = 0x8012,////查询点数和虚拟币响应（7－8）
            JW2_HOME_ITEM_QUERY = 0x0013,////查看房间物品清单与期限（7－9）
            JW2_HOME_ITEM_QUERY_RESP = 0x8013,////查看房间物品清单与期限响应（7－9）
            JW2_SMALL_PRESENT_QUERY = 0x0014,////查看购物，送礼（7－10）
            JW2_SMALL_PRESENT_QUERY_RESP = 0x8014,////查看购物，送礼响应（7－10）
            JW2_WASTE_ITEM_QUERY = 0x0015,////查看消耗性道具（7－11）
            JW2_WASTE_ITEM_QUERY_RESP = 0x8015,////查看消耗性道具响应（7－11）
            JW2_SMALL_BUGLE_QUERY = 0x0016,////查看小喇叭（7－12）
            JW2_SMALL_BUGLE_QUERY_RESP = 0x8016,////查看小喇叭响应（7－12）


            JW2_WEDDINGINFO_QUERY = 0x0017,//婚姻信息
            JW2_WEDDINGINFO_QUERY_RESP = 0x8017,
            JW2_WEDDINGLOG_QUERY = 0x0018,//婚姻历史
            JW2_WEDDINGLOG_QUERY_RESP = 0x8018,
            JW2_WEDDINGGROUND_QUERY = 0x0019,//结婚信息
            JW2_WEDDINGGROUND_QUERY_RESP = 0x8019,
            JW2_COUPLEINFO_QUERY = 0x0020,//情人信息
            JW2_COUPLEINFO_QUERY_RESP = 0x8020,
            JW2_COUPLELOG_QUERY = 0x0021,//情人历史
            JW2_COUPLELOG_QUERY_RESP = 0x8021,


            JW2_FAMILYINFO_QUERY = 0x0022,//家族信息
            JW2_FAMILYINFO_QUERY_RESP = 0x8022,
            JW2_FAMILYMEMBER_QUERY = 0x0023,//家族成员信息
            JW2_FAMILYMEMBER_QUERY_RESP = 0x8023,
            JW2_SHOP_QUERY = 0x0024,//商城信息
            JW2_SHOP_QUERY_RESP = 0x8024,
            JW2_User_Family_Query = 0x0025,//用户家族信息
            JW2_User_Family_Query_Resp = 0x8025,

            JW2_FamilyItemInfo_Query = 0x0026,//家族道具信息
            JW2_FamilyItemInfo_Query_Resp = 0x8026,

            JW2_FamilyBuyLog_Query = 0x0027,//家族购买日志
            JW2_FamilyBuyLog_Query_Resp = 0x8027,

            JW2_FamilyTransfer_Query = 0x0028,//家族转让信息
            JW2_FamilyTransfer_Query_Resp = 0x8028,

            JW2_FriendList_Query = 0x0029,//好友列表
            JW2_FriendList_Query_Resp = 0x8029,

            JW2_BasicInfo_Query = 0x0030,//基地信息查询
            JW2_BasicInfo_Query_Resp = 0x8030,

            JW2_FamilyMember_Applying = 0x0031,//申请中成员
            JW2_FamilyMember_Applying_Resp = 0x8031,

            JW2_BasicRank_Query = 0x0032,//基地等级
            JW2_BasicBank_Query_Resp = 0x8032,


            ///////////公告////////////////////////////
            JW2_BOARDTASK_INSERT = 0x0033,//公告添加
            JW2_BOARDTASK_INSERT_RESP = 0x8033,//公告添加响应
            JW2_BOARDTASK_QUERY = 0x0034,//公告查询
            JW2_BOARDTASK_QUERY_RESP = 0x8034,//公告查询响应
            JW2_BOARDTASK_UPDATE = 0x0035,//公告更新
            JW2_BOARDTASK_UPDATE_RESP = 0x8035,//公告更新响应

            JW2_ITEM_DEL = 0x0036,//道具删除（身上0，物品栏1，礼盒2）
            JW2_ITEM_DEL_RESP = 0x8036,//道具删除（身上0，物品栏1，礼盒2）

            JW2_MODIFYSEX_QUERY = 0x0037,//修改角色性别
            JW2_MODIFYSEX_QUERY_RESP = 0x8037,

            JW2_MODIFYLEVEL_QUERY = 0x0038,//修改等级
            JW2_MODIFYLEVEL_QUERY_RESP = 0x8038,

            JW2_MODIFYEXP_QUERY = 0x0039,//修改经验
            JW2_MODIFYEXP_QUERY_RESP = 0x8039,

            JW2_BAN_BIGBUGLE = 0x0040,//禁用大喇叭
            JW2_BAN_BIGBUGLE_RESP = 0x8040,

            JW2_BAN_SMALLBUGLE = 0x0041,//禁用小喇叭
            JW2_BAN_SMALLBUGLE_RESP = 0x8041,

            JW2_DEL_CHARACTER = 0x0042,//删除角色
            JW2_DEL_CHARACTER_RESP = 0x8042,

            JW2_RECALL_CHARACTER = 0x0043,//恢复角色
            JW2_RECALL_CHARACTER_RESP = 0x8043,

            JW2_MODIFY_MONEY = 0x0044,//修改金钱
            JW2_MODIFY_MONEY_RESP = 0x8044,

            JW2_ADD_ITEM = 0x0045,//增加道具
            JW2_ADD_ITEM_RESP = 0x8045,

            JW2_CREATE_GM = 0x0046,//每个大区创建GM
            JW2_CREATE_GM_RESP = 0x8046,

            JW2_MODIFY_PWD = 0x0047,//修改密码
            JW2_MODIFY_PWD_RESP = 0x8047,

            JW2_RECALL_PWD = 0x0048,//恢复密码
            JW2_RECALL_PWD_RESP = 0x8048,


            JW2_ItemInfo_Query = 0x0049,//道具查询
            JW2_ItemInfo_Query_Resp = 0x8049,//


            JW2_ITEM_SELECT = 0x0050,//道具模糊查询
            JW2_ITEM_SELECT_RESP = 0x8050,//

            JW2_PetInfo_Query = 0x0051,//宠物信息
            JW2_PetInfo_Query_Resp = 0x8051,

            JW2_Messenger_Query = 0x0052,//称号查询
            JW2_Messenger_Query_Resp = 0x8052,

            JW2_Wedding_Paper = 0x0053,//结婚证书
            JW2_Wedding_Paper_Resp = 0x8053,

            JW2_CoupleParty_Card = 0x0054,//情侣派对卡
            JW2_CoupleParty_Card_Resp = 0x8054,


            JW2_MailInfo_Query = 0x0055,//纸箱信息
            JW2_MailInfo_Query_Resp = 0x8055,

            JW2_MoneyLog_Query = 0x0056,//金钱日志查询
            JW2_MoneyLog_Query_Resp = 0x8056,

            JW2_FamilyFund_Log = 0x0057,//基金日志
            JW2_FamilyFund_Log_Resp = 0x8057,

            JW2_FamilyItem_Log = 0x0058,//家族道具日志
            JW2_FamilyItem_Log_Resp = 0x8058,

            JW2_Item_Log = 0x0059,//道具日志
            JW2_Item_Log_Resp = 0x8059,


            JW2_ADD_ITEM_ALL = 0x0060,//增加道具(批量)
            JW2_ADD_ITEM_ALL_RESP = 0x8060,

            JW2_CashMoney_Log = 0x0061,//消费日志
            JW2_CashMoney_Log_Resp = 0x8061,

            JW2_SearchPassWord_Query = 0x0062,//查询临时密码
            JW2_SearchPassWord_Query_Resp = 0x8062,//查询临时密码

            JW2_CenterAvAtarItem_Bag_Query = 0x0063,//中间背包道具
            JW2_CenterAvAtarItem_Bag_Query_Resp = 0x8063,//中间背包道具

            JW2_CenterAvAtarItem_Equip_Query = 0x0064,//中间身上道具
            JW2_CenterAvAtarItem_Equip_Query_Resp = 0x8064,//中间身上道具

            JW2_House_Query = 0x0065,//小黑屋
            JW2_House_Query_Resp = 0x8065,//小黑屋

            JW2_GM_Update = 0x0066,//GM狀態修改
            JW2_GM_Update_Resp = 0x8066,//GM狀態修改
            JW2_JB_Query = 0x0067,//舉報信息查?
            JW2_JB_Query_Resp = 0x8067,//舉報信息查?


            JW2_UpDateFamilyName_Query = 0x0068,//修改家族名
            JW2_UpDateFamilyName_Query_Resp = 0x8068,//修改家族名

            JW2_UpdatePetName_Query = 0x0069,//修改?物名
            JW2_UpdatePetName_Query_Resp = 0x8069,//修改?物名


            JW2_Act_Card_Query = 0x0070,//活动卡查询
            JW2_Act_Card_Query_Resp = 0x8070,//活动卡查询

            JW2_Center_Kick_Query = 0x0071,//中間件踢人
            JW2_Center_Kick_Query_Resp = 0x8071,//中間件踢人

            JW2_ChangeServerExp_Query = 0x0072,//修改服務器??倍數
            JW2_ChangeServerExp_Query_Resp = 0x8072,//修改服務器??倍數

            JW2_ChangeServerMoney_Query = 0x0073,//修改服務器金钱倍數
            JW2_ChangeServerMoney_Query_Resp = 0x8073,//修改服務器金钱倍數

            JW2_MissionInfoLog_Query = 0x0074,//任务LOG查询
            JW2_MissionInfoLog_Query_Resp = 0x8074,//任务LOG查询

            JW2_AgainBuy_Query = 0x0075,//重复购买退款
            JW2_AgainBuy_Query_Resp = 0x8075,//重复购买退款

            JW2_GSSvererList_Query = 0x0076,//服务器列表GS
            JW2_GSSvererList_Query_Resp = 0x8076,//服务器列表GS


            JW2_Materiallist_Query = 0x0079,//用戶合成材料查询
            JW2_Materiallist_Query_Resp = 0x8079,//用戶合成材料查询

            JW2_MaterialHistory_Query = 0x0080,//用戶合成记录
            JW2_MaterialHistory_Query_Resp = 0x8080,//用戶合成记录

            JW2_ACTIVEPOINT_QUERY = 0x0081,//活跃度查询	
            JW2_ACTIVEPOINT_QUERY_Resp = 0x8081,//活跃度查询

            JW2_GETPIC_Query = 0x0082,//获得需要审核的图片列表
            JW2_GETPIC_Query_Resp = 0x8082,//获得需要审核的图片列表

            JW2_CHKPIC_Query = 0x0083,//审核图片 2审核通过，3审核不通过 
            JW2_CHKPIC_Query_Resp = 0x8083,//审核图片 2审核通过，3审核不通过

            JW2_PicCard_Query = 0x0084,//圖片上傳卡使用
            JW2_PicCard_Query_Resp = 0x8084,//圖片上傳卡使用

            JW2_FamilyPet_Query = 0x0085,//家族宠物查询
            JW2_FamilyPet_Query_Resp = 0x8085,//家族宠物查询

            JW2_BuyPetAgg_Query = 0x0086,//族长购买宠物蛋查询
            JW2_BuyPetAgg_Query_Resp = 0x8086,//族长购买宠物蛋查询

            JW2_PetFirend_Query = 0x0087,//家族宠物交友查询
            JW2_PetFirend_Query_Resp = 0x8087,//家族宠物交友查询

            JW2_SmallPetAgg_Query = 0x0088,//家族成员领取小宠物信息查询
            JW2_SmallPetAgg_Query_Resp = 0x8088,//家族成员领取小宠物信息查询
            #endregion
            MAGIC_Account_Query = 0x0001,//角色基本资料
            MAGIC_Account_Query_Resp = 0x8001,//角色基本资料
            ERROR = 0xFFFF,

              #region 光线飞车
            /// <summary>
            ///光线飞车
            /// </summary>
            RayCity_Character_Query = 0x0001,
            RayCity_Character_Query_Resp = 0x8001,
            RayCity_CharacterState_Query = 0x0002,
            RayCity_CharacterState_Query_Resp = 0x8002,
            RayCity_RaceState_Query = 0x0003,
            RayCity_RaceState_Query_Resp = 0x8003,
            RayCity_InventoryList_Query = 0x0004,
            RayCity_InventoryList_Query_Resp = 0x8004,
            RayCity_InventoryDetail_Query = 0x0005,
            RayCity_InventoryDetail_Query_Resp = 0x8005,
            RayCity_CarList_Query = 0x0006,
            RayCity_CarList_Query_Resp = 0x8006,
            RayCity_Guild_Query = 0x0007,
            RayCity_Guild_Query_Resp = 0x8007,
            RayCity_QuestLog_Query = 0x0008,
            RayCity_QuestLog_Query_Resp = 0x8008,
            RayCity_MissionLog_Query = 0x0009,
            RayCity_MissionLog_Query_Resp = 0x8009,
            RayCity_DealLog_Query = 0x0010,
            RayCity_DealLog_Query_Resp = 0x8010,
            RayCity_FriendList_Query = 0x0011,
            RayCity_FriendList_Query_Resp = 0x8011,
            RayCity_BasicAccount_Query = 0x0012,
            RayCity_BasicAccount_Query_Resp = 0x8012,
            RayCity_GuildMember_Query = 0x0013,
            RayCity_GuildMember_Query_Resp = 0x8013,
            RayCity_BasicCharacter_Query = 0x0014,
            RayCity_BasicCharacter_Query_Resp = 0x8014,
            RayCity_BuyCar_Query = 0x0015,
            RayCity_BuyCar_Query_Resp = 0x8015,
            RayCity_ConnectionLog_Query = 0x0016,
            RayCity_ConnectionLog_Query_Resp = 0x8016,
            RayCity_CarInventory_Query = 0x0017,
            RayCity_CarInventory_Query_Resp = 0x8017,
            RayCity_ConnectionState_Query = 0x0018,
            RayCity_ConnectionState_Resp = 0x8018,
            RayCity_ItemShop_Insert = 0x0019,
            RayCity_ItemShop_Insert_Resp = 0x8019,
            RayCity_ItemShop_Query = 0x0020,
            RayCity_ItemShop_Query_Resp = 0x8020,
            RayCity_MoneyLog_Query = 0x0021,
            RayCity_MoneyLog_Query_Resp = 0x8021,
            RayCity_RaceLog_Query = 0x0022,
            RayCity_RaceLog_Query_Resp = 0x8022,
            RayCity_AddMoney = 0x0023,
            RayCity_AddMoney_Resp = 0x8023,
            RayCity_Skill_Query = 0x0024,
            RayCity_Skill_Query_Resp = 0x8024,
            RayCity_PlayerSkill_Query = 0x0025,
            RayCity_PlayerSkill_Query_Resp = 0x8025,
            RayCity_PlayerSkill_Delete = 0x0026,
            RayCity_PlayerSkill_Delete_Resp = 0x8026,
            RayCity_PlayerSkill_Insert = 0x0027,
            RayCity_PlayerSkill_Insert_Resp = 0x8027,
            RayCity_ItemType_Query = 0x0028,
            RayCity_ItemType_Query_Resp = 0x8028,
            RayCity_GMUser_Query = 0x0029,
            RayCity_GMUser_Query_Resp = 0x8029,
            RayCity_GMUser_Update = 0x0030,
            RayCity_GMUser_Update_Resp = 0x8030,
            RayCity_TradeInfo_Query = 0x0031,
            RayCity_TradeInfo_Query_Resp = 0x8031,
            RayCity_TradeDetail_Query = 0x0032,
            RayCity_TradeDetail_Query_Resp = 0x8032,
            RayCity_SetPos_Update = 0x0033,
            RayCity_SetPos_Update_Resp = 0x8033,
            RayCity_PlayerAccount_Create = 0x0034,
            RayCity_PlayerAccount_Create_Resp = 0x8034,
            RayCity_WareHousePwd_Update = 0x0035,
            RayCity_WareHousePwd_Update_Resp = 0x8035,
            RayCity_BingoCard_Query = 0x0036,
            RayCity_BingoCard_Query_Resp = 0x8036,
            RayCity_UserCharge_Query = 0x0037,
            RayCity_UserCharge_Query_Resp = 0x8037,
            RayCity_ItemConsume_Query = 0x0038,
            RayCity_ItemConsume_Query_Resp = 0x8038,
            RayCity_UserMails_Query = 0x0039,
            RayCity_UserMails_Query_Resp = 0x8039,
            RayCity_CashItemDetailLog_Query = 0x0040,
            RayCity_CashItemDetailLog_Query_Resp = 0x8040,
            RC_Character_Update = 0x0015,
            RC_Character_Update_Resp = 0x8015,
            #region 疯狂飙车
            RC_Character_Query = 0x0001,
            RC_Character_Query_Resp = 0x8001,
            RC_UserLoginOut_Query = 0x0002,
            RC_UserLoginOut_Query_Resp = 0x8002,
            RC_UserLogin_Del = 0x0003,
            RC_UserLogin_Del_Resp = 0x8003,
            RC_RcCode_Query = 0x0004,
            RC_RcCode_Query_Resp = 0x8004,
            RC_RcUser_Query = 0x0005,
            RC_RcUser_Query_Resp = 0x8005,
            #endregion
            RayCity_Coupon_Query = 0x0041,
            RayCity_Coupon_Query_Resp = 0x8041,
            RayCity_ActiveCard_Query = 0x0042,
            RayCity_ActiveCard_Query_Resp = 0x8042,

            RayCity_BoardList_Query = 0x0043,
            RayCity_BoardList_Query_Resp = 0x8043,
            RayCity_BoardList_Insert = 0x0044,
            RayCity_BoardList_Insert_Resp = 0x8044,
            RayCity_BoardList_Delete = 0x0045,
            RayCity_BoardList_Delete_Resp = 0x8045,
            #endregion

               CS_Accountbyid_Query = 0x0033,
            CS_Accountbyid_Query_Resp = 0x8033,
        }

        /// <summary>
        /// 消息类型标签
        /// </summary>
        public enum Msg_Category : byte
        {
            COMMON = 0x80,//公用消息集
            USER_ADMIN = 0x81,//GM帐号操作消息集
            MODULE_ADMIN = 0x82,//模块操作消息集
            USER_MODULE_ADMIN = 0x83,//用户和模块操作消息集
            GAME_ADMIN = 0x84, //游戏模块操作消息集
            NOTES_ADMIN = 0x85,//NOTES模块操作消息集
            MJ_ADMIN = 0x86,//猛将游戏GM工具操作消息集
            SDO_ADMIN = 0x87,//超级舞者操作消息集
            AU_ADMIN = 0x88,//劲舞团
            CR_ADMIN = 0x89,//疯狂卡丁车操作消息集
            CARD_ADMIN = 0x90,
            AUSHOP_ADMIN = 0x91,
            O2JAM_ADMIN = 0x92,
            O2JAM2_ADMIN = 0x93,
            SOCCER_ADMIN = 0x94,//劲爆足球记录消息集

            JW2_ADMIN = 0x61,//劲舞团2


            RC_ADMIN = 0x96,
            RAYCITY_ADMIN = 0x97,//光线飞车记录消息集
            SD_ADMIN = 0x70,//SD高达记录消息集
            ERROR = 0xFF
        }

        /// <summary>
        /// 消息状态标签
        /// </summary>
        public enum Body_Status : ushort
        {
            MSG_STRUCT_OK = 0,
            MSG_STRUCT_ERROR = 1,
            ILLEGAL_SOURCE_ADDR = 2,
            AUTHEN_ERROR = 3,
            OTHER_ERROR = 4
        }
        /// <summary>
        /// 消息头标签
        /// </summary>
        public enum Message_Tag_ID : uint
        {
            /// <summary>
            /// 公共模块(0x80)
            /// </summary>
            CONNECT = 0x800001,//连接请求
            CONNECT_RESP = 0x808001,//连接响应
            DISCONNECT = 0x800002,//断开请求
            DISCONNECT_RESP = 0x808002,//断开响应
            ACCOUNT_AUTHOR = 0x800003,//用户身份验证请求
            ACCOUNT_AUTHOR_RESP = 0x808003,//用户身份验证响应
            SERVERINFO_IP_QUERY = 0x800004,
            SERVERINFO_IP_QUERY_RESP = 0x808004,
            GMTOOLS_OperateLog_Query = 0x800005,//查看工具操作记录
            GMTOOLS_OperateLog_Query_RESP = 0x808005,//查看工具操作记录响应
            SERVERINFO_IP_ALL_QUERY = 0x800006,
            SERVERINFO_IP_ALL_QUERY_RESP = 0x808006,
            LINK_SERVERIP_CREATE = 0x800007,
            LINK_SERVERIP_CREATE_RESP = 0x808007,
            CLIENT_PATCH_COMPARE = 0x800008,
            CLIENT_PATCH_COMPARE_RESP = 0x808008,
            CLIENT_PATCH_UPDATE = 0x800009,
            CLIENT_PATCH_UPDATE_RESP = 0x808009,

            /// <summary>
            /// 用户管理模块(0x81)
            /// </summary>
            USER_CREATE = 0x810001,//创建GM帐号请求
            USER_CREATE_RESP = 0x818001,//创建GM帐号响应
            USER_UPDATE = 0x810002,//更新GM帐号信息请求
            USER_UPDATE_RESP = 0x818002,//更新GM帐号信息响应
            USER_DELETE = 0x810003,//删除GM帐号信息请求
            USER_DELETE_RESP = 0x818003,//删除GM帐号信息响应
            USER_QUERY = 0x810004,//查询GM帐号信息请求
            USER_QUERY_RESP = 0x818004,//查询GM帐号信息响应
            USER_PASSWD_MODIF = 0x810005,//密码修改请求
            USER_PASSWD_MODIF_RESP = 0x818005, //密码修改信息响应
            USER_QUERY_ALL = 0x810006,//查询所有GM帐号信息
            USER_QUERY_ALL_RESP = 0x818006,//查询所有GM帐号信息响应
            DEPART_QUERY = 0x810007, //查询部门列表
            DEPART_QUERY_RESP = 0x818007,//查询部门列表响应
            UPDATE_ACTIVEUSER = 0x810008,//更新在线用户状态
            UPDATE_ACTIVEUSER_RESP = 0x818008,//更新在线用户状态响应
            /// <summary>
            /// 模块管理(0x82)
            /// </summary>
            MODULE_CREATE = 0x820001,//创建模块信息请求
            MDDULE_CREATE_RESP = 0x828001,//创建模块信息响应
            MODULE_UPDATE = 0x820002,//更新模块信息请求
            MODULE_UPDATE_RESP = 0x828002,//更新模块信息响应
            MODULE_DELETE = 0x820003,//删除模块请求
            MODULE_DELETE_RESP = 0x828003,//删除模块响应
            MODULE_QUERY = 0x820004,//查询模块信息的请求
            MODULE_QUERY_RESP = 0x828004,//查询模块信息的响应

            /// <summary>
            /// 用户与模块管理(0x83)
            /// </summary>
            USER_MODULE_CREATE = 0x830001,//创建用户与模块请求
            USER_MODULE_CREATE_RESP = 0x838001,//创建用户与模块响应
            USER_MODULE_UPDATE = 0x830002,//更新用户与模块的请求
            USER_MODULE_UPDATE_RESP = 0x838002,//更新用户与模块的响应
            USER_MODULE_DELETE = 0x830003,//删除用户与模块请求
            USER_MODULE_DELETE_RESP = 0x838003,//删除用户与模块响应
            USER_MODULE_QUERY = 0x830004,//查询用户所对应模块请求
            USER_MODULE_QUERY_RESP = 0x838004,//查询用户所对应模块响应

            /// <summary>
            /// 游戏管理(0x84)
            /// </summary>
            GAME_CREATE = 0x840001,//创建GM帐号请求
            GAME_CREATE_RESP = 0x848001,//创建GM帐号响应
            GAME_UPDATE = 0x840002,//更新GM帐号信息请求
            GAME_UPDATE_RESP = 0x848002,//更新GM帐号信息响应
            GAME_DELETE = 0x840003,//删除GM帐号信息请求
            GAME_DELETE_RESP = 0x848003,//删除GM帐号信息响应
            GAME_QUERY = 0x840004,//查询GM帐号信息请求
            GAME_QUERY_RESP = 0x848004,//查询GM帐号信息响应
            GAME_MODULE_QUERY = 0x840005,//查询游戏的模块列表
            GAME_MODULE_QUERY_RESP = 0x848005,//查询游戏的模块列表响应


            /// <summary>
            /// NOTES管理(0x85)
            /// </summary>
            NOTES_LETTER_TRANSFER = 0x850001, //取得邮件列表
            NOTES_LETTER_TRANSFER_RESP = 0x858001,//取得邮件列表的响应
            NOTES_LETTER_PROCESS = 0x850002, //邮件处理
            NOTES_LETTER_PROCESS_RESP = 0x858002,//邮件处理
            NOTES_LETTER_TRANSMIT = 0x850003, //邮件转发列表
            NOTES_LETTER_TRANSMIT_RESP = 0x858003,//邮件转发列表

            /// <summary>
            /// 猛将GM工具(0x86)
            /// </summary>
            MJ_CHARACTERINFO_QUERY = 0x860001,//检查玩家状态
            MJ_CHARACTERINFO_QUERY_RESP = 0x868001,//检查玩家状态响应
            MJ_CHARACTERINFO_UPDATE = 0x860002,//修改玩家状态
            MJ_CHARACTERINFO_UPDATE_RESP = 0x868002,//修改玩家状态响应
            MJ_LOGINTABLE_QUERY = 0x860003,//检查玩家是否在线
            MJ_LOGINTABLE_QUERY_RESP = 0x868003,//检查玩家是否在线响应
            MJ_CHARACTERINFO_EXPLOIT_UPDATE = 0x860004,//修改功勋值
            MJ_CHARACTERINFO_EXPLOIT_UPDATE_RESP = 0x868004,//修改功勋值响应
            MJ_CHARACTERINFO_FRIEND_QUERY = 0x860005,//列出好友名单
            MJ_CHARACTERINFO_FRIEND_QUERY_RESP = 0x868005,//列出好有名单响应
            MJ_CHARACTERINFO_FRIEND_CREATE = 0x860006,//添加好友
            MJ_CHARACTERINFO_FRIEND_CREATE_RESP = 0x868006,//添加好友响应
            MJ_CHARACTERINFO_FRIEND_DELETE = 0x860007,//删除好友
            MJ_CHARACTERINFO_FRIEND_DELETE_RESP = 0x868007,//删除好友响应
            MJ_GUILDTABLE_UPDATE = 0x860008,//修改服务器所有已存在帮会
            MJ_GUILDTABLE_UPDATE_RESP = 0x868008,//修改服务器所有已存在帮会响应
            MJ_ACCOUNT_LOCAL_CREATE = 0x860009,//将服务器上的account表里的玩家信息保存到本地服务器的
            MJ_ACCOUNT_LOCAL_CREATE_RESP = 0x868009,//将服务器上的account表里的玩家信息保存到本地服务器的响应
            MJ_ACCOUNT_REMOTE_DELETE = 0x860010,//永久封停帐号
            MJ_ACCOUNT_REMOTE_DELETE_RESP = 0x868010,//永久封停帐号的响应
            MJ_ACCOUNT_REMOTE_RESTORE = 0x860011,//解封帐号
            MJ_ACCOUNT_REMOTE_RESTORE_RESP = 0x868011,//解封帐号响应
            MJ_ACCOUNT_LIMIT_RESTORE = 0x860012,//有时限的封停
            MJ_ACCOUNT_LIMIT_RESTORE_RESP = 0x868012,//有时限的封停响应
            MJ_ACCOUNTPASSWD_LOCAL_CREATE = 0x860013,//保存玩家密码到本地 
            MJ_ACCOUNTPASSWD_LOCAL_CREATE_RESP = 0x868013,//保存玩家密码到本地
            MJ_ACCOUNTPASSWD_REMOTE_UPDATE = 0x860014,//修改玩家密码 
            MJ_ACCOUNTPASSWD_REMOTE_UPDATE_RESP = 0x868014,//修改玩家密码
            MJ_ACCOUNTPASSWD_REMOTE_RESTORE = 0x860015,//恢复玩家密码
            MJ_ACCOUNTPASSWD_REMOTE_RESTORE_RESP = 0x868015,//恢复玩家密码
            MJ_ITEMLOG_QUERY = 0x860016,//检查该用户交易记录
            MJ_ITEMLOG_QUERY_RESP = 0x868016,//检查该用户交易记录
            MJ_GMTOOLS_LOG_QUERY = 0x860017,//检查使用者操作记录
            MJ_GMTOOLS_LOG_QUERY_RESP = 0x868017,//检查使用者操作记录
            MJ_MONEYSORT_QUERY = 0x860018,//根据金钱排序
            MJ_MONEYSORT_QUERY_RESP = 0x868018,//根据金钱排序的响应
            MJ_LEVELSORT_QUERY = 0x860019,//根据等级排序
            MJ_LEVELSORT_QUERY_RESP = 0x868019,//根据等级排序的响应
            MJ_MONEYFIGHTERSORT_QUERY = 0x860020,//根据不同职业金钱排序
            MJ_MONEYFIGHTERSORT_QUERY_RESP = 0x868020,//根据不同职业金钱排序的响应
            MJ_LEVELFIGHTERSORT_QUERY = 0x860021,//根据不同职业等级排序
            MJ_LEVELFIGHTERSORT_QUERY_RESP = 0x868021,//根据不同职业等级排序的响应
            MJ_MONEYTAOISTSORT_QUERY = 0x860022,//根据道士金钱排序
            MJ_MONEYTAOISTSORT_QUERY_RESP = 0x868022,//根据道士金钱排序的响应
            MJ_LEVELTAOISTSORT_QUERY = 0x860023,//根据道士等级排序
            MJ_LEVELTAOISTSORT_QUERY_RESP = 0x868023,//根据道士等级排序的响应
            MJ_MONEYRABBISORT_QUERY = 0x860024,//根据法师金钱排序
            MJ_MONEYRABBISORT_QUERY_RESP = 0x868024,//根据法师金钱排序的响应
            MJ_LEVELRABBISORT_QUERY = 0x860025,//根据法师等级排序
            MJ_LEVELRABBISORT_QUERY_RESP = 0x868025,//根据法师等级排序的响应
            MJ_ACCOUNT_QUERY = 0x860026,//猛将帐号查询
            MJ_ACCOUNT_QUERY_RESP = 0x868026,//猛将帐号查询响应
            MJ_ACCOUNT_LOCAL_QUERY = 0x860027,//查询猛将本地帐号
            MJ_ACCOUNT_LOCAL_QUERY_RESP = 0x868027,//查询猛将本地帐号响应
            SDO_ACCOUNT_QUERY = 0x870026,//查看玩家的帐号信息
            SDO_ACCOUNT_QUERY_RESP = 0x878026,//查看玩家的帐号信息响应
            SDO_CHARACTERINFO_QUERY = 0x870027,//查看任务资料的信息
            SDO_CHARACTERINFO_QUERY_RESP = 0x878027,//查看人物资料的信息响应
            SDO_ACCOUNT_CLOSE = 0x870028,//封停帐户的权限信息
            SDO_ACCOUNT_CLOSE_RESP = 0x878028,//封停帐户的权限信息响应
            SDO_ACCOUNT_OPEN = 0x870029,//解封帐户的权限信息
            SDO_ACCOUNT_OPEN_RESP = 0x878029,//解封帐户的权限信息响应
            SDO_PASSWORD_RECOVERY = 0x870030,//玩家找回密码
            SDO_PASSWORD_RECOVERY_RESP = 0x878030,//玩家找回密码响应
            SDO_CONSUME_QUERY = 0x870031,//查看玩家的消费记录
            SDO_CONSUME_QUERY_RESP = 0x878031,//查看玩家的消费记录响应
            SDO_USERONLINE_QUERY = 0x870032,//查看玩家上下线状态
            SDO_USERONLINE_QUERY_RESP = 0x878032,//查看玩家上下线状态响应
            SDO_USERTRADE_QUERY = 0x870033,//查看玩家交易状态
            SDO_USERTRADE_QUERY_RESP = 0x878033,//查看玩家交易状态响应
            SDO_CHARACTERINFO_UPDATE = 0x870034,//修改玩家的账号信息
            SDO_CHARACTERINFO_UPDATE_RESP = 0x878034,//修改玩家的账号信息响应
            SDO_ITEMSHOP_QUERY = 0x870035,//查看游戏里面所有道具信息
            SDO_ITEMSHOP_QUERY_RESP = 0x878035,//查看游戏里面所有道具信息响应
            SDO_ITEMSHOP_DELETE = 0x870036,//删除玩家道具信息
            SDO_ITEMSHOP_DELETE_RESP = 0x878036,//删除玩家道具信息响应
            SDO_GIFTBOX_CREATE = 0x870037,//添加玩家礼物盒道具信息
            SDO_GIFTBOX_CREATE_RESP = 0x878037,//添加玩家礼物盒道具信息响应
            SDO_GIFTBOX_QUERY = 0x870038,//查看玩家礼物盒的道具
            SDO_GIFTBOX_QUERY_RESP = 0x878038,//查看玩家礼物盒的道具响应
            SDO_GIFTBOX_DELETE = 0x870039,//删除玩家礼物盒的道具
            SDO_GIFTBOX_DELETE_RESP = 0x878039,//删除玩家礼物盒的道具响应
            SDO_USERLOGIN_STATUS_QUERY = 0x870040,//查看玩家登录状态
            SDO_USERLOGIN_STATUS_QUERY_RESP = 0x878040,//查看玩家登录状态响应
            SDO_ITEMSHOP_BYOWNER_QUERY = 0x870041,////查看玩家身上道具信息
            SDO_ITEMSHOP_BYOWNER_QUERY_RESP = 0x878041,////查看玩家身上道具信息
            SDO_ITEMSHOP_TRADE_QUERY = 0x870042,//查看玩家交易记录信息
            SDO_ITEMSHOP_TRADE_QUERY_RESP = 0x878042,//查看玩家交易记录信息的响应
            SDO_MEMBERSTOPSTATUS_QUERY = 0x870043,//查看该帐号状态
            SDO_MEMBERSTOPSTATUS_QUERY_RESP = 0x878043,///查看该帐号状态的响应
            SDO_MEMBERBANISHMENT_QUERY = 0x870044,//查看所有停封的帐号
            SDO_MEMBERBANISHMENT_QUERY_RESP = 0x878044,//查看所有停封的帐号响应
            SDO_USERMCASH_QUERY = 0x870045,//玩家充值记录查询
            SDO_USERMCASH_QUERY_RESP = 0x878045,//玩家充值记录查询响应
            SDO_USERGCASH_UPDATE = 0x870046,//补偿玩家G币
            SDO_USERGCASH_UPDATE_RESP = 0x878046,//补偿玩家G币的响应
            SDO_MEMBERLOCAL_BANISHMENT = 0x870047,//本地保存停封信息
            SDO_MEMBERLOCAL_BANISHMENT_RESP = 0x878047,//本地保存停封信息响应
            SDO_EMAIL_QUERY = 0x870048,//得到玩家的EMAIL
            SDO_EMAIL_QUERY_RESP = 0x878048,//得到玩家的EMAIL响应
            SDO_USERCHARAGESUM_QUERY = 0x870049,//得到充值记录总和
            SDO_USERCHARAGESUM_QUERY_RESP = 0x878049,//得到充值记录总和响应
            SDO_USERCONSUMESUM_QUERY = 0x870050,//得到消费记录总和
            SDO_USERCONSUMESUM_QUERY_RESP = 0x878050,//得到消费记录总和响应
            SDO_USERGCASH_QUERY = 0x870051,//玩家?币记录查询
            SDO_USERGCASH_QUERY_RESP = 0x878051,//玩家?币记录查询响应

            SDO_USERNICK_UPDATE = 0x870069,
            SDO_USERNICK_UPDATE_RESP = 0x878069,

            SDO_PADKEYWORD_QUERY = 0x870070,
            SDO_PADKEYWORD_QUERY_RESP = 0x878070,

            SDO_BOARDMESSAGE_REQ = 0x870071,
            SDO_BOARDMESSAGE_REQ_RESP = 0x878071,

            SDO_CHANNELLIST_QUERY = 0x870072,
            SDO_CHANNELLIST_QUERY_RESP = 0x878072,
            SDO_ALIVE_REQ = 0x870073,
            SDO_ALIVE_REQ_RESP = 0x878073,

            SDO_BOARDTASK_QUERY = 0x870074,
            SDO_BOARDTASK_QUERY_RESP = 0x878074,

            SDO_BOARDTASK_UPDATE = 0x870075,
            SDO_BOARDTASK_UPDATE_RESP = 0x878075,

            SDO_BOARDTASK_INSERT = 0x870076,
            SDO_BOARDTASK_INSERT_RESP = 0x878076,

            SDO_DAYSLIMIT_QUERY = 0x870077,
            SDO_DAYSLIMIT_QUERY_RESP = 0x878077,
            SDO_FRIENDS_QUERY = 0x870078,//
            SDO_FRIENDS_QUERY_RESP = 0x878078,
            SDO_USERLOGIN_DEL = 0x870079,
            SDO_USERLOGIN_DEL_RESP = 0x878079,
            SDO_USERLOGIN_CLEAR = 0x870080,
            SDO_USERLOGIN_CLEAR_RESP = 0x878080,
            SDO_GATEWAY_QUERY = 0x870081,
            SDO_GATEWAY_QUERY_RESP = 0x878081,

            SDO_USERINTEGRAL_QUERY = 0x870082,
            SDO_USERINTEGRAL_QUERY_RESP = 0x878082,

            SDO_YYHAPPYITEM_QUERY = 0x870084,
            SDO_YYHAPPYITEM_QUERY_RESP = 0x878084,
            SDO_YYHAPPYITEM_CREATE = 0x870085,
            SDO_YYHAPPYITEM_CREATE_RESP = 0x878085,
            SDO_YYHAPPYITEM_UPDATE = 0x870086,
            SDO_YYHAPPYITEM_UPDATE_RESP = 0x878086,
            SDO_YYHAPPYITEM_DELETE = 0x870087,
            SDO_YYHAPPYITEM_DELETE_RESP = 0x878087,
            SDO_StageAward_Query = 0x870111,
            SDO_StageAward_Query_RESP = 0x878111,
            SDO_StageAward_Create = 0x870112,
            SDO_StageAward_Create_RESP = 0x878112,
            SDO_StageAward_Delete = 0x870113,
            SDO_StageAward_Delete_RESP = 0x878113,
            SDO_StageAward_Update = 0x870114,
            SDO_StageAward_Update_RESP = 0x878114,
            SDO_BAOXIANGRate_Query = 0x870120,
            SDO_BAOXIANGRate_Query_RESP = 0x878120,
            SDO_BAOXIANGRate_Update = 0x870121,
            SDO_BAOXIANGRate_Update_RESP = 0x878121,
            MAGIC_Account_Query = 0x710001,//角色基本资料
            MAGIC_Account_Query_Resp = 0x718001,//角色基本资料
            /// <summary>
            /// 劲舞团GM工具(0x88)
            /// </summary>
            AU_ACCOUNT_QUERY = 0x880001,//玩家帐号信息查询
            AU_ACCOUNT_QUERY_RESP = 0x888001,//玩家帐号信息查询响应
            AU_ACCOUNTREMOTE_QUERY = 0x880002,//游戏服务器封停的玩家帐号查询
            AU_ACCOUNTREMOTE_QUERY_RESP = 0x888002,//游戏服务器封停的玩家帐号查询响应
            AU_ACCOUNTLOCAL_QUERY = 0x880003,//本地封停的玩家帐号查询
            AU_ACCOUNTLOCAL_QUERY_RESP = 0x888003,//本地封停的玩家帐号查询响应
            AU_ACCOUNT_CLOSE = 0x880004,//封停的玩家帐号
            AU_ACCOUNT_CLOSE_RESP = 0x888004,//封停的玩家帐号响应
            AU_ACCOUNT_OPEN = 0x880005,//解封的玩家帐号
            AU_ACCOUNT_OPEN_RESP = 0x888005,//解封的玩家帐号响应
            AU_ACCOUNT_BANISHMENT_QUERY = 0x880006,//玩家封停帐号查询
            AU_ACCOUNT_BANISHMENT_QUERY_RESP = 0x888006,//玩家封停帐号查询响应
            AU_CHARACTERINFO_QUERY = 0x880007,//查询玩家的账号信息
            AU_CHARACTERINFO_QUERY_RESP = 0x888007,//查询玩家的账号信息响应
            AU_CHARACTERINFO_UPDATE = 0x880008,//修改玩家的账号信息
            AU_CHARACTERINFO_UPDATE_RESP = 0x888008,//修改玩家的账号信息响应
            AU_ITEMSHOP_QUERY = 0x880009,//查看游戏里面所有道具信息
            AU_ITEMSHOP_QUERY_RESP = 0x888009,//查看游戏里面所有道具信息响应
            AU_ITEMSHOP_DELETE = 0x880010,//删除玩家道具信息
            AU_ITEMSHOP_DELETE_RESP = 0x888010,//删除玩家道具信息响应
            AU_ITEMSHOP_BYOWNER_QUERY = 0x880011,////查看玩家身上道具信息
            AU_ITEMSHOP_BYOWNER_QUERY_RESP = 0x888011,////查看玩家身上道具信息
            AU_ITEMSHOP_TRADE_QUERY = 0x880012,//查看玩家交易记录信息
            AU_ITEMSHOP_TRADE_QUERY_RESP = 0x888012,//查看玩家交易记录信息的响应
            AU_ITEMSHOP_CREATE = 0x880013,//添加玩家礼物盒道具信息
            AU_ITEMSHOP_CREATE_RESP = 0x888013,//添加玩家礼物盒道具信息响应
            AU_LEVELEXP_QUERY = 0x880014,//查看玩家等级经验
            AU_LEVELEXP_QUERY_RESP = 0x888014,////查看玩家等级经验响应
            AU_USERLOGIN_STATUS_QUERY = 0x880015,//查看玩家登录状态
            AU_USERLOGIN_STATUS_QUERY_RESP = 0x888015,//查看玩家登录状态响应
            AU_USERCHARAGESUM_QUERY = 0x880016,//得到充值记录总和
            AU_USERCHARAGESUM_QUERY_RESP = 0x888016,//得到充值记录总和响应
            AU_CONSUME_QUERY = 0x880017,//查看玩家的消费记录
            AU_CONSUME_QUERY_RESP = 0x888017,//查看玩家的消费记录响应
            AU_USERCONSUMESUM_QUERY = 0x880018,//得到消费记录总和
            AU_USERCONSUMESUM_QUERY_RESP = 0x888018,//得到消费记录总和响应
            AU_USERMCASH_QUERY = 0x880019,//玩家充值记录查询
            AU_USERMCASH_QUERY_RESP = 0x888019,//玩家充值记录查询响应
            AU_USERGCASH_QUERY = 0x880020,//玩家?币记录查询
            AU_USERGCASH_QUERY_RESP = 0x888020,//玩家?币记录查询响应
            AU_USERGCASH_UPDATE = 0x880021,//补偿玩家G币
            AU_USERGCASH_UPDATE_RESP = 0x888021,//补偿玩家G币的响应


            Au_User_Msg_Query = 0x880062, //查询玩家在游戏中的聊天记录 
            Au_User_Msg_Query_Resp = 0x888062,//查询玩家在游戏中的聊天记录    

            Au_BroaditeminfoNow_Query = 0x880059,//当前时间用户发送喇叭日志
            Au_BroaditeminfoNow_Query_Resp = 0x888059,//当前时间用户发送喇叭日志

            Au_BroaditeminfoBymsg_Query = 0x880060,//内容模糊查询用户发送喇叭日志
            Au_BroaditeminfoBymsg_Query_Resp = 0x888060,//内容模糊查询用户发送喇叭日志

            AU_MsgServerinfo_Query = 0x800018,
            AU_MsgServerinfo_Query_RESP = 0x808018,

            /// <summary>
            /// 疯狂卡丁车GM工具(0x89)
            /// </summary>
            CR_ACCOUNT_QUERY = 0x890001,//玩家帐号信息查询
            CR_ACCOUNT_QUERY_RESP = 0x898001,//玩家帐号信息查询响应
            CR_ACCOUNTACTIVE_QUERY = 0x890002,//玩家帐号激活信息
            CR_ACCOUNTACTIVE_QUERY_RESP = 0x898002,//玩家帐号激活响应
            CR_CALLBOARD_QUERY = 0x890003,//公告信息查询
            CR_CALLBOARD_QUERY_RESP = 0x898003,//公告信息查询响应
            CR_CALLBOARD_CREATE = 0x890004,//发布公告
            CR_CALLBOARD_CREATE_RESP = 0x898004,//发布公告响应
            CR_CALLBOARD_UPDATE = 0x890005,//更新公告信息
            CR_CALLBOARD_UPDATE_RESP = 0x898005,//更新公告信息的响应
            CR_CALLBOARD_DELETE = 0x890006,//删除公告信息
            CR_CALLBOARD_DELETE_RESP = 0x898006,//删除公告信息的响应

            CR_CHARACTERINFO_QUERY = 0x890007,//玩家角色信息查询
            CR_CHARACTERINFO_QUERY_RESP = 0x898007,//玩家角色信息查询的响应
            CR_CHARACTERINFO_UPDATE = 0x890008,//玩家角色信息查询
            CR_CHARACTERINFO_UPDATE_RESP = 0x898008,//玩家角色信息查询的响应
            CR_CHANNEL_QUERY = 0x890009,//公告频道查询
            CR_CHANNEL_QUERY_RESP = 0x898009,//公告频道查询的响应
            CR_NICKNAME_QUERY = 0x890010,//玩家昵称查询
            CR_NICKNAME_QUERY_RESP = 0x898010,//玩家昵称的响应
            CR_LOGIN_LOGOUT_QUERY = 0x890011,//玩家上线、下线时间查询
            CR_LOGIN_LOGOUT_QUERY_RESP = 0x898011,//玩家上线、下线时间查询的响应
            CR_ERRORCHANNEL_QUERY = 0x890012,//补充错误公告频道查询
            CR_ERRORCHANNEL_QUERY_RESP = 0x898012,//补充错误公告频道查询的响应


            /// <summary>
            /// 充值消费GM工具(0x90)
            /// </summary>
            CARD_USERCHARGEDETAIL_QUERY = 0x900001,//一卡通查询
            CARD_USERCHARGEDETAIL_QUERY_RESP = 0x908001,//一卡通查询响应
            CARD_USERDETAIL_QUERY = 0x900002,//久之游用户注册信息查询
            CARD_USERDETAIL_QUERY_RESP = 0x908002,////久之游用户注册信息查询响应
            CARD_USERCONSUME_QUERY = 0x900003,//休闲币消费查询
            CARD_USERCONSUME_QUERY_RESP = 0x908003,//休闲币消费查询响应
            CARD_VNETCHARGE_QUERY = 0x900004,//互联星空充值查询
            CARD_VNETCHARGE_QUERY_RESP = 0x908004,//互联星空充值查询响应
            CARD_USERDETAIL_SUM_QUERY = 0x900005,//充值合计查询
            CARD_USERDETAIL_SUM_QUERY_RESP = 0x908005,//充值合计查询响应
            CARD_USERCONSUME_SUM_QUERY = 0x900006,//消费合计查询
            CARD_USERCONSUME_SUM_QUERY_RESP = 0x908006,//消费合计响应
            CARD_USERINFO_QUERY = 0x900007,//玩家注册信息查询
            CARD_USERINFO_QUERY_RESP = 0x908007,//玩家注册信息查询响应阿斯科 26日21:00 切　沃 3
            CARD_USERINFO_CLEAR = 0x900008,
            CARD_USERINFO_CLEAR_RESP = 0x908008,
            CARD_USERINITACTIVE_QUERY = 0x900015,//激活游戏
            CARD_USERINITACTIVE_QUERY_RESP = 0x908015,
            /// <summary>
            /// 劲舞团商城(0x91)
            /// </summary>
            AUSHOP_USERGPURCHASE_QUERY = 0x910001,//用户G币购买记录
            AUSHOP_USERGPURCHASE_QUERY_RESP = 0x918001,//用户G币购买记录
            AUSHOP_USERMPURCHASE_QUERY = 0x910002,//用户M币购买记录
            AUSHOP_USERMPURCHASE_QUERY_RESP = 0x918002,//用户M币购买记录
            AUSHOP_AVATARECOVER_QUERY = 0x910003,//道具回收兑换记
            AUSHOP_AVATARECOVER_QUERY_RESP = 0x918003,//道具回收兑换记
            AUSHOP_USERINTERGRAL_QUERY = 0x910004,//用户积分记录
            AUSHOP_USERINTERGRAL_QUERY_RESP = 0x918004,//用户积分记录

            AUSHOP_USERGPURCHASE_SUM_QUERY = 0x910005,//用户G币购买记录合计
            AUSHOP_USERGPURCHASE_SUM_QUERY_RESP = 0x918005,//用户G币购买记录合计响应
            AUSHOP_USERMPURCHASE_SUM_QUERY = 0x910006,//用户M币购买记录合计
            AUSHOP_USERMPURCHASE_SUM_QUERY_RESP = 0x918006,//用户M币购买记录合计响应

            AUSHOP_AVATARECOVER_DETAIL_QUERY = 0x910007,// 具回收兑换详细记录
            AUSHOP_AVATARECOVER_DETAIL_QUERY_RESP = 0x918007,// 具回收兑换详细记录


            DEPARTMENT_CREATE = 0x810009,//部门创建
            DEPARTMENT_CREATE_RESP = 0x818009,//部门创建响应
            DEPARTMENT_UPDATE = 0x810010,//部门修改
            DEPARTMENT_UPDATE_RESP = 0x818010,//部门修改响应
            DEPARTMENT_DELETE = 0x810011,//部门删除
            DEPARTMENT_DELETE_RESP = 0x818011,//部门删除响应
            DEPARTMENT_ADMIN = 0x810012,//部门管理
            DEPARTMENT_ADMIN_RESP = 0x818012,//部门管理响应

            DEPARTMENT_RELATE_QUERY = 0x810013,//部门关联查询
            DEPARTMENT_RELATE_QUERY_RESP = 0x818013,//部门关联查询

            /// <summary>
            /// 劲乐团工具(0x92)
            /// </summary>
            O2JAM_CHARACTERINFO_QUERY = 0x920001,//玩家角色信息查询
            O2JAM_CHARACTERINFO_QUERY_RESP = 0x928001,//玩家角色信息查询
            O2JAM_CHARACTERINFO_UPDATE = 0x920002,//玩家角色信息更新
            O2JAM_CHARACTERINFO_UPDATE_RESP = 0x928002,//玩家角色信息更新
            O2JAM_ITEM_QUERY = 0x920003,//玩家道具信息查询
            O2JAM_ITEM_QUERY_RESP = 0x928003,//玩家角色信息查询
            O2JAM_ITEM_UPDATE = 0x920004,//玩家道具信息更新
            O2JAM_ITEM_UPDATE_RESP = 0x928004,//玩家道具信息更新
            O2JAM_CONSUME_QUERY = 0x920005,//玩家消费信息查询
            O2JAM_CONSUME_QUERY_RESP = 0x928005,//玩家消费信息查询
            O2JAM_ITEMDATA_QUERY = 0x920006,// 具列表查询
            O2JAM_ITEMDATA_QUERY_RESP = 0x928006,// 具列表信息查询
            O2JAM_GIFTBOX_QUERY = 0x920007,//玩家礼物盒查询
            O2JAM_GIFTBOX_QUERY_RESP = 0x928007,//玩家礼物盒查询
            O2JAM_USERGCASH_UPDATE = 0x920008,//补偿玩家G币
            O2JAM_USERGCASH_UPDATE_RESP = 0x928008,//补偿玩家G币的响应
            O2JAM_CONSUME_SUM_QUERY = 0x920009,//玩家消费信息查询
            O2JAM_CONSUME_SUM_QUERY_RESP = 0x928009,//玩家消费信息查询
            O2JAM_GIFTBOX_CREATE_QUERY = 0x920010,//添加玩家礼物盒d具
            O2JAM_GIFTBOX_CREATE_QUERY_RESP = 0x928010,//添加玩家礼物盒d具
            O2JAM_ITEMNAME_QUERY = 0x920011,
            O2JAM_ITEMNAME_QUERY_RESP = 0x928011,

            O2JAM_GIFTBOX_DELETE = 0x920012,
            O2JAM_GIFTBOX_DELETE_RESP = 0x928012,


            DEPART_RELATE_GAME_QUERY = 0x810014,
            DEPART_RELATE_GAME_QUERY_RESP = 0x818014,
            USER_SYSADMIN_QUERY = 0x810015,
            USER_SYSADMIN_QUERY_RESP = 0x818015,
            CARD_USERSECURE_CLEAR = 0x900009,//重置玩家安全码信息
            CARD_USERSECURE_CLEAR_RESP = 0x908009,//重置玩家安全码信息响应


            /// <summary>
            /// 劲乐团IIGM工具(0x93)
            /// </summary>
            O2JAM2_ACCOUNT_QUERY = 0x930001,//玩家帐号信息查询
            O2JAM2_ACCOUNT_QUERY_RESP = 0x938001,//玩家帐号信息查询响应
            O2JAM2_ACCOUNTACTIVE_QUERY = 0x930002,//玩家帐号激活信息
            O2JAM2_ACCOUNTACTIVE_QUERY_RESP = 0x938002,//玩家帐号激活响应

            O2JAM2_CHARACTERINFO_QUERY = 0x930003,//用户信息查询
            O2JAM2_CHARACTERINFO_QUERY_RESP = 0x938003,
            O2JAM2_CHARACTERINFO_UPDATE = 0x930004,//用户信息修改
            O2JAM2_CHARACTERINFO_UPDATE_RESP = 0x938004,
            O2JAM2_ITEMSHOP_QUERY = 0x930005,
            O2JAM2_ITEMSHOP_QUERY_RESP = 0x938005,
            O2JAM2_ITEMSHOP_DELETE = 0x930006,
            O2JAM2_ITEMSHOP_DELETE_RESP = 0x938006,
            O2JAM2_MESSAGE_QUERY = 0x930007,
            O2JAM2_MESSAGE_QUERY_RESP = 0x938007,
            O2JAM2_MESSAGE_CREATE = 0x930008,
            O2JAM2_MESSAGE_CREATE_RESP = 0x938008,
            O2JAM2_MESSAGE_DELETE = 0x930009,
            O2JAM2_MESSAGE_DELETE_RESP = 0x938009,
            O2JAM2_CONSUME_QUERY = 0x930010,
            O2JAM2_CONUMSE_QUERY_RESP = 0x938010,
            O2JAM2_CONSUME_SUM_QUERY = 0x930011,
            O2JAM2_CONUMSE_QUERY_SUM_RESP = 0x938011,
            O2JAM2_TRADE_QUERY = 0x930012,
            O2JAM2_TRADE_QUERY_RESP = 0x938012,
            O2JAM2_TRADE_SUM_QUERY = 0x930013,
            O2JAM2_TRADE_QUERY_SUM_RESP = 0x938013,
            O2JAM2_AVATORLIST_QUERY = 0x930014,
            O2JAM2_AVATORLIST_QUERY_RESP = 0x938014,

            O2JAM2_ACCOUNT_CLOSE = 0x930015,//封停帐户的权限信息
            O2JAM2_ACCOUNT_CLOSE_RESP = 0x938015,//封停帐户的权限信息响应
            O2JAM2_ACCOUNT_OPEN = 0x930016,//解封帐户的权限信息
            O2JAM2_ACCOUNT_OPEN_RESP = 0x938016,//解封帐户的权限信息响应
            O2JAM2_MEMBERBANISHMENT_QUERY = 0x930017,
            O2JAM2_MEMBERBANISHMENT_QUERY_RESP = 0x938017,
            O2JAM2_MEMBERSTOPSTATUS_QUERY = 0x930018,
            O2JAM2_MEMBERSTOPSTATUS_QUERY_RESP = 0x938018,
            O2JAM2_MEMBERLOCAL_BANISHMENT = 0x930019,
            O2JAM2_MEMBERLOCAL_BANISHMENT_RESP = 0x938019,

            O2JAM2_USERLOGIN_DELETE = 0x930020,
            O2JAM2_USERLOGIN_DELETE_RESP = 0x938020,



            SDO_CHALLENGE_QUERY = 0x870052,
            SDO_CHALLENGE_QUERY_RESP = 0x878052,
            SDO_CHALLENGE_INSERT = 0x870053,
            SDO_CHALLENGE_INSERT_RESP = 0x878053,
            SDO_CHALLENGE_UPDATE = 0x870054,
            SDO_CHALLENGE_UPDATE_RESP = 0x878054,
            SDO_CHALLENGE_DELETE = 0x870055,
            SDO_CHALLENGE_DELETE_RESP = 0x878055,
            SDO_MUSICDATA_QUERY = 0x870056,
            SDO_MUSICDATA_QUERY_RESP = 0x878056,


            SDO_MUSICDATA_OWN_QUERY = 0x870057,
            SDO_MUSICDATA_OWN_QUERY_RESP = 0x878057,


            SDO_CHALLENGE_SCENE_QUERY = 0x870058,
            SDO_CHALLENGE_SCENE_QUERY_RESP = 0x878058,
            SDO_CHALLENGE_SCENE_CREATE = 0x870059,
            SDO_CHALLENGE_SCENE_CREATE_RESP = 0x878059,
            SDO_CHALLENGE_SCENE_UPDATE = 0x870060,
            SDO_CHALLENGE_SCENE_UPDATE_RESP = 0x878060,
            SDO_CHALLENGE_SCENE_DELETE = 0x870061,
            SDO_CHALLENGE_SCENE_DELETE_RESP = 0x878061,


            SDO_MEDALITEM_CREATE = 0x870062,
            SDO_MEDALITEM_CREATE_RESP = 0x878062,
            SDO_MEDALITEM_UPDATE = 0x870063,
            SDO_MEDALITEM_UPDATE_RESP = 0x878063,
            SDO_MEDALITEM_DELETE = 0x870064,
            SDO_MEDALITEM_DELETE_RESP = 0x878064,
            SDO_MEDALITEM_QUERY = 0x870065,
            SDO_MEDALITEM_QUERY_RESP = 0x878065,


            SDO_MEDALITEM_OWNER_QUERY = 0x870066,
            SDO_MEDALITEM_OWNER_QUERY_RESP = 0x878066,

            SDO_MEMBERDANCE_OPEN = 0x870067,
            SDO_MEMBERDANCE_OPEN_RESP = 0x878067,
            SDO_MEMBERDANCE_CLOSE = 0x870068,
            SDO_MEMBERDANCE_CLOSE_RESP = 0x878068,
            SDO_PetInfo_Query = 0x870088,
            SDO_PetInfo_Query_RESP = 0x878088,


            #region 敢达
            /// <summary>
            /// 敢达(Ox70)
            /// </summary>
            SD_ActiveCode_Query = 0x700001,
            SD_ActiveCode_Query_Resp = 0x708001,
            SD_Account_Query = 0x700002,//帐号查询
            SD_Account_Query_Resp = 0x708002,
            SD_UserIteminfo_Query = 0x700003,//用户道具信息查询
            SD_UserIteminfo_Query_Resp = 0x708003,

            SD_UserMailinfo_Query = 0x700004,//用户邮件信息查询
            SD_UserMailinfo_Query_Resp = 0x708004,
            SD_UserGuildinfo_Query = 0x700005,//用户公会信息查询
            SD_UserGuildinfo_Query_Resp = 0x708005,
            SD_UserStorageinfo_Query = 0x700006,//用户仓库信息查询
            SD_UserStorageinfo_Query_Resp = 0x708006,
            SD_UserAdditem_Add = 0x700007,//添加道具
            SD_UserAdditem_Add_Resp = 0x708007,
            SD_UserAdditem_Del = 0x700011,//删除道具
            SD_UserAdditem_Del_Resp = 0x708011,
            SD_BanUser_Query = 0x700008,//查询封停用户
            SD_BanUser_Query_Resp = 0x708008,
            SD_BanUser_Ban = 0x700009,//封停用户
            SD_BanUser_Ban_Resp = 0x708009,
            SD_BanUser_UnBan = 0x700010,//解封用户
            SD_BanUser_UnBan_Resp = 0x708010,
            SD_AccountDetail_Query = 0x700012,//帐号详细信息查询
            SD_AccountDetail_Query_Resp = 0x708012,

            SD_UserLoginfo_Query = 0x700013,//用户登陆信息查询
            SD_UserLoginfo_Query_Resp = 0x708013,

            SD_Item_UserUnits_Query = 0x700014,	//玩家机体信息
            SD_Item_UserUnits_Query_Resp = 0x708014,
            SD_Item_UserCombatitems_Query = 0x700015,	//玩家战斗道具
            SD_Item_UserCombatitems_Query_Resp = 0x708015,
            SD_Item_Operator_Query = 0x700016,	//玩家副官道具
            SD_Item_Operator_Query_Resp = 0x708016,
            SD_Item_Paint_Query = 0x700017,	//玩家涂料道具
            SD_Item_Paint_Query_Resp = 0x708017,
            SD_Item_Skill_Query = 0x700018,//玩家技能道具
            SD_Item_Skill_Query_Resp = 0x708018,//玩家技能道具
            SD_Item_Sticker_Query = 0x700019,//玩家标签道具
            SD_Item_Sticker_Query_Resp = 0x708019,//玩家标签道具

            SD_Item_MixTree_Query = 0x700020,	//玩家机体组合
            SD_Item_MixTree_Query_Resp = 0x708020,

            SD_KickUser_Query = 0x700021,//踢用户下线
            SD_KickUser_Query_Resp = 0x708021,//踢用户下线
            SD_UserGrift_Query = 0x700022,//礼物信息查询
            SD_UserGrift_Query_Resp = 0x708022,//礼物信息查询
            SD_SendNotes_Query = 0x700023,//发送公告
            SD_SendNotes_Query_Resp = 0x708023,//发送公告
            SD_SeacrhNotes_Query = 0x700024,//公告信息查询
            SD_SeacrhNotes_Query_Resp = 0x708024,//公告信息查询
            SD_ItemType_Query = 0x700025,//获取道具类型
            SD_ItemType_Query_Resp = 0x708025,//获取道具类型
            SD_ItemList_Query = 0x700026,//获取道具列表
            SD_ItemList_Query_Resp = 0x708026,//获取道具列表

            SD_TmpPassWord_Query = 0x700027,//临时密码
            SD_TmpPassWord_Query_Resp = 0x708027,//临时密码
            SD_ReTmpPassWord_Query = 0x700028,//恢复临时密码
            SD_ReTmpPassWord_Query_Resp = 0x708028,//恢复临时密码
            SD_SearchPassWord_Query = 0x700029,//查询临时密码
            SD_SearchPassWord_Query_Resp = 0x708029,//查询临时密码
            SD_UpdateExp_Query = 0x700030,//修改等级
            SD_UpdateExp_Query_Resp = 0x708030,//修改等级

            SD_Grift_FromUser_Query = 0x700031,//发送人礼物信息查询
            SD_Grift_FromUser_Query_Resp = 0x708031,//发送人礼物信息查询
            SD_Grift_ToUser_Query = 0x700032,//接收人礼物信息查询
            SD_Grift_ToUser_Query_Resp = 0x708032,//接收人礼物信息查询

            SD_TaskList_Update = 0x700033,//修改公告
            SD_TaskList_Update_Resp = 0x708033,//修改公告

            SD_Account_Active_Query = 0x700034,//通过帐号查询激活信息
            SD_Account_Active_Query_Resp = 0x708034,//通过帐号查询激活信息

            SD_BuyLog_Query = 0x700035,//玩家购买道具
            SD_BuyLog_Query_Resp = 0x708035,//玩家购买道具
            SD_Delete_ItemLog_Query = 0x700036,//玩家删除道具记录
            SD_Delete_ItemLog_Query_Resp = 0x708036,//玩家删除道具记录
            SD_LogInfo_Query = 0x700037,//玩家日志记录
            SD_LogInfo_Query_Resp = 0x708037,//玩家日志记录

            SD_Firend_Query = 0x700038,//玩家好友查询
            SD_Firend_Query_Resp = 0x708038,//玩家好友查询

            SD_UserRank_query = 0x700039,//玩家排名查询
            SD_UserRank_query_Resp = 0x708039,//玩家排名查询

            SD_UpdateUnitsExp_Query = 0x700040,//修改玩家机体等级
            SD_UpdateUnitsExp_Query_Resp = 0x708040,//修改玩家机体等级

            SD_UnitsItem_Query = 0x700041,//查询机体道具
            SD_UnitsItem_Query_Resp = 0x708041,//查询机体道具

            SD_GetGmAccount_Query = 0x700042,//查询GM账号
            SD_GetGmAccount_Query_Resp = 0x708042,//查询GM账号
            SD_UpdateGmAccount_Query = 0x700043,//修改GM账号
            SD_UpdateGmAccount_Query_Resp = 0x708043,//修改GM账号

            SD_UpdateMoney_Query = 0x700044,//修改G币
            SD_UpdateMoney_Query_Resp = 0x708044,//修改G币

            SD_Card_Info_Query = 0x700045,//新手/钻石卡查询
            SD_Card_Info_Query_Resp = 0x708045,//新手/钻石卡查询

            SD_UserAdditem_Add_All = 0x700046,//批量添加道具
            SD_UserAdditem_Add_All_Resp = 0x708046,//批量添加道具

            SD_ReGetUnits_Query = 0x700047,//恢复机体
            SD_ReGetUnits_Query_Resp = 0x708047,//恢复机体
            #endregion

            #region 劲舞团2

            JW2_ACCOUNT_QUERY = 0x610001,//玩家帐号信息查询（1.2.3.4.5.8）
            JW2_ACCOUNT_QUERY_RESP = 0x618001,//玩家帐号信息查询响应（1.2.3.4.5.8）
            /////////////封停类/////////////////////////////////////////
            JW2_ACCOUNTREMOTE_QUERY = 0x610002,//游戏服务器封停的玩家帐号查询
            JW2_ACCOUNTREMOTE_QUERY_RESP = 0x618002,//游戏服务器封停的玩家帐号查询响应

            JW2_ACCOUNTLOCAL_QUERY = 0x610003,//本地封停的玩家帐号查询
            JW2_ACCOUNTLOCAL_QUERY_RESP = 0x618003,//本地封停的玩家帐号查询响应

            JW2_ACCOUNT_CLOSE = 0x610004,//封停的玩家帐号
            JW2_ACCOUNT_CLOSE_RESP = 0x618004,//封停的玩家帐号响应
            JW2_ACCOUNT_OPEN = 0x610005,//解封的玩家帐号
            JW2_ACCOUNT_OPEN_RESP = 0x618005,//解封的玩家帐号响应
            JW2_ACCOUNT_BANISHMENT_QUERY = 0x610006,//玩家封停帐号查询
            JW2_ACCOUNT_BANISHMENT_QUERY_RESP = 0x618006,//玩家封停帐号查询响应
            ////////////////////////////
            JW2_BANISHPLAYER = 0x610007,//踢人
            JW2_BANISHPLAYER_RESP = 0x618007,//踢人响应

            JW2_BOARDMESSAGE = 0x610008,//公告
            JW2_BOARDMESSAGE_RESP = 0x618008,//公告响应

            JW2_LOGINOUT_QUERY = 0x610009,//玩家人物登入/登出信息
            JW2_LOGINOUT_QUERY_RESP = 0x618009,//玩家人物登入/登出信息响应
            JW2_RPG_QUERY = 0x610010,//查询故事情节（6）
            JW2_RPG_QUERY_RESP = 0x618010,//查询故事情节响应（6）

            JW2_ITEMSHOP_BYOWNER_QUERY = 0x610011,////查看玩家身上道具信息（7－7）
            JW2_ITEMSHOP_BYOWNER_QUERY_RESP = 0x618011,////查看玩家身上道具信息响应（7－7）


            JW2_DUMMONEY_QUERY = 0x610012,////查询点数和虚拟币（7－8）
            JW2_DUMMONEY_QUERY_RESP = 0x618012,////查询点数和虚拟币响应（7－8）
            JW2_HOME_ITEM_QUERY = 0x610013,////查看房间物品清单与期限（7－9）
            JW2_HOME_ITEM_QUERY_RESP = 0x618013,////查看房间物品清单与期限响应（7－9）
            JW2_SMALL_PRESENT_QUERY = 0x610014,////查看购物，送礼（7－10）
            JW2_SMALL_PRESENT_QUERY_RESP = 0x618014,////查看购物，送礼响应（7－10）
            JW2_WASTE_ITEM_QUERY = 0x610015,////查看消耗性道具（7－11）
            JW2_WASTE_ITEM_QUERY_RESP = 0x618015,////查看消耗性道具响应（7－11）
            JW2_SMALL_BUGLE_QUERY = 0x610016,////查看小喇叭（7－12）
            JW2_SMALL_BUGLE_QUERY_RESP = 0x618016,////查看小喇叭响应（7－12）


            JW2_WEDDINGINFO_QUERY = 0x610017,//婚姻信息
            JW2_WEDDINGINFO_QUERY_RESP = 0x618017,
            JW2_WEDDINGLOG_QUERY = 0x610018,//婚姻历史
            JW2_WEDDINGLOG_QUERY_RESP = 0x618018,
            JW2_WEDDINGGROUND_QUERY = 0x610019,//结婚信息
            JW2_WEDDINGGROUND_QUERY_RESP = 0x618019,
            JW2_COUPLEINFO_QUERY = 0x610020,//情人信息
            JW2_COUPLEINFO_QUERY_RESP = 0x618020,
            JW2_COUPLELOG_QUERY = 0x610021,//情人历史
            JW2_COUPLELOG_QUERY_RESP = 0x618021,


            JW2_FAMILYINFO_QUERY = 0x610022,//家族信息
            JW2_FAMILYINFO_QUERY_RESP = 0x618022,
            JW2_FAMILYMEMBER_QUERY = 0x610023,//家族成员信息
            JW2_FAMILYMEMBER_QUERY_RESP = 0x618023,
            JW2_SHOP_QUERY = 0x610024,//商城信息
            JW2_SHOP_QUERY_RESP = 0x618024,
            JW2_User_Family_Query = 0x610025,//用户家族信息
            JW2_User_Family_Query_Resp = 0x618025,

            JW2_FamilyItemInfo_Query = 0x610026,//家族道具信息
            JW2_FamilyItemInfo_Query_Resp = 0x618026,

            JW2_FamilyBuyLog_Query = 0x610027,//家族购买日志
            JW2_FamilyBuyLog_Query_Resp = 0x618027,

            JW2_FamilyTransfer_Query = 0x610028,//家族转让信息
            JW2_FamilyTransfer_Query_Resp = 0x618028,

            JW2_FriendList_Query = 0x610029,//好友列表
            JW2_FriendList_Query_Resp = 0x618029,

            JW2_BasicInfo_Query = 0x610030,//基地信息查询
            JW2_BasicInfo_Query_Resp = 0x618030,

            JW2_FamilyMember_Applying = 0x610031,//申请中成员
            JW2_FamilyMember_Applying_Resp = 0x618031,

            JW2_BasicRank_Query = 0x610032,//基地等级
            JW2_BasicBank_Query_Resp = 0x618032,


            ///////////公告////////////////////////////
            JW2_BOARDTASK_INSERT = 0x610033,//公告添加
            JW2_BOARDTASK_INSERT_RESP = 0x618033,//公告添加响应
            JW2_BOARDTASK_QUERY = 0x610034,//公告查询
            JW2_BOARDTASK_QUERY_RESP = 0x618034,//公告查询响应
            JW2_BOARDTASK_UPDATE = 0x610035,//公告更新
            JW2_BOARDTASK_UPDATE_RESP = 0x618035,//公告更新响应

            JW2_ITEM_DEL = 0x610036,//道具删除（身上0，物品栏1，礼盒2）
            JW2_ITEM_DEL_RESP = 0x618036,//道具删除（身上0，物品栏1，礼盒2）

            JW2_MODIFYSEX_QUERY = 0x610037,//修改角色性别
            JW2_MODIFYSEX_QUERY_RESP = 0x618037,

            JW2_MODIFYLEVEL_QUERY = 0x610038,//修改等级
            JW2_MODIFYLEVEL_QUERY_RESP = 0x618038,

            JW2_MODIFYEXP_QUERY = 0x610039,//修改经验
            JW2_MODIFYEXP_QUERY_RESP = 0x618039,

            JW2_BAN_BIGBUGLE = 0x610040,//禁用大喇叭
            JW2_BAN_BIGBUGLE_RESP = 0x618040,

            JW2_BAN_SMALLBUGLE = 0x610041,//禁用小喇叭
            JW2_BAN_SMALLBUGLE_RESP = 0x618041,

            JW2_DEL_CHARACTER = 0x610042,//删除角色
            JW2_DEL_CHARACTER_RESP = 0x618042,

            JW2_RECALL_CHARACTER = 0x610043,//恢复角色
            JW2_RECALL_CHARACTER_RESP = 0x618043,

            JW2_MODIFY_MONEY = 0x610044,//修改金钱
            JW2_MODIFY_MONEY_RESP = 0x618044,

            JW2_ADD_ITEM = 0x610045,//增加道具
            JW2_ADD_ITEM_RESP = 0x618045,

            JW2_CREATE_GM = 0x610046,//每个大区创建GM
            JW2_CREATE_GM_RESP = 0x618046,

            JW2_MODIFY_PWD = 0x610047,//修改密码
            JW2_MODIFY_PWD_RESP = 0x618047,

            JW2_RECALL_PWD = 0x610048,//恢复密码
            JW2_RECALL_PWD_RESP = 0x618048,


            JW2_ItemInfo_Query = 0x610049,//道具查询
            JW2_ItemInfo_Query_Resp = 0x618049,//


            JW2_ITEM_SELECT = 0x610050,//道具模糊查询
            JW2_ITEM_SELECT_RESP = 0x618050,//

            JW2_PetInfo_Query = 0x610051,//宠物信息
            JW2_PetInfo_Query_Resp = 0x618051,

            JW2_Messenger_Query = 0x610052,//称号查询
            JW2_Messenger_Query_Resp = 0x618052,

            JW2_Wedding_Paper = 0x610053,//结婚证书
            JW2_Wedding_Paper_Resp = 0x618053,

            JW2_CoupleParty_Card = 0x610054,//情侣派对卡
            JW2_CoupleParty_Card_Resp = 0x618054,


            JW2_MailInfo_Query = 0x610055,//纸箱信息
            JW2_MailInfo_Query_Resp = 0x618055,

            JW2_MoneyLog_Query = 0x610056,//金钱日志查询
            JW2_MoneyLog_Query_Resp = 0x618056,

            JW2_FamilyFund_Log = 0x610057,//基金日志
            JW2_FamilyFund_Log_Resp = 0x618057,

            JW2_FamilyItem_Log = 0x610058,//家族道具日志
            JW2_FamilyItem_Log_Resp = 0x618058,

            JW2_Item_Log = 0x610059,//道具日志
            JW2_Item_Log_Resp = 0x618059,

            JW2_ADD_ITEM_ALL = 0x610060,//增加道具(批量)
            JW2_ADD_ITEM_ALL_RESP = 0x618060,

            JW2_CashMoney_Log = 0x610061,//消费日志
            JW2_CashMoney_Log_Resp = 0x618061,

            JW2_SearchPassWord_Query = 0x610062,//查询临时密码
            JW2_SearchPassWord_Query_Resp = 0x618062,//查询临时密码

            JW2_CenterAvAtarItem_Bag_Query = 0x610063,//中间背包道具
            JW2_CenterAvAtarItem_Bag_Query_Resp = 0x618063,//中间背包道具

            JW2_CenterAvAtarItem_Equip_Query = 0x610064,//中间身上道具
            JW2_CenterAvAtarItem_Equip_Query_Resp = 0x618064,//中间身上道具


            JW2_House_Query = 0x610065,//小黑屋
            JW2_House_Query_Resp = 0x618065,//小黑屋

            JW2_GM_Update = 0x610066,//GM狀態修改
            JW2_GM_Update_Resp = 0x618066,//GM狀態修改
            JW2_JB_Query = 0x610067,//舉報信息查?
            JW2_JB_Query_Resp = 0x618067,//舉報信息查?

            JW2_UpDateFamilyName_Query = 0x610068,//修改家族名
            JW2_UpDateFamilyName_Query_Resp = 0x618068,//修改家族名

            JW2_UpdatePetName_Query = 0x610069,//修改?物名
            JW2_UpdatePetName_Query_Resp = 0x618069,//修改?物名



            JW2_Act_Card_Query = 0x610070,//活动卡查询
            JW2_Act_Card_Query_Resp = 0x618070,//活动卡查询


            JW2_Center_Kick_Query = 0x610071,//中間件踢人
            JW2_Center_Kick_Query_Resp = 0x618071,//中間件踢人

            JW2_ChangeServerExp_Query = 0x610072,//修改服務器??倍數
            JW2_ChangeServerExp_Query_Resp = 0x618072,//修改服務器??倍數

            JW2_ChangeServerMoney_Query = 0x610073,//修改服務器金钱倍數
            JW2_ChangeServerMoney_Query_Resp = 0x618073,//修改服務器金钱倍數

            JW2_MissionInfoLog_Query = 0x610074,//任务LOG查询
            JW2_MissionInfoLog_Query_Resp = 0x618074,//任务LOG查询

            JW2_AgainBuy_Query = 0x610075,//重复购买退款
            JW2_AgainBuy_Query_Resp = 0x618075,//重复购买退款

            JW2_GSSvererList_Query = 0x610076,//服务器列表GS
            JW2_GSSvererList_Query_Resp = 0x618076,//服务器列表GS


            JW2_Materiallist_Query = 0x610079,//用戶合成材料查询
            JW2_Materiallist_Query_Resp = 0x618079,//用戶合成材料查询

            JW2_MaterialHistory_Query = 0x610080,//用戶合成记录
            JW2_MaterialHistory_Query_Resp = 0x618080,//用戶合成记录

            JW2_ACTIVEPOINT_QUERY = 0x610081,//活跃度查询	
            JW2_ACTIVEPOINT_QUERY_Resp = 0x618081,//活跃度查询

            JW2_GETPIC_Query = 0x610082,//获得需要审核的图片列表
            JW2_GETPIC_Query_Resp = 0x618082,//获得需要审核的图片列表

            JW2_CHKPIC_Query = 0x610083,//审核图片 2审核通过，3审核不通过 
            JW2_CHKPIC_Query_Resp = 0x618083,//审核图片 2审核通过，3审核不通过

            JW2_PicCard_Query = 0x610084,//圖片上傳卡使用
            JW2_PicCard_Query_Resp = 0x618084,//圖片上傳卡使用

            JW2_FamilyPet_Query = 0x610085,//家族宠物查询
            JW2_FamilyPet_Query_Resp = 0x618085,//家族宠物查询

            JW2_BuyPetAgg_Query = 0x610086,//族长购买宠物蛋查询
            JW2_BuyPetAgg_Query_Resp = 0x618086,//族长购买宠物蛋查询

            JW2_PetFirend_Query = 0x610087,//家族宠物交友查询
            JW2_PetFirend_Query_Resp = 0x618087,//家族宠物交友查询

            JW2_SmallPetAgg_Query = 0x610088,//家族成员领取小宠物信息查询
            JW2_SmallPetAgg_Query_Resp = 0x618088,//家族成员领取小宠物信息查询
            #endregion

            /// <summary>
            /// 劲爆足球 (0x94)Add by KeHuaQing 2006-09-14
            /// </summary>
            SOCCER_CHARACTERINFO_QUERY = 0x940001,//用户信息查询
            SOCCER_CHARACTERINFO_QUERY_RESP = 0x948001,
            SOCCER_CHARCHECK_QUERY = 0x940002,//用户NameCheck,SocketCheck
            SOCCER_CHARCHECK_QUERY_RESP = 0x948002,
            SOCCER_CHARITEMS_RECOVERY_QUERY = 0x940003,//用户启用
            SOCCER_CCHARITEMS_RECOVERY_QUERY_RESP = 0x948003,
            SOCCER_CHARPOINT_QUERY = 0x940004,//用户G币修改
            SOCCER_CHARPOINT_QUERY_RESP = 0x948004,
            SOCCER_DELETEDCHARACTERINFO_QUERY = 0x940005,//删除用户查询
            SOCCER_DELETEDCHARACTERINFO_QUERY_RESP = 0x948005,

            SOCCER_CHARACTERSTATE_MODIFY = 0x940006,//停封角色
            SOCCER_CHARACTERSTATE_MODIFY_RESP = 0x948006,
            SOCCER_ACCOUNTSTATE_MODIFY = 0x940007,//停封玩家
            SOCCER_ACCOUNTSTATE_MODIFY_RESP = 0x948007,
            SOCCER_CHARACTERSTATE_QUERY = 0x940008,//停封角色查询
            SOCCER_CHARACTERSTATE_QUERY_RESP = 0x948008,
            SOCCER_ACCOUNTSTATE_QUERY = 0x940009,//停封玩家查询
            SOCCER_ACCOUNTSTATE_QUERY_RESP = 0x948009,

            CARD_USERNICK_QUERY = 0x900010,
            CARD_USERNICK_QUERY_RESP = 0x908010,

            AU_USERNICK_UPDATE = 0x880022,
            AU_USERNICK_UPDATE_RESP = 0x888022,


            LINK_SERVERIP_DELETE = 0x800010,
            LINK_SERVERIP_DELETE_RESP = 0x808010,


            NOTDEFINED = 0x0,
            ERROR = 0xFFFFFF,

            #region 光线飞车
            /// <summary>
            /// 光线飞车
            /// </summary>
            RC_Character_Query = 0x960001,
            RC_Character_Query_Resp = 0x968001,
            RC_UserLoginOut_Query = 0x960002,
            RC_UserLoginOut_Query_Resp = 0x968002,
            RC_UserLogin_Del = 0x960003,
            RC_UserLogin_Del_Resp = 0x968003,
            RC_RcCode_Query = 0x960004,
            RC_RcCode_Query_Resp = 0x968004,
            RC_RcUser_Query = 0x960005,
            RC_RcUser_Query_Resp = 0x968005,
            RC_Character_Update = 0x960015,
            RC_Character_Update_Resp = 0x968015,

            RayCity_Character_Query = 0x970001,
            RayCity_Character_Query_Resp = 0x978001,
            RayCity_CharacterState_Query = 0x970002,
            RayCity_CharacterState_Query_Resp = 0x978002,
            RayCity_RaceState_Query = 0x970003,
            RayCity_RaceState_Query_Resp = 0x978003,
            RayCity_InventoryList_Query = 0x970004,
            RayCity_InventoryList_Query_Resp = 0x978004,
            RayCity_InventoryDetail_Query = 0x970005,
            RayCity_InventoryDetail_Query_Resp = 0x978005,
            RayCity_CarList_Query = 0x970006,
            RayCity_CarList_Query_Resp = 0x978006,
            RayCity_Guild_Query = 0x970007,
            RayCity_Guild_Query_Resp = 0x978007,
            RayCity_QuestLog_Query = 0x970008,
            RayCity_QuestLog_Query_Resp = 0x978008,
            RayCity_MissionLog_Query = 0x970009,
            RayCity_MissionLog_Query_Resp = 0x978009,
            RayCity_DealLog_Query = 0x970010,
            RayCity_DealLog_Query_Resp = 0x978010,
            RayCity_FriendList_Query = 0x970011,
            RayCity_FriendList_Query_Resp = 0x978011,
            RayCity_BasicAccount_Query = 0x970012,
            RayCity_BasicAccount_Query_Resp = 0x978012,
            RayCity_GuildMember_Query = 0x970013,
            RayCity_GuildMember_Query_Resp = 0x978013,
            RayCity_BasicCharacter_Query = 0x970014,
            RayCity_BasicCharacter_Query_Resp = 0x978014,
            RayCity_BuyCar_Query = 0x970015,
            RayCity_BuyCar_Query_Resp = 0x978015,
            RayCity_ConnectionLog_Query = 0x970016,
            RayCity_ConnectionLog_Query_Resp = 0x978016,
            RayCity_CarInventory_Query = 0x970017,
            RayCity_CarInventory_Query_Resp = 0x978017,
            RayCity_ConnectionState_Query = 0x970018,
            RayCity_ConnectionState_Resp = 0x978018,
            RayCity_ItemShop_Insert = 0x970019,
            RayCity_ItemShop_Insert_Resp = 0x978019,
            RayCity_ItemShop_Query = 0x970020,
            RayCity_ItemShop_Query_Resp = 0x978020,
            RayCity_MoneyLog_Query = 0x970021,
            RayCity_MoneyLog_Query_Resp = 0x978021,
            RayCity_RaceLog_Query = 0x970022,
            RayCity_RaceLog_Query_Resp = 0x978022,
            RayCity_AddMoney = 0x970023,
            RayCity_AddMoney_Resp = 0x978023,
            RayCity_Skill_Query = 0x970024,
            RayCity_Skill_Query_Resp = 0x978024,
            RayCity_PlayerSkill_Query = 0x970025,
            RayCity_PlayerSkill_Query_Resp = 0x978025,
            RayCity_PlayerSkill_Delete = 0x970026,
            RayCity_PlayerSkill_Delete_Resp = 0x978026,
            RayCity_PlayerSkill_Insert = 0x970027,
            RayCity_PlayerSkill_Insert_Resp = 0x978027,
            RayCity_ItemType_Query = 0x970028,
            RayCity_ItemType_Query_Resp = 0x978028,
            RayCity_TradeInfo_Query = 0x970031,
            RayCity_TradeInfo_Query_Resp = 0x978031,
            RayCity_TradeDetail_Query = 0x970032,
            RayCity_TradeDetail_Query_Resp = 0x978032,
            RayCity_SetPos_Update = 0x970033,
            RayCity_SetPos_Update_Resp = 0x978033,
            RayCity_BingoCard_Query = 0x970036,
            RayCity_BingoCard_Query_Resp = 0x978036,
            RayCity_GMUser_Query = 0x970029,
            RayCity_GMUser_Query_Resp = 0x978029,
            RayCity_GMUser_Update = 0x970030,
            RayCity_GMUser_Update_Resp = 0x978030,
            RayCity_PlayerAccount_Create = 0x970034,
            RayCity_PlayerAccount_Create_Resp = 0x978034,
            RayCity_WareHousePwd_Update = 0x970035,
            RayCity_WareHousePwd_Update_Resp = 0x978035,
            RayCity_UserCharge_Query = 0x970037,
            RayCity_UserCharge_Query_Resp = 0x978037,
            RayCity_ItemConsume_Query = 0x970038,
            RayCity_ItemConsume_Query_Resp = 0x978038,
            RayCity_UserMails_Query = 0x970039,
            RayCity_UserMails_Query_Resp = 0x978039,
            RayCity_CashItemDetailLog_Query = 0x970040,
            RayCity_CashItemDetailLog_Query_Resp = 0x978040,
            RayCity_Coupon_Query = 0x970041,
            RayCity_Coupon_Query_Resp = 0x978041,
            RayCity_ActiveCard_Query = 0x970042,
            RayCity_ActiveCard_Query_Resp = 0x978042,
            RayCity_BoardList_Query = 0x970043,
            RayCity_BoardList_Query_Resp = 0x978043,
            RayCity_BoardList_Insert = 0x970044,
            RayCity_BoardList_Insert_Resp = 0x978044,
            RayCity_BoardList_Delete = 0x970045,
            RayCity_BoardList_Delete_Resp = 0x978045,
            CS_Carinfo_Update = 0x960024,
            CS_Carinfo_Update_Resp = 0x968024,
            #endregion
        }
        #endregion

        /// <summary>
        /// Socket 消息体
        /// </summary>
        [Serializable()]
        [StructLayout(LayoutKind.Sequential)]
        public struct Message_Body
        {
            public TagFormat eTag;
            public TagName eName;
            public object oContent;
        }

        /// <summary>
        /// 日志内容
        /// </summary>
        [Serializable()]
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct TLogData
        {
            public int iSort;
            [MarshalAs(UnmanagedType.LPStr, SizeConst = 255)]
            public string strDescribe;
            //[MarshalAs(UnmanagedType.LPStr)]
            [MarshalAs(UnmanagedType.LPStr, SizeConst = 255)]
            public string strException;
        }
    }
}
