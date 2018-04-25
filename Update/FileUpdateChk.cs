using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Update
{
    class FileUpdateChk
    {
        private string[,] saveArrayInfo = null;
        private string[,] tempArrayInfo = null;


        /// <summary>
        /// 获取本地所有ｄｌｌ文件
        /// </summary>
        /// <returns></returns>
        public string[,] GetLocalDllFile(string strPath)
        {
            string[,] dllFilesInfo = null;   //返回指定路径的ｄｌｌ文件信息
            FileVersionInfo fileInfo = null;
            string[] fileInfoSplit = null;
            System.IO.DirectoryInfo dDirectory = new System.IO.DirectoryInfo(strPath);

            try
            {
                foreach (System.IO.FileInfo file in dDirectory.GetFiles("*.dll"))
                {
                    fileInfo = FileVersionInfo.GetVersionInfo(file.FullName.ToString());
                    fileInfoSplit = fileInfo.FileName.Split(new char[] { '\\' });
                    dllFilesInfo = SaveArray(fileInfoSplit[fileInfoSplit.Length - 1].ToString(), fileInfo.FileVersion.ToString());
                }
                saveArrayInfo = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dllFilesInfo;
        }

        /// <summary>
        /// 获取本地exe文件
        /// </summary>
        /// <param name="strPath"></param>
        /// <returns></returns>
        public string[,] GetLocalExeFile(string strPath)
        {
            string[,] dllFilesInfo = null;   //返回指定路径的ｄｌｌ文件信息
            FileVersionInfo fileInfo = null;
            string[] fileInfoSplit = null;
            System.IO.DirectoryInfo dDirectory = new System.IO.DirectoryInfo(strPath);

            try
            {
                foreach (System.IO.FileInfo file in dDirectory.GetFiles("*.exe"))
                {
                    fileInfo = FileVersionInfo.GetVersionInfo(file.FullName.ToString());
                    fileInfoSplit = fileInfo.FileName.Split(new char[] { '\\' });
                    dllFilesInfo = SaveArray(fileInfoSplit[fileInfoSplit.Length - 1].ToString(), fileInfo.FileVersion.ToString());
                }
                saveArrayInfo = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dllFilesInfo;
        }

        public string[,] GetLocalIniFile(string strPath)
        {
            string[,] dllFilesInfo = null;   //返回指定路径的ｄｌｌ文件信息
            FileVersionInfo fileInfo = null;
            string[] fileInfoSplit = null;
            System.IO.DirectoryInfo dDirectory = new System.IO.DirectoryInfo(strPath);

            try
            {
                foreach (System.IO.FileInfo file in dDirectory.GetFiles("*.ini"))
                {
                    fileInfo = FileVersionInfo.GetVersionInfo(file.FullName.ToString());
                    fileInfoSplit = fileInfo.FileName.Split(new char[] { '\\' });
                    dllFilesInfo = SaveArray(fileInfoSplit[fileInfoSplit.Length - 1].ToString(),"");
                }
                saveArrayInfo = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dllFilesInfo;
        }


        /// <summary>
        /// 建立二维数组，并存储信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private string[,] SaveArray(string key, string value)
        {
            if (saveArrayInfo == null)
            {
                ///存储第一次调用函数时保存的信息
                saveArrayInfo = new string[1, 2];
                saveArrayInfo[0, 0] = key;
                saveArrayInfo[0, 1] = value;
            }
            else
            {
                ///存储第二次调用函数时保存的信息

                //获取数组主存中第一维的长度
                int sAFirLength = saveArrayInfo.GetLength(0) + 1;
                //设置数组辅存
                tempArrayInfo = new string[sAFirLength, 2];
                //将主存中的内容赋给辅存
                for (int i = 0; i < sAFirLength - 1; i++)
                {
                    tempArrayInfo[i, 0] = saveArrayInfo[i, 0];
                    tempArrayInfo[i, 1] = saveArrayInfo[i, 1];
                }
                //将函数被调用的参数内容保存进辅存
                tempArrayInfo[sAFirLength - 1, 0] = key;
                tempArrayInfo[sAFirLength - 1, 1] = value;
                //将辅存内容赋给主存
                saveArrayInfo = tempArrayInfo;
            }
            //返回主存内容
            return saveArrayInfo;
        }
    }
}
