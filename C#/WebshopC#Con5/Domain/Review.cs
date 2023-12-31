using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Review
    {
        public User Author { get; }
        public Product ReviewedProduct { get; }

        public string Text { get; }

        public int Rating { get; }

        public DateTime Date { get; }

        public Review(User author, Product product, string text, int rating)
        {
            Author = author;
            ReviewedProduct = product;
            Text = text;
            Rating = rating;
            Date = DateTime.Now; // Current date 
        }
    }
}