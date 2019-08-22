using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            // Parallel
            int[] durchgänge = { 10_000, 50_000, 100_000, 250_000, 500_000, 1_000_000, 5_000_000, 10_000_000 };
            Stopwatch watch = new Stopwatch();

            // JIT - Compiler
            ForTest(5);
            ParallelTest(5);

            for (int i = 0; i < durchgänge.Length; i++)
            {
                Console.WriteLine($"----- Aktueller Durchgang: {durchgänge[i]} -----");
                watch.Restart();
                ParallelTest(durchgänge[i]);
                watch.Stop();
                Console.WriteLine($"Parallel: {watch.ElapsedMilliseconds}ms");

                watch.Restart();
                ForTest(durchgänge[i]);
                watch.Stop();
                Console.WriteLine($"For: {watch.ElapsedMilliseconds}ms");
            }

            // ForEach
            //Parallel.ForEach(meineListe, item =>
            // {
            //    //Logik für item
            // });

            // PLINQ
            //int[] zahlen = null;
            //zahlen.AsParallel()
            //    .WithDegreeOfParallelism(2)
            //    .Where(x => x % 2 == 0)
            //    // .AsSequential()
            //    .ToList();

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        public static void ParallelTest(int durchgänge)
        {
            double[] data = new double[durchgänge];
            Parallel.For(0, durchgänge,new ParallelOptions { MaxDegreeOfParallelism = 2 }, i =>
             {
                 data[i] = Math.Pow(i, 0.77777) * Math.Sqrt(Math.Sin(i));
             });
        }
        public static void ForTest(int durchgänge)
        {
            double[] data = new double[durchgänge];
            for (int i = 0; i < durchgänge; i++)
            {
                data[i] = Math.Pow(i, 0.77777) * Math.Sqrt(Math.Sin(i));
            }
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
