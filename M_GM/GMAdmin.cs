using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using C_Global;
using C_Event;

namespace M_GM
{
	/// <summary>
	/// GMAdmin 的摘要说明。
	/// </summary>
	public class GMAdmin
	{
		public GMAdmin()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public GMAdmin(C_Global.CEnum.Message_Body[,] mComboBody)
		{
			this.pComboBody = mComboBody;
		}

		/// <summary>
		/// 构造ListView
		/// </summary>
		/// <param name="m_Event">事件类</param>
		/// <param name="mView">列表</param>
		/// <param name="mMsgBody">消息</param>
		/// <returns>列表</returns>
		public static ListView DisplayView(CSocketEvent m_Event, ListView mView, C_Global.CEnum.Message_Body[,] mMsgBody,bool isTag)
		{
			//读取用户信息
			//构造头
			try
			{
				for (int i=0; i<mMsgBody.GetLength(1); i++)
				{
					ColumnHeader mClmParent = new ColumnHeader();
					mClmParent.Text = m_Event.DecodeFieldName(mMsgBody[0,i].eName);
					mView.Columns.Add( mClmParent);
				}

				//构造内容
				for (int i=0; i<mMsgBody.GetLength(0); i++)
				{
					ListViewItem mItmParent = new ListViewItem();
					string[] mItemContent = new string[mMsgBody.GetLength(1)];

					for (int j=0; j<mMsgBody.GetLength(1); j++)
					{
						
						mItemContent[j] = mMsgBody[i,j].oContent.ToString();
									
					}
					ListViewItem mlistViewItem = new ListViewItem(mItemContent, -1);
				
					mView.Items.Add(mlistViewItem);
					if (isTag)
					{
						mView.Items[i].Tag = mMsgBody[i,0].oContent.ToString();
					}
				}
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
			
			return mView;
		}

		
		public static ComboBox DisplayComboBox(CSocketEvent m_Event, ComboBox mComboBox, C_Global.CEnum.Message_Body[,] mMsgBody)
		{
			for (int i=0; i<mMsgBody.GetLength(0); i++)
			{
				for (int j=0; j<mMsgBody.GetLength(1); j++)
				{
					if (mMsgBody[i,j].eName == C_Global.CEnum.TagName.GameName)
					{
						mComboBox.Items.Add(mMsgBody[i,j].oContent.ToString().Trim());
					}
				}
			}
			return mComboBox;
		}

		public static int GetContentID(C_Global.CEnum.Message_Body[,] mMsg, string strSearch)
		{
			int iResult = 0;
			
			for (int i=0; i<mMsg.GetLength(0); i++)
			{
				for (int j=0; j<mMsg.GetLength(1); j++)
				{
					if (mMsg[i,j].eName == C_Global.CEnum.TagName.GameID && mMsg[i,j+1].oContent.Equals(strSearch))
					{
						iResult = Convert.ToInt32(mMsg[i,j].oContent.ToString());
					}
				}
			}

			return iResult;
		}

		public static C_Global.CEnum.Message_Body[,] ModuleAdd(CSocketEvent m_Event, C_Global.CEnum.Message_Body[] mMsg)
		{
			C_Global.CEnum.Message_Body[,] mReturn = null;


			mReturn = 
				m_Event.RequestResult(C_Global.CEnum.ServiceKey.MODULE_CREATE, C_Global.CEnum.Msg_Category.MODULE_ADMIN, mMsg);

			return mReturn;
		}

		public static C_Global.CEnum.Message_Body[,] ModuleModi(CSocketEvent m_Event, C_Global.CEnum.Message_Body[] mMsg)
		{
			C_Global.CEnum.Message_Body[,] mReturn = null;


			mReturn = 
				m_Event.RequestResult(C_Global.CEnum.ServiceKey.MODULE_UPDATE, C_Global.CEnum.Msg_Category.MODULE_ADMIN, mMsg);

			return mReturn;
		}

		private C_Global.CEnum.Message_Body[,] pComboBody = null;
	}
}
