using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Domain
{

    public class Shoppingcart
    {



        private Warehouse warehouse;


        private List<Entry> cartEntries;


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

                if (entry.GetProduct() == productToAdd)
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


            foreach (Entry entry in cartEntries)
            {

                // descrease the amount of the product in the shoppingcart. 
                entry.DeleteAmount(amount);

                // if there is none of the product left in the cart, remove its entry
                if (entry.GetAmount() <= 0)
                {

                    cartEntries.Remove(entry);

                }
                break;

            }


        }



        public double CalculateTotalPrice()
        {


            double totalPrice = 0;


            foreach (Entry entry in cartEntries)
            {

                double productPrice = warehouse.GetProductPrice(entry.GetProduct());
                totalPrice = totalPrice + (entry.GetAmount() * productPrice);

            }

            return totalPrice;

        }


        public void EmptyShoppingcart()
        {

            cartEntries.Clear();
        }




    }
}
