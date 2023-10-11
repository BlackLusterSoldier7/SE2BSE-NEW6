using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Entry
    {

        private Product product;
        private int amount;

        public Entry(Product product)
        {
            this.product = product;
            amount = 0;
        }


        public int GetAmount()
        {
            return amount;
        }


        public Product GetProduct()
        {

            return product;


        }


        public void AddAmount(int stock)
        {

            amount = amount + stock;

        }


        public void DeleteAmount(int stock)
        {


            amount = amount - stock;

            // check on negative amount
            if (amount < 0)
            {
                amount = 0;


            }


        }




    }
}