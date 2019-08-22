using Models.Interfaces;

namespace PremiumFeatures
{
    public class Division : ICalculationMethod
    {
        public string Operator => "/";
        public int Calculate(int Value1, int Value2) => Value1 / Value2;
    }
}
