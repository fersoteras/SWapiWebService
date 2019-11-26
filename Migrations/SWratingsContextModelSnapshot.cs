﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiService.EFmodel;

namespace WebApiService.Migrations
{
    [DbContext(typeof(SWratingsContext))]
    partial class SWratingsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0-preview3.19554.8");

            modelBuilder.Entity("WebApiService.EFmodel.SWRating", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CharacterRating")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxRating")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
