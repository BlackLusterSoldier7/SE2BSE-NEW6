using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Discount
{
    public class BuyOneGetOneDiscount : IDiscountStrategy
    {

        private Product DiscountedProduct { get; }

        public BuyOneGetOneDiscount(Product product)
        {

            DiscountedProduct = product;


        }


        public double ApplyDiscount(double totalCost, Shoppingcart shoppingcart)
        {

            // Count how many times the discounted product appears in the shoppingcart 
            int productCount = 0;

            foreach (Entry item in shoppingcart.ViewProducts())
            {

                if (item.GetProduct() == DiscountedProduct)
                {
                    productCount++;
                }

            }

            // Calculate how many products will be discounted (half of the productCount)
            int discountedCount = productCount / 2;

            double discountValue = discountedCount * DiscountedProduct.Price;

            // Subtract the discount from the original price 
            return totalCost - discountValue;



        }



    }
}
