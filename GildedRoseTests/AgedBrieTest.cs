using System.Collections.Generic;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests
{
    public class AgedBrieTest
    {
        [Fact]
        public void AgedBrie_QualityIncreasesByOne_SellInDateIsPositive()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 0 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(1, app.Items[0].Quality);
        }

        [Fact]
        public void AgedBrie_QualityIncreasesByTwo_SellInDateIsZeroOrNegative()
        {
            IList<Item> items = new List<Item> {new Item {Name = "Aged Brie", SellIn = 0, Quality = 0}};
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(2, app.Items[0].Quality);
        }

        [Fact]
        public void AgedBrie_QualityCannotBeMoreThanFifty()
        {
            IList<Item> items = new List<Item> {new Item {Name = "Aged Brie", SellIn = 0, Quality = 49}};
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(50, app.Items[0].Quality);
            app.UpdateQuality();
            Assert.Equal(50, app.Items[0].Quality);
        }
    }
}