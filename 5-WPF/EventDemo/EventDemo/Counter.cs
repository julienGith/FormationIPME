namespace EventDemo
{
    public class Counter
    {
        public event EventHandler<CounterEventArgs> CounterEvent;

        public event Action<int> CounterEvent2;

        public int CountNumber { get; set; }

        public void Count()
        {
            while (true)
            {
                CountNumber++; 
                CounterEvent?.Invoke(this, new CounterEventArgs() { CounterNumber = CountNumber});
                CounterEvent2(CountNumber);
                Thread.Sleep(1000);
            }
        }
    }
}
