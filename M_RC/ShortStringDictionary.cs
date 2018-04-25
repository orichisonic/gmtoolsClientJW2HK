using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace M_RC
{
    class ShortStringDictionary : DictionaryBase
    {
        #region

        public String this[String key]
        {
            get
            {
                return ((String)Dictionary[key]);
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

        public void Add(String key, String value)
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

            if (value.GetType() != typeof(System.String))
                throw new ArgumentException("键值必须是一个String类型", "value");
            else
            {

                String strValue = (String)value;
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

            if (newValue.GetType() != typeof(System.String))
                throw new ArgumentException("newValue must be of type String.", "newValue");
            else
            {
                String strValue = (String)newValue;
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

            if (value.GetType() != typeof(System.String))
                throw new ArgumentException("value must be of type String.", "value");
            else
            {
                String strValue = (String)value;
                //if ( strValue.Length > 5 )
                //   throw new ArgumentException( "value must be no more than 5 characters in length.", "value" );
            }
        }



        #endregion


    }
}
