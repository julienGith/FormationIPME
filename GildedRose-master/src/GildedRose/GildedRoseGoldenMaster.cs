using GildedRose.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    public class GildedRoseGoldenMaster
    {
        private IList<Item> Items;

        public GildedRoseGoldenMaster(IList<Item> Items)
        {
            this.Items = Items;
        }
        public void UpdateQuality()
        {
            var items1 = GetItemsNotBrieNotBack();
            foreach (var item in items1)
            {
                if (item.Quality > 0)
                {
                    if (item.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
            }
            var items2 = Items.Where(item => item.Quality < 50 && item.Name == "Aged Brie" && item.Name == "Backstage passes to a TAFKAL80ETC concert").ToList();
            foreach (var item in items2)
            {
                item.Quality = item.Quality + 1;
                if (item.SellIn < 11)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
            foreach (var item in Items)
            {
                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != "Aged Brie")
                    {
                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    item.Quality = item.Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                }
            }
        }

        private IList<Item> GetItemsNotBrieNotBack()
        {
            return Items.Where(i => i.Name != "Aged Brie" && i.Name != "Backstage passes to a TAFKAL80ETC concert").ToList();
        }
    }
}
