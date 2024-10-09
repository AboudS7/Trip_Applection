using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Trip_Applection.Models
{
    [Table("Contry")]
    public partial class Contry
    {
        public Contry()
        {
            Trips = new HashSet<Trip>();
        }

        [Key]
        [Column("contry_id")]
        public int ContryId { get; set; }
        [Column("city_id")]
        public int? CityId { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string? Name { get; set; }

        [ForeignKey("CityId")]
        [InverseProperty("Contries")]
        public virtual City? City { get; set; }
        [InverseProperty("Contry")]
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
