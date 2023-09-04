using System.Collections.Generic;

namespace GildedRoseKata
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
            foreach (Item item in Items)
            {

                //Sulfuras disprait car aucune action si == sulfuras

                
                
                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;

                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                    item.SellIn = item.SellIn - 1;
                    if (item.SellIn < 0)
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }

                else if (item.Name == "Aged Brie")
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                
                    item.SellIn = item.SellIn - 1;
               
                    if (item.SellIn < 0)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
                else if ((item.Name == "Sulfuras, Hand of Ragnaros"))
                {
                    //aucune action à effectuer
                }
                else if (((item.Name == "Conjured Mana Cake")))
                {
                    //TODO
                }
                else
                {
                    if (item.Quality > 0)
                    {

                        item.Quality = item.Quality - 1;
                    }

                    item.SellIn = item.SellIn - 1;

                    if (item.SellIn < 0)
                    {
                        if (item.Quality > 0)
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                }
            }
        }

        private static bool IsBaseItem(Item item)
        {
            return item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert" && item.Name != "Sulfuras, Hand of Ragnaros";
        }
    }
}
