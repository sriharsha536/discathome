using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDRentalAPI.Core.Model
{
    public partial class Flights
    {
        [Key]
        public int Id { get; set; }
        [StringLength(10)]
        public string Source { get; set; }
        [StringLength(10)]
        public string Destination { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndTime { get; set; }
    }
}
