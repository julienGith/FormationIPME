using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCode.Factory
{
    public class PianoFactory : InstrumentFactory
    {
        public override IInstrument CreateInstrument()
        {
            IInstrument piano = new Piano();
            return piano;
        }
    }
}
