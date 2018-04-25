using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace M_GM
{
    class Status
    {
        /// <summary>
        /// 在主界面中写入状态信息
        /// </summary>
        /// <param name="form"></param>
        /// <param name="statusString"></param>
        public static void WriteStatusText(Form form,string statusString)
        {
            string DavidPanelName = "dpStatus";
            string LabelName = "lblStatus";

            for (int i = 0; i < form.Controls.Count; i++)
            {
                if (form.Controls[i].Name.Equals(DavidPanelName))
                {
                    for (int j = 0; j < form.Controls[i].Controls.Count; j++)
                    {
                        if (form.Controls[i].Controls[j].Name.Equals(LabelName))
                        {
                            form.Controls[i].Controls[j].Text = statusString;
                        }
                    }
                }
            }               
        }
    }

    
}
