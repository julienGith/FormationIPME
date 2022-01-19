using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAppConsole
{
    public class Counter
    {
        public event EventHandler<CounterEventArgs> CounterEventHandler;
        public int CountNumber { get; set; }
        public Counter()
        {
        }
        public void Count()
        {
            while (true)
            {
                CounterEventHandler?.Invoke(this,e:new CounterEventArgs(){ CounterNumber=CountNumber});
                Thread.Sleep(1000);
            }
        }
    }
}
