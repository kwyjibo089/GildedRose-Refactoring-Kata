using System;
using System.Collections.Generic;
using Xunit;

namespace csharpcore.tests
{
    public class GildedRoseTest
    {
        [Fact]
        public void Test_1Day()
        {
            IList<Item> items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}
            };

            GildedRose unitUnderTest = new GildedRose(items);

            unitUnderTest.UpdateQuality();

            Assert.Equal(19, items[0].Quality);
            Assert.Equal(9, items[0].SellIn);
        }

        [Fact]
        public void Test_After_SellIn()
        {
            IList<Item> items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 1, Quality = 20}
            };

            GildedRose unitUnderTest = new GildedRose(items);

            unitUnderTest.UpdateQuality();

            Assert.Equal(19, items[0].Quality);
            Assert.Equal(0, items[0].SellIn);

            unitUnderTest.UpdateQuality();

            Assert.Equal(17, items[0].Quality);
            Assert.Equal(-1, items[0].SellIn);
        }

        [Fact]
        public void Test_Quality_Never_Negative()
        {
            IList<Item> items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 1, Quality = 1}
            };

            GildedRose unitUnderTest = new GildedRose(items);

            unitUnderTest.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
            Assert.Equal(0, items[0].SellIn);

            unitUnderTest.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
            Assert.Equal(-1, items[0].SellIn);
        }

        [Fact]
        public void Test_Quality_Never_Negative_SellIn_Negative()
        {
            IList<Item> items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = -1, Quality = 1}
            };

            GildedRose unitUnderTest = new GildedRose(items);

            unitUnderTest.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
            Assert.Equal(-2, items[0].SellIn);

            unitUnderTest.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
            Assert.Equal(-3, items[0].SellIn);
        }

        [Fact]
        public void Test_Quality_Degrades_Twice_SellIn_Negative()
        {
            IList<Item> items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = -1, Quality = 10}
            };

            GildedRose unitUnderTest = new GildedRose(items);

            unitUnderTest.UpdateQuality();

            Assert.Equal(8, items[0].Quality);
            Assert.Equal(-2, items[0].SellIn);

            unitUnderTest.UpdateQuality();

            Assert.Equal(6, items[0].Quality);
            Assert.Equal(-3, items[0].SellIn);
        }
    }
}
