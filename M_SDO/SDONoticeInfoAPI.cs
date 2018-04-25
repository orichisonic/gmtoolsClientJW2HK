using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Text;

using GM_Server.SDODataInfo;
using System.Windows.Forms;
namespace GM_Server.SDOAPI
{
	/// <summary>
	/// SDONoticeInfoAPI 的摘要说明。
	/// </summary>
	public class SDONoticeInfoAPI
	{

        private delegate void LoadChannel(int iItemIndex, short sPlanetID, short sChannelID, int iLimitUser, int iCurrentUser, string sAddr, System.Windows.Forms.Form _form);
		//Message msg;
		CMsg msgStruct;
		Socket client = null;

        System.Windows.Forms.Form _form = null;
        System.Windows.Forms.ListView _listView = null;

        short wPlanetID = 0, wChannelID = 0;
        int iLimitUser = 0, iCurrentUser = 0;
        string ipaddr = "";
        int iItemIndex = 0;

		public SDONoticeInfoAPI()
		{
		}

        public SDONoticeInfoAPI(System.Windows.Forms.Form _form,System.Windows.Forms.ListView _listView)
        {
            this._form = _form;
            this._listView = _listView;
        }


		public void connect_Req(string serverIP)
		{
			string userName = "sdohuodong05";
			string password = "asdfjkl";
			short version = 1;
			short version1 = 6;
			int port = 15010;
			try
			{
				IPAddress ipAdress = IPAddress.Parse(serverIP);
				client = new Socket(AddressFamily.InterNetwork,
					SocketType.Stream,
					ProtocolType.Tcp);
 
				//Console.WriteLine("Establishing Connection to {0}",serverIP);
				IPEndPoint ipReomtePoint = new IPEndPoint(ipAdress,port);

				client.Connect(ipReomtePoint);
				if(client.Connected==true)
				{
					//Console.WriteLine("Connection established");
					msgStruct = new CMsg((short)protocol.GW_LOGIN_REQ);
					msgStruct.WriteData(System.Text.Encoding.Default.GetBytes(userName),userName.Length);
					msgStruct.WriteData(System.Text.Encoding.Default.GetBytes(password),password.Length);
					byte[] ret = new byte[]{
											   (byte)version,(byte)(version>>8)
										   };
					msgStruct.WriteData(ret,1);
					ret = new byte[]{
										(byte)version1,(byte)(version1>>8)
									};
					msgStruct.WriteData(ret,1);
					msgStruct.writeLength(msgStruct.GetSize());
					client.Send(msgStruct.GetBuf(),0,msgStruct.GetSize(),0);
					ThreadStart wokerStart = new ThreadStart(ReadThreadFunc);
					Thread workThread = new Thread(wokerStart);
					workThread.Start();
				}
			}
			catch(SocketException ex)
			{
				//Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
			}

		}
        public bool ChannelList_Query(string srvIP)
		{
			string serverIP = null;
			try
			{
                serverIP = srvIP;
				//serverIP = System.Text.Encoding.Default.GetString(msg.m_packet.m_Body.getTLVByTag(TagName.SDO_ServerIP).m_bValueBuffer);
				connect_Req(serverIP);
				return true;

				
			}
			catch(System.Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;

			}
		}
		public void ReadThreadFunc()
		{
			while(true)
			{
				if(receiveMsg()>0)
				{
					parseMsg();

					msgStruct = new CMsg((short)protocol.GM_CHANNELLIST_REQ);
					msgStruct.writeLength(msgStruct.GetSize());
					client.Send(msgStruct.GetBuf(),0,msgStruct.GetSize(),0);
					Thread.Sleep(1000);
				}
			}
		}
		/*接收消息
		 * */
		public int receiveMsg()
		{
			byte[] recvBuf  = new byte[4096];
			short size = 0;
			try
			{
				if(client.Receive(recvBuf,0,2,0)!= 2)
					return 0;

				size = (short)CMsg.toInteger(recvBuf,2);
				if(size > 0)
				{
					if(size > CMsg.NETWORK_MSG_SIZE)
					{
						Console.WriteLine("Message Too Large");
						return 0;
					}
					if(client.Receive(recvBuf,2,size-2,0) == size-2 )
					{
						System.Array.Copy(recvBuf,msgStruct.GetBuf(),size);
						msgStruct.Clear();
						return size;
					}
				}
			}
			catch(System.Exception ex)
			{
				Console.WriteLine(ex.Message);
				return 0;
			}
			return 0;
		}
		/*消息解析
		 * */
		public int parseMsg()
		{
            try
            {
                switch (msgStruct.ID())
                {
                    case protocol.GW_LOGIN_ACK:
                        {
                            int res = 0;
                            //m_msg >> res;
                            if (res == (int)protocol.RET_OK)
                            {
                                //Console.WriteLine("登录成功");
                            }
                            else
                            {
                                MessageBox.Show("登录失败");
                            }
                        }
                        break;
                    case protocol.GM_CHANNELLIST_ACK:
                        {


                            //M_SDO.Notice notice = new M_SDO.Notice();
                            int nChan = 0;
                            byte bHasMore = 0;
                            
                            nChan = (int)msgStruct.ReadData(nChan, 4);
                            bHasMore = Convert.ToByte(msgStruct.ReadData(bHasMore, 1));
                            //Console.WriteLine("收到频道信息"+nChan+"个");
                            for (int i = 0; i < nChan; i++)
                            {
                                wPlanetID = Convert.ToInt16(msgStruct.ReadData(wPlanetID, 2));
                                wChannelID = Convert.ToInt16(msgStruct.ReadData(wChannelID, 2));
                                iLimitUser = (int)msgStruct.ReadData(iLimitUser, 4);
                                iCurrentUser = (int)msgStruct.ReadData(iCurrentUser, 4);
                                ipaddr = Convert.ToString(msgStruct.ReadData(ipaddr, 15));
                                iItemIndex = i;

                                _form.Invoke(new EventHandler(ReLoadChannel1));
                                //this._listView.Invoke(new LoadChannel(ToLoadChannel));

                                // LoadChannel loadChannel = new LoadChannel(notice.ToLoadChannel);
                                // loadChannel(i, wPlanetID, wChannelID, iLimitUser, iCurrentUser, ipaddr, this._form);
                                //Console.WriteLine(wPlanetID+"/"+wChannelID+"/"+iLimitUser+"/"+iCurrentUser+"/");
                                //this._listView.Items.Add(wPlanetID.ToString() + "/" + wChannelID.ToString() + "/" + iLimitUser.ToString() + "/" + iCurrentUser.ToString() + "/" + ipaddr);
                                //this._listView.Items[i].Tag = wPlanetID.ToString() + "/" + wChannelID.ToString() + "/" + iLimitUser.ToString() + "/" + iCurrentUser.ToString() + "/" + ipaddr;
                                //Console.WriteLine(ipaddr);
                            }
                            Thread.CurrentThread.Abort();
                        }
                        break;
                    case protocol.EH_ALIVE_REQ:
                        {
                            msgStruct = new CMsg((short)protocol.EH_ALIVE_ACK);
                            send_msg(msgStruct);
                        }
                        break;
                    default:
                        //Console.WriteLine("Unknown Message Received:"+msgStruct.ID());
                        break;
                    //////m_debugList.AddString(debugString);
                }
            }
            catch { }
			return 0;

		}

