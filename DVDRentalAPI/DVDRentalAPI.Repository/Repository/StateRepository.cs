using System;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Repository.Interfaces;

namespace DVDRentalAPI.Repository.Repository
{
    public class StateRepository : GenericRepository<State>, IStateRepository
    {
        private readonly DVDRentalContext _context;

        public StateRepository(DVDRentalContext context) : base(context)
        {
            _context = context;
        }
    }
}
