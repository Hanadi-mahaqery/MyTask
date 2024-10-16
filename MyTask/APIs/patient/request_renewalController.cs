using Microsoft.AspNetCore.Mvc;
using MyTask.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTask.APIs.patient
{
    [Route("api/patient/[controller]")]
    [ApiController]
    public class request_renewalController : ControllerBase
    {
        private readonly MedicinesContext context;
        private readonly ILogger<request_renewalController> _logger;

        public request_renewalController(MedicinesContext context, ILogger<request_renewalController> logger)
        {
            this.context = context;
            _logger = logger;

        }
       

      
            // POST: api/patient/request-renewal
        [HttpPost("request-renewal")]
        public IActionResult RequestPrescriptionRenewal([FromBody] Request request)
        {
            try
            {
                if (request != null && ModelState.IsValid)
                {
                    // إضافة الطلب إلى قاعدة البيانات
                    var addRes = context.Requests.Add(request);
                    context.SaveChanges();

                    return Ok("Request added successfully.");
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
