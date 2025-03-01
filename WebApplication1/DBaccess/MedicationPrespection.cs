using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.DBaccess
{
    public class MedicationPrespection
    {
        


        public int PrespectionId;
        public Prescription prescription;
        public Medication medication;
        public int medicationId;
        public int BillsId;
        public Bill bill;
        public MedicationPrespection()
        {
        }
        public MedicationPrespection(int prespectionId, Prescription prescription, int medicationId,Medication medication, int billsId, Bill bill)
        {
            PrespectionId = prespectionId;
            this.prescription = prescription;
            this.medication = medication;
            this.medicationId = medicationId;
            BillsId = billsId;
            this.bill = bill;
            
        }
    }
}