using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyTask.Models
{
    public partial class Medication
    {
        public Medication()
        {
            Prescriptions = new HashSet<Prescription>();
        }

        [Key]
        [Column("MedicationID")]
        public int MedicationId { get; set; }
        [StringLength(20)]
        public string Name { get; set; } = null!;
        [StringLength(50)]
        public string Dosage { get; set; } = null!;
        [StringLength(50)]
        public string Description { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }

        [InverseProperty(nameof(Prescription.Medication))]
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
