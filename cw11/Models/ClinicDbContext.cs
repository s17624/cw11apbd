using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace cw11.Models
{
    public class ClinicDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

        public ClinicDbContext()
        {

        }

        public ClinicDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Prescription_Medicament>()
                .HasKey((e => new {e.IdMedicament, e.IdPrescription}));

            var doctors = new List<Doctor>();
            var d1 = new Doctor
            {
                IdDoctor = 1,
                FirstName = "Zbigniew",
                LastName = "JSON",
                Email = "zbigniew@json.pl"
            };
            doctors.Add(d1);

            var d2 = new Doctor
            {
                IdDoctor = 2,
                FirstName = "Lekarz",
                LastName = "Lekarski",
                Email = "lekarz@lekarski.pl"
            };
            doctors.Add(d2);


            var patients = new List<Patient>();
            var p1 = new Patient
            {
                IdPatient = 1,
                FirstName = "Pacjent",
                LastName = "Pacjent",
                Birthdate = DateTime.Now.AddYears(-30)
            };

            patients.Add(p1);
            var p2 = new Patient
            {
                IdPatient = 2,
                FirstName = "Chory",
                LastName = "Czlowiek",
                Birthdate = DateTime.Now.AddYears(-40)
            };
            patients.Add(p2);

            var p3 = new Patient
            {
                IdPatient = 3,
                FirstName = "Jan",
                LastName = "Kowalski",
                Birthdate = DateTime.Now.AddYears(-50)
            };
            patients.Add(p3);

            var prescriptions = new List<Prescription>();
            var pr1 = new Prescription
            {
                IdPrescription = 1,
                Date = DateTime.Now.AddDays(-30),
                DueDate = DateTime.Now.AddDays(1),
                IdPatient = 1,
                IdDoctor = 1
            };
            prescriptions.Add(pr1);

            var pr2 = new Prescription
            {
                IdPrescription = 2,
                Date = DateTime.Now.AddDays(-15),
                DueDate = DateTime.Now.AddDays(1),
                IdPatient = 2,
                IdDoctor = 1
            };
            prescriptions.Add(pr2);

            var pr3 = new Prescription
            {
                IdPrescription = 3,
                Date = DateTime.Now,
                DueDate = DateTime.Now.AddDays(15),
                IdPatient = 3,
                IdDoctor = 2
            };
            prescriptions.Add(pr3);

            var medicaments = new List<Medicament>();
            var m1 = new Medicament
            {
                IdMedicament = 1,
                Name = "Rutinoscorbin",
                Description = "Lek na niewyraznosc",
                Type = "tabletki"
            };
            medicaments.Add(m1);

            var m2 = new Medicament
            {
                IdMedicament = 2,
                Name = "Piachopiruna",
                Description = "Lek na brak bolu glowy",
                Type = "tabletki"
            };
            medicaments.Add(m2);

            var prescriptionMedicaments = new List<Prescription_Medicament>();
            var pm1 = new Prescription_Medicament
            {
                IdMedicament = 1,
                IdPrescription = 3,
                Dose = 1,
                Details = "2x dziennie"
            };

            prescriptionMedicaments.Add(pm1);
            var pm2 = new Prescription_Medicament
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Dose = 2,
                Details = "1x dziennie"
            };

            prescriptionMedicaments.Add(pm2);
            var pm3 = new Prescription_Medicament
            {
                IdMedicament = 1,
                IdPrescription = 2,
                Dose = 1,
                Details = "2x dziennie"
            };

            prescriptionMedicaments.Add(pm3);
            var pm4 = new Prescription_Medicament
            {
                IdMedicament = 2,
                IdPrescription = 3,
                Dose = 1,
                Details = "1x dziennie"
            };
            prescriptionMedicaments.Add(pm4);

            modelBuilder.Entity<Doctor>().HasData(doctors);
            modelBuilder.Entity<Patient>().HasData(patients);
            modelBuilder.Entity<Prescription>().HasData(prescriptions);
            modelBuilder.Entity<Medicament>().HasData(medicaments);
            modelBuilder.Entity<Prescription_Medicament>().HasData(prescriptionMedicaments);
        }
    }
}
