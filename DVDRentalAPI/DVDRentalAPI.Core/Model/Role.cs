using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDRentalAPI.Core.Model
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<Users>();
        }

        [Key]
        [Column("Role_Id")]
        public int RoleId { get; set; }
        [Required]
        [Column("Role_Name")]
        [StringLength(50)]
        public string RoleName { get; set; }
        [Column("Is_Active")]
        public bool IsActive { get; set; }
        [Column("Last_Updated_By", TypeName = "datetime")]
        public DateTime LastUpdatedBy { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<Users> Users { get; set; }
    }
}
