using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class GrouponCodeDiscount
    {


        private double discountPercentage;
        private string validCode;


        public GrouponCodeDiscount(double discountPercentage, string validCode)
        {

            this.discountPercentage = discountPercentage;
            this.validCode = validCode;

        }


        public double ApplyDiscount(Shoppingcart cart)
        {

            if (cart.CouponCode == validCode)
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
