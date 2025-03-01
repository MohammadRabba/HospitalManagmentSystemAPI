using static WebApplication1.DBaccess.Appointment;

namespace WebApplication1.EntityDTO
{
    public class AppointmentDTO
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string AppointmentDate { get; set; } 
        public AppointmentStatus Status { get; set; } = 0;
    }
}
