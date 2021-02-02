using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //this is the action to display the home page/ Index view
        public IActionResult Index()
        {
            return View();
        }

        //view in order to display the page with the podcast website link
        public IActionResult Podcast()
        {
            return View();
        }

        //this action will display the page with a form
        [HttpGet]
        public IActionResult MovieEntry()
        {
            return View();
        }
        //once the form is submit, this action will occur
        [HttpPost]
        public IActionResult MovieEntry( MovieEntry movieEntry)
        {
            if (ModelState.IsValid)
            {
                Response.Redirect("Index");
            }

            return View(movieEntry);
            
        }

        //these are built-in pages, optional views that might not be used
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
