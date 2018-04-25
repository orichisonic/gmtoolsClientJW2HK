using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace M_FJ
{
    class ShortStringArrayDictionary : DictionaryBase
    {
        #region

        public ArrayList this[String key]
        {
            get
            {
                return ((ArrayList)Dictionary[key]);
            }
            set
            {
                Dictionary[key] = value;
            }
        }
        public ICollection Keys
        {
            get
            {
                return (Dictionary.Keys);
            }
        }
        public ICollection Values
        {
            get
            {
                return (Dictionary.Values);
            }
        }

        public void Add(String key, ArrayList value)
        {
            if (Dictionary.Contains(key) != false)
                return;
            Dictionary.Add(key, value);
        }
        public bool contains(String key)
        {
            return (Dictionary.Contains(key));
        }
        public void Remove(String key)
        {
            Dictionary.Remove(key);
        }

        protected override void OnInsert(object key, object value)
        {
            if (key.GetType() != typeof(System.String))
                throw new ArgumentException("键值必须是一个字符串类型。", "key");
            else
            {
                String strKey = (String)key;
                //if (strKey.Length < 10)
                //    throw new ArgumentException("键值不能少于10个字符");
            }

            if (value.GetType() != typeof(System.Collections.ArrayList))
                throw new ArgumentException("键值必须是一个ArrayList类型", "value");
            else
            {

                System.Collections.ArrayList strValue = (System.Collections.ArrayList)value;
                //if ( strValue.Length > 5 )
                //   throw new ArgumentException( "value must be no more than 5 characters in length.", "value" );
            }
        }

        protected override void OnRemove(Object key, Object value)
        {
            if (key.GetType() != typeof(System.String))
                throw new ArgumentException("key must be of type String.", "key");
            else
            {
                String strKey = (String)key;
                //if ( strKey.Length > 5 )
                //   throw new ArgumentException( "key must be no more than 5 characters in length.", "key" );
            }
        }

        protected override void OnSet(Object key, Object oldValue, Object newValue)
        {
            if (key.GetType() != typeof(System.String))
                throw new ArgumentException("key must be of type String.", "key");
            else
            {
                String strKey = (String)key;
                //if ( strKey.Length > 5 )
                //   throw new ArgumentException( "key must be no more than 5 characters in length.", "key" );
            }

            if (newValue.GetType() != typeof(System.Collections.ArrayList))
                throw new ArgumentException("newValue must be of type ArrayList.", "newValue");
            else
            {
                System.Collections.ArrayList strValue = (System.Collections.ArrayList)newValue;
                //if ( strValue.Length > 5 )
                //   throw new ArgumentException( "newValue must be no more than 5 characters in length.", "newValue" );
            }
        }


        protected override void OnValidate(Object key, Object value)
        {
            if (key.GetType() != typeof(System.String))
                throw new ArgumentException("key must be of type String.", "key");
            else
            {
                String strKey = (String)key;
                //if ( strKey.Length > 5 )
                //   throw new ArgumentException( "key must be no more than 5 characters in length.", "key" );
            }

            if (value.GetType() != typeof(System.Collections.ArrayList))
                throw new ArgumentException("value must be of type ArrayList.", "value");
            else
            {
                System.Collections.ArrayList strValue = (System.Collections.ArrayList)value;
                //if ( strValue.Length > 5 )
                //   throw new ArgumentException( "value must be no more than 5 characters in length.", "value" );
            }
        }



        #endregion


    }
}
