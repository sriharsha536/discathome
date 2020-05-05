using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDRentalAPI.Core.Model
{
    public partial class Users
    {
        public Users()
        {
            RentalHistory = new HashSet<RentalHistory>();
            Store = new HashSet<Store>();
        }

        [Key]
        [Column("User_Id")]
        public int UserId { get; set; }
        [Required]
        [Column("First_Name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [Column("Last_Name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Column("Address_Id")]
        public int? AddressId { get; set; }
        [Column("Role_Id")]
        public int? RoleId { get; set; }
        [Required]
        [Column("Email_id")]
        [StringLength(50)]
        public string EmailId { get; set; }
        [Column("Is_Active")]
        public bool IsActive { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Column("Last_Updated_By", TypeName = "datetime")]
        public DateTime LastUpdatedBy { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Users")]
        public virtual Address Address { get; set; }
        [ForeignKey(nameof(RoleId))]
        [InverseProperty("Users")]
        public virtual Role Role { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<RentalHistory> RentalHistory { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Store> Store { get; set; }
    }
}
