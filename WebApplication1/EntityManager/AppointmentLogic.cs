using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.DBaccess;
using static WebApplication1.DBaccess.Appointment;

namespace WebApplication1.EntityManager
{
    public class AppointmentLogic
    {
        public readonly MyDBContext context ;
        public AppointmentLogic(MyDBContext dbcontext)
        {
            context = dbcontext;
        }
        public  void CancelAppointment(int id)
        {
          
            var Appointment = context.Appointments.FirstOrDefault
                (x => x.AppointmentId== 
       id);
            if (Appointment != null)
            {
                Appointment.Status = AppointmentStatus.Cancelled;
                context.SaveChanges();
                Console.WriteLine("Appointment Cancelled successfully.");
            }
        }
        public void RemoveAppointment(int Id)
        {
            

            var Appointment = context.Appointments.FirstOrDefault
                (x => x.AppointmentId == 
       Id);
            if (Appointment != null)
            {
                context.Appointments.Remove(Appointment);
                context.SaveChanges();
                Console.WriteLine("Appointment Removed successfully.");
            }
        }
        public  void UpdateAppointment(int Id,Appointment appointment)
        {
            {
              
                var Appointment = context.Appointments.FirstOrDefault(x => x.AppointmentId == 
               Id);
                if (Appointment != null) { 
                context.Appointments.Remove(Appointment);
                context.Appointments.Add(appointment);

                    context.SaveChanges();
                    Console.WriteLine("Appointment Updated successfully.");
                }
                else
                {
                    Console.WriteLine("Appointment not exsist");
                }
            }
        }

        public List<Appointment> GetAppointmentByID(int? pId,int? dId)
        {
            if (pId == null && dId!=null){
                var Appointments = context.Appointments.Where(x => x.PatientId == pId && x.DoctorId == dId).ToList();
                return Appointments;


            }
            else if (pId == null && dId != null)
            {
                var Appointments = context.Appointments.Where(x => x.DoctorId == dId).ToList();
                return Appointments;

            }
            else
            {
                var Appointments = context.Appointments.Where(x => x.PatientId == pId ).ToList();
                return Appointments;

            }

        }
        public  List<Appointment> GetAllAppointment()
        {
            var Appointments = context.Appointments.ToList();
            return Appointments;
        }

        public  void SceduleAppointment(Appointment appointment)
        {


            
                context.Appointments.Add(appointment);
                context.SaveChanges();
                Console.WriteLine("Appointment created successfully.");
            

            
            
        }
    }
}
    

