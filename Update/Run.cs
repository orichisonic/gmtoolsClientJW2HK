using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Update
{
    public partial class Run : Form
    {
        public Run()
        {
            InitializeComponent();
        }

        private void Update_Load(object sender, EventArgs e)
        {
            MoveFiles();
        }

        /// <summary>
        /// 移动文件
        /// </summary>
        private void MoveFiles()
        {
            try
            {
                FileUpdateChk fileUpdateChk = new FileUpdateChk();
                string[,] dllFiles = null;
                string[] dir = new string[] { @".\Temp", @".\Temp\Modules", @".\Temp\Schmem",@".\Temp\Lang" };


                for (int i = 0; i < dir.Length; i++)
                {
                    //检测目录
                    if (!Directory.Exists(dir[i]))
                    {
                        Directory.CreateDirectory(dir[i]);
                    }
                    //读取下载的文件
                    dllFiles = fileUpdateChk.GetLocalDllFile(dir[i].ToString());

                    if (dllFiles != null)
                    {
                        for (int j = 0; j < dllFiles.GetLength(0); j++)
                        {
                            
                            //检测文件并覆盖
                            if (File.Exists(dir[i] + @"\" + dllFiles[j, 0]))
                            {
                                string[] destDir = dir[i].Split(new char[] { '\\' });
                                if (destDir[destDir.Length - 1].ToString().Equals("Modules"))
                                {
                                    File.Copy(dir[i] + @"\" + dllFiles[j, 0], @".\Modules\" + dllFiles[j, 0],true);
                                    File.Delete(dir[i] + @"\" + dllFiles[j, 0]);
                                }
                                else
                                {
                                    File.Copy(dir[i] + @"\" + dllFiles[j, 0], @".\" + dllFiles[j, 0],true);
                                    File.Delete(dir[i] + @"\" + dllFiles[j, 0]);
                                }

                            }
                        }
                    }
                }

                for (int i = 0; i < dir.Length; i++)
                {
                    //检测目录
                    if (!Directory.Exists(dir[i]))
                    {
                        Directory.CreateDirectory(dir[i]);
                    }
                    //读取下载的文件
                    dllFiles = fileUpdateChk.GetLocalExeFile(dir[i].ToString());

                    if (dllFiles != null)
                    {
                        for (int j = 0; j < dllFiles.GetLength(0); j++)
                        {

                            //检测文件并覆盖
                            if (File.Exists(dir[i] + @"\" + dllFiles[j, 0]))
                            {
                                string[] destDir = dir[i].Split(new char[] { '\\' });
                                if (destDir[destDir.Length - 1].ToString().Equals("Modules"))
                                {
                                    File.Copy(dir[i] + @"\" + dllFiles[j, 0], @".\Modules\" + dllFiles[j, 0], true);
                                    File.Delete(dir[i] + @"\" + dllFiles[j, 0]);
                                }
                                else
                                {
                                    File.Copy(dir[i] + @"\" + dllFiles[j, 0], @".\" + dllFiles[j, 0], true);
                                    File.Delete(dir[i] + @"\" + dllFiles[j, 0]);
                                }

                            }
                        }
                    }
                }


                for (int i = 0; i < dir.Length; i++)
                {
                    string[] lang_dir = null;

                    //检测目录
                    if (!Directory.Exists(dir[i]))
                    {
                        Directory.CreateDirectory(dir[i]);
                    }

                    if (dir[i].Equals(@".\Temp\Lang"))
                    {
                        lang_dir = Directory.GetDirectories(dir[i]);
                    }

                    //读取下载的文件
                    if (lang_dir == null)
                    {
                        //Schmem
                        dllFiles = fileUpdateChk.GetLocalIniFile(dir[i].ToString());

                        if (dllFiles != null)
                        {
                            for (int j = 0; j < dllFiles.GetLength(0); j++)
                            {

                                //检测文件并覆盖
                                if (File.Exists(dir[i] + @"\" + dllFiles[j, 0]))
                                {
                                    string[] destDir = dir[i].Split(new char[] { '\\' });
                                    if (destDir[destDir.Length - 1].ToString().Equals("Schmem"))
                                    {
                                        File.Copy(dir[i] + @"\" + dllFiles[j, 0], @".\Schmem\" + dllFiles[j, 0], true);
                                        File.Delete(dir[i] + @"\" + dllFiles[j, 0]);
                                    }
                                    else
                                    {
                                        File.Copy(dir[i] + @"\" + dllFiles[j, 0], @".\" + dllFiles[j, 0], true);
                                        File.Delete(dir[i] + @"\" + dllFiles[j, 0]);
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        //Lang

                        for (int k = 0; k < lang_dir.GetLength(0); k++)
                        {
                            //Schmem
                            dllFiles = fileUpdateChk.GetLocalIniFile(lang_dir[k].ToString());

                            if (dllFiles != null)
                            {
                                for (int j = 0; j < dllFiles.GetLength(0); j++)
                                {
                                    File.Copy(lang_dir[k] + @"\" + dllFiles[j, 0], lang_dir[k].Replace(@".\Temp\", "") + @"\" + dllFiles[j, 0], true);
                                    File.Delete(lang_dir[k] + @"\" + dllFiles[j, 0]);
                                }
                            }
                        }

                    }

                    
                }

                

                AppDomain currentDomain = AppDomain.CurrentDomain;
                AppDomain otherDomain = AppDomain.CreateDomain("otherDomain");
                otherDomain.ExecuteAssembly("GMCLIENT.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }
    }
}