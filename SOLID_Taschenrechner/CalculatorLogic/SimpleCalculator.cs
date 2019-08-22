using Models;
using Models.Interfaces;
using System;

namespace CalculatorLogic
{
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
}
