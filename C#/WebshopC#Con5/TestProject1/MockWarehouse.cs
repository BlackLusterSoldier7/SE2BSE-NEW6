using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class MockWarehouse : IWarehouse
    {
        private List<Product> products;
        private List<int> quantities;
        public List<Entry> Entries { get; private set; }

        public MockWarehouse()
        {
            products = new List<Product>();
            quantities = new List<int>();
            Entries = new List<Entry>();
        }

        public void AddProduct(Product product, int amount)
        {
            int index = FindProductIndex(product);
            if (index != -1)
            {
                // Product bestaat, verhoog aantal 
                quantities[index] += amount;
            }
            else
            {
                // Nieuw product, voeg toe aan lijst 
                products.Add(product);
                quantities.Add(amount);
            }
        }

        public int DeleteProduct(Product product, int amount)
        {
            int index = FindProductIndex(product);

            if (index != -1)
            {
                // Product bestaat, verlaag aantal
                int availableAmount = quantities[index];
                int amountToDelete;

                if (amount <= availableAmount)
                {
                    amountToDelete = amount;
                }
                else
                {
                    amountToDelete = availableAmount;
                }

                quantities[index] -= amountToDelete;
                return amountToDelete;
            }
            return 0; // Product niet gevonden. 
        }

        public double GetProductPrice(Product product)
        {
            if (product.Name == "Product 1")
            {
                return 100;
            }
            else if (product.Name == "Product 2")
            {
                return 200;
            }
            return 50; // Default prijs 
        }

        public List<Product> GetProducts()
        {
            return new List<Product>(products);
        }

        private int FindProductIndex(Product product)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Name == product.Name)
                {
                    return i;
                }
            }
            return -1; // Product not found 
        }
    }
}