using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAppConsole
{
    public class CounterEventArgs : EventArgs
    {
        public int CounterNumber { get; set; }
    }
}
