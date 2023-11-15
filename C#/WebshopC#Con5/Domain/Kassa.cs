using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Kassa
    {

        public Bill CheckOut(Shoppingcart shoppingCart, List<IDiscount> discounts)
        {

            double total = shoppingCart.CalculateTotalPrice();
            double totalDiscount = 0;





            



            foreach(var discount in discounts)
            {

                totalDiscount += discount.ApplyDiscount(shoppingCart); 

            }


           
            return new Bill(total, totalDiscount);


        }

   

    }
}
