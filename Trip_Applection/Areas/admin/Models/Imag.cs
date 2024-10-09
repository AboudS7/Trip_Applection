using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Trip_Applection.Models
{
    [Table("Imag")]
    public partial class Imag
    {
        [Key]
        [Column("imag_id")]
        public int ImagId { get; set; }
        [Column("Imag_name")]
        public string? ImagName { get; set; }
        [Column("trip_id")]
        public int? TripId { get; set; }

        [ForeignKey("TripId")]
        [InverseProperty("Imags")]
        public virtual Trip? Trip { get; set; }
    }
}
