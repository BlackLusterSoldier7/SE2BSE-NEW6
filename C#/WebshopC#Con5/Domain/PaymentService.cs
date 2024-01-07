using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PaymentService
    {
        public List<Product> Products { get; private set; }


        public PaymentService()
        {
            Products = new List<Product>();
       
        }


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