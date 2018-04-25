using System;
using System.Reflection;
using System.Collections;
using System.ComponentModel;

using C_Global;

namespace C_Event
{
	/// <summary>
	/// CForms 创建模块窗体。
	/// </summary>
	public class CFormEvent
	{
		public CFormEvent(Hashtable hApps)
		{
			this.p_Apps = hApps;
		}
		
		/// <summary>
		/// 创建登录框窗体
		/// </summary>
		/// <param name="oParent">父窗体</param>
		/// <param name="oSender">窗体名称</param>
		/// <param name="oEvent">Socket事件</param>
		/// <returns>验证结果</returns>
		public bool CallLogin(object oParent, object oSender, object oEvent)
		{
			//执行结果
			bool bResult = false;
			//判断内容
			string strItem = (string)oSender;
			//模块入口点
			string strEntrance = "CreateModule";

			if( p_Apps.ContainsKey(strItem) )
			{
				CModuleForms mModuleForm = (CModuleForms)p_Apps[strItem];
				Assembly asm = Assembly.LoadFile(mModuleForm.Path);
				Type[] types = asm.GetTypes();

				foreach (Type tCheckType in types)
				{
					if (tCheckType.IsSubclassOf(typeof(System.Windows.Forms.Form)) && tCheckType.Name == strItem)
					{
						object o = Activator.CreateInstance(tCheckType);
							
						try
						{
							MethodInfo mi = tCheckType.GetMethod(strEntrance, new Type[] {typeof(object), typeof(object)});
							bResult = (bool)mi.Invoke(o,new Object[] {oParent, oEvent});
						}
						catch (Exception e)
						{
							bResult = false;

                            CEnum.TLogData tLogData = new CEnum.TLogData();
							
							tLogData.strDescribe = "调用模块信息出错!";
							tLogData.strException = e.Message;
							
							//throw new Exception("调用模块信息出错!");								
						}
					}
				}
			}
			else
			{
				bResult = false;

                CEnum.TLogData tLogData = new CEnum.TLogData();

				tLogData.iSort = 2;
				tLogData.strDescribe = "未找到相应模块信息!";
				tLogData.strException = "N/A";
					
				//throw new Exception("未找到相应模块信息!");
			}			
			
			return bResult;
		}

		/// <summary>
		/// 调用模块窗体 -- 默认方法
		/// </summary>
		/// <param name="oParent">父窗体</param>
		/// <param name="oSender">窗体类</param>
		/// 调用示例：
		///		1、模块窗体中设置属性
		///				[C_Global.CModuleAttribute("显示名称", "窗体类名", "功能描述", "隶属范围")]
		///		2、主窗体中声明变量并赋值（根据需要设置私有或公共类型变量）：
		///				Hashtable m_Apps = C_Global.CModule.Module(模块所在路径,模块扩展名);
		///		2、根据应用程序模式：
		///			SDI模式：
		///				oParent 参数为 NULL （空）
		///				oSender 参数为 m_Apps的属性（根据函数体内判断选择相应属性）
		///			MDI模式
		///				主窗体声明私有静态变量：private static 主窗体类名 定义名称 = null;
		///				主线程中创建主窗体类 定义名称 = new 主窗体类名();
		///				修改默认方法 Application.Run(定义名称);
		///				oParent 参数为 定义名称
		///				oSender 参数为 m_Apps的属性（根据函数体内判断选择相应属性）
		public void CallForm(object oParent, object oSender)
		{
			string strItem = (string)oSender;
			if( p_Apps.ContainsKey(strItem) )
			{
				if( ((CModuleForms)p_Apps[strItem]).Form == null )
				{
					CModuleForms mModuleForm = (CModuleForms)p_Apps[strItem];
					Assembly asm = Assembly.LoadFile(mModuleForm.Path);
					Type[] types = asm.GetTypes();

					foreach (Type tCheckType in types)
					{
						//根据p_Apps属性进行判断
						if (tCheckType.Name == strItem)
						{
							System.Windows.Forms.Form FrmChild = (System.Windows.Forms.Form)Activator.CreateInstance(tCheckType);
							if (oParent != null)
							{
								FrmChild.MdiParent = (System.Windows.Forms.Form)oParent;
							}
							FrmChild.Name = strItem;
							FrmChild.Show();

							FrmChild.Closing += new CancelEventHandler(CloseForm);

							((CModuleForms)p_Apps[strItem]).Form = FrmChild;
						}
					}
				}
				else
				{
					((CModuleForms)p_Apps[strItem]).Form.Activate();
				}
			}
			else
			{
                CEnum.TLogData tLogData = new CEnum.TLogData();

				tLogData.iSort = 2;
				tLogData.strDescribe = "未找到相应模块信息!";
				tLogData.strException = "N/A";

				//throw new Exception("未找到相应模块信息!");
			}
		}

