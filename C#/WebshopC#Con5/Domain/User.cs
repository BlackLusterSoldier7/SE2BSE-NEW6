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
        public string Username { get; private set; }
        private string Password { get; set; }
        public string Email { get; private set; }
        public string firstname { get; private set; }
        public string lastname { get; private set; }

        public Shoppingcart shoppingCart { get; private set; }

        public List<string> SearchHistory { get; private set; }

        public bool IsNewUser { get; private set; }

        public User(string username, Warehouse warehouse)
        {
            this.Username = username;
            // shoppingCart = new Shoppingcart(warehouse); origineel oude code 

            shoppingCart = new Shoppingcart(null); // om te testen 
            SearchHistory = new List<string>();
        }

        public User(string username, Warehouse warehouse, bool isNewUser = true)
        {
            Username = username;
            // shoppingCart = new Shoppingcart(warehouse); origineel oude code 
            shoppingCart = new Shoppingcart(null); // om te testen 
            SearchHistory = new List<string>();
            IsNewUser = isNewUser;
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