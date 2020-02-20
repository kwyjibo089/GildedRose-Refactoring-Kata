using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace csharpcore.tests
{
    public class SulfurasTest
    {
        [Fact]
        public void Test_QualityIncreases()
        {
            IList<Item> items = new List<Item>
            {
                 new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 100},
                 new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 49}
            };

            GildedRose unitUnderTest = new GildedRose(items);

            unitUnderTest.UpdateQuality();

            Assert.Equal(100, items[0].Quality);
            Assert.Equal(1, items[0].SellIn);

            Assert.Equal(80, items[1].Quality);
            Assert.Equal(0, items[1].SellIn);

            Assert.Equal(49, items[2].Quality);
            Assert.Equal(-1, items[2].SellIn);
        }
    }
}
