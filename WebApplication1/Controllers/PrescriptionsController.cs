using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.EntityDTO;
using WebApplication1.EntityManager;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionsController : ControllerBase
{
    private readonly PrescriptionLogic _prescriptionLogic;

    public PrescriptionsController(PrescriptionLogic prescriptionLogic)
    {
        _prescriptionLogic = prescriptionLogic;
    }

            [Authorize(Roles = "patient,admin")]

    [HttpGet]

    public IActionResult GetAllPrescriptions()
    {
        var prescriptions = _prescriptionLogic.GetAllPrescriptionss();
        return Ok(prescriptions);
    }
    [Authorize(Roles = "patient,admin")]


    [HttpGet("{id}")]

    public IActionResult GetPrescriptionById(int id)
    {
        var prescription = _prescriptionLogic.GetPresprictionById(id);
        if (prescription == null)
        {
            return NotFound("Prescription not found.");
        }
        return Ok(prescription);
    }
    [Authorize(Roles = "patient,admin,doctor")]


    [HttpPost]

    public IActionResult IssuePrescription([FromBody] PrescriptionDTO request)
    {
        if (request == null || request.PatientId <= 0 || request.DoctorId <= 0 || request.MedicationIds == null || request.MedicationIds.Count == 0)
        {
            return BadRequest("Invalid prescription data.");
        }

        _prescriptionLogic.IssuePrescription(request.PatientId, request.DoctorId, request.MedicationIds);
        return Ok("Prescription issued successfully.");
    }
    [Authorize(Roles = "admin")]

    [HttpPut("{id}")]

    public IActionResult UpdatePrescription(int id, [FromBody] PrescriptionDTO request)
    {
        if (request == null || request.PatientId <= 0 || request.DoctorId <= 0 || request.MedicationIds == null || request.MedicationIds.Count == 0)
        {
            return BadRequest("Invalid prescription data.");
        }

        _prescriptionLogic.UpdatePrescription(id, request.PatientId, request.DoctorId, request.MedicationIds);
        return Ok("Prescription updated successfully.");
    }
}
