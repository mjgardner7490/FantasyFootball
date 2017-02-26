﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using YahooFantasyFootball.ViewModels;
using YahooFantasyFootball.Services;
using YahooFantasyFootball.Models;

namespace YahooFantasyFootball.Controllers
{
    public class HomeController : Controller
    {

        private IYahooApiService _yahooApiService;
        private IWeatherApiService _weatherApiService;

        public HomeController(IYahooApiService yahooApiService, IWeatherApiService weatherApiService)
        {
            _yahooApiService = yahooApiService;
            _weatherApiService = weatherApiService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Title = "Welcome to my Fantasy Football site";
            return View();
        }

        public IActionResult Oops()
        {
            ViewBag.Title = "Oops!";
            return View();
        }

        public IActionResult Standings()
        {
            StandingsVM leagueStandings = _yahooApiService.GetLeagueStandings();
            ViewBag.LeagueName = leagueStandings.leagueName;

            return View(leagueStandings);
        }

        public IActionResult SpankBank()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WeatherTool(WeatherToolVM weatherToolVM)
        {
            if(ModelState.IsValid)
            {
                WeatherToolVM teamRoster = _yahooApiService.GetTeamRoster(weatherToolVM.TeamId, weatherToolVM.GameWeekId);  
                
                foreach(var player in teamRoster.TeamRoster)
                {
                    string city = player.NflTeam.Substring(0, player.NflTeam.IndexOf(" "));
                    RootObject cityWeather = _weatherApiService.GetCityWeather(city);

                    player.gameWeather = new GameWeather()
                    {                          
                        temperature = cityWeather.main.temp,
                        description = cityWeather.weather.First().description,
                        windSpeed = cityWeather.wind.speed
                    };
                }
                   
                return View(teamRoster);
            }

            return WeatherTool();
        }

        [HttpGet]
        public IActionResult WeatherTool()
        {
            ViewBag.Title = "Weather Tool";
            var weatherTool = new WeatherToolVM();
            return View(weatherTool);
        }

        #region Private Helpers




        #endregion
    }
}
