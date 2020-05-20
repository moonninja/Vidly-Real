using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly_Real.Models
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }
        public ActionResult Details(int? Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            return View(movie);
        }
        public ActionResult Edit(int? Id)
        {
            Movie movie = new Movie();
            if (Id == 0) 
            {
                movie = new Movie()
                {
                    Id = 0,
                    DateAdded = new DateTime(2015, 05, 05)
            };
            }
            else
            {
                movie = _context.Movies.SingleOrDefault(m => m.Id == Id);

            }
            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            Movie u_movie = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
            if (u_movie == null)
            {
                return HttpNotFound();
            }
            u_movie.Name = movie.Name;
            u_movie.ReleaseDate = movie.ReleaseDate;
            u_movie.NumberInStock = movie.NumberInStock;
            u_movie.Genre = movie.Genre;
            _context.SaveChanges();
            return RedirectToAction("Details","Movies",new { u_movie.Id});
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Movie movie)
        {
            if (movie == null) return HttpNotFound();
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}


//public string Name { get; set; }
//public string Genre { get; set; }
//public DateTime ReleaseDate { get; set; }
//public DateTime DateAdded { get; set; }
//public int NumberInStock { get; set; }