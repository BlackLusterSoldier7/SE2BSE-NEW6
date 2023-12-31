using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Shoppingcart
    {
        private readonly IWarehouse warehouse;
        //private readonly List<Entry> cartEntries;

        public List<Entry> cartEntries { get; private set; }

        public string CouponCode { get; set; }

        public Shoppingcart(IWarehouse warehouse)
        {
            this.warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse));
            cartEntries = new List<Entry>();
        }

        public double CalculateTotalPrice()
        {
            double total = 0;
            foreach (var entry in cartEntries)
            {
                double pricePerProduct = entry.Product.Price;

               /* if (entry.Product.Discount != null)
                {
                    pricePerProduct = entry.Product.Discount.ApplyDiscount(pricePerProduct);
                }*/
                total += pricePerProduct * entry.Amount;
            }
            return total;
        }

        public ReadOnlyCollection<Entry> ViewProducts()
        {
            return cartEntries.AsReadOnly();
        }

        public void AddProductToShoppingcart(Product product, int amount)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than 0.");
            }

            Entry entryFound = null;

            foreach (var entry in cartEntries)
            {
                if (entry.Product == product)
                {
                    entryFound = entry;
                    break;
                }
            }

            if (entryFound != null)
            {
                entryFound.AddAmount(amount);
            }
            else
            {
                cartEntries.Add(new Entry(product, amount));
            }
        }
    }
}