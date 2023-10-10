using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopC_Console;

public class Warehouse
{


    public List<Entry> Entries { get; private set; }

    private List<Product> products;







    public Warehouse()
    {

        Entries = new List<Entry>();
        products = new List<Product>();
    }



    public void AddProduct(Product product, int amount)
    {

        if (product == null)
        {


            return; // exit method 
        }


        bool productFound = false;

        foreach (Entry entry in Entries)
        {


            if (entry.GetProduct() == product)
            {

                entry.AddAmount(amount);

                productFound = true;

                break; // exit the loop. 


            }



        }



        if (!productFound)
        {


            Entry newEntry = new Entry(product);
            newEntry.AddAmount(amount);
            Entries.Add(newEntry);


        }




    }


    // 




    public int DeleteProduct(Product product, int amount)
    {

        foreach (Entry entry in Entries)
        {

            if (entry.GetProduct() == product)
            {


                entry.DeleteAmount(amount);

                if (entry.GetAmount() <= 0)
                {
                    Entries.Remove(entry);
                }



                return entry.GetAmount();
            }

        }


        // If no matching entry is found, return 0. 
        return 0;
    }








    public double GetProductPrice(Product productToFind)
    {

        foreach (Product product in products)
        {

            if (product.Name == productToFind.Name)
            {

                return product.Price;

            }

        }


        // Product not found in the warehouse 
        return 0;



    }






}
