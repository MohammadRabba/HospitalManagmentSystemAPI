using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.DBaccess
{
    public class Person
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public Person()
        {
        }
        public Person(string Name, int Age, string gender, string ContactNumber, string address)
        {
            this.Name = Name;
            this.Age = Age;
            Gender = gender;
            this.ContactNumber = ContactNumber;
            Address = address;
        }
    }
}
