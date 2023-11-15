using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class NewUserAccountDiscount : IDiscount
    {

        private double discountPercentage;
        private User user;





        public NewUserAccountDiscount(double discountPercentage, User user)
        {

            this.discountPercentage = discountPercentage;
            this.user = user;



        }




        public double ApplyDiscount(Shoppingcart cart)
        {


            if (user.IsNewUser)
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
