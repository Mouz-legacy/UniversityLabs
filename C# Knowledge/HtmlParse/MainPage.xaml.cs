using System;
using System.Collections.ObjectModel;
using TestParse.Core;
using TestParse.Core.DevBy;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace TestParse
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ParserWorker<string[]> parser;
        ObservableCollection<string> info = new ObservableCollection<string>();

        public MainPage()
        {
            this.InitializeComponent();
            parser = new ParserWorker<string[]>(new DevbyParser(), new DevbySettings());
            parser.OnCompleted += ParserOnCompleted;
            parser.OnNewData += ParserOnNewData;
            listData.ItemsSource = info;
        }

        private void ParserOnNewData(object arg1, string[] arg2)
        {
            foreach (var str in arg2)
                info.Add(str);
        }

        private async void ParserOnCompleted(object obj)
        {
            var message = new MessageDialog("All works done!");
            await message.ShowAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            parser.Settings = new DevbySettings();
            parser.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            parser.Abort();
        }
    }
}
