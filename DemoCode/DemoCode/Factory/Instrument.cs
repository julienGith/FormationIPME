using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCode.Factory
{
    public abstract class Instrument : IInstrument
    {
        public virtual void Jouer() { }
        public virtual void CreateInstrument()
        {

        }
    }
}
