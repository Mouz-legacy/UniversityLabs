using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telegram.Bot;
using TelegramBot;

namespace Telegram
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<TelegramUser> Users;
        private TelegramBotClient _bot;
        private List<string> ListCommands;
        private string readHelper;
        public MainWindow()
        {
            InitializeComponent();
            Users = new ObservableCollection<TelegramUser>();
            ListCommands = new List<string>();
            userList.ItemsSource = Users;
            BotInitialize();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BotInitialize()
        {
            using (StreamReader sr = new StreamReader("Commands.txt"))
            {
                while ((readHelper = sr.ReadLine()) != null)
                    ListCommands.Add(readHelper + '\n');
            }
            testCommands.ItemsSource = ListCommands;
            string token = File.ReadAllText("Token.txt");
            _bot = new TelegramBotClient(token);
            _bot.OnMessage += (object sender, Telegram.Bot.Args.MessageEventArgs e) =>
            {
                string sentMessage = $"{DateTime.Now}: {e.Message.Chat.FirstName} {e.Message.Chat.Id} {e.Message.Text}";
                File.AppendAllText("dataLog.txt", $"{sentMessage}\n");
               // chatWithUser.TextInput += WriteTextInChat();
                this.Dispatcher.Invoke(() =>//Выполняет указанный делегат синхронно в потоке
                {
                    var person = new TelegramUser(e.Message.Chat.FirstName, e.Message.Chat.Id.ToString());
                    if (!Users.Contains(person))
                        Users.Add(person);
                    Users[Users.IndexOf(person)].AddMessage($"{person.Nick}: {e.Message.Text}");
                });
            };
            _bot.StartReceiving();
            btnSendMessage.Click += delegate { SendMsg(); };
            txtBoxMsgContainer.KeyDown += (s, e) => { if (e.Key == Key.Return) { SendMsg(); } };
        }

        private void SendMsg()
        {
            if (userList.SelectedItem as TelegramUser != null)
            {
                var concreteUser = Users[Users.IndexOf(userList.SelectedItem as TelegramUser)];
                string responseMsg = $"Support: {txtBoxMsgContainer.Text}";
                concreteUser.Messages.Add(responseMsg);
                _bot.SendTextMessageAsync(concreteUser.Id, txtBoxMsgContainer.Text);
                string logText = $"{DateTime.Now}: >> {concreteUser.Id} {concreteUser.Nick} {responseMsg}\n";
                File.AppendAllText("dataLog.txt", logText);
                txtBoxMsgContainer.Text = String.Empty;
            }
            else
            {
                txtBoxMsgContainer.Text = String.Empty;
                txtBoxMsgContainer.Text = "ERROR: Choose a member";
            }

        }

        private void OnMouseEnter(object sender, MouseButtonEventArgs e)
        {
            if(txtBoxMsgContainer.Text == "Enter message")
                txtBoxMsgContainer.Text = String.Empty;
        }

    }
}
