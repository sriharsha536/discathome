using AutoMapper;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Models;

namespace DVDRentalAPI.Services.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Users, UserModel>();
        }
    }
}
