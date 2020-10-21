using System;
using System.Collections.Generic;
using System.Text;

namespace Observer.News
{
    interface ISubject
    {
        void RegisterObserver(Widgets.IObserver observer);
        void RemoveObserver(Widgets.IObserver observer);
        void NotifyObserver();
    }
}
