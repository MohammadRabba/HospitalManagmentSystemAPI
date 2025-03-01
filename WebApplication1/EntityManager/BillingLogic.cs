using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.DBaccess;
using static WebApplication1.DBaccess.Bill;


namespace WebApplication1.EntityManager
{
    public class BillingLogic
    {
        private readonly MyDBContext context ;

        public BillingLogic(MyDBContext dbcontext)
        {
            context = dbcontext;
        }

        public void updateBill(int billId, decimal price, int status)
        {
            var bill = context.Bills.FirstOrDefault(x => x.BillId == billId);

            if (bill == null)
            {
                Console.WriteLine($"Bill with ID {billId} not found.");
            }

            bill.BillPrice = price;

            if (status == 0)
            {
                bill.Status = BillStatus.Unpaid;
            }
            else if (status == 1)
            {
                bill.Status = BillStatus.Paid;
            }
            else
            {
                Console.WriteLine("Invalid status input. Status must be 0 (Unpaid) or 1 (Paid).");
            }

            context.SaveChanges();
            Console.WriteLine("Bill updated successfully.");
        }

        public  List<Bill> ViewAllBillings()
        {
           var Bills = context.Bills.ToList();
            return Bills;
        }
        public List<Bill> ViewAllBillingsbyId(int patientId)
        {
            var pres = context.Prescriptions.Where(x => x.PatientId == patientId).ToList();
            var Bills = new List<Bill>();
            foreach(var prespriction in pres)
            {
                 Bills.Add(context.Bills.FirstOrDefault(x => x.prescription.PrescriptionId == prespriction.PrescriptionId));

            }
            return Bills;
        }
    }
}
