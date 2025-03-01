using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.DBaccess
{
    public class Medication
    {
        public int MedicationId {  get; set; }
        public string MedicationName { get; set; }
        public int MedicationQuantity { get; set; }
        public decimal MedicationAmount { get; set; }
        public virtual List<MedicationPrespection> medicationPrespections { get; set; } 

        public Medication() { }
        public Medication( string medicationName, int medicationQuantity, decimal medicationAmount)
        {
            MedicationName = medicationName;
            MedicationQuantity = medicationQuantity;
            MedicationAmount = medicationAmount;
        }
    }
}
