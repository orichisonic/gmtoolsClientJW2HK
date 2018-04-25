using System;

namespace C_Socket
{
	/// <summary>
	/// CException 引用异常类。
	/// </summary>
	///
	/*
	public class CException : System.Exception
	{
		public CException()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
	}
	*/

	public class CException : System.Exception
	{
		private int m_iGMMsg_ErrCode;
		private string m_sGMMsg_ErrMessage;
		public CException ()
		{
			this.m_iGMMsg_ErrCode = 0;
			this.m_sGMMsg_ErrMessage = null;
		}
		public CException(string sMessage) : base(sMessage)
		{
			this.m_iGMMsg_ErrCode = 0;
			this.m_sGMMsg_ErrMessage = null;
		}


		public string GMMsg_ErrCode
		{
			set
			{
				this.m_iGMMsg_ErrCode = System.Int32.Parse(value.Substring(value.Length-7,7));
			}
			get
			{
				return "GMMsg-0" + this.m_iGMMsg_ErrCode.ToString("D4");
			}
		}

		public string GMMsg_ErrMessage
		{
			set
			{
				this.m_sGMMsg_ErrMessage = value;
			}
			get
			{
				return this.m_sGMMsg_ErrMessage;
			}
		}

		public override string ToString()
		{
			return "[GMMsg-0" 
				+ this.m_iGMMsg_ErrCode.ToString("D4")
				+ "]"
				+ this.m_sGMMsg_ErrMessage;
		}
	}
	public class TypeException : CException
	{
		public TypeException(string sParameterType,string sExpectedType)
		{
			this.GMMsg_ErrCode = "GMMsg-01";
			this.GMMsg_ErrMessage = "参数预期类型错误(预期类型-"+sExpectedType+",实际类型-"+sParameterType+")";
		}
		public TypeException(string sMessage):base(sMessage)
		{
			this.GMMsg_ErrCode = "GMMsg-01";
			this.GMMsg_ErrMessage = "参数预期类型错误";

		}
	}
	public class ValueException : CException
	{
		public ValueException(string sParameterValue,string sExpectedValue)
		{
			this.GMMsg_ErrCode = "GMMsg-02";
			this.GMMsg_ErrMessage = "参数值错误(预期值-"+sExpectedValue+",实际值-"+sParameterValue+")";
		}
		public ValueException(string sMessage):base(sMessage)
		{
			this.GMMsg_ErrCode = "GMMsg-02";
			this.GMMsg_ErrMessage = "参数值错误";
		}
	}
}
