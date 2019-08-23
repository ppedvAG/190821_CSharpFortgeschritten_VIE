using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialisierung
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, }; // Kontostand = 100 };
            Person p2 = new Person { Vorname = "Tom2", Nachname = "Ate", Alter = 10, }; // Kontostand = 100 };
            Person p3 = new Person { Vorname = "Tom3", Nachname = "Ate", Alter = 10, }; //Kontostand = 100 };

            Person[] personen = { p1, p2, p3 };

            // Binär
            //BinaryFormatter formatter = new BinaryFormatter();
            //FileStream stream = new FileStream("person.bin", FileMode.Create);

            //formatter.Serialize(stream, personen);

            //stream.Close();

            //stream = new FileStream("person.bin", FileMode.Open);
            //object p4 = formatter.Deserialize(stream);

            // Console.WriteLine(p2.GetType());

            // XML
            // Limitierung: Klasse muss public sein

            //XmlSerializer formatter = new XmlSerializer(typeof(Person));
            //FileStream stream = new FileStream("person.xml", FileMode.Create);
            //formatter.Serialize(stream, p1);
            //stream.Close();

            //stream = new FileStream("person.xml", FileMode.Open);
            //object personXML = formatter.Deserialize(stream);
            //stream.Close();

            // JSON

            File.WriteAllText("person.json",JsonConvert.SerializeObject(personen));

            List<Person> personJson = JsonConvert.DeserializeObject<List<Person>>(File.ReadAllText("person.json"));

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
