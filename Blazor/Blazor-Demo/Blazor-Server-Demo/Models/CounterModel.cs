namespace Blazor_Server_Demo.Models
{
    public class CounterModel
    {
        public int CurrentValue { get; set; }
        public int CounterValue { get; set; }

        public void Add(int extra)
        {
            CurrentValue += CounterValue + extra;
        }

        public void Subtract()
        {
            CurrentValue-=CounterValue;
        }
    }
}
