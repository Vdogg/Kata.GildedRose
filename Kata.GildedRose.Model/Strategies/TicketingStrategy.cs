using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.GildedRose.Model.Strategies
{
    public class TicketingStrategy : IUpdateStrategy
    {
        public Item Update(Item item)
        {
            item.SellIn = item.SellIn - 1;

            if(item.SellIn < 0)
            {
                item.Quality = 0; //Not using MIN_QUALITY because the "0" is explicitly asked.
                return item; 
            }

            if (item.SellIn < 5)
                item.Quality += 3;
            else if (item.SellIn < 10)
                item.Quality += 2;
            else item.Quality++;

            if (item.Quality > QualityUpdater.MAX_QUALITY) item.Quality = QualityUpdater.MAX_QUALITY;
            return item;
        }
    }
}
