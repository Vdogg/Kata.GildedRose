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