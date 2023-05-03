using oop4_1.Observers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace oop4_1
{
    internal abstract class Figure : Observable, Observer
    {
        public int x;
        public int y;
        public int a = 70;
        public Pen pen;
        public abstract void Draw(Graphics g); //отрисовка фигры
        public abstract bool isClickedOnFigure(int X, int Y); //определение попадания в фигуру
        public virtual bool DecoratorCheck() { return false; }
        public virtual void UndecoratedGroup() { }
        public virtual void SizeUp(int add, int widht, int height) { a += add; }
        public virtual void move(int add_X, int add_Y, int widht, int height)
        {
            x += add_X;
            y += add_Y;
        }
        public virtual bool canSizeUp(int add, int widht, int height) //проверка выхода за область при увеличении
        {
            return x - add - 3 - a / 2 <= 0 ||
                y - add - 3 - a / 2 <= 0 || x + add + 3 + a / 2 >= widht ||
                y + add + 3 + a / 2 >= height;
        }
        public virtual bool canMove(int add_X, int add_Y, int widht, int height)   //проверка выхода за область при перемещении
        {
            return x + add_X - 3 - a / 2 <= 0 ||
                y + add_Y - 3 - a / 2 <= 0 || x + add_X + 3 + a / 2 >= widht ||
                y + add_Y + 3 + a / 2 >= height;
        }
        public virtual void SetColor(Color color) { pen.Color = color; }   //установка цвета
        public Color GetColor() { return pen.Color; }  //определение цвета
        public abstract void Save(string filename);
        public string ColorCode()
        {
            if (pen.Color == Color.Red) { return "R"; }
            else if (pen.Color == Color.Black) { return "B"; }
            else if (pen.Color == Color.Blue) { return "S"; }
            else if (pen.Color == Color.Green) { return "G"; }
            else { return "Y"; }
        }
        //---------------------------------
        virtual public String Who()
        {
            return Name;
        }
        public void OnSubjectChanged(Observable who)
        {
            return;
        }

        public void OnSubjectSelect(Observable who)
        {
            return;
        }

        public void OnSubjectMove(int x, int y, int widht, int height)
        {
            move(x, y, widht, height);
        }
    }
}
