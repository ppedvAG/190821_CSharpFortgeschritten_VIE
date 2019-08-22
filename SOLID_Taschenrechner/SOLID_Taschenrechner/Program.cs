using CalculatorLogic;
using FreeFeatures;
using PremiumFeatures;
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
            var calculator = new ModularCalculator(new Addition(), new Subtraction(), new Multiplication(), new Division());
            new ConsoleUI(parser, calculator).Start();

            // Übung: DLL "PaidFeatures"
            // Multiplikation, Division
        }
    }

}
