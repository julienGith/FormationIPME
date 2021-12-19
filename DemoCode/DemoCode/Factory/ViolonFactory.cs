using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCode.Factory
{
    public class ViolonFactory : InstrumentFactory
    {
        public override IInstrument CreateInstrument()
        {
            IInstrument violon = new Violon();
            return violon;
        }
    }
}
