using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Trip_Applection.Models
{
    [Table("City")]
    public partial class City
    {
        public City()
        {
            Contries = new HashSet<Contry>();
        }

        [Key]
        [Column("city_id")]
        public int CityId { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string? Name { get; set; }

        [InverseProperty("City")]
        public virtual ICollection<Contry> Contries { get; set; }
    }
}
