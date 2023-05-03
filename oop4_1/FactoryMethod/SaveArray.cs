using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop4_1.FactoryMethod
{
    internal class SaveArray
    {
        public void save(List<Figure> figure, string filename)
        {
            int count = figure.Count;
            if (count == 0) { return; }
            File.WriteAllText(filename, count.ToString() + Environment.NewLine);
            foreach (Figure f in figure)
            {
                f.Save(filename);
            }
        }
    }
}
