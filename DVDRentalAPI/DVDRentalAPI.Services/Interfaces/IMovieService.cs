using System;
using System.Collections.Generic;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Models;

namespace DVDRentalAPI.Services.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<MovieSearchModel> SearchMovies(string matchingFilter);
    }
}
