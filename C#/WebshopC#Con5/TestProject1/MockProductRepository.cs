using Domain;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class MockProductRepository : IProductRepository
    {
        public List<ProductDTO> Products { get; set; }

        public MockProductRepository()
        {
            Products = new List<ProductDTO>();
        }

        public List<ProductDTO> GetAllProducts()
        {
            return Products;
        }

        public ProductDTO GetProductById(int id)
        {
            foreach (ProductDTO product in Products)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }
            return null;
        }

        public void AddProduct(ProductDTO product)
        {
            Products.Add(product);
        }

        public void UpdateProduct(ProductDTO product)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].Id == product.Id)
                {
                    Products[i].Name = product.Name;
                    Products[i].Description = product.Description;
                    Products[i].Price = product.Price;
                    Products[i].Amount = product.Amount;
                    break;
                }
            }
        }

        public void DeleteProduct(int id)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].Id == id)
                {
                    Products.RemoveAt(i);
                    break;
                }
            }
        }
    }
}