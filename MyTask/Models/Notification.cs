using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyTask.Models
{
    public partial class Notification
    {
        [Key]
        [Column("NotificationID")]
        public int NotificationId { get; set; }
        [Column("PatientID")]
        public int? PatientId { get; set; }
        [StringLength(50)]
        public string Message { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime? SentDate { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string? Type { get; set; }

        [ForeignKey(nameof(PatientId))]
        [InverseProperty(nameof(User.Notifications))]
        public virtual User? Patient { get; set; }
    }
}
