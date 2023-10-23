using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ProductRepository
    {

        private List<ProductDTO> products;


        public ProductRepository()
        {


            this.products = new List<ProductDTO>()
            { 

            // ToDo: Get product data from database 
            // Hack: hard-coded for now 

         
                new ProductDTO()
                {
                    Name = "HP laptop i9",
                    Description = "i9 64 GB RAM 24 GB graphic card",
                    Price = 4000,
                    Category = Shared.ProductCategory.Electronics,
                    Reviews = new List<ReviewDTO>()
                    {
                        new ReviewDTO() { Comment = "Great laptop", Rating = 5 },
                        new ReviewDTO() { Comment = "Great laptop. Bad side to much noise makes the fan.", Rating = 4 }


                    }




                },


                new ProductDTO()
                {
                    Name = "Macbook Pro i9",
                    Description = "i9 64 GB RAM 24 GB graphic card",
                    Price = 4000,
                    Category = Shared.ProductCategory.Electronics,
                    Reviews = new List<ReviewDTO>()
                    {
                        new ReviewDTO() { Comment = "Great laptop", Rating = 5 },
                        new ReviewDTO() { Comment = "Great laptop. Bad side to much noise makes the fan.", Rating = 4 }


                    }




                },


                new ProductDTO()
                {
                    Name = "HP5 laptop i9",
                    Description = "i9 64 GB RAM 24 GB graphic card",
                    Price = 4000,
                    Category = Shared.ProductCategory.Electronics,
                    Reviews = new List<ReviewDTO>()
                    {
                        new ReviewDTO() { Comment = "Great laptop", Rating = 5 },
                        new ReviewDTO() { Comment = "Great laptop. Bad side to much noise makes the fan.", Rating = 4 }


                    }




                },



                new ProductDTO()
                {
                    Name = "HP6 laptop i9",
                    Description = "i9 64 GB RAM 24 GB graphic card",
                    Price = 4000,
                    Category = Shared.ProductCategory.Electronics,
                    Reviews = new List<ReviewDTO>()
                    {
                        new ReviewDTO() { Comment = "Great laptop", Rating = 5 },
                        new ReviewDTO() { Comment = "Great laptop. Bad side to much noise makes the fan.", Rating = 4 }


                    }




                },


                new ProductDTO()
                {
                    Name = "Puma jacket",
                    Description = "Large Puma jacket men.",
                    Price = 125,
                    Category = Shared.ProductCategory.Clothing,

                    Reviews = new List<ReviewDTO>()
                    {
                        new ReviewDTO() { Comment = "Comfortable jacket", Rating = 5 },
                        new ReviewDTO() { Comment = "To expensive", Rating = 1 },
                        new ReviewDTO() { Comment = "good price and good quality. Not much colors", Rating = 4 }

                    }

                },


                new ProductDTO()
                {
                    Name = "Puma jacket2",
                    Description = "Large Puma jacket men.",
                    Price = 125,
                    Category = Shared.ProductCategory.Clothing,

                    Reviews = new List<ReviewDTO>()
                    {
                        new ReviewDTO() { Comment = "Comfortable jacket", Rating = 5 },
                        new ReviewDTO() { Comment = "To expensive", Rating = 1 },
                        new ReviewDTO() { Comment = "good price and good quality. Not much colors", Rating = 4 }

                    }

                },

                new ProductDTO()
                {
                    Name = "Puma jacket4",
                    Description = "Large Puma jacket men.",
                    Price = 125,
                    Category = Shared.ProductCategory.Clothing,

                    Reviews = new List<ReviewDTO>()
                    {
                        new ReviewDTO() { Comment = "Comfortable jacket", Rating = 5 },
                        new ReviewDTO() { Comment = "To expensive", Rating = 1 },
                        new ReviewDTO() { Comment = "good price and good quality. Not much colors", Rating = 4 }

                    }

                },


                new ProductDTO()
                {
                    Name = "Puma jacket10",
                    Description = "Large Puma jacket men.",
                    Price = 125,
                    Category = Shared.ProductCategory.Clothing,

                    Reviews = new List<ReviewDTO>()
                    {
                        new ReviewDTO() { Comment = "Comfortable jacket", Rating = 5 },
                        new ReviewDTO() { Comment = "To expensive", Rating = 1 },
                        new ReviewDTO() { Comment = "good price and good quality. Not much colors", Rating = 4 }

                    }

                }






        };

        }





        public bool UpdateProduct(string productName, ProductDTO updateProduct)
        {


            ProductDTO product = null;

            foreach (ProductDTO p in products)
            {

                if (p.Name == productName)
                {
                    product = p;
                    break;

                }

            }



            if (product == null)
            {
                return false;
            }



            product.Name = updateProduct.Name;
            product.Description = updateProduct.Description;
            product.Price = updateProduct.Price;
            product.Category = updateProduct.Category;
            product.Reviews = updateProduct.Reviews;

            return true;


        }









        public List<ProductDTO> GetAllProducts()
        {
            return products;
        }






        /*

        public List<ProductDTO> GetAllProducts()
        {

            // ToDo: Get product data from database 
            // Hack: hard-coded for now 

            return new List<ProductDTO>()
            {

                new ProductDTO()
                {
                    Name = "HP laptop i9",
                    Description = "i9 64 GB RAM 24 GB graphic card",
                    Price = 4000,
                    Category = Shared.ProductCategory.Electronics,
                    Reviews = new List<ReviewDTO>()
                    {
                        new ReviewDTO() { Comment = "Great laptop", Rating = 5 },
                        new ReviewDTO() { Comment = "Great laptop. Bad side to much noise makes the fan.", Rating = 4 }


                    }




                },


                new ProductDTO()
                {
                    Name = "Macbook Pro i9",
                    Description = "i9 64 GB RAM 24 GB graphic card",
                    Price = 4000,
                    Category = Shared.ProductCategory.Electronics,
                    Reviews = new List<ReviewDTO>()
                    {
                        new ReviewDTO() { Comment = "Great laptop", Rating = 5 },
                        new ReviewDTO() { Comment = "Great laptop. Bad side to much noise makes the fan.", Rating = 4 }


                    }




                },


                new ProductDTO()
                {
                    Name = "HP5 laptop i9",
                    Description = "i9 64 GB RAM 24 GB graphic card",
                    Price = 4000,
                    Category = Shared.ProductCategory.Electronics,
                    Reviews = new List<ReviewDTO>()
                    {
                        new ReviewDTO() { Comment = "Great laptop", Rating = 5 },
                        new ReviewDTO() { Comment = "Great laptop. Bad side to much noise makes the fan.", Rating = 4 }


                    }




                },



                new ProductDTO()
                {
                    Name = "HP6 laptop i9",
                    Description = "i9 64 GB RAM 24 GB graphic card",
                    Price = 4000,
                    Category = Shared.ProductCategory.Electronics,
                    Reviews = new List<ReviewDTO>()
                    {
                        new ReviewDTO() { Comment = "Great laptop", Rating = 5 },
                        new ReviewDTO() { Comment = "Great laptop. Bad side to much noise makes the fan.", Rating = 4 }


                    }




                },


                new ProductDTO()
                {
                    Name = "Puma jacket",
                    Description = "Large Puma jacket men.",
                    Price = 125,
                    Category = Shared.ProductCategory.Clothing,

                    Reviews = new List<ReviewDTO>()
                    {
                        new ReviewDTO() { Comment = "Comfortable jacket", Rating = 5 },
                        new ReviewDTO() { Comment = "To expensive", Rating = 1 },
                        new ReviewDTO() { Comment = "good price and good quality. Not much colors", Rating = 4 }

                    }

                },


                new ProductDTO()
                {
                    Name = "Puma jacket2",
                    Description = "Large Puma jacket men.",
                    Price = 125,
                    Category = Shared.ProductCategory.Clothing,

                    Reviews = new List<ReviewDTO>()
                    {
                        new ReviewDTO() { Comment = "Comfortable jacket", Rating = 5 },
                        new ReviewDTO() { Comment = "To expensive", Rating = 1 },
                        new ReviewDTO() { Comment = "good price and good quality. Not much colors", Rating = 4 }

                    }

                },

                new ProductDTO()
                {
                    Name = "Puma jacket4",
                    Description = "Large Puma jacket men.",
                    Price = 125,
                    Category = Shared.ProductCategory.Clothing,

                    Reviews = new List<ReviewDTO>()
                    {
                        new ReviewDTO() { Comment = "Comfortable jacket", Rating = 5 },
                        new ReviewDTO() { Comment = "To expensive", Rating = 1 },
                        new ReviewDTO() { Comment = "good price and good quality. Not much colors", Rating = 4 }

                    }

                },


                new ProductDTO()
                {
                    Name = "Puma jacket10",
                    Description = "Large Puma jacket men.",
                    Price = 125,
                    Category = Shared.ProductCategory.Clothing,

                    Reviews = new List<ReviewDTO>()
                    {
                        new ReviewDTO() { Comment = "Comfortable jacket", Rating = 5 },
                        new ReviewDTO() { Comment = "To expensive", Rating = 1 },
                        new ReviewDTO() { Comment = "good price and good quality. Not much colors", Rating = 4 }

                    }

                }



            };
        }  */
    }
}

