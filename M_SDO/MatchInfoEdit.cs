using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Global;
using C_Event;
using System.Text.RegularExpressions;
using Language;
namespace M_SDO
{
    public partial class MatchInfoEdit : Form
    {
        public MatchInfoEdit()
        {
            InitializeComponent();
        }

        public MatchInfoEdit(bool isEdit)
        {
            InitializeComponent();

            _editType = isEdit;     //是否为设计模式
            
            
        }

        public MatchInfoEdit(bool isEdit,C_Global.Betweenness btwnValue)
        {
            InitializeComponent();

            _editType = isEdit;     //是否为设计模式
            _btwnValue = btwnValue;

        }

        public MatchInfoEdit(bool isEdit,string serverName)
        {
            InitializeComponent();

            _editType = isEdit;     //是否为设计模式
            _serverName = serverName;


        }


        public MatchInfoEdit(bool isEdit, string serverName,C_Global.Betweenness btwnValue)
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
        private string _isbattle = null;
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
            get
            {
                return _sceneName;
            }

         
            //get
            //{
            //    for (int i = 0; i < senceResult.GetLength(0); i++)
            //    {
            //        if (int.Parse(senceResult[i, 0].oContent.ToString()) == _scene)
            //        {
            //           return senceResult[i, 1].oContent.ToString();
            //        }
            //    }
               
            //}
         
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

        public string Sdobattle
        {
            set
            {
                _isbattle = value;
            }
            get
            {
                return _isbattle;
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

                if (_ServerIP == null)
                {
                    for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
                    {
                        if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                        {
                            this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                        }
                    }
                }
                
                //messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                //messageBody[0].eName = C_Global.CEnum.TagName.SDO_ServerIP;
                //messageBody[0].oContent = _ServerIP;
                
                /*
                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 2;
                */

                //musicResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SDO_MUSICDATA_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);

                //检测状态
                //if (musicResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(musicResult[0, 0].oContent.ToString());
                //    //Application.Exit();
                //    return;
                //}

                cbxServerIP.Enabled = false;
                dpContent.Enabled = true;
                btnConfirm.Enabled = true;
                btnCancel.Enabled = true;




                //for (int i = 0; i < musicResult.GetLength(0); i++)
                //{
                //    cbxSong1.Items.Add(musicResult[i, 1].oContent.ToString());
                //    cbxSong2.Items.Add(musicResult[i, 1].oContent.ToString());
                //    cbxSong3.Items.Add(musicResult[i, 1].oContent.ToString());
                //    cbxSong4.Items.Add(musicResult[i, 1].oContent.ToString());
                //    cbxSong5.Items.Add(musicResult[i, 1].oContent.ToString());

                //}

                cbxDay.SelectedIndex = 0;
                //cbxScene.SelectedIndex = 0;
                //cbxSong1.SelectedIndex = 0;
                //cbxLevel1.SelectedIndex = 0;

                //cbxSong2.SelectedIndex = 0;
                //cbxLevel2.SelectedIndex = 0;

                //cbxSong3.SelectedIndex = 0;
                //cbxLevel3.SelectedIndex = 0;

                //cbxSong4.SelectedIndex = 0;
                //cbxLevel4.SelectedIndex = 0;

                //cbxSong5.SelectedIndex = 0;
                //cbxLevel5.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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
            IntiUI();
        }

        private void IntiUI()
        {
            this.Text = config.ReadConfigValue("MSDO", "ME_UI_MatchInfoEdit");
            this.label19.Text = config.ReadConfigValue("MSDO", "ME_UI_label19");
            this.btnIpOk.Text = config.ReadConfigValue("MSDO", "ME_UI_btnIpOk");
            this.btnIPCancel.Text = config.ReadConfigValue("MSDO", "ME_UI_btnIPCancel");
            this.label1.Text = config.ReadConfigValue("MSDO", "ME_UI_label1");
            this.label2.Text = config.ReadConfigValue("MSDO", "ME_UI_label2");
            this.label3.Text = config.ReadConfigValue("MSDO", "ME_UI_label3");
            this.label4.Text = config.ReadConfigValue("MSDO", "ME_UI_label4");

            this.label18.Text = config.ReadConfigValue("MSDO", "ME_UI_label18");
            this.label5.Text = config.ReadConfigValue("MSDO", "ME_UI_label5");
            this.label6.Text = config.ReadConfigValue("MSDO", "ME_UI_label6");
            this.label7.Text = config.ReadConfigValue("MSDO", "ME_UI_label7");
            this.label8.Text = config.ReadConfigValue("MSDO", "ME_UI_label8");
            this.label9.Text = config.ReadConfigValue("MSDO", "ME_UI_label9");
            this.label11.Text = config.ReadConfigValue("MSDO", "ME_UI_label11");
            this.label10.Text = config.ReadConfigValue("MSDO", "ME_UI_label10");
            this.label13.Text = config.ReadConfigValue("MSDO", "ME_UI_label13");
            this.label12.Text = config.ReadConfigValue("MSDO", "ME_UI_label12");

            this.label15.Text = config.ReadConfigValue("MSDO", "ME_UI_label15");
            this.label14.Text = config.ReadConfigValue("MSDO", "ME_UI_label14");

            this.label17.Text = config.ReadConfigValue("MSDO", "ME_UI_label17");
            this.label16.Text = config.ReadConfigValue("MSDO", "ME_UI_label16");
            this.btnConfirm.Text = config.ReadConfigValue("MSDO", "ME_UI_btnConfirm");
            this.btnCancel.Text = config.ReadConfigValue("MSDO", "ME_UI_btnCancel");
            this.label20.Text = config.ReadConfigValue("MSDO", "ME_UI_label20");
            this.comboBox1.Items.AddRange(new object[] {
            config.ReadConfigValue("MSDO", "XF_UI_Type1"),
            config.ReadConfigValue("MSDO", "XF_UI_Type2"),
            config.ReadConfigValue("MSDO", "XF_UI_Type3"),
            config.ReadConfigValue("MSDO", "XF_UI_Type4")
            });

        }
        #endregion
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
                    messageBody = new C_Global.CEnum.Message_Body[20];
                }
                else
                {
                    messageBody = new C_Global.CEnum.Message_Body[18];
                }

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.SDO_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.SDO_WeekDay;
                messageBody[1].oContent = cbxDay.SelectedIndex;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.SDO_StPtMin;
                messageBody[2].oContent = int.Parse(txtHours.Text);

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].eName = C_Global.CEnum.TagName.SDO_MatPtMin;
                messageBody[3].oContent = int.Parse(txtMinutes.Text);

                messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[4].eName = C_Global.CEnum.TagName.SDO_GCash;
                messageBody[4].oContent = int.Parse(txtGCash.Text);

                int __senceID = 0;
                for (int i = 0; i < senceResult.GetLength(0); i++)
                {
                    if (cbxScene.Text.Trim().Equals(senceResult[i, 1].oContent.ToString().Trim()))
                    {
                        __senceID = int.Parse(senceResult[i, 0].oContent.ToString());
                    }
                }
                messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[5].eName = C_Global.CEnum.TagName.SDO_Sence;
                messageBody[5].oContent = __senceID;

                messageBody[6].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[6].eName = C_Global.CEnum.TagName.SDO_MusicID1;
                messageBody[6].oContent = GetMusicIndex(cbxSong1.Text);

                messageBody[7].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[7].eName = C_Global.CEnum.TagName.SDO_LV1;
                messageBody[7].oContent = cbxLevel1.SelectedIndex;

                messageBody[8].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[8].eName = C_Global.CEnum.TagName.SDO_MusicID2;
                messageBody[8].oContent = GetMusicIndex(cbxSong2.Text);

                messageBody[9].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[9].eName = C_Global.CEnum.TagName.SDO_LV2;
                messageBody[9].oContent = cbxLevel2.SelectedIndex;

                messageBody[10].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[10].eName = C_Global.CEnum.TagName.SDO_MusicID3;
                messageBody[10].oContent = GetMusicIndex(cbxSong3.Text);

                messageBody[11].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[11].eName = C_Global.CEnum.TagName.SDO_LV3;
                messageBody[11].oContent = cbxLevel3.SelectedIndex;

                messageBody[12].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[12].eName = C_Global.CEnum.TagName.SDO_MusicID4;
                messageBody[12].oContent = GetMusicIndex(cbxSong4.Text);

                messageBody[13].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[13].eName = C_Global.CEnum.TagName.SDO_LV4;
                messageBody[13].oContent = cbxLevel4.SelectedIndex;

