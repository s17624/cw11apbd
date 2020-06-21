using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw11.DTOs;
using cw11.Models;

namespace cw11.Services
{
    public interface IClinicDbService
    {
        IEnumerable<DoctorDTO> GetDoctors();
        DoctorDTO GetDoctor(int id);
        Doctor AddDoctor(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
        void DeleteDoctor(int id);
    }
}
