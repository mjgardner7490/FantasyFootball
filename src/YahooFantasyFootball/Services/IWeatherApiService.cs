using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YahooFantasyFootball.Models;

namespace YahooFantasyFootball.Services
{
    public interface IWeatherApiService
    {
        RootObject GetCityWeather(string city, string country = "us");
    }
}
