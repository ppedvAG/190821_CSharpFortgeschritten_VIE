namespace Models.Interfaces
{
    public interface ICalculationMethod
    {
        string Operator { get; }
        int Calculate(int Value1, int Value2);
    }
}
