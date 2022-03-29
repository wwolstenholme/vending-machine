using System;
using System.Collections.Generic;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello!");


            Dictionary<string, FoodItems> foodItems = new Dictionary<string, FoodItems>();
            foodItems = VendingMachine.ReadFile();
            VendingMachine.MainMenu(foodItems);


           
        }
    }
}
