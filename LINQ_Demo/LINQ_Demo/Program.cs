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


            // SELECT -> Wert zurückgeben
            // Gib von jeder Person die Vornamen aus:

            // Ohne Lambda
            string[] alleVornamen = personen.Select(Filterfunktion).ToArray();
            // Mit Lambda
            List<string> alleVornamen2 = personen.Select(x => x.Vorname).ToList();


            // WHERE -> Filtern
            // Gib von jeder Person, die einen negativen Kontostand hat, den Vornamen aus

            string[] alleVornamenMitSchulden = personen.Where(x => x.Kontostand < 0)
                                                       .Select(x => x.Vorname)
                                                       .ToArray();

            // ORDERBY, ORDERBYDESCENDING
            // Gib von jeder Person, die einen negativen Kontostand hat, den Vornamen aus, sortiert nach Alter

            List<string> negativNachAlter = personen.Where(x => x.Kontostand < 0)
                                                    .OrderByDescending(x => x.Alter)
                                                    .Select(x => x.Vorname)
                                                    .ToList();
            // SUM

            decimal alles = personen.Sum(x => x.Kontostand);
            decimal gesamtSchulden = personen.Where(x => x.Kontostand < 0)
                                             .Sum(x => x.Kontostand);
            // Min, Max, Average usw....

            // Elemente herausnehmen: TAKE
            // Beispiel: Die reichsten 3 Personen

            Person[] dieTop3 = personen.OrderByDescending(x => x.Kontostand)
                                       .Take(3)
                                       .ToArray();

            // Elemente auslassen und alle danach nehmen: SKIP

            Person[] alleAusserTop3 = personen.OrderByDescending(x => x.Kontostand)
                           .Skip(3)
                           .ToArray();

            Person topSchuldner = personen.OrderBy(x => x.Kontostand).First();

            if (personen.Any(x => x.Kontostand == 99))
                ;// irgendeine Person hat den Kontostand 99

            

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        private static string Filterfunktion(Person item)
        {
            return item.Vorname;
        }
        private static string Filterfunktion2(Person x) => x.Vorname;
    }
}
