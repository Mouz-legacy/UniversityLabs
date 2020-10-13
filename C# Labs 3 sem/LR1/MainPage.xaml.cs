using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Networking.Sockets;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using System.IO.Compression;
using Newtonsoft.Json;
using Windows.Storage.AccessCache;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using Windows.UI.Popups;
using C1.C1Zip;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Lab1
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region --Fields--

        private SimpleCollection<Monitors> Monitorses;
        private List<string> PhotosDirectory;
        private List<(string, string, string)> Description;
        private readonly string _pathDirect = @"test.txt";
        private SimpleCollection<Monitors> Samsung;
        private SimpleCollection<Monitors> AOC;
        private SimpleCollection<Monitors> LG;
        private SimpleCollection<Monitors> DELL;
        private SimpleCollection<Monitors> BenQ;

        #endregion


        public MainPage()
        {
            InitializeComponent();
            BasicAssignments();
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
            Description = new List<(string, string, string)>();

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

                foreach (var monitor in Monitorses)
                {
                    monitor.ChangeCompany(Description[iterator].Item1);
                    monitor.ChangeModel(Description[iterator].Item2);
                    monitor.Description = Description[iterator].Item3;
                    if (iterator < 5)
                        AOC.Add(monitor);
                    else if (iterator < 10)
                        BenQ.Add(monitor);
                    else if (iterator < 15)
                        DELL.Add(monitor);
                    else if (iterator < 20)
                        LG.Add(monitor);
                    else if (iterator < 25)
                        Samsung.Add(monitor);
                    iterator++;
                }
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
        }

        private void BasicAssignments()
        {
            Monitorses = new SimpleCollection<Monitors>();
            LoadPhotosAndDescription();
        }

        private async void LoadPhotosAndDescription()
        {
            PhotosDirectory = new List<string>();
            #region --GovnoCode--

            Samsung = new SimpleCollection<Monitors>();
            AOC = new SimpleCollection<Monitors>();
            LG = new SimpleCollection<Monitors>();
            DELL = new SimpleCollection<Monitors>();
            BenQ = new SimpleCollection<Monitors>();

            #endregion
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
