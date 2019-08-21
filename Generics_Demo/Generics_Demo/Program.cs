using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Generics aus "Anwendersicht"
            // Generics aus "Anwendersicht"
            // List<int> meineZahlen = new List<int>();
            // meineZahlen.Add(12);
            // meineZahlen.Add(7);
            // meineZahlen.Add(3);

            // foreach (var item in meineZahlen)
            // {
            //     Console.WriteLine(item);
            // }

            // Variante vor .NET 2.0
            // ArrayList alteZahlenListe = new ArrayList();
            // alteZahlenListe.Add(123);
            // alteZahlenListe.Add("123");
            // alteZahlenListe.Add(null);
            #endregion

            ObjectStack os = new ObjectStack();
            os.Push(7);
            os.Push("12");
            os.Push(3);
            os.Push(99);

            os.Push(12345);

            Console.WriteLine(os.Pop());
            Console.WriteLine(os.Pop());
            Console.WriteLine(os.Pop());
            Console.WriteLine(os.Pop());
            Console.WriteLine(os.Pop());

            Console.WriteLine(os.Pop()); // Exception

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
