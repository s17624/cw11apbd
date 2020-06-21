using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw11.DTOs;
using cw11.Models;
using cw11.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cw11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicDbService service;

        public ClinicController(IClinicDbService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(service.GetDoctors());
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctor(int id)
        {
            return Ok(service.GetDoctor(id));
        }

        [HttpPost]
        public IActionResult CreateDoctor(Doctor doctor)
        {
            return Ok(new DoctorDTO(service.AddDoctor(doctor)));
        }

        [HttpPut]
        public IActionResult UpdateDoctor(Doctor doctor)
        {
            service.UpdateDoctor(doctor);
            return Ok("Doctor updated.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            service.DeleteDoctor(id);
            return Ok("Record deleted.");
        }

    }
}