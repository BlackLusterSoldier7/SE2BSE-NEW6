package logicDomainLayer;

import java.util.ArrayList;
import java.util.List;

public class Shoppingcart {

	private List<Product> products;

	public Shoppingcart() {

		this.products = new ArrayList<>();

	}

	public List<Product> getProducts() {

		return products;

	}

	public void setProducts(List<Product> products) {

		this.products = products;
	}

	public void addProduct(Product product) {

		if (product != null) {

			products.add(product);

		}

	}
	
	
	
	public Order convertToOrder() {

		Order order = new Order(products);
		// empty the products list in the shoppingCart instance.
		// preventing duplicate orders
		products.clear();
		return order;

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
	
	
	public boolean contains(Product product) {
		
		return products.contains(product); 
		
		
	}

}
