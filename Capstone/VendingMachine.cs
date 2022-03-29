using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
   public class VendingMachine
   {
        public static decimal balance { get; set; } = 0.00M;


        public static void FeedMoney(int dollars)
        {


            balance += dollars;
        }



        public static Dictionary<string, FoodItems> ReadFile()
        {



            // Directory and file name
            //string directory = @"C:\Users\Student\workspace\mod-1-capstone-orange-team-1\capstone\Capstone";
            //string filename = "vendingmachine.csv";

            // Full Path
            //string fullPath = Path.Combine(directory, filename);



            const string relativeFileName = @"..\..\..\vendingmachine.csv";
            string directory = Environment.CurrentDirectory;
            string filename = Path.Combine(directory, relativeFileName);
            string fullPath = Path.GetFullPath(filename);


            Dictionary<string, FoodItems> allFoods = new Dictionary<string, FoodItems>();

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] foodItemData = line.Split('|');
                        FoodItems fooditem = new FoodItems(foodItemData[1], decimal.Parse(foodItemData[2]), foodItemData[3]);
                        allFoods[foodItemData[0]] = fooditem;

                    }
                    //Console.WriteLine(allFoods);
                }
                return allFoods;
            }
            catch (IOException)
            {
                Console.WriteLine("There is no file by that name, sorry.");
                return null;
            }
        }

        public static void MainMenu(Dictionary<string, FoodItems> allFoods)
        {
            int optionSelected = 0;
            while (optionSelected < 1 || optionSelected > 3)
            {
                try
                {
                    Console.WriteLine("(1) Display Vending Machine Items");
                    Console.WriteLine("(2) Purchase");
                    Console.WriteLine("(3) Exit");
                    optionSelected = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Sorry, that is not a valid option");
                }
            }
            if (optionSelected == 1)
            {
                foreach(KeyValuePair<string, FoodItems> food in allFoods)
                {
                    Console.Write($"{food.Key} {food.Value.Name} {food.Value.Price} ");
                    Console.Write(food.Value.Quantity == 0 ? "Qty: Sold Out" : $"Qty {food.Value.Quantity}");
                    Console.Write("\n");
                }
                Console.WriteLine();
                MainMenu(allFoods);
            }
            else if (optionSelected == 2)
            {
                //more code
                //method for purchasing item
                PurchaseItem(allFoods);
            }
            else
            {
                Console.WriteLine("Thank you!");


            }
        }

        public static void PurchaseItem(Dictionary<string, FoodItems> foodItems)
        {
            Log log = new Log();
            int optionSelected = 0;
            while (optionSelected < 1 || optionSelected > 3)
            {
                try
                {
                    Console.WriteLine("(1) Feed Money");
                    Console.WriteLine("(2) Select Product");
                    Console.WriteLine("(3) Finish Transaction");
                    Console.WriteLine($"\nCurrent Money Provided: {balance}");
                    optionSelected = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Sorry, that is not a valid option!");
                }
            }
            if (optionSelected == 1)
            {
                bool keepFeedingMoney = false;
                do
                {
                    try
                    {
                        int dollars = 0;
                        Console.WriteLine("Please feed a dollar amount");
                        dollars = int.Parse(Console.ReadLine());
                      

                        if (dollars > 0)
                        {
                            FeedMoney(dollars);
                               
                            Console.Write(balance);
                            Console.WriteLine(" Keep feeding money Y or N");
                            string feedMoney = Console.ReadLine();
                            log.LogDeposit(dollars, balance);

                            if (feedMoney.ToUpper() == "Y")
                            {
                                keepFeedingMoney = true;
                            }
                            else
                            {
                                keepFeedingMoney = false;
                                PurchaseItem(foodItems);
                            }
                        }
                        else
                        {
                            Console.WriteLine("That is not a valid dollar amount.");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Sorry, that is not a valid option");
                        PurchaseItem(foodItems);
                    }
                }
                while (keepFeedingMoney);
            }




            else if (optionSelected == 2)
            {

                foreach (KeyValuePair<string, FoodItems> food in foodItems)
                {
                    Console.Write($"{food.Key} {food.Value.Name} {food.Value.Price} ");
                    Console.Write(food.Value.Quantity == 0 ? "Qty: Sold Out" : $"Qty {food.Value.Quantity}");
                    Console.Write("\n");
                }


                Console.WriteLine("\nPlease enter the product slot number.");
                string property = Console.ReadLine();
                if (foodItems.ContainsKey(property))
                {
                    if (foodItems[property].Quantity < 1)
                    {
                        Console.WriteLine("Sorry, that item is sold out.");
                    }
                    else if (foodItems[property].Price > balance)
                    {
                        Console.WriteLine("Sorry, you do not have enough money to purchase this item.");
                    }
                    else
                    {

                        Console.WriteLine("Your item will be dispensed below");
                        balance -= foodItems[property].Price;
                        Console.WriteLine($"{foodItems[property].Name}|{foodItems[property].Price}|Balance Remaining: {balance}");
                        foodItems[property].updateQuantity();
                        switch (foodItems[property].Type)
                        {
                            case "Chip":
                                Console.WriteLine("Crunch Crunch, Yum!");
                                break;
                            case "Candy":
                                Console.WriteLine("Munch Munch, Yum!");
                                break;
                            case "Drink":
                                Console.WriteLine("Glug Glug, Yum!");
                                break;
                            case "Gum":
                                Console.WriteLine("Chew Chew, Yum!");
                                break;
                            default:
                                Console.WriteLine("Yum Yum, Yum!");
                                break;
                        }

                        log.LogPurchase(property, foodItems[property].Name, balance + foodItems[property].Price, balance);








                    }
                }
                else
                {
                    Console.WriteLine("Sorry, that is not a valid option.");
                }
                PurchaseItem(foodItems);
           
            }
           
            else
            {
                Console.WriteLine("Thank you!");
          
                log.LogChange(balance);
                ChangeDispensed changeDispensed = new ChangeDispensed(balance);
                Console.WriteLine(changeDispensed.ChangeAmount);
                balance = 0.00M;
                VendingMachine.MainMenu(foodItems);
            }
        }



        }
}
