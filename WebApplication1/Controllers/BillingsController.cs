using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.EntityDTO;
using WebApplication1.EntityManager;

[ApiController]
[Route("api/[controller]")]
public class BillingsController : ControllerBase
{
    private readonly BillingLogic _billingLogic;

    public BillingsController(BillingLogic billingLogic)
    {
        _billingLogic = billingLogic;
    }

    [Authorize(Roles = "patient,admin,doctor")]

    [HttpGet]
    public IActionResult ViewAllBillings()
    {
        var bills = _billingLogic.ViewAllBillings();
        return Ok(bills);
    }

    [Authorize(Roles = "admin")]
    [HttpPut("{id}")]
    public IActionResult UpdateBill(int id, [FromBody] BillDTO request)
    {
        if (request.Status < 0 || request.Status > 1)
        {
            return BadRequest("Invalid status. Status must be 0 (Unpaid) or 1 (Paid).");
        }

        _billingLogic.updateBill(id, request.BillPrice, request.Status);
        return Ok("Bill updated successfully.");
    }
    [HttpGet("[action]")]
    [Authorize(Roles = "patient,admin,doctor")]

    public IActionResult ViewAllBillingsbyId([FromQuery] int id)
    {
        var bills = _billingLogic.ViewAllBillingsbyId(id);
        return Ok(bills);
    }
}