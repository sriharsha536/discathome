using System;
using System.Linq;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Repository.Interfaces;

namespace DVDRentalAPI.Repository.Repository
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly DVDRentalContext _context;

        public MovieRepository(DVDRentalContext context): base(context)
        {
            _context = context;
        }

        public Movie CheckIfExists(string imdbId)
        {
            var movie = _context.Movie.Where(i => i.ImdbId == imdbId).FirstOrDefault();
            return movie;
        }
    }
}
