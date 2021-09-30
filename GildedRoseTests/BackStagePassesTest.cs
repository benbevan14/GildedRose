using System.Collections.Generic;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests
{
    public class BackStagePassesTest
    {
        public Item getPass(int sellIn, int quality)
        {
            return new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = sellIn,
                Quality = quality
            };
        }
        
        [Fact]
        public void BackstagePass_QualityIncreasesByOne_SellInDateGreaterThanTen()
        {
            int originalQuality = 20;
            int originalSellIn = 15;
            IList<Item> items = new List<Item> { getPass(originalSellIn, originalQuality) };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(originalQuality + 1, app.Items[0].Quality);
        }

        [Fact]
        public void BackstagePass_QualityIncreasesByTwo_SellInDateBetweenTenAndSix()
        {
            int originalQuality = 20;
            int originalSellIn = 10;
            IList<Item> items = new List<Item> {getPass(originalSellIn, originalQuality)};
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(originalQuality + 2, app.Items[0].Quality);
        }

        [Fact]
        public void BackstagePass_QualityIncreasesByThree_SellInDateBetweenFiveAndZero()
        {
            int originalQuality = 20;
            int originalSellIn = 5;
            IList<Item> items = new List<Item> {getPass(originalSellIn, originalQuality)};
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(originalQuality + 3, app.Items[0].Quality);
        }

        [Fact]
        public void BackstagePass_QualityIsZero_SellInDateNegative()
        {
            int originalQuality = 20;
            int originalSellIn = 0;
            IList<Item> items = new List<Item> {getPass(originalSellIn, originalQuality)};
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(0, app.Items[0].Quality);
        }

        [Fact]
        public void BackstagePass_QualityIsNeverAboveFifty()
        {
            int originalQuality = 49;
            int originalSellIn = 10;
            IList<Item> items = new List<Item> {getPass(originalSellIn, originalQuality)};
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(50, app.Items[0].Quality);
            app.UpdateQuality();
            Assert.Equal(50, app.Items[0].Quality);
        }
    }
}