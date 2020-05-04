using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDRentalAPI.Core.Model
{
    public partial class RentalHistory
    {
        [Key]
        [Column("Rental_Id")]
        public int RentalId { get; set; }
        [Column("Rental_Fee", TypeName = "money")]
        public decimal RentalFee { get; set; }
        [Column("Rental_Date", TypeName = "datetime")]
        public DateTime RentalDate { get; set; }
        [Column("Return_Date", TypeName = "datetime")]
        public DateTime? ReturnDate { get; set; }
        [Column("Store_Id")]
        public int StoreId { get; set; }
        [Column("User_Id")]
        public int UserId { get; set; }
        [Column("Last_Updated_By", TypeName = "datetime")]
        public DateTime LastUpdatedBy { get; set; }

        [ForeignKey(nameof(StoreId))]
        [InverseProperty("RentalHistory")]
        public virtual Store Store { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.RentalHistory))]
        public virtual Users User { get; set; }
    }
}
