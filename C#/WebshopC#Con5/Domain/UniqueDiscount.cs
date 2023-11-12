using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UniqueDiscount : Discount 
    {


        public UniqueDiscount(int amount) : base(amount) { }



        public override bool DiscountCondition(string name, Shoppingcart cart)
        {
            var namedProduct = cart.cartEntries.FirstOrDefault(p => p.Product.Name == name);
            return namedProduct != null && namedProduct.Amount == 1;
        }





    }
}
