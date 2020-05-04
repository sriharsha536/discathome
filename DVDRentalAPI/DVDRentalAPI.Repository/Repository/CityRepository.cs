using System;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Repository.Interfaces;

namespace DVDRentalAPI.Repository.Repository
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        private readonly DVDRentalContext _context;

        public CityRepository(DVDRentalContext context) : base(context)
        {
            _context = context;
        }
    }
}
