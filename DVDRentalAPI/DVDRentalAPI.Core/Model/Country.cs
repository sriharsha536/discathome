using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDRentalAPI.Core.Model
{
    public partial class Country
    {
        public Country()
        {
            Director = new HashSet<Director>();
            Producer = new HashSet<Producer>();
            State = new HashSet<State>();
            Writer = new HashSet<Writer>();
        }

        [Key]
        [Column("Country_Id")]
        public int CountryId { get; set; }
        [Required]
        [Column("Country_Name")]
        [StringLength(50)]
        public string CountryName { get; set; }
        [Column("Last_Updated_By", TypeName = "datetime")]
        public DateTime LastUpdatedBy { get; set; }

        [InverseProperty("LivingCountry")]
        public virtual ICollection<Director> Director { get; set; }
        [InverseProperty("HqCountry")]
        public virtual ICollection<Producer> Producer { get; set; }
        [InverseProperty("Country")]
        public virtual ICollection<State> State { get; set; }
        [InverseProperty("LivingCountry")]
        public virtual ICollection<Writer> Writer { get; set; }
    }
}
