using Domain;
using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class WarehouseTests
    {
        // Verwijderen van een groter aantal dan aanwezig
        [Fact]
        public void VerwijderenVanEenGroterAantalDanAanwezig()
        {
            // Arrange 
            var mockWarehouse = new MockWarehouse();
            var product = new Product("Playstation 5", "Disk edition", 775, Shared.ProductCategory.Electronics);

            // Act
            mockWarehouse.AddProduct(product, 10);
            var result = mockWarehouse.DeleteProduct(product, 20);

            Assert.Equal(10, result);
            Assert.Empty(mockWarehouse.Entries);
        }

        [Fact]
        public void DeleteProduct_ShouldReturnZero_WhenProductNotInWarehouse()
        {
            // Arrange 
            var mockWarehouse = new MockWarehouse();
            var product = new Product("Playstation 5", "Disk edition", 775, Shared.ProductCategory.Electronics);

            // Act 
            var result = mockWarehouse.DeleteProduct(product, 1);

            Assert.Equal(0, result);
        }

        [Fact]
        public void AddProduct_ShouldNotAdd_WhenAmountIsNegative()
        {
            // Arrange 
            var mockWarehouse = new MockWarehouse();
            var product = new Product("Playstation 5", "Disk edition", 775, Shared.ProductCategory.Electronics);

            // Act 
            mockWarehouse.AddProduct(product, -5);

            // Assert 
            Assert.Empty(mockWarehouse.Entries);
        }

        [Fact]
        public void AddProduct_AddsNewEntry_WhenProductNotInEntries()
        {
            // Arrange
            var mockWarehouse = new MockWarehouse();
            var product = new Product("Playstation 5", "Disk edition", 775, Shared.ProductCategory.Electronics);

            // Act 
            mockWarehouse.AddProduct(product, 6);

            // Assert 
            // Verifieert dat er een entry is in de Entries property van de warehouse. 
            Assert.Single(mockWarehouse.Entries);
            var entry = mockWarehouse.Entries[0];
            // Controleert of het Product-object dat in Entry is opgeslagen, 
            // overeenkomt met het oorspronkelijke product dat is toegevoegd. 
            // check of juiste product is toegevoegd. 
            Assert.Equal(product, entry.Product);
            // Controle of de hoeveelheid van het product 
            // dat aan warehouse is toegevoegd correct is. 
            Assert.Equal(6, entry.Amount);
        }

        [Fact]
        public void AddProduct_IncreaseAmount_WhenProductAlreadyInEntries()
        {
            // Arrange 
            var mockWarehouse = new MockWarehouse();
            var product = new Product("Playstation 5", "Digital Edition", 445, Shared.ProductCategory.Electronics);

            mockWarehouse.AddProduct(product, 3);

            // Act 
            mockWarehouse.AddProduct(product, 2);

            // Assert 
            Assert.Single(mockWarehouse.Entries);
            var entry = mockWarehouse.Entries[0];
            Assert.Equal(product, entry.Product);
            Assert.Equal(5, entry.Amount);
        }

        [Fact]
        public void DeleteProduct_DecreaseAmount_WhenProductInEntries()
        {
            // Arrange 
            var mockWarehouse = new MockWarehouse();
            var product = new Product("Playstation 6", "Disk Edition", 1600, Shared.ProductCategory.Electronics);

            // Act 
            mockWarehouse.AddProduct(product, 5);
            var remainingAmount = mockWarehouse.DeleteProduct(product, 3);

            // Assert 
            Assert.Equal(2, remainingAmount);
        }

        [Fact]
        public void DeleteProduct_RemovesEntry_WhenAmountBecomesZero()
        {
            // Arrange 
            var mockWarehouse = new MockWarehouse();
            var product = new Product("HP-Desktop", "HP Gaming desktop. i9, 128 GB Graphic card. ", 1600, Shared.ProductCategory.Electronics);

            // Act 

            // De AddProduct-methode van warehouse wordt aangeroepen om twee units van het 
            // product aan warehouse object toe te voegen. 
            mockWarehouse.AddProduct(product, 2);
            var remainingAmount = mockWarehouse.DeleteProduct(product, 2);

            // Assert 
            // Empty checks of de Entries van de warehouse leeg is nadat het product 
            // is verwijderd. Indien het leeg is is deze test geslaagd. 
            Assert.Empty(mockWarehouse.Entries);
            Assert.Equal(0, remainingAmount);
        }

        //[Fact]
        //public void AddProduct_AddsNewEntry_WhenProductNotInEntries()
        //{
        //    // Arrange 
        //    var warehouse = new Warehouse();
        //    var product = new Product("Playstation 5", "Disk edition", 775, Shared.ProductCategory.Electronics);

        //    // Act 
        //    warehouse.AddProduct(product, 3);

        //    // Assert 
        //    // Verifieert dat er een entry is in de Entries property van de warehouse. 
        //    Assert.Single(warehouse.Entries);
        //    var entry = warehouse.Entries[0];
        //    // Controleert of het Product-object dat in Entry is opgeslagen, 
        //    // overeenkomt met het oorspronkelijke product dat is toegevoegd. 
        //    // check of juiste product is toegevoegd. 
        //    Assert.Equal(product, entry.Product);
        //    // Controle of de hoeveelheid van het product 
        //    // dat aan warehouse is toegevoegd correct is. 
        //    Assert.Equal(3, entry.Amount);
        //}

        //[Fact]
        //public void AddProduct_IncreaseAmount_WhenProductAlreadyInEntries()
        //{
        //    // Arrange 
        //    var warehouse = new Warehouse();
        //    var product = new Product("Playstation 5", "Digital Edition", 445, Shared.ProductCategory.Electronics);
        //    warehouse.AddProduct(product, 3);

        //    // Act 
        //    warehouse.AddProduct(product, 2);

        //    // Assert 
        //    Assert.Single(warehouse.Entries);
        //    var entry = warehouse.Entries[0];
        //    Assert.Equal(product, entry.Product);
        //    Assert.Equal(5, entry.Amount);
        //}

        //[Fact]
        //public void DeleteProduct_DecreaseAmount_WhenProductInEntries()
        //{
        //    // Arrange 
        //    var warehouse = new Warehouse();
        //    var product = new Product("Playstation 6", "Disk Edition", 1600, Shared.ProductCategory.Electronics);
        //    warehouse.AddProduct(product, 5);

        //    // Act 
        //    var remainingAmount = warehouse.DeleteProduct(product, 3);

        //    // Assert 
        //    Assert.Equal(2, remainingAmount);
        //}

        //[Fact]
        //public void DeleteProduct_RemovesEntry_WhenAmountBecomesZero()
        //{
        //    // Arrange 
        //    var warehouse = new Warehouse();
        //    var product = new Product("TestProduct27", "TestProduct desc", 999.75, Shared.ProductCategory.Electronics);

        //    // De AddProduct-methode van warehouse wordt aangeroepen om twee units van het 
        //    // product aan warehouse object toe te voegen. 
        //    warehouse.AddProduct(product, 2);

        //    // Act 
        //    var remainingAmount = warehouse.DeleteProduct(product, 2);

        //    // Assert 
        //    // Empty checks of de Entries van de warehouse leeg is nadat het product 
        //    // is verwijderd. Indien het leeg is is deze test geslaagd. 
        //    Assert.Empty(warehouse.Entries);
        //    Assert.Equal(0, remainingAmount);
        //}
    }
}