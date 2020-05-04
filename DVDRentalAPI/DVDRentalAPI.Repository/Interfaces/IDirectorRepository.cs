using System;
using DVDRentalAPI.Core.Model;

namespace DVDRentalAPI.Repository.Interfaces
{
    public interface IDirectorRepository : IGenericRepository<Director>
    {
        Director CheckIfExists(string Name);
    }
}
