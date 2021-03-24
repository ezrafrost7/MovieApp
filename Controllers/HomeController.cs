using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieApp.Models;
using MovieApp.Models.ViewModels;
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

        //setting teh DB objects in the controller
        private IMoviesRepository _repository;
        private MoviesContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger, IMoviesRepository repository, MoviesContext context)
        {
            //settting the private objects, settings, db stuff
            _logger = logger;
            _repository = repository;
            _context = context;
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
        public IActionResult MovieEntry(MovieEntry movieEntry)
        {
            if (movieEntry.Title == "Independence Day")
            {
                ModelState.AddModelError(movieEntry.Title, "Independence Day is not a good movie");
                return View(movieEntry);
            }

            if (ModelState.IsValid)
            {
                _context.Movies.Add(movieEntry);
                _context.SaveChanges();

                return View("ViewEntries", _context.Movies);

                //this is for temp storage, before adding the DB
                ////adding the submitted form to the local storage for display on another page
                //TempStorage.AddEntry(movieEntry);
                ////once the fomr is successfully sumbitted, it redirects to the view of all submitted movies
                //Response.Redirect("ViewEntries");
            } else {
                return View(movieEntry);
                    };
            
        }

        //removing an entry????
        [HttpPost]
        public IActionResult RemoveEntry(long moviesId)
        {
            _context.Movies.Remove(_context.Movies.First(m => m.MoviesId == moviesId));

            _context.SaveChanges();

            return View("ViewEntries", _context.Movies);
        }

        //edit a movie entry
        [HttpPost]
        public IActionResult EditView(long moviesId)
        {
            MovieEntry movie = _context.Movies.Where(m => m.MoviesId == moviesId).First();
            movie.Edited = true;

            return View("EditEntry", movie);
        }
        [HttpPost]
        public IActionResult EditEntry(MovieEntry movie)
        {
            _context.Update(movie);

            _context.SaveChanges();

            return View("ViewEntries", _context.Movies);
        }

        //movie entries view
        public IActionResult ViewEntries()
        {
            return View(_context.Movies);
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
