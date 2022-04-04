﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.GildedRose.Model.Strategies
{
    public class DefaultStrategy : IUpdateStrategy
    {
        public Item update(Item item)
        {
            return item;
        }
    }
}
