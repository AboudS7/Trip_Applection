using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Trip_Applection.Models
{
    [Table("Catogery")]
    public partial class Catogery
    {
        public Catogery()
        {
            Trips = new HashSet<Trip>();
        }

        [Key]
        [Column("catogry_id")]
        public int CatogryId { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string? Name { get; set; }

        [InverseProperty("Catogry")]
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
