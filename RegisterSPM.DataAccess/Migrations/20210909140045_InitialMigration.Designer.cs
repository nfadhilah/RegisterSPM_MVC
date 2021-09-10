﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegisterSPM.DataAccess.Data;

namespace RegisterSPM.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210909140045_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "b9a421be-c00b-4936-a827-88952eaeec73",
                            ConcurrencyStamp = "5b4adbbc-64e8-47d0-9bfb-e8fb491de8c4",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "808cad2c-9253-4c59-acd3-b9cbf0fc1d05",
                            ConcurrencyStamp = "c8cbe351-b0c9-4bd9-b701-4c64d235b93b",
                            Name = "SA",
                            NormalizedName = "SA"
                        },
                        new
                        {
                            Id = "19b30aa5-3912-440a-8a64-113d6f504793",
                            ConcurrencyStamp = "6853ad38-2b37-4172-b5c8-7f003ea518f8",
                            Name = "Registrator",
                            NormalizedName = "REGISTRATOR"
                        },
                        new
                        {
                            Id = "d62c7742-76e5-4a10-9c0b-a341b4681ab5",
                            ConcurrencyStamp = "f7e381ca-5c01-4e75-b01c-1f1f9ea51f7b",
                            Name = "Verifikator",
                            NormalizedName = "VERIFIKATOR"
                        },
                        new
                        {
                            Id = "d94445f9-fa22-47f8-b1c5-a3656098cc13",
                            ConcurrencyStamp = "8a6dc435-ae16-499d-aeb3-68658a98df0f",
                            Name = "Approver",
                            NormalizedName = "APPROVER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
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

                    b.Property<string>("Discriminator")
                        .IsRequired()
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

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
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

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
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

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("RegisterSPM.Models.Checklist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SeqNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uraian")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Checklist");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SeqNo = "00001",
                            Uraian = "Penelitian Kelengkapan Dokumen SPP - UP/GU/TU/LS (Cheklist)"
                        },
                        new
                        {
                            Id = 2,
                            SeqNo = "00002",
                            Uraian = "Surat Pengantar SPP - UP/GU/TU/LS"
                        },
                        new
                        {
                            Id = 3,
                            SeqNo = "00003",
                            Uraian = "Ringkasan SPP - UP/GU/TU/LS "
                        },
                        new
                        {
                            Id = 4,
                            SeqNo = "00004",
                            Uraian = "Rincian SPP - UP/GU/TU/LS"
                        },
                        new
                        {
                            Id = 5,
                            SeqNo = "00005",
                            Uraian = "Surat Perintah Membayar (SPM)"
                        },
                        new
                        {
                            Id = 6,
                            SeqNo = "00006",
                            Uraian = "Kuitansi Dinas"
                        },
                        new
                        {
                            Id = 7,
                            SeqNo = "00007",
                            Uraian = "Surat Pernyataan Pengajuan SPP -UP/GU/TU/LS"
                        },
                        new
                        {
                            Id = 8,
                            SeqNo = "00008",
                            Uraian = "Surat Pernyataan Tanggung jawab yang ditandatangani oleh PA/KPA"
                        },
                        new
                        {
                            Id = 9,
                            SeqNo = "00009",
                            Uraian = "Faktur Pajak/SSP"
                        },
                        new
                        {
                            Id = 10,
                            SeqNo = "00010",
                            Uraian = "Salinan SPD"
                        },
                        new
                        {
                            Id = 11,
                            SeqNo = "00011",
                            Uraian = "Foto Copy Buku Rekening Bank / Referensi Bank"
                        });
                });

            modelBuilder.Entity("RegisterSPM.Models.ChecklistSPM", b =>
                {
                    b.Property<int>("ChecklistId")
                        .HasColumnType("int");

                    b.Property<int>("SPMId")
                        .HasColumnType("int");

                    b.HasKey("ChecklistId", "SPMId");

                    b.HasIndex("SPMId");

                    b.ToTable("ChecklistSPM");
                });

            modelBuilder.Entity("RegisterSPM.Models.SPM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApprovedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ApprovedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DocStatus")
                        .HasColumnType("int");

                    b.Property<string>("Keperluan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Nilai")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NoSPM")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OPD")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RejectedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RejectedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TglSPM")
                        .HasColumnType("datetime2");

                    b.Property<string>("UnitKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VerifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("VerifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OPD", "NoSPM", "UnitKey")
                        .IsUnique()
                        .HasFilter("[OPD] IS NOT NULL AND [NoSPM] IS NOT NULL AND [UnitKey] IS NOT NULL");

                    b.ToTable("SPM");
                });

            modelBuilder.Entity("RegisterSPM.Models.Tahun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SeqNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SeqNo", "Label")
                        .IsUnique();

                    b.ToTable("Tahun");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Label = "2021",
                            SeqNo = "00001"
                        });
                });

            modelBuilder.Entity("RegisterSPM.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Jabatan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
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

            modelBuilder.Entity("RegisterSPM.Models.ChecklistSPM", b =>
                {
                    b.HasOne("RegisterSPM.Models.Checklist", "Checklist")
                        .WithMany("ListChecklistSPM")
                        .HasForeignKey("ChecklistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegisterSPM.Models.SPM", "SPM")
                        .WithMany("ListChecklistSPM")
                        .HasForeignKey("SPMId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Checklist");

                    b.Navigation("SPM");
                });

            modelBuilder.Entity("RegisterSPM.Models.Checklist", b =>
                {
                    b.Navigation("ListChecklistSPM");
                });

            modelBuilder.Entity("RegisterSPM.Models.SPM", b =>
                {
                    b.Navigation("ListChecklistSPM");
                });
#pragma warning restore 612, 618
        }
    }
}