using oop4_1.Observers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace oop4_1.Figures
{
    internal class Decorator : Figure
    {
        public Figure _shape;
        private Pen pp;

        public Decorator(Figure shape)
        {
            _shape = shape;

            a = shape.a + 10;
            pp = new Pen(Color.Black);
            pp.DashStyle = DashStyle.Dash;
        }
        public override void Draw(Graphics g)
        {
            _shape.Draw(g);
            if (_shape is GGroup gGroup)
            {
                gGroup.DrawSelected(g, pp);
            }
            else g.DrawRectangle(pp, _shape.x - a / 2, _shape.y - a / 2, a, a);
        }
        public override bool isClickedOnFigure(int X, int Y)
        {
            return _shape.isClickedOnFigure(X, Y);
        }
        public Figure GetOriginalFigure()
        {
            return _shape;
        }
        public override bool DecoratorCheck()
        {
            return true;
        }
        public override void SizeUp(int add, int widht, int height)
        {
            if (!_shape.canSizeUp(add, widht, height))
            {
                _shape.SizeUp(add, widht, height);
                base.SizeUp(add, widht, height);
            }
        }
        public override void move(int add_X, int add_Y, int widht, int height)
        {
            if (!_shape.canMove(add_X, add_Y, widht, height))
            {
                _shape.move(add_X, add_Y, widht, height);
                base.move(add_X, add_Y, widht, height);
            }
        }
        public override void SetColor(Color color)
        {
            _shape.SetColor(color);
        }
        public override void Save(string filename)
        {
            _shape.Save(filename);
        }

        //---------------------------------------------
        public override string Who()
        {
            return _shape.Who();
        }
        override public void AddObserver(Observer o)
        {
            _shape.AddObserver(o);
        }
        override public void RemoveObserver()
        {
            _shape.RemoveObserver();
        }

        override public void NotifyEveryone()
        {
            _shape.NotifyEveryone();
        }

        override public void NotifyEveryoneSelect()
        {
            _shape.NotifyEveryoneSelect();
        }

        public void OnSubjectMove(int x, int y, int widht, int height)
        {
            _shape.move(x, y, widht, height);
        }
    }
}
