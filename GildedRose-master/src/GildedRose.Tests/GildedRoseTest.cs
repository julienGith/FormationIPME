using System.Collections.Generic;
using FluentAssertions;
using GildedRose.Items;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class GildedRoseTest
    {
        [TestMethod]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("fixme", Items[0].Name);
        }
        [TestMethod]
        public void GoldenMasterGildedRose()
        {
            IList<Item> gmItems = new List<Item> {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                new Item {Name = "Aged Brie", SellIn = -1, Quality = 6},
                new Item {Name = "Elixir of the Mongoose", SellIn = -5, Quality = 7},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -3, Quality = 6},
                // this conjured item does not work properly yet
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
            IList<Item> NewItems = new List<Item> {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                new Item {Name = "Aged Brie", SellIn = -1, Quality = 6},
                new Item {Name = "Elixir of the Mongoose", SellIn = -5, Quality = 7},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -3, Quality = 6},
                // this conjured item does not work properly yet
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
            GildedRose gildedRoseNew = new GildedRose(NewItems);
            GildedRoseGoldenMaster gildedRoseGM = new GildedRoseGoldenMaster(gmItems);
            gildedRoseNew.UpdateQuality();
            gildedRoseGM.UpdateQuality();
            gmItems.Should().BeEquivalentTo(NewItems);
        }
    }
    
}
