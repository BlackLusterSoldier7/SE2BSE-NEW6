using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {

        private string name;
        private string description;
        private double price;
       
        private List<Review> reviews;





        public Product(string name, string description, double price)
        {

            this.name = name;
            this.description = description;
            this.price = price;
            this.reviews = new List<Review>(); // Initialize the reviews list 
        
        }





        // Properties 

        public string Name
        {
            get { return name; }
        }


        public string Description
        {

            get { return description; }
        }


        public double Price
        {

            get { return price; }

        }


    

        
        public bool AddReview(Review review)
        {

            if (review == null) return false;
            reviews.Add(review);
            return true; 

        }


        // method to get all reviews for a product 
        public List<Review> GetAllReviews()
        {

            return new List<Review>(reviews); // Return a copy to prevent external modification

            
        }






    }
}
