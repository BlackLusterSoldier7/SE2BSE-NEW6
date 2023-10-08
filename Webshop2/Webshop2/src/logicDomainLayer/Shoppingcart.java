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

	public void addProduct(Product product) {

		if (product != null) {

			products.add(product);

		}

	}

	// deze methode scheiden ivm single
	public Order convertToOrder() {

		Order order = new Order();
		order.addProduct(new Product("iPhone 15", 2000, "256 GB"));

		products.clear(); // maak de lijst van producten in winkelwagen leeg
		return order;

	}

	public boolean contains(Product product) {

		return products.contains(product);

	}

}
