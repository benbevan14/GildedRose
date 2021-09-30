using System.Collections.Generic;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests
{
    public class SulfurasTest
    {
        [Fact]
        public void Sulfuras_NoDecreaseInQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(80, app.Items[0].Quality);
        }

        [Fact]
        public void Sulfuras_NoDecreaseInSellIn()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(0, app.Items[0].SellIn);
        }
    }
}