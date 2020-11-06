using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsService
{
    public partial class Service1 : ServiceBase
    {
        ServiceProvider service;

        public Service1()
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            service = new ServiceProvider();
            Thread loggerThread = new Thread(new ThreadStart(service.Start));
            loggerThread.Start();
        }

        protected override void OnStop()
        {
            service.Stop();
            Thread.Sleep(1000);
        }
    }

    class ServiceProvider
    {
        #region --Fields--

        private FileSystemWatcher watcher;
        private object obj = new object();
        private bool enabled = true;
        private static string ftpAdress = @"ftp://192.168.100.5:21/";

        #endregion

        #region --Methods--

        public ServiceProvider()
        {
            watcher = new FileSystemWatcher(@"F:\WinService\Temp");
            watcher.Deleted += Watcher_Deleted;
            watcher.Created += Watcher_Created;
            watcher.Changed += Watcher_Changed;
            watcher.Renamed += Watcher_Renamed;
        }

        public void Start()
        {
            watcher.EnableRaisingEvents = true;
            while (enabled)
            {
                Thread.Sleep(1000);
            }
        }

        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
            enabled = false;
        }

        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            string fileEvent = "changed to " + e.FullPath;
            string filePath = e.OldFullPath;
            FtpTransformations();
            RecordEntry(fileEvent, filePath);

        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "changed";
            string filePath = e.FullPath;
            FtpTransformations();
            RecordEntry(fileEvent, filePath);
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "created";
            string filePath = e.FullPath;
            FtpTransformations();
            RecordEntry(fileEvent, filePath);
        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "deleted";
            string filePath = e.FullPath;
            FtpTransformations();
            RecordEntry(fileEvent, filePath);
        }

        private void RecordEntry(string fileEvent, string filePath)
        {
            lock(obj)
            {
                using (StreamWriter writer = new StreamWriter(@"F:\WinService\events.txt", true))
                {
                    writer.WriteLine(String.Format("{0} File {1} was {2}",
                        DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), filePath, fileEvent));
                    writer.Flush();
                }
            }
             
        }

        private void FtpTransformations()
        {
            string archPath = $@"F:\WinService\Archive\Data.zip";
            string newarchPath = $@"F:\WinService\ArchiveFromFtp\Data.zip";
            Thread.Sleep(2500);
            try
            {
                if (File.Exists(archPath))
                {
                    File.Delete(archPath);
                }

                if (File.Exists(newarchPath))
                {
                    File.Delete(newarchPath);
                }

                ZipFile.CreateFromDirectory($@"F:\WinService\Temp", archPath, CompressionLevel.Optimal, false, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                RecordEntry(ex.Message, ex.Message);
            }

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create($@"{ftpAdress}\Data.zip");
            request.Method = WebRequestMethods.Ftp.UploadFile;
            FileStream fs = new FileStream(archPath, FileMode.Open);
            byte[] fileContents = new byte[fs.Length];
            fs.Read(fileContents, 0, fileContents.Length);
            fs.Close();
            request.ContentLength = fileContents.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            request = (FtpWebRequest)WebRequest.Create($@"{ftpAdress}\Data.zip");
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            FileStream fstream = new FileStream(newarchPath, FileMode.Create);
            byte[] buffer = new byte[64];
            int size;

            while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                fstream.Write(buffer, 0, size);

            }
            fstream.Close();
            response.Close();

            ZipFile.ExtractToDirectory(newarchPath, $@"F:\WinService\Destination", Encoding.UTF8);
        }

        #endregion
    }
}
