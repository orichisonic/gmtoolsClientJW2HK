using System;

namespace C_Socket
{
	/// <summary>
	/// SeqId_Generator 创建消息ID。
	/// </summary>
	public class SeqId_Generator
	{
		public const uint ERROR_ID = 0;
		private static SeqId_Generator theSingleton = null;
		private uint m_uiID;
		
		public SeqId_Generator() 
		{
			this.m_uiID = 1;
		}

		public SeqId_Generator( uint uiInitID ) 
		{
			if (uiInitID == 0) uiInitID = 1;
			this.m_uiID = uiInitID;
		}

		public static SeqId_Generator Instance() 
		{
			if (theSingleton == null)
				theSingleton = new SeqId_Generator();
			return theSingleton;
		}

		public uint GetNewSeqID() 
		{
			if ( this.m_uiID == 0xFFFFFFFF )
				return this.m_uiID = 1;
			else
				return this.m_uiID ++;
		}

		public void SetCurrSeqID( uint uiID ) 
		{
			if (uiID == 0) uiID = 1;
			this.m_uiID = uiID;
		}
	}
}
