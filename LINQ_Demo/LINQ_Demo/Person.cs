using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Demo
{
    class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public byte Alter { get; set; }
        public decimal Kontostand { get; set; }
    }

    //class PersonenVergleicher : IComparer<Person>
    //{
    //    public int Compare(Person x, Person y)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
