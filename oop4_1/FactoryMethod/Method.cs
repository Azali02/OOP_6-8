using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oop4_1.Figures;

namespace oop4_1.FactoryMethod
{
    internal class Method
    {
        public virtual Figure CreateShape(string code)
        {
            Figure shape = null;
            string[] words = code.Split(' ');
            char f = char.Parse(words[0]);   //words[0].ToCharArray()[0];
            int x = int.Parse(words[1]);
            int y = int.Parse(words[2]);
            int a = int.Parse(words[3]);
            char c = char.Parse(words[4]);
            Color color = Color.White;
            switch (c)
            {
                case 'B':
                    color = Color.Black;
                    break;
                case 'S':
                    color = Color.Blue;
                    break;
                case 'G':
                    color = Color.Green;
                    break;
                case 'Y':
                    color = Color.Yellow;
                    break;
                case 'R':
                    color = Color.Red;
                    break;
                default:
                    break;
            }
            switch (f)
            {
                case 'C':
                    shape = new CCircle(x, y);
                    break;
                case 'S':
                    shape = new Square(x, y);
                    break;
                case 'T':
                    shape = new Triangle(x, y);
                    break;
                default:
                    break;
            }
            shape.a = a;
            shape.pen.Color = color;
            return shape;
        }
    }
}
