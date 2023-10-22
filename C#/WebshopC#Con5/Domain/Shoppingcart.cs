using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Shoppingcart
    {
        private Warehouse warehouse;
        private List<Entry> cartEntries;
        private PaymentService paymentService; 



        // shoppingcart created, it needs to know about the warehouse 
        public Shoppingcart(Warehouse warehouseReference)
        {

            warehouse = warehouseReference;
            cartEntries = new List<Entry>();



        }



        public void AddProductToShoppingcart(Product productToAdd, int amount)
        {

            // check if the product is already in shoppingcart. 
            Entry foundEntry = null;


            foreach (Entry entry in cartEntries)
            {

                if (entry.Product == productToAdd)
                {

                    foundEntry = entry;
                    break;

                }

            }



            if (foundEntry != null)
            {

                foundEntry.AddAmount(amount);
            }
            else
            {
                Entry newEntry = new Entry(productToAdd);
                newEntry.AddAmount(amount);
                cartEntries.Add(newEntry);

            }







        }




        public void DeleteProduct(Product productToRemove, int amount)
        {

            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than 0.");

            Entry entryToRemove = null; 
            foreach(Entry entry in cartEntries)
            {

                if(entry.Product == productToRemove)
                {
                    entryToRemove = entry;
                    break; 
                }

            }


            if(entryToRemove != null)
            {

                entryToRemove.DeleteAmount(amount); 
                if(entryToRemove.Amount <= 0)
                {
                    cartEntries.Remove(entryToRemove); 
                }

            } else
            {
                throw new InvalidOperationException("Product not found in shopping cart. ");
            }


        }
       









        public double CalculateTotalPrice()
        {


            double totalPrice = 0;


            foreach (Entry entry in cartEntries)
            {

                double productPrice = warehouse.GetProductPrice(entry.Product);
                totalPrice = totalPrice + (entry.Amount * productPrice);

            }

            return totalPrice;

        }


        public void EmptyShoppingcart()
        {

            cartEntries.Clear();
        }


        public ReadOnlyCollection<Entry> ViewProducts()
        {
            return new ReadOnlyCollection<Entry>(cartEntries);
        }


    }
}
