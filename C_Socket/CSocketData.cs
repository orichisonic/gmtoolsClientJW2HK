using System;
using System.Reflection;
using System.Collections;

using C_Global;

namespace C_Socket
{
	/// <summary>
	/// CSocketData Socket数据。
	/// </summary>
	public class CSocketData
	{
		//公共变量
		public byte[] bMsgBuffer;
		public uint iMsgLen;
		public Packet m_Packet;
		public bool bValidMsag = false;			
		
		/// <summary>
		/// 构造函数
		/// </summary>
		public CSocketData() {}
		/// <summary>
		/// 构造函数 -- 发送消息
		/// </summary>
		/// <param name="packet">数据包</param>
		public CSocketData(Packet packet)
		{
			if (packet == null || !packet.IsValidPacket)
				return;
			this.m_Packet = packet;
			this.bValidMsag = this.EncodeMessage();		
		}


		/// <summary>
		/// 构造函数 -- 接收消息
		/// </summary>
		/// <param name="buffer">接收内容</param>
		/// <param name="len">长度</param>
		public CSocketData(byte[] bBuffer , uint ilen)
		{
			if (bBuffer == null || bBuffer.Length != ilen)
				return;
			this.bMsgBuffer = bBuffer;
			this.iMsgLen = ilen;
			this.bValidMsag = this.DecodeMessage();		
		}
		/// <summary>
		/// 发送消息
		/// </summary>
		/// <param name="eKey">事件类型</param>
		/// <param name="Msg_Category">消息类型</param>
		/// <param name="tBody">消息内容</param>
		/// <returns>客户端消息</returns>
        public CSocketData SocketSend(CEnum.ServiceKey eKey, CEnum.Msg_Category eCategory, CEnum.Message_Body[] tBody)
		{
			try
			{
				int iMsgLength = 0;			//消息长度
				byte[] bMsg = null;
				TLV_Structure[] tMsg = null;
				
				if (tBody != null)
				{
					iMsgLength = tBody.GetLength(0);
					tMsg = new TLV_Structure[iMsgLength];
					for (int i=0; i<iMsgLength;i++)
					{
						bMsg = TLV_Structure.ValueToByteArray(tBody[i].eTag,tBody[i].oContent);
						tMsg[i] = new TLV_Structure(tBody[i].eName,(uint)bMsg.GetLength(0),bMsg);
					}
				}
				else
				{
					string strSendMsg = "Get List";
					iMsgLength = 1;
					tMsg = new TLV_Structure[1];
					bMsg = System.Text.Encoding.Unicode.GetBytes(strSendMsg);
					tMsg[0] = new TLV_Structure(CEnum.TagName.Connect_Msg,(uint)bMsg.GetLength(0),bMsg);
				}

				Packet_Body body = new Packet_Body(tMsg,(uint)iMsgLength);
				Packet_Head head = new Packet_Head(SeqId_Generator.Instance().GetNewSeqID(), eCategory,eKey,body.m_uiBodyLen);

				CSocketData m_Return = new CSocketData(new Packet(head,body));
				return m_Return;
			}
			catch (Exception e)
			{
                CEnum.TLogData tLogData = new CEnum.TLogData();

				tLogData.iSort = 5;
				tLogData.strDescribe = "构造Socket数据包失败!";
				tLogData.strException = e.Message;

				throw new Exception("发送数据异常!");
			}
		}


		/// <summary>
		/// 组织接收消息
		/// </summary>
		/// <param name="bMsg">接收消息</param>
		/// <returns>CSocketData类</returns>
		public CSocketData SocketRecive(byte[] bMsg)
		{
			try
			{
				CSocketData m_Return = new CSocketData(bMsg, Convert.ToUInt32(bMsg.GetLength(0)));
				return m_Return;
			}
			catch (Exception e)
			{
                CEnum.TLogData tLogData = new CEnum.TLogData();

				tLogData.iSort = 5;
				tLogData.strDescribe = "解析Socket数据包失败!";
				tLogData.strException = e.Message;

				throw new Exception("接收数据异常!");
			}
		}

        public CEnum.Message_Tag_ID GetMessageID()
		{
			if (!this.bValidMsag)
                return CEnum.Message_Tag_ID.ERROR;
			uint uiID;
			byte bCategory = (byte)this.m_Packet.m_Head.m_mcCategory;
			ushort bServicekey = (ushort)this.m_Packet.m_Head.m_skServiceKey;
			uiID = (uint)(bCategory << 16) + (uint)bServicekey;
            return (CEnum.Message_Tag_ID)uiID;
		}

		#region 私有函数
		/// <summary>
		/// 编码消息
		/// </summary>
		/// <returns></returns>
		private bool EncodeMessage() 
		{
			if (this.m_Packet == null || !this.m_Packet.IsValidPacket)
				return false;
			byte[] source = this.m_Packet.ToByteArray();

			System.Collections.ArrayList dest = new System.Collections.ArrayList();
			dest.Add((byte)0xFE);
			for (int i = 0;i < source.Length;i++)
			{
				switch ( source[ i ] ) 
				{

					case 0xFE: 
						dest.Add((byte)0xFD);
						dest.Add((byte)0x01);
						break;
					case 0xEF: 
						dest.Add((byte)0xFD);
						dest.Add((byte)0xF2);
						break;
					case 0xFD: 
						dest.Add((byte)0xFD);
						dest.Add((byte)0x00);
						break;
					default :
						dest.Add((byte)source[i]);
						break;
				}
			}
			dest.Add((byte)0xEF);
			int size = dest.Count;
			this.iMsgLen = (uint)size;
			this.bMsgBuffer = new byte[size];
			for (int i = 0;i < size;i ++)
				this.bMsgBuffer[i] = (byte)dest[i];
			return true;
		}
		/// <summary>
		/// 解码消息
		/// </summary>
		/// <returns></returns>
		private bool DecodeMessage() 
		{			
			int head = 0 , tail = 0;
			for ( ; head < iMsgLen ; head ++ )
				if ( bMsgBuffer[ head ] == 0xFE )
					break;
			for ( tail = head ; tail < iMsgLen ; tail ++ )
				if ( bMsgBuffer[ tail ] == 0xEF )
					break;
			// tail extends the packet size , the packet corrupts.
			if ( tail >= iMsgLen )
				return false;

			System.Collections.ArrayList dest = new System.Collections.ArrayList();
			for ( int i = head + 1 ; i < tail ; i ++ ) 
			{
				if ( bMsgBuffer[ i ] == 0xFD ) 
				{
					switch ( bMsgBuffer[ ++i ] ) 
					{
						case 0x01: 
							dest.Add((byte)0xFE);
							break;
						case 0x00: 
							dest.Add((byte)0xFD);
							break;
						case 0xF2: 
							dest.Add((byte)0xEF);
							break;
						default: 
							return false;
					}
				}
				else					
					dest.Add(bMsgBuffer[ i ]);
			}
			int size = dest.Count;
			byte[] buffer = new byte[size];
			for (int i = 0;i < size;i ++)
				buffer[i] = (byte)dest[i];
			this.m_Packet = new Packet(buffer,(uint)size);
			if (this.m_Packet.IsValidPacket)
				return true;
			else
				return false;
		}
		#endregion


        
	}
}
