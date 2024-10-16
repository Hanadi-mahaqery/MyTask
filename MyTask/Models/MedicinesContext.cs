using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyTask.Models
{
    public partial class MedicinesContext : DbContext
    {
        public MedicinesContext()
        {
        }

        public MedicinesContext(DbContextOptions<MedicinesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Medication> Medications { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Prescription> Prescriptions { get; set; } = null!;
        public virtual DbSet<Request> Requests { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-6FOQ2KB\\SQLHANADI; Database=Medicines;Trusted_Connection= true; TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("Notifications_Patient_fk");
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.PrescriptionDoctors)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescript_doctor_fk");

                entity.HasOne(d => d.Medication)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.MedicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescript_medication_fk");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PrescriptionPatients)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescript_Patient_fk");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.RequestDoctors)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("Requests_Doctor_fk");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.RequestPatients)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Requests_Patient_fk");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.PrescriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Requests_Prescript_fk");
            });

          

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
