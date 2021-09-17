﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trip.Creator.Persistence.Base;

namespace Trip.Creator.Api.Migrations.CreatorReaderDb
{
    [DbContext(typeof(CreatorReaderDbContext))]
    partial class CreatorReaderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("Trip.Creator.Domain.Entities.Creation", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Acknowledged")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Delete")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Processed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tagline")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tags")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Creation");
                });

            modelBuilder.Entity("Trip.Creator.Domain.Entities.CreationResource", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreationId")
                        .HasColumnType("TEXT");

                    b.Property<string>("MediumPath")
                        .HasColumnType("TEXT");

                    b.Property<string>("MimeType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .HasColumnType("TEXT");

                    b.Property<string>("SmallPath")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CreationId");

                    b.ToTable("CreationResource");
                });

            modelBuilder.Entity("Trip.Creator.Domain.Entities.CreationResource", b =>
                {
                    b.HasOne("Trip.Creator.Domain.Entities.Creation", "Creation")
                        .WithMany("Resources")
                        .HasForeignKey("CreationId");

                    b.Navigation("Creation");
                });

            modelBuilder.Entity("Trip.Creator.Domain.Entities.Creation", b =>
                {
                    b.Navigation("Resources");
                });
#pragma warning restore 612, 618
        }
    }
}
