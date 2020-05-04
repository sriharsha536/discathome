using System;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Repository.Interfaces;

namespace DVDRentalAPI.Repository.Repository
{
    public class MovieActorRepository : GenericRepository<MovieActor>, IMovieActorRepository
    {
        private readonly DVDRentalContext _context;

        public MovieActorRepository(DVDRentalContext context) : base(context)
        {
            _context = context;
        }
    }
}
