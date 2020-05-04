using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDRentalAPI.Core.Model
{
    public partial class Media
    {
        [Key]
        [Column("Media_Id")]
        public int MediaId { get; set; }
        [Column("Movie_Id")]
        public int? MovieId { get; set; }
        [Column("Media_Type")]
        public string MediaType { get; set; }
        [Column("Media_Provider")]
        public string MediaProvider { get; set; }
        [Required]
        [Column("Media_Identifier")]
        [StringLength(255)]
        public string MediaIdentifier { get; set; }
        [Column("Media_Url")]
        [StringLength(255)]
        public string MediaUrl { get; set; }
        [Column("Last_Updated_By", TypeName = "datetime")]
        public DateTime LastUpdatedBy { get; set; }

        [ForeignKey(nameof(MovieId))]
        [InverseProperty("Media")]
        public virtual Movie Movie { get; set; }
    }
}
