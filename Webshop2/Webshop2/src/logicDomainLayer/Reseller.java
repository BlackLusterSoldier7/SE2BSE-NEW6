package logicDomainLayer;

import java.util.ArrayList;
import java.util.List;

import DTO.UserDTO;

public class Reseller extends User {

	// Ordered collection of elements.
	private List<Product> products;

	public Reseller(String username, String password, String email, String firstname, String lastname) {

		super(new UserDTO(username, password, email, firstname, lastname));
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
