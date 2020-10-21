using System;
using Observer.News;
using Observer.Widgets;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var newsAggregator = new NewsAggregator();
            var twitterWidget = new TwitterWidget();
            var lentaWidget = new LentaWidget();
            var tvWidget = new TvWidget();

            newsAggregator.NewsChanged += (twitterWidget.Update);
            newsAggregator.NewsChanged += (lentaWidget.Update);
            newsAggregator.NewsChanged += (tvWidget.Update);
            newsAggregator.NewNewsAvaliable();
        } 
    }
}
