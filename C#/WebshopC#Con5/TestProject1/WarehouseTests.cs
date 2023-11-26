using Domain;
using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class WarehouseTests
    {
        [Fact]
        public void AddProduct_AddsNewEntry_WhenProductNotInEntries()
        {
            // Arrange 
            var warehouse = new Warehouse();
            var product = new Product("Playstation 5", "Disk edition", 775, Shared.ProductCategory.Electronics);

            // Act 
            warehouse.AddProduct(product, 3);

            // Assert 
            // Verifieert dat er een entry is in de Entries property van de warehouse. 
            Assert.Single(warehouse.Entries);
            var entry = warehouse.Entries[0];
            // Controleert of het Product-object dat in Entry is opgeslagen, 
            // overeenkomt met het oorspronkelijke product dat is toegevoegd. 
            // check of juiste product is toegevoegd. 
            Assert.Equal(product, entry.Product);
            // Controle of de hoeveelheid van het product 
            // dat aan warehouse is toegevoegd correct is. 
            Assert.Equal(3, entry.Amount);
        }

        [Fact]
        public void AddProduct_IncreaseAmount_WhenProductAlreadyInEntries()
        {
            // Arrange 
            var warehouse = new Warehouse();
            var product = new Product("Playstation 5", "Digital Edition", 445, Shared.ProductCategory.Electronics);
            warehouse.AddProduct(product, 3);

            // Act 
            warehouse.AddProduct(product, 2);

            // Assert 
            Assert.Single(warehouse.Entries);
            var entry = warehouse.Entries[0];
            Assert.Equal(product, entry.Product);
            Assert.Equal(5, entry.Amount);
        }

        [Fact]
        public void DeleteProduct_DecreaseAmount_WhenProductInEntries()
        {
            // Arrange 
            var warehouse = new Warehouse();
            var product = new Product("Playstation 6", "Disk Edition", 1600, Shared.ProductCategory.Electronics);
            warehouse.AddProduct(product, 5);

            // Act 
            var remainingAmount = warehouse.DeleteProduct(product, 3);

            // Assert 
            Assert.Equal(2, remainingAmount);
        }
    }
}