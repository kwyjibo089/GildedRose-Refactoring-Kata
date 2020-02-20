using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace csharpcore.tests
{
    public class BackstagePassesTest
    {
        [Fact]
        public void Test_BackstagePasses_Quality_Increases()
        {
            IList<Item> items = new List<Item>
            {
                 new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",SellIn = 15,Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",SellIn = 10,Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",SellIn = 5,Quality = 30
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",SellIn = 10,Quality = 51
                }
            };

            GildedRose unitUnderTest = new GildedRose(items);

            unitUnderTest.UpdateQuality();

            Assert.Equal(21, items[0].Quality);
            Assert.Equal(14, items[0].SellIn);

            Assert.Equal(50, items[1].Quality);
            Assert.Equal(9, items[1].SellIn);

            Assert.Equal(33, items[2].Quality);
            Assert.Equal(4, items[2].SellIn);

            Assert.Equal(51, items[3].Quality);
            Assert.Equal(9, items[3].SellIn);

        }

        [Fact]
        public void Test_BackstagePasses_Quality_ToZero_After_SellIn()
        {
            IList<Item> items = new List<Item>
            {
                 new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",SellIn = 1,Quality = 30
                },
                 new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",SellIn = 0,Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",SellIn = -1,Quality = 49
                }
            };

            GildedRose unitUnderTest = new GildedRose(items);

            unitUnderTest.UpdateQuality();

            Assert.Equal(33, items[0].Quality);
            Assert.Equal(0, items[0].SellIn);

            Assert.Equal(0, items[1].Quality);
            Assert.Equal(-1, items[1].SellIn);

            Assert.Equal(0, items[2].Quality);
            Assert.Equal(-2, items[2].SellIn);

        }
    }
}
