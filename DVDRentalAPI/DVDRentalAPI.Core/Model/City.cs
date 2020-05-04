using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDRentalAPI.Core.Model
{
    public partial class City
    {
        public City()
        {
            Address = new HashSet<Address>();
        }

        [Key]
        [Column("City_Id")]
        public int CityId { get; set; }
        [Required]
        [Column("City_Name")]
        [StringLength(50)]
        public string CityName { get; set; }
        [Column("State_Id")]
        public int? StateId { get; set; }
        [Column("Last_Updated_By", TypeName = "datetime")]
        public DateTime LastUpdatedBy { get; set; }

        [ForeignKey(nameof(StateId))]
        [InverseProperty("City")]
        public virtual State State { get; set; }
        [InverseProperty("City")]
        public virtual ICollection<Address> Address { get; set; }
    }
}
