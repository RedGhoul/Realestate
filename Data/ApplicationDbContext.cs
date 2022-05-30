using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RealEstate.Models;

namespace RealEstate.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.SetCommandTimeout(150000);
            
        }

      
        public virtual DbSet<Brokeragephonenumber> Brokeragephonenumbers { get; set; } = null!;
        public virtual DbSet<Home> Homes { get; set; } = null!;
        public virtual DbSet<Imagelink> Imagelinks { get; set; } = null!;
        public virtual DbSet<Landtype> Landtypes { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Realestatebroker> Realestatebrokers { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Scraperconfig> Scraperconfigs { get; set; } = null!;
        public virtual DbSet<Searchlocation> Searchlocations { get; set; } = null!;
        public virtual DbSet<Useragentname> Useragentnames { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Brokeragephonenumber>(entity =>
            {
                entity.HasIndex(e => e.RealEstateBrokerFkId, "IX_Brokeragephonenumbers_RealEstateBrokerFkId");

                entity.HasOne(d => d.RealEstateBrokerFk)
                    .WithMany(p => p.Brokeragephonenumbers)
                    .HasForeignKey(d => d.RealEstateBrokerFkId);
            });

            modelBuilder.Entity<Home>(entity =>
            {
                entity.HasIndex(e => e.AddressFkId, "IX_Homes_AddressFkId");

                entity.HasIndex(e => e.RealEstateBrokerFkId, "IX_Homes_RealEstateBrokerFkId");

                entity.HasOne(d => d.AddressFk)
                    .WithOne(p => p.Home)
                    .HasForeignKey<Home>(d => d.AddressFkId);

                entity.HasOne(d => d.RealEstateBrokerFk)
                    .WithMany(p => p.Homes)
                    .HasForeignKey(d => d.RealEstateBrokerFkId);
            });

            modelBuilder.Entity<Imagelink>(entity =>
            {
                entity.HasIndex(e => e.HomeFkId, "IX_Imagelinks_HomeFkId");

                entity.HasOne(d => d.HomeFk)
                    .WithMany(p => p.Imagelinks)
                    .HasForeignKey(d => d.HomeFkId);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasIndex(e => e.HomeFkId, "IX_Rooms_HomeFkId");

                entity.HasOne(d => d.HomeFk)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.HomeFkId);
            });

            modelBuilder.Entity<Searchlocation>(entity =>
            {
                entity.HasIndex(e => e.ScrapingConfigFkId, "IX_Searchlocations_ScrapingConfigFkId");

                entity.HasOne(d => d.ScrapingConfigFk)
                    .WithMany(p => p.Searchlocations)
                    .HasForeignKey(d => d.ScrapingConfigFkId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
