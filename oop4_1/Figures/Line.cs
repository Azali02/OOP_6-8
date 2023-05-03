using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop4_1.Figures
{
    internal class Line : Figure
    {
        Figure shape1;
        Figure shape2;
        public Line(int x, int y)
        {
            this.x = x;
            this.y = y;
            pen = new Pen(Color.Red);
            pen.DashStyle = DashStyle.Dash;
        }

        public void addLine(Figure s1, Figure s2)
        {
            shape1 = s1;
            shape2 = s2;
            shape2.AddObserver(shape1);
        }

        public override void Save(string filename)
        {
            //--------------
        }

        //public override void Load(StreamReader stream)
        //{
        //    string[] values = stream.ReadLine().Split(' ');
        //    p.X = int.Parse(values[0]);
        //    p.Y = int.Parse(values[1]);
        //    R = int.Parse(values[2]);
        //    Colored = char.Parse(values[3]);
        //}
        public override bool isClickedOnFigure(int X, int Y)
        {
            return false;
        }
        override public void Draw(Graphics g)
        {
            Point startPoint = new Point(shape1.x, shape1.y);
            Point endPoint = new Point(shape2.x, shape2.y);

            // Рисуем линию между начальной и конечной точками
            g.DrawLine(pen, startPoint, endPoint);
            g.DrawEllipse(pen, x - a / 6, y - a / 6, a / 3, a / 3);
            return;
        }

        public void Del()
        {
            shape1.RemoveObserver();
            shape2.RemoveObserver();
        }
    }
}
