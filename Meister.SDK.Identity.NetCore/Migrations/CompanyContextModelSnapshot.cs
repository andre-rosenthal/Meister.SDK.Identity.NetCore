﻿// <auto-generated />
using System;
using Meister.SDK.Identity.NetCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Meister.SDK.Identity.NetCore.Migrations
{
    [DbContext(typeof(CompanyContext))]
    partial class CompanyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Meister.SDK.Identity.NetCore.Models.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ConnectionId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Secret")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ConnectionId");

                    b.HasIndex("UserId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Meister.SDK.Identity.NetCore.Models.MeisterConnection", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Authentication")
                        .HasColumnType("int");

                    b.Property<string>("Client")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<string>("Gateway")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("SAPPassword")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SAPUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("MeisterConnection");
                });

            modelBuilder.Entity("Meister.SDK.Identity.NetCore.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Secret")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Meister.SDK.Identity.NetCore.Models.Company", b =>
                {
                    b.HasOne("Meister.SDK.Identity.NetCore.Models.MeisterConnection", "Connection")
                        .WithMany()
                        .HasForeignKey("ConnectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Meister.SDK.Identity.NetCore.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Meister.SDK.Identity.NetCore.Models.MeisterConnection", b =>
                {
                    b.HasOne("Meister.SDK.Identity.NetCore.Models.Company", null)
                        .WithMany("Connections")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Meister.SDK.Identity.NetCore.Models.User", b =>
                {
                    b.HasOne("Meister.SDK.Identity.NetCore.Models.Company", null)
                        .WithMany("Users")
                        .HasForeignKey("CompanyId");
                });
#pragma warning restore 612, 618
        }
    }
}
