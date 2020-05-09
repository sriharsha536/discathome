using System;
using DVDRentalAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("{matchingFilter}")]
        public IActionResult SearchMovies(string matchingFilter)
        {
            var movies = _movieService.SearchMovies(matchingFilter);
            return Ok(movies);
        }
    }
}
