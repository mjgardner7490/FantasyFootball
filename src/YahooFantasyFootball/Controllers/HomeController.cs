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
        public IActionResult WeatherTool(GameWeekVM gameWeekVM)
        {
            if(ModelState.IsValid)
            {
                var test = gameWeekVM;
            }
            return WeatherTool();
        }

        [HttpGet]
        public IActionResult WeatherTool()
        {
            ViewBag.Title = "Weather Tool";
            GameWeekVM gameWeekVM = new GameWeekVM();
            gameWeekVM.GameWeekList = new[]
            {
                new SelectListItem { Value = "1", Text = "Week 1" },
                new SelectListItem { Value = "2", Text = "Week 2" },
                new SelectListItem { Value = "3", Text = "Week 3" },
                new SelectListItem { Value = "4", Text = "Week 4" },
                new SelectListItem { Value = "5", Text = "Week 5" },
                new SelectListItem { Value = "6", Text = "Week 6" },
                new SelectListItem { Value = "7", Text = "Week 7" },
                new SelectListItem { Value = "8", Text = "Week 8" },
                new SelectListItem { Value = "9", Text = "Week 9" },
                new SelectListItem { Value = "10", Text = "Week 10" },
                new SelectListItem { Value = "11", Text = "Week 11" },
                new SelectListItem { Value = "12", Text = "Week 12" },
                new SelectListItem { Value = "13", Text = "Week 13" },
                new SelectListItem { Value = "14", Text = "Week 14" },
                new SelectListItem { Value = "15", Text = "Week 15" },
                new SelectListItem { Value = "16", Text = "Week 16" }
            };
            return View(gameWeekVM);
        }
    }
}
