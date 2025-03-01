using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.DBaccess;

namespace WebApplication1.EntityManager
{
    public class PrescriptionLogic
    {
        private readonly MyDBContext context ;
        public PrescriptionLogic(MyDBContext dbcontext)
        {
            context = dbcontext;
        }

        public void UpdatePrescription(int prescriptionId, int patientId, int doctorId, List<int> medicationIds)
        {
            var prescription = context.Prescriptions
                .FirstOrDefault(p => p.PrescriptionId == prescriptionId);

            if (prescription == null)
            {
                Console.WriteLine("Prescription not found.");
                return;
            }

            prescription.medicationPrespections = context.MedicationPrespections
                .Where(mp => mp.PrespectionId == prescriptionId) 
                .ToList();

            var bill = context.Bills
                .FirstOrDefault(b => b.PrescriptionId == prescriptionId);

            prescription.PatientId = patientId;
            prescription.patient = context.Patients.FirstOrDefault(x => x.Id == patientId);
            prescription.DoctorId = doctorId;
            prescription.doctor = context.Doctors.FirstOrDefault(x => x.Id == doctorId);
            
            var existingMedications = prescription.medicationPrespections
                .Select(mp => mp.medicationId)
                .ToList();

            foreach (var medId in medicationIds)
            {
                if (!existingMedications.Contains(medId))
                {
                    var medication = context.Medications.FirstOrDefault(m => m.MedicationId == medId);
                    if (medication != null && medication.MedicationQuantity > 0)
                    {
                        var medPrescription = new MedicationPrespection
                        {
                            PrespectionId   = prescriptionId, 
                            medicationId= medId,
                            prescription = prescription,
                            medication = medication
                        };

                        context.MedicationPrespections.Add(medPrescription);
                        prescription.medicationPrespections.Add(medPrescription);

                        medication.MedicationQuantity--;

                        if (bill == null)
                        {
                            bill = new Bill
                            {
                                PrescriptionId = prescriptionId,
                                BillPrice = 0
                            };
                            context.Bills.Add(bill);
                        }
                        bill.BillPrice += medication.MedicationAmount;
                    }
                    else
                    {
                        Console.WriteLine($"Medication {medId} is out of stock or not found.");
                    }
                }
            }

            var medicationsToRemove = prescription.medicationPrespections
                .Where(mp => !medicationIds.Contains(mp.medicationId))
                .ToList();

            foreach (var mp in medicationsToRemove)
            {
                var medication = context.Medications.FirstOrDefault(m => m.MedicationId == mp.medicationId);
                if (medication != null)
                {
                    medication.MedicationQuantity++;
                }

                if (bill != null)
                {
                    bill.BillPrice -= medication.MedicationAmount;
                }

                context.MedicationPrespections.Remove(mp);
                prescription.medicationPrespections.Remove(mp);
            }

            context.SaveChanges();
            Console.WriteLine("Prescription updated successfully.");
        }
        public List<Prescription> GetAllPrescriptionss()
        {
            var Prescriptions = context.Prescriptions.ToList();
            return Prescriptions;
        }
        public Prescription GetPresprictionById(int Id)
        {
            var Prescriptions = context.Prescriptions.FirstOrDefault(x=>x.PrescriptionId==Id);
            return Prescriptions;
        }
        public void IssuePrescription(int patientId, int doctorId, List<int> medicationIds)
        {
            var patient = context.Patients.FirstOrDefault(x => x.Id == patientId);
            var doctor = context.Doctors.FirstOrDefault(x => x.Id == doctorId);

            if (patient == null || doctor == null)
            {
                Console.WriteLine("Invalid patient or doctor.");
                return;
            }

            List<Medication> medications = new List<Medication>();
            foreach (var medId in medicationIds)
            {
                var temp = context.Medications.FirstOrDefault(x => x.MedicationId == medId);
                if (temp != null)
                {
                    medications.Add(temp);
                }
            }

            if (medications.Count == 0)
            {
                Console.WriteLine("No valid medications found.");
                return;
            }

            var prescription = new Prescription
            {
                PatientId = patientId,
                DoctorId = doctorId,
                doctor = doctor,
                patient = patient,
                PrescriptionDate = DateTime.Now
            };

            var bill = new Bill
            {
                prescription = prescription,
                BillPrice = 0
            };

            context.Bills.Add(bill);
            context.Prescriptions.Add(prescription);

            foreach (var medication in medications)
            {
                var existingMedication = context.Medications.FirstOrDefault(m => m.MedicationId == medication.MedicationId);

                if (existingMedication != null && existingMedication.MedicationQuantity > 0)
                {
                    bill.BillPrice += existingMedication.MedicationAmount;
                    existingMedication.MedicationQuantity--; 


                    var medPrescription = new MedicationPrespection
                    {
                        PrespectionId = prescription.PrescriptionId,
                        medicationId = existingMedication.MedicationId,
                        prescription = prescription,
                        medication = existingMedication,
                        bill=bill,BillsId=bill.BillId,
                    };

                    context.MedicationPrespections.Add(medPrescription);
                }
                else
                {
                    Console.WriteLine($"Medication {medication.MedicationName} is out of stock.");
                }
            }

            context.SaveChanges();
            Console.WriteLine("Prescription issued successfully with an unpaid bill.");
        }
    }
}