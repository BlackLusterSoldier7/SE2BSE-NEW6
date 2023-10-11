using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {

        private string name;
        private string description;
        private double price;
        private int amount;
        private List<Review> reviews;





        public Product(string name, string description, double price, int amount)
        {

            this.name = name;
            this.description = description;
            this.price = price;
            this.amount = amount;
        }





        // Properties 

        public string Name
        {
            get { return name; }
        }


        public string Description
        {

            get { return description; }
        }


        public double Price
        {

            get { return price; }

        }


        public int Amount
        {

            get { return amount; }
        }



    }
}
