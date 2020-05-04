using System;
using System.Linq;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Repository.Interfaces;

namespace DVDRentalAPI.Repository.Repository
{
    public class WriterRepository : GenericRepository<Writer>, IWriterRepository
    {
        private readonly DVDRentalContext _context;

        public WriterRepository(DVDRentalContext context) : base(context)
        {
            _context = context;
        }

        public Writer CheckIfExists(string Name)
        {
            var actor = _context.Writer.Where(i => i.Name == Name).FirstOrDefault();
            return actor;
        }
    }
}
