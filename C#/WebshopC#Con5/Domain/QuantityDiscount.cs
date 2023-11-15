using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class QuantityDiscount : IDiscount
    {

        private int requiredQuantity;
        private double discountPercentage;



        public QuantityDiscount(int requiredQuantity, double discountPercentage)
        {


            this.requiredQuantity = requiredQuantity;
            this.discountPercentage = discountPercentage;

        }




        public double ApplyDiscount(Shoppingcart cart)
        {

            int totalQuantity = 0;

            foreach (var entry in cart.cartEntries)
            {


                totalQuantity += entry.Amount;


            }







            if (totalQuantity >= requiredQuantity)
            {

                double total = 0;

                foreach (var entry in cart.cartEntries)
                {


                    total += entry.Product.Price * entry.Amount;

                }

                return total * (discountPercentage / 100);


            }
            return 0;





        }










    }
}
