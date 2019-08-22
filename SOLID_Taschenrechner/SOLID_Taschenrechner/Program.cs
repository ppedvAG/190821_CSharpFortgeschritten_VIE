using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Taschenrechner
{
    class Program
    {
        // Main(): Bootstrapping
        static void Main(string[] args)
        {
            new ConsoleUI().Start();
        }
    }

    public struct Formula
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public string Operator { get; set; }
    }

    public class StringSplitParser
    {
        public Formula Parse(string input)
        {
            string[] formula = input.Split();

            Formula output = new Formula();
            output.Value1 = Convert.ToInt32(formula[0]);
            output.Value2 = Convert.ToInt32(formula[2]);
            output.Operator = formula[1];

            return output;
        }
    }

    public class SimpleCalculator
    {
        public int Calculate(Formula formula)
        {
            if (formula.Operator == "+")
                return formula.Value1 + formula.Value2;
            else if (formula.Operator == "-")
                return formula.Value1 - formula.Value2;
            // ....
            else
                throw new InvalidOperationException($"Der Operator {formula.Operator} wird nicht unterstützt");
        }
    }

    public class ConsoleUI
    {
        // Definiert den Programm-Workflow
        public void Start()
        {
            // UI
            Console.WriteLine("Bitte geben Sie die Formel ein:"); // "2 + 2"
            string input = Console.ReadLine();

            // Parsen
            StringSplitParser parser = new StringSplitParser();
            Formula formula = parser.Parse(input);

            // Berechnen
            SimpleCalculator calculator = new SimpleCalculator();
            int result = calculator.Calculate(formula);

            // UI
            Console.WriteLine($"Das Ergebnis ist {result}");

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }

}
