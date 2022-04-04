using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.GildedRose.Model.Strategies
{
    interface IUpdateStrategy
    {
        Item update(Item item);
    }
}
