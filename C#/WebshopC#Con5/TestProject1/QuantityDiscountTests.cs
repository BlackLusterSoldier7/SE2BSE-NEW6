using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1
{
    public class QuantityDiscountTests
    {
        [Fact]
        public void TestApplyDiscount_NoDiscount()
        {
            // Arrange 
            Warehouse warehouse = new Warehouse();
            QuantityDiscount discount = new QuantityDiscount(5, 10);
            Domain.Shoppingcart cart = new Domain.Shoppingcart(warehouse);
            Product product = new Product("iPhone 15", "iPhone 15 Pro MAX 512 GB", 1900, Shared.ProductCategory.Electronics);
            cart.AddProductToShoppingcart(product, 3);

            // Act 
            double result = discount.ApplyDiscount(cart);

            // Assert 
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestApplyDiscount_DiscountApplied()
        {
            // Arrange 
            Warehouse warehouse = new Warehouse();
            QuantityDiscount discount = new QuantityDiscount(5, 10);
            Domain.Shoppingcart cart = new Domain.Shoppingcart(warehouse);
            Product product = new Product("HP Laptop 2023", "i9 processor, 1 TB SSD, 64 GB RAM en 128 GB VideoKaart", 2500, Shared.ProductCategory.Electronics);
            cart.AddProductToShoppingcart(product, 9);

            // Act 
            double result = discount.ApplyDiscount(cart);

            // Assert 
            Assert.Equal(2250, result);
        }

        [Fact]
        public void TestApplyDiscount_NoCartEntries()
        {
            // Arrange 
            Warehouse warehouse = new Warehouse();
            QuantityDiscount discount = new QuantityDiscount(6, 15);
            Domain.Shoppingcart cart = new Domain.Shoppingcart(warehouse);

            // Act 
            double result = discount.ApplyDiscount(cart);

            // Assert 
            Assert.Equal(0, result); // No discount applied. 
        }

        [Fact]
        public void TestApplyDiscount_NotEnoughQuantity()
        {
            // Arrange 
            Warehouse warehouse = new Warehouse();
            QuantityDiscount discount = new QuantityDiscount(7, 13);
            Domain.Shoppingcart cart = new Domain.Shoppingcart(warehouse);
            Product product = new Product("Playstation 5", "Playstation 5 met Call of Duty Modern Warefare III. ", 550, Shared.ProductCategory.Electronics);
            cart.AddProductToShoppingcart(product, 3);

            // Act 
            double result = discount.ApplyDiscount(cart);

            // Assert 
            Assert.Equal(0, result);
        }
    }
}