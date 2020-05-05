using System;
using AutoMapper;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Models;

namespace DVDRentalAPI.Services.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserModel, Users>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
                {
                    StreetName = src.StreetName,
                    AptNumber = src.AptNo,
                    City = new City
                    {
                        CityName = src.City,
                        State = new State
                        {
                            StateName = src.State,
                            CountryId = 1,
                            LastUpdatedBy = DateTime.UtcNow
                        },
                        LastUpdatedBy = DateTime.UtcNow
                    },
                    ZipCode = src.ZipCode
                }))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
