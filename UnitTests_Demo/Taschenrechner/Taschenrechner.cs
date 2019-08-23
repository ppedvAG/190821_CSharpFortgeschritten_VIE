using System;

namespace Taschenrechner
{
    public class Taschenrechner
    {
        public int Add(int z1, int z2)
        {
            checked // Prüft auf Overflow/Underflow
            {
                return z1 + z2;
            }
        }

        public DateTime GibUhrzeit()
        {
            return DateTime.Now;
        }
    }
}
