using System;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace C_Global
{
    #region CModuleAttribute类
    /// <summary>
    /// CModuleAttribute 模块属性
    /// </summary>
    /// 建立系统模块的索引,引用创建自定义组件的概念

    //定义模块属性只允许存在一个实例
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CModuleAttribute : Attribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strName">模块名称</param>
        /// <param name="strTips">模块类名</param>
        /// <param name="strGroup">模块说明</param>
        /// <param name="strDesigner">模块隶属组</param>
        public CModuleAttribute(string strName, string stClass, string strTips, string strGroup)
        {
            this.strName = strName;
            this.stClass = stClass;
            this.strTips = strTips;
            this.strGroup = strGroup;
        }

        #region 属性信息
        /// <summary>
        /// 模块名称
        /// </summary>
        public string Name
        {
            get
            {
                return strName;
            }
        }

        public string Class
        {
            get
            {
                return stClass;
            }
        }

        /// <summary>
        /// 模块说明
        /// </summary>
        public string Tips
        {
            get
            {
                return strTips;
            }
        }

        /// <summary>
        /// 模块隶属
        /// </summary>
        public string Group
        {
            get
            {
                return strGroup;
            }
        }
        #endregion

        #region 私有变量
        private string strName;			//模块名称
        private string stClass;			//模块类名
        private string strTips;			//模块说明
        private string strGroup;		//模块隶属组
        #endregion
    }
    #endregion

    #region CModuleForms类
    /// <summary>
    /// CModuleForms 模块窗体
    /// </summary>
    public sealed class CModuleForms
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strClass">类名</param>
        /// <param name="strGroup">组名</param>
        /// <param name="strName">名称</param>
        /// <param name="strPath">路径</param>
        public CModuleForms(string strClass, string strGroup, string strName, string strPath)
        {
            this.strClass = strClass;
            this.strGroup = strGroup;
            this.strName = strName;
            this.strPath = strPath;
        }

        #region 内部属性
        public string Path
        {
            get { return strPath; }
        }

        public string Name
        {
            get { return strName; }
        }

        public string Class
        {
            get { return strClass; }
        }

        public string Group
        {
            get { return strGroup; }
        }

        public System.Windows.Forms.Form Form
        {
            set { FrmModule = value; }
            get { return FrmModule; }
        }
        #endregion

        #region 私有变量
        private readonly string strPath;
        private readonly string strName;
        private readonly string strClass;
        private readonly string strGroup;

        private System.Windows.Forms.Form FrmModule = null;
        #endregion
    }
    #endregion

    #region CModule类
    /// <summary>
    /// CModule 获取模块信息。
    /// </summary>
    public class CModule
    {
        /// <summary>
        /// 静态函数
        /// </summary>
        /// <param name="strPath">模块路径</param>
        /// <param name="strSuffix">模块后缀</param>
        /// <returns>模块哈希表</returns>
        public static Hashtable Module(string strPath, string strSuffix)
        {
            Hashtable hHashtable = new Hashtable();
            System.IO.DirectoryInfo dDirectory = new System.IO.DirectoryInfo(strPath);

            //枚举指定类型文件
            foreach (System.IO.FileInfo file in dDirectory.GetFiles("*." + strSuffix))
            {
                System.Reflection.Assembly asmAssembly = System.Reflection.Assembly.LoadFile(file.FullName);

                //枚举模块信息
                foreach (System.Reflection.Module mod in asmAssembly.GetModules())
                {
                    //枚举类型信息
                    foreach (Type t in mod.GetTypes())
                    {
                        object[] oModule = t.GetCustomAttributes(typeof(CModuleAttribute), true);

                        if (oModule.Length == 1)
                        {
                            string strModuleName = ((CModuleAttribute)oModule[0]).Name;
                            string strModuleClass = ((CModuleAttribute)oModule[0]).Class;
                            string strModuleTips = ((CModuleAttribute)oModule[0]).Tips;
                            string strModuleGroup = ((CModuleAttribute)oModule[0]).Group;

                            CModuleForms mForms = new CModuleForms(t.Name, strModuleGroup, strModuleName, file.FullName);

                            if (hHashtable.ContainsKey(strModuleName))
                            {
                                throw new Exception("系统模块加载错误：模块重复加载或模块名称重复！");
                            }
                            else
                            {
                                hHashtable.Add(t.Name, mForms);
                            }
                        }
                    }
                }
            }

            return hHashtable;
        }
    }
    #endregion
}
