using Microsoft.VisualBasic;
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
            //DateTime today = DateTime.Today;
            int year = 2023;
            int month = 12;
            int day = 20;
            int hour = 12;
            int minute = 15;
            int second = 00;

            DateTime today = new DateTime(year, month, day, hour, minute, second);

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