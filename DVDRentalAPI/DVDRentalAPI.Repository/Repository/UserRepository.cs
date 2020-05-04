using System;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Repository.Interfaces;

namespace DVDRentalAPI.Repository.Repository
{
    public class UserRepository: GenericRepository<Users>, IUserRepository
    {
        private readonly DVDRentalContext _context;

        public UserRepository(DVDRentalContext context) : base(context)
        {
            _context = context;
        }
    }
}
