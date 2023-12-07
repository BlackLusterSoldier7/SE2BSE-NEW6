using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IWarehouse
    {
        void AddProduct(Product product, int amount);
        int DeleteProduct(Product product, int amount);
        double GetProductPrice(Product product);
        List<Product> GetProducts();
    }
}