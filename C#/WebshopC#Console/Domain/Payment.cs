using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Payment
    {

        public Order RelatedOrder { get; private set; } // The order associated with this payment 
        public DateTime PaymentDate { get; private set; } // Date and time when the payment was made 
        public PaymentMethod Method { get; private set; } // Method used for payment Creditcard, PayPal, iDEAL 

        public PaymentStatus Status { get; private set; } // Current status of the payment 

        public double Amount { get; } 


        public Payment(Order order)
        {

            RelatedOrder = order;
            Amount = order.CalculateTotal();
            PaymentDate = DateTime.Now;
            Status = PaymentStatus.Pending;  

        }




    }
}
