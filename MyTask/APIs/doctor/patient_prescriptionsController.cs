using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTask.Models;
using MyTask.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTask.APIs.doctor
{
    [Route("api/doctor/[controller]")]
    [ApiController]
    public class patient_prescriptionsController : ControllerBase
    {
        private readonly MedicinesContext context;
        private readonly ILogger<patient_prescriptionsController> _logger;


        public patient_prescriptionsController(MedicinesContext context, ILogger<patient_prescriptionsController> logger)
        {
            this.context = context;
            _logger = logger;

        }
     
     

        // GET api/<patient_prescriptions>/5
        [HttpGet("patient_Prescript/{patientId}")]
        public ActionResult<IEnumerable<Prescription>> Get(int patientId)
        {

            try
            {
                var Prescript = context.Prescriptions
                    .Include(s => s.Medication)
                    .Include(s => s.Patient)
                    .Include(s => s.Doctor)
                    .Where(s => s.PatientId == patientId)

                    .Select(s => new PrescriptionViewModel
                    {
                        PrescriptionId = s.PrescriptionId,
                        MedicationId = s.MedicationId,
                        PatientId = s.PatientId,
                        DoctorId = s.DoctorId,
                        Dosage = s.Dosage,
                        Frequency = s.Frequency,
                        MedicationName = s.Medication.Name,
                        PatientName = s.Patient.FullName,
                        DoctorName = s.Doctor.FullName,


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
