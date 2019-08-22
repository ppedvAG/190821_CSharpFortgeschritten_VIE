using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection11223344
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Typeninformation holen
            //// GetType() --> Typeninformation von einer Instanz holen
            //object o1 = new object();
            //var objectType = o1.GetType();

            //Console.WriteLine(objectType);

            //int demo = 12;
            //Console.WriteLine(demo.GetType());

            //// Klassen bzw Interfaces, Statische Klassen etc..
            //// typeof()

            //var statischeKlasse = typeof(Convert);
            //Console.WriteLine(statischeKlasse); 
            #endregion

            #region Zur Laufzeit Instanzen erstellen
            //int zahl1 = 42;
            //Type intType = zahl1.GetType();

            //var instanz = Activator.CreateInstance(intType);
            //Console.WriteLine(instanz);
            //Console.WriteLine(instanz.GetType()); 
            #endregion

            // Zur Laufzeit eine DLL laden und eine Instanz erstellt
            var loadedAssembly = Assembly.LoadFrom("Taschenrechner.dll");

            var allTypesFromAssembly = loadedAssembly.GetTypes();
            var rechnerType = loadedAssembly.GetType("Taschenrechner.Rechner");

            var instance = Activator.CreateInstance(rechnerType);
            // Tipp: Rechner implementiert ein Interface, -> Casten auf Interface ;)

            // Variante ohne Interface
            var addMethodInfo = rechnerType.GetMethod("Add", new Type[] { typeof(int), typeof(int) });

            var result = addMethodInfo.Invoke(instance, new object[] { 12, 99 });
            Console.WriteLine(result);


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
