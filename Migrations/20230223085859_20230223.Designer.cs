﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelCompany.data;

#nullable disable

namespace TravelCompany.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20230223085859_20230223")]
    partial class _20230223
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("TravelCompany.Models.Booking", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("DateTime")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<bool?>("isCheck")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<bool?>("isPay")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("noteCompany")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("noteUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("numSeates")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("personInfonationalNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("tripsid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("user")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("personInfonationalNumber");

                    b.HasIndex("tripsid");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("TravelCompany.Models.Buses", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool?>("active")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("busNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companiesid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("paletNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("regionid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("seatsNumber")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool?>("vip")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("companiesid");

                    b.HasIndex("regionid");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("TravelCompany.Models.Companies", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool?>("active")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("TravelCompany.Models.NotesCompany", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("companiesid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("companiesid");

                    b.ToTable("NotesCompany");
                });

            modelBuilder.Entity("TravelCompany.Models.PersonInfo", b =>
                {
                    b.Property<string>("nationalNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("amana")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("birthDay")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("fatherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("kayed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("motherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("regionid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool?>("sex")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.HasKey("nationalNumber");

                    b.HasIndex("regionid");

                    b.ToTable("PersonInfo");
                });

            modelBuilder.Entity("TravelCompany.Models.Region", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("arRegion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("enRegion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("TravelCompany.Models.Seates", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("bookingid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("seatNumber")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("bookingid");

                    b.ToTable("Seates");
                });

            modelBuilder.Entity("TravelCompany.Models.Trips", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("busesid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("date")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("fromid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool?>("isFull")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<int?>("minutes")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<double?>("price")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<string>("toid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("busesid");

                    b.HasIndex("fromid");

                    b.HasIndex("toid");

                    b.ToTable("Trips");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravelCompany.Models.Booking", b =>
                {
                    b.HasOne("TravelCompany.Models.PersonInfo", "personInfo")
                        .WithMany()
                        .HasForeignKey("personInfonationalNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelCompany.Models.Trips", "trips")
                        .WithMany()
                        .HasForeignKey("tripsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("personInfo");

                    b.Navigation("trips");
                });

            modelBuilder.Entity("TravelCompany.Models.Buses", b =>
                {
                    b.HasOne("TravelCompany.Models.Companies", "companies")
                        .WithMany()
                        .HasForeignKey("companiesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelCompany.Models.Region", "region")
                        .WithMany()
                        .HasForeignKey("regionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("companies");

                    b.Navigation("region");
                });

            modelBuilder.Entity("TravelCompany.Models.NotesCompany", b =>
                {
                    b.HasOne("TravelCompany.Models.Companies", "companies")
                        .WithMany()
                        .HasForeignKey("companiesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("companies");
                });

            modelBuilder.Entity("TravelCompany.Models.PersonInfo", b =>
                {
                    b.HasOne("TravelCompany.Models.Region", "region")
                        .WithMany()
                        .HasForeignKey("regionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("region");
                });

            modelBuilder.Entity("TravelCompany.Models.Seates", b =>
                {
                    b.HasOne("TravelCompany.Models.Booking", "booking")
                        .WithMany()
                        .HasForeignKey("bookingid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("booking");
                });

            modelBuilder.Entity("TravelCompany.Models.Trips", b =>
                {
                    b.HasOne("TravelCompany.Models.Buses", "buses")
                        .WithMany()
                        .HasForeignKey("busesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelCompany.Models.Region", "from")
                        .WithMany()
                        .HasForeignKey("fromid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelCompany.Models.Region", "to")
                        .WithMany()
                        .HasForeignKey("toid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("buses");

                    b.Navigation("from");

                    b.Navigation("to");
                });
#pragma warning restore 612, 618
        }
    }
}
