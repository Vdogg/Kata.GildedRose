using Kata.GildedRose.Model;
using Kata.GildedRose.Model.Strategies;
using System;
using System.Collections.Generic;

namespace Kata.GildedRose.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            QualityUpdater updater = new QualityUpdater();

            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {

                    System.Console.WriteLine(Items[j]);
                    updater.updateStrategy = StrategyChooser(Items[j]);
                    if (updater.updateStrategy != null) updater.Update(Items[j]);
                }
                Console.WriteLine("");
            }
        }

        public static IUpdateStrategy StrategyChooser(Item item)
        {
            switch (item.Name)
            {
                case "Elixir of the Mongoose": return new DefaultStrategy();
                case "Conjured Mana Cake": return new InvokedStrategy();
                case "Aged Brie": return new CheeseStrategy();
                case "Sulfuras, Hand of Ragnaros": return null;
                default: return new DefaultStrategy();            //Personnal choice
            }
        }

    }
}
