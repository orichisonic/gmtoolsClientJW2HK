 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using C_Global;

namespace C_Controls.LabelTextBox
{
    public partial class LabelTextBox : UserControl
    {
        public LabelTextBox()
        {
            InitializeComponent();
        }

        public LabelTextBox(bool isVisable)
        {
            InitializeComponent();
            LblText.Visible = isVisable;
            TxtContent.Visible = isVisable;

            
        }

        private void LabelTextBox_Load(object sender, EventArgs e)
        {
            //初始化控件属性
            LblText.AutoSize = true;
            this.Height = LblText.Height + TxtContent.Height;
            MoveControls();
            ReadOnlyControls();
        }

        private void LabelTextBox_SizeChanged(object sender, EventArgs e)
        {
            MoveControls();
        }

        private void TxtContent_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e);
        }

        private void TxtContent_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnKeyPress(e);
        }

        private void TxtContent_KeyUp(object sender, KeyEventArgs e)
        {
            OnKeyUp(e);
        }

        private void TxtContent_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            OnPreviewKeyDown(e);
        }

        #region 控件属性
        /// <summary>
        /// LABELTEXTBOX 的位置属性
        /// </summary>
        private int mMargin = 0;
        private int mTxtTop = 0;
        private CEnum.TagName mTag = CEnum.TagName.ERROR_Msg;
        private CEnum.TagFormat mFormat = CEnum.TagFormat.TLV_INTEGER;
        private bool mReadOnly = true;
        private ELABELPOSITION mPosition = ELABELPOSITION.LEFT;
        private System.Drawing.ContentAlignment mAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        public event System.EventHandler PositionChanged = null;
        public enum ELABELPOSITION
        {
            TOP,
            LEFT,
        }

        public ELABELPOSITION Position
        {
            get
            {
                return mPosition;
            }

            set
            {
                mPosition = value;

                MoveControls();

                if (PositionChanged != null)
                {
                    System.Delegate[] subscribers = PositionChanged.GetInvocationList();

                    foreach (System.EventHandler target in subscribers)
                    {
                        target(this, new EventArgs());
                    }
                }
            }
        }

        public int sMargin
        {
            get
            {
                return mMargin;
            }

            set
            {
                mMargin = value;

                MoveControls();
            }
        }


        public bool IsVisable
        {
            set
            {
                TxtContent.Visible = value;
                LblText.Visible = value;
            }
        }


        public string LabelText
        {
            get
            {
                return LblText.Text;
            }

            set
            {
                LblText.Text = value;

                MoveControls();
            }
        }

        public string TextBoxText
        {
            get
            {
                return TxtContent.Text;
            }

            set
            {
                TxtContent.Text = value;
            }
        }

        public CEnum.TagName TagName
        {
            get
            {
                return mTag;
            }

            set
            {
                mTag = value;
            }
        }

        public CEnum.TagFormat TagFmt
        {
            get
            {
                return mFormat;
            }

            set
            {
                mFormat = value;
            }
        }

        public bool ReadOnly
        {
            get
            {
                return mReadOnly;
            }
            set
            {
                mReadOnly = value;

                ReadOnlyControls();
            }
        }

        private void MoveControls()
        {
            this.LblText.Top = 6;

            switch (mPosition)
            {
                case ELABELPOSITION.TOP:
                    this.TxtContent.Top = this.LblText.Height + 5;
                    this.TxtContent.Left = this.LblText.Left + mMargin;
                    this.TxtContent.Width = this.Width - 3;
                    this.Height = this.LblText.Height + this.TxtContent.Height + 5;
                    break;
                case ELABELPOSITION.LEFT:
                    int iWidth = this.Width - this.LblText.Width - 5;

                    this.TxtContent.Top = this.LblText.Top - mTxtTop;
                    this.TxtContent.Left = this.LblText.Width + 5 + mMargin;
                    this.TxtContent.Width = iWidth;
                    this.Height = 24;

                    this.LblText.TextAlign = mAlignment;
                    break;
            }
        }

        private void ReadOnlyControls()
        {
            switch (mReadOnly)
            {
                case false:
                    mTxtTop = 0;

                    TxtContent.ReadOnly = false;
                    TxtContent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    break;
                case true:
                    mTxtTop = -1;

                    TxtContent.ReadOnly = true;
                    TxtContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    break;
            }

            MoveControls();
        }

        #endregion
    }
}
