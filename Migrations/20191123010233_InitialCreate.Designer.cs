﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiService.EFmodel;

namespace WebApiService.Migrations
{
    [DbContext(typeof(SWratingsContext))]
    [Migration("20191123010233_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1");

            modelBuilder.Entity("WebApiService.EFmodel.SWRating", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CharacterRating")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
