using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mutex_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Mutex mutex = new Mutex(false, "demoMutex");
            while(mutex.WaitOne(1000) == false)
            {
                Console.WriteLine("Programm ist bereits offen, warte auf das Ende...");
            }
            for (int i = 0; i < 100; i++)
            {
                //mutex.WaitOne();
                Thread.Sleep(100);
                Console.WriteLine(i);
                //mutex.ReleaseMutex();
            }

            mutex.ReleaseMutex();
            Console.WriteLine("---Ende---");
            Console.ReadKey();
        }
    }
}
