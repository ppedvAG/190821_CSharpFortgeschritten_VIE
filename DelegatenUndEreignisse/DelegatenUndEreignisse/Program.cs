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
        public delegate void Fließband(ref string x);
        public delegate int Rechner(int z1, int z2);
        static void Main(string[] args)
        {
            #region Delegate - Schlüsselwort
            //MeinDelegat del = new MeinDelegat(A);
            //del += B;
            //del();

            //MeinDelegat2 del2 = C; // Alternative Schreibweise
            //del2(99); 
            #endregion

            #region Verketten von Delegaten
            //Fließband f = FabrikA;
            //f += FabrikB;
            //f += FabrikC;

            //string demo = "Hallo Welt - ";
            //f(ref demo);

            //Console.WriteLine(demo);

            //Rechner r = Sub;
            //r += Add;

            //Console.WriteLine(r(12,5)); 
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

        static void FabrikA(ref string text)
        {
            text += "Arbeit aus A - ";
        }
        static void FabrikB(ref string text)
        {
            text += "Berechnung aus B - ";
        }
        static void FabrikC(ref string text)
        {
            text += "---ENDE";
        }

        static int Add(int z1, int z2) => z1 + z2;
        static int Sub(int z1, int z2) => z1 - z2;
    }
}
