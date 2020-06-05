using System;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Repository.Interfaces;

namespace DVDRentalAPI.Repository.Repository
{
    public class MovieThumbRepository : GenericRepository<GetLatestByGenre>, IMovieThumbRepository
    {
        private readonly DVDRentalContext _context;

        public MovieThumbRepository(DVDRentalContext context) : base(context)
        {
            _context = context;
        }

    }
}
