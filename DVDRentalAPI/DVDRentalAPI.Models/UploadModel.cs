using System;
namespace DVDRentalAPI.Models
{
    public class UploadModel
    {
        public string EmailId { get; set; }
        public string JobId { get; set; }
        public UploadType UploadType { get; set; }
        public string FilePath { get; set; }
    }

    public enum UploadType
    {
        //Movie Type File
        Movie = 0,

        //City, State, Country File
        CSC = 1
    }
}
