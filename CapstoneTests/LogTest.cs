using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;


namespace Capstone.Classes.Test
{
    [TestClass()]
    public class LogTest
    {

        [TestMethod]
        public void Logtests()
        {
            Log log = new Log();
            string filepath = log.writefile();

            Assert.IsTrue(File.Exists(filepath));
            System.Console.WriteLine(filepath);


        }







    }
}
