using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatenUndEreignisse
{
    class Program
    {
        // Delegate-Type: Signatur (Rückgabetyp, Name, Parameter)
        public delegate void MeinDelegat();
        public delegate void MeinDelegat2(int zahl);
        static void Main(string[] args)
        {
            #region Delegate - Schlüsselwort
            //MeinDelegat del = new MeinDelegat(A);
            //del += B;
            //del();

            //MeinDelegat2 del2 = C; // Alternative Schreibweise
            //del2(99); 
            #endregion

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        static void A()
        {
            Console.WriteLine("A");
        }
        static void B() => Console.WriteLine("B");
        static void C(int zahl)
        {
            Console.WriteLine($"C{zahl}");
        }
    }
}
