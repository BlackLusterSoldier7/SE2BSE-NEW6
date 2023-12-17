
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

        public Entry(Product product, int amount)
        {
            this.product = product;
            this.amount = amount;
        }

        public bool AddAmount(int stock)
        {
            if (stock < 0)
            {
                Console.WriteLine("Stock can not be negative.");
                return false;
            }
            amount += stock;
            return true;
        }

        public bool DeleteAmount(int stock)
        {
            if (stock < 0)
            {
                Console.WriteLine("Stock can not be negative.");
                return false;
            }

            if (stock > amount)
            {
                Console.WriteLine("Not enough stock to delete.");
                return false;
            }
            amount -= stock;
            return true;
        }
    }
}