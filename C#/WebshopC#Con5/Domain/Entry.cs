
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    // Entry eventueel veranderen naar InventoryItem
    public class Entry
    {

        private Product product;
        private int amount;



        public int Amount
        {
            get { return amount; }
        }


        public Product Product
        {
            get { return product; }
        }



        public Entry(Product product)
        {
            this.product = product;
            amount = 0;
        }











        public void AddAmount(int stock)
        {

            if (stock < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(stock), "Stock cannot be negative.");

            }
            amount += stock;

        }


        public void DeleteAmount(int stock)
        {


            if (stock < 0) throw new ArgumentOutOfRangeException(nameof(stock), "Stock cannot be negative.");
            if (stock > amount) throw new InvalidOperationException("Not enough to delete");
            amount -= stock;
        }
    }
}