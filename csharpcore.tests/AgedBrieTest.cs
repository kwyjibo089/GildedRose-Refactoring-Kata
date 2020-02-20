using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace csharpcore.tests
{
    public class AgedBrieTest
    {
        [Fact]
        public void Test_QualityIncreases()
        {
            IList<Item> items = new List<Item>
            {
                 new Item {Name = "Aged Brie", SellIn = 2, Quality = 10},
                 new Item {Name = "Aged Brie", SellIn = 5, Quality = 50},
                 new Item {Name = "Aged Brie", SellIn = 0, Quality = 50},
                 new Item {Name = "Aged Brie", SellIn = -1, Quality = 40}
            };

            GildedRose unitUnderTest = new GildedRose(items);

            unitUnderTest.UpdateQuality();

            Assert.Equal(11, items[0].Quality);
            Assert.Equal(1, items[0].SellIn);

            Assert.Equal(50, items[1].Quality);
            Assert.Equal(4, items[1].SellIn);

            Assert.Equal(50, items[2].Quality);
            Assert.Equal(-1, items[2].SellIn);

            Assert.Equal(42, items[3].Quality);
            Assert.Equal(-2, items[3].SellIn);
        }
    }
}
