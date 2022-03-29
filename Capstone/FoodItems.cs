using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class FoodItems
    {

        public string Name { get; set; }
        
        public decimal Price { get; set; }

        public string Type { get; set; }

        public int Quantity { get; set; }

        public FoodItems( string name, decimal price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
            this.Quantity = 5;
        }

        public void updateQuantity()
        {
            this.Quantity--;
        }





    }
}
