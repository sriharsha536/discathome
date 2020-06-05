using System;
using DVDRentalAPI.Core.Dto;
using DVDRentalAPI.Core.Model;

namespace DVDRentalAPI.Repository.Interfaces
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Movie CheckIfExists(string imdbId);
        MovieDetailDto GetMovieDetail(int movieId);
    }
}
