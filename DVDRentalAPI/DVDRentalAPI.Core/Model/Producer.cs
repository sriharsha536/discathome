using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDRentalAPI.Core.Model
{
    public partial class Producer
    {
        public Producer()
        {
            Movie = new HashSet<Movie>();
        }

        [Key]
        [Column("Production_Id")]
        public int ProductionId { get; set; }
        [Column("Firm_Name")]
        public string FirmName { get; set; }
        [Column("Owner_First_Name")]
        public string OwnerFirstName { get; set; }
        [Column("Owner_Last_Name")]
        public string OwnerLastName { get; set; }
        [Column("HQ_Country_Id")]
        public int? HqCountryId { get; set; }
        [Column("Last_Updated_By", TypeName = "datetime")]
        public DateTime LastUpdatedBy { get; set; }

        [ForeignKey(nameof(HqCountryId))]
        [InverseProperty(nameof(Country.Producer))]
        public virtual Country HqCountry { get; set; }
        [InverseProperty("Production")]
        public virtual ICollection<Movie> Movie { get; set; }
    }
}
