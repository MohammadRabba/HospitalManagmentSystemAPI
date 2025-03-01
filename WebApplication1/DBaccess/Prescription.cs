using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.DBaccess
{
    public class Prescription
    {
        public int PrescriptionId {  get; set; }
        public int PatientId { get; set; }
        public Patient patient;
        public int DoctorId { get; set; }
        public Doctor doctor;
        public   List<MedicationPrespection>medicationPrespections { get; set; }

        public DateTime PrescriptionDate { set; get; }

        public Prescription(int PatientId,int DoctorId,Patient patient,Doctor doctor)
        {
            this.PatientId = PatientId;
            this.DoctorId = DoctorId;
            this.patient = patient;this.doctor = doctor;
            PrescriptionDate = DateTime.Now;
        }
        public Prescription(int PatientId, int DoctorId)
        {
            this.PatientId = PatientId;
            this.DoctorId = DoctorId;
            PrescriptionDate = DateTime.Now;
        }
        public Prescription()
        {
        }
    }
}
