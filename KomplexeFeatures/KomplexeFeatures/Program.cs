using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomplexeFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Erweiterungsmethoden

            //int zahl1 = 42;

            //int erg1 = Erweiterungsmethoden.Verdoppeln(zahl1);
            //int erg2 = zahl1.Verdoppeln();

            //Console.WriteLine(erg1);
            //Console.WriteLine(erg2);

            //DisposablePerson p = new DisposablePerson();

            //p.DisposeWithInfo(); 
            #endregion

            #region Operatorüberladung
            //Bruch b1 = new Bruch { Zähler = 1, Nenner = 2 };
            //Bruch b2 = new Bruch { Zähler = 1, Nenner = 4 };

            //var erg = b1 * 3;

            //Console.WriteLine($"{erg.Zähler}/{erg.Nenner}"); 
            #endregion

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
