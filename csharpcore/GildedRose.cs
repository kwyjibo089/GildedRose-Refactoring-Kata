using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if(Items[i].Name == "Sulfuras, Hand of Ragnaros")
                {
                    continue;
                }

                Items[i].SellIn = Items[i].SellIn - 1;

                switch (Items[i].Name)
                {
                    case "Aged Brie":
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                            if (Items[i].SellIn < 0)
                            {
                                Items[i].Quality = Items[i].Quality + 1;
                            }
                        }                        
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;

                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 0)
                            {
                                Items[i].Quality = 0;
                            }
                        }
                        break;
                    default:
                        if (Items[i].Quality > 0)
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                            if (Items[i].SellIn < 0 && Items[i].Quality > 0)
                            {
                                Items[i].Quality = Items[i].Quality - 1;
                            }
                        }
                        break;
                }               
            }
        }
    }
}
