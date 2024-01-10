using Domain;
using Domain.DTO;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Diagnostics.SymbolStore;

namespace TestProject1
{
    public class ProductServiceTests
    {
        [Fact]
        public void GetSearchHistoryRecommendations_ReturnsEmptyList_WhenUserHasNoSearchHistory()
        {
            // Arrange 
            var mockProductRepository = new MockProductRepository();
            var productService = new ProductService(mockProductRepository);
            var user = new User("testUsername", new Warehouse());

            // Act
            var recommendations = productService.GetSearchHistoryRecommendations(user);

            // Assert 
            // Checks of de recommendations lijst leeg is. 
            // De reden hiervoor is, omdat de User geen zoekgeschiedenis heeft. Zie naam unit test 
            Assert.Empty(recommendations);
        }


        [Fact]
        public void GetSearchHistoryRecommendations_ReturnsCorrectRecommendations_WhenUserHasSearchHistory()
        {
            // Arrange 
            var mockProductRepository = new MockProductRepository();
            mockProductRepository.Products = new List<Domain.DTO.ProductDTO>
            {
                new ProductDTO { Name = "Arduino UNO R4 ", Description = "The Arduino UNO R4 WiFi combines the processing power and exciting new peripherals of the RA4M1 microcontroller from Renesas with the wireless connectivity power of the ESP32-S3 from Espressif. On top of this, the UNO R4 WiFi offers an on-board 12x8 LED matrix, Qwiic connector, VRTC, and OFF pin, covering all potential needs makers will have for their next project.", Price = 45 },
                new ProductDTO { Name = "Raspberry Pi Pico", Description = "Powerful, flexible microcontroller boards, available from $4\r\n\r\nThe Raspberry Pi Pico series is a range of tiny, fast, and versatile boards built using RP2040, the flagship microcontroller chip designed by Raspberry Pi in the UK", Price = 17 },
                new ProductDTO { Name = "Embedded Systems Fundamentals with Arm Cortex-M based Microcontrollers", Description = "Now in its 2nd edition, this textbook has been updated on a new development board from STMicroelectronics - the Arm Cortex-M0+ based Nucleo-F091RC. Designed to be used in a one- or two-semester introductory course on embedded systems.", Price = 85 }
            };

            var productService = new ProductService(mockProductRepository);
            var user = new User("testUsername", new Warehouse());
            AddSearchHistory(user, new List<string> { "arduino", "raspberry" });

            // Act 
            var recommendations = productService.GetSearchHistoryRecommendations(user);

            // Assert 
            Assert.NotNull(recommendations);
            Assert.True(recommendations.Count > 0);
            // Assert.Equal(2, recommendations.Count);
            // Assert.True(ListContainsProductWithName(recommendations, "arduino"));
            // Assert.True(ListContainsProductWithName(recommendations, "raspberry"));
        }

        private void AddSearchHistory(User user, List<string> searches)
        {
            foreach (var search in searches)
            {
                user.SearchHistory.Add(search);
            }
        }

        private bool ListContainsProductWithName(List<ProductDTO> list, string productName)
        {
            foreach (var product in list)
            {
                if (product.Name.ToLower().Contains(productName.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        private bool AreStringsEqualIgnoreCase(string a, string b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (char.ToLower(a[i]) != char.ToLower(b[i]))
                {
                    return false;
                }
            }
            return true;
        }


        [Theory]
        //[InlineData("sterrenbeeld", "str", true)] // Search string gevonden aan het begin 
        //[InlineData("sterrenbeeld", "eld", true)] // Search string gevonden aan het eind
        [InlineData("sterrenbeeld", "en", true)] // Search string gevonden in het midden
        [InlineData("sterrenbeeld", "boven", false)] // Search string niet gevonden 
        [InlineData("sterrenbeeld", "sterrenbeelde", false)] // Search string longer than haystack

        public void StringContains_ReturnsExpectedResult(string haystack, string search, bool expectedResult)
        {
            // Arrange 
            var mockProductRepository = new MockProductRepository();
            var productService = new ProductService(mockProductRepository);

            // Act 
            bool result = productService.StringContains(haystack, search);

            // Assert 
            Assert.Equal(expectedResult, result);
        }
    }
}