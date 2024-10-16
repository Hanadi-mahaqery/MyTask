using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyTask.Models
{
    public partial class Request
    {
        [Key]
        [Column("RequestID")]
        public int RequestId { get; set; }
        [Column("PatientID")]
        public int PatientId { get; set; }
        [Column("PrescriptionID")]
        public int PrescriptionId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? RequestDate { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? Status { get; set; }
        [Column("DoctorID")]
        public int? DoctorId { get; set; }

        [ForeignKey(nameof(DoctorId))]
        [InverseProperty(nameof(User.RequestDoctors))]
        public virtual User? Doctor { get; set; }
        [ForeignKey(nameof(PatientId))]
        [InverseProperty(nameof(User.RequestPatients))]
        public virtual User? Patient { get; set; } = null!;
        [ForeignKey(nameof(PrescriptionId))]
        [InverseProperty("Requests")]
        public virtual Prescription? Prescription { get; set; } = null!;
    }
}
