using System;
using System.Collections.Generic;
using System.Text;
using Observer.Widgets;

namespace Observer.News
{
    public class NewsEventArgs
    {
        public string Twitter { get; private set; }
        public string Lenta { get; private set; }
        public string Tv { get; private set; }

        public NewsEventArgs(string twitter, string lenta, string tv)
        {
            Twitter = twitter;
            Lenta = lenta;
            Tv = tv;
        }
    }

    public delegate void NewsChangedEventHandler(object s, NewsEventArgs e);
    public class NewsAggregator
    {
        private static Random _random;

        public NewsAggregator()
        {
            _random = new Random();
        }

        public event NewsChangedEventHandler NewsChanged;

        public string GetTwitterNews()
        {
            var news = new List<string>
            {
                "News number1",
                "News number2",
                "News number3"
            };
            return news[_random.Next(3)];
        }

        public string GetLentaNews()
        {
            var news = new List<string>
            {
                "News number1",
                "News number2",
                "News number3"
            };
            return news[_random.Next(3)];
        }
        public string GetTvNews()
        {
            var news = new List<string>
            {
                "News number1",
                "News number2",
                "News number3"
            };
            return news[_random.Next(3)];
        }

        public void NewNewsAvaliable()
        {
            string twitter = GetTwitterNews();
            string lenta = GetLentaNews();
            string tv = GetTvNews();
            
            if(NewsChanged != null)
                NewsChanged.Invoke(this, new NewsEventArgs(twitter, lenta, tv));
        }

    }
}
