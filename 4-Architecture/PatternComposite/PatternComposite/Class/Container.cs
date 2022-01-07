using PatternComposite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternComposite.Class
{
    internal class Container : IIventory, IItemComponent
    {
        private Consumable _consumable;
        private Weapon _weapon;
        public Container()
        {
            _consumable=new Consumable();
            _weapon=new Weapon();
        }
        private IEnumerable<Item> _items;
        public  IEnumerable<Item> Items
        {
            get { return _items??=new List<Item>(); }
            set { _items = value; }
        }
        public void Add(Item item)
        {
            var itemType = item.GetType();
            var itemsModifyed = Items as List<Item>;
            itemsModifyed.Add(item);
            Items = itemsModifyed;
            switch (itemType.Name)
            {
                case "Knife": _weapon.Add(item as Knife); break;
                case "Potion": _consumable.Add(item); break;
                default:
                    break;
            }
        }
        public IEnumerable<Item> GetConsumables()
        {
            return _consumable.Consumables;
        }
        public void Remove(Guid guidItem)
        {
            var item = _items.FirstOrDefault(i => i.Id == guidItem);
            var itemType = item.GetType();
            switch (itemType.Name)
            {
                case "Knife": _weapon.Remove(item); break;
                case "Potion": _consumable.Remove(item); break;
                default:
                    break;
            }
        }

        public void Display()
        {
            foreach (var item in Items)
            {
                item.Display();
            }
        }

    }
}
