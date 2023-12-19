using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class MockShoppingcart : Shoppingcart
    {
        public MockShoppingcart(IWarehouse warehouse) : base(warehouse)
        {
        }

        public new void AddProductToShoppingcart(Product product, int amount)
        {
            base.AddProductToShoppingcart(product, amount);
        }
    }
}