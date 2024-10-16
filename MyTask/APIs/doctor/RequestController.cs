using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTask.Models;
using MyTask.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTask.APIs.doctor
{
    [Route("api/doctor/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {

        private readonly MedicinesContext context;
        private readonly ILogger<RequestController> _logger;


        public RequestController(MedicinesContext context, ILogger<RequestController> logger)
        {
            this.context = context;
            _logger = logger;

        }
       
     

        // GET api/<RequestController>/5
        [HttpGet("{doctorId}")]
        public ActionResult<IEnumerable<Prescription>> Get(int doctorId)
        {

            try
            {
                var Prescript = context.Requests
                    .Include(s => s.Patient)
                    .Where(s => s.DoctorId == doctorId && s.Status=="Pending")

                    .Select(s => new RequestViewModel
                    {
                        RequestId = s.RequestId,
                        PrescriptionId= (int)s.PrescriptionId,
                        PatientId = (int)s.PatientId,
                        DoctorId = (int)s.DoctorId,
                       PatientName= s.Patient.FullName,
                       RequestDate= s.RequestDate,
                       Status = s.Status,


                    })
                    .ToList();

                return Ok(Prescript);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving students: {Message}", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching students.");
            }
        }

     
    }
}
