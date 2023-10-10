using System;

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

		foreach(Entry entry in cartEntries)
		{

			

		}



	}




	


}
