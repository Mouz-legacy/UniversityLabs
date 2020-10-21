using Observer.News;
using System;
using System.Collections.Generic;
using System.Text;

namespace Observer.Widgets
{
    class TwitterWidget : IWidget
    {
        private string _twitter;
        public void Display()
        {
            Console.WriteLine("Tv: {0}", _twitter);
        }

        public void Update(object s, NewsEventArgs e)
        {
            _twitter = e.Twitter;
            Display();
        }
    }
}
