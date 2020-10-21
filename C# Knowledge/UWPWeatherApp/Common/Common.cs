using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPWeatherApp.Common
{
    public class Common
    {
        public static string API_LINK = "http://api.openweathermap.org/data/2.5/weather";
        public static string API_KEY = "6712a43de5dfbbbe695c82a06f9e682d";

        public static string APIRequest(string lat, string lot)
        {
            StringBuilder strBuilder = new StringBuilder(API_LINK);
            strBuilder.AppendFormat("?lat={0}&lon={1}&APPID={2}&units=metric", lat, lot, API_KEY);
            return strBuilder.ToString();
        }

        public static DateTime ConvertUnixTimeToDateTime(double unix)
        {
            DateTime dt = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
            dt = dt.AddSeconds(unix).ToLocalTime();
            return dt;
        }
    }
}
