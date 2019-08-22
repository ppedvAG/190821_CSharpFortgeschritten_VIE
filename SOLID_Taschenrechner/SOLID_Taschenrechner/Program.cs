using CalculatorLogic;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SOLID_Taschenrechner
{
    class Program
    {
        // Main(): Bootstrapping
        static void Main(string[] args)
        {
            // Alle Assemblies aus dem PlugIn-Ordner laden
            if (!Directory.Exists(@".\PlugIns"))
                Directory.CreateDirectory(@".\PlugIns");

            foreach (string file in Directory.GetFiles(@".\PlugIns"))
            {
                if (Path.GetExtension(file) == ".dll" || Path.GetExtension(file) == ".exe")
                    Assembly.LoadFrom(file); // jede Assembly laden
            }

            // firmenname.projektname.Schichtname....
            // ppedv.SolidTaschenrechner.Models
            // ppedv.SolidTaschenrechner.Logic
            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                                                       .Where(x => x.FullName.StartsWith("Logic."))
                                                       .SelectMany(x => x.GetTypes())
                                                       .Where(x => typeof(ICalculationMethod).IsAssignableFrom(x) &&
                                                                   x.IsInterface == false &&
                                                                   x.IsAbstract == false)
                                                       .Select(x => (ICalculationMethod)Activator.CreateInstance(x))
                                                       .ToArray();

            var parser = new RegexParser();
            var calculator = new ModularCalculator(allAssemblies);
            new ConsoleUI(parser, calculator).Start();

            // Übung: DLL "PaidFeatures"
            // Multiplikation, Division
        }
    }

}