		/// <summary>
		/// 调用模块窗体 -- 传 CSocketEvent 方法
		/// </summary>
		/// <param name="oParent">父窗体</param>
		/// <param name="oSender">窗体类</param>
		/// <param name="oEvent">CSocketEvent 类</param>
		/// 调用示例：
		///			使用方法同默认方法基本一致，仅需要在模块窗体内声明函数
		///			函数声明方法：
		///				public static Form CreateModule(object oParent, object oEvent)
		///				{
		///					ModuleFrm mModuleFrm = new ModuleFrm();
		///					mModuleFrm.m_ClientEvent = (CSocketEvent)oEvent;（模块窗体内声明的变量）
		///					
		///					//MDI模式
		///					if (oParent != null)
		///					{
		///						mModuleFrm.MdiParent = (Form)oParent;
		///						mModuleFrm.Show();
		///					}
		///					//SDI模式
		///					else
		///					{
		///						mModuleFrm.ShowDialog();
		///					}
		///					
		///					return mModuleFrm;
		///				}
		public void CallForm(object oParent, object oSender, object oEvent)
		{
			//MDI 控制
			bool bDisplay = false;
			//判断内容
			string strItem = (string)oSender;
			//模块入口点
			string strEntrance = "CreateModule";

			//MDI模式
			if (oParent != null)
			{
				//保证子窗体唯一性
				if ( ((System.Windows.Forms.Form)oParent).MdiChildren.GetLength(0) > 0)
				{
					for (int i=0; i<((System.Windows.Forms.Form)oParent).MdiChildren.GetLength(0); i++)
					{
						if ( ((System.Windows.Forms.Form)oParent).MdiChildren[i].Name == strItem)
						{
							bDisplay = true;
							((System.Windows.Forms.Form)oParent).MdiChildren[i].Activate();
							return;
						}
						else
						{
							bDisplay = false;
						}
					}

					if (!bDisplay)
					{
						((CModuleForms)p_Apps[strItem]).Form = null;
						
						if( p_Apps.ContainsKey(strItem) )
						{
							if( ((CModuleForms)p_Apps[strItem]).Form == null )
							{
								CModuleForms mModuleForm = (CModuleForms)p_Apps[strItem];
								Assembly asm = Assembly.LoadFile(mModuleForm.Path);
								Type[] types = asm.GetTypes();

								foreach (Type tCheckType in types)
								{
									if (tCheckType.IsSubclassOf(typeof(System.Windows.Forms.Form)) && tCheckType.Name == strItem)
									{
										object o = Activator.CreateInstance(tCheckType);
							
										try
										{
											MethodInfo mi = tCheckType.GetMethod(strEntrance, new Type[] {typeof(object), typeof(object)});
											((CModuleForms)p_Apps[strItem]).Form = (System.Windows.Forms.Form)mi.Invoke(o,new Object[] {oParent, oEvent});
										}
										catch (Exception e)
										{
                                            CEnum.TLogData tLogData = new CEnum.TLogData();

											tLogData.iSort = 5;
											tLogData.strDescribe = "调用模块信息出错!";
											tLogData.strException = e.Message;

											//throw new Exception("调用模块信息出错!");
										}
									}
								}
							}
							else
							{
								((CModuleForms)p_Apps[strItem]).Form.Activate();
							}
						}
						else
						{
                            CEnum.TLogData tLogData = new CEnum.TLogData();

							tLogData.iSort = 2;
							tLogData.strDescribe = "未找到相应模块信息!";
							tLogData.strException = "N/A";				
							
							//throw new Exception("未找到相应模块信息!");
						}						
					}
				}
				else
				{
					if( p_Apps.ContainsKey(strItem) )
					{
						((CModuleForms)p_Apps[strItem]).Form = null;
					
						if( ((CModuleForms)p_Apps[strItem]).Form == null )
						{
							CModuleForms mModuleForm = (CModuleForms)p_Apps[strItem];
							Assembly asm = Assembly.LoadFile(mModuleForm.Path);
							Type[] types = asm.GetTypes();

							foreach (Type tCheckType in types)
							{
								if (tCheckType.IsSubclassOf(typeof(System.Windows.Forms.Form)) && tCheckType.Name == strItem)
								{
									object o = Activator.CreateInstance(tCheckType);
							
									try
									{
										MethodInfo mi = tCheckType.GetMethod(strEntrance, new Type[] {typeof(object), typeof(object)});
										((CModuleForms)p_Apps[strItem]).Form = (System.Windows.Forms.Form)mi.Invoke(o,new Object[] {oParent, oEvent});
									}
									catch (Exception e)
									{
                                        CEnum.TLogData tLogData = new CEnum.TLogData();

										tLogData.iSort = 5;
										tLogData.strDescribe = "调用模块信息出错!";
										tLogData.strException = e.Message;

										//throw new Exception("调用模块信息出错!");									
									}
								}
							}
						}
						else
						{
							((CModuleForms)p_Apps[strItem]).Form.Activate();
						}
					}
					else
					{
                        CEnum.TLogData tLogData = new CEnum.TLogData();

						tLogData.iSort = 2;
						tLogData.strDescribe = "未找到相应模块信息!";
						tLogData.strException = "N/A";

						//throw new Exception("未找到相应模块信息!");
					}				
				}
			}
			//SDI模式
			else
			{
				if( p_Apps.ContainsKey(strItem) )
				{
					((CModuleForms)p_Apps[strItem]).Form = null;
					
					if( ((CModuleForms)p_Apps[strItem]).Form == null )
					{
						CModuleForms mModuleForm = (CModuleForms)p_Apps[strItem];
						Assembly asm = Assembly.LoadFile(mModuleForm.Path);
						Type[] types = asm.GetTypes();

						foreach (Type tCheckType in types)
						{
							if (tCheckType.IsSubclassOf(typeof(System.Windows.Forms.Form)) && tCheckType.Name == strItem)
							{
								object o = Activator.CreateInstance(tCheckType);
							
								try
								{
									MethodInfo mi = tCheckType.GetMethod(strEntrance, new Type[] {typeof(object), typeof(object)});
									((CModuleForms)p_Apps[strItem]).Form = (System.Windows.Forms.Form)mi.Invoke(o,new Object[] {oParent, oEvent});
								}
								catch (Exception e)
								{
                                    CEnum.TLogData tLogData = new CEnum.TLogData();

									tLogData.iSort = 5;
									tLogData.strDescribe = "调用模块信息出错!";
									tLogData.strException = e.Message;

									//throw new Exception("调用模块信息出错!");								
								}
							}
						}
					}
					else
					{
						((CModuleForms)p_Apps[strItem]).Form.Activate();
					}
				}
				else
				{
                    CEnum.TLogData tLogData = new CEnum.TLogData();

					tLogData.iSort = 2;
					tLogData.strDescribe = "未找到相应模块信息!";
					tLogData.strException = "N/A";
					
					//throw new Exception("未找到相应模块信息!");
				}
			}
		}


		/// <summary>
		/// 获取模块类名
		/// </summary>
		/// <param name="Index">索引</param>
		/// <param name="Key">键值</param>
		/// <param name="MenuBody">菜单数组</param>
		/// <returns>类名</returns>
        public string GetModuleClass(int Index, string Key, CEnum.Message_Body[,] MenuBody)
		{
			string strClass = null;

			for (int i=0; i<MenuBody.GetLength(0); i++)
			{
				for (int j=0; j<MenuBody.GetLength(1); j++)
				{
					if (MenuBody[i, j].oContent.Equals(Key))
					{
						strClass = MenuBody[i, Index].oContent.ToString();
						break;
					}				
				}
			}

			return strClass;
		}

		#region 私有变量
		private Hashtable p_Apps;

		private void CloseForm(object sender, CancelEventArgs e)
		{
			string strName = ((System.Windows.Forms.Form)sender).Name;

			if( p_Apps.ContainsKey(strName) )
			{
				((CModuleForms)p_Apps[strName]).Form = null;
			}
		}
		#endregion
	}
}
