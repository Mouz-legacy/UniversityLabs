using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Windows.ApplicationModel.Core;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Lab1
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region --Fields--

        private SimpleCollection<Monitors> Monitorses = new SimpleCollection<Monitors>();
        private List<string> PhotosDirectory = new List<string>();
        private List<(string, string, string)> Description = new List<(string, string, string)>();
        private readonly string _pathDirect = @"test.txt";
        private SimpleCollection<Monitors> Samsung = new SimpleCollection<Monitors>();
        private SimpleCollection<Monitors> AOC = new SimpleCollection<Monitors>();
        private SimpleCollection<Monitors> LG = new SimpleCollection<Monitors>();
        private SimpleCollection<Monitors> DELL = new SimpleCollection<Monitors>();
        private SimpleCollection<Monitors> BenQ = new SimpleCollection<Monitors>();

        #endregion


        public MainPage()
        {
            InitializeComponent();
            LoadPhotosAndDescription();
        }

        private async void Contact_Click(object sender, RoutedEventArgs e)
        {
            var mesBox = new MessageDialog("If you have any problems with this application, please contact the developer at this address: streletswork@gmail.com");
            await mesBox.ShowAsync();
        }

        private async void OpenBtn_OnClick(object sender, RoutedEventArgs e)
        {
            (string, string, string) interStr = (" ", " ", " ");
            char[] buffer = new char[150];
            var picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.List;
            picker.FileTypeFilter.Add(".txt");
            var file = await picker.PickSingleFileAsync();

            if (file != null)
            {
                string description = await FileIO.ReadTextAsync(file);
                for (int i = 0, j = 0, itemCounter = 0; i < description.Length; i++, j++)
                {
                    if (description[i] == ';')
                    {
                        itemCounter++;
                        switch (itemCounter)
                        {
                            case 1:
                                interStr.Item1 = Converter(buffer);
                                break;
                            case 2:
                                interStr.Item2 = Converter(buffer);
                                break;
                            case 3:
                                {
                                    interStr.Item3 = Converter(buffer);
                                    Description.Add(interStr);
                                    interStr.Item1 = null;
                                    interStr.Item2 = null;
                                    interStr.Item3 = null;
                                    itemCounter = 0;
                                    break;
                                }
                        }

                        Array.Clear(buffer, 0, buffer.Length);
                        j = -1;
                    }
                    else
                    {
                        buffer[j] = description[i];
                    }
                }
                int iterator = 0;


                AOC = (SimpleCollection<Monitors>)Monitorses.Select(item => item.Company == "AOC");
                BenQ = (SimpleCollection<Monitors>)Monitorses.Select(item => item.Company == "Benq");
                DELL = (SimpleCollection<Monitors>)Monitorses.Select(item => item.Company == "DELL");
                LG = (SimpleCollection<Monitors>)Monitorses.Select(item => item.Company == "LG");
                Samsung = (SimpleCollection<Monitors>)Monitorses.Select(item => item.Company == "Samsung");
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
        }

        private async void LoadPhotosAndDescription()
        {
            PhotosDirectory = new List<string>();
            char[] buffer = new char[100];
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile filePathes = await storageFolder.GetFileAsync(_pathDirect);

            string pathes = await FileIO.ReadTextAsync(filePathes);
            for(int i = 0, j = 0; i < pathes.Length; i++, j++)
            {
                if (pathes[i] == ';')
                {
                    string charConvert = Converter(buffer);
                    PhotosDirectory.Add(charConvert);
                    Array.Clear(buffer, 0, buffer.Length);
                    j = -1;
                    i += 2;
                    continue;
                }
                buffer[j] = pathes[i];
            }//Get directories

            foreach (var path in PhotosDirectory)
            {
                Monitorses.Add(new Monitors(null, null, 0, null, path));
            }

            ImageGridView.ItemsSource = Monitorses;
            ImageGridView.Visibility = Visibility.Collapsed;

        }

        private string Converter(char[] buffer)
        {
            string convertedBuffer;
            int counter = 0;
            for (int i = 0; i < buffer.Length; i++)
                if (buffer[i] != '\0')
                    counter++;
                else
                    break;
            char[] bufferNew = new char[counter];
            for (int i = 0; i < counter; i++)
                if(buffer[i] != '\n' || buffer[i] != '\r' || buffer[i] != '\\' || buffer[i] != 'n' || buffer[i] != 'r')
                    bufferNew[i] = buffer[i];
            convertedBuffer = new string(bufferNew);

            return convertedBuffer;
        }

        private void ImageGridView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            Image image = sender as Image;
            image.Visibility = Visibility.Collapsed;
        }

        private void Change(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
         
        }

        private async void SaveAsBtn_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await storageFolder.CreateFileAsync("SaveInfo.txt", CreationCollisionOption.OpenIfExists);
            List<string> ForWrite = new List<string>();
            foreach (var monitor in Monitorses)
            {
                ForWrite.Add(JsonConvert.SerializeObject(monitor));
            }
            
            await FileIO.WriteLinesAsync(file, ForWrite);

        }

        private async void SaveArchive_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            object locker = new object();
            try
            {
                lock(locker)
                {
                    ZipFile.CreateFromDirectory(storageFolder.Path, $@"{storageFolder.Path}\test.zip");
                }
            }
            catch(Exception)
            {
                
            }
            finally
            {
                var dialog2 = new MessageDialog("I think, files where added to archive");
                await dialog2.ShowAsync();
            }

        }

        private async void ShowDirectory_Click(object sender, RoutedEventArgs e)
        {
            bool direct = File.Exists(@"C:\Users\Алексей\AppData\Local\Packages\ad74c6bf-0059-43c9-845e-4bce85fa9555_3z4b6ca6htxw4\LocalState\Description.txt");
            switch(direct)
            {
                case true: 
                    var mesBox = new MessageDialog("File 'Description' exist, everything is OK ");
                    await mesBox.ShowAsync();
                    break;
                case false:
                    var mesBox2 = new MessageDialog("Someone delete our 'Description' ((((");
                    await mesBox2.ShowAsync();
                    break;
            }

        }

        private void Samsung_Click(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            ImageGridView.ItemsSource = Samsung;
        }

        private void LG_Click(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            ImageGridView.ItemsSource = LG;
        }

        private void BenQ_Click(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            ImageGridView.ItemsSource = BenQ;
        }

        private void DELL_Click(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            ImageGridView.ItemsSource = DELL;
        }

        private void AOC_Click(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            ImageGridView.ItemsSource = AOC;
        }

        private void Company_Click(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            ImageGridView.Visibility = Visibility.Visible;
            ImageGridView.ItemsSource = Monitorses;
        }

        private async void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await storageFolder.CreateFileAsync("SaveInfo2.txt", CreationCollisionOption.OpenIfExists);

            byte[] buffer = new byte[50*Monitorses.Count];
            int j = 0;
            foreach(var monitor in Monitorses)
            {
                for(int i = 0;i < monitor.Company.Length; i++, j++)
                {
                    buffer[j] = (byte)monitor.Company[i];
                }
                buffer[j + 1] = (byte)' ';
                j += 2;
            }
            await FileIO.WriteBytesAsync(file, buffer);

        }

    }
}
