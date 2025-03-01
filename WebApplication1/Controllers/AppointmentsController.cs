using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Cryptography;
using WebApplication1.DBaccess;
using WebApplication1.EntityDTO;
using WebApplication1.EntityManager;
using static WebApplication1.DBaccess.Appointment;

namespace WebApplication1
{
   
[ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentLogic _appointmentLogic;

        public AppointmentsController(AppointmentLogic appointmentLogic)
        {
            _appointmentLogic = appointmentLogic;
        }

        [Authorize(Roles = "patient,admin,doctor")]

        [HttpPost]
        public IActionResult ScheduleAppointment([FromBody] AppointmentDTO request)
        {
            if (!DateTime.TryParseExact(request.AppointmentDate, "dd MM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime appDate))
            {
                return BadRequest("Invalid date format. Please use 'dd MM yyyy'.");
            }

            var appointment = new Appointment(request.PatientId, request.DoctorId, appDate);
            _appointmentLogic.SceduleAppointment(appointment);

            return Ok("Appointment scheduled successfully.");
        }

        [HttpGet]
        [Authorize(Roles = "admin")] 
        public IActionResult GetAllAppointments()
        {
            var appointments = _appointmentLogic.GetAllAppointment();
            return Ok(appointments);
        }

        [Authorize(Roles = "admin")] 
        [HttpGet("GetAppointmentByID")]
        public IActionResult GetAppointmentByID([FromQuery] int? patientId, [FromQuery] int? doctorId)
        {
            if (patientId == null && doctorId == null)
            {
                return BadRequest("Please provide either patientId or doctorId.");
            }

            var appointments = _appointmentLogic.GetAppointmentByID(patientId, doctorId);
            return Ok(appointments);
        }

        [Authorize(Roles = "admin,doctor")]

        [HttpPut("{id}")]
        public IActionResult UpdateAppointment(int id, [FromBody] AppointmentDTO request)
        {
            if (!DateTime.TryParseExact(request.AppointmentDate, "dd MM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime appDate))
            {
                return BadRequest("Invalid date format. Please use 'dd MM yyyy'.");
            }

            var appointment = new Appointment(request.PatientId, request.DoctorId, appDate, request.Status);
            _appointmentLogic.UpdateAppointment(id,appointment);

            return Ok("Appointment updated successfully.");
        }

        [Authorize(Roles = "patient,admin,doctor")] 

        [HttpDelete("[action]/{id}")]
        public IActionResult CancelAppointment(int id)
        {
            _appointmentLogic.CancelAppointment(id);
            return Ok("Appointment canceled successfully.");
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("[action]/{id}")]
        public IActionResult RemoveAppointment(int id)
        {
            _appointmentLogic.RemoveAppointment(id);
            return Ok("Appointment removed successfully.");
        }
    }
}


