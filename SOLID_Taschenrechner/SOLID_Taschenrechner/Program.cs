using System;
using System.Collections.Generic;
using System.Linq;
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
            var parser = new RegexParser();
            var calculator = new ModularCalculator(new Addition(),new Subtraction());
            new ConsoleUI(parser, calculator).Start();
        }
    }

    public struct Formula
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public string Operator { get; set; }
    }

    public interface IParser
    {
        Formula Parse(string input);
    }
    public class StringSplitParser : IParser
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

    public class RegexParser : IParser
    {
        private Regex regex = new Regex(@"(\d+)\s*(\D+?)\s*(\d+)");
        public Formula Parse(string input)
        {
            var result = regex.Match(input);
            if (result.Success)
            {
                Formula formula = new Formula();
                formula.Value1 = Convert.ToInt32(result.Groups[1].Value);
                formula.Value2 = Convert.ToInt32(result.Groups[3].Value);
                formula.Operator = result.Groups[2].Value;

                return formula;
            }
            else
                throw new FormatException("Die Formel hat das falsche Format");
        }
    }

    public interface ICalculator
    {
        int Calculate(Formula formula);
    }
    public class SimpleCalculator : ICalculator
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
    public class ModularCalculator : ICalculator
    {
        public ModularCalculator(params ICalculationMethod[] calculationMethods)
        {
            this.calculationMethods = calculationMethods;
        }

        private readonly ICalculationMethod[] calculationMethods;
        public int Calculate(Formula formula)
        {
            var calcMethod = calculationMethods.FirstOrDefault(x => x.Operator == formula.Operator);
            if (calcMethod == null)
                throw new InvalidOperationException($"Der Operator {formula.Operator} wird nicht unterstützt");

            return calcMethod.Calculate(formula.Value1, formula.Value2);
        }
    }

    public interface ICalculationMethod
    {
        string Operator { get; }
        int Calculate(int Value1, int Value2);
    }

    public class Addition : ICalculationMethod
    {
        public string Operator => "+";
        public int Calculate(int Value1, int Value2) => Value1 + Value2;
    }

    public class Subtraction : ICalculationMethod
    {
        public string Operator => "-";
        public int Calculate(int Value1, int Value2) => Value1 - Value2;
    }

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
