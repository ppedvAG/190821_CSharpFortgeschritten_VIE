using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Threads erstellen
            //// Thread ohne Parameter
            //Thread t1 = new Thread(MachEtwasInEinemThread);
            //t1.IsBackground = true;
            //t1.Start();

            //// Thread mit Parameter
            //Thread t2 = new Thread(new ParameterizedThreadStart(MachEtwasMitParameter));
            //t2.IsBackground = true;
            //t2.Start("😍"); // WIN + . 
            #endregion

            #region Auf Threads warten und Threads abbrechen
            //Thread t1 = new Thread(MachEtwasSehrLange);
            //t1.Start();

            //Thread.Sleep(5000);
            //t1.Abort();
            //t1.Join(); // auf einen Thread warten 
            #endregion

            #region Threadpriorität
            //Thread t1 = new Thread(BerechneEtwasLange);
            //Thread t2 = new Thread(BerechneEtwasLange);
            //Thread t3 = new Thread(BerechneEtwasLange);
            //Thread t4 = new Thread(BerechneEtwasLange);
            //Thread t5 = new Thread(BerechneEtwasLange);

            //t1.Priority = ThreadPriority.Highest;
            //t2.Priority = ThreadPriority.AboveNormal;
            //t3.Priority = ThreadPriority.Normal;
            //t4.Priority = ThreadPriority.BelowNormal;
            //t5.Priority = ThreadPriority.Lowest;

            //t1.Start(0);
            //t2.Start(1);
            //t3.Start(2);
            //t4.Start(3);
            //t5.Start(4);


            //for (int i = 0; i < 100; i++)
            //{
            //    Thread.Sleep(2500);
            //    Console.Clear();
            //    Console.WriteLine($"Highest: \t\t{index[0]}");
            //    Console.WriteLine($"AboveNormal: \t\t{index[1]}");
            //    Console.WriteLine($"Normal: \t\t{index[2]}");
            //    Console.WriteLine($"BelowNormal: \t\t{index[3]}");
            //    Console.WriteLine($"Lowest: \t\t{index[4]}");
            //} 
            #endregion

            var konto = new Konto(1000);
            for (int i = 0; i < 100; i++)
                ThreadPool.QueueUserWorkItem(ZufälligesUpdate, konto);

            Console.WriteLine();
            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        private static void ZufälligesUpdate(object param)
        {
            Konto konto = (Konto)param;
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                int menge = r.Next(0, 1000);
                if (r.NextDouble() < 0.5)
                    konto.Einzahlen(menge);
                else
                    konto.Abheben(menge);
            }
        }




        static ulong[] index = { 0, 0, 0, 0, 0 };

        private static void BerechneEtwasLange(object currentIndex)
        {
            int number = (int)currentIndex;

            for (ulong i = 0; i < ulong.MaxValue; i++)
            {
                index[number] = i;
            }
        }

        private static void MachEtwasSehrLange()
        {
            try
            {
                for (int i = 0; i < 10_000; i++)
                {
                    Thread.Sleep(100);
                    Console.Write("zZzZ");
                }
            }
            catch (ThreadAbortException)
            {
                Console.WriteLine("hahaha ich mache trotzem weiter ;)");
                for (int i = 0; i < 50; i++)
                {
                    Thread.Sleep(100);
                    Console.Write("...schnarch...");
                }
                Console.WriteLine(".... Guten Morgen :)");
            }
        }

        private static void MachEtwasMitParameter(object obj)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(obj);
            }
        }

        private static void MachEtwasInEinemThread()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("*");
            }
        }
    }
}
