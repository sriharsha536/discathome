using System;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Repository.Interfaces;

namespace DVDRentalAPI.Repository.Repository
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly DVDRentalContext _context;
        public RoleRepository(DVDRentalContext context): base(context)
        {
            _context = context;
        }
    }
}
