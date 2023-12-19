using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MoreThan2Discount : Discount
    {
        public MoreThan2Discount(int amount) : base(amount) { }

        public override bool DiscountCondition(string name, Shoppingcart cart)
        {
            foreach (var cartEntry in cart.cartEntries)
            {
                if (cartEntry.Product.Name == name && cartEntry.Amount > 2)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
