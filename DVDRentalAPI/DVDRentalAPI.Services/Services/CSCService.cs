using System;
using System.Collections.Generic;
using AutoMapper;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Repository.Interfaces;
using DVDRentalAPI.Services.Interfaces;

namespace DVDRentalAPI.Services.Services
{
    public class CSCService : ICSCService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CSCService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<City> GetCities(int stateId)
        {
            return _unitOfWork.Cities.Find(i => i.StateId == stateId);
        }

        public IEnumerable<State> GetStates()
        {
            return _unitOfWork.States.GetAll();
        }
    }
}
