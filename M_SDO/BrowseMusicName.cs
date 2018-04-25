using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Global;
using C_Event;

namespace M_SDO
{
    public partial class BrowseMusicName : Form
    {
        public BrowseMusicName()
        {
            InitializeComponent();
        }

        public BrowseMusicName(int musicID,string serverIP,int xPos,int yPos)
        {
            InitializeComponent();

            this._musicID = musicID;
            this._serverIP = serverIP;
            this._xPos = xPos;
            this._yPos = yPos;
        }

        #region 变量
        private CSocketEvent m_ClientEvent = null;

        C_Global.CEnum.Message_Body[,] musicResult = null;

        private int _musicID = 0;
        private string _serverIP = null;
        private int _xPos = 0;
        private int _yPos = 0;
        int seconds = 0;
        #endregion

        #region 调用函数
        /// <summary>
        /// 创建类库中的窗体
        /// </summary>
        /// <param name="oParent">MDI 程序的父窗体</param>
        /// <param name="oSocket">Socket</param>
        /// <returns>类库中的窗体</returns>
        public Form CreateModule(object oParent, object oEvent)
        {
            this.m_ClientEvent = (CSocketEvent)oEvent;
            if (oParent != null)
            {
                this.MdiParent = (Form)oParent;
                this.Show();
            }
            else
            {
                this.ShowDialog();
            }
            return this;
        }
        #endregion

        #region 函数
        public void InitializeMusicList()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];


                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.SDO_ServerIP;
                messageBody[0].oContent = _serverIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.SDO_MusicID1;
                messageBody[1].oContent = _musicID;

                musicResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SDO_MUSICDATA_OWN_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);

                //检测状态
                if (musicResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    musicName.Text = "";
                    return;
                }

                musicName.Text = musicResult[0, 0].oContent.ToString();
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void BrowseMusicName_Load(object sender, EventArgs e)
        {
           
            

            if (_xPos > (Screen.GetWorkingArea(this).Width - this.Width))
            {
                _xPos = Screen.GetWorkingArea(this).Width - this.Width;
            }
            if (_yPos > (Screen.GetWorkingArea(this).Height - this.Height))
            {
                _yPos = Screen.GetWorkingArea(this).Height - this.Height;
            }
            this.Location = new Point(_xPos, _yPos);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dividerPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds += 1;
            if (seconds == 1)
            {
                InitializeMusicList();
                timer1.Enabled = false;
            }
        }
    }


}