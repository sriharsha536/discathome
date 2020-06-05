using System.Linq;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Repository.Interfaces;

namespace DVDRentalAPI.Repository.Repository
{
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        private readonly DVDRentalContext _context;

        public ActorRepository(DVDRentalContext context) : base(context)
        {
            _context = context;
        }

        public Actor CheckIfExists(string Name)
        {
            var actor = _context.Actor.Where(i => i.Name == Name).FirstOrDefault();
            return actor;
        }
    }
}
