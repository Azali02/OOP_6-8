
using System.Drawing.Drawing2D;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace oop4_1
{
    internal class CCircle : Figure
    {
        public CCircle(int x, int y)
        {
            this.x = x;
            this.y = y;
            pen = new Pen(Color.Red, 3);
        }
        public override void Draw(Graphics g)  //отрисовка круга
        {
            g.DrawEllipse(pen, x - a / 2, y - a / 2, a, a);
        }
        public override bool isClickedOnFigure(int X, int Y) //определение попадания в круг
        {
            return (X - x) * (X - x) + (Y - y) * (Y - y) <= a * a / 4;
        }
        public override bool DecoratorCheck()
        {
            return false;
        }

    }
}
