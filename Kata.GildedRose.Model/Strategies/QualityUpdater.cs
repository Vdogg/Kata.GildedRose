using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.GildedRose.Model.Strategies
{
    public class QualityUpdater
    {
        public IUpdateStrategy updateStrategy;

        public Item UpdateQuality(Item item)
        {
            return item;
        }

       
    }
}
