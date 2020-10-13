using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Search;
using Windows.UI.Xaml.Controls;

namespace Lab1
{

    [Serializable]
    public class Monitors : IMonitor, INotifyPropertyChanged
    {
        #region --Fields--

        public event PropertyChangedEventHandler PropertyChanged;
        private string _modelDescription;
        private string _image;

        #endregion

        #region --Properties--

        [Required(ErrorMessage = "Model of the monitor must be entered")]
        public string Model { get; private set; }
        [Required(ErrorMessage = "Company name must be entered")]
        public string Company { get; private set; }
        [Required(ErrorMessage = "Identification number must be entered")]
        public int Id { get; private set; }
        [Required(ErrorMessage ="Description of the model must be entered")]
        public string Description
        {
            get => _modelDescription;
            set
            {
                _modelDescription = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
            }
        }
        [Required]
        public string MonitorImage
        {
            get => _image;
            set
            {
                _image = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MonitorImage)));
            }
        }

        #endregion

        #region --Methods--

        public Monitors(string model = null, string company = null, int id = 0, string description = null, string image = null)
        {
            Model = model;
            Company = company;
            Id = id;
            Description = description;
            MonitorImage = image;
        }

        public void ChangeModel(string newModel)
        {
            Model = newModel;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Model)));
        }

        public void ChangeId(int newId)
        {
            Id = newId;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
        }

        public void ChangeCompany(string newCompany)
        {
            Company = newCompany;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Company)));
        }

        #endregion
    }

    [Serializable]
    public class SimpleCollection<T> : ICollection<T> where T : class
    {
        #region --Fields--

        private ICollection<T> _items;

        #endregion

        #region --Properties--

        public int Count => _items.Count;
        public bool IsReadOnly => false;


        #endregion

        #region --Methods--

        public SimpleCollection()
        {
            _items = new List<T>();
        }

        public SimpleCollection(ICollection<T> collection)
        {
            _items = collection;
        }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Clear()
        {
            _items.Clear();
        }
        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public bool Remove(T item)
        {
            return _items.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        #endregion
    }


}
