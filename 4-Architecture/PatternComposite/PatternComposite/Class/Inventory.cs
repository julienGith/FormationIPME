using PatternComposite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternComposite.Class
{
    internal class Inventory : IIventory, IItemComponent
    {
        private Container _container;
        public Inventory()
        {
            _container=new Container();
        }
        private int _maxWeight;
        public int MaxWeight
        {
            get { return _maxWeight; }
            set { _maxWeight = value; }
        }
        private int _weight;
        public int Wheight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        public void Add(Item item)
        {
            _container.Add(item);
        }
        public void Remove(Guid guidItem)
        {
            _container.Remove(guidItem);
        }
        public IEnumerable<Item> GetConsumables()
        {
            return _container.GetConsumables();
        }

        public void Display()
        {
            _container.Display();
        }
    }
}
