using System;
using System.Linq;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Repository.Interfaces;

namespace DVDRentalAPI.Repository.Repository
{
    public class ProducerRepository : GenericRepository<Producer>, IProducerRepository
    {
        private readonly DVDRentalContext _context;

        public ProducerRepository(DVDRentalContext context) : base(context)
        {
            _context = context;
        }

        public Producer CheckIfExists(string Name)
        {
            var actor = _context.Producer.Where(i => i.FirmName == Name).FirstOrDefault();
            return actor;
        }
    }
}