        private void ReLoadChannel1(object sender, System.EventArgs e)
        {
            //this._listView.Items.Add("aadddff");
            this._listView.Items.Add(wPlanetID.ToString() + "/" + wChannelID.ToString() + "/" + iLimitUser.ToString() + "/" + iCurrentUser.ToString() + "/" + ipaddr);
            this._listView.Items[iItemIndex].Tag = wPlanetID.ToString() + "/" + wChannelID.ToString() + "/" + iLimitUser.ToString() + "/" + iCurrentUser.ToString() + "/" + ipaddr;
        }


        private void Invoke(EventHandler eventHandler)
        {
            throw new Exception("The method or operation is not implemented.");
        }


        



		int send_msg(CMsg msg)
		{
			return client.Send(msg.GetBuf(),msg.GetSize(),0);
		}

        

		public void sendBoardMsg_Req(int[,] iArrayPC ,string sNotcie)
		{
            int nChan = iArrayPC.GetLength(0);

            string strNotice = sNotcie;

			msgStruct = new CMsg((short)protocol.GM_NOTICE_REQ);

			msgStruct.WriteData(System.Text.Encoding.Default.GetBytes(strNotice),strNotice.Length);

			byte[] ret = new byte[]{
									   (byte)nChan,(byte)(nChan>>8)
								   };
			msgStruct.WriteData(ret,2);
 
			for(int i=0;i<nChan;i++)
			{
                //星球
                 ret = new byte[]{
									   (byte)iArrayPC[i,0],(byte)(nChan>>8)
								 };
				 msgStruct.WriteData(ret,2);
                //频道
                 ret = new byte[]{
									   (byte)iArrayPC[i,1],(byte)(nChan>>8)
								 };
				msgStruct.WriteData(ret,2);
			}
			msgStruct.writeLength(msgStruct.GetSize());
			client.Send(msgStruct.GetBuf(),0,msgStruct.GetSize(),0);
		}

		public int _send(byte[] buf,int len,int flags)
		{
			int sended=0;
			while(sended<len)
			{
				int now=client.Send(buf,sended,len-sended,0);
				if(now==-1) break;
				sended+=now;
			}
			return sended;
		}
		public int _recv(byte[] buf,int len,int flags)
		{
			int recved=0;
			while(recved<len)
			{
				int now=client.Receive(buf,recved,len-recved,0);
				if(now==-1||now==0) break;
				recved+=now;
			}
			return recved;
		}
		public short LOWORD(ulong itemData)
		{
            return ((short)((ulong)(itemData) & 0xffff));
		}
		public short HIWORD(ulong itemData)
		{
            return ((short)((ulong)(itemData) >> 16));
		}
	}
}
