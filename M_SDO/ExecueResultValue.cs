using System;
using System.Collections.Generic;
using System.Text;

namespace M_SDO
{
    public enum ActionResult
    {
        sucess,
        failure
    }

    class ExecueResultValue
    {

        private ActionResult _result = ActionResult.sucess;

        public ActionResult RESULT
        {
            set
            {
                _result = value;
            }
            get
            {
                return _result;
            }
        }


    }


}
