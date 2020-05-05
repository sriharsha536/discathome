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
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address {
                    StreetName = src.StreetName,
                    AptNumber = src.AptNo,
                    City = new City {
                        CityName = src.City,
                        State = new State
                        {
                            StateName = src.State,
                        }
                    },
                    ZipCode = src.ZipCode
                }));
        }
    }
}
