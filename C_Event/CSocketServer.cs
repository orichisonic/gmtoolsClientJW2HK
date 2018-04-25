using System;
using System.Collections.Generic;
using System.Text;

namespace C_Event
{
    /// <summary>
    /// 弃用，改放到CSocketEvent类下
    /// </summary>
    public class CSocketServer
    {
        /// <summary>
        /// 获取CSocketEvent中已存的ServersCount、IpForServer + i、(CSocketEvent)(Server + i)
        /// 
        /// </summary>
        /// <param name="m_ClientEvent"></param>
        /// <returns></returns>
        public CSocketEvent GetSocket(CSocketEvent m_ClientEvent,string sCurrServerIp)
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
    }
}
