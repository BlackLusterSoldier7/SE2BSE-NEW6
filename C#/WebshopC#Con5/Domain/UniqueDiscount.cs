using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UniqueDiscount : Discount2
    {
        public UniqueDiscount(int amount) : base(amount) { }

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

        public override double ApplyDiscount(Shoppingcart cart)
        {
            double discountAmount = 0;

            foreach (var cartEntry in cart.cartEntries)
            {
                if (DiscountCondition(cartEntry.Product.Name, cart))
                {
                    // Pas de korting toe op de prijs van dit specifieke product 
                    discountAmount += cartEntry.Product.Price * (Amount / 100.00);
                }
            }
            return discountAmount;
        }
    }
}