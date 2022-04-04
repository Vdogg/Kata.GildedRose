using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.GildedRose.Model.Strategies
{
    public interface IUpdateStrategy
    {
        Item update(Item item);
    }
}
