﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PatientsWebApi.Features.Patients.Models;

#nullable disable

namespace PatientsWebApi.Migrations
{
    [DbContext(typeof(PostgresContext))]
    partial class PostgresContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PatientsWebApi.Features.Patients.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "gender_id_uindex")
                        .IsUnique();

                    b.HasIndex(new[] { "Name" }, "gender_name_uindex")
                        .IsUnique();

                    b.ToTable("gender", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "male"
                        },
                        new
                        {
                            Id = 2,
                            Name = "female"
                        },
                        new
                        {
                            Id = 3,
                            Name = "other"
                        },
                        new
                        {
                            Id = 4,
                            Name = "unknown"
                        });
                });

            modelBuilder.Entity("PatientsWebApi.Features.Patients.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birth_date");

                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("gender_id");

                    b.Property<int>("NameId")
                        .HasColumnType("integer")
                        .HasColumnName("name_id");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("NameId");

                    b.HasIndex(new[] { "Id" }, "patient_id_uindex")
                        .IsUnique();

                    b.ToTable("patient", (string)null);
                });

            modelBuilder.Entity("PatientsWebApi.Features.Patients.Models.PatientName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Family")
                        .HasColumnType("text")
                        .HasColumnName("family");

                    b.Property<string[]>("Given")
                        .HasColumnType("text[]")
                        .HasColumnName("given");

                    b.Property<bool>("Official")
                        .HasColumnType("boolean")
                        .HasColumnName("official");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "patient_name_id_uindex")
                        .IsUnique();

                    b.ToTable("patient_name", (string)null);
                });

            modelBuilder.Entity("PatientsWebApi.Features.Patients.Models.Patient", b =>
                {
                    b.HasOne("PatientsWebApi.Features.Patients.Models.Gender", "Gender")
                        .WithMany("Patients")
                        .HasForeignKey("GenderId")
                        .IsRequired()
                        .HasConstraintName("patient_gender_id_fk");

                    b.HasOne("PatientsWebApi.Features.Patients.Models.PatientName", "Name")
                        .WithMany("Patients")
                        .HasForeignKey("NameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("patient_patient_name_id_fk");

                    b.Navigation("Gender");

                    b.Navigation("Name");
                });

            modelBuilder.Entity("PatientsWebApi.Features.Patients.Models.Gender", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("PatientsWebApi.Features.Patients.Models.PatientName", b =>
                {
                    b.Navigation("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}
