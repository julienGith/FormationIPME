using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCode.Factory
{
    public abstract class InstrumentFactory
    {
        public abstract IInstrument CreateInstrument();

    }
}
