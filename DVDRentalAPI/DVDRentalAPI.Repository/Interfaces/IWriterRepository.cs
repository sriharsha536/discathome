using System;
using DVDRentalAPI.Core.Model;

namespace DVDRentalAPI.Repository.Interfaces
{
    public interface IWriterRepository : IGenericRepository<Writer>
    {
        Writer CheckIfExists(string Name);
    }
}
