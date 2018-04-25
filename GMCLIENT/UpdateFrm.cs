using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

using Language;



namespace GMCLIENT
{
    public partial class UpdateFrm : Form
    {
        C_Global.CEnum.Message_Body[,] MustUpdateFileMsg = null;
        ConfigValue config = null;

        public UpdateFrm()
        {
            InitializeComponent();
        }

        public UpdateFrm(C_Global.CEnum.Message_Body[,] MustUpdateFileMsg)
        {
            this.MustUpdateFileMsg = MustUpdateFileMsg;
            InitializeComponent();
        }

        private void UpdateFrm_Load(object sender, EventArgs e)
        {
            /////////////////////////////////////////
            // 获取语言文字库                      //
            /////////////////////////////////////////
            config = (ConfigValue)m_ClientEvent.GetInfo("INI");
            /////////////////////////////////////////
            // 初始化界面文字                      //
            /////////////////////////////////////////
            IntiUI();


            Thread thread = new Thread(new ThreadStart(DownloadFile));
            thread.Start();
           
        }

        public void DownloadFile()
        {
            int fileSize = 0;

            string fileAddress = null;
            string[] fileAddressSplit = null;
            C_Socket.Query_Structure[] structList = new C_Socket.Query_Structure[1];
            C_Socket.Query_Structure strut = null;
            byte[] bytes = null;

            //拉文件
            for (int i = 0; i < MustUpdateFileMsg.GetLength(0); i++)
            {
                
                int iLangIndex = MustUpdateFileMsg[i, 2].oContent.ToString().IndexOf("Lang");

                if (iLangIndex != -1)
                {

                    fileName = MustUpdateFileMsg[i, 0].oContent.ToString();
                    fileSize = int.Parse(MustUpdateFileMsg[i, 3].oContent.ToString());
                    fileAddress = MustUpdateFileMsg[i, 2].oContent.ToString().Substring(iLangIndex);

                    string file_path = @".\Temp\" + MustUpdateFileMsg[i, 2].oContent.ToString().Substring(iLangIndex);

                    strut = new C_Socket.Query_Structure(2);

                    bytes = C_Socket.TLV_Structure.ValueToByteArray(C_Global.CEnum.TagFormat.TLV_STRING, fileName);
                    strut.AddTagKey(C_Global.CEnum.TagName.UpdateFileName, C_Global.CEnum.TagFormat.TLV_STRING, (uint)bytes.Length, bytes);

                    bytes = C_Socket.TLV_Structure.ValueToByteArray(C_Global.CEnum.TagFormat.TLV_STRING, fileAddress);
                    strut.AddTagKey(C_Global.CEnum.TagName.UpdateFilePath, C_Global.CEnum.TagFormat.TLV_STRING, (uint)bytes.Length, bytes);

                    structList[0] = strut;

                    byte[] ss = C_Event.CSocketEvent.COMMON_MES_RESP(structList, C_Global.CEnum.Msg_Category.COMMON, C_Global.CEnum.ServiceKey.CLIENT_PATCH_UPDATE, 2).bMsgBuffer;
                    byte[] abc = m_ClientEvent.RequestResult(ss, fileSize);


                    

                    if (!Directory.Exists(file_path))
                    {
                        Directory.CreateDirectory(file_path);
                    }



                    string file_address = file_path + @"\" + fileName;
                    FileStream fs = new FileStream(file_address, FileMode.Create, FileAccess.Write, FileShare.Write, 1024);
                    fs.Write(abc, 0, abc.Length);
                    fs.Close();

                }
                else
                {
                    //非INI文件

                    fileName = MustUpdateFileMsg[i, 0].oContent.ToString();
                    fileSize = int.Parse(MustUpdateFileMsg[i, 3].oContent.ToString());
                    fileAddressSplit = MustUpdateFileMsg[i, 2].oContent.ToString().Split(new char[] { '\\' });
                    fileAddress = fileAddressSplit[fileAddressSplit.Length - 1];

                    strut = new C_Socket.Query_Structure(2);

                    bytes = C_Socket.TLV_Structure.ValueToByteArray(C_Global.CEnum.TagFormat.TLV_STRING, fileName);
                    strut.AddTagKey(C_Global.CEnum.TagName.UpdateFileName, C_Global.CEnum.TagFormat.TLV_STRING, (uint)bytes.Length, bytes);

                    bytes = C_Socket.TLV_Structure.ValueToByteArray(C_Global.CEnum.TagFormat.TLV_STRING, fileAddress);
                    strut.AddTagKey(C_Global.CEnum.TagName.UpdateFilePath, C_Global.CEnum.TagFormat.TLV_STRING, (uint)bytes.Length, bytes);

                    structList[0] = strut;

                    byte[] ss = C_Event.CSocketEvent.COMMON_MES_RESP(structList, C_Global.CEnum.Msg_Category.COMMON, C_Global.CEnum.ServiceKey.CLIENT_PATCH_UPDATE, 2).bMsgBuffer;
                    byte[] abc = m_ClientEvent.RequestResult(ss, fileSize);


                    if (fileAddress.Equals("root"))
                    {
                        fileAddress = "";
                        //查看目录并创建
                        if (!Directory.Exists(@".\Temp"))
                        {
                            Directory.CreateDirectory(@".\Temp");
                        }
                    }
                    else
                    {
                        if (!Directory.Exists(@".\Temp\Modules"))
                        {
                            Directory.CreateDirectory(@".\Temp\Modules");
                        }
                        if (!Directory.Exists(@".\Temp\Lang"))
                        {
                            Directory.CreateDirectory(@".\Temp\Lang");
                        }
                        if (!Directory.Exists(@".\Temp\Schmem"))
                        {
                            Directory.CreateDirectory(@".\Temp\Schmem");
                        }
                    }

                    fileAddress = @".\Temp\" + fileAddress + @".\" + fileName;
                    FileStream fso = new FileStream(fileAddress, FileMode.Create, FileAccess.Write, FileShare.Write, 1024);
                    fso.Write(abc, 0, abc.Length);
                    fso.Close();
                }

                

                this.Invoke(new EventHandler(RefreshUILoading));
            }
            this.Invoke(new EventHandler(RefreshUIFinish));
        }


