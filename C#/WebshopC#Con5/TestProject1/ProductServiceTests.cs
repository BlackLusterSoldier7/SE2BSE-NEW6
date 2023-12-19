﻿using Domain;
using Infrastructure.DTO;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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