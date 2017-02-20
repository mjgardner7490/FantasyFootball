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
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Title = "To Do List";
            //ViewData["Title"] = "To Do List";
            //TempData["Title"] = "To Do List"; //Persists between redirects (session variable)

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
            var test = gameWeekVM;
            return View();
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
                new SelectListItem { Value = "4", Text = "Week 4" }
            };
            return View(gameWeekVM);
        }
    }
}
