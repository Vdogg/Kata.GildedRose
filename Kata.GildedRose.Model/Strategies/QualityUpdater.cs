using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.GildedRose.Model.Strategies
{
    public class QualityUpdater
    {
        public IUpdateStrategy updateStrategy;

        public const int MAX_QUALITY = 50;
        public const int MIN_QUALITY = 0;

        public Item Update(Item item)
        {
            return updateStrategy.Update(item);
        }

       
    }
}
