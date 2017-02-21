using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YahooFantasyFootball.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace YahooFantasyFootball.Controllers
{
    public class HomeController : Controller
    {
        private static readonly string CONSUMER_KEY = "dj0yJmk9RTdwa0JPdm9yd2N1JmQ9WVdrOVZIVkxRMVJETXpZbWNHbzlNQS0tJnM9Y29uc3VtZXJzZWNyZXQmeD03Yg--";
        private static readonly string CONSUMER_SECRET = "b4501ca7d9301f9173c1b6be607f63896e34a2ff";
        private const string TOKEN_FILE = "token2";

        public HomeController()
        {

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

        public IActionResult Members()
        {
            ViewBag.Title = "League Members";
            return View();
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
