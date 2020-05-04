using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDRentalAPI.Core.Model
{
    public partial class Director
    {
        public Director()
        {
            Movie = new HashSet<Movie>();
        }

        [Key]
        [Column("Director_Id")]
        public int DirectorId { get; set; }
        [Column("Living_Country_Id")]
        public int? LivingCountryId { get; set; }
        [Column("Last_Updated_By", TypeName = "datetime")]
        public DateTime LastUpdatedBy { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(LivingCountryId))]
        [InverseProperty(nameof(Country.Director))]
        public virtual Country LivingCountry { get; set; }
        [InverseProperty("Director")]
        public virtual ICollection<Movie> Movie { get; set; }
    }
}
