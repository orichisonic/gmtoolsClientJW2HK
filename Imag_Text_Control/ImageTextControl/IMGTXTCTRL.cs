using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ImageTextControl
{
    public delegate void ITCEventHandler(object sender);

    public partial class IMGTXTCTRL : UserControl
    {

        public event ITCEventHandler ITC_CLICIK;

        private string _text = null;
        private Color _textMouseHoverColor = new Color();
        private Color _textForeColor = new Color();
        private bool _changeForeColor = false;
        private Point _controlPoint = new Point();
        private Image _imgSrc = null;


        protected override void OnPaint(PaintEventArgs e)
        {
            int space = 5;
            this.IMG.Location = new Point(0, 0);

            int txtLocationX = this.IMG.Width + space;
            int txtLocationY = (this.IMG.Height - this.TXT.Height) / 2;
            this.TXT.Location = new Point(txtLocationX, txtLocationY);

            this.Width = this.IMG.Size.Width + this.TXT.Size.Width + space;
            this.Height = this.IMG.Size.Height;

            if (_changeForeColor)
            {
                this.TXT.ForeColor = this._textMouseHoverColor;
            }
            else
            {
                this.TXT.ForeColor = this._textForeColor;
            }
        }

        [Category("外观")]
        [Description("文字内容")]
        public Point ControlPoint
        {
            get
            {
               return _controlPoint;
            }
            set
            {
                _controlPoint = value;
            }
        }


        public IMGTXTCTRL()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
        }

        [Category("外观")]
        [Description("文字内容")]
        public string ITXT_TEXT
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                this.TXT.Text = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 字体前景色
        /// </summary>
        [Category("外观")]
        [Description("字体前景色")]
        public Color ITXT_ForeColor
        {
            get
            {
                return _textForeColor;
            }
            set
            {
                _textForeColor = value;
                this.TXT.ForeColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 鼠标在控件上方时字体颜色
        /// </summary>
        [Category("外观")]
        [Description("鼠标在控件上方时字体颜色")]
        public Color ITXT_MouseHoverColor
        {
            get
            {
                return _textMouseHoverColor;
            }
            set
            {
                _textMouseHoverColor = value;
                this.TXT.ForeColor = value;
                this.Invalidate();
            }
        }

        [Category("外观")]
        [Description("空间显示图片")]
        public Image IMG_SRC
        {
            get
            {
                return _imgSrc;
            }
            set
            {
                _imgSrc = value;
                this.IMG.Image = value;
                this.Invalidate();
            }
        }

        private void IMGTXT_MOUSEMOVE(object sender, MouseEventArgs e)
        {
            if (e.X >= 0 && e.X <= this.Width && e.Y >= 0 && e.Y <= this.Height)
            {
                _changeForeColor = true;
            }
            this.Invalidate();
        }

        private void IMGTXTCTRL_MouseLeave(object sender, EventArgs e)
        {
            _changeForeColor = false;
            this.Invalidate();
        }

        private void TXT_MouseMove(object sender, MouseEventArgs e)
        {
            _changeForeColor = true;
            this.Invalidate();
        }

        private void IMG_MouseMove(object sender, MouseEventArgs e)
        {
            _changeForeColor = true;
            this.Invalidate();
        }

        private void TXT_MouseLeave(object sender, EventArgs e)
        {
            _changeForeColor = false;
            this.Invalidate();
        }

        private void IMG_MouseLeave(object sender, EventArgs e)
        {
            _changeForeColor = false;
            this.Invalidate();
        }

        private void IMGTXTCTRL_MouseDown(object sender, MouseEventArgs e)
        {
            if (this._changeForeColor && ITC_CLICIK != null)
            {
                ITC_CLICIK(this);
            }
        }

        private void TXT_Click(object sender, EventArgs e)
        {
            if (this._changeForeColor && ITC_CLICIK != null)
            {
                ITC_CLICIK(this);
            }
        }

        private void IMG_Click(object sender, EventArgs e)
        {
            if (this._changeForeColor && ITC_CLICIK != null)
            {
                ITC_CLICIK(this);
            }
        }
    }
}
