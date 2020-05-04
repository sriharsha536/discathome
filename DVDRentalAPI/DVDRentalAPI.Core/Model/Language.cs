using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDRentalAPI.Core.Model
{
    public partial class Language
    {
        [Key]
        [Column("Language_Id")]
        public int LanguageId { get; set; }
        [Column("Language_Name")]
        public string LanguageName { get; set; }
        [Column("Movie_Id")]
        public int? MovieId { get; set; }
        [Column("Last_Updated_By", TypeName = "datetime")]
        public DateTime LastUpdatedBy { get; set; }

        [ForeignKey(nameof(MovieId))]
        [InverseProperty("Language")]
        public virtual Movie Movie { get; set; }
    }
}
