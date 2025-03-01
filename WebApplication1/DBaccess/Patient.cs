using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.DBaccess
{
    public class Patient : Person
    {

        public List<Appointment>? Appointment { get; set; }
        public List<Prescription>? Prescription { get; set; }
        public Patient() : base()
        {
        }

        public Patient(string name,int age,string gender,string ContactNumber, string address) :  base(name, age, gender, ContactNumber,address) 
        {
            Name = name;
            Age = age;
            Gender = gender;
            this.ContactNumber = ContactNumber;

            Address = address;

        }
    }
}