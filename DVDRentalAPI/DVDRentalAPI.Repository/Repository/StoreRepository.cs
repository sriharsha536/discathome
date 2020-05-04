using System;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Repository.Interfaces;

namespace DVDRentalAPI.Repository.Repository
{
    public class StoreRepository : GenericRepository<Store>, IStoreRepository
    {
        private readonly DVDRentalContext _context;

        public StoreRepository(DVDRentalContext context) : base(context)
        {
            _context = context;
        }
    }
}
