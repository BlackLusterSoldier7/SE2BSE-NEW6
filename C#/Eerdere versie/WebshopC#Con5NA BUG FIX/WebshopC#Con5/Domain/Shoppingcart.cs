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

                if (entry.Product.Discount != null)
                {
                    pricePerProduct = entry.Product.Discount.ApplyDiscount(pricePerProduct);
                }
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








//        private Warehouse warehouse;
//        // private List<Entry> cartEntries;
//        private PaymentService paymentService;


//        public string CouponCode { get; set; }


//        public List<Entry> cartEntries { get; private set; }






//        // shoppingcart created, it needs to know about the warehouse 
//        public shoppingcart(warehouse warehousereference)
//        {

//            warehouse = warehousereference;
//            cartentries = new list<entry>();



//        }



//        public void AddProductToShoppingcart(Product productToAdd, int amount)
//        {

//            // check if the product is already in shoppingcart. 
//            Entry? foundEntry = null;


//            foreach (Entry entry in cartEntries)
//            {

//                if (entry.Product == productToAdd)
//                {

//                    foundEntry = entry;
//                    break;

//                }

//            }



//            if (foundEntry != null)
//            {

//                foundEntry.AddAmount(amount);
//            }
//            else
//            {
//                Entry newEntry = new Entry(productToAdd);
//                newEntry.AddAmount(amount);
//                cartEntries.Add(newEntry);

//            }







//        }




//        public void DeleteProduct(Product productToRemove, int amount)
//        {

//            if (amount <= 0)
//            {
//                throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than 0.");

//            }


//            Entry entryToRemove = null;
//            foreach (Entry entry in cartEntries)
//            {

//                if (entry.Product == productToRemove)
//                {
//                    entryToRemove = entry;
//                    break;
//                }

//            }


//            if (entryToRemove != null)
//            {

//                entryToRemove.DeleteAmount(amount);
//                if (entryToRemove.Amount <= 0)
//                {
//                    cartEntries.Remove(entryToRemove);
//                }

//            }
//            else
//            {
//                throw new InvalidOperationException("Product not found in shopping cart. ");
//            }


//        }





//        public double CalculateTotalPrice()
//        {



//            double total = 0;

//            foreach (Entry entry in cartEntries)
//            {

//                double pricePerProduct = entry.Product.Price;


//                if (entry.Product.Discount != null)
//                {

//                    pricePerProduct = entry.Product.Discount.ApplyDiscount(pricePerProduct);

//                }


//                total += pricePerProduct * entry.Amount;




//            }

//            return total;


//        }








//        /*

//        public double CalculateTotalPrice()
//        {


//            double totalPrice = 0;


//            foreach (Entry entry in cartEntries)
//            {

//                double productPrice = warehouse.GetProductPrice(entry.Product);
//                totalPrice += entry.Amount * productPrice;

//            }

//            return totalPrice;

//        } */


//        public void EmptyShoppingcart()
//        {

//            cartEntries.Clear();
//        }


//        public ReadOnlyCollection<Entry> ViewProducts()
//        {
//            return new ReadOnlyCollection<Entry>(cartEntries);
//        }


//    }
//}