using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Global;
using C_Event;
using System.Text.RegularExpressions;

namespace M_SDO
{
    public partial class testMatchInfoEdit : Form
    {
        public testMatchInfoEdit()
        {
            InitializeComponent();
        }

        public testMatchInfoEdit(bool isEdit)
        {
            InitializeComponent();

            _editType = isEdit;     //是否为设计模式
            
            
        }

        public testMatchInfoEdit(bool isEdit,C_Global.Betweenness btwnValue)
        {
            InitializeComponent();

            _editType = isEdit;     //是否为设计模式
            _btwnValue = btwnValue;

        }

        public testMatchInfoEdit(bool isEdit,string serverName)
        {
            InitializeComponent();

            _editType = isEdit;     //是否为设计模式
            _serverName = serverName;


        }


        public testMatchInfoEdit(bool isEdit, string serverName,C_Global.Betweenness btwnValue)
        {
            InitializeComponent();

            _editType = isEdit;     //是否为设计模式
            _serverName = serverName;
            _btwnValue = btwnValue;
        }

        #region 变量
        private C_Global.Betweenness _btwnValue = new Betweenness(C_Global.BetweennessValue.FAILURE);//存储执行的中间结果
        private string _serverName = null;
        private string _ServerIP = null;
        private bool _editType = false;

        private int _sceneID = 0;
        private string _sence = null;
        private int _weekDay = 0;
        private int _matpt_hr = 0;
        private int _matpt_min = 0;
        private int _stpt_hr = 0;
        private int _stpt_min = 0;
        private int _edpt_hr = 0;
        private int _edpt_min = 0;
        private int _gCash = 0;
        private int _mCash = 0;
        private int _scene = 0;
        private string _sceneName = null;
        private string _musicName1 = null;
        private int _level1 = 0;
        private string _musicName2 = null;
        private int _level2 = 0;
        private string _musicName3 = null;
        private int _level3 = 0;
        private string _musicName4 = null;
        private int _level4 = 0;
        private string _musicName5 = null;
        private int _level5 = 0;
        #endregion

        #region 属性


            public int SceneID
        {
            set
            {
                _sceneID = value;
            }
        }

        public string ServerIP
        {
            set
            {
                _ServerIP = value;
            }
            
        }

        public int WeekDAY
        {
            set
            {
                _weekDay = value;
            }
            get
            {
                return _weekDay;
            }
        }

        public int MatPt_hr
        {
            set
            {
                _matpt_hr = value;
            }
            get
            {
                return _matpt_hr;
            }
        }

        public int MatPt_min
        {
            set
            {
                _matpt_min = value;
            }
            get
            {
                return _matpt_min;
            }
        }

        public int StPt_hr
        {
            set
            {
                _stpt_hr = value;
            }
            get
            {
                return _stpt_hr;
            }
        }

        public int StPt_min
        {
            set
            {
                _stpt_min = value;
            }
            get
            {
                return _stpt_min;
            }
        }

        public int EdPt_hr
        {
            set
            {
                _edpt_hr = value;
            }
            get
            {
                return _edpt_hr;
            }
        }

        public int EdPt_min
        {
            set
            {
                _edpt_min = value;
            }
            get
            {
                return _edpt_min;
            }
        }

        public int Gcash
        {
            set
            {
                _gCash = value;
            }
            get
            {
                return _gCash;
            }
        }

        public int Mcash
        {
            set
            {
                _mCash = value;
            }
            get
            {
                return _mCash;
            }
        }

        public string Scene
        {
            set
            {
                _sceneName = value;
                
            }
            /*
            get
            {
                for (int i = 0; i < senceResult.GetLength(0); i++)
                {
                    if (int.Parse(senceResult[i, 0].oContent.ToString()) == _scene)
                    {
                        return senceResult[i, 1].oContent.ToString();
                    }
                }
            }
            */
        }

        public string MusicName1
        {
            set
            {
                _musicName1 = value;
            }
            get
            {
                return _musicName1;
            }
        }

        public int Lv1
        {
            set
            {
                _level1 = value;
            }
            get
            {
                return _level1;
            }
        }

        public string MusicName2
        {
            set
            {
                _musicName2 = value;
            }
            get
            {
                return _musicName2;
            }
        }

        public int Lv2
        {
            set
            {
                _level2 = value;
            }
            get
            {
                return _level2;
            }
        }

        public string MusicName3
        {
            set
            {
                _musicName3 = value;
            }
            get
            {
                return _musicName3;
            }
        }

        public int Lv3
        {
            set
            {
                _level3 = value;
            }
            get
            {
                return _level3;
            }
        }

        public string MusicName4
        {
            set
            {
                _musicName4 = value;
            }
            get
            {
                return _musicName4;
            }
        }

        public int Lv4
        {
            set
            {
                _level4 = value;
            }
            get
            {
                return _level4;
            }
        }

