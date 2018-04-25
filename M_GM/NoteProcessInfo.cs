using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Language;

namespace M_GM
{
    public partial class NoteProcessInfo : Form
    {
        private string notesTitle = null;
        private string notesContent = null;
        private string notesProcesser = null;
        private string notesProcessDate = null;
        private string notesProcessContent = null;
        private int xPos = 0;
        private int yPos = 0;

        #region 属性
        public string NotesTitle
        {
            set
            {
                notesTitle = value;
            }
        }

        public string NotesContent
        {
            set
            {
                notesContent = value;
            }
        }

        public string NotesProcesser
        {
            set
            {
                notesProcesser = value;
            }
        }

        public string NotesProcessDate
        {
            set
            {
                notesProcessDate = value;
            }
        }

        public string NotesProcessContent
        {
            set
            {
                notesProcessContent = value;
            }
        }

        public int XPos
        {
            set
            {
                xPos = value;
            }
        }

        public int YPos
        {
            set
            {
                yPos = value;
            }
        }

        #endregion

        public NoteProcessInfo()
        {
            InitializeComponent();
        }


        public NoteProcessInfo(string notesTitle,string notesContent,string notesProcesser,string notesProcessDate,string notesProcessContent,int xPos,int yPos,ConfigValue config)
        {
            
            InitializeComponent();

            this.notesTitle = notesTitle;
            this.notesProcesser = notesProcesser;
            this.notesContent = notesContent;
            this.notesProcessDate = notesProcessDate;
            this.notesProcessContent = notesProcessContent;
            this.xPos = xPos;
            this.yPos = yPos;
            this.config = config;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void NoteProcessInfo_Load(object sender, EventArgs e)
        {
            IntiFontLib();

            this.lblNoteTitle.Text = notesTitle;
            this.lblProcesser.Text = notesProcesser;
            this.txtNotesContent.Text = notesContent;
            this.lblProcessDate.Text = notesProcessDate;
            this.txtProcessContent.Text = notesProcessContent;

            if (xPos > (Screen.GetWorkingArea(this).Width - this.Width))
            {
                xPos = Screen.GetWorkingArea(this).Width - this.Width;
            }
            if (yPos > (Screen.GetWorkingArea(this).Height - this.Height))
            {
                yPos = Screen.GetWorkingArea(this).Height - this.Height;
            }
            this.Location = new Point(xPos, yPos);
            this.Invalidate();
        }

        private void dividerPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        #region 语言库
        /// <summary>
        ///　文字库
        /// </summary>
        ConfigValue config = null;

        /// <summary>
        /// 初始化华文字语言库
        /// </summary>
        private void IntiFontLib()
        {
            //config = (ConfigValue)m_ClientEvent.GetInfo("INI");
            IntiUI();
        }

        private void IntiUI()
        {

            this.linkLabel1.Text = config.ReadConfigValue("MGM", "NPL_UI_Close");
            this.label2.Text = config.ReadConfigValue("MGM", "NPL_UI_Object");
            this.label3.Text = config.ReadConfigValue("MGM", "NPL_UI_Content");
            this.label1.Text = config.ReadConfigValue("MGM", "NPL_UI_People");
            this.label4.Text = config.ReadConfigValue("MGM", "NPL_UI_Date");
            this.label5.Text = config.ReadConfigValue("MGM", "NPL_UI_Description");
        }


        #endregion
    }
}