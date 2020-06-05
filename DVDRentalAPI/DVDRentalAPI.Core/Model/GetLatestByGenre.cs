using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDRentalAPI.Core.Model
{
    public partial class GetLatestByGenre
    {
        [Column("Movie_Id")]
        public int MovieId { get; set; }
        public string Poster { get; set; }
        [Column("Genre_Name")]
        public string GenreName { get; set; }
    }
}
