using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Models;
using DVDRentalAPI.Repository.Interfaces;
using DVDRentalAPI.Services.Interfaces;

namespace DVDRentalAPI.Services.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MovieService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<MovieSearchModel> SearchMovies(string matchingFilter)
        {
            var movies = _unitOfWork.Movies.Find(i => i.MovieName.Contains(matchingFilter));
            var movieSearchModel = _mapper.Map<IEnumerable<MovieSearchModel>>(movies);
            return movieSearchModel;
        }
    }
}
