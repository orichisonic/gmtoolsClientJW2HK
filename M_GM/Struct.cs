using System;

namespace M_GM
{
	#region （用户、游戏、游戏权限）结构

	/// <summary>
	/// 用户
	/// </summary>
	public struct _USERACCOUNT
	{
		public string Name;			//名称
		public string fullName;		//全名
		public string description;	//描述
		public string mac;			//验证码
		public string pwd;			//密码
		public bool mustModiPwd;	//用户下次登陆时必须更改密码
		public bool cantModiPwd;	//用户不能更改密码
		public bool isStop;			//帐户停用标记
		public int[,] gameRole;		//游戏权限。第一维存放游戏id；第二维为数组（int），存放该游戏中可操作的游戏的id
	}

	/// <summary>
	/// 游戏
	/// </summary>
	public struct _GAMELIST
	{
		public int gameID;		//游戏id
		public string Name;		//游戏名称
		public string description;//游戏描述
		
	}

	/// <summary>
	///	权限
	/// </summary>
	public struct _ROLE
	{
		public int[] userID;	//现可操作本模块的用户id
		public int gameID;		//所属游戏id
		public int roleID;		//模块id
		public string roleName;	//模块名称
		public string roleClass;//模块类名
		public string roleContent;//描述
	}


	#endregion

	

	

}
