using System;
using System.Collections.Generic;
using System.Text;


using C_Global;
using C_Event;

namespace M_GM
{
    class DefaultRoles
    {
        /// <summary>
        /// 设置要获取数据库中ｉｄ号的权限名称
        /// </summary>
        private string[] rolesByGM = new string[]{"修改密码"};

        private string[] rolesByDeptAdmin = new string[] { "用户管理", "修改密码" };

        /// <summary>
        /// 数据库中权限模块的信息列表
        /// </summary>
        private C_Global.CEnum.Message_Body[,] moduleListResult = null;

        /// <summary>
        /// C/S　通道信息
        /// </summary>
        private CSocketEvent m_ClientEvent = null;

        private bool deptAdmin = false;

        public DefaultRoles(CSocketEvent clientEvent,bool deptAdmin)
        {
            this.m_ClientEvent = clientEvent;
            this.deptAdmin = deptAdmin;
        }


        /// <summary>
        /// 获取权限的对应ｉｄ号
        /// </summary>
        /// <returns></returns>
        public int[] GetRoleID()
        {
            string[] arrays = deptAdmin == true ? rolesByDeptAdmin : rolesByGM;

            int[] returnArray = new int[arrays.Length];

            //获取模块列表
            moduleListResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.GAME_MODULE_QUERY, C_Global.CEnum.Msg_Category.GAME_ADMIN, null);
            //检测状态
            if (moduleListResult[0, 0].eName != C_Global.CEnum.TagName.ERROR_Msg)
            {
                int currArrayNum = 0;
                for (int i = 0; i < moduleListResult.GetLength(0); i++)
                {
                    for (int j = 0; j < arrays.Length; j++)
                    {
                        if (moduleListResult[i, 3].oContent.ToString().Equals(arrays[j]))
                        {
                            returnArray[currArrayNum] = int.Parse(moduleListResult[i, 0].oContent.ToString());
                            currArrayNum++;
                        }
                    }
                }
            }

            return returnArray;
        }


        public string GetRoleIDString()
        {
            //组合权限值
            string sModuleID = "";

            //获取权限ｉｄ
            int[] roleIDs = GetRoleID();

            for (int i = 0; i < roleIDs.Length; i++)
            {
                sModuleID += roleIDs[i].ToString() + ",";
            }

            return sModuleID;
        }

        /// <summary>
        /// 执行存储默认权限
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool InsertDefaultRols(int userID)
        {
            //执行结果状态
            bool result = true;

            //获取权限ｉｄ
            int[] roleIDs = GetRoleID();
            
            //组合权限值
            string sModuleID = "";

            for (int i = 0; i < roleIDs.Length; i++)
            {
                sModuleID += roleIDs[i].ToString() + ",";
            }

            C_Global.CEnum.Message_Body[,] resultMsgBody = null;

            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];
            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
            messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[1].eName = C_Global.CEnum.TagName.User_ID;
            messageBody[1].oContent = userID;

            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[2].eName = C_Global.CEnum.TagName.ModuleList;
            messageBody[2].oContent = sModuleID;

            resultMsgBody = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.USER_MODULE_UPDATE, C_Global.CEnum.Msg_Category.USER_MODULE_ADMIN, messageBody);

            if (resultMsgBody[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            {
                result = false;
            }

            if (resultMsgBody[0, 0].oContent.ToString().ToUpper().Equals("SUCESS"))
            {
                result = true;
            }

            return result;
        }


    }
}
