using System;
using System.Management;
using System.Windows.Forms;

using C_Global;
using C_Event;

namespace M_GM
{
	/// <summary>
	/// Functions 的摘要说明。
	/// </summary>
	public class Functions
	{
		public Functions()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 获取本地机器的mac码
		/// </summary>
		/// <returns></returns>
		public string getMac()
		{
			string mac =null;
			ManagementClass mc;
			mc=new ManagementClass("Win32_NetworkAdapterConfiguration");
			ManagementObjectCollection moc=mc.GetInstances();
			foreach(ManagementObject mo in moc)
			{
				if(mo["IPEnabled"].ToString()=="True")
					mac=mo["MacAddress"].ToString();                    
			}
			return mac;
		}

		/// <summary>
		/// 检测RequestResult返回的结果
		/// </summary>
		public static void ChkServer(C_Global.CEnum.Message_Body[,] mResult)
		{
			//检测状态
			if (mResult[0,0].eName == C_Global.CEnum.TagName.ERROR_Msg)
			{
				MessageBox.Show(mResult[0,0].oContent.ToString());
				//Application.Exit();
			}
		}


	}
}
