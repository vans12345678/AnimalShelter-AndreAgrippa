﻿// <auto-generated />
using System;
using AnimalShelter_AndreAgrippa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnimalShelter_AndreAgrippa.Migrations
{
    [DbContext(typeof(ShelterContext))]
    partial class ShelterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AnimalShelter_AndreAgrippa.Models.Animal", b =>
                {
                    b.Property<int>("animalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("age")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("animalName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("species")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("animalID");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("AnimalShelter_AndreAgrippa.Models.Appointment", b =>
                {
                    b.Property<int>("appointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("animalID")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ownerID")
                        .HasColumnType("int");

                    b.HasKey("appointmentID");

                    b.HasIndex("animalID");

                    b.HasIndex("ownerID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("AnimalShelter_AndreAgrippa.Models.Owner", b =>
                {
                    b.Property<int>("ownerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phonenumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ownerID");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("AnimalShelter_AndreAgrippa.Models.Appointment", b =>
                {
                    b.HasOne("AnimalShelter_AndreAgrippa.Models.Animal", "animal")
                        .WithMany()
                        .HasForeignKey("animalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnimalShelter_AndreAgrippa.Models.Owner", "owner")
                        .WithMany()
                        .HasForeignKey("ownerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("animal");

                    b.Navigation("owner");
                });
#pragma warning restore 612, 618
        }
    }
}
