using System;
using System.Collections.Generic;
using System.Text;

namespace M_AU
{
    class OArray
    {
        private string[,] saveArrayInfo = null;
        private string[,] tempArrayInfo = null;

        public OArray(string[,] saveArrayInfo)
        {
            this.saveArrayInfo = saveArrayInfo;
        }
               

        /// <summary>
        /// 建立二维数组，并存储信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string[,] SaveArray(string key, string value)
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
                int row = 0;
                if (IsExistKey(key,ref row))
                {
                    /*
                     * 此处作判断第二维是否为空
                     * 以确保字符串始终是以数字开头，而非逗号
                     */
                    if (saveArrayInfo[row, 1] == null || saveArrayInfo[row, 1] == "")
                    {
                        saveArrayInfo[row, 0] = key;
                        saveArrayInfo[row, 1] = value;
                    }
                    else
                    {
                        bool isExistValue = false;
                        string[] items = saveArrayInfo[row, 1].Split(new char[] { ',' });
                        for (int i = 0; i < items.Length; i++)
                        {
                            if (items[i].Equals(value))
                            {
                                isExistValue = true;
                            }
                        }

                        if (!isExistValue)
                        {
                            saveArrayInfo[row, 1] = saveArrayInfo[row, 1] + "," + value;
                        }
                    }
                }
                else
                {
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
            }
            //返回主存内容
            return saveArrayInfo;
        }

        /// <summary>
        /// 移出数组中指定key的第二位内容
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string[,] RemoveArraySecond(string key, string value)
        {
            if (saveArrayInfo != null)
            {
                for (int i = 0; i < saveArrayInfo.GetLength(0); i++)
                {
                    if (saveArrayInfo[i, 0].Equals(key))
                    {
                        string[] itemArray = saveArrayInfo[i, 1].Split(new char[]{','});
                        itemArray = Remove(itemArray, value);
                        saveArrayInfo[i, 1] = null;
                        for (int j = 0; j < itemArray.Length; j++)
                        {
                            saveArrayInfo[i, 1] += itemArray[j] + ",";
                        }
                        if (saveArrayInfo[i, 1] != null)
                        {
                            saveArrayInfo[i, 1] = saveArrayInfo[i, 1].Substring(0, saveArrayInfo[i, 1].Length - 1);
                        }
                        else
                        {
                            /*
                             * 当第二维数据为空的时候，应该在二维数组中清除这一行数据
                             * 
                             * 目的:
                             * 考虑到在服务器端插入数据时,会先读取本地传送的内容
                             * 如果提交的数据中只有玩家信息,没有获取的道具 会造成数据的冗余
                             * 
                             * 暂定函数为RemovePlanar(string[,] array,string key) [待定]
                             */
                            saveArrayInfo = RemovePlanar(saveArrayInfo, key);
                        }
                    }
                }
            }
            return saveArrayInfo;
        }

        /// <summary>
        /// 删除二维数组中的某行数据
        /// 1.遍历二维数组,找到第1维内容与key相同者跳到2，否则跳到3
        /// 2.删除找到的数据项
        /// 3.返回新结果
        /// </summary>
        /// <param name="?"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private string[,] RemovePlanar(string[,] array, string key)
        {
            //1
            for (int i = 0; i < array.GetLength(0); i++)
            {
                //3
                if (array[i, 0].Equals(key))
                {
                    //j为找的项所在的索引
                    for (int j = i; j < array.GetLength(0) - 1; j++)
                    {
                        for (int k = 0; k < array.GetLength(1); k++)
                        {
                            array[j, k] = array[j + 1, k];
                        }
                    }
                    string[,] tmpArray = new string[array.GetLength(0) - 1, array.GetLength(1)];
                    for (int m = 0; m < tmpArray.GetLength(0); m++)
                    {
                        for (int n=0;n<tmpArray.GetLength(1);n++)
                        {
                            tmpArray[m, n] = array[m, n];
                        }
                    }
                    array = tmpArray;
                }
            }
            //3
            return array;
        }

        /// <summary>
        /// 检测二位数组中是否存在第一维内容与提供参数相同的情况
        /// 并返回所在的行数
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        private bool IsExistKey(string keyName, ref int row)
        {
            bool isExistKey = false;

            for (int i = 0; i < saveArrayInfo.GetLength(0); i++)
            {
                if (saveArrayInfo[i, 0].Equals(keyName))
                {
                    isExistKey = true;  //存在key
                    row = i;            //在二位数组中的行数
                    break;
                }
            }
            return isExistKey;
        }

        /// <summary>
        /// 移出以为数组中的某一项内容
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private string[] Remove(string[] array, string value)
        {
            string[] tempArray = null;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(value))
                {
                    tempArray = new string[array.Length - 1];

                    for (int j = i; j < array.Length - 1; j++)
                    {
                        array[j] = array[j + 1];
                    }
                    for (int j = 0; j < tempArray.Length; j++)
                    {
                        tempArray[j] = array[j];
                    }
                    array = tempArray;
                }
            }
            return array;
        }
    }
}
