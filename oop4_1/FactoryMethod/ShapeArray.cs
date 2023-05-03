using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oop4_1.Figures;

namespace oop4_1.FactoryMethod
{
    internal class ShapeArray : Method
    {
        public void LoadShapes(string filename, Method factory, List<Figure> figure)
        {
            for (int i = 0; i < figure.Count;)
            {
                figure.Remove(figure[i]);
            }
            FileStream stream = new FileStream(filename, FileMode.Open);
            StreamReader reader = new StreamReader(stream);
            int count = int.Parse(reader.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string code = reader.ReadLine();
                if (code[0] == 'G')
                {
                    GGroup _shape = new GGroup();
                    string[] words = code.Split(' ');
                    int n = int.Parse(words[1]);
                    for (int j = 0; j < n; j++)
                    {
                        string _code = reader.ReadLine();
                        Figure shapeGroupe = factory.CreateShape(_code);
                        if (shapeGroupe != null) { _shape.Add(shapeGroupe); }
                    }
                    figure.Add(_shape);
                }
                else
                {
                    Figure shape = factory.CreateShape(code);
                    if (shape != null)
                    {
                        figure.Add(shape);
                    }
                }
            }
            reader.Close();
            stream.Close();
        }
    }
}
