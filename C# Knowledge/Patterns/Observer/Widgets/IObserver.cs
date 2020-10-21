using System;
using System.Collections.Generic;
using System.Text;

namespace Observer.Widgets
{
    public interface IObserver
    {
        void Update(string twitter, string lenta, string tv);
        void RemoveFromSubject();
    }
}
