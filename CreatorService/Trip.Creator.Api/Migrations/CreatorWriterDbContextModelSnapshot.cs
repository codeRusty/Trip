﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trip.Creator.Persistence.Base;

namespace Trip.Creator.Api.Migrations
{
    [DbContext(typeof(CreatorWriterDbContext))]
    partial class CreatorWriterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("Trip.Creator.Domain.Entities.Creation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Acknowledged")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Delete")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

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
                        .HasColumnType("TEXT");

                    b.Property<string>("CreationId")
                        .HasColumnType("TEXT");

                    b.Property<string>("MimeType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
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
