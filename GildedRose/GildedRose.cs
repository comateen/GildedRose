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
                    UpdateBackStageItem(item);
                }
                else if (item.Name == "Aged Brie")
                {
                    UpdateAgedBrieItem(item);
                }
                else if ((item.Name == "Sulfuras, Hand of Ragnaros"))
                {
                    //rien à effectuer sur Sulfuras
                    //Par le feu soyez purifié!
                }
                else if (((item.Name == "Conjured Mana Cake")))
                {
                    UpdateConjuredItem(item);
                }
                else
                {
                    UpdateStandardItem(item);
                }
            }
        }

        private static void UpdateBackStageItem(Item item)
        {
            SellInDown(item);
            if (item.SellIn > 0 && item.Quality < 50)
            {
                QualityUp(item);

                if (item.SellIn <= 10 && item.Quality < 50)
                {
                    QualityUp(item);
                }

                if (item.SellIn <= 5 && item.Quality < 50)
                {
                    QualityUp(item);
                }
            }
            
            if (item.SellIn < 0)
            {
                QualityToZero(item);
            }
        }

        private static void UpdateAgedBrieItem(Item item)
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

        private static void UpdateConjuredItem(Item item)
        {
            
            item.Quality -= 2;

            if (item.SellIn <= 0)
            {
                item.Quality -= 2;
            }
            SellInDown(item);
            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }

        private static void UpdateStandardItem(Item item)
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
