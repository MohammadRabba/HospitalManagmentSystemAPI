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
    public class PatientLogic
    {
        public readonly MyDBContext context;
        

        public PatientLogic(MyDBContext dbcontext)
        {
            context = dbcontext;
        }

        public  List<Patient> GetAllPatient()


        { 
        
            return context.Patients.ToList();
        }
        public  Patient? GetPatient(int patId)


        {

            return context.Patients.FirstOrDefault(x => x.Id == patId)
 ;        }
        public  void UpdatePatient(int id,PatientDTO patient)
        {

            {
             
                var newPatient = context.Patients.FirstOrDefault(x => x.Id ==id);
                newPatient.Name = patient.Name;
                newPatient.Gender = patient.Gender;
                newPatient.Address = patient.Address;
                newPatient.Age = patient.Age;
                newPatient.ContactNumber = patient.ContactNumber;

                context.SaveChanges();
            }
        }


        public  void RemovePatient(int patId)
        {

            
              
                    var patient = context.Patients.FirstOrDefault
                        (x => x.Id == 
               patId);
                if (patient != null)
                {
                    context.Patients.Remove(patient);
                    context.SaveChanges();
                    //Console.WriteLine("Patient Removed successfully.");
                
            }
        }
        public  void AddPatient(PatientDTO patients)
        {
            var patient = new Patient { Name = patients.Name, Address = patients.Address, Gender = patients.Gender, Age = patients.Age, ContactNumber = patients.ContactNumber, };
          
                context.Patients.Add(patient);
                context.SaveChanges();
            
        }
    }
}
