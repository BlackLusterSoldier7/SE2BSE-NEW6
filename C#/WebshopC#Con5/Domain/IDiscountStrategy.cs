using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IDiscountStrategy
    {

        double ApplyDiscount(double originalPrice, Shoppingcart shoppingcart);


    }
}
