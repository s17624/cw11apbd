using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw11.Models;

namespace cw11.DTOs
{
    public class DoctorDTO
    {
        public int IdDoctor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public DoctorDTO(Doctor doctor)
        {
            IdDoctor = doctor.IdDoctor;
            FirstName = doctor.FirstName;
            LastName = doctor.LastName;
            Email = doctor.Email;
        }
    }
}
