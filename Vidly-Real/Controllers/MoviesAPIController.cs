using AutoMapper;
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
    public class MoviesAPIController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesAPIController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: api/MoviesAPI
        [HttpGet]
        public IEnumerable<Movie> GetMovie()
        {
            return _context.Movies.ToList();
        }

        // GET: api/MoviesAPI/5
        [HttpGet]
        public IHttpActionResult GetMovie(int Id)
        {
            Movie movie = _context.Movies.SingleOrDefault(c => c.Id == Id);
            if (movie == null) return NotFound();
            return Ok(Mapper.Map<Movie,MovieDTO>(movie));
        }

        // POST: api/MoviesAPI
        [HttpPost]
        public IHttpActionResult PostMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
            _context.Movies.Add(movie);
            try
            {
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            movieDTO.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDTO);
        }

        // PUT: api/MoviesAPI/5
        [HttpPut]
        public void PutMovie(int Id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);
            var MovieInDb = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (MovieInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDTO, MovieInDb);
            MovieInDb.Name = movieDTO.Name;
            MovieInDb.Genre = movieDTO.Genre;
            MovieInDb.ReleaseDate = movieDTO.ReleaseDate;
            MovieInDb.DateAdded = movieDTO.DateAdded;
            MovieInDb.NumberInStock = movieDTO.NumberInStock;
            _context.SaveChanges();
        }

        // DELETE: api/MoviesAPI/5
        [HttpDelete]
        public void DeleteMovie(int Id)
        {
            var MovieInDb = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (MovieInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(MovieInDb);
            _context.SaveChanges();
        }
    }
}
