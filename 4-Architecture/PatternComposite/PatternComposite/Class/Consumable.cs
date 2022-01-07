using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternComposite.Class
{
    internal class Consumable
    {
        private IEnumerable<Item> _consumables;
        public IEnumerable<Item> Consumables
        {
            get { return _consumables??=new List<Item>(); }
            set { _consumables = value; }
        }
        private int _totalPockets;
        public int TotalPockets
        {
            get { return _totalPockets; }
            set { _totalPockets = value; }
        }
        internal void Remove(Item item)
        {
            var consumablesModified = _consumables.Where(i => i.Id != item.Id);
            _consumables = consumablesModified;
        }
        internal void Add(Item item)
        {
            if (_totalPockets + 1 > 5)
            {
                Console.WriteLine($"Pas assez de poches pour {item.Name}");
            }
            var consumablesModified = Consumables as List<Item>;
            consumablesModified.Add(item);
            Consumables = consumablesModified;
        }
    }
}
