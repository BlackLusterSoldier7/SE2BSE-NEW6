using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class Discount2 : IDiscount
    {
        public int Amount { get; private set; }

        public Discount2(int amount)
        {
            Amount = amount;
        }

        public abstract bool DiscountCondition(string name, Shoppingcart cart);
        public abstract double ApplyDiscount(Shoppingcart cart);
    }
}