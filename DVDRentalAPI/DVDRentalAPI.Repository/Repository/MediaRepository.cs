using System;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Repository.Interfaces;

namespace DVDRentalAPI.Repository.Repository
{
    public class MediaRepository : GenericRepository<Media>, IMediaRepository
    {
        private readonly DVDRentalContext _context;

        public MediaRepository(DVDRentalContext context) : base(context)
        {
            _context = context;
        }
    }
}
