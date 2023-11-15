using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ChristmasDiscount : IDiscount
    {



        private double discountPercentage;

        public ChristmasDiscount(double discountPercentage)
        {

            this.discountPercentage = discountPercentage;



        }



        public double ApplyDiscount(Shoppingcart cart)
        {


            DateTime today = DateTime.Today;

            if (today.Month == 12)
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
