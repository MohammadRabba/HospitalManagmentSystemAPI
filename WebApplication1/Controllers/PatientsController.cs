using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.DBaccess;
using WebApplication1.EntityDTO;
using WebApplication1.EntityManager;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly PatientLogic patientLogic ;
        public PatientsController(PatientLogic patientLogic)
        {
            this.patientLogic = patientLogic;
        }


        [HttpPost]
        [Authorize(Roles = "admin,doctor")]

        public IActionResult RegisterPatient([FromBody] PatientDTO patient)
        {

            {

                patientLogic.AddPatient(patient);
                return Created();
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin,doctor")]


        public List<Patient> ViewAllPatient()


        {
            return patientLogic.GetAllPatient();
        }
        [HttpGet("{Id}")]
        [Authorize(Roles = "patient,admin,doctor")]


        public Patient? GetPatient(int Id)
        {
            if (User.FindFirst(ClaimTypes.Role)?.Value == "patient") {
                Id = int.Parse(User.FindFirst("PatientId")?.Value);
            }

            return patientLogic.GetPatient(Id);
        }

       
      
        [HttpPut("{Id}")]
        [Authorize(Roles = "patient,admin,doctor")]

        public IActionResult UpdatePatientProfile(int Id, [FromBody] PatientDTO patient)
        {
          if (User.FindFirst(ClaimTypes.Role)?.Value == "patient") {
                Id = int.Parse(User.FindFirst("PatientId")?.Value);
            }
       

            patientLogic.UpdatePatient(Id,patient);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,doctor")]

        public IActionResult RemovePatient(int id)
        {

            { 
                patientLogic.RemovePatient(id);
                return Accepted(id);
            }
        }
       
    }
 }
