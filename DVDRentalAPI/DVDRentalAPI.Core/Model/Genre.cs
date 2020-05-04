using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDRentalAPI.Core.Model
{
    public partial class Genre
    {
        [Key]
        [Column("Genre_Id")]
        public int GenreId { get; set; }
        [Column("Movie_Id")]
        public int? MovieId { get; set; }
        [Column("Genre_Name")]
        public string GenreName { get; set; }
        [Column("Last_Updated_On", TypeName = "datetime")]
        public DateTime LastUpdatedOn { get; set; }

        [ForeignKey(nameof(MovieId))]
        [InverseProperty("Genre")]
        public virtual Movie Movie { get; set; }
    }
}
