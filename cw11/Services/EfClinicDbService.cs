using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw11.DTOs;
using cw11.Models;
using Microsoft.EntityFrameworkCore;

namespace cw11.Services
{
    public class EfClinicDbService : IClinicDbService
    {

        private readonly ClinicDbContext db;

        public EfClinicDbService(ClinicDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<DoctorDTO> GetDoctors()
        {
            var doctors = db.Doctors.ToList();
            var resp = new List<DoctorDTO>();

            foreach (Doctor d in doctors)
            {
                resp.Add(new DoctorDTO(d));
            }

            return resp;
        }

        public DoctorDTO GetDoctor(int id)
        {
            return new DoctorDTO(db.Doctors.Find(id));
        }

        public Doctor AddDoctor(Doctor doctor)
        {
            db.Attach(doctor);
            db.Entry(doctor).State = EntityState.Added;
            db.SaveChanges();
            return doctor;
        }

        public void UpdateDoctor(Doctor doctor)
        {
            db.Attach(doctor);
            db.Entry(doctor).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteDoctor(int id)
        {
            var doctor = new Doctor
            {
                IdDoctor = id
            };
            db.Attach(doctor);
            db.Remove(doctor);
            db.SaveChanges();
        }
    }
}
