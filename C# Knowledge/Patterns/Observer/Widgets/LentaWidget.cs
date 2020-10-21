using System;
using System.Collections.Generic;
using System.Text;
using Observer.News;

namespace Observer.Widgets
{
    class LentaWidget : IWidget
    {
        private string _lenta;
        public void Display()
        {
            Console.WriteLine("Lenta: {0}", _lenta);
        }

        public void Update(object s, NewsEventArgs e)
        {
            _lenta = e.Lenta;
            Display();
        }
    }
}
