using System.Collections.Generic;
using FotoABIld;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FotoABildTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sharedpropertieslist = new List<Pictures>();
            var shared1 = new Pictures("", 25, "10x15");
            var shared2 = new Pictures("", 25, "15x21");
            var shared3 = new Pictures("", 7, "20x30");
            var shared4 = new Pictures("", 2, "25x38");
            var shared5 = new Pictures("", 7, "25x38");
            sharedpropertieslist.Add(shared1);
            sharedpropertieslist.Add(shared2);
            sharedpropertieslist.Add(shared3);
            sharedpropertieslist.Add(shared4);
            sharedpropertieslist.Add(shared5);


            var amounthandler = new AmountHandler(sharedpropertieslist);

            int expected1 = 100 + 420 * 15 + 360 + 630;
            var actual1 = PriceCalculator.CalculateTotalPrice(sharedpropertieslist);

            var expected2 = 25*15;
            var actual2 = PriceCalculator.CalculatePrice("15x21",amounthandler.GetAmountofSize("15x21"));
            var expected3 = 360;
            var actual3 = PriceCalculator.CalculatePrice("20x30", amounthandler.GetAmountofSize("20x30"));
            var expected4 = 630;
            var actual4 = PriceCalculator.CalculatePrice("25x38",amounthandler.GetAmountofSize("25x38"));



            //Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
            Assert.AreEqual(expected4, actual4);

        }
    }
}
