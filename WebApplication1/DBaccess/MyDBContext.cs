using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.DBaccess
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() { }
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) { }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<MedicationPrespection> MedicationPrespections { get; set; }
        public DbSet<Roll> Rolls { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Bill>()
                .Property(b => b.BillPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Medication>()
                .Property(m => m.MedicationAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<MedicationPrespection>()
             .HasKey(mp => new { mp.PrespectionId, mp.medicationId });

            modelBuilder.Entity<MedicationPrespection>()
                .HasOne(mp => mp.prescription)
                .WithMany(p => p.medicationPrespections)
                .HasForeignKey(mp => mp.PrespectionId);

            modelBuilder.Entity<MedicationPrespection>()
                .HasOne(mp => mp.medication)
                .WithMany(m => m.medicationPrespections)
                .HasForeignKey(mp => mp.medicationId);
            modelBuilder.Entity<User>()
        .HasMany(u => u.userRoles)
        .WithOne(ur => ur.user)
        .HasForeignKey(ur => ur.userId);

            modelBuilder.Entity<UserRoles>()
                .HasOne(ur => ur.user)
                .WithMany(u => u.userRoles)
                .HasForeignKey(ur => ur.userId);
        }
    }
}
