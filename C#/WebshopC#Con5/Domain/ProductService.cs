
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    // Handles product-related business logic 

    public class ProductService
    {
        private readonly IProductRepository productRepository;

        // private ProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public List<ProductDTO> GetAllProducts()
        {
            return productRepository.GetAllProducts();
        }

        public List<ProductDTO> GetSearchHistoryRecommendations(User user)
        {
            List<string> recentSearches = new List<string>();

            // Limit the number of recent searches to the first 5 elements. 
            int count = 0;
            foreach (string searchQuery in user.SearchHistory)
            {
                if (count >= 5)
                {
                    break;
                }
                recentSearches.Add(searchQuery);
                count++;
            }

            List<ProductDTO> allProducts = productRepository.GetAllProducts();
            List<ProductDTO> recommendations = new List<ProductDTO>();

            foreach (string searchQuery in recentSearches)
            {
                foreach (ProductDTO product in allProducts)
                {
                    if (StringContains(product.Name.ToLower(), searchQuery))
                    {
                        recommendations.Add(product);
                    }
                }
            }

            // Remove duplicates 
            List<ProductDTO> distinctRecommendations = new List<ProductDTO>();
            foreach (ProductDTO product in recommendations)
            {
                if (!distinctRecommendations.Contains(product))
                {
                    distinctRecommendations.Add(product);
                }
            }
            return distinctRecommendations;
        }

        public bool StringContains(string hayStack, string search)
        {
            for (int i = 0; i < hayStack.Length - (search.Length); i++)
            {
                for (int j = 0; j < search.Length; j++)
                {
                    if (hayStack[i + j] == search[j])
                    {
                        if (j == (search.Length - 1))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return false;
        }
    }
}