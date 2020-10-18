 using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram
{
    class TelegramUser : INotifyPropertyChanged, IEquatable<TelegramUser>
    {
        #region - Поля и События -

        private string _nickName;
        private string _id;
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region - Свойства - 

        public ObservableCollection<string> Messages { get; set; }
        public string Nick
        {
            get { return _nickName; }
            set
            {
                _nickName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nick)));
            }
        }

        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }

        #endregion

        #region - Методы -

        public TelegramUser(string nickName, string id)
        {
            _nickName = nickName;
            _id = id;
            Messages = new ObservableCollection<string>();
        }

        public bool Equals(TelegramUser other) => other.Id == this.Id;

        public void AddMessage(string message) => Messages.Add(message);

        #endregion

    }
}
