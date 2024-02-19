using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PatientsWebApi.Features.Patients.Models
{
    public partial class PostgresContext : DbContext
    {
        public PostgresContext()
        {
        }

        public PostgresContext(DbContextOptions<PostgresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Gender> Genders { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<PatientName> PatientNames { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=valsl;Password=etereg14");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("gender");

                entity.HasIndex(e => e.Id, "gender_id_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "gender_name_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("patient");

                entity.HasIndex(e => e.Id, "patient_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.BirthDate).HasColumnName("birth_date");

                entity.Property(e => e.GenderId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("gender_id");

                entity.Property(e => e.NameId)
                    .HasColumnName("name_id")
                    .HasDefaultValueSql("nextval('patient_name_id_seq1'::regclass)");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("patient_gender_id_fk");

                entity.HasOne(d => d.Name)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.NameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("patient_patient_name_id_fk");
            });

            modelBuilder.Entity<PatientName>(entity =>
            {
                entity.ToTable("patient_name");

                entity.HasIndex(e => e.Id, "patient_name_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Family).HasColumnName("family");

                entity.Property(e => e.Given).HasColumnName("given");

                entity.Property(e => e.Official).HasColumnName("official");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
