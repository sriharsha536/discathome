using System;
using System.Collections.Generic;
using DVDRentalAPI.Core.Model;

namespace DVDRentalAPI.Services.Interfaces
{
    public interface ICSCService
    {
        IEnumerable<City> GetCities(int stateId);
        IEnumerable<State> GetStates();
    }
}
