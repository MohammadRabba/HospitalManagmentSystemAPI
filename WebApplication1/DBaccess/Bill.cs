using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.DBaccess
{
    public class Bill
    {
        public enum BillStatus
        {
            Unpaid,Paid, 

        }
        public int BillId {  get; set; }
        public BillStatus Status { get; set; }
            public int PrescriptionId { get; set; }
        public Prescription prescription { get; set; }
        public DateTime BillDate {  get; set; }
        public decimal BillPrice { get; set; } 

        public Bill()
        {
        }
        public Bill( int prescriptionId, Prescription prescription)
        {
            Status = BillStatus.Unpaid;
            
            PrescriptionId = prescriptionId;
            BillDate = DateTime.Now;
            this.prescription = prescription;
            BillPrice = 0;
            
            }
        }
    }
