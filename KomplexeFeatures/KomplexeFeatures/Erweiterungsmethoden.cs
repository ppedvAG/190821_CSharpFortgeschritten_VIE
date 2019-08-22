using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomplexeFeatures
{
    // 1) static class
    static class Erweiterungsmethoden
    {
        // 2) this - Schlüsselwort
        public static int Verdoppeln(this int zahl) => zahl * 2;

        public static void DisposeWithInfo(this IDisposable item)
        {
            Console.WriteLine("Es wird etwas gelöscht !");
            item.Dispose();
        }
    }
}
