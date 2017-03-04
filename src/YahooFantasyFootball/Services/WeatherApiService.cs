using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using YahooFantasyFootball.Models;

namespace YahooFantasyFootball.Services
{
    public class WeatherApiService : IWeatherApiService
    {
        private static string apiKey = "18a390c41b21328841ff6471db7bef48";


        public RootObject GetCityWeather(string city, string country = "us")
        {
            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0},{1}&units=imperial&APPID={2}", city, country, apiKey);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            RootObject cityWeather = new RootObject();
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                cityWeather = JsonConvert.DeserializeObject<RootObject>(json);
            }

            return cityWeather;
        }
    }
}

