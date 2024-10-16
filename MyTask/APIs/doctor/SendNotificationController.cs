using Microsoft.AspNetCore.Mvc;
using MyTask.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTask.APIs.doctor
{
    [Route("api/doctor/[controller]")]
    [ApiController]
    public class SendNotificationController : ControllerBase
    {

        private readonly MedicinesContext context;
        private readonly ILogger<SendNotificationController> _logger;


        public SendNotificationController(MedicinesContext context, ILogger<SendNotificationController> logger)
        {
            this.context = context;
            _logger = logger;

        }

        // POST api/<SendNotificationController>
        [HttpPost("add-prescription")]

        public IActionResult AddPrescription([FromBody] Notification notify)
        {
            try
            {
                if (notify != null && ModelState.IsValid)
                {
                    // إضافة الطلب إلى قاعدة البيانات
                    var addRes = context.Notifications.Add(notify);
                    context.SaveChanges();

                    return Ok("Notification added successfully.");
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
