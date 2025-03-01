using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.DBaccess;
using WebApplication1.EntityDTO;

namespace WebApplication1.EntityManager
{
    public class DoctorLogic
    {
        private readonly MyDBContext context ;
       
        public DoctorLogic(MyDBContext dbcontext)
        {
            context = dbcontext;
        }
       

        public  Doctor? GetDoctor(int did)


        {
           
            var patient = context.Doctors.FirstOrDefault(x => x.Id == did);
                return patient;
            }        
        public  void UpdateDoctor(int id,DoctorDTO doctor)
        {

            {

                var newDoctor = context.Doctors.FirstOrDefault(x => x.Id == id);
                newDoctor.Name = doctor.Name;
                newDoctor.Gender = doctor.Gender;
                newDoctor.Address = doctor.Address;
                newDoctor.Age = doctor.Age;
                newDoctor.Email = doctor.Email;
                newDoctor.Specify = doctor.Specify;
                newDoctor.ContactNumber = doctor.ContactNumber;

                context.SaveChanges();
            }
        }


        public  void RemoveDoctor(int DoctorId)
        {

            {
               

                var Doctor = context.Doctors.FirstOrDefault
                    (x => x.Id == DoctorId);
                if (Doctor != null)
                {
                    context.Doctors.Remove(Doctor);
                    context.SaveChanges();
                }
            }
        }
        public  void AddDoctor(DoctorDTO doctor)
        {
            var doc = new Doctor { Name = doctor.Name, Gender = doctor.Gender, Address = doctor.Address, ContactNumber = doctor.ContactNumber, Specify = doctor.Specify, Email = doctor.Email, Age = doctor.Age };

           

                context.Doctors.Add(doc);
                context.SaveChanges();
                Console.WriteLine("Doctor added successfully.");
            }

        public List<Doctor> GetAllDoctors()
        {
            return context.Doctors.ToList();
        }
    }
}
