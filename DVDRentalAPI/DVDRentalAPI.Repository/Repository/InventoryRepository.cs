using System;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Repository.Interfaces;

namespace DVDRentalAPI.Repository.Repository
{
    public class InventoryRepository : GenericRepository<Inventory>, IInventoryRepository
    {
        private readonly DVDRentalContext _context;

        public InventoryRepository(DVDRentalContext context) : base(context)
        {
            _context = context;
        }
    }
}
