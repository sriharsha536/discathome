using System;
using System.Linq;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Repository.Interfaces;

namespace DVDRentalAPI.Repository.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        private readonly DVDRentalContext _context;

        public CountryRepository(DVDRentalContext context) : base(context)
        {
            _context = context;
        }

        public Country CheckIfExists(string Name)
        {
            var actor = _context.Country.Where(i => i.CountryName == Name).FirstOrDefault();
            return actor;
        }
    }
}
