using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCode.Factory
{
    public class Violon : Instrument
    {
        public override void Jouer() { Console.WriteLine("son de violon"); }
    }
}
