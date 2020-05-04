using System;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Repository.Interfaces;

namespace DVDRentalAPI.Repository.Repository
{
    public class RentalHistoryRepository : GenericRepository<RentalHistory>, IRentalHistoryRepository
    {
        private readonly DVDRentalContext _context;

        public RentalHistoryRepository(DVDRentalContext context) : base(context)
        {
            _context = context;
        }
    }
}
