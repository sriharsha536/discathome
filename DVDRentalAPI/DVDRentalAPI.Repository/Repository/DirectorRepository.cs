using System;
using System.Linq;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Repository.Interfaces;

namespace DVDRentalAPI.Repository.Repository
{
    public class DirectorRepository : GenericRepository<Director>, IDirectorRepository
    {
        private readonly DVDRentalContext _context;

        public DirectorRepository(DVDRentalContext context) : base(context)
        {
            _context = context;
        }

        public Director CheckIfExists(string Name)
        {
            var director = _context.Director.Where(i => i.Name == Name).FirstOrDefault();
            return director;
        }
    }
}
