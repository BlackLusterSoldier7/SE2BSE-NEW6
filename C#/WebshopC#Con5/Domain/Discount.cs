using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class Discount
    {
        public int Amount { get; private set; }

        protected Discount(int amount)
        {
            Amount = amount;
        }

        public abstract bool DiscountCondition(string name, Shoppingcart cart);

        public double ApplyDiscount(double price)
        {
            return price - (price * (Amount / 100.0));
        }
    }
}