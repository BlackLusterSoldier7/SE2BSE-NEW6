using System.ComponentModel;



namespace XUnitTestWebshop
{
    public class UnitTest1
    {



        [Fact]
        public void BubbleSortLowToHighPricesAscending_CheckSortCorrectly()
        {




            // Arrange 
            var category = new Category("Electronics", "Toys");
            var products = new List<ProductDTO>
            {
                new ProductDTO { Price = 50 },
                new ProductDTO { Price = 30 },
                new ProductDTO { Price = 70 },
                new ProductDTO { Price = 20 },


            };












        }
    }
}