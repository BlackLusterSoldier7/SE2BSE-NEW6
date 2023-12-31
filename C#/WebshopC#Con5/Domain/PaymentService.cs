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
        public Shoppingcart shoppingcart { get; private set; }

        public PaymentService(Shoppingcart shoppingcart)
        {
            Products = new List<Product>();
            this.shoppingcart = shoppingcart;
        }

        public PaymentResultDTO DoPayment(Order order)
        {
            PaymentResultDTO paymentResultDTO = new PaymentResultDTO
            {
                Success = false,
                Message = "Payment failed: Invalid order or shopping cart is empty. "
            };

            if (order != null && shoppingcart != null && Products.Count > 0)
            {
                paymentResultDTO.Success = true;
                paymentResultDTO.Message = "Payment successful for order " + order.Shippingaddress + " eigenlijk order number of ID. Voor test shippingadres gedaan. ";
                paymentResultDTO.AmountPaid = shoppingcart.CalculateTotalPrice();
            }
            return paymentResultDTO;
        }
    }
}