using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Bill
    {
        private List<Product> products;

        public double Discount { get; private set; }

        public double Total { get; private set; }

        public Bill(double total, double discount)
        {
            Total = total;
            Discount = discount;
        }
    }
}