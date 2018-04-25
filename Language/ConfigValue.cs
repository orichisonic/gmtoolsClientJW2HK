using System;
using System.Collections.Generic;
using System.Text;


using System.Collections;

using C_Global;

namespace Language
{
    public class ConfigValue
    {
        Hashtable hIniFile = new Hashtable();


        public ConfigValue()
        {
        }

        public void Add(string dllName, CIniFile iniFile)
        {
            if (!hIniFile.ContainsKey((string)dllName))
            {
                hIniFile.Add(dllName, iniFile);
            }
        }

        public string ReadConfigValue(string sDll, string key)
        {
            return ((CIniFile)hIniFile[(string)sDll]).ReadValue(sDll, key);
        }
    }
}
