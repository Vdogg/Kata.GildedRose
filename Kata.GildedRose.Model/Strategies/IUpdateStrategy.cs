using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.GildedRose.Model.Strategies
{
    public interface IUpdateStrategy
    {
        Item Update(Item item);
    }
}
