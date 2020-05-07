using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDRentalAPI.Core.Model
{
    public partial class State
    {
        public State()
        {
            Address = new HashSet<Address>();
            City = new HashSet<City>();
        }

        [Key]
        [Column("State_Id")]
        public int StateId { get; set; }
        [Required]
        [Column("State_Name")]
        [StringLength(50)]
        public string StateName { get; set; }
        [Required]
        [Column("State_Short_Name")]
        [StringLength(10)]
        public string StateShortName { get; set; }
        [Column("Country_Id")]
        public int? CountryId { get; set; }
        [Column("Last_Updated_By", TypeName = "datetime")]
        public DateTime LastUpdatedBy { get; set; }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty("State")]
        public virtual Country Country { get; set; }
        [InverseProperty("State")]
        public virtual ICollection<Address> Address { get; set; }
        [InverseProperty("State")]
        public virtual ICollection<City> City { get; set; }
    }
}
