using System;
using DVDRentalAPI.Core.Model;

namespace DVDRentalAPI.Repository.Interfaces
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Country CheckIfExists(string Name);
    }
}
