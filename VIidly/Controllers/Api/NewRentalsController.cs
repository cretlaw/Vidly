using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VIidly.Dtos;
using VIidly.Models;

namespace VIidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public  IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var movieIdsCount = newRental.MovieIds.Count;

            //you pass a rental with no movies
            if (movieIdsCount == 0)
                return BadRequest("No Movie Id was given");

            //Getting the customer by ID
            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);

            //Making it robust if its null it means that someone tried to pass an invalid id as in the post request
            if (customer == null)
                return BadRequest("Invalid Customer Id");

            //Loading the movies Id of the customer rental order
            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            if (movieIdsCount != movies.Count)
                return BadRequest("One or more of Movie Id's are not valid");

            //Creating the records of movies rented by the customer in our DB table Rentals
            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie Is Not Available");

                //Subtracting one from NumberAvailable for each movie rented
                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now

                };

                _context.Rentals.Add(rental);
            }

            //save the changes to DB to make it persistent
            _context.SaveChanges();

            return Ok();

            throw new NotImplementedException();
        }
    }
}
