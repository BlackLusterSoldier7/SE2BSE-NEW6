using Domain.DTO;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Category
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Product> Products { get; private set; }

        public Category(string name, string description)
        {
            this.Name = name;
            this.Description = description;
            this.Products = new List<Product>();
        }

        public void BubbleSortLowToHighPricesAscending(List<ProductDTO> products)
        {
            int lengthArray = products.Count;
            bool sorted = false;

            while (!sorted)
            {
                sorted = true;
                for (int i = 0; i < lengthArray - 1; i++)
                {
                    double price1 = products[i].Price;
                    double price2 = products[i + 1].Price;

                    if (price1 > price2)
                    {
                        // Swap the elements 
                        ProductDTO temp = products[i];
                        products[i] = products[i + 1];
                        products[i + 1] = temp;
                        sorted = false;
                    }
                }
                lengthArray -= 1;
            }
        }

        public void BubbleSortProductPricesDescendingOrderFromHighToLow(List<ProductDTO> products)
        {
            int lengthArray = products.Count;
            bool sorted = false;

            while (!sorted)
            {
                sorted = true;
                for (int i = 0; i < lengthArray - 1; i++)
                {
                    double price1 = products[i].Price;
                    double price2 = products[i + 1].Price;
                    if (price1 < price2)
                    {
                        // Swap the elements 
                        ProductDTO temp = products[i];
                        products[i] = products[i + 1];
                        products[i + 1] = temp;
                        sorted = false;
                    }
                }
                lengthArray -= 1;
            }
        }
    }
}