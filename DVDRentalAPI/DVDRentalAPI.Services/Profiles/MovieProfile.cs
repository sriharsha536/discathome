using System;
using AutoMapper;
using DVDRentalAPI.Core.Dto;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Models;

namespace DVDRentalAPI.Services.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieSearchModel>();

            CreateMap<GetLatestByGenre, MovieThumbModel>();

            CreateMap<MovieDetailDto, MovieDetailModel>();
        }
    }
}
