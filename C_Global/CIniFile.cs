 using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace C_Global
{
    /// <summary>
    /// CIniFile 读写 INI 文件。
    /// </summary>    
    public class CIniFile
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strPath">配置文件路径</param>
        public CIniFile(string strPath)
        {
            this.strPathOfIni = strPath;
        }

        /// <summary>
        /// ReadValue 读取指定键变量
        /// </summary>
        /// <param name="strSection">片断名称</param>
        /// <param name="strKey">键名称</param>
        /// <returns>键变量</returns>
        public string ReadValue(string strSection, string strKey)
        {
            try
            {
                StringBuilder strValue = new StringBuilder(255);
                GetPrivateProfileString(strSection, strKey, "", strValue, 255, this.strPathOfIni);

                return strValue.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        /// <summary>
        /// WriteValue 写入指定键变量
        /// </summary>
        /// <param name="strSection">片断名称</param>
        /// <param name="strKey">键名称</param>
        /// <param name="strValue">键变量</param>
        public void WriteValue(string strSection, string strKey, string strValue)
        {
            WritePrivateProfileString(strSection, strKey, strValue, this.strPathOfIni);
        }

        #region 内部变量
        private string strPathOfIni;	//INI文件路径

        #region 引入 Win32 API 函数
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        #endregion

        #endregion
    }
}
