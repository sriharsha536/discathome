using System.Threading.Tasks;
using AutoMapper;
using DVDRentalAPI.Models;
using DVDRentalAPI.Repository.Interfaces;
using DVDRentalAPI.Services.Interfaces;
using Import.MovieDataLibrary;

namespace DVDRentalAPI.Services.Services
{
    public class UploadService : IUploadService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UploadService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<string> UploadMovieFileAsync(UploadModel uploadModel)
        {
            var movieFileUploadTask = Task.Run(() =>
            {
                var loadMovieData = new LoadMovieData(uploadModel.FilePath);
                var movieIds = loadMovieData.PrepareMovieListFromHtml();
                return loadMovieData.BulkLoadMovieData(movieIds);
            });

            var logFilePath = await movieFileUploadTask;
            return logFilePath;
        }
    }
}
