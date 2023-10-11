using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class ProductDTO
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
        public int Amount { get; private set; }



        public ProductDTO(string name, string description, double price, int amount)
        {

            Name = name;
            Description = description;
            Price = price;
            Amount = amount;

        }




    }
}
