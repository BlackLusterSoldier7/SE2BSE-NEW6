using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IDiscount
    {
        double ApplyDiscount(Shoppingcart cart);

        // Eventuele uitbreidingen. Door tijdsgebrek niet geimplementeerd. 
        // check conditions, minimum cart value, specific items present in the cart etc. 
        // bool IsValidForCart(Shoppingcart cart);

        // current discount can be combined with another discount?
        // bool CanCombineWith(IDiscount otherDiscount); 

        // ApplyDiscountToItem can discounts apply to spefic items insteand of the whole cart
        // bedoeld voor een individu product. 
        //double ApplyDiscountToItem(Product item); 
    }
}