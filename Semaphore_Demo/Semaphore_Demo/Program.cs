using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Semaphore_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            SemaphoreZähler s_zähler = new SemaphoreZähler();

            for (int i = 0; i < 500; i++)
            {
                new Thread(s_zähler.ZähleWas).Start();
            }

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
