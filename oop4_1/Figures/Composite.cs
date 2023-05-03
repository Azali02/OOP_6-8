using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace oop4_1.Figures
{
    internal class GGroup : Figure
    {
        public List<Figure> _gGroup = new List<Figure>();


        public void Add(Figure figure)
        {
            _gGroup.Add(figure);
        }
        public int Count()
        {
            return _gGroup.Count;
        }
        public List<Figure> GetFigures()
        {
            return _gGroup;
        }
        public Figure GetOriginalFigure()
        {
            return _gGroup[0];
        }
        public void RemoveAt()
        {
            _gGroup.RemoveAt(0);
        }
        public override void Draw(Graphics g)
        {
            foreach (Figure f in _gGroup)
            {
                f.Draw(g);
            }
        }
        public void DrawSelected(Graphics g, Pen pp)
        {
            foreach (Figure f in _gGroup)
            {
                if (f is GGroup gGroup)
                {
                    gGroup.DrawSelected(g, pp);
                }
                else
                {
                    f.Draw(g);
                    g.DrawRectangle(pp, f.x - (f.a + 10) / 2, f.y - (f.a + 10) / 2, f.a + 10, f.a + 10);
                }
            }
        }
        public override bool isClickedOnFigure(int X, int Y)
        {
            foreach (Figure f in _gGroup)
            {
                if (f.isClickedOnFigure(X, Y)) return true;
            }
            return false;
        }
        public override bool DecoratorCheck()
        {
            return _gGroup[1].DecoratorCheck();
        }
        public override void UndecoratedGroup()
        {
            for (int i = 0; i < _gGroup.Count; i++)
            {
                if (_gGroup[i] is Decorator decorator)
                {
                    _gGroup[i] = decorator.GetOriginalFigure();
                }
                else if (_gGroup[i].DecoratorCheck()) //выделенная группа
                {
                    _gGroup[i].UndecoratedGroup();
                }
            }
        }
        public override void SizeUp(int add, int widht, int height)
        {
            foreach (Figure f in _gGroup)
            {
                f.SizeUp(add, widht, height);
            }
        }
        public override void move(int add_X, int add_Y, int widht, int height)
        {
            foreach (Figure f in _gGroup)
            {
                f.move(add_X, add_Y, widht, height);
            }
        }
        public override bool canMove(int add_X, int add_Y, int widht, int height)
        {
            foreach (Figure f in _gGroup)
            {
                if (f.canMove(add_X, add_Y, widht, height)) return true;
            }
            return false;
        }
        public override bool canSizeUp(int add, int widht, int height)
        {
            foreach (Figure f in _gGroup)
            {
                if (f.canSizeUp(add, widht, height)) return true;
            }
            return false;
        }
        public override void SetColor(Color color)
        {
            foreach (Figure f in _gGroup)
            {
                f.pen.Color = color;
            }
        }
        public override void Save(string filename)
        {
            string inf = "G " + _gGroup.Count.ToString();
            using (StreamWriter writer = new StreamWriter(filename, true))
            {
                writer.WriteLine(inf);
            }
            foreach (Figure f in _gGroup)
            {
                f.Save(filename);
            }
        }
    }
}
