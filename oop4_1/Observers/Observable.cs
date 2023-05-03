using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop4_1.Observers
{
    internal class Observable
    {
        public List<Observer> _observers = new List<Observer>();
        protected string Name;

        virtual public String Who()
        {
            return Name;
        }

        virtual public void AddObserver(Observer o)
        {
            _observers.Add(o);
        }
        virtual public void RemoveObserver()
        {
            _observers.Clear();
        }

        virtual public void NotifyEveryone()
        {
            foreach (Observer o in _observers)
            {
                o.OnSubjectChanged(this);
            }
        }

        virtual public void NotifyEveryoneSelect()
        {
            foreach (Observer o in _observers)
            {
                o.OnSubjectSelect(this);
            }
        }

        virtual public void NotifyEveryoneMove(int x, int y, int widht, int height)
        {
            foreach (Observer o in _observers)
            {
                o.OnSubjectMove(x, y, widht, height);
            }
        }

    }
}
