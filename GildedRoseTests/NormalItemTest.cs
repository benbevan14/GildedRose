using Xunit;
using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void NormalItem_DecreaseQualityByOne_ItemHasPositiveSellIn()
        {
            int originalQuality = 20;
            IList<Item> items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = originalQuality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(originalQuality - 1, app.Items[0].Quality);
        }

        [Fact]
        public void NormalItem_DecreaseSellInByOne_ItemHasPositiveSellIn()
        {
            int originalSellIn = 10;
            IList<Item> items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = originalSellIn, Quality = 20 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(originalSellIn - 1, app.Items[0].SellIn);
        }

        [Fact]
        public void NormalItem_DecreaseQualityByTwo_ItemHasNegativeSellIn()
        {
            int originalQuality = 20;
            IList<Item> items = new List<Item>
                {new Item {Name = "+5 Dexterity Vest", SellIn = 0, Quality = originalQuality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(originalQuality - 2, app.Items[0].Quality);
        }

        [Fact]
        public void NormalItem_QualityIsNeverNegative()
        {
            int originalQuality = 0;
            IList<Item> items = new List<Item> {new Item {Name = "+5 Dexterity Vest", SellIn = 0, Quality = originalQuality}};
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(originalQuality, app.Items[0].Quality);
        }
    }
}
