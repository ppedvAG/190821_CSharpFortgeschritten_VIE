using Models;
using Models.Interfaces;
using System;

namespace SOLID_Taschenrechner
{
    public class ConsoleUI
    {
        public ConsoleUI(IParser parser, ICalculator calculator)
        {
            this.parser = parser;
            this.calculator = calculator;
        }

        private readonly IParser parser;
        private readonly ICalculator calculator;

        // Definiert den Programm-Workflow
        public void Start()
        {
            // UI
            Console.WriteLine("Bitte geben Sie die Formel ein:"); // "2 + 2"
            string input = Console.ReadLine();

            // Parsen
            Formula formula = parser.Parse(input);

            // Berechnen
            int result = calculator.Calculate(formula);

            // UI
            Console.WriteLine($"Das Ergebnis ist {result}");

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }

}
