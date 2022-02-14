using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listes
{
    public class TestLists
    {
        public SortedList GetSortedList()
        {
            SortedList sortedList = new SortedList();
            sortedList.Add(1, "julien");
            sortedList.Add(2, "Simon");
            sortedList.Add(3, "Johan");

            return sortedList;
        }
        public string GetSortedListItemById(int id)
        {
            SortedList sortedList = GetSortedList();
            return sortedList[id].ToString();
        }
    }
}
