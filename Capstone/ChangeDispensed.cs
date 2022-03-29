using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class ChangeDispensed
    {
        public int Quarters { get; set; }

        public int Dimes { get; set; }

        public int Nickels { get; set; }

        public string ChangeAmount { get; private set; }


        public ChangeDispensed(decimal balance)
        {
            int FullBalance = (int)(balance * 100);

            this.Quarters = FullBalance / 25;

            FullBalance %= 25;
            
            this.Dimes = FullBalance / 10;

            FullBalance %= 10;

            this.Nickels = FullBalance / 5;

            ChangeAmount = ($"Returning {Quarters} Quarters, {Dimes} Dimes, and {Nickels} Nickels");

        }



        




    }
}
