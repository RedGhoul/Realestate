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

            modelBuilder.Entity<Home>().Property(x => x.GeneralizedAddress).HasColumnType("NVARCHAR(200)");
            modelBuilder.Entity<Home>().Property(x => x.MlsNumber).HasColumnType("NVARCHAR(40)");
            modelBuilder.Entity<Home>().Property(x => x.Brokerage).HasColumnType("NVARCHAR(70)");
            modelBuilder.Entity<Home>().Property(x => x.Type).HasColumnType("NVARCHAR(20)");
            modelBuilder.Entity<Home>().Property(x => x.SubType).HasColumnType("NVARCHAR(30)");
            modelBuilder.Entity<Home>().Property(x => x.YearBuilt).HasColumnType("NVARCHAR(30)");
            modelBuilder.Entity<Home>().Property(x => x.NeighborHood).HasColumnType("NVARCHAR(60)");
            modelBuilder.Entity<Home>().Property(x => x.Basement).HasColumnType("NVARCHAR(70)");
            modelBuilder.Entity<Home>().Property(x => x.LinkUrl).HasColumnType("NVARCHAR(255)");
            modelBuilder.Entity<Home>().Property(x => x.Description).HasColumnType("NVARCHAR(MAX)");
            modelBuilder.Entity<Home>().Property(x => x.BuilderName).HasColumnType("NVARCHAR(40)");
            modelBuilder.Entity<Home>().Property(x => x.FeaturesAndFinishes).HasColumnType("NVARCHAR(MAX)");
            modelBuilder.Entity<Home>().Property(x => x.GenSlug).HasColumnType("NVARCHAR(200)");
            modelBuilder.Entity<Home>().Property(x => x.HtmlPage).HasColumnType("NVARCHAR(MAX)");
            modelBuilder.Entity<Home>().HasIndex(x => x.GenSlug);
            modelBuilder.Entity<Home>().HasIndex(x => x.Price);
            modelBuilder.Entity<Brokeragephonenumber>().Property(x => x.PhoneNumber).HasColumnType("NVARCHAR(255)");
            modelBuilder.Entity<Imagelink>().Property(x => x.Link).HasColumnType("NVARCHAR(400)");
            modelBuilder.Entity<Location>().Property(x => x.ExactAddress).HasColumnType("NVARCHAR(200)");
            modelBuilder.Entity<Location>().Property(x => x.City).HasColumnType("NVARCHAR(150)");
            modelBuilder.Entity<Location>().Property(x => x.HouseNumber).HasColumnType("NVARCHAR(10)");
            modelBuilder.Entity<Location>().Property(x => x.PostalCode).HasColumnType("NVARCHAR(10)");
            modelBuilder.Entity<Realestatebroker>().Property(x => x.Name).HasColumnType("NVARCHAR(200)");
            modelBuilder.Entity<Realestatebroker>().Property(x => x.Brokerage).HasColumnType("NVARCHAR(255)");
            modelBuilder.Entity<Realestatebroker>().Property(x => x.Brokerage).HasColumnType("NVARCHAR(200)");
            modelBuilder.Entity<Room>().Property(x => x.Name).HasColumnType("NVARCHAR(25)");
            modelBuilder.Entity<Room>().Property(x => x.Location).HasColumnType("NVARCHAR(100)");
            modelBuilder.Entity<Room>().Property(x => x.RoomSize).HasColumnType("NVARCHAR(100)");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
