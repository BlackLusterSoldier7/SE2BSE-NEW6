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





        /*

        De methode SplitWords wordt in de methode QueryHits gebruikt om een zoekopdracht 
        in losse woorden op te splitsen, zodat deze woorden kunnen worden vergeleken
        met keywords die gekoppeld zijn aan Producten. 
        Hierdoor kan de QueryHits methode tellen hoeveel woorden uit de zoekopdracht 
        overeenkomen met de keywords die aan product zijn gekoppeld en het aantal 
        hits retourneren. 


        */



        private List<string> SplitWords(string sentence)
        {
            // laptop ssd 16gb ram

            // acc variabel wordt gebruikt om characters te verzamelen
            // om een woord te vormen. 

            string acc = "";
            List<string> words = new List<string>();
            foreach (char c in sentence.Trim())
            {

                // Als c geen spatieteken is (dat wil zeggen: het is een deel van een woord), 
                // wordt het toegevoegd aan de accumulate string. Dit wordt gedaan om karakters
                // te verzamelen en woorden te bouwen. 

                if (c != ' ')
                {
                    acc += c;
                }

                // Als c een spatie is, betekent dit dat het huidige woord compleet is.
                // In mij geval controleert de code of accumulate geen lege string is (
                // dat wil zeggen dat het tekens bevat). Als acc niet leeg is, beekent dit 
                // dat er een woord is verzameld in acc, dan wordt het toegevoegd aan de 
                // woordenlijst en wordt acc reset lege string reset gedaan. 
                // Vervolgens kan het beginnen met het verzamelen van het volgende woord. 



                else if (acc != "")
                {
                    words.Add(acc);
                    acc = "";
                }
            }



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
