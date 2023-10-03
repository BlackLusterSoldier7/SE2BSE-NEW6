package sm2Webshop;

import java.util.ArrayList;
import java.util.List;

public class Seller extends User {

	// Ordered collection of elements.
	private List<Product> products;

	public Seller(String username, String password, String email, String firstname, String lastname) {

		super(new UserProfile(username, password, email, firstname, lastname));
		this.products = new ArrayList<>();

	}

	public void addProduct(Product product) {

		if (product == null) {

			throw new NullPointerException("Product kan niet null zijn");
		}

		this.products.add(product);

	}

	public List<Product> getProducts() {

		return products;

	}

	public boolean contains(Product product) {

		return products.contains(product);

	}

}