        public string MusicName5
        {
            set
            {
                _musicName5 = value;
            }
            get
            {
                return _musicName5;
            }
        }

        public int Lv5
        {
            set
            {
                _level5 = value;
            }
            get
            {
                return _level5;
            }
        }



        #endregion


        #region 变量
        private CSocketEvent m_ClientEvent = null;

        C_Global.CEnum.Message_Body[,] musicResult = null;
        C_Global.CEnum.Message_Body[,] serverIPResult = null;
        C_Global.CEnum.Message_Body[,] addResult = null;
        C_Global.CEnum.Message_Body[,] senceResult = null;
        
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

        private void ReadSence()
        {
            try
            {

                senceResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_CHALLENGE_SCENE_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, null);


                if (senceResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(senceResult[0, 0].oContent.ToString());
                    return;
                }

                for (int i = 0; i < senceResult.GetLength(0); i++)
                {
                    cbxScene.Items.Add(senceResult[i, 1].oContent.ToString());
                }
                cbxScene.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public void InitializeMusicList()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[1];

                //if (_ServerIP == null)
                //{
                //    for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
                //    {
                //        if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                //        {
                //            this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                //        }
                //    }
                //}
                
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.SDO_ServerIP;
                messageBody[0].oContent = "2222";
                
                /*
                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 2;
                */

                musicResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SDO_MUSICDATA_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);

                //检测状态
                if (musicResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(musicResult[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }

                cbxServerIP.Enabled = false;
                dpContent.Enabled = true;
                btnConfirm.Enabled = true;
                btnCancel.Enabled = true;




                for (int i = 0; i < musicResult.GetLength(0); i++)
                {
                    cbxSong1.Items.Add(musicResult[i, 1].oContent.ToString());
                    cbxSong2.Items.Add(musicResult[i, 1].oContent.ToString());
                    cbxSong3.Items.Add(musicResult[i, 1].oContent.ToString());
                    cbxSong4.Items.Add(musicResult[i, 1].oContent.ToString());
                    cbxSong5.Items.Add(musicResult[i, 1].oContent.ToString());

                }

                cbxDay.SelectedIndex = 0;
                //cbxScene.SelectedIndex = 0;
                cbxSong1.SelectedIndex = 0;
                cbxLevel1.SelectedIndex = 0;

                cbxSong2.SelectedIndex = 0;
                cbxLevel2.SelectedIndex = 0;

                cbxSong3.SelectedIndex = 0;
                cbxLevel3.SelectedIndex = 0;

                cbxSong4.SelectedIndex = 0;
                cbxLevel4.SelectedIndex = 0;

                cbxSong5.SelectedIndex = 0;
                cbxLevel5.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 初始化游戏服务器列表
        /// </summary>
        public void InitializeServerIP()
        {
            try
            {
                this.cbxServerIP.Items.Clear();

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.ServerInfo_GameID;
                messageBody[0].oContent = m_ClientEvent.GetInfo("GameID_SDO");

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 1;

                serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);

                //检测状态
                if (serverIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
                    return;
                }


                //显示内容到列表
                for (int i = 0; i < serverIPResult.GetLength(0); i++)
                {
                    this.cbxServerIP.Items.Add(serverIPResult[i, 1].oContent.ToString());
                }

                if (!_editType)
                {
                    for (int i = 0; i < serverIPResult.GetLength(0); i++)
                    {
                        if (serverIPResult[i, 1].oContent.ToString().Equals(_serverName))
                        {
                            cbxServerIP.SelectedIndex = i;
                        }
                    }
                }

                cbxServerIP.Enabled = false;
                
            }
            catch
            {
            }
        }


        private void Add()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = null;

                if (_editType)
                {
                    messageBody = new C_Global.CEnum.Message_Body[23];
                }
                else
                {
                    messageBody = new C_Global.CEnum.Message_Body[22];
                }

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.SDO_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.SDO_WeekDay;
                messageBody[1].oContent = cbxDay.SelectedIndex;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.SDO_MatPtHR;
                messageBody[2].oContent = int.Parse(txtHours.Text);

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].eName = C_Global.CEnum.TagName.SDO_MatPtMin;
                messageBody[3].oContent = int.Parse(txtMinutes.Text);

                messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[4].eName = C_Global.CEnum.TagName.SDO_StPtHR;
                messageBody[4].oContent = int.Parse(Convert.ToDateTime(dptBeginTime.Text).Hour.ToString());

                messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[5].eName = C_Global.CEnum.TagName.SDO_StPtMin;
                messageBody[5].oContent = int.Parse(Convert.ToDateTime(dptBeginTime.Text).Minute.ToString());

                messageBody[6].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[6].eName = C_Global.CEnum.TagName.SDO_EdPtHR;
                messageBody[6].oContent = int.Parse(Convert.ToDateTime(dptEndTime.Text).Hour.ToString());

