using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using DbEssense;
using Microsoft.SqlServer.Server;
using ServiceLayer;

namespace DbDataManager
{
    public partial class Service1 : ServiceBase
    {
        public List<DataAccessLayer> Essenses;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Essenses = new List<DataAccessLayer>();
            GetData();
            XmlParse();
            PushToFtp("ftp://192.168.100.5:21/", $@"F:\WinService\Archive\Data.zip");
        }

        protected override void OnStop()
        {

        }

        private void GetData()
        {
            using (MuzShopEntities db = new MuzShopEntities())
            {
                List<MuzShopEssence> Members = new List<MuzShopEssence>();
                MuzShopEssence dataTransporter = new MuzShopEssence();
                bool validator;
                int i = 0;
                foreach (var muzShopMember in db.Shops)
                {
                    dataTransporter.Shop = muzShopMember;
                    Members.Add(dataTransporter);
                }

                foreach (var muzDeliveryMember in db.Deliveries)
                {
                    dataTransporter.Delivery = muzDeliveryMember;
                    if (dataTransporter.Delivery.Id == Members[i].Shop.DeliveryManId)
                    {
                        Members[i].Delivery = dataTransporter.Delivery;
                        i++;
                    }
                }

                i = 0;
                foreach (var muzEmployeEmploye in db.Employes)
                {
                    dataTransporter.Employe = muzEmployeEmploye;
                    if (dataTransporter.Employe.Id == Members[i].Shop.EmployeId)
                    {
                        Members[i].Employe = dataTransporter.Employe;
                        i++;
                    }
                }

                i = 0;
                foreach (var dbGroup in db.Groups)
                {
                    dataTransporter.Group = dbGroup;
                    if (dataTransporter.Group.Id == Members[i].Shop.GroupId)
                    {
                        Members[i].Group = dataTransporter.Group;
                        i++;
                    }
                }

                i = 0;
                foreach (var locationE in db.Locations)
                {
                    dataTransporter.Location = locationE;
                    if (dataTransporter.Location.Id == Members[i].Shop.LocationId)
                    {
                        Members[i].Location = dataTransporter.Location;
                        i++;
                    }
                }

                i = 0;
                foreach (var member in Members)
                {
                    validator = false;
                    Essenses[0].ValidateModel(member, out validator);
                    if (validator)
                    {
                        DataAccessLayer essense = new DataAccessLayer();
                        essense.Essence = member;
                        Essenses.Add(essense);
                    }
                    else
                    {
                        WriteErrors($"Can't Parse number{i}");
                    }

                    i++;
                }
            }
        }

        private void XmlParse()
        {
            List<string> data = new List<string>(Essenses.Capacity*3);
            int i = 0, j = 0;
            foreach (var member in Essenses)
            {
                data[j++] = Essenses[i].Essence.Delivery.MerchType;
                data[j++] = Essenses[i].Essence.Delivery.Id.ToString();
                data[j++] = Essenses[i].Essence.Employe.Name;
                data[j++] = Essenses[i].Essence.Employe.Id.ToString();
                data[j++] = Essenses[i].Essence.Employe.Wage.ToString();
                data[j++] = Essenses[i].Essence.Shop.Name;
                data[j++] = Essenses[i].Essence.Location.City;
                i++;
            }
            MyXmlSerializer serializer = new MyXmlSerializer();
            serializer.Serializer("dbData.xml", data);
        }

        private void WriteErrors(string fileEvent)
        {
            lock (new object())
            {
                using (StreamWriter writer = new StreamWriter("F:\\Temp\\templog.txt", true))
                {
                    writer.WriteLine(String.Format("{0} файл {1} был {2}",
                        DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), fileEvent));
                    writer.Flush();
                }
            }
        }

        private void PushToFtp(string adress, string archPath)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create($@"{adress}\Data.zip");
            request.Method = WebRequestMethods.Ftp.UploadFile;
            FileStream fs = new FileStream(archPath, FileMode.Open);
            byte[] fileContents = new byte[fs.Length];
            fs.Read(fileContents, 0, fileContents.Length);
            fs.Close();
            request.ContentLength = fileContents.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();
        }
    }
}
