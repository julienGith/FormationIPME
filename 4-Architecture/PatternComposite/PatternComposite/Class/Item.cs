using PatternComposite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternComposite.Class
{
    internal class Item : IItemComponent
    {
        public Item(string name)
        {
            _id = Guid.NewGuid();
            _name = name;
            
        }
        public Item(string name, int weight) :this(name)
        {
            _weight = weight;
        }
        private int _weight;
        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        private Guid _id;
        private string _name;
        public string Name { get { return _name; } init { } }
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public void Display()
        {
            Console.WriteLine(this.Name);
        }
    }
}
