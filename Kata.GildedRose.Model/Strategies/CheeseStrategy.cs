using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.GildedRose.Model.Strategies
{
    public class CheeseStrategy : IUpdateStrategy
    {
        public Item Update(Item item)
        {
            return item;
        }
    }
}
