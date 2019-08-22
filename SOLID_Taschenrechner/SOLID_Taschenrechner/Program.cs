using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Taschenrechner
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Bitte geben Sie die Formel ein:"); // "2 + 2"
            string input = Console.ReadLine();

            string[] formula = input.Split();
            int v1 = Convert.ToInt32(formula[0]);
            int v2 = Convert.ToInt32(formula[2]);
            string op = formula[1];

            int result = 0;
            if (op == "+")
                result = v1 + v2;
            else if (op == "-")
                result = v1 - v2;
            // ....

            Console.WriteLine($"Das Ergebnis ist {result}");

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
