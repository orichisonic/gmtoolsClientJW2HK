using System;
using System.Collections.Generic;
using System.Text;

namespace M_AU
{
    public class SendAboutInfo
    {

        private string reason = null;
        private int expire = 30;

        public string REASON
        {
            get
            {
                return this.reason;
            }
            set
            {
                this.reason = value;
            }
        }

        public int EXPIRE
        {
            get
            {
                return this.expire;
            }
            set
            {
                this.expire = value;
            }
        }
    }
}
