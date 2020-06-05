using System.Collections.Generic;

namespace DVDRentalAPI.Core.Dto
{
    public class MovieDetailDto
    {
        public int MovieId { get; set; }
        public string ImdbId { get; set; }
        public string MovieName { get; set; }
        public string DirectorName { get; set; }
        public string WriterName { get; set; }
        public string ProducerName { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public int ReleaseYear { get; set; }
        public long ImdbVotes { get; set; }
        public decimal ImdbRating { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Cast { get; set; }
        public List<string> Languages { get; set; }
        public List<string> MediaUrls { get; set; }
    }
}
