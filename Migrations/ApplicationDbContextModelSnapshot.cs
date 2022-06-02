﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealEstate.Data;

#nullable disable

namespace RealEstate.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RealEstate.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("RealEstate.Models.Brokeragephonenumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("NVARCHAR(255)");

                    b.Property<int?>("RealEstateBrokerFkId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "RealEstateBrokerFkId" }, "IX_Brokeragephonenumbers_RealEstateBrokerFkId");

                    b.ToTable("Brokeragephonenumbers");
                });

            modelBuilder.Entity("RealEstate.Models.Home", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AddressFkId")
                        .HasColumnType("int");

                    b.Property<string>("Basement")
                        .HasColumnType("NVARCHAR(70)");

                    b.Property<double>("BathRooms")
                        .HasColumnType("float");

                    b.Property<double>("BedRooms")
                        .HasColumnType("float");

                    b.Property<string>("Brokerage")
                        .HasColumnType("NVARCHAR(70)");

                    b.Property<string>("BuilderName")
                        .HasColumnType("NVARCHAR(40)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<string>("FeaturesAndFinishes")
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<bool>("FromRemax")
                        .HasColumnType("bit");

                    b.Property<string>("GenSlug")
                        .HasColumnType("NVARCHAR(200)");

                    b.Property<string>("GeneralizedAddress")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(200)");

                    b.Property<string>("HtmlPage")
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<string>("LinkUrl")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(255)");

                    b.Property<string>("MlsNumber")
                        .HasColumnType("NVARCHAR(40)");

                    b.Property<string>("NeighborHood")
                        .HasColumnType("NVARCHAR(60)");

                    b.Property<bool>("NewConstruction")
                        .HasColumnType("bit");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<int?>("RealEstateBrokerFkId")
                        .HasColumnType("int");

                    b.Property<long?>("RentPrice")
                        .HasColumnType("bigint");

                    b.Property<bool>("Rentable")
                        .HasColumnType("bit");

                    b.Property<string>("SubType")
                        .HasColumnType("NVARCHAR(30)");

                    b.Property<string>("Type")
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("YearBuilt")
                        .HasColumnType("NVARCHAR(30)");

                    b.HasKey("Id");

                    b.HasIndex("AddressFkId")
                        .IsUnique()
                        .HasFilter("[AddressFkId] IS NOT NULL");

                    b.HasIndex("GenSlug");

                    b.HasIndex("Price");

                    b.HasIndex(new[] { "AddressFkId" }, "IX_Homes_AddressFkId")
                        .HasDatabaseName("IX_Homes_AddressFkId1");

                    b.HasIndex(new[] { "RealEstateBrokerFkId" }, "IX_Homes_RealEstateBrokerFkId");

                    b.ToTable("Homes");
                });

            modelBuilder.Entity("RealEstate.Models.Imagelink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("HomeFkId")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasColumnType("NVARCHAR(400)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "HomeFkId" }, "IX_Imagelinks_HomeFkId");

                    b.ToTable("Imagelinks");
                });

            modelBuilder.Entity("RealEstate.Models.Landtype", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Landtypes");
                });

            modelBuilder.Entity("RealEstate.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .HasColumnType("NVARCHAR(150)");

                    b.Property<string>("ExactAddress")
                        .HasColumnType("NVARCHAR(200)");

                    b.Property<string>("HouseNumber")
                        .HasColumnType("NVARCHAR(10)");

                    b.Property<double?>("Lat")
                        .HasColumnType("float");

                    b.Property<double?>("Long")
                        .HasColumnType("float");

                    b.Property<string>("MapBoxResult")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("NVARCHAR(10)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("RealEstate.Models.Realestatebroker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brokerage")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(200)");

                    b.Property<string>("BrokerageWebsite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(200)");

                    b.HasKey("Id");

                    b.ToTable("Realestatebrokers");
                });

            modelBuilder.Entity("RealEstate.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("HomeFkId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR(25)");

                    b.Property<string>("RoomSize")
                        .HasColumnType("NVARCHAR(100)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "HomeFkId" }, "IX_Rooms_HomeFkId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("RealEstate.Models.Scraperconfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BaseDomain")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScrapConfigName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Scraperconfigs");
                });

            modelBuilder.Entity("RealEstate.Models.Searchlocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("LocationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ScrapingConfigFkId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ScrapingConfigFkId" }, "IX_Searchlocations_ScrapingConfigFkId");

                    b.ToTable("Searchlocations");
                });

            modelBuilder.Entity("RealEstate.Models.Useragentname", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Useragentnames");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RealEstate.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RealEstate.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstate.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RealEstate.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RealEstate.Models.Brokeragephonenumber", b =>
                {
                    b.HasOne("RealEstate.Models.Realestatebroker", "RealEstateBrokerFk")
                        .WithMany("Brokeragephonenumbers")
                        .HasForeignKey("RealEstateBrokerFkId");

                    b.Navigation("RealEstateBrokerFk");
                });

            modelBuilder.Entity("RealEstate.Models.Home", b =>
                {
                    b.HasOne("RealEstate.Models.Location", "AddressFk")
                        .WithOne("Home")
                        .HasForeignKey("RealEstate.Models.Home", "AddressFkId");

                    b.HasOne("RealEstate.Models.Realestatebroker", "RealEstateBrokerFk")
                        .WithMany("Homes")
                        .HasForeignKey("RealEstateBrokerFkId");

                    b.Navigation("AddressFk");

                    b.Navigation("RealEstateBrokerFk");
                });

            modelBuilder.Entity("RealEstate.Models.Imagelink", b =>
                {
                    b.HasOne("RealEstate.Models.Home", "HomeFk")
                        .WithMany("Imagelinks")
                        .HasForeignKey("HomeFkId");

                    b.Navigation("HomeFk");
                });

            modelBuilder.Entity("RealEstate.Models.Room", b =>
                {
                    b.HasOne("RealEstate.Models.Home", "HomeFk")
                        .WithMany("Rooms")
                        .HasForeignKey("HomeFkId");

                    b.Navigation("HomeFk");
                });

            modelBuilder.Entity("RealEstate.Models.Searchlocation", b =>
                {
                    b.HasOne("RealEstate.Models.Scraperconfig", "ScrapingConfigFk")
                        .WithMany("Searchlocations")
                        .HasForeignKey("ScrapingConfigFkId");

                    b.Navigation("ScrapingConfigFk");
                });

            modelBuilder.Entity("RealEstate.Models.Home", b =>
                {
                    b.Navigation("Imagelinks");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("RealEstate.Models.Location", b =>
                {
                    b.Navigation("Home");
                });

            modelBuilder.Entity("RealEstate.Models.Realestatebroker", b =>
                {
                    b.Navigation("Brokeragephonenumbers");

                    b.Navigation("Homes");
                });

            modelBuilder.Entity("RealEstate.Models.Scraperconfig", b =>
                {
                    b.Navigation("Searchlocations");
                });
#pragma warning restore 612, 618
        }
    }
}
