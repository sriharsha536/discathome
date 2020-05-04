using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDRentalAPI.Core.Model
{
    public partial class Movie
    {
        public Movie()
        {
            Genre = new HashSet<Genre>();
            Inventory = new HashSet<Inventory>();
            Language = new HashSet<Language>();
            Media = new HashSet<Media>();
            MovieActor = new HashSet<MovieActor>();
        }

        [Key]
        [Column("Movie_Id")]
        public int MovieId { get; set; }
        [Column("Imdb_Id")]
        public string ImdbId { get; set; }
        [Column("Movie_Name")]
        public string MovieName { get; set; }
        public int Year { get; set; }
        [Column("Release_Date", TypeName = "datetime")]
        public DateTime ReleaseDate { get; set; }
        [Column("Run_Time")]
        public int RunTime { get; set; }
        [Column("Director_Id")]
        public int? DirectorId { get; set; }
        [Column("Writer_Id")]
        public int? WriterId { get; set; }
        [Column("Imdb_Votes")]
        public long ImdbVotes { get; set; }
        [Column("Imdb_Rating", TypeName = "decimal(5, 2)")]
        public decimal ImdbRating { get; set; }
        [Column("Production_Id")]
        public int? ProductionId { get; set; }
        [Column("Box_Office", TypeName = "money")]
        public decimal BoxOffice { get; set; }
        public string Plot { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }

        [ForeignKey(nameof(DirectorId))]
        [InverseProperty("Movie")]
        public virtual Director Director { get; set; }
        [ForeignKey(nameof(ProductionId))]
        [InverseProperty(nameof(Producer.Movie))]
        public virtual Producer Production { get; set; }
        [ForeignKey(nameof(WriterId))]
        [InverseProperty("Movie")]
        public virtual Writer Writer { get; set; }
        [InverseProperty("Movie")]
        public virtual ICollection<Genre> Genre { get; set; }
        [InverseProperty("Movie")]
        public virtual ICollection<Inventory> Inventory { get; set; }
        [InverseProperty("Movie")]
        public virtual ICollection<Language> Language { get; set; }
        [InverseProperty("Movie")]
        public virtual ICollection<Media> Media { get; set; }
        [InverseProperty("Movie")]
        public virtual ICollection<MovieActor> MovieActor { get; set; }
    }
}
