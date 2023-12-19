using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;



namespace Domain
{
    public class Catalog
    {


        public string Name { get; private set; }
        public string Description { get; private set; }
        public Warehouse Warehouse { get; private set; } 

        public Catalog(string name, string description, Warehouse warehouse)
        {
            Name = name;
            Description = description;
            Warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse), "Warehouse cannot be null"); 

        }


        public List<Product> GetProducts()
        {
            return Warehouse.GetProducts(); 
        }


    }
}
