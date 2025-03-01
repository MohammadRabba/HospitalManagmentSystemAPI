using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.DBaccess
{
    public class Doctor:Person
    {public string Email { get;set;}
        public string Specify { get;set;}

        public List<Prescription> Prescription { get; set; }
        public List<Appointment> Appointment{ get; set; }
        public Doctor() { }
        public Doctor(string name, int age, string gender, string ContactNumber, string Email,string specify,string address) : base(name, age, gender, ContactNumber, address)
        {
            Name = name;
            Age = age;
            Gender = gender;
            this.ContactNumber = ContactNumber;
            this.Email = Email;
            Specify = specify;
            Address = address;
        }

    }
}
