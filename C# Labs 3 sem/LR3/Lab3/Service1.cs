using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FileManager;

namespace Lab3
{
    public partial class Service1 : ServiceBase
    {
        Logger logger;
        public Service1()
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            logger = new Logger();
            Thread loggerThread = new Thread(new ThreadStart(logger.Start));
            loggerThread.Start();
        }

        protected override void OnStop()
        {
            logger.Stop();
            Thread.Sleep(1000);
        }
    }

    class Logger
    {
        FileSystemWatcher watcher;
        object obj = new object();
        bool enabled = true;
        private ConfigurationProvider<ConfigInfo> provider;
        private ConfigInfo _info;
        ASCIIEncoding coder;

        public Logger()
        {
            provider = new ConfigurationProvider<ConfigInfo>(".xml");
            _info = provider.GetConfig();
            watcher = new FileSystemWatcher(_info.SourceDirectory);
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
            string fileEvent = "Renamed to" + e.FullPath;
            string filePath = e.OldFullPath;
            BaseTransformations();
            RecordEntry(fileEvent, filePath);
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "Was Changed";
            string filePath = e.FullPath;
            BaseTransformations();
            RecordEntry(fileEvent, filePath);
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "Was Created";
            string filePath = e.FullPath;
            BaseTransformations();
            RecordEntry(fileEvent, filePath);
        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "Was Deleted";
            string filePath = e.FullPath;
            BaseTransformations();
            RecordEntry(fileEvent, filePath);
        }

        private void RecordEntry(string fileEvent, string filePath)
        {
            lock (obj)
            {
                using (StreamWriter writer = new StreamWriter("D:\\WinService\\templog.txt", true))
                {
                    writer.WriteLine(String.Format("{0} File {1} was {2}",
                        DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), filePath, fileEvent));
                    writer.Flush();
                }
            }
        }

        private void BaseTransformations()
        {
            if (_info.Encryption)
            {
                coder = new ASCIIEncoding();
                Thread.Sleep(1000);
            }

            StartArchiving();
            ZipFile.ExtractToDirectory(_info.DestinationDirectory, $@"F:\WinService\Destination", coder);
        }

        private void StartArchiving()
        {
            try
            {
                if (File.Exists(_info.Archiving))
                {
                    File.Delete(_info.Archiving);
                }

                ZipFile.CreateFromDirectory($@"F:\WinService\Temp", _info.Archiving, CompressionLevel.Optimal, false, coder);
            }
            catch (Exception ex)
            {
                RecordEntry(ex.Message, ex.Message);
            }
        }
    }
}