                messageBody[7].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[7].eName = C_Global.CEnum.TagName.SDO_EdPtMin;
                messageBody[7].oContent = int.Parse(Convert.ToDateTime(dptEndTime.Text).Minute.ToString());

                messageBody[8].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[8].eName = C_Global.CEnum.TagName.SDO_GCash;
                messageBody[8].oContent = int.Parse(txtGCash.Text);

                messageBody[9].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[9].eName = C_Global.CEnum.TagName.SDO_MCash;
                messageBody[9].oContent = int.Parse(txtMCash.Text);

                int __senceID = 0;
                for (int i = 0; i < senceResult.GetLength(0); i++)
                {
                    if (cbxScene.Text.Trim().Equals(senceResult[i, 1].oContent.ToString().Trim()))
                    {
                        __senceID = int.Parse(senceResult[i, 0].oContent.ToString());
                    }
                }
                messageBody[10].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[10].eName = C_Global.CEnum.TagName.SDO_Sence;
                messageBody[10].oContent = __senceID;

                messageBody[11].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[11].eName = C_Global.CEnum.TagName.SDO_MusicID1;
                messageBody[11].oContent = GetMusicIndex(cbxSong1.Text);

                messageBody[12].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[12].eName = C_Global.CEnum.TagName.SDO_LV1;
                messageBody[12].oContent = cbxLevel1.SelectedIndex;

                messageBody[13].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[13].eName = C_Global.CEnum.TagName.SDO_MusicID2;
                messageBody[13].oContent = GetMusicIndex(cbxSong2.Text);

                messageBody[14].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[14].eName = C_Global.CEnum.TagName.SDO_LV2;
                messageBody[14].oContent = cbxLevel2.SelectedIndex;

                messageBody[15].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[15].eName = C_Global.CEnum.TagName.SDO_MusicID3;
                messageBody[15].oContent = GetMusicIndex(cbxSong3.Text);

                messageBody[16].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[16].eName = C_Global.CEnum.TagName.SDO_LV3;
                messageBody[16].oContent = cbxLevel3.SelectedIndex;

                messageBody[17].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[17].eName = C_Global.CEnum.TagName.SDO_MusicID4;
                messageBody[17].oContent = GetMusicIndex(cbxSong4.Text);

                messageBody[18].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[18].eName = C_Global.CEnum.TagName.SDO_LV4;
                messageBody[18].oContent = cbxLevel4.SelectedIndex;

                messageBody[19].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[19].eName = C_Global.CEnum.TagName.SDO_MusicID5;
                messageBody[19].oContent = GetMusicIndex(cbxSong5.Text);

                messageBody[20].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[20].eName = C_Global.CEnum.TagName.SDO_LV5;
                messageBody[20].oContent = cbxLevel5.SelectedIndex;

                messageBody[21].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[21].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[21].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());





