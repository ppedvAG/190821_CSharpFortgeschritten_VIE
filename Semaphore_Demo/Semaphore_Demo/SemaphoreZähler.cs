using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Semaphore_Demo
{
    class SemaphoreZähler
    {
        private static Semaphore semaphore = new Semaphore(10,10);
        private static int zähler = 0;

        public void ZähleWas()
        {
            semaphore.WaitOne();
            zähler++;
            Console.WriteLine(zähler);
            zähler--;
            semaphore.Release();
        }

    }
}
