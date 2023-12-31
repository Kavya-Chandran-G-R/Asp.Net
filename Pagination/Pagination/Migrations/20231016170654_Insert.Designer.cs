﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pagination.Data;

#nullable disable

namespace Pagination.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231016170654_Insert")]
    partial class Insert
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Pagination.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Galaxy"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Samsung"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Android"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Phone"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Vivo"
                        },
                        new
                        {
                            Id = 6,
                            Name = "One plus"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Realme"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Pixel"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Node"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Lap"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
