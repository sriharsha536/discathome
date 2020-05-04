using System;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Repository.Interfaces;

namespace DVDRentalAPI.Repository.Repository
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        private readonly DVDRentalContext _context;

        public GenreRepository(DVDRentalContext context) : base(context)
        {
            _context = context;
        }
    }
}
