 using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

using C_Global;

namespace C_Socket
{
	/// <summary>
	/// CSocketClient Socket 客户端。
	/// </summary>
	public class CSocketClient
	{
		public NetworkStream mStream = null;	//网络传输
		
		/// <summary>
		/// 构造函数
		/// </summary>
		public CSocketClient() {}

		/// <summary>
		/// Socket 初始化
		/// </summary>
		/// <param name="strAddress">服务器地址</param>
		/// <param name="iPort">服务器端口</param>
		/// <returns>T：成功；F：失败</returns>
		public bool Init(string strAddress, int iPort)
		{
			bool bConnect = false;
			
			try
			{
				this.strServerAddr = strAddress;
				this.iServerPort = iPort;
				
				mTCPClient = new TcpClient();
				mTCPClient.Connect(strAddress, iPort);
                mTCPClient.ReceiveBufferSize = 663840;
				mStream = mTCPClient.GetStream();

				bConnect = true;
			}
			catch (Exception e)
			{
                CEnum.TLogData tLogData = new CEnum.TLogData();

				tLogData.iSort = 5;
				tLogData.strDescribe = "无法与连接服务器建立连接!";
				tLogData.strException = e.Message;	
				
				bConnect = false;
			}

			return bConnect;
		}

		/// <summary>
		/// Socket 释放
		/// </summary>
		public void finallize()
		{
			mStream.Close();
			mTCPClient.Close();
		}
	
		/// <summary>
		/// Socket 状态
		/// </summary>
		/// <returns></returns>
		public bool Status()
		{
			bool bCheckStatus = false;
			
			try
			{
				bCheckStatus = true;
			}
			catch(Exception e)
			{
				bCheckStatus = false;

                CEnum.TLogData tLogData = new CEnum.TLogData();

				tLogData.iSort = 5;
				tLogData.strDescribe = "失去与连接服务器的连接!";
				tLogData.strException = e.Message;
			}
			return bCheckStatus;
		}

		/// <summary>
		/// 接收数据
		/// </summary>
		/// <returns></returns>
		public byte[] ReceiveData()
		{			
			try
			{
				//无限循环 -- 可读数据时退出
				DateTime mStarTime = DateTime.Now;
				for (;;)
				{
					DateTime mEndTime = DateTime.Now;

					if (( mEndTime.Minute - mStarTime.Minute) > 4)
					{
                        CEnum.TLogData tLogData = new CEnum.TLogData();

						tLogData.iSort = 5;
						tLogData.strDescribe = "接收Socket数据超时!";
						tLogData.strException = "N/A";
				
						byte[] bContent = System.Text.Encoding.Unicode.GetBytes("FAILURE");
						return bContent;
					}

					//防止无限循环引起的 CPU 占用率过高现象
					Thread.Sleep(500);

					if(mStream.DataAvailable == true && mStream.CanRead)
					{						
						byte[] bReturn = null;

						int iLength = LengthOfReceive();
						byte[] bContent = new byte[iLength];
						mStream.Read(bContent, 0, iLength);

						//非多组数据
						if (System.Text.Encoding.Unicode.GetString(bContent,0,5) != "BEGIN" && System.Text.Encoding.Unicode.GetString(bContent,0,3) != "END")
						{
							return bContent;
						}
						//多组数据
						else
						{
							//循环读取内容
							for (;;)
							{														
								try
								{
									//读取数据									
									if(mStream.DataAvailable == true && mStream.CanRead)
									{
										int iLoopLength = LengthOfReceive();
										byte[] bLoopContent = new byte[iLoopLength];
										mStream.Read(bLoopContent, 0,iLoopLength);									

										//退出循环
										if (System.Text.Encoding.Unicode.GetString(bLoopContent,0,3) == "END")
										{
											string ssd = System.Text.Encoding.Unicode.GetString(bReturn);
											byte[] tt = RemoveNull(-1, bReturn);
											return tt;
										}

										//组织多组数据
										bReturn = GetLongData(bLoopContent);

										//退出循环
										if (System.Text.Encoding.Unicode.GetString(bReturn) == "FAILURE")
										{
											return bReturn;
										}

										//降低CPU占用率
										Thread.Sleep(500);

										//发送完成标志
										SendDate(System.Text.Encoding.Unicode.GetBytes("OK"));
									}
								}
								catch (Exception e)
								{
                                    CEnum.TLogData tLogData = new CEnum.TLogData();

									tLogData.iSort = 5;
									tLogData.strDescribe = "接收多组Socket数据失败!";
									tLogData.strException = e.Message;

									byte[] bLoopContent = System.Text.Encoding.Unicode.GetBytes("FAILURE");
									return bLoopContent;
								}
							}
						}
					}
				}
			}
			catch(Exception e)
			{
                CEnum.TLogData tLogData = new CEnum.TLogData();

				tLogData.iSort = 5;
				tLogData.strDescribe = "接收Socket数据失败!";
				tLogData.strException = e.Message;

				byte[] bLoopContent = System.Text.Encoding.Unicode.GetBytes("FAILURE");
				return bLoopContent;
			}
		}

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <returns></returns>
        public byte[] ReceiveData(int fileSize)
        {

            //循环读取内容
            //for (; ; )
           // {
                //读取数据									
                //if (mStream.DataAvailable == true && mStream.CanRead)
                //{
                    int iLoopLength = fileSize;
                    byte[] bLoopContent = new byte[iLoopLength];
                    mStream.Read(bLoopContent, 0, iLoopLength);
     
                    return bLoopContent;
                //}
            //}
        }

