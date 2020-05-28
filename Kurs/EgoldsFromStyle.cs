using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Kursach
{
    public partial class egoldsFromStyle1 : Component
    {
        #region --Поля--
        public enum FStyle // Набор стилей
        {
            None,

            UserStyle,

            SimpleDark,
            TelegramStyle
        }

        private readonly int HeaderHeight = 28;
        private FStyle formStyle = FStyle.None;
        private readonly Color HeaderColor = Color.DimGray;
        private readonly StringFormat SF = new StringFormat();
        private readonly Font Font = new Font("Arial", 8.75F, FontStyle.Regular);

        private Size IconSize = new Size(14, 14);
        bool MousePressed = false;//кнопка мыши нажата
        Point clickPosition;//Начальная позиция курсора в момент клика
        Point moveStartPosition;//Начальная позиция формы в момент клика
        bool BtnCloseHovered = false;

        Rectangle rectBtnClose = new Rectangle();
        readonly Pen WhitePen = new Pen(Color.White){ Width = 1.55F};


        #endregion

        #region -- Свойства --

        public Form Form { get; set; }
        public FStyle FormStyle
        {
            get => formStyle;
            set
            {
                formStyle = value;
                Sign();
            }
        }

        #endregion

        #region --FormEvents--

        private void Form_Load(object sender, EventArgs e)
        {
            Apply();
        }

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            DrawStyle(e.Graphics);
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Location.Y <= HeaderHeight)
            {
                MousePressed = true;
                clickPosition = Cursor.Position;
                moveStartPosition = Form.Location;
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            MousePressed = false;

            if(e.Button == MouseButtons.Left)
            {
                if (rectBtnClose.Contains(e.Location))
                    Form.Close();
            }
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (MousePressed)
            {
                Size frmOffSet = new Size(Point.Subtract(Cursor.Position, new Size(clickPosition)));
                Form.Location = Point.Add(moveStartPosition, frmOffSet);
            }
            else
            {
                if(rectBtnClose.Contains(e.Location))
                {
                    if(BtnCloseHovered == false)
                    {
                        BtnCloseHovered = true;
                        Form.Invalidate();
                    }
                }
                else
                {
                    if (BtnCloseHovered == true)
                    {
                        BtnCloseHovered = false;
                        Form.Invalidate();
                    }
                }
            }
        }

        private void Form_MouseLeave(object sender, MouseEventArgs e)
        {
            BtnCloseHovered = false;
            Form.Invalidate();
        }

        #endregion

        public egoldsFromStyle1()
        {
            InitializeComponent();
        }

        public egoldsFromStyle1(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void Sign()
        {
            if (Form != null)
                Form.Load += Form_Load;
        }

        private void Apply()
        {
            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;

            Form.FormBorderStyle = FormBorderStyle.None;

            OffsetContorls();

            Form.Paint += Form_Paint;
            Form.MouseDown += Form_MouseDown;
            Form.MouseUp += Form_MouseUp;
            Form.MouseMove += Form_MouseMove;
           // Form.MouseLeave += Form_MouseLeave;

        }

        private void OffsetContorls()
        {
            Form.Height = Form.Height + HeaderHeight;

            foreach(Control ctrl in Form.Controls)
            {
                ctrl.Location = new Point(ctrl.Location.X, ctrl.Location.Y + HeaderHeight);
                ctrl.Refresh();
            }
        }

        private void DrawStyle(Graphics graph)
        {
            graph.SmoothingMode = SmoothingMode.HighQuality;

            Rectangle rectHeader = new Rectangle(0,0, Form.Width - 1, HeaderHeight);//Верхняя часть
            Rectangle rectBorder = new Rectangle(0, 0, Form.Width - 1, Form.Height - 1);//Линия обводки формы
            Rectangle rectTitleText = new Rectangle(rectHeader.X , rectHeader.Y, rectHeader.Width, rectHeader.Height);

            Rectangle rectIcon = new Rectangle(rectHeader.Height / 2 - IconSize.Width / 2, rectHeader.Height/2 - IconSize.Width / 2, IconSize.Width, IconSize.Height);//Размер иконки

            rectBtnClose = new Rectangle(rectHeader.Width - rectHeader.Height, rectHeader.Y, rectHeader.Height, rectHeader.Height);//Прямоугольник красный при закрытии формы
            Rectangle rectCrosshair = new Rectangle(
                rectBtnClose.X + rectBtnClose.Width / 2 - 6,
                rectBtnClose.Height / 2 - 5,
                10, 10);//Прямоугольик для крестика на кнопке выхода

            Rectangle rectCollapse = new Rectangle(rectBtnClose.X + rectBtnClose.Width / 2 - 35,
                rectBtnClose.Height / 2 + 4,
                10, 10);//Кнопка свернуть
            

            //Шапка
            graph.DrawRectangle(new Pen(HeaderColor),rectHeader);
            graph.FillRectangle(new SolidBrush(HeaderColor), rectHeader);

            //Текст заголовка
            graph.DrawString(Form.Text, Font, new SolidBrush(Color.White), rectTitleText, SF);

            //Иконка
            graph.DrawImage(Form.Icon.ToBitmap(), rectIcon);

            //Кнопка Х
            graph.DrawRectangle(new Pen(BtnCloseHovered ? Color.Red : HeaderColor), rectBtnClose);
            graph.FillRectangle(new SolidBrush(BtnCloseHovered ? Color.Red : HeaderColor), rectBtnClose);
            DrawCrosshair(graph, rectCrosshair, WhitePen);

            //Кнопка -- 
            graph.DrawLine(WhitePen, rectCollapse.X, rectCollapse.Y, rectCollapse.X + rectCollapse.Width, rectCollapse.Y);

            //Обводка
            graph.DrawRectangle(new Pen(Color.Black), rectBorder);

        }

        private void DrawCrosshair(Graphics graph, Rectangle rect, Pen pen)//Рисование крестика
        {
            graph.DrawLine(pen, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
            graph.DrawLine(pen, rect.X + rect.Width, rect.Y, rect.X, rect.Y + rect.Height);
        }
    }
}
