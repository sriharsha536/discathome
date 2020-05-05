using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDRentalAPI.Core.Model
{
    public partial class Address
    {
        public Address()
        {
            Store = new HashSet<Store>();
            Users = new HashSet<Users>();
        }

        [Key]
        [Column("Address_Id")]
        public int AddressId { get; set; }
        [Required]
        [Column("Street_Name")]
        [StringLength(50)]
        public string StreetName { get; set; }
        [Required]
        [Column("Apt_Number")]
        [StringLength(50)]
        public string AptNumber { get; set; }
        [Column("City_Id")]
        public int? CityId { get; set; }
        [Required]
        [StringLength(50)]
        public string ZipCode { get; set; }
        [Column("State_Id")]
        public int? StateId { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty("Address")]
        public virtual City City { get; set; }
        [ForeignKey(nameof(StateId))]
        [InverseProperty("Address")]
        public virtual State State { get; set; }
        [InverseProperty("Address")]
        public virtual ICollection<Store> Store { get; set; }
        [InverseProperty("Address")]
        public virtual ICollection<Users> Users { get; set; }
    }
}