		/// <summary>
		/// 发送数据包
		/// </summary>
		/// <param name="bContent"></param>
		/// <returns></returns>
		public bool SendDate(byte[] bContent)
		{
			try
			{
				mStream.Write(bContent, 0, bContent.GetLength(0));
				return true;
			}
			catch(Exception e)
			{
                CEnum.TLogData tLogData = new CEnum.TLogData();

				tLogData.iSort = 5;
				tLogData.strDescribe = "发送Socket数据失败!";
				tLogData.strException = e.Message;
				
				return false;
			}		
		}


		#region 私有变量
		private int iServerPort = 0;
		private string strServerAddr = null;
		private TcpClient mTCPClient;				//TCP 连接
		private byte[] bLongData = null;
		private int iLoop = 0;

		/// <summary>
		/// Sockect 接收数据的长度
		/// </summary>
		/// <returns></returns>
		private int LengthOfReceive()
		{
            return mTCPClient.ReceiveBufferSize;
		}

		private byte[] GetLongData(byte[] val)
		{			
			byte[] bReturn = null;
			
			try
			{
				//第一次读取数据
				if (this.bLongData == null)
				{
					this.iLoop = 0;
					this.bLongData = RemoveNull(iLoop, val);
				}
				else
				{				
					this.iLoop++;
				
					//临时数组
					byte[] bTempData = RemoveNull(iLoop, val);
				
					//保留的长度
					int iDataLength = this.bLongData.GetLength(0) + bTempData.GetLength(0);
					bReturn = new byte[iDataLength];

					//保留原来内容
					for (int i=0; i<this.bLongData.GetLength(0); i++)
					{
						bReturn[i] = this.bLongData[i];
					}

					//增加新内容
					for (int i=0; i<bTempData.GetLength(0); i++)
					{
						bReturn[i+this.bLongData.GetLength(0)-1] = bTempData[i];
						
						if (bTempData[i] != 0)
						{
							//bReturn[i+this.bLongData.GetLength(0)-1] = RemoveNull(iLoop, false, bTempData)[i];
						}
					}

					this.bLongData = bReturn;
				}

				return this.bLongData;
			}
			catch (Exception e)
			{
                CEnum.TLogData tLogData = new CEnum.TLogData();

				tLogData.iSort = 5;
				tLogData.strDescribe = "组合Socket数据失败!";
				tLogData.strException = e.Message;

				byte[] bLoopContent = System.Text.Encoding.Unicode.GetBytes("FAILURE");
				return bLoopContent;
			}
		}

		private byte[] RemoveNull(int Key, byte[] val)
		{
			int iIndexOfEnd = 0;
			byte[] bRetrun = null;
			
			for (int i=0; i<val.GetLength(0); i++)
			{
				if (val[i] == 0xEF)
				{
					iIndexOfEnd = i;
				}
			}

			try
			{	
				if (Key == 0)
				{
					bRetrun = new byte[iIndexOfEnd];
					System.Array.Copy(val, bRetrun, iIndexOfEnd);
				}
				else if (Key == -1)
				{
					bRetrun = new byte[val.GetLength(0) + 1];
					System.Array.Copy(val, bRetrun, val.GetLength(0));
					bRetrun[val.GetLength(0)] = 0xEF;
				}
				else
				{
					bRetrun = new byte[iIndexOfEnd +1];
					bRetrun[0] = 0xFD;
					bRetrun[1] = 0x01;
					System.Array.Copy(val, 1, bRetrun, 0, iIndexOfEnd -1);
				}

				return bRetrun;
			}
			catch (Exception e)
			{
                CEnum.TLogData tLogData = new CEnum.TLogData();

                tLogData.iSort = 5;
                tLogData.strDescribe = "组合Socket数据失败!";
                tLogData.strException = e.Message;				
                
                return null;
			}
		}

		#endregion
	}
}
