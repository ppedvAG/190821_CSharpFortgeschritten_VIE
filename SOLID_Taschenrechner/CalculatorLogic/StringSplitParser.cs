using Models;
using Models.Interfaces;
using System;

namespace CalculatorLogic
{
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
}
