using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyTask.Models
{
    public partial class Prescription
    {
        public Prescription()
        {
            Requests = new HashSet<Request>();
        }

        [Key]
        [Column("PrescriptionID")]
        public int PrescriptionId { get; set; }
        [Column("DoctorID")]
        public int DoctorId { get; set; }
        [Column("PatientID")]
        public int PatientId { get; set; }
        [Column("MedicationID")]
        public int MedicationId { get; set; }
        [StringLength(50)]
        public string Dosage { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        [StringLength(30)]
        public string Frequency { get; set; } = null!;

        [ForeignKey(nameof(DoctorId))]
        [InverseProperty(nameof(User.PrescriptionDoctors))]
        public virtual User? Doctor { get; set; } = null!;
        [ForeignKey(nameof(MedicationId))]
        [InverseProperty("Prescriptions")]
        public virtual Medication? Medication { get; set; } = null!;
        [ForeignKey(nameof(PatientId))]
        [InverseProperty(nameof(User.PrescriptionPatients))]
        public virtual User? Patient { get; set; } = null!;
        [InverseProperty(nameof(Request.Prescription))]
        public virtual ICollection<Request> Requests { get; set; }
    }
}
