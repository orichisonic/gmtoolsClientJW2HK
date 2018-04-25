using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FRM_MJ
{
    public partial class waiting : Form
    {
        public waiting()
        {
            InitializeComponent();
        }


        private void waiting_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 50000; i++)
            {
                
            }
            this.Close();
        }
    }
}