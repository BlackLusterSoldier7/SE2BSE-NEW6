using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BlackFridayDiscount : IDiscount
    {


        private double discountPercentage;

        public BlackFridayDiscount(double discountPercentage)
        {

            this.discountPercentage = discountPercentage;

        }



        public double ApplyDiscount(Shoppingcart cart)
        {


            DateTime today = DateTime.Today;
            DateTime blackFriday = GetLastFridayOfNovember(today.Year);

            if (today == blackFriday)
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


    

        private DateTime GetLastFridayOfNovember(int year)
        {


            DateTime lastDayOfNovember = new DateTime(year, 11, 30);

            int daysUntilLastFriday = (int)lastDayOfNovember.DayOfWeek - (int)DayOfWeek.Friday;

            if(daysUntilLastFriday >= 0)
            {

                lastDayOfNovember = lastDayOfNovember.AddDays(-daysUntilLastFriday); 

            }
            else
            {


                lastDayOfNovember = lastDayOfNovember.AddDays(-(7 + daysUntilLastFriday));
            }


            return lastDayOfNovember; 

        }










    }
}
