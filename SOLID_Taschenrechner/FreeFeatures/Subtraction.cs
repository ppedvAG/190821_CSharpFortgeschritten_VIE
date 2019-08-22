using Models.Interfaces;

namespace FreeFeatures
{
    public class Subtraction : ICalculationMethod
    {
        public string Operator => "-";
        public int Calculate(int Value1, int Value2) => Value1 - Value2;
    }
}
