using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.GildedRose.Model.Strategies
{
    class DefaultStrategy : IUpdateStrategy
    {
        public Item update(Item item)
        {
            return item;
        }
    }
}
