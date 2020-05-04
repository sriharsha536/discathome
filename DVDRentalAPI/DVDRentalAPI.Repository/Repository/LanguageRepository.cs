using System;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Repository.Interfaces;

namespace DVDRentalAPI.Repository.Repository
{
    public class LanguageRepository : GenericRepository<Language>, ILanguageRepository
    {
        private readonly DVDRentalContext _context;

        public LanguageRepository(DVDRentalContext context) : base(context)
        {
            _context = context;
        }
    }
}
