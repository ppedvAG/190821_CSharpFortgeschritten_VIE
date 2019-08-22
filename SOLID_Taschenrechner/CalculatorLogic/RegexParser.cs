using Models;
using Models.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace CalculatorLogic
{
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
}
