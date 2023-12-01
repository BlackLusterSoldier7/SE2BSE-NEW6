using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Kassa
    {
        public Bill CheckOut(Shoppingcart shoppingcart, List<IDiscount> discounts)
        {
            double total = shoppingcart.CalculateTotalPrice();
            double totalDiscount = 0;

            foreach (var discount in discounts)
            {
                double discountAmount = discount.ApplyDiscount(shoppingcart);
                totalDiscount += discountAmount;

                // De totale korting mag niet meer dan totaalbedrag zijn 
                if (totalDiscount > total)
                {
                    totalDiscount = total;
                    break;
                }
            }
            return new Bill(total, totalDiscount);
        }
    }
}