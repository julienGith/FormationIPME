using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCode.Factory
{
    public class Piano : Instrument
    {
        public override void Jouer()
        {
            Console.WriteLine("son de piano");
        }
    }
}
