using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace M_AU
{
    public partial class SendReasion : Form
    {
        SendAboutInfo about = null;

        public SendReasion()
        {
            InitializeComponent();
        }

        public SendReasion(SendAboutInfo about)
        {
            this.about = about;
            InitializeComponent();
        }

        private void SendReasion_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbxExpire.Text == null || cbxExpire.Text == "")
            {
                MessageBox.Show("请选择有效时效");
                return;
            }

            about.REASON = (this.txtReason.Text == "" || txtReason.Text == null) ? "" : txtReason.Text.ToString();

            switch (cbxExpire.Text)
            {
                case "1个月":
                    about.EXPIRE = 30;
                    break;
                case "3个月":
                    about.EXPIRE = 90;
                    break;
                default:
                    about.EXPIRE = 30;
                    break;
            }

            this.Close();
            

        }
    }
}