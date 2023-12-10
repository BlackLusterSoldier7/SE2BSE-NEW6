using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class GrouponCodeDiscountTests
    {
        [Fact]
        public void ApplyDiscount_withValidCouponCode_AppliesDiscountCorrectly()
        {
            // Arrange 
            var warehouse = new MockWarehouse();
            var mockCart = new MockShoppingcart(warehouse);
            var discount = new GrouponCodeDiscount(25, "DIS##123");

            mockCart.CouponCode = "DIS##123";
            var product = new Product("Test Product", "Description", 100, null);
            mockCart.AddProductToShoppingcart(product, 3);

            // Act 
            double result = discount.ApplyDiscount(mockCart);

            // Assert 
            double expectedDiscount = 100 * 3 * 0.25;
            Assert.Equal(expectedDiscount, result);
        }

        [Fact]
        public void ApplyDiscount_ValidCode()
        {
            // Arrange 
            GrouponCodeDiscount discount = new GrouponCodeDiscount(30, "dis33@#234");
            var warehouse = new MockWarehouse();
            var mockCart = new MockShoppingcart(warehouse);

            mockCart.CouponCode = "dis33@#234";
            var product = new Product("Samsung Smart TV", "4K OLED TV 75 inch. ", 100, null);
            mockCart.AddProductToShoppingcart(product, 3);

            // Act 
            double result = discount.ApplyDiscount(mockCart);

            // Assert 
            double expectedDiscount = 100 * 3 * 0.30;
            Assert.Equal(expectedDiscount, result);
        }

        [Fact]
        public void ApplyDiscount_InvalidCode()
        {
            // Arrange 
            var warehouse = new MockWarehouse();
            var mockCart = new MockShoppingcart(warehouse);
            var discount = new GrouponCodeDiscount(35, "##GroupC2");

            mockCart.CouponCode = "InvalidGrouponCode@@@##";
            var product = new Product("Bureaustoel Ahrend", "Ergonomische bureaustoel. ", 1300, null);
            mockCart.AddProductToShoppingcart(product, 5);

            // Act 
            double result = discount.ApplyDiscount(mockCart);

            // Assert 
            double expectedDiscount = 1300 * 5 * 0.35;
            Assert.Equal(expectedDiscount, result);
        }

        [Fact]
        public void ApplyDiscount_NoCartEntries()
        {
            // Arrange 
            var warehouse = new MockWarehouse();
            var mockCart = new MockShoppingcart(warehouse);
            var discount = new GrouponCodeDiscount(40, "Groupon99");

            mockCart.CouponCode = "Groupon99";

            // Act 
            double result = discount.ApplyDiscount(mockCart);

            // Assert 
            double expectedDiscount = 100 * 6 * 0.40;
            Assert.Equal(expectedDiscount, result);
        }

        [Fact]
        public void ApplyDiscount_NoCouponCode()
        {
            // Arrange 

            var warehouse = new MockWarehouse();
            var mockCart = new MockShoppingcart(warehouse);
            var discount = new GrouponCodeDiscount(22, "GroupCode$$");

            var product = new Product("Zit sta bureau Ahred", "Zit sta bureau Ahrend elektrisch verstelbaar", 3375, null);
            mockCart.AddProductToShoppingcart(product, 6);

            // Act 
            double result = discount.ApplyDiscount(mockCart);

            // Assert 
            double expectedDiscount = 3375 * 6 * 0.22;
            Assert.Equal(expectedDiscount, result);
        }

        //[Fact]
        //public void ApplyDiscount_ValidCode()
        //{
        //    // Arrange 
        //    GrouponCodeDiscount discount = new GrouponCodeDiscount(25, "#Marco123");
        //    Warehouse warehouse = new Warehouse();
        //    Shoppingcart cart = new Shoppingcart();
        //    cart.CouponCode = "#Marco123";
        //    Product product = new Product("Samsung Smart TV", "4K OLED TV 75 inch. ", 975, Shared.ProductCategory.Electronics);
        //    cart.AddProductToShoppingcart(product, 2);

        //    // Act 
        //    double result = discount.ApplyDiscount(cart);

        //    // Assert 
        //    Assert.Equal(487.5, result);
        //}





        //[Fact]
        //public void ApplyDiscount_InvalidCode()
        //{
        //    // Arrange 
        //    GrouponCodeDiscount discount = new GrouponCodeDiscount(12, "##GroupC2");
        //    Warehouse warehouse = new Warehouse();
        //    Shoppingcart cart = new Shoppingcart(warehouse);
        //    cart.CouponCode = "InvalidGrouponCode@@@##";
        //    Product product = new Product("Bureaustoel Ahrend", "Ergonomische bureaustoel. ", 1300, Shared.ProductCategory.Toys);
        //    cart.AddProductToShoppingcart(product, 5);

        //    // Act 
        //    double result = discount.ApplyDiscount(cart);

        //    // Assert 
        //    Assert.Equal(0, result);
        //}



        //[Fact]
        //public void ApplyDiscount_NoCartEntries()
        //{
        //    // Arrange 
        //    GrouponCodeDiscount discount = new GrouponCodeDiscount(17, "Groupon99");
        //    Warehouse warehouse = new Warehouse();
        //    Shoppingcart cart = new Shoppingcart(warehouse);
        //    cart.CouponCode = "Groupon99";

        //    // Act 
        //    double result = discount.ApplyDiscount(cart);

        //    // Assert 
        //    Assert.Equal(0, result);
        //}



        //[Fact]
        //public void ApplyDiscount_NoCouponCode()
        //{
        //    // Arrange 
        //    GrouponCodeDiscount discount = new GrouponCodeDiscount(22, "GroupCode$$");
        //    Warehouse warehouse = new Warehouse();
        //    Shoppingcart cart = new Shoppingcart(warehouse);
        //    Product product = new Product("Zit sta bureau Ahred", "Zit sta bureau Ahrend elektrische verstelbaar", 3375, Shared.ProductCategory.Toys);
        //    cart.AddProductToShoppingcart(product, 3);

        //    // Act 
        //    double result = discount.ApplyDiscount(cart);

        //    // Assert 
        //    Assert.Equal(0, result);

        //}
    }
}
