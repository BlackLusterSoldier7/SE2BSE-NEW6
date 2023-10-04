package logicDomainLayer;

import DTO.UserDTO;

// inherit from super class User 
public class Buyer extends User {

	// associaton Buyer with ShoppingCart class

	private Shoppingcart shoppingcart;

	public Buyer(String username, String password, String email, String firstname, String lastname) {

		super(new UserDTO(username, password, email, firstname, lastname));

		this.shoppingcart = new Shoppingcart();

	}

	public void addProductToCart(Product product) {

		this.shoppingcart.addProduct(product);

	}

}
