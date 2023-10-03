package sm2Webshop;

import java.util.ArrayList;
import java.util.List;

public class ShoppingCart {

	private List<Product> products;

	public ShoppingCart() {

		this.products = new ArrayList<>();

	}

	public void addProduct(Product product) {

		if (product != null) {

			products.add(product);
			 //System.out.println(product.getName() + " has been added to your personal
			// shopping cart object. ");

		} else {
			System.out.println("Can not add to shopping cart the product ");

		}

	}

	public void viewProducts() {

		if (products.isEmpty()) {

			System.out.println("Your Shopping Cart is empty. ");
		

		}

		System.out.println("The next Products you have in your Shopping Cart: ");
		for (Product product : products) {

			System.out.println("- " + product.getName() + ": €" + product.getPrice());

		}

	}

	public Order convertToOrder() {

		Order order = new Order(products);
		// empty the products list in the shoppingCart instance.
		// preventing duplicate orders
		products.clear();
		return order;

	}
	
	
	
	
	public boolean contains(Product product) {
		
		return products.contains(product); 
		
		
	}
	
	
	

}
