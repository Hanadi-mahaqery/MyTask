using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTask.Models;
using MyTask.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTask.APIs.doctor
{
    [Route("api/doctor/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly MedicinesContext context;
        private readonly ILogger<PrescriptionController> _logger;


        public PrescriptionController(MedicinesContext context, ILogger<PrescriptionController> logger)
        {
            this.context = context;
            _logger = logger;

        }
        // GET: api/<PrescriptionController>
     

        // POST api/<PrescriptionController>
        [HttpPost("add-prescription")]

        public IActionResult AddPrescription([FromBody] Prescription prescription)
        {
            try
            {
                if (prescription != null && ModelState.IsValid)
                {
                    // إضافة الطلب إلى قاعدة البيانات
                    var addRes = context.Prescriptions.Add(prescription);
                    context.SaveChanges();

                    return Ok("prescription added successfully.");
                }
                return BadRequest("Invalid data.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }

        

      
    }
}