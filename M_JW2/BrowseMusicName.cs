﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Language;
using C_Global;
using C_Event;

namespace M_JW2
{
    public partial class BrowseMusicName : Form
    {
        public BrowseMusicName()
        {
            InitializeComponent();
        }

        public BrowseMusicName(CEnum.Message_Body[,] result,int iPageCount,int xPos,int yPos)
        {
            InitializeComponent();

            this._result = result;
            this._xPos = xPos;
            this._yPos = yPos;
            this.iPageCount = iPageCount;
        }

        #region 变量
        private CSocketEvent m_ClientEvent = null;

        C_Global.CEnum.Message_Body[,] musicResult = null;

        private int _musicID = 0;
        private string _serverIP = null;
        private int _xPos = 0;
        private int _yPos = 0;
        private CEnum.Message_Body[,] _result;
        private int iPageCount;
        int seconds = 0;

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        private System.Drawing.Point mousePoint;
        ConfigValue config = null;
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

                //C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];


                //messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                //messageBody[0].eName = C_Global.CEnum.TagName.SDO_ServerIP;
                //messageBody[0].oContent = _serverIP;

                //messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                //messageBody[1].eName = C_Global.CEnum.TagName.SDO_MusicID1;
                //messageBody[1].oContent = _musicID;

                //musicResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SDO_MUSICDATA_OWN_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);


                //CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];

                //mContent[0].eName = CEnum.TagName.FJ_Item_GuID;
                //mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                //mContent[0].oContent = this._musicID;

                ////musicResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.FJ_ItemName_Query, C_Global.CEnum.Msg_Category.SDO_ADMIN, mContent);
                //musicResult = Operation_RCode.GetResult(m_ClientEvent, CEnum.ServiceKey.FJ_ItemName_Query, mContent);

                //检测状态
                //if (musicResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                //{
                //    musicName.Text = "";
                //    return;
                //}

                //musicName.Text = musicResult[0, 0].oContent.ToString();

                Operation_JW2.BuildDataTable(this.m_ClientEvent, this._result, dataGridView1, out this.iPageCount);
                //musicName.Text = "記錄明細";
                musicName.Text = config.ReadConfigValue("MJW2", "NEW_UI_RECORDDETAL");
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

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    if ((int)m.Result == HTCLIENT)
                        m.Result = (IntPtr)HTCAPTION;
                    return;
                    break;
            }
            base.WndProc(ref m);
        }
     
        private void BrowseMusicName_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //MousePosition.X = e.X;
                //MousePosition.Y = e.Y;
            }
        }

        private void BrowseMusicName_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Top = Control.MousePosition.Y - BrowseMusicName.MousePosition.Y
                - SystemInformation.FrameBorderSize.Height - SystemInformation.CaptionHeight;
                this.Left = Control.MousePosition.Y - BrowseMusicName.MousePosition.Y
                - SystemInformation.FrameBorderSize.Width;
            } 
        }
    }

}