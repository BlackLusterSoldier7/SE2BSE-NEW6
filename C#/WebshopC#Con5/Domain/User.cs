using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {

        public string Username { get; }
        public string Password { get; }
        public string Email { get; }
        public string firstname { get; }
        public string lastname { get; }


        public Shoppingcart shoppingCart { get; }


        public User(string username, Shoppingcart shoppingcart)
        {

            this.Username = username;
        }

        public bool AddReview(Product product, int score, string comment)
        {
            if (product == null) return false;
            if (score < 1 || score > 5) return false;

            // Create a new review 
            Review newReview = new Review(this, product, comment, score);

            bool isReviewedAdded = product.AddReview(newReview);

            return isReviewedAdded; 




        }








    }

}