                messageBody[14].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[14].eName = C_Global.CEnum.TagName.SDO_MusicID5;
                messageBody[14].oContent = GetMusicIndex(cbxSong5.Text);

                messageBody[15].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[15].eName = C_Global.CEnum.TagName.SDO_LV5;
                messageBody[15].oContent = cbxLevel5.SelectedIndex;

                messageBody[16].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[16].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[16].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[17].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[17].eName = C_Global.CEnum.TagName.SDO_IsBattle;
                messageBody[17].oContent = ReturnStauas(comboBox1.Text.Trim());



                if (_editType)
                {
                    messageBody[18].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                    messageBody[18].eName = C_Global.CEnum.TagName.SDO_SenceID;
                    messageBody[18].oContent = _sceneID;

                    messageBody[19].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                    messageBody[19].eName = C_Global.CEnum.TagName.SDO_IsBattle;
                    messageBody[19].oContent = ReturnStauas(comboBox1.Text.Trim());
                    ArrayList paramList = new ArrayList();
                    paramList.Add(true);
                    paramList.Add(messageBody);

                    this.backgroundWorkerAddMatch.RunWorkerAsync(paramList);
                 
                }
                else
                {
                    ArrayList paramList = new ArrayList();
                    paramList.Add(false);
                    paramList.Add(messageBody);
                    this.backgroundWorkerAddMatch.RunWorkerAsync(paramList);
                 
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private int ReturnStauas(string strStauas)
        {
            int IntStauas = -1;
            if (strStauas == config.ReadConfigValue("MSDO", "XF_UI_Type1").Trim())
            {
                IntStauas = 0;
            }
            else if (strStauas == config.ReadConfigValue("MSDO", "XF_UI_Type2").Trim())
            {
                IntStauas = 1;
            }
            else if (strStauas == config.ReadConfigValue("MSDO", "XF_UI_Type3").Trim())
            {
                IntStauas = 10;
            }
            else if (strStauas == config.ReadConfigValue("MSDO", "XF_UI_Type4").Trim())
            {
                IntStauas = 11;
            }

            return IntStauas;
        }
        private int GetMusicIndex(string musicName)
        {
            int musicIndex = 0;
            //for (int i = 0; i < musicResult.GetLength(0); i++)
            //{
            //    if (musicResult[i, 1].oContent.ToString().Equals(musicName))
            //    {
            //        musicIndex = int.Parse(musicResult[i,0].oContent.ToString());
            //    }
            //}
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
            //for (int i = 0; i < musicResult.GetLength(0); i++)
            //{
            //    if (int.Parse(musicResult[i, 0].oContent.ToString()) == musicID)
            //    {
            //        musicIndex = i;
            //    }
            //}
            return musicIndex;
        }

        #endregion

        private void MatchInfoEdit_Load(object sender, EventArgs e)
        {
            //dpContent.Enabled = false;
            //btnConfirm.Enabled = false;
            //btnCancel.Enabled = false;
            IntiFontLib();
            cbxDay.Items.Add(config.ReadConfigValue("MSDO", "MI_Code_day"));
            cbxDay.Items.Add(config.ReadConfigValue("MSDO", "MI_Code_day1"));
            cbxDay.Items.Add(config.ReadConfigValue("MSDO", "MI_Code_day2"));
            cbxDay.Items.Add(config.ReadConfigValue("MSDO", "MI_Code_day3"));
            cbxDay.Items.Add(config.ReadConfigValue("MSDO", "MI_Code_day4"));
            cbxDay.Items.Add(config.ReadConfigValue("MSDO", "MI_Code_day5"));
            cbxDay.Items.Add(config.ReadConfigValue("MSDO", "MI_Code_day6"));
            btnIpOk.Enabled = false;
            btnIPCancel.Enabled = false;

            

            InitializeServerIP();
            InitializeMusicList();
            ReadSence();
            comboBox1.SelectedIndex = 0;

            

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
                txtHours.Text = StPt_min.ToString();
                txtMinutes.Text = _matpt_min.ToString();

                dptBeginTime.Text = _stpt_hr + ":" + _stpt_min;
                dptEndTime.Text = _edpt_hr + ":" + _edpt_min;

                txtGCash.Text = _gCash.ToString();
                txtMCash.Text = _mCash.ToString();

                for (int i = 0; i < senceResult.GetLength(0); i++)
                {
                    if (senceResult[i, 0].oContent.ToString().Equals(_sceneName))
                    {
                        _scene = i;
                    }
                }

                cbxScene.SelectedIndex = _scene;

                //cbxSong1.SelectedIndex = GetMusicIndex(int.Parse(_musicName1));
                //cbxLevel1.SelectedIndex = _level1;

                //cbxSong2.SelectedIndex = GetMusicIndex(int.Parse(_musicName2));
                //cbxLevel2.SelectedIndex = _level2;

                //cbxSong3.SelectedIndex = GetMusicIndex(int.Parse(_musicName3));
                //cbxLevel3.SelectedIndex = _level3;

                //cbxSong4.SelectedIndex = GetMusicIndex(int.Parse(_musicName4));
                //cbxLevel4.SelectedIndex = _level4;

                //cbxSong5.SelectedIndex = GetMusicIndex(int.Parse(_musicName5));
                //cbxLevel5.SelectedIndex = _level5;

                if (_isbattle == "0")
                {
                    comboBox1.SelectedIndex = 0;
                }
                else if (_isbattle == "1")
                {
                    comboBox1.SelectedIndex = 1;
                }
                else if (_isbattle == "10")
                {
                    comboBox1.SelectedIndex = 2;
                }
                else if (_isbattle == "11")
                {
                    comboBox1.SelectedIndex = 3;
                }
                else
                {
                    comboBox1.SelectedIndex = 0;
                }


                
            }
        }

