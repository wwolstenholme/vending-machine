using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class Log
    {

        //private string Filepath = @"C:\Users\Student\workspace\mod-1-capstone-orange-team-1\capstone\Capstone\log.txt";

        public string writefile() 
        {
            const string logRelativeFileName = @"..\..\..\log.txt";
            string logdirectory = Environment.CurrentDirectory;
            string filenameLog = Path.Combine(logdirectory, logRelativeFileName);
            string Filepath = Path.GetFullPath(filenameLog);
            return Filepath;
           
        }

    

        public void LogDeposit(decimal amount, decimal finalBalance)
        {

            


            try
            {
                string Filepath = writefile();
                amount *= 1.00M;
                using (StreamWriter sw = new StreamWriter(Filepath, true))
                {
                    sw.WriteLine($"{DateTime.Now} FEED MONEY {amount}  {finalBalance}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        public void LogPurchase(string slot, string product, decimal initialBalance, decimal finalBalance)
        {
  


            try
            {
                string Filepath = writefile();
                using (StreamWriter sw = new StreamWriter(Filepath, true))
                {
                    sw.WriteLine($"{DateTime.Now} {product} {slot} {initialBalance} {finalBalance} ");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void LogChange(decimal initialBalance)
        {



            try
            {
                string Filepath = writefile();
                decimal finalBalance = 0.00M;
                using (StreamWriter sw = new StreamWriter(Filepath, true))
                {
                    sw.WriteLine($"{DateTime.Now} GIVE CHANGE {initialBalance}  {finalBalance}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }





    }
}
