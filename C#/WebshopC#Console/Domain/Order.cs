using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order
    {


        public User Buyer { get; private set; } // The user who made the order 
        public List<Entry> Items { get; private set; } // Items being purchased in this order 

        public DateTime OrderDate { get; } // The date and time when the order was made 

        public string Shippingaddress { get; } // Address to which the items should be shipped

        public OrderStatus Status { get; private set; }



        public Order(User buyer)
        {


            Buyer = buyer;
            Items = new List<Entry>();
            OrderDate = DateTime.Now;
            Status = OrderStatus.Processing;

        }


        public double CalculateTotal()
        {
            double totalCost = 0;

            foreach (Entry item in Items)
            {

                double itemCost = item.GetProduct().Price * item.GetAmount();


                totalCost = totalCost + itemCost;

            }

            return totalCost;

        }





    }
}
