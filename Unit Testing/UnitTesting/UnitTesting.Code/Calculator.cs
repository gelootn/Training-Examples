namespace UnitTesting.Code
{
    public class Calculator : ICalculator
    {
        public decimal Sum(decimal a, decimal b) { return a + b; }
        public decimal Subtract(decimal a, decimal b) { return a - b; }
        public decimal Multiply(decimal a, decimal b) { return a * b; }
        public decimal Divide(decimal a, decimal b) { return a / b; }
    }
}