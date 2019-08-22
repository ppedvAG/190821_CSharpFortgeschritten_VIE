using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomplexeFeatures
{
    class Bruch
    {
        public int Zähler { get; set; }
        public int Nenner { get; set; }


        public static Bruch operator *(Bruch left,Bruch right)
        {
            Bruch result = new Bruch();
            result.Zähler = left.Zähler * right.Zähler;
            result.Nenner = left.Nenner * right.Nenner;

            return result;
        }
        public static Bruch operator *(Bruch left, int right)
        {
            Bruch result = new Bruch();
            result.Zähler = left.Zähler * right;
            result.Nenner = left.Nenner;

            return result;
        }


        // Operatoren:
        // Arith.
        // +,-,*,/,%
        // Binary
        // &,|,^,<<,>>
        // Vergleich:
        // <,>,<=,>=,==,!=
        // --- Achtung: Paarweise überladen

        // Automatisch:
        // +   --> += wird miterstell
    }
}
