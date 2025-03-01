using WebApplication1.DBaccess;

namespace WebApplication1.EntityDTO
{
    public class PrescriptionDTO
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public List<int> MedicationIds { get; set; }

        public DateTime PrescriptionDate { set; get; }
    }
}
