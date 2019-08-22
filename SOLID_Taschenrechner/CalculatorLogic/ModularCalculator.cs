using Models;
using Models.Interfaces;
using System;
using System.Linq;

namespace CalculatorLogic
{
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
}
