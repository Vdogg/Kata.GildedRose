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

            item.Quality = item.SellIn >= 0 ?
                item.Quality <= 0 ?
                    QualityUpdater.MIN_QUALITY : item.Quality + 1
            :
                item.Quality <= 1 ?
                    QualityUpdater.MIN_QUALITY : item.Quality + 2;

            if (item.Quality > QualityUpdater.MAX_QUALITY) item.Quality = QualityUpdater.MAX_QUALITY;
            return item;
        }
    }
}
