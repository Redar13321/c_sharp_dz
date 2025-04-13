using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.classes
{
    public class Mail
    {
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Building { get; set; }
        public string Apartment { get; set; }
        public string Message { get; set; }

        public string GetAddress()
        {
            return $"{ZipCode}, {City}, {Street}, д.{House}, корп.{Building}, кв.{Apartment}";
        }
    }
}
