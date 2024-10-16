using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyTask.Models
{
    public partial class User
    {
        public User()
        {
            Notifications = new HashSet<Notification>();
            PrescriptionDoctors = new HashSet<Prescription>();
            PrescriptionPatients = new HashSet<Prescription>();
            RequestDoctors = new HashSet<Request>();
            RequestPatients = new HashSet<Request>();
        }

        [Key]
        [Column("UserID")]
        public int UserId { get; set; }
        public int Roles { get; set; }
        [StringLength(50)]
        public string FullName { get; set; } = null!;
        [StringLength(30)]
        public string? Email { get; set; }
        [StringLength(10)]
        public string? Password { get; set; }
        [StringLength(9)]
        public string PhoneNumber { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [InverseProperty(nameof(Notification.Patient))]
        public virtual ICollection<Notification> Notifications { get; set; }
        [InverseProperty(nameof(Prescription.Doctor))]
        public virtual ICollection<Prescription> PrescriptionDoctors { get; set; }
        [InverseProperty(nameof(Prescription.Patient))]
        public virtual ICollection<Prescription> PrescriptionPatients { get; set; }
        [InverseProperty(nameof(Request.Doctor))]
        public virtual ICollection<Request> RequestDoctors { get; set; }
        [InverseProperty(nameof(Request.Patient))]
        public virtual ICollection<Request> RequestPatients { get; set; }
    }
}
