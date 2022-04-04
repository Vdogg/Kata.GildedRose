using Kata.GildedRose.Model;
using Kata.GildedRose.Model.Strategies;
using NUnit.Framework;

namespace Kata.GildedRose.Test
{
    public class Tests
    {


		[Test]
		public void BasicStrategy_ReturnsItem()
		{
			QualityUpdater updater = new QualityUpdater();
			Item apple = new Item();

            updater.updateStrategy = new DefaultStrategy();

			Item sameRef = updater.Update(apple);

			Assert.AreEqual(sameRef, apple);

		}




		private static object[] ItemsGetsOld =
		{
			new object[]{ new Item { Name= "Apple", SellIn= 10, Quality = 5},9,4 }
		};
		/*
		 * - At the end of each day our system lowers both values for every item
		 */
		[TestCaseSource("ItemsGetsOld")]
		public void Item_GetsOld_SellinAndQualityMinusOne(Item item,int expectedSellin,int expectedQuality)
        {
			QualityUpdater updater = new QualityUpdater();
			updater.updateStrategy = new DefaultStrategy();

			updater.Update(item);

			Assert.AreEqual(expectedSellin, item.SellIn);
			Assert.AreEqual(expectedQuality, item.Quality);

		}


		private static object[] ItemsRotting =
		{
			new object[]{ new Item { Name= "Apple", SellIn= 10, Quality = 5},4 },
			new object[]{ new Item { Name= "Banana", SellIn= 1, Quality = 5},4 },
			new object[]{ new Item { Name= "Raspberries", SellIn= 0, Quality = 5},3 }
		};

		/*
		 * - Once the sell by date has passed, Quality degrades twice as fast
		 */
		[TestCaseSource("ItemsRotting")]
		public void Item_GettinRotten_AfterSellinOutDated_QualityMinusTwo(Item item,int expectedQuality)
        {
			QualityUpdater updater = new QualityUpdater();
			updater.updateStrategy = new DefaultStrategy();

			updater.Update(item);

			Assert.AreEqual(expectedQuality, item.Quality);
		}


		private static object[] ItemsNeverNegative =
		{
			new object[]{ new Item { Name= "Apple", SellIn= 10, Quality = 5},4 },
			new object[]{ new Item { Name= "Banana", SellIn= 1, Quality = 0},0 },
			new object[]{ new Item { Name= "Raspberries", SellIn= 0, Quality = 0},0 }
		};


		/*
		 * - The Quality of an item is never negative
		 */
		[TestCaseSource("ItemsNeverNegative")]
		public void Item_GetsOld_QualityNeverNegative(Item item, int expectedQuality)
        {
			QualityUpdater updater = new QualityUpdater();
			updater.updateStrategy = new DefaultStrategy();

			updater.Update(item);

			Assert.AreEqual(expectedQuality, item.Quality);
		}



		private static object[] CheesyItems =
{
			new object[]{ new Item { Name= "Brie", SellIn= 1, Quality = 9},10 },
			new object[]{ new Item { Name= "Munster", SellIn= 0, Quality = 8},10 },
		};

		/*
		 * - "Aged Brie" actually increases in Quality the older it gets
		 */
		[TestCaseSource("CheesyItems")]
		public void Cheese_gettingOld_QualityUpgrades(Item cheese,int expectedQuality)
        {
			QualityUpdater updater = new QualityUpdater();
			updater.updateStrategy = new CheeseStrategy();

			updater.Update(cheese);

			Assert.AreEqual(expectedQuality, cheese.Quality);
		}



		private static object[] ItemsNeverMoreThanFifthy =
		{
			new object[]{ new Item { Name= "Brie", SellIn= 5, Quality = 50},50 },
			new object[]{ new Item { Name= "Munster", SellIn= 0, Quality = 50},50 },
		};
		/*
		 * - The Quality of an item is never more than 50
		 * It seems to only concern the cheese when it's the only kind of item which gains of quality along time.
		 * 
		 */
		[TestCaseSource("ItemsNeverMoreThanFifthy")]
		public void Items_QualityNeverMoreThanFifthy(Item cheese, int expectedQuality)
		{
			QualityUpdater updater = new QualityUpdater();
			updater.updateStrategy = new CheeseStrategy();

			updater.Update(cheese);

			Assert.AreEqual(expectedQuality, cheese.Quality);
		}


		/*
		 * - "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
		 * 
		 * This text is meaningfull because it's written that it never has to be sold.
		 * So we don't have to affect it in any way.
		 * Except perhaps make some protections/exceptions to prevent selling it.
		 * But i don't like that goblin. So... Who cares ?
		 */




		private static object[] BackStagePassesQualityUpgrades =
{
			new object[]{ new Item { Name= "Pass", SellIn= 30, Quality = 9},10 },

			new object[]{ new Item { Name= "Pass", SellIn= 9, Quality = 20},22 },
			new object[]{ new Item { Name= "Pass", SellIn= 10, Quality = 20},22 },
			new object[]{ new Item { Name= "Pass", SellIn= 11, Quality = 20},21 },

			new object[]{ new Item { Name= "Pass", SellIn= 4, Quality = 20},23 },
			new object[]{ new Item { Name= "Pass", SellIn= 5, Quality = 20},23 },
			new object[]{ new Item { Name= "Pass", SellIn= 6, Quality = 20},22 },

		};
		/*
		 * - "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
		 * - Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less 
		 */
		[TestCaseSource("BackStagePassesQualityUpgrades")]
		public void BackStagePass_GettingCloseToEvent_QualityUpgrades(Item pass, int expectedQuality)
        {
			QualityUpdater updater = new QualityUpdater();
			updater.updateStrategy = new TicketingStrategy();

			updater.Update(pass);

			Assert.AreEqual(expectedQuality, pass.Quality);
		}





		/*
		 * 
		 * TODOLIST
		 * 
    OK  - All items have a SellIn value which denotes the number of days we have to sell the item 
	OK	- All items have a Quality value which denotes how valuable the item is
	OK	- At the end of each day our system lowers both values for every item

		Pretty simple, right? Well this is where it gets interesting:

		- Once the sell by date has passed, Quality degrades twice as fast
		- The Quality of an item is never negative
		- "Aged Brie" actually increases in Quality the older it gets
		- The Quality of an item is never more than 50
		- "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
		- "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
		Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
		Quality drops to 0 after the concert

		We have recently signed a supplier of conjured items. This requires an update to our system:

		- "Conjured" items degrade in Quality twice as fast as normal items
         */
	}
}