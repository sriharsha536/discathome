using System.Linq;
using DVDRentalAPI.Core.Dto;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DVDRentalAPI.Repository.Repository
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly DVDRentalContext _context;

        public MovieRepository(DVDRentalContext context) : base(context)
        {
            _context = context;
        }

        public Movie CheckIfExists(string imdbId)
        {
            var movie = _context.Movie.Where(i => i.ImdbId == imdbId).FirstOrDefault();
            return movie;
        }

        public MovieDetailDto GetMovieDetail(int movieId)
        {
            var movieDetail = new MovieDetailDto();
            var movie = (from m in _context.Movie
                         join d in _context.Director on m.DirectorId equals d.DirectorId
                         join w in _context.Writer on m.WriterId equals w.WriterId
                         join p in _context.Producer on m.ProductionId equals p.ProductionId
                         where m.MovieId == movieId
                         select new
                         {
                             MovieId = m.MovieId,
                             ImdbId = m.ImdbId,
                             MovieName = m.MovieName,
                             DirectorName = d.Name,
                             WriterName = w.Name,
                             ProducerName = p.FirmName,
                             Plot = m.Plot,
                             Poster = m.Poster,
                             ReleaseYear = m.Year,
                             ImdbVotes = m.ImdbVotes,
                             ImdbRating = m.ImdbRating
                         }).FirstOrDefault();

            var genres = (from m in _context.Movie
                          join g in _context.Genre on m.MovieId equals g.MovieId
                          where m.MovieId == movieId
                          select g.GenreName).ToList();

            var cast = (from m in _context.Movie
                        join ma in _context.MovieActor on m.MovieId equals ma.MovieId
                        join a in _context.Actor on ma.ActorId equals a.ActorId
                        where m.MovieId == movieId
                        select a.Name).ToList();

            var languages = (from m in _context.Movie
                             join l in _context.Language on m.MovieId equals l.MovieId
                             where m.MovieId == movieId
                             select l.LanguageName).ToList();

            var media = (from m in _context.Movie
                         join g in _context.Media on m.MovieId equals g.MovieId
                         where m.MovieId == movieId
                         select g.MediaUrl).ToList();

            if (movie != null)
            {
                movieDetail.MovieId = movie.MovieId;
                movieDetail.ImdbId = movie.ImdbId;
                movieDetail.MovieName = movie.MovieName;
                movieDetail.DirectorName = movie.DirectorName;
                movieDetail.WriterName = movie.WriterName;
                movieDetail.ProducerName = movie.ProducerName;
                movieDetail.Plot = movie.Plot;
                movieDetail.Poster = movie.Poster;
                movieDetail.ReleaseYear = movie.ReleaseYear;
                movieDetail.ImdbVotes = movie.ImdbVotes;
                movieDetail.ImdbRating = movie.ImdbRating;
                movieDetail.Genres = genres;
                movieDetail.Cast = cast;
                movieDetail.Languages = languages;
                movieDetail.MediaUrls = media;
            }

            return movieDetail;
        }
    }
}
