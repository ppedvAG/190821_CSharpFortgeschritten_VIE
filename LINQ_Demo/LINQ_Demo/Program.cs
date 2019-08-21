using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> personen = new List<Person>
            {
                new Person{Vorname="Tom",Nachname="Ate",Alter=10,Kontostand=100},
                new Person{Vorname="Anna",Nachname="Nass",Alter=20,Kontostand=200},
                new Person{Vorname="Peter",Nachname="Silie",Alter=30,Kontostand=3000},
                new Person{Vorname="Franz",Nachname="Ose",Alter=40,Kontostand=-4000},
                new Person{Vorname="Klara",Nachname="Fall",Alter=50,Kontostand=5555},
                new Person{Vorname="Martha",Nachname="Pfahl",Alter=60,Kontostand=98765},
                new Person{Vorname="Rainer",Nachname="Zufall",Alter=70,Kontostand=-987654342223423},
                new Person{Vorname="Albert",Nachname="Tross",Alter=80,Kontostand=123456},
                new Person{Vorname="Claire",Nachname="Grube",Alter=90,Kontostand=8643747},
                new Person{Vorname="Anna",Nachname="Bolika",Alter=100,Kontostand=100000000000}
            };

            //// Gib von jeder Person die Vornamen aus:
            //string[] alleVornamen = new string[personen.Count];
            //for (int i = 0; i < personen.Count; i++)
            //{
            //    alleVornamen[i] = personen[i].Vorname;
            //}

            //// Gib von jeder Person, die einen negativen Kontostand hat, den Vornamen aus
            //List<string> alleVornamenMitSchulden = new List<string>();
            //for (int i = 0; i < personen.Count; i++)
            //{
            //    if (personen[i].Kontostand < 0)
            //        alleVornamenMitSchulden.Add(personen[i].Vorname);
            //}

            //// Gib von jeder Person, die einen negativen Kontostand hat, den Vornamen aus, sortiert nach Alter
            //// Gib von den ersten 3 Personen, die einen negativen Kontostand haben, den Vornamen aus, sortiert nach Alter absteigend




            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