        public void RefreshUILoading(object sender, System.EventArgs e)
        {
            this.UdProgressBar.Value = 0;
            this.UdLabel.Text = config.ReadConfigValue("MAIN","Update_Code_Downloading") + fileName + " ...";
            for (int i = 0; i <= 100; i++)
            {
                this.UdProgressBar.Value = i;
            }
        }

        public void RefreshUIFinish(object sender, System.EventArgs e)
        {
            this.UdLabel.Text = config.ReadConfigValue("MAIN","Update_Code_Finish");
            this.timer1.Enabled = true;
        }

        public void CloseWindow(object sender, System.EventArgs e)
        {
            int closeSeconds = 5;
            int leftSeconds = closeSeconds - Seconds;
            this.label2.Text = config.ReadConfigValue("MAIN", "Update_Code_ToCloseApplication").Replace("{Second}", leftSeconds.ToString());
            if (leftSeconds == 0)
            {
                Process.GetCurrentProcess().Kill();
            }
        }

        private void IntiUI()
        {
            this.Text = config.ReadConfigValue("MAIN", "Update_UI_Caption");
            this.label1.Text = config.ReadConfigValue("MAIN", "Update_UI_Description");
        }


        #region 调用函数
        /// <summary>
        /// 创建类库中的窗体
        /// </summary>
        /// <param name="oParent">MDI 程序的父窗体</param>
        /// <param name="oSocket">Socket</param>
        /// <returns>类库中的窗体</returns>
        public Form CreateModule(object oParent, object oEvent)
        {
            this.m_ClientEvent = (C_Event.CSocketEvent)oEvent;

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

        #region 变量
        private C_Event.CSocketEvent m_ClientEvent = null;
        private string fileName = null;
        private int Seconds = 0;
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            Seconds += 1;
            this.Invoke(new EventHandler(CloseWindow));
        }
    }
}