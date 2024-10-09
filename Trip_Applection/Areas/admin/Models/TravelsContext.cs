using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Trip_Applection.Areas.admin.Models;

namespace Trip_Applection.Models
{
    public partial class TravelsContext :IdentityDbContext<User>
    {
        public TravelsContext()
        {

        }
        public TravelsContext(DbContextOptions<TravelsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Catogery> Catogeries { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Contry> Contries { get; set; } = null!;
        public virtual DbSet<Imag> Imags { get; set; } = null!;
        public virtual DbSet<Trip> Trips { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.; Database=Travels; Trusted_Connection=yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Catogery>(entity =>
            {
                entity.HasKey(e => e.CatogryId)
                    .HasName("PK__Catogery__19BD3E1984A2C092");
            });

            modelBuilder.Entity<Contry>(entity =>
            {
                entity.HasOne(d => d.City)
                    .WithMany(p => p.Contries)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("City_Id");
            });

            modelBuilder.Entity<Imag>(entity =>
            {
                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Imags)
                    .HasForeignKey(d => d.TripId)
                    .HasConstraintName("Trip_Id");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasOne(d => d.Catogry)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.CatogryId)
                    .HasConstraintName("Catogry_id");

                entity.HasOne(d => d.Contry)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.ContryId)
                    .HasConstraintName("Contry_Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
