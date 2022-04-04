using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.GildedRose.Model.Strategies
{
    public class InvokedStrategy : IUpdateStrategy
    {
        public Item Update(Item item)
        {
            item.SellIn = item.SellIn - 1;

            item.Quality = item.SellIn >= 0 ?
                item.Quality <= 0 ?
                    QualityUpdater.MIN_QUALITY : item.Quality - 2
            :
                item.Quality <= 1 ?
                    QualityUpdater.MIN_QUALITY : item.Quality - 4;

            return item;
        }
    }
}
