using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }

        public ProductCategory Category { get; set; }
        public List<ReviewDTO> Reviews { get; set; }

        public ProductDTO()
        {
        }

        public ProductDTO(string name, string description, double price, int amount)
        {
            Name = name;
            Description = description;
            Price = price;
            Amount = amount;
        }
    }
}