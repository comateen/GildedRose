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
                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Quality < 50)
                    {
                        QualityUp(item);

                        if (item.SellIn < 11 && item.Quality < 50)
                        {
                            QualityUp(item);
                        }

                        if (item.SellIn < 6 && item.Quality < 50)
                        {
                            QualityUp(item);
                        }
                    }
                    SellInDown(item);
                    if (item.SellIn < 0)
                    {
                        QualityToZero(item);
                    }
                }

                else if (item.Name == "Aged Brie")
                {
                    if (item.Quality < 50)
                    {
                        QualityUp(item);
                    }

                    SellInDown(item);

                    if (item.SellIn < 0)
                    {
                        if (item.Quality < 50)
                        {
                            QualityUp(item);
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
                        QualityDown(item);
                    }

                    SellInDown(item);

                    if (item.SellIn < 0 && item.Quality > 0)
                    {
                        QualityDown(item);
                    }
                }
            }
        }

        private static void QualityToZero(Item item)
        {
            item.Quality = item.Quality - item.Quality;
        }

        private static void SellInDown(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }

        private static void QualityDown(Item item)
        {
            item.Quality = item.Quality - 1;
        }

        private static void QualityUp(Item item)
        {
            item.Quality = item.Quality + 1;
        }
    }
}
