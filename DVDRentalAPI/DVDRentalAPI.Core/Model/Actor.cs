using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDRentalAPI.Core.Model
{
    public partial class Actor
    {
        public Actor()
        {
            MovieActor = new HashSet<MovieActor>();
        }

        [Key]
        [Column("Actor_Id")]
        public int ActorId { get; set; }
        [Column("Last_Updated_By", TypeName = "datetime")]
        public DateTime LastUpdatedBy { get; set; }
        public string Name { get; set; }

        [InverseProperty("Actor")]
        public virtual ICollection<MovieActor> MovieActor { get; set; }
    }
}
