using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDRentalAPI.Core.Model
{
    public partial class MovieActor
    {
        [Key]
        [Column("MA_Id")]
        public int MaId { get; set; }
        [Column("Actor_Id")]
        public int? ActorId { get; set; }
        [Column("Movie_Id")]
        public int? MovieId { get; set; }
        [Column("Last_Updated_By", TypeName = "datetime")]
        public DateTime LastUpdatedBy { get; set; }

        [ForeignKey(nameof(ActorId))]
        [InverseProperty("MovieActor")]
        public virtual Actor Actor { get; set; }
        [ForeignKey(nameof(MovieId))]
        [InverseProperty("MovieActor")]
        public virtual Movie Movie { get; set; }
    }
}
