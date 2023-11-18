using Infrastructure.DTO;
using Shared;
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

        public ProductCategory Category { get; }


        public Discount Discount { get; private set; }

        private List<string> KeyWords { get; set; }


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



        public Product(string name, string description, double price, Discount discount)
        {

            this.name = name;
            this.description = description;
            this.price = price;
            this.reviews = new List<Review>(); // Initialize the reviews list 
            // this.Category = category;
            Discount = discount;

        }









        public Product(string name, string description, double price, ProductCategory category)
        {

            this.name = name;
            this.description = description;
            this.price = price;
            this.reviews = new List<Review>(); // Initialize the reviews list 
            this.Category = category;
            KeyWords = new List<string>(); // Initialize KeyWords

        }



        public int QueryHits(string query)
        {
            // woorden opdelen uit query
            List<string> queryWords = SplitWords(query);

            // zoek in keywords voor de woorden uit de query
            int hits = 0;
            foreach (string keyWord in KeyWords)
            {
                foreach (string queryWord in queryWords)
                {
                    if (queryWord == keyWord)
                    {
                        hits++;
                        break;
                    }
                }
            }

            // return aantal hits
            return hits;
        }

        private List<string> SplitWords(string sentence)
        {
            // laptop ssd 16gb ram
            string acc = "";
            List<string> words = new List<string>();
            foreach (char c in sentence.Trim())
            {
                if (c != ' ')
                {
                    acc += c;
                }
                // check acc for content to not insert empty string on multiple spaces
                else if (acc != "")
                {
                    words.Add(acc);
                    acc = "";
                }
            }

            // put last word in list
            if (acc == "")
            {
                words.Add(acc);
            }

            return words;
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
