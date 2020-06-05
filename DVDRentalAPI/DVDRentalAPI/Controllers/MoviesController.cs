using DVDRentalAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DVDRentalAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : BaseController
    {
        private readonly IMovieService _movieService;
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(IMovieService movieService, ILogger<MoviesController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _movieService = movieService;
            _logger = logger;
        }

        [HttpGet("{matchingFilter}")]
        public IActionResult SearchMovies(string matchingFilter)
        {
            _logger.LogInformation($"Action method {nameof(SearchMovies)} has been called");

            var movies = _movieService.SearchMovies(matchingFilter);

            _logger.LogInformation($"Returning MovieSearchModel: {movies}");

            return Ok(movies);
        }

        [HttpGet("gettopthumbs")]
        public IActionResult GetTopThumbsByGenre()
        {
            _logger.LogInformation($"Action method {nameof(GetTopThumbsByGenre)} has been called");

            var movies = _movieService.GetTopThumbsByGenre();

            _logger.LogInformation($"Returning List<MovieThumbModel>: {movies}");

            return Ok(movies);
        }

        [AllowAnonymous]
        [HttpGet("getmoviedetail/{movieId}")]
        public IActionResult GetMovieDetail(int movieId)
        {
            _logger.LogInformation($"Fetching movie details for {GetUserName()}: {movieId}");

            var movieDetailModel = _movieService.GetMovieDetail(movieId);

            _logger.LogInformation($"Returning movieDetailModel: {movieDetailModel}");

            return Ok(movieDetailModel);
        }
    }
}
