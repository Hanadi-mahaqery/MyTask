using Microsoft.AspNetCore.Mvc;
using MyTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyTask.ViewModels;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTask.APIs.patient
{
    [Route("api/patient/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        // GET: api/<medicationController>
        private readonly MedicinesContext context;
        private readonly ILogger<NotificationsController> _logger;


        public NotificationsController(MedicinesContext context, ILogger<NotificationsController> logger)
        {
            this.context = context;
            _logger = logger;

        }
        // GET: api/<NotificationsController>
      /*[HttpGet]
        public IEnumerable<Notification> Get()
        {
            var notification = context.Notifications.ToList();
            return notification;

        }*/
        // GET api/<NotificationsController>/5
        [HttpGet("notification/{patientId}")]
        public ActionResult<IEnumerable<Notification>> Get(int patientId)
        {
      var  notification = context.Notifications.Where(l => l.PatientId == patientId).ToList();
            return Ok(notification);
        }

     
    }
}
