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
                    CityId = Convert.ToInt32(src.City),
                    StateId = Convert.ToInt32(src.State),
                    ZipCode = src.ZipCode
                }))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<Users, UserModel>();
        }
    }
}
