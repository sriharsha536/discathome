using System;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Repository.Interfaces;

namespace DVDRentalAPI.Repository.Repository
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        private readonly DVDRentalContext _context;

        public AddressRepository(DVDRentalContext context): base(context)
        {
            _context = context;
        }
    }
}
