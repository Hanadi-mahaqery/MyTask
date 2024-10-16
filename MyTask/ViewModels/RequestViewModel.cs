namespace MyTask.ViewModels
{
    public class RequestViewModel
    {
        public int RequestId { get; set; }

        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int PrescriptionId { get; set; }
        public string PatientName { get; set; }
        public DateTime? RequestDate { get; set; }
        public string Status { get; set; }
      
    }
}
