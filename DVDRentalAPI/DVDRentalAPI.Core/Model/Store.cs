using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDRentalAPI.Core.Model
{
    public partial class Store
    {
        public Store()
        {
            Inventory = new HashSet<Inventory>();
            RentalHistory = new HashSet<RentalHistory>();
        }

        [Key]
        [Column("Store_Id")]
        public int StoreId { get; set; }
        [Column("User_Id")]
        public int? UserId { get; set; }
        [Column("Address_Id")]
        public int? AddressId { get; set; }
        [Required]
        [Column("Last_Name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Column("Last_Updated_By", TypeName = "datetime")]
        public DateTime LastUpdatedBy { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Store")]
        public virtual Address Address { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.Store))]
        public virtual Users User { get; set; }
        [InverseProperty("Store")]
        public virtual ICollection<Inventory> Inventory { get; set; }
        [InverseProperty("Store")]
        public virtual ICollection<RentalHistory> RentalHistory { get; set; }
    }
}
