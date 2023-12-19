using Domain;
using Infrastructure.DTO;
using NuGet.Frameworks;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class CategoryTests
    {
        [Fact]
        public void TestBubbleSortLowToHighPricesAscendingShouldSortMultipleProducts()
        {
            // Arrange 
            var category = new Category("TestCategory", "Test omschrijving");
            var products = new List<ProductDTO>
            {
                new ProductDTO { Price = 30.0 },
                new ProductDTO { Price = 10.0 },
                new ProductDTO { Price = 20.0 },
            };

            // Act 
            category.BubbleSortLowToHighPricesAscending(products);

            // Assert 
            var product1 = products[0];
            var product2 = products[1];
            var product3 = products[2];

            Assert.Equal(10.0, product1.Price);
            Assert.Equal(20.0, product2.Price);
            Assert.Equal(30.0, product3.Price);
        }

        [Fact]
        public void TestBubbleSortProductPriceDescendingOrderShouldSortSingleProduct()
        {
            // Arrange 
            var category = new Category("TestCategory", "Test omschrijving");
            var products = new List<ProductDTO>
            {
                new ProductDTO { Price = 10.0 }
            };

            // Act 
            category.BubbleSortProductPricesDescendingOrderFromHighToLow(products);

            // Assert 
            Assert.Equal(10.0, products[0].Price);
        }

        [Fact]
        public void TestBubbleSortProductPricesDescendingOrderShouldSortMultipleProductsDescending()
        {
            // Arrange 
            var category = new Category("TestCategory", "Test omschrijving");
            var products = new List<ProductDTO>
            {
                new ProductDTO { Price = 30.0 },
                new ProductDTO { Price = 10.0 },
                new ProductDTO { Price = 20.0 },
            };

            // Act 
            category.BubbleSortProductPricesDescendingOrderFromHighToLow(products);

            // Assert 
            Assert.Equal(30.0, products[0].Price);
            Assert.Equal(20.0, products[1].Price);
            Assert.Equal(10.0, products[2].Price);
        }

        [Fact]
        public void TestBubbleSortProductPricesDescendingOrderShouldHandleDuplicatePrices()
        {
            // Arrange 
            var category = new Category("TestCategory", "Test omschrijving");
            var products = new List<ProductDTO>
            {
                new ProductDTO { Price = 20.0 },
                new ProductDTO { Price = 10.0},
                new ProductDTO { Price = 20.0},
            };

            // Act 
            category.BubbleSortProductPricesDescendingOrderFromHighToLow(products);

            // Assert 
            Assert.Equal(20.0, products[0].Price);
            Assert.Equal(20.0, products[1].Price);
            Assert.Equal(10.0, products[2].Price);
        }
    }
}