        private void btnIpOk_Click(object sender, EventArgs e)
        {
            #region 过滤
            if (cbxServerIP.Text == null || cbxServerIP.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "ME_Code_MsgServer"));
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
                MessageBox.Show(config.ReadConfigValue("MSDO", "ME_Code_MsgHour"));
                txtHours.Focus();
                return;
            }


            if (txtMinutes.Text == null || txtMinutes.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "ME_Code_MsgMin"));
                txtMinutes.Focus();
                return;
            }

            if (dptBeginTime.Text == null || dptBeginTime.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "ME_Code_MsgStartTime"));
                dptBeginTime.Focus();
                return;
            }

            if (dptEndTime.Text == null || dptEndTime.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "ME_Code_MsgEndTime"));
                dptEndTime.Focus();
                return;
            }

            if (txtGCash.Text == null || txtGCash.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "ME_Code_MsgG"));
                txtGCash.Focus();
                return;
            }

            if (txtMCash.Text == null || txtMCash.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "ME_Code_MsgM"));
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

        private void backgroundWorkerAddMatch_DoWork(object sender, DoWorkEventArgs e)
        {
            ArrayList paramList = (ArrayList)e.Argument;
            if ((bool)paramList[0])
            {
                lock (typeof(C_Event.CSocketEvent))
                {
                    addResult = m_ClientEvent.GetSocket(m_ClientEvent, this._ServerIP).RequestResult(C_Global.CEnum.ServiceKey.SDO_CHALLENGE_UPDATE, C_Global.CEnum.Msg_Category.SDO_ADMIN, (CEnum.Message_Body[])paramList[1]);
                }
            }
            else
            {
                lock (typeof(C_Event.CSocketEvent))
                {
                    addResult = m_ClientEvent.GetSocket(m_ClientEvent, this._ServerIP).RequestResult(C_Global.CEnum.ServiceKey.SDO_CHALLENGE_INSERT, C_Global.CEnum.Msg_Category.SDO_ADMIN, (CEnum.Message_Body[])paramList[1]);
                }
            }
        }

        private void backgroundWorkerAddMatch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (addResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            {
                _btwnValue.BtwnValue = C_Global.BetweennessValue.FAILURE;
                MessageBox.Show(addResult[0, 0].oContent.ToString());
                return;
            }

            if (addResult[0, 0].oContent.ToString().Equals("FAILURE"))
            {
                _btwnValue.BtwnValue = C_Global.BetweennessValue.FAILURE;
                MessageBox.Show(config.ReadConfigValue("MSDO", "ME_Code_MsgopFail"));
                return;
            }

            if (addResult[0, 0].oContent.ToString().Equals("SUCESS"))
            {
                _btwnValue.BtwnValue = C_Global.BetweennessValue.SUCESS;
                MessageBox.Show(config.ReadConfigValue("MSDO", "ME_Code_MsgopSucces"));
                this.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}