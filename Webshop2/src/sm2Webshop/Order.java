package sm2Webshop;

import java.util.ArrayList;
import java.util.List;

public class Order {

	private List<Product> orderedProducts;

	public Order() {

	}

	public Order(List<Product> products) {

		this.orderedProducts = new ArrayList<>(products);

	}

	public double getTotalPrice() {

		double total = 0;

		// for each loop. iterate over each element of a collection.
		// List iterating over each Product in the orderedProducts list.

		for (Product product : orderedProducts) {

			total = total + product.getPrice();

		}
		return total;
	}

	// Override toString() method from the superclass.

	@Override
	public String toString() {

		String result = "Products in this order:\n";

		// looping through Ordered Products
		for (Product product : orderedProducts) {

			result = result + product.getName() + " - €" + product.getPrice() + "\n";

		}

		result = result + "Total price: €" + getTotalPrice();

		return result;

	}

}
