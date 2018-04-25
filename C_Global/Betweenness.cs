using System;
using System.Collections.Generic;
using System.Text;

namespace C_Global
{
    /// <summary>
    /// 
    /// </summary>
    public class Betweenness
    {
        public Betweenness(BetweennessValue btwnValue)
        {
            _btwnValue = btwnValue;
        }

        /// <summary>
        /// 操作执行结果
        /// </summary>
        private BetweennessValue _btwnValue = BetweennessValue.SUCESS;   

        /// <summary>
        /// 执行状态值
        /// </summary>
        public BetweennessValue BtwnValue
        {
            set
            {
                _btwnValue = value;
            }
            get
            {
                return _btwnValue;
            }
        }

    }

    public enum BetweennessValue
    {
        SUCESS,
        FAILURE
    }
}
