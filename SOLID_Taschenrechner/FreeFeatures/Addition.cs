using Models.Interfaces;
using System;

namespace FreeFeatures
{
    public class Addition : ICalculationMethod
    {
        public string Operator => "+";
        public int Calculate(int Value1, int Value2) => Value1 + Value2;
    }
}
