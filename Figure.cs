using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace oop4_1
{
    internal abstract class Figure
    {
        public int x;
        public int y;
        public int a = 70;
        public Pen pen;
        public abstract void Draw(Graphics g); //отрисовка фигры
        public abstract bool isClickedOnFigure(int X, int Y); //определение попадания в фигуру
        public abstract bool DecoratorCheck();
        public virtual void SizeUp(int add, int widht, int height)
        {
            a += add;
        }
        public virtual void move(int add_X, int add_Y, int widht, int height)
        {
            x += add_X;
            y += add_Y;
        }
        public virtual bool canMove(int add_X, int add_Y, int widht, int height)
        {
            return ((x + add_X - 3 - a / 2) <= 0 || (y+ add_Y - 3 - a / 2) <= 0 || (x + add_X + 3 + a / 2) >= widht || (y + add_Y + 3 + a / 2) >= height);
        }
        public virtual void SetColor(Color color)  //установка цвета
        {
            pen.Color = color;
        }

    }
}
