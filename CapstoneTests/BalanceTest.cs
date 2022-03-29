using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Capstone.Classes.Test
{
    [TestClass()]
    public class BalanceTest
    {
        [TestMethod]
        public void Menutests()
        {


            VendingMachine vm = new VendingMachine();
            VendingMachine.FeedMoney(5);

            Assert.AreEqual(5, VendingMachine.balance);













        }







    }
}
