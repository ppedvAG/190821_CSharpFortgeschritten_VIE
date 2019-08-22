using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLib
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task erstellen
            //// 1)
            //Task t1 = new Task(MachEtwasInEinemTask);
            //t1.Start();

            //// 2) ab .NET 4.0
            //Task.Factory.StartNew(MachEtwasInEinemTask2);

            //// 3) ab .NET 4.5
            //Task.Run(MachEtwasInEinemTask3);

            //// Unterschied zwischen 2 und 3:
            //// Variante 3:
            //// Task.Run(action) bedeutet soviel wie
            //// Task.Factory.StartNew(action, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);

            //// indirekt: 4) anonyme Methode
            ////Task.Run( () =>
            ////{
            ////    // Logik..
            ////});
            #endregion

            #region Task mit einer Rückgabe
            ////Task<int> t1 = new Task<int>(GibWasZurück);
            ////t1.Start();

            ////Console.WriteLine(t1.Result); // Programm wartet auf das Ergebnis

            //var t1 = Task.Factory.StartNew(GibWasZurück);
            //int erg = t1.Result; 
            #endregion

            #region Auf einen Task warten

            //Task t1 = Task.Run(MachEtwasInEinemTask);
            //// t1.Wait(); // Variante 1;
            //Task t2 = Task.Factory.StartNew(MachEtwasInEinemTask2);

            //Task.WaitAll(t1, t2);
            //Task.WaitAny(t1, t2); 
            #endregion

            #region Task beenden
            // CancellationTokenSource cts = new CancellationTokenSource();

            // Task t1 = Task.Run(() =>
            //{
            //    Console.WriteLine(".... es passiert Etwas....");
            //    for (int i = 0; i < 200; i++)
            //    {
            //        if (cts.Token.IsCancellationRequested)
            //            break;

            //        Console.Write("#");
            //        Thread.Sleep(100);
            //    }
            //    Console.WriteLine("..... Aufgabe erledigt .....");
            //});

            // Thread.Sleep(5000);
            // cts.Cancel();
            #endregion

            #region Exceptions im Task
            //Task t1 = new Task(WirfEineException);
            //t1.Start();
            //Task t2 = Task.Run(() => throw new DivideByZeroException());
            //Task t3 = Task.Run(() =>
            //{
            //    Thread.Sleep(5000);
            //    throw new FormatException();
            //});


            //try
            //{
            //    Task.WaitAll(t1, t2, t3);
            //}
            //catch (AggregateException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            #endregion

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        private static void WirfEineException()
        {
            throw new NotImplementedException();
        }

        private static int GibWasZurück()
        {
            Thread.Sleep(5000);
            return 42;
        }

        private static void MachEtwasInEinemTask3()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write("-");
            }
        }

        private static void MachEtwasInEinemTask2()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write("#");
            }
        }

        private static void MachEtwasInEinemTask()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write(".");
            }
        }
    }
}
