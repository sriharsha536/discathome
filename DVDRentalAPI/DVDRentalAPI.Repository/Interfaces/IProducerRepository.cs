using System;
using DVDRentalAPI.Core.Model;

namespace DVDRentalAPI.Repository.Interfaces
{
    public interface IProducerRepository : IGenericRepository<Producer>
    {
        Producer CheckIfExists(string Name);
    }
}
