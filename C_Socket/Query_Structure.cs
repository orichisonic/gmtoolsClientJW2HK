using System;
using System.Collections;

using C_Global;

namespace C_Socket
{
	public class TagStruct
	{
        public C_Global.CEnum.TagName tag;
        public C_Global.CEnum.TagFormat format;
        public uint len;
        public byte[] tag_buf;

        public TagStruct(C_Global.CEnum.TagName _tag, C_Global.CEnum.TagFormat _format, uint _len, byte[] _tag_buf)
        {
            tag = _tag;
            format = _format;
            len = _len;
            tag_buf = new byte[len];
            tag_buf = _tag_buf;
        }
		
	}
	/// <summary>
	/// Query_Structure 的摘要说明。
	/// </summary>
	public class Query_Structure : TLV_Structure
	{		
		public TagStruct[] m_tagList;
		public uint structLen = 0;
		public Query_Structure(uint len)
		{
			structLen = len;
			m_tagList = new TagStruct[structLen];
                                   			
		}
        public void AddTagKey(C_Global.CEnum.TagName tag, C_Global.CEnum.TagFormat style, uint len, byte[] val)
        {
            int i = 0;
            for (i = 0; i < structLen; i++)
            {
                if (null == m_tagList[i])
                    break;
            }
            m_tagList[i] = new TagStruct(tag, style, len, val);
        }
		
	}
}
