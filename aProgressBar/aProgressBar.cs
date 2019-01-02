using System;
using System.Drawing;
using System.Windows.Forms;

namespace aProgressBar
{
    public class aProgressBar : ProgressBar
    {
        /// <summary>
        /// Hold the text Alignment in ProgressBar
        /// </summary>
        public System.Drawing.ContentAlignment TextAlignment { get; set; }

        /// <summary>
        /// Hold the text Font
        /// </summary>
        public System.Drawing.Font TextFont { get; set; }

        /// <summary>
        /// Hold the text color
        /// </summary>
        public System.Drawing.Color TextColor { get; set; }

        /// <summary>
        /// Ширина отступов текста внутри контрола
        /// </summary>
        public System.Drawing.Point TextMargin { get; set; }

        /// <summary>
        /// Hold the custom text 
        /// </summary>
        public String Text { get; set; }

        public aProgressBar()
        {
            // Modify the ControlStyles flags
            //http://msdn.microsoft.com/en-us/library/system.windows.forms.controlstyles.aspx
            SetStyle( ControlStyles.OptimizedDoubleBuffer 
                    | ControlStyles.UserPaint 
                    | ControlStyles.AllPaintingInWmPaint
                    , true);
            TextAlignment = ContentAlignment.TopLeft;
            TextFont = new Font(FontFamily.GenericSerif, 10);
            TextColor = System.Drawing.SystemColors.ControlText;
            TextMargin = new Point(1, 1);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = ClientRectangle;
            Graphics g = e.Graphics;

            ProgressBarRenderer.DrawHorizontalBar(g, rect);
            if (Value > 0)
            {
                Rectangle clip = new Rectangle(rect.X, rect.Y, (int)Math.Round(((float)Value / Maximum) * rect.Width), rect.Height);
                ProgressBarRenderer.DrawHorizontalChunks(g, clip);
            }
            if (Text != "")
            {
                g.DrawString(Text, TextFont, new SolidBrush(TextColor), getLocation(g));
            }
        }

        private Point getLocation(Graphics _g)
        {
            if (TextAlignment != ContentAlignment.TopLeft)
            {
                SizeF sizeText = _g.MeasureString(Text, TextFont);
                switch (TextAlignment)
                {
                    case ContentAlignment.TopCenter     : return new Point(Convert.ToInt32((Width / 2) - sizeText.Width / 2)        , TextMargin.Y);
                    case ContentAlignment.TopRight      : return new Point(Convert.ToInt32(Width - sizeText.Width - TextMargin.X)   , TextMargin.Y);

                    case ContentAlignment.MiddleLeft    : return new Point(TextMargin.X                                             , Convert.ToInt32((Height / 2) - sizeText.Height / 2));
                    case ContentAlignment.MiddleCenter  : return new Point(Convert.ToInt32((Width / 2) - sizeText.Width / 2)        , Convert.ToInt32((Height / 2) - sizeText.Height / 2));
                    case ContentAlignment.MiddleRight   : return new Point(Convert.ToInt32(Width - sizeText.Width - TextMargin.X)   , Convert.ToInt32((Height / 2) - sizeText.Height / 2));

                    case ContentAlignment.BottomLeft    : return new Point(TextMargin.X                                             , Convert.ToInt32(Height - sizeText.Height - TextMargin.Y));
                    case ContentAlignment.BottomCenter  : return new Point(Convert.ToInt32((Width / 2) - sizeText.Width / 2)        , Convert.ToInt32(Height - sizeText.Height - TextMargin.Y));
                    case ContentAlignment.BottomRight   : return new Point(Convert.ToInt32(Width - sizeText.Width - TextMargin.X)   , Convert.ToInt32(Height - sizeText.Height - TextMargin.Y));
                }
            }
            return TextMargin;
        }
    }
}