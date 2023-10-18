using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Catalog
    {

        private List<Product> products; 

        public Catalog()
        {
            products = new List<Product>(); 
        }


        public void AddProduct(Product product)
        {
            if (product == null) return;
            products.Add(product); 
        }

        public void RemoveProduct(Product product)
        {
            if (product == null) return;
            products.Remove(product); 

        }

        // Return all products in the catalog 
        public List<Product> GetAllProducts()
        {
            return products; 
        }

        // Filter products based on a category 

        public List<Product> FilterProductsByCategory(ProductCategory category)
        {

            List<Product> filteredProducts = new List<Product>(); 

            foreach(Product product in products)
            {

                if(product.Category == category)
                {
                    filteredProducts.Add(product); 
                }

            }

            return filteredProducts; 


        }








    }
}
