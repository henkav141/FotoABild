using System.Collections.Generic;

using FotoABildShared;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FotoABildTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sharedpropertieslist = new List<SharedProperties>();
            var shared1 = new SharedProperties("", 25, "10x15");
            var shared2 = new SharedProperties("", 420, "15x21");
            var shared3 = new SharedProperties("", 7, "20x30");
            var shared4 = new SharedProperties("", 2, "25x38");
            var shared5 = new SharedProperties("", 7, "25x38");
            sharedpropertieslist.Add(shared1);
            sharedpropertieslist.Add(shared2);
            sharedpropertieslist.Add(shared3);
            sharedpropertieslist.Add(shared4);
            sharedpropertieslist.Add(shared5);

            var pricecalc = new PriceCalculator(sharedpropertieslist);



            int expected1 = 100 + 420 * 15 + 360 + 630;
            var actual1 = pricecalc.CalculateTotalPrice();

            var expected2 = 130;
            var actual2 = pricecalc.Calculate2();
            var expected3 = 150;
            var actual3 = pricecalc.Calculate3();
            var expected4 = 400;
            var actual4 = pricecalc.Calculate4();



            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
            Assert.AreEqual(expected4, actual4);

        }
    }
}
