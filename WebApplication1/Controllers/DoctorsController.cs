using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.DBaccess;
using WebApplication1.EntityDTO;
using WebApplication1.EntityManager;

namespace WebApplication1
{
    [ApiController]

    [Route("api/[controller]")]
    public class DoctorsController:ControllerBase
    {
        private readonly DoctorLogic doctorLogic;
        public DoctorsController(DoctorLogic doctorLogic)
        {
            this.doctorLogic = doctorLogic;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]

        public List<Doctor> GetAllDoctors()


        {
            return doctorLogic.GetAllDoctors();
        }
        [HttpGet("{Id}")]
        [Authorize(Roles = "admin")]

        public Doctor? GetDoctor(int Id)


        {
            return doctorLogic.GetDoctor(Id);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]

        public IActionResult UpdateDoctor(int id, [FromBody] DoctorDTO pat)
        {
         

            doctorLogic.UpdateDoctor(id,pat);
            return NoContent();

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]

        public IActionResult RemoveDoctor(int id)
        {

            {
                doctorLogic.RemoveDoctor(id);
                return Accepted(id);
            }
        }
        [HttpPost]
        [Authorize(Roles = "admin")]

        public IActionResult AddDoctor([FromBody] DoctorDTO Doctor)
        {

            {

                doctorLogic.AddDoctor(Doctor);
                return Created();
            }
        }
    }
}
