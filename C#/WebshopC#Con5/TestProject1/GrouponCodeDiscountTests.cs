using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1
{
    public class GrouponCodeDiscountTests
    {
        // Dit mag dus niet in de logica, omdat een klant dan geld korting terug krijgt. 
        [Fact]
        public void ApplyDiscount_withNegativaAmount_CheckWhatHappensWithNegativeAmount()
        {
            // Arrange 
            var warehouse = new MockWarehouse();
            var mockCart = new MockShoppingcart(warehouse);
            var discount = new GrouponCodeDiscount(15, "NegaDi##@");

            mockCart.CouponCode = "NegaDi##@";
            var product = new Product("Arduino", "Arduino Uno R4 ", 65, null);
            mockCart.AddProductToShoppingcart(product, -15);

            // Act 
            double result = discount.ApplyDiscount(mockCart);

            // Assert 
            double expectedDiscount = 65 * -15 * 0.15;
            Assert.Equal(expectedDiscount, result);
        }

        // Check wat ApplyDiscount methode doet wanneer de totalebedrag in winkelwagen 0 is 
        public void DoNotApplyDiscount_whenShoppingcartTotalIsZero_CheckWhatHappensWithValueZeroInShoppingcart()
        {
            // Arrange 
            var warehouse = new MockWarehouse();
            var mockCart = new MockShoppingcart(warehouse);
            var discount = new GrouponCodeDiscount(26, "ShoppZeroDi#");

            mockCart.CouponCode = "ShoppZeroDi#";
            var product = new Product("Raspberry Pi", "Raspberry Pi Pico - W", 46, null);
            mockCart.AddProductToShoppingcart(product, 0);

            // Act 
            double result = discount.ApplyDiscount(mockCart);

            // Assert 
            double expectedDiscount = 46 * 0 * 0.26;
            Assert.Equal(expectedDiscount, result);
        }

        // Testen wanneer er producten in Winkelwagen zijn maar de producten prijs zijn 
        // bijvoorbeeld 0 euro. Ook dan mag je geen korting toepassen. Omdat de klant anders 
        // geld terug krijgt. 
        public void DoNotApplyDiscount_whenProductsAreInShoppingcart_productsPricesZero()
        {
            // Arrange 
            var warehouse = new MockWarehouse();
            var mockCart = new MockShoppingcart(warehouse);
            var discount = new GrouponCodeDiscount(14, "ZeroPrice@#67");

            mockCart.CouponCode = "ZeroPrice@#67";
            var product1 = new Product("USB to Serial RS485", "USB to Serial RS485 Cable", 0, null);
            var product2 = new Product("Raspberry Pi", "Raspberry Pi Pico - W", 0, null);
            var product3 = new Product("Raspberry Pi", "Raspberry Pi Pico - W", 0, null);
            var product4 = new Product("Raspberry Pi", "Raspberry Pi Pico - W", 0, null);
            var product5 = new Product("Raspberry Pi", "Raspberry Pi Pico - W", 0, null);
            var product6 = new Product("Raspberry Pi", "Raspberry Pi Pico - W", 0, null);
            var product7 = new Product("Raspberry Pi", "Raspberry Pi Pico - W", 0, null);
            var product8 = new Product("Raspberry Pi", "Raspberry Pi Pico - W", 0, null);
            mockCart.AddProductToShoppingcart(product1, 10);
            mockCart.AddProductToShoppingcart(product2, 20);
            mockCart.AddProductToShoppingcart(product3, 30);
            mockCart.AddProductToShoppingcart(product4, 50);
            mockCart.AddProductToShoppingcart(product5, 100);
            mockCart.AddProductToShoppingcart(product6, 3);
            mockCart.AddProductToShoppingcart(product7, 17);
            mockCart.AddProductToShoppingcart(product8, 2);

            // Act 
            double result = discount.ApplyDiscount(mockCart);

            // Assert 
            double expectedDiscount = 100 * 0 * 0.14;
            Assert.Equal(expectedDiscount, result);
            double expectedDiscountProductRandom = 50 * 0 * 0.14;
            Assert.Equal(expectedDiscountProductRandom, result);
        }

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
            double expectedDiscount = 0;
            Assert.Equal(expectedDiscount, result);
        }
    }
}