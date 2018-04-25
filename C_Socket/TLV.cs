 using System;

using C_Global;

namespace C_Socket
{
	/// <summary>
	/// TLV 的摘要说明。
	/// </summary>
	public class TLV
	{
		public const int MAX_TAG_LENGTH = 30;
		public static TagStruct[] Tags =
			{
				new TagStruct(CEnum.TagName.UserName , CEnum.TagFormat.TLV_STRING, 6,"UserName"),
				new TagStruct(CEnum.TagName.PassWord , CEnum.TagFormat.TLV_STRING, 6,"PassWord" ),
				new TagStruct(CEnum.TagName.MAC , CEnum.TagFormat.TLV_NUMBER, 0xffffffff,"Random Number" ),
				new TagStruct(CEnum.TagName.ModuleName , CEnum.TagFormat.TLV_STRING, 0xffffffff,"Module Name" ),
				new TagStruct(CEnum.TagName.ModuleClass , CEnum.TagFormat.TLV_STRING, 0xffffffff,"Module Class" ),
				new TagStruct(CEnum.TagName.ModuleContent , CEnum.TagFormat.TLV_STRING, 0xffffffff,"Module Content" ),
				new TagStruct(CEnum.TagName.User_ID , CEnum.TagFormat.TLV_INTEGER,4, "User ID" ),
				new TagStruct(CEnum.TagName.Module_ID , CEnum.TagFormat.TLV_INTEGER,4, "Module ID" ),
				/*
				new TagStruct(TagName.Billing_Part , TagFormat.TLV_INTEGER,1, "Billing Part" ),
				new TagStruct(TagName.VPN_Account , TagFormat.TLV_NUMBER,0xffffffff, "VPN Number" ),
				new TagStruct(TagName.Fee_Amount , TagFormat.TLV_MONEY,4, "Fee Amount" ),
				new TagStruct(TagName.Fee_Detail , TagFormat.TLV_EXTEND,0xffffffff, "Fee Detail" ),
				new TagStruct(TagName.Billing_Report , TagFormat.TLV_INTEGER,1, "Billing Report" ),
				
				new TagStruct(TagName.Charge_Num , TagFormat.TLV_NUMBER,0xffffffff, "Charge Number" ),
				*/
			};
		
		public TLV() {}
		
		public class TagStruct
		{
            public TagStruct(CEnum.TagName _tag, CEnum.TagFormat _format, uint _len, string _tag_buf)
			{
				tag = _tag;
				format = _format;
				len = _len;
				tag_buf= _tag_buf;
			}
            public CEnum.TagName tag;
            public CEnum.TagFormat format;
			public uint len;
			public string tag_buf;
		}

	}
}
