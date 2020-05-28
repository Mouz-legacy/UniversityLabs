using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Kursach
{
    class MyButton : Control
    {
        

        private bool roundingEnable = false;
        [Description("Вкл/Выкл Закругление объекта")]
        public bool RoundingEnable
        {
            get => roundingEnable;
            set
            {
                roundingEnable = value;
                Refresh();
            }
        }

        private int roundingPercent = 100;
        [DisplayName("Rounding [%]")]
        [DefaultValue(100)]
        [Description("Указывает радиус закругления объекта в процентном соотношении")]
        public int Rounding
        {
            get => roundingPercent;
            set
            {
                if(value >= 0 && value <= 100)
                {
                    roundingPercent = value;

                    Refresh();
                }
            }
        }

        private readonly StringFormat SF = new StringFormat();
        private bool MouseEnter = false;
        public MyButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            Size = new Size(100, 30);
            BackColor = Color.Tomato;
            ForeColor = Color.White;

            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graph = e.Graphics;
            graph.SmoothingMode = SmoothingMode.HighQuality;

            graph.Clear(Parent.BackColor);

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            //Закругление
            float roundingValue = 0.1F;
            if(RoundingEnable && roundingPercent > 0)
            {
                roundingValue = Height/100F * roundingPercent;
            }
            GraphicsPath rectPath = Drawer.RoundedRectangle(rect, roundingValue);


            //Основа
            graph.DrawPath(new Pen(BackColor), rectPath);
            graph.FillPath(new SolidBrush(BackColor), rectPath);

            if(MouseEnter)
            {
                graph.DrawRectangle(new Pen(Color.FromArgb(60, Color.White)), rect);
                graph.FillRectangle(new SolidBrush(Color.FromArgb(60, Color.White)), rect);
            }

            graph.DrawString(Text, Font, new SolidBrush(ForeColor), rect, SF);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            MouseEnter = true;

            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);


            MouseEnter = false;

            Invalidate();
        }
    }
}
