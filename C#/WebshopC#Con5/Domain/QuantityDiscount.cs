using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class QuantityDiscount : IDiscount

    {
        private int requiredQuantity;
        private double discountPercentage;

        public QuantityDiscount(int requiredQuantity, double discountPercentage)
        {
            this.requiredQuantity = requiredQuantity;
            this.discountPercentage = discountPercentage;
        }

        public double ApplyDiscount(Shoppingcart cart)
        {
            double discountAmount = 0;

            foreach (var entry in cart.cartEntries)
            {
                // Controleren of de hoeveelheid van het huidige product voldoet aan de vereiste Quantity 
                if (entry.Amount >= requiredQuantity)
                {
                    // Alleen de korting toepassen op de prijs van de producten die de requireQuantity bereiken.
                    double productTotal = entry.Product.Price * entry.Amount;
                    discountAmount += productTotal * (discountPercentage / 100);
                }
            }
            return discountAmount;
        }
    }
}