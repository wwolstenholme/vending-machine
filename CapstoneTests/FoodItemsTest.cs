
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone.Classes.Test
{
    [TestClass()]
    public class FoodItemsTest
    {


        [TestMethod]
        public void FoodItemsTests()
        {

            FoodItems fm = new FoodItems("Moonpie", 5, "Candy");
            fm.updateQuantity();


            Assert.AreEqual(4, fm.Quantity);






        }






    }
}
