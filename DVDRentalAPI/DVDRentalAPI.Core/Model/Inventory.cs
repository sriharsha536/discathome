using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDRentalAPI.Core.Model
{
    public partial class Inventory
    {
        [Key]
        [Column("Inventory_Id")]
        public int InventoryId { get; set; }
        [Column("Store_Id")]
        public int? StoreId { get; set; }
        [Column("Movie_Id")]
        public int? MovieId { get; set; }
        [Column("Last_Updated_By", TypeName = "datetime")]
        public DateTime LastUpdatedBy { get; set; }

        [ForeignKey(nameof(MovieId))]
        [InverseProperty("Inventory")]
        public virtual Movie Movie { get; set; }
        [ForeignKey(nameof(StoreId))]
        [InverseProperty("Inventory")]
        public virtual Store Store { get; set; }
    }
}
