using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.DBaccess
{
    public class Appointment
    {
        public enum AppointmentStatus
        {
            Scheduled,Completed,Cancelled

        }
        public int AppointmentId {  get; set; }
        public DateTime AppoitmentDate { get; set; }
        public AppointmentStatus Status
        { get; set; }
        public int PatientId { get; set; }
        public Patient patient;
        public int DoctorId { get; set; }
        public Doctor doctor;
        public Appointment() { }

        public Appointment(int PatientId, int DoctorId,DateTime appoitmentDate, AppointmentStatus status)
        {
            this.PatientId = PatientId;
            AppoitmentDate = appoitmentDate;
            this.DoctorId = DoctorId;
            Status = status;
        }
        public Appointment(int PatientId, int DoctorId, DateTime appoitmentDate)
        {
            this.PatientId = PatientId;
            AppoitmentDate = appoitmentDate;
            this.DoctorId = DoctorId;
        }
    }
}
