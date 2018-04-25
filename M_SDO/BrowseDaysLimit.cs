using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Global;
using C_Event;
using Language;
namespace M_SDO
{
    public partial class BrowseDaysLimit : Form
    {
        public BrowseDaysLimit()
        {
            InitializeComponent();
        }

        public BrowseDaysLimit(int productID, string serverIP, int xPos, int yPos)
        {
            InitializeComponent();

            this._productID = productID;
            this._serverIP = serverIP;
            this._xPos = xPos;
            this._yPos = yPos;
        }

        #region 变量
        private CSocketEvent m_ClientEvent = null;

        C_Global.CEnum.Message_Body[,] musicResult = null;

        private int _productID = 0;
        private string _serverIP = null;
        private int _xPos = 0;
        private int _yPos = 0;
        int seconds = 0;
        #endregion

        #region 函数
        public void InitializeDaysLimit()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];


                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.SDO_ServerIP;
                messageBody[0].oContent = _serverIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.SDO_ProductID;
                messageBody[1].oContent = _productID;

                musicResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SDO_DAYSLIMIT_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);

                //检测状态

                if (musicResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    DaysLimit.Text = config.ReadConfigValue("MSDO", "DL_Code_Daylimit");
                    return;
                }


                if (musicResult[0, 0].oContent.ToString() == "4294967295")
                    DaysLimit.Text = config.ReadConfigValue("MSDO", "DL_Code_Daylimit1");
                else
                    DaysLimit.Text = config.ReadConfigValue("MSDO", "DL_Code_Daylimit2").Replace("{Days}", musicResult[0, 0].oContent.ToString());
                      
                

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 语言库
        /// <summary>
        ///　文字库
        /// </summary>
        ConfigValue config = null;

        /// <summary>
        /// 初始化华文字语言库
        /// </summary>
        private void IntiFontLib()
        {
            config = (ConfigValue)m_ClientEvent.GetInfo("INI");
        }


        #endregion
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


        private void BrowseDaysLimit_Load(object sender, EventArgs e)
        {
            IntiFontLib();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds += 1;
            if (seconds == 1)
            {
                InitializeDaysLimit();
                timer1.Enabled = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dividerPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}