using PatternComposite.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternComposite.Interfaces
{
    internal interface IIventory
    {
        void Add(Item item);

        void Remove(Guid guidItem);

        IEnumerable<Item> GetConsumables();


    }
}
