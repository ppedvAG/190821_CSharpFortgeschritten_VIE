using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads_Demo
{
    class Konto
    {
        public Konto(decimal kontostand)
        {
            this.kontostand = kontostand;
        }

        private decimal kontostand;
        private int buchungsnummer = 0;
        private object lockObject = new object();

        public void Abheben(decimal menge)
        {
            Monitor.Enter(lockObject);
            if (kontostand > menge)
            {
                Console.WriteLine($"[{buchungsnummer}] Kontostand vor dem Abheben:\t\t{kontostand}");
                Console.WriteLine($"[{buchungsnummer}] Betrag zum Abheben:\t\t\t{menge}");
                kontostand -= menge;
                Console.WriteLine($"[{buchungsnummer}] Kontostand nach dem Abheben:\t\t{kontostand}");
            }
            else
                Console.WriteLine($"Kontostand reicht nicht aus:\t\t{kontostand}");

            buchungsnummer++;
            Monitor.Exit(lockObject);
        }
        public void Einzahlen(decimal menge)
        {
            lock (lockObject)
            {
                Console.WriteLine($"[{buchungsnummer}] Kontostand vor dem Einzahlen:\t\t{kontostand}");
                Console.WriteLine($"[{buchungsnummer}] Betrag zum Einzahlen:\t\t\t{menge}");
                kontostand += menge;
                Console.WriteLine($"[{buchungsnummer}] Kontostand nach dem Einzahlen:\t\t{kontostand}");
                buchungsnummer++;
            }
        }

    }
}
