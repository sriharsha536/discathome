using System;
using DVDRentalAPI.Core.Model;

namespace DVDRentalAPI.Repository.Interfaces
{
    public interface IActorRepository : IGenericRepository<Actor>
    {
        Actor CheckIfExists(string Name);
    }
}
