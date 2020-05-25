using System;
using System.Threading.Tasks;
using DVDRentalAPI.Models;

namespace DVDRentalAPI.Services.Interfaces
{
    public interface IUploadService
    {
        Task<string> UploadMovieFileAsync(UploadModel uploadModel);
    }
}
