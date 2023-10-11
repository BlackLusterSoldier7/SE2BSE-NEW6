using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PercentageDiscount : IDiscountStrategy
    {

        private double percentage;

        public PercentageDiscount(double percentage)
        {
            this.percentage = percentage;

        }


        public double ApplyDiscount(double originalPrice)
        {

            return originalPrice * (percentage / 100);
        }


    }
}
