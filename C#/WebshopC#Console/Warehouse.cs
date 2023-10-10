using System;

public class Warehouse
{


    public List<Entry> Entries { get; }


    public Warehouse()
    {

        Entries = new List<Entry>();

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


            if (entry.Product == product)
            {

                entry.Amount += amount;

                productFound = true;

                break; // exit the loop. 


            }



        }



        if (!productFound)
        {


            Entry newEntry = new Entry();
            newEntry.Product = product;
            newEntry.Amount = amount;

            Entries.Add(newEntry);


        }




    }


    // 




    public void DeleteProduct(Product product, int amount)
    {

        foreach (Entry entry in Entries)
        {

            if (entry.Product == product)
            {


                return entry.Amount;
            }

        }


        // If no matching entry is found, return 0. 
        return 0;
    }





