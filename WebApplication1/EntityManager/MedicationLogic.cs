using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.DBaccess;

namespace WebApplication1.EntityManager
{
   public class MedicationLogic
    {
        private readonly MyDBContext context ;
      public MedicationLogic(MyDBContext dbcontext)
        {
            context = dbcontext;
        }

        public void DeleteMadication(int medId)
        {
            Console.Write("Enter Madication Id: ");

            var Madication = context.Medications.FirstOrDefault
                (x => x.MedicationId == medId);
            if (Madication != null)
            {
                context.Medications.Remove(Madication);
                context.SaveChanges();
                Console.WriteLine("Medication Removed successfully.");
            }
        }

        public void UpdateMedication(Medication medication)
        {
            
            var Medication = context.Medications.FirstOrDefault(x => x.MedicationId == medication.MedicationId);
            context.Medications.Remove(Medication);
            context.Medications.Add(medication);
            context.SaveChanges();
            Console.WriteLine("Medication Updated successfully.");
        }

        public List<Medication> GetAllMadication()
        {
            var Medications = context.Medications.ToList();
            return Medications;
        }

public List<Medication> searchMedication(int medId)
    {
        {
            var medicationPrescriptions = context.MedicationPrespections
                .Where(x => x.medicationId == medId)
                .ToList();

            var medications = new List<Medication>();

            foreach (var medicationPrescription in medicationPrescriptions)
            {
                var prescription = context.Prescriptions.FirstOrDefault(x => x.PrescriptionId == medicationPrescription.PrespectionId);

                if (prescription != null) 
                {
                    var patient = context.Patients.FirstOrDefault(x => x.Id == prescription.PatientId);
                    var doctor = context.Patients.FirstOrDefault(x => x.Id == prescription.DoctorId);
                    var medication = context.Medications.FirstOrDefault(x => x.MedicationId == medicationPrescription.medicationId);

                    if (medication != null) 
                    {
                        medications.Add(medication); 

                    
                    }
                }
            }
            return medications;
        }
    }
    public void AddMadication(Medication medication)
        {
            {
                

                context.Medications.Add(medication);
                context.SaveChanges();
                Console.WriteLine("Medication added successfully.");
            }
        }
    }
    }

