using Observer.News;
using System;
using System.Collections.Generic;
using System.Text;

namespace Observer.Widgets
{
    class TvWidget : IWidget
    {
        private string _tv;
        public void Display()
        {
            Console.WriteLine("Tv: {0}", _tv);
        }

        public void Update(object s, NewsEventArgs e)
        {
            _tv = e.Tv;
            Display();
        }
    }
}
