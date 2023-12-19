using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UniqueDiscountOLD : Discount
    {
        public UniqueDiscountOLD(int amount) : base(amount) { }

        public override bool DiscountCondition(string name, Shoppingcart cart)
        {
            foreach (var cartEntry in cart.cartEntries)
            {
                if (cartEntry.Product.Name == name && cartEntry.Amount == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
