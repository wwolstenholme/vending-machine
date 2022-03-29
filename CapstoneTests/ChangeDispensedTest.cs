using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace Capstone.Classes.Test
{
    [TestClass()]
    public class ChangeDispensedTest
    {
        [TestMethod]
        public void ChangeDispensedTests()
        {

            // Arrange
            ChangeDispensed vm = new ChangeDispensed(6.15M);
           
 
            //Act
            Assert.AreEqual(24, vm.Quarters, "Additional details about this test...");
            Assert.AreEqual(1, vm.Dimes, "Additional details about this test...");
            Assert.AreEqual(1, vm.Nickels, "Additional details about this test...");














        }
    }
}
