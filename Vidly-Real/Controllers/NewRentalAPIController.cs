using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly_Real.Data_Transfer_Objects;
using Vidly_Real.Models;

namespace Vidly_Real.Controllers
{
    public class NewRentalAPIController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalAPIController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDTO newrentaldto)
        {
            if (newrentaldto.MoviesIds.Count == 0) return BadRequest("No movie ids has been given");
            var customer = _context.Customers.SingleOrDefault( c => c.Id == newrentaldto.CustomerId);
            if (customer == null) { return BadRequest("No customer was found"); }
            var movies = _context.Movies.Where(m => newrentaldto.MoviesIds.Contains(m.Id)).ToList() ;
            if (movies.Count != newrentaldto.MoviesIds.Count) return BadRequest("One or more movies not loaded");

            foreach(var movie in movies)
            {
                if (movie.NumberAvailable == 0) return BadRequest("Movie is not available");
                movie.NumberAvailable--;
                Rental rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now,
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();

            return Ok();
        }
    }
}
