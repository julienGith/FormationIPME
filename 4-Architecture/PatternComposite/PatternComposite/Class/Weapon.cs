using PatternComposite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternComposite.Class
{
    internal class Weapon : IItemComponent
    {
        private IEnumerable<Item> _weapons;
        public Weapon()
        {
            _weapons=new List<Item>();
        }
        public IEnumerable<Item> Weapons
        {
            get { return _weapons??=new List<Item>(); }
            set { _weapons = value; }
        }
        private int _totalWeight;
        public int TotalWeight
        {
            get { return _totalWeight=_weapons.Sum(i=>i.Weight); }
        }
        internal void Add(Item item)
        {
            if (TotalWeight + item.Weight >100)
            {
                Console.WriteLine($"La capacité de charge {TotalWeight} / 100 ne permet pas l'ajout de {item.Name} ");
                //throw new Exception($"La capacité de charge {_totalWeight} / 100 ne permet pas l'ajout de {item.Name} ");
            }
            else
            {
                var weaponsModified = Weapons as List<Item>;
                weaponsModified.Add(item);
                Weapons = weaponsModified;
            }
        }
        internal void Remove(Item item)
        {
            _weapons = _weapons.Where(i => i.Id != item.Id);
        }
        public void Display()
        {
            foreach (var item in Weapons)
            {
                item.Display();
            };
        }
    }
}
