using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YahooFantasyFootball.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using YahooAPI;
using YahooSports.Api.Sports.Models;
using YahooFantasyFootball.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace YahooFantasyFootball.Controllers
{
    public class HomeController : Controller
    {

        private IYahooApiService _yahooApiService;

        public HomeController(ISportsProviderService sportsProviderService, IYahooApiService yahooApiService)
        {
            _yahooApiService = yahooApiService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Title = "To Do List";
            //ViewData["Title"] = "To Do List";
            //TempData["Title"] = "To Do List"; //Persists between redirects (session variable)

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

        [HttpPost]
        public IActionResult WeatherTool(WeatherToolVM weatherToolVM)
        {
            if(ModelState.IsValid)
            {
                var test = weatherToolVM;
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
