using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Trip_Applection.Models
{
    [Table("Trip")]
    public partial class Trip
    {
        public Trip()
        {
            Imags = new HashSet<Imag>();
        }

        [Key]
        [Column("trip_id")]
        public int TripId { get; set; }
        [Column("description_")]
        [StringLength(100)]
        public string? Description { get; set; }
        [Column("price", TypeName = "money")]
        public decimal? Price { get; set; }
        [Column("contry_id")]
        public int? ContryId { get; set; }
        [Column("imag_id")]
        public int? ImagId { get; set; }
        [Column("catogry_id")]
        public int? CatogryId { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string? Name { get; set; }

        [ForeignKey("CatogryId")]
        [InverseProperty("Trips")]
        public virtual Catogery? Catogry { get; set; }
        [ForeignKey("ContryId")]
        [InverseProperty("Trips")]
        public virtual Contry? Contry { get; set; }
        [InverseProperty("Trip")]
        public virtual ICollection<Imag> Imags { get; set; }
    }
}
