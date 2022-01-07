using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternComposite.Class
{
    internal class Knife : Item
    {
        public Knife(string name,int weight) : base(name,weight)
        {
            _weight=weight;
        }
        private int _weight;

        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

    }
}
