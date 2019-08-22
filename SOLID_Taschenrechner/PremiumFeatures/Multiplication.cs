using Models.Interfaces;
using System;

namespace PremiumFeatures
{
    public class Multiplication : ICalculationMethod
    {
        public string Operator => "*";
        public int Calculate(int Value1, int Value2) => Value1 * Value2;
    }
}