                if (_editType)
                {
                    messageBody[22].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                    messageBody[22].eName = C_Global.CEnum.TagName.SDO_SenceID;
                    messageBody[22].oContent = _sceneID;

                    addResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SDO_CHALLENGE_UPDATE, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);
                }
                else
                {
                    addResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SDO_CHALLENGE_INSERT, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);
                }


                //检测状态
                if (addResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    _btwnValue.BtwnValue = C_Global.BetweennessValue.FAILURE;
                    MessageBox.Show(addResult[0, 0].oContent.ToString());
                    return;
                }

                if (addResult[0, 0].oContent.ToString().Equals("FAILURE"))
                {
                    _btwnValue.BtwnValue = C_Global.BetweennessValue.FAILURE;
                    MessageBox.Show("失败");
                    return;
                }

                if (addResult[0, 0].oContent.ToString().Equals("SUCESS"))
                {
                    _btwnValue.BtwnValue = C_Global.BetweennessValue.SUCESS;
                    MessageBox.Show("成功");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private int GetMusicIndex(string musicName)
        {
            int musicIndex = 0;
            for (int i = 0; i < musicResult.GetLength(0); i++)
            {
                if (musicResult[i, 1].oContent.ToString().Equals(musicName))
                {
                    musicIndex = int.Parse(musicResult[i,0].oContent.ToString());
                }
            }
            return musicIndex;
        }

       

        #endregion

        #region 编辑区内容
        private int GetIpIndex()
        {
            int ipIndex = 0;
            for (int i = 0; i < serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 0].oContent.ToString().Equals(_ServerIP))
                {
                    ipIndex = i;
                }
            }
            return ipIndex;
        }

        private int GetMusicIndex(int musicID)
        {
            int musicIndex = 0;
            for (int i = 0; i < musicResult.GetLength(0); i++)
            {
                if (int.Parse(musicResult[i, 0].oContent.ToString()) == musicID)
                {
                    musicIndex = i;
                }
            }
            return musicIndex;
        }

        #endregion

        private void MatchInfoEdit_Load(object sender, EventArgs e)
        {
            //dpContent.Enabled = false;
            //btnConfirm.Enabled = false;
            //btnCancel.Enabled = false;

            btnIpOk.Enabled = false;
            btnIPCancel.Enabled = false;

            

            InitializeServerIP();
            InitializeMusicList();
            ReadSence();


            

            if (!_editType)
            {
                dptBeginTime.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
                dptEndTime.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
            }
            else
            {
                

                
                cbxServerIP.Enabled = false;
                btnIpOk.Enabled = false;
                btnIPCancel.Enabled = false;
                dpContent.Enabled = true;
                btnConfirm.Enabled = true;
                btnCancel.Enabled = true;

                cbxDay.SelectedIndex = _weekDay;
                cbxServerIP.SelectedIndex = GetIpIndex();
                txtHours.Text = _matpt_hr.ToString();
                txtMinutes.Text = _matpt_min.ToString();

                dptBeginTime.Text = _stpt_hr + ":" + _stpt_min;
                dptEndTime.Text = _edpt_hr + ":" + _edpt_min;

                txtGCash.Text = _gCash.ToString();
                txtMCash.Text = _mCash.ToString();

                for (int i = 0; i < senceResult.GetLength(0); i++)
                {
                    if (senceResult[i, 1].oContent.ToString().Equals(_sceneName))
                    {
                        _scene = i;
                    }
                }

                cbxScene.SelectedIndex = _scene;

                cbxSong1.SelectedIndex = GetMusicIndex(int.Parse(_musicName1));
                cbxLevel1.SelectedIndex = _level1;

                cbxSong2.SelectedIndex = GetMusicIndex(int.Parse(_musicName2));
                cbxLevel2.SelectedIndex = _level2;

                cbxSong3.SelectedIndex = GetMusicIndex(int.Parse(_musicName3));
                cbxLevel3.SelectedIndex = _level3;

                cbxSong4.SelectedIndex = GetMusicIndex(int.Parse(_musicName4));
                cbxLevel4.SelectedIndex = _level4;

                cbxSong5.SelectedIndex = GetMusicIndex(int.Parse(_musicName5));
                cbxLevel5.SelectedIndex = _level5;
                
            }
        }

        private void btnIpOk_Click(object sender, EventArgs e)
        {
            #region 过滤
            if (cbxServerIP.Text == null || cbxServerIP.Text == "")
            {
                MessageBox.Show("请选择服务器");
                return;
            }            
            #endregion

            #region IP检索
            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                {
                    this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion

            InitializeMusicList();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtHours.Text == null || txtHours.Text == "")
            {
                MessageBox.Show("请输入比赛时间（小时）");
                txtHours.Focus();
                return;
            }


            if (txtMinutes.Text == null || txtMinutes.Text == "")
            {
                MessageBox.Show("请输入比赛时间（分钟）");
                txtMinutes.Focus();
                return;
            }

            if (dptBeginTime.Text == null || dptBeginTime.Text == "")
            {
                MessageBox.Show("请输入大赛频道开始时间");
                dptBeginTime.Focus();
                return;
            }

            if (dptEndTime.Text == null || dptEndTime.Text == "")
            {
                MessageBox.Show("请输入大赛频道结束时间");
                dptEndTime.Focus();
                return;
            }

            if (txtGCash.Text == null || txtGCash.Text == "")
            {
                MessageBox.Show("请输入G币价格");
                txtGCash.Focus();
                return;
            }

            if (txtMCash.Text == null || txtMCash.Text == "")
            {
                MessageBox.Show("请输入M币价格");
                txtMCash.Focus();
                return;
            }

            Add();
        }

        private void btnIPCancel_Click(object sender, EventArgs e)
        {
            cbxServerIP.Enabled = true;
            dpContent.Enabled = false;
            btnCancel.Enabled = false;
            btnConfirm.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _btwnValue.BtwnValue = C_Global.BetweennessValue.FAILURE;
            this.Close();
           // return;
        }

        private void dpContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtHours_MouseUp(object sender, MouseEventArgs e)
        {
            string txt = txtHours.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtHours.Text = rx.Replace(txt, "");
        }

        private void txtHours_KeyUp(object sender, KeyEventArgs e)
        {
            string txt = txtHours.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtHours.Text = rx.Replace(txt, "");
        }

        private void txtMinutes_KeyUp(object sender, KeyEventArgs e)
        {
            string txt = txtMinutes.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtMinutes.Text = rx.Replace(txt, "");
        }

        private void txtMinutes_MouseUp(object sender, MouseEventArgs e)
        {
            string txt = txtMinutes.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtMinutes.Text = rx.Replace(txt, "");
        }
    }
}