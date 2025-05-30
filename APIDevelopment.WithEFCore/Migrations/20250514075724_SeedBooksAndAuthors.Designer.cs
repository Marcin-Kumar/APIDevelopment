﻿// <auto-generated />
using System;
using APIDevelopment.WithEFCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIDevelopment.WithEFCore.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20250514075724_SeedBooksAndAuthors")]
    partial class SeedBooksAndAuthors
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APIDevelopment.WithEFCore.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "J K Rowling"
                        },
                        new
                        {
                            Id = 2,
                            Name = "A P J Abdul Kalam"
                        },
                        new
                        {
                            Id = 3,
                            Name = "J R R Tolkien"
                        });
                });

            modelBuilder.Entity("APIDevelopment.WithEFCore.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            PublishedDate = new DateTime(2000, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Harry Potter: The Philosophers stone"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            PublishedDate = new DateTime(2002, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Wings of Fire"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            PublishedDate = new DateTime(2003, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Hobbit"
                        });
                });

            modelBuilder.Entity("APIDevelopment.WithEFCore.Models.Book", b =>
                {
                    b.HasOne("APIDevelopment.WithEFCore.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("APIDevelopment.WithEFCore.Models.Author", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
