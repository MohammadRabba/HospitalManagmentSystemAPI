using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.EntityDTO;
using WebApplication1.EntityManager;

[ApiController]
[Route("api/[controller]")]
public class MedicationsController : ControllerBase
{
    private readonly MedicationLogic _medicationLogic;

    public MedicationsController(MedicationLogic medicationLogic)
    {
        _medicationLogic = medicationLogic;
    }

    [Authorize(Roles = "admin")]
    [HttpGet]
    public IActionResult GetAllMedications()
    {
        var medications = _medicationLogic.GetAllMadication();
        return Ok(medications);
    }

    [Authorize(Roles = "admin")]
    [HttpGet("{id}")]
    public IActionResult GetMedicationById(int id)
    {
        var medication = _medicationLogic.searchMedication(id);
        if (medication == null)
        {
            return NotFound("Medication not found.");
        }
        return Ok(medication);
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public IActionResult AddMedication([FromBody] MedicationDTO med)
    {
        if (med == null || string.IsNullOrEmpty(med.MedicationName) || med.MedicationAmount <= 0 || med.MedicationQuantity < 0)
        {
            return BadRequest("Invalid medication data.");
        }

        var medication = new WebApplication1.DBaccess.Medication(med.MedicationName, med.MedicationQuantity, med.MedicationAmount);
        _medicationLogic.AddMadication(medication);
        return Ok("Medication added successfully.");
    }

    [Authorize(Roles = "admin")]
    [HttpPut("{id}")]
    public IActionResult UpdateMedication(int id, [FromBody] MedicationDTO request)
    {
        if (request == null || string.IsNullOrEmpty(request.MedicationName) || request.MedicationAmount <= 0 || request.MedicationQuantity < 0)
        {
            return BadRequest("Invalid medication data.");
        }

        var medication = new WebApplication1.DBaccess.Medication(request.MedicationName, request.MedicationQuantity, request.MedicationAmount);
        _medicationLogic.UpdateMedication(medication);
        return Ok("Medication updated successfully.");
    }

    [Authorize(Roles = "admin")]
    [HttpDelete("{id}")]
    public IActionResult DeleteMedication(int id)
    {
        _medicationLogic.DeleteMadication(id);
        return Ok("Medication deleted successfully.");
    }
}
