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
    public class medicationController : ControllerBase
    {
        // GET: api/<medicationController>
        private readonly MedicinesContext context;
        private readonly ILogger<medicationController> _logger;


        public medicationController(MedicinesContext context, ILogger<medicationController> logger)
        {
            this.context = context;
            _logger = logger;

        }
        /*
        [HttpGet]
        public ActionResult<IEnumerable<Prescription>> Get()
        {
            try
            {
                var Prescript = context.Prescriptions
                    .Include(s => s.Medication)
                    .Include(s => s.Patient)
                    .Select(s => new PrescriptionViewModel
                    {
                       PrescriptionId = s.PrescriptionId,
                       PatientId= (int)s.PatientId,
                       Dosage= s.Dosage,
                       Frequency= s.Frequency,
                       MedicationName=s.Medication.Name,
                       PatientName=s.Patient.FullName,


                    })
                    .ToList();

                return Ok(Prescript);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving students: {Message}", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching students.");
            }
        }*/

        // GET api/<medicationController>/5
        [HttpGet("Prescript/{patientId}")]

        public ActionResult<IEnumerable<Prescription>> Get(int patientId)
        {
            try
            {
                var Prescript = context.Prescriptions
                       .Include(s => s.Medication)
                       .Include(s => s.Patient)
                       .Include(s => s.Doctor)
                       .Where(s => s.PatientId== patientId)
                       .Select(s => new PrescriptionViewModel
                       {
                           PrescriptionId = s.PrescriptionId,
                           MedicationId = s.MedicationId,
                           PatientId = (int)s.PatientId,
                           DoctorId = s.DoctorId,
                           DoctorName= s.Doctor.FullName,
                           Dosage = s.Dosage,
                           Frequency = s.Frequency,
                           MedicationName = s.Medication.Name,
                           PatientName = s.Patient.FullName,
                       })
                    .ToList();

                if (Prescript == null)
                {
                    return NotFound();
                }

                return Ok(Prescript);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving student by ID: {Message}", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the student.");
            }
        }

        
    }
}
