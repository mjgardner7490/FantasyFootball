using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
    }
}
