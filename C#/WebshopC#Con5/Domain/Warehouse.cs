using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Warehouse
    {




        public List<Entry> Entries { get; private set; }

        private List<Product> products;

        private List<ProductDTO> productDTOs; 





        public Warehouse()
        {

            Entries = new List<Entry>();
            products = new List<Product>();
            productDTOs = new List<ProductDTO>(); 
        }



        public void AddProduct(Product product, int amount)
        {

            if (product == null)
            {


                return; // exit method 
            }


            bool productFound = false;

            foreach (Entry entry in Entries)
            {


                if (entry.Product == product)
                {

                    entry.AddAmount(amount);

                    productFound = true;

                    break; // exit the loop. 


                }



            }



            if (!productFound)
            {


                Entry newEntry = new Entry(product);
                newEntry.AddAmount(amount);
                Entries.Add(newEntry);


            }




        }


        // 




        public int DeleteProduct(Product product, int amount)
        {

            foreach (Entry entry in Entries)
            {

                if (entry.Product == product)
                {


                    entry.DeleteAmount(amount);

                    if (entry.Amount <= 0)
                    {
                        Entries.Remove(entry);
                    }



                    return entry.Amount; 
                }

            }


            // If no matching entry is found, return 0. 
            return 0;
        }








        public double GetProductPrice(Product productToFind)
        {

            foreach (Product product in products)
            {

                if (product.Name == productToFind.Name)
                {

                    return product.Price;

                }

            }


            // Product not found in the warehouse 
            return 0;



        }


        public List<Product> GetProducts()
        {
            // Convert the list of ProductDTOs to a list of Products 
            List<Product> products = new List<Product>(); 

            foreach(ProductDTO productDTO in productDTOs)
            {
                Product product = new Product(productDTO.Name, productDTO.Description,
                    productDTO.Price, productDTO.Category);
                products.Add(product); 
            }
            return products; 
        }






    }

}

