using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace oop4_1.Observers
{
    internal interface Observer
    {
        void OnSubjectChanged(Observable who);

        void OnSubjectSelect(Observable who);

        void OnSubjectMove(int x, int y, int widht, int height);
    }
}
